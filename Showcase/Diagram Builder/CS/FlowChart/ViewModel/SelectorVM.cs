#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiagramBuilder.ViewModel;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using DiagramBuilder.Utility;
using DiagramBuilder;
using Syncfusion.UI.Xaml.Diagram;

namespace FlowChart.ViewModel
{
    /// <summary>
    /// Custom selectot class used to change the selector appearance
    /// </summary>
    public class FlowChartSelectorVm : SelectorVM
    {
        /// <summary>
        /// To handle the collections of shapes visisbility
        /// </summary>
        private Visibility _mPanelVisibity = Visibility.Collapsed;

        /// <summary>
        /// To handle the shapes collections margin 
        /// </summary>
        private Thickness _mPanelMargin;

        /// <summary>
        /// To handle horizontal alignment for shapes panel
        /// </summary>
        private HorizontalAlignment panelHorizontalAlignment = HorizontalAlignment.Center;

        /// <summary>
        /// To handle vertical alignment for shapes panel
        /// </summary>
        private VerticalAlignment panelVertiaclAlignment = VerticalAlignment.Center;

        /// <summary>
        /// To handle direction of the collection of shapes panel.
        /// </summary>
        private string panelDirection;

        /// <summary>
        /// To have offset X values of node added to the diagram newly
        /// </summary>
        private double offsetx = 350;

        /// <summary>
        /// To have offset Y values of node added to the diagram newly
        /// </summary>
        private double offsety = 300;

        /// <summary>
        /// Holds visibility value of right side quick button.
        /// </summary>
        private Visibility _rightButtonVisibility = Visibility.Visible;

        /// <summary>
        /// Holds visibility value of left side quick button.
        /// </summary>
        private Visibility _leftButtonVisibility = Visibility.Visible;

        /// <summary>
        /// Holds visibility value of top side quick button.
        /// </summary>
        private Visibility _topButtonVisibility = Visibility.Visible;

        /// <summary>
        /// Holds visibility value of bottom side quick button.
        /// </summary>
        private Visibility _bottomButtonVisibility = Visibility.Visible;

        /// <summary>
        /// To hold instance of DiagramVm class
        /// </summary>
        //private FlowDiagramVm Diagram;

        //Command used to show collections of shapes panel with selector elements
        public ICommand ShowShapesCollectionsPanelCommand { get; set; }

        //Command used to add shapes into diagram when click on particular shapes
        public ICommand AddShapesCommand { get; set; }

        //Command used to control visibility of right side button.
        public ICommand RightButtonVisibilityCommand { get; set; }

        /// <summary>
        /// Gets or sets value for collections of Shapes pannel visibility
        /// </summary>
        public Visibility PanelVisibility
        {
            get
            {
                return _mPanelVisibity;
            }

            set
            {
                if (_mPanelVisibity != value)
                {
                    _mPanelVisibity = value;
                    OnPropertyChanged("PanelVisibility");
                }
            }
        }

        public Visibility RightButtonVisibility
        {
            get
            {
                return _rightButtonVisibility;
            }

            set
            {
                if (value != _rightButtonVisibility)
                {
                    _rightButtonVisibility = value;
                    OnPropertyChanged("RightButtonVisibility");
                }
            }
        }

        /// <summary>
        /// Gets or sets value for Left Button visibility.
        /// </summary>
        public Visibility LeftButtonVisibility
        {
            get
            {
                return _leftButtonVisibility;
            }

            set
            {
                if (value != _leftButtonVisibility)
                {
                    _leftButtonVisibility = value;
                    OnPropertyChanged("LeftButtonVisibility");
                }
            }
        }

        /// <summary>
        /// Gets or sets value for Left Button visibility.
        /// </summary>
        public Visibility TopButtonVisibility
        {
            get
            {
                return _topButtonVisibility;
            }

            set
            {
                if (value != _topButtonVisibility)
                {
                    _topButtonVisibility = value;
                    OnPropertyChanged("TopButtonVisibility");
                }
            }
        }

