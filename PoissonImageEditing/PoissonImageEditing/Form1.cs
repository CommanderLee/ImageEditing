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

        public FormImageEditing()
        {
            InitializeComponent();
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
    }
}
