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

namespace AreaChart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            AreaSeries.StrokeThickness = 2;
            AreaSeries.Stroke = new SolidColorBrush(Color.FromArgb(255, 27, 161, 226));
            AreaSeries.Interior = new SolidColorBrush(Color.FromArgb(120, 27, 161, 226));
        }
        
    }

    public class Model
    {
        public double People { get; set; }

        public string FruitName { get; set; }

    }

    public class ViewModel
    {
        public ViewModel()
        {
            this.Fruits = new ObservableCollection<Model>();

            Fruits.Add(new Model() { FruitName = "Apple", People = 27 });
            Fruits.Add(new Model() { FruitName = "Orange", People = 33 });
            Fruits.Add(new Model() { FruitName = "Grapes", People = 15 });
            Fruits.Add(new Model() { FruitName = "Banana", People = 5 });
            Fruits.Add(new Model() { FruitName = "Blueberry", People = 20 });
        }

        public ObservableCollection<Model> Fruits { get; set; }
    }
}
