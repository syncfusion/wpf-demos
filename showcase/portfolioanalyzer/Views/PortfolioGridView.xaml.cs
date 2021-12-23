#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;

namespace syncfusion.portfolioanalyzerdemo.wpf
{
    /// <summary>
    /// Interaction logic for PortfolioGridView.xaml
    /// </summary>
    public partial class PortfolioGridView 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PortfolioGridView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public PortfolioGridView(PortfolioGridViewModel viewModel)
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