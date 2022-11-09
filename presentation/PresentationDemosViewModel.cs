#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Collections.Generic;

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
            this.Demos = new List<DemoInfo>();
            this.Tag = Tag.Updated;

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
                DemoViewType = typeof(PPTXToPDF),
                Tag = Tag.Updated
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Images",
                GroupName = "Slide Elements",
                Description = "This sample demonstrates how to insert an image in a PowerPoint slide.",
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

