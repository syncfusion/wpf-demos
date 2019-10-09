#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Layout;
using Syncfusion.UI.Xaml.Diagram.Theming;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using CoreVirtualKeyStates = System.Windows.Input.KeyStates;
using VirtualKey = System.Windows.Input.Key;
using VirtualKeyModifiers = System.Windows.Input.ModifierKeys;
using Brainstorming.Layout;
using DiagramBuilder;
using DiagramBuilder.ViewModel;

namespace Brainstorming.ViewModel
{
    public class BrainstormingVM : DiagramVM
    {
        public NodeVMCollection NodeCollection
        {
            get { return Nodes as NodeVMCollection; }
        }
        public ConnectorVMCollection ConnectorCollection
        {
            get { return Connectors as ConnectorVMCollection; }
        }

        #region Private Fields
        private BrainstormingNodeVM _mRootnode = null;
        private NodeVMCollection _nodes = new NodeVMCollection();
        private ConnectorVMCollection _connectors = new ConnectorVMCollection();
        // Adding child to root node alternate side when execute the peer command        
        internal bool addChildAtLeft = false;
        public QuickCommandViewModel Quickcommands_Delete;
        public QuickCommandViewModel Quickcommands_Left;
        public QuickCommandViewModel Quickcommands_Right;
        private Dictionary<int, System.Tuple<string, StyleId>> _mLevelStyles;
        #endregion
        #region Public Propereties
        public Dictionary<int, System.Tuple<string, StyleId>> LevelStyles
        {
            get { return _mLevelStyles; }
            set { _mLevelStyles = value; }
        }



        public BrainstormingNodeVM Rootnode
        {
            get { return _mRootnode; }
            set
            {
                if (_mRootnode != value)
                {
                    _mRootnode = value;
                    OnPropertyChanged("Rootnode");
                }
            }
        }

        #endregion
        #region Public ICommand    

        private DelegateCommand<object> editText;
        private DelegateCommand<object> deleteChildCommand;
        private DelegateCommand<object> endEditText;
        private DelegateCommand<object> addRightChildCommand;
        private DelegateCommand<object> addLeftChildCommand;
        private DelegateCommand<object> expandCollapseCommand;

