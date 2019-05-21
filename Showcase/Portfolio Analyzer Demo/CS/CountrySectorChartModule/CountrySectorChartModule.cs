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
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Composite.Events;
using PortfolioAnalyzer.Infrastructure;

namespace PortfolioAnalyzer.CountrySectorChartModule
{
    /// <summary>
    /// Represents the CountrySectorChartModule class. This module is responsible for adding the CountrySectorChartView to the Docking region. 
    /// </summary>
    public class CountrySectorChartModule : IModule
    {
        #region IModule Members
        private readonly IUnityContainer container;
        private readonly IRegionViewRegistry regionViewRegistry;
        private readonly IRegionManager regionManager;
        private IModuleManager moduleManager;
        private readonly IEventAggregator eventaggregator;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CountrySectorChartModule"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="regionViewRegistry">The region view registry.</param>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="eventagg">The eventagg.</param>
        public CountrySectorChartModule(IUnityContainer container, IRegionViewRegistry regionViewRegistry, IRegionManager regionManager, IEventAggregator eventagg)
        {
            this.container = container;
            this.regionViewRegistry = regionViewRegistry;
            this.regionManager = regionManager;
            this.eventaggregator = eventagg;
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
            CountrySectorChartViewModel chartmodel = new CountrySectorChartViewModel(eventaggregator);
            this.regionManager.Regions[RegionNames.DockingRegion].Add(new CountrySectorChartView(chartmodel), "countrysectorchartView");
        }

    }
}
