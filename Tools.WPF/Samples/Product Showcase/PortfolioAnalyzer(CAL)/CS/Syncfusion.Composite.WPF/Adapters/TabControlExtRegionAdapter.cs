using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Composite.Presentation.Regions;
using Syncfusion.Windows.Tools.Controls;
using System.Windows;

namespace Syncfusion.Composite.WPF
{
    public class TabControlExtRegionAdapter : RegionAdapterBase<TabControlExt>
    {
        public TabControlExtRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            :base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, TabControlExt regionTarget)
        {
            region.Views.CollectionChanged += delegate
            {
                foreach (var tab in region.Views.Cast<FrameworkElement>())
                {
                    if (!regionTarget.Items.Contains(tab))
                    {
                        regionTarget.Items.Add(tab);
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
