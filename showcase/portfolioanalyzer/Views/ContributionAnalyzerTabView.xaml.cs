#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Events;

namespace syncfusion.portfolioanalyzerdemo.wpf
{
    /// <summary>
    /// Interaction logic for ContributionAnalyzerTabView.xaml
    /// </summary>
    public partial class ContributionAnalyzerTabView 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContributionAnalyzerTabView"/> class.
        /// </summary>
        /// <param name="eventAgg">The event agg.</param>
        /// <param name="moduleManager">The module manager.</param>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="unityContainer">The unity container.</param>
        /// <param name="viewModel">The view model.</param>
        public ContributionAnalyzerTabView(IEventAggregator eventAgg, IModuleManager moduleManager, IRegionManager regionManager, IUnityContainer unityContainer, ContributionAnalyzerTabViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
