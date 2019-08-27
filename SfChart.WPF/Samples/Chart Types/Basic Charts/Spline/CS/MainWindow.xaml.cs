#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using Syncfusion.Windows.SampleLayout;
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

namespace SplineChart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
    }

    public class SplineChartViewModel
    {
        public SplineChartViewModel()
        {
            this.List = new ObservableCollection<Data>();
            DateTime yr = new DateTime(2010, 1, 1);

            List.Add(new Data() { Year = yr.AddYears(0), India = 28, Germany = 31, Japan = 36, America = 39 });
            List.Add(new Data() { Year = yr.AddYears(1), India = 24, Germany = 28, Japan = 32, America = 36 });
            List.Add(new Data() { Year = yr.AddYears(2), India = 26, Germany = 30, Japan = 34, America = 40 });
            List.Add(new Data() { Year = yr.AddYears(3), India = 27, Germany = 36, Japan = 41, America = 44 });
            List.Add(new Data() { Year = yr.AddYears(4), India = 32, Germany = 36, Japan = 42, America = 45 });
            List.Add(new Data() { Year = yr.AddYears(5), India = 35, Germany = 39, Japan = 42, America = 48 });
        }

        public ObservableCollection<Data> List
        {
            get;
            set;
        }
    }

    public class Data
    {
        public DateTime Year { get; set; }

        public double India { get; set; }
        public double Germany { get; set; }
        public double Japan { get; set; }
        public double America { get; set; }
    }
}
