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

namespace MultiLevelLabelsDemo_2015
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

        private void labelAlignment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            switch (combo.SelectedIndex)
            {
                case 0:
                    {
                        foreach (var label in xAxis.MultiLevelLabels)
                            label.LabelAlignment = LabelAlignment.Center;
                        foreach (var label in yAxis.MultiLevelLabels)
                            label.LabelAlignment = LabelAlignment.Center;
                    }
                    break;
                case 1:
                    {
                        foreach (var label in xAxis.MultiLevelLabels)
                            label.LabelAlignment = LabelAlignment.Far;
                        foreach (var label in yAxis.MultiLevelLabels)
                            label.LabelAlignment = LabelAlignment.Far;
                    }
                    break;
                case 2:
                    {
                        foreach (var label in xAxis.MultiLevelLabels)
                            label.LabelAlignment = LabelAlignment.Near;
                        foreach (var label in yAxis.MultiLevelLabels)
                            label.LabelAlignment = LabelAlignment.Near;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
