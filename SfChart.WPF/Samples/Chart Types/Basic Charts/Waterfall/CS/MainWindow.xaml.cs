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
using System.ComponentModel;
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

namespace WaterfallChart
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

    public class Model
    {
        public double Value  { get; set; }

        public string Category { get; set; }

        public bool IsSummary { get; set; }
    }

    public class ViewModel
    {
        public ViewModel()
        {
            this.RevenueDetails = new ObservableCollection<Model>();

            RevenueDetails.Add(new Model() { Category= "Income", Value=4711 });
            RevenueDetails.Add(new Model() { Category = "Marketing and sales", Value = -427 });
            RevenueDetails.Add(new Model() { Category = "Research", Value = -588 });
            RevenueDetails.Add(new Model() { Category = "Development", Value = -688 });
            RevenueDetails.Add(new Model() { Category = "Other revenue", Value = 1030 });
            RevenueDetails.Add(new Model() { Category = "Intermediate sum", Value = 4711 ,IsSummary=true});
            RevenueDetails.Add(new Model() { Category = "Administrative", Value = -780 });
            RevenueDetails.Add(new Model() { Category = "Other expense", Value = -361 });
            RevenueDetails.Add(new Model() { Category = "Income tax", Value = -695 });
            RevenueDetails.Add(new Model() { Category = "Net profit", Value = -695 ,IsSummary=true});
        }

        public ObservableCollection<Model> RevenueDetails { get; set; }
    }
    
}
