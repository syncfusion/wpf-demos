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

namespace Sparkline_Demo
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
