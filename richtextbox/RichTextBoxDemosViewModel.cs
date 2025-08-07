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

namespace syncfusion.richtextboxdemos.wpf
{
   public class RichTextBoxDemosViewModel : DemoBrowserViewModel
    {
        // <summary>
        /// Maintains the list of products.
        /// </summary>
        /// <returns>Returns the list of products demos.</returns>
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new RichTextBoxProductDemos());
            this.ShowcaseDemos = new List<DemoInfo>();
            this.ShowcaseDemos.Add(new DemoInfo()
            {
                DemoViewType = typeof(documenteditor.wpf.DocumentEditorDemo),
                SampleName = "Document Editor",
                ImagePath = "/syncfusion.documenteditor.wpf;component/Assets/documenteditor/DocumentEditor.png"
            });
            return productdemos;
        }
    }

    /// <summary>
    /// Class represents the product demos
    /// </summary>
    public class RichTextBoxProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes the new instances of <see cref="RichTextBoxProductDemos"/> class.
        /// </summary>
        public RichTextBoxProductDemos()
        {
            this.Product = "RichTextBox";
            this.ProductCategory = "FILE VIEWERS AND EDITORS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2 1H12C12.5523 1 13 1.44772 13 2V4H1V2C1 1.44772 1.44772 1 2 1ZM0 5V4V2C0 0.89543 0.895431 0 2 0H12C13.1046 0 14 0.895431 14 2V12C14 13.1046 13.1046 14 12 14H2C0.89543 14 0 13.1046 0 12V5ZM1 5H13V12C13 12.5523 12.5523 13 12 13H2C1.44772 13 1 12.5523 1 12V5ZM11 8H3V10H11V8ZM3 7C2.44772 7 2 7.44772 2 8V10C2 10.5523 2.44772 11 3 11H11C11.5523 11 12 10.5523 12 10V8C12 7.44772 11.5523 7 11 7H3ZM4.5 8.5C4.22386 8.5 4 8.72386 4 9C4 9.27614 4.22386 9.5 4.5 9.5H7.5C7.77614 9.5 8 9.27614 8 9C8 8.72386 7.77614 8.5 7.5 8.5H4.5Z"),
                Width = 14,
                Height = 14,
            };
            this.Tag = Tag.None;
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/FileViewersAndEditors.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The RichTextBox control provides all the common word-processing features including editing text, formatting contents, resizing images and tables, finding and replacing text, spell checking, adding comments, printing, and importing and exporting Word documents.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/RichTextBox.png", UriKind.RelativeOrAbsolute));
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Document Editor", GroupName = "PRODUCT SHOWCASE", Title = "Document Editor", Description = "This sample illustrates document editor using SfRichTextBoxAdv control that is similar to Microsoft Word with Ribbon options.", DemoViewType = typeof(DocumentEditorDemo), ThemeMode = ThemeMode.Inherit, DemoLauchMode = DemoLauchMode.Window, Tag = Tag.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Sticky Notes", GroupName = "CUSTOMIZATION", Title = "Sticky Notes", Description = "This sample illustrates text editor by using SfRichTextBoxAdv control that is similar to the Windows Sticky Notes.", DemoViewType = typeof(StickyNotesDemo), ThemeMode = ThemeMode.Default, DemoLauchMode = DemoLauchMode.Window, Tag = Tag.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Create Letters", GroupName = "CUSTOMIZATION", Title = "Create Letters", Description = "This sample illustrates creating letter by modifying recipients in the template using UI container of SfRichTextBoxAdv control.", DemoViewType = typeof(CreateLettersDemo), ThemeMode = ThemeMode.Default, DemoLauchMode = DemoLauchMode.Window, Tag = Tag.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Forum", GroupName = "CUSTOMIZATION", Title = "Forum", Description = "This sample illustrates creation of forum application by using SfRichTextBoxAdv control in block and continuous (single-page view) layout types.", DemoViewType = typeof(ForumDemo), ThemeMode = ThemeMode.None, DemoLauchMode = DemoLauchMode.Window, Tag = Tag.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Right to Left", GroupName = "LOCALIZATION", Title = "Right to Left", Description = "This sample illustrates document editor fully localized for Right-to-left language using SfRichTextBoxAdv control.", DemoViewType = typeof(RightToLeftDemo), ThemeMode = ThemeMode.Inherit, DemoLauchMode = DemoLauchMode.Window, Tag = Tag.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Localization", GroupName = "LOCALIZATION", Title = "Localization", Description = "This sample illustrates localized document editor by using SfRichTextBoxAdv control with a set of resource manager files.", DemoViewType = typeof(LocalizationDemo), ThemeMode = ThemeMode.Inherit, DemoLauchMode = DemoLauchMode.Window, Tag = Tag.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Smart Writer", GroupName = "SMART RichTextBox", Title = "Smart Writer", Description = "The smart writer feature in SfRichTextBoxAdv helps users generate new content based on their ideas or prompts. It seamlessly integrates into the editor, providing relevant text suggestions with the assistance of AI that can be directly inserted into the document, enhancing the writing experience.", DemoViewType = typeof(SmartWriterDemo), ThemeMode = ThemeMode.Inherit, DemoLauchMode = DemoLauchMode.Window, Tag = Tag.None , IsAISample = true });
            this.Demos.Add(new DemoInfo() { SampleName = "Smart Editor", GroupName = "SMART RichTextBox", Title = "Smart Editor", Description = "This sample showcases the integration of AI services into the SfRichTextBoxAdv control, offering features such as grammar corrections, text paraphrasing for improved readability, and multilingual translations. These capabilities are seamlessly accessible via the context menu-just right-click on the selected text to refine content or perform translations effortlessly.", DemoViewType = typeof(SmartEditorDemo), ThemeMode = ThemeMode.Inherit, DemoLauchMode = DemoLauchMode.Window, Tag = Tag.None , IsAISample = true });
            this.Demos.Add(new DemoInfo() { SampleName = "Smart Summarizer", GroupName = "SMART RichTextBox", Title = "Smart Summarizer", Description = "This sample showcases the capabilities of SfRichTextBoxAdv for document summarization and Q&A. Users can generate a summary of a Word document by clicking the AI Assistant button in the bottom-right corner. After the summary is generated, users can ask questions about the document using their own queries or AI-generated suggestions.", DemoViewType = typeof(SmartSummarizerDemo), ThemeMode = ThemeMode.Inherit, DemoLauchMode = DemoLauchMode.Window, Tag = Tag.None , IsAISample = true });
        }
    }
}
