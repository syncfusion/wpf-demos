#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;

namespace TabControlExtDemo
{
    public class TestingModel :NotificationObject
    {
        double _x;
        double _y;

        public double X 
        { 
            get
            {
                return _x;
            }
            set
            {
                _x = value;
                RaisePropertyChanged("X");
            }
        }

        public double Y 
        { 
            get
            {
                return _y;
            }
            set
            {
                _y = value;
                RaisePropertyChanged("Y");
            }
        }
    }
}
