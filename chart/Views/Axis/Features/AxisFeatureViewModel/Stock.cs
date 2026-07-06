#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a stock, its data collection, and derived statistics.</summary>
    public class Stock : NotificationObject
    {
        /// <summary>Gets or sets the stock symbol/name.</summary>
        public string StockName { get; set; }

        List<StockData> datas;

        /// <summary>Gets or sets the complete list of stock data records.</summary>
        public List<StockData> Datas
        {
            get
            {
                return datas;
            }
            set
            {
                datas = value;
                selectedStock = this;
                RaisePropertyChanged(nameof(this.Datas));
            }
        }


        Stock selectedStock;

        /// <summary>Gets or sets the currently selected stock instance.</summary>
        public Stock SelectedStock
        {
            get
            {
                return selectedStock;
            }
            set
            {
                selectedStock = value;
                RaisePropertyChanged(nameof(this.SelectedStock));
            }
        }

        private double currentLow;

        private double currentClose;

        private double currentHigh;

        /// <summary>Gets or sets the latest low price.</summary>
        public double CurrentLow
        {
            get
            {
                return currentLow;
            }
            set
            {
                currentLow = value;
                RaisePropertyChanged(nameof(this.CurrentLow));
            }
        }

        /// <summary>Gets or sets the latest high price.</summary>
        public double CurrentHigh
        {
            get
            {
                return currentHigh;
            }
            set
            {
                currentHigh = value;
                RaisePropertyChanged(nameof(this.CurrentHigh));
            }
        }

        /// <summary>Gets or sets the latest close price.</summary>
        public double CurrentClose
        {
            get
            {
                return currentClose;
            }
            set
            {
                currentClose = value;
                RaisePropertyChanged(nameof(this.CurrentClose));
            }
        }

        private double previousClose;

        /// <summary>Gets or sets the previous close price.</summary>
        public double PreviousClose
        {
            get
            {
                return previousClose;
            }
            set
            {
                previousClose = value;
                RaisePropertyChanged(nameof(this.PreviousClose));
            }
        }

        /// <summary>Gets or sets the original data set.</summary>
        public List<StockData> OrgDatas
        {
            get;
            set;
        }

        private ObservableCollection<ChartSeries> indicatorsColln = new ObservableCollection<ChartSeries>();

        /// <summary>Gets or sets the technical indicator series collection.</summary>
        public ObservableCollection<ChartSeries> IndicatorsCollection
        {

            get
            {
                return indicatorsColln;
            }
            set
            {
                indicatorsColln = value;
                RaisePropertyChanged(nameof(this.IndicatorsCollection));
            }
        }

        private string selindicator;

        /// <summary>Gets or sets the name of the selected indicator.</summary>
        public string SelectedIndicator
        {

            get
            {
                return selindicator;
            }
            set
            {
                selindicator = value;
                RaisePropertyChanged(nameof(this.SelectedIndicator));
            }
        }
    }

    /// <summary>Represents a single stock record with OHLC, volume, and timestamp.</summary>
    public class StockData
    {
        /// <summary>Gets or sets the high price.</summary>
        public double High { get; set; }

        /// <summary>Gets or sets the low price.</summary>
        public double Low { get; set; }

        /// <summary>Gets or sets the open price.</summary>
        public double Open { get; set; }

        /// <summary>Gets or sets the close price.</summary>
        public double Close { get; set; }

        /// <summary>Gets or sets the traded volume.</summary>
        public double Volume { get; set; }

        /// <summary>Gets or sets the last traded price.</summary>
        public double Last { get; set; }

        /// <summary>Gets or sets the timestamp of the record.</summary>
        public DateTime TimeStamp { get; set; }
    }
}
