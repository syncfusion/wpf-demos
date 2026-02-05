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

namespace syncfusion.treemapdemos.wpf
{
    public class TreeMapDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new TreeMapProductDemos());
            return productdemos;
        }
    }

    public class TreeMapProductDemos : ProductDemo
    {
        public TreeMapProductDemos()
        {
            this.Product = "Treemap";
            this.ProductCategory = "DATA VISUALIZATION";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2 0C0.895431 0 0 0.895431 0 2V7C0 7.55229 0.447715 8 1 8H2C2.55228 8 3 7.55229 3 7V1C3 0.447715 2.55228 0 2 0ZM1 10C0.447715 10 0 10.4477 0 11V12C0 13.1046 0.895431 14 2 14C2.55228 14 3 13.5523 3 13V11C3 10.4477 2.55228 10 2 10H1ZM5 1C5 0.447715 5.44772 0 6 0H7C7.55228 0 8 0.447715 8 1V4C8 4.55228 7.55228 5 7 5H6C5.44772 5 5 4.55228 5 4V1ZM11 12C10.4477 12 10 12.4477 10 13C10 13.5523 10.4477 14 11 14H12.6667C13.403 14 14 13.403 14 12.6667C14 12.2985 13.7015 12 13.3333 12H11ZM10 1C10 0.447715 10.4477 0 11 0H12C13.1046 0 14 0.895431 14 2V10C14 10.5523 13.5523 11 13 11H11C10.4477 11 10 10.5523 10 10V1ZM6 7C5.44772 7 5 7.44772 5 8V13C5 13.5523 5.44772 14 6 14H7C7.55228 14 8 13.5523 8 13V8C8 7.44772 7.55228 7 7 7H6Z"),
                Width = 14,
                Height = 14,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/DataVisualization.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "TreeMap is a data visualization control for displaying hierarchical data in a nested, rectangular layout, enabling quick identification of patterns and trends in data structure.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Treemap.png", UriKind.RelativeOrAbsolute));

            DemoInfo GettingStartedDemo = new DemoInfo()
            {
                SampleName = "Getting Started",

                GroupName = "TREEMAP",

                Description = "This sample showcases the layouts, legends and range color mapping of the TreeMap control.",

                DemoViewType = typeof(GettingStarted),

            };

            List<Documentation> GettingStartedHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "TreeMap - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/treemap/getting-started")}
            };

            GettingStartedDemo.Documentations = GettingStartedHelpDocuments;
            this.Demos.Add(GettingStartedDemo);            
            this.Demos.Add(new DemoInfo() { SampleName = "Hierarchical Collection Treemap", GroupName = "TREEMAP", DemoViewType = typeof(HierarchicalCollectionTreeMap), Description = "This sample showcases the Hierarchical Level data capability of TreeMap control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Customization", GroupName = "TREEMAP", DemoViewType = typeof(TreeMapCustomization), Description = "This sample showcases the leaf node customization capabilities of the TreeMap control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Drilldown", GroupName = "TREEMAP", DemoViewType = typeof(TreeMapDrillDown), Description = "This sample showcases the drilldown capability of the TreeMap control." });
        }
    }
}