        public DelegateCommand<object> ExpandCollapseCommand
        {
            get
            {
                return expandCollapseCommand ??
                    (expandCollapseCommand = new DelegateCommand<object>(ExpandCollapseCommandExecute));
            }
        }
        public DelegateCommand<object> EditText
        {
            get
            {
                return editText ??
                    (editText = new DelegateCommand<object>(EditTextExecute));
            }
        }
        public DelegateCommand<object> EndEditText
        {
            get
            {
                return endEditText ??
                    (endEditText = new DelegateCommand<object>(EndEditTextExecute));
            }
        }
        public DelegateCommand<object> AddLeftChildCommand
        {
            get
            {
                return addLeftChildCommand ??
                    (addLeftChildCommand = new DelegateCommand<object>(AddLeftChildCommandExecute));
            }
        }
        public DelegateCommand<object> AddRightChildCommand
        {
            get
            {
                return addRightChildCommand ??
                    (addRightChildCommand = new DelegateCommand<object>(AddRightChildCommandExecute));
            }
        }
        public DelegateCommand<object> DeleteChildCommand
        {
            get
            {
                return deleteChildCommand ??
                    (deleteChildCommand = new DelegateCommand<object>(DeleteChildCommandExecute));
            }
        }
        #endregion
        #region Constructor
        public BrainstormingVM()
        { }
        public BrainstormingVM(string file, bool isValidXml) : base(file, isValidXml)
        {
            LevelStyles = new Dictionary<int, System.Tuple<string, StyleId>>();
            LevelStyles.Add(0, new System.Tuple<string, StyleId>("Oval", StyleId.Variant1));
            LevelStyles.Add(1, new System.Tuple<string, StyleId>("Rectangle", StyleId.Variant1));
            LevelStyles.Add(2, new System.Tuple<string, StyleId>("Rectangle", StyleId.Variant1));
            LevelStyles.Add(3, new System.Tuple<string, StyleId>("Rectangle", StyleId.Variant1));
            DiagramType = DiagramType.Brainstorming;
            this.Nodes = new NodeVMCollection();
            this.Connectors = new ConnectorVMCollection();
            Theme = new OfficeTheme();
            Constraints |= GraphConstraints.Events;
            Constraints &= ~GraphConstraints.Undoable;
            this.DefaultConnectorType = ConnectorType.Orthogonal;
            #region Diagram Commands
            this.ItemSelectedCommand = new DelegateCommand<object>(ItemSelectedCommandExecute);
            this.AnnotationChangedCommand = new DelegateCommand<object>(AnnotationChangedCommandExecute);
            this.ItemDeletingCommand = new DelegateCommand<object>(ItemDeletingCommandExecute);
            this.ItemDeletedCommand = new DelegateCommand<object>(ItemDeletedCommandExecute);
            this.NodeChangedCommand = new DelegateCommand<object>(NodeChangedCommandExecute);
            this.HorizontalRuler = new Ruler()
            {
                Orientation = Orientation.Horizontal,
                BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D4D4D4")),
                BorderThickness = new Thickness(0, 0, 0, 1)
            };
            this.VerticalRuler = new Ruler()
            {
                Orientation = Orientation.Vertical,
                BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D4D4D4")),
                BorderThickness = new Thickness(0, 0, 1, 0)
            };
            if (this.SelectedItems is ISelectorVM)
                (this.SelectedItems as ISelectorVM).SelectorConstraints |= SelectorConstraints.HideDisabledResizer;
            //this.ExpandCollapse = new DelegateCommand<object>(ExpandCollapseCommandExecute);
            #endregion
            if (file == null)
            {
                AddRootNode();
            }
            this.LayoutManager = new Syncfusion.UI.Xaml.Diagram.Layout.LayoutManager()
            {
                Layout = new BrainStormingLayout()
                {
                    LayoutRoot = Rootnode,
                    HorizontalSpacing = 25,
                    VerticalSpacing = 65
                }
            };
            CommandManager = new Syncfusion.UI.Xaml.Diagram.CommandManager();
            CommandManager.Commands = new CommandCollection();
            AddKeyCommands();
            PageSettings = new PageVM();
            (PageSettings as PageVM).InitDiagram(this);
        }
        #endregion
        #region Commands Execution
        private void NodeChangedCommandExecute(object param)
        {
            ChangeEventArgs<object, NodeChangedEventArgs> args = param as ChangeEventArgs<object, NodeChangedEventArgs>;
            if (args.NewValue.InteractionState == NodeChangedInteractionState.Resized)
            {
                BrainstormingNodeVM node = args.Item as BrainstormingNodeVM;
                Updatebowtielayout(node.Type);
            }
        }
        /// <summary>
        /// Method will execute when ItemDeletedCommand executed
        /// </summary>
        /// <param name="param"></param>
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
            else if (args.Item is BrainstormingNodeVM && args.Item != Rootnode)
            {
                Updatebowtielayout((args.Item as BrainstormingNodeVM).Type);
            }
        }
        /// <summary>
        /// Method will execute when ItemDeletingCommand executed
        /// </summary>
        /// <param name="param"></param>
        private void ItemDeletingCommandExecute(object param)
        {
            ItemDeletingEventArgs args = param as ItemDeletingEventArgs;
            if (args != null)
            {
                if (args.Item is BrainstormingNodeVM)
                {
                    if (args.Item == Rootnode)
                    {
                        args.Cancel = true;
                    }
                    else
                    {
                        DeleteNode(args.Item as BrainstormingNodeVM);
                    }
                }
            }
            else
            {
                BrainstormingNodeVM SelectedNode = GetFirstSelectedItem();
                DeleteNode(SelectedNode);
            }
        }
        /// <summary>
        /// Method will execute when AnnotationChangedCommand executed
        /// </summary>
        /// <param name="param"></param>
        private void AnnotationChangedCommandExecute(object param)
        {
            ChangeEventArgs<object, AnnotationChangedEventArgs> args = param as ChangeEventArgs<object, AnnotationChangedEventArgs>;
            AnnotationChangedEventArgs newvalue = args.NewValue;

            AnnotationChangedEventArgs oldvalue = args.OldValue;
            if (newvalue.AnnotationInteractionState == AnnotationInteractionState.Edited
            && oldvalue.AnnotationInteractionState == AnnotationInteractionState.Editing)
            {
                Updatebowtielayout(Rootnode.Type);
            }
        }        
        /// <summary>
        /// Method will execute when ItemSelectedCommand executed
        /// </summary>
        /// <param name="param"></param>
        private void ItemSelectedCommandExecute(object param)
        {
            DiagramEventArgs args = param as DiagramEventArgs;
            if (args.Item is BrainstormingNodeVM)
            {
                BrainstormingNodeVM node = args.Item as BrainstormingNodeVM;
                UpdateQuickCommandsVisibility(Rootnode.IsSelected ? Rootnode : node);
            }
        }
        /// <summary>
        /// Method will execute when DeleteChildCommand executed
        /// </summary>
        private void DeleteChildCommandExecute(object param)
        {
            for(int i=0;i< ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>).Count();)
            {
                BrainstormingNodeVM selectedNode = ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>)[i] as BrainstormingNodeVM;
                if (selectedNode != Rootnode)
                {
                    DeleteNode(selectedNode);
                    Updatebowtielayout(selectedNode.Type);
                }
                else
                {
                    i++;
                }
            }
            if(Rootnode.IsSelected)
            {
                UpdateQuickCommandsVisibility(Rootnode);
            }
        }
        //private void ShapeSelectedItemCommandExecute(object param)
        //{
        //    ChangeDiagramStyleForNode(this, param.ToString());
        //}
        //private void ConnectorSelectedItemCommandExecute(object param)
        //{
        //    ChangeDiagramStyleForConnector(this, param.ToString());
        //}
        private void EndEditTextExecute(object param)
        {
            BrainstormingNodeVM SelectedNode = GetFirstSelectedItem();
            if (SelectedNode != null)
            {
                IAnnotation annotation = (SelectedNode.Annotations as List<IAnnotation>).First();
                annotation.Mode = ContentEditorMode.View;
            }
        }
        private void EditTextExecute(object param)
        {
            BrainstormingNodeVM SelectedNode = GetFirstSelectedItem();
            if (SelectedNode != null)
            {
                IAnnotation annotation = (SelectedNode.Annotations as List<IAnnotation>).First();
                annotation.Mode = ContentEditorMode.Edit;
            }
        }
        private void ExpandCollapseCommandExecute(object param)
        {
            BrainstormingNodeVM selectedNode = GetFirstSelectedItem();
            //selectedNode.IsExpanded = selectedNode.IsExpanded ? false : true;
            //Updatebowtielayout(selectedNode.Type);
            ExpandCollapseParameter parameter = new ExpandCollapseParameter()
            {
                node = selectedNode,
                IsUpdateLayout = true
            };
            (this.Info as IGraphInfo).Commands.ExpandCollapse.Execute(parameter);
        }

        /// <summary>
        /// Method will execute when AddLeftChildCommand executed
        /// </summary>
        private void AddLeftChildCommandExecute(object param)
        {
            BrainstormingNodeVM node = CreateChild("left");
            ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>).Clear();
            node.IsSelected = true;
        }
        /// <summary>
        /// Method will execute when AddRightChildCommand executed
        /// </summary>
        private void AddRightChildCommandExecute(object param)
        {
            BrainstormingNodeVM node = CreateChild("right");
            ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>).Clear();
            node.IsSelected = true;
        }
        #endregion
        #region Private Methods
        /// <summary>
        /// Adding RootNode
        /// </summary>
        internal BrainstormingNodeVM AddRootNode()
        {
            BrainstormingNodeVM n = new BrainstormingNodeVM();
            n.Shape = App.Current.Resources["Oval"];
            n.ShapeName = "Oval";
            n.Level = 0;
            //n.OffsetX = 500;
            //n.OffsetY = 200;
            n.UnitWidth = 192;
            n.UnitHeight = 96;
            n.Type = "root";
            n.Constraints &= ~(NodeConstraints.InheritDraggable | NodeConstraints.InheritResizable
                | NodeConstraints.InheritRotatable);
            n.Constraints |= (NodeConstraints.ResizeEast | NodeConstraints.ResizeWest|NodeConstraints.ExcludeFromLayout);
            
            ((n.Annotations as List<IAnnotation>)[0] as LabelVM).Content= "Main Topic";
            (this.Nodes as ObservableCollection<BrainstormingNodeVM>).Add(n);
            Rootnode = n;
            //Rootnode.IsSelected = true;
            //AddContextMenutoNode(Rootnode);
            return n;
        }
       
        /// <summary>
        /// This method will delete the all the child layout for the node 
        /// </summary>
        /// <param name="SelectedNode"></param>
        private void DeleteNode(BrainstormingNodeVM SelectedNode)
        {
            if ((SelectedNode.Info as INodeInfo).OutNeighbors != null && (SelectedNode.Info as INodeInfo).OutNeighbors.Count() > 0)
            {
                for (int i = (SelectedNode.Info as INodeInfo).OutNeighbors.Count() - 1; (SelectedNode.Info as INodeInfo).OutNeighbors.Count() - 1 >= i && i >= 0; i--)
                {
                    BrainstormingNodeVM c = (SelectedNode.Info as INodeInfo).OutNeighbors.ElementAt(i) as BrainstormingNodeVM;
                    DeleteNode(c);
                }
            }
            if ((SelectedNode.Info as INodeInfo).InOutConnectors != null)
            {
                for (int i = (SelectedNode.Info as INodeInfo).InOutConnectors.Count() - 1; (SelectedNode.Info as INodeInfo).InOutConnectors.Count() - 1 >= i && i >= 0; i--)
                {
                    BrainstormingConnectorVM con = (SelectedNode.Info as INodeInfo).InOutConnectors.ElementAt(i) as BrainstormingConnectorVM;
                    (this.Connectors as ObservableCollection<BrainstormingConnectorVM>).Remove(con);
                }
            }
            (this.Nodes as ObservableCollection<BrainstormingNodeVM>).Remove(SelectedNode);

        }

        /// <summary>
        /// This mehtod will create new child and connect it to related parent
        /// </summary>
        /// <param name="ptype"></param>
        BrainstormingNodeVM CreateChild(string ptype = null)
        {
            BrainstormingNodeVM n = null;
            if ((this.SelectedItems as SelectorViewModel).Nodes != null)
            {
                BrainstormingNodeVM SelectedNode = GetFirstSelectedItem();
                if (SelectedNode is BrainstormingNodeVM)
                {
                    if ((SelectedNode as BrainstormingNodeVM).Type.Equals("root"))
                    {
                        n = CreateNode(SelectedNode, ptype);
                    }
                    else
                    {
                        if (SelectedNode.Type.Equals("right") || SelectedNode.Type.Equals("subright"))
                        {
                            n = CreateNode(SelectedNode, "subright");
                            ptype = "right";
                        }
                        else
                        {
                            n = CreateNode(SelectedNode, "subleft");
                            ptype = "left";
                        }
                    }

                }
                Updatebowtielayout(ptype);
            }
            return n;
        }
        /// <summary>
        /// This mehtod will create new child and connect it to related parent
        /// </summary>
        /// <param name="ptype"></param>
        private BrainstormingNodeVM CreateNode(BrainstormingNodeVM SelectedNode, string type)
        {
            if (!SelectedNode.IsExpanded)
            {
                ExecuteExpandCollapseCommand(SelectedNode);
            }
            BrainstormingNodeVM n = new BrainstormingNodeVM();
            n.UnitWidth = 120;
            n.UnitHeight = 30;
            n.Type = type;
            n.Constraints &= ~(NodeConstraints.InheritDraggable | NodeConstraints.InheritResizable
                | NodeConstraints.InheritRotatable);
            if (type.Contains("right"))
            {
                n.Constraints |= (NodeConstraints.ResizeEast);
            }
            else if (type.Contains("left"))
            {
                n.Constraints |= (NodeConstraints.ResizeWest);
            }

            //AddAnnotation(n);
            ((n.Annotations as List<IAnnotation>)[0] as LabelVM).Content = "New Topic";
            (this.Nodes as ObservableCollection<BrainstormingNodeVM>).Add(n);
            if (SelectedNode != null)
            {
                Connect(SelectedNode, n);
                SelectedNode.ChildCount++;
                n.Level = SelectedNode.Level + 1;
            }
            //AddContextMenutoNode(n);
            n.Ports = new ObservableCollection<IPort>()
            {
                new NodePortVM()
                {
                    NodeOffsetX =0 , NodeOffsetY = 1,
                    Displacement = new Thickness(0,-8, 0, 0)
                },
                new NodePortVM()
                {
                    NodeOffsetX =0 , NodeOffsetY = 0.4
                },
                new NodePortVM()
                {
                    NodeOffsetX =1 , NodeOffsetY = 0.05
                },
                new NodePortVM()
                {
                    NodeOffsetX =1 , NodeOffsetY = 1,
                    Displacement = new Thickness(0,-8, 0, 0)
                }
            };   
            if(n.Level < 4)
            {
                n.ShapeName = LevelStyles[n.Level].Item1;
                n.ThemeStyleId = LevelStyles[n.Level].Item2;
            }
            else
            {
                n.ShapeName = LevelStyles[3].Item1;
                n.ThemeStyleId = LevelStyles[3].Item2;
            }
            return n;
        }
        private BrainstormingConnectorVM Connect(BrainstormingNodeVM SelectedNode, BrainstormingNodeVM n)
        {
            BrainstormingConnectorVM conn = new BrainstormingConnectorVM();
            (this.Connectors as ObservableCollection<BrainstormingConnectorVM>).Add(conn);
            conn.SourceNode = SelectedNode;
            conn.TargetNode = n;
            return conn;
        }
        internal void Updatebowtielayout(string type)
        {
            if (type.Equals("root"))
            {
                (this.LayoutManager.Layout as BrainStormingLayout).UpdateLayout(Rootnode);
            }
            if (Rootnode.Info != null && (Rootnode.Info as INodeInfo).OutNeighbors != null && (Rootnode.Info as INodeInfo).OutNeighbors.ToList().Find(c => (c as BrainstormingNodeVM).Type == "left") != null && type != null && type.EndsWith("left"))
            {
                foreach (BrainstormingNodeVM item in this.Nodes as ObservableCollection<BrainstormingNodeVM>)
                {
                    if (item.Type.Equals("left") || item.Type.Equals("root") || item.Type.Equals("subleft"))
                    {
                        item.Constraints = item.Constraints & ~NodeConstraints.ExcludeFromLayout;
                    }
                    else
                    {
                        item.Constraints = item.Constraints | NodeConstraints.ExcludeFromLayout;
                    }
                }
                if ((this.Nodes as ObservableCollection<BrainstormingNodeVM>).Contains(Rootnode))
                {
                    (this.LayoutManager.Layout as BrainStormingLayout).Orientation = TreeOrientation.RightToLeft;
                    (this.LayoutManager.Layout as BrainStormingLayout).UpdateLayout(Rootnode);
                }
            }
            if (Rootnode.Info != null && (Rootnode.Info as INodeInfo).OutNeighbors != null && (Rootnode.Info as INodeInfo).OutNeighbors.ToList().Find(c => (c as BrainstormingNodeVM).Type == "right") != null && type != null && type.EndsWith("right"))
            {
                foreach (BrainstormingNodeVM item in this.Nodes as ObservableCollection<BrainstormingNodeVM>)
                {
                    if (item.Type.Equals("right") || item.Type.Equals("root") || item.Type.Equals("subright"))
                    {
                        item.Constraints = item.Constraints & ~NodeConstraints.ExcludeFromLayout;
                    }
                    else
                    {
                        item.Constraints = item.Constraints | NodeConstraints.ExcludeFromLayout;
                    }
                }
                (this.LayoutManager.Layout as BrainStormingLayout).Orientation = TreeOrientation.LeftToRight;
                if ((this.Nodes as ObservableCollection<BrainstormingNodeVM>).Contains(Rootnode))
                {
                    (this.LayoutManager.Layout as BrainStormingLayout).UpdateLayout(Rootnode);
                }
            }

        }
        /// <summary>
        /// Get first selected node
        /// </summary>
        /// <returns></returns>
        internal BrainstormingNodeVM GetFirstSelectedItem()
        {
            object SelectedNode = ((IEnumerable<object>)(this.SelectedItems as SelectorViewModel).Nodes).FirstOrDefault();
            if (SelectedNode == null)
            {
                return null;
            }
            return SelectedNode as BrainstormingNodeVM;
        }
        /// <summary>
        /// Adding child elements when executing Multiple Subtopics command
        /// </summary>
        /// <param name="mulipleSubtopics"></param>
        internal void AddMultipleSubTopics(string mulipleSubtopics, ICommand SubTopicCommand)
        {
            List<string> subtopics = Regex.Split(mulipleSubtopics, "\r\n|\r|\n").ToList();
            BrainstormingNodeVM SelectedNode = GetFirstSelectedItem();
            foreach (string subtopic in subtopics)
            {
                if (!string.IsNullOrEmpty(subtopic))
                {
                    CreateSubTopicCommandChild(subtopic, false);
                }
            }
            ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>).Clear();
            BrainstormingNodeVM lastnewNode = (this.Nodes as ObservableCollection<BrainstormingNodeVM>).Last() as BrainstormingNodeVM;
            lastnewNode.IsSelected = true;
        }
        /// <summary>
        /// Change shape for selected node
        /// </summary>
        /// <param name="shape"></param>
        internal void ChangeItemShape(string shape)
        {
            foreach (BrainstormingNodeVM nodeVM in ((IEnumerable<object>)(this.SelectedItems as SelectorViewModel).Nodes))
            {
                //nodeVM.Shape = App.Current.Resources[shape];
                nodeVM.ShapeName = shape;
            }
        }

        internal void ChangeItemShapeForSelectedLevel()
        {
            foreach (BrainstormingNodeVM node in this.Nodes as NodeVMCollection)
            {
                if (node.Level < 4)
                {
                    node.ShapeName = LevelStyles[node.Level].Item1;
                }
                else
                {
                    node.ShapeName = LevelStyles[3].Item1;
                }
            }
        }
        internal void ChangeStyleIdForSelectedLevel()
        {
            foreach (BrainstormingNodeVM node in Nodes as NodeVMCollection)
            {
                if(node.Level < 4)
                {
                    node.ThemeStyleId = LevelStyles[node.Level].Item2;
                }
                else
                {
                    node.ThemeStyleId = LevelStyles[3].Item2;
                }
            }
        }
        /// <summary>
        /// Change Connector Type based on inbuilt options
        /// </summary>
        /// <param name="style"></param>
        internal void ChangeDiagramStyleForConnector(BrainstormingVM diagram, string style)
        {
            switch (style)
            {
                case "Curved":
                    this.DefaultConnectorType = ConnectorType.CubicBezier;
                    foreach (BrainstormingConnectorVM connector in this.Connectors as ConnectorVMCollection)
                    {
                        connector.Segments = new ObservableCollection<IConnectorSegment>
                            {
                                new CubicCurveSegment()
                                {
                                }
                            };
                    }
                    break;
                case "Straight":
                    this.DefaultConnectorType = ConnectorType.Orthogonal;
                    foreach (BrainstormingConnectorVM connector in this.Connectors as ConnectorVMCollection)
                    {
                        connector.Segments = new ObservableCollection<IConnectorSegment>
                            {
                              new OrthogonalSegment()
                              {

                              }
                            };
                    }
                    break;
            }
        }

        internal void CreateSubTopicCommandChild(object param, bool selectNewNode = true)
        {
            BrainstormingNodeVM SelectedNode = GetFirstSelectedItem();
            BrainstormingNodeVM n;
            if ((SelectedNode as BrainstormingNodeVM).Type.Equals("root"))
            {
                if (SelectedNode.ChildCount == 0)
                {
                    addChildAtLeft = false;
                }
                else
                {
                    addChildAtLeft = addChildAtLeft ? false : true;
                }
                string type = addChildAtLeft ? "left" : "right";
                n = CreateChild(type);
                if (param != null && !(param is IGestureParameter))
                {
                    ((n.Annotations as List<IAnnotation>)[0] as LabelVM).Content = param.ToString();
                }
            }
            else
            {
                n = CreateChild();
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
        internal void CreatePeerCommandChild()
        {
            BrainstormingNodeVM SelectedNode = GetFirstSelectedItem();
            BrainstormingNodeVM childNode = null;
            if (!SelectedNode.Type.Equals("root"))
            {
                if (SelectedNode.Level == 1)
                {
                    addChildAtLeft = addChildAtLeft ? false : true;
                    string type = addChildAtLeft ? "left" : "right";
                    childNode = CreateNode(Rootnode, type);
                    Updatebowtielayout(type);
                }
                else
                {
                    IConnector inEdge = (SelectedNode.Info as INodeInfo).InConnectors.First() as IConnector;
                    if (inEdge != null)
                    {
                        BrainstormingNodeVM parentNode = inEdge.SourceNode as BrainstormingNodeVM;
                        childNode = CreateNode(parentNode, SelectedNode.Type);
                        Updatebowtielayout(SelectedNode.Type);
                    }
                }
            }
            if (childNode != null)
            {
                ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>).Clear();
                childNode.IsSelected = true;
            }
        }
        internal void ExecuteExpandCollapseCommand(NodeVM nodeVm)
        {
            ExpandCollapseParameter parameter = new ExpandCollapseParameter()
            {
                node = nodeVm,
                IsUpdateLayout = true
            };
            (this.Info as IGraphInfo).Commands.ExpandCollapse.Execute(parameter);
        }
        private void AddKeyCommands()
        {
            CommandManager.Commands.Add
            (
                new GestureCommand()
                {
                    Command = EditText,
                    Gesture = new Gesture
                    {
                        Key = VirtualKey.F2,
                        KeyState = CoreVirtualKeyStates.Down

                    },
                    Name = "EditText",
                }
            );
            CommandManager.Commands.Add
            (
                new GestureCommand()
                {
                    Command = EndEditText,
                    Gesture = new Gesture
                    {
                        Key = VirtualKey.Escape,
                        KeyState = CoreVirtualKeyStates.Down

                    },
                    Name = "EndEditText",
                }
            );
        }
        private void UpdateQuickCommandsVisibility(BrainstormingNodeVM node)
        {
            if (node.Type != null && Quickcommands_Delete != null)
            {
                // Work around : Quick Command related things.
                if (node.Type.Equals("root"))
                {
                    if (node.ChildCount == 0)
                    {
                        addChildAtLeft = false;
                    }
                    Quickcommands_Delete.VisibilityMode = VisibilityMode.Connector;
                    Quickcommands_Left.VisibilityMode = VisibilityMode.Node;
                    Quickcommands_Right.VisibilityMode = VisibilityMode.Node;
                }
                else if (node.Type.Contains("left"))
                {
                    Quickcommands_Delete.VisibilityMode = VisibilityMode.Node;
                    Quickcommands_Delete.Margin = new Thickness(22, 0, 0, 0);
                    Quickcommands_Delete.OffsetX = 1;
                    Quickcommands_Left.VisibilityMode = VisibilityMode.Node;
                    Quickcommands_Right.VisibilityMode = VisibilityMode.Connector;
                }
                else if (node.Type.Contains("right"))
                {
                    Quickcommands_Delete.VisibilityMode = VisibilityMode.Node;
                    Quickcommands_Delete.Margin = new Thickness(-22, 0, 0, 0);
                    Quickcommands_Delete.OffsetX = 0;
                    Quickcommands_Left.VisibilityMode = VisibilityMode.Connector;
                    Quickcommands_Right.VisibilityMode = VisibilityMode.Node;
                }
            }
        }
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
                                  if (e1.NewItems != null && Info != null)
                                  {
                                      IGestureCommand gestureCommand = e1.NewItems[0] as IGestureCommand;
                                      if (gestureCommand.Command == (Info as IGraphInfo).Commands.Delete)
                                      {
                                          gestureCommand.Command = this.DeleteChildCommand;
                                      }
                                      else if (gestureCommand.Command == (Info as IGraphInfo).Commands.MoveDown
                                      || gestureCommand.Command == (Info as IGraphInfo).Commands.MoveUp
                                      || gestureCommand.Command == (Info as IGraphInfo).Commands.MoveLeft
                                      || gestureCommand.Command == (Info as IGraphInfo).Commands.MoveRight
                                      || gestureCommand.Command == (Info as IGraphInfo).Commands.Cut
                                      || gestureCommand.Command == (Info as IGraphInfo).Commands.Copy
                                      || gestureCommand.Command == (Info as IGraphInfo).Commands.Paste
                                      || gestureCommand.Command == (Info as IGraphInfo).Commands.Duplicate
                                      || gestureCommand.Command == (Info as IGraphInfo).Commands.Group
                                      || gestureCommand.Command == (Info as IGraphInfo).Commands.UnGroup
                                      )
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
                    if (Nodes is NodeVMCollection)
                    {
                        foreach (BrainstormingNodeVM node in Nodes as NodeVMCollection)
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
        #endregion
    }

    public class NodeVMCollection : ObservableCollection<BrainstormingNodeVM>
    {
        
    }
    public class ConnectorVMCollection : ObservableCollection<BrainstormingConnectorVM>
    {

    }
}
