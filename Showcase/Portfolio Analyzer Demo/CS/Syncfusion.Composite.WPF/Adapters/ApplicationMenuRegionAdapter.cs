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
using System.Windows;
using Microsoft.Practices.Composite.Regions;

namespace Syncfusion.Composite.WPF
{
    /// <summary>
    /// Application Menu Region Adapter that helps to inject Ribbon MenuItems.
    /// </summary>
    public class ApplicationMenuRegionAdapter : RegionAdapterBase<ApplicationMenu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationMenuRagionAdapter"/> class.
        /// </summary>
        /// <param name="regionBehaviorFactory">The region behavior factory.</param>
        public ApplicationMenuRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {

        }

        /// <summary>
        /// Adapts the specified region.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="regionTarget">The region target.</param>
        protected override void Adapt(IRegion region, ApplicationMenu regionTarget)
        {
            region.Views.CollectionChanged += delegate
            {
                foreach (var element in region.Views.Cast<FrameworkElement>())
                {
                    if (!regionTarget.Items.Contains(element))
                    {
                        int i = 0;
                        if (element.Tag != null)
                        {
                            i = Convert.ToInt32(element.Tag);
                        }

                        regionTarget.Items.Insert(i, element);
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
