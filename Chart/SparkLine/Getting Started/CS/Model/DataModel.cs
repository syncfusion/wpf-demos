#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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

namespace GettingStartedDemo
{
    public class DataModel
    {
        private double day;
        public double Day
        {
            get
            {
                return day;
            }
            set
            {
                this.day = value;
            }
        }

        private double shareHolders;
        public double ShareHolders
        {
            get
            {
                return shareHolders;
            }
            set
            {
                this.shareHolders = value;
            }
        }

        private double yearPerformance;
        public double YearPerformance
        {
            get
            {
                return yearPerformance;
            }
            set
            {
                this.yearPerformance = value;
            }
        }
    }
}
