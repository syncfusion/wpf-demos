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
using System.Windows.Media.Imaging;
using System.Windows.Media;
using syncfusion.markdownviewerdemo.wpf.Views;

namespace syncfusion.markdownviewerdemo.wpf
{
    public class MarkdownViewerDemoViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new MarkdownViewerProductDemos());
            return productdemos;
        }
    }

    public class MarkdownViewerProductDemos : ProductDemo
    {
        public MarkdownViewerProductDemos()
        {
            this.Product = "Markdown Viewer";
            this.ProductCategory = "MISCELLANEOUS";
            this.Tag = Tag.New;
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M3.10254 0.00488281C3.60667 0.0562144 4 0.482323 4 1H12C12 0.447715 12.4477 0 13 0H15L15.1025 0.00488281C15.6067 0.0562144 16 0.482323 16 1V3L15.9951 3.10254C15.9438 3.60667 15.5177 4 15 4V12L15.1025 12.0049C15.6067 12.0562 16 12.4823 16 13V15L15.9951 15.1025C15.9438 15.6067 15.5177 16 15 16H13C12.4477 16 12 15.5523 12 15H4L3.99512 15.1025C3.94379 15.6067 3.51768 16 3 16H1C0.447715 16 0 15.5523 0 15V13C0 12.4477 0.447715 12 1 12V4C0.447715 4 0 3.55228 0 3V1C0 0.447715 0.447715 0 1 0H3L3.10254 0.00488281ZM1 15H3V13H1V15ZM13 15H15V13H13V15ZM4 3L3.99512 3.10254C3.94379 3.60667 3.51768 4 3 4H2V12H3L3.10254 12.0049C3.60667 12.0562 4 12.4823 4 13V14H12V13C12 12.4477 12.4477 12 13 12H14V4H13C12.4477 4 12 3.55228 12 3V2H4V3ZM5.74023 8.70703C5.823 8.94829 5.88305 9.19095 5.9209 9.43457H5.94238C6.00627 9.153 6.07355 8.90744 6.14453 8.69922L7.18457 5.69043H8.82129V10.7793H7.68848V7.73438C7.68848 7.40549 7.70305 7.04204 7.73145 6.64453H7.70312C7.64397 6.95686 7.59029 7.1821 7.54297 7.31934L6.35059 10.7793H5.41406L4.2002 7.35449C4.16707 7.26221 4.11339 7.02548 4.04004 6.64453H4.00781C4.03857 7.14608 4.05468 7.5863 4.05469 7.96484V10.7793H3.02148V5.69043H4.7002L5.74023 8.70703ZM11.3271 5.39453C11.6617 5.39453 11.9326 5.66547 11.9326 6V8.03027H12.6924C13.2317 8.03065 13.5016 8.68298 13.1201 9.06445L11.8662 10.3184C11.8053 10.4398 11.7062 10.5369 11.583 10.5947C11.4339 10.7183 11.2202 10.7187 11.0713 10.5947C10.9472 10.5364 10.8468 10.4382 10.7861 10.3154L9.53516 9.06445C9.15383 8.68297 9.42361 8.03066 9.96289 8.03027H10.7217V6C10.7217 5.66562 10.9928 5.39478 11.3271 5.39453ZM1 3H3V1H1V3ZM13 3H15V1H13V3Z"),
                Width = 16,
                Height = 16,
            };
            this.Demos = new List<DemoInfo>();
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Markdown Viewer.png", UriKind.RelativeOrAbsolute));
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Miscellaneous.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The MarkdownViewer control is used to render and preview Markdown files. It converts markdown syntax into a clean, readable format and supports elements such as headings, lists, code blocks, tables, and other common markdown structures.";
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Tag = Tag.New, Description = "This sample demonstrates the basic features of the MarkdownViewer control, showcasing common markdown elements such as headings, paragraphs, links, lists, and code blocks.", GroupName = "Markdown Viewer", DemoViewType = typeof(Overview) });
            this.Demos.Add(new DemoInfo() { SampleName = "Advance Markdown", Tag = Tag.New, Description = "This sample demonstrates support for advanced markdown structures including tables, images, nested lists, blockquotes, and fenced code blocks, providing a comprehensive view of the MarkdownViewer control’s rendering capabilities.", GroupName = "Markdown Viewer", DemoViewType = typeof(AdvanceMarkdown) });
            //this.Demos.Add(new DemoInfo() { SampleName = "Customization", Tag = Tag.New, Description = "This sample demonstrates how to customize the appearance of the MarkdownViewer control. It showcases styling options such as font customization, color themes, and layout adjustments to match the application's visual design.", GroupName = "Markdown Viewer", DemoViewType = typeof(Customization) });
        }
    }
}
