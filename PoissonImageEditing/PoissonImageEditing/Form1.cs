using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;

// Math.Net Numerics Library.
// Using 'LA.Matrix' to avoid conflit with Emgu.CV.Matrix
using MathNet.Numerics;
using LA = MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double.Solvers;
using MathNet.Numerics.LinearAlgebra.Solvers;

namespace PoissonImageEditing
{
    public partial class FormImageEditing : Form
    {
        private Image<Bgr, Byte>    srcImg, tarImg;

        private int                 srcWidth, srcHeight;
        private int                 tarWidth, tarHeight;

        // Control of drawing boundry on the source image
        private Image<Bgr, Byte>    newSrcImg;
        private bool                isDrawing;
        private List<Point>         clickList;
        private List<Point>         boundryList;
        private int                 selWidth, selHeight;

        // List of content point, and mapping to id
        private List<Point>         contentList;
        private Point[]             contentArray;
        private Point               selCenterPoint;

        // [0...]: content point, -1: boundry point, -2: other
        private int[,]              pointID;

        // Control of placing the selected image on the target image
        private Image<Bgr, Byte>    newTarImg;
        private bool                isPlacing;
        private Point               placeCenterPoint;

        // Bias from selected source image to the target image
        private int                 biasX, biasY;

        // Result of the cloning
        private Image<Bgr, Byte>    resultImg;

        public FormImageEditing()
        {
            InitializeComponent();

            clickList = new List<Point>();
            boundryList = new List<Point>();
            contentList = new List<Point>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine(SpecialFunctions.Erf(0.5));
            var m = LA.Matrix<double>.Build.Random(500, 500);
            var v = LA.Vector<double>.Build.Random(500);
            var y = m.Solve(v);
            Console.WriteLine(y);
        }

        private void buttonLoadA_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                // Load the image
                srcImg = new Image<Bgr, Byte>(openFile.FileName);
                srcWidth = srcImg.Width;
                srcHeight = srcImg.Height;

                // Display the image. 
                // I(x, y, {B,G,R}): img.Data[x, y, {0,1,2}]. x: row No. y: col No.
                pictureBoxA.Image = srcImg.ToBitmap();

