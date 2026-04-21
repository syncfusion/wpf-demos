#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Represents the data model for sparkline chart visualization.
    /// </summary>
    public class SparkModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SparkModel"/> class.
        /// </summary>
        public SparkModel()
        {
            this.DayActivity = new ObservableCollection<DataModel>();
            this.Transaction = new ObservableCollection<DataModel>();
            this.OneYearPerformance = new ObservableCollection<DataModel>();
        }

        private string companyName;
        /// <summary>Gets or sets the company name.</summary>
        public string CompanyName
        {
            get { return this.companyName; }
            set { this.companyName = value; }
        }

        private double high;
        /// <summary>Gets or sets the high value.</summary>
        public double High
        {
            get { return this.high; }
            set { this.high = value; }
        }

        private DateTime date;
        /// <summary>Gets or sets the date value.</summary>
        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        private double low;
        /// <summary>Gets or sets the low value.</summary>
        public double Low
        {
            get { return this.low; }
            set { this.low = value; }
        }

        private double marketCap;
        /// <summary>Gets or sets the market capitalization.</summary>
        public double MarketCap
        {
            get { return this.marketCap; }
            set { this.marketCap = value; }
        }

        private double performance;
        /// <summary>Gets or sets the performance value.</summary>
        public double Performance
        {
            get { return this.performance; }
            set { this.performance = value; }
        }

        private ObservableCollection<DataModel> dayActivity;
        /// <summary>Gets or sets the day activity data collection.</summary>
        public ObservableCollection<DataModel> DayActivity
        {
            get { return this.dayActivity; }
            set { this.dayActivity = value; }
        }

        private ObservableCollection<DataModel> transaction;
        /// <summary>Gets or sets the transaction data collection.</summary>
        public ObservableCollection<DataModel> Transaction
        {
            get { return this.transaction; }
            set { this.transaction = value; }
        }

        private ObservableCollection<DataModel> oneYearPerformance;
        /// <summary>Gets or sets the one year performance data collection.</summary>
        public ObservableCollection<DataModel> OneYearPerformance
        {
            get { return this.oneYearPerformance; }
            set { this.oneYearPerformance = value; }
        }

        private double start;
        /// <summary>Gets or sets the start value.</summary>
        public double Start
        {
            get { return start; }
            set { this.start = value; }
        }

        private double end;
        /// <summary>Gets or sets the end value.</summary>
        public double End
        {
            get { return end; }
            set { this.end = value; }
        }
    }
}
