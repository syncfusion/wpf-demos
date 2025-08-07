#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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

namespace syncfusion.presentationdemos.wpf
{
    public class PresentationDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new PresentationProductDemos());
            return productdemos;
        }
    }
    public class PresentationProductDemos : ProductDemo
    {
        public PresentationProductDemos()
        {
            this.Product = "Presentation";
            this.ProductCategory = "FILE FORMAT";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2.5 14C1.12 14 0 12.88 0 11.5V2.5C0 1.12 1.12 0 2.5 0H11.5C12.88 0 14 1.12 14 2.5V11.5C14 12.88 12.88 14 11.5 14H2.5ZM2.5 1C1.67 1 1 1.67 1 2.5V11.5C1 12.33 1.67 13 2.5 13H11.5C12.33 13 13 12.33 13 11.5V2.5C13 1.67 12.33 1 11.5 1H2.5ZM7 3.5C6.20887 3.5 5.43552 3.7346 4.77772 4.17412C4.11992 4.61365 3.60723 5.23836 3.30448 5.96927C3.00173 6.70017 2.92252 7.50444 3.07686 8.28036C3.2312 9.05629 3.61216 9.76902 4.17157 10.3284C4.73098 10.8878 5.44371 11.2688 6.21964 11.4231C6.99556 11.5775 7.79983 11.4983 8.53073 11.1955C9.26164 10.8928 9.88635 10.3801 10.3259 9.72228C10.7654 9.06448 11 8.29113 11 7.5H7V3.5ZM11.1955 5.46927C11.3965 5.95457 11.5 6.47471 11.5 7H7.5V3C8.02529 3 8.54543 3.10346 9.03073 3.30448C9.51604 3.5055 9.95699 3.80014 10.3284 4.17157C10.6999 4.54301 10.9945 4.98396 11.1955 5.46927Z"),
                Width = 14,
                Height = 14,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/FileFormat.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "A .NET PowerPoint library to create, read, and edit PowerPoint files programmatically.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Presentation.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Hello World",
                GroupName = "Getting Started",
                Description = "This sample demonstrates how to create slides with simple text in a PowerPoint presentation.",
                DemoViewType = typeof(HelloWorld)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "PPTX to Image",
                GroupName = "Conversion",
                Description = "This sample demonstrates how to convert the PowerPoint slide to an image.",
                DemoViewType = typeof(PPTXToImage)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "PPTX to PDF",
                GroupName = "Conversion",
                Description = "This sample demonstrates how to convert a PowerPoint presentation to PDF.",
                DemoViewType = typeof(PPTXToPDF)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "PPTX to PDF/A",
                GroupName = "Conversion",
                Description = "This sample demonstrates how to convert a PowerPoint Presentation to PDF/A using .NET PowerPoint library and .NET PDF library.",
	        DemoViewType = typeof(PPTXToPDFA)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "PPTX to PDF/UA",
                GroupName = "Conversion",
                Description = "This sample demonstrates how to convert a PowerPoint Presentation to PDF/UA using .NET PowerPoint library and .NET PDF library.",
	        DemoViewType = typeof(PPTXToPDFUA)
            });
			 this.Demos.Add(new DemoInfo()
            {
                 SampleName = "Find and Replace",
                 GroupName = "Editing",
                 Description = "This sample demonstrates how to replace a specific text in the PowerPoint presentation with another text using Find and Replace functionality of .NET PowerPoint  library.",
                 DemoViewType = typeof(FindAndReplace)
             });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Find and Highlight",
                GroupName = "Editing",
                Description = "This sample demonstrates how to find a specific text and highlight it in an existing PowerPoint presentation using Find functionality of .NET PowerPoint library.",
	        DemoViewType = typeof(FindAndHighlight)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Images",
                GroupName = "Slide Elements",
                Description = "This sample demonstrates how to add and format images in PowerPoint Presentation using .NET PowerPoint Library (Presentation).",
                DemoViewType = typeof(Images)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Slides",
                GroupName = "Slide Elements",
                Description = "This sample demonstrates how to create slides with simple text, table and image in a PowerPoint presentation.",
                DemoViewType = typeof(Slide)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Tables",
                GroupName = "Slide Elements",
                Description = "This sample demonstrates how to add tables in a PowerPoint presentation.",
                DemoViewType = typeof(Tables)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Notes",
                GroupName = "Slide Elements",
                Description = "This sample demonstrates how to add and convert the notes pages of a PowerPoint slide.",
                DemoViewType = typeof(Notes)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "OLE Object",
                GroupName = "Slide Elements",
                Description = "This sample demonstrates how to insert and extract a OLE Object in PowerPoint presentation.",
                DemoViewType = typeof(OLEObject)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Comments",
                GroupName = "Slide Elements",
                Description = "This sample demonstrates how to add comments to a presentation slide.",
                DemoViewType = typeof(Comments)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Connector",
                GroupName = "Slide Elements",
                Description = "This sample demonstrates how to insert the connectors in a PowerPoint slide.",
                DemoViewType = typeof(Connectors)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Header And Footer",
                GroupName = "Slide Elements",
                Description = "This sample demonstrates how to insert the header and footer in a PowerPoint presentation.",
                DemoViewType = typeof(HeaderAndFooter)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Create Animation",
                GroupName = "Animation",
                Description = "This sample demonstrates how to add different animation effect for shapes.",
                DemoViewType = typeof(Animation)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Modify Animation",
                GroupName = "Animation",
                Description = "This sample demonstrates how to modify the animation effect for shapes.",
                DemoViewType = typeof(ModifyAnimation)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Slide Transition",
                GroupName = "Transition",
                Description = "This sample demonstrates how to create slide transition effects in PowerPoint presentation.",
                DemoViewType = typeof(SlideTransition)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Cloning Slide",
                GroupName = "Clone and Merge",
                Description = "This sample demonstrates cloning an individual slide from a PowerPoint presentation and merge it to another PowerPoint presentation with source and destination paste options.",
                DemoViewType = typeof(CloningSlide)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Merging Presentation",
                GroupName = "Clone and Merge",
                Description = "This sample demonstrates merging two PowerPoint presentation documents with paste options - use destination theme and source formatting.",
                DemoViewType = typeof(MergingPresentation)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Encryption and Decryption",
                GroupName = "Security",
                Description = "This sample demonstrates how to encrypt and decrypt the PowerPoint document using Essential Presentation.",
                DemoViewType = typeof(EncryptDecrypt)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Write Protection",
                GroupName = "Security",
                Description = "This sample demonstrates how to set write protection for a PowerPoint presentation with password.",
                DemoViewType = typeof(WriteProtection)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "SmartArt Creation",
                GroupName = "SmartArt",
                Description = "This sample demonstrates how to create SmartArt diagram in a PowerPoint presentation and convert it to PDF document.",
                DemoViewType = typeof(SmartArtCreation)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Manipulating SmartArt",
                GroupName = "SmartArt",
                Description = "This sample demonstrates how to add/remove nodes in a SmartArt diagram and edit text of the nodes in a PowerPoint presentation.",
                DemoViewType = typeof(ManipulatingSmartArt)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Customizing Appearance",
                GroupName = "SmartArt",
                Description = "This sample demonstrates how to customize the appearance of a SmartArt diagram in a PowerPoint slide.",
                DemoViewType = typeof(CustomizingAppearance)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Chart Creation",
                GroupName = "Working With Chart",
                Description = "This sample demonstrates how to create charts in a presentation using PowerPoint presentation.",
                DemoViewType = typeof(ChartCreation)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Chart from Excel Data",
                GroupName = "Working With Chart",
                Description = "This sample demonstrates how to create a chart in a PowerPoint presentation, from the data in an existing excel file.",
                DemoViewType = typeof(ExcelDataToChart)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Customizing Appearance",
                GroupName = "Working With Chart",
                Description = "This sample demonstrates how to modify charts in a presentation using PowerPoint presentation.",
                DemoViewType = typeof(ChartModifications)
            });            
        }
    }
}

