#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.SampleLayout;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SplineRangeAreaChart
{
    
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            SplineRangeAreaSeries.StrokeThickness = 3;
            SplineRangeAreaSeries.Stroke = new SolidColorBrush(Color.FromArgb(255, 27, 161, 226));
            SplineRangeAreaSeries.Interior = new SolidColorBrush(Color.FromArgb(150, 27, 161, 226));
        }
    }

    public class Model
    {
        public string Month { get; set; }

        public double LowMetric { get; set; }

        public double HighMetric { get; set; }
    }

    public class ViewModel
    {
        public ViewModel()
        {
            this.Products = new ObservableCollection<Model>();

            Products.Add(new Model() { Month = "Jan", LowMetric = 20, HighMetric = 53 });
            Products.Add(new Model() { Month = "Feb", LowMetric = 22, HighMetric = 76 });
            Products.Add(new Model() { Month = "Mar", LowMetric = 30, HighMetric = 80 });
            Products.Add(new Model() { Month = "Apr", LowMetric = 26, HighMetric = 50 });
            Products.Add(new Model() { Month = "May", LowMetric = 36, HighMetric = 68 });
            Products.Add(new Model() { Month = "Jun", LowMetric = 20, HighMetric = 90 });
            Products.Add(new Model() { Month = "Jul", LowMetric = 40, HighMetric = 73 });
            Products.Add(new Model() { Month = "Aug", LowMetric = 22, HighMetric = 76 });
            Products.Add(new Model() { Month = "Sep", LowMetric = 30, HighMetric = 80 });
            Products.Add(new Model() { Month = "Oct", LowMetric = 26, HighMetric = 50 });
            Products.Add(new Model() { Month = "Nov", LowMetric = 36, HighMetric = 68 });
            Products.Add(new Model() { Month = "Dec", LowMetric = 20, HighMetric = 90 });
        }

        public ObservableCollection<Model> Products { get; set; }
    }
}
