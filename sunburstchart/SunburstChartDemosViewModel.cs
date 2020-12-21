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

namespace syncfusion.sunburstchartdemos.wpf
{
    public class SunburstChartDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new SunburstChartProductDemos());
            return productdemos;
        }
    }

    public class SunburstChartProductDemos : ProductDemo
    {
        public SunburstChartProductDemos()
        {
            this.Product = "Sunburst Chart";
            this.ProductCategory = "CHARTS";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "SUNBURST CHART", DemoViewType = typeof(GettingStarted), Description = "This sample demonstrates the basic features in sunburst chart." });
            this.Demos.Add(new DemoInfo() { SampleName = "Animation", GroupName = "SUNBURST CHART", DemoViewType = typeof(Animation), Description = "This sample demonstrates animation functionality in sunburst chart." });
            this.Demos.Add(new DemoInfo() { SampleName = "Selection", GroupName = "SUNBURST CHART", DemoViewType = typeof(Selection), Description = "This sample demonstrates interactive selection functionality in sunburst chart." });
            this.Demos.Add(new DemoInfo() { SampleName = "Zoom", GroupName = "SUNBURST CHART", DemoViewType = typeof(ZoomableSunburst), Description = "This sample demonstrates interactive zooming functionality in sunburst chart." });
        }
    }
}
