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

namespace syncfusion.barcodedemos.wpf
{
    public class BarcodeDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new BarcodeProductDemos());
            return productdemos;
        }
    }

    public class BarcodeProductDemos : ProductDemo
    {
        public BarcodeProductDemos()
        {
            this.Product = "Barcode";
            this.ProductCategory = "DATA VISUALIZATION";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M0 0H1V12H0V0ZM2 0H5V12H2V0ZM8 0H6V12H8V0ZM9 0H10V12H9V0ZM12 0H11V12H12V0ZM13 0H16V12H13V0Z"),
                Width = 16,
                Height = 12,
            };
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/DataVisualization.png", UriKind.RelativeOrAbsolute));
            this.Demos = new List<DemoInfo>();
            this.ControlDescription = "The Barcode control is a light-weight and high-performance control to display industry-standard 1D and 2D barcodes in your desktop application.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Barcode.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Barcode", GroupName = "Barcode", DemoViewType = typeof(SfBarcode) });
        }
    }
}
