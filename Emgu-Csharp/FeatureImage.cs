using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Collections;
using Emgu.CV.UI;
using Emgu.CV.VideoSurveillance;
using Emgu.CV.Features2D;
using Emgu.CV.XFeatures2D;
using Emgu.CV.Util;

namespace Emgu_Csharp
{
    public class ImageSpecifications
    {
        public int Width , Height ;
        public VectorOfKeyPoint KeyPoints;
        public Mat Descriptors;
    }
}
