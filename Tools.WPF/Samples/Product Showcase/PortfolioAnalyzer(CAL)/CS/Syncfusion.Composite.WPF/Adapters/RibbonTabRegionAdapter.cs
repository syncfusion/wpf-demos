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
    /// Ribbon Tab Region Adapter that helps to host Ribbon Bars.
    /// </summary>
    public class RibbonTabRegionAdapter : RegionAdapterBase<RibbonTab>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RibbonTabRegionAdapter"/> class.
        /// </summary>
        /// <param name="regionBehaviorFactory">The region behavior factory.</param>
        public RibbonTabRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {

        }

        /// <summary>
        /// Adapts the specified region.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="regionTarget">The region target.</param>
        protected override void Adapt(IRegion region, RibbonTab regionTarget)
        {
            region.Views.CollectionChanged += delegate
            {
                foreach (var bar in region.Views.Cast<RibbonBar>())
                {
                    if (!regionTarget.Items.Contains(bar))
                    {
                        regionTarget.Items.Add(bar);
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
            return new AllActiveRegion();
        }
    }
}
