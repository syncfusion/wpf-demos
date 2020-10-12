#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
    public class SparkModel 
    {
        public SparkModel()
        {
            this.DayActivity = new ObservableCollection<DataModel>();
            this.Transaction = new ObservableCollection<DataModel>();
            this.OneYearPerformance = new ObservableCollection<DataModel>();
        }

        private string companyName;
        public string CompanyName
        {
            get
            {
                return this.companyName;
            }
            set
            {
                this.companyName = value;
            }
        }

        private double high;
        public double High
        {
            get
            {
                return this.high;
            }
            set
            {
                this.high = value;
            }
        }

        private DateTime date;
        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        private double low;
        public double Low
        {
            get
            {
                return this.low;
            }
            set
            {
                this.low = value;
            }
        }

        private double marketCap;
        public double MarketCap
        {
            get
            {
                return this.marketCap;
            }
            set
            {
                this.marketCap = value;
            }
        }

        private double performance;
        public double Performance
        {
            get
            {
                return this.performance;
            }
            set
            {
                this.performance = value;
            }
        }

        private ObservableCollection<DataModel> dayActivity;
        public ObservableCollection<DataModel> DayActivity
        {
            get
            {
                return this.dayActivity;
            }
            set
            {
                this.dayActivity = value;
            }
        }

        private ObservableCollection<DataModel> transaction;
        public ObservableCollection<DataModel> Transaction
        {
            get
            {
                return this.transaction;
            }
            set
            {
                this.transaction = value;
            }
        }

        private ObservableCollection<DataModel> oneYearPerformance;
        public ObservableCollection<DataModel> OneYearPerformance
        {
            get
            {
                return this.oneYearPerformance;
            }
            set
            {
                this.oneYearPerformance = value;
            }
        }

        private double start;
        public double Start
        {
            get
            {
                return start;
            }
            set
            {
                this.start = value;
            }
        }

        private double end;
        public double End
        {
            get
            {
                return end;
            }
            set
            {
                this.end = value;
            }
        }
    }
}
