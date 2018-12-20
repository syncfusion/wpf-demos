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
using System.Collections.ObjectModel;
using System.IO;
using System.Globalization;

namespace GoogleFinanceDemo
{
    public class GoogleData
    {
        public DateTime TimeStamp
        {
            get;
            set;
        }
        public double High
        {
            get;
            set;
        }
        public double Low
        {
            get;
            set;
        }
        public double Last
        {
            get;
            set;
        }
        public double Open
        {
            get;
            set;
        }
        public double Volume
        {
            get;
            set;
        }
    }
  
}
