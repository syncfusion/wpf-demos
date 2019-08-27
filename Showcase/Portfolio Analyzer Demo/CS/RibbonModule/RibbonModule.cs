#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
//using PerformanceAnalyzer.Modules.EmployeeManagement.Employee.Controllers;
//using PerformanceAnalyzer.Modules.EmployeeManagement.Employee.Services;
using System;
using Microsoft.Practices.Composite.Events;

namespace PortfolioAnalyzer.RibbonModule
{
    public class RibbonModule : IModule
    {
        IEventAggregator eventAggregator;
        IModuleManager moduleManager;
        private readonly IUnityContainer container;
        private readonly IRegionViewRegistry regionViewRegistry;
        private readonly IRegionManager regionManager;
        /// <summary>
        /// Initializes a new instance of the <see cref="RibbonModule"/> class.
        /// </summary>
        /// <param name="eventAgg">The event agg.</param>
        /// <param name="container">The container.</param>
        /// <param name="regionViewRegistry">The region view registry.</param>
        /// <param name="regionManager">The region manager.</param>
        public RibbonModule( IEventAggregator eventAgg,IUnityContainer container, IRegionViewRegistry regionViewRegistry, IRegionManager regionManager)
        {
            this.eventAggregator = eventAgg;
            this.container = container;
            this.regionViewRegistry = regionViewRegistry;
            this.regionManager = regionManager;
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            try
            {
                moduleManager = container.Resolve<IModuleManager>();
            }
            catch (ResolutionFailedException ex)
            {
                if (ex.Message.Contains("IModuleCatalog"))
                {
                    throw new InvalidOperationException("NullModuleCatalogExceptio");
                }

                throw;
            }
          this.RegisterViewsWithRegions();
        }

        /// <summary>
        /// Registers the views with regions.
        /// </summary>
        private void RegisterViewsWithRegions()
        {
            DashBoardTabViewModel dmodel = new DashBoardTabViewModel(eventAggregator, moduleManager, regionManager, container);
            this.regionManager.Regions[RegionNames.RibbonRegion].Add(new DashboardTabView(eventAggregator, moduleManager, regionManager, container, dmodel), "dashboardView");
            ContributionAnalyzerTabViewModel cmodel = new ContributionAnalyzerTabViewModel(eventAggregator, moduleManager, regionManager, container);
            this.regionManager.Regions[RegionNames.RibbonRegion].Add(new ContributionAnalyzerTabView(eventAggregator, moduleManager, regionManager, container, cmodel), "contributionAnalyzerView");
            //this.regionManager.RegisterViewWithRegion(RegionNames.RibbonRegion, typeof(DashboardTabView));
            //this.regionManager.RegisterViewWithRegion(RegionNames.RibbonRegion, typeof(ContributionAnalyzerTabView));
            this.regionManager.RegisterViewWithRegion(RegionNames.AppMenuRegion, typeof(SelectView));

        }

    }
}
