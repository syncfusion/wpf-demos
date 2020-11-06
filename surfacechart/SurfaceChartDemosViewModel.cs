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
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Surface and Wireframe Surface", ThemeMode = ThemeMode.Default, GroupName = "SURFACE CHART", DemoViewType = typeof(SurfaceandWireframeSurface), Description = "This sample showcases surface chart types such as Surface and Wireframe Surface." });
            this.Demos.Add(new DemoInfo() { SampleName = "Contour and Wireframe Contour", ThemeMode = ThemeMode.Default, GroupName = "SURFACE CHART", DemoViewType = typeof(ContourandWireframeContour), Description = "This sample showcases surface chart types such as Contour and Wireframe Contour." });
        }
    }
}
