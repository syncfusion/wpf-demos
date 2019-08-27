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

namespace ColumnChart
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
        public double ItemsCount  { get; set; }

        public string Brand { get; set; }
    }

    public class ViewModel
    {
        public ViewModel()
        {
            this.SneakersDetail = new ObservableCollection<Model>();

            SneakersDetail.Add(new Model() { Brand = "Adidas", ItemsCount = 25 });
            SneakersDetail.Add(new Model() { Brand = "Nike", ItemsCount = 17 });
            SneakersDetail.Add(new Model() { Brand = "Reebok", ItemsCount = 30 });
            SneakersDetail.Add(new Model() { Brand = "Fila", ItemsCount = 18 });
            SneakersDetail.Add(new Model() { Brand = "Puma", ItemsCount = 10 });
        }

        public ObservableCollection<Model> SneakersDetail { get; set; }
    }
    
}
