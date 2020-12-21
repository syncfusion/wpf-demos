#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.patientmonitor.wpf
{
    public class ChartPoint : NotificationObject
    {
        #region Fields

        private double x;

        private double y;

        #endregion

        #region Constructor
        public ChartPoint(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        #endregion

        #region Properties
        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
                RaisePropertyChanged("X");
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
                RaisePropertyChanged("Y");
            }
        }
        #endregion
    }
}
