#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Charts;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace syncfusion.chartdemos.wpf
{
    public class ExportChartViewModel : NotificationObject
    {
        private ChartView chartView;
        private ICommand exportCommand;

        public ICommand ExportCommand
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
                    RaisePropertyChanged(nameof(this.ExportCommand));
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
                    RaisePropertyChanged(nameof(this.ChartView));
                }
            }
        }

        public ObservableCollection<ExportChartDataModel> ClimateData { get; set; }

        public ExportChartViewModel()
        {
            ClimateData = new ObservableCollection<ExportChartDataModel>();
            ClimateData.Add(new ExportChartDataModel() { Month = "Jan", Temperature = 33 });
            ClimateData.Add(new ExportChartDataModel() { Month = "Feb", Temperature = 37 });
            ClimateData.Add(new ExportChartDataModel() { Month = "Mar", Temperature = 39 });
            ClimateData.Add(new ExportChartDataModel() { Month = "Apr", Temperature = 43 });
            ClimateData.Add(new ExportChartDataModel() { Month = "May", Temperature = 45 });
            ClimateData.Add(new ExportChartDataModel() { Month = "Jun", Temperature = 43 });
            ClimateData.Add(new ExportChartDataModel() { Month = "Jul", Temperature = 41 });
            ClimateData.Add(new ExportChartDataModel() { Month = "Aug", Temperature = 40 });
            ClimateData.Add(new ExportChartDataModel() { Month = "Sep", Temperature = 39 });
            ClimateData.Add(new ExportChartDataModel() { Month = "Oct", Temperature = 39 });
            ClimateData.Add(new ExportChartDataModel() { Month = "Nov", Temperature = 34 });
            ClimateData.Add(new ExportChartDataModel() { Month = "Dec", Temperature = 33 });

            ChartView = new ChartView();
            ExportCommand = new DelegateCommand(Execute);
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

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Save")
            {
                Save();
            }
            else
            {
                Print();
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
    }
}
