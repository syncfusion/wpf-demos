#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Office;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class LineRoutingVM: DiagramViewModel
    {

        private Rect currentViewPort = Rect.Empty;

        //Initializes new resource dictionary.
        ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/Syncfusion.SfDiagram.Wpf;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
        };

        /// <summary>
        /// Initializes a new constructor for <see cref="LineRoutingVM"/> class.
        /// </summary>
        public LineRoutingVM()
        {
            //Initialize the nodes and connectors collection
            this.Nodes = new ObservableCollection<RoutingNodeViewModel>();
            this.Connectors = new ObservableCollection<ConnectorViewModel>();

            //Enable bridging and routing constraints.
            this.Constraints = GraphConstraints.Default | GraphConstraints.Bridging | GraphConstraints.Routing;

            //Initialize the command to bring the elements to the center of the page.
            ViewPortChangedCommand = new DelegateCommand(OnViewPortChangedCommandExecute);

            //Create and add nodes
            RoutingNodeViewModel start = CreateNodes("start", 115, 110, "Start", "#D5535D", "Terminator");
            RoutingNodeViewModel process = CreateNodes("process", 115, 255, "Process", "#65B091", "Process");
            RoutingNodeViewModel document = CreateNodes("document", 115, 400, "Document", "#5BA5F0", "Document");
            RoutingNodeViewModel decision = CreateNodes("decision", 390, 110, "Decision", "#9A8AF7", "Decision");
            RoutingNodeViewModel document2 = CreateNodes("document2", 390, 255, "Document", "#5BA5F0", "Document");
            RoutingNodeViewModel end = CreateNodes("end", 390, 400, "End", "#D5535D", "Terminator");
            RoutingNodeViewModel process2 = CreateNodes("process2", 640, 110, "Process", "#65B091", "Process");
            RoutingNodeViewModel card = CreateNodes("card", 640, 255, "Card", "#76C3F0", "Card");

            //Add Node to Nodes property of the Diagram
            (this.Nodes as ObservableCollection<RoutingNodeViewModel>).Add(start);
            (this.Nodes as ObservableCollection<RoutingNodeViewModel>).Add(process);
            (this.Nodes as ObservableCollection<RoutingNodeViewModel>).Add(document);
            (this.Nodes as ObservableCollection<RoutingNodeViewModel>).Add(decision);
            (this.Nodes as ObservableCollection<RoutingNodeViewModel>).Add(document2);
            (this.Nodes as ObservableCollection<RoutingNodeViewModel>).Add(end);
            (this.Nodes as ObservableCollection<RoutingNodeViewModel>).Add(process2);
            (this.Nodes as ObservableCollection<RoutingNodeViewModel>).Add(card);

            CreateNodePort(start, "startPort1", 0, 0.5);
            CreateNodePort(document, "documentPort1", 0, 0.5);
            CreateNodePort(card, "cardPort1", 1, 0.5);
            CreateNodePort(card, "cardPort2", 0.5, 1);

            //Create and add connectors
            CreateConnectors("start", "process", null, null);
            CreateConnectors("process", "document", null, null);
            CreateConnectors("document", "end", null, null);
            CreateConnectors("start", "decision", null, null);
            CreateConnectors("decision", "process2", null, null);
            CreateConnectors("process2", "card", null, null);
            CreateConnectors("process", "document2", null, null);
            CreateConnectors("document2", "card", null, null);
            CreateConnectors("start", "card", "startPort1", "cardPort1");
            CreateConnectors("card", "document", "cardPort2", "documentPort1");
        }

        /// <summary>
        /// Create and add the nodes.
        /// </summary>
        /// <param name="id">ID of the Node</param>
        /// <param name="offsetx">Offset-x value of the node.</param>
        /// <param name="offsety">Offset-y value of the node.</param>
        /// <param name="text">Text to the node.</param>
        private RoutingNodeViewModel CreateNodes(string id, double offsetx, double offsety, string text, string fillColor, string shape )
        {
            RoutingNodeViewModel node = new RoutingNodeViewModel()
            {
                ID = id,
                UnitHeight = 50,
                UnitWidth = 120,
                OffsetX = offsetx,
                OffsetY = offsety,
                Shape = resourceDictionary[shape],
                Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(fillColor)),
                Annotations = new ObservableCollection<IAnnotation>()
                {
                    new TextAnnotationViewModel()
                    {
                        Text = text,
                        FontSize = 15,
                        Foreground = new SolidColorBrush(Colors.White),
                    }
                },
            };

            return node;
           
        }

        /// <summary>
        /// To create the connector.
        /// </summary>
        /// <param name="sourceNode">Source node of the connector</param>
        /// <param name="targetNode">Target node of the connector.</param>
        /// <param name="text">Text to the connector.</param>
        /// <param name="sourcePort">Source port of the connector</param>
        /// <param name="targetPort">Target port of the connector</param>
        /// <returns></returns>
        private void CreateConnectors(string sourceNode, string targetNode, string sourcePortID, string targetPortID)
        {
            ConnectorViewModel connector = new ConnectorViewModel()
            {
                SourceNodeID = sourceNode,
                TargetNodeID = targetNode,
                SourcePortID = sourcePortID,
                TargetPortID = targetPortID,
            };

            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector);
        }

        /// <summary>
        /// Method to create NodePort
        /// </summary>
        /// <param name="node1">Parent for the created nodeport</param>
        /// <param name="id">NodePort ID</param>
        /// <param name="nodeoffsetx">NodePort's OffsetX</param>
        /// <param name="nodeoffsety">NodePort's OffsetY</param>
        /// <param name="porttype">Port Type</param>
        private void CreateNodePort(NodeViewModel node1, string id, double nodeoffsetx, double nodeoffsety)
        {
            NodePortViewModel nodePort = new NodePortViewModel()
            {
                ID = id,
                NodeOffsetX = nodeoffsetx,
                NodeOffsetY = nodeoffsety,
                Shape = resourceDictionary["Ellipse"],
                Constraints = PortConstraints.Default & ~PortConstraints.InheritPortVisibility,
                PortVisibility = PortVisibility.Collapse,
            };
            (node1.Ports as PortCollection).Add(nodePort);
        }

        /// <summary>
        /// Command to bring the diagram elemnts to center of the view port
        /// </summary>
        /// <param name="parameter">ViewPortChangedEventArgs</param>
        private void OnViewPortChangedCommandExecute(object parameter)
        {
            var args = parameter as ChangeEventArgs<object, ScrollChanged>;
            if (Info != null && (args.Item as SfDiagram).IsLoaded == true && args.NewValue.ContentBounds != currentViewPort)
            {
                (Info as IGraphInfo).BringIntoCenter(args.NewValue.ContentBounds);
            }

            currentViewPort = args.NewValue.ContentBounds;
        }
    }

    /// <summary>
    /// Create the custom node view model class of the <see cref="NodeViewModel"/> class.
    /// </summary>
    public class RoutingNodeViewModel : NodeViewModel
    {
        //To hold the fill color of the nodes.
        private Brush fill = new SolidColorBrush(Colors.Black);

        /// <summary>
        /// Gets or sets the fill color to the nodes.
        /// </summary>
        public Brush Fill
        {
            get
            {
                return fill;
            }
            set
            {
                if (fill != value)
                {
                    fill = value;
                    OnPropertyChanged("Fill");
                    OnFillChanged();
                }
            }
        }

        #region Methods

        /// <summary>
        /// Updates the fill color, stroke color, stroke thickness, stroke dash values to the nodes.
        /// </summary>
        private void OnFillChanged()
        {
            Style s = new Style(typeof(Path));
            if (Fill != null)
            {
                s.Setters.Add(new Setter(Path.FillProperty, Fill));
                //s.Setters.Add(new Setter(Path.StrokeThicknessProperty, 1));
                s.Setters.Add(new Setter(Path.StretchProperty, Stretch.Fill));
                s.Setters.Add(new Setter(Path.StrokeProperty, Fill));
            }
            ShapeStyle = s;
        }

        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);

            switch (name)
            {
                case "Fill":
                    OnFillChanged();
                    break;
            }
        }
        #endregion
    }
}
