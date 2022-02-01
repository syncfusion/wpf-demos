#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Collections.Generic;

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
            this.Demos = new List<DemoInfo>();
            this.Tag = Tag.Updated;

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
                DemoLauchMode = DemoLauchMode.Default,
                Tag = Tag.Updated
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Text Markups",
                Description = "The PDF Viewer control supports adding and modifying the highlight, strikethrough, and underline annotations in PDF files.",
                GroupName = "ANNOTATION",
                DemoViewType = typeof(TextMarkups),
                ShowBusyIndicator = false,
                DemoLauchMode = DemoLauchMode.Default
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
                Description = "The PDF Viewer control supports adding and modifying the free text annotation in PDF files.",
                GroupName = "ANNOTATION",
                DemoViewType = typeof(FreeText),
                ShowBusyIndicator = false,
                DemoLauchMode = DemoLauchMode.Default
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Form Filling",
                Description = "PDF Viewer control supports filling, editing, saving and printing the AcroForm fields present in the PDF document.",
                GroupName = "FORM FILLLING",
                DemoViewType = typeof(FormFilling),
                ShowBusyIndicator = false,
                DemoLauchMode = DemoLauchMode.Default
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

