using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Collections;
using Emgu.CV.UI;
using Emgu.CV.VideoSurveillance;
using Emgu.CV.Features2D;
using Emgu.CV.XFeatures2D;
using Emgu.CV.Util;
using Emgu.CV.Stitching;

namespace Image_Analyzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static Image<Bgr, Byte> img1;
        public static Image<Bgr, Byte> img2;

        ImageData imgD1;
        ImageData imgD2;

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //string selectedFile = openFileDialog.FileName;
                    //pictureBox1.Image = new Bitmap(selectedFile);

                    //img1 = new Image<Bgr, Byte>(selectedFile);

                }


            }

        }
    }
}
