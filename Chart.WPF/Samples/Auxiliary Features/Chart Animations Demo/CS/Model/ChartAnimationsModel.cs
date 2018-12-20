#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChartAnimations
{
    public class MonthlyNet
    {
        int _monthno;
        string _monthstr;
        double _net;

        public String Month
        {
            get
            {
                return _monthstr;
            }
            set
            {
                _monthstr = value;
            }
        }

        public int MonthNo
        {
            get
            {
                return _monthno;
            }
            set
            {
                _monthno = value;
            }

        }

        public double NetUp
        {
            get
            {
                return _net;
            }
            set
            {
                _net = value;
            }
        }

        public MonthlyNet(int month, string monthname, double net)
        {
            _monthno = month;
            _monthstr = monthname;
            _net = net;
        }
    }
}
