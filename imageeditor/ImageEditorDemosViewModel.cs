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
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "IMAGE EDITOR", DemoViewType = typeof(GettingStarted), Description = "This sample demonstrates the basic features in SfImageEditor." });
            this.Demos.Add(new DemoInfo() { SampleName = "Banner Creator", GroupName = "IMAGE EDITOR", DemoViewType = typeof(BannerCreator), Description = "This sample demonstrates the cropping features in SfImageEditor." });
            this.Demos.Add(new DemoInfo() { SampleName = "Overlay Image", GroupName = "IMAGE EDITOR", DemoViewType = typeof(OverlayImage), Description = "This sample demonstrates the overlay images that can be added with the help of customized toolbar in SfImageEditor." });
        }
    }
}
