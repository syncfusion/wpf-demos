#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Practices.Composite.Events;

namespace syncfusion.portfolioanalyzerdemo.wpf
{
    /// <summary>
    /// Interaction logic for EmployeesView.xaml
    /// </summary>
    public partial class SelectView
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectView"/> class.
        /// </summary>
        /// <param name="eventAgg">The event agg.</param>
        /// <param name="viewModel">The view model.</param>
        public SelectView(IEventAggregator eventAgg, AppMenuViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }       
    }
}
