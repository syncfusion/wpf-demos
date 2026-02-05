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
            this.ProductCategory = "CHARTS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2 1H7V5H2C1.44772 5 1 4.55228 1 4L1 3.5L5 3.5C5.27614 3.5 5.5 3.27614 5.5 3C5.5 2.72386 5.27614 2.5 5 2.5L1 2.5V2C1 1.44772 1.44772 1 2 1ZM8 5V1H12C12.5523 1 13 1.44772 13 2V4C13 4.55228 12.5523 5 12 5H8ZM0 2C0 0.89543 0.895431 0 2 0H12C13.1046 0 14 0.895431 14 2V4C14 5.10457 13.1046 6 12 6H2C0.89543 6 0 5.10457 0 4V2ZM12 9C12.5523 9 13 9.44772 13 10V12C13 12.5523 12.5523 13 12 13H8V11.5H11C11.2761 11.5 11.5 11.2761 11.5 11C11.5 10.7239 11.2761 10.5 11 10.5H8V9H12ZM7 9V10.5L1 10.5V10C1 9.44772 1.44772 9 2 9H7ZM7 11.5L1 11.5L1 12C1 12.5523 1.44772 13 2 13H7V11.5ZM0 10C0 8.89543 0.895431 8 2 8H12C13.1046 8 14 8.89543 14 10V12C14 13.1046 13.1046 14 12 14H2C0.89543 14 0 13.1046 0 12V10Z"),
                Width = 14,
                Height = 14,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Charts.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The Bullet graph is used to display and track progress towards goals. It has a compact and customizable view for easy visualization of metrics.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Bullet Graph.png", UriKind.RelativeOrAbsolute));

            DemoInfo GettingStartedDemo = new DemoInfo()
            {
                SampleName = "Getting Started",

                GroupName = "BULLET GRAPH",

                Description = "This sample showcases the bulletgraph control's customization of ticks, labels and caption position.",

                DemoViewType = typeof(GettingStarted),

            };

            List<Documentation> GettingStartedHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "BulletGraph - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/bullet-graph/getting-started")}
            };

            GettingStartedDemo.Documentations = GettingStartedHelpDocuments;
            this.Demos.Add(GettingStartedDemo);         
            this.Demos.Add(new DemoInfo() { SampleName = "Bullet Graph Measures", GroupName = "BULLET GRAPH", DemoViewType = typeof(BulletGraphMeasures), Description = "This sample showcases the customization with ticks and labels of the bulletgraph control, comparative and featured measures and customization of binding range stroke." });
        }
    }
}
