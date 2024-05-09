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
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.dociodemos.wpf
{
    public class DocIODemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new DocIOProductDemos());
            return productdemos;
        }
    }
    public class DocIOProductDemos : ProductDemo
    {
        public DocIOProductDemos()
        {
            this.Product = "DocIO";
            this.ProductCategory = "FILE FORMAT";
            this.Tag = Tag.Updated;
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2.5 14H11.5C12.88 14 14 12.88 14 11.5V2.5C14 1.12 12.88 0 11.5 0H2.5C1.12 0 0 1.12 0 2.5V11.5C0 12.88 1.12 14 2.5 14ZM1 2.5C1 1.67 1.67 1 2.5 1H11.5C12.33 1 13 1.67 13 2.5V11.5C13 12.33 12.33 13 11.5 13H2.5C1.67 13 1 12.33 1 11.5V2.5ZM9.28349 10L11 4H9.98049L8.77373 8.85612L7.56697 4H6.50585L5.20546 8.88849L4.0091 4H3L4.6437 10H5.70481L6.9948 5.45681L8.21196 10H9.28349Z"),
                Width = 14,
                Height = 14,
            };
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/FileFormat.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "A .NET Word library to create, read, and edit Word documents programmatically.";
            this.Demos = new List<DemoInfo>();
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/DocIO.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Update Fields",
                GroupName = "PRODUCT SHOWCASE",
                Description = "This sample demonstrates how to update the fields available in the Word document using Essential DocIO. Here, in the example, merge fields and formula fields are used together to populate the net profit or loss.",
                DemoViewType = typeof(UpdateFields)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Hello World",
                GroupName = "GETTING STARTED",
                Description = "This sample demonstrates how to create a simple Word document with text, image and table using Essential DocIO.",
                DemoViewType = typeof(HelloWorld)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Image Insertion",
                GroupName = "INSERT CONTENT",
                Description = "This sample demonstrates how to insert images into the Word document using Essential DocIO.",
                DemoViewType = typeof(ImageInsertion)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Table Insertion",
                GroupName = "INSERT CONTENT",
                Description = "This sample demonstrates how to insert tables into the Word document using Essential DocIO.",
                DemoViewType = typeof(TableInsertion)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Hyperlink",
                GroupName = "INSERT CONTENT",
                Description = "This sample demonstrates how to create a template document that contains different kinds of Hyperlinks, and lets the user to modify the content of those Hyperlinks and save the result into a new document using Essential DocIO.",
                DemoViewType = typeof(Hyperlink)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Bookmarks",
                GroupName = "INSERT CONTENT",
                Description = "This sample demonstrates how to insert bookmarks into the Word document using Essential DocIO.",
                DemoViewType = typeof(Bookmarks)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Header and Footer",
                GroupName = "INSERT CONTENT",
                Description = "This sample demonstrates how to insert headers and footers to the Word document using DocIO.",
                DemoViewType = typeof(HeaderandFooter)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Clone and Merge",
                GroupName = "INSERT CONTENT",
                Description = "This sample demonstrates how to clone and merge Word documents using Essential DocIO.",
                DemoViewType = typeof(CloneandMerge)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "OLE Object",
                GroupName = "INSERT CONTENT",
                Description = "This sample demonstrates how to insert OLE Object into the Word document using Essential DocIO.",
                DemoViewType = typeof(InsertOLEObject)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Format Text",
                GroupName = "FORMATTING",
                Description = "This sample demonstrates how to format the text in the Word document using Essential DocIO.",
                DemoViewType = typeof(FormatText)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Format Table",
                GroupName = "FORMATTING",
                Description = "This sample demonstrates how to format the tables in the Word document using Essential DocIO.",
                DemoViewType = typeof(FormatTable)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Styles",
                GroupName = "FORMATTING",
                Description = "This sample demonstrates how to apply built-in and custom styles to the contents of the Word document using Essential DocIO.",
                DemoViewType = typeof(Styles)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "RTL Support",
                GroupName = "FORMATTING",
                Description = "This sample demonstrates how to create a Word document with Right-To-Left language text using Essential DocIO.",
                DemoViewType = typeof(RTL)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Table Styles",
                GroupName = "FORMATTING",
                Description = "This sample demonstrates how to apply built-in and custom styles to the tables of the Word document using Essential DocIO.",
                DemoViewType = typeof(TableStyles)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Insert Break",
                GroupName = "PAGE LAYOUT",
                Description = "This sample demonstrates how to insert breaks to the Word document using Essential DocIO.",
                DemoViewType = typeof(InsertBreak)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Watermark",
                GroupName = "PAGE LAYOUT",
                Description = "This sample demonstrates how to insert text and picture watermark into the Word document using Essential DocIO.",
                DemoViewType = typeof(Watermark)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Footnotes and Endnotes",
                GroupName = "REFERENCE",
                Description = "This sample demonstrates how to insert footnotes and endnotes in a Word document using Essential DocIO.",
                DemoViewType = typeof(FootnotesandEndnotes)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Table of Contents",
                GroupName = "REFERENCE",
                Description = "This sample demonstrates how to insert and update the Table of Contents (TOC) in a Word document using Essential DocIO.",
                DemoViewType = typeof(TableofContent)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Table of Figures",
                GroupName = "REFERENCE",
                Description = "This sample demonstrates how to insert and update the table of figures in a Word document using .NET Word Library (DocIO).",
                Tag = Tag.New,
                DemoViewType = typeof(TableOfFigures)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Find and Replace",
                GroupName = "EDITING",
                Description = "This sample demonstrates how to find a text and replacing it with a new text using Essential DocIO.",
                DemoViewType = typeof(FindAndReplace)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Advanced Replace",
                GroupName = "EDITING",
                Description = "This sample demonstrates how to replace a specific content in the Word document with another document using the Find and Replace functionality of Essential DocIO.",
                DemoViewType = typeof(AdvancedReplace)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Bookmark Navigation",
                GroupName = "EDITING",
                Description = "This sample demonstrates how to navigate between the bookmarks in a Word document and edit its content using Bookmark Navigation functionality of Essential DocIO.",
                DemoViewType = typeof(BookmarkNavigation)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Forms",
                GroupName = "EDITING",
                Description = "This sample demonstrates how to create a simple job application form and fill the form using Essential DocIO.",
                DemoViewType = typeof(Forms)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Form Filling and Protection",
                GroupName = "CONTENT CONTROL",
                Description = "This sample demonstrates how to fill a form and protect the content controls in an existing Word document using Essential DocIO.",
                DemoViewType = typeof(FormFillingandProtection)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "XML Mapping",
                GroupName = "CONTENT CONTROL",
                Description = "This sample demonstrates how to map custom XML parts to content controls in the Word document using Essential DocIO.",
                DemoViewType = typeof(XMLMapping)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Create Equation",
                GroupName = "MATHEMATICAL EQUATION",
                Description = "This sample demonstrates how to create a Word document with mathematical equations using Essential DocIO.",
                DemoViewType = typeof(CreateEquation)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Edit Equation",
                GroupName = "MATHEMATICAL EQUATION",
                Description = "This sample demonstrates how to modify a mathematical equation in a Word document using Essential DocIO.",
                DemoViewType = typeof(EditEquation)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "LaTeX",
                GroupName = "MATHEMATICAL EQUATION",
                Description = "This sample demonstrates how to create a Word document with mathematical equation using LaTeX using Essential DocIO.",
                DemoViewType = typeof(LaTeX)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Employee Report",
                GroupName = "MAIL MERGE",
                Description = "This sample demonstrates how to generate an employee report using Mail merge functionality of Essential DocIO.",
                DemoViewType = typeof(EmployeeReport)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Letter Format",
                GroupName = "MAIL MERGE",
                Description = "This sample demonstrates how to generate a letter using Mail merge functionality of Essential DocIO.",
                DemoViewType = typeof(LetterFormat)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Mail Merge Event",
                GroupName = "MAIL MERGE",
                Description = "This sample demonstrates how to format the Mail merged data using Mail merge events of Essential DocIO.",
                DemoViewType = typeof(MailMergeEvent)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Nested Mail Merge",
                GroupName = "MAIL MERGE",
                Description = "This sample demonstrates how to perform Mail merge for nested groups in Word document using Essential DocIO.",
                DemoViewType = typeof(NestedMailMerge)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Sales Invoice",
                GroupName = "MAIL MERGE",
                Description = "This sample demonstrates how to generate sales invoice using Mail merge functionality of Essential DocIO.",
                DemoViewType = typeof(SalesInvoice)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Document Settings",
                GroupName = "VIEW",
                Description = "This sample demonstrates how to apply various document settings to the Word document using Essential DocIO.",
                DemoViewType = typeof(DocumentSettings)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Macro Preservation",
                GroupName = "VIEW",
                Description = "This sample demonstrates preservation of macros in macro-enabled documents (DOCM and DOTM) using Essential DocIO.",
                DemoViewType = typeof(MacroPreservation)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Document Protection",
                GroupName = "SECURITY",
                Description = "This sample demonstrates how to protect the Word document from editing using Essential DocIO.",
                DemoViewType = typeof(DocumentProtection)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Encrypt and Decrypt",
                GroupName = "SECURITY",
                Description = "This sample demonstrates how to encrypt and decrypt the Word document using Essential DocIO.",
                DemoViewType = typeof(EncryptandDecrypt)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Word to PDF",
                GroupName = "IMPORT AND EXPORT",
                Description = "This sample demonstrates how to convert Word document to PDF using Essential DocIO and PDF.",
                DemoViewType = typeof(WordToPDF)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Word to PDF/A",
                GroupName = "IMPORT AND EXPORT",
                Description = "This sample demonstrates how to convert a Word document to PDF/A using .NET Word (DocIO) library and .NET PDF library.",
	        DemoViewType = typeof(WordToPDFA)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Word to PDF/UA",
                GroupName = "IMPORT AND EXPORT",
                Description = "This sample demonstrates how to convert a Word document to PDF/UA (Section 508 compliant) using .NET Word (DocIO) library and .NET PDF library.",
		DemoViewType = typeof(WordToPDFUA)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Word to Image",
                GroupName = "IMPORT AND EXPORT",
                Description = "This sample demonstrates how to convert Word document to Image using Essential DocIO.",
                DemoViewType = typeof(WordToImage)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Word to HTML",
                GroupName = "IMPORT AND EXPORT",
                Description = "This sample demonstrates how to convert the Word document to HTML file using Essential DocIO.",
                DemoViewType = typeof(WordToHTML)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "HTML to Word",
                GroupName = "IMPORT AND EXPORT",
                Description = "This sample demonstrates how to convert the HTML file to Word document using Essential DocIO.",
                DemoViewType = typeof(HTMLToWord)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Word to Markdown",
                GroupName = "IMPORT AND EXPORT",
                Description = "This sample demonstrates how to convert the Word document to Markdown using .NET Word (DocIO) library.",
	        DemoViewType = typeof(WordToMarkdown)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Markdown to Word",
                GroupName = "IMPORT AND EXPORT",
                Description = "This sample demonstrates how to convert the Markdown file to Word document using .NET Word (DocIO) library.",
	        DemoViewType = typeof(MarkdownToWord)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Word to RTF",
                GroupName = "IMPORT AND EXPORT",
                Description = "This sample demonstrates how to convert the Word document to RTF file using Essential DocIO.",
                DemoViewType = typeof(WordToRTF)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "RTF to Word",
                GroupName = "IMPORT AND EXPORT",
                Description = "This sample demonstrates how to convert the RTF file to Word document using Essential DocIO..",
                DemoViewType = typeof(RTFToWord)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Word to WordML",
                GroupName = "IMPORT AND EXPORT",
                Description = "This sample demonstrates how to convert the Word document to Word processing XML using Essential DocIO.",
                DemoViewType = typeof(WordToWordML)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "WordML to Word",
                GroupName = "IMPORT AND EXPORT",
                Description = "This sample demonstrates how to convert the Word processing XML to Word document using Essential DocIO.",
                DemoViewType = typeof(WordMLToWord)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Word to ODT",
                GroupName = "IMPORT AND EXPORT",
                Description = "This sample demonstrates how to convert the Word document to ODT file using Essential DocIO.",
                DemoViewType = typeof(WordToODT)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Word to EPUB",
                GroupName = "IMPORT AND EXPORT",
                Description = "This sample demonstrates how to convert Word document to EPUB using Essential DocIO.",
                DemoViewType = typeof(WordToEPUB)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Auto Shapes",
                GroupName = "SHAPES",
                Description = "This sample demonstrates how to create a Word document with Auto shapes using Essential DocIO.",
                DemoViewType = typeof(AutoShapes)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Group Shapes",
                GroupName = "SHAPES",
                Description = "This sample demonstrates how to create a Word document with Group shapes using Essential DocIO.",
                DemoViewType = typeof(GroupShapes)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Print",
                GroupName = "PRINT",
                Description = "This sample demonstrates how to print a Word document using Essential DocIO.",
                DemoViewType = typeof(Print)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Pie Chart",
                GroupName = "CHARTS",
                Description = "This sample demonstrates how to insert a pie chart into the Word document using Essential DocIO.",
                DemoViewType = typeof(PieChart)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Bar Chart",
                GroupName = "CHARTS",
                Description = "This sample demonstrates how to insert a bar chart into the Word document using Essential DocIO.",
                DemoViewType = typeof(BarChart)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Track Changes",
                GroupName = "REVIEW",
                Description = "This sample demonstrates how to accept or reject the tracked changes in the Word document using Essential DocIO.",
                DemoViewType = typeof(TrackChanges)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Compare Documents",
                GroupName = "REVIEW",
                Description = "This sample demonstrates how to compare two Word documents using .NET Word (DocIO) library. With this, you can easily identify the changes between two versions of a document.",
                DemoViewType = typeof(CompareDocuments)
            });
        }
    }
}

