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
using System.ComponentModel;

namespace syncfusion.chartdemos.wpf
{
    public class Stock : NotificationObject
    {
        public string StockName { get; set; }

        List<StockData> datas;

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

        public List<StockData> OrgDatas
        {
            get;
            set;
        }

        private ObservableCollection<ChartSeries> indicatorsColln = new ObservableCollection<ChartSeries>();

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

    public class StockData
    {
        public double High { get; set; }

        public double Low { get; set; }

        public double Open { get; set; }

        public double Close { get; set; }

        public double Volume { get; set; }

        public double Last { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
