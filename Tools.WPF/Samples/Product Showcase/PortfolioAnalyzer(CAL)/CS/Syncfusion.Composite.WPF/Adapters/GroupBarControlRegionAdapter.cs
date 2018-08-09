using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Presentation.Regions;
using Syncfusion.Windows.Tools.Controls;
using Microsoft.Practices.Composite.Regions;

namespace Syncfusion.Composite.WPF
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
