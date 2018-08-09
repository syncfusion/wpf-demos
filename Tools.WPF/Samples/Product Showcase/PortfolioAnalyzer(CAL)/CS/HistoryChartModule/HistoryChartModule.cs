
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
using System;
using PortfolioAnalyzer.HistoryChartModule;
using Microsoft.Practices.Composite.Events;
using PortfolioAnalyzer.Infrastructure;

namespace PortfolioAnalyzer.HistoryChartModule
{
    /// <summary>
    /// Represents the HistoryChartModule class. This module is responsible for adding the HistoryChartView to the Docking region. 
    /// </summary>
    public class HistoryChartModule : IModule
    {
        #region Class Members
        private readonly IUnityContainer container;
        private readonly IRegionViewRegistry regionViewRegistry;
        private readonly IRegionManager regionManager;
        private IModuleManager moduleManager;
        private IEventAggregator eventaggregator;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="HistoryChartModule"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="regionViewRegistry">The region view registry.</param>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="eventagg">The eventagg.</param>
        public HistoryChartModule(IUnityContainer container, IRegionViewRegistry regionViewRegistry, IRegionManager regionManager, IEventAggregator eventagg)
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
            HistoryChartViewModel chartmodel = new HistoryChartViewModel(eventaggregator);
            this.regionManager.Regions[RegionNames.DockingRegion].Add(new HistoryChartView(chartmodel), "historychartView");
        }
    }
}
