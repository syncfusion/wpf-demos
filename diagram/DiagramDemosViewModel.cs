#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
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
using Syncfusion.SfSkinManager;

namespace syncfusion.diagramdemo.wpf
{
    public class DiagramDemosViewModel : DemoBrowserViewModel
    {        
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new DiagramProductDemos());
            return productdemos;
        }
    }

    public class DiagramProductDemos : ProductDemo
    {
        public DiagramProductDemos()
        {
            this.Product = "Diagram";
            this.Tag = Tag.Updated;
            this.ProductCategory = "DATA VISUALIZATION";
            this.Demos = new List<DemoInfo>();

            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", DemoLauchMode = DemoLauchMode.Window, ThemeMode = ThemeMode.Default, GroupName = "Getting Started", Description = "The Diagram is a feature-rich library for visualizing, creating and editing interactive diagrams.\n\nThe new SfDiagramRibbon is a predefined, fully customizable, and ready-to-use ribbon control, providing the UI for the most common features and settings of SfDiagram and its elements, like: save and load diagrams, printing and exporting to an image, formatting text within the shapes, customizing the appearance of the shapes and more.\n\nThis sample demonstrate how to create a simple diagrams using SfDiagram control and helps to explore its features.", DemoViewType = typeof(Views.FlowDiagram)});
            this.Demos.Add(new DemoInfo() { SampleName = "Nodes", GroupName = "Getting Started", Description = "This example shows how to add nodes to a diagram control and how to customize the appearance of the nodes.", DemoViewType = typeof(Views.Nodes) });
            this.Demos.Add(new DemoInfo() { SampleName = "Connectors", GroupName = "Getting Started", Description = "This sample visualizes how to build the diagram connectors interactively. Different types of connectors and their appearance, continuous draw option, Poly line draw options added to interact with connectors.", DemoViewType = typeof(Views.Connectors) });
            this.Demos.Add(new DemoInfo() { SampleName = "Annotations", GroupName = "Getting Started", Description = "This example shows how to add textual description to shapes and how to position them over the shapes, how to customize the position of the description, how to customize the appearance of the description.", DemoViewType = typeof(Views.Annotations) });
            this.Demos.Add(new DemoInfo() { SampleName = "Ports",Tag = Tag.Updated, GroupName = "Getting Started", Description = "This sample visualizes the process flow of publishing a book using connection points. Connection points are static points over the shapes that allow creating connections to the shapes. Customizing the size and appearance of the connection points is illustrated in this example.", DemoViewType = typeof(Views.Ports) });
            this.Demos.Add(new DemoInfo() { SampleName = "Swimlanes", GroupName = "Getting Started", Description = "This example shows how to visualize the sales processing flow chart with the help of built-in swimlane shapes.", DemoViewType = typeof(Views.Swimlane) });
            this.Demos.Add(new DemoInfo() { SampleName = "Grouping and Ordering", GroupName = "Getting Started", Description = "This example shows how to group/ungroup and order the diagram elements.", DemoViewType = typeof(Views.Grouping_and_Ordering) });
            this.Demos.Add(new DemoInfo() { SampleName = "Events", GroupName = "Getting Started", Description = "This sample visualize what are the events are available in the diagram.", DemoViewType = typeof(Views.Events) });
            this.Demos.Add(new DemoInfo() { SampleName = "Commands", GroupName = "Getting Started", Description = "This sample demonstrates the various types of Commands supported in SfDiagram.", DemoViewType = typeof(Views.Commands) });
            this.Demos.Add(new DemoInfo() { SampleName = "Constraints", GroupName = "Getting Started", Description = "This sample illustrates interaction with diagram control using constraints.", DemoViewType = typeof(Views.Constraints) });
            this.Demos.Add(new DemoInfo() { SampleName = "Rulers and Units", GroupName = "Getting Started", Description = "This sample illustrates Ruler and Units.", DemoViewType = typeof(Views.Rulers_and_Units) });
            this.Demos.Add(new DemoInfo() { SampleName = "Stencil", GroupName = "Getting Started", Tag = Tag.Updated , Description = "Stencil is a collection of reusable objects (nodes/connectors), it can be dragged and dropped into diagram any number of times. This sample demonstrates how to create and add nodes into Stencil.", DemoViewType = typeof(Views.Stencil) });            

            this.Demos.Add(new DemoInfo() { SampleName = "Zooming and Panning", GroupName = "Interactive Features", Description = "This example shows the navigating options like zooming and panning in diagram control.", DemoViewType = typeof(Views.Zooming_and_Panning) });
            this.Demos.Add(new DemoInfo() { SampleName = "Snapping", GroupName = "Interactive Features", Description = "This sample visualizes how to snap the diagram objects with each other objects, gridlines. Rulers, gridlines, and snapping options are enabled to snap the objects.", DemoViewType = typeof(Views.Snapping) });
            this.Demos.Add(new DemoInfo() { SampleName = "Scrolling", GroupName = "Interactive Features", Description = "This sample demostrates how to use the ScrollSettings in SfDiagram.", DemoViewType = typeof(Views.Scrolling) });
            this.Demos.Add(new DemoInfo() { SampleName = "Drawing tools", GroupName = "Interactive Features", Description = "This sample visualizes how to build a diagram interactively using drawing tools. Continuous draw option, snapping support are enabled to easily draw diagrams. Rulers, gridlines, and snapping options are enabled to easily align objects.", DemoViewType = typeof(Views.DrawingTools) });
            this.Demos.Add(new DemoInfo() { SampleName = "Keyboard Interaction", GroupName = "Interactive Features", Description = "This sample illustrates interaction with diagram control using shortcut keys. Command Manager support is used to manage keyboard interactions.", DemoViewType = typeof(Views.KeyBoardInteraction) });
            this.Demos.Add(new DemoInfo() { SampleName = "User Handles", GroupName = "Interactive Features", Description = "This sample visualizes a simple flow diagram along with options to execute the frequently used commands using user handles.", DemoViewType = typeof(Views.UserHandles) });
            this.Demos.Add(new DemoInfo() { SampleName = "Expand and Collapse", GroupName = "Interactive Features", Description = "This example shows how to show or hide children and view only the relevant nodes in the diagram.", DemoViewType = typeof(Views.Expand_and_Collapse) });
            this.Demos.Add(new DemoInfo() { SampleName = "Overview", GroupName = "Interactive Features", Description = "The Overview control shows a small preview of a large diagram with a navigation window to focus a particular portion of page.", DemoViewType = typeof(Views.Overview) });
            
            this.Demos.Add(new DemoInfo() { SampleName = "Node Content", GroupName = "Customization", Description = "This sample illustrates Node Content.", DemoViewType = typeof(Views.NodeContent) });
            this.Demos.Add(new DemoInfo() { SampleName = "Selector", ThemeMode = ThemeMode.Default, GroupName = "Customization", Description = "This sample illustrates the Selector customization support in Diagram.", DemoViewType = typeof(Views.Selector) });

            this.Demos.Add(new DemoInfo() { SampleName = "Flowchart Layout", GroupName = "Automatic Layout", Description = "This sample demonstrates Flowchart Layout of diagram.", DemoViewType = typeof(Views.FlowChart) });
            this.Demos.Add(new DemoInfo() { SampleName = "Organization Chart", GroupName = "Automatic Layout", Description = "This sample demonstrates Organization Layout of Diagram.", DemoViewType = typeof(Views.OrganizationLayout) });
            this.Demos.Add(new DemoInfo() { SampleName = "Mindmap Layout", GroupName = "Automatic Layout", Description = "This sample demonstrates MindMapLayout of Diagram.", DemoViewType = typeof(Views.MindMap) });
            this.Demos.Add(new DemoInfo() { SampleName = "Hierarchical Tree", GroupName = "Automatic Layout", Description = "This sample demonstrates Hierarchical Layout of Diagram.", DemoViewType = typeof(Views.HierarchicalTree) });
            this.Demos.Add(new DemoInfo() { SampleName = "Hierarchical Layout with Multiple Root", GroupName = "Automatic Layout", Description = "This sample demonstrates Hierarchical Layout with Multiple Root.", DemoViewType = typeof(Views.HierarchicalLayoutWithMultipleRoot) });
            this.Demos.Add(new DemoInfo() { SampleName = "Multi Parent Hierarchical Tree", GroupName = "Automatic Layout", Description = "This sample demonstrates Hierarchical Layout of Diagram with multiple parents.", DemoViewType = typeof(Views.MultiParent) });
            this.Demos.Add(new DemoInfo() { SampleName = "Radial Tree", GroupName = "Automatic Layout", Description = "This sample demonstrates RadialTreeLayout of Diagram.", DemoViewType = typeof(Views.RadialTree) });

            this.Demos.Add(new DemoInfo() { SampleName = "Virtualization", GroupName = "Performance", Description = "This sample demonstrates loading and panning performance of diagram using UIVirtualization with 10000 (NodeViewModel) and 14850 (ConnectorViewModel).", DemoViewType = typeof(Views.Virtualization) });
            
            this.Demos.Add(new DemoInfo() { SampleName = "Serialization", GroupName = "Serialization", Description = "This sample visualizes building diagrams interactively and editing the saved diagrams. Stencil is used to easily build diagrams.", DemoViewType = typeof(Views.Serialization) });
            
            this.Demos.Add(new DemoInfo() { SampleName = "Shape Themes", DemoLauchMode = DemoLauchMode.Window, GroupName = "Appearance", Description = "This sample demonstrates theme support for shapes, you can apply different themes and variants for a diagram. All Shape's style will be updated based on theme. You can also apply style for individual shape.", DemoViewType = typeof(Views.ThemeStyle) });

            this.Demos.Add(new DemoInfo() { SampleName = "Export", GroupName = "Export and Print", Description = "This sample demonstrates the export feature of Diagram.", DemoViewType = typeof(Views.Export) });
            this.Demos.Add(new DemoInfo() { SampleName = "Print", GroupName = "Export and Print", Description = "This sample demonstrates the print feature of Diagram.", DemoViewType = typeof(Views.Print) });                       
            this.Demos.Add(new DemoInfo() { SampleName = "Localization", DemoLauchMode = DemoLauchMode.Window, GroupName = "Localization", Description = "This example illustrates the Localization support for Diagram", DemoViewType = typeof(Views.LocalizationRibbon)});

            this.Demos.Add(new DemoInfo() { SampleName = "Circuit Diagram", GroupName = "Real-time diagrams", Description = "This sample demonstrates the electrical circuit design using Diagram.", DemoViewType = typeof(Views.Circuit_Diagram) });
            this.Demos.Add(new DemoInfo() { SampleName = "Sequence Diagram", GroupName = "Real-time diagrams", Description = "This sample illustrates how to create sequence diagram using Port feature for Node.", DemoViewType = typeof(Views.SequenceDiagram) });
            this.Demos.Add(new DemoInfo() { SampleName = "Ishikawa Diagram", GroupName = "Real-time diagrams", Description = "This sample illustrates how to create Ishikawa diagram using Port feature for Connector.", DemoViewType = typeof(Views.IshikawaDiagram) });
            this.Demos.Add(new DemoInfo() { SampleName = "SfDiagram binding with Treeview", GroupName = "Real-time diagrams", Description = "This sample illustrates how to create treeview and diagram with a single itemsource.", DemoViewType = typeof(Views.SfDiagram_Binding_With_TreeView) });
            this.Demos.Add(new DemoInfo() { SampleName = "Flow Execution", GroupName = "Real-time diagrams", Description = "This example shows the flow exection of the diagramming elements.", DemoViewType = typeof(Views.FlowExecution) });
        }
    }
}
