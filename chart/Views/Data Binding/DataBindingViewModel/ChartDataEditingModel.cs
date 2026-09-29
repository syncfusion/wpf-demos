#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents an editable chart data point with X, Y, and scatter values.</summary>
    public class ChartDataEditingModel : NotificationObject
    {
        /// <summary>Gets or sets the X value (date) of the data point.</summary>
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

        /// <summary>Gets or sets the Y value of the data point.</summary>
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

        /// <summary>Gets or sets the scatter value associated with the data point.</summary>
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