                // Initialize the mapping from coordinate to id
                pointID = new int[srcHeight, srcWidth];
            }
        }

        private void buttonLoadB_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                // Load the image
                tarImg = new Image<Bgr, Byte>(openFile.FileName);
                tarWidth = tarImg.Width;
                tarHeight = tarImg.Height;

                // Display the image. 
                // I(x, y, {B,G,R}): img.Data[x, y, {0,1,2}]. x: row No. y: col No.
                pictureBoxB.Image = tarImg.ToBitmap();
            }
        }

        /**
         * Currenty, I just implement the rectangular version. 
         * - Zhen.
         */
        private void pictureBoxA_Click(object sender, EventArgs e)
        {
            if (isDrawing)
            {
                var mouseEvent = e as MouseEventArgs;
                if (mouseEvent != null)
                {
                    // Record the point
                    Console.WriteLine(String.Format("X:{0}, Y:{1}", mouseEvent.X, mouseEvent.Y));
                    // Inverse the order to fit the OpenCV order of index.
                    // So that x: row number, y: col number
                    clickList.Add(new Point(mouseEvent.Y, mouseEvent.X));

                    // Show the point as red
                    newSrcImg[mouseEvent.Y, mouseEvent.X] = new Bgr(Color.Red);

                    // Rectangular version:
                    if (clickList.Count == 2)
                    {
                        // Get boundry list from the click list
                        Point pointA = clickList.ElementAt<Point>(0), pointB = clickList.ElementAt<Point>(1);
                        selWidth = pointB.Y - pointA.Y + 1;
                        selHeight = pointB.X - pointA.X + 1;
                        selCenterPoint = new Point((pointA.X + pointB.X) / 2, (pointA.Y + pointB.Y) / 2);
                        Console.WriteLine(String.Format("Selected: heightxwidth: {0}x{1}", selHeight, selWidth));

                        // Initialize the mapping
                        for (int i = 0; i < srcHeight; ++i)
                            for (int j = 0; j < srcWidth; ++j)
                                pointID[i, j] = -2;

                        // Assume A:top-left, B:bottom-right
                        // +----------+
                        // +          +
                        // +----------+
                        for (int i = pointA.X; i <= pointB.X; ++i)
                        {
                            boundryList.Add(new Point(i, pointA.Y));
                            boundryList.Add(new Point(i, pointB.Y));

                            newSrcImg[i, pointA.Y] = new Bgr(Color.Red);
                            newSrcImg[i, pointB.Y] = new Bgr(Color.Red);

                            pointID[i, pointA.Y] = -1;
                            pointID[i, pointB.Y] = -1;
                        }

                        // -++++++++++-
                        // -          -
                        // -++++++++++-
                        for (int j = pointA.Y + 1; j < pointB.Y; ++j)
                        {
                            boundryList.Add(new Point(pointA.X, j));
                            boundryList.Add(new Point(pointB.X, j));

                            newSrcImg[pointA.X, j] = new Bgr(Color.Red);
                            newSrcImg[pointB.X, j] = new Bgr(Color.Red);

                            pointID[pointA.X, j] = -1;
                            pointID[pointB.X, j] = -1;
                        }

                        // Get content list and set the mapping of pointID
                        int cntID = 0;
                        contentList.Clear();
                        for (int i = pointA.X + 1; i < pointB.X; ++i)
                        {
                            for (int j = pointA.Y + 1; j < pointB.Y; ++j)
                            {
                                contentList.Add(new Point(i, j));
                                pointID[i, j] = cntID;
                                ++cntID;
                            }
                        }
                        contentArray = contentList.ToArray();
                        Console.WriteLine("Array: " + contentArray.Length);

                        isDrawing = false;
                    }

                    pictureBoxA.Image = newSrcImg.ToBitmap();
                }
            }
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            isDrawing = true;
            newSrcImg = srcImg.Copy();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            clickList.Clear();
            boundryList.Clear();
            contentList.Clear();

            isDrawing = false;
            if (srcImg != null)
                pictureBoxA.Image = srcImg.ToBitmap();
        }

        private void buttonPlace_Click(object sender, EventArgs e)
        {
            isPlacing = true;
            newTarImg = tarImg.Copy();
        }

        private void buttonClear2_Click(object sender, EventArgs e)
        {
            if (tarImg != null)
                pictureBoxB.Image = tarImg.ToBitmap();
        }

        /**
         * Poisson Image Editing
         * Based on Poisson Image Editing. P Perez et. al. SIGGRAPH 2003
         * -Zhen.
         */
        private void buttonClone_Click(object sender, EventArgs e)
        {
            int contentNum = contentArray.Length;
            // int boundryNum = boundryList.Count, 
            // int pointNum = boundryNum + contentNum;
            resultImg = newTarImg.Copy();

            // To solve AX=B, get matrix A and B first
            var matA = LA.Matrix<double>.Build.Sparse(contentNum, contentNum);
            var matB = LA.Double.Vector.Build.Dense(contentNum);

            // for color tunnel B, G, R
            for (int c = 0; c <= 2; ++c)
            {
                Console.WriteLine("Generate Matrix No. " + c);

                // Set matrix A & B to zero
                matA.Clear();
                matB.Clear();

                // top, right, bottom, left
                int[] dx = new int[] {-1, 0, 1, 0};
                int[] dy = new int[] { 0, 1, 0, -1 };
                List<Point> Np = new List<Point>();

                // Generate matrix A & B
                for (int id = 0; id < contentNum; ++id)
                {
                    // Use equation No.7 & No.8 in the paper
                    Np.Clear();
                    Point oldP = contentArray[id];
                    Point newP = new Point(oldP.X + biasX, oldP.Y + biasY);
                    for (int i = 0; i < 4; ++i)
                    {
                        Point newQ = new Point(newP.X + dx[i], newP.Y + dy[i]);
                        if (newQ.X >= 0 && newQ.X < tarHeight && newQ.Y >= 0 && newQ.Y < tarWidth)
                        {
                            // Point q is inside the area
                            Np.Add(newQ);
                        }
                    }
                    matA.At(id, id, Np.Count);

                    foreach (Point newQ in Np)
                    {
                        int qID = pointID[newQ.X - biasX, newQ.Y - biasY];
                        // q is inside Sigma
                        if (qID >= 0)
                        {
                            matA.At(id, qID, -1);
                        }
                    }

                    double Bi = 0;
                    foreach (Point newQ in Np)
                    {
                        int qID = pointID[newQ.X - biasX, newQ.Y - biasY];
                        // q is on the boundry
                        if (qID == -1)
                        {
                            Bi += tarImg.Data[newQ.X, newQ.Y, c];
                        }

                        Point oldQ = new Point(newQ.X - biasX, newQ.Y - biasY);
                        Bi += srcImg.Data[oldP.X, oldP.Y, c] - srcImg.Data[oldQ.X, oldQ.Y, c];
                    }
                    matB.At(id, Bi);
                }

                // Solve the sparse linear equation using BiCgStab (Bi-Conjugate Gradient Stabilized)
                Console.WriteLine("Solve the equations.");
                var fp = LA.Double.Vector.Build.Dense(contentNum);
                BiCgStab solver = new BiCgStab();

                // Choose stop criterias
                // Learn about stop criteria from: wo80, http://mathnetnumerics.codeplex.com/discussions/404689
                var stopCriterias = new List<IIterationStopCriterion<double>>()
                {
                    new ResidualStopCriterion<double>(1e-5),
                    new IterationCountStopCriterion<double>(1000),
                    new DivergenceStopCriterion<double>(),
                    new FailureStopCriterion<double>()
                };

                solver.Solve(matA, matB, fp, new Iterator<double>(stopCriterias), new DiagonalPreconditioner());
                Console.WriteLine("Solved.");
                // Console.WriteLine(fp);

                // Set the color
                for (int id = 0; id < contentNum; ++id)
                {
                    int color = (int)fp.At(id);
                    if (color < 0)
                        color = 0;
                    if (color > 255)
                        color = 255;
                    resultImg.Data[contentArray[id].X + biasX, contentArray[id].Y + biasY, c] = (Byte)color;
                }
            }

            pictureBoxResult.Image = resultImg.ToBitmap();
        }

        private void pictureBoxB_Click(object sender, EventArgs e)
        {
            if (isPlacing)
            {
                var mouseEvent = e as MouseEventArgs;
                if (mouseEvent != null)
                {
                    newTarImg = tarImg.Copy();

                    // Inverse to fit the order of OpenCV Point
                    placeCenterPoint = new Point(mouseEvent.Y, mouseEvent.X);
                    Console.WriteLine(String.Format("Place on <{0}, {1}>", placeCenterPoint.X, placeCenterPoint.Y));
                    biasX = placeCenterPoint.X - selCenterPoint.X;
                    biasY = placeCenterPoint.Y - selCenterPoint.Y;

                    // Paint the selected image on the target
                    foreach (Point point in contentArray)
                    {
                        int _x = point.X + biasX, _y = point.Y + biasY;
                        if (_x >= 0 && _x < tarHeight && _y >= 0 && _y < tarWidth)
                        {
                            newTarImg[_x, _y] = srcImg[point.X, point.Y];
                        }
                    }
                    pictureBoxB.Image = newTarImg.ToBitmap();
                }
            }
        }
    }
}
