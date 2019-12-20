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
using System.ComponentModel;

    
namespace PortfolioAnalyzer.StockListModule
{
    /// <summary>
    /// Interaction logic for StockListView.xaml
    /// </summary>
    public partial class StockListView 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StockListView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public StockListView(StockListViewModel viewModel)
        {
            InitializeComponent();
            stockGrid.SelectedItem = viewModel.StockList.ElementAt(0);
            this.DataContext = viewModel;

            this.IsVisibleChanged += delegate(object sender, DependencyPropertyChangedEventArgs e)
            {
                viewModel.IsVisible = (bool)e.NewValue;
            };            
        }    
    }
}
