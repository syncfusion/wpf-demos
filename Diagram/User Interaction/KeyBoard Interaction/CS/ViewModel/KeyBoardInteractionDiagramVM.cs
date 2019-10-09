#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using UserInteraction_KeyBoardInteraction.Utilities;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Layout;
using Syncfusion.UI.Xaml.Diagram.Theming;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System.Windows.Controls;

namespace UserInteraction_KeyBoardInteraction.ViewModel
{
    public class KeyBoardInteractionDiagramVM : DiagramViewModel
    {

        #region Fields

        private ICommand _CustomUngroup;
        private ICommand _CustomGroup;
        private ICommand _ChildNode;
        private ICommand _ParentNode;
        private ICommand _NextChild;
        private ICommand _PreviousChild;

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the CustomGroup command value
        /// </summary>
        public ICommand CustomGroup
        {
            get { return _CustomGroup; }
            set { _CustomGroup = value; }
        }

        /// <summary>
        /// Gets or sets the CustomUngroup command value
        /// </summary>
        public ICommand CustomUngroup
        {
            get { return _CustomUngroup; }
            set { _CustomUngroup = value; }
        }

        /// <summary>
        /// Gets or sets the ChildNode command value
        /// </summary>
        public ICommand ChildNode
        {
            get { return _ChildNode; }
            set { _ChildNode = value; }
        }

        /// <summary>
        /// Gets or sets the ParentNode command value
        /// </summary>
        public ICommand ParentNode
        {
            get { return _ParentNode; }
            set { _ParentNode = value; }
        }

        /// <summary>
        /// Gets or sets the NextChild command value
        /// </summary>
        public ICommand NextChild
        {
            get { return _NextChild; }
            set { _NextChild = value; }
        }

        /// <summary>
        /// Gets or sets the PreviosChild command value
        /// </summary>
        public ICommand PreviousChild
        {
            get { return _PreviousChild; }
            set { _PreviousChild = value; }
        }

        #endregion

