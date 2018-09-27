using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Syncfusion.Windows.Shared;

namespace Node_Port
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            //Initialize Node and Connector
            diagramcontrol.Nodes = new ObservableCollection<NodeViewModel>();
            diagramcontrol.Connectors = new ObservableCollection<ConnectorViewModel>();

            //PortVisibility used to enable/disable the Port
            diagramcontrol.PortVisibility = PortVisibility.Collapse;

            //PageSettings used to Disable the Appearance of Daigram Page
            diagramcontrol.PageSettings = null;

            //To Disable ContextMenu
            diagramcontrol.Menu = null;

            //To Enable Zooming and Panning
            diagramcontrol.Tool = Tool.ZoomPan;
            //diagramcontrol.Constraints = diagramcontrol.Constraints & ~(GraphConstraints.Zoomable | GraphConstraints.Pannable);
            //Create Nodes and Connections
            CreateNodesandConnections();
        }

        // Create Nodes,Ports and Connections
        private void CreateNodesandConnections()
        {

            // Create Nodes
            NodeViewModel node1 = AddNode(50, 100, 100, 50, label: "Employee");
            NodeViewModel node2 = AddNode(50, 100, 300, 50, label: "Team Lead");
            NodeViewModel node3 = AddNode(50, 100, 500, 50, label: "Dashboard");
            NodeViewModel node4 = AddNode(50, 100, 700, 50, label: "Manager");
            NodeViewModel node8 = AddNode(50, 100, 100, 500);
            NodeViewModel node9 = AddNode(50, 100, 300, 500);
            NodeViewModel node10 = AddNode(50, 100, 500, 500);
            NodeViewModel node11 = AddNode(50, 100, 700, 500);

            // Connect Nodes and Ports
            ConnectorViewModel connector3 = Connect(node1, node8, label1: "c3", style: App.Current.Resources["GetLineStyle1"] as Style);
            ConnectorViewModel connector4 = Connect(node2, node9, label1: "c4", style: App.Current.Resources["GetLineStyle1"] as Style);
            ConnectorViewModel connector5 = Connect(node3, node10, label1: "c5", style: App.Current.Resources["GetLineStyle1"] as Style);
            ConnectorViewModel connector6 = Connect(node4, node11, label1: "c6", style: App.Current.Resources["GetLineStyle1"] as Style);
            NodeViewModel node5 = AddNode(180, 10, 300, 250, style: App.Current.Resources["GetNodeStyle"] as Style);
            NodeViewModel node6 = AddNode(25, 10, 500, 250, style: App.Current.Resources["GetNodeStyle"] as Style);
            NodeViewModel node7 = AddNode(48, 10, 700, 348, style: App.Current.Resources["GetNodeStyle"] as Style);
            NodeViewModel node26 = AddNode(240, 10, 100, 278, style: App.Current.Resources["GetNodeStyle"] as Style);

            // Create Ports to the Nodes and Connectors
            NodePort port1 = addPort(node5, 0, 0.053);
            NodePort port111 = addPort(node5, 1, 0.5);
            NodePort port12 = addPort(node5, 1, 0.938);
            NodePort port2 = addPort(node6, 0, 0.5);
            NodePort port3 = addPort(node7, 0, 0.1);
            NodePort port10 = addPort(node7, 0, 0.91);
            NodePort port11 = addPort(node26, 1, 0.049);
            NodePort port7 = addPort(node26, 1, 0.97);
            node5.Ports = new ObservableCollection<INodePort>()
            {
                port1,            
                port111,            
                port12
            };
            node6.Ports = new ObservableCollection<INodePort>()
            {
                port2
            };
            node7.Ports = new ObservableCollection<INodePort>()
            {
                port3,                
                port10
            };
            node26.Ports = new ObservableCollection<INodePort>()
            {
                port11,                
                port7
            };

            ConnectorViewModel connector1 = Connect(node5, node6, headport: port111, tailport: port2, label2: "Check Employee availability and task status", style: App.Current.Resources["GetLineStyle2"] as Style, margin: new Thickness(0, 20, 0, 0));
            ConnectorViewModel connector2 = Connect(node5, node7, headport: port12, tailport: port3, label2: "Forward Leave Request", style: App.Current.Resources["GetLineStyle2"] as Style, margin: new Thickness(0, 10, 0, 0));
            ConnectorViewModel connector7 = Connect(node26, node5, headport: port11, tailport: port1, label2: "Leave Request", style: App.Current.Resources["GetLineStyle2"] as Style, margin: new Thickness(0, 10, 0, 0));

            ConnectorPort port5 = addPort(connector4, 0.78);
            ConnectorPort port6 = addPort(connector4, 0.73);

            connector4.Ports = new ObservableCollection<IConnectorPort>()
            {
                port5,                
                port6
            };

            ConnectorViewModel connector8 = Connect(null, node26, tailport: port7, connector: connector4, connectorheadport: port5, label2: "Leave Approval", style: App.Current.Resources["GetLineDashStyle"] as Style, margin: new Thickness(0, 10, 0, 0));
            ConnectorViewModel connector10 = Connect(node7, null, headport: port10, connector: connector4, connectortailport: port6, label2: "No Objection", style: App.Current.Resources["GetLineDashStyle"] as Style, margin: new Thickness(0, 10, 0, 0));
        }

        // Add Connector
        private ConnectorViewModel Connect(NodeViewModel headnode, NodeViewModel tailnode, NodePort headport = null, NodePort tailport = null, ConnectorViewModel connector = null, ConnectorPort connectorheadport = null, ConnectorPort connectortailport = null, String label1 = null, String label2 = null, Style style = null, Thickness margin = new Thickness())
        {
            ConnectorViewModel conn = new ConnectorViewModel();
            conn.SourceNode = headnode;
            conn.TargetNode = tailnode;

            //To Represent Annotation Properties
            conn.Annotations = new ObservableCollection<IAnnotation>()
            {   
                new AnnotationEditorViewModel()
                { 
                    Content=label2,
                    WrapText = TextWrapping.Wrap,
                    UnitWidth=150,
                    Margin = margin, 
                    ReadOnly = true,
                    RotationReference= Syncfusion.UI.Xaml.Diagram.RotationReference.Page,
                    ViewTemplate=this.Resources["viewtemplate1"] as DataTemplate,
                    EditTemplate=this.Resources["edittemplate"] as DataTemplate 
                }               
            };

            if (headport != null)
            {
                conn.SourcePort = headport;
            }
            else
            {
                conn.SourcePort = connectorheadport;
            }

            if (tailport != null)
            {
                conn.TargetPort = tailport;
            }
            else
            {
                conn.TargetPort = connectortailport;
            }

            if (tailnode != null)
            {
                conn.SourceConnector = connector;
            }
            else
            {
                conn.TargetConnector = connector;
            }

            conn.TargetDecoratorStyle = this.Resources["DecoratorStyle"] as Style;

            if ((label1 == "c3") || (label1 == "c4") || (label1 == "c5") || (label1 == "c6"))
            {
                conn.TargetDecorator = null;
                conn.TargetDecoratorStyle = null;
            }

            if (style != null)
            {
                conn.ConnectorGeometryStyle = style;
            }
            //Selectable Constraints used to enable/disable the Connector Selection.
            conn.Constraints = conn.Constraints & ~ConnectorConstraints.Selectable;
            diagramcontrol.DefaultConnectorType = ConnectorType.Line;
            (diagramcontrol.Connectors as ICollection<ConnectorViewModel>).Add(conn);
            return conn;

        }

        // Add port for Node
        private NodePort addPort(NodeViewModel node, double offsetX, double offsetY)
        {
            NodePort v = new NodePort()
            {
                Width = 10,
                Height = 10,
                NodeOffsetX = offsetX,
                NodeOffsetY = offsetY,
                Node = node,
                ShapeStyle = this.Resources["GetPortStyle"] as Style,
            };
            return v;
        }

        // Add port for Connector
        private ConnectorPort addPort(ConnectorViewModel connector, double length)
        {
            ConnectorPort v = new ConnectorPort()
            {
                Width = 10,
                Height = 10,
                Length = length,
                Connector = connector,
                ShapeStyle = this.Resources["GetPortStyle"] as Style,
            };
            return v;
        }

        // Add Node
        private NodeViewModel AddNode(double height, double width, double offx, double offy, string label = null, Style style = null)
        {
            NodeViewModel n = new NodeViewModel()
            {
                UnitHeight = height,
                UnitWidth = width,
                OffsetX = offx,
                OffsetY = offy,
                Shape = new RectangleGeometry() { Rect = new Rect(10, 0, 50, 60) },
            };

            //To Represent Annotation Properties
            n.Annotations = new ObservableCollection<IAnnotation>()
            { 
                new AnnotationEditorViewModel()
                {
                    Content=label,
                    WrapText= TextWrapping.Wrap,
                    ReadOnly = true,
                    ViewTemplate=this.Resources["viewtemplate"] as DataTemplate,
                    EditTemplate=this.Resources["edittemplate"] as DataTemplate 
                }               
            };

            if (style != null)
            {
                n.ShapeStyle = style;
            }
            //Selectable Constraints used to enable/disable Node Selection.
            n.Constraints = n.Constraints & ~NodeConstraints.Selectable;
            (diagramcontrol.Nodes as ICollection<NodeViewModel>).Add(n);
            return n;
        }
    }
}
