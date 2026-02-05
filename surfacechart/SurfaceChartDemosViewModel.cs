#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
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

namespace syncfusion.surfacechartdemos.wpf
{
    public class SurfaceChartDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new SurfaceChartProductDemos());
            return productdemos;
        }
    }

    public class SurfaceChartProductDemos : ProductDemo
    {
        public SurfaceChartProductDemos()
        {
            this.Product = "Surface Chart";
            this.ProductCategory = "CHARTS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2.5 0C2.77614 0 3 0.223858 3 0.5V10.8215L5.56561 7.3402C5.79994 7.02224 6.28593 7.05809 6.47106 7.40699C6.66932 7.78065 7.20193 7.7884 7.41099 7.42067L8.60663 5.31757C8.85996 4.87197 9.43375 4.72761 9.86778 5.00027L12.0788 6.38922C12.3409 6.5539 12.5 6.84174 12.5 7.15132V11H13.5C13.7761 11 14 11.2239 14 11.5C14 11.7761 13.7761 12 13.5 12L3 12V13.5C3 13.7761 2.77614 14 2.5 14C2.22386 14 2 13.7761 2 13.5V12H0.5C0.223858 12 0 11.7761 0 11.5C0 11.2239 0.223858 11 0.5 11H2V0.5C2 0.223858 2.22386 0 2.5 0Z"),
                Width = 14,
                Height = 14,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Charts.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The Surface chart control is a high-performance, visually stunning, three-dimensional surface chart.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Surface Chart.png", UriKind.RelativeOrAbsolute));

            DemoInfo SurfaceAndWireframeSurfaceDemo = new DemoInfo()
            {
                SampleName = "Surface and Wireframe Surface",

                GroupName = "SURFACE CHART",

                Description = "This sample showcases surface chart types such as Surface and Wireframe Surface.",

                DemoViewType = typeof(SurfaceandWireframeSurface),

            };

            List<Documentation> SurfaceChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Surface chart - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/surface-chart/getting-started")}
            };

            SurfaceAndWireframeSurfaceDemo.Documentations = SurfaceChartHelpDocuments;
            this.Demos.Add(SurfaceAndWireframeSurfaceDemo);
            this.Demos.Add(new DemoInfo() { SampleName = "Contour and Wireframe Contour", GroupName = "SURFACE CHART", DemoViewType = typeof(ContourandWireframeContour), Description = "This sample showcases surface chart types such as Contour and Wireframe Contour." });
        }
    }
}
