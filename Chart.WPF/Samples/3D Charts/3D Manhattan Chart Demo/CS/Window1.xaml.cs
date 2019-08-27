#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Chart;
using System.Reflection;
using Syncfusion.Windows.SampleLayout;

namespace _3DManhattanChart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Window1 : SampleLayoutWindow
    {
        public Window1()
        {
            InitializeComponent();            
        }

        #region HelperMethods
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //ChartSeries ser = new ChartSeries();
            //ser.DataSource = (this.DataContext as ColumnChartModel).Products;
            //ser.BindingPathX = "ProdId";
            //ser.IsEnabled = true;
            //ser.Label = "stock" + (Chart1.Areas[0].Series.Count + 1).ToString();
            //ser.Type = (ChartTypes)type.SelectedItem;
            //ser.BindingPathsY = new string[] { "Stock1" };
            //Chart1.Areas[0].Series.Add(ser);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //if (Chart1.Areas[0].Series.Count - 1 >= 0)
            //{
            //    Chart1.Areas[0].Series.RemoveAt(Chart1.Areas[0].Series.Count - 1);
            //}
        }
        private void Window_LayoutUpdated(object sender, RoutedEventArgs e)
        {
            //Chart1.Areas[0].View3DMode = true;
        }
        #endregion

    }   
}

