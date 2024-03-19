#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
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

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for SelectionBehavior.xaml
    /// </summary>
    public partial class SeriesSelection : DemoControl
    {
        public SeriesSelection()
        {
            InitializeComponent();                
        }

        protected override void Dispose(bool disposing)
        {
            seriesSelectionChart.Dispose();
            base.Dispose(disposing);
        }

        private void selectionStyleCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selectionStyleCombo.SelectedItem is SelectionStyle selectionStyle)
            {
                if (selectionStyle == SelectionStyle.Single || selectionStyle == SelectionStyle.Multiple)
                {
                    ClearSelectedItems();
                }
            }
        }

        private void ClearSelectedItems()
        {
            foreach (var series in seriesSelectionChart.Series)
            {
                series.Opacity = 0.5;
            }
        }

        private void chart_SelectionChanged(object sender, Syncfusion.UI.Xaml.Charts.ChartSelectionChangedEventArgs e)
        {

            foreach (var series in seriesSelectionChart.Series)
            {
                series.Opacity = 0.5;
            }

            if (e.SelectedSeriesCollection.Count > 0)
            {
                foreach (var series in e.SelectedSeriesCollection)
                {
                    series.Opacity = 1;
                }
            }
        }
    }
}
