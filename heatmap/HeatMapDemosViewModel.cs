#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M3 0.5C3 0.223858 2.77614 0 2.5 0C2.22386 0 2 0.223858 2 0.5L2 11H0.5C0.223858 11 0 11.2239 0 11.5C0 11.7761 0.223858 12 0.5 12H2L2 13.5C2 13.7761 2.22386 14 2.5 14C2.77614 14 3 13.7761 3 13.5V12H13.5C13.7761 12 14 11.7761 14 11.5C14 11.2239 13.7761 11 13.5 11H3L3 0.5ZM5 1H6V2H5V1ZM6 8H5V9H6V8ZM5 4H6V5H5V4ZM8 4H7V5H8V4ZM13 4H14V5H13V4ZM11 1H10V2H11V1ZM10 8H11V9H10V8ZM9 0H7V2H9V0ZM14 0H12V2H14V0ZM12 4H10V6H12V4ZM7 7H9V9H7V7ZM12 7H14V9H12V7Z"),
                Width = 14,
                Height = 14,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/DataVisualization.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The HeatMap Control is used to show tabular data values as gradient colors instead of numbers. Low and high values are represented in different colors with different gradients.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Heat Map.png", UriKind.RelativeOrAbsolute));
            
             List<Documentation> GettingStartedHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "HeatMap - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/heatmap/getting-started")},
             };
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "HEAT MAP", Description = "This sample showcases the basic feature in HeatMap configured with a collection.", DemoViewType = typeof(GettingStarted) , Documentations = GettingStartedHelpDocuments });
             List<Documentation> LegendHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "HeatMap - Legend", Uri = new Uri("https://help.syncfusion.com/wpf/heatmap/legend")},
             };
            this.Demos.Add(new DemoInfo() { SampleName = "Legend", GroupName = "HEAT MAP", Description = "This sample demonstrates the Legend features in HeatMap Control.", DemoViewType = typeof(LegendDemo) , Documentations = LegendHelpDocuments });
            List<Documentation> VirtualizationHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "HeatMap - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/heatmap/getting-started")},
             };
            this.Demos.Add(new DemoInfo() { SampleName = "Virtualization", GroupName = "HEAT MAP", Description = "This sample demonstrates loading of large data set quickly though Virtualization feature of HeatMap Control.", DemoViewType = typeof(Virtualization) , Documentations = VirtualizationHelpDocuments });
            List<Documentation> ItemsMappingHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "HeatMap - Items Mapping", Uri = new Uri("https://help.syncfusion.com/wpf/heatmap/itemsmapping")},
             };
            this.Demos.Add(new DemoInfo() { SampleName = "Items Mapping", GroupName = "HEAT MAP", Description = "This sample demonstrates rendering of two different kind of data source in HeatMap Control. \n\nIn TableMapping rows represents an objects in collection, columns represents numerical properties of that object. \n\nIn CellMapping  each cell represent an object in collection, this collection is grouped based on specific property to form as rows and columns.", DemoViewType = typeof(ItemsMappingDemo) , Documentations = ItemsMappingHelpDocuments });

        }
    }
}
