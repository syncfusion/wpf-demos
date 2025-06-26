#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class ActivityDiagramViewModel : DiagramViewModel
    {
        private bool first = true;
        ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/Syncfusion.SfDiagram.Wpf;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
        };

        public ActivityDiagramViewModel()
        {
            this.Nodes = new ObservableCollection<NodeViewModel>();
            this.Connectors = new ObservableCollection<ConnectorViewModel>();
            this.Swimlanes = new ObservableCollection<SwimlaneViewModel>();
            this.PortVisibility = PortVisibility.MouseOver;
            InitializeDiagram();
        }
        private void InitializeDiagram()
        {
            NodeViewModel n1 = CreateNode("InitialNode", 300, 70, 35, 35, "Initial", "");
            NodeViewModel n2 = CreateNode("Receivecall", 300, 130, 40, 150, "Activity", "Receive Customer Call");
            NodeViewModel n3 = CreateNode("HorizontalFork", 300, 180, 20, 80, "ForkNode", "");
            CreatePort(n3);

            NodeViewModel n4 = CreateNode("DetermineCall", 150, 270, 40, 150, "Activity", "Determine Type Of Call");
            CreatePort(n4);

            NodeViewModel n5 = CreateNode("CustomerCall", 440, 270, 40, 150, "Activity", "Customer Logging a Call");
            CreatePort(n5);

            NodeViewModel n6 = CreateNode("MergeNode", 150, 348, 50, 50, "MergeNode", "");
            CreatePort(n6);

            NodeViewModel n7 = CreateNode("salesCall", 40, 420, 40, 150, "Activity", "Tranfer the call to Sales");
            CreatePort(n7);

            NodeViewModel n8 = CreateNode("helpdeskCall", 260, 420, 40, 150, "Activity", "Transfer the call to Help Desk");
            CreatePort(n8);

            NodeViewModel n9 = CreateNode("MergeNode2", 150, 490, 50, 50, "MergeNode", "");
            CreatePort(n9);

            NodeViewModel n10 = CreateNode("Join", 420, 600, 20, 80, "JoinNode", "");
            CreatePort(n10);

            NodeViewModel n11 = CreateNode("MergeCall", 420, 660, 30, 80, "Activity", "Close Call");
            NodeViewModel n12 = CreateNode("Final", 420, 720, 35, 35, "Final", "");
            (this.Nodes as ObservableCollection<NodeViewModel>).Add(n1);
            (this.Nodes as ObservableCollection<NodeViewModel>).Add(n2);
            (this.Nodes as ObservableCollection<NodeViewModel>).Add(n3);
            (this.Nodes as ObservableCollection<NodeViewModel>).Add(n4);
            (this.Nodes as ObservableCollection<NodeViewModel>).Add(n5);
            (this.Nodes as ObservableCollection<NodeViewModel>).Add(n6);
            (this.Nodes as ObservableCollection<NodeViewModel>).Add(n7);
            (this.Nodes as ObservableCollection<NodeViewModel>).Add(n8);
            (this.Nodes as ObservableCollection<NodeViewModel>).Add(n9);
            (this.Nodes as ObservableCollection<NodeViewModel>).Add(n10);
            (this.Nodes as ObservableCollection<NodeViewModel>).Add(n11);
            (this.Nodes as ObservableCollection<NodeViewModel>).Add(n12);

            CreateConnectors("c1", "InitialNode", "Receivecall");
            CreateConnectors("c1", "Receivecall", "HorizontalFork");
            CreateConnectors("c1", "DetermineCall", "MergeNode");
            CreateConnectors("c1", "Join", "MergeCall");
            CreateConnectors("c1", "MergeCall", "Final");
            ConnectorViewModel connector2 = ConnectPort("Forkport3", "CustomerCall_port1", "");
            ConnectorViewModel connector3 = ConnectPort("port2", "Salesport", "New Customer");
            ConnectorViewModel connector4 = ConnectPort("port", "helpdeskCall", "Existing Customer");
            ConnectorViewModel connector5 = ConnectPort("Salesport2", "mergeport", "");
            ConnectorViewModel connector6 = ConnectPort("helpdeskCall2", "mergeport2", "");
            ConnectorViewModel connector7 = ConnectPort("CustomerCall_port2", "Jointopright", "");
            ConnectorViewModel connector8 = ConnectPort("Forkport4", "DetermineCallport1", "");
            ConnectorViewModel connector9 = ConnectPort("mergeport3", "Jointopleft", "");

            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector2);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector3);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector4);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector5);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector6);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector7);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector8);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector9);

            ViewPortChangedCommand = new DelegateCommand(OnViewPortChanged);
            ItemAddedCommand = new DelegateCommand(OnItemAdded);
            SwimlaneChildChangedCommand = new DelegateCommand(OnSwimlaneChildChanged);
        }

        private void OnSwimlaneChildChanged(object obj)
        {
            var args = obj as ChangeEventArgs<object, SwimlaneChildChangedEventArgs>;
            if (args.Item is PhaseViewModel phaseViewModel)
            {
                if (phaseViewModel.Header is SwimlaneHeaderViewModel && (phaseViewModel.Header as SwimlaneHeaderViewModel).Annotation != null)
                {
                    AnnotationEditorViewModel anno = (phaseViewModel.Header as SwimlaneHeaderViewModel).Annotation as AnnotationEditorViewModel;
                    anno.FontSize = 12;
                    anno.FontFamily = new FontFamily("Inter");
                    anno.Foreground = new SolidColorBrush(Colors.White);
                }
            }
            else if (args.Item is LaneViewModel laneViewModel)
            {
                if (laneViewModel.Header is SwimlaneHeaderViewModel && (laneViewModel.Header as SwimlaneHeaderViewModel).Annotation != null)
                {
                    AnnotationEditorViewModel anno = (laneViewModel.Header as SwimlaneHeaderViewModel).Annotation as AnnotationEditorViewModel;
                    anno.FontSize = 12;
                    anno.FontFamily = new FontFamily("Inter");
                    anno.Foreground = new SolidColorBrush(Colors.White);
                }
            }
            else if (args.Item is SwimlaneHeaderViewModel swimlaneHeaderViewModel)
            {
                if ((args.Item as SwimlaneHeaderViewModel).Annotation != null)
                {
                    AnnotationEditorViewModel anno = (args.Item as SwimlaneHeaderViewModel).Annotation as AnnotationEditorViewModel;
                    anno.FontSize = 12;
                    anno.FontFamily = new FontFamily("Inter");
                    anno.Foreground = new SolidColorBrush(Colors.White);
                }
            }
        }

        private void OnViewPortChanged(object obj)
        {
            var args = obj as ChangeEventArgs<object, ScrollChanged>;
            if (Info != null && (args.Item as SfDiagram).IsLoaded == true && args.NewValue.ContentBounds != args.OldValue.ContentBounds && first)
            {
                var bounds = args.NewValue.ContentBounds;
                bounds.Inflate(new Size(50, 50));
                if (bounds.Height > args.NewValue.ViewPort.Height)
                {
                    (Info as IGraphInfo).Commands.FitToPage.Execute(new FitToPageParameter() { FitToPage = FitToPage.FitToPage, Margin = new Thickness(20) });
                }
                else
                {
                    (Info as IGraphInfo).BringIntoCenter(bounds);
                }
                first = false;
            }
        }

        private void OnItemAdded(object obj)
        {
            var args = obj as ItemAddedEventArgs;
            if (args.ItemSource == ItemSource.Stencil)
            {
                if (args.Item is INode)
                {
                    var addedNode = args.Item as INode;
                    var annotation = (addedNode.Annotations as AnnotationCollection).FirstOrDefault();
                    if (annotation != null)
                    {
                        annotation.FontFamily = new FontFamily("Inter");
                        annotation.FontSize = 12;
                        if (!annotation.Offset.Y.Equals(1))
                        {
                            annotation.Foreground = new SolidColorBrush(Colors.White);
                        }
                    }
                }
                else if (args.Item is IConnector)
                {
                    var addedConnector = args.Item as IConnector;
                    var annotation = (addedConnector.Annotations as AnnotationCollection).FirstOrDefault();
                    if (annotation != null)
                    {
                        annotation.FontSize = 12;
                        annotation.FontFamily = new FontFamily("Inter");
                        annotation.Background = new SolidColorBrush(Colors.White);
                    }
                }
            }
        }

        private NodeViewModel CreateNode(string name, double offsetX, double offsetY, double height, double width, string pathData, string annotation)
        {
            NodeViewModel node = new NodeViewModel()
            {
                ID = name,
                Name = name,
                OffsetX = offsetX + 70,
                OffsetY = offsetY,
                UnitHeight = height,
                UnitWidth = width,
                Shape = resourceDictionary[pathData],
                Annotations = new ObservableCollection<IAnnotation>()
                {
                   new TextAnnotationViewModel()
                   {
                       Text = annotation,
                       FontSize = 12,
                       FontFamily = new FontFamily("Inter"),
                       Foreground = new SolidColorBrush(Colors.White),
                       HorizontalAlignment = HorizontalAlignment.Center,
                       TextHorizontalAlignment = TextAlignment.Center,
                   },
                }
            };

            return node;
        }

        private void AddPortToNode(NodeViewModel node, string portId, double offsetX, double offsetY)
        {
            NodePortViewModel port = new NodePortViewModel()
            {
                ID = portId,
                UnitHeight = 8d,
                UnitWidth = 8d,
                NodeOffsetX = offsetX,
                NodeOffsetY = offsetY,
            };

            (node.Ports as PortCollection).Add(port);
        }

        private void CreatePort(NodeViewModel node)
        {
            switch (node.Name.ToString())
            {
                case "HorizontalFork":
                    AddPortToNode(node, "Forkport1", 0.5, 0);
                    AddPortToNode(node, "Forkport2", 0.5, 1);
                    AddPortToNode(node, "Forkport3", 0.75, 1);
                    AddPortToNode(node, "Forkport4", 0.25, 1);
                    break;

                case "CustomerCall":
                    AddPortToNode(node, "CustomerCall_port1", 0.5, 0);
                    AddPortToNode(node, "CustomerCall_port2", 0.5, 1);
                    break;

                case "DetermineCall":
                    AddPortToNode(node, "DetermineCallport1", 0.5, 0);
                    AddPortToNode(node, "DetermineCallport2", 0.5, 1);
                    break;

                case "salesCall":
                    AddPortToNode(node, "Salesport", 0.5, 0);
                    AddPortToNode(node, "Salesport2", 0.5, 1);
                    break;

                case "helpdeskCall":
                    AddPortToNode(node, "helpdeskCall", 0.5, 0);
                    AddPortToNode(node, "helpdeskCall2", 0.5, 1);
                    break;

                case "MergeNode":
                    AddPortToNode(node, "port", 1, 0.5);
                    AddPortToNode(node, "port2", 0, 0.5);
                    AddPortToNode(node, "port3", 0.5, 0);
                    AddPortToNode(node, "port4", 0.5, 1);
                    break;

                case "MergeNode2":
                    AddPortToNode(node, "mergeport", 0, 0.5);
                    AddPortToNode(node, "mergeport2", 1, 0.5);
                    AddPortToNode(node, "mergeport3", 0.5, 1);
                    AddPortToNode(node, "mergeport4", 0.5, 0);
                    break;

                case "Join":
                    AddPortToNode(node, "Jointopleft", 0.25, 0);
                    AddPortToNode(node, "Jointopmid", 0.5, 0);
                    AddPortToNode(node, "Jointopright", 0.75, 0);
                    AddPortToNode(node, "Joinbottom", 0.5, 1);
                    break;
            }
        }

        private ConnectorViewModel ConnectPort(string sourceportid, string targetportid, string content)
        {
            ConnectorViewModel con = new ConnectorViewModel()
            {
                SourcePortID = sourceportid,
                TargetPortID = targetportid,
                Annotations = new ObservableCollection<IAnnotation>()
                {
                    new AnnotationEditorViewModel()
                    {
                        Content=content,
                        Alignment = ConnectorAnnotationAlignment.Center,
                        Foreground = new SolidColorBrush(Colors.Black),
                        Background = new SolidColorBrush(Colors.White),
                        RotationReference = Syncfusion.UI.Xaml.Diagram.RotationReference.Page,
                        Displacement = 30,
                        FontSize = 12,
                        FontFamily = new FontFamily("Inter"),
        }
                }
            };
            con.TargetDecorator = "M0,0 L8,4 L0,8 L8,4 L0,0Z";
            return con;
        }

        private void CreateConnectors(string id, string sourceID, string targetID)
        {
            ConnectorViewModel connector = new ConnectorViewModel()
            {
                ID = id,
                SourceNodeID = sourceID,
                TargetNodeID = targetID,
            };
            connector.TargetDecorator = "M0,0 L8,4 L0,8 L8,4 L0,0Z";
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector);
        }
    }
}
