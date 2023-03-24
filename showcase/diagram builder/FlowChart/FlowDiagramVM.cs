#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.diagrambuilder.wpf.Utility;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Theming;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace syncfusion.diagrambuilder.wpf.FlowChart
{
    public class FlowDiagramVM : DiagramViewModel
    {

        public ICommand ShowShapesPanelCommand { get; set; }

        public ICommand AddShapesCommand { get; set; }

        ShapePanel shapePanel = new ShapePanel();

        /// <summary>
        ///     To handle the shapes collections margin
        /// </summary>
        private Thickness _mPanelMargin;

        /// <summary>
        ///     To handle the collections of shapes visisbility
        /// </summary>
        private bool _mPanelVisibity;

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

        private double panelHorizontalOffset;
        private double panelVerticalOffset;
        private QuickCommandViewModel _PressedQuickCommand;

        public QuickCommandViewModel PressedQuickCommand
        {
            get
            {
                return _PressedQuickCommand;
            }

            set
            {
                if (value != null)
                {
                    _PressedQuickCommand = value;
                    this.OnPropertyChanged("PressedQuickCommand");
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlowChartDiagramVM"/> class.
        /// </summary>
        /// <param name="diagram">
        /// The diagram.
        /// </param>
        /// <summary>        
        /// Gets or sets value for Left Button visibility.
        /// </summary>
        public double PanelHorizontalOffset
        {
            get
            {
                return this.panelHorizontalOffset;
            }

            set
            {
                if (value != this.panelHorizontalOffset)
                {
                    this.panelHorizontalOffset = value;
                    this.OnPropertyChanged("PanelHorizontalOffset");
                }
            }
        }

        public double PanelVerticalOffset
        {
            get
            {
                return this.panelVerticalOffset;
            }

            set
            {
                if (value != this.panelVerticalOffset)
                {
                    this.panelVerticalOffset = value;
                    this.OnPropertyChanged("PanelVerticalOffset");
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
        public bool PanelVisibility
        {
            get
            {
                return this._mPanelVisibity;
            }

            set
            {
                this._mPanelVisibity = value;
                this.OnPropertyChanged("PanelVisibility");
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


        ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/Syncfusion.SfDiagram.WPF;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
        };       

        public FlowDiagramVM()
        {
            Nodes = new NodeCollection();
            Connectors = new ConnectorCollection();
            Groups = new GroupCollection();
            SnapSettings = new SnapSettings() { SnapToObject = SnapToObject.All, SnapConstraints = SnapConstraints.All };
            HorizontalRuler = new Syncfusion.UI.Xaml.Diagram.Controls.Ruler() { Orientation = System.Windows.Controls.Orientation.Horizontal };
            VerticalRuler = new Syncfusion.UI.Xaml.Diagram.Controls.Ruler() { Orientation = System.Windows.Controls.Orientation.Vertical };
            PageSettings = new PageSettings();
            PortVisibility = PortVisibility.MouseOverOnConnect;
            SelectedItems = new SelectorViewModel();
            ShowShapesPanelCommand = new DelegateCommand(OnShowShapesPanel);
            AddShapesCommand = new DelegateCommand(OnAddShapesCommand);
            ItemUnSelectedCommand = new Command(this.OnItemUnselectCommandExecute);
            DropCommand = new Command(this.OnSymbolDropCommandExecute);
            NodeChangedCommand = new Command(this.OnNodeChangedCommandExecute);
            ItemSelectedCommand = new Command(this.OnItemSelectionCommandExecute);
            ItemAddedCommand = new Command(this.ItemAddedCommandExcecute);
            ItemDeletingCommand = new DelegateCommand<object>(this.ItemDeletingCommandExecute);            
            shapePanel.DataContext = this;
            GetQuickCommand();
        }

        /// <summary>
        /// The find quick command visibilty method handles the visibility of the quickcommand.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private void FindQuickCommandVisibility(DiagramEventArgs param)
        {
            // right side intersecting bounds
            Rect nodeBounds = ((param.Item as NodeViewModel).Info as INodeInfo).Bounds;
            double right_x = nodeBounds.Right + 50;
            double right_y = (param.Item as NodeViewModel).OffsetY - 25;
            Rect rightintersectbounds = new Rect(right_x, right_y, 100, 50);

            // left side intersecting bounds
            double left_x = nodeBounds.Left - 150;
            double left_y = (param.Item as NodeViewModel).OffsetY - 25;
            Rect leftIntersectBounds = new Rect(left_x, left_y, 100, 50);

            // bottom side intersecting bounds
            double bottom_x = (param.Item as NodeViewModel).OffsetX - 50;
            double bottom_y = nodeBounds.Bottom + 50;
            Rect bottomIntersectbounds = new Rect(bottom_x, bottom_y, 100, 50);

            // top side intersecting bounds
            double top_x = (param.Item as NodeViewModel).OffsetX - 50;
            double top_y = nodeBounds.Top - 100;
            Rect topIntersectbounds = new Rect(top_x, top_y, 100, 50);

            ObservableCollection<NodeViewModel> nodesCollection = this.Nodes as ObservableCollection<NodeViewModel>;

            double Nodeangle = (param.Item as NodeViewModel).RotateAngle;

            if (nodesCollection != null)
            {
                if (Nodeangle >= 315 && Nodeangle <= 360 || Nodeangle >= 0 && Nodeangle <= 45)
                {
                    // To hide or show right side button
                    foreach (NodeViewModel node in nodesCollection)
                    {
                        SelectorViewModel sd = this.SelectedItems as SelectorViewModel;
                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(rightintersectbounds))
                        {
                            ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(0) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Connector;
                            break;
                        }

                        ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(0) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Node;
                    }

                    ;

                    // To hide or show left side button
                    foreach (NodeViewModel node in nodesCollection)
                    {
                        SelectorViewModel sd = this.SelectedItems as SelectorViewModel;

                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(leftIntersectBounds))
                        {
                            ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(1) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Connector;
                            break;
                        }

                        ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(1) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Node;
                    }

                    ;

                    // To hide or show top side button
                    foreach (NodeViewModel node in nodesCollection)
                    {
                        SelectorViewModel sd = this.SelectedItems as SelectorViewModel;

                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(topIntersectbounds))
                        {
                            ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(2) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Connector;
                            break;
                        }

                        ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(2) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Node;
                    }

                    ;

                    // To hide or show bottom side button
                    foreach (NodeViewModel node in nodesCollection)
                    {
                        SelectorViewModel sd = this.SelectedItems as SelectorViewModel;

                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(bottomIntersectbounds))
                        {
                            ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(3) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Connector;
                            break;
                        }

                        ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(3) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Node;
                    }

                    ;
                }
                else if (Nodeangle >= 45 && Nodeangle <= 135)
                {
                    // To hide or show right side button
                    foreach (NodeViewModel node in nodesCollection)
                    {
                        SelectorViewModel sd = this.SelectedItems as SelectorViewModel;
                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(rightintersectbounds))
                        {
                            ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(2) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Connector;
                            break;
                        }

                        ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(2) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Node;
                    }

                    ;

                    // To hide or show left side button
                    foreach (NodeViewModel node in nodesCollection)
                    {
                        SelectorViewModel sd = this.SelectedItems as SelectorViewModel;

                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(leftIntersectBounds))
                        {
                            ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(3) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Connector;
                            break;
                        }

                        ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(3) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Node;
                    }

                    ;

                    // To hide or show top side button
                    foreach (NodeViewModel node in nodesCollection)
                    {
                        SelectorViewModel sd = this.SelectedItems as SelectorViewModel;

                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(topIntersectbounds))
                        {
                            ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(1) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Connector;
                            break;
                        }

                        ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(1) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Node;
                    }

                    ;

                    // To hide or show bottom side button
                    foreach (NodeViewModel node in nodesCollection)
                    {
                        SelectorViewModel sd = this.SelectedItems as SelectorViewModel;

                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(bottomIntersectbounds))
                        {
                            ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(0) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Connector;
                            break;
                        }

                        ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(0) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Node;
                    }

                    ;
                }
                else if (Nodeangle >= 135 && Nodeangle <= 225)
                {
                    // To hide or show right side button
                    foreach (NodeViewModel node in nodesCollection)
                    {
                        SelectorViewModel sd = this.SelectedItems as SelectorViewModel;
                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(rightintersectbounds))
                        {
                            ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(1) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Connector;
                            break;
                        }

                        ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(1) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Node;
                    }

                    ;

                    // To hide or show left side button
                    foreach (NodeViewModel node in nodesCollection)
                    {
                        SelectorViewModel sd = this.SelectedItems as SelectorViewModel;

                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(leftIntersectBounds))
                        {
                            ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(0) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Connector;
                            break;
                        }

                        ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(0) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Node;
                    }

                    ;

                    // To hide or show top side button
                    foreach (NodeViewModel node in nodesCollection)
                    {
                        SelectorViewModel sd = this.SelectedItems as SelectorViewModel;

                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(topIntersectbounds))
                        {
                            ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(3) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Connector;
                            break;
                        }

                        ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(3) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Node;
                    }

                    ;

                    // To hide or show bottom side button
                    foreach (NodeViewModel node in nodesCollection)
                    {
                        SelectorViewModel sd = this.SelectedItems as SelectorViewModel;

                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(bottomIntersectbounds))
                        {
                            ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(2) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Connector;
                            break;
                        }

                        ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(2) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Node;
                    }

                    ;
                }
                else if (Nodeangle >= 225 && Nodeangle <= 325)
                {
                    // To hide or show right side button
                    foreach (NodeViewModel node in nodesCollection)
                    {
                        SelectorViewModel sd = this.SelectedItems as SelectorViewModel;
                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(rightintersectbounds))
                        {
                            ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(3) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Connector;
                            break;
                        }

                        ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(3) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Node;
                    }

                    ;

                    // To hide or show left side button
                    foreach (NodeViewModel node in nodesCollection)
                    {
                        SelectorViewModel sd = this.SelectedItems as SelectorViewModel;

                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(leftIntersectBounds))
                        {
                            ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(2) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Connector;
                            break;
                        }

                        ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(2) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Node;
                    }

                    ;

                    // To hide or show top side button
                    foreach (NodeViewModel node in nodesCollection)
                    {
                        SelectorViewModel sd = this.SelectedItems as SelectorViewModel;

                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(topIntersectbounds))
                        {
                            ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(0) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Connector;
                            break;
                        }

                        ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(0) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Node;
                    }

                    ;

                    // To hide or show bottom side button
                    foreach (NodeViewModel node in nodesCollection)
                    {
                        SelectorViewModel sd = this.SelectedItems as SelectorViewModel;

                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(bottomIntersectbounds))
                        {
                            ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(1) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Connector;
                            break;
                        }

                        ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(1) as QuickCommandViewModel).VisibilityMode  = VisibilityMode.Node;
                    }

                    ;
                }
            }
        }

        /// <summary>
        /// This command executes when an item gets added.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private void ItemAddedCommandExcecute(object param)
        {
            if (param is ItemAddedEventArgs && (param as ItemAddedEventArgs).Item is NodeViewModel)
            {
                ((param as ItemAddedEventArgs).Item as NodeViewModel).Constraints |= NodeConstraints.AllowDrop;
            }
        }

        /// <summary>
        /// This command executes when an item gets deleted.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private void ItemDeletingCommandExecute(object param)
        {
            int val = ((this.SelectedItems as SelectorViewModel).Connectors as IEnumerable<object>).Count();
            if (val == 0)
            {
                NodeViewModel deletingNode = (param as ItemDeletingEventArgs).Item as NodeViewModel;

                if ((param as ItemDeletingEventArgs).Item is NodeViewModel
                    && (deletingNode.Info as INodeInfo).InConnectors != null
                    && (deletingNode.Info as INodeInfo).OutConnectors != null)
                {
                    if ((deletingNode.Info as INodeInfo).InConnectors.Count() > 1
                        && (deletingNode.Info as INodeInfo).OutConnectors.Count() > 1
                        || (deletingNode.Info as INodeInfo).InConnectors.Count() == 1
                        && (deletingNode.Info as INodeInfo).OutConnectors.Count() == 0
                        || (deletingNode.Info as INodeInfo).InConnectors.Count() == 0
                        && (deletingNode.Info as INodeInfo).OutConnectors.Count() == 1
                        || (deletingNode.Info as INodeInfo).InConnectors.Count() == 0
                        && (deletingNode.Info as INodeInfo).OutConnectors.Count() > 1
                        || (deletingNode.Info as INodeInfo).InConnectors.Count() > 1
                        && (deletingNode.Info as INodeInfo).OutConnectors.Count() == 0)
                    {
                        (param as ItemDeletingEventArgs).DeleteDependentConnector = true;
                    }
                    else
                    {
                        (param as ItemDeletingEventArgs).DeleteDependentConnector = false;

                        if ((deletingNode.Info as INodeInfo).InConnectors.Count() == 1
                            && (deletingNode.Info as INodeInfo).OutConnectors.Count() == 1)
                        {
                            NodeViewModel newtargetNode = null;
                            ConnectorViewModel outconnector =
                                (deletingNode.Info as INodeInfo).OutConnectors.ToList()[0] as ConnectorViewModel;
                            newtargetNode = outconnector.TargetNode as NodeViewModel;
                            (this.Connectors as ConnectorCollection).Remove(outconnector);

                            ConnectorViewModel inconnector =
                                (deletingNode.Info as INodeInfo).InConnectors.ToList()[0] as ConnectorViewModel;
                            inconnector.TargetNode = newtargetNode;

                            if (inconnector.SourceNode == inconnector.TargetNode)
                            {
                                (this.Connectors as ConnectorCollection).Remove(inconnector);
                            }
                        }
                        else if ((deletingNode.Info as INodeInfo).InConnectors.Count() > 1
                                 && (deletingNode.Info as INodeInfo).OutConnectors.Count() == 1)
                        {
                            NodeViewModel newtargetNode = null;
                            ConnectorViewModel outconnector =
                                (deletingNode.Info as INodeInfo).OutConnectors.ToList()[0] as ConnectorViewModel;
                            newtargetNode = outconnector.TargetNode as NodeViewModel;
                            (this.Connectors as ConnectorCollection).Remove(outconnector);

                            IEnumerable<IConnector> inConnectorsCollction =
                                (deletingNode.Info as INodeInfo).InConnectors;
                            foreach (ConnectorViewModel connector in inConnectorsCollction.ToList())
                            {
                                connector.TargetNode = newtargetNode;
                            }
                        }
                        else if ((deletingNode.Info as INodeInfo).InConnectors.Count() == 1
                                 && (deletingNode.Info as INodeInfo).OutConnectors.Count() > 1)
                        {
                            NodeViewModel newtargetNode = null;
                            ConnectorViewModel inconnector =
                                (deletingNode.Info as INodeInfo).InConnectors.ToList()[0] as ConnectorViewModel;
                            newtargetNode = inconnector.SourceNode as NodeViewModel;
                            (this.Connectors as ConnectorCollection).Remove(inconnector);

                            IEnumerable<IConnector> outConnectorsCollection =
                                (deletingNode.Info as INodeInfo).OutConnectors;
                            foreach (ConnectorViewModel connector in outConnectorsCollection.ToList())
                            {
                                connector.SourceNode = newtargetNode;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// To make shapes collection panel visible when item is getting selection
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private void OnItemSelectionCommandExecute(object param)
        {
            if ((param as ItemSelectedEventArgs).Item is INode)
            {
                if ((param as ItemSelectedEventArgs).InteractionState == InteractionState.Completed)
                {
                    int val = ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>).Count();
                    if (val == 1)
                    {
                        if ((param as DiagramEventArgs).Item is NodeViewModel)
                        {
                            this.FindQuickCommandVisibility(param as DiagramEventArgs);
                        }
                    }
                    else if (val > 1)
                    {
                        DisableAllQuickCommand();
                    }
                }
            }
            else
            {
                DisableAllConnectorQuickCommand();
            }
        }

        private void DisableAllConnectorQuickCommand()
        {
            SelectorViewModel sd = this.SelectedItems as SelectorViewModel;

            ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(1) as QuickCommandViewModel).VisibilityMode = VisibilityMode.Node;
            ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(0) as QuickCommandViewModel).VisibilityMode = VisibilityMode.Node;
            ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(2) as QuickCommandViewModel).VisibilityMode = VisibilityMode.Node;
            ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(3) as QuickCommandViewModel).VisibilityMode = VisibilityMode.Node;
        }

        private void DisableAllQuickCommand()
        {
            SelectorViewModel sd = this.SelectedItems as SelectorViewModel;

            ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(1) as QuickCommandViewModel).VisibilityMode = VisibilityMode.Connector;
            ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(0) as QuickCommandViewModel).VisibilityMode = VisibilityMode.Connector;
            ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(2) as QuickCommandViewModel).VisibilityMode = VisibilityMode.Connector;
            ((sd.Commands as ObservableCollection<QuickCommandViewModel>).ElementAt(3) as QuickCommandViewModel).VisibilityMode = VisibilityMode.Connector;
        }

        /// <summary>
        /// To make shapes collection panel invisible when item is getting unselection
        /// </summary>
        /// <param name="param">
        /// </param>
        private void OnItemUnselectCommandExecute(object param)
        {
            if ((param as DiagramEventArgs).Item is NodeViewModel)
            {
                this.PanelVisibility = false;
            }
        }

        /// <summary>
        /// To add connectors when node is dragging and on diagram page and placed over Connector
        /// </summary>
        /// <param name="param">
        /// value of NodeChangedEventArgs
        /// </param>
        private void OnNodeChangedCommandExecute(object param)
        {
            if ((param as DiagramEventArgs).Item is NodeViewModel && ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>).Count == 1)
            {
                this.FindQuickCommandVisibility(param as DiagramEventArgs);
            }

            // Enables the allow drop constraints when node/Connector intersectes.
            ObservableCollection<ConnectorViewModel> ConnectorsCollections =
                this.Connectors as ObservableCollection<ConnectorViewModel>;
            ObservableCollection<NodeViewModel> NodesCollections = this.Nodes as ObservableCollection<NodeViewModel>;

            // To split and add the connectors when exisiting node is dropped on connector.
            if ((param as ChangeEventArgs<object, NodeChangedEventArgs>).NewValue.InteractionState
                == NodeChangedInteractionState.Dragged)
            {
                Rect nodeBounds = new Rect(0, 0, 0, 0);
                if ((((param as DiagramEventArgs).Item as NodeViewModel).Info as INodeInfo).InOutConnectors == null)
                {
                    nodeBounds = (((param as DiagramEventArgs).Item as NodeViewModel).Info as INodeInfo).Bounds;
                    ObservableCollection<ConnectorViewModel> ConnectorCollection =
                        this.Connectors as ObservableCollection<ConnectorViewModel>;
                    if (ConnectorCollection.Count > 0)
                    {
                        foreach (ConnectorViewModel connector in ConnectorCollection)
                        {
                            Rect Connectorbounds = (connector.Info as IConnectorInfo).Bounds;
                            if (nodeBounds.IntersectsWith(Connectorbounds))
                            {
                                ConnectorViewModel newConnector = new ConnectorViewModel
                                {
                                    SourceNode = (param as DiagramEventArgs).Item,
                                    TargetNode = connector.TargetNode
                                };
                                connector.TargetNode = (param as DiagramEventArgs).Item;
                                (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(newConnector);
                                break;
                            }
                        }
                    }
                }
            }            

            else if((param as ChangeEventArgs<object, NodeChangedEventArgs>).NewValue.InteractionState == NodeChangedInteractionState.Dragging 
                || (param as ChangeEventArgs<object, NodeChangedEventArgs>).NewValue.InteractionState == NodeChangedInteractionState.Resizing 
                || (param as ChangeEventArgs<object, NodeChangedEventArgs>).NewValue.InteractionState == NodeChangedInteractionState.Rotating
                || (param as ChangeEventArgs<object, NodeChangedEventArgs>).NewValue.InteractionState == NodeChangedInteractionState.Started)
            {
                this.PanelVisibility = false;
            }
        }

        /// <summary>
        /// Split and adding the connector when symbol is dragged form Stencil and dropped over connector
        /// </summary>
        /// <param name="param">
        /// </param>
        private void OnSymbolDropCommandExecute(object param)
        {
            IEnumerable<object> targetCollection = (param as ItemDropEventArgs).Target as IEnumerable<object>;
            if (targetCollection != null)
            {
                ConnectorViewModel newConnector = new ConnectorViewModel { SourceNode = (param as ItemDropEventArgs).Source };
                foreach (object target in targetCollection)
                {
                    if (target is IConnector)
                    {
                        if ((target as ConnectorViewModel).TargetNode != null)
                        {
                            newConnector.TargetNode = (target as ConnectorViewModel).TargetNode;
                            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(newConnector);
                        }

                        (target as ConnectorViewModel).TargetNode = (param as ItemDropEventArgs).Source;
                        return;
                    }
                }
            }
        }

        protected override void OnPropertyChanged(string name)
        {
            if (name == "RotateAngle")
            {
                this.PanelAngle = 360 - (this.SelectedItems as SelectorViewModel).RotateAngle;
                this.PanelVisibility = false;
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
            ConnectorViewModel connector = new ConnectorViewModel();

            ObservableCollection<NodeViewModel> nodescollection = (this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<NodeViewModel>;
            NodeViewModel selectedNode = ((this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).First() as NodeViewModel;
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

            NodeViewModel node = new NodeViewModel
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
                                         new NodePortViewModel
                                             {
                                                 NodeOffsetX = 0,
                                                 NodeOffsetY = 0.5,
                                                 Shape = resourceDictionary["Rectangle"],
                                                 ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                             },
                                         new NodePortViewModel
                                             {
                                                 NodeOffsetX = 0.5,
                                                 NodeOffsetY = 0,
                                                 Shape = resourceDictionary["Rectangle"],
                                                 ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                             },
                                         new NodePortViewModel
                                             {
                                                 NodeOffsetX = 1,
                                                 NodeOffsetY = 0.5,
                                                 Shape = resourceDictionary["Rectangle"],
                                                 ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                             },
                                         new NodePortViewModel
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
                                         new NodePortViewModel
                                             {
                                                 NodeOffsetX = 0.1,
                                                 NodeOffsetY = 0.5,
                                                 Shape = resourceDictionary["Rectangle"],
                                                 ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                             },
                                         new NodePortViewModel
                                             {
                                                 NodeOffsetX = 0.5,
                                                 NodeOffsetY = 0,
                                                 Shape = resourceDictionary["Rectangle"],
                                                 ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                             },
                                         new NodePortViewModel
                                             {
                                                 NodeOffsetX = 0.9,
                                                 NodeOffsetY = 0.5,
                                                 Shape = resourceDictionary["Rectangle"],
                                                 ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                             },
                                         new NodePortViewModel
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
                                         new NodePortViewModel
                                             {
                                                 NodeOffsetX = 0,
                                                 NodeOffsetY = 0.5,
                                                 Shape = resourceDictionary["Rectangle"],
                                                 ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                             },
                                         new NodePortViewModel
                                             {
                                                 NodeOffsetX = 0.5,
                                                 NodeOffsetY = 0,
                                                 Shape = resourceDictionary["Rectangle"],
                                                 ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                             },
                                         new NodePortViewModel
                                             {
                                                 NodeOffsetX = 1,
                                                 NodeOffsetY = 0.5,
                                                 Shape = resourceDictionary["Rectangle"],
                                                 ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                             },
                                         new NodePortViewModel
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
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0,
                                             NodeOffsetY = 0.5,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 0,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0.95,
                                             NodeOffsetY = 0.5,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 1,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
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
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 0,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 0.5,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
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
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 0,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0,
                                             NodeOffsetY = 0.5,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 1,
                                             NodeOffsetY = 0.5,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 1,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0.15,
                                             NodeOffsetY = 0.15,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0.85,
                                             NodeOffsetY = 0.15,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0.15,
                                             NodeOffsetY = 0.85,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
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
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 0,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 1,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0.25,
                                             NodeOffsetY = 0.5,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
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
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 0,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 1,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0,
                                             NodeOffsetY = 0.7,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
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
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0,
                                             NodeOffsetY = 0.5,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 0,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0.9,
                                             NodeOffsetY = 0.5,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
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
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0.1,
                                             NodeOffsetY = 0.5,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 0,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0.9,
                                             NodeOffsetY = 0.5,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
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
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0,
                                             NodeOffsetY = 0.5,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 0.5,
                                             NodeOffsetY = 0.2,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
                                         {
                                             NodeOffsetX = 1,
                                             NodeOffsetY = 0.5,
                                             Shape = resourceDictionary["Rectangle"],
                                             ShapeStyle = resourceDictionary["portShapeStyle"] as Style
                                         },
                                     new NodePortViewModel
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
            (this.Nodes as ObservableCollection<NodeViewModel>).Add(node);
            connector.TargetNode = node;
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector);
            node.IsSelected = true;
        }

        private void OnShowShapesPanel(object param)
        {
            bool MenuAlignment = SystemParameters.MenuDropAlignment;

            if(PanelVisibility)
            {
                PanelVisibility = false;
            }

            if((param as QuickCommandViewModel).OffsetX == 1 && (param as QuickCommandViewModel).OffsetY == 0.5)
            {
                this.panelDirection = "Right";
            }

            else if ((param as QuickCommandViewModel).OffsetX == 0 && (param as QuickCommandViewModel).OffsetY == 0.5)
            {
                this.panelDirection = "Left";
            }

            else if ((param as QuickCommandViewModel).OffsetX == 0.5 && (param as QuickCommandViewModel).OffsetY == 0)
            {
                this.panelDirection = "Top";
            }

            else if ((param as QuickCommandViewModel).OffsetX == 0.5 && (param as QuickCommandViewModel).OffsetY == 1)
            {
                this.panelDirection = "Bottom";
            }

            this.PanelVisibility = true;
            this.PressedQuickCommand = param as QuickCommandViewModel;
            if ((this.SelectedItems as SelectorViewModel).Nodes != null && ((this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).Count() > 0)
            {
                NodeViewModel node = ((this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).First() as NodeViewModel;
                if (node != null)
                {
                    Rect selectedNodeBounds = (node.Info as INodeInfo).Bounds;
                    if (this.PanelDirection == "Right")
                    {
                        this.PanelHorizontalOffset = MenuAlignment ? 130 : 20;
                        this.PanelVerticalOffset = -75;
                    }
                    else if (this.PanelDirection == "Left")
                    {
                        this.PanelHorizontalOffset = MenuAlignment ? -20 : -130;
                        this.PanelVerticalOffset = -75;
                    }
                    else if (this.PanelDirection == "Top")
                    {
                        this.PanelHorizontalOffset = MenuAlignment ? 55 : -55;
                        this.PanelVerticalOffset = -170;
                    }
                    else if (this.PanelDirection == "Bottom")
                    {
                        this.PanelHorizontalOffset = MenuAlignment ? 55 : -55;
                        this.PanelVerticalOffset = 5;
                    }
                }
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
                //this.PanelMargin = new Thickness(-145, 0, 0, 0);
                
                this.PanelHorizontalAlignment = HorizontalAlignment.Left;
                this.PanelVerticalAlignment = VerticalAlignment.Center;
            }
            else if (param.ToString().Equals("Right"))
            {
                //this.PanelMargin = new Thickness(172, 0, 0, 0);
                this.PanelHorizontalAlignment = HorizontalAlignment.Right;
                this.PanelVerticalAlignment = VerticalAlignment.Center;
            }
            else if (param.ToString().Equals("Bottom"))
            {
                //this.PanelMargin = new Thickness(0, 180, 0, 0);
                this.PanelHorizontalAlignment = HorizontalAlignment.Center;
                this.PanelVerticalAlignment = VerticalAlignment.Bottom;
            }
            else if (param.ToString().Equals("Top"))
            {
                //this.PanelMargin = new Thickness(0, -172, 0, 0);
                this.PanelHorizontalAlignment = HorizontalAlignment.Center;
                this.PanelVerticalAlignment = VerticalAlignment.Top;
            }
        }

        private void GetQuickCommand()
        {
            ResourceDictionary QuickCommandResources = new ResourceDictionary()
            {
                Source = new Uri(@"/syncfusion.diagrambuilder.wpf;component/FlowChart/QuickCommandTemplate.xaml", UriKind.RelativeOrAbsolute)
            };

            QuickCommandViewModel RightQuickCommand = new QuickCommandViewModel()
            {
                OffsetX = 1,
                OffsetY = 0.5,
                Command = ShowShapesPanelCommand,
                Shape = resourceDictionary["Ellipse"],
                ShapeStyle = QuickCommandResources["QuickCommandStyle"] as Style,
                ContentTemplate = QuickCommandResources["RightQuickCommandTemplate"] as DataTemplate,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(25, 0, 0, 0),
            };

            RightQuickCommand.CommandParameter = RightQuickCommand;

            QuickCommandViewModel LeftQuickCommand = new QuickCommandViewModel()
            {
                OffsetX = 0,
                OffsetY = 0.5,
                Command = ShowShapesPanelCommand,
                Shape = resourceDictionary["Ellipse"],
                ShapeStyle = QuickCommandResources["QuickCommandStyle"] as Style,
                ContentTemplate = QuickCommandResources["LeftQuickCommandTemplate"] as DataTemplate,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 25, 0),
            };

            LeftQuickCommand.CommandParameter = LeftQuickCommand;

            QuickCommandViewModel TopQuickCommand = new QuickCommandViewModel()
            {
                OffsetX = 0.5,
                OffsetY = 0,
                Command = ShowShapesPanelCommand,
                Shape = resourceDictionary["Ellipse"],
                ShapeStyle = QuickCommandResources["QuickCommandStyle"] as Style,
                ContentTemplate = QuickCommandResources["TopQuickCommandTemplate"] as DataTemplate,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 0, 75),
            };

            TopQuickCommand.CommandParameter = TopQuickCommand;

            QuickCommandViewModel BottomQuickCommand = new QuickCommandViewModel()
            {
                OffsetX = 0.5,
                OffsetY = 1,
                Command = ShowShapesPanelCommand,
                Shape = resourceDictionary["Ellipse"],
                ShapeStyle = QuickCommandResources["QuickCommandStyle"] as Style,
                ContentTemplate = QuickCommandResources["BottomQuickCommandTemplate"] as DataTemplate,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 25, 0, 0),
            };

            BottomQuickCommand.CommandParameter = BottomQuickCommand;

            (SelectedItems as SelectorViewModel).Commands = new ObservableCollection<QuickCommandViewModel>()
            {                
                RightQuickCommand,
                LeftQuickCommand,
                TopQuickCommand,
                BottomQuickCommand,
            };
        }
    }
}
