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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    public class StockZoomingViewModel : NotificationObject
    {
        private DateTime startDate; 
        private DateTime endDate;
        
        public DateTime StartDate
        {
            get 
            {
                return startDate;
            }

            set
            { 
                startDate = value;
                RaisePropertyChanged(nameof(this.StartDate));
            }
        }

        public DateTime EndDate
        {
            get
            {
                return endDate;
            }

            set
            {
                endDate = value;
                RaisePropertyChanged(nameof(this.EndDate));
            }
        }

        public ICommand RangeCheckCommand { get; set; }

        public StockZoomingViewModel()
        {
            this.StockPriceDetails = new ObservableCollection<StockZoomingModel>();
            DateTime date = new DateTime(2010, 5, 19);
            Random rd = new Random();
            double value = 70;
            for (int i = 0; i < 2555; i++)
            {
                if (rd.NextDouble() > .5)
                    value += rd.NextDouble();
                else
                    value -= rd.NextDouble();
                if (value >= 110) value = 110;
                if (value <= 20) value = 20;
                this.StockPriceDetails.Add(new StockZoomingModel()
                {
                    Date = date.AddDays(i),
                    YValue = value,
                });
            }

            RangeCheckCommand = new DelegateCommand(Execute);
            StartDate = new DateTime(2011, 1, 1);
            EndDate = new DateTime(2013, 1, 1);
        }

        public void Execute(object parameter)
        {
            SetRange(parameter.ToString());
        }

        internal void SetRange(string range)
        {
            switch (range)
            {
                case "OneMonth":
                    StartDate = EndDate.AddMonths(-1);
                    break;

                case "ThreeMonth":
                    StartDate = EndDate.AddMonths(-3);

                    break;

                case "SixMonth":
                    StartDate = EndDate.AddMonths(-6);
                    break;

                case "YTD":
                    int count = StockPriceDetails.Count;
                    var dateTime = StockPriceDetails[count - 1].Date;
                    EndDate = dateTime;
                    StartDate = new DateTime(dateTime.Year, 1, 1);
                    break;

                case "OneYear":
                    StartDate = EndDate.AddYears(-1);
                    break;

                default:
                    int count2 = StockPriceDetails.Count;
                    StartDate = StockPriceDetails[0].Date;
                    EndDate = StockPriceDetails[count2 - 1].Date;
                    break;
            }
        }

        public ObservableCollection<StockZoomingModel> StockPriceDetails { get; set; }

    }
}
