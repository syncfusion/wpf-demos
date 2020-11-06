#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Collections.Generic;

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
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "Navigation Drawer", Description = "The NavigationDrawer is a sliding panel menu that allows you to navigate between the major modules of the application. The Navigation Drawer is usually hidden, and it appears when you swipe the screen from any of the four edges or by tapping the app icon, if available.", DemoViewType = typeof(NavigationDrawerDemosView), DemoLauchMode = DemoLauchMode.Window , ThemeMode = ThemeMode.None });
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
            this.Demos = new List<DemoInfo>();
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
            this.Demos = new List<DemoInfo>();
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
            this.Demos = new List<DemoInfo>();
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
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description= "This sample showcases the basic features of TabControlExt Control such as Positions of the TabStrip, Close button customization, Drag and Drop and Drag marker customization, Pin and Unpin tabs", GroupName = "TabControlExt", DemoViewType = typeof(TabControlExtDemosView)
                                  , ThemeMode = ThemeMode.Default });
            this.Demos.Add(new DemoInfo() { SampleName = "Lazy Loading", Description= "This sample showcases the basic features of TabControl such as On demand loading, Loading huge tab items in very short time", GroupName = "TabControlExt", DemoViewType = typeof(LazyLoadingDemosView) });
            this.Demos.Add(new DemoInfo() { SampleName = "TouchStyle", Description= "This sample showcases the Touch functionality of TabControl", GroupName = "TabControlExt", DemoViewType = typeof(TouchStyleDemosView), DemoLauchMode = DemoLauchMode.Window, ThemeMode = ThemeMode.Default });
            this.Demos.Add(new DemoInfo() { SampleName = "Multiline TabItem", Description= "This sample showcases the ItemLayout property of the Tabcontrol", GroupName = "TabControlExt", DemoViewType = typeof(MultilineTabItemsDemosView) });
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
            this.Demos = new List<DemoInfo>();
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
            this.Demos = new List<DemoInfo>();
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
            this.Demos = new List<DemoInfo>();
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
            this.Demos = new List<DemoInfo>();
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
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "Radial Menu", Description = "This sample showcases a simple use case scenario having an editor loaded with Radial Menu with editor options loaded with the items of the Radial Menu. ", DemoViewType = typeof(RadialMenuDemosView) });
        }
    }
}
