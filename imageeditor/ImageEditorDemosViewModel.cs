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

namespace syncfusion.imageeditordemos.wpf
{
    public class ImageEditorDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new ImageEditorProductDemos());
            return productdemos;
        }
    }

    public class ImageEditorProductDemos : ProductDemo
    {
        public ImageEditorProductDemos()
        {
            this.Product = "Image Editor";
            this.ProductCategory = "INPUT CONTROLS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2 1H12C12.5523 1 13 1.44772 13 2V5.5L14 4.5V2C14 0.895431 13.1046 0 12 0H2C0.895431 0 0 0.89543 0 2V12C0 13.1046 0.89543 14 2 14H4.50098L4.50049 13.9995L9.70732 8.79268L9.03722 7.93645C8.92542 7.79359 8.71338 7.78188 8.58652 7.91156L7.53029 8.99126C7.39358 9.131 7.16187 9.10475 7.05989 8.93796L4.93738 5.46647C4.81387 5.26446 4.51598 5.27845 4.41194 5.49115L1.09305 12.2764C1.07999 12.3031 1.07119 12.3311 1.06652 12.3594C1.02355 12.2479 1 12.1267 1 12V2C1 1.44772 1.44772 1 2 1ZM11.5004 14H12C13.1046 14 14 13.1046 14 12V11.5004L11.5004 14ZM11 3.36719C11 3.91948 10.5523 4.36719 10 4.36719C9.44771 4.36719 9 3.91948 9 3.36719C9 2.81491 9.44771 2.36719 10 2.36719C10.5523 2.36719 11 2.81491 11 3.36719ZM15.8425 7.28999L14.6925 6.14C14.6025 6.05 14.4825 6 14.3525 6C14.2225 6 14.1025 6.05 14.0125 6.14L8.38253 11.77L10.2125 13.6L15.8425 7.97C15.9325 7.88 15.9825 7.76 15.9825 7.63C15.9825 7.5 15.9325 7.37999 15.8425 7.28999ZM7.69 12.4827L7 15.0027L9.52 14.3127L9.75 14.0827L7.92001 12.2527L7.69 12.4827Z"),
                Width = 16,
                Height = 15,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/InputControls.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The ImageEditor control enables easy image editing with features for cropping, rotating, flipping, adjusting colors, and adding text and shapes.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Image Editor.png", UriKind.RelativeOrAbsolute));

            DemoInfo GettingStartedDemo = new DemoInfo()
            {
                SampleName = "Getting Started",

                GroupName = "IMAGE EDITOR",

                Description = "This sample demonstrates the basic features in SfImageEditor.",

                DemoViewType = typeof(GettingStarted),

            };

            List<Documentation> GettingStartedHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "ImageEditor - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/image-editor/getting-started")}
            };

            GettingStartedDemo.Documentations = GettingStartedHelpDocuments;
            this.Demos.Add(GettingStartedDemo);           
            this.Demos.Add(new DemoInfo() { SampleName = "Banner Creator", GroupName = "IMAGE EDITOR", DemoViewType = typeof(BannerCreator), Description = "This sample demonstrates the cropping features in SfImageEditor." });
            this.Demos.Add(new DemoInfo() { SampleName = "Overlay Image", GroupName = "IMAGE EDITOR", DemoViewType = typeof(OverlayImage), Description = "This sample demonstrates the overlay images that can be added with the help of customized toolbar in SfImageEditor." });
        }
    }
}
