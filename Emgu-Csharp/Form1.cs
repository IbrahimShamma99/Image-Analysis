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
namespace Emgu_Csharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static Image<Bgr, Byte> img1;
        public static Image<Bgr, Byte> img2;

        ImageSpecifications imgD1;
        ImageSpecifications imgD2;

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string selectedFile = openFileDialog.FileName;
                    pictureBox1.Image = new Bitmap(selectedFile);

                    img1 = new Image<Bgr, Byte>(selectedFile);

                }

                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string selectedFile = openFileDialog.FileName;
                    pictureBox2.Image = new Bitmap(selectedFile);

                    img2 = new Image<Bgr, Byte>(selectedFile);

                }


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExtractFeature(img1, imgD1);
            ExtractFeature(img2, imgD2);

        }

        private void ExtractFeature(Image<Bgr, byte> img , ImageSpecifications imgD)
        {
            using (Image<Gray, Byte> model = new Image<Gray, byte>(img.Bitmap))
            using (var modelMat = model.Mat.ToUMat(AccessType.Read))
            using (var detector = new SURF(hessianThresh: 350))
            {
                var descriptor = new Mat();
                var keyPoints = new VectorOfKeyPoint();
                detector.DetectAndCompute(modelMat, null, keyPoints, descriptor, false);
                imgD.Height = img.Height;
                imgD.Width = img.Width;
                imgD.KeyPoints = keyPoints;
                imgD.Descriptors = descriptor;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        public static void Stitch2Images(Image<Bgr, byte> img1 , Image<Bgr, byte> img2)
        {

            List<Image<Bgr, byte>> imageArray = new List<Image<Bgr, byte>>();
            imageArray.Add(img1);
            imageArray.Add(img2);

                using (var stitcher = new Stitcher(false))
                {
                    using (var vm = new VectorOfMat())
                    {
                        var result = new Mat();
                        vm.Push(imageArray.ToArray());
                        stitcher.Stitch(vm, result);

                    }
                }
                foreach (Image<Bgr, Byte> img in imageArray)
                {
                    img.Dispose();
                }
        }


    }
}
