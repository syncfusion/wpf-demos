#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace syncfusion.gaugedemos.wpf
{
    public class MultipleScaleViewModel : NotificationObject
    {
        private double startAngle = 135;

        public double StartAngle
        {
            get 
            {
                return startAngle;
            }
            set 
            {
                startAngle = value;
                RaisePropertyChanged("StartAngle");
            }
        }

        private double sweepAngle = 270;

        public double SweepAngle
        {
            get 
            {
                return sweepAngle; 
            }
            set 
            {
                sweepAngle = value;
                RaisePropertyChanged("SweepAngle");
            }
        }

    }
}
