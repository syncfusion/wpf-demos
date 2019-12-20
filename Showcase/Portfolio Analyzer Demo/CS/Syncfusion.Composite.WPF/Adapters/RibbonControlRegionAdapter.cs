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
using Microsoft.Practices.Composite.Presentation.Regions;
using Syncfusion.Windows.Tools.Controls;
using Microsoft.Practices.Composite.Regions;

namespace Syncfusion.Composite.WPF
{
    /// <summary>
    /// Ribbon Control Region Adapter that helps to inject RibbonTab.
    /// </summary>
    public class RibbonControlRegionAdapter : RegionAdapterBase<Ribbon>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RibbonControlRegionAdapter"/> class.
        /// </summary>
        /// <param name="regionBehaviorFactory">The region behavior factory.</param>
        public RibbonControlRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {

        }

        /// <summary>
        /// Adapts the specified region.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="regionTarget">The region target.</param>
        protected override void Adapt(IRegion region, Ribbon regionTarget)
        {
            region.Views.CollectionChanged += delegate
            {
                foreach (var tab in region.Views.Cast<RibbonTab>())
                {
                    if (!regionTarget.Items.Contains(tab))
                    {
                        regionTarget.Items.Add(tab);
                    }
                }
            };
        }

        /// <summary>
        /// Attaches the behaviors.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="regionTarget">The region target.</param>
        protected override void AttachBehaviors(IRegion region, Ribbon regionTarget)
        {
            // Add the behavior that syncs the items source items with the rest of the items
            region.Behaviors.Add(RibbonSyncBehavior.BehaviorKey, new RibbonSyncBehavior()
            {
                HostControl = regionTarget
            });

            base.AttachBehaviors(region, regionTarget);
        }

        /// <summary>
        /// Creates the region.
        /// </summary>
        /// <returns></returns>
        protected override IRegion CreateRegion()
        {
            return new Region();
        }





    }
}
