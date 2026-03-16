#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
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

namespace syncfusion.ribbondemos.wpf
{
    public class RibbonDemosViewModel : DemoBrowserViewModel
    {

        /// <summary>
        /// Maintains the list of products.
        /// </summary>
        /// <returns>Returns the list of products demos.</returns>
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new RibbonProductDemos());
            return productdemos;
        }
    }

    /// <summary>
    /// Class represents the product demos
    /// </summary>
    public class RibbonProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes the new instances of <see cref="RibbonProductDemos"/> class.
        /// </summary>
        public RibbonProductDemos()
        {
            this.Product = "Ribbon";
            this.ProductCategory = "MENUS AND BARS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2 1H14C14.5523 1 15 1.44772 15 2V5H1V2C1 1.44772 1.44772 1 2 1ZM1 6V12C1 12.5523 1.44772 13 2 13H14C14.5523 13 15 12.5523 15 12V6H1ZM0 2C0 0.89543 0.895431 0 2 0H14C15.1046 0 16 0.895431 16 2V12C16 13.1046 15.1046 14 14 14H2C0.895431 14 0 13.1046 0 12V2ZM6 3.5C6 3.77614 6.22386 4 6.5 4C6.77614 4 7 3.77614 7 3.5V2.5C7 2.22386 6.77614 2 6.5 2C6.22386 2 6 2.22386 6 2.5V3.5ZM3 2.5C2.72386 2.5 2.5 2.72386 2.5 3C2.5 3.27614 2.72386 3.5 3 3.5H4C4.27614 3.5 4.5 3.27614 4.5 3C4.5 2.72386 4.27614 2.5 4 2.5H3ZM3.5 7.5C3.5 7.22386 3.72386 7 4 7L12 7C12.2761 7 12.5 7.22386 12.5 7.5C12.5 7.77614 12.2761 8 12 8L4 8C3.72386 8 3.5 7.77614 3.5 7.5ZM4 10C3.72386 10 3.5 10.2239 3.5 10.5C3.5 10.7761 3.72386 11 4 11H8C8.27614 11 8.5 10.7761 8.5 10.5C8.5 10.2239 8.27614 10 8 10H4ZM8.5 3C8.5 2.72386 8.72386 2.5 9 2.5H10C10.2761 2.5 10.5 2.72386 10.5 3C10.5 3.27614 10.2761 3.5 10 3.5H9C8.72386 3.5 8.5 3.27614 8.5 3ZM13.5 4C13.2239 4 13 3.77614 13 3.5V2.5C13 2.22386 13.2239 2 13.5 2C13.7761 2 14 2.22386 14 2.5V3.5C14 3.77614 13.7761 4 13.5 4Z"),
                Width = 16,
                Height = 14,
            };
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/MenusandBars.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The Ribbon control accommodates all the tools required for an application in a single, easy-to-navigate user interface similar to Microsoft Office.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Ribbon.png", UriKind.RelativeOrAbsolute));
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "Getting Started",ThemeMode=ThemeMode.Inherit, DemoViewType = typeof(GettingStarted),Title="Getting Started", DemoLauchMode = DemoLauchMode.Default, Description = "This sample showcases basic Ribbon and its functionalities along with auto arranging of items while resizing the Window." });
            this.Demos.Add(new DemoInfo() { SampleName = "Simplified Ribbon", GroupName = "Getting Started", ThemeMode =ThemeMode.Inherit,DemoViewType = typeof(SimplifiedRibbon), DemoLauchMode = DemoLauchMode.Window, Title = "Simplified Ribbon", Description = "This sample showcases the simplified ribbon support which allows to collapse the ribbon bar in a single line interface, allowing more screen space for compact viewing of the content." });
            this.Demos.Add(new DemoInfo() { SampleName = "Backstage", GroupName = "Getting Started",ThemeMode=ThemeMode.Inherit, DemoViewType = typeof(Backstage), DemoLauchMode = DemoLauchMode.Window ,Title="Backstage",Description= "This sample showcases the functionalities of backstage option in Ribbon control and events associated with it." });
            this.Demos.Add(new DemoInfo() { SampleName = "Application Menu", GroupName = "Getting Started", ThemeMode = ThemeMode.Inherit, DemoViewType = typeof(ApplicationMenu), Title = "Application Menu", DemoLauchMode = DemoLauchMode.Window, Description = "This samples showcases the application menu support in Ribbon control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Menu Merging", GroupName = "Menu Merging",ThemeMode=ThemeMode.Inherit, DemoViewType = typeof(MenuMerging), DemoLauchMode = DemoLauchMode.Window,Title="Menu Merging",Description= "This sample showcases the merging support for Ribbon items. It includes the ability to merge the content of RibbonTab and RibbonBar from a child to parent Ribbon." });
            this.Demos.Add(new DemoInfo() { SampleName = "Modal Tab", GroupName = "Features",ThemeMode=ThemeMode.Inherit, DemoViewType = typeof(ModelTab), DemoLauchMode = DemoLauchMode.Window,Title="Modal Tab",Description= "This sample showcases the modal tab in Ribbon control. It is used to display a collection of custom commands hiding the core tabs with pre-defined commands." });
            this.Demos.Add(new DemoInfo() { SampleName = "Option Tab", GroupName = "Features",ThemeMode=ThemeMode.Inherit, DemoViewType = typeof(OptionTab), DemoLauchMode = DemoLauchMode.Window,Title = "Option Tab", Description = "This sample showcases the ability to add option tabs in the More Commands window." });
            this.Demos.Add(new DemoInfo() { SampleName = "Contextual Tab", GroupName = "Features",ThemeMode=ThemeMode.Inherit, DemoViewType = typeof(ContextualTab), DemoLauchMode = DemoLauchMode.Window, Title = "Contextual Tab", Description = "This sample showcases the contextual tabs which will be displayed on-demand based on their context." });
            this.Demos.Add(new DemoInfo() { SampleName = "Touch", GroupName = "Features", ThemeMode=ThemeMode.Inherit,DemoViewType = typeof(Touch), DemoLauchMode = DemoLauchMode.Window, Title = "Touch", Description = "This sample showcases the touch support in Ribbon control." });
            this.Demos.Add(new DemoInfo() { SampleName = "RibbonBar positioning", GroupName = "Features", ThemeMode = ThemeMode.Inherit, DemoViewType = typeof(RibbonBarPositioning), DemoLauchMode = DemoLauchMode.Window, Title = "RibbonBar positioning", Description = "This sample showcases the RibbonBar is positioned to the right of the Ribbon. Also this sample demonstrates the ability to add controls to the title bar in the RibbonWindow." });
            this.Demos.Add(new DemoInfo() { SampleName = "RibbonBar collapse order", GroupName = "Features", ThemeMode = ThemeMode.Inherit, DemoViewType = typeof(RibbonBarCollapseOrder), DemoLauchMode = DemoLauchMode.Window, Title = "RibbonBar collapse order", Description = "This sample showcases the RibbonBar is resized based on the priority order." });
        }
    }
}
