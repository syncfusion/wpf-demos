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

namespace syncfusion.syntaxeditordemos.wpf
{
    public class SyntaxEditorDemosViewModel : DemoBrowserViewModel
    {
        /// <summary>
        /// Maintains the list of products.
        /// </summary>
        /// <returns>Returns the list of products demos.</returns>
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new SyntaxEditorProductDemos());
            return productdemos;
        }
    }

    /// <summary>
    /// Class represents the product demos
    /// </summary>
    public class SyntaxEditorProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes the new instances of <see cref="SyntaxEditorProductDemos"/> class.
        /// </summary>
        public SyntaxEditorProductDemos()
        {
            this.Product = "Syntax Editor";
            this.ProductCategory = "MISCELLANEOUS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M10.4565 0.703194C10.5687 0.450852 10.455 0.155371 10.2027 0.043219C9.95032 -0.068933 9.65484 0.0447134 9.54269 0.297056L5.54269 9.29706C5.43054 9.5494 5.54418 9.84488 5.79652 9.95703C6.04887 10.0692 6.34435 9.95554 6.4565 9.70319L10.4565 0.703194ZM4.35315 2.14657C4.54841 2.34183 4.54841 2.65842 4.35315 2.85368L1.7067 5.50012L4.35315 8.14657C4.54841 8.34183 4.54841 8.65842 4.35315 8.85368C4.15789 9.04894 3.8413 9.04894 3.64604 8.85368L0.716752 5.92439C0.482438 5.69008 0.482436 5.31018 0.716751 5.07586L3.64604 2.14657C3.8413 1.95131 4.15789 1.95131 4.35315 2.14657ZM11.646 2.14657C11.4508 2.34183 11.4508 2.65842 11.646 2.85368L14.2925 5.50012L11.646 8.14657C11.4508 8.34183 11.4508 8.65842 11.646 8.85368C11.8413 9.04894 12.1579 9.04894 12.3531 8.85368L15.2824 5.92439C15.5168 5.69008 15.5168 5.31018 15.2824 5.07586L12.3531 2.14657C12.1579 1.95131 11.8413 1.95131 11.646 2.14657Z"),
                Width = 16,
                Height = 10,
            };
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/FileViewersAndEditors.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The WPF SyntaxEditor is a powerful text editor control similar to the Microsoft Visual Studio editor. It provides built-in syntax highlighting and code editing experience for popular languages and allows users to create custom syntax highlighting of keywords and operators of their language.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Syntax Editor.png", UriKind.RelativeOrAbsolute));
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "Getting Started",Description= "This sample showcases the various functionalities such as cut, copy, paste, undo, redo, find and replace, tab key behavior and single line mode in EditControl.", ThemeMode=ThemeMode.Inherit, DemoViewType = typeof(GettingStarted) });
            this.Demos.Add(new DemoInfo() { SampleName = "C# Editor", GroupName = "Built-in Languages",Description= "This sample showcases the built-in syntax highlighting feature of C# language, automatic completion list and parameter information support, line background customization, print preview and printing support in EditControl.", ThemeMode=ThemeMode.Inherit, DemoViewType = typeof(CSharpEditor) });
            this.Demos.Add(new DemoInfo() { SampleName = "SQL Editor", GroupName = "Built-in Languages",Description= "This sample showcases how to customize the SQL language in EditControl.", ThemeMode=ThemeMode.Inherit, DemoViewType = typeof(SQLEditor) });
            this.Demos.Add(new DemoInfo() { SampleName = "Visual Basic Editor", GroupName = "Built-in Languages",Description= "This sample showcases how to customize the Visual Basic language in EditControl.", ThemeMode=ThemeMode.Inherit, DemoViewType = typeof(VisualBasicEditor) });
            this.Demos.Add(new DemoInfo() { SampleName = "XML and XAML Editor", GroupName = "Built-in Languages",Description= "This sample showcases how to customize the XML and XAML language in EditControl.", ThemeMode=ThemeMode.Inherit, DemoViewType = typeof(XMLAndXAMLEditor) });
            this.Demos.Add(new DemoInfo() { SampleName = "Custom Language", GroupName = "Custom Language",Description= "This sample showcases how to open, create, and modify programming language files, highlighting, line number, read-only support, expand and collapse, comment or uncomment functionalities in EditControl.", ThemeMode=ThemeMode.Inherit, DemoViewType = typeof(CustomLanguage) });
            this.Demos.Add(new DemoInfo() { SampleName = "Syntax Highlighting", GroupName = "Syntax Highlighting",Description= "This sample showcases the language-based syntax highlighting feature in EditControl.", ThemeMode=ThemeMode.Inherit, DemoViewType = typeof(SyntaxHighlighting) });
            this.Demos.Add(new DemoInfo() { SampleName = "Custom Intellisense", GroupName = "Intellisense",Description= "This sample showcases the support to customize the intellisense list box, enable or disable the intellisense and add or remove items to it in EditControl.", ThemeMode=ThemeMode.Inherit,  DemoViewType = typeof(CustomIntellisense) });
            this.Demos.Add(new DemoInfo() { SampleName = "Intellisense Editor", GroupName = "Intellisense", Description = "This sample showcases the support to customize the intellisense list box, add references or remove references button and type code in the edit control to view a list of intellisense items in EditControl.", ThemeMode=ThemeMode.Inherit, DemoViewType = typeof(IntellisenseEditor) });
            this.Demos.Add(new DemoInfo() { SampleName = "Multilevel Intellisense", GroupName = "Intellisense", Description = "This sample showcases the nested intellisense support using the intellisense list box in EditControl.", ThemeMode=ThemeMode.Inherit, DemoViewType = typeof(MultilevelIntellisense) });
            this.Demos.Add(new DemoInfo() { SampleName = "Context Prompt", GroupName = "Context Prompt", Description = "This sample showcases the context prompt generated from loaded assemblies of EditControl.", ThemeMode = ThemeMode.Inherit, DemoViewType = typeof(ContextPrompt) });
        }
    }
}
