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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M6 4.09091V2C6 1.44772 6.44772 1 7 1C7.55228 1 8 1.44772 8 2V4.09091C8 5.14527 8.85473 6 9.90909 6H12C12.5523 6 13 6.44772 13 7C13 7.55228 12.5523 8 12 8H9.90909C8.85473 8 8 8.85473 8 9.90909V12C8 12.5523 7.55228 13 7 13C6.44772 13 6 12.5523 6 12V9.90909C6 8.85473 5.14527 8 4.09091 8H2C1.44772 8 1 7.55228 1 7C1 6.44772 1.44772 6 2 6H4.09091C5.14527 6 6 5.14527 6 4.09091ZM5 2C5 0.89543 5.89543 0 7 0C8.10457 0 9 0.895431 9 2V4.09091C9 4.59299 9.40701 5 9.90909 5H12C13.1046 5 14 5.89543 14 7C14 8.10457 13.1046 9 12 9H9.90909C9.40701 9 9 9.40701 9 9.90909V12C9 13.1046 8.10457 14 7 14C5.89543 14 5 13.1046 5 12V9.90909C5 9.40701 4.59299 9 4.09091 9H2C0.89543 9 0 8.10457 0 7C0 5.89543 0.895431 5 2 5H4.09091C4.59299 5 5 4.59299 5 4.09091V2ZM6.7886 1.71287L6.51287 1.9886C6.32388 2.17759 6.45773 2.50074 6.725 2.50074H7.27647C7.54374 2.50074 7.67759 2.17759 7.48861 1.9886L7.21287 1.71287C7.09571 1.59571 6.90576 1.59571 6.7886 1.71287ZM7.21287 11.7886L7.4886 11.5129C7.67759 11.3239 7.54374 11.0007 7.27647 11.0007H6.725C6.45773 11.0007 6.32388 11.3239 6.51287 11.5129L6.7886 11.7886C6.90576 11.9058 7.09571 11.9058 7.21287 11.7886ZM2.48787 7.48787L2.21213 7.21213C2.09497 7.09497 2.09497 6.90503 2.21213 6.78787L2.48787 6.51213C2.67686 6.32314 3 6.45699 3 6.72426V7.27574C3 7.54301 2.67686 7.67686 2.48787 7.48787ZM11.7879 6.78787L11.5121 6.51213C11.3231 6.32314 11 6.45699 11 6.72426V7.27574C11 7.54301 11.3231 7.67686 11.5121 7.48787L11.7879 7.21213C11.905 7.09497 11.905 6.90503 11.7879 6.78787Z"),
                Width = 14,
                Height = 14,
            };
            this.IsHighlighted= true;
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Layout.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The Docking Manager control provides an interface to create Visual Studio-like dockable windows in your applications";
            this.Demos = new List<DemoInfo>();
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Docking Manager.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description= "This sample showcases the DockingManager control with basic functionalities.",
                GroupName = "Getting Started", DemoViewType = typeof(GettingStarted) });
            this.Demos.Add(new DemoInfo() { SampleName = "Caption Restriction", Description= "This sample showcases how to customize the dock child's header caption such as Context Menu button, Hide button, Close button, and custom header image.", GroupName = "Getting Started", DemoViewType = typeof(CaptionRestriction) });
            this.Demos.Add(new DemoInfo() { SampleName = "DockHints Restriction", Description = "This sample showcases how to restrict the specific DockAbility of child window when it is moved to the client area in the DockingManager", GroupName = "Getting Started", DemoViewType = typeof(DockHintsRestrictionDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Maximization", Description = "This sample exhibits support for minimize and maximize the dock windows as well as maximize mode.", GroupName = "Getting Started", DemoViewType = typeof(DockChildMaximization) });
            this.Demos.Add(new DemoInfo() { SampleName = "Scrollable Auto Hidden Windows", Description = "This sample showcases the docking manager layout with buttons in auto hide panel to scroll and view the items when the auto hidden items are exceeded in the panel.", GroupName = "Window Types", DemoViewType = typeof(ScrollableAutoHiddenPanel) });
            this.Demos.Add(new DemoInfo() { SampleName = "Floating Windows", Description = "This sample showcases the docking manager layout with the Floating windows and its alignment functionalities", GroupName = "Window Types", DemoViewType = typeof(FloatWindow) });
            this.Demos.Add(new DemoInfo() { SampleName = "Tabbed Windows", Description = "This sample showcases the docking manager layout with the tabbed windows and its alignment functionalities", GroupName = "Window Types", DemoViewType = typeof(TabbedWindow) });
            this.Demos.Add(new DemoInfo() { SampleName = "Multiple Document Interface", Description= "This sample showcases the MDI layout of the Document Window and different types of navigations when pressing Ctrl + Tab key.", GroupName = "MDI & TDI", DemoViewType = typeof(MDIDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Tabbed Document Interface", Description= "This sample showcases the TDI layout of the Document Window and different types of navigations when pressing Ctrl + Tab key.", GroupName = "MDI & TDI", DemoViewType = typeof(TDIDemo) });
            //this.Demos.Add(new DemoInfo() { SampleName = "Auto Hide", Description= "This sample showcases how the child elements are arranged as Auto Hidden window, and how the dock windows can be moved to auto hidden window without the Autohidden pin.", GroupName = "Docking Manager", DemoViewType = typeof(AutoHide) }); 
            this.Demos.Add(new DemoInfo() { SampleName = "State Persistence", Description= "This sample showcases the support for serialization and deserialization in DockingManager. DockingManager serializes the child element into various formats like IsolatedStorage, BinaryFormat, XML file, XmlWriter, and de-serializes from it.", GroupName = "Serialization", DemoViewType = typeof(StatePersistence), DemoLauchMode = DemoLauchMode.Window, ThemeMode = ThemeMode.Default });
            this.Demos.Add(new DemoInfo() { SampleName = "Visual Studio like State Persistence", Description= "This sample showcases how the docking manager retains the different mode layouts when the application is closed and reopened like Visual Studio.", GroupName = "Serialization", DemoViewType = typeof(DockingManagerlikeVisualStudio) });
             //this.Demos.Add(new DemoInfo() { SampleName = "Docking Touch", Description= "This sample showcases the Touch functionality of Docking Manager Control", GroupName = "DOCKING TOUCH", DemoViewType = typeof(DockingTouch), DemoLauchMode = DemoLauchMode.Window});
            this.Demos.Add(new DemoInfo() { SampleName = "Linked Manager", Description= "This sample showcases how the drag and drop operations can be performed from one DockingManager to another DockingManager control", GroupName = "Advanced Use Cases", DemoViewType = typeof(LinkedManager), DemoLauchMode = DemoLauchMode.Window });
            this.Demos.Add(new DemoInfo() { SampleName = "Nested Docking", Description = "This sample showcases the nested level functionality like having DockingManager control as child of another Docking Manager Control.", GroupName = "Advanced Use Cases", DemoViewType = typeof(NestedDockingManager) });
            this.Demos.Add(new DemoInfo() { SampleName = "Localization", Description = "This sample illustrates how to localize the contextmenu items headers and tooltips depending on required culture.", GroupName = "Getting Started", DemoViewType = typeof(DockingManagerLocalizationDemo) });
        }
    }
}
