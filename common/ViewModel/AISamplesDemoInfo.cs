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
