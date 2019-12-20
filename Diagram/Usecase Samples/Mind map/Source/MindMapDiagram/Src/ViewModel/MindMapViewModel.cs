#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.MindMapDiagram.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Layout;
using VirtualKey = System.Windows.Input.Key;
using CoreVirtualKeyStates = System.Windows.Input.KeyStates;
using VirtualKeyModifiers = System.Windows.Input.ModifierKeys;
using System.Text.RegularExpressions;
using Syncfusion.UI.Xaml.Diagram.Theming;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Win32;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;

namespace Syncfusion.UI.Xaml.MindMapDiagram.ViewModel
{
    public class MindMapViewModel : DiagramViewModel, IMindMapViewModel
    {
        #region Private Fields
        private Root root;
        private ObservableCollection<MindMapNodeStyle> nodeStyles;
        private MindMapConnectionStyle connectionStyle;
        bool addChildAtLeft = false;
        private Dictionary<int, System.Tuple<string, StyleId>> _mLevelStyles;
        bool isLoading = false;
        bool isLayoutUpdating = false;
        #endregion
        #region Internal Fields
        internal QuickCommandViewModel Quickcommands_Delete;
        internal QuickCommandViewModel Quickcommands_Left;
        internal QuickCommandViewModel Quickcommands_Right;

        internal OpenCloseWindowBehavior OpenCloseWindowBehavior { get; set; }
        internal ChangeTopicViewModel ChangeTopicViewModel { get; set; }
        internal MultipleSubTopicViewModel MultipleSubTopicViewModel { get; set; }
        public DiagramStyleViewModel DiagramStyleViewModel { get; set; }
        
       
        internal Dictionary<int, System.Tuple<string, StyleId>> LevelStyles
        {
            get { return _mLevelStyles; }
            set { _mLevelStyles = value; }
        }
        #endregion
        #region Constructor

        public MindMapViewModel()
        {
            this.ItemAddedCommand = new DelegateCommand<object>(ItemAddedCommandExecute);
            this.ItemSelectedCommand = new DelegateCommand<object>(ItemSelectedCommandExecute);
            this.AnnotationChangedCommand = new DelegateCommand<object>(AnnotationChangedCommandExecute);
            this.ItemDeletingCommand = new DelegateCommand<object>(ItemDeletingCommandExecute);
            this.ItemDeletedCommand = new DelegateCommand<object>(ItemDeletedCommandExecute);
            this.NodeChangedCommand = new DelegateCommand<object>(NodeChangedCommandExecute);
            #region Work around
            this.PageSettings = new PageSettings();
            PageSettings.PageWidth = 793.70;
            PageSettings.PageHeight = 1122.52;
            PageSettings.MultiplePage = true;
            PageSettings.ShowPageBreaks = true;
            PageSettings.PageBackground = new SolidColorBrush(Colors.White);
            #endregion
            this.SnapSettings = new SnapSettings()
            {
                SnapConstraints = SnapConstraints.ShowLines,
                SnapToObject = SnapToObject.None
            };
            this.HorizontalRuler = new Ruler()
            {
                Orientation = Orientation.Horizontal,
                BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D4D4D4")),
                BorderThickness = new Thickness(0,0,0,1)
            };
            this.VerticalRuler = new Ruler()
            {
                Orientation = Orientation.Vertical,
                BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D4D4D4")),
                BorderThickness = new Thickness(0, 0, 1, 0)
            };
            this.PrintingService = new PrintingService();
            Theme = new OfficeTheme();
            Root = new Root() { UnitWidth = 192, UnitHeight = 96 };
            AddContextMenutoNode(Root);
            OpenCloseWindowBehavior = new OpenCloseWindowBehavior() { MindMapViewModel = this };
            ChangeTopicViewModel = new ChangeTopicViewModel(this);
            MultipleSubTopicViewModel = new MultipleSubTopicViewModel(this);
            DiagramStyleViewModel = new DiagramStyleViewModel(this);
            LevelStyles = new Dictionary<int, System.Tuple<string, StyleId>>();
            LevelStyles.Add(0, new System.Tuple<string, StyleId>("Oval", StyleId.Variant3));
            LevelStyles.Add(1, new System.Tuple<string, StyleId>("Rectangle", StyleId.Variant3));
            LevelStyles.Add(2, new System.Tuple<string, StyleId>("Rectangle", StyleId.Variant3));
            LevelStyles.Add(3, new System.Tuple<string, StyleId>("Rectangle", StyleId.Variant3));
            LevelStyles.Add(4, new System.Tuple<string, StyleId>("Rectangle", StyleId.Variant3));
            this.SelectedItems = new SelectorViewModel();
            Constraints |= GraphConstraints.Events;
            Constraints &= ~GraphConstraints.Undoable;
            this.DefaultConnectorType = ConnectorType.CubicBezier;
            this.PortVisibility = PortVisibility.Collapse;
              
            (this.SelectedItems as SelectorViewModel).SelectorConstraints |= SelectorConstraints.HideDisabledResizer;
            (this.SelectedItems as SelectorViewModel).SelectorConstraints &= ~SelectorConstraints.Rotator;
            this.LayoutManager = new LayoutManager()
            {
                Layout = new DirectedTreeLayout
                {
                    HorizontalSpacing = 25,
                    VerticalSpacing = 65,
                    LayoutRoot = Root
                }
            };
            CommandManager = new CommandManager();
            CommandManager.Commands = new CommandCollection();
            AddKeyCommands();
        }
        #endregion

        #region Public Properties     
        public Root Root
        {
            get { return root; }
            set
            {
                if (root != value)
                {
                    root = value;
                    OnPropertyChanged("Root");
                }
            }
        }
        public ObservableCollection<MindMapNodeStyle> NodeStyles
        {
            get { return nodeStyles; }
            set
            {
                if (nodeStyles != value)
                {
                    nodeStyles = value;
                    OnPropertyChanged("NodeStyles");
                }
            }
        }
        public MindMapConnectionStyle ConnectionStyle
        {
            get { return connectionStyle; }
            set
            {
                if (connectionStyle != value)
                {
                    connectionStyle = value;
                    OnPropertyChanged("ConnectionStyle");
                }
            }
        }

        #endregion
        #region Public Commands
        private DelegateCommand<object> addSubTopicCommand;
        private DelegateCommand<object> addRightChildCommand;
        private DelegateCommand<object> addLeftChildCommand;
        private DelegateCommand<object> deleteChildCommand;
        private DelegateCommand<object> editText;
        private DelegateCommand<object> endEditText;
        private DelegateCommand<string> changeTopicCommand;
        private DelegateCommand<object> multipleSubTopicCommand;
        private DelegateCommand<string> diagramStyleCommand;
        private DelegateCommand<object> peerCommand;
        private DelegateCommand<object> expandCommand;
        private DelegateCommand<object> collapseCommand;
        private DelegateCommand<object> navigateLeftCommand;
        private DelegateCommand<object> navigateRightCommand;
        private DelegateCommand<object> navigateDownCommand;
        private DelegateCommand<object> navigateUpCommand;
        private DelegateCommand<object> saveCommand;
        private DelegateCommand<object> loadCommand;
        private DelegateCommand<object> addChildCommand;
        private DelegateCommand<object> addSiblingCommand;
        private DelegateCommand<object> zoominCommand;
        private DelegateCommand<object> zoomoutCommand;
        private DelegateCommand<object> fittopageCommand;
        private DelegateCommand<object> fittowidthCommand;

