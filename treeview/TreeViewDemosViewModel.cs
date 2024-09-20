#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
using System.Windows;
using System.Windows.Media.Imaging;

namespace syncfusion.treeviewdemos.wpf
{
    public class TreeViewDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new TreeViewProductDemos());
            return productdemos;
        }
    }

    public class TreeViewProductDemos : ProductDemo
    {
        public TreeViewProductDemos()
        {
            this.Product = "TreeView";
            this.ProductCategory = "NAVIGATION";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M6 4C6.55228 4 7 3.55228 7 3L7 1C7 0.447715 6.55228 0 6 0H1C0.447715 0 0 0.447715 0 1V3C0 3.55229 0.447716 4 1 4L3 4L3 7.1C3 7.8732 3.6268 8.5 4.4 8.5H5V9C5 9.55229 5.44772 10 6 10L8 10V13.1C8 13.8732 8.6268 14.5 9.4 14.5H10V15C10 15.5523 10.4477 16 11 16H15C15.5523 16 16 15.5523 16 15V13C16 12.4477 15.5523 12 15 12H11C10.4477 12 10 12.4477 10 13V13.5H9.4C9.17909 13.5 9 13.3209 9 13.1V10H11C11.5523 10 12 9.55229 12 9V7C12 6.44771 11.5523 6 11 6L6 6C5.44772 6 5 6.44772 5 7V7.5H4.4C4.17909 7.5 4 7.32091 4 7.1L4 4H6Z"),
                Width = 16,
                Height = 16,
            };
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Navigation.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The TreeView is a data-oriented control that displays data in a hierarchical structure with nodes that expand and collapse.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/TreeView.png", UriKind.RelativeOrAbsolute));
            this.Demos = new List<DemoInfo>();

            List<Documentation> gettingStartedDocumentation = new List<Documentation>();
            gettingStartedDocumentation.Add(new Documentation { Content = "TreeView - API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.TreeView.html") });
            gettingStartedDocumentation.Add(new Documentation { Content = "TreeView - ShowLines API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.TreeView.SfTreeView.html#Syncfusion_UI_Xaml_TreeView_SfTreeView_ShowLines") });
            gettingStartedDocumentation.Add(new Documentation { Content = "TreeView - Getting Started Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treeview/getting-started") });
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "GETTING STARTED", Description = "This sample showcases the basic features in SfTreeView by simple ObservableCollection binding.", ThemeMode= ThemeMode.Inherit, DemoViewType = typeof(GettingStartedDemo), Documentations = gettingStartedDocumentation });
            List<Documentation> unboundModeDocumentation = new List<Documentation>();
            unboundModeDocumentation.Add(new Documentation { Content = "TreeView - Unbound Mode Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treeview/getting-started#populating-nodes-without-data-source---unbound-mode") });
            this.Demos.Add(new DemoInfo() { SampleName = "Unbound Mode", GroupName = "GETTING STARTED", Description = "This sample showcases the unbound support of SfTreeView.", ThemeMode = ThemeMode.Inherit, DemoViewType = typeof(UnboundModeDemo), Documentations = unboundModeDocumentation });

            List<Documentation> loadOnCommandDocumentation = new List<Documentation>();
            loadOnCommandDocumentation.Add(new Documentation { Content = "TreeView - LoadOnDemandCommand API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.TreeView.SfTreeView.html#Syncfusion_UI_Xaml_TreeView_SfTreeView_LoadOnDemandCommand") });
            loadOnCommandDocumentation.Add(new Documentation { Content = "TreeView - Load On Demand Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treeview/load-on-demand") });
            this.Demos.Add(new DemoInfo() { SampleName = "Load on Demand", GroupName = "DATA", Description = "This sample exposes the OnDemand data loading of SfTreeView.", ThemeMode = ThemeMode.Inherit, DemoViewType = typeof(LoadOnDemandDemo), Documentations = loadOnCommandDocumentation });
            List<Documentation> performanceDocumentation = new List<Documentation>();
            performanceDocumentation.Add(new Documentation { Content = "TreeView - Scrolling Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treeview/scrolling") });
            this.Demos.Add(new DemoInfo() { SampleName = "Performance", GroupName = "DATA", Description = "This sample showcases the loading and scrolling performance of Tree View by loading 1 million items.", ThemeMode = ThemeMode.Inherit, DemoViewType = typeof(PerformanceDemo), Documentations = performanceDocumentation });
            this.Demos.Add(new DemoInfo() { SampleName = "Filtering", GroupName = "DATA", Description = "This sample showcases the ListCollectionView binding with filtering support of SfTreeView.", ThemeMode = ThemeMode.Inherit, DemoViewType = typeof(FilteringDemo) });

            List<Documentation> selectionDocumentation = new List<Documentation>();
            selectionDocumentation.Add(new Documentation { Content = "TreeView - SelectionMode API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.TreeView.SfTreeView.html#Syncfusion_UI_Xaml_TreeView_SfTreeView_SelectionMode") });
            selectionDocumentation.Add(new Documentation { Content = "TreeView - Selection Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treeview/selection") });
            this.Demos.Add(new DemoInfo() { SampleName = "Selection", GroupName = "INTERACTIVE FEATURES", Description = "This sample showcases the treeview item selection capability of SfTreeView. SfTreeGrid control provides an interactive support for selecting items in different mode with smooth and ease manner. It supports to select a specific item or group of items programmatically or by mouse interactions by SelectionMode property. This property provides options like Single, Multiple, Extended and None.", ThemeMode = ThemeMode.Inherit, DemoViewType = typeof(SelectionDemo), Documentations = selectionDocumentation });
            List<Documentation> editingDocumentation = new List<Documentation>();
            editingDocumentation.Add(new Documentation { Content = "TreeView - AllowEditing API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.TreeView.SfTreeView.html#Syncfusion_UI_Xaml_TreeView_SfTreeView_AllowEditing") });
            editingDocumentation.Add(new Documentation { Content = "TreeView - EditTemplate API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.TreeView.SfTreeView.html#Syncfusion_UI_Xaml_TreeView_SfTreeView_EditTemplate") });
            editingDocumentation.Add(new Documentation { Content = "TreeView - Editing Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treeview/editing") });
            this.Demos.Add(new DemoInfo() { SampleName = "Editing", GroupName = "INTERACTIVE FEATURES", Description = "This sample showcases the editing capability in SfTreeView. You can start editing the treeview item by pressing the F2 key or DoubleTap on the treeview item.", ThemeMode = ThemeMode.None, DemoViewType = typeof(EditingDemo), Documentations = editingDocumentation });
            List<Documentation> checkBoxDocumentation = new List<Documentation>();
            checkBoxDocumentation.Add(new Documentation { Content = "TreeView - CheckBoxMode API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.TreeView.SfTreeView.html#Syncfusion_UI_Xaml_TreeView_SfTreeView_CheckBoxMode") });
            checkBoxDocumentation.Add(new Documentation { Content = "TreeView - CheckBox Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treeview/checkbox") });
            this.Demos.Add(new DemoInfo() { SampleName = "CheckBoxes", GroupName = "INTERACTIVE FEATURES", Description = "This sample showcases how nodes can be selected by CheckBox in SfTreeView.", ThemeMode = ThemeMode.Inherit, DemoViewType = typeof(CheckedTreeViewDemo), Documentations = checkBoxDocumentation });

            List<Documentation> autoFitContentDocumentation = new List<Documentation>();
            autoFitContentDocumentation.Add(new Documentation { Content = "TreeView - AutoFit Content Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treeview/item-height-customization#autofit-item-height-based-on-content") });
            this.Demos.Add(new DemoInfo() { SampleName = "AutoFit Content", GroupName = "NODE CUSTOMIZATION", Description = "This sample showcases the auto-fit content feature of SfTreeView, which improves the readability of the content and occurs on demand. It does not affect the loading performance of the SfTreeView and provides support for changing the height of the item based on its on-demand content for all SfTreeView items.", ThemeMode = ThemeMode.None, DemoViewType = typeof(AutoFitContentDemo), Documentations = autoFitContentDocumentation });
            List<Documentation> nodeWithImageDocumentation = new List<Documentation>();
            nodeWithImageDocumentation.Add(new Documentation { Content = "TreeView - ItemTemplate API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.TreeView.SfTreeView.html#Syncfusion_UI_Xaml_TreeView_SfTreeView_ItemTemplate") });
            nodeWithImageDocumentation.Add(new Documentation { Content = "TreeView - Node with Image Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treeview/appearance#itemtemplate") });
            this.Demos.Add(new DemoInfo() { SampleName = "Node with Image", GroupName = "NODE CUSTOMIZATION", Description = "This sample showcases node with image support of SfTreeView.", ThemeMode = ThemeMode.None, DemoViewType = typeof(NodeWithImageDemo), Documentations = nodeWithImageDocumentation });

            List<Documentation> betweenTwoTreeViewDocumentation = new List<Documentation>();
            betweenTwoTreeViewDocumentation.Add(new Documentation { Content = "TreeView - AllowDragging API reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.TreeView.SfTreeView.html#Syncfusion_UI_Xaml_TreeView_SfTreeView_AllowDragging") });
            betweenTwoTreeViewDocumentation.Add(new Documentation { Content = "TreeView - Between Two TreeView Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/treeview/drag-and-drop#drag-and-drop-between-two-treeviews") });
            this.Demos.Add(new DemoInfo() { SampleName = "Between Two TreeView", GroupName = "DRAG AND DROP", Description = "This sample showcases the drag and drop behavior between two SfTreeView controls.", ThemeMode = ThemeMode.None, DemoViewType = typeof(DragAndDropDemo), Documentations = betweenTwoTreeViewDocumentation });
            
            List<Documentation> betweenTreeViewAndDataGridDocumentation = new List<Documentation>();
            betweenTreeViewAndDataGridDocumentation.Add(new Documentation { Content = "TreeView - AllowDragging API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.TreeView.SfTreeView.html#Syncfusion_UI_Xaml_TreeView_SfTreeView_AllowDragging") });
            betweenTreeViewAndDataGridDocumentation.Add(new Documentation { Content = "DataGrid - Drag And Drop Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/datagrid/drag-and-drop") });
            this.Demos.Add(new DemoInfo() { SampleName = "Between TreeView and DataGrid", GroupName = "DRAG AND DROP", Description = "This sample showcases the drag and drop behavior between SfTreeView and SfDataGrid.", ThemeMode = ThemeMode.Inherit, DemoViewType = typeof(DragDropBetweenTreeViewAndDataGridDemo), Documentations = betweenTreeViewAndDataGridDocumentation });           
            
            List<Documentation> betweenTreeViewAndTreeGridDocumentation = new List<Documentation>();
            betweenTreeViewAndTreeGridDocumentation.Add(new Documentation { Content = "TreeView - AllowDragging API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.TreeView.SfTreeView.html#Syncfusion_UI_Xaml_TreeView_SfTreeView_AllowDragging") });
            this.Demos.Add(new DemoInfo() { SampleName = "Between TreeView and TreeGrid", GroupName = "DRAG AND DROP", Description = "This sample showcases the drag and drop behavior between SfTreeView and SfTreeGrid.", ThemeMode = ThemeMode.Inherit, DemoViewType = typeof(DragDropBetweenTreeViewAndTreeGridDemo), Documentations = betweenTreeViewAndTreeGridDocumentation });
            
            List<Documentation> betweenTreeViewAndListViewDocumentation = new List<Documentation>();
            betweenTreeViewAndListViewDocumentation.Add(new Documentation { Content = "TreeView - AllowDragging API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.TreeView.SfTreeView.html#Syncfusion_UI_Xaml_TreeView_SfTreeView_AllowDragging") });
            this.Demos.Add(new DemoInfo() { SampleName = "Between TreeView and ListView", GroupName = "DRAG AND DROP", Description = "This sample showcases the drag and drop behavior between SfTreeView and ListView.", ThemeMode = ThemeMode.None, DemoViewType = typeof(DragDropBetweenTreeViewAndListViewDemo), Documentations = betweenTreeViewAndListViewDocumentation });
        }
    }
}