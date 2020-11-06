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

namespace syncfusion.gaugedemos.wpf
{
    public class GaugeDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new GaugeProductDemos());
            return productdemos;
        }
    }

    public class GaugeProductDemos : ProductDemo
    {
        public GaugeProductDemos()
        {
            this.Product = "Gauge";
            this.ProductCategory = "DATA VISUALIZATION";
            this.Tag = Tag.Updated;
            this.Demos = new List<DemoInfo>();

            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "CIRCULAR GAUGE", DemoViewType = typeof(GettingStarted), Description = "Circular gauges are perfect for presenting values of a specific range. They can be used to create sophisticated dashboards, clocks, industrial equipment, medical equipment, and much more." });
            this.Demos.Add(new DemoInfo() { SampleName = "Customization", GroupName = "CIRCULAR GAUGE", DemoViewType = typeof(Customization), Description = "This sample showcases the scale, range and header customization of the circular gauge control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Multiple Scale", GroupName = "CIRCULAR GAUGE", DemoViewType = typeof(MultipleScale), Description = "This sample showcases the multiple scale capability of circular gauge control. Then, symbol pointer can be interactively dragged to a new position using mouse and pointer value changed event." });
            this.Demos.Add(new DemoInfo() { SampleName = "Pointer Customization", GroupName = "CIRCULAR GAUGE", DemoViewType = typeof(PointerCustomization), Description = "This sample showcases the needle, range and symbol pointers of gauge control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Direction Compass", GroupName = "CIRCULAR GAUGE", DemoViewType = typeof(DirectionCompass), Tag = Tag.Updated, Description = "This sample showcases the labels and pointers customization of the circular gauge control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Annotation", GroupName = "CIRCULAR GAUGE", DemoViewType = typeof(Annotation), Description = "This sample demonstrates the Annotation feature in Circular Gauge." });
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "LINEAR GAUGE", DemoViewType = typeof(LinearGauge), Description = "This sample showcases the customization of ticks, ranges and labels of the linear gauge control" });
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "DIGITAL GAUGE", DemoViewType = typeof(DigitalGauge), Description = "This sample showcases the customization of digital characters of the digital gauge control and ease integration with the application." });
        }
    }
}