        public DelegateCommand<object> AddSubTopicCommand
        {
            get
            {
                return addSubTopicCommand ??
                    (addSubTopicCommand = new DelegateCommand<object>(OnAddSubTopicCommandExecuted));
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
        public DelegateCommand<object> AddPeerCommand
        {
            get
            {
                return peerCommand ??
                    (peerCommand = new DelegateCommand<object>(OnAddPeerCommandExecute));
            }
        }
        public DelegateCommand<string> ChangeTopicCommand
        {
            get
            {
                return changeTopicCommand ??
                    (changeTopicCommand = new DelegateCommand<string>(OnChangeTopicCommandExecute));
            }
        }
        public DelegateCommand<object> AddMultipleSubTopicCommand
        {
            get
            {
                return multipleSubTopicCommand ??
                    (multipleSubTopicCommand = new DelegateCommand<object>(OnAddMultipleSubTopicCommandExecute));
            }
        }
        public DelegateCommand<string> DiagramStyleCommand
        {
            get
            {
                return diagramStyleCommand ??
                    (diagramStyleCommand = new DelegateCommand<string>(OnDiagramStyleCommandExecute));
            }
        }
        public DelegateCommand<object> ExpandCommand
        {
            get
            {
                return expandCommand ??
                    (expandCommand = new DelegateCommand<object>(OnExpandCommandExecute));
            }
        }
        public DelegateCommand<object> CollapseCommand
        {
            get
            {
                return collapseCommand ??
                    (collapseCommand = new DelegateCommand<object>(OnCollapseCommandExecute));
            }
        }        
        public DelegateCommand<object> NavigateLeftCommand
        {
            get
            {
                return navigateLeftCommand ??
                    (navigateLeftCommand = new DelegateCommand<object>(OnNavigateLeftCommandExecute));
            }
        }
        public DelegateCommand<object> NavigateRightCommand
        {
            get
            {
                return navigateRightCommand ??
                    (navigateRightCommand = new DelegateCommand<object>(OnNavigateRightCommandExecute));
            }
        }
        public DelegateCommand<object> NavigateUpCommand
        {
            get
            {
                return navigateUpCommand ??
                    (navigateUpCommand = new DelegateCommand<object>(OnNavigateUpCommandExecute));
            }
        }
        public DelegateCommand<object> NavigateDownCommand
        {
            get
            {
                return navigateDownCommand ??
                    (navigateDownCommand = new DelegateCommand<object>(OnNavigateDownCommandExecute));
            }
        }
        public DelegateCommand<object> SaveCommand
        {
            get
            {
                return saveCommand ??
                    (saveCommand = new DelegateCommand<object>(OnSaveCommandExecute));
            }
        }
        public DelegateCommand<object> LoadCommand
        {
            get
            {
                return loadCommand ??
                    (loadCommand = new DelegateCommand<object>(OnLoadCommandExecute));
            }
        }
        public DelegateCommand<object> AddChildCommand
        {
            get
            {
                return addChildCommand ??
                    (addChildCommand = new DelegateCommand<object>(OnAddChildCommandExecute));
            }
        }
        public DelegateCommand<object> AddSiblingCommand
        {
            get
            {
                return addSiblingCommand ??
                    (addSiblingCommand = new DelegateCommand<object>(OnAddSiblingCommandExecute));
            }
        }

        public DelegateCommand<object> ZoomInCommand
        {
            get
            {
                return zoominCommand ??
                    (zoominCommand = new DelegateCommand<object>(OnZoomInCommandExecute));
            }
        }

        public DelegateCommand<object> ZoomOutCommand
        {
            get
            {
                return zoomoutCommand ??
                    (zoomoutCommand = new DelegateCommand<object>(OnZoomOutCommandExecute));
            }
        }

        public DelegateCommand<object> FitToPageCommand
        {
            get
            {
                return fittopageCommand ??
                    (fittopageCommand = new DelegateCommand<object>(OnFitToPageCommandExecute));
            }
        }

        public DelegateCommand<object> FitToWidthCommand
        {
            get
            {
                return fittowidthCommand ??
                    (fittowidthCommand = new DelegateCommand<object>(OnFitToWidthCommandExecute));
            }
        }

        #endregion
        #region Override Methods
        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);
            switch(name)
            {
                case "Root":
                    OnRootChanged();
                    break;
                case "Info":
                    this.Root.OffsetX = PageSettings.PageWidth / 2;
                    this.Root.OffsetY = PageSettings.PageHeight / 2;
                    break;
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
                                    || gestureCommand.Command == (Info as IGraphInfo).Commands.FocusToNextItem
                                    || gestureCommand.Command == (Info as IGraphInfo).Commands.FocusToPreviousItem
                                    )
                                    {
                                        this.CommandManager.Commands.Remove(gestureCommand);
                                    }
                                }
                            };
                        }
                    };
                    break;
            }
        }
        #endregion
        #region Command Execution Methods
        private void OnAddSubTopicCommandExecuted(object param)
        {
            NodeViewModel selectedNode = GetFirstSelectedItem();
            if (selectedNode == null)
            {
                OpenCloseWindowBehavior.OpenMessageBoxWindow = true;
            }
            else
            {
                NodeViewModel newNode;
                if (selectedNode is Root)
                {
                    if ((selectedNode as Root).Children.Count() == 0)
                    {
                        addChildAtLeft = false;
                    }
                    else
                    {
                        addChildAtLeft = addChildAtLeft ? false : true;
                    }
                    newNode = CreateRootChid(param, addChildAtLeft ? Direction.Left : Direction.Right);
                }
                else
                {
                    newNode = CreateChild(selectedNode as RootChild, param);
                }
                ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>).Clear();
                newNode.IsSelected = true;
                Updatebowtielayout(newNode);
            }
        }
        /// <summary>
        /// Method will execute when PeerCommand executed
        /// </summary>
        private void OnAddPeerCommandExecute(object param)
        {
            NodeViewModel SelectedNode = GetFirstSelectedItem();
            if (SelectedNode == null)
            {
                OpenCloseWindowBehavior.OpenMessageBoxWindow = true;
            }
            else
            {
                NodeViewModel childNode = null;
                if (SelectedNode != Root)
                {
                    if ((SelectedNode as RootChild).Level == 1)
                    {
                        addChildAtLeft = addChildAtLeft ? false : true;
                        string type = addChildAtLeft ? "left" : "right";

                        childNode = CreateRootChid(param, addChildAtLeft ? Direction.Left : Direction.Right);
                        Updatebowtielayout(childNode);
                    }
                    else
                    {
                        IConnector inEdge = (SelectedNode.Info as INodeInfo).InConnectors.First() as IConnector;
                        if (inEdge != null)
                        {
                            NodeViewModel parentNode = inEdge.SourceNode as NodeViewModel;
                            childNode = CreateChild(parentNode as RootChild, param);
                            Updatebowtielayout(SelectedNode);
                        }
                    }
                }
                if (childNode != null)
                {
                    (childNode as RootChild).Select();
                }
            }
        }
        /// <summary>
        /// Method will execute when MultipleSubTopicCommand executed
        /// </summary>
        private void OnAddMultipleSubTopicCommandExecute(object param)
        {
            NodeViewModel SelectedNode = GetFirstSelectedItem();
            if (SelectedNode == null)
            {
                OpenCloseWindowBehavior.OpenMessageBoxWindow = true;
            }
            else
            {
                OpenCloseWindowBehavior.OpenMultipleSubTopicWindow = true;
            }
        }
        /// <summary>
        /// Method will execute when ChangeTopicCommand executed
        /// </summary>
        private void OnChangeTopicCommandExecute(object param)
        {
            NodeViewModel SelectedNode = GetFirstSelectedItem();
            if (SelectedNode == null)
            {
                OpenCloseWindowBehavior.OpenMessageBoxWindow = true;
            }
            else
            {
                OpenCloseWindowBehavior.OpenTopicChangeWindow = true;
            }
        }
        /// <summary>
        /// Method will execute when DiagramStyleCommand executed
        /// </summary>
        private void OnDiagramStyleCommandExecute(object param)
        {
            OpenCloseWindowBehavior.OpenDiagramStyleWindow = true;
        }
        private void OnExpandCommandExecute(object parma)
        {
            NodeViewModel selectedNode = GetFirstSelectedItem();
            if(selectedNode != null && !selectedNode.IsExpanded)
            {
                ExpandCollapseParameter parameter = new ExpandCollapseParameter()
                {
                    node = selectedNode,
                    IsUpdateLayout = true
                };
                (this.Info as IGraphInfo).Commands.ExpandCollapse.Execute(parameter);
            }
        }
        private void OnCollapseCommandExecute(object param)
        {
            NodeViewModel selectedNode = GetFirstSelectedItem();
            if (selectedNode != null && selectedNode.IsExpanded)
            {
                ExpandCollapseParameter parameter = new ExpandCollapseParameter()
                {
                    node = selectedNode,
                    IsUpdateLayout = true
                };
                (this.Info as IGraphInfo).Commands.ExpandCollapse.Execute(parameter);
                selectedNode.IsSelected = true;
            }
        }

        private void OnNavigateLeftCommandExecute(object param)
        {
            NodeViewModel selectedNode = GetFirstSelectedItem();
            if(selectedNode != null)
            {
                NodeViewModel child = FindNearestChild(selectedNode, Direction.Left);
                if (child != null)
                {
                    if (child is Root)
                    {
                        Root.Select();
                    }
                    else
                    {
                        (child as RootChild).Select();
                    }
                }
            }
        }
        private void OnNavigateRightCommandExecute(object param)
        {
            NodeViewModel selectedNode = GetFirstSelectedItem();
            if (selectedNode != null)
            {
                NodeViewModel child = FindNearestChild(selectedNode, Direction.Right);
                if (child != null)
                {
                    if (child is Root)
                    {
                        Root.Select();
                    }
                    else
                    {
                        (child as RootChild).Select();
                    }
                }
            }
        }
        private void OnNavigateUpCommandExecute(object param)
        {
            NodeViewModel selectedNode = GetFirstSelectedItem();
            if (selectedNode != null && selectedNode != Root)
            {
                NodeViewModel bottomNode = FindNextTopElement(selectedNode);
                if (bottomNode != null)
                {
                    (bottomNode as RootChild).Select();
                }
            }
        }
        private void OnNavigateDownCommandExecute(object param)
        {
            NodeViewModel selectedNode = GetFirstSelectedItem();
            if(selectedNode != null && selectedNode != Root)
            {
                NodeViewModel bottomNode = FindNextBottomElement(selectedNode);
                if(bottomNode != null)
                {
                    (bottomNode as RootChild).Select();
                }
            }
        }
        private void OnSaveCommandExecute(object param)
        {
            SaveFileDialog saveAsFileDialog = new SaveFileDialog() { Title = "Save ", DefaultExt = ".xml" };
            saveAsFileDialog.Filter = "Text file (*.xml)|*.xml";

            if (saveAsFileDialog.ShowDialog() == true)
            {
                string _SavedPath = saveAsFileDialog.FileName.ToString();
                IGraphInfo graph = this.Info as IGraphInfo;
                //PageVM page = this.SelectedDiagram.PageSettings as PageVM;
                //page.Scale = graph.ScrollInfo.CurrentZoom;
                using (Stream fileStream = saveAsFileDialog.OpenFile())
                {
                    graph.Save(fileStream);
                }
            }
        }
        private void OnLoadCommandExecute(object param)
        {
            if (param == null || param is IGestureParameter)
            {
                OpenFileDialog openDialogBox = new OpenFileDialog();
                openDialogBox.Title = "Load";
                openDialogBox.RestoreDirectory = true;
                openDialogBox.DefaultExt = "xml";
                openDialogBox.Filter = "xml files (*.xml)|*.xml";
                bool? isFileChoosen = openDialogBox.ShowDialog();
                if (isFileChoosen == true)
                {
                    this.isLoading = true;
                    this.addChildAtLeft = false;
                    IGraphInfo graph = this.Info as IGraphInfo;
                    string _SavedPath = openDialogBox.FileName.ToString();
                    using (FileStream fileStream = File.OpenRead(_SavedPath))
                    {
                        graph.Load(fileStream);
                    }
                    this.isLoading = false;
                }
            }
            else
            {
                this.isLoading = true;
                this.addChildAtLeft = false;
                IGraphInfo graph = this.Info as IGraphInfo;
                string value = param.ToString();
#if NETCORE

                value = param.ToString().Insert(0, "../");
#endif
                using (FileStream fileStream = File.OpenRead(value))
                {
                    graph.Load(fileStream);
                }
                this.isLoading = false;
            }
            FitToPageParameter fitToPage = new FitToPageParameter() { FitToPage = FitToPage.FitToPage, Region = Region.PageSettings };
            (this.Info as IGraphInfo).Commands.FitToPage.Execute(fitToPage);
            //this.Root.OffsetX = ((this.Info as IGraphInfo).Viewport.Width / 2) * (this.Info as IGraphInfo).ScrollInfo.CurrentZoom;
            //this.Root.OffsetY = (this.Info as IGraphInfo).Viewport.Height / 2 * (this.Info as IGraphInfo).ScrollInfo.CurrentZoom;
            Updatebowtielayout(Root);
        }
        private void OnAddChildCommandExecute(object param)
        {
            NodeViewModel selectedNode = GetFirstSelectedItem();
            if(selectedNode != null)
            {
                this.AddSubTopicCommand.Execute(null);
            }
            else
            {
                OpenCloseWindowBehavior.OpenMessageBoxWindow = true;
            }
        }
        private void OnAddSiblingCommandExecute(object param)
        {
            NodeViewModel selectedNode = GetFirstSelectedItem();
            if (selectedNode == null)
            {
                OpenCloseWindowBehavior.OpenMessageBoxWindow = true;
            }
            else if (!(selectedNode is Root))
            {
                this.AddPeerCommand.Execute(null);
            }            
        }
        /// <summary>
        /// Method will execute when AddLeftChildCommand executed
        /// </summary>
        private void AddLeftChildCommandExecute(object param)
        {
            CreateSubTopic(param);
        }
        private void AddRightChildCommandExecute(object param)
        {
            NodeViewModel selectedNode = GetFirstSelectedItem();
            RootChild newNode;
            if (selectedNode == Root)
            {
                newNode = CreateRootChid(param, Direction.Right);
            }
            else
            {
                newNode = CreateChild(selectedNode as RootChild, param);
            }
            newNode.Select();
            Updatebowtielayout(newNode);
        }
        private void DeleteChildCommandExecute(object param)
        {
            NodeViewModel firstSelectedItem = GetFirstSelectedItem();
            NodeViewModel nextElementToBeSelected = null;
            if (firstSelectedItem is Child)
            {
                RootChild parent = (firstSelectedItem as Child).Parent;
                int index = parent.Children.IndexOf(firstSelectedItem as Child);
                if (parent.Children.Count() > index + 1)
                {
                    nextElementToBeSelected = parent.Children[index + 1];
                }
                else
                {
                    nextElementToBeSelected = parent;
                }
            }
            else if(firstSelectedItem is RootChild)
            {
                RootChild rootChild = FindNexeRootChildAtSameDirection(firstSelectedItem as RootChild);
                if (rootChild != null)
                {
                    nextElementToBeSelected = rootChild;
                }
                else
                {
                    nextElementToBeSelected = Root;
                }
            }
            for (int i = 0; i < ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>).Count();)
            {
                NodeViewModel selectedNode = ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>)[i] as NodeViewModel;
                if (selectedNode != Root)
                {
                    DeleteNode(selectedNode);
                    Updatebowtielayout(selectedNode);
                }
                else
                {
                    i++;
                }
            }
            if(nextElementToBeSelected != null && (this.Nodes as NodeCollection).Contains(nextElementToBeSelected))
            {
                nextElementToBeSelected.IsSelected = true;
            }
            if (Root.IsSelected)
            {
                UpdateQuickCommandsVisibility(Root);
            }
        }
        private void EditTextExecute(object param)
        {
            NodeViewModel SelectedNode = GetFirstSelectedItem();
            if (SelectedNode != null)
            {
                IAnnotation annotation = (SelectedNode.Annotations as AnnotationCollection).First();
                annotation.Mode = ContentEditorMode.Edit;
            }
        }
        private void EndEditTextExecute(object param)
        {
            NodeViewModel SelectedNode = GetFirstSelectedItem();
            if (SelectedNode != null)
            {
                IAnnotation annotation = (SelectedNode.Annotations as AnnotationCollection).First();
                annotation.Mode = ContentEditorMode.View;
            }
        }


        /// <summary>
        /// Represent a method to zoom in the page to by 0.2 level.
        /// </summary>
        private void OnZoomInCommandExecute(object param)
        {
            (this.Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParamenter() { ZoomFactor = 0.2, ZoomCommand = ZoomCommand.ZoomIn });
        }

        /// <summary>
        /// Represent a method to zoom out the page to by 0.2 level.
        /// </summary>
        private void OnZoomOutCommandExecute(object param)
        {
            (this.Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParamenter() { ZoomFactor = 0.2, ZoomCommand = ZoomCommand.ZoomOut });
        }

        /// <summary>
        /// Represent a method to fit the page to current window.
        /// </summary>
        private void OnFitToPageCommandExecute(object param)
        {
            (this.Info as IGraphInfo).Commands.FitToPage.Execute(new FitToPageParameter() { FitToPage = FitToPage.FitToPage, CanZoomIn = true, Region = Region.PageSettings });
        }

        /// <summary>
        /// Represent a method to fit the page to current window width.
        /// </summary>
        private void OnFitToWidthCommandExecute(object param)
        {
            (this.Info as IGraphInfo).Commands.FitToPage.Execute(new FitToPageParameter() { FitToPage = FitToPage.FitToWidth });
        }
        #endregion
        #region Diagram Commands Execution
        private void ItemAddedCommandExecute(object param)
        {
            ItemAddedEventArgs args = param as ItemAddedEventArgs;
            if (args.Item is NodeViewModel)
            {
                if (isLoading)
                {
                    if (args.Item is Root)
                    {
                        this.Root = args.Item as Root;                        
                        (this.LayoutManager.Layout as DirectedTreeLayout).LayoutRoot = this.Root;
                    }
                }
                AddContextMenutoNode(args.Item as NodeViewModel);
                Updatebowtielayout(args.Item as NodeViewModel);
            }
            else
            {
                ConnectorViewModel connector = args.Item as ConnectorViewModel;
                connector.Annotations = null;
                connector.ThemeStyleId = Syncfusion.UI.Xaml.Diagram.Theming.StyleId.Accent1 | Syncfusion.UI.Xaml.Diagram.Theming.StyleId.Subtly;
                connector.Constraints = ConnectorConstraints.Default ^ ConnectorConstraints.Selectable;
                
                NodeViewModel sourceNode = connector.SourceNode as NodeViewModel;
                NodeViewModel targetNode = connector.TargetNode as NodeViewModel;
                connector.ConnectorGeometryStyle = SetDefultConnectorGeometryStyle(sourceNode);
                connector.TargetDecoratorStyle = SetDefaultTargetDecoratorStyle(sourceNode);
                if (isLoading)
                {
                    if (connector.Segments is ObservableCollection<IConnectorSegment>)
                    {
                        if ((connector.Segments as ObservableCollection<IConnectorSegment>).Count() > 0)
                        {
                            if ((connector.Segments as ObservableCollection<IConnectorSegment>)[0] is CubicCurveSegment)
                            {
                                if (DefaultConnectorType != ConnectorType.CubicBezier)
                                {
                                    DefaultConnectorType = ConnectorType.CubicBezier;
                                }
                            }
                            else
                            {
                                if (DefaultConnectorType != ConnectorType.Orthogonal)
                                {
                                    DefaultConnectorType = ConnectorType.Orthogonal;
                                }
                            }
                        }
                    }
                    
                    if (sourceNode is Root)
                    {
                        (sourceNode as Root).Children.Add(targetNode as RootChild);
                        (targetNode as RootChild).Level = 1;
                        // Work around
                        if ((sourceNode as Root).Level < 5)
                        {
                            LevelStyles[(sourceNode as Root).Level] = new System.Tuple<string, StyleId>((sourceNode as Root).ShapeName, LevelStyles[(sourceNode as Root).Level].Item2);
                        }
                        if ((targetNode as RootChild).Level < 5)
                        {
                            LevelStyles[(targetNode as RootChild).Level] = new System.Tuple<string, StyleId>((targetNode as RootChild).ShapeName, LevelStyles[(targetNode as RootChild).Level].Item2);
                        }
                        foreach (RootChild child in (targetNode as RootChild).Children)
                        {
                            child.Level = (targetNode as RootChild).Level + 1;
                            if (child.Level < 5)
                            {
                                LevelStyles[(child as RootChild).Level] = new System.Tuple<string, StyleId>((child as RootChild).ShapeName, LevelStyles[(child as RootChild).Level].Item2);
                            }
                        }
                    }
                    else
                    {
                        (sourceNode as RootChild).Children.Add(targetNode as Child);
                        (targetNode as Child).Parent = sourceNode as RootChild;
                        (targetNode as Child).Level = (sourceNode as RootChild).Level + 1;
                        // Work around
                        if ((sourceNode as RootChild).Level < 5)
                        {
                            LevelStyles[(sourceNode as RootChild).Level] = new System.Tuple<string, StyleId>((sourceNode as RootChild).ShapeName, LevelStyles[(sourceNode as RootChild).Level].Item2);
                        }
                        if ((targetNode as RootChild).Level < 5)
                        {
                            LevelStyles[(targetNode as RootChild).Level] = new System.Tuple<string, StyleId>((targetNode as RootChild).ShapeName, LevelStyles[(targetNode as RootChild).Level].Item2);
                        }
                        foreach (RootChild child in (targetNode as RootChild).Children)
                        {
                            child.Level = (targetNode as RootChild).Level + 1;
                            if (child.Level < 5)
                            {
                                LevelStyles[(child as RootChild).Level] = new System.Tuple<string, StyleId>((child as RootChild).ShapeName, LevelStyles[(child as RootChild).Level].Item2);
                            }
                        }
                    }
                }
            }
        }
        private void ItemSelectedCommandExecute(object param)
        {
            DiagramEventArgs args = param as DiagramEventArgs;
            if (args.Item is NodeViewModel)
            {
                NodeViewModel node = args.Item as NodeViewModel;
                UpdateQuickCommandsVisibility(Root.IsSelected ? Root : node);
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
                Updatebowtielayout(Root);
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
                if (args.Item is NodeViewModel)
                {
                    if (args.Item is Root)
                    {
                        args.Cancel = true;
                    }
                    else
                    {
                        DeleteNode(args.Item as NodeViewModel);
                    }
                }
            }
            else
            {
                NodeViewModel SelectedNode = GetFirstSelectedItem();
                DeleteNode(SelectedNode);
            }
        }
        /// <summary>
        /// Method will execute when ItemDeletedCommand executed
        /// </summary>
        /// <param name="param"></param>
        private void ItemDeletedCommandExecute(object param)
        {
            ItemDeletedEventArgs args = param as ItemDeletedEventArgs;
            if (args.Item is ConnectorViewModel)
            {
                ConnectorViewModel connectorVM = args.Item as ConnectorViewModel;
                NodeViewModel sourceNode = connectorVM.SourceNode as NodeViewModel;
                NodeViewModel targetNode = connectorVM.TargetNode as NodeViewModel;
                if (sourceNode != null)
                {
                    if (sourceNode is Root)
                    {
                        (sourceNode as Root).Children.Remove(targetNode as RootChild);
                    }
                    else
                    {
                        (sourceNode as RootChild).Children.Remove(targetNode as Child);
                    }
                }
            }
            else if (args.Item is NodeViewModel && args.Item != Root)
            {
                if (!isLoading)
                {
                    Updatebowtielayout(args.Item as NodeViewModel);
                }
            }
        }
        private void NodeChangedCommandExecute(object param)
        {
            if (!isLayoutUpdating)
            {
                ChangeEventArgs<object, NodeChangedEventArgs> args = param as ChangeEventArgs<object, NodeChangedEventArgs>;
                if (args.NewValue.InteractionState == NodeChangedInteractionState.Resized)
                {
                    NodeViewModel node = args.Item as NodeViewModel;
                    isLayoutUpdating = true;
                    Updatebowtielayout(node);
                    isLayoutUpdating = false;
                }
            }
        }
        #endregion
        #region Internal Methods
        /// <summary>
        /// Change shape for selected node
        /// </summary>
        /// <param name="shape"></param>
        internal void ChangeItemShape(string shape)
        {
            foreach (NodeViewModel nodeVM in ((IEnumerable<object>)(this.SelectedItems as SelectorViewModel).Nodes))
            {
                //nodeVM.Shape = App.Current.Resources[shape];
                //nodeVM.ShapeName = shape;
                if(nodeVM is Root)
                {
                    (nodeVM as Root).ShapeName = shape;
                }
                else
                {
                    (nodeVM as RootChild).ShapeName = shape;
                }
            }
        }
        /// <summary>
        /// Adding child elements when executing Multiple Subtopics command
        /// </summary>
        /// <param name="mulipleSubtopics"></param>
        internal void AddMultipleSubTopics(string mulipleSubtopics, DelegateCommand<object> SubTopicCommand)
        {
            List<string> subtopics = Regex.Split(mulipleSubtopics, "\r\n|\r|\n").ToList();
            NodeViewModel selectedNode = GetFirstSelectedItem();
            foreach (string subtopic in subtopics)
            {
                if (!string.IsNullOrEmpty(subtopic))
                {
                    if (selectedNode is Root)
                    {
                        if ((selectedNode as Root).Children.Count() == 0)
                        {
                            addChildAtLeft = false;
                        }
                        else
                        {
                            addChildAtLeft = addChildAtLeft ? false : true;
                        }
                        CreateRootChid(subtopic, addChildAtLeft ? Direction.Left : Direction.Right);
                    }
                    else
                    {
                        CreateChild(selectedNode as RootChild, subtopic);
                    }
                }
            }
            NodeViewModel lastnewNode = (this.Nodes as ObservableCollection<NodeViewModel>).Last();
            if (lastnewNode is RootChild)
            {
                (lastnewNode as RootChild).Select();
            }
            Updatebowtielayout(lastnewNode);
        }
        internal void ChangeItemShapeForSelectedLevel()
        {
            foreach (NodeViewModel node in this.Nodes as NodeCollection)
            {
                if (node == Root)
                {
                    (node as Root).ShapeName = LevelStyles[0].Item1;
                }
                else
                {
                    if ((node as RootChild).Level < 5)
                    {
                        (node as RootChild).ShapeName = LevelStyles[(node as RootChild).Level].Item1;
                    }
                    else
                    {
                        (node as RootChild).ShapeName = LevelStyles[4].Item1;
                    }
                }
            }
        }
        internal void ChangeStyleIdForSelectedLevel()
        {
            foreach (NodeViewModel node in Nodes as NodeCollection)
            {
                if (node == Root)
                {
                    node.ThemeStyleId = LevelStyles[0].Item2;
                }
                else
                {
                    if ((node as RootChild).Level < 5)
                    {
                        node.ThemeStyleId = LevelStyles[(node as RootChild).Level].Item2;
                    }
                    else
                    {
                        node.ThemeStyleId = LevelStyles[4].Item2;
                    }
                }
            }
        }
        /// <summary>
        /// Change Connector Type based on inbuilt options
        /// </summary>
        /// <param name="style"></param>
        internal void ChangeDiagramStyleForConnector(MindMapViewModel diagram, string style)
        {
            switch (style)
            {
                case "Curved":
                    this.DefaultConnectorType = ConnectorType.CubicBezier;
                    foreach (ConnectorViewModel connector in this.Connectors as ConnectorCollection)
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
                    foreach (ConnectorViewModel connector in this.Connectors as ConnectorCollection)
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
        #endregion
        #region Private Methods
        private void OnRootChanged()
        {
            if (!(this.Nodes as NodeCollection).Contains(Root))
            {
                (this.Nodes as NodeCollection).Add(Root);
            }
            if (this.LayoutManager != null && this.LayoutManager.Layout != null)
            {
                (this.LayoutManager.Layout as DirectedTreeLayout).LayoutRoot = Root;
            }
        }
        private RootChild CreateRootChid(object param, Direction direction)
        {
            if (!Root.IsExpanded)
            {
                ExpandCollapseParameter parameter = new ExpandCollapseParameter()
                {
                    node = Root,
                    IsUpdateLayout = true
                };
                (this.Info as IGraphInfo).Commands.ExpandCollapse.Execute(parameter);
            }
            RootChild rootChild = new RootChild(direction);
            rootChild.UnitWidth = 120;
            rootChild.UnitHeight = 30;
            rootChild.ThemeStyleId = StyleId.Variant3;
            if (param != null && !(param is IGestureParameter))
            {
                IAnnotation annotation = (rootChild.Annotations as AnnotationCollection)[0];
                (annotation as TextAnnotationViewModel).Text = param.ToString();
            }
            rootChild.Ports = new PortCollection
            {
                new NodePortViewModel()
                {
                    NodeOffsetX =0 , NodeOffsetY = 1,
                    Displacement = new Thickness(0,-1, 0, 0)
                },
                new NodePortViewModel()
                {
                    NodeOffsetX =0 , NodeOffsetY = 0.4
                },
                new NodePortViewModel()
                {
                    NodeOffsetX =1 , NodeOffsetY = 0.05
                },
                new NodePortViewModel()
                {
                    NodeOffsetX =1 , NodeOffsetY = 1,
                    Displacement = new Thickness(0,-1, 0, 0)
                }
            };
            Root.Children.Add(rootChild);
            rootChild.Level = Root.Level + 1;
            (this.Nodes as NodeCollection).Add(rootChild);
            Connect(Root, rootChild);
            if (rootChild.Level < 5)
            {
                rootChild.ShapeName = LevelStyles[rootChild.Level].Item1;
                rootChild.ThemeStyleId = LevelStyles[rootChild.Level].Item2;
            }
            else
            {
                rootChild.ShapeName = LevelStyles[4].Item1;
                rootChild.ThemeStyleId = LevelStyles[4].Item2;
            }
            return rootChild;
        }
        private Child CreateChild(RootChild parent, object param)
        {
            if (!parent.IsExpanded)
            {
                ExpandCollapseParameter parameter = new ExpandCollapseParameter()
                {
                    node = parent,
                    IsUpdateLayout = true
                };
                (this.Info as IGraphInfo).Commands.ExpandCollapse.Execute(parameter);
            }
            Child child = new Child(parent);
            child.UnitWidth = 120;
            child.UnitHeight = 30;
            
            if (param != null && !(param is IGestureParameter))
            {
                IAnnotation annotation = (child.Annotations as AnnotationCollection)[0];
                (annotation as TextAnnotationViewModel).Text = param.ToString();
            }
            child.Ports = new PortCollection
            {
                new NodePortViewModel()
                {
                    NodeOffsetX =0 , NodeOffsetY = 1,
                    Displacement = new Thickness(0,-1, 0, 0)
                },
                new NodePortViewModel()
                {
                    NodeOffsetX =0 , NodeOffsetY = 0.4
                },
                new NodePortViewModel()
                {
                    NodeOffsetX =1 , NodeOffsetY = 0.05
                },
                new NodePortViewModel()
                {
                    NodeOffsetX =1 , NodeOffsetY = 1,
                    Displacement = new Thickness(0,-1, 0, 0)
                }
            };
            parent.Children.Add(child);
            child.Level = parent.Level + 1;            
            (this.Nodes as NodeCollection).Add(child);
            Connect(parent, child);
            if (child.Level < 5)
            {
                child.ShapeName = LevelStyles[child.Level].Item1;
                child.ThemeStyleId = LevelStyles[child.Level].Item2;
            }
            else
            {
                child.ShapeName = LevelStyles[4].Item1;
                child.ThemeStyleId = LevelStyles[4].Item2;
            }
            if (!string.IsNullOrEmpty(parent.ShapeName) && parent.ShapeName.Equals("Line"))
            {
                if ((parent.Info as INodeInfo).OutConnectors != null && (parent.Info as INodeInfo).OutConnectors.Count() > 0)
                {
                    foreach (IConnector connector in (parent.Info as INodeInfo).OutConnectors.ToList())
                    {
                        if (parent.Direction == Direction.Left)
                        {
                            connector.SourcePort = (parent.Ports as ObservableCollection<IPort>)[0];
                        }
                        else if (parent.Direction == Direction.Right)
                        {
                            connector.SourcePort = (parent.Ports as ObservableCollection<IPort>)[3];
                        }
                    }
                }
            }
            return child;
        }
        private void CreateSubTopic(object param, bool selectNewNode = true)
        {
            NodeViewModel selectedNode = GetFirstSelectedItem();
            RootChild newNode;
            if (selectedNode == Root)
            {
                newNode = CreateRootChid(param, Direction.Left);
            }
            else
            {
                newNode = CreateChild(selectedNode as RootChild, param);
            }            
            Updatebowtielayout(newNode);
            if (selectNewNode)
            {
                ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>).Clear();
                newNode.IsSelected = true;
            }
        }
        private void Connect(NodeViewModel source, NodeViewModel target)
        {
            ConnectorViewModel conn = new ConnectorViewModel();
            conn.SourceNode = source;
            conn.TargetNode = target;
            (this.Connectors as ConnectorCollection).Add(conn);
        }
        private NodeViewModel GetFirstSelectedItem()
        {
            object SelectedNode = ((IEnumerable<object>)(this.SelectedItems as SelectorViewModel).Nodes).FirstOrDefault();
            if (SelectedNode == null)
            {
                return null;
            }
            return SelectedNode as NodeViewModel;
        }        
        private void Updatebowtielayout(NodeViewModel node)
        {
            if (node == Root)
            {
                (this.LayoutManager.Layout as DirectedTreeLayout).UpdateLayout(Root);
            }
            if (Root.Info != null && (Root.Info as INodeInfo).OutNeighbors != null && (Root.Info as INodeInfo).OutNeighbors.ToList().Find(c => (c as RootChild).Direction == Direction.Left) != null)
            {
                foreach (NodeViewModel item in this.Nodes as NodeCollection)
                {
                    if (item is Root || (item as RootChild).Direction == Direction.Left)
                    {
                        item.Constraints = item.Constraints & ~NodeConstraints.ExcludeFromLayout;
                    }
                    else
                    {
                        item.Constraints = item.Constraints | NodeConstraints.ExcludeFromLayout;
                    }
                }
                if ((this.Nodes as ObservableCollection<NodeViewModel>).Contains(Root))
                {
                    (this.LayoutManager.Layout as DirectedTreeLayout).Orientation = TreeOrientation.RightToLeft;
                    (this.LayoutManager.Layout as DirectedTreeLayout).UpdateLayout(Root);
                }
            }
            if (Root.Info != null && (Root.Info as INodeInfo).OutNeighbors != null && (Root.Info as INodeInfo).OutNeighbors.ToList().Find(c => (c as RootChild).Direction == Direction.Right) != null)
            {
                foreach (NodeViewModel item in this.Nodes as NodeCollection)
                {
                    if (item is Root || (item as RootChild).Direction == Direction.Right)
                    {
                        item.Constraints = item.Constraints & ~NodeConstraints.ExcludeFromLayout;
                    }
                    else
                    {
                        item.Constraints = item.Constraints | NodeConstraints.ExcludeFromLayout;
                    }
                }
                
                if ((this.Nodes as ObservableCollection<NodeViewModel>).Contains(Root))
                {
                    (this.LayoutManager.Layout as DirectedTreeLayout).Orientation = TreeOrientation.LeftToRight;
                    (this.LayoutManager.Layout as DirectedTreeLayout).UpdateLayout(Root);
                }
            }
            (this.LayoutManager.Layout as DirectedTreeLayout).UpdateLayout(Root);
        }
        private void DeleteNode(NodeViewModel SelectedNode)
        {
            if ((SelectedNode.Info as INodeInfo).OutNeighbors != null && (SelectedNode.Info as INodeInfo).OutNeighbors.Count() > 0)
            {
                for (int i = (SelectedNode.Info as INodeInfo).OutNeighbors.Count() - 1; (SelectedNode.Info as INodeInfo).OutNeighbors.Count() - 1 >= i && i >= 0; i--)
                {
                    NodeViewModel c = (SelectedNode.Info as INodeInfo).OutNeighbors.ElementAt(i) as NodeViewModel;
                    DeleteNode(c);
                }
            }
            if ((SelectedNode.Info as INodeInfo).InOutConnectors != null)
            {
                for (int i = (SelectedNode.Info as INodeInfo).InOutConnectors.Count() - 1; (SelectedNode.Info as INodeInfo).InOutConnectors.Count() - 1 >= i && i >= 0; i--)
                {
                    ConnectorViewModel con = (SelectedNode.Info as INodeInfo).InOutConnectors.ElementAt(i) as ConnectorViewModel;
                    (this.Connectors as ObservableCollection<ConnectorViewModel>).Remove(con);
                }
            }
            (this.Nodes as ObservableCollection<NodeViewModel>).Remove(SelectedNode);

        }
        private void UpdateQuickCommandsVisibility(NodeViewModel node)
        {
            if (Quickcommands_Delete != null)
            {
                // Work around : Quick Command related things.
                if (node is Root)
                {
                    if ((node as Root).Children.Count() == 0)
                    {
                        addChildAtLeft = false;
                    }
                    Quickcommands_Delete.VisibilityMode = VisibilityMode.Connector;
                    Quickcommands_Left.VisibilityMode = VisibilityMode.Node;
                    Quickcommands_Right.VisibilityMode = VisibilityMode.Node;
                }
                else if ((node as RootChild).Direction == Direction.Left)
                {
                    Quickcommands_Delete.VisibilityMode = VisibilityMode.Node;
                    Quickcommands_Delete.Margin = new Thickness(22, 0, 0, 0);
                    Quickcommands_Delete.OffsetX = 1;
                    Quickcommands_Left.VisibilityMode = VisibilityMode.Node;
                    Quickcommands_Right.VisibilityMode = VisibilityMode.Connector;
                }
                else if ((node as RootChild).Direction == Direction.Right)
                {
                    Quickcommands_Delete.VisibilityMode = VisibilityMode.Node;
                    Quickcommands_Delete.Margin = new Thickness(-22, 0, 0, 0);
                    Quickcommands_Delete.OffsetX = 0;
                    Quickcommands_Left.VisibilityMode = VisibilityMode.Connector;
                    Quickcommands_Right.VisibilityMode = VisibilityMode.Node;
                }
            }
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
            CommandManager.Commands.Add
                (
                    new GestureCommand()
                    {
                        Command = AddSubTopicCommand,
                        Gesture = new Gesture
                        {
                            Key = VirtualKey.B,
                            KeyModifiers = VirtualKeyModifiers.Alt,
                            KeyState = CoreVirtualKeyStates.Down

                        },
                        Name = "SubTopic",
                    }
                );
            CommandManager.Commands.Add
            (
                new GestureCommand()
                {
                    Command = AddPeerCommand,
                    Gesture = new Gesture
                    {
                        Key = VirtualKey.P,
                        KeyModifiers = VirtualKeyModifiers.Alt,
                        KeyState = CoreVirtualKeyStates.Down

                    },
                    Name = "Peer",
                }
            );
            CommandManager.Commands.Add
            (
                new GestureCommand()
                {
                    Command = AddMultipleSubTopicCommand,
                    Gesture = new Gesture
                    {
                        Key = VirtualKey.U,
                        KeyModifiers = VirtualKeyModifiers.Alt,
                        KeyState = CoreVirtualKeyStates.Down

                    },
                    Name = "MultipleSubTopic",
                }
            );
            CommandManager.Commands.Add
            (
                new GestureCommand()
                {
                    Command = ExpandCommand,
                    Gesture = new Gesture
                    {
                        Key = VirtualKey.OemPlus,
                        KeyState = CoreVirtualKeyStates.Down

                    },
                    Name = "ExpandCommand",
                }
            );
            CommandManager.Commands.Add
            (
                new GestureCommand()
                {
                    Command = CollapseCommand,
                    Gesture = new Gesture
                    {
                        Key = VirtualKey.OemMinus,
                        KeyState = CoreVirtualKeyStates.Down

                    },
                    Name = "CollapseCommand",
                }
            );
            CommandManager.Commands.Add
            (
                new GestureCommand()
                {
                    Command = NavigateLeftCommand,
                    Gesture = new Gesture
                    {
                        Key = VirtualKey.Left,
                        KeyState = CoreVirtualKeyStates.Down

                    },
                    Name = "NavigateLeftCommand",
                }
            );
            CommandManager.Commands.Add
            (
                new GestureCommand()
                {
                    Command = NavigateRightCommand,
                    Gesture = new Gesture
                    {
                        Key = VirtualKey.Right,
                        KeyState = CoreVirtualKeyStates.Down

                    },
                    Name = "NavigateRightCommand",
                }
            );
            CommandManager.Commands.Add
            (
                new GestureCommand()
                {
                    Command = NavigateDownCommand,
                    Gesture = new Gesture
                    {
                        Key = VirtualKey.Down,
                        KeyState = CoreVirtualKeyStates.Down

                    },
                    Name = "NavigateDownCommand",
                }
            );
            CommandManager.Commands.Add
            (
                new GestureCommand()
                {
                    Command = NavigateUpCommand,
                    Gesture = new Gesture
                    {
                        Key = VirtualKey.Up,
                        KeyState = CoreVirtualKeyStates.Down

                    },
                    Name = "NavigateUpCommand",
                }
            );
            CommandManager.Commands.Add
            (
                new GestureCommand()
                {
                    Command = AddChildCommand,
                    Gesture = new Gesture
                    {
                        Key = VirtualKey.Tab,
                        KeyState = CoreVirtualKeyStates.Down

                    },
                    Name = "AddChildCommand",
                }
            );
            CommandManager.Commands.Add
            (
                new GestureCommand()
                {
                    Command = AddSiblingCommand,
                    Gesture = new Gesture
                    {
                        Key = VirtualKey.Enter,
                        KeyState = CoreVirtualKeyStates.Down

                    },
                    Name = "AddSiblingCommand",
                }
            );
            CommandManager.Commands.Add
            (
                new GestureCommand()
                {
                    Command = SaveCommand,
                    Gesture = new Gesture
                    {
                        Key = VirtualKey.S,
                        KeyModifiers = VirtualKeyModifiers.Control,
                        KeyState = CoreVirtualKeyStates.Down

                    },
                    Name = "SaveCommand",
                }
            );
            CommandManager.Commands.Add
            (
                new GestureCommand()
                {
                    Command = LoadCommand,
                    Gesture = new Gesture
                    {
                        Key = VirtualKey.O,
                        KeyModifiers = VirtualKeyModifiers.Control,
                        KeyState = CoreVirtualKeyStates.Down

                    },
                    Name = "LoadCommand",
                }
            );
        }
        private void AddContextMenutoNode(NodeViewModel node)
        {
            if (node != null)
            {
                if (node.Menu == null)
                {
                    node.Menu = new DiagramMenu();
                    node.Menu.MenuItems = new ObservableCollection<DiagramMenuItem>();
                }

                DiagramMenuItem mi = new DiagramMenuItem()
                {
                    Content = "Add Subtopic",
                    Command = AddSubTopicCommand
                };
                DiagramMenuItem mi1 = new DiagramMenuItem()
                {
                    Content = "Add Peer Topic",
                    Command = AddPeerCommand
                };
                DiagramMenuItem mi2 = new DiagramMenuItem()
                {
                    Content = "Add Multiple Subtopics",
                    Command = AddMultipleSubTopicCommand
                };
                DiagramMenuItem mi3 = new DiagramMenuItem()
                {
                    Content = "Change Topic Shapes",
                    Command = ChangeTopicCommand
                };
                (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(mi);
                if (node != Root)
                {
                    (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(mi1);
                }
                (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(mi2);
                (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(mi3);

                DiagramMenuItem mi4 = new DiagramMenuItem()
                {
                    Content = "Edit Text",
                    Command = EditText
                };
                DiagramMenuItem mi5 = new DiagramMenuItem()
                {
                    Content = "Delete",
                    Command = ItemDeletingCommand
                };
                (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(mi4);
                if (node != Root)
                {
                    (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(mi5);
                }
                node.Constraints = node.Constraints | NodeConstraints.Menu;
                node.Constraints = node.Constraints & ~NodeConstraints.InheritMenu;
            }
        }
        private NodeViewModel FindNearestChild(NodeViewModel node, Direction direction)
        {
            NodeViewModel previousChild = null;
            if (node is Root)
            {
                for (int x = 0; x < (node as Root).Children.Count(); x++)
                {
                    if ((node as Root).Children[x].Direction == direction)
                    {
                        double distance = node.OffsetY - (node as Root).Children[x].OffsetY;
                        if (distance < 0)
                        {
                            if (x == 0)
                            {
                                previousChild = (node as Root).Children[x];
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        previousChild = (node as Root).Children[x];
                    }
                }
            }
            else
            {
                if ((node as RootChild).Direction != direction)
                {
                    if (node is Child)
                    {
                        previousChild = (node as Child).Parent;
                    }
                    else
                    {
                        previousChild = Root;
                    }
                }
                else
                {
                    for (int x = 0; x < (node as RootChild).Children.Count(); x++)
                    {
                        if ((node as RootChild).Children[x].Direction == direction)
                        {
                            double distance = node.OffsetY - (node as RootChild).Children[x].OffsetY;
                            if (distance < 0)
                            {
                                if (x == 0)
                                {
                                    previousChild = (node as RootChild).Children[x];
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            previousChild = (node as RootChild).Children[x];
                        }
                    }
                }
            }
            return previousChild;
        }
        private NodeViewModel FindNextBottomElement(NodeViewModel node)
        {
            NodeViewModel nextBottomElement = null;
            if(!(node is Root))
            {
                if(node is Child)
                {                    
                    RootChild parent = (node as Child).Parent;
                    int index = parent.Children.IndexOf(node as Child);
                    if(parent.Children.Count() > index + 1)
                    {
                        nextBottomElement = parent.Children[index + 1];
                    }
                }
                else
                {
                    nextBottomElement = FindNexeRootChildAtSameDirection(node as RootChild);
                }
            }
            return nextBottomElement;
        }
        private NodeViewModel FindNextTopElement(NodeViewModel node)
        {
            NodeViewModel nextBottomElement = null;
            if (!(node is Root))
            {
                if (node is Child)
                {
                    RootChild parent = (node as Child).Parent;
                    int index = parent.Children.IndexOf(node as Child);
                    if (index != 0)
                    {
                        nextBottomElement = parent.Children[index - 1];
                    }
                }
                else
                {
                    nextBottomElement = FindPreviousRootChildAtSameDirection(node as RootChild);
                }
            }
            return nextBottomElement;
        }
        private RootChild FindNexeRootChildAtSameDirection(RootChild node)
        {
            RootChild child = null;
            int index = Root.Children.IndexOf(node);
            for (int i = index + 1; i < Root.Children.Count(); i++)
            {
                if(Root.Children[i].Direction == node.Direction)
                {
                    child = Root.Children[i];
                    break;
                }
            }
            return child;
        }
        private RootChild FindPreviousRootChildAtSameDirection(RootChild node)
        {
            RootChild child = null;
            int index = Root.Children.IndexOf(node);
            if (index != 0)
            {
                for (int i = index - 1; i >= 0; i--)
                {
                    if (Root.Children[i].Direction == node.Direction)
                    {
                        child = Root.Children[i];
                        break;
                    }
                }
            }
            return child;
        }
        private Style SetDefultConnectorGeometryStyle(NodeViewModel node)
        {
            Style _mStaticGeometryStyle = null;
            var info = node.Info as INodeInfo;
            if (node.Constraints.Contains(NodeConstraints.ThemeStyle) && info != null && this.Theme != null)
            {
                DiagramItemStyle style = this.Theme.GetNodeStyle(node.ThemeStyleId);
                _mStaticGeometryStyle = new Style()
                {
                    TargetType = typeof(System.Windows.Shapes.Shape),
                };
                _mStaticGeometryStyle.Setters.Add(
                    new Setter()
                    {
                        Property = System.Windows.Shapes.Shape.StrokeProperty,
                        Value = style.Stroke
                    });
                _mStaticGeometryStyle.Setters.Add(
                    new Setter()
                    {
                        Property = System.Windows.Shapes.Shape.StrokeThicknessProperty,
                        Value = 1d
                    });
            }
            return _mStaticGeometryStyle;
        }
        private Style SetDefaultTargetDecoratorStyle(NodeViewModel node)
        {
            Style _mStaticTargetDecoratorStyle = null;
            var info = node.Info as INodeInfo;
            if (node.Constraints.Contains(NodeConstraints.ThemeStyle) && info != null && this.Theme != null)
            {
                DiagramItemStyle style = this.Theme.GetNodeStyle(node.ThemeStyleId);
                _mStaticTargetDecoratorStyle = new Style()
                {
                    TargetType = typeof(System.Windows.Shapes.Shape),
                };
                _mStaticTargetDecoratorStyle.Setters.Add(
                    new Setter()
                    {
                        Property = System.Windows.Shapes.Shape.StrokeProperty,
                        Value = style.Stroke
                });
                _mStaticTargetDecoratorStyle.Setters.Add(
                    new Setter()
                    {
                        Property = System.Windows.Shapes.Shape.FillProperty,
                        Value = style.Stroke
                    });
                _mStaticTargetDecoratorStyle.Setters.Add(
                    new Setter()
                    {
                        Property = System.Windows.Shapes.Shape.StrokeThicknessProperty,
                        Value = 0d
                    });
                _mStaticTargetDecoratorStyle.Setters.Add(
                    new Setter()
                    {
                        Property = System.Windows.Shapes.Shape.StretchProperty,
                        Value = Stretch.Fill
                    });
                _mStaticTargetDecoratorStyle.Setters.Add(
                    new Setter()
                    {
                        Property = FrameworkElement.WidthProperty,
                        Value = 10d
                    });
                _mStaticTargetDecoratorStyle.Setters.Add(
                    new Setter()
                    {
                        Property = FrameworkElement.HeightProperty,
                        Value = 10d
                    });
            }
            return _mStaticTargetDecoratorStyle;
        }

        #endregion

    }
}
