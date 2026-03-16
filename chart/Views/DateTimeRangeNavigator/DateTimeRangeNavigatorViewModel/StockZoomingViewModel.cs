#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Provides stock and temperature series with a selectable date range for zooming.</summary>
    public class StockZoomingViewModel : NotificationObject , IDisposable
    {
        private DateTime startDate;
        private DateTime endDate;

        /// <summary>Gets or sets the start of the visible date range.</summary>
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

        /// <summary>Gets or sets the end of the visible date range.</summary>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="StockZoomingViewModel"/> class.
        /// </summary>
        public StockZoomingViewModel()
        {
            this.StockPriceDetails = new ObservableCollection<StockZoomingModel>();
            this.TemperatureDetails = new ObservableCollection<StockZoomingModel>();
            DateTime date = new DateTime(2010, 5, 19);
            Random rd = new Random();
            double value = 90;
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

            double temperature = 10;
            for (int i = 0; i < 2555; i++)
            {
                if (rd.NextDouble() > .5)
                    temperature += rd.NextDouble();
                else
                    temperature -= rd.NextDouble();
                if (temperature <= 10)
                    temperature = 10;
                else if (temperature > 40) temperature = 40;
                this.TemperatureDetails.Add(new StockZoomingModel()
                {
                    Date = date.AddDays(i),
                    YValue = temperature,
                });
            }

            StartDate = new DateTime(2012, 01, 1);
            EndDate = new DateTime(2016, 01, 1);
        }

        /// <summary>Gets or sets the generated stock price data.</summary>
        public ObservableCollection<StockZoomingModel> StockPriceDetails { get; set; }

        /// <summary>Gets or sets the generated temperature data.</summary>
        public ObservableCollection<StockZoomingModel> TemperatureDetails { get; set; }

        /// <summary>Releases resources and performs cleanup operations.</summary>
        public void Dispose()
        {
            if(StockPriceDetails != null)
                 StockPriceDetails.Clear(); 

            if(TemperatureDetails != null)
                TemperatureDetails.Clear();

        }
    }
}
