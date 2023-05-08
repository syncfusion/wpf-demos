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
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.pdfviewerdemos.wpf
{
    public class PdfViewerDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new PdfViewerProductDemos());
            return productdemos;
        }
    }
    public class PdfViewerProductDemos : ProductDemo
    {
        public PdfViewerProductDemos()
        {
            this.Product = "PDF Viewer";
            this.ProductCategory = "FILE VIEWERS AND EDITORS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2.5 14H11.5C12.88 14 14 12.88 14 11.5V2.5C14 1.12 12.88 0 11.5 0H2.5C1.12 0 0 1.12 0 2.5V11.5C0 12.88 1.12 14 2.5 14ZM1 2.5C1 1.67 1.67 1 2.5 1H11.5C12.33 1 13 1.67 13 2.5V11.5C13 12.33 12.33 13 11.5 13H2.5C1.67 13 1 12.33 1 11.5V2.5ZM3.16875 10.4001C3.31875 10.7701 3.67875 11.0002 4.04875 11.0002L4.05875 10.9801C4.15875 10.9801 4.26875 10.9701 4.36875 10.9301C4.70814 10.8138 4.87827 10.5094 5.01592 10.2631C5.02023 10.2554 5.0245 10.2477 5.02875 10.2401C5.04375 10.2151 5.05625 10.1901 5.06875 10.1651C5.08125 10.1401 5.09375 10.1151 5.10875 10.0901C5.33875 9.71015 5.54875 9.33015 5.73875 8.94015C6.54875 8.65015 7.31875 8.44015 8.06875 8.31015L8.39875 8.25015C8.48375 8.32515 8.56625 8.40015 8.64875 8.47515C8.73125 8.55015 8.81375 8.62515 8.89875 8.70015C8.93208 8.74014 8.9743 8.78014 9.01651 8.82013C9.03763 8.84013 9.05875 8.86014 9.07875 8.88014C9.33875 9.15014 9.66875 9.46014 10.0988 9.46014C10.3888 9.45014 10.6788 9.31014 10.8688 9.07014C11.0588 8.83014 11.1388 8.53015 11.0788 8.25015C11.0288 7.97015 10.8287 7.62016 10.1687 7.52016C9.62875 7.45016 9.09875 7.54015 8.57875 7.64015C7.97875 7.05015 7.42875 6.41015 6.92875 5.73015C6.96875 5.57015 7.00875 5.40015 7.04875 5.23015C7.06876 5.14015 7.09875 5.04015 7.12875 4.94015L7.13213 4.92848C7.24138 4.55116 7.36742 4.11585 7.23875 3.70015C7.09875 3.24015 6.61875 2.95016 6.12875 3.02016C5.97875 3.05016 5.82875 3.11015 5.70875 3.20015C5.23875 3.54015 5.25875 4.17015 5.51875 4.62015C5.76875 5.04015 6.02875 5.45014 6.30875 5.85014C6.21875 6.16014 6.12875 6.46015 6.02875 6.75015C5.82875 7.34015 5.58875 7.92014 5.31875 8.49014C5.22316 8.52838 5.12757 8.56515 5.03142 8.60214C4.87611 8.66189 4.71934 8.72221 4.55875 8.79014L4.36875 8.86015L4.36563 8.86134C3.94588 9.02125 3.36825 9.24129 3.16875 9.70015C3.06875 9.92015 3.06875 10.1501 3.16875 10.4001ZM4.9059 9.26529L4.76875 9.32014L4.56875 9.40015C4.25875 9.52015 3.79875 9.70014 3.68875 9.93014C3.66875 9.98014 3.64875 10.0502 3.69875 10.1902C3.76875 10.3702 3.97876 10.4702 4.15876 10.4102C4.30875 10.3602 4.40874 10.1702 4.50874 9.98018L4.50875 9.98015L4.5088 9.98006C4.53878 9.92009 4.56876 9.86013 4.59875 9.81015C4.68001 9.67718 4.75582 9.53875 4.8302 9.40292C4.85554 9.35663 4.88073 9.31065 4.9059 9.26529ZM9.25875 8.28015C9.20875 8.23015 9.14875 8.18014 9.08875 8.13014C9.41875 8.07014 9.75875 8.04015 10.0788 8.09015C10.4788 8.15015 10.5087 8.30015 10.5187 8.36015C10.5387 8.48015 10.4987 8.61014 10.4187 8.71014C10.3287 8.82014 10.2088 8.89015 10.0788 8.89015C9.89875 8.88015 9.66875 8.67015 9.46875 8.48015C9.39875 8.41015 9.32875 8.34015 9.25875 8.28015ZM6.64875 6.68515C6.67625 6.60015 6.70375 6.51515 6.72875 6.43014C7.09876 6.90014 7.48875 7.35015 7.89875 7.78015C7.29875 7.88015 6.68875 8.04014 6.05875 8.24014C6.24875 7.82014 6.41875 7.38015 6.56875 6.94015C6.59375 6.85516 6.62125 6.77016 6.64875 6.68515ZM6.21875 3.58015H6.27875C6.44875 3.58015 6.63875 3.69014 6.69875 3.88014C6.77875 4.13014 6.68875 4.47014 6.58875 4.79014C6.57761 4.83098 6.5651 4.87181 6.55274 4.91214C6.53181 4.98044 6.51133 5.04727 6.49875 5.11015C6.32875 4.86015 6.16875 4.60015 6.01875 4.33015C5.90875 4.14015 5.82875 3.81015 6.04875 3.65015C6.09875 3.61015 6.15875 3.58015 6.21875 3.58015Z"),
                Width = 14,
                Height = 14,
            };
            this.Demos = new List<DemoInfo>();
            this.IsHighlighted= true;
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/FileViewersAndEditors.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The PDF Viewer control lets you view, review, and print PDF files in WPF applications.";
            this.Tag = Tag.None;
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/PDF Viewer.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Getting Started",
                Description = "PDF Viewer control is a light weight viewer for viewing PDF files. It has a built-in user friendly toolbar for page navigation, zooming option, opening files and printing them to a selected printer. This sample demonstrates how to start with PDF Viewer and helps to explore its features.",
                GroupName = "GETTING STARTED",
                DemoViewType = typeof(PdfViewerGettingStarted),
                ShowBusyIndicator = false,
                DemoLauchMode = DemoLauchMode.Default,
                Tag = Tag.None
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Shapes",
                Description = "The PDF Viewer control supports adding and modifying the arrow, ellipse, line, polygon, polyline, and rectangle-shaped annotations in PDF files.",
                GroupName = "ANNOTATION",
                DemoViewType = typeof(Shapes),
                ShowBusyIndicator = false,
                DemoLauchMode = DemoLauchMode.Default
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Text Markups",
                Description = "The PDF Viewer control supports adding and modifying the highlight, strikethrough, underline, and squiggly annotations in PDF files.",
                GroupName = "ANNOTATION",
                DemoViewType = typeof(TextMarkups),
                ShowBusyIndicator = false,
                DemoLauchMode = DemoLauchMode.Default,
                Tag = Tag.None
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Sticky Note",
                Description = "The PDF Viewer control supports adding and modifying the sticky note annotation in PDF files. The annotations can be locked to prevent unintentional move and delete operations.",
                GroupName = "ANNOTATION",
                DemoViewType = typeof(StickyNote),
                ShowBusyIndicator = false,
                DemoLauchMode = DemoLauchMode.Default
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Ink Signature",
                Description = "The PDF Viewer control supports adding and modifying the ink annotations in PDF files.",
                GroupName = "ANNOTATION",
                DemoViewType = typeof(InkSignature),
                ShowBusyIndicator = false,
                DemoLauchMode = DemoLauchMode.Default
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Free Text",
                Description = "The PDF Viewer control supports adding and modifying free text and callout text box annotation in PDF files.",
                GroupName = "ANNOTATION",
                DemoViewType = typeof(FreeText),
                ShowBusyIndicator = false,
                DemoLauchMode = DemoLauchMode.Default,
                Tag = Tag.None
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Form Filling",
                Description = "PDF Viewer control supports filling, editing, saving and printing the AcroForm fields present in the PDF document. To navigate through AcroForm fields press Tab/Shift+Tab to move forward/backward.",
                GroupName = "FORM FILLLING",
                DemoViewType = typeof(FormFilling),
                ShowBusyIndicator = false,
                DemoLauchMode = DemoLauchMode.Default,
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Layers",
                Description = "The layer support in PDF Viewer, allows the user to toggle the visibility of individual and group of layers in the PDF document to view, print, save and export as image.",
                GroupName = "LAYERS",
                DemoViewType = typeof(Layers),
                ShowBusyIndicator = false,
                DemoLauchMode = DemoLauchMode.Default
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Bookmark Navigation",
                Description = "PDF Viewer control supports bookmark navigation between the pages of PDF document.",
                GroupName = "NAVIGATION",
                DemoViewType = typeof(BookmarkNavigation),
                ShowBusyIndicator = false,
                DemoLauchMode = DemoLauchMode.Default
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Thumbnail Navigation",
                Description = "PDF Viewer control supports thumbnail navigation using pdf pages.",
                GroupName = "NAVIGATION",
                DemoViewType = typeof(ThumbnailNavigation),
                ShowBusyIndicator = false,
                DemoLauchMode = DemoLauchMode.Default
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Custom Toolbar",
                Description = "This sample shows how to make use of custom ribbon instead of built-in toolbar for PDF Viewer control.",
                GroupName = "CUSTOMIZATION",
                DemoViewType = typeof(CustomToolbar),
                DemoLauchMode = DemoLauchMode.Window,
                ThemeMode = ThemeMode.None
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Multi Tabbed Viewer",
                Description = "You can view more than one PDF file simultaneously using the PdfDocumentView. It can be added as MDI child window associated with a custom toolbar, which helps you to achieve the desired multi-tabbed viewer.",
                GroupName = "CUSTOMIZATION",
                DemoViewType = typeof(MultiTabbedViewer),
                DemoLauchMode = DemoLauchMode.Window,
                ThemeMode = ThemeMode.None
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Redaction",
                Description = "Redaction support allows you to remove sensitive/confidential information in text, images, and graphics from a PDF document.",
                GroupName = "REDACTION",
                DemoViewType = typeof(Redaction),
                ShowBusyIndicator = false,
                DemoLauchMode = DemoLauchMode.Default
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Export as Image",
                Description = "Currently viewed PDF file can be exported as raster image. Selected or all pages of the document can be exported. This sample demonstrates how to export the PDF file as raster image.",
                GroupName = "EXPORT AND PRINTING",
                DemoViewType = typeof(ExportAsImage),
                DemoLauchMode = DemoLauchMode.Window
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Silent Printing",
                Description = "The PDF file viewed in PDF Viewer can be printed either through user interactive Print Dialog box or through silent printing. This sample demonstrates how to enable silent printing.",
                GroupName = "EXPORT AND PRINTING",
                DemoViewType = typeof(SilentPrinting),
                DemoLauchMode = DemoLauchMode.Window
            });
        }
    }
}

