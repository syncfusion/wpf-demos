#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows.Controls;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Composite.Modularity;
using System.Windows.Input;
using Microsoft.Practices.Composite.Events;
using PortfolioAnalyzer.Infrastructure;
using System.Windows;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools;
using Syncfusion.Windows.Tools.Controls;

namespace PortfolioAnalyzer.RibbonModule
{
    /// <summary>
    /// Interaction logic for EmployeesView.xaml
    /// </summary>
    public partial class SelectSkin
    {
        IEventAggregator eventAggregator;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectSkin"/> class.
        /// </summary>
        /// <param name="eventAgg">The event agg.</param>
        /// <param name="viewModel">The view model.</param>
        public SelectSkin(IEventAggregator eventAgg, AppMenuViewModel viewModel)
        {
            this.eventAggregator = eventAgg;
            InitializeComponent();
            this.DataContext = viewModel;
        }    
    }
}
