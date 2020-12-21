#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.wpf
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
