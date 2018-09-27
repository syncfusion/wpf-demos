using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Composite.Events;
using PortfolioAnalyzer.Infrastructure;

namespace PortfolioAnalyzer.PortfolioGridModule
{
    /// <summary>
    /// Represents the PortfolioGridModule class. This module is responsible for adding the PortfolioGridView to the Docking region. 
    /// </summary>
    public class PortfolioGridModule : IModule
    {
        #region Class Members

        private readonly IRegionManager regionManager;
        private readonly IModuleManager moduleManager;
        private readonly IEventAggregator eventagg;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="PortfolioGridModule"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="moduleManager">The module manager.</param>
        /// <param name="eventagg">The eventagg.</param>
        public PortfolioGridModule(IRegionManager regionManager, IModuleManager moduleManager, IEventAggregator eventagg)
        {
            this.regionManager = regionManager;
            this.moduleManager = moduleManager;
            this.eventagg = eventagg;
        }


        /// <summary>
        /// Initializes this instance and adds the view to the region.
        /// </summary>
        public void Initialize()
        {
            PortfolioGridViewModel gridmodel = new PortfolioGridViewModel(eventagg);
            this.regionManager.Regions[RegionNames.DockingRegion].Add(new PortfolioGridView(gridmodel), "portfoliogridView");
        }
        
    }
}
