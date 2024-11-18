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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class CommandsViewModel : DiagramViewModel
    {
        #region Field

        private ICommand _AllCommand;
        private bool _enabled;
        private bool _flipenabled;
        private bool first = true;

        #endregion

        ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/Syncfusion.SfDiagram.Wpf;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
        };

        #region Constructor

        public CommandsViewModel()
        {
            Constraints = GraphConstraints.Default | GraphConstraints.Undoable;

            HorizontalRuler = new Ruler() { Orientation = Orientation.Horizontal };

            VerticalRuler = new Ruler() { Orientation = Orientation.Vertical };

            SelectedItems = new SelectorViewModel()
            {
                SelectorConstraints = SelectorConstraints.Default & ~SelectorConstraints.QuickCommands,
            };

            ItemSelectedCommand = new DelegateCommand(OnItemSelectedCommand);
            ItemUnSelectedCommand = new DelegateCommand(OnItemUnSelectedCommand);
            ViewPortChangedCommand = new DelegateCommand(OnViewPortChangedCommand);

            AllCommand = new DelegateCommand(OnAllCommandExecution);

            CreateNode(40, 60, 150, 100, (SolidColorBrush)(new BrushConverter().ConvertFrom("#DAEBFF")), "");
            CreateNode(40, 80, 150, 170, (SolidColorBrush)(new BrushConverter().ConvertFrom("#F5E0F7")), "");
            CreateNode(40, 100, 150, 240, (SolidColorBrush)(new BrushConverter().ConvertFrom("#E0E5BB")), "");

            CreateNode(60, 40, 80, 470, (SolidColorBrush)(new BrushConverter().ConvertFrom("#DAEBFF")), "");
            CreateNode(80, 40, 160, 470, (SolidColorBrush)(new BrushConverter().ConvertFrom("#F5E0F7")), "");
            CreateNode(100, 40, 240, 470, (SolidColorBrush)(new BrushConverter().ConvertFrom("#E0E5BB")), "");

            CreateNode(40, 80, 525, 100, (SolidColorBrush)(new BrushConverter().ConvertFrom("#DAEBFF")), "");
            CreateNode(40, 80, 675, 100, (SolidColorBrush)(new BrushConverter().ConvertFrom("#F5E0F7")), "");
            CreateNode(40, 80, 645, 180, (SolidColorBrush)(new BrushConverter().ConvertFrom("#E0E5BB")), "");

            CreateNode(40, 80, 525, 400, (SolidColorBrush)(new BrushConverter().ConvertFrom("#DAEBFF")), "");
            CreateNode(40, 80, 525, 500, (SolidColorBrush)(new BrushConverter().ConvertFrom("#F5E0F7")), "");
            CreateNode(40, 80, 675, 430, (SolidColorBrush)(new BrushConverter().ConvertFrom("#E0E5BB")), "");

            CommandsCustomNodeViewModel leftNode = new CommandsCustomNodeViewModel
            {
                UnitHeight = 70,
                UnitWidth = 70,
                OffsetX = 1060,
                OffsetY = 100,
                FillColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E0E5BB")),
                Shape = resourceDictionary["RightTriangle"],
                Annotations = null,
                Key = "Flip",
                Ports = new PortCollection()
                { new NodePortViewModel()
                    {
                    ID = "leftNodePort",
                    NodeOffsetX = 0.5,
                    NodeOffsetY = 0.5,
                    } 
                }
            };
            CommandsCustomNodeViewModel rightNode = new CommandsCustomNodeViewModel
            {
                UnitHeight = 70,
                UnitWidth = 70,
                OffsetX = 1160,
                OffsetY = 150,
                FillColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E0E5BB")),
                Shape = resourceDictionary["RightTriangle"],
                Annotations = null,
                Key = "Flip",
                Ports = new PortCollection ()
                { new NodePortViewModel()
                    {
                    ID = "rightNodePort",
                    NodeOffsetX = 0,
                    NodeOffsetY = 0.5,
                    }
                }
            };
            ConnectorViewModel connector = new ConnectorViewModel() {SourcePortID = "leftNodePort", TargetPortID = "rightNodePort" };
            (Connectors as ConnectorCollection).Add(connector);

            GroupViewModel group = new GroupViewModel()
            {
                Key = "Flip",
                Nodes = new NodeCollection()
                {
                    leftNode, rightNode
                },
                Connectors = new ConnectorCollection() { connector }
            };

            CreateNode(20, 60, 1100, 350, (SolidColorBrush)(new BrushConverter().ConvertFrom("#DAEBFF")), "");
            CreateNode(40, 80, 1100, 420, (SolidColorBrush)(new BrushConverter().ConvertFrom("#F5E0F7")), "");
            CreateNode(50, 100, 1100, 500, (SolidColorBrush)(new BrushConverter().ConvertFrom("#E0E5BB")), "");

            (Nodes as NodeCollection).Add(leftNode);
            (Nodes as NodeCollection).Add(rightNode);
            (Groups as GroupCollection).Add(group);

            CreateNode(20, 200, 150, 40, new SolidColorBrush(Colors.Transparent), "Select the below nodes");
            CreateNode(50, 250, 150, 300, new SolidColorBrush(Colors.Transparent), "Try Alignment Commands(AlignLeft, AlignRight and AlignCenter)");
            CreateNode(20, 200, 150, 370, new SolidColorBrush(Colors.Transparent), "Select the below nodes");
            CreateNode(50, 250, 170, 550, new SolidColorBrush(Colors.Transparent), "Try Alignment Commands(AlignTop, AlignBottom and AlignMiddle)");
            CreateNode(20, 200, 600, 40, new SolidColorBrush(Colors.Transparent), "Select the below nodes");
            CreateNode(20, 250, 600, 240, new SolidColorBrush(Colors.Transparent), "Try SpaceAcross Command");
            CreateNode(20, 200, 600, 320, new SolidColorBrush(Colors.Transparent), "Select the below nodes");
            CreateNode(20, 250, 600, 550, new SolidColorBrush(Colors.Transparent), "Try SpaceDown Command");
            CreateNode(20, 200, 1100, 40, new SolidColorBrush(Colors.Transparent), "Select the below Group");
            CreateNode(20, 250, 1100, 240, new SolidColorBrush(Colors.Transparent), "Try Flip Commands");
            CreateNode(20, 200, 1100, 300, new SolidColorBrush(Colors.Transparent), "Select the below nodes");
            CreateNode(20, 250, 1100, 550, new SolidColorBrush(Colors.Transparent), "Try Sizing Commands");
        }

        #endregion

        #region Property and Command

        public ICommand AllCommand
        {
            get { return _AllCommand; }
            set { _AllCommand = value; }
        }

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

        public bool FlipEnabled
        {
            get
            {
                return _flipenabled;
            }
            set
            {
                if (_flipenabled != value)
                {
                    _flipenabled = value;
                    OnPropertyChanged("FlipEnabled");
                }
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// This method is used to execute ItemUnSelected Command
        /// </summary>
        /// <param name="obj"></param>
        private void OnItemUnSelectedCommand(object obj)
        {
            Enabled = false;
            FlipEnabled = false;
        }

        /// <summary>
        /// This method is used to execute ItemSelected Command
        /// </summary>
        /// <param name="obj"></param>
        private void OnItemSelectedCommand(object obj)
        {
            if (((SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).Count() > 0)
            {
                if (((SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).Count() == 1)
                {
                    Enabled = true;
                    CommandsCustomNodeViewModel FlipNode = ((SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).First() as CommandsCustomNodeViewModel;
                    if (FlipNode.Key != null && FlipNode.Key.ToString() == "Flip")
                    {
                        FlipEnabled = true;
                    }
                }
            }
            var selectedGroups = (SelectedItems as SelectorViewModel).Groups as IEnumerable<object>;
            if (selectedGroups.Count() > 0)
            {
                if (selectedGroups.Count() == 1)
                {
                    Enabled = true;
                    GroupViewModel FlipGroup = selectedGroups.First() as GroupViewModel;
                    // When duplicating(copy/paste), the Group "Key" property remains null since it's not defined in the source during deserialization processes
                    if (FlipGroup != null)
                    {
                        FlipEnabled = true;
                    }
                }

            }
        }
        private void OnViewPortChangedCommand(object obj)
        {
            var args = obj as ChangeEventArgs<object, ScrollChanged>;
            //WPF-858764-SfDiagram.IsLoaded always false when Nodes and Connector added to Group's Nodes and Connectors
            if (Info != null && args.NewValue.ContentBounds != args.OldValue.ContentBounds && first)
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

        /// <summary>
        /// This method is used to execute commands
        /// </summary>
        /// <param name="obj"></param>
        private void OnAllCommandExecution(object obj)
        {
            string item = obj as string;
            switch (item)
            {
                case "FlipVertical":
                    (Info as IGraphInfo).Commands.Flip.Execute(new FlipParameter() { Flip = Flip.VerticalFlip, FlipMode = FlipMode.FlipMode });
                    break;
                case "FlipHorizontal":
                    (Info as IGraphInfo).Commands.Flip.Execute(new FlipParameter() { Flip = Flip.HorizontalFlip, FlipMode = FlipMode.FlipMode });
                    break;
                case "RotateRight":
                    Rotate("Right");
                    break;
                case "RotateLeft":
                    Rotate("Left");
                    break;
            }
        }

        /// <summary>
        /// This method is used to execute Rotate function
        /// </summary>
        /// <param name="direction"></param>
        private void Rotate(string direction)
        {
            if (direction == "Right")
                (Info as IGraphInfo).Commands.Rotate.Execute(new RotateParameter() { RotationDirection = RotationDirection.Clockwise });
            else
                (Info as IGraphInfo).Commands.Rotate.Execute(new RotateParameter() { RotationDirection = RotationDirection.AntiClockwise });
        }


        /// <summary>
        /// This method is used to create Node
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="offsetx"></param>
        /// <param name="offsety"></param>
        /// <param name="fillcolor"></param>
        /// <param name="content"></param>
        /// <param name="rotateangle"></param>
        /// <returns></returns>
        private void CreateNode(double height, double width, double offsetx, double offsety, Brush fillcolor, string content)
        {
            CommandsCustomNodeViewModel node = new CommandsCustomNodeViewModel()
            {
                UnitHeight = height,
                UnitWidth = width,
                OffsetX = offsetx,
                OffsetY = offsety,
                FillColor = fillcolor,
                Shape = resourceDictionary["Rectangle"],
            };

            if (content != null && content != "")
            {
                node.Annotations = new AnnotationCollection()
                {
                    new TextAnnotationViewModel()
                    {
                        Text = content,
                        ReadOnly = true,
                        WrapText = TextWrapping.Wrap,
                        TextHorizontalAlignment = TextAlignment.Center,
                    },
                };

                node.Constraints = NodeConstraints.Default & ~NodeConstraints.Inherit & ~NodeConstraints.Selectable;
            }
            else
            {
                node.Annotations = null;
            }

            (Nodes as NodeCollection).Add(node);
        }

        #endregion
    }

    public class CommandsCustomNodeViewModel : NodeViewModel
    {
        private Brush _FillColor;
        public CommandsCustomNodeViewModel()
        {

        }

        [DataMember]
        public Brush FillColor
        {
            get
            {
                return _FillColor;
            }
            set
            {
                if (_FillColor != value)
                {
                    _FillColor = value;
                    OnPropertyChanged("FillColor");
                }
            }
        }
    }
}
