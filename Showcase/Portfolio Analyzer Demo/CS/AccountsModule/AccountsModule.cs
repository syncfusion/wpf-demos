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
using Microsoft.Practices.Composite.Regions;
using PortfolioAnalyzer.AccountsModule;
using PortfolioAnalyzer.Infrastructure;
using Microsoft.Practices.Composite.Events;

namespace PortfolioAnalyzer.AccountsModule
{
    /// <summary>
    /// Represents the Accounts Module
    /// </summary>
    public class AccountsModule : IModule
    {
        private readonly IRegionManager regionManager;
        private readonly IModuleManager moduleManager;
        private readonly IEventAggregator eventagg;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsModule"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="moduleManager">The module manager.</param>
        /// <param name="eventagg">The eventagg.</param>
        public AccountsModule(IRegionManager regionManager, IModuleManager moduleManager, IEventAggregator eventagg)
        {
            this.regionManager = regionManager;
            this.moduleManager = moduleManager;
            this.eventagg = eventagg;
        }

        /// <summary>
        /// Initializes this instance and adds the View to the docking region.
        /// </summary>
        public void Initialize()
        {
            AccountsViewModel accmodel = new AccountsViewModel(eventagg);
            this.regionManager.Regions[RegionNames.DockingRegion].Add(new AccountsView(accmodel), "accountsView");
        }
    }
}
