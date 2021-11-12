#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Linq;
using Microsoft.Practices.Composite.Presentation.Regions;
using Syncfusion.Windows.Tools.Controls;
using Microsoft.Practices.Composite.Regions;

namespace syncfusion.portfolioanalyzerdemo.wpf
{
    /// <summary>
    /// ContextTabGroup Region Adapter that helps to inject Ribbon Tab.
    /// </summary>
    public class ContextTabGroupRegionAdapter : RegionAdapterBase<ContextTabGroup>
    {
        public ContextTabGroupRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {

        }

        /// <summary>
        /// Adapts the specified region.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="regionTarget">The region target.</param>
        protected override void Adapt(IRegion region, ContextTabGroup regionTarget)
        {
            region.Views.CollectionChanged += delegate
            {
                foreach (var tab in region.Views.Cast<RibbonTab>())
                {
                    if (!regionTarget.RibbonTabs.Contains(tab))
                    {
                        regionTarget.RibbonTabs.Add(tab);
                    }
                }
            };
        }

        /// <summary>
        /// Creates the region.
        /// </summary>
        /// <returns></returns>
        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }
    }
}
