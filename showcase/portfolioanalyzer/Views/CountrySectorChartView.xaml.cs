#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;

namespace syncfusion.portfolioanalyzerdemo.wpf
{
    /// <summary>
    /// Interaction logic for CountrySectorChartView.xaml
    /// </summary>
    public partial class CountrySectorChartView 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountrySectorChartView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public CountrySectorChartView(CountrySectorChartViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
            this.IsVisibleChanged += delegate(object sender, DependencyPropertyChangedEventArgs e)
            {
                viewModel.IsVisible = (bool)e.NewValue;
            };            
        }
    }
}
