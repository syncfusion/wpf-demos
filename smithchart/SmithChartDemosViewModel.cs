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

namespace syncfusion.smithchartdemos.wpf
{
    public class SmithChartDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new SmithChartProductDemos());
            return productdemos;
        }
    }

    public class SmithChartProductDemos : ProductDemo
    {
        public SmithChartProductDemos()
        {
            this.Product = "Smith Chart";
            this.ProductCategory = "CHARTS";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "SMITH CHART", DemoViewType = typeof(GettingStarted), Description = "This sample demonstrates the basic features in SmithChart." });
            this.Demos.Add(new DemoInfo() { SampleName = "Customization", GroupName = "SMITH CHART", DemoViewType = typeof(Customization), Description = "This sample demonstrates the customization of SmithChart features" });
        }
    }
}
