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
            this.Tag = Tag.New;
            this.ProductCategory = "NAVIGATION";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "GETTING STARTED", Description = "This sample showcases the basic features in SfTreeView by simple ObservableCollection binding.", ThemeMode= ThemeMode.Default, DemoViewType = typeof(GettingStartedDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Unbound Mode", GroupName = "GETTING STARTED", Description = "This sample showcases the unbound support of SfTreeView.", ThemeMode = ThemeMode.Default, DemoViewType = typeof(UnboundModeDemo) });

            this.Demos.Add(new DemoInfo() { SampleName = "Load on Demand", GroupName = "DATA", Description = "This sample exposes the OnDemand data loading of SfTreeView.", ThemeMode = ThemeMode.Default, DemoViewType = typeof(LoadOnDemandDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Performance", GroupName = "DATA", Description = "This sample showcases the loading and scrolling performance of Tree View by loading 1 million items.", ThemeMode = ThemeMode.Default, DemoViewType = typeof(PerformanceDemo) });

            this.Demos.Add(new DemoInfo() { SampleName = "Selection", GroupName = "INTERACTIVE FEATURES", Description = "This sample showcases the treeview item selection capability of SfTreeView. SfTreeGrid control provides an interactive support for selecting items in different mode with smooth and ease manner. It supports to select a specific item or group of items programmatically or by mouse interactions by SelectionMode property. This property provides options like Single, Multiple, Extended and None.", ThemeMode = ThemeMode.Default, DemoViewType = typeof(SelectionDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Editing", GroupName = "INTERACTIVE FEATURES", Description = "This sample showcases the editing capability in SfTreeView. You can start editing by navigating to required treeview item and press the F2 key.", ThemeMode = ThemeMode.Default, DemoViewType = typeof(EditingDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "CheckBoxes", GroupName = "INTERACTIVE FEATURES", Description = "This sample showcases how nodes can be selected by CheckBox in SfTreeView.", ThemeMode = ThemeMode.Default, DemoViewType = typeof(CheckedTreeViewDemo) });

            this.Demos.Add(new DemoInfo() { SampleName = "AutoFit Content", GroupName = "NODE CUSTOMIZATION", Description = "This sample showcases the auto-fit content feature of SfTreeView, which improves the readability of the content and occurs on demand. It does not affect the loading performance of the SfTreeView and provides support for changing the height of the item based on its on-demand content for all SfTreeView items.", ThemeMode = ThemeMode.Default, DemoViewType = typeof(AutoFitContentDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Node with Image", GroupName = "NODE CUSTOMIZATION", Description = "This sample showcases node with image support of SfTreeView.", ThemeMode = ThemeMode.Default, DemoViewType = typeof(NodeWithImageDemo) });

            this.Demos.Add(new DemoInfo() { SampleName = "Between Two TreeView", GroupName = "DRAG AND DROP", Description = "This sample showcases the drag and drop behavior between two SfTreeView controls.", ThemeMode = ThemeMode.Default, DemoViewType = typeof(DragAndDropDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Between TreeView and DataGrid", GroupName = "DRAG AND DROP", Description = "This sample showcases the drag and drop behavior between SfTreeView and SfDataGrid.", ThemeMode = ThemeMode.Default, DemoViewType = typeof(DragDropBetweenTreeViewAndDataGridDemo) });           
            this.Demos.Add(new DemoInfo() { SampleName = "Between TreeView and TreeGrid", GroupName = "DRAG AND DROP", Description = "This sample showcases the drag and drop behavior between SfTreeView and SfTreeGrid.", ThemeMode = ThemeMode.Default, DemoViewType = typeof(DragDropBetweenTreeViewAndTreeGridDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Between TreeView and ListView", GroupName = "DRAG AND DROP", Description = "This sample showcases the drag and drop behavior between SfTreeView and ListView.", ThemeMode = ThemeMode.Default, DemoViewType = typeof(DragDropBetweenTreeViewAndListViewDemo) });
        }
    }
}