#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.dockingmanagerdemos.wpf
{
    public class DockingManagerDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {

            var productdemos = new List<ProductDemo>();
            productdemos.Add(new DockingManagerProductDemos());             
            return productdemos;
        }
    }

    public class DockingManagerProductDemos : ProductDemo
    {
        public DockingManagerProductDemos()
        {
            this.Product = "Docking Manager";
            this.ProductCategory = "LAYOUT";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description= "This sample showcases the DockingManager control with basic functionalities.",
                GroupName = "Docking Manager", DemoViewType = typeof(GettingStarted), DemoLauchMode=DemoLauchMode.Window, ThemeMode = ThemeMode.Default });
            this.Demos.Add(new DemoInfo() { SampleName = "Caption Restriction", Description= "This sample showcases how to customize the dock child's header caption such as Context Menu button, Hide button, Close button, and custom header image.", GroupName = "Docking Manager", DemoViewType = typeof(CaptionRestriction) });
            this.Demos.Add(new DemoInfo() { SampleName = "MDI", Description= "This sample showcases the MDI layout of the Document Window and different types of navigations when pressing Ctrl + Tab key.", GroupName = "Docking Manager", DemoViewType = typeof(MDI) });
            //this.Demos.Add(new DemoInfo() { SampleName = "Auto Hide", Description= "This sample showcases how the child elements are arranged as Auto Hidden window, and how the dock windows can be moved to auto hidden window without the Autohidden pin.", GroupName = "Docking Manager", DemoViewType = typeof(AutoHide) }); 
            this.Demos.Add(new DemoInfo() { SampleName = "Scrollable Auto Hidden", Description= "This sample showcases the docking manager layout with buttons in auto hide panel to scroll and view the items when the auto hidden items are exceeded in the panel.", GroupName = "Docking Manager", DemoViewType = typeof(ScrollableAutoHiddenPanel)});
            this.Demos.Add(new DemoInfo() { SampleName = "Dock Child Maximization", Description= "This sample exhibits support for minimize and maximize the dock windows as well as maximize mode.", GroupName = "Docking Manager", DemoViewType = typeof(DockChildMaximization) });
            this.Demos.Add(new DemoInfo() { SampleName = "State Persistence", Description= "This sample showcases the support for serialization and deserialization in DockingManager. DockingManager serializes the child element into various formats like IsolatedStorage, BinaryFormat, XML file, XmlWriter, and de-serializes from it.", GroupName = "Docking Manager", DemoViewType = typeof(StatePersistence), DemoLauchMode = DemoLauchMode.Window, ThemeMode = ThemeMode.Default });
            this.Demos.Add(new DemoInfo() { SampleName = "Nested Docking ", Description= "This sample showcases the nested level functionality like having DockingManager control as child of another Docking Manager Control.", GroupName = "Docking Manager", DemoViewType = typeof(NestedDockingManager) });
            //this.Demos.Add(new DemoInfo() { SampleName = "Docking Touch", Description= "This sample showcases the Touch functionality of Docking Manager Control", GroupName = "DOCKING TOUCH", DemoViewType = typeof(DockingTouch), DemoLauchMode = DemoLauchMode.Window});
            this.Demos.Add(new DemoInfo() { SampleName = "Linked Manager", Description= "This sample showcases how the drag and drop operations can be performed from one DockingManager to another DockingManager control", GroupName = "Docking Manager", DemoViewType = typeof(LinkedManager), DemoLauchMode = DemoLauchMode.Window });
            this.Demos.Add(new DemoInfo() { SampleName = "DockHints Restriction", Description= "This sample showcases how to restrict the specific DockAbility of child window when it is moved to the client area in the DockingManager", GroupName = "Docking Manager", DemoViewType = typeof(DockHintsRestrictionDemo) });
        }
    }
}
