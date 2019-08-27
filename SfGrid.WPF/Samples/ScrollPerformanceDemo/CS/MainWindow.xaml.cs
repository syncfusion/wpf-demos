#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
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
using Syncfusion.UI.Xaml.Grid.Helpers;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ScrollPerformanceDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();            
            this.datagrid.Loaded += datagrid_Loaded;
        }

        /// <summary>
        /// Wired to show the busy indicator when generating data source.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void datagrid_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<StockData> stocks = null;
            var viewmodel = this.DataContext as StocksViewModel;
            var worker = new BackgroundWorker();
            worker.DoWork += (o, ae) =>
                {                 
                    stocks = viewmodel.GenerateDataSource(20000);
                };

            worker.RunWorkerCompleted += (o, ae) =>
            {
                viewmodel.Stocks = stocks;
                viewmodel.IsBusy = false;
            };

            worker.RunWorkerAsync();
        }
    }
}
