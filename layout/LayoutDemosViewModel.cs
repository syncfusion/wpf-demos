#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using syncfusion.layoutdemos.wpf.Views.TextInputLayout;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.layoutdemos.wpf
{
    /// <summary>
    /// Class represents the demos launch using DemoLauchMode.Window
    /// </summary>
    public class LayoutDemosViewModel : DemoBrowserViewModel
    {
        /// <summary>
        /// Method used to get demo details.
        /// </summary>
        /// <returns>Returns the list of product demos</returns>
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new TextInputLayoutProductDemos());
            productdemos.Add(new CardViewProductDemo());
            productdemos.Add(new CarouselProductDemos());
            productdemos.Add(new ChromelessWindowProductDemos());
            productdemos.Add(new DocumentContainerProductDemos());
            productdemos.Add(new GridSplitterProductDemos());
            productdemos.Add(new TileViewProductDemos());
            return productdemos;
        }
    }

    /// <summary>
    /// Class represents the product demo
    /// </summary>
    public class TextInputLayoutProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes the new instance of <see cref="TextInputLayoutProductDemos"/> class.
        /// </summary>
        public TextInputLayoutProductDemos()
        {
            this.Product = "TextInputLayout";
            this.ProductCategory = "LAYOUT";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2 1H14C14.5523 1 15 1.44772 15 2V5C15 5.55228 14.5523 6 14 6H2C1.44772 6 1 5.55228 1 5V2C1 1.44772 1.44772 1 2 1ZM0 2C0 0.89543 0.895431 0 2 0H14C15.1046 0 16 0.895431 16 2V5C16 6.10457 15.1046 7 14 7H2C0.895431 7 0 6.10457 0 5V2ZM2.5 3C2.22386 3 2 3.22386 2 3.5C2 3.77614 2.22386 4 2.5 4H10.5C10.7761 4 11 3.77614 11 3.5C11 3.22386 10.7761 3 10.5 3H2.5ZM7 11C7 10.4477 7.44772 10 8 10H9C9.55229 10 10 10.4477 10 11C10 11.5523 9.55228 12 9 12H8C7.44772 12 7 11.5523 7 11ZM13 10C12.4477 10 12 10.4477 12 11C12 11.5523 12.4477 12 13 12H14C14.5523 12 15 11.5523 15 11C15 10.4477 14.5523 10 14 10H13Z"),
                Width = 16,
                Height = 12,
            };

            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Layout.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The Text input layout displays a label floating above an input editor as the user types or interacts with it.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/TextInputLayout.png", UriKind.RelativeOrAbsolute));

            DemoInfo GettingStartedDemo = new DemoInfo()
            {
                SampleName = "Getting Started",

                GroupName = "TEXT INPUT LAYOUT",

                Description = "This sample demonstrates the basic functionality of text input layout control",

                DemoViewType = typeof(TextInputLayoutGettingStartedDemo),

            };

            List<Documentation> GettingStartedHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Text input layout - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/textinputlayout/getting-started")}
            };


            GettingStartedDemo.Documentations = GettingStartedHelpDocuments;
            this.Demos.Add(GettingStartedDemo);
            this.Demos.Add(new DemoInfo() { SampleName = "Smart Paste", IsAISample = true, Description = "AI-Powered smart paste in TextInputLayout control maps clipboard data for efficient form completion.", GroupName = "TEXT INPUT LAYOUT", DemoViewType = typeof(FeedbackFormSmartFill) });
        }
    }

    /// <summary>
    /// Class represents the product demo
    /// </summary>
    public class DocumentContainerProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes the new instance of <see cref="DocumentContainerProductDemos"/> class.
        /// </summary>
        public DocumentContainerProductDemos()
        {
            this.Product = "Document Container";
            this.ProductCategory = "LAYOUT";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2 1H12C12.5523 1 13 1.44772 13 2V4H1V2C1 1.44772 1.44772 1 2 1ZM0 2C0 0.89543 0.895431 0 2 0H12C13.1046 0 14 0.895431 14 2V12C14 13.1046 13.1046 14 12 14H2C0.89543 14 0 13.1046 0 12V2ZM1 5H13V12C13 12.5523 12.5523 13 12 13H2C1.44772 13 1 12.5523 1 12V5ZM9.82322 1.82322C9.92085 1.72559 10.0791 1.72559 10.1768 1.82322L10.5 2.14645L10.8232 1.82322C10.9209 1.72559 11.0791 1.72559 11.1768 1.82322C11.2744 1.92085 11.2744 2.07915 11.1768 2.17678L10.8536 2.5L11.1768 2.82322C11.2744 2.92085 11.2744 3.07915 11.1768 3.17678C11.0791 3.27441 10.9209 3.27441 10.8232 3.17678L10.5 2.85355L10.1768 3.17678C10.0791 3.27441 9.92085 3.27441 9.82322 3.17678C9.72559 3.07915 9.72559 2.92085 9.82322 2.82322L10.1464 2.5L9.82322 2.17678C9.72559 2.07915 9.72559 1.92085 9.82322 1.82322ZM2.5 7.5C2.5 7.22386 2.72386 7 3 7H11C11.2761 7 11.5 7.22386 11.5 7.5C11.5 7.77614 11.2761 8 11 8H3C2.72386 8 2.5 7.77614 2.5 7.5ZM3 10C2.72386 10 2.5 10.2239 2.5 10.5C2.5 10.7761 2.72386 11 3 11H7C7.27614 11 7.5 10.7761 7.5 10.5C7.5 10.2239 7.27614 10 7 10H3Z"),
                Width = 14,
                Height = 14,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Layout.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The DocumentContainer, provides TDI and a MDI to create document groups in your application.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Document Container.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description= "This sample showcases the basic features of the DocumentContainer Control such as MDI and TDI Modes and State persistence", GroupName = "Document Container", DemoViewType = typeof(DocumentContainerDemosView) });
            this.Demos.Add(new DemoInfo() { SampleName = "Window State Restriction", Description= "This sample demonstrates restrictions, that can be performed on window states.", GroupName = "Document Container", DemoViewType = typeof(WindowStateRestrictionDemo) });
        }
    }

    /// <summary>
    /// Class represents the product demo
    /// </summary>
    public class GridSplitterProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes the new instance of <see cref="GridSplitterProductDemos"/> class.
        /// </summary>
        public GridSplitterProductDemos()
        {
            this.Product = "Grid Splitter";
            this.ProductCategory = "LAYOUT";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M8.99979 0.5C8.99979 0.223858 8.77593 0 8.49979 0C8.22365 0 7.99979 0.223858 7.99979 0.5V6H0.5C0.223858 6 0 6.22386 0 6.5C0 6.77614 0.223858 7 0.5 7H7.99979V13.5C7.99979 13.7761 8.22365 14 8.49979 14C8.77593 14 8.99979 13.7761 8.99979 13.5V7H13.5C13.7761 7 14 6.77614 14 6.5C14 6.22386 13.7761 6 13.5 6H8.99979V0.5ZM1.99979 3C1.99979 2.44772 2.4475 2 2.99979 2H5.99979C6.55207 2 6.99979 2.44772 6.99979 3V4C6.99979 4.55228 6.55207 5 5.99979 5H2.99979C2.4475 5 1.99979 4.55228 1.99979 4V3ZM2.99979 8C2.4475 8 1.99979 8.44771 1.99979 9V12C1.99979 12.5523 2.4475 13 2.99979 13H5.99979C6.55207 13 6.99979 12.5523 6.99979 12V9C6.99979 8.44771 6.55207 8 5.99979 8H2.99979Z"),
                Width = 14,
                Height = 14,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Layout.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "GridSplitter control is a divider that helps to split the available space into rows and columns in a grid.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Grid Splitter.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description= "Essential GridSplitter control splits the control into rows or columns that redistribute the space between the rows and columns.", GroupName = "Grid Splitter", DemoViewType = typeof(GridSplitterDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Customization", Description = "This sample demonstrates custom look and feel for Expander and Gripper in SfGridSplitter control.", GroupName = "Grid Splitter", DemoViewType = typeof(SplitterCustomizationDemo) });
        }
    }

    /// <summary>
    /// Class represents the product demo
    /// </summary>
    public class CardViewProductDemo : ProductDemo
    {
        /// <summary>
        /// Initializes the new instance of <see cref="LayoutProductDemos"/> class.
        /// </summary>
        public CardViewProductDemo()
        {
            this.Product = "Card View";
            this.ProductCategory = "LAYOUT";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2 1H14C14.5523 1 15 1.44772 15 2V9C15 9.55228 14.5523 10 14 10H2C1.44772 10 1 9.55228 1 9V2C1 1.44772 1.44772 1 2 1ZM0 2C0 0.895431 0.895431 0 2 0H14C15.1046 0 16 0.895431 16 2V9C16 10.1046 15.1046 11 14 11H2C0.895431 11 0 10.1046 0 9V2ZM3.5 3C2.67157 3 2 3.67157 2 4.5V6.5C2 7.32843 2.67157 8 3.5 8H5.5C6.32843 8 7 7.32843 7 6.5V4.5C7 3.67157 6.32843 3 5.5 3H3.5ZM3 4.5C3 4.22386 3.22386 4 3.5 4H5.5C5.77614 4 6 4.22386 6 4.5V6.5C6 6.77614 5.77614 7 5.5 7H3.5C3.22386 7 3 6.77614 3 6.5V4.5ZM8.5 3.5C8.5 3.22386 8.72386 3 9 3H13C13.2761 3 13.5 3.22386 13.5 3.5C13.5 3.77614 13.2761 4 13 4H9C8.72386 4 8.5 3.77614 8.5 3.5ZM9 6C8.72386 6 8.5 6.22386 8.5 6.5C8.5 6.77614 8.72386 7 9 7H12C12.2761 7 12.5 6.77614 12.5 6.5C12.5 6.22386 12.2761 6 12 6H9Z"),
                Width = 16,
                Height = 11,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Layout.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The Card View control is a panel that helps organize a list of items in cards. It supports grouping, sorting, filtering, and editing options.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Card View.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description= "This sample showcases the basic features of CardView Control such as Grouping, Filtering and Sorting options", GroupName = "Card View", DemoViewType = typeof(CardViewDemo) });
        }
    }

    public class CarouselProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes the new instance of <see cref="CarouselProductDemos"/> class.
        /// </summary>
        public CarouselProductDemos()
        {
            this.Product = "Carousel";
            this.ProductCategory = "LAYOUT";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M4 2H12C12.5523 2 13 2.44772 13 3V9.0985C12.999 8.37163 12.2472 7.88843 11.5854 8.18991L9.8037 9.00162C9.26943 9.24502 8.6414 8.97795 8.44608 8.42428L7.82742 6.67056C7.56845 5.93646 6.60701 5.7667 6.11229 6.36771L3 10.1488V3C3 2.44772 3.44772 2 4 2ZM2 3C2 1.89543 2.89543 1 4 1H12C13.1046 1 14 1.89543 14 3V11C14 12.1046 13.1046 13 12 13H4C2.89543 13 2 12.1046 2 11V3ZM1 4.5C1 4.22386 0.776142 4 0.5 4C0.223858 4 0 4.22386 0 4.5V9.5C0 9.77614 0.223857 10 0.5 10C0.776142 10 1 9.77614 1 9.5L1 4.5ZM15.5 4C15.7761 4 16 4.22386 16 4.5V9.5C16 9.77614 15.7761 10 15.5 10C15.2239 10 15 9.77614 15 9.5V4.5C15 4.22386 15.2239 4 15.5 4ZM11 4C11 4.55228 10.5523 5 10 5C9.44771 5 9 4.55228 9 4C9 3.44772 9.44771 3 10 3C10.5523 3 11 3.44772 11 4ZM4 16C4.55228 16 5 15.5523 5 15C5 14.4477 4.55228 14 4 14C3.44772 14 3 14.4477 3 15C3 15.5523 3.44772 16 4 16ZM9 15C9 15.5523 8.55228 16 8 16C7.44772 16 7 15.5523 7 15C7 14.4477 7.44772 14 8 14C8.55228 14 9 14.4477 9 15ZM12 16C12.5523 16 13 15.5523 13 15C13 14.4477 12.5523 14 12 14C11.4477 14 11 14.4477 11 15C11 15.5523 11.4477 16 12 16Z"),
                Width = 16,
                Height = 16,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Layout.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The Carousel provides navigation through a list of items with smooth animations. It allows arranging items in linear, and circular layouts.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Carousel.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started",Description= "This sample showcases the basic features of Carousel such as Data-binding, Scaling and Skewing support", GroupName = "Carousel", ShowBusyIndicator=true , DemoViewType = typeof(CarouselDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Custom Path", Description= "This sample showcases the custom path support in Carousel. This custom path support helps to arrange carousel items in any form such as 3D perspective, circular, linear layouts etc", GroupName = "Carousel", DemoViewType = typeof(CarouselCusomPathDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Navigation", Description= "This sample showcases the navigation support in Carousel. This navigation support helps to select any carousel item.", GroupName = "Carousel", DemoViewType = typeof(CarouselNavigationDemo) });
        }
    }

    public class TileViewProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes the new instance of <see cref="TileViewProductDemos"/> class.
        /// </summary>
        public TileViewProductDemos()
        {
            this.Product = "Tile View";
            this.ProductCategory = "LAYOUT";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2 1H7C7.55228 1 8 1.44772 8 2V4C8 4.55228 7.55228 5 7 5H2C1.44772 5 1 4.55228 1 4V2C1 1.44772 1.44772 1 2 1ZM0 2C0 0.89543 0.895431 0 2 0H7C8.10457 0 9 0.895431 9 2V4C9 5.10457 8.10457 6 7 6H2C0.89543 6 0 5.10457 0 4V2ZM9 8H14C14.5523 8 15 8.44772 15 9V11C15 11.5523 14.5523 12 14 12H9C8.44772 12 8 11.5523 8 11V9C8 8.44772 8.44771 8 9 8ZM7 9C7 7.89543 7.89543 7 9 7H14C15.1046 7 16 7.89543 16 9V11C16 12.1046 15.1046 13 14 13H9C7.89543 13 7 12.1046 7 11V9ZM14 1H12C11.4477 1 11 1.44772 11 2V4C11 4.55228 11.4477 5 12 5H14C14.5523 5 15 4.55228 15 4V2C15 1.44772 14.5523 1 14 1ZM12 0C10.8954 0 10 0.89543 10 2V4C10 5.10457 10.8954 6 12 6H14C15.1046 6 16 5.10457 16 4V2C16 0.895431 15.1046 0 14 0H12ZM2 8H4C4.55228 8 5 8.44772 5 9V11C5 11.5523 4.55228 12 4 12H2C1.44772 12 1 11.5523 1 11V9C1 8.44772 1.44772 8 2 8ZM0 9C0 7.89543 0.895431 7 2 7H4C5.10457 7 6 7.89543 6 9V11C6 12.1046 5.10457 13 4 13H2C0.89543 13 0 12.1046 0 11V9Z"),
                Width = 16,
                Height = 13,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Layout.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The Tile View control displays items as tiles that can be minimized and maximized. It supports virtualization, minimize and maximize tile, etc.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Tile View.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", ThemeMode = ThemeMode.Default, Description= "This sample showcases the basic features of TileView such as Dragging, Maximization and Minimization", GroupName = "TileView", DemoViewType = typeof(TileViewDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "UI Virtualization",Description= "This sample showcases the UI virtualization capability of the tile view control", GroupName = "TileView", DemoViewType = typeof(TileViewVirtualizationDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Data Binding", Description= "This sample showcases the Observable binding capability of TileView Control", GroupName = "TileView", DemoViewType = typeof(DataBindingDemo) });
        }
    }

    public class ChromelessWindowProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes the new instance of <see cref="ChromelessWindowProductDemos"/> class.
        /// </summary>
        public ChromelessWindowProductDemos()
        {
            this.Product = "Chromeless Window";
            this.ProductCategory = "LAYOUT";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2 1H12C12.5523 1 13 1.44772 13 2V4H1V2C1 1.44772 1.44772 1 2 1ZM1 5V12C1 12.5523 1.44772 13 2 13H12C12.5523 13 13 12.5523 13 12V5H1ZM0 2C0 0.89543 0.895431 0 2 0H12C13.1046 0 14 0.895431 14 2V12C14 13.1046 13.1046 14 12 14H2C0.89543 14 0 13.1046 0 12V2ZM9.82322 1.82322C9.92085 1.72559 10.0791 1.72559 10.1768 1.82322L10.5 2.14645L10.8232 1.82322C10.9209 1.72559 11.0791 1.72559 11.1768 1.82322C11.2744 1.92085 11.2744 2.07915 11.1768 2.17678L10.8536 2.5L11.1768 2.82322C11.2744 2.92085 11.2744 3.07915 11.1768 3.17678C11.0791 3.27441 10.9209 3.27441 10.8232 3.17678L10.5 2.85355L10.1768 3.17678C10.0791 3.27441 9.92085 3.27441 9.82322 3.17678C9.72559 3.07915 9.72559 2.92085 9.82322 2.82322L10.1464 2.5L9.82322 2.17678C9.72559 2.07915 9.72559 1.92085 9.82322 1.82322Z"),
                Width = 14,
                Height = 14,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Layout.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The WPF ChromelessWindow is used to create a customizable window for the end user’s applications.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Chromeless Window.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "Chromeless Window", DemoViewType = typeof(GettingStarted), DemoLauchMode = DemoLauchMode.Window, ThemeMode=ThemeMode.Inherit, Description= "This sample showcases the basic features of ChromelessWindow such as changing its corner radius, resize border thickness, title bar height and opacity level values." });
            this.Demos.Add(new DemoInfo() { SampleName = "TitleBar Customization", GroupName = "Chromeless Window", DemoViewType = typeof(TitleBarCustomization), DemoLauchMode = DemoLauchMode.Window, ThemeMode=ThemeMode.Inherit, Description= "This sample demonstrates the ability to add controls to the title bar in the ChromelessWindow." });
        }
    }
}
