// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FlowChartSelectorVm.cs" company="">
//   
// </copyright>
// <summary>
//   Custom selector class used to change the selector appearance
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FlowChart.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;

    using DiagramBuilder.Utility;
    using DiagramBuilder.ViewModel;

    using Syncfusion.UI.Xaml.Diagram;

    /// <summary>
    ///     Custom selector class used to change the selector appearance
    /// </summary>
    public class FlowChartSelectorVm : SelectorVM
    {

        ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/syncfusion.diagrambuilder.Wpf;component/FlowChart/Theme/FlowChartUI.xaml", UriKind.RelativeOrAbsolute)
        };

        /// <summary>
        ///     Holds visibility value of bottom side quick button.
        /// </summary>
        private Visibility _bottomButtonVisibility = Visibility.Visible;

        /// <summary>
        ///     Holds visibility value of left side quick button.
        /// </summary>
        private Visibility _leftButtonVisibility = Visibility.Visible;

        /// <summary>
        ///     To handle the shapes collections margin
        /// </summary>
        private Thickness _mPanelMargin;

        /// <summary>
        ///     To handle the collections of shapes visisbility
        /// </summary>
        private Visibility _mPanelVisibity = Visibility.Collapsed;

        /// <summary>
        ///     Holds visibility value of right side quick button.
        /// </summary>
        private Visibility _rightButtonVisibility = Visibility.Visible;

        /// <summary>
        ///     Holds visibility value of top side quick button.
        /// </summary>
        private Visibility _topButtonVisibility = Visibility.Visible;

        /// <summary>
        ///     To have offset X values of node added to the diagram newly
        /// </summary>
        private double offsetx = 350;

        /// <summary>
        ///     To have offset Y values of node added to the diagram newly
        /// </summary>
        private double offsety = 300;

        /// <summary>
        ///     The panel angle.
        /// </summary>
        private double panelAngle;

        /// <summary>
        ///     To handle direction of the collection of shapes panel.
        /// </summary>
        private string panelDirection;

        /// <summary>
        ///     To handle horizontal alignment for shapes panel
        /// </summary>
        private HorizontalAlignment panelHorizontalAlignment = HorizontalAlignment.Center;

        /// <summary>
        ///     To handle vertical alignment for shapes panel
        /// </summary>
        private VerticalAlignment panelVertiaclAlignment = VerticalAlignment.Center;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlowChartSelectorVm"/> class.
        /// </summary>
        /// <param name="diagram">
        /// The diagram.
        /// </param>
        public FlowChartSelectorVm(FlowDiagramVm diagram)
            : base(diagram)
        {
            // Diagram = diagram;
            this.ShowShapesCollectionsPanelCommand = new Command(this.OnShowShapesCollectionsPanelCommandExecute);
            this.AddShapesCommand = new Command(this.OnAddShapesCommand);
            this.RightButtonVisibilityCommand = new Command(this.OnRightButtonVisibilityCommandExecute);
        }

        // Command used to add shapes into diagram when click on particular shapes
        /// <summary>
        ///     Gets or sets the add shapes command.
        /// </summary>
        public ICommand AddShapesCommand { get; set; }

        /// <summary>
        ///     Gets or sets value for Left Button visibility.
        /// </summary>
        public Visibility BottomButtonVisibility
        {
            get
            {
                return this._bottomButtonVisibility;
            }

            set
            {
                if (value != this._bottomButtonVisibility)
                {
                    this._bottomButtonVisibility = value;
                    this.OnPropertyChanged("BottomButtonVisibility");
                }
            }
        }

        /// <summary>
        ///     Gets or sets value for Left Button visibility.
        /// </summary>
        public Visibility LeftButtonVisibility
        {
            get
            {
                return this._leftButtonVisibility;
            }

            set
            {
                if (value != this._leftButtonVisibility)
                {
                    this._leftButtonVisibility = value;
                    this.OnPropertyChanged("LeftButtonVisibility");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the panel angle.
        /// </summary>
        public double PanelAngle
        {
            get
            {
                return this.panelAngle;
            }

            set
            {
                if (value != this.panelAngle)
                {
                    this.panelAngle = value;
                    this.OnPropertyChanged("PanelAngle");
                }
            }
        }

        /// <summary>
        ///     Gets or set value of Panel direction which used to add the node exactly same side of the panel direction
        /// </summary>
        public string PanelDirection
        {
            get
            {
                return this.panelDirection;
            }

            set
            {
                if (value != this.panelDirection)
                {
                    this.panelDirection = value;
                    this.OnPropertyChanged(this.PanelDirection);
                }
            }
        }

        /// <summary>
        ///     Gets or sets value for Shapes collection panel's horizontal alignment
        /// </summary>
        public HorizontalAlignment PanelHorizontalAlignment
        {
            get
            {
                return this.panelHorizontalAlignment;
            }

            set
            {
                if (value != this.panelHorizontalAlignment)
                {
                    this.panelHorizontalAlignment = value;
                    this.OnPropertyChanged("PanelHorizontalAlignment");
                }
            }
        }

        /// <summary>
        ///     Gets or sets margin value for shapes collections pannel
        /// </summary>
        public Thickness PanelMargin
        {
            get
            {
                return this._mPanelMargin;
            }

            set
            {
                if (this._mPanelMargin != value)
                {
                    this._mPanelMargin = value;
                    this.OnPropertyChanged("PanelMargin");
                }
            }
        }

        /// <summary>
        ///     Gets or sets value for Shapes collection panel's vertical alignment
        /// </summary>
        public VerticalAlignment PanelVerticalAlignment
        {
            get
            {
                return this.panelVertiaclAlignment;
            }

            set
            {
                if (value != this.panelVertiaclAlignment)
                {
                    this.panelVertiaclAlignment = value;
                    this.OnPropertyChanged("PanelVerticalAlignment");
                }
            }
        }

        /// <summary>
        ///     Gets or sets value for collections of Shapes pannel visibility
        /// </summary>
        public Visibility PanelVisibility
        {
            get
            {
                return this._mPanelVisibity;
            }

            set
            {
                if (this._mPanelVisibity != value)
                {
                    this._mPanelVisibity = value;
                    this.OnPropertyChanged("PanelVisibility");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the right button visibility.
        /// </summary>
        public Visibility RightButtonVisibility
        {
            get
            {
                return this._rightButtonVisibility;
            }

            set
            {
                if (value != this._rightButtonVisibility)
                {
                    this._rightButtonVisibility = value;
                    this.OnPropertyChanged("RightButtonVisibility");
                }
            }
        }

        // Command used to control visibility of right side button.
        /// <summary>
        ///     Gets or sets the right button visibility command.
        /// </summary>
        public ICommand RightButtonVisibilityCommand { get; set; }

        /// <summary>
        ///     Command used to show collections of shapes panel with selector elements.
        /// </summary>

        public ICommand ShowShapesCollectionsPanelCommand { get; set; }

        /// <summary>
        ///     Gets or sets value for Left Button visibility.
        /// </summary>
        public Visibility TopButtonVisibility
        {
            get
            {
                return this._topButtonVisibility;
            }

            set
            {
                if (value != this._topButtonVisibility)
                {
                    this._topButtonVisibility = value;
                    this.OnPropertyChanged("TopButtonVisibility");
                }
            }
        }

        /// <summary>
        /// Occurs when ever the property changes.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        protected override void OnPropertyChanged(string name)
        {
            if (name == "RotateAngle")
            {
                this.PanelAngle = 360 - this.RotateAngle;
                this.PanelVisibility = Visibility.Hidden;
            }

            base.OnPropertyChanged(name);
        }

        /// <summary>
        /// Command for adding shapes into diagram
        /// </summary>
        /// <param name="param">
        /// Name of the shape
        /// </param>
        private void OnAddShapesCommand(object param)
        {
            ConnectorVM connector = new ConnectorVM();

            ObservableCollection<NodeVM> nodescollection = this.Diagram.Nodes as ObservableCollection<NodeVM>;
            NodeVM selectedNode = (this.Nodes as ObservableCollection<object>).First() as NodeVM;
            if (selectedNode != null)
            {
                Rect selectedNodeBounds = (selectedNode.Info as INodeInfo).Bounds;
                if (this.PanelDirection == "Right")
                {
                    this.offsetx = selectedNodeBounds.Right + 100;
                    this.offsety = selectedNode.OffsetY;
                }
                else if (this.PanelDirection == "Left")
                {
                    this.offsetx = selectedNodeBounds.Left - 100;
                    this.offsety = selectedNode.OffsetY;
                }
                else if (this.PanelDirection == "Top")
                {
                    this.offsetx = selectedNode.OffsetX;
                    this.offsety = selectedNodeBounds.Top - 75;
                }
                else if (this.PanelDirection == "Bottom")
                {
                    this.offsetx = selectedNode.OffsetX;
                    this.offsety = selectedNodeBounds.Bottom + 75;
                }

                connector.SourceNode = selectedNode;
                selectedNode.IsSelected = false;
            }

            NodeVM node = new NodeVM
                              {
                                  OffsetX = this.offsetx,
                                  OffsetY = this.offsety,
                                  Shape = resourceDictionary[param]
                              };

            if (param.ToString().Equals("Process") || param.ToString().Equals("Decision")
                                                   || param.ToString().Equals("MultiDocument")
                                                   || param.ToString().Equals("Terminator")
                                                   || param.ToString().Equals("Sort")
                                                   || param.ToString().Equals("Document")
                                                   || param.ToString().Equals("DirectData")
                                                   || param.ToString().Equals("ManualOperation")
                                                   || param.ToString().Equals("InternalStorage")
                                                   || param.ToString().Equals("Card")
                                                   || param.ToString().Equals("PredefinedProcess")
                                                   || param.ToString().Equals("Or"))
            {
                if (param.ToString().Equals("Terminator"))
                {
                    node.UnitHeight = 37;
                    node.UnitWidth = 94;
                }
                else if (param.ToString().Equals("Or"))
                {
                    node.UnitHeight = 75;
                    node.UnitWidth = 75;
                }
                else
                {
                    node.UnitHeight = 56;
                    node.UnitWidth = 94;
                }

                if (param.ToString().Equals("MultiDocument") || param.ToString().Equals("Document"))
                {
                    node.Ports = new PortCollection
                                     {
                                         new NodePortVM
                                             {
                                                 NodeOffsetX = 0,
                                                 NodeOffsetY = 0.5,
                                                 Shape = resourceDictionary["Rectangle"],
                                                 ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                             },
                                         new NodePortVM
                                             {
                                                 NodeOffsetX = 0.5,
                                                 NodeOffsetY = 0,
                                                 Shape = resourceDictionary["Rectangle"],
                                                 ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                             },
                                         new NodePortVM
                                             {
                                                 NodeOffsetX = 1,
                                                 NodeOffsetY = 0.5,
                                                 Shape = resourceDictionary["Rectangle"],
                                                 ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                             },
                                         new NodePortVM
                                             {
                                                 NodeOffsetX = 0.5,
                                                 NodeOffsetY = 0.9,
                                                 Shape = resourceDictionary["Rectangle"],
                                                 ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                             }
                                     };
                }
                else if (param.ToString().Equals("ManualOperation"))
                {
                    node.Ports = new PortCollection
                                     {
                                         new NodePortVM
                                             {
                                                 NodeOffsetX = 0.1,
                                                 NodeOffsetY = 0.5,
                                                 Shape = resourceDictionary["Rectangle"],
                                                 ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                             },
                                         new NodePortVM
                                             {
                                                 NodeOffsetX = 0.5,
                                                 NodeOffsetY = 0,
                                                 Shape = resourceDictionary["Rectangle"],
                                                 ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                             },
                                         new NodePortVM
                                             {
                                                 NodeOffsetX = 0.9,
                                                 NodeOffsetY = 0.5,
                                                 Shape = resourceDictionary["Rectangle"],
                                                 ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                             },
                                         new NodePortVM
                                             {
                                                 NodeOffsetX = 0.5,
                                                 NodeOffsetY = 1,
                                                 Shape = resourceDictionary["Rectangle"],
                                                 ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                             }
                                     };
                }
                else
                {
                    node.Ports = new PortCollection
                                     {
                                         new NodePortVM
                                             {
                                                 NodeOffsetX = 0,
                                                 NodeOffsetY = 0.5,
                                                 Shape = resourceDictionary["Rectangle"],
                                                 ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                             },
                                         new NodePortVM
                                             {
                                                 NodeOffsetX = 0.5,
                                                 NodeOffsetY = 0,
                                                 Shape = resourceDictionary["Rectangle"],
                                                 ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                             },
                                         new NodePortVM
                                             {
                                                 NodeOffsetX = 1,
                                                 NodeOffsetY = 0.5,
                                                 Shape = resourceDictionary["Rectangle"],
                                                 ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                             },
                                         new NodePortVM
                                             {
                                                 NodeOffsetX = 0.5,
                                                 NodeOffsetY = 1,
                                                 Shape = resourceDictionary["Rectangle"],
                                                 ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                             }
                                     };
                }
            }
            else if (param.ToString().Equals("SequentialData") || param.ToString().Equals("SequentialAccessStorage"))
            {
                node.UnitHeight = 95;
                node.UnitWidth = 95;
                node.Ports = new PortCollection
                                 {
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0,
                                             NodeOffsetY = 0.5,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 0,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.95,
                                             NodeOffsetY = 0.5,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 1,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 1,
                                             NodeOffsetY = 1,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         }
                                 };
            }
            else if (param.ToString().Equals("Collate"))
            {
                node.UnitHeight = 75;
                node.UnitWidth = 75;
                node.Ports = new PortCollection
                                 {
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 0,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 0.5,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 1,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         }
                                 };
            }
            else if (param.ToString().Equals("SummingJunction"))
            {
                node.UnitHeight = 75;
                node.UnitWidth = 75;
                node.Ports = new PortCollection
                                 {
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 0,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0,
                                             NodeOffsetY = 0.5,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 1,
                                             NodeOffsetY = 0.5,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 1,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.15,
                                             NodeOffsetY = 0.15,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.85,
                                             NodeOffsetY = 0.15,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.15,
                                             NodeOffsetY = 0.85,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.85,
                                             NodeOffsetY = 0.85,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         }
                                 };
            }
            else if (param.ToString().Equals("Extract") || param.ToString().Equals("Merge"))
            {
                node.UnitHeight = 75;
                node.UnitWidth = 75;
                node.Ports = new PortCollection
                                 {
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 0,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 1,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.25,
                                             NodeOffsetY = 0.5,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.75,
                                             NodeOffsetY = 0.5,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         }
                                 };
            }
            else if (param.ToString().Equals("OffPageReference"))
            {
                node.UnitHeight = 45;
                node.UnitWidth = 45;
                node.Ports = new PortCollection
                                 {
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 0,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 1,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0,
                                             NodeOffsetY = 0.7,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 1,
                                             NodeOffsetY = 0.7,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         }
                                 };
            }
            else if (param.ToString().Equals("StoredData"))
            {
                node.UnitHeight = 56;
                node.UnitWidth = 95;
                node.Ports = new PortCollection
                                 {
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0,
                                             NodeOffsetY = 0.5,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 0,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.9,
                                             NodeOffsetY = 0.5,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 1,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         }
                                 };
            }
            else if (param.ToString().Equals("Data"))
            {
                node.UnitHeight = 56;
                node.UnitWidth = 95;
                node.Ports = new PortCollection
                                 {
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.1,
                                             NodeOffsetY = 0.5,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 0,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.9,
                                             NodeOffsetY = 0.5,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 1,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         }
                                 };
            }
            else if (param.ToString().Equals("ManualInput"))
            {
                node.UnitHeight = 56;
                node.UnitWidth = 95;
                node.Ports = new PortCollection
                                 {
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0,
                                             NodeOffsetY = 0.5,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 0.2,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 1,
                                             NodeOffsetY = 0.5,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortVM
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 1,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         }
                                 };
            }

            connector.Constraints |= ConnectorConstraints.AllowDrop;
            node.Constraints |= NodeConstraints.AllowDrop;
            (this.Diagram.Nodes as ObservableCollection<NodeVM>).Add(node);
            connector.TargetNode = node;
            (this.Diagram.Connectors as ObservableCollection<ConnectorVM>).Add(connector);
            node.IsSelected = true;
        }

        /// <summary>
        /// The on right button visibility command execute.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private void OnRightButtonVisibilityCommandExecute(object param)
        {
        }

        /// <summary>
        /// To show the collection of shapes panel on quick command click
        /// </summary>
        /// <param name="param">
        /// value for direction of shapes panel
        /// </param>
        private void OnShowShapesCollectionsPanelCommandExecute(object param)
        {
            this.PanelVisibility = Visibility.Visible;
            this.PanelDirection = param.ToString();

            if (this.IsNodeSelected)
            {
                NodeVM node = (this.Nodes as ObservableCollection<object>).First() as NodeVM;
                if (node.RotateAngle != 0)
                {
                    if (45 < node.RotateAngle && node.RotateAngle < 135)
                    {
                        if (this.PanelDirection == "Top")
                        {
                            this.PanelDirection = "Right";
                        }
                        else if (this.PanelDirection == "Right")
                        {
                            this.PanelDirection = "Bottom";
                        }
                        else if (this.PanelDirection == "Bottom")
                        {
                            this.PanelDirection = "Left";
                        }
                        else if (this.PanelDirection == "Left")
                        {
                            this.PanelDirection = "Top";
                        }
                    }
                    else if (135 < node.RotateAngle && node.RotateAngle < 225)
                    {
                        if (this.PanelDirection == "Top")
                        {
                            this.PanelDirection = "Bottom";
                        }
                        else if (this.PanelDirection == "Right")
                        {
                            this.PanelDirection = "Left";
                        }
                        else if (this.PanelDirection == "Bottom")
                        {
                            this.PanelDirection = "Top";
                        }
                        else if (this.PanelDirection == "Left")
                        {
                            this.PanelDirection = "Right";
                        }
                    }
                    else if (225 < node.RotateAngle && node.RotateAngle < 315)
                    {
                        if (this.PanelDirection == "Top")
                        {
                            this.PanelDirection = "Left";
                        }
                        else if (this.PanelDirection == "Right")
                        {
                            this.PanelDirection = "Top";
                        }
                        else if (this.PanelDirection == "Bottom")
                        {
                            this.PanelDirection = "Right";
                        }
                        else if (this.PanelDirection == "Left")
                        {
                            this.PanelDirection = "Bottom";
                        }
                    }
                }
            }

            if (param.ToString().Equals("Left"))
            {
                this.PanelMargin = new Thickness(-145, 0, 0, 0);
                this.PanelHorizontalAlignment = HorizontalAlignment.Left;
                this.PanelVerticalAlignment = VerticalAlignment.Center;
            }
            else if (param.ToString().Equals("Right"))
            {
                this.PanelMargin = new Thickness(172, 0, 0, 0);
                this.PanelHorizontalAlignment = HorizontalAlignment.Right;
                this.PanelVerticalAlignment = VerticalAlignment.Center;
            }
            else if (param.ToString().Equals("Bottom"))
            {
                this.PanelMargin = new Thickness(0, 180, 0, 0);
                this.PanelHorizontalAlignment = HorizontalAlignment.Center;
                this.PanelVerticalAlignment = VerticalAlignment.Bottom;
            }
            else if (param.ToString().Equals("Top"))
            {
                this.PanelMargin = new Thickness(0, -172, 0, 0);
                this.PanelHorizontalAlignment = HorizontalAlignment.Center;
                this.PanelVerticalAlignment = VerticalAlignment.Top;
            }
        }
    }
}