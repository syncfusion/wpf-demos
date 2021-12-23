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
    public class GroupBarControlRegionAdapter : RegionAdapterBase<GroupBar>
    {
        public GroupBarControlRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {

        }

        protected override void Adapt(IRegion region, GroupBar regionTarget)
        {
            region.Views.CollectionChanged += delegate
            {
                foreach (var item in region.Views.Cast<GroupBarItem>())
                {
                    if (!regionTarget.Items.Contains(item))
                    {
                        regionTarget.Items.Add(item);
                    }
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new Region();
        }
    }
}
