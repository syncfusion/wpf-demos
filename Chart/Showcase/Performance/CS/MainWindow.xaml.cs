#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using System.Diagnostics;
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

namespace High_Volume_Data_Demo
{
    public partial class MainWindow : SampleLayoutWindow
    {
        Stopwatch stopwatch = new Stopwatch();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataGenerator viewModel = new DataGenerator();
            ObservableCollection<Data> collection = viewModel.GenerateData();
            stopwatch.Restart();
            chart1.Series[0].ItemsSource = collection;
        }

        private void Chart_LayoutUpdated(object sender, EventArgs e)
        {
            if (stopwatch != null)
            {
                stopwatch.Stop();
                text.Text = "Total Time Taken : " + stopwatch.ElapsedMilliseconds.ToString() + " ms";
            }
        }
    }
}
