#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interactivity;

namespace ScrollPerformanceDemo
{
    public class DataGridBehavior : Behavior<SfDataGrid>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            (this.AssociatedObject as SfDataGrid).Loaded += OnLoaded;
            base.OnAttached();
        }

        /// <summary>
        /// Wired to show the busy indicator when generating data source.
        /// </summary>
        private void OnLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ObservableCollection<StockData> stocks = null;
            var viewModel = this.AssociatedObject.DataContext as StocksViewModel;
            var worker = new BackgroundWorker();
            worker.DoWork += (o, ae) =>
            {
                stocks = viewModel.GenerateDataSource(20000);
            };

            worker.RunWorkerCompleted += (o, ae) =>
            {
                viewModel.Stocks = stocks;
                viewModel.IsBusy = false;
            };

            worker.RunWorkerAsync();
        }


        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        protected override void OnDetaching()
        {
            (this.AssociatedObject as SfDataGrid).Loaded -= OnLoaded;
            base.OnDetaching();
        }
    }
}
