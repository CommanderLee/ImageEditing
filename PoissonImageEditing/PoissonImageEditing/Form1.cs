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

namespace PoissonImageEditing
{
    public partial class FormImageEditing : Form
    {
        private Image<Bgr, Byte>    srcImg, tarImg;

        private int                 srcWidth, srcHeight;
        private int                 tarWidth, tarHeight;

        // Control flag for drawing boundry on the source image
        private Image<Bgr, Byte>    newSrcImg;
        private bool                isDrawing;
        private List<Point>         clickList;
        private List<Point>         boundryList;

        public FormImageEditing()
        {
            InitializeComponent();

            clickList = new List<Point>();
            boundryList = new List<Point>();
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
                        Point A = clickList.ElementAt<Point>(0), B = clickList.ElementAt<Point>(1);
                        // Assume A:top-left, B:bottom-right
                        // +----------+
                        // +          +
                        // +----------+
                        for (int i = A.X; i <= B.X; ++i)
                        {
                            boundryList.Add(new Point(i, A.Y));
                            boundryList.Add(new Point(i, B.Y));

                            newSrcImg[i, A.Y] = new Bgr(Color.Red);
                            newSrcImg[i, B.Y] = new Bgr(Color.Red);
                        }

                        // -++++++++++-
                        // -          -
                        // -++++++++++-
                        for (int j = A.Y + 1; j < B.Y; ++j)
                        {
                            boundryList.Add(new Point(A.X, j));
                            boundryList.Add(new Point(B.X, j));

                            newSrcImg[A.X, j] = new Bgr(Color.Red);
                            newSrcImg[B.X, j] = new Bgr(Color.Red);
                        }

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
            isDrawing = false;
            if (srcImg != null)
                pictureBoxA.Image = srcImg.ToBitmap();
        }
    }
}
