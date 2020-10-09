#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using syncfusion.layoutdemos.wpf.Views.TextInputLayout;
using System.Collections.Generic;

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
            this.Demos = new List<DemoInfo>();
             this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description= "This sample demonstrates the basic functionality of text input layout control", GroupName = "TEXT INPUT LAYOUT", DemoViewType = typeof(TextInputLayoutGettingStartedDemo) });
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
            this.Demos = new List<DemoInfo>();
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
            this.Demos = new List<DemoInfo>();
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
            this.Demos = new List<DemoInfo>();
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
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started",Description= "This sample showcases the basic features of Carousel such as Data-binding, Scaling and Skewing support", GroupName = "Carousel", DemoViewType = typeof(CarouselDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Custom Path", Description= "This sample showcases the custom path support in Carousel. This custom path support helps to arrange carousel items in any form such as 3D perspective, circular, linear layouts etc", GroupName = "Carousel", DemoViewType = typeof(CarouselCusomPathDemo) });
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
            this.Demos = new List<DemoInfo>();
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
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "Chromeless Window", DemoViewType = typeof(GettingStarted), DemoLauchMode = DemoLauchMode.Window, ThemeMode=ThemeMode.Inherit, Description= "This sample showcases the basic features of ChromelessWindow such as changing its corner radius, resize border thickness, title bar height and opacity level values." });
            this.Demos.Add(new DemoInfo() { SampleName = "TitleBar Customization", GroupName = "Chromeless Window", DemoViewType = typeof(TitleBarCustomization), DemoLauchMode = DemoLauchMode.Window, ThemeMode=ThemeMode.Inherit, Description= "This sample demonstrates the ability to add controls to the title bar in the ChromelessWindow." });
        }
    }
}
