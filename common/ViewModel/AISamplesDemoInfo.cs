#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace syncfusion.demoscommon.wpf
{
    public class AISamplesProductDemos : ProductDemo
    {
        public AISamplesProductDemos()
        {
            this.Product = "Smart AI";
            this.ProductCategory = "Smart Components";
            this.Demos = new List<DemoInfo>();
        }
    }

    public class AIHighlightedProductDemos : ProductDemo
    {
        public AIHighlightedProductDemos()
        {
            this.Product = "Smart AI Solutions";
            this.ProductCategory = "Smart Components";
            this.Tag = Tag.None;
            this.ControlDescription = "Showcasing how Syncfusion® components work with AI tools to enhance functionality and deliver smarter solutions.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/SmartAISolution.png", UriKind.RelativeOrAbsolute));
        }
    }
}
