#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snapping
{
    /// <summary>
    /// Represents the class to view model of <see cref="SfDiagram"/>
    /// </summary>
    public class SnappingViewModel : DiagramViewModel
    {
        #region  Fields

        //Holds the snap interval value
        private object snapIntervalChanged = "20";
        //Holds the stroke color of the snap indicator line
        private Brush strokecolor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#83F6F0"));
        //Holds the stroke thickness of the snap indicator line
        private double strokethickness = 2;
        //Holds the snapping angle value
        private object snapAngleChanged = "5";
        //Holds the snap to object value
        private SnapToObject snaptoObject = SnapToObject.All;

        //Holds nodes and connectors instances
        NodeViewModel node1;
        NodeViewModel node2;
        NodeViewModel node3;
        NodeViewModel node4;
        ConnectorViewModel connector1;

        //Holds commands to show or hide the gridlines
        public ICommand ShowGridlinesCommand { get; set; }
        //Holds commands to enable or disable snapping on gridlines
        public ICommand SnappingToGridlinesCommand { get; set; }

        //Gets or sets the snap interval value.
        public object SnapIntervalChanged
        {
            get
            {
                return snapIntervalChanged;
            }

            set
            {
                if (value != snapIntervalChanged)
                {
                    snapIntervalChanged = value;
                    OnPropertyChanged("SnapIntervalChanged");
                    this.OnSnapIntervalChanged(snapIntervalChanged);
                }
            }
        }

        /// <summary>
        /// Gets or sets the Strokecolor snap indicator lines
        /// </summary>
        public Brush Strokecolor
        {
            get
            {
                return strokecolor;
            }

            set
            {
                if (strokecolor != value)
                {
                    strokecolor = value;
                    OnPropertyChanged("Strokecolor");
                    OnStrokeColorChanged(strokecolor);
                }
            }
        }

        /// <summary>
        /// Gets or sets the Strokethickness snap indicator lines
        /// </summary>
        public double Strokethickness
        {
            get
            {
                return strokethickness;
            }

            set
            {
                if (strokethickness != value)
                {
                    strokethickness = value;
                    OnPropertyChanged("Strokethickness");
                    OnStrokeThicknessChanged(strokethickness);
                }
            }
        }

        /// <summary>
        /// Gets or sets the snap angle value.
        /// </summary>
        public object SnapAngleChanged
        {
            get
            {
                return snapAngleChanged;
            }

            set
            {
                if (value != snapAngleChanged)
                {
                    snapAngleChanged = value;
                    OnPropertyChanged("SnapAngleChanged");
                    this.OnSnapAngleChanged(snapAngleChanged);
                }
            }
        }

        /// <summary>
        /// Gets ore sets the snap to object value of snapping
        /// </summary>
        public SnapToObject SnapToObjectValue
        {
            get
            {
                return snaptoObject;
            }

            set
            {
                if (value != snaptoObject)
                {
                    snaptoObject = value;
                    OnPropertyChanged("SnapAngleChanged");
                    this.OnSnapToObjectChanged(snaptoObject);
                }
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes the new instance of <see cref="SnappingViewModel"/> class.
        /// </summary>
        public SnappingViewModel()
        {
            //Intialize the nodes and connectors collection
            this.Nodes = new NodeCollection();
            this.Connectors = new ConnectorCollection();

            //Initialize the horizontal ruler
            this.HorizontalRuler = new Syncfusion.UI.Xaml.Diagram.Controls.Ruler()
            {
                Orientation = Orientation.Horizontal,
            };

            //Initialize the vertical ruler
            this.VerticalRuler = new Syncfusion.UI.Xaml.Diagram.Controls.Ruler()
            {
                Orientation = Orientation.Vertical,
            };

            //Initialize the snap settings class.
            this.SnapSettings = new SnapSettings()
            {
                SnapConstraints = SnapConstraints.All,
                SnapToObject = SnapToObject.All,
            };

            //Enable the ports visibility
            this.PortVisibility = PortVisibility.Collapse;

            //Initialize the selector view model and disbale the quick coammnds.
            this.SelectedItems = new SelectorViewModel();
            (this.SelectedItems as SelectorViewModel).SelectorConstraints &= ~(SelectorConstraints.QuickCommands);
            //Initialize the command to show gridlines and enable the snapping on gridlines 
            ShowGridlinesCommand = new Command(OnShowGridlinesCommandExecute);
            SnappingToGridlinesCommand = new Command(OnSnappingCommandExecute);

            #region Nodes

            node1 = CreateNodes(350, 250, 100, 100, "Shape 1", "Rectangle");
            node2 = CreateNodes(650, 250, 100, 100, "Shape 2", "Rectangle");
            node3 = CreateNodes(500, 400, 100, 100, "Shape 3", "Rectangle");
            node4 = CreateNodeforLabel("Rectangle", "");
            (this.Nodes as NodeCollection).Add(node1);
            (this.Nodes as NodeCollection).Add(node2);
            (this.Nodes as NodeCollection).Add(node3);
            (this.Nodes as NodeCollection).Add(node4);
            CreateNodePorts(node1);
            CreateNodePorts(node2);
            connector1 = CreateConnectors(node1, node3);
            DockPortViewModel dockPort = new DockPortViewModel()
            {
                SourcePoint = new Point(0, 0),
                TargetPoint = new Point(0, 1),
            };
            dockPort.Constraints &= ~PortConstraints.InheritHitPadding;
            dockPort.HitPadding = 20;
            (node2.Ports as PortCollection).Add(dockPort);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector1);
            this.PortVisibility = PortVisibility.Visible;
            (this.SelectedItems as SelectorViewModel).SelectorConstraints |= (SelectorConstraints.QuickCommands);
            #endregion
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// To create the node for lable to update the guidlines for  snap to object values
        /// </summary>
        /// <param name="shape">Shape of the node.</param>
        /// <param name="label">Content of the node.</param>
        /// <returns></returns>
        private NodeViewModel CreateNodeforLabel(string shape, string label)
        {
            NodeViewModel node = new NodeViewModel()
            {
                UnitHeight = 60,
                UnitWidth = 700,
                OffsetY = 100,
                Constraints = NodeConstraints.Default & ~NodeConstraints.Selectable & ~NodeConstraints.ThemeStyle,
                Shape = App.Current.Resources[shape],
                OffsetX = 480,
                ShapeStyle = App.Current.Resources["NodeStyle"] as Style,
                Annotations = new ObservableCollection<IAnnotation>()
                {
                    new TextAnnotationViewModel()
                    {
                        Text = "",
                        FontSize = 24,
                        Foreground = new SolidColorBrush(Colors.Black),
                        TextWrapping = TextWrapping.Wrap,
                        FontFamily= new FontFamily("Segoe UI"),
                    }
                }
            };

            node.Constraints  &= ~(NodeConstraints.InheritSnapToObject| NodeConstraints.InheritSnapping);
            node.SnapToObject = SnapToObject.None;
            return node;
        }

        /// <summary>
        /// Updating content of the lable node when snap to object value is changed.
        /// </summary>
        /// <param name="content">New content to update in the label node</param>
        private void ChangeInstructions(string content)
        {
            node4.Annotations = new ObservableCollection<IAnnotation>()
            {
                new TextAnnotationViewModel()
                {
                    Text = content,
                    FontSize = 24,
                    Foreground = new SolidColorBrush(Colors.Black),
                    TextWrapping = TextWrapping.Wrap,
                    FontFamily = new FontFamily("Segoe UI"),
                }
            };
        }

        /// <summary>
        /// TO create the node.
        /// </summary>
        /// <param name="offsetx">offset-x value of the node.</param>
        /// <param name="offsety">offset-y value of the node.</param>
        /// <param name="unitWidth">Width of the nodes.</param>
        /// <param name="unitHeight">Height of the node.</param>
        /// <param name="text">Text to be displayed in the node.</param>
        /// <param name="shape">Shape of the node.</param>
        /// <returns></returns>
        private NodeViewModel CreateNodes(double offsetx, double offsety, double unitWidth, double unitHeight, string text, string shape)
        {
            NodeViewModel node = new NodeViewModel()
            {
                UnitWidth = unitWidth,
                UnitHeight = unitHeight,
                OffsetX = offsetx,
                OffsetY = offsety,
                Shape = App.Current.Resources[shape],
                ShapeStyle = App.Current.Resources["DefaultStyle"] as Style,
                Annotations = new ObservableCollection<IAnnotation>()
                {
                    new TextAnnotationViewModel()
                    {
                        Text = text,
                        FontSize = 13,
                        Foreground = new SolidColorBrush(Colors.Black),
                        TextWrapping = TextWrapping.Wrap,
                        Offset = new Point(0.5,1),
                        Margin = new Thickness(0,10,0,0),
                        FontWeight = FontWeights.Bold,
                    }
                }
            };

            return node;
        }

        /// <summary>
        /// To create the connectors.
        /// </summary>
        /// <param name="sourceNode">Source node to the connector.</param>
        /// <param name="targetNode">Target node to the connector.</param>
        /// <returns></returns>
        private ConnectorViewModel CreateConnectors(NodeViewModel sourceNode, NodeViewModel targetNode)
        {
            ConnectorViewModel connector = new ConnectorViewModel()
            {
                SourceNode = sourceNode,
                TargetNode = targetNode,
            };

            return connector;
        }

        /// <summary>
        /// To show or hide the gridlines on the diagrma page.
        /// </summary>
        /// <param name="parameter">Boolean command to change the grid lines visibility.</param>
        private void OnShowGridlinesCommandExecute(object parameter)
        {
            if (this != null)
            {
                if ((bool)parameter)
                {
                    this.SnapSettings.SnapConstraints |= SnapConstraints.ShowLines;
                }
                else
                {
                    this.SnapSettings.SnapConstraints &= ~SnapConstraints.ShowLines;
                }
            }
        }

        /// <summary>
        /// To enable or disable the snapping on gridlines.
        /// </summary>
        /// <param name="parameter">Boolean command to enable or disable the snapping on gridlines.</param>
        private void OnSnappingCommandExecute(object parameter)
        {
            if (this != null)
            {
                if ((bool)parameter)
                {
                    this.SnapSettings.SnapConstraints |= SnapConstraints.SnapToLines;
                }
                else
                {
                    this.SnapSettings.SnapConstraints &= ~SnapConstraints.SnapToLines;
                }
            }
        }

        /// <summary>
        /// To change the snap interval.
        /// </summary>
        /// <param name="sizechanged">Snap interval value.</param>
        private void OnSnapIntervalChanged(object sizechanged)
        {
            double value = double.Parse(sizechanged.ToString());
            if (this.SnapSettings != null)
            {
                this.SnapSettings.HorizontalGridlines.SnapInterval = new List<double>() { value };
                this.SnapSettings.VerticalGridlines.SnapInterval = new List<double>() { value };
            }
        }

        /// <summary>
        /// To change the snap angle.
        /// </summary>
        /// <param name="sizechanged">Snap angle value.</param>
        private void OnSnapAngleChanged(object sizechanged)
        {
            double value = double.Parse(sizechanged.ToString());
            if (this.SnapSettings != null)
            {
                this.SnapSettings.SnapAngle = value;
            }
        }

        /// <summary>
        /// Create the node ports
        /// </summary>
        /// <param name="node">A node to create the node port.</param>
        private void CreateNodePorts(NodeViewModel node)
        {
            node.Ports = new PortCollection()
            {
                new NodePortViewModel()
                {
                    NodeOffsetX = 0.5,
                    NodeOffsetY = 0.5,
                }
            };
        }

        /// <summary>
        /// To change the snap to object value and updates the lable node content with repective to snapto object value to guide the interaction.
        /// </summary>
        /// <param name="snaptoObjectvalues">SnapToObject value.</param>
        private void OnSnapToObjectChanged(SnapToObject snaptoObjectvalues)
        {
            if (this.SnapSettings != null)
            {
                this.SnapSettings.SnapToObject = snaptoObjectvalues;
            }

            this.Nodes = null;
            this.Connectors = null;

            this.Nodes = new NodeCollection();
            (this.Nodes as ObservableCollection<NodeViewModel>).Add(node4);
            this.Connectors = new ConnectorCollection();
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Remove(connector1);
            this.PortVisibility = PortVisibility.Collapse;
            ChangeInstructions("");

            (this.SelectedItems as SelectorViewModel).SelectorConstraints &= ~(SelectorConstraints.QuickCommands);

            if (this.SnapSettings.SnapToObject == SnapToObject.All)
            {
                node1 = CreateNodes(350, 250, 100, 100, "Shape 1", "Rectangle");
                node2 = CreateNodes(650, 250, 100, 100, "Shape 2", "Rectangle");
                node3 = CreateNodes(500, 400, 100, 100, "Shape 3", "Rectangle");
                (this.Nodes as NodeCollection).Add(node1);
                (this.Nodes as NodeCollection).Add(node2);
                (this.Nodes as NodeCollection).Add(node3);
                CreateNodePorts(node1);
                CreateNodePorts(node2);
                connector1 = CreateConnectors(node1, node3);
                DockPortViewModel dockPort = new DockPortViewModel()
                {
                    SourcePoint = new Point(0, 0),
                    TargetPoint = new Point(0, 1),
                };
                dockPort.Constraints &= ~PortConstraints.InheritHitPadding;
                dockPort.HitPadding = 20;
                (node2.Ports as PortCollection).Add(dockPort);
                (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector1);
                this.PortVisibility = PortVisibility.Visible;
                (this.SelectedItems as SelectorViewModel).SelectorConstraints |= (SelectorConstraints.QuickCommands);
                ChangeInstructions("");
            }
            else if (this.SnapSettings.SnapToObject == SnapToObject.Bottom)
            {
                node1 = CreateNodes(350, 400, 100, 100, "Shape 1", "Rectangle");
                node2 = CreateNodes(650, 250, 100, 100, "Shape 2", "Rectangle");
                (this.Nodes as NodeCollection).Add(node1);
                (this.Nodes as NodeCollection).Add(node2);
                node2.IsSelected = true;
                ChangeInstructions("Drag the Shape 2 vertically down");
            }
            else if (this.SnapSettings.SnapToObject == SnapToObject.BottomBottom)
            {
                node1 = CreateNodes(350, 350, 100, 100, "Shape 1", "Rectangle");
                node2 = CreateNodes(650, 250, 100, 100, "Shape 2", "Rectangle");
                (this.Nodes as NodeCollection).Add(node1);
                (this.Nodes as NodeCollection).Add(node2);
                node2.IsSelected = true;
                ChangeInstructions("Drag the Shape 2 vertically down");
            }
            else if (this.SnapSettings.SnapToObject == SnapToObject.BottomTop)
            {
                node1 = CreateNodes(350, 400, 100, 100, "Shape 1", "Rectangle");
                node2 = CreateNodes(650, 250, 100, 100, "Shape 2", "Rectangle");
                (this.Nodes as NodeCollection).Add(node1);
                (this.Nodes as NodeCollection).Add(node2);
                node2.IsSelected = true;
                ChangeInstructions("Drag the Shape 2 vertically down");
            }
            else if (this.SnapSettings.SnapToObject == SnapToObject.Height)
            {
                node1 = CreateNodes(350, 350, 100, 100, "Shape 1", "Rectangle");
                node2 = CreateNodes(650, 320, 100, 40, "Shape 2", "Rectangle");
                (this.Nodes as NodeCollection).Add(node1);
                (this.Nodes as NodeCollection).Add(node2);
                node2.IsSelected = true;
                ChangeInstructions("Increase the Height of the Shape 2");
            }
            else if (this.SnapSettings.SnapToObject == SnapToObject.HorizontalCenter)
            {
                node1 = CreateNodes(350, 250, 100, 100, "Shape 1", "Rectangle");
                node2 = CreateNodes(650, 250, 100, 100, "Shape 2", "Rectangle");
                (this.Nodes as NodeCollection).Add(node1);
                (this.Nodes as NodeCollection).Add(node2);
                node2.IsSelected = true;
                ChangeInstructions("Drag the Shape2 horizontally");
            }
            else if (this.SnapSettings.SnapToObject == SnapToObject.HorizontalSpacing)
            {
                node1 = CreateNodes(350, 250, 100, 100, "Shape 1", "Rectangle");
                node2 = CreateNodes(650, 250, 100, 100, "Shape 2", "Rectangle");
                node3 = CreateNodes(500, 400, 100, 100, "Shape 3", "Rectangle");
                (this.Nodes as NodeCollection).Add(node1);
                (this.Nodes as NodeCollection).Add(node2);
                (this.Nodes as NodeCollection).Add(node3);
                node3.IsSelected = true;
                ChangeInstructions("Drag the shape 3 in-between shapes 1 & 2");
            }
            else if (this.SnapSettings.SnapToObject == SnapToObject.Left || this.SnapSettings.SnapToObject == SnapToObject.LeftLeft
                || this.SnapSettings.SnapToObject == SnapToObject.LeftRight)
            {
                node1 = CreateNodes(350, 250, 100, 100, "Shape 1", "Rectangle");
                node2 = CreateNodes(250, 450, 100, 100, "Shape 2", "Rectangle");
                (this.Nodes as NodeCollection).Add(node1);
                (this.Nodes as NodeCollection).Add(node2);
                node2.IsSelected = true;
                ChangeInstructions("Drag the Shape 2 horizontally right");
            }
            else if (this.SnapSettings.SnapToObject == SnapToObject.Port)
            {
                this.PortVisibility = PortVisibility.Visible;
                node1 = CreateNodes(350, 250, 100, 100, "Shape 1", "Rectangle");
                CreateNodePorts(node1);
                node2 = CreateNodes(650, 250, 100, 100, "Shape 2", "Rectangle");
                CreateNodePorts(node2);
                (this.Nodes as NodeCollection).Add(node1);
                (this.Nodes as NodeCollection).Add(node2);
                node2.IsSelected = true;
                ChangeInstructions("Drag the Shape 2 horizontally");
            }
            else if (this.SnapSettings.SnapToObject == SnapToObject.Right || this.SnapSettings.SnapToObject == SnapToObject.RightLeft
                || this.SnapSettings.SnapToObject == SnapToObject.RightRight)
            {
                node1 = CreateNodes(350, 250, 100, 100, "Shape 1", "Rectangle");
                node2 = CreateNodes(200, 450, 100, 100, "Shape 2", "Rectangle");
                (this.Nodes as NodeCollection).Add(node1);
                (this.Nodes as NodeCollection).Add(node2);
                node2.IsSelected = true;
                ChangeInstructions("Drag the Shape 2 horizontally right");
            }
            else if (this.SnapSettings.SnapToObject == SnapToObject.Segment)
            {
                node1 = CreateNodes(350, 250, 100, 100, "Shape 1", "Rectangle");
                node2 = CreateNodes(550, 250, 100, 100, "Shape 2", "Rectangle");
                (this.Nodes as NodeCollection).Add(node1);
                this.PortVisibility = PortVisibility.Visible;
                DockPortViewModel dockPort = new DockPortViewModel()
                {
                    SourcePoint = new Point(0, 0),
                    TargetPoint = new Point(0, 1),
                };
                dockPort.Constraints &= ~PortConstraints.InheritHitPadding;
                dockPort.HitPadding = 20;
                (node2.Ports as PortCollection).Add(dockPort);
                node1.IsSelected = true;
                (this.Nodes as NodeCollection).Add(node2);
                ChangeInstructions("Draw a connector from Shape 1 to Dock port of shape 2");
                (this.SelectedItems as SelectorViewModel).SelectorConstraints |= (SelectorConstraints.QuickCommands);
            }
            else if (this.SnapSettings.SnapToObject == SnapToObject.Size)
            {
                node1 = CreateNodes(350, 250, 100, 100, "Shape 1", "Rectangle");
                (this.Nodes as NodeCollection).Add(node1);
                node2 = CreateNodes(650, 250, 100, 100, "Shape 2", "Rectangle");
                (this.Nodes as NodeCollection).Add(node2);
                node3 = CreateNodes(500, 400, 60, 60, "Shape 3", "Rectangle");
                (this.Nodes as NodeCollection).Add(node3);
                node3.IsSelected = true;
                ChangeInstructions("Resize the Shape 3");
            }
            else if (this.SnapSettings.SnapToObject == SnapToObject.Top || this.SnapSettings.SnapToObject == SnapToObject.TopBottom
                || this.SnapSettings.SnapToObject == SnapToObject.TopTop)
            {
                node1 = CreateNodes(350, 250, 100, 100, "Shape 1", "Rectangle");
                (this.Nodes as NodeCollection).Add(node1);
                node2 = CreateNodes(650, 450, 100, 100, "Shape 2", "Rectangle");
                (this.Nodes as NodeCollection).Add(node2);
                node2.IsSelected = true;
                ChangeInstructions("Drag the Shape 2 vertically up");
            }
            else if (this.SnapSettings.SnapToObject == SnapToObject.VerticalCenter)
            {
                node1 = CreateNodes(350, 250, 100, 100, "Shape 1", "Rectangle");
                (this.Nodes as NodeCollection).Add(node1);
                node2 = CreateNodes(350, 500, 100, 100, "Shape 2", "Rectangle");
                (this.Nodes as NodeCollection).Add(node2);
                node2.IsSelected = true;
                ChangeInstructions("Drag the Shape 2 vertically");
            }
            else if (this.SnapSettings.SnapToObject == SnapToObject.VerticalSpacing)
            {
                node1 = CreateNodes(350, 190, 100, 100, "Shape 1", "Rectangle");
                (this.Nodes as NodeCollection).Add(node1);
                node2 = CreateNodes(350, 510, 100, 100, "Shape 3", "Rectangle");
                (this.Nodes as NodeCollection).Add(node2);
                node3 = CreateNodes(550, 350, 100, 100, "Shape 2", "Rectangle");
                (this.Nodes as NodeCollection).Add(node3);
                node3.IsSelected = true;
                ChangeInstructions("Drag the Shape 2 in-between Shape 1 & 3");
            }
            else if (this.SnapSettings.SnapToObject == SnapToObject.Width)
            {
                node1 = CreateNodes(350, 250, 100, 100, "Shape 1", "Rectangle");
                (this.Nodes as NodeCollection).Add(node1);
                node2 = CreateNodes(650, 250, 100, 100, "Shape 2", "Rectangle");
                (this.Nodes as NodeCollection).Add(node2);
                node3 = CreateNodes(500, 400, 60, 100, "Shape 3", "Rectangle");
                (this.Nodes as NodeCollection).Add(node3);
                node3.IsSelected = true;
                ChangeInstructions("Increase the width of Shape 3");
            }
        }

        /// <summary>
        /// Method to change the stroke color of snap line
        /// </summary>
        /// <param name="strokecolor">color of the stroke.</param>
        private void OnStrokeColorChanged(Brush strokecolor)
        {
            Brush value = strokecolor;
            Style pathStyle = new Style(typeof(Shape));
            double thickness = double.Parse(Strokethickness.ToString());
            pathStyle.Setters.Add(new Setter(Shape.StrokeThicknessProperty, thickness));
            pathStyle.Setters.Add(new Setter(Shape.StrokeProperty, value));
            if (this.SnapSettings != null)
            {
                this.SnapSettings.SnapIndicatorStyle = pathStyle as Style;
            }
            pathStyle = null;
        }

        /// <summary>
        /// Method to change the strokethickness of snaplines
        /// </summary>
        /// <param name="strokethickness">Stroke thickness value.</param>
        private void OnStrokeThicknessChanged(double strokethickness)
        {
            double value = double.Parse(strokethickness.ToString());
            Style pathStyle = new Style(typeof(Shape));
            pathStyle.Setters.Add(new Setter(Shape.StrokeProperty, Strokecolor));
            pathStyle.Setters.Add(new Setter(Shape.StrokeThicknessProperty, value));
            if (this.SnapSettings != null)
            {
                this.SnapSettings.SnapIndicatorStyle = pathStyle as Style;
            }

            pathStyle = null;
        }

        #endregion
    }

    /// <summary>
    /// Represents the calss to convert soid color to Color value.
    /// </summary>
    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                var converter = new System.Windows.Media.BrushConverter();

                Brush brush = (Brush)converter.ConvertFromString(value.ToString());

                return (brush as SolidColorBrush).Color;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(value.ToString());
                return brush;
            }
            return value;
        }
    }
}