        /// <summary>
        /// Gets or sets value for Left Button visibility.
        /// </summary>
        public Visibility BottomButtonVisibility
        {
            get
            {
                return _bottomButtonVisibility;
            }

            set
            {
                if (value != _bottomButtonVisibility)
                {
                    _bottomButtonVisibility = value;
                    OnPropertyChanged("BottomButtonVisibility");
                }
            }
        }

        /// <summary>
        /// Gets or sets margin value for shapes collections pannel
        /// </summary>
        public Thickness PanelMargin
        {
            get
            {
                return _mPanelMargin;
            }

            set
            {
                if (_mPanelMargin != value)
                {
                    _mPanelMargin = value;
                    OnPropertyChanged("PanelMargin");
                }
            }
        }

        /// <summary>
        /// Gets or sets value for Shapes collection panel's horizontal alignment
        /// </summary>
        public HorizontalAlignment PanelHorizontalAlignment
        {
            get
            {
                return panelHorizontalAlignment;
            }

            set
            {
                if (value != panelHorizontalAlignment)
                {
                    panelHorizontalAlignment = value;
                    OnPropertyChanged("PanelHorizontalAlignment");
                }
            }
        }

        /// <summary>
        /// Gets or sets value for Shapes collection panel's vertical alignment
        /// </summary>
        public VerticalAlignment PanelVerticalAlignment
        {
            get
            {
                return panelVertiaclAlignment;
            }
            set
            {
                if (value != panelVertiaclAlignment)
                {
                    panelVertiaclAlignment = value;
                    OnPropertyChanged("PanelVerticalAlignment");
                }
            }
        }

        private double panelAngle = 0;

        public double PanelAngle
        {
            get
            {
                return panelAngle;
            }
            set
            {
                if (value != panelAngle)
                {
                    panelAngle = value;
                    OnPropertyChanged("PanelAngle");
                }
            }
        }

        /// <summary>
        /// Gets or set value of Panel direction which used to add the node exactly same side of the panel direction
        /// </summary>
        public string PanelDirection
        {
            get
            {
                return panelDirection;
            }
            set
            {
                if (value != panelDirection)
                {
                    panelDirection = value;
                    OnPropertyChanged(PanelDirection);
                }
            }
        }

        protected override void OnPropertyChanged(string name)
        {
            if (name == "RotateAngle")
            {
                this.PanelAngle = 360 - base.RotateAngle;
                this.PanelVisibility = Visibility.Hidden;
            }         
            base.OnPropertyChanged(name);
        }

        public FlowChartSelectorVm(FlowDiagramVm diagram) : base(diagram)
        {
            //Diagram = diagram;
            ShowShapesCollectionsPanelCommand = new Command(OnShowShapesCollectionsPanelCommandExecute);
            AddShapesCommand = new Command(OnAddShapesCommand);
            RightButtonVisibilityCommand = new Command(OnRightButtonVisibilityCommandExecute);
        }

        void OnRightButtonVisibilityCommandExecute(object param)
        {

        }

