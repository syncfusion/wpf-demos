#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
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
    /// <summary>
    /// Represents the product category for "Smart AI" samples in the demo browser. This class acts as a container for all the individual AI-powered demos.
    /// </summary>
    public class AISamplesProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AISamplesProductDemos"/> class, setting the product name, category and intializing the demo list.
        /// </summary>
        public AISamplesProductDemos()
        {
            this.Product = "Smart AI";
            this.ProductCategory = "Smart Components";
            this.Demos = new List<DemoInfo>();
        }
    }

    /// <summary>
    /// Represents the highlighted showcase entry for the "Smart AI Solutions". This class provides the descriptive text and image used in the main gallery view.
    /// </summary>
    public class AIHighlightedProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AIHighlightedProductDemos"/> class, setting the display properties for the showcase tile.
        /// </summary>
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
