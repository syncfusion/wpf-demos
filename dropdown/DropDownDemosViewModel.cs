#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using syncfusion.demoscommon.wpf;
using System.Collections.Generic;

namespace syncfusion.dropdowndemos.wpf
{
    /// <summary>
    /// Class represents the dropdown demo viewmodel
    /// </summary>
    public class DropDownDemosViewModel : DemoBrowserViewModel
    {
        /// <summary>
        /// Maintains the list of products.
        /// </summary>
        /// <returns>Returns the list of products demos.</returns>
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new ComboBoxProductDemos());
            productdemos.Add(new AutoCompleteProductDemos());
            productdemos.Add(new TextboxExtProductDemos());
            productdemos.Add(new CheckListBoxProductDemos());
            productdemos.Add(new MultiColumnDropDownProductDemos());
            return productdemos;
        }
    }

    /// <summary>
    /// Class represents the product demos
    /// </summary>
    public class CheckListBoxProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes the new instances of <see cref="CheckListBoxProductDemos"/> class.
        /// </summary>
        public CheckListBoxProductDemos()
        {
            this.Product = "CheckListBox";
            this.ProductCategory = "LISTS AND DROPDOWN";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description = "This sample showcases the basic features of CheckListBox control such as Select All, Grouping, Sorting, Checking", GroupName = "CHECKLISTBOX", DemoViewType = typeof(CheckListBoxDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Virtualization", Description = "This sample demonstrates loading huge item into CheckListBox using Virtualization feature", GroupName = "CHECKLISTBOX", DemoViewType = typeof(VirtualizationDemo) });
        }
    }

    /// <summary>
    /// Class represents the product demos
    /// </summary>
    public class ComboBoxProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes the new instances of <see cref="ComboBoxProductDemos"/> class.
        /// </summary>
        public ComboBoxProductDemos()
        {
            this.Product = "ComboBox";
            this.ProductCategory = "LISTS AND DROPDOWN";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "ComboBox", Description = "This sample showcases the various features of ComboBox control such as single selection, multi-selection, delimiter character and watermark support.", GroupName = "ComboBox", DemoViewType = typeof(ComboBoxView) });
        }
    }

    /// <summary>
    /// Class represents the product demos
    /// </summary>
    public class MultiColumnDropDownProductDemos : ProductDemo
    {
        public MultiColumnDropDownProductDemos()
        {
            this.Product = "MultiColumn Dropdown";
            this.ProductCategory = "LISTS AND DROPDOWN";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "MultiColumn Dropdown", Description = "This sample showcases the features in SfMultiColumnDropDownControl. SfMultiColumnDropDownControl is a selection control with drop down SfDataGrid that can be shown or hidden by clicking the arrow control. It provides textbox to the user. Based on the user input, it shows the possible suggestion to the users. The SfMultiColumnDropDownControl provides features like AllowAutoComplete, AllowIncrementalFiltering, AllowCaseSensitiveFiltering, AllowImmediatePouup and ReadOnly.", GroupName = "MULTICOLUMN DROPDOWN", DemoViewType = typeof(MultiColumnDropDownDemo), ThemeMode = ThemeMode.Inherit });

        }
    }

    /// <summary>
    /// Class represents the product demos
    /// </summary>
    public class AutoCompleteProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes the new instances of <see cref="AutoCompleteProductDemos"/> class.
        /// </summary>
        public AutoCompleteProductDemos()
        {
            this.Product = "AutoComplete";
            this.ProductCategory = "LISTS AND DROPDOWN";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "AutoComplete", Description = "This sample showcases the capabilities of AutoComplete (SfTextBoxExt) like different suggestion modes, watermark texts, setting minimum prefix characters, and custom filters.", GroupName = "Auto Complete", DemoViewType = typeof(AutoCompleteDemo), ThemeMode = ThemeMode.Inherit });
            this.Demos.Add(new DemoInfo() { SampleName = "MultiSelection", Description = "This sample showcases the multiple selection support in AutoComplete (SfTextBoxExt).", GroupName = "Auto Complete", DemoViewType = typeof(MultiSelectionDemo), ThemeMode = ThemeMode.Inherit });
        }
    }

    /// <summary>
    /// Class represents the product demos
    /// </summary>
    public class TextboxExtProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes the new instances of <see cref="ComboBoxProductDemos"/> class.
        /// </summary>
        public TextboxExtProductDemos()
        {
            this.Product = "TextboxExt";
            this.ProductCategory = "LISTS AND DROPDOWN";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "AutoComplete", Description = "This sample showcases the capabilities of AutoComplete (TextBoxExt) like different suggestion modes, watermark texts, setting minimum prefix characters, and custom filters.", GroupName = "TextboxExt", DemoViewType = typeof(AutoCompleteDemo), ThemeMode = ThemeMode.Inherit });
            this.Demos.Add(new DemoInfo() { SampleName = "MultiSelection", Description = "This sample showcases the multiple selection support in AutoComplete (TextBoxExt).", GroupName = "TextboxExt", DemoViewType = typeof(MultiSelectionDemo), ThemeMode = ThemeMode.Inherit });
        }
    }
}