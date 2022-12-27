#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    public class ChartDataEditingModel : NotificationObject
    {
        public DateTime XValue
        {
            get { return xValue; }
            set
            {
                if (value != xValue)
                {
                    xValue = value;
                    RaisePropertyChanged(nameof(this.XValue));
                }
            }
        }

        public double YValue
        {
            get { return yValue; }
            set
            {
                if (value != yValue)
                {
                    yValue = value;
                    RaisePropertyChanged(nameof(this.YValue));
                }
            }
        }

        public double Scatter
        {
            get { return scatter; }
            set
            {
                if (value != scatter)
                {
                    scatter = value;
                    RaisePropertyChanged(nameof(this.Scatter));
                }
            }
        }

        private DateTime xValue;
        private double yValue;
        private double scatter;
    }
}
