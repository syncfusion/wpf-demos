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

namespace RangeAreaChart
{
    
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            RangeAreaSeries.StrokeThickness = 3;
            RangeAreaSeries.Stroke = new SolidColorBrush(Color.FromArgb(255, 27, 161, 226));
            RangeAreaSeries.Interior = new SolidColorBrush(Color.FromArgb(150, 27, 161, 226));
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

            Products.Add(new Model() { ProdName = "Rice", Price = 20, Stock = 53 });
            Products.Add(new Model() {ProdName = "Wheat", Price = 22, Stock = 76 });
            Products.Add(new Model() { ProdName = "Oil", Price = 30, Stock = 80 });
            Products.Add(new Model() { ProdName = "Corn", Price = 26, Stock = 50 });
            Products.Add(new Model() { ProdName = "Gram", Price = 36, Stock = 68 });
            Products.Add(new Model() { ProdName = "Milk", Price = 20, Stock = 90 });
            Products.Add(new Model() { ProdName = "Butter", Price = 40, Stock = 73 });
        }

        public ObservableCollection<Model> Products { get; set; }
    }
}
