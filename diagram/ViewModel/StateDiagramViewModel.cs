#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
using System.Windows.Shapes;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class StateDiagramViewModel : DiagramViewModel
    {
        private static Style _mStaticGeometryStyle;
        private static Style _mStaticTargetDecoratorStyle;
        private bool first = true;
        ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/Syncfusion.SfDiagram.Wpf;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
        };


        public StateDiagramViewModel()
        {
            this.Nodes = new ObservableCollection<NodeViewModel>();
            this.Connectors = new ObservableCollection<ConnectorViewModel>();

            InitializeDiagram();
        }
        private void InitializeDiagram()
        {
            ContainerViewModel container = CreateContainer("MainContainer", "Bank ATM", "", 800, 670, 540, 370);
            ContainerViewModel container2 = CreateContainer("SubContainer", "Service Customer", "", 680, 180, 565, 585);


            NodeViewModel n1 = CreateNode("initialNode", 180, 110, 30, 30, "Initial", "");
            NodeViewModel n2 = CreateNode("Off", 300, 110, 50, 120, "Activity", "Off");
            NodeViewModel n3 = CreateNode("SelfTest", 520, 210, 50, 120, "Activity", "Self Test");
            NodeViewModel n4 = CreateNode("Idle", 330, 330, 50, 140, "Activity", "Idle");
            NodeViewModel n5 = CreateNode("Maintenance", 650, 330, 50, 120, "Activity", "Maintenance");
            NodeViewModel n6 = CreateNode("OutOfService", 850, 330, 50, 120, "Activity", "Out Of Service");

            NodeViewModel n7 = CreateNode("initialNode1", 260, 615, 30, 30, "Initial", "");
            NodeViewModel n8 = CreateNode("CA", 395, 640, 50, 120, "Activity", "Customer Authentication");
            NodeViewModel n9 = CreateNode("ST", 580, 640, 50, 120, "Activity", "Selecting Transaction");
            NodeViewModel n10 = CreateNode("Transaction", 750, 640, 50, 120, "Activity", "Transaction");
            NodeViewModel n11 = CreateNode("FinalNode", 870, 615, 30, 30, "Final", "");

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
            CreatePort(n2);
            CreatePort(n3);
            CreatePort(n4);
            CreatePort(n5);
            CreatePort(n6);
            CreatePort(container2);
            CreateConnectors("c1", "", "initialNode", "Off");
            CreateConnectors("c2", "", "initialNode1", "CA");
            CreateConnectors("c3", "", "CA", "ST");
            CreateConnectors("c4", "", "ST", "Transaction");
            CreateConnectors("c5", "", "Transaction", "FinalNode");
            container2.Nodes = new NodeCollection()
            {
                n7,n8,n9,n10,n11
            };
            container.Nodes = new NodeCollection()
            {
                n1,n2,n3, n4, n5, n6
            };
            container.Groups = new GroupCollection()
            {
                container2
            };
            ConnectorViewModel connector2 = ConnectPort("Off3", "SelfTest4", "turn on / startup");
            ConnectorViewModel connector3 = ConnectPort("OutOfService4", "Off1", "turn off / shutDown");
            ConnectorViewModel connector4 = ConnectPort("Idle2", "Off2", "turn off / shutDown");
            ConnectorViewModel connector5 = ConnectPort("SelfTest2", "OutOfService3", "failure");
            ConnectorViewModel connector6 = ConnectPort("Maintenance3", "SelfTest1", "");
            ConnectorViewModel connector7 = ConnectPort("SelfTest3", "Idle1", "");
            ConnectorViewModel connector8 = ConnectPort("OutOfService2", "Maintenance2", "service");
            ConnectorViewModel connector9 = ConnectPort("Maintenance1", "OutOfService1", "failure");
            ConnectorViewModel connector10 = ContainerPortConnect("Idle4", "SubContainer1", "cardinserted", container2);
            ConnectorViewModel connector11 = ContainerPortConnect("SubContainer2", "Idle3", "cancel", container2);
            ConnectorViewModel connector12 = ContainerPortConnect("SubContainer3", "Idle5", "", container2);
            ConnectorViewModel connector13 = ContainerPortConnect("SubContainer4", "OutOfService5", "failure", container2);
            ConnectorViewModel connector14 = ConnectPort("Idle6", "Maintenance4", "service");

            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector2);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector3);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector4);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector5);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector6);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector7);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector8);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector9);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector10);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector11);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector12);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector13);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector14);

            ItemAddedCommand = new DelegateCommand(OnItemAdded);
            ViewPortChangedCommand = new DelegateCommand(OnViewPortChanged);
            NodeChangedCommand = new DelegateCommand(OnNodeChangedCommand);
        }

        private void OnItemAdded(object obj)
        {
            var args = obj as ItemAddedEventArgs;
            if (args.ItemSource == ItemSource.Stencil)
            {
                if (args.Item is IContainer)
                {
                    var addedCoentainer = args.Item as IContainer;
                    addedCoentainer.Header.Annotation = new AnnotationEditorViewModel()
                    {
                        Content = "Title",
                        WrapText = TextWrapping.Wrap,
                        FontSize = 12,
                        Foreground = new SolidColorBrush(Colors.White),
                        FontFamily = new FontFamily("Inter")
                    };
                }
                else if (args.Item is INode)
                {
                    var addedNode = args.Item as INode;
                    var annotation = (addedNode.Annotations as AnnotationCollection).FirstOrDefault();
                    if (annotation != null)
                    {
                        annotation.FontFamily = new FontFamily("Inter");
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
                        annotation.FontFamily = new FontFamily("Inter");
                        annotation.Background = new SolidColorBrush(Colors.White);
                    }
                }
            }
        }

        private void OnNodeChangedCommand(object obj)
        {
            var args = obj as ChangeEventArgs<object, NodeChangedEventArgs>;
            if (args.Item is IContainer)
            {
                var container = args.Item as IContainer;
                if (args.NewValue.Width != args.OldValue.Width || args.NewValue.Height != args.OldValue.Height)
                {
                    container.Shape = new RectangleGeometry(new Rect(0, 0, args.NewValue.Width, args.NewValue.Height), 9, 9);
                }
            }
        }
        private ContainerViewModel CreateContainer(string name, string Headercontent, string content, double width, double height, double offsetX, double offsetY)
        {
            ContainerViewModel container = new ContainerViewModel()
            {
                ID = name,
                Name = name,
                UnitHeight = height,
                UnitWidth = width,
                OffsetX = offsetX,
                OffsetY = offsetY,

                Shape = new RectangleGeometry(new Rect(0, 0, width, height), 9, 9),
            };
            container.Header = new ContainerHeaderViewModel()
            {
                UnitHeight = 40,
                Annotation = new AnnotationEditorViewModel()
                {
                    Content = Headercontent,
                    WrapText = TextWrapping.Wrap,
                    FontSize = 12,
                    Foreground = new SolidColorBrush(Colors.White),
                    FontFamily = new FontFamily("Inter"),
                }
            };

            if (name == "SubContainer")
            {
                container.Annotations = new AnnotationCollection()
                {
                    new AnnotationEditorViewModel()
                    {
                        Offset = new Point(0.08,0.38),
                        Content = "entry / readCard \nexit / eject Card",
                        WrapText = TextWrapping.Wrap,
                        FontSize = 12,
                        FontFamily = new FontFamily("Inter"),
                        Foreground = new SolidColorBrush(Colors.Black),
                    }
                };
            }

            (Groups as GroupCollection).Add(container);

            return container;
        }
        private NodeViewModel CreateNode(string name, double offsetX, double offsetY, double height, double width, string pathData, string annotation)
        {
            NodeViewModel node = new NodeViewModel()
            {
                ID = name,
                Name = name,
                OffsetX = offsetX,
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
                       Foreground = new SolidColorBrush(Colors.White),
                       FontFamily = new FontFamily("Inter"),
                       TextHorizontalAlignment = TextAlignment.Center,
                   },
                }


            };
            return node;
        }
        private void CreatePort(ContainerViewModel container)
        {
            if (container.Name.ToString() == "SubContainer")
            {
                container.Ports = new PortCollection();
                NodePortViewModel SubContainer1 = new NodePortViewModel()
                {
                    ID = "SubContainer1",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 0.103,
                    NodeOffsetY = 0,
                };
                NodePortViewModel SubContainer2 = new NodePortViewModel()
                {
                    ID = "SubContainer2",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 0.15,
                    NodeOffsetY = 0,
                };
                NodePortViewModel SubContainer3 = new NodePortViewModel()
                {
                    ID = "SubContainer3",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 0.23,
                    NodeOffsetY = 0,
                };
                NodePortViewModel SubContainer4 = new NodePortViewModel()
                {
                    ID = "SubContainer4",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 0.92,
                    NodeOffsetY = 0,
                };
                (container.Ports as PortCollection).Add(SubContainer1);
                (container.Ports as PortCollection).Add(SubContainer2);
                (container.Ports as PortCollection).Add(SubContainer3);
                (container.Ports as PortCollection).Add(SubContainer4);
                container.PortVisibility = PortVisibility.Collapse;
            }
        }
        private void CreatePort(NodeViewModel node)
        {
            if (node.Name.ToString() == "Off")
            {

                NodePortViewModel Off1 = new NodePortViewModel()
                {
                    ID = "Off1",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 1,
                    NodeOffsetY = 0.5,
                };
                NodePortViewModel Off2 = new NodePortViewModel()
                {
                    ID = "Off2",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 0.5,
                    NodeOffsetY = 1,
                };
                NodePortViewModel Off3 = new NodePortViewModel()
                {
                    ID = "Off3",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 0.75,
                    NodeOffsetY = 1,
                };
                (node.Ports as PortCollection).Add(Off1);
                (node.Ports as PortCollection).Add(Off2);
                (node.Ports as PortCollection).Add(Off3);

            }
            if (node.Name.ToString() == "SelfTest")
            {

                NodePortViewModel SelfTest1 = new NodePortViewModel()
                {
                    ID = "SelfTest1",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 1,
                    NodeOffsetY = 0.5,
                };
                NodePortViewModel SelfTest2 = new NodePortViewModel()
                {
                    ID = "SelfTest2",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 1,
                    NodeOffsetY = 0.25,
                };
                NodePortViewModel SelfTest3 = new NodePortViewModel()
                {
                    ID = "SelfTest3",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 0.5,
                    NodeOffsetY = 1,
                };
                NodePortViewModel SelfTest4 = new NodePortViewModel()
                {
                    ID = "SelfTest4",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 0,
                    NodeOffsetY = 0.5,
                };
                (node.Ports as PortCollection).Add(SelfTest1);
                (node.Ports as PortCollection).Add(SelfTest2);
                (node.Ports as PortCollection).Add(SelfTest3);
                (node.Ports as PortCollection).Add(SelfTest4);
            }
            if (node.Name.ToString() == "Idle")
            {

                NodePortViewModel Idle1 = new NodePortViewModel()
                {
                    ID = "Idle1",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 0.5,
                    NodeOffsetY = 0,
                };
                NodePortViewModel Idle2 = new NodePortViewModel()
                {
                    ID = "Idle2",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 0.284,
                    NodeOffsetY = 0,
                };
                NodePortViewModel Idle3 = new NodePortViewModel()
                {
                    ID = "Idle3",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 0.48,
                    NodeOffsetY = 1,
                };
                NodePortViewModel Idle4 = new NodePortViewModel()
                {
                    ID = "Idle4",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 0.25,
                    NodeOffsetY = 1,
                };
                NodePortViewModel Idle5 = new NodePortViewModel()
                {
                    ID = "Idle5",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 0.87,
                    NodeOffsetY = 1,
                };
                NodePortViewModel Idle6 = new NodePortViewModel()
                {
                    ID = "Idle6",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 1,
                    NodeOffsetY = 0.5,
                };
                (node.Ports as PortCollection).Add(Idle1);
                (node.Ports as PortCollection).Add(Idle2);
                (node.Ports as PortCollection).Add(Idle3);
                (node.Ports as PortCollection).Add(Idle4);
                (node.Ports as PortCollection).Add(Idle5);
                (node.Ports as PortCollection).Add(Idle6);
            }
            if (node.Name.ToString() == "Maintenance")
            {
                NodePortViewModel Maintenance1 = new NodePortViewModel()
                {
                    ID = "Maintenance1",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 1,
                    NodeOffsetY = 0.25,
                };
                NodePortViewModel Maintenance2 = new NodePortViewModel()
                {
                    ID = "Maintenance2",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 1,
                    NodeOffsetY = 0.75,
                };
                NodePortViewModel Maintenance3 = new NodePortViewModel()
                {
                    ID = "Maintenance3",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 0.5,
                    NodeOffsetY = 0,
                };
                NodePortViewModel Maintenance4 = new NodePortViewModel()
                {
                    ID = "Maintenance4",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 0,
                    NodeOffsetY = 0.5,
                };

                (node.Ports as PortCollection).Add(Maintenance1);
                (node.Ports as PortCollection).Add(Maintenance2);
                (node.Ports as PortCollection).Add(Maintenance3);
                (node.Ports as PortCollection).Add(Maintenance4);

            }
            if (node.Name.ToString() == "OutOfService")
            {
                NodePortViewModel OutOfService1 = new NodePortViewModel()
                {
                    ID = "OutOfService1",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 0,
                    NodeOffsetY = 0.25,
                };
                NodePortViewModel OutOfService2 = new NodePortViewModel()
                {
                    ID = "OutOfService2",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 0,
                    NodeOffsetY = 0.75,
                };
                NodePortViewModel OutOfService3 = new NodePortViewModel()
                {
                    ID = "OutOfService3",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 0.25,
                    NodeOffsetY = 0,
                };
                NodePortViewModel OutOfService4 = new NodePortViewModel()
                {
                    ID = "OutOfService4",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 0.75,
                    NodeOffsetY = 0,
                };
                NodePortViewModel OutOfService5 = new NodePortViewModel()
                {
                    ID = "OutOfService5",
                    UnitHeight = 7,
                    UnitWidth = 7,
                    NodeOffsetX = 0.5,
                    NodeOffsetY = 1,
                };
                (node.Ports as PortCollection).Add(OutOfService1);
                (node.Ports as PortCollection).Add(OutOfService2);
                (node.Ports as PortCollection).Add(OutOfService3);
                (node.Ports as PortCollection).Add(OutOfService4);
                (node.Ports as PortCollection).Add(OutOfService5);
            }
        }
        private ConnectorViewModel ConnectPort(string sourceportid, string targetportid, string content)
        {
            var annotation = new AnnotationEditorViewModel()
            {
                Content = content,
                Alignment = ConnectorAnnotationAlignment.Center,
                Foreground = new SolidColorBrush(Colors.Black),
                Background = new SolidColorBrush(Colors.White),
                RotateAngle = 360,
            };
            if (!string.IsNullOrEmpty(content))
            {
                annotation.ViewTemplate = GetViewTempalte();
            }

            ConnectorViewModel con = new ConnectorViewModel()
            {
                SourcePortID = sourceportid,
                TargetPortID = targetportid,
                Annotations = new ObservableCollection<IAnnotation>() { annotation }
            };
            SetDefultConnectorGeometryStyle();
            SetTargetDecoratorStyle();
            con.CornerRadius = 5;
            con.TargetDecoratorStyle = _mStaticTargetDecoratorStyle;
            con.TargetDecorator = "M0,0 L8,4 L0,8 L8,4 L0,0Z";
            return con;
        }
        public static DataTemplate GetViewTempalte()
        {
            const string vTemplate = "<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">" +
                                       "<TextBlock RenderTransformOrigin=\"0.5,0.5\" Text=\"{Binding Path=Content, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}\" Padding=\"4,0,4,0\" VerticalAlignment=\"{Binding Path=TextVerticalAlignment, UpdateSourceTrigger=PropertyChanged}\" TextAlignment=\"{Binding Path=TextHorizontalAlignment, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}\" TextWrapping=\"{Binding Path=WrapText, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}\" TextTrimming=\"{Binding Path=TextTrimming, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}\" TextDecorations =\"{Binding Path=TextDecorations, UpdateSourceTrigger=PropertyChanged }\" >" +
                                        "</TextBlock>" +
                                        "</DataTemplate>";

            return System.Windows.Markup.XamlReader.Parse(vTemplate) as DataTemplate;
        }
        private ConnectorViewModel ContainerPortConnect(string sourceportid, string targetportid, string content, ContainerViewModel SourceContainer)
        {
            var annotation = new AnnotationEditorViewModel()
            {
                Content = content,
                Alignment = ConnectorAnnotationAlignment.Center,
                Foreground = new SolidColorBrush(Colors.Black),
                Background = new SolidColorBrush(Colors.White),
                RotateAngle = -180,
            };
            if (!string.IsNullOrEmpty(content))
            {
                annotation.ViewTemplate = GetViewTempalte();
            }
            
            ConnectorViewModel con = new ConnectorViewModel()
            {
                SourcePortID = sourceportid,
                TargetPortID = targetportid,
                SourceNode = SourceContainer,
                Annotations = new ObservableCollection<IAnnotation>() { annotation  }
            };
            SetDefultConnectorGeometryStyle();
            SetTargetDecoratorStyle();
            con.TargetDecoratorStyle = _mStaticTargetDecoratorStyle;
            con.TargetDecorator = "M0,0 L8,4 L0,8 L8,4 L0,0Z";
            return con;
        }
        private void CreateConnectors(string id, string content, string sourceID, string targetID)
        {
            var annotation = new AnnotationEditorViewModel()
            {
                Content = content,
                Alignment = ConnectorAnnotationAlignment.Center,
                Foreground = new SolidColorBrush(Colors.Black),
                Background = new SolidColorBrush(Colors.White),
                RotateAngle = -90,
                Displacement = 30,   
            };
            if (!string.IsNullOrEmpty(content))
            {
                annotation.ViewTemplate = GetViewTempalte();
            }

            ConnectorViewModel connector = new ConnectorViewModel()
            {
                ID = id,
                SourceNodeID = sourceID,
                TargetNodeID = targetID,
                Annotations = new ObservableCollection<IAnnotation>() { annotation }
            };
            SetDefultConnectorGeometryStyle();
            SetTargetDecoratorStyle();
            connector.CornerRadius = 5;
            connector.TargetDecoratorStyle = _mStaticTargetDecoratorStyle;
            connector.TargetDecorator = "M0,0 L8,4 L0,8 L8,4 L0,0Z";
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector);
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
        private static void SetTargetDecoratorStyle()
        {
            _mStaticTargetDecoratorStyle = new Style()
            {
                TargetType = typeof(Shape),
            };
            _mStaticTargetDecoratorStyle.Setters.Add(
                new Setter()
                {
                    Property = Shape.StrokeProperty,
                    Value = new SolidColorBrush(Colors.DimGray),
                });
            _mStaticTargetDecoratorStyle.Setters.Add(
           new Setter()
           {
               Property = Shape.StretchProperty,
               Value = Stretch.Fill
           });
            _mStaticTargetDecoratorStyle.Setters.Add(
          new Setter()
          {
              Property = Shape.FillProperty,
              Value = new SolidColorBrush(Colors.White)
          });
        }
        private static void SetDefultConnectorGeometryStyle()
        {
            DoubleCollection param = new DoubleCollection() { 5.0, 5.0 };
            _mStaticGeometryStyle = new Style()
            {
                TargetType = typeof(Shape),
            };
            _mStaticGeometryStyle.Setters.Add(
                new Setter()
                {
                    Property = Shape.StrokeProperty,
                    Value = new SolidColorBrush(Colors.Black)
                });
            _mStaticGeometryStyle.Setters.Add(
                new Setter()
                {
                    Property = Shape.StrokeThicknessProperty,
                    Value = 1d
                });

        }
    }
}
