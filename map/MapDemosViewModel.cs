#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M3.1026 3.03916C4.13245 2.05611 5.534 1.5 7 1.5C8.466 1.5 9.86755 2.05611 10.8974 3.03916C11.9265 4.02145 12.5 5.34862 12.5 6.72727C12.5 8.7447 11.1273 10.6885 9.64511 12.1819C8.91576 12.9168 8.18453 13.518 7.63493 13.9357C7.37521 14.1332 7.15699 14.2889 7 14.3976C6.843 14.2889 6.62479 14.1332 6.36507 13.9357C5.81547 13.518 5.08424 12.9168 4.35489 12.1819C2.8727 10.6885 1.5 8.7447 1.5 6.72727C1.5 5.34862 2.07353 4.02145 3.1026 3.03916ZM6.73128 15.4216C6.73143 15.4217 6.73156 15.4218 7 15L6.73128 15.4216C6.89506 15.5259 7.10465 15.5261 7.26844 15.4218L7 15C7.26844 15.4218 7.26828 15.4219 7.26844 15.4218L7.27041 15.4206L7.27455 15.4179L7.28922 15.4085L7.30694 15.3969L7.34313 15.3731C7.38962 15.3424 7.45676 15.2974 7.54161 15.2389C7.71124 15.1219 7.95195 14.9509 8.24007 14.7319C8.81547 14.2945 9.58424 13.6628 10.3549 12.8863C11.8727 11.357 13.5 9.16439 13.5 6.72727C13.5 5.06799 12.8092 3.48166 11.5879 2.3158C10.3673 1.1507 8.7166 0.5 7 0.5C5.2834 0.5 3.6327 1.1507 2.41212 2.3158C1.19075 3.48166 0.5 5.06799 0.5 6.72727C0.5 9.16439 2.1273 11.357 3.64512 12.8863C4.41576 13.6628 5.18453 14.2945 5.75993 14.7319C6.04805 14.9509 6.28876 15.1219 6.45839 15.2389C6.54324 15.2974 6.61038 15.3424 6.65687 15.3731C6.68012 15.3885 6.69822 15.4003 6.71078 15.4085L6.72545 15.4179L6.72959 15.4206L6.73128 15.4216ZM6 6.5C6 5.94772 6.44772 5.5 7 5.5C7.5523 5.5 7.99968 5.94737 7.99968 6.49963C7.99968 7.05192 7.55196 7.49963 6.99968 7.49963C6.44737 7.49963 6 7.05226 6 6.5ZM7 4.5C5.89543 4.5 5 5.39543 5 6.5C5 7.60459 5.89513 8.49963 6.99968 8.49963C8.10425 8.49963 8.99968 7.6042 8.99968 6.49963C8.99968 5.39504 8.10455 4.5 7 4.5Z"),
                Width = 14,
                Height = 16,
            };

            this.IsHighlighted= true;
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/DataVisualization.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "Maps is a data visualization control for displaying geographical data.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Map.png", UriKind.RelativeOrAbsolute));

            DemoInfo GettingStartedDemo = new DemoInfo()
            {
                SampleName = "Getting Started",

                GroupName = "MAP",

                Description = "This sample showcases the markers visualization capability of the Map control.",

                DemoViewType = typeof(GettingStarted),

            };

            List<Documentation> GettingStartedHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Maps - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/maps/getting-started")}
            };

            GettingStartedDemo.Documentations = GettingStartedHelpDocuments;
            this.Demos.Add(GettingStartedDemo);            
            this.Demos.Add(new DemoInfo() { SampleName = "Bubble Visualization", GroupName = "MAP", DemoViewType = typeof(BubbleVisualization), Description = "This sample showcases the bubbles visualization capability of the Map control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Heat Map", GroupName = "MAP", DemoViewType = typeof(HeatMap), Description = "This sample showcases the RangeColorMapping and labels customization of the Map control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Map Points", GroupName = "MAP", DemoViewType = typeof(MapPoints), Description = "This sample showcases the multipoints rendering capability of the Map control." });
            this.Demos.Add(new DemoInfo() { SampleName = "MultiLayer", GroupName = "MAP", DemoViewType = typeof(MultiLayer), Description = "This sample showcases the multilayers rendering capability of the Map control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Shape Selection", GroupName = "MAP", DemoViewType = typeof(ShapeSelection), Description = "This sample showcases the shape selection capability of the Map control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Election Result", GroupName = "MAP", DemoViewType = typeof(ElectionResultDemo), Description = "This sample showcases the equals color mapping capability of Map control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Data Labels", GroupName = "MAP", DemoViewType = typeof(DataLabels), Description = "Data labels are used to display the values of shapes. This sample shows how to enable the smart label appearance." });
            this.Demos.Add(new DemoInfo() { SampleName = "Open Street Map", GroupName = "MAP", DemoViewType = typeof(OpenStreetMaps), Description = "This sample showcases the Open Street Map in the Maps control" });
            this.Demos.Add(new DemoInfo() { SampleName = "Smart Location Finder", IsAISample = true, GroupName = "SMART MAP", DemoViewType = typeof(LocationIndicator), Description = "This sample allows users to search for and find locations." });
        }
    }
}
