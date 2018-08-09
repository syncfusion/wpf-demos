using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace connectorport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            //Initialize Nodes and Connectors
            diagramcontrol.Nodes = new ObservableCollection<NodeViewModel>();
            diagramcontrol.Connectors = new ObservableCollection<ConnectorViewModel>();

            //To disable the ContextMenu
            diagramcontrol.Menu = null;

            //Initialize PageSettings and Constraints
            InitializeDiagram();

            //Create Node and Connection
            Ishikawadiagrammodel();
            
            //To Enable Zooming and Panning
            diagramcontrol.Tool = Tool.ZoomPan;     
            //diagramcontrol.Constraints=diagramcontrol.Constraints&~(GraphConstraints.Zoomable|GraphConstraints.Pannable);
        }

        private void InitializeDiagram()
        {
            diagramcontrol.DefaultConnectorType = ConnectorType.Line;
            diagramcontrol.PageSettings = null;
            //Draggable Constraints used to enable/disable the Dragging.
            diagramcontrol.Constraints = GraphConstraints.Default & ~(GraphConstraints.Selectable & GraphConstraints.Draggable);
        }

        //Create Node and Connection
        private void Ishikawadiagrammodel()
        {
            //Node Creation
            int height = 20;
            int width = 75;
            NodeViewModel n1 = AddNode(height, width, 60, 290, null);
            NodeViewModel n2 = AddNode2(height + 45, width + 75, 860, 290, "HIGH PETROL\nCONSUMPTION IN BIKE");
            TitleNode n3 = AddNode(height, width, 200, 70, "MACHINERY");
            TitleNode n4 = AddNode(height, width, 410, 70, "METHOD");
            TitleNode n5 = AddNode(height, width, 620, 70, "PEOPLE");
            TitleNode n6 = AddNode(height, width, 180, 510, "MATERIAL");
            TitleNode n7 = AddNode(height, width, 390, 510, "MEASUREMENT");
            TitleNode n8 = AddNode(height, width, 610, 510, "ENVIRONMENT");

            //Create lineconnector from node to node
            ConnectorViewModel line = addlineconnector(n1, n2, null, null, new Point(0, 0), "", new Thickness(0, 0, 0, 0));

            //Fixed a port in a lineconnector
            ConnectorPort p1 = addport(line, 0.25);
            ConnectorPort p2 = addport(line, 0.28);
            ConnectorPort p3 = addport(line, 0.58);
            ConnectorPort p4 = addport(line, 0.60);
            ConnectorPort p5 = addport(line, 0.90);
            ConnectorPort p6 = addport(line, 0.93);

            //Create lineconnector from Node to Port
            ConnectorViewModel c1 = addlineconnector(n3, null, p1, line, new Point(0, 0), "", new Thickness(0, 0, 0, 0));
            ConnectorViewModel c2 = addlineconnector(n6, null, p2, line, new Point(0, 0), "", new Thickness(0, 0, 0, 0));
            ConnectorViewModel c3 = addlineconnector(n4, null, p3, line, new Point(0, 0), "", new Thickness(0, 0, 0, 0));
            ConnectorViewModel c4 = addlineconnector(n7, null, p4, line, new Point(0, 0), "", new Thickness(0, 0, 0, 0));
            ConnectorViewModel c5 = addlineconnector(n5, null, p5, line, new Point(0, 0), "", new Thickness(0, 0, 0, 0));
            ConnectorViewModel c6 = addlineconnector(n8, null, p6, line, new Point(0, 0), "", new Thickness(0, 0, 0, 0));

            ConnectorPort m1 = addport(c1, 0.25);
            ConnectorViewModel mp1 = addlineconnector(null, null, m1, c1, new Point(70, 133), "Worn-out Pistons", new Thickness(50, 15, 0, 0));

            ConnectorPort m2 = addport(c1, 0.54);
            ConnectorViewModel mp2 = addlineconnector(null, null, m2, c1, new Point(80, 193), "Wrong Tire Pressure", new Thickness(55, 15, 0, 0));

            ConnectorPort m3 = addport(c3, 0.25);
            ConnectorViewModel mp3 = addlineconnector(null, null, m3, c3, new Point(305, 133), "Fast Driving", new Thickness(35, 15, 0, 0));

            ConnectorPort m4 = addport(c3, 0.54);
            ConnectorViewModel mp4 = addlineconnector(null, null, m4, c3, new Point(330, 193), "Wrong Gear", new Thickness(35, 15, 0, 0));

            ConnectorPort m5 = addport(c5, 0.55);
            ConnectorViewModel mp5 = addlineconnector(null, null, m5, c5, new Point(510, 193), "Maintenance Habit", new Thickness(50, 15, 0, 0));

            ConnectorPort m6 = addport(mp5, 0.77);
            ConnectorViewModel mp6 = addlineconnector(null, null, m6, mp5, new Point(600, 155), "No Owner Manual", new Thickness(0,0, 20, 10));

            ConnectorPort m7 = addport(c2, 0.73);
            ConnectorViewModel mp7 = addlineconnector(null, null, m7, c2, new Point(75, 345), "Poor Quality Petrol", new Thickness(50, 15, 0, 0));

            ConnectorPort m8 = addport(c2, 0.26);
            ConnectorViewModel mp8 = addlineconnector(null, null, m8, c2, new Point(70, 443), "Incorrect Lubricant", new Thickness(50, 15, 0, 0));

            ConnectorPort m9 = addport(mp8, 0.73);
            ConnectorViewModel mp9 = addlineconnector(null, null, m9, mp4, new Point(145, 410), "Wrong Oil", new Thickness(0, 0, 10, 10));

            ConnectorPort m10 = addport(c4, 0.6);
            ConnectorViewModel mp10 = addlineconnector(null, null, m10, c4, new Point(300, 373), "Do not Reset\nOdometer Properly", new Thickness(50, 25, 0, 0));

            ConnectorPort m11 = addport(c6, 0.6);
            ConnectorViewModel mp11 = addlineconnector(null, null, m11, c6, new Point(520, 373), "Extreme Weather\nConditions", new Thickness(45, 25, 0, 0));
        }

        //Add ConnectorPort
        private ConnectorPort addport(ConnectorViewModel line, double length)
        {
            ConnectorPort port = new ConnectorPort()
            {
                Width = 10,
                Height = 10,
                Length = length,
                Connector = line,
                Shape = new EllipseGeometry() { RadiusX = 5, RadiusY = 5 },
                PortVisibility = PortVisibility.Visible,
                ShapeStyle = this.Resources["style"] as Style,
                Constraints = PortConstraints.Default & ~PortConstraints.Inherit
            };
            (line.Ports as ICollection<IConnectorPort>).Add(port);
            return port;
        }

        //Add lineConnector 
        private ConnectorViewModel addlineconnector(NodeViewModel headnode, NodeViewModel tailnode, ConnectorPort port, ConnectorViewModel connect, Point sourcepoint, string label, Thickness margin)
        {
            ConnectorViewModel line = new ConnectorViewModel();
            line.TargetDecoratorStyle = this.Resources["DecoratorStyle"] as Style;
            line.Ports = new ObservableCollection<IConnectorPort>();
            //To Represent Annotation Properties
            line.Annotations = new ObservableCollection<IAnnotation>()
            {
                new AnnotationEditorViewModel()
                {
                    Content = label,
                    ViewTemplate = Application.Current.MainWindow.Resources["viewtemplate"] as DataTemplate,
                    Length=0,
                    Margin = margin,
                    WrapText = TextWrapping.NoWrap,
                    ReadOnly = true,
                    RotationReference= RotationReference.Page
                }
            };

            if (tailnode == null)
            {
                if (!Point.Equals(sourcepoint, new Point(0, 0)))
                {
                    line.SourcePoint = sourcepoint;
                }
                else
                {
                    line.SourceNode = headnode;
                }
                //Set ConnectorViewModel Style
                line.ConnectorGeometryStyle = this.Resources["style1"] as Style;
                line.TargetPort = port;
                line.TargetConnector = connect;
            }
            else
            {
                line.ConnectorGeometryStyle = this.Resources["connectorstyle"] as Style;
                line.SourceNode = headnode;
                line.TargetNode = tailnode;
                line.TargetConnector = connect;
            }

            (diagramcontrol.Connectors as ICollection<ConnectorViewModel>).Add(line);

            //Selectable Constraints used to enable/disable the ConnectorViewModel Selection.
            line.Constraints = line.Constraints & ~ConnectorConstraints.Selectable;
            return line;
        }

        //Add TextNodes
        private NodeViewModel AddNode2(double height, double width, double offx, double offy, string label)
        {
            NodeViewModel n = new NodeViewModel();
            n.UnitHeight = height;
            n.UnitWidth = width;
            n.OffsetX = offx;
            n.OffsetY = offy;
            n.ShapeStyle = this.Resources["nvmstyle"] as Style;
            n.Constraints = n.Constraints & ~NodeConstraints.Selectable;

            //To Represent Annotation Properties
            n.Annotations = new ObservableCollection<IAnnotation>()
            {
                new AnnotationEditorViewModel()
                {
                    Content =label,
                    ReadOnly=true,
                    ViewTemplate=this.Resources["viewtemplate2"] as DataTemplate,
                    EditTemplate=this.Resources["edittemplate"] as DataTemplate
                }  
            };
            (diagramcontrol.Nodes as ICollection<NodeViewModel>).Add(n);
            return n;
        }

        //Add TitleNodes
        private TitleNode AddNode(double height, double width, double offx, double offy, string label)
        {
            TitleNode n = new TitleNode();

            n.Label = label;
            n.UnitHeight = height;
            n.UnitWidth = width;
            n.OffsetX = offx;
            n.OffsetY = offy;
            //Selectable Constraints used to enable/disable the Node Selection. 
            n.Constraints = n.Constraints & ~NodeConstraints.Selectable;
            (diagramcontrol.Nodes as ICollection<NodeViewModel>).Add(n);
            return n;
        }

    }

    //Create TitleNode Class
    public class TitleNode : NodeViewModel
    {
        public TitleNode()
        {
            //To Represent Annotation Property
            this.Annotations = new ObservableCollection<IAnnotation>();
            //Add Annotation to TitleNode
            AnnotationEditorViewModel title = new AnnotationEditorViewModel()
            {
                WrapText = TextWrapping.NoWrap,
                TextVerticalAlignment = System.Windows.VerticalAlignment.Bottom,
                ReadOnly = true,
                //Set Annotation Template to Node
                ViewTemplate = Application.Current.MainWindow.Resources["viewtemplate1"] as DataTemplate,
                EditTemplate = Application.Current.MainWindow.Resources["edittemplate"] as DataTemplate
            };
            (this.Annotations as ICollection<IAnnotation>).Add(title);

        }


        //Create Label property for TitleNode
        private string _mlabel = string.Empty;
        public string Label
        {
            get
            {
                return _mlabel;
            }
            set
            {
                if (_mlabel != value)
                {
                    _mlabel = value;
                    OnPropertyChanged("Label");
                    AnnotationEditorViewModel vm = (this.Annotations as ICollection<IAnnotation>).ToList()[0] as AnnotationEditorViewModel;
                    vm.Content = _mlabel;
                }

            }
        }
    }

    //Create TextNode Class 
    public class TextNode : NodeViewModel
    {
        public TextNode()
        {
            this.Annotations = new ObservableCollection<IAnnotation>();

            //Add Annotation to TitleNode
            AnnotationEditorViewModel title = new AnnotationEditorViewModel()
            {
                Content = Label1,
                ViewTemplate = Application.Current.MainWindow.Resources["viewtemplate"] as DataTemplate,
                EditTemplate = Application.Current.MainWindow.Resources["edittemplate"] as DataTemplate
            };
            (this.Annotations as ICollection<IAnnotation>).Add(title);

        }

        //Create Label1 property for TextNode
        private string _label = string.Empty;
        public string Label1
        {
            get
            {
                return _label;
            }
            set
            {
                if (_label != value)
                {
                    _label = value;
                    OnPropertyChanged("Label1");
                    AnnotationEditorViewModel vm = (this.Annotations as ICollection<IAnnotation>).ToList()[0] as AnnotationEditorViewModel;
                    vm.Content = _label;

                }

            }
        }

    }

}
