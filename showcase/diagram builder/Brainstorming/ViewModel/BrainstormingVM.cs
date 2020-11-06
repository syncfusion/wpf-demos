// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BrainstormingVM.cs" company="">
//   
// </copyright>
// <summary>
//   The brainstorming vm.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using CoreVirtualKeyStates = System.Windows.Input.KeyStates;
using VirtualKey = System.Windows.Input.Key;

namespace Brainstorming.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;

    using Brainstorming.Layout;

    using DiagramBuilder;
    using DiagramBuilder.ViewModel;

    using Syncfusion.UI.Xaml.Diagram;
    using Syncfusion.UI.Xaml.Diagram.Controls;
    using Syncfusion.UI.Xaml.Diagram.Layout;
    using Syncfusion.UI.Xaml.Diagram.Theming;
    using Syncfusion.Windows.Shared;

    using CommandManager = Syncfusion.UI.Xaml.Diagram.CommandManager;

    /// <summary>
    ///     The brainstorming vm.
    /// </summary>
    public class BrainstormingVM : DiagramVM
    {

        ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/syncfusion.diagrambuilder.Wpf;component/Brainstorming/Theme/BrainstormingUI.xaml", UriKind.RelativeOrAbsolute)
        };

        /// <summary>
        ///     The quickcommands_ delete.
        /// </summary>
        public QuickCommandViewModel QuickCommands_Delete;

        /// <summary>
        ///     The quickcommands_ left.
        /// </summary>
        public QuickCommandViewModel QuickCommands_Left;

        /// <summary>
        ///     The quickcommands_ right.
        /// </summary>
        public QuickCommandViewModel QuickCommands_Right;

        // Adding child to root node alternate side when execute the peer command        
        /// <summary>
        ///     The add child at left.
        /// </summary>
        internal bool addChildAtLeft;

        /// <summary>
        ///     The _connectors.
        /// </summary>
        private ConnectorVMCollection _connectors = new ConnectorVMCollection();

        /// <summary>
        ///     The _m level styles.
        /// </summary>
        private Dictionary<int, System.Tuple<string, StyleId>> _mLevelStyles;

        /// <summary>
        ///     The _m rootnode.
        /// </summary>
        private BrainstormingNodeVM _mRootnode;

        /// <summary>
        ///     The _nodes.
        /// </summary>
        private NodeVMCollection _nodes = new NodeVMCollection();

        /// <summary>
        ///     The add left child command.
        /// </summary>
        private DelegateCommand<object> addLeftChildCommand;

        /// <summary>
        ///     The add right child command.
        /// </summary>
        private DelegateCommand<object> addRightChildCommand;

        /// <summary>
        ///     The delete child command.
        /// </summary>
        private DelegateCommand<object> deleteChildCommand;

        /// <summary>
        ///     The edit text.
        /// </summary>
        private DelegateCommand<object> editText;

        /// <summary>
        ///     The end edit text.
        /// </summary>
        private DelegateCommand<object> endEditText;

        /// <summary>
        ///     The expand collapse command.
        /// </summary>
        private DelegateCommand<object> expandCollapseCommand;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BrainstormingVM" /> class.
        /// </summary>
        public BrainstormingVM()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BrainstormingVM"/> class.
        /// </summary>
        /// <param name="file">
        /// The file.
        /// </param>
        /// <param name="isValidXml">
        /// The is valid xml.
        /// </param>
        public BrainstormingVM(string file, bool isValidXml)
            : base(file, isValidXml)
        {
            this.LevelStyles = new Dictionary<int, System.Tuple<string, StyleId>>();
            this.LevelStyles.Add(0, new System.Tuple<string, StyleId>("Oval", StyleId.Variant1));
            this.LevelStyles.Add(1, new System.Tuple<string, StyleId>("Rectangle", StyleId.Variant1));
            this.LevelStyles.Add(2, new System.Tuple<string, StyleId>("Rectangle", StyleId.Variant1));
            this.LevelStyles.Add(3, new System.Tuple<string, StyleId>("Rectangle", StyleId.Variant1));
            this.DiagramType = DiagramType.Brainstorming;
            this.Nodes = new NodeVMCollection();
            this.Connectors = new ConnectorVMCollection();
            this.Theme = new OfficeTheme();
            this.Constraints |= GraphConstraints.Events;
            this.Constraints &= ~GraphConstraints.Undoable;
            this.DefaultConnectorType = ConnectorType.Orthogonal;

            this.ItemSelectedCommand = new DelegateCommand<object>(this.ItemSelectedCommandExecute);
            this.AnnotationChangedCommand = new DelegateCommand<object>(this.AnnotationChangedCommandExecute);
            this.ItemDeletingCommand = new DelegateCommand<object>(this.ItemDeletingCommandExecute);
            this.ItemDeletedCommand = new DelegateCommand<object>(this.ItemDeletedCommandExecute);
            this.NodeChangedCommand = new DelegateCommand<object>(this.NodeChangedCommandExecute);
            this.HorizontalRuler = new Ruler
                                       {
                                           Orientation = Orientation.Horizontal,
                                           BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#D4D4D4"),
                                           BorderThickness = new Thickness(0, 0, 0, 1)
                                       };
            this.VerticalRuler = new Ruler
                                     {
                                         Orientation = Orientation.Vertical,
                                         BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#D4D4D4"),
                                         BorderThickness = new Thickness(0, 0, 1, 0)
                                     };
            if (this.SelectedItems is ISelectorVM)
                (this.SelectedItems as ISelectorVM).SelectorConstraints |= SelectorConstraints.HideDisabledResizer;

            // this.ExpandCollapse = new DelegateCommand<object>(ExpandCollapseCommandExecute);
            if (file == null)
            {
                this.AddRootNode();
            }

            this.LayoutManager = new LayoutManager
                                     {
                                         Layout = new BrainStormingLayout
                                                      {
                                                          LayoutRoot = this.Rootnode,
                                                          HorizontalSpacing = 25,
                                                          VerticalSpacing = 65,
                                                          Orientation = TreeOrientation.LeftToRight
                                                      }
                                     };
            this.CommandManager = new CommandManager() { Commands = new CommandCollection() };
            this.AddKeyCommands();
            this.PageSettings = new PageVM();
            (this.PageSettings as PageVM).InitDiagram(this);
        }

        /// <summary>
        ///     Gets the add left child command.
        /// </summary>
        public DelegateCommand<object> AddLeftChildCommand
        {
            get
            {
                return this.addLeftChildCommand
                       ?? (this.addLeftChildCommand = new DelegateCommand<object>(this.AddLeftChildCommandExecute));
            }
        }

        /// <summary>
        ///     Gets the add right child command.
        /// </summary>
        public DelegateCommand<object> AddRightChildCommand
        {
            get
            {
                return this.addRightChildCommand
                       ?? (this.addRightChildCommand = new DelegateCommand<object>(this.AddRightChildCommandExecute));
            }
        }

        /// <summary>
        ///     Gets the connector collection.
        /// </summary>
        public new ConnectorVMCollection ConnectorCollection
        {
            get
            {
                return this.Connectors as ConnectorVMCollection;
            }
        }

        /// <summary>
        ///     Gets the delete child command.
        /// </summary>
        public DelegateCommand<object> DeleteChildCommand
        {
            get
            {
                return this.deleteChildCommand
                       ?? (this.deleteChildCommand = new DelegateCommand<object>(this.DeleteChildCommandExecute));
            }
        }

        /// <summary>
        ///     Gets the edit text.
        /// </summary>
        public DelegateCommand<object> EditText
        {
            get
            {
                return this.editText ?? (this.editText = new DelegateCommand<object>(this.EditTextExecute));
            }
        }

        /// <summary>
        ///     Gets the end edit text.
        /// </summary>
        public DelegateCommand<object> EndEditText
        {
            get
            {
                return this.endEditText ?? (this.endEditText = new DelegateCommand<object>(this.EndEditTextExecute));
            }
        }

        /// <summary>
        ///     Gets the expand collapse command.
        /// </summary>
        public DelegateCommand<object> ExpandCollapseCommand
        {
            get
            {
                return this.expandCollapseCommand ?? (this.expandCollapseCommand =
                                                          new DelegateCommand<object>(
                                                              this.ExpandCollapseCommandExecute));
            }
        }

        /// <summary>
        ///     Gets or sets the level styles.
        /// </summary>
        public Dictionary<int, System.Tuple<string, StyleId>> LevelStyles
        {
            get
            {
                return this._mLevelStyles;
            }

            set
            {
                this._mLevelStyles = value;
            }
        }

        /// <summary>
        ///     Gets the node collection.
        /// </summary>
        public new NodeVMCollection NodeCollection
        {
            get
            {
                return this.Nodes as NodeVMCollection;
            }
        }

        /// <summary>
        ///     Gets or sets the rootnode.
        /// </summary>
        public BrainstormingNodeVM Rootnode
        {
            get
            {
                return this._mRootnode;
            }

            set
            {
                if (this._mRootnode != value)
                {
                    this._mRootnode = value;
                    this.OnPropertyChanged("Rootnode");
                }
            }
        }

        /// <summary>
        /// Adding child elements when executing Multiple Subtopics command
        /// </summary>
        /// <param name="mulipleSubtopics">
        /// </param>
        /// <param name="SubTopicCommand">
        /// The Sub Topic Command.
        /// </param>
        internal void AddMultipleSubTopics(string mulipleSubtopics, ICommand SubTopicCommand)
        {
            List<string> subtopics = Regex.Split(mulipleSubtopics, "\r\n|\r|\n").ToList();
            BrainstormingNodeVM SelectedNode = this.GetFirstSelectedItem();
            foreach (string subtopic in subtopics)
            {
                if (!string.IsNullOrEmpty(subtopic))
                {
                    this.CreateSubTopicCommandChild(subtopic, false);
                }
            }

            ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>).Clear();
            BrainstormingNodeVM lastnewNode = (this.Nodes as ObservableCollection<BrainstormingNodeVM>).Last();
            lastnewNode.IsSelected = true;
        }

        /// <summary>
        ///     Adding RootNode
        /// </summary>
        /// <returns>
        ///     The <see cref="BrainstormingNodeVM" />.
        /// </returns>
        internal BrainstormingNodeVM AddRootNode()
        {
            BrainstormingNodeVM n = new BrainstormingNodeVM();
            n.Shape = resourceDictionary["Oval"];
            n.ShapeName = "Oval";
            n.Level = 0;

            // n.OffsetX = 500;
            // n.OffsetY = 200;
            n.UnitWidth = 192;
            n.UnitHeight = 96;
            n.Type = "root";
            n.Constraints &= ~(NodeConstraints.InheritDraggable | NodeConstraints.InheritResizable
                                                                | NodeConstraints.InheritRotatable);
            n.Constraints |= (NodeConstraints.ResizeEast | NodeConstraints.ResizeWest 
                                                         | NodeConstraints.ExcludeFromLayout);

            ((n.Annotations as List<IAnnotation>)[0] as LabelVM).Content = "Main Topic";
            (this.Nodes as ObservableCollection<BrainstormingNodeVM>).Add(n);
            this.Rootnode = n;

            // Rootnode.IsSelected = true;
            // AddContextMenutoNode(Rootnode);
            return n;
        }

        /// <summary>
        /// Change Connector Type based on inbuilt options
        /// </summary>
        /// <param name="diagram">
        /// The diagram.
        /// </param>
        /// <param name="style">
        /// </param>
        internal void ChangeDiagramStyleForConnector(BrainstormingVM diagram, string style)
        {
            switch (style)
            {
                case "Curved":
                    this.DefaultConnectorType = ConnectorType.CubicBezier;
                    foreach (BrainstormingConnectorVM connector in this.Connectors as ConnectorVMCollection)
                    {
                        connector.Segments = new ObservableCollection<IConnectorSegment> { new CubicCurveSegment() };
                    }

                    break;
                case "Straight":
                    this.DefaultConnectorType = ConnectorType.Orthogonal;
                    foreach (BrainstormingConnectorVM connector in this.Connectors as ConnectorVMCollection)
                    {
                        connector.Segments = new ObservableCollection<IConnectorSegment> { new OrthogonalSegment() };
                    }

                    break;
            }
        }

        /// <summary>
        /// Change shape for selected node
        /// </summary>
        /// <param name="shape">
        /// </param>
        internal void ChangeItemShape(string shape)
        {
            foreach (BrainstormingNodeVM nodeVM in (IEnumerable<object>)(this.SelectedItems as SelectorViewModel).Nodes)
            {
                // nodeVM.Shape = App.Current.Resources[shape];
                nodeVM.ShapeName = shape;
            }
        }

        /// <summary>
        ///     The change item shape for selected level.
        /// </summary>
        internal void ChangeItemShapeForSelectedLevel()
        {
            foreach (BrainstormingNodeVM node in this.Nodes as NodeVMCollection)
            {
                int index = node.Level < 4 ? node.Level : 3;
                node.ShapeName = this.LevelStyles[index].Item1;
            }
        }

        /// <summary>
        ///     The change style id for selected level.
        /// </summary>
        internal void ChangeStyleIdForSelectedLevel()
        {
            foreach (BrainstormingNodeVM node in this.Nodes as NodeVMCollection)
            {
                int index = node.Level < 4 ? node.Level : 3;
                node.ThemeStyleId = this.LevelStyles[index].Item2;
            }
        }

        /// <summary>
        ///     The create peer command child.
        /// </summary>
        internal void CreatePeerCommandChild()
        {
            BrainstormingNodeVM SelectedNode = this.GetFirstSelectedItem();
            BrainstormingNodeVM childNode = null;
            if (!SelectedNode.Type.Equals("root"))
            {
                if (SelectedNode.Level == 1)
                {
                    this.addChildAtLeft = this.addChildAtLeft ? false : true;
                    string type = this.addChildAtLeft ? "left" : "right";
                    childNode = this.CreateNode(this.Rootnode, type);
                    this.Updatebowtielayout(type);
                }
                else
                {
                    IConnector inEdge = (SelectedNode.Info as INodeInfo).InConnectors.First();
                    if (inEdge != null)
                    {
                        BrainstormingNodeVM parentNode = inEdge.SourceNode as BrainstormingNodeVM;
                        childNode = this.CreateNode(parentNode, SelectedNode.Type);
                        this.Updatebowtielayout(SelectedNode.Type);
                    }
                }
            }

            if (childNode != null)
            {
                ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>).Clear();
                childNode.IsSelected = true;
            }
        }

        /// <summary>
        /// The create sub topic command child.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        /// <param name="selectNewNode">
        /// The select new node.
        /// </param>
        internal void CreateSubTopicCommandChild(object param, bool selectNewNode = true)
        {
            BrainstormingNodeVM SelectedNode = this.GetFirstSelectedItem();
            BrainstormingNodeVM n;
            if (SelectedNode.Type.Equals("root"))
            {
                if (SelectedNode.ChildCount == 0)
                {
                    this.addChildAtLeft = false;
                }
                else
                {
                    this.addChildAtLeft = this.addChildAtLeft ? false : true;
                }

                string type = this.addChildAtLeft ? "left" : "right";
                n = this.CreateChild(type);
                if (param != null && !(param is IGestureParameter))
                {
                    ((n.Annotations as List<IAnnotation>)[0] as LabelVM).Content = param.ToString();
                }
            }
            else
            {
                n = this.CreateChild();
                if (param != null && !(param is IGestureParameter))
                {
                    ((n.Annotations as List<IAnnotation>)[0] as LabelVM).Content = param.ToString();
                }
            }

            if (selectNewNode)
            {
                ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>).Clear();
                n.IsSelected = true;
            }
        }

        /// <summary>
        /// The execute expand collapse command.
        /// </summary>
        /// <param name="nodeVm">
        /// The node vm.
        /// </param>
        internal void ExecuteExpandCollapseCommand(NodeVM nodeVm)
        {
            ExpandCollapseParameter parameter = new ExpandCollapseParameter { Node = nodeVm, IsUpdateLayout = true };
            (this.Info as IGraphInfo).Commands.ExpandCollapse.Execute(parameter);
        }

        /// <summary>
        ///     Get first selected node
        /// </summary>
        /// <returns>
        ///     The <see cref="BrainstormingNodeVM" />.
        /// </returns>
        internal BrainstormingNodeVM GetFirstSelectedItem()
        {
            object SelectedNode =
                ((IEnumerable<object>)(this.SelectedItems as SelectorViewModel).Nodes).FirstOrDefault();
            if (SelectedNode == null)
            {
                return null;
            }

            return SelectedNode as BrainstormingNodeVM;
        }

        /// <summary>
        /// The updatebowtielayout.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        internal void Updatebowtielayout(string type)
        {
            if (type.Equals("root"))
            {
                (this.LayoutManager.Layout as BrainStormingLayout).UpdateLayout(this.Rootnode);
            }

            INodeInfo rootNodeInfo = this.Rootnode.Info as INodeInfo;
            ObservableCollection<BrainstormingNodeVM> nodes = (ObservableCollection<BrainstormingNodeVM>)this.Nodes;
            BrainStormingLayout brainStormingLayout = (BrainStormingLayout)this.LayoutManager.Layout;
            if (rootNodeInfo != null && rootNodeInfo.OutNeighbors != null
                                     && rootNodeInfo.OutNeighbors.ToList()
                                         .Find(c => (c as BrainstormingNodeVM).Type == "left") != null && type != null
                                     && type.EndsWith("left"))
            {
                foreach (BrainstormingNodeVM item in nodes)
                {
                    if (item.Type.Equals("left") || item.Type.Equals("root") || item.Type.Equals("subleft"))
                    {
                        item.Constraints &= ~NodeConstraints.ExcludeFromLayout;
                    }
                    else
                    {
                        item.Constraints |= NodeConstraints.ExcludeFromLayout;
                    }
                }

                if (nodes.Contains(this.Rootnode))
                {
                    brainStormingLayout.Orientation = TreeOrientation.RightToLeft;
                    brainStormingLayout.UpdateLayout(this.Rootnode);
                }
            }

            if (rootNodeInfo != null && rootNodeInfo.OutNeighbors != null
                                     && rootNodeInfo.OutNeighbors.ToList()
                                         .Find(c => (c as BrainstormingNodeVM).Type == "right") != null && type != null
                                     && type.EndsWith("right"))
            {
                foreach (BrainstormingNodeVM item in nodes)
                {
                    if (item.Type.Equals("right") || item.Type.Equals("root") || item.Type.Equals("subright"))
                    {
                        item.Constraints &= ~NodeConstraints.ExcludeFromLayout;
                    }
                    else
                    {
                        item.Constraints |= NodeConstraints.ExcludeFromLayout;
                    }
                }

                brainStormingLayout.Orientation = TreeOrientation.LeftToRight;
                if (nodes.Contains(this.Rootnode))
                {
                    brainStormingLayout.UpdateLayout(this.Rootnode);
                }
            }
        }

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);
            switch (name)
            {
                case "CommandManager":
                    this.CommandManager.PropertyChanged += (s, e) =>
                        {
                            if (e.PropertyName.Equals("Commands"))
                            {
                                this.CommandManager.Commands.CollectionChanged += (s1, e1) =>
                                    {
                                        if (e1.NewItems != null && this.Info != null)
                                        {
                                            IGestureCommand gestureCommand = e1.NewItems[0] as IGestureCommand;
                                            if (gestureCommand.Command == (this.Info as IGraphInfo).Commands.Delete)
                                            {
                                                gestureCommand.Command = this.DeleteChildCommand;
                                            }
                                            else if (
                                                gestureCommand.Command == (this.Info as IGraphInfo).Commands.MoveDown
                                                || gestureCommand.Command == (this.Info as IGraphInfo).Commands.MoveUp
                                                || gestureCommand.Command == (this.Info as IGraphInfo).Commands.MoveLeft
                                                || gestureCommand.Command
                                                == (this.Info as IGraphInfo).Commands.MoveRight
                                                || gestureCommand.Command == (this.Info as IGraphInfo).Commands.Cut
                                                || gestureCommand.Command == (this.Info as IGraphInfo).Commands.Copy
                                                || gestureCommand.Command == (this.Info as IGraphInfo).Commands.Paste
                                                || gestureCommand.Command
                                                == (this.Info as IGraphInfo).Commands.Duplicate
                                                || gestureCommand.Command == (this.Info as IGraphInfo).Commands.Group
                                                || gestureCommand.Command == (this.Info as IGraphInfo).Commands.UnGroup)
                                            {
                                                this.CommandManager.Commands.Remove(gestureCommand);
                                            }
                                        }
                                    };
                            }
                        };
                    break;
                case "Info":
                case "Theme":
                    if (this.Nodes is NodeVMCollection)
                    {
                        foreach (BrainstormingNodeVM node in this.Nodes as NodeVMCollection)
                        {
                            node.OnThemeStyleIdChanged();
                        }
                    }

                    break;
                case "Rootnode":
                    this.Rootnode.OffsetX = this.PageSettings.PageWidth / 2;
                    this.Rootnode.OffsetY = this.PageSettings.PageHeight / 2;
                    break;
            }
        }

        /// <summary>
        ///     The add key commands.
        /// </summary>
        private void AddKeyCommands()
        {
            this.CommandManager.Commands.Add(
                new GestureCommand
                    {
                        Command = this.EditText,
                        Gesture = new Gesture { Key = VirtualKey.F2, KeyState = CoreVirtualKeyStates.Down },
                        Name = "EditText"
                    });
            this.CommandManager.Commands.Add(
                new GestureCommand
                    {
                        Command = this.EndEditText,
                        Gesture = new Gesture { Key = VirtualKey.Escape, KeyState = CoreVirtualKeyStates.Down },
                        Name = "EndEditText"
                    });
        }

        /// <summary>
        /// Method will execute when AddLeftChildCommand executed
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private void AddLeftChildCommandExecute(object param)
        {
            BrainstormingNodeVM node = this.CreateChild("left");
            ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>).Clear();
            node.IsSelected = true;
        }

        /// <summary>
        /// Method will execute when AddRightChildCommand executed
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private void AddRightChildCommandExecute(object param)
        {
            BrainstormingNodeVM node = this.CreateChild("right");
            ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>).Clear();
            node.IsSelected = true;
        }

        /// <summary>
        /// Method will execute when AnnotationChangedCommand executed
        /// </summary>
        /// <param name="param">
        /// </param>
        private void AnnotationChangedCommandExecute(object param)
        {
            ChangeEventArgs<object, AnnotationChangedEventArgs> args =
                param as ChangeEventArgs<object, AnnotationChangedEventArgs>;
            AnnotationChangedEventArgs newvalue = args.NewValue;

            AnnotationChangedEventArgs oldvalue = args.OldValue;
            if (newvalue.AnnotationInteractionState == AnnotationInteractionState.Edited)
            {
                this.Updatebowtielayout(this.Rootnode.Type);
            }
        }

        /// <summary>
        /// The connect.
        /// </summary>
        /// <param name="SelectedNode">
        /// The selected node.
        /// </param>
        /// <param name="n">
        /// The n.
        /// </param>
        /// <returns>
        /// The <see cref="BrainstormingConnectorVM"/>.
        /// </returns>
        private BrainstormingConnectorVM Connect(BrainstormingNodeVM SelectedNode, BrainstormingNodeVM n)
        {
            BrainstormingConnectorVM conn = new BrainstormingConnectorVM();
            (this.Connectors as ObservableCollection<BrainstormingConnectorVM>).Add(conn);
            conn.SourceNode = SelectedNode;
            conn.TargetNode = n;
            return conn;
        }

        /// <summary>
        /// This mehtod will create new child and connect it to related parent
        /// </summary>
        /// <param name="ptype">
        /// </param>
        /// <returns>
        /// The <see cref="BrainstormingNodeVM"/>.
        /// </returns>
        private BrainstormingNodeVM CreateChild(string ptype = null)
        {
            BrainstormingNodeVM n = null;
            if ((this.SelectedItems as SelectorViewModel).Nodes != null)
            {
                BrainstormingNodeVM SelectedNode = this.GetFirstSelectedItem();
                if (SelectedNode is BrainstormingNodeVM)
                {
                    if (SelectedNode.Type.Equals("root"))
                    {
                        n = this.CreateNode(SelectedNode, ptype);
                    }
                    else
                    {
                        if (SelectedNode.Type.Equals("right") || SelectedNode.Type.Equals("subright"))
                        {
                            n = this.CreateNode(SelectedNode, "subright");
                            ptype = "right";
                        }
                        else
                        {
                            n = this.CreateNode(SelectedNode, "subleft");
                            ptype = "left";
                        }
                    }
                }

                this.Updatebowtielayout(ptype);
            }

            return n;
        }

        /// <summary>
        /// This mehtod will create new child and connect it to related parent
        /// </summary>
        /// <param name="SelectedNode">
        /// The Selected Node.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="BrainstormingNodeVM"/>.
        /// </returns>
        private BrainstormingNodeVM CreateNode(BrainstormingNodeVM SelectedNode, string type)
        {
            if (!SelectedNode.IsExpanded)
            {
                this.ExecuteExpandCollapseCommand(SelectedNode);
            }

            BrainstormingNodeVM n = new BrainstormingNodeVM();
            n.UnitWidth = 120;
            n.UnitHeight = 30;
            n.Type = type;
            n.Constraints &= ~(NodeConstraints.InheritDraggable | NodeConstraints.InheritResizable
                                                                | NodeConstraints.InheritRotatable);
            if (type.Contains("right"))
            {
                n.Constraints |= NodeConstraints.ResizeEast;
            }
            else if (type.Contains("left"))
            {
                n.Constraints |= NodeConstraints.ResizeWest;
            }

            // AddAnnotation(n);
            ((n.Annotations as List<IAnnotation>)[0] as LabelVM).Content = "New Topic";
            (this.Nodes as ObservableCollection<BrainstormingNodeVM>).Add(n);
            if (SelectedNode != null)
            {
                this.Connect(SelectedNode, n);
                SelectedNode.ChildCount++;
                n.Level = SelectedNode.Level + 1;
            }

            // AddContextMenutoNode(n);
            n.Ports = new ObservableCollection<IPort>
                          {
                              new NodePortVM
                                  {
                                      NodeOffsetX = 0, NodeOffsetY = 1, Displacement = new Thickness(0, -8, 0, 0)
                                  },
                              new NodePortVM { NodeOffsetX = 0, NodeOffsetY = 0.4 },
                              new NodePortVM { NodeOffsetX = 1, NodeOffsetY = 0.05 },
                              new NodePortVM
                                  {
                                      NodeOffsetX = 1, NodeOffsetY = 1, Displacement = new Thickness(0, -8, 0, 0)
                                  }
                          };
            if (n.Level < 4)
            {
                n.ShapeName = this.LevelStyles[n.Level].Item1;
                n.ThemeStyleId = this.LevelStyles[n.Level].Item2;
            }
            else
            {
                n.ShapeName = this.LevelStyles[3].Item1;
                n.ThemeStyleId = this.LevelStyles[3].Item2;
            }

            return n;
        }

        /// <summary>
        /// Method will execute when DeleteChildCommand executed
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private void DeleteChildCommandExecute(object param)
        {
            for (int i = 0;
                 i < ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>).Count();)
            {
                BrainstormingNodeVM selectedNode =
                    ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>)[i] as
                    BrainstormingNodeVM;
                if (selectedNode != this.Rootnode)
                {
                    this.DeleteNode(selectedNode);
                    this.Updatebowtielayout(selectedNode.Type);
                }
                else
                {
                    i++;
                }
            }

            if (this.Rootnode.IsSelected)
            {
                this.UpdateQuickCommandsVisibility(this.Rootnode);
            }
        }

        /// <summary>
        /// This method will delete the all the child layout for the node
        /// </summary>
        /// <param name="SelectedNode">
        /// </param>
        private void DeleteNode(BrainstormingNodeVM SelectedNode)
        {
            if ((SelectedNode.Info as INodeInfo).OutNeighbors != null
                && (SelectedNode.Info as INodeInfo).OutNeighbors.Count() > 0)
            {
                for (int i = (SelectedNode.Info as INodeInfo).OutNeighbors.Count() - 1;
                     (SelectedNode.Info as INodeInfo).OutNeighbors.Count() - 1 >= i && i >= 0;
                     i--)
                {
                    BrainstormingNodeVM c =
                        (SelectedNode.Info as INodeInfo).OutNeighbors.ElementAt(i) as BrainstormingNodeVM;
                    this.DeleteNode(c);
                }
            }

            if ((SelectedNode.Info as INodeInfo).InOutConnectors != null)
            {
                for (int i = (SelectedNode.Info as INodeInfo).InOutConnectors.Count() - 1;
                     (SelectedNode.Info as INodeInfo).InOutConnectors.Count() - 1 >= i && i >= 0;
                     i--)
                {
                    BrainstormingConnectorVM con =
                        (SelectedNode.Info as INodeInfo).InOutConnectors.ElementAt(i) as BrainstormingConnectorVM;
                    (this.Connectors as ObservableCollection<BrainstormingConnectorVM>).Remove(con);
                }
            }

            (this.Nodes as ObservableCollection<BrainstormingNodeVM>).Remove(SelectedNode);
        }

        /// <summary>
        /// The edit text execute.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private void EditTextExecute(object param)
        {
            BrainstormingNodeVM SelectedNode = this.GetFirstSelectedItem();
            if (SelectedNode != null)
            {
                IAnnotation annotation = (SelectedNode.Annotations as List<IAnnotation>).First();
                annotation.Mode = ContentEditorMode.Edit;
            }
        }

        // private void ShapeSelectedItemCommandExecute(object param)
        // {
        // ChangeDiagramStyleForNode(this, param.ToString());
        // }
        // private void ConnectorSelectedItemCommandExecute(object param)
        // {
        // ChangeDiagramStyleForConnector(this, param.ToString());
        // }
        /// <summary>
        /// The end edit text execute.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private void EndEditTextExecute(object param)
        {
            BrainstormingNodeVM SelectedNode = this.GetFirstSelectedItem();
            if (SelectedNode != null)
            {
                IAnnotation annotation = (SelectedNode.Annotations as List<IAnnotation>).First();
                annotation.Mode = ContentEditorMode.View;
            }
        }

        /// <summary>
        /// The expand collapse command execute.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private void ExpandCollapseCommandExecute(object param)
        {
            BrainstormingNodeVM selectedNode = this.GetFirstSelectedItem();

            // selectedNode.IsExpanded = selectedNode.IsExpanded ? false : true;
            // Updatebowtielayout(selectedNode.Type);
            ExpandCollapseParameter parameter = new ExpandCollapseParameter
                                                    {
                                                        Node = selectedNode, IsUpdateLayout = true
                                                    };
            (this.Info as IGraphInfo).Commands.ExpandCollapse.Execute(parameter);
        }

        /// <summary>
        /// Method will execute when ItemDeletedCommand executed
        /// </summary>
        /// <param name="param">
        /// </param>
        private void ItemDeletedCommandExecute(object param)
        {
            ItemDeletedEventArgs args = param as ItemDeletedEventArgs;
            if (args.Item is BrainstormingConnectorVM)
            {
                BrainstormingConnectorVM connectorVM = args.Item as BrainstormingConnectorVM;
                BrainstormingNodeVM sourceNode = connectorVM.SourceNode as BrainstormingNodeVM;
                if (sourceNode != null)
                {
                    sourceNode.ChildCount--;
                }
            }
            else if (args.Item is BrainstormingNodeVM && args.Item != this.Rootnode)
            {
                this.Updatebowtielayout((args.Item as BrainstormingNodeVM).Type);
            }
        }

        /// <summary>
        /// Method will execute when ItemDeletingCommand executed
        /// </summary>
        /// <param name="param">
        /// </param>
        private void ItemDeletingCommandExecute(object param)
        {
            ItemDeletingEventArgs args = param as ItemDeletingEventArgs;
            if (args != null)
            {
                if (args.Item is BrainstormingNodeVM)
                {
                    if (args.Item == this.Rootnode)
                    {
                        args.Cancel = true;
                    }
                    else
                    {
                        this.DeleteNode(args.Item as BrainstormingNodeVM);
                    }
                }
            }
            else
            {
                BrainstormingNodeVM SelectedNode = this.GetFirstSelectedItem();
                this.DeleteNode(SelectedNode);
            }
        }

        /// <summary>
        /// Method will execute when ItemSelectedCommand executed
        /// </summary>
        /// <param name="param">
        /// </param>
        private void ItemSelectedCommandExecute(object param)
        {
            DiagramEventArgs args = param as DiagramEventArgs;
            if (args.Item is BrainstormingNodeVM)
            {
                BrainstormingNodeVM node = args.Item as BrainstormingNodeVM;
                if (this.Rootnode != null)
                {
                    this.UpdateQuickCommandsVisibility(this.Rootnode.IsSelected ? this.Rootnode : node);
                }
            }
        }

        /// <summary>
        /// The node changed command execute.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private void NodeChangedCommandExecute(object param)
        {
            ChangeEventArgs<object, NodeChangedEventArgs> args = param as ChangeEventArgs<object, NodeChangedEventArgs>;
            if (args.NewValue.InteractionState == NodeChangedInteractionState.Resized)
            {
                BrainstormingNodeVM node = args.Item as BrainstormingNodeVM;
                this.Updatebowtielayout(node.Type);
            }
        }

        /// <summary>
        /// The update quick commands visibility.
        /// </summary>
        /// <param name="node">
        /// The node.
        /// </param>
        private void UpdateQuickCommandsVisibility(BrainstormingNodeVM node)
        {
            if (node.Type != null && this.QuickCommands_Delete != null)
            {
                // Work around : Quick Command related things.
                if (node.Type.Equals("root"))
                {
                    if (node.ChildCount == 0)
                    {
                        this.addChildAtLeft = false;
                    }

                    this.QuickCommands_Delete.VisibilityMode = VisibilityMode.Connector;
                    this.QuickCommands_Left.VisibilityMode = VisibilityMode.Node;
                    this.QuickCommands_Right.VisibilityMode = VisibilityMode.Node;
                }
                else if (node.Type.Contains("left"))
                {
                    this.QuickCommands_Delete.VisibilityMode = VisibilityMode.Node;
                    this.QuickCommands_Delete.Margin = new Thickness(22, 0, 0, 0);
                    this.QuickCommands_Delete.OffsetX = 1;
                    this.QuickCommands_Left.VisibilityMode = VisibilityMode.Node;
                    this.QuickCommands_Right.VisibilityMode = VisibilityMode.Connector;
                }
                else if (node.Type.Contains("right"))
                {
                    this.QuickCommands_Delete.VisibilityMode = VisibilityMode.Node;
                    this.QuickCommands_Delete.Margin = new Thickness(-22, 0, 0, 0);
                    this.QuickCommands_Delete.OffsetX = 0;
                    this.QuickCommands_Left.VisibilityMode = VisibilityMode.Connector;
                    this.QuickCommands_Right.VisibilityMode = VisibilityMode.Node;
                }
            }
        }
    }
}