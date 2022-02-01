#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.portfolioanalyzerdemo.wpf
{
    /// <summary>
    /// Interaction logic for HistoryChartView.xaml
    /// </summary>
    public partial class HistoryChartView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HistoryChartView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public HistoryChartView(HistoryChartViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
