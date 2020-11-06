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

namespace syncfusion.sparklinedemos.wpf
{
    public class SparklineDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new SparklineProductDemos());
            return productdemos;
        }
    }

    public class SparklineProductDemos : ProductDemo
    {
        public SparklineProductDemos()
        {
            this.Product = "Sparkline";
            this.ProductCategory = "CHARTS";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "SPARKLINE", DemoViewType = typeof(GettingStarted), Description = "Sparkline is a very small chart, typically drawn without axes or coordinates. This demo illustrates different types of spark lines and its functionalities." });
            this.Demos.Add(new DemoInfo() { SampleName = "Sparkline In Grid", GroupName = "SPARKLINE", DemoViewType = typeof(Sparkline), Description = "This sample demonstrates how the sparkline can be loaded as content for a cell inside the grid." });
        }
    }
}
