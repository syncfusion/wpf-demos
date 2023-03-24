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

namespace syncfusion.navigationdemos.wpf
{
    public class NavigationDemosViewModel : DemoBrowserViewModel
    {
        /// <summary>
        /// Maintains the list of products.
        /// </summary>
        /// <returns>Returns the list of products demos.</returns>
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new TabControlExtProductDemos());
            productdemos.Add(new AccordionProductDemos());
			productdemos.Add(new HierarchicalNavigatorProductDemo());
            productdemos.Add(new NavigationDrawerProductDemos());
            productdemos.Add(new TreeNavigatorProductDemo());
            productdemos.Add(new GroupBarProductDemos());
            productdemos.Add(new MenuProductDemos());
            productdemos.Add(new RadialMenuProductDemos());
            productdemos.Add(new ToolBarProductDemos());
            productdemos.Add(new TaskBarProductDemos());
            productdemos.Add(new WizardControlProductDemo());
            return productdemos;
        }
    }

    /// <summary>
    /// Class represents the product demos
    /// </summary>
    public class NavigationDrawerProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes the new instances of <see cref="NavigationDrawerProductDemos"/> class.
        /// </summary>
        public NavigationDrawerProductDemos()
        {
            this.Product = "Navigation Drawer";
            this.ProductCategory = "NAVIGATION";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M12 1H6V13H12C12.5523 13 13 12.5523 13 12V2C13 1.44772 12.5523 1 12 1ZM2 0C0.895431 0 0 0.89543 0 2V12C0 13.1046 0.89543 14 2 14H12C13.1046 14 14 13.1046 14 12V2C14 0.895431 13.1046 0 12 0H2ZM8 3C7.72386 3 7.5 3.22386 7.5 3.5C7.5 3.77614 7.72386 4 8 4H11C11.2761 4 11.5 3.77614 11.5 3.5C11.5 3.22386 11.2761 3 11 3H8ZM7.5 6.5C7.5 6.22386 7.72386 6 8 6H11C11.2761 6 11.5 6.22386 11.5 6.5C11.5 6.77614 11.2761 7 11 7H8C7.72386 7 7.5 6.77614 7.5 6.5ZM8 9C7.72386 9 7.5 9.22386 7.5 9.5C7.5 9.77614 7.72386 10 8 10H11C11.2761 10 11.5 9.77614 11.5 9.5C11.5 9.22386 11.2761 9 11 9H8Z"),
                Width = 14,
                Height = 14,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Navigation.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The WPF Navigation Drawer control is a sidebar navigation view used to create a navigation menu. It provides compact and extended display modes with built-in navigation view items. Switch between the modes based on the available size of the window. It also provides a default mode that allows a custom pane view.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Navigation Drawer.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "Navigation Drawer", Description = "This sample showcase the basic functionalities of NavigationDrawer.", DemoViewType = typeof(DisplayMode), ThemeMode = ThemeMode.Inherit });
            this.Demos.Add(new DemoInfo() { SampleName = "Data Binding", GroupName = "Navigation Drawer", Description = "This sample showcases the items populated with the collection of business objects using ItemsSource in NavigationDrawer.", DemoViewType = typeof(NavigationDrawerDataBinding), ThemeMode = ThemeMode.Inherit});
            this.Demos.Add(new DemoInfo() { SampleName = "Footer Items", GroupName = "Navigation Drawer", Description = "This sample showcase the FooterItems support in NavigationDrawer.", DemoViewType = typeof(FooterItems), ThemeMode = ThemeMode.Inherit});
            this.Demos.Add(new DemoInfo() { SampleName = "Hierarchical Collection", GroupName = "Navigation Drawer", Description = "This sample showcase the hierarchical levels of items placed inside the drawer menu when using compact and expanded display mode.", DemoViewType = typeof(HierarchicalCollection), ThemeMode = ThemeMode.Inherit });
            this.Demos.Add(new DemoInfo() { SampleName = "API in action", GroupName = "Navigation Drawer", Description = "This sample showcase the API action in NavigationDrawer.", DemoViewType = typeof(Hierarchical), ThemeMode = ThemeMode.Inherit });
            this.Demos.Add(new DemoInfo() { SampleName = "Custom Views", GroupName = "Navigation Drawer",Description = "Custom views can be populated to the header, body and footer part of the drawer menu. The Navigation Drawer is usually hidden, and it appears when you swipe the screen from any of the four edges or by tapping the app icon, if available.", DemoViewType = typeof(NavigationDrawerView), ThemeMode = ThemeMode.None });
            }
    }

    /// <summary>
    /// Class represents the product demos
    /// </summary>
    public class WizardControlProductDemo : ProductDemo
    {
        /// <summary>
        /// Initializes the new instances of <see cref="WizardControlProductDemo"/> class.
        /// </summary>
        public WizardControlProductDemo()
        {
            this.Product = "Wizard Control";
            this.ProductCategory = "NAVIGATION";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2 1H12C12.5523 1 13 1.44772 13 2V4H1V2C1 1.44772 1.44772 1 2 1ZM1 5V12C1 12.5523 1.44772 13 2 13H12C12.5523 13 13 12.5523 13 12V5H1ZM0 2C0 0.89543 0.895431 0 2 0H12C13.1046 0 14 0.895431 14 2V12C14 13.1046 13.1046 14 12 14H2C0.89543 14 0 13.1046 0 12V2ZM9.82322 1.82322C9.92085 1.72559 10.0791 1.72559 10.1768 1.82322L10.5 2.14645L10.8232 1.82322C10.9209 1.72559 11.0791 1.72559 11.1768 1.82322C11.2744 1.92085 11.2744 2.07915 11.1768 2.17678L10.8536 2.5L11.1768 2.82322C11.2744 2.92085 11.2744 3.07915 11.1768 3.17678C11.0791 3.27441 10.9209 3.27441 10.8232 3.17678L10.5 2.85355L10.1768 3.17678C10.0791 3.27441 9.92085 3.27441 9.82322 3.17678C9.72559 3.07915 9.72559 2.92085 9.82322 2.82322L10.1464 2.5L9.82322 2.17678C9.72559 2.07915 9.72559 1.92085 9.82322 1.82322ZM5 10C5 9.44771 5.44772 9 6 9H7C7.55228 9 8 9.44771 8 10C8 10.5523 7.55228 11 7 11H6C5.44772 11 5 10.5523 5 10ZM10 9C9.44772 9 9 9.44771 9 10C9 10.5523 9.44771 11 10 11H11C11.5523 11 12 10.5523 12 10C12 9.44771 11.5523 9 11 9H10Z"),
                Width = 14,
                Height = 14,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Navigation.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The WPF Wizard control provides an interface to create a multi-step wizard that guides users to complete a specific process such as installation or updates.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Wizard Control.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Title = "Getting Started", GroupName = "Wizard Control", DemoViewType = typeof(WizardDemosView), DemoLauchMode = DemoLauchMode.Window, ThemeMode = ThemeMode.Inherit, Description = "This sample showcases the different wizard pages and layout options in Wizard control." });
        }
    }

    /// <summary>
    /// Class represents the product demos
    /// </summary>
    public class TreeNavigatorProductDemo : ProductDemo
    {
        /// <summary>
        /// Initializes the new instances of <see cref="TreeNavigatorProductDemo"/> class.
        /// </summary>
        public TreeNavigatorProductDemo()
        {
            this.Product = "Tree Navigator";
            this.ProductCategory = "NAVIGATION";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M11 1H2C1.44772 1 1 1.44772 1 2V12C1 12.5523 1.44772 13 2 13H11C11.5523 13 12 12.5523 12 12V2C12 1.44772 11.5523 1 11 1ZM2 0C0.895431 0 0 0.89543 0 2V12C0 13.1046 0.89543 14 2 14H11C12.1046 14 13 13.1046 13 12V2C13 0.895431 12.1046 0 11 0H2ZM2.5 3.5C2.5 3.22386 2.72386 3 3 3H7C7.27614 3 7.5 3.22386 7.5 3.5C7.5 3.77614 7.27614 4 7 4H3C2.72386 4 2.5 3.77614 2.5 3.5ZM3 6C2.72386 6 2.5 6.22386 2.5 6.5C2.5 6.77614 2.72386 7 3 7H7C7.27614 7 7.5 6.77614 7.5 6.5C7.5 6.22386 7.27614 6 7 6H3ZM2.5 9.5C2.5 9.22386 2.72386 9 3 9H7C7.27614 9 7.5 9.22386 7.5 9.5C7.5 9.77614 7.27614 10 7 10H3C2.72386 10 2.5 9.77614 2.5 9.5ZM10.836 5.36332C10.9011 5.41759 11 5.37128 11 5.2865V3.2135C11 3.12872 10.9011 3.0824 10.836 3.13668L9.59219 4.17318C9.54421 4.21316 9.54421 4.28684 9.59219 4.32682L10.836 5.36332Z"),
                Width = 13,
                Height = 14,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Navigation.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The WPF Tree Navigator control provides a unique interface that can expand a tree structure in-place without taking up more space on the screen.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Tree Navigator.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Title = "Getting Started", GroupName = "Tree Navigator", DemoViewType = typeof(TreeNavigatorDemosView), ThemeMode = ThemeMode.Inherit, Description = "This sample showcases the different navigation modes supported in the TreeNavigator for hierarchical data." });
         }
    }

   

    /// <summary>
    /// Class represents the product demos
    /// </summary>
    public class HierarchicalNavigatorProductDemo : ProductDemo
    {
        /// <summary>
        /// Initializes the new instances of <see cref="HierarchicalNavigatorProductDemo"/> class.
        /// </summary>
        public HierarchicalNavigatorProductDemo()
        {
            this.Product = "Hierarchical Navigator";
            this.ProductCategory = "NAVIGATION";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2 1H12C12.5523 1 13 1.44772 13 2V4H1V2C1 1.44772 1.44772 1 2 1ZM1 5V12C1 12.5523 1.44772 13 2 13H12C12.5523 13 13 12.5523 13 12V5H1ZM0 2C0 0.89543 0.895431 0 2 0H12C13.1046 0 14 0.895431 14 2V12C14 13.1046 13.1046 14 12 14H2C0.89543 14 0 13.1046 0 12V2ZM2.5 2.5C2.5 2.22386 2.72386 2 3 2H4C4.27614 2 4.5 2.22386 4.5 2.5C4.5 2.77614 4.27614 3 4 3H3C2.72386 3 2.5 2.77614 2.5 2.5ZM7 2C6.72386 2 6.5 2.22386 6.5 2.5C6.5 2.77614 6.72386 3 7 3H8C8.27614 3 8.5 2.77614 8.5 2.5C8.5 2.22386 8.27614 2 8 2H7ZM5 2.1618C5 2.08747 5.07823 2.03912 5.14472 2.07236L5.82111 2.41056C5.89482 2.44741 5.89482 2.55259 5.82111 2.58944L5.14472 2.92764C5.07823 2.96088 5 2.91253 5 2.8382V2.1618ZM11.8293 2.17071C11.8923 2.10771 11.8477 2 11.7586 2H10.2414C10.1523 2 10.1077 2.10771 10.1707 2.17071L10.9293 2.92929C10.9683 2.96834 11.0317 2.96834 11.0707 2.92929L11.8293 2.17071ZM2 7.5C2 7.22386 2.22386 7 2.5 7H10.5C10.7761 7 11 7.22386 11 7.5C11 7.77614 10.7761 8 10.5 8H2.5C2.22386 8 2 7.77614 2 7.5ZM2.5 10C2.22386 10 2 10.2239 2 10.5C2 10.7761 2.22386 11 2.5 11H7.5C7.77614 11 8 10.7761 8 10.5C8 10.2239 7.77614 10 7.5 10H2.5Z"),
                Width = 14,
                Height = 14,
            };
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Navigation.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The WPF Hierarchical Navigator control provides a bread-crumb interface, that allows users to keep track of their location while navigating the application along with their history.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Hierarchical Navigator.png", UriKind.RelativeOrAbsolute));
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Title = "Getting Started", GroupName = "Hierarchical Navigator", DemoViewType = typeof(HierarchyNavigatorDemosView),ThemeMode=ThemeMode.Inherit,Description= "This sample showcases the features such as edit mode, history and the progress bar supported by Hierarchy Navigator." });
         }
    }

    /// <summary>
    /// Class represents the product demos
    /// </summary>
    public class AccordionProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes the new instances of <see cref="AccordionProductDemos"/> class.
        /// </summary>
        public AccordionProductDemos()
        {
            this.Product = "Accordion";
            this.ProductCategory = "NAVIGATION";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M13.5 7H2.5C1.12 7 0 5.88 0 4.5V2.5C0 1.12 1.12 0 2.5 0H13.5C14.88 0 16 1.12 16 2.5V4.5C16 5.88 14.88 7 13.5 7ZM2.5 1C1.67 1 1 1.67 1 2.5V4.5C1 5.33 1.67 6 2.5 6H13.5C14.33 6 15 5.33 15 4.5V2.5C15 1.67 14.33 1 13.5 1H2.5ZM3.5 4H8.5C8.78 4 9 3.78 9 3.5C9 3.22 8.78 3 8.5 3H3.5C3.22 3 3 3.22 3 3.5C3 3.78 3.22 4 3.5 4ZM3.5 13H8.5C8.78 13 9 12.78 9 12.5C9 12.22 8.78 12 8.5 12H3.5C3.22 12 3 12.22 3 12.5C3 12.78 3.22 13 3.5 13ZM2.5 16H13.5C14.88 16 16 14.88 16 13.5V11.5C16 10.12 14.88 9 13.5 9H2.5C1.12 9 0 10.12 0 11.5V13.5C0 14.88 1.12 16 2.5 16ZM1 11.5C1 10.67 1.67 10 2.5 10H13.5C14.33 10 15 10.67 15 11.5V13.5C15 14.33 14.33 15 13.5 15H2.5C1.67 15 1 14.33 1 13.5V11.5ZM12.7929 3C13.2383 3 13.4614 3.53857 13.1464 3.85355L12.3536 4.64645C12.1583 4.84171 11.8417 4.84171 11.6464 4.64645L10.8536 3.85355C10.5386 3.53857 10.7617 3 11.2071 3H12.7929ZM10.8536 12.1464C10.5386 12.4614 10.7617 13 11.2071 13H12.7929C13.2383 13 13.4614 12.4614 13.1464 12.1464L12.3536 11.3536C12.1583 11.1583 11.8417 11.1583 11.6464 11.3536L10.8536 12.1464Z"),
                Width = 16,
                Height = 16,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Navigation.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The WPF Accordion control organizes content into multiple collapsible sections that can be expanded on demand.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Accordion.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Title = "Getting Started", GroupName = "Accordion", DemoViewType = typeof(GettingStarted), ThemeMode = ThemeMode.Inherit, Description = "This sample showcases the basic features and various selection mode options in Accordion." });
            this.Demos.Add(new DemoInfo() { SampleName = "DataBinding", Title = "DataBinding", GroupName = "Accordion", DemoViewType = typeof(DataBinding), ThemeMode = ThemeMode.Inherit, Description = "This sample showcases the items populated with the collection of business objects with custom item template in Accordion." });
        }
    }

    public class TabControlExtProductDemos : ProductDemo
    {
        public TabControlExtProductDemos()
        {
            this.Product = "TabControl";
            this.ProductCategory = "NAVIGATION";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2.5 10C1.12 10 0 8.88 0 7.5V6.5C0 5.12 1.12 4 2.5 4H3V1.5C3 0.67 3.67 0 4.5 0H6.5C7.33 0 8 0.67 8 1.5V4H13.5C14.88 4 16 5.12 16 6.5V7.5C16 8.88 14.88 10 13.5 10H2.5ZM2.5 5C1.67 5 1 5.67 1 6.5V7.5C1 8.33 1.67 9 2.5 9H13.5C14.33 9 15 8.33 15 7.5V6.5C15 5.67 14.33 5 13.5 5H7.5C7.22 5 7 4.78 7 4.5V1.5C7 1.22 6.78 1 6.5 1H4.5C4.22 1 4 1.22 4 1.5V4.5C4 4.78 3.78 5 3.5 5H2.5ZM10.5 3H9.5C9.22 3 9 2.78 9 2.5C9 2.22 9.22 2 9.5 2H10.5C10.78 2 11 2.22 11 2.5C11 2.78 10.78 3 10.5 3ZM12.5 3H13.5C13.78 3 14 2.78 14 2.5C14 2.22 13.78 2 13.5 2H12.5C12.22 2 12 2.22 12 2.5C12 2.78 12.22 3 12.5 3Z"),
                Width = 16,
                Height = 10,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Navigation.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The TabControl provides an efficient interface for displaying multiple tabs and helps arrange content in a compact and organized form in less space. ";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/TabControl.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description= "This sample showcases the basic features of TabControlExt Control such as Positions of the TabStrip, Close button customization, Drag and Drop and Drag marker customization, Pin and Unpin tabs", GroupName = "TabControlExt", DemoViewType = typeof(TabControlExtDemosView)
                                  , ThemeMode = ThemeMode.Default });
            this.Demos.Add(new DemoInfo() { SampleName = "Lazy Loading", Description= "This sample showcases the basic features of TabControl such as On demand loading, Loading huge tab items in very short time", GroupName = "TabControlExt", DemoViewType = typeof(LazyLoadingDemosView) });
            this.Demos.Add(new DemoInfo() { SampleName = "Multiline TabItem", Description= "This sample showcases the ItemLayout property of the Tabcontrol", GroupName = "TabControlExt", DemoViewType = typeof(MultilineTabItemsDemosView) });
            this.Demos.Add(new DemoInfo() { SampleName = "Auto Scroll", Description = "This sample showcases the TabControl's Auto Scroll property", GroupName = "TabControlExt", DemoViewType = typeof(AutoScrollDemosView)});
        }
    }

    /// <summary>
    /// Class represents the product demos
    /// </summary>
    public class ToolBarProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes the new instances of <see cref="ToolBarProductDemos"/> class.
        /// </summary>
        public ToolBarProductDemos()
        {
            this.Product = "Tool Bar";
            this.ProductCategory = "MENUS AND BARS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M14 1H2C1.44772 1 1 1.44772 1 2V10C1 10.5523 1.44772 11 2 11H14C14.5523 11 15 10.5523 15 10V2C15 1.44772 14.5523 1 14 1ZM2 0C0.895431 0 0 0.895431 0 2V10C0 11.1046 0.895431 12 2 12H14C15.1046 12 16 11.1046 16 10V2C16 0.895431 15.1046 0 14 0H2ZM2 3.3C2 3.13431 2.13431 3 2.3 3H4.7C4.86569 3 5 3.13431 5 3.3V4.7C5 4.86569 4.86569 5 4.7 5H2.3C2.13431 5 2 4.86569 2 4.7V3.3ZM2.3 7C2.13431 7 2 7.13431 2 7.3V8.7C2 8.86569 2.13431 9 2.3 9H4.7C4.86569 9 5 8.86569 5 8.7V7.3C5 7.13431 4.86569 7 4.7 7H2.3ZM6 3.3C6 3.13431 6.13431 3 6.3 3H9.7C9.86569 3 10 3.13431 10 3.3V4.7C10 4.86569 9.86569 5 9.7 5H6.3C6.13431 5 6 4.86569 6 4.7V3.3ZM6.3 7C6.13431 7 6 7.13431 6 7.3V8.7C6 8.86569 6.13431 9 6.3 9H9.7C9.86569 9 10 8.86569 10 8.7V7.3C10 7.13431 9.86569 7 9.7 7H6.3ZM11 3.3C11 3.13431 11.1343 3 11.3 3H13.7C13.8657 3 14 3.13431 14 3.3V4.7C14 4.86569 13.8657 5 13.7 5H11.3C11.1343 5 11 4.86569 11 4.7V3.3ZM11.3 7C11.1343 7 11 7.13431 11 7.3V8.7C11 8.86569 11.1343 9 11.3 9H13.7C13.8657 9 14 8.86569 14 8.7V7.3C14 7.13431 13.8657 7 13.7 7H11.3Z"),
                Width = 16,
                Height = 12,
            };
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/MenusandBars.png", UriKind.RelativeOrAbsolute));
            this.Demos = new List<DemoInfo>();
            this.ControlDescription = "The WPF ToolBar control is used to display shortcut commands and place them conveniently anywhere within the application for better access.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Tool Bar.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "Tool Bar", DemoViewType = typeof(ToolBarDemosView), Description = "This sample showcases the basic features of customizing and positioning of ToolBarTrayAdv in ToolBarAdv control.", ThemeMode = ThemeMode.Inherit });
        }
    }

    /// <summary>
    /// Class represents the product demos
    /// </summary>
    public class TaskBarProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes the new instances of <see cref="TaskBarProductDemos"/> class.
        /// </summary>
        public TaskBarProductDemos()
        {
            this.Product = "Task Bar";
            this.ProductCategory = "MENUS AND BARS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2 1H12C12.5523 1 13 1.44772 13 2V3C13 3.55228 12.5523 4 12 4H2C1.44772 4 1 3.55228 1 3V2C1 1.44772 1.44772 1 2 1ZM0 2C0 0.89543 0.895431 0 2 0H12C13.1046 0 14 0.895431 14 2V3C14 4.10457 13.1046 5 12 5H2C0.89543 5 0 4.10457 0 3V2ZM1 8C1 7.44772 1.44772 7 2 7H12C12.5523 7 13 7.44772 13 8V10C13 10.5523 12.5523 11 12 11H2C1.44772 11 1 10.5523 1 10V8ZM0 8C0 6.89543 0.895431 6 2 6H12C13.1046 6 14 6.89543 14 8V10C14 11.1046 13.1046 12 12 12H2C0.89543 12 0 11.1046 0 10V8ZM2.5 2.5C2.5 2.22386 2.72386 2 3 2H5C5.27614 2 5.5 2.22386 5.5 2.5C5.5 2.77614 5.27614 3 5 3H3C2.72386 3 2.5 2.77614 2.5 2.5ZM7 2C6.72386 2 6.5 2.22386 6.5 2.5C6.5 2.77614 6.72386 3 7 3H9C9.27614 3 9.5 2.77614 9.5 2.5C9.5 2.22386 9.27614 2 9 2H7Z"),
                Width = 14,
                Height = 12,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/MenusandBars.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The WPF TaskBar control is used to add Windows-style collapsible, grouped, and command item lists to your applications.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Task Bar.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Title = "Getting Started", GroupName = "Task Bar", DemoViewType = typeof(TaskBarDemosView), ThemeMode = ThemeMode.Inherit, Description = "This sample showcases the basic functionalities of Taskbar control to group multiple items in desired layout with headers." });
        }
    }


    /// <summary>
    /// Class represents the product demos
    /// </summary>
    public class MenuProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes the new instances of <see cref="MenuProductDemos"/> class.
        /// </summary>
        public MenuProductDemos()
        {
            this.Product = "Menu";
            this.ProductCategory = "MENUS AND BARS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M7 1H12C12.5523 1 13 1.44772 13 2V5C13 5.55228 12.5523 6 12 6H7V1ZM0 2C0 0.89543 0.895431 0 2 0H12C13.1046 0 14 0.895431 14 2V5C14 6.10457 13.1046 7 12 7H7V12C7 13.1046 6.10457 14 5 14H2C0.89543 14 0 13.1046 0 12V2ZM6 7H1V12C1 12.5523 1.44772 13 2 13H5C5.55228 13 6 12.5523 6 12V7ZM8.5 3.5C8.5 3.22386 8.72386 3 9 3L11 3C11.2761 3 11.5 3.22386 11.5 3.5C11.5 3.77614 11.2761 4 11 4H9C8.72386 4 8.5 3.77614 8.5 3.5ZM3 8C2.72386 8 2.5 8.22386 2.5 8.5C2.5 8.77614 2.72386 9 3 9H4C4.27614 9 4.5 8.77614 4.5 8.5C4.5 8.22386 4.27614 8 4 8H3ZM2.5 11.5C2.5 11.2239 2.72386 11 3 11H4C4.27614 11 4.5 11.2239 4.5 11.5C4.5 11.7761 4.27614 12 4 12H3C2.72386 12 2.5 11.7761 2.5 11.5ZM2.5 3.5C2.5 3.22386 2.72386 3 3 3L5 3C5.27614 3 5.5 3.22386 5.5 3.5C5.5 3.77614 5.27614 4 5 4H3C2.72386 4 2.5 3.77614 2.5 3.5Z"),
                Width = 14,
                Height = 14,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/MenusandBars.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The WPF Menu control allows users to organize items associated with commands and events in a hierarchical structure.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Menu.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "Menu", DemoViewType = typeof(MenuGettingStartedDemosView), Description = "This sample showcases the various animation, orientation and expanding mode features in MenuAdv control.", ThemeMode = ThemeMode.Default });
            this.Demos.Add(new DemoInfo() { SampleName = "Menu Merging", GroupName = "Menu", DemoViewType = typeof(MenuMerging), DemoLauchMode = DemoLauchMode.Window, Description = "This sample showcases the merging support in MenuAdv control. It includes the ability to merge the menu items within the MenuAdv control.", ThemeMode = ThemeMode.Default });
        }
    }

    /// <summary>
    /// Class represents the product demos
    /// </summary>
    public class GroupBarProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes the new instances of <see cref="GroupBarProductDemos"/> class.
        /// </summary>
        public GroupBarProductDemos()
        {
            this.Product = "Group Bar";
            this.ProductCategory = "MENUS AND BARS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M12 1H2C1.44772 1 1 1.44772 1 2V9H13V2C13 1.44772 12.5523 1 12 1ZM1 12V10H13V12C13 12.5523 12.5523 13 12 13H2C1.44772 13 1 12.5523 1 12ZM2 0C0.895431 0 0 0.89543 0 2V12C0 13.1046 0.89543 14 2 14H12C13.1046 14 14 13.1046 14 12V2C14 0.895431 13.1046 0 12 0H2ZM6.5 10.5C5.94772 10.5 5.5 10.9477 5.5 11.5C5.5 12.0523 5.94772 12.5 6.5 12.5H7.5C8.05228 12.5 8.5 12.0523 8.5 11.5C8.5 10.9477 8.05228 10.5 7.5 10.5H6.5ZM2.5 3.5C2.5 3.22386 2.72386 3 3 3L11 3C11.2761 3 11.5 3.22386 11.5 3.5C11.5 3.77614 11.2761 4 11 4L3 4C2.72386 4 2.5 3.77614 2.5 3.5ZM3 6C2.72386 6 2.5 6.22386 2.5 6.5C2.5 6.77614 2.72386 7 3 7L7 7C7.27614 7 7.5 6.77614 7.5 6.5C7.5 6.22386 7.27614 6 7 6L3 6Z"),
                Width = 14,
                Height = 14,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/MenusandBars.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The WPF GroupBar provides a navigation UI similar to Microsoft Outlook with support to expand and collapse a view using its header.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Group Bar.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Title = "Getting Started", GroupName = "Group Bar", DemoViewType = typeof(GroupBarGettingStarted), ThemeMode = ThemeMode.Inherit, Description = "This sample showcases the basic features and the various visual modes in GroupBar control." });
            this.Demos.Add(new DemoInfo() { SampleName = "DataBinding", Title = "DataBinding", GroupName = "Group Bar", DemoViewType = typeof(GroupBarDataBinding), ThemeMode = ThemeMode.Inherit, Description = "This sample showcases the data binding support where items are populated with the collection of business objects in GroupBar control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Drag and Drop", Title = "Drag and Drop", GroupName = "Group Bar", DemoViewType = typeof(DragDropView), ThemeMode = ThemeMode.Inherit, Description = "This sample showcases the Drag and Drop support between two GroupBar's along with the orientation and visual modes." });
            this.Demos.Add(new DemoInfo() { SampleName = "GroupBar Outlook", Title = "GroupBar Outlook", GroupName = "Group Bar", DemoViewType = typeof(GroupBarOutlook), Description = "This sample showcases the built-in style of GroupBar control that looks like the latest Microsoft Outlook." });
        }
    }

    /// <summary>
    /// Class represents the product demos
    /// </summary>
    public class RadialMenuProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes the new instances of <see cref="RadialMenuProductDemos"/> class.
        /// </summary>
        public RadialMenuProductDemos()
        {
            this.Product = "Radial Menu";
            this.ProductCategory = "MENUS AND BARS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M15 8C15 11.866 11.866 15 8 15C4.13401 15 1 11.866 1 8C1 4.13401 4.13401 1 8 1C11.866 1 15 4.13401 15 8ZM16 8C16 12.4183 12.4183 16 8 16C3.58172 16 0 12.4183 0 8C0 3.58172 3.58172 0 8 0C12.4183 0 16 3.58172 16 8ZM8 10C9.10457 10 10 9.10457 10 8C10 6.89543 9.10457 6 8 6C6.89543 6 6 6.89543 6 8C6 9.10457 6.89543 10 8 10ZM13.68 7.76L12.48 6.86C12.2822 6.71167 12 6.85279 12 7.1V8.9C12 9.14721 12.2822 9.28833 12.48 9.14L13.68 8.24C13.84 8.12 13.84 7.88 13.68 7.76ZM3.52 6.86L2.32 7.76C2.16 7.88 2.16 8.12 2.32 8.24L3.52 9.14C3.71777 9.28833 4 9.14721 4 8.9V7.1C4 6.85279 3.71777 6.71167 3.52 6.86ZM7.76 2.32L6.86 3.52C6.71167 3.71777 6.85279 4 7.1 4H8.9C9.14721 4 9.28833 3.71777 9.14 3.52L8.24 2.32C8.12 2.16 7.88 2.16 7.76 2.32ZM6.86 12.48L7.76 13.68C7.88 13.84 8.12 13.84 8.24 13.68L9.14 12.48C9.28833 12.2822 9.14721 12 8.9 12H7.1C6.85279 12 6.71167 12.2822 6.86 12.48Z"),
                Width = 16,
                Height = 16,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/MenusandBars.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The Radial Menu displays a hierarchical menu in a circular layout. Typically used as a context menu, it can expose more menu items in the same space than traditional menus.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Radial Menu.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "Radial Menu", Description = "This sample showcases a simple use case scenario having an editor loaded with Radial Menu with editor options loaded with the items of the Radial Menu. ", DemoViewType = typeof(RadialMenuDemosView) });
        }
    }
}
