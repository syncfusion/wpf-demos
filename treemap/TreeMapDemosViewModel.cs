#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.treemapdemos.wpf
{
    public class TreeMapDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new TreeMapProductDemos());
            return productdemos;
        }
    }

    public class TreeMapProductDemos : ProductDemo
    {
        public TreeMapProductDemos()
        {
            this.Product = "Treemap";
            this.ProductCategory = "DATA VISUALIZATION"; 
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "TREEMAP", DemoViewType = typeof(GettingStarted), Description = "This sample showcases the layouts, legends and range color mapping of the TreeMap control" });
            this.Demos.Add(new DemoInfo() { SampleName = "Hierarchical Collection Treemap", GroupName = "TREEMAP", DemoViewType = typeof(HierarchicalCollectionTreeMap), Description = "This sample showcases the Hierarchical Level data capability of TreeMap control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Treemap Customization", GroupName = "TREEMAP", DemoViewType = typeof(TreeMapCustomization), Description = "This sample showcases the leaf node customization capabilities of the TreeMap control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Treemap Drill Down", GroupName = "TREEMAP", DemoViewType = typeof(TreeMapDrillDown), Description = "This sample showcases the drilldown capability of the TreeMap control." });
        }
    }
}