        /// <summary>
        /// Command for adding shapes into diagram
        /// </summary>
        /// <param name="param"> Name of the shape</param>
        void OnAddShapesCommand(object param)
        {
            ConnectorVM connector = new ConnectorVM()
            {

            };

            var nodescollection = Diagram.Nodes as ObservableCollection<NodeVM>;
            NodeVM selectedNode = (this.Nodes as ObservableCollection<object>).First() as NodeVM;
            if (selectedNode != null)
            {
                Rect selectedNodeBounds = (selectedNode.Info as INodeInfo).Bounds;
                if (PanelDirection == "Right")
                {
                    offsetx = selectedNodeBounds.Right + 100;
                    offsety = selectedNode.OffsetY;
                }
                else if (PanelDirection == "Left")
                {
                    offsetx = selectedNodeBounds.Left - 100;
                    offsety = selectedNode.OffsetY;
                }
                else if (PanelDirection == "Top")
                {
                    offsetx = selectedNode.OffsetX;
                    offsety = selectedNodeBounds.Top - 75;
                }
                else if (PanelDirection == "Bottom")
                {
                    offsetx = selectedNode.OffsetX;
                    offsety = selectedNodeBounds.Bottom + 75;
                }
                connector.SourceNode = selectedNode;
                selectedNode.IsSelected = false;
            }


            NodeVM node = new NodeVM()
            {
                OffsetX = offsetx,
                OffsetY = offsety,
                Shape = App.Current.Resources[param],
            };

            if (param.ToString().Equals("Process") || param.ToString().Equals("Decision") || param.ToString().Equals("MultiDocument") ||
                param.ToString().Equals("Terminator") || param.ToString().Equals("Sort") || param.ToString().Equals("Document") ||
                param.ToString().Equals("DirectData") || param.ToString().Equals("ManualOperation") || param.ToString().Equals("InternalStorage") ||
                param.ToString().Equals("Card") || param.ToString().Equals("PredefinedProcess") || param.ToString().Equals("Or"))
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
                    node.Ports = new DiagramBuilder.ViewModel.PortCollection()
                    {
                        new NodePortVM()
                        {
                            NodeOffsetX =0,
                            NodeOffsetY =0.5,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {

                            NodeOffsetX =0.5,
                            NodeOffsetY =0,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {
                            NodeOffsetX =1,
                            NodeOffsetY =0.5,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {
                            NodeOffsetX =0.5,
                            NodeOffsetY =0.9,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                    };
                }
                else if (param.ToString().Equals("ManualOperation"))
                {
                    node.Ports = new DiagramBuilder.ViewModel.PortCollection()
                    {
                        new NodePortVM()
                        {
                            NodeOffsetX =0.1,
                            NodeOffsetY =0.5,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {

                            NodeOffsetX =0.5,
                            NodeOffsetY =0,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {
                            NodeOffsetX =0.9,
                            NodeOffsetY =0.5,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {
                            NodeOffsetX =0.5,
                            NodeOffsetY =1,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                    };
                }
                else
                {
                    node.Ports = new DiagramBuilder.ViewModel.PortCollection()
                    {
                        new NodePortVM()
                        {
                            NodeOffsetX =0,
                            NodeOffsetY =0.5,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {

                            NodeOffsetX =0.5,
                            NodeOffsetY =0,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {
                            NodeOffsetX =1,
                            NodeOffsetY =0.5,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {
                            NodeOffsetX =0.5,
                            NodeOffsetY =1,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                    };
                }
            }
            else if (param.ToString().Equals("SequentialData") || param.ToString().Equals("SequentialAccessStorage"))
            {
                node.UnitHeight = 95;
                node.UnitWidth = 95;
                node.Ports = new DiagramBuilder.ViewModel.PortCollection()
                    {
                        new NodePortVM()
                        {
                            NodeOffsetX =0,
                            NodeOffsetY =0.5,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {

                            NodeOffsetX =0.5,
                            NodeOffsetY =0,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {
                            NodeOffsetX =0.95,
                            NodeOffsetY =0.5,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {
                            NodeOffsetX =0.5,
                            NodeOffsetY =1,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {
                            NodeOffsetX =1,
                            NodeOffsetY =1,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                    };

            }
            else if (param.ToString().Equals("Collate"))
            {
                node.UnitHeight = 75;
                node.UnitWidth = 75;
                node.Ports = new DiagramBuilder.ViewModel.PortCollection()
                    {
                        new NodePortVM()
                        {
                            NodeOffsetX =0.5,
                            NodeOffsetY =0,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {

                            NodeOffsetX =0.5,
                            NodeOffsetY =0.5,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {
                            NodeOffsetX =0.5,
                            NodeOffsetY =1,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                    };
            }
            else if (param.ToString().Equals("SummingJunction"))
            {
                node.UnitHeight = 75;
                node.UnitWidth = 75;
                node.Ports = new DiagramBuilder.ViewModel.PortCollection()
                    {
                        new NodePortVM()
                        {
                            NodeOffsetX =0.5,
                            NodeOffsetY =0,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {

                            NodeOffsetX =0,
                            NodeOffsetY =0.5,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {
                            NodeOffsetX =1,
                            NodeOffsetY =0.5,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {
                            NodeOffsetX =0.5,
                            NodeOffsetY =1,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                         new NodePortVM()
                        {
                            NodeOffsetX =0.15,
                            NodeOffsetY =0.15,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {
                            NodeOffsetX =0.85,
                            NodeOffsetY =0.15,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {
                            NodeOffsetX =0.15,
                            NodeOffsetY =0.85,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                            new NodePortVM()
                        {
                            NodeOffsetX =0.85,
                            NodeOffsetY =0.85,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                    };
            }
            else if (param.ToString().Equals("Extract") || param.ToString().Equals("Merge"))
            {
                node.UnitHeight = 75;
                node.UnitWidth = 75;
                node.Ports = new DiagramBuilder.ViewModel.PortCollection()
                    {
                        new NodePortVM()
                        {
                            NodeOffsetX =0.5,
                            NodeOffsetY =0,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {

                            NodeOffsetX =0.5,
                            NodeOffsetY =1,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {
                            NodeOffsetX =0.25,
                            NodeOffsetY =0.5,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {
                            NodeOffsetX =0.75,
                            NodeOffsetY =0.5,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                    };
            }
            else if (param.ToString().Equals("OffPageReference"))
            {
                node.UnitHeight = 45;
                node.UnitWidth = 45;
                node.Ports = new DiagramBuilder.ViewModel.PortCollection()
                    {
                        new NodePortVM()
                        {
                            NodeOffsetX =0.5,
                            NodeOffsetY =0,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {

                            NodeOffsetX =0.5,
                            NodeOffsetY =1,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {
                            NodeOffsetX =0,
                            NodeOffsetY =0.7,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {
                            NodeOffsetX =1,
                            NodeOffsetY =0.7,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                    };
            }
            else if (param.ToString().Equals("StoredData"))
            {
                node.UnitHeight = 56;
                node.UnitWidth = 95;
                node.Ports = new DiagramBuilder.ViewModel.PortCollection()
                    {
                        new NodePortVM()
                        {
                            NodeOffsetX =0,
                            NodeOffsetY =0.5,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {

                            NodeOffsetX =0.5,
                            NodeOffsetY =0,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {
                            NodeOffsetX =0.9,
                            NodeOffsetY =0.5,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {
                            NodeOffsetX =0.5,
                            NodeOffsetY =1,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                    };
            }
            else if (param.ToString().Equals("Data"))
            {
                node.UnitHeight = 56;
                node.UnitWidth = 95;
                node.Ports = new DiagramBuilder.ViewModel.PortCollection()
                    {
                        new NodePortVM()
                        {
                            NodeOffsetX =0.1,
                            NodeOffsetY =0.5,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {

                            NodeOffsetX =0.5,
                            NodeOffsetY =0,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {
                            NodeOffsetX =0.9,
                            NodeOffsetY =0.5,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {
                            NodeOffsetX =0.5,
                            NodeOffsetY =1,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                    };
            }
            else if (param.ToString().Equals("ManualInput"))
            {
                node.UnitHeight = 56;
                node.UnitWidth = 95;
                node.Ports = new DiagramBuilder.ViewModel.PortCollection()
                    {
                        new NodePortVM()
                        {
                            NodeOffsetX =0,
                            NodeOffsetY =0.5,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {

                            NodeOffsetX =0.5,
                            NodeOffsetY =0.2,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {
                            NodeOffsetX =1,
                            NodeOffsetY =0.5,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                        new NodePortVM()
                        {
                            NodeOffsetX =0.5,
                            NodeOffsetY =1,
                            Shape = App.Current.Resources["Rectangle"],
                            ShapeStyle = App.Current.Resources["portShapeStyle"] as Style,
                        },
                    };
            }

            connector.Constraints |= ConnectorConstraints.AllowDrop;
            node.Constraints |= NodeConstraints.AllowDrop;
            (Diagram.Nodes as ObservableCollection<NodeVM>).Add(node);
            connector.TargetNode = node;
            (Diagram.Connectors as ObservableCollection<ConnectorVM>).Add(connector);
            node.IsSelected = true;
        }

        /// <summary>
        /// To show the collection of shapes panel on quick command click
        /// </summary>
        /// <param name="param">value for direction of shapes panel</param>
        void OnShowShapesCollectionsPanelCommandExecute(object param)
        {
            PanelVisibility = Visibility.Visible;
            PanelDirection = param.ToString();

            if( this.IsNodeSelected)
            {
                NodeVM node = (this.Nodes as ObservableCollection<object>).First() as NodeVM;
                if (node.RotateAngle != 0 )
                {
                    if (45 < node.RotateAngle && node.RotateAngle < 135)
                    {
                        if (PanelDirection == "Top")
                        {
                            PanelDirection = "Right";
                        }
                        else if (PanelDirection == "Right")
                        {
                            PanelDirection = "Bottom";
                        }
                        else if (PanelDirection == "Bottom")
                        {
                            PanelDirection = "Left";
                        }
                        else if(PanelDirection == "Left")
                        {
                            PanelDirection = "Top";
                        }
                    }
                    else if (135 < node.RotateAngle && node.RotateAngle < 225)
                    {
                        if (PanelDirection == "Top")
                        {
                            PanelDirection = "Bottom";
                        }
                        else if (PanelDirection == "Right")
                        {
                            PanelDirection = "Left";
                        }
                        else if (PanelDirection == "Bottom")
                        {
                            PanelDirection = "Top";
                        }
                        else if (PanelDirection == "Left")
                        {
                            PanelDirection = "Right";
                        }
                    }
                    else if (225 < node.RotateAngle && node.RotateAngle < 315)
                    {
                        if (PanelDirection == "Top")
                        {
                            PanelDirection = "Left";
                        }
                        else if (PanelDirection == "Right")
                        {
                            PanelDirection = "Top";
                        }
                        else if (PanelDirection == "Bottom")
                        {
                            PanelDirection = "Right";
                        }
                        else if (PanelDirection == "Left")
                        {
                            PanelDirection = "Bottom";
                        }
                    }
                }
            }
           

            if (param.ToString().Equals("Left"))
            {
                PanelMargin = new Thickness(-145, 0, 0, 0);
                PanelHorizontalAlignment = HorizontalAlignment.Left;
                PanelVerticalAlignment = VerticalAlignment.Center;
            }
            else if (param.ToString().Equals("Right"))
            {
                PanelMargin = new Thickness(172, 0, 0, 0);
                PanelHorizontalAlignment = HorizontalAlignment.Right;
                PanelVerticalAlignment = VerticalAlignment.Center;
            }
            else if (param.ToString().Equals("Bottom"))
            {
                PanelMargin = new Thickness(0, 180, 0, 0);
                PanelHorizontalAlignment = HorizontalAlignment.Center;
                PanelVerticalAlignment = VerticalAlignment.Bottom;
            }
            else if (param.ToString().Equals("Top"))
            {
                PanelMargin = new Thickness(0, -172, 0, 0);
                PanelHorizontalAlignment = HorizontalAlignment.Center;
                PanelVerticalAlignment = VerticalAlignment.Top;
            }
        }
    }
}
