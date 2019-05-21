#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
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
using Syncfusion.UI.Xaml.Charts;

namespace ContourChartDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            SetData();
        }

        private void SetData()
        {
            int x = 0;
            for (double i = -10; i <= 10; i++,x++)
            {
                int z = 0;
                for (double j = -10; j <= 10; j++,z++)
                {
                    double y = i*Math.Sin(j) + j*Math.Sin(i);
                    surface.Data.AddPoints(x,y,z);
                }
            }

            surface.RowSize = 21;
            surface.ColumnSize = 21;
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (surface != null)
            {
                if (comboBox.SelectedIndex == 0)
                    surface.Type = SurfaceType.Contour;
                else
                    surface.Type = SurfaceType.WireframeContour;
            }
        }
    }
}
