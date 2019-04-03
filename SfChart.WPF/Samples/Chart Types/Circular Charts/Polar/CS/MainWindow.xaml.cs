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

namespace PolarChart
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

    public class PolarChartViewModel
    {
        public PolarChartViewModel()
        {
            this.PlantDetails = new ObservableCollection<PlantData>();
            this.PlantDetails.Add(new PlantData() {Direction = "North", Weed = 63, Flower = 42, Tree = 80 });
            this.PlantDetails.Add(new PlantData() {Direction = "NorthEast", Weed = 70, Flower = 40, Tree = 85 });
            this.PlantDetails.Add(new PlantData() {Direction = "East", Weed = 45, Flower = 25, Tree = 78 });
            this.PlantDetails.Add(new PlantData() {Direction = "SouthEast", Weed = 70, Flower = 40, Tree = 90 });
            this.PlantDetails.Add(new PlantData() {Direction = "South", Weed = 47, Flower = 20, Tree = 78 });
            this.PlantDetails.Add(new PlantData() {Direction = "SouthWest", Weed = 65, Flower = 45, Tree = 83 });
            this.PlantDetails.Add(new PlantData() {Direction = "West", Weed = 58, Flower = 40, Tree = 79 });
            this.PlantDetails.Add(new PlantData() {Direction = "NorthWest", Weed = 73, Flower = 28, Tree = 88 });
        }

        public ObservableCollection<PlantData> PlantDetails { get; set; }
    }

    public class PlantData
    {
        public string Direction { get; set; }
        public double Weed { get; set; }
        public double Flower { get; set; }
        public double Tree { get; set; }
    }
}
