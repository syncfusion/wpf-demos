#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.sparklinedemos.wpf
{
    /// <summary>
    /// Represents the data model for chart values.
    /// </summary>
    public class DataModel 
    {
        private double day;
        /// <summary>Gets or sets the day value.</summary>
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
        /// <summary>Gets or sets the number of shareholders.</summary>
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
        /// <summary>Gets or sets the year performance value.</summary>
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

