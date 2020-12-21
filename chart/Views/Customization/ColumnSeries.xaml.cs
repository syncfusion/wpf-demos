#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for ColumnSeries.xaml
    /// </summary>
    public partial class ColumnSeries : UserControl
    {
        public ColumnSeries()
        {
            InitializeComponent();

            var binding1 = new Binding();
            binding1.Source = SfChart1;
            binding1.Path = new PropertyPath("ActualWidth");
            HeaderStack1.SetBinding(StackPanel.WidthProperty,binding1);

            var binding2 = new Binding();
            binding2.Source = SfChart2;
            binding2.Path = new PropertyPath("ActualWidth");
            HeaderStack2.SetBinding(StackPanel.WidthProperty,binding2);
        }
    }
}
