#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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

namespace StackingArea100Chart
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
    public class StackingAreaChartViewModel
    {
        public StackingAreaChartViewModel()
        {

            this.Accidents = new ObservableCollection<Accidents>();
            DateTime mth = new DateTime(2011, 1, 1);
            Accidents.Add(new Accidents() { Margin = new Thickness(30, 0, 0, 0), Month = mth.AddMonths(1), Bus = 3, Car = 4, Truck = 5 });
            Accidents.Add(new Accidents() { Margin = new Thickness(0, 0, 0, 0), Month = mth.AddMonths(2), Bus = 4, Car = 5, Truck = 6 });
            Accidents.Add(new Accidents() { Margin = new Thickness(0, 0, 0, 0), Month = mth.AddMonths(3), Bus = 3, Car = 4, Truck = 5 });
            Accidents.Add(new Accidents() { Margin = new Thickness(0, 0, 0, 0), Month = mth.AddMonths(4), Bus = 4, Car = 5, Truck = 6 });
            Accidents.Add(new Accidents() { Margin = new Thickness(0, 0, 0, 0), Month = mth.AddMonths(5), Bus = 7, Car = 8, Truck = 7 });
            Accidents.Add(new Accidents() { Margin = new Thickness(0, 0, 0, 0), Month = mth.AddMonths(6), Bus = 4, Car = 5, Truck = 6 });
            Accidents.Add(new Accidents() { Margin = new Thickness(0, 0, 0, 0), Month = mth.AddMonths(7), Bus = 7, Car = 8, Truck = 7 });
            Accidents.Add(new Accidents() { Margin = new Thickness(0, 0, 30, 0), Month = mth.AddMonths(8), Bus = 4, Car = 5, Truck = 6 });
        }

        public ObservableCollection<Accidents> Accidents
        {
            get;
            set;
        }
    }
    public class Accidents
    {
        public Thickness Margin { get; set; }
        public DateTime Month { get; set; }
        public double Bus { get; set; }
        public double Car { get; set; }
        public double Truck { get; set; }
    }
}
