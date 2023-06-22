#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M8 16C3.59 16 0 12.41 0 8C0 3.59 3.59 0 8 0C12.41 0 16 3.59 16 8C16 12.41 12.41 16 8 16ZM14.9823 8.5H13.4492C13.1692 8.5 12.9492 8.28 12.9492 8C12.9492 7.72 13.1692 7.5 13.4492 7.5H14.9823C14.7369 4.03764 11.9624 1.26314 8.5 1.01767V2.55C8.5 2.83 8.28 3.05 8 3.05C7.72 3.05 7.5 2.83 7.5 2.55V1.01767C4.03764 1.26314 1.26314 4.03764 1.01767 7.5H2.54977C2.82977 7.5 3.04977 7.72 3.04977 8C3.04977 8.28 2.82977 8.5 2.54977 8.5H1.01767C1.27485 12.1275 4.3081 15 8 15C11.6919 15 14.7251 12.1275 14.9823 8.5ZM5.88979 4.01993L9.06979 7.61993L9.06405 7.62353C9.24602 7.80775 9.35836 8.06091 9.35836 8.34031C9.35836 8.90364 8.90169 9.36031 8.33836 9.36031C7.8848 9.36031 7.50037 9.06427 7.36778 8.65487L5.32979 4.39993C5.10979 4.05993 5.60979 3.71993 5.88979 4.01993Z"),
                Width = 16,
                Height = 16,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/DataVisualization.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The Gauge provides customizable data visualization real-time monitoring, and optimal performance.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Gauge.png", UriKind.RelativeOrAbsolute));

            DemoInfo CircularGaugeGettingStartedDemo = new DemoInfo()
            {
                SampleName = "Getting Started",

                GroupName = "CIRCULAR GAUGE",

                Description = "Circular gauges are perfect for presenting values of a specific range. They can be used to create sophisticated dashboards, clocks, industrial equipment, medical equipment, and much more.",

                DemoViewType = typeof(GettingStarted),

            };

            List<Documentation> CircularGaugeHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "CircularGauge - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/radial-gauge/getting-started")}
            };

            CircularGaugeGettingStartedDemo.Documentations = CircularGaugeHelpDocuments;
            this.Demos.Add(CircularGaugeGettingStartedDemo);
            this.Demos.Add(new DemoInfo() { SampleName = "Customization", GroupName = "CIRCULAR GAUGE", DemoViewType = typeof(Customization), Description = "This sample showcases the scale, range and header customization of the circular gauge control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Multiple Scale", GroupName = "CIRCULAR GAUGE", DemoViewType = typeof(MultipleScale), Description = "This sample showcases the multiple scale capability of circular gauge control. Then, symbol pointer can be interactively dragged to a new position using mouse and pointer value changed event." });
            this.Demos.Add(new DemoInfo() { SampleName = "Pointer Customization", GroupName = "CIRCULAR GAUGE", DemoViewType = typeof(PointerCustomization), Description = "This sample showcases the needle, range and symbol pointers of gauge control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Direction Compass", GroupName = "CIRCULAR GAUGE", DemoViewType = typeof(DirectionCompass), Description = "This sample showcases the labels and pointers customization of the circular gauge control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Annotation", GroupName = "CIRCULAR GAUGE", DemoViewType = typeof(Annotation), Description = "This sample demonstrates the Annotation feature in Circular Gauge." });

            DemoInfo LinearGaugeGettingStartedDemo = new DemoInfo()
            {
                SampleName = "Getting Started",

                GroupName = "LINEAR GAUGE",

                Description = "This sample showcases the customization of ticks, ranges and labels of the linear gauge control",

                DemoViewType = typeof(LinearGauge),

            };

            List<Documentation> LinearGaugeHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "LinearGauge - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/linear-gauge/getting-started")}
            };

            LinearGaugeGettingStartedDemo.Documentations = LinearGaugeHelpDocuments;
            this.Demos.Add(LinearGaugeGettingStartedDemo);

            DemoInfo DigitalGaugeGettingStartedDemo = new DemoInfo()
            {
                SampleName = "Getting Started",

                GroupName = "DIGITAL GAUGE",

                Description = "This sample showcases the customization of digital characters of the digital gauge control and ease integration with the application.",

                DemoViewType = typeof(DigitalGauge),

            };

            List<Documentation> DigitalGaugeHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "DigitalGauge - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/digital-gauge/getting-started")}
            };

            DigitalGaugeGettingStartedDemo.Documentations = DigitalGaugeHelpDocuments;
            this.Demos.Add(DigitalGaugeGettingStartedDemo);
            
        }
    }
}
