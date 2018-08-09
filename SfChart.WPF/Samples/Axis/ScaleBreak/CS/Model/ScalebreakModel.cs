using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scalebreak_Demo_2015
{
    public class ScalebreakModel
    {
        private string xData;
        public string XData
        {
            get { return xData; }
            set { xData = value; }
        }

        private double xData1;
        public double XData1
        {
            get { return xData1; }
            set { xData1 = value; }
        }

        private double yData;
        public double YData
        {
            get { return yData; }
            set { yData = value; }
        }


        private double? yData1;
        public double? YData1
        {
            get { return yData1; }
            set { yData1 = value; }
        }
    }
}
