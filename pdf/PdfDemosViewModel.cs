#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Zugferd;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.pdfdemos.wpf
{
    public class PdfDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new PdfProductDemos());
            return productdemos;
        }
    }
    public class PdfProductDemos : ProductDemo
    {
        public PdfProductDemos()
        {
            this.Product = "PDF";
            this.ProductCategory = "FILE FORMAT";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2.5 14H11.5C12.88 14 14 12.88 14 11.5V2.5C14 1.12 12.88 0 11.5 0H2.5C1.12 0 0 1.12 0 2.5V11.5C0 12.88 1.12 14 2.5 14ZM1 2.5C1 1.67 1.67 1 2.5 1H11.5C12.33 1 13 1.67 13 2.5V11.5C13 12.33 12.33 13 11.5 13H2.5C1.67 13 1 12.33 1 11.5V2.5ZM8.43 7.54938C8.76 7.36938 9 7.13937 9.15 6.85938L9.16 6.87936C9.31 6.59936 9.38 6.29937 9.38 5.97937C9.38 5.62937 9.3 5.30936 9.13 5.02936C8.96 4.74936 8.71 4.52938 8.38 4.35938C8.05 4.18937 7.64 4.10938 7.16 4.10938H5V10.3594H6.03V7.81937H7.16C7.68 7.81937 8.1 7.72938 8.43 7.54938ZM8.32 5.95938C8.32 6.27938 8.22 6.52938 8.03 6.70938V6.69937C7.84 6.87937 7.55 6.96936 7.16 6.96936H6.03V4.92938H7.16C7.93 4.92938 8.32 5.27938 8.32 5.95938Z"),
                Width = 14,
                Height = 14,
            };
            this.Demos = new List<DemoInfo>();
            this.Tag = Tag.None;
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/FileFormat.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "A .NET PDF library to create, read, and edit PDF files programmatically with formatted text, tables, links, list, header, and footer, and more.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/PDF.png", UriKind.RelativeOrAbsolute));

            this.Demos.Add(new DemoInfo() { SampleName = "Job Application", GroupName = "Product Showcase", DemoViewType = typeof(JobApplication), Description = "This sample demonstrates Essential PDF support for creating rich forms with various page settings and form actions." });
            this.Demos.Add(new DemoInfo() { SampleName = "ZUGFeRD Invoice", GroupName = "Product Showcase", DemoViewType = typeof(ZugFerd), Description = "This sample demonstrates how to create ZUGFeRD PDF invoice using Essential PDF" });
            this.Demos.Add(new DemoInfo() { SampleName = "Hello World", GroupName = "Getting Started", DemoViewType = typeof(HelloWorld), Description = "This sample demonstrates how to start with Essential PDF and create a PDF document with the text \"Hello World.\"" });
            this.Demos.Add(new DemoInfo() { SampleName = "PDF Compression Level", GroupName = "Compression", DemoViewType = typeof(PDFCompressionLevel), Description = "This sample demonstrates the various compression technique that can be used with Essential Pdf." });
            this.Demos.Add(new DemoInfo() { SampleName = "Compress Existing PDF", GroupName = "Compression", DemoViewType = typeof(CompressExistingPDF), Description = "This sample demonstrates how to compress the existing PDF document by using Essential Pdf." });
            this.Demos.Add(new DemoInfo() { SampleName = "Text Flow", GroupName = "Drawing Text", DemoViewType = typeof(TextFlow), Description = "This sample demonstrates how large text from a text file can span multiple pages in a PDF document. This sample also explains events that are raised when each page begins and ends." });
            this.Demos.Add(new DemoInfo() { SampleName = "RTL Support", GroupName = "Drawing Text", DemoViewType = typeof(RTLSupport), Description = "This sample demonstrates how the text of right-to-left [RTL] languages, like Arabic, can be rendered in a PDF document. It also demonstrates various alignments of text." });
            this.Demos.Add(new DemoInfo() { SampleName = "Complex Script", GroupName = "Drawing Text", DemoViewType = typeof(ComplexScript), Description = "This sample demonstrates drawing complex script language text in the PDF document. It is possible to draw complex languages such as Thai, Hindi, Tamil, Kannada and more." });
            this.Demos.Add(new DemoInfo() { SampleName = "Bullets and Lists", GroupName = "Drawing Text", DemoViewType = typeof(BulletsAndLists), Description = "This sample demonstrates Essential PDF's support for creating ordered and unordered lists. It also demonstrates how formatting can be applied to those lists." });
            this.Demos.Add(new DemoInfo() { SampleName = "Multi Column HTML Text", GroupName = "Drawing Text", DemoViewType = typeof(MultiColumnText), Description = "This sample demonstrates Essential PDF's support for rendering a HTML-formatted string in a multicolumn format." });
            this.Demos.Add(new DemoInfo() { SampleName = "OpenType Font", GroupName = "Drawing Text", DemoViewType = typeof(OpenTypeFont), Description = "This sample demonstrates how to draw a text with OpenType font in a PDF document." });
            this.Demos.Add(new DemoInfo() { SampleName = "Barcode", GroupName = "Graphics", DemoViewType = typeof(Barcode), Description = "This sample demonstrates how to draw various sequences of vertical bars and spaces to represent numbers and other symbols. It typically consists of five parts: a quiet zone, a start character, data characters, a stop character, and another quiet zone." });
            this.Demos.Add(new DemoInfo() { SampleName = "Drawing Shapes", GroupName = "Graphics", DemoViewType = typeof(DrawingShapes), Description = "This sample demonstrates how various shapes, like line, ellipse, circle, rectangle etc., can be drawn and paginated. It also explains various color spaces that are supported by Essential PDF." });
            this.Demos.Add(new DemoInfo() { SampleName = "Graphic Brushes", GroupName = "Graphics", DemoViewType = typeof(GraphicBrushes), Description = "This sample demonstrates the support for creating and filling shapes with the various types of brushes that are supported by Essential PDF." });
            this.Demos.Add(new DemoInfo() { SampleName = "Image Insertion", GroupName = "Graphics", DemoViewType = typeof(ImageInsertion), Description = "This sample demonstrates how to insert images in a PDF document using Essential PDF." });
            this.Demos.Add(new DemoInfo() { SampleName = "Adventure Cycle Works", GroupName = "Tables", DemoViewType = typeof(AdventureCycle), Description = "This sample is demonstrates the support for built-in style in PdfGrid." });
            this.Demos.Add(new DemoInfo() { SampleName = "Table Features", GroupName = "Tables", DemoViewType = typeof(TableFeatures), Description = "This sample demonstrates the advanced features for tables. This includes tables in headers, graphic objects in table cells, styles, and gradient colors." });
            this.Demos.Add(new DemoInfo() { SampleName = "Digital Signature", GroupName = "Security", DemoViewType = typeof(DigitalSignature), Description = "This sample demonstrates how a PDF document can be secured with certificates and signed with either standard or author signatures. Now added the support for Elliptic Curve Digital Signature Algorithm (ECDSA) to sign the PDF document." });
            this.Demos.Add(new DemoInfo() { SampleName = "Digital Signature Validation", GroupName = "Security", DemoViewType = typeof(SignatureValidation), Description = "This sample demonstrates to validate the digital signature by using Essential PDF." });
            this.Demos.Add(new DemoInfo() { SampleName = "Encryption", GroupName = "Security", DemoViewType = typeof(Encryption), Description = "This sample demonstrates how a PDF document can be protected with user and owner passwords, and how it can restrict users from accessing some functionalities, such as printing." });
            this.Demos.Add(new DemoInfo() { SampleName = "Redaction", GroupName = "Security", DemoViewType = typeof(Redaction), Description = "This sample demonstrates the redaction of PDF documents. Redaction is used to remove confidential information from PDF document." });
            this.Demos.Add(new DemoInfo() { SampleName = "Document Settings", GroupName = "Settings", DemoViewType = typeof(DocumentSettings), Description = "This sample demonstrates Essential PDF's support for setting document properties. It also explains how XMP properties can be set using Essential PDF." });
            this.Demos.Add(new DemoInfo() { SampleName = "Page Settings", GroupName = "Settings", DemoViewType = typeof(PageSettings), Description = "This sample demonstrates the support for setting page-oriented properties such as page size, orientation, viewer preference, page view mode, and page transition. It also explains how transparency can be set." });
            this.Demos.Add(new DemoInfo() { SampleName = "Headers and Footers", GroupName = "Settings", DemoViewType = typeof(HeadersAndFooters), Description = "This sample demonstrates how headers and footers with page numbers and images can be inserted using Essential PDF." });
            this.Demos.Add(new DemoInfo() { SampleName = "Layers", GroupName = "Settings", DemoViewType = typeof(Layers), Description = "This sample demonstrates how multiple layers can be added to a page and how elements are drawn over each layer." });
            this.Demos.Add(new DemoInfo() { SampleName = "Find PDF Corruption", GroupName = "Analyze Document", DemoViewType = typeof(FindPDFCorruption), Description = "This sample demonstrates the find corrupted PDF document can be used with Essential Pdf." });
            this.Demos.Add(new DemoInfo() { SampleName = "Form Fill", GroupName = "User Interaction", DemoViewType = typeof(FormFilling), Description = "This sample demonstrates Essential PDF's form filling support." });
            this.Demos.Add(new DemoInfo() { SampleName = "Interactive Features", GroupName = "User Interaction", DemoViewType = typeof(InteractiveFeatures), Description = "This sample demonstrates various interactive annotations in a PDF document that can be created using Essential PDF." });
            this.Demos.Add(new DemoInfo() { SampleName = "Portfolio", GroupName = "User Interaction", DemoViewType = typeof(Portfolio), Description = "This sample demonstrates Essential PDF's Portfolio support." });
            this.Demos.Add(new DemoInfo() { SampleName = "Annotations", GroupName = "User Interaction", DemoViewType = typeof(AnnotationFlatten), Description = "This sample demonstrates Essential PDF's support annotation flatten feature.", Tag = Tag.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Named Destination", GroupName = "User Interaction", DemoViewType = typeof(NamedDestination), Description = "This sample demonstrates Essential PDF's support for bookmark with named destination in PDF documents." });
            this.Demos.Add(new DemoInfo() { SampleName = "XFA Form Creation", GroupName = "User Interaction", DemoViewType = typeof(XFAFormCreation), Description = "This sample demonstrates Essential PDF's support for creating XFA forms with various form fields such as text box, combo box, date time field, numeric field and so on." });
            this.Demos.Add(new DemoInfo() { SampleName = "XFA Form Fill", GroupName = "User Interaction", DemoViewType = typeof(XFAFormFilling), Description = "This sample demonstrates filling and flattening XFA form fields present in the PDF document." });
            this.Demos.Add(new DemoInfo() { SampleName = "Image Extraction", GroupName = "Import and Export", DemoViewType = typeof(ImageExtraction), Description = "This sample demonstrates Essential PDF's support for extracting images from an existing PDF document." });
            this.Demos.Add(new DemoInfo() { SampleName = "Text Extraction", GroupName = "Import and Export", DemoViewType = typeof(TextExtraction), Description = "This sample demonstrates Essential PDF's support for extracting text from an existing PDF document." });
            this.Demos.Add(new DemoInfo() { SampleName = "Word to PDF", GroupName = "Import and Export", DemoViewType = typeof(WordToPDF), Description = "This sample demonstrates Essential PDF's support for converting Word document to a PDF." });
            this.Demos.Add(new DemoInfo() { SampleName = "Excel to PDF", GroupName = "Import and Export", DemoViewType = typeof(ExceltoPDF), Description = "This sample demonstrates Essential PDF's support for converting Excel document to a PDF." });
            this.Demos.Add(new DemoInfo() { SampleName = "PDF to Image", GroupName = "Import and Export", DemoViewType = typeof(PDFToImage), Description = "This sample demonstrates how to convert a PDF document to an image using the PdfToImageConverter. It supports customization in image conversion, such as setting a transparent background and removing annotations for a specific page or range of pages." });
#if !NET50			
            this.Demos.Add(new DemoInfo() { SampleName = "XPS to PDF", GroupName = "Import and Export", DemoViewType = typeof(XPStoPDF), Description = "This sample demonstrates Essential PDF's support for converting a XPS document to a PDF." });
#endif			
            this.Demos.Add(new DemoInfo() { SampleName = "PDF Conformance", GroupName = "Conformance", DemoViewType = typeof(PDFConformance), Description = "This sample demonstrates various PDF conformance support in Essential PDF.", Tag = Tag.None });
            this.Demos.Add(new DemoInfo() { SampleName = "PDF to PDF-A", GroupName = "Conformance", DemoViewType = typeof(PDFToPDFA1b), Description = "This sample demonstrates how to convert PDF document into PDF/A conformance document using Essential Pdf.", Tag = Tag.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Merge Documents", GroupName = "Modify Documents", DemoViewType = typeof(MergeDocuments), Description = "This sample demonstrates how to merge multiple PDF documents using Essential PDF." });
            this.Demos.Add(new DemoInfo() { SampleName = "Split Document", GroupName = "Modify Documents", DemoViewType = typeof(SplitDocument), Description = "This sample demonstrates how to split an existing PDF document into multiple PDF documents." });
            this.Demos.Add(new DemoInfo() { SampleName = "Overlay Documents", GroupName = "Modify Documents", DemoViewType = typeof(OverlayDocuments), Description = "This sample demonstrates Essential PDF's support for importing PDF documents as templates." });
            this.Demos.Add(new DemoInfo() { SampleName = "Booklet", GroupName = "Modify Documents", DemoViewType = typeof(Booklet), Description = "This sample demonstrates how to create a booklet from an existing PDF document." });
            this.Demos.Add(new DemoInfo() { SampleName = "Import and Stamp", GroupName = "Modify Documents", DemoViewType = typeof(ImportAndStamp), Description = "This sample demonstrates Essential PDF's support for importing a page from an existing PDF and stamping the PDF file." });
            this.Demos.Add(new DemoInfo() { SampleName = "Remove Images", GroupName = "Modify Documents", DemoViewType = typeof(RemoveImage), Description = "This sample demonstrates how to remove images from an existing PDF" });
            this.Demos.Add(new DemoInfo() { SampleName = "Autotag", GroupName = "Accessibility", DemoViewType = typeof(AutoTag), Description = "This sample demonstrates how to create a tagged PDF document using Essential PDF." });
            this.Demos.Add(new DemoInfo() { SampleName = "Customtag", GroupName = "Accessibility", DemoViewType = typeof(CustomTag), Description = "This sample demonstrates how to create a tagged PDF by assigning the tags to the elements using Essential PDF" });

        }
    }
}

