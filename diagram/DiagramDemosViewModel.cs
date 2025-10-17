using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.SfSkinManager;
using System.Windows.Media.Imaging;
using System.Windows.Media;

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
            this.ProductCategory = "DATA VISUALIZATION";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M6.22936 0.701212C5.51192 0.286999 4.59454 0.532812 4.18032 1.25025L1.19736 6.4169C0.773298 7.15139 1.04204 8.0911 1.79032 8.49032L5.05495 10.2321C5.37134 12.1251 7.01721 13.5678 9.00005 13.5678C11.2092 13.5678 13.0001 11.777 13.0001 9.56782C13.0001 8.38597 12.4875 7.32384 11.6726 6.59158L12.3802 5.41806L12.385 5.40987C12.6611 4.93158 12.4973 4.31999 12.019 4.04385L6.22936 0.701212ZM10.8494 6.02009L11.5189 4.90983L5.72936 1.56724C5.49021 1.42917 5.18442 1.5111 5.04635 1.75025L2.06338 6.9169C1.92203 7.16173 2.01161 7.47496 2.26104 7.60804L5.02892 9.08476C5.26743 7.10341 6.95441 5.56782 9.00005 5.56782C9.66727 5.56782 10.2963 5.73118 10.8494 6.02009ZM3.02284 12.5678H3.40005C3.64727 12.5678 3.78838 12.2856 3.64005 12.0878L2.74005 10.8878C2.62005 10.7278 2.38005 10.7278 2.26005 10.8878L1.36005 12.0878C1.21173 12.2856 1.35284 12.5678 1.60005 12.5678H2.01859C2.07506 13.2611 2.28343 13.9855 2.94254 14.4996C3.73408 15.117 5.03666 15.3171 7.06207 15.064C7.33608 15.0297 7.53044 14.7798 7.49619 14.5058C7.46194 14.2318 7.21205 14.0374 6.93804 14.0717C4.96344 14.3185 4.01602 14.0687 3.55757 13.7111C3.22757 13.4537 3.07557 13.0787 3.02284 12.5678Z"),
                Width = 13,
                Height = 16,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/DataVisualization.png", UriKind.RelativeOrAbsolute));
            this.IsHighlighted = true;
            this.ControlDescription = "The WPF Diagram control allows you to quickly create and edit flowcharts, organizational charts, UML diagrams, swim lane charts, mind maps, floor plans, and more within their applications.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Diagram.png", UriKind.RelativeOrAbsolute));
            
            List<Documentation> GettingStartedHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/getting-started")},
                new Documentation(){ Content = "Diagram - Diagram Ribbon", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/diagram-ribbon")},
            };
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", DemoLauchMode = DemoLauchMode.Window, ThemeMode = ThemeMode.Default, GroupName = "Getting Started", Description = "The Diagram is a feature-rich library for visualizing, creating and editing interactive diagrams.\n\nThe new SfDiagramRibbon is a predefined, fully customizable, and ready-to-use ribbon control, providing the UI for the most common features and settings of SfDiagram and its elements, like: save and load diagrams, printing and exporting to an image, formatting text within the shapes, customizing the appearance of the shapes and more.\n\nThis sample demonstrate how to create a simple diagrams using SfDiagram control and helps to explore its features.", DemoViewType = typeof(Views.FlowDiagram), Tag = Tag.None, Documentations= GettingStartedHelpDocuments });

            
            List<Documentation> NodesHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Nodes",Uri = new Uri("https://help.syncfusion.com/wpf/diagram/node")},
             };
            this.Demos.Add(new DemoInfo() { SampleName = "Nodes", GroupName = "Getting Started", Description = "This example shows how to add nodes to a diagram control and how to customize the appearance of the nodes.", DemoViewType = typeof(Views.Nodes) , Documentations=NodesHelpDocuments});

            List<Documentation> ConnectorsHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Connectors", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/connector/defineconnector")},
             };
            this.Demos.Add(new DemoInfo() { SampleName = "Connectors", GroupName = "Getting Started", Description = "This sample visualizes how to build the diagram connectors interactively. Different types of connectors and their appearance, continuous draw option, Poly line draw options added to interact with connectors.", DemoViewType = typeof(Views.Connectors) , Documentations= ConnectorsHelpDocuments });

             List<Documentation> LineRoutingHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Line Routing", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/connector/selectionanddragging#how-to-route-the-connectors")},
             }; 
            this.Demos.Add(new DemoInfo() { SampleName = "Line Routing", GroupName = "Getting Started", Description = "This sample visualizes the connectors that are automatically re-routing or moving away if any shape found on the connectors path and Bridging feature of the connectors.", DemoViewType = typeof(Views.LineRouting) , Documentations= LineRoutingHelpDocuments});

            List<Documentation> AnnotationsHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Annotations", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/annotation/defineannotation")},
             }; 
            this.Demos.Add(new DemoInfo() { SampleName = "Annotations", GroupName = "Getting Started", Description = "This example shows how to add textual description to shapes and how to position them over the shapes, how to customize the position of the description, how to customize the appearance of the description.", DemoViewType = typeof(Views.Annotations) , Documentations = AnnotationsHelpDocuments });

            List<Documentation> PortsHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Ports", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/port/port")},
             }; 
            this.Demos.Add(new DemoInfo() { SampleName = "Ports", GroupName = "Getting Started", Description = "This sample visualizes the process flow of publishing a book using connection points. Connection points are static points over the shapes that allow creating connections to the shapes. Customizing the size and appearance of the connection points is illustrated in this example.", DemoViewType = typeof(Views.Ports) , Documentations = PortsHelpDocuments });

            List<Documentation> SwimlanesHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Swimlanes", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/swimlane/swimlane")},
             }; 
            this.Demos.Add(new DemoInfo() { SampleName = "Swimlanes", GroupName = "Getting Started", Description = "This example shows how to visualize the sales processing flow chart with the help of built-in swimlane shapes.", DemoViewType = typeof(Views.Swimlane) , Documentations = SwimlanesHelpDocuments });

             List<Documentation> ContainersHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Containers", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/container")},
             }; 
            this.Demos.Add(new DemoInfo() { SampleName = "Containers", GroupName = "Getting Started", Description = "This example shows how to visualize the Azure Container Apps environment with the help of built-in SfDiagram Container support.", DemoViewType = typeof(Views.Container) , Documentations = ContainersHelpDocuments });

            List<Documentation> GroupHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Groups", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/group")},
             }; 
            this.Demos.Add(new DemoInfo() { SampleName = "Grouping and Ordering", GroupName = "Getting Started", Description = "This example shows how to group/ungroup and order the diagram elements.", DemoViewType = typeof(Views.Grouping_and_Ordering) , Documentations = GroupHelpDocuments });
            
            List<Documentation> EventsHelpDocuments= new List<Documentation>()
            {
                new Documentation(){ Content = "Diagram - NodeEvents", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/node#interaction)")},
                new Documentation(){ Content = "Diagram - ConnectorEvents", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/connector/appearanceandvalidation#events-for-connectors)")},
            }; 
            this.Demos.Add(new DemoInfo() { SampleName = "Events", GroupName = "Getting Started", Description = "This sample visualize what are the events are available in the diagram.", DemoViewType = typeof(Views.Events) , Documentations = EventsHelpDocuments});
            
            List<Documentation> HistoryManagerHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - History Manager", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/undoredo#undo-and-redo-actions")},
             }; 
            this.Demos.Add(new DemoInfo() { SampleName = "History Manager", GroupName = "Getting Started", Description = "This sample demonstrates viewing, deleting, limiting diagram history and groups diagram actions and stores it as a single entry in the history manager.", DemoViewType = typeof(Views.HistoryManager) , Documentations = HistoryManagerHelpDocuments });
            
             List<Documentation> CommandsHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Commands", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/commands/alignment")},
             }; 
            this.Demos.Add(new DemoInfo() { SampleName = "Commands", GroupName = "Getting Started", Description = "This sample demonstrates the various types of Commands supported in SfDiagram.", DemoViewType = typeof(Views.Commands) , Documentations = CommandsHelpDocuments });

            List<Documentation> ConstraintsHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Constraints", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/constraints")},
             };
            this.Demos.Add(new DemoInfo() { SampleName = "Constraints", GroupName = "Getting Started", Description = "This sample illustrates interaction with diagram control using constraints.", DemoViewType = typeof(Views.Constraints) , Documentations = ConstraintsHelpDocuments });

            List<Documentation> RulersHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Rulers", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/rulers")},
             }; 
            this.Demos.Add(new DemoInfo() { SampleName = "Rulers and Units", GroupName = "Getting Started", Description = "This sample illustrates Ruler and Units.", DemoViewType = typeof(Views.Rulers_and_Units) , Documentations = RulersHelpDocuments });

            List<Documentation> StencilHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Stencil", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/stencil/stencil")},
             }; 
            this.Demos.Add(new DemoInfo() { SampleName = "Stencil", GroupName = "Getting Started", Description = "Stencil is a collection of reusable objects (nodes/connectors), it can be dragged and dropped into diagram any number of times. This sample demonstrates how to create and add nodes into Stencil.", DemoViewType = typeof(Views.Stencil) , Documentations = StencilHelpDocuments });


              List<Documentation> ZoomingandPanningHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Zooming and Panning", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/interaction/zoompan")},
             }; 
            this.Demos.Add(new DemoInfo() { SampleName = "Zooming and Panning", GroupName = "Interactive Features", Description = "This example shows the navigating options like zooming and panning in diagram control.", DemoViewType = typeof(Views.Zooming_and_Panning) , Documentations = ZoomingandPanningHelpDocuments});

             List<Documentation> SnappingHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Snapping", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/snapping/definesnapping")},
             }; 
            this.Demos.Add(new DemoInfo() { SampleName = "Snapping", GroupName = "Interactive Features", Description = "This sample visualizes how to snap the diagram objects with each other objects, gridlines. Rulers, gridlines, and snapping options are enabled to snap the objects.", DemoViewType = typeof(Views.Snapping) , Documentations = SnappingHelpDocuments });

            List<Documentation> ScrollingHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Scrolling", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/scroll-settings/scrollstatusandautoscroll")},
             }; 
            this.Demos.Add(new DemoInfo() { SampleName = "Scrolling", GroupName = "Interactive Features", Description = "This sample demostrates how to use the ScrollSettings in SfDiagram.", DemoViewType = typeof(Views.Scrolling) , Documentations = ScrollingHelpDocuments });

            List<Documentation> DrawingtoolsHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Drawing tools", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/tools#drawing-tools")},
             }; 
            this.Demos.Add(new DemoInfo() { SampleName = "Drawing tools", GroupName = "Interactive Features", Description = "This sample visualizes how to build a diagram interactively using drawing tools. Continuous draw option, snapping support are enabled to easily draw diagrams. Rulers, gridlines, and snapping options are enabled to easily align objects.", DemoViewType = typeof(Views.DrawingTools) , Documentations = DrawingtoolsHelpDocuments });

            List<Documentation> KeyboardInteractionHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Keyboard Interaction", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/interaction/keyboard")},
             }; 
            this.Demos.Add(new DemoInfo() { SampleName = "Keyboard Interaction", GroupName = "Interactive Features", Description = "This sample illustrates interaction with diagram control using shortcut keys. Command Manager support is used to manage keyboard interactions.", DemoViewType = typeof(Views.KeyBoardInteraction) , Documentations = KeyboardInteractionHelpDocuments });
             List<Documentation> UserHandlesHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - User Handles", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/interaction/userhandle")},
             };
            this.Demos.Add(new DemoInfo() { SampleName = "User Handles", GroupName = "Interactive Features", Description = "This sample visualizes a simple flow diagram along with options to execute the frequently used commands using user handles.", DemoViewType = typeof(Views.UserHandles) , Documentations = UserHandlesHelpDocuments });
            
             List<Documentation> ExpandandCollapseHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Expand and Collapse", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/commands/expandcollapse")},
             }; 
            this.Demos.Add(new DemoInfo() { SampleName = "Expand and Collapse", GroupName = "Interactive Features", Description = "This example shows how to show or hide children and view only the relevant nodes in the diagram.", DemoViewType = typeof(Views.Expand_and_Collapse) , Documentations = ExpandandCollapseHelpDocuments });

            List<Documentation> OverviewHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Overview Control", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/overview-control")},
             }; 
            this.Demos.Add(new DemoInfo() { SampleName = "Overview", GroupName = "Interactive Features", Description = "The Overview control shows a small preview of a large diagram with a navigation window to focus a particular portion of page.", DemoViewType = typeof(Views.Overview) , Documentations = OverviewHelpDocuments });
            
            
            List<Documentation> NodeContentHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Node Content", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/node#visualize-a-node")},
             }; 
            this.Demos.Add(new DemoInfo() { SampleName = "Node Content", GroupName = "Customization", Description = "This sample illustrates Node Content.", DemoViewType = typeof(Views.NodeContent) , Documentations = NodeContentHelpDocuments });
            List<Documentation> SelectorHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Selection", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/interaction/selection")},
             };  
            this.Demos.Add(new DemoInfo() { SampleName = "Selector", ThemeMode = ThemeMode.Default, GroupName = "Customization", Description = "This sample illustrates the Selector customization support in Diagram.", DemoViewType = typeof(Views.Selector) , Documentations = SelectorHelpDocuments });
           
             List<Documentation> FlowchartLayoutHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Flowchart Layout", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/automatic-layouts/flowchartlayout")},
             }; 
            this.Demos.Add(new DemoInfo() { SampleName = "Flowchart Layout", GroupName = "Automatic Layout", Description = "This sample demonstrates Flowchart Layout of diagram.", DemoViewType = typeof(Views.FlowChart) , Documentations = FlowchartLayoutHelpDocuments });
            List<Documentation> OrganizationChartHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Organization Chart", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/automatic-layouts/organizationlayout")},
             }; 
            this.Demos.Add(new DemoInfo() { SampleName = "Organization Chart", GroupName = "Automatic Layout", Description = "This sample demonstrates Organization Layout of Diagram.", DemoViewType = typeof(Views.OrganizationLayout) , Documentations = OrganizationChartHelpDocuments });

             List<Documentation> MindmapLayoutHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Mind Map Layout", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/automatic-layouts/mindmaptreelayout")},
             }; 
            this.Demos.Add(new DemoInfo() { SampleName = "Mind Map Layout", GroupName = "Automatic Layout", Description = "This sample demonstrates Mind Map Layout of Diagram.", DemoViewType = typeof(Views.MindMap) , Documentations = MindmapLayoutHelpDocuments });

             List<Documentation> HierarchicalTreeHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Hierarchical Tree", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/automatic-layouts/hierarchicaltreelayout")},
             };
            this.Demos.Add(new DemoInfo() { SampleName = "Hierarchical Tree", GroupName = "Automatic Layout", Description = "This sample demonstrates Hierarchical Layout of Diagram.", DemoViewType = typeof(Views.HierarchicalTree) , Documentations = HierarchicalTreeHelpDocuments });
            List<Documentation> HierarchicalLayoutwithMultipleRootHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Hierarchical Layout", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/automatic-layouts/hierarchicaltreelayout")},
             };
            this.Demos.Add(new DemoInfo() { SampleName = "Hierarchical Layout with Multiple Root", GroupName = "Automatic Layout", Description = "This sample demonstrates Hierarchical Layout with Multiple Root.", DemoViewType = typeof(Views.HierarchicalLayoutWithMultipleRoot) , Documentations = HierarchicalLayoutwithMultipleRootHelpDocuments });
             List<Documentation> MultiParentHierarchicalTreeHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Multiparent Layout", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/datasource#layout-with-multiple-parents")},
             };
            this.Demos.Add(new DemoInfo() { SampleName = "Multi Parent Hierarchical Tree", GroupName = "Automatic Layout", Description = "This sample demonstrates Hierarchical Layout of Diagram with multiple parents.", DemoViewType = typeof(Views.MultiParent) , Documentations = MultiParentHierarchicalTreeHelpDocuments });
            
            List<Documentation> RadialTreeHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Radial Tree", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/automatic-layouts/radialtreelayout")},
             }; 
            this.Demos.Add(new DemoInfo() { SampleName = "Radial Tree", GroupName = "Automatic Layout", Description = "This sample demonstrates RadialTreeLayout of Diagram.", DemoViewType = typeof(Views.RadialTree) , Documentations = RadialTreeHelpDocuments });
            List<Documentation> ActivityHelpDocument = new List<Documentation>()
            {
                new Documentation(){ Content = "Diagram - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/getting-started")},
            };
            this.Demos.Add(new DemoInfo() { SampleName = "Activity Diagram", GroupName = "UML Diagrams", Description = "This sample represents the message flow from one activity to another in customer service using built-in UML Activity diagram shapes.", DemoViewType = typeof(Views.ActivityDiagram), Documentations = ActivityHelpDocument });
            List<Documentation> UseCaseHelpDocument = new List<Documentation>()
            {
                new Documentation() { Content = "Diagram - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/getting-started") },
            };
            this.Demos.Add(new DemoInfo() { SampleName = "Use Case Diagram", GroupName = "UML Diagrams", Description = "This sample represents the online shopping of a web customer using built-in UML Use Case diagram shapes.", DemoViewType = typeof(Views.UseCaseDiagram), Documentations = UseCaseHelpDocument });
            List<Documentation> StateDiagramHelpDocument = new List<Documentation>()
            {
                new Documentation() { Content = "Diagram - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/getting-started") },
            };
            this.Demos.Add(new DemoInfo() { SampleName = "State Diagram", GroupName = "UML Diagrams", Description = "This sample represents the Bank ATM process using built-in UML State diagram shapes.", DemoViewType = typeof(Views.StateDiagram), Documentations = StateDiagramHelpDocument });
            List<Documentation> SequenceDiagramHelpDocuments = new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/getting-started")},
             };
            this.Demos.Add(new DemoInfo() { SampleName = "Sequence Diagram", GroupName = "UML Diagrams", Description = "This sample illustrates how to create a sequence diagram using UMLSequenceDiagramModel", DemoViewType = typeof(Views.SequenceDiagram), Documentations = SequenceDiagramHelpDocuments });

             List<Documentation> VirtualizationHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Virtualization", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/virtualization")},
             }; 
            this.Demos.Add(new DemoInfo() { SampleName = "Virtualization", GroupName = "Performance", Description = "This sample demonstrates loading and panning performance of diagram using UIVirtualization with 10000 (NodeViewModel) and 14850 (ConnectorViewModel).", DemoViewType = typeof(Views.Virtualization) , Documentations = VirtualizationHelpDocuments });

            
            List<Documentation> SerializationHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Serialization", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/serialization")},
             }; 
            this.Demos.Add(new DemoInfo() { SampleName = "Serialization", GroupName = "Serialization", Description = "This sample visualizes building diagrams interactively and editing the saved diagrams. Stencil is used to easily build diagrams.", DemoViewType = typeof(Views.Serialization), Tag=Tag.None , Documentations = SerializationHelpDocuments});
            
             List<Documentation> ShapeThemesHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Diagram Theme", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/themes")},
             }; 
            this.Demos.Add(new DemoInfo() { SampleName = "Shape Themes", DemoLauchMode = DemoLauchMode.Window, GroupName = "Appearance", Description = "This sample demonstrates theme support for shapes, you can apply different themes and variants for a diagram. All Shape's style will be updated based on theme. You can also apply style for individual shape.", DemoViewType = typeof(Views.ThemeStyle) , Documentations = ShapeThemesHelpDocuments });

             List<Documentation> ExportHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram -Exporting", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/exporting")},
             };
            this.Demos.Add(new DemoInfo() { SampleName = "Export", GroupName = "Export and Print", Description = "This sample demonstrates the export feature of Diagram.", DemoViewType = typeof(Views.Export) , Documentations = ExportHelpDocuments});
              List<Documentation> PrintHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Printing", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/printing")},
             };
            this.Demos.Add(new DemoInfo() { SampleName = "Print", GroupName = "Export and Print", Description = "This sample demonstrates the print feature of Diagram.", DemoViewType = typeof(Views.Print) , Documentations=PrintHelpDocuments });                       
             List<Documentation> LocalizationHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Localization", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/localization")},
             };
            this.Demos.Add(new DemoInfo() { SampleName = "Localization", DemoLauchMode = DemoLauchMode.Window, GroupName = "Localization", Description = "This example illustrates the Localization support for Diagram", DemoViewType = typeof(Views.LocalizationRibbon) , Documentations = LocalizationHelpDocuments});
            List<Documentation> CircuitDiagramHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/getting-started")},
             };
            this.Demos.Add(new DemoInfo() { SampleName = "Circuit Diagram", GroupName = "Real-time diagrams", Description = "This sample demonstrates the electrical circuit design using Diagram.", DemoViewType = typeof(Views.Circuit_Diagram) , Documentations = CircuitDiagramHelpDocuments});
                 List<Documentation> IshikawaDiagramHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/getting-started")},
             };
            this.Demos.Add(new DemoInfo() { SampleName = "Ishikawa Diagram", GroupName = "Real-time diagrams", Description = "This sample illustrates how to create Ishikawa diagram using Port feature for Connector.", DemoViewType = typeof(Views.IshikawaDiagram) , Documentations= IshikawaDiagramHelpDocuments });
             List<Documentation> FishboneDiagramHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/getting-started")},
             };
            this.Demos.Add(new DemoInfo() { SampleName = "Fishbone Diagram", GroupName = "Real-time diagrams", Description = "This sample visually represents a simple fishbone diagram. Diagram nodes and annotations are used to define fishbone diagrams.", DemoViewType = typeof(Views.FishboneDiagram) , Tag = Tag.None , Documentations = FishboneDiagramHelpDocuments});
             List<Documentation> SfDiagrambindingwithTreeviewHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/getting-started")},
             };
            this.Demos.Add(new DemoInfo() { SampleName = "SfDiagram binding with Treeview", GroupName = "Real-time diagrams", Description = "This sample illustrates how to create treeview and diagram with a single itemsource.", DemoViewType = typeof(Views.SfDiagram_Binding_With_TreeView) , Documentations = SfDiagrambindingwithTreeviewHelpDocuments});
             List<Documentation> FlowExecutionHelpDocuments= new List<Documentation>()
             {
                new Documentation(){ Content = "Diagram - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/diagram/getting-started")},
             };
            this.Demos.Add(new DemoInfo() { SampleName = "Flow Execution", GroupName = "Real-time diagrams", Description = "This example shows the flow exection of the diagramming elements.", DemoViewType = typeof(Views.FlowExecution) , Documentations = FlowExecutionHelpDocuments });

            this.Demos.Add(new DemoInfo() { SampleName = "Text to Flowchart", ThemeMode = ThemeMode.Default, IsAISample = true, GroupName = "Smart Diagrams", AISampleDescription = "This demo illustrates the creation of a flowchart diagram using the SfDiagram Component with the assistance of AI. The AI-powered flowchart is structured with nodes and connectors arranged in a flowchart layout, designed to visually represent processes and workflows. This sample is particularly effective for visualizing step-by-step procedures, workflows, and decision-making paths in a clear and interactive manner.", Description = "This demo illustrates the creation of a flowchart diagram using the SfDiagram Component with the assistance of AI. The AI-powered flowchart is structured with nodes and connectors arranged in a flowchart layout, designed to visually represent processes and workflows. This sample is particularly effective for visualizing step-by-step procedures, workflows, and decision-making paths in a clear and interactive manner.", DemoViewType = typeof(Views.SmartFlowChart), Documentations = FlowchartLayoutHelpDocuments });
            this.Demos.Add(new DemoInfo() { SampleName = "Text to Mind Map", ThemeMode = ThemeMode.Default, IsAISample = true, GroupName = "Smart Diagrams", AISampleDescription = "This demo sample showcases the creation of a dynamic mind map diagram using the SfDiagram Component with the assistance of AI. The AI-powered diagram features nodes and connectors arranged in a mind map layout, designed to visually organize and represent ideas and concepts. This sample is ideal for brainstorming, organizing thoughts, and visually mapping out complex information.", Description = "This demo sample showcases the creation of a dynamic mind map diagram using the SfDiagram Component with the assistance of AI. The AI-powered diagram features nodes and connectors arranged in a mind map layout, designed to visually organize and represent ideas and concepts. This sample is ideal for brainstorming, organizing thoughts, and visually mapping out complex information.", DemoViewType = typeof(Views.SmartMindMap), Documentations = MindmapLayoutHelpDocuments });
            this.Demos.Add(new DemoInfo() { SampleName = "Text to Sequence Diagram", ThemeMode = ThemeMode.Default, IsAISample = true, GroupName = "Smart Diagrams", AISampleDescription = "This demo sample showcases the creation of a dynamic sequence diagram using the SfDiagram Component with the assistance of AI. The AI-powered diagram features participants, messages, fragments and activation regions arranged in a sequence diagram layout, which helps in visualizing the interaction between various components over time. This sample is ideal for understanding and documenting processes in systems.", Description = "This demo sample showcases the creation of a dynamic sequence diagram using the SfDiagram Component with the assistance of AI. The AI-powered diagram features participants, messages, fragments and activation regions arranged in a sequential format, providing a visual representation of interactions over time. This sample is ideal for documenting complex processes and system interactions.", DemoViewType = typeof(Views.SmartSequenceDiagram), Documentations = SequenceDiagramHelpDocuments });
        }
    }
}
