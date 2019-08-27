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

namespace SplineAreaChart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            SplineAreaSeries.StrokeThickness = 2;
            SplineAreaSeries.Stroke = new SolidColorBrush(Color.FromArgb(255, 27, 161, 226));
            SplineAreaSeries.Interior = new SolidColorBrush(Color.FromArgb(120, 27, 161, 226));
            SplineAreaSeries.AdornmentsInfo.SymbolStroke = SplineAreaSeries.Stroke;
      

            SplineAreaSeries1.StrokeThickness = 2;
            SplineAreaSeries1.Stroke = new SolidColorBrush(Color.FromArgb(255, 160, 80, 0));
            SplineAreaSeries1.Interior = new SolidColorBrush(Color.FromArgb(120, 160, 80, 0));
            SplineAreaSeries1.AdornmentsInfo.SymbolStroke = SplineAreaSeries1.Stroke;
      
        }
    }

    public class Model
    {
        public string ProdName { get; set; }

        public double Price { get; set; }

        public double Stock { get; set; }
    }

    public class ViewModel
    {
        public ViewModel()
        {
            this.Products = new ObservableCollection<Model>();
            Products.Add(new Model() {ProdName = "Toyota", Price = 11, Stock = 10 });
            Products.Add(new Model() {ProdName = "Volkswagen", Price = 8, Stock = 7 });
            Products.Add(new Model() {ProdName = "Audi", Price = 2, Stock = 1 });
            Products.Add(new Model() {ProdName = "Ford", Price = 8, Stock = 7 });
            Products.Add(new Model() {ProdName = "Mercedes", Price = 2, Stock = 1 });
            Products.Add(new Model() {ProdName = "Hyundai", Price = 5, Stock = 5 });
           
        }

        public ObservableCollection<Model> Products { get; set; }
    }
}
