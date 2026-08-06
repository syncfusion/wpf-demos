#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Provides data, commands, and helpers to export or print a chart.</summary>
    public class ExportChartViewModel : NotificationObject , IDisposable
    {
        private ChartView chartView;
        private ICommand exportCommand;

        /// <summary>Gets or sets the command that triggers save or print operations.</summary>
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

        /// <summary>Gets or sets the ChartView hosting the SfChart to export.</summary>
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

        /// <summary>Gets or sets the monthly climate data displayed by the chart.</summary>
        public ObservableCollection<ExportChartDataModel> ClimateData { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportChartViewModel"/> class.
        /// </summary>
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

        /// <summary>Executes the export action; routes to Save or Print based on the parameter.</summary>
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

        /// <summary>Releases resources and performs cleanup operations.</summary>
        public void Dispose()
        {
            if(ClimateData != null)
                ClimateData.Clear();
        }
    }
}
