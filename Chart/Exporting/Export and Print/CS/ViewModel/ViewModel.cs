#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using Syncfusion.UI.Xaml.Charts;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ExportChartDemo
{
    public class ViewModel : INotifyPropertyChanged
    {
        private ChartView chartView;
        private ExportCommand exportCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public ExportCommand ExportCommand
        {
            get
            {
                return exportCommand;
            }

            set
            {
                if(exportCommand != value)
                {
                    exportCommand = value;
                    OnPropertyChanged("OperationCommand");
                }
            }
        }

        public ChartView ChartView 
        {
            get
            {
                return chartView;
            }

            set
            {
                if (chartView != value)
                {
                    chartView = value;
                    OnPropertyChanged("ChartView");
                }
            }
        }

        public ObservableCollection<DataModel> ClimateData { get; set; }

        public ViewModel()
        {
            ClimateData = new ObservableCollection<DataModel>();
            ClimateData.Add(new DataModel() { Month = "Jan", Temperature = 33 });
            ClimateData.Add(new DataModel() { Month = "Feb", Temperature = 37 });
            ClimateData.Add(new DataModel() { Month = "Mar", Temperature = 39 });
            ClimateData.Add(new DataModel() { Month = "Apr", Temperature = 43 });
            ClimateData.Add(new DataModel() { Month = "May", Temperature = 45 });
            ClimateData.Add(new DataModel() { Month = "Jun", Temperature = 43 });
            ClimateData.Add(new DataModel() { Month = "Jul", Temperature = 41 });
            ClimateData.Add(new DataModel() { Month = "Aug", Temperature = 40 });
            ClimateData.Add(new DataModel() { Month = "Sep", Temperature = 39 });
            ClimateData.Add(new DataModel() { Month = "Oct", Temperature = 39 });
            ClimateData.Add(new DataModel() { Month = "Nov", Temperature = 34 });
            ClimateData.Add(new DataModel() { Month = "Dec", Temperature = 33 });

            ChartView = new ChartView();
            exportCommand = new ExportCommand(this);
        }

        internal void Save()
        {
            var chart = (ChartView.Content as Grid).Children[0] as SfChart;
            if (chart != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = "Untitled";
                sfd.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg,*.jpeg)|*.jpg;*.jpeg|Gif (*.gif)|*.gif|PNG(*.png)|*.png|All files (*.*)|*.*";
                if (sfd.ShowDialog() == true)
                {
                    using (Stream fs = sfd.OpenFile())
                    {
                        chart.Save(fs, new PngBitmapEncoder());
                    }
                }
            }
        }

        internal void Print()
        {
            var chart = (ChartView.Content as Grid).Children[0] as SfChart;
            if (chart != null)
            {
                chart.Print();
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
