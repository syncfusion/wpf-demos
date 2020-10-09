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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.wpf
{
    public class ZAxisViewModel : NotificationObject
    {

        private int selectedSeriesIndex = -1;
        private ChartSeries3DCollection seriesCollection;
        
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
                            BarSeries3D series1 = new BarSeries3D();
                            series1.ShowTooltip = true;
                            series1.Palette = ChartColorPalette.Metro;
                            series1.ItemsSource = this.FruitDetails;
                            series1.XBindingPath = "FruitsName";
                            series1.YBindingPath = "Count";
                            series1.ZBindingPath = "Day";
                            SeriesCollection.Add(series1);
                            break;

                        case 2:
                            SeriesCollection.Clear();
                            ScatterSeries3D series2 = new ScatterSeries3D();
                            series2.ShowTooltip = true;
                            series2.Palette = ChartColorPalette.Metro;
                            series2.ItemsSource = this.FruitDetails;
                            series2.XBindingPath = "FruitsName";
                            series2.YBindingPath = "Count";
                            series2.ZBindingPath = "Day";
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

        public ObservableCollection<ZAxisModel> FruitDetails
        {
            get;
            set;
        }

        public ZAxisViewModel()
        {
            FruitDetails = new ObservableCollection<ZAxisModel>();
            FruitDetails.Add(new ZAxisModel() { FruitsName = "Apple", Day = "Sun", Count = 50 });
            FruitDetails.Add(new ZAxisModel() { FruitsName = "Orange", Day = "Mon", Count = 30 });
            FruitDetails.Add(new ZAxisModel() { FruitsName = "Mango", Day = "Tue", Count = 60 });
            FruitDetails.Add(new ZAxisModel() { FruitsName = "Banana", Day = "Wed", Count = 80 });
            FruitDetails.Add(new ZAxisModel() { FruitsName = "Grape", Day = "Thur", Count = 60 });
            FruitDetails.Add(new ZAxisModel() { FruitsName = "Jackfruit", Day = "Fri", Count = 30 });
            FruitDetails.Add(new ZAxisModel() { FruitsName = "Guava", Day = "Sat", Count = 75 });

            SeriesCollection = new ChartSeries3DCollection();
            SelectedSeriesIndex = 0;
        }
    }
}
