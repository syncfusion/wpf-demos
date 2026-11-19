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
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Manages 3D series selection and data for the depth axis demo.</summary>
    public class ZAxisViewModel : NotificationObject , IDisposable
    {
        private int selectedSeriesIndex = -1;
        private ChartSeries3DCollection seriesCollection;

        /// <summary>Gets or sets the selected 3D series type index.</summary>
        public int SelectedSeriesIndex
        {
            get
            {
                return selectedSeriesIndex;
            }

            set
            {
                if (selectedSeriesIndex != value)
                {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
                    selectedSeriesIndex = value;
                    switch (selectedSeriesIndex)
                    {
                        case 1:
                            SeriesCollection.Clear();
                            ScatterSeries3D series2 = new ScatterSeries3D();
                            series2.ShowTooltip = true;
                            series2.Palette = ChartColorPalette.Metro;
                            series2.ItemsSource = this.FruitDetails;
                            series2.XBindingPath = "FruitsName";
                            series2.YBindingPath = "Count";
                            series2.ZBindingPath = "Day";
                            series2.ScatterHeight = 30;
                            series2.ScatterWidth = 30;
                            SeriesCollection.Add(series2);
                            break;

                        default:
                            SeriesCollection.Clear();
                            ColumnSeries3D series3 = new ColumnSeries3D();
                            series3.ShowTooltip = true;
                            series3.Palette = ChartColorPalette.Metro;
                            series3.ItemsSource = this.FruitDetails;
                            series3.XBindingPath = "FruitsName";
                            series3.YBindingPath = "Count";
                            series3.ZBindingPath = "Day";
                            SeriesCollection.Add(series3);
                            break;
                    }

                    RaisePropertyChanged(nameof(this.SeriesCollection));
                    RaisePropertyChanged(nameof(this.SelectedSeriesIndex));
                }
            }
        }

        /// <summary>Gets or sets the collection of 3D chart series.</summary>
        public ChartSeries3DCollection SeriesCollection 
        {
            get
            {
                return seriesCollection;
            }

            set
            {
                seriesCollection = value;
                RaisePropertyChanged(nameof(this.SeriesCollection));
            }
        }

        /// <summary>Gets or sets the data used for 3D charting.</summary>
        public ObservableCollection<ZAxisModel> FruitDetails
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZAxisViewModel"/> class.
        /// </summary>
        public ZAxisViewModel()
        {
            FruitDetails = new ObservableCollection<ZAxisModel>();
            FruitDetails.Add(new ZAxisModel() { FruitsName = "Apple", Day = "Sun", Count = 50 });
            FruitDetails.Add(new ZAxisModel() { FruitsName = "Orange", Day = "Mon", Count = 30 });
            FruitDetails.Add(new ZAxisModel() { FruitsName = "Mango", Day = "Tue", Count = 60 });
            FruitDetails.Add(new ZAxisModel() { FruitsName = "Banana", Day = "Wed", Count = 80 });
            FruitDetails.Add(new ZAxisModel() { FruitsName = "Grape", Day = "Thu", Count = 60 });
            FruitDetails.Add(new ZAxisModel() { FruitsName = "Jackfruit", Day = "Fri", Count = 30 });
            FruitDetails.Add(new ZAxisModel() { FruitsName = "Guava", Day = "Sat", Count = 75 });

            SeriesCollection = new ChartSeries3DCollection();
            SelectedSeriesIndex = 0;
        }

        /// <summary>Releases resources and performs cleanup operations.</summary>
        public void Dispose()
        {
            if (FruitDetails != null)
                FruitDetails.Clear();
        }
    }
}
