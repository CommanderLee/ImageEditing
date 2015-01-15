﻿using System;
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

        // Control of drawing boundry on the source image
        private Image<Bgr, Byte>    newSrcImg;
        private bool                isDrawing;
        private List<Point>         clickList;
        private List<Point>         boundryList;
        private int                 selWidth, selHeight;

        // List of content point, and mapping to id
        private List<Point>         contentList;
        private Point[]             contentArray;
        private int[,]              pointID;
        private Point               selCenterPoint;

        // Control of placing the selected image on the target image
        private Image<Bgr, Byte>    newTarImg;
        private bool                isPlacing;
        private Point               placeCenterPoint;

        // Bias from selected source image to the target image
        private int                 biasX, biasY;

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
                        Point A = clickList.ElementAt<Point>(0), B = clickList.ElementAt<Point>(1);
                        selWidth = B.Y - A.Y + 1;
                        selHeight = B.X - A.X + 1;
                        selCenterPoint = new Point((A.X + B.X) / 2, (A.Y + B.Y) / 2);
                        Console.WriteLine(String.Format("Selected: heightxwidth: {0}x{1}", selHeight, selWidth));

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

                        // Get content list and set the mapping
                        int cntID = 0;
                        contentList.Clear();
                        for (int i = A.X + 1; i < B.X; ++i)
                        {
                            for (int j = A.Y + 1; j < B.Y; ++j)
                            {
                                contentList.Add(new Point(i, j));
                                pointID[i, j] = cntID;
                                ++cntID;
                            }
                        }
                        contentArray = contentList.ToArray();
                        Console.WriteLine("List: " + contentList.Count);
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

        private void buttonClone_Click(object sender, EventArgs e)
        {

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