        public KeyBoardInteractionDiagramVM()
        {

            #region Properties

            Constraints = Constraints.Add(GraphConstraints.Undoable);

            DefaultConnectorType = ConnectorType.Line;

            PageSettings = new PageSettings()
            {
                PageBackground = new SolidColorBrush(Colors.Transparent),
                PageBorderBrush = new SolidColorBrush(Colors.Transparent),
            };

            SelectedItems = new SelectorViewModel()
            {
                SelectorConstraints = SelectorConstraints.Default & ~SelectorConstraints.QuickCommands, 
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




                
            Theme = new LinearTheme();      
            Theme.NodeStyles = (Theme as LinearTheme).VariantStyles[1];

            #endregion

            #region Nodes and Connectors Creation

            CustomNode Node1 = CreateNode(550, 100, "A", "SkyBlue","1","");
            CustomNode Node2 = CreateNode(450, 200, "B", "Red","2","1");
            CustomNode Node3 = CreateNode(550, 200, "C", "Red","3","1");
            CustomNode Node4 = CreateNode(650, 200, "D", "Red","4","1");
            CustomNode Node5 = CreateNode(400, 300, "E","Yellow","5","2");
            CustomNode Node6 = CreateNode(500, 300, "F", "Yellow","6","2");
            CustomNode Node7 = CreateNode(600, 300, "G", "Yellow", "7", "4");
            CustomNode Node8 = CreateNode(700, 300, "H", "Yellow", "8", "4");
            CustomNode Node9 = CreateNode(450, 400, "I", "Violet","9","6");
            CustomNode Node10 = CreateNode(550, 400, "J", "Violet","10","6");
            CustomNode Node11 = CreateNode(650, 400, "K", "Violet", "11", "8");
            CustomNode Node12 = CreateNode(750, 400, "L", "Violet", "12", "8");
            CustomNode Node13 = CreateNode(400, 500, "M", "Green","13","9");
            CustomNode Node14 = CreateNode(500, 500, "N", "Green","14","9");
            CustomNode Node15 = CreateNode(600, 500, "O", "Green", "15", "11");
            CustomNode Node16 = CreateNode(700, 500, "P", "Green", "16", "11");
            CustomNode Node17 = CreateNode(450, 600, "Q", "SkyBlue", "17", "14");
            CustomNode Node18 = CreateNode(550, 600, "R", "SkyBlue", "18", "14");
            CustomNode Node19 = CreateNode(650, 600, "S", "SkyBlue", "19", "16");
            CustomNode Node20 = CreateNode(750, 600, "T", "SkyBlue", "20", "16");

            (Nodes as NodeCollection).Add(Node1);
            (Nodes as NodeCollection).Add(Node2);
            (Nodes as NodeCollection).Add(Node3);
            (Nodes as NodeCollection).Add(Node4);
            (Nodes as NodeCollection).Add(Node5);
            (Nodes as NodeCollection).Add(Node6);
            (Nodes as NodeCollection).Add(Node7);
            (Nodes as NodeCollection).Add(Node8);
            (Nodes as NodeCollection).Add(Node9);
            (Nodes as NodeCollection).Add(Node10);
            (Nodes as NodeCollection).Add(Node11);
            (Nodes as NodeCollection).Add(Node12);
            (Nodes as NodeCollection).Add(Node13);
            (Nodes as NodeCollection).Add(Node14);
            (Nodes as NodeCollection).Add(Node15);
            (Nodes as NodeCollection).Add(Node16);
            (Nodes as NodeCollection).Add(Node17);
            (Nodes as NodeCollection).Add(Node18);
            (Nodes as NodeCollection).Add(Node19);
            (Nodes as NodeCollection).Add(Node20);

            CreateConnector(Node1, Node2);
            CreateConnector(Node1, Node3);
            CreateConnector(Node1, Node4);
            CreateConnector(Node2, Node5);
            CreateConnector(Node2, Node6);
            CreateConnector(Node4, Node7);
            CreateConnector(Node4, Node8);
            CreateConnector(Node6, Node9);
            CreateConnector(Node6, Node10);
            CreateConnector(Node8, Node11);
            CreateConnector(Node8, Node12);
            CreateConnector(Node9, Node13);
            CreateConnector(Node9, Node14);
            CreateConnector(Node11, Node15);
            CreateConnector(Node11, Node16);
            CreateConnector(Node14, Node17);
            CreateConnector(Node14, Node18);
            CreateConnector(Node16, Node19);
            CreateConnector(Node16, Node20);

            #endregion

            #region Commands and CommandManager

            // Custom command and Modified Commands

            CustomGroup = new Command(OnCustomGroupCommand);
            CustomUngroup = new Command(OnCustomUngroupCommand);
            ChildNode = new Command(OnChildNodeCommand);
            ParentNode = new Command(OnParentNodeCommand);
            NextChild = new Command(OnNextChildCommand);
            PreviousChild = new Command(OnPreviousChildCommand);

            ItemAddedCommand = new Command(OnItemAdded);

            CommandManager = new Syncfusion.UI.Xaml.Diagram.CommandManager();

            (CommandManager as Syncfusion.UI.Xaml.Diagram.CommandManager).Commands = new CommandCollection();

            (CommandManager.Commands as CommandCollection).Add
            (
                new GestureCommand()
                {
                    Name = "CustomGroup",
                    Command = CustomGroup,
                    Gesture = new Gesture
                    {
                        KeyModifiers = ModifierKeys.Control,
                        KeyState = KeyStates.Down,
                        Key = System.Windows.Input.Key.G,
                    },
                }
            );

            (CommandManager.Commands as CommandCollection).Add
            (
                new GestureCommand()
                {
                    Name = "CustomUngroup",
                    Command = CustomUngroup,
                    Gesture = new Gesture
                    {
                        KeyModifiers = ModifierKeys.Control,
                        KeyState = KeyStates.Down,
                        Key = System.Windows.Input.Key.U,
                    },
                }
            );


            (CommandManager.Commands as CommandCollection).Add
            (
                new GestureCommand()
                {
                    Name = "ChildNode",
                    Command = ChildNode,
                    Gesture = new Gesture
                    {
                        KeyState = KeyStates.Down,
                        Key = System.Windows.Input.Key.Down,
                    },
                }
            );


            (CommandManager.Commands as CommandCollection).Add
            (
                new GestureCommand()
                {
                    Name = "ParentNode",
                    Command = ParentNode,
                    Gesture = new Gesture
                    {
                        KeyState = KeyStates.Down,
                        Key = System.Windows.Input.Key.Up,
                    },
                }
            );

            (CommandManager.Commands as CommandCollection).Add
            (
                new GestureCommand()
                {
                    Name = "NextChild",
                    Command = NextChild,
                    Gesture = new Gesture
                    {
                        KeyState = KeyStates.Down,
                        Key = System.Windows.Input.Key.Right,
                    },
                }
            );

            (CommandManager.Commands as CommandCollection).Add
            (
                new GestureCommand()
                {
                    Name = "PreviousChild",
                    Command = PreviousChild,
                    Gesture = new Gesture
                    {
                        KeyState = KeyStates.Down,
                        Key = System.Windows.Input.Key.Left,
                    },
                }
            );

            #endregion

        }

        private void OnItemAdded(object obj)
        {
            ItemAddedEventArgs args = obj as ItemAddedEventArgs;

            if(args.Item is CustomNode)
            {
                foreach (var anno in (args.Item as CustomNode).Annotations as ObservableCollection<TextAnnotationViewModel>)
                {
                    (anno as TextAnnotationViewModel).FontFamily = new FontFamily("Calibri");
                }
            }
        }

        #region Helper Methods

        /// <summary>
        /// Method to find the previous child of the selected node.
        /// </summary>
        /// <param name="obj"></param>
        private void OnPreviousChildCommand(object obj)
        {
            SelectorViewModel selectorvm = this.SelectedItems as SelectorViewModel;
            if ((selectorvm.Nodes as ObservableCollection<object>).Count != 0)
            {
                CustomNode node = (selectorvm.Nodes as ObservableCollection<object>)[0] as CustomNode;
                NodeCollection nodes = Nodes as NodeCollection;
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (node == nodes[i])
                    {
                        for (int k = nodes.Count - 1; k >= 0; k--)
                        {
                            
                            if ((nodes[i] as CustomNode).ParentId == (nodes[k] as CustomNode).ParentId
                                && int.Parse((nodes[i] as CustomNode).Id) > int.Parse((nodes[k] as CustomNode).Id))
                            {
                                nodes[i].IsSelected = false;
                                nodes[k].IsSelected = true;
                                break;
                            }
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Method to find the next child of the selected node
        /// </summary>
        /// <param name="obj"></param>
        private void OnNextChildCommand(object obj)
        {
            SelectorViewModel selectorvm = this.SelectedItems as SelectorViewModel;
            if ((selectorvm.Nodes as ObservableCollection<object>).Count != 0)
            {
                CustomNode node = (selectorvm.Nodes as ObservableCollection<object>)[0] as CustomNode;
                NodeCollection nodes = Nodes as NodeCollection;

                for (int i = 0; i < nodes.Count; i++)
                {
                    if (node == nodes[i])
                    {
                        for (int k = i + 1; k < nodes.Count; k++)
                        {
                            if ((nodes[i] as CustomNode).ParentId == (nodes[k] as CustomNode).ParentId)
                            {
                                nodes[i].IsSelected = false;
                                nodes[k].IsSelected = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Method to find the parent node of the selected node.
        /// </summary>
        /// <param name="obj"></param>
        private void OnParentNodeCommand(object obj)
        {
            SelectorViewModel selectorvm = this.SelectedItems as SelectorViewModel;
            if ((selectorvm.Nodes as ObservableCollection<object>).Count != 0)
            {
                CustomNode node = (selectorvm.Nodes as ObservableCollection<object>)[0] as CustomNode;
                NodeCollection nodes = Nodes as NodeCollection;

                for (int i = 0; i < nodes.Count; i++)
                {
                    if (node == nodes[i])
                    {
                        for (int k = nodes.Count - 1; k >= 0; k--)
                        {
                            if ((nodes[i] as CustomNode).ParentId == (nodes[k] as CustomNode).Id)
                            {
                                nodes[i].IsSelected = false;
                                nodes[k].IsSelected = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Method to find the child of the selected node.
        /// </summary>
        /// <param name="obj"></param>
        private void OnChildNodeCommand(object obj)
        {
            SelectorViewModel selectorvm = this.SelectedItems as SelectorViewModel;
            if ((selectorvm.Nodes as ObservableCollection<object>).Count != 0)
            {
                CustomNode node = (selectorvm.Nodes as ObservableCollection<object>)[0] as CustomNode;
                NodeCollection nodes = Nodes as NodeCollection;

                for (int i = 0; i < nodes.Count; i++)
                {
                    if (node == nodes[i])
                    {
                        for (int k = i; k < nodes.Count; k++)
                        {
                            if ((nodes[i] as CustomNode).Id == (nodes[k] as CustomNode).ParentId)
                            {
                                nodes[i].IsSelected = false;
                                nodes[k].IsSelected = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Methdo to execute ungroup command
        /// </summary>
        /// <param name="obj"></param>
        private void OnCustomUngroupCommand(object obj)
        {
            (this.Info as IGraphInfo).Commands.UnGroup.Execute(null);
        }

        /// <summary>
        /// Method to execute group command
        /// </summary>
        /// <param name="obj"></param>
        private void OnCustomGroupCommand(object obj)
        {
            (this.Info as IGraphInfo).Commands.Group.Execute(null);
        }

        /// <summary>
        /// Method to create connector
        /// </summary>
        /// <param name="node1">Source Node of the connector</param>
        /// <param name="node2">Target Node of the connector</param>
        private void CreateConnector(NodeViewModel node1, NodeViewModel node2)
        {
            ConnectorViewModel connector = new ConnectorViewModel()
            {
                SourceNode = node1,
                TargetNode = node2,
                ConnectorGeometryStyle = App.Current.Resources["ConnectorStyle"] as Style,
                TargetDecoratorStyle = App.Current.Resources["ConnectorStyle"] as Style,
            };

            (Connectors as ConnectorCollection).Add(connector);
        }

        /// <summary>
        /// Method to create Node
        /// </summary>
        /// <param name="offsetx"></param>
        /// <param name="offsety"></param>
        /// <param name="annotation"></param>
        /// <param name="shapestyle"></param>
        /// <param name="id"></param>
        /// <param name="parentid"></param>
        /// <returns></returns>
        private CustomNode CreateNode(double offsetx, double offsety, string annotation, string shapestyle, string id, string parentid)
        {
            CustomNode node = new CustomNode()
            {
                OffsetX = offsetx,
                OffsetY = offsety,
                UnitHeight = 60,
                UnitWidth = 60,
                Id = id,
                ParentId = parentid,
                Shape = App.Current.Resources["Ellipse"],
                Annotations = new ObservableCollection<TextAnnotationViewModel>()
                {
                    new TextAnnotationViewModel()
                    {
                        Text = annotation,
                    },
                }
            };

            if (shapestyle == "Red")
            {
                node.ThemeStyleId = StyleId.Moderate | StyleId.Accent6;
            }

            else if(shapestyle == "Yellow")
            {
                node.ThemeStyleId = StyleId.Moderate | StyleId.Accent7;
            }

            else if (shapestyle == "Green")
            {
                node.ThemeStyleId = StyleId.Intense | StyleId.Accent5;
            }

            else if (shapestyle == "Violet")
            {
                node.ThemeStyleId = StyleId.Intense | StyleId.Accent2;
            }

            return node;
        }

        #endregion
    }
}
