#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Syncfusion.Windows.SampleLayout;
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

namespace WaterMark
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            SneakerDetails sneaker = new SneakerDetails();
            InitializeComponent();
            this.DataContext = sneaker.SneakersDetail;
        }
    }

    public class Sneaker
    {
        public double ItemsCount  { get; set; }

        public string Brand { get; set; }

    }

    public class SneakerDetails
    {
        public SneakerDetails()
        {
            this.SneakersDetail = new ObservableCollection<Sneaker>();

            SneakersDetail.Add(new Sneaker() { Brand = "Adidas", ItemsCount = 25 });
            SneakersDetail.Add(new Sneaker() { Brand = "Nike", ItemsCount = 17 });
            SneakersDetail.Add(new Sneaker() { Brand = "Reebok", ItemsCount = 34 });
            SneakersDetail.Add(new Sneaker() { Brand = "Fila", ItemsCount = 18 });
            SneakersDetail.Add(new Sneaker() { Brand = "Puma", ItemsCount = 10 });
            SneakersDetail.Add(new Sneaker() { Brand = "Fastrack", ItemsCount = 27 });
            SneakersDetail.Add(new Sneaker() { Brand = "Yepme", ItemsCount = 17 });
            SneakersDetail.Add(new Sneaker() { Brand = "Zovi", ItemsCount = 10 });
            SneakersDetail.Add(new Sneaker() { Brand = "Woodland", ItemsCount = 22 });
        }

        public ObservableCollection<Sneaker> SneakersDetail { get; set; }
    }
}
