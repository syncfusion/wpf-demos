#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M0 2C0 0.89543 0.895431 0 2 0H4C5.10457 0 6 0.895431 6 2V4C6 5.10457 5.10457 6 4 6H2C0.89543 6 0 5.10457 0 4V2ZM4.85355 2.35355L2.99497 4.21213C2.72161 4.4855 2.27839 4.4855 2.00503 4.21213L1.14645 3.35355C0.951184 3.15829 0.951184 2.84171 1.14645 2.64645C1.34171 2.45118 1.65829 2.45118 1.85355 2.64645L2.5 3.29289L4.14645 1.64645C4.34171 1.45118 4.65829 1.45118 4.85355 1.64645C5.04882 1.84171 5.04882 2.15829 4.85355 2.35355ZM2 9H4C4.55228 9 5 9.44772 5 10V12C5 12.5523 4.55228 13 4 13H2C1.44772 13 1 12.5523 1 12V10C1 9.44772 1.44772 9 2 9ZM0 10C0 8.89543 0.895431 8 2 8H4C5.10457 8 6 8.89543 6 10V12C6 13.1046 5.10457 14 4 14H2C0.89543 14 0 13.1046 0 12V10ZM8 1.5C8 1.22386 8.22386 1 8.5 1H13.5C13.7761 1 14 1.22386 14 1.5C14 1.77614 13.7761 2 13.5 2H8.5C8.22386 2 8 1.77614 8 1.5ZM8.5 9C8.22386 9 8 9.22386 8 9.5C8 9.77614 8.22386 10 8.5 10H13.5C13.7761 10 14 9.77614 14 9.5C14 9.22386 13.7761 9 13.5 9H8.5ZM8 4.5C8 4.22386 8.22386 4 8.5 4H11.5C11.7761 4 12 4.22386 12 4.5C12 4.77614 11.7761 5 11.5 5H8.5C8.22386 5 8 4.77614 8 4.5ZM8.5 12C8.22386 12 8 12.2239 8 12.5C8 12.7761 8.22386 13 8.5 13H11.5C11.7761 13 12 12.7761 12 12.5C12 12.2239 11.7761 12 11.5 12H8.5Z"),
                Width = 14,
                Height = 14,
            };
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/ListandDropdown.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The CheckedListBox control allows to check items in a list. The control also supports select-all, grouping, sorting, virtualization, theming, etc.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/CheckListBox.png", UriKind.RelativeOrAbsolute));
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
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2.5 5H13.5C14.88 5 16 3.88 16 2.5C16 1.12 14.88 0 13.5 0H2.5C1.12 0 0 1.12 0 2.5C0 3.88 1.12 5 2.5 5ZM1 2.5C1 1.67 1.67 1 2.5 1H13.5C14.33 1 15 1.67 15 2.5C15 3.33 14.33 4 13.5 4H2.5C1.67 4 1 3.33 1 2.5ZM3.5 3H8.5C8.78 3 9 2.78 9 2.5C9 2.22 8.78 2 8.5 2H3.5C3.22 2 3 2.22 3 2.5C3 2.78 3.22 3 3.5 3ZM13.5 14H2.5C1.12 14 0 12.88 0 11.5V9.5C0 8.12 1.12 7 2.5 7H13.5C14.88 7 16 8.12 16 9.5V11.5C16 12.88 14.88 14 13.5 14ZM2.5 8C1.67 8 1 8.67 1 9.5V11.5C1 12.33 1.67 13 2.5 13H13.5C14.33 13 15 12.33 15 11.5V9.5C15 8.67 14.33 8 13.5 8H2.5ZM12.16 3.10001L13.32 2H11L12.16 3.10001Z"),
                Width = 16,
                Height = 14,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/ListandDropdown.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The ComboBox control is a rich, multiselect combo box implementation that provides a flexible dropdown list with support for single and multiple selection.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/ComboBox.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "ComboBox", Description = "This sample showcases the various features of ComboBox control such as single selection, multi-selection, delimiter character and watermark support.", GroupName = "ComboBox", DemoViewType = typeof(ComboBoxView) });
            this.Demos.Add(new DemoInfo() { SampleName = "Editing", Description = "This sample showcases the various autocomplete modes of ComboBox.", GroupName = "ComboBox", DemoViewType = typeof(AutoComplete) });
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
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M13.5 6H2.5C1.12 6 0 4.88 0 3.5C0 2.12 1.12 1 2.5 1H13.5C14.88 1 16 2.12 16 3.5C16 4.88 14.88 6 13.5 6ZM2.5 2C1.67 2 1 2.67 1 3.5C1 4.33 1.67 5 2.5 5H13.5C14.33 5 15 4.33 15 3.5C15 2.67 14.33 2 13.5 2H2.5ZM8.5 4H3.5C3.22 4 3 3.78 3 3.5C3 3.22 3.22 3 3.5 3H8.5C8.78 3 9 3.22 9 3.5C9 3.78 8.78 4 8.5 4ZM12.16 4.10001L13.32 3H11L12.16 4.10001ZM2 9H1.5C1.22386 9 1 9.22386 1 9.5V13.5C1 13.7761 1.22386 14 1.5 14H2V9ZM5 9V14H7V9H5ZM9 9V14H11V9H9ZM14.5 14H14V9H14.5C14.7761 9 15 9.22386 15 9.5V13.5C15 13.7761 14.7761 14 14.5 14ZM1.5 8C0.671573 8 0 8.67157 0 9.5V13.5C0 14.3284 0.671573 15 1.5 15H14.5C15.3284 15 16 14.3284 16 13.5V9.5C16 8.67157 15.3284 8 14.5 8H1.5Z"),
                Width = 16,
                Height = 16,
            };
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/ListandDropdown.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The MultiColumnDropDown control provides a rich lookup selection experience by embedding the SfDataGrid control to display multiple columns in a dropdown.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/MultiColumn Dropdown.png", UriKind.RelativeOrAbsolute));
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "MultiColumn Dropdown", Description = "This sample showcases the features in SfMultiColumnDropDownControl. SfMultiColumnDropDownControl is a selection control with drop down SfDataGrid that can be shown or hidden by clicking the arrow control. It provides textbox to the user. Based on the user input, it shows the possible suggestion to the users. The SfMultiColumnDropDownControl provides features like AllowAutoComplete, AllowIncrementalFiltering, AllowCaseSensitiveFiltering, AllowImmediatePopup and ReadOnly.", GroupName = "MULTICOLUMN DROPDOWN", DemoViewType = typeof(MultiColumnDropDownDemo), ThemeMode = ThemeMode.Inherit });

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
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M13.5 5H2.5C1.12 5 0 3.88 0 2.5C0 1.12 1.12 0 2.5 0H13.5C14.88 0 16 1.12 16 2.5C16 3.88 14.88 5 13.5 5ZM2.5 1C1.67 1 1 1.67 1 2.5C1 3.33 1.67 4 2.5 4H13.5C14.33 4 15 3.33 15 2.5C15 1.67 14.33 1 13.5 1H2.5ZM8.5 3H3.5C3.22 3 3 2.78 3 2.5C3 2.22 3.22 2 3.5 2H8.5C8.78 2 9 2.22 9 2.5C9 2.78 8.78 3 8.5 3ZM2.5 14H13.5C14.88 14 16 12.88 16 11.5V9.5C16 8.12 14.88 7 13.5 7H2.5C1.12 7 0 8.12 0 9.5V11.5C0 12.88 1.12 14 2.5 14ZM1 9.5C1 8.67 1.67 8 2.5 8H13.5C14.33 8 15 8.67 15 9.5V11.5C15 12.33 14.33 13 13.5 13H2.5C1.67 13 1 12.33 1 11.5V9.5Z"),
                Width = 16,
                Height = 14,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/ListandDropdown.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The WPF AutoComplete control provides a common autocomplete text box to select values from a predefined list easily and adds the common autocomplete paradigm to the text boxes. The control has features to help you customize the behavior, look, and feel in many different ways.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Auto Complete.png", UriKind.RelativeOrAbsolute));
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
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/ListandDropdown.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The WPF TextBoxExt control provides a common autocomplete text box to select values from a predefined list easily and adds the common autocomplete paradigm to the text boxes. The control has features to help you customize the behavior, look, and feel in many different ways.";
            this.Demos.Add(new DemoInfo() { SampleName = "AutoComplete", Description = "This sample showcases the capabilities of AutoComplete (TextBoxExt) like different suggestion modes, watermark texts, setting minimum prefix characters, and custom filters.", GroupName = "TextboxExt", DemoViewType = typeof(AutoCompleteDemo), ThemeMode = ThemeMode.Inherit });
            this.Demos.Add(new DemoInfo() { SampleName = "MultiSelection", Description = "This sample showcases the multiple selection support in AutoComplete (TextBoxExt).", GroupName = "TextboxExt", DemoViewType = typeof(MultiSelectionDemo), ThemeMode = ThemeMode.Inherit });
        }
    }
}