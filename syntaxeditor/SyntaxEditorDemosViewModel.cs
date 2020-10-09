#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Collections.Generic;

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
            this.ProductCategory = "FILE VIEWERS AND EDITORS";
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
