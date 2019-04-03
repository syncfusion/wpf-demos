#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
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

namespace SurfaceChartDemo
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

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (surface != null)
            {
                if (comboBox.SelectedIndex == 0)
                    surface.Type = SurfaceType.Surface;
                else
                    surface.Type = SurfaceType.WireframeSurface;
            }
        }

        private void Selector_OnSelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (surface != null)
            {
                if (comboBox.SelectedIndex == 0)
                {
                    DataValues=new ObservableCollection<Data>();
                    double inc = 8.0/35;
                    for (double x = -4; x < 4; x += inc)
                    {
                        for (double z = -4; z < 4; z += inc)
                        {
                            double y = 2*(x*x) + 2*(z*z) - 4;
                            DataValues.Add(new Data() {X = x, Y = y, Z = z});
                        }
                    }
                    surface.RowSize = 35;
                    surface.ColumnSize = 35;
                    surface.ItemsSource = DataValues;
                }

                else if (comboBox.SelectedIndex == 1)
                {
                    DataValues = new ObservableCollection<Data>();
                    double inc = 1.0 / 50;
                    for (double x = 0; x < 1; x += inc)
                    {
                        for (double z = 0; z < 1; z += inc)
                        {
                            double y = Math.Sin((x - 0.5)*2*Math.PI)*Math.Sin((z - 0.5)*2*Math.PI);
                            DataValues.Add(new Data() { X = x, Y = y, Z = z });
                        }
                    }
                    surface.RowSize = 50;
                    surface.ColumnSize = 50;
                    surface.ItemsSource = DataValues;
                }

                else
                {

                    DataValues = new ObservableCollection<Data>();
                    double inc = 7.0 / 50;
                    for (double x = -3.5; x < 3.5; x += inc)
                    {
                        for (double z = -3.5; z < 3.5; z += inc)
                        {
                            double y = (1 - Math.Cos(x*x + z*z)/(x*x + z*z))*1.25;
                            if (y < -3.0) y = 0;
                            DataValues.Add(new Data() { X = x, Y = y, Z = z });
                        }
                    }
                    surface.RowSize = 50;
                    surface.ColumnSize = 50;
                    surface.ItemsSource = DataValues;
                }
                    
            }
        }
        public ObservableCollection<Data> DataValues { get; set; }

        private void Surface_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            surface.ZoomLevel = 0.33d;
        }
    }

    public class Data
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}
