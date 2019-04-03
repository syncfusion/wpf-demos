#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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

namespace HistogramChartDemo_2013
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

    public class ViewModel
    {
        public ViewModel()
        {
            this.Product = new ObservableCollection<Model>();

            Product.Add(new Model() { Price = 3 });
            Product.Add(new Model() { Price = 4 });
            Product.Add(new Model() { Price = 6 });
            Product.Add(new Model() { Price = 7 });
            Product.Add(new Model() { Price = 8 });
            Product.Add(new Model() { Price = 11 });
            Product.Add(new Model() { Price = 13 });
            Product.Add(new Model() { Price = 12 });
            Product.Add(new Model() { Price = 14 });
            Product.Add(new Model() { Price = 17 });
            Product.Add(new Model() { Price = 18 });
            Product.Add(new Model() { Price = 19 });
            Product.Add(new Model() { Price = 16 });
            Product.Add(new Model() { Price = 20 });
            Product.Add(new Model() { Price = 21 });
            Product.Add(new Model() { Price = 22 });
            Product.Add(new Model() { Price = 23 });
            Product.Add(new Model() { Price = 23 });
            Product.Add(new Model() { Price = 22 });
            Product.Add(new Model() { Price = 23 });
            Product.Add(new Model() { Price = 26 });
            Product.Add(new Model() { Price = 28 });
            Product.Add(new Model() { Price = 26 });
            Product.Add(new Model() { Price = 26 });
            Product.Add(new Model() { Price = 27 });
            Product.Add(new Model() { Price = 31 });
            Product.Add(new Model() { Price = 33 });
            Product.Add(new Model() { Price = 31 });
            Product.Add(new Model() { Price = 33 });
            Product.Add(new Model() { Price = 38 });
            Product.Add(new Model() { Price = 37 });
            Product.Add(new Model() { Price = 39 });
            Product.Add(new Model() { Price = 42 });
            Product.Add(new Model() { Price = 44 });
        }

        public ObservableCollection<Model> Product { get; set; }
    }

    public class Model
    {
        public double Price { get; set; } 

        public double Value { get; set; }

    }
}
