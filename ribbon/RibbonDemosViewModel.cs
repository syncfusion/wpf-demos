#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion


using syncfusion.demoscommon.wpf;
using System.Collections.Generic;

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
            this.Tag = Tag.Updated;
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "Getting Started",ThemeMode=ThemeMode.Inherit, DemoViewType = typeof(GettingStarted),Title="Getting Started", DemoLauchMode = DemoLauchMode.Window, Description = "This sample showcases basic Ribbon and its functionalities along with auto arranging of items while resizing the Ribbon window." });
            this.Demos.Add(new DemoInfo() { SampleName = "Backstage", Tag=Tag.Updated, GroupName = "Getting Started",ThemeMode=ThemeMode.Inherit, DemoViewType = typeof(Backstage), DemoLauchMode = DemoLauchMode.Window ,Title="Backstage",Description= "This sample showcases the functionalities of backstage option in Ribbon control and events associated with it." });
            this.Demos.Add(new DemoInfo() { SampleName = "Menu Merging", GroupName = "Menu Merging",ThemeMode=ThemeMode.Inherit, DemoViewType = typeof(MenuMerging), DemoLauchMode = DemoLauchMode.Window,Title="Menu Merging",Description= "This sample showcases the merging support for Ribbon items. It includes the ability to merge the content of RibbonTab and RibbonBar from a child to parent Ribbon." });
            this.Demos.Add(new DemoInfo() { SampleName = "Modal Tab", GroupName = "Features",ThemeMode=ThemeMode.Inherit, DemoViewType = typeof(ModelTab), DemoLauchMode = DemoLauchMode.Window,Title="Modal Tab",Description= "This sample showcases the modal tab in Ribbon control. It is used to display a collection of custom commands hiding the core tabs with pre-defined commands." });
            this.Demos.Add(new DemoInfo() { SampleName = "Option Tab", GroupName = "Features",ThemeMode=ThemeMode.Inherit, DemoViewType = typeof(OptionTab), DemoLauchMode = DemoLauchMode.Window,Title = "Option Tab", Description = "This sample showcases the ability to add option tabs in the More Commands window." });
            this.Demos.Add(new DemoInfo() { SampleName = "Contextual Tab", GroupName = "Features",ThemeMode=ThemeMode.Inherit, DemoViewType = typeof(ContextualTab), DemoLauchMode = DemoLauchMode.Window, Title = "Contextual Tab", Description = "This sample showcases the contextual tabs which will be displayed on-demand based on their context." });
            this.Demos.Add(new DemoInfo() { SampleName = "Touch", GroupName = "Features", ThemeMode=ThemeMode.Inherit,DemoViewType = typeof(Touch), DemoLauchMode = DemoLauchMode.Window, Title = "Touch", Description = "This sample showcases the touch support in Ribbon control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Simplified Ribbon", GroupName = "Features", ThemeMode=ThemeMode.Inherit,DemoViewType = typeof(SimplifiedRibbon), DemoLauchMode = DemoLauchMode.Window, Title = "Simplified Ribbon", Description = "This sample showcases the simplified ribbon support which allows to collapse the ribbon bar in a single line interface, allowing more screen space for compact viewing of the content." });
        }
    }
}
