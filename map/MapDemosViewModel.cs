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

namespace syncfusion.mapdemos.wpf
{
    public class MapDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new MapProductDemos());
            return productdemos;
        }
    }

    public class MapProductDemos : ProductDemo
    {
        public MapProductDemos()
        {
            this.Product = "Map";
            this.ProductCategory = "DATA VISUALIZATION";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "MAP", DemoViewType = typeof(GettingStarted), Description = "This sample showcases the markers visualization capability of the Map control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Bubble Visualization", GroupName = "MAP", DemoViewType = typeof(BubbleVisualization), Description = "This sample showcases the bubbles visualization capability of the Map control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Heat Map", GroupName = "MAP", DemoViewType = typeof(HeatMap), Description = "This sample showcases the RangeColorMapping and labels customization of the Map control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Map Points", GroupName = "MAP", DemoViewType = typeof(MapPoints), Description = "This sample showcases the multipoints rendering capability of the Map control." });
            this.Demos.Add(new DemoInfo() { SampleName = "MultiLayer", GroupName = "MAP", DemoViewType = typeof(MultiLayer), Description = "This sample showcases the multilayers rendering capability of the Map control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Shape Selection", GroupName = "MAP", DemoViewType = typeof(ShapeSelection), Description = "This sample showcases the shape selection capability of the Map control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Election Result", GroupName = "MAP", DemoViewType = typeof(ElectionResultDemo), Description = "This sample showcases the equals color mapping capability of Map control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Data Labels", GroupName = "MAP", DemoViewType = typeof(DataLabels), Description = "Data labels are used to display the values of shapes. This sample shows how to enable the smart label appearance." });
            this.Demos.Add(new DemoInfo() { SampleName = "Open Street Map", GroupName = "MAP", DemoViewType = typeof(OpenStreetMaps), Description = "This sample showcases the Open Street Map in the Maps control" });
        }
    }
}
