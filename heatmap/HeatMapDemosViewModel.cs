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

namespace syncfusion.heatmapdemos.wpf
{
    public class HeatMapDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new HeatMapProductDemos());
            return productdemos;
        }
    }

    public class HeatMapProductDemos : ProductDemo
    {
        public HeatMapProductDemos()
        {
            this.Product = "Heat Map";
            this.ProductCategory = "DATA VISUALIZATION"; 
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "HEAT MAP", Description = "This sample showcases the basic feature in HeatMap configured with a collection.", DemoViewType = typeof(GettingStarted) });
            this.Demos.Add(new DemoInfo() { SampleName = "Legend", GroupName = "HEAT MAP", Description = "This sample demonstrates the Legend features in HeatMap Control.", DemoViewType = typeof(LegendDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Virtualization", GroupName = "HEAT MAP", Description = "This sample demonstrates loading of large data set quickly though Virtualization feature of HeatMap Control.", DemoViewType = typeof(Virtualization) });
            this.Demos.Add(new DemoInfo() { SampleName = "Items Mapping", GroupName = "HEAT MAP", Description = "This sample demonstrates rendering of two different kind of data source in HeatMap Control. \n\nIn TableMapping rows represents an objects in collection, columns represents numerical properties of that object. \n\nIn CellMapping  each cell represent an object in collection, this collection is grouped based on specific property to form as rows and columns.", DemoViewType = typeof(ItemsMappingDemo) });

        }
    }
}
