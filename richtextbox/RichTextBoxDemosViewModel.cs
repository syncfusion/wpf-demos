#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Collections.Generic;

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
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Document Editor", GroupName = "PRODUCT SHOWCASE", Title = "Document Editor", Description = "This sample illustrates document editor using SfRichTextBoxAdv control that is similar to Microsoft Word with Ribbon options.", DemoViewType = typeof(DocumentEditorDemo), ThemeMode = ThemeMode.Inherit, DemoLauchMode = DemoLauchMode.Window, Tag = Tag.Updated });
            this.Demos.Add(new DemoInfo() { SampleName = "Sticky Notes", GroupName = "CUSTOMIZATION", Title = "Sticky Notes", Description = "This sample illustrates text editor by using SfRichTextBoxAdv control that is similar to the Windows Sticky Notes.", DemoViewType = typeof(StickyNotesDemo), ThemeMode = ThemeMode.Default, DemoLauchMode = DemoLauchMode.Window, Tag = Tag.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Create Letters", GroupName = "CUSTOMIZATION", Title = "Create Letters", Description = "This sample illustrates creating letter by modifying recipients in the template using UI container of SfRichTextBoxAdv control.", DemoViewType = typeof(CreateLettersDemo), ThemeMode = ThemeMode.Inherit, DemoLauchMode = DemoLauchMode.Window, Tag = Tag.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Forum", GroupName = "CUSTOMIZATION", Title = "Forum", Description = "This sample illustrates creation of forum application by using SfRichTextBoxAdv control in block and continuous (single-page view) layout types.", DemoViewType = typeof(ForumDemo), ThemeMode = ThemeMode.Default, DemoLauchMode = DemoLauchMode.Window, Tag = Tag.None });
        }
    }
}
