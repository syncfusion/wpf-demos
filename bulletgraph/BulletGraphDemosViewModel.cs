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

namespace syncfusion.bulletgraphdemos.wpf
{
    public class BulletGraphDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new BulletGraphProductDemos());
            return productdemos;
        }
    }

    public class BulletGraphProductDemos : ProductDemo
    {
        public BulletGraphProductDemos()
        {
            this.Product = "Bullet Graph";
            this.ProductCategory = "DATA VISUALIZATION";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "BULLET GRAPH", DemoViewType = typeof(GettingStarted), Description= "This sample showcases the bulletgraph control's customization of ticks, labels and caption position." });
            this.Demos.Add(new DemoInfo() { SampleName = "Bullet Graph Measures", GroupName = "BULLET GRAPH", DemoViewType = typeof(BulletGraphMeasures), Description = "This sample showcases the customization with ticks and labels of the bulletgraph control, comparative and featured measures and customization of binding range stroke." });
        }
    }
}
