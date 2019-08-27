#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Ports.Utility;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Theming;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace GettingStarted_PortsDiagram.ViewModel
{
    public class PortsDiagramViewModel : DiagramViewModel
    {
        #region Fields

        private bool _enabled;

        private object _portvisibility;

        private object _portshape;

        private Brush _fillcolor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1916C1"));

        private Brush _strokecolor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

        private object _strokethickness = 1;

        private object _sizechanged = 10;

        private object _paddingchanged = 0;

        private object _connectiondirection;

        private List<string> _mConnectionDirection = new List<string> { "Auto", "Top", "Left", "Bottom", "Right" };

        private List<string> _mvisibility = new List<string> { "Default", "Collapse", "Visible", "MouseOver", "MouseOverOnConnect", "ValidConnection" };

        private List<string> _mshape = new List<string> { "Circle", "Rectangle", "Star", "Custom Shape" };

        #endregion

        public PortsDiagramViewModel()
        {
            #region DiagramViewModel Properties , Commands Initialization

            ItemUnSelectedCommand = new Command(OnItemUnselectedCommand);

            ItemSelectedCommand = new Command(OnItemSelectedCommand);

            Theme = new SimpleTheme();

            DefaultConnectorType = ConnectorType.Orthogonal;

            ScrollSettings = new ScrollSettings()
            {
                ScrollLimit = ScrollLimit.Diagram,
            };

            SnapSettings = new SnapSettings()
            {
                SnapConstraints = SnapConstraints.All,
                SnapToObject = SnapToObject.All,
            };

            HorizontalRuler = new Ruler();

            VerticalRuler = new Ruler()
            {
                Orientation = Orientation.Vertical,
            };

            PageSettings = new PageSettings()
            {
                PageBackground = new SolidColorBrush(Colors.Transparent),
                PageBorderBrush = new SolidColorBrush(Colors.Transparent),
            };

            SelectedItems = new SelectorViewModel()
            {
                SelectorConstraints = SelectorConstraints.Default & ~SelectorConstraints.QuickCommands | SelectorConstraints.HideDisabledResizer,
            };

            #endregion

            #region Node Creation

            NodeViewModel Node1 = CreateNode(65, 100, 200, 150, "Rectangle", "Publisher",true);
            NodeViewModel Node2 = CreateNode(65, 100, 450, 150, "Rectangle", "Completed Book",false);
            NodeViewModel Node3 = CreateNode(65, 100, 700, 150, "Rectangle", "Board", false);
            NodeViewModel Node4 = CreateNode(65, 100, 450, 300, "Decision", "1st Review", false);
            NodeViewModel Node5 = CreateNode(65, 100, 700, 300, "Decision", "Approval", false);
            NodeViewModel Node6 = CreateNode(65, 100, 450, 450, "Rectangle", "Legal Terms", false);
            NodeViewModel Node7 = CreateNode(65, 100, 450, 600, "Decision", "2nd Review", false);

            #endregion

            #region Port Creation

            CreateNodePort(Node1, "NodePort11", 0, 0.5, "In");
            CreateNodePort(Node1, "NodePort12", 1, 0.5, "Out");
            CreateNodePort(Node1, "NodePort13", 0.25, 1, "In");
            CreateNodePort(Node1, "NodePort14", 0.5, 1, "Out");
            CreateNodePort(Node1, "NodePort15", 0.75, 1, "In" );

            CreateNodePort(Node2, "NodePort21", 0, 0.5, "In");
            CreateNodePort(Node2, "NodePort22", 0.5, 1, "Out");
            CreateNodePort(Node2, "NodePort23", 1, 0.4, "Out");
            CreateNodePort(Node2, "NodePort24", 1, 0.6, "In");

            CreateNodePort(Node3, "NodePort31", 0, 0.4, "In");
            CreateNodePort(Node3, "NodePort32", 0.5, 1, "Out");

            CreateNodePort(Node4, "NodePort41", 0, 0.5,"Out");
            CreateNodePort(Node4, "NodePort42", 0.5, 0, "In");
            CreateNodePort(Node4, "NodePort43", 0.5, 1, "Out");

            CreateNodePort(Node5, "NodePort51", 0.5, 0, "In");
            CreateNodePort(Node5, "NodePort52", 0.5, 1, "Out");

            CreateNodePort(Node6, "NodePort61", 0, 0.5, "In");
            CreateNodePort(Node6, "NodePort62", 0.5, 0, "In");
            CreateNodePort(Node6, "NodePort63", 0.5, 1, "Out");

            CreateNodePort(Node7, "NodePort71", 0, 0.5, "Out");
            CreateNodePort(Node7, "NodePort72", 0.5, 0, "In");
            CreateNodePort(Node7, "NodePort73", 1, 0.5, "Out");

            #endregion

            #region NodeCollection

            (Nodes as NodeCollection).Add(Node1);
            (Nodes as NodeCollection).Add(Node2);
            (Nodes as NodeCollection).Add(Node3);
            (Nodes as NodeCollection).Add(Node4);
            (Nodes as NodeCollection).Add(Node5);
            (Nodes as NodeCollection).Add(Node6);
            (Nodes as NodeCollection).Add(Node7);

            #endregion
        }

        #region Properties

        /// <summary>
        /// Gets or sets the PortVisibility for Ports
        /// </summary>
        public object Portvisibility
        {
            get
            {
                return _portvisibility;
            }
            set
            {
                if (_portvisibility != value)
                {
                    _portvisibility = value;
                    OnPropertyChanged("Portvisibility");
                    OnPortVisibilityChanged(_portvisibility);
                }
            }
        }

        /// <summary>
        /// Gets or sets the PortShape for Ports
        /// </summary>
        public object Portshape
        {
            get
            {
                return _portshape;
            }
            set
            {
                if (_portshape != value)
                {
                    _portshape = value;
                    OnPropertyChanged("Portshape");
                    OnPortShapeChanged(_portshape);
                }
            }
        }

        /// <summary>
        /// Gets or sets the Size for Ports
        /// </summary>
        public object SizeChanged
        {
            get
            {
                return _sizechanged;
            }
            set
            {
                if (_sizechanged != value)
                {
                    _sizechanged = value;
                    OnPropertyChanged("SizeChanged");
                    OnSizeChanged(_sizechanged);
                }
            }
        }

        /// <summary>
        /// Gets or sets the ConnectorPadding for Ports
        /// </summary>
        public object PaddingChanged
        {
            get
            {
                return _paddingchanged;
            }
            set
            {
                if (_paddingchanged != value)
                {
                    _paddingchanged = value;
                    OnPropertyChanged("PaddingChanged");
                    OnPaddingChanged(_paddingchanged);
                }
            }
        }

        /// <summary>
        /// Gets or sets the ConnectionDirection for Ports
        /// </summary>
        public object Connectiondirection
        {
            get
            {
                return _connectiondirection;
            }
            set
            {
                if (_connectiondirection != value)
                {
                    _connectiondirection = value;
                    OnPropertyChanged("Connectiondirection");
                    OnConnectionDirectionChanged(_connectiondirection);
                }
            }
        }

        /// <summary>
        /// Gets or sets the Strokethickness for Ports
        /// </summary>
        public object Strokethickness
        {
            get
            {
                return _strokethickness;
            }
            set
            {
                if (_strokethickness != value)
                {
                    _strokethickness = value;
                    OnPropertyChanged("Strokethickness");
                    OnStrokeThicknessChanged(_strokethickness);
                }
            }
        }

        /// <summary>
        /// Gets or sets the Strokecolor for Ports
        /// </summary>
        public Brush Strokecolor
        {
            get
            {
                return _strokecolor;
            }
            set
            {
                if(_strokecolor!= value)
                {
                    _strokecolor = value;
                    OnPropertyChanged("Strokecolor");
                    OnStrokeColorChanged(_strokecolor);
                }
            }
        }

        /// <summary>
        /// Gets or sets the Fillcolor for Ports
        /// </summary>
        public Brush Fillcolor
        {
            get
            {
                return _fillcolor;
            }
            set
            {
                if (_fillcolor != value)
                {
                    _fillcolor = value;
                    OnPropertyChanged("Fillcolor");
                    OnFillColorChanged(_fillcolor);
                }
            }
        }

        /// <summary>
        /// Gets or sets whether to enable or disable
        /// </summary>
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                if (_enabled != value)
                {
                    _enabled = value;
                    OnPropertyChanged("Enabled");
                }
            }
        }

        public List<string> Connectiondirections
        {
            get
            {
                return _mConnectionDirection;
            }
        }

        public List<string> Visibility
        {
            get
            {
                return _mvisibility;
            }
        }

        public List<string> PortShape
        {
            get
            {
                return _mshape;
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Method to create NodePort
        /// </summary>
        /// <param name="node1">Parent for the created nodeport</param>
        /// <param name="id">NodePort ID</param>
        /// <param name="nodeoffsetx">NodePort's OffsetX</param>
        /// <param name="nodeoffsety">NodePort's OffsetY</param>
        /// <param name="porttype">Port Type</param>
        private void CreateNodePort(NodeViewModel node1, string id, double nodeoffsetx, double nodeoffsety, string porttype)
        {
            CustomPort nodePort = new CustomPort()
            {
                ID = id,
                NodeOffsetX = nodeoffsetx,
                NodeOffsetY = nodeoffsety,
                Shape = App.Current.Resources["Ellipse"],
                Constraints = PortConstraints.Default & ~PortConstraints.InheritPortVisibility,
                PortVisibility = PortVisibility.Visible,
            };

            if (porttype == "In")
            {
                nodePort.Porttype = porttype;
            }
            else
            {
                nodePort.Porttype = porttype;
            }

            (node1.Ports as PortCollection).Add(nodePort);
        }

        /// <summary>
        /// Method to create Node
        /// </summary>
        /// <param name="height">Height Of Node</param>
        /// <param name="width">Width Of Node</param>
        /// <param name="offsetx">OffsetX Of Node</param>
        /// <param name="offsety">OffsetY Of Node</param>
        /// <param name="shape">Shape Of Node</param>
        /// <param name="annotation">Content Of Node's Annotation</param>
        /// <param name="selected">IsSelected or not</param>
        /// <returns></returns>
        private NodeViewModel CreateNode(double height, double width, double offsetx, double offsety, string shape, string annotation, bool selected)
        {
            NodeViewModel node = new NodeViewModel()
            {
                OffsetX = offsetx,
                OffsetY = offsety,
                UnitHeight = height,
                UnitWidth = width,
                Shape = App.Current.Resources[shape],
                IsSelected = selected,
                Annotations = new ObservableCollection<AnnotationEditorViewModel>()
                {
                    new AnnotationEditorViewModel()
                    {
                        Content = annotation,
                    },
                }
            };
            return node;
        }

        /// <summary>
        /// Method to change the PortVisibility
        /// </summary>
        /// <param name="portvisibility"></param>
        private void OnPortVisibilityChanged(object portvisibility)
        {
            string name = null;
            if (portvisibility is ComboBoxItem)
            {
                name = (portvisibility as ComboBoxItem).Content.ToString();
            }
            else
            {
                name = portvisibility.ToString();
            }

            if (this.Info != null && (this.Info as IGraph).SelectedItems != null)
            {
                SelectorViewModel selectorvm = (this.Info as IGraph).SelectedItems as SelectorViewModel;
                if ((selectorvm.Nodes as ObservableCollection<object>).Count > 0)
                {
                    NodeViewModel node = (selectorvm.Nodes as ObservableCollection<object>).ElementAt(0) as NodeViewModel;
                    switch (name)
                    {
                        case "Default":
                            PortVisibilityChange(node, PortVisibility.Default);
                            break;
                        case "Visible":
                            PortVisibilityChange(node, PortVisibility.Visible);
                            break;
                        case "MouseOver":
                            PortVisibilityChange(node, PortVisibility.MouseOver);
                            break;
                        case "Collapse":
                            PortVisibilityChange(node, PortVisibility.Collapse);
                            break;
                        case "MouseOverOnConnect":
                            PortVisibilityChange(node, PortVisibility.MouseOverOnConnect);
                            break;
                        case "ValidConnection":
                            PortVisibilityChange(node, PortVisibility.ValidConnection);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Method to change the Port shape
        /// </summary>
        /// <param name="portshape"></param>
        private void OnPortShapeChanged(object portshape)
        {
            string name;
            if (portshape is ComboBoxItem)
            {
                name = (portshape as ComboBoxItem).Content.ToString();
            }
            else
            {
                name = portshape.ToString();
            }
            if (this.Info != null && (this.Info as IGraph).SelectedItems != null)
            {
                SelectorViewModel selectorvm = (this.Info as IGraph).SelectedItems as SelectorViewModel;
                if ((selectorvm.Nodes as ObservableCollection<object>).Count > 0)
                {
                    NodeViewModel node = (selectorvm.Nodes as ObservableCollection<object>).ElementAt(0) as NodeViewModel;
                    switch (name)
                    {
                        case "Star":
                            PortShapeChange(node, "Star");
                            break;
                        case "Circle":
                            PortShapeChange(node, "Circle");
                            break;
                        case "Rectangle":
                            PortShapeChange(node, "Rectangle");
                            break;
                        case "Custom Shape":
                            PortShapeChange(node, "Custom Shape");
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Method to change the Connection Direction to Port.
        /// </summary>
        /// <param name="connectiondirection"></param>
        private void OnConnectionDirectionChanged(object connectiondirection)
        {
            string name = null;
            if (connectiondirection is ComboBoxItem)
            {
                name = (connectiondirection as ComboBoxItem).Content.ToString();
            }
            else
            {
                name = connectiondirection.ToString();
            }
            if (this.Info != null && (this.Info as IGraph).SelectedItems != null)
            {
                SelectorViewModel selectorvm = (this.Info as IGraph).SelectedItems as SelectorViewModel;
                if ((selectorvm.Nodes as ObservableCollection<object>).Count > 0)
                {
                    NodeViewModel node = (selectorvm.Nodes as ObservableCollection<object>).ElementAt(0) as NodeViewModel;
                    switch (name)
                    {
                        case "Auto":
                            ConnectionDirectionChange(node, ConnectionDirection.Auto);
                            break;
                        case "Left":
                            ConnectionDirectionChange(node, ConnectionDirection.Left);
                            break;
                        case "Top":
                            ConnectionDirectionChange(node, ConnectionDirection.Top);
                            break;
                        case "Right":
                            ConnectionDirectionChange(node, ConnectionDirection.Right);
                            break;
                        case "Bottom":
                            ConnectionDirectionChange(node, ConnectionDirection.Bottom);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Method to change the size of the port.
        /// </summary>
        /// <param name="sizechanged"></param>
        private void OnSizeChanged(object sizechanged)
        {
            double value = double.Parse(sizechanged.ToString());
            if (this.Info != null && (this.Info as IGraph).SelectedItems != null)
            {
                SelectorViewModel selectorvm = (this.Info as IGraph).SelectedItems as SelectorViewModel;
                if ((selectorvm.Nodes as ObservableCollection<object>).Count > 0)
                {
                    NodeViewModel node = (selectorvm.Nodes as ObservableCollection<object>).ElementAt(0) as NodeViewModel;
                    foreach (IPort nodeport in (node.Ports as ObservableCollection<IPort>))
                    {
                        nodeport.UnitHeight = value;
                        nodeport.UnitWidth = value;
                        (nodeport as CustomPort).Sizechanged = value.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// Method to change the connector padding values.
        /// </summary>
        /// <param name="paddingchanged"></param>
        private void OnPaddingChanged(object paddingchanged)
        {
            double value = double.Parse(paddingchanged.ToString());
            if (this.Info != null && (this.Info as IGraph).SelectedItems != null)
            {
                SelectorViewModel selectorvm = (this.Info as IGraph).SelectedItems as SelectorViewModel;
                if ((selectorvm.Nodes as ObservableCollection<object>).Count > 0)
                {
                    NodeViewModel node = (selectorvm.Nodes as ObservableCollection<object>).ElementAt(0) as NodeViewModel;
                    foreach (IPort nodeport in (node.Ports as ObservableCollection<IPort>))
                    {
                        nodeport.ConnectorPadding = value;
                    }
                }
            }
        }

        /// <summary>
        /// Method to change the strokethickness of Port
        /// </summary>
        /// <param name="strokethickness"></param>
        private void OnStrokeThicknessChanged(object strokethickness)
        {
            double value = double.Parse(strokethickness.ToString());
            if (this.Info != null && (this.Info as IGraph).SelectedItems != null)
            {
                SelectorViewModel selectorvm = (this.Info as IGraph).SelectedItems as SelectorViewModel;
                if ((selectorvm.Nodes as ObservableCollection<object>).Count > 0)
                {
                    NodeViewModel node = (selectorvm.Nodes as ObservableCollection<object>).ElementAt(0) as NodeViewModel;
                    foreach (IPort nodeport in (node.Ports as ObservableCollection<IPort>))
                    {
                        (nodeport as CustomPort).Strokethickness = value.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// Method to change the stroke color of Port
        /// </summary>
        /// <param name="strokecolor"></param>
        private void OnStrokeColorChanged(Brush strokecolor)
        {
            Brush value = strokecolor;
            if (this.Info != null && (this.Info as IGraph).SelectedItems != null)
            {
                SelectorViewModel selectorvm = (this.Info as IGraph).SelectedItems as SelectorViewModel;
                if ((selectorvm.Nodes as ObservableCollection<object>).Count > 0)
                {
                    NodeViewModel node = (selectorvm.Nodes as ObservableCollection<object>).ElementAt(0) as NodeViewModel;
                    foreach (IPort nodeport in (node.Ports as ObservableCollection<IPort>))
                    {
                        (nodeport as CustomPort).Strokecolor = value;
                    }
                }
            }
        }

        /// <summary>
        /// Method to change the fill color of Port
        /// </summary>
        /// <param name="fillcolor"></param>
        private void OnFillColorChanged(Brush fillcolor)
        {
            Brush value = fillcolor;
            if (this.Info != null && (this.Info as IGraph).SelectedItems != null)
            {
                SelectorViewModel selectorvm = (this.Info as IGraph).SelectedItems as SelectorViewModel;
                if ((selectorvm.Nodes as ObservableCollection<object>).Count > 0)
                {
                    NodeViewModel node = (selectorvm.Nodes as ObservableCollection<object>).ElementAt(0) as NodeViewModel;
                    foreach (IPort nodeport in (node.Ports as ObservableCollection<IPort>))
                    {
                        (nodeport as CustomPort).Fillcolor = value;
                    }
                }
            }
        }

        /// <summary>
        /// Method to change the PortShape
        /// </summary>
        /// <param name="node"></param>
        /// <param name="v"></param>
        private void PortShapeChange(NodeViewModel node, string v)
        {
            foreach (IPort nodeport in (node.Ports as ObservableCollection<IPort>))
            {
                if(v == "Star")
                {
                    nodeport.Shape = App.Current.Resources["Star"];
                }
                else if(v=="Circle")
                {
                    nodeport.Shape = new EllipseGeometry() { RadiusX = 10, RadiusY = 10 };
                }
                else if(v=="Rectangle")
                {
                    nodeport.Shape = new RectangleGeometry() { Rect = new Rect(10, 10, 10, 10) };
                }
                else if(v=="Custom Shape")
                {
                    nodeport.Shape = App.Current.Resources["Diamond"];
                }
                (nodeport as CustomPort).ShapeName = v;
            }
        }

        /// <summary>
        /// Method to change the PortVisibility
        /// </summary>
        /// <param name="node"></param>
        /// <param name="portVisibility"></param>
        private void PortVisibilityChange(NodeViewModel node , PortVisibility portVisibility)
        {
            foreach(IPort nodeport in (node.Ports as ObservableCollection<IPort>))
            {
                if(portVisibility == PortVisibility.ValidConnection)
                {
                    if ((nodeport as CustomPort).Porttype == "In")
                    {
                        (nodeport as CustomPort).Constraints = (nodeport as CustomPort).Constraints & ~PortConstraints.InheritConnectable;
                        (nodeport as CustomPort).Constraints = (nodeport as CustomPort).Constraints | PortConstraints.InConnect;
                    }
                    else if ((nodeport as CustomPort).Porttype == "Out")
                    {
                        (nodeport as CustomPort).Constraints = (nodeport as CustomPort).Constraints & ~PortConstraints.InheritConnectable;
                        (nodeport as CustomPort).Constraints = (nodeport as CustomPort).Constraints | PortConstraints.OutConnect;
                    }
                    nodeport.PortVisibility = portVisibility;
                }
                else if(portVisibility == PortVisibility.MouseOverOnConnect || portVisibility == PortVisibility.Default)
                {
                    (nodeport as CustomPort).Constraints = PortConstraints.Default & ~PortConstraints.InheritPortVisibility;
                    nodeport.PortVisibility = portVisibility;
                }
                else
                {
                    nodeport.PortVisibility = portVisibility;
                }
            }
        }

        /// <summary>
        /// Method to change the Connection Direction
        /// </summary>
        /// <param name="node"></param>
        /// <param name="direction"></param>
        private void ConnectionDirectionChange(NodeViewModel node, ConnectionDirection direction)
        {
            foreach (IPort nodeport in (node.Ports as ObservableCollection<IPort>))
            {
                if (direction == ConnectionDirection.Auto)
                {
                    nodeport.Constraints = nodeport.Constraints | PortConstraints.ConnectionDirection;
                    nodeport.ConnectionDirection = ConnectionDirection.Auto;
                }
                else if (direction == ConnectionDirection.Left)
                {
                    nodeport.Constraints = nodeport.Constraints | PortConstraints.ConnectionDirection;
                    nodeport.ConnectionDirection = ConnectionDirection.Left;
                }
                else if (direction == ConnectionDirection.Top)
                {
                    nodeport.Constraints = nodeport.Constraints | PortConstraints.ConnectionDirection;
                    nodeport.ConnectionDirection = ConnectionDirection.Top;
                }
                else if (direction == ConnectionDirection.Right)
                {
                    nodeport.Constraints = nodeport.Constraints | PortConstraints.ConnectionDirection;
                    nodeport.ConnectionDirection = ConnectionDirection.Right;
                }
                else if (direction == ConnectionDirection.Bottom)
                {
                    nodeport.Constraints = nodeport.Constraints | PortConstraints.ConnectionDirection;
                    nodeport.ConnectionDirection = ConnectionDirection.Bottom;
                }
            }
        }

        /// <summary>
        /// Method for ItemSelected Command
        /// </summary>
        /// <param name="obj"></param>
        private void OnItemSelectedCommand(object obj)
        {
            if ((obj as ItemSelectedEventArgs).Item is INode)
            {
                NodeViewModel node = (obj as ItemSelectedEventArgs).Item as NodeViewModel;
                node.Constraints = NodeConstraints.Default & ~NodeConstraints.InheritResizable | NodeConstraints.Resizable 
                    & ~NodeConstraints.ResizeNorth & ~NodeConstraints.ResizeEast & ~NodeConstraints.ResizeSouth & ~NodeConstraints.ResizeWest;
                this.Portvisibility = ((node.Ports as ObservableCollection<IPort>)[0] as CustomPort).PortVisibility.ToString();
                this.Connectiondirection = ((node.Ports as ObservableCollection<IPort>)[0] as CustomPort).ConnectionDirection.ToString();
                this.Portshape = ((node.Ports as ObservableCollection<IPort>)[0] as CustomPort).ShapeName.ToString();
                this.Fillcolor = ((node.Ports as ObservableCollection<IPort>)[0] as CustomPort).Fillcolor;
                this.Strokecolor = ((node.Ports as ObservableCollection<IPort>)[0] as CustomPort).Strokecolor;
                this.Strokethickness = ((node.Ports as ObservableCollection<IPort>)[0] as CustomPort).Strokethickness.ToString();
                this.SizeChanged = ((node.Ports as ObservableCollection<IPort>)[0] as CustomPort).Sizechanged.ToString();
                this.PaddingChanged = ((node.Ports as ObservableCollection<IPort>)[0] as CustomPort).ConnectorPadding.ToString();
                Enabled = true;
            }
        }

        /// <summary>
        /// Method for ItemUnSelected Command
        /// </summary>
        /// <param name="obj"></param>
        private void OnItemUnselectedCommand(object obj)
        {
            Enabled = false;
        }

        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);
        }

        #endregion
    }

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
