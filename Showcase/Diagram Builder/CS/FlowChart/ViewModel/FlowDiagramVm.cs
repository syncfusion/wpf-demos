// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FlowDiagramVm.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the diagram view model class for flowchart diagram.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FlowChart.ViewModel
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    using DiagramBuilder;
    using DiagramBuilder.Utility;
    using DiagramBuilder.ViewModel;

    using Syncfusion.UI.Xaml.Diagram;
    using Syncfusion.UI.Xaml.Diagram.Controls;
    using Syncfusion.Windows.Shared;

    /// <summary>
    ///     Represents the diagram view model class for flowchart diagram.
    /// </summary>
    public class FlowDiagramVm : DiagramVM
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlowDiagramVm"/> class.
        /// </summary>
        /// <param name="file">
        /// The file.
        /// </param>
        /// <param name="isValidXml">
        /// The is valid xml.
        /// </param>
        public FlowDiagramVm(string file, bool isValidXml)
            : base(file, isValidXml)
        {
            this.DiagramType = DiagramType.FlowChart;
            this.SelectedItems = new FlowChartSelectorVm(this);
            this.ItemUnSelectedCommand = new Command(this.OnItemUnselectCommandExecute);
            this.DropCommand = new Command(this.OnSymbolDropCommandExecute);
            this.NodeChangedCommand = new Command(this.OnNodeChangedCommandExecute);
            this.VerticalRuler = new Ruler { Orientation = Orientation.Vertical };
            this.HorizontalRuler = new Ruler { Orientation = Orientation.Horizontal };
            this.ItemSelectedCommand = new Command(this.OnItemSelectionCommandExecute);
            this.SymbolDroppingCommand = new Command(this.SymbolsDroppingCommandExecute);
            this.ItemAddedCommand = new Command(this.ItemAddedCommandExcecute);
            this.ItemDeletingCommand = new DelegateCommand<object>(this.ItemDeletingCommandExecute);
            this.Constraints |= GraphConstraints.Undoable;
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
            Rect nodeBounds = ((param.Item as NodeVM).Info as INodeInfo).Bounds;
            double right_x = nodeBounds.Right + 50;
            double right_y = (param.Item as NodeVM).OffsetY - 25;
            Rect rightintersectbounds = new Rect(right_x, right_y, 100, 50);

            // left side intersecting bounds
            double left_x = nodeBounds.Left - 150;
            double left_y = (param.Item as NodeVM).OffsetY - 25;
            Rect leftIntersectBounds = new Rect(left_x, left_y, 100, 50);

            // bottom side intersecting bounds
            double bottom_x = (param.Item as NodeVM).OffsetX - 50;
            double bottom_y = nodeBounds.Bottom + 50;
            Rect bottomIntersectbounds = new Rect(bottom_x, bottom_y, 100, 50);

            // top side intersecting bounds
            double top_x = (param.Item as NodeVM).OffsetX - 50;
            double top_y = nodeBounds.Top - 100;
            Rect topIntersectbounds = new Rect(top_x, top_y, 100, 50);

            ObservableCollection<NodeVM> nodesCollection = this.Nodes as ObservableCollection<NodeVM>;

            double Nodeangle = (param.Item as NodeVM).RotateAngle;

            if (nodesCollection != null)
            {
                if (Nodeangle >= 315 && Nodeangle <= 360 || Nodeangle >= 0 && Nodeangle <= 45)
                {
                    // To hide or show right side button
                    foreach (NodeVM node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;
                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(rightintersectbounds))
                        {
                            sd.RightButtonVisibility = Visibility.Hidden;
                            break;
                        }

                        sd.RightButtonVisibility = Visibility.Visible;
                    }

                    ;

                    // To hide or show left side button
                    foreach (NodeVM node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;

                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(leftIntersectBounds))
                        {
                            sd.LeftButtonVisibility = Visibility.Hidden;
                            break;
                        }

                        sd.LeftButtonVisibility = Visibility.Visible;
                    }

                    ;

                    // To hide or show top side button
                    foreach (NodeVM node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;

                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(topIntersectbounds))
                        {
                            sd.TopButtonVisibility = Visibility.Hidden;
                            break;
                        }

                        sd.TopButtonVisibility = Visibility.Visible;
                    }

                    ;

                    // To hide or show bottom side button
                    foreach (NodeVM node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;

                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(bottomIntersectbounds))
                        {
                            sd.BottomButtonVisibility = Visibility.Hidden;
                            break;
                        }

                        sd.BottomButtonVisibility = Visibility.Visible;
                    }

                    ;
                }
                else if (Nodeangle >= 45 && Nodeangle <= 135)
                {
                    // To hide or show right side button
                    foreach (NodeVM node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;
                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(rightintersectbounds))
                        {
                            sd.TopButtonVisibility = Visibility.Hidden;
                            break;
                        }

                        sd.TopButtonVisibility = Visibility.Visible;
                    }

                    ;

                    // To hide or show left side button
                    foreach (NodeVM node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;

                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(leftIntersectBounds))
                        {
                            sd.BottomButtonVisibility = Visibility.Hidden;
                            break;
                        }

                        sd.BottomButtonVisibility = Visibility.Visible;
                    }

                    ;

                    // To hide or show top side button
                    foreach (NodeVM node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;

                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(topIntersectbounds))
                        {
                            sd.LeftButtonVisibility = Visibility.Hidden;
                            break;
                        }

                        sd.LeftButtonVisibility = Visibility.Visible;
                    }

                    ;

                    // To hide or show bottom side button
                    foreach (NodeVM node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;

                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(bottomIntersectbounds))
                        {
                            sd.RightButtonVisibility = Visibility.Hidden;
                            break;
                        }

                        sd.RightButtonVisibility = Visibility.Visible;
                    }

                    ;
                }
                else if (Nodeangle >= 135 && Nodeangle <= 225)
                {
                    // To hide or show right side button
                    foreach (NodeVM node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;
                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(rightintersectbounds))
                        {
                            sd.LeftButtonVisibility = Visibility.Hidden;
                            break;
                        }

                        sd.LeftButtonVisibility = Visibility.Visible;
                    }

                    ;

                    // To hide or show left side button
                    foreach (NodeVM node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;

                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(leftIntersectBounds))
                        {
                            sd.RightButtonVisibility = Visibility.Hidden;
                            break;
                        }

                        sd.RightButtonVisibility = Visibility.Visible;
                    }

                    ;

                    // To hide or show top side button
                    foreach (NodeVM node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;

                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(topIntersectbounds))
                        {
                            sd.BottomButtonVisibility = Visibility.Hidden;
                            break;
                        }

                        sd.BottomButtonVisibility = Visibility.Visible;
                    }

                    ;

                    // To hide or show bottom side button
                    foreach (NodeVM node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;

                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(bottomIntersectbounds))
                        {
                            sd.TopButtonVisibility = Visibility.Hidden;
                            break;
                        }

                        sd.TopButtonVisibility = Visibility.Visible;
                    }

                    ;
                }
                else if (Nodeangle >= 225 && Nodeangle <= 325)
                {
                    // To hide or show right side button
                    foreach (NodeVM node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;
                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(rightintersectbounds))
                        {
                            sd.BottomButtonVisibility = Visibility.Hidden;
                            break;
                        }

                        sd.BottomButtonVisibility = Visibility.Visible;
                    }

                    ;

                    // To hide or show left side button
                    foreach (NodeVM node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;

                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(leftIntersectBounds))
                        {
                            sd.TopButtonVisibility = Visibility.Hidden;
                            break;
                        }

                        sd.TopButtonVisibility = Visibility.Visible;
                    }

                    ;

                    // To hide or show top side button
                    foreach (NodeVM node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;

                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(topIntersectbounds))
                        {
                            sd.RightButtonVisibility = Visibility.Hidden;
                            break;
                        }

                        sd.RightButtonVisibility = Visibility.Visible;
                    }

                    ;

                    // To hide or show bottom side button
                    foreach (NodeVM node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;

                        if ((node.Info as INodeInfo).Bounds.IntersectsWith(bottomIntersectbounds))
                        {
                            sd.LeftButtonVisibility = Visibility.Hidden;
                            break;
                        }

                        sd.LeftButtonVisibility = Visibility.Visible;
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
            if (param is ItemAddedEventArgs && (param as ItemAddedEventArgs).Item is NodeVM)
            {
                ((param as ItemAddedEventArgs).Item as NodeVM).Constraints |= NodeConstraints.AllowDrop;
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
            int val = ((this.SelectedItems as FlowChartSelectorVm).Connectors as IEnumerable<object>).Count();
            if (val == 0)
            {
                NodeVM deletingNode = (param as ItemDeletingEventArgs).Item as NodeVM;

                if ((param as ItemDeletingEventArgs).Item is NodeVM
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
                            NodeVM newtargetNode = null;
                            ConnectorVM outconnector =
                                (deletingNode.Info as INodeInfo).OutConnectors.ToList()[0] as ConnectorVM;
                            newtargetNode = outconnector.TargetNode as NodeVM;
                            this.ConnectorCollection.Remove(outconnector);

                            ConnectorVM inconnector =
                                (deletingNode.Info as INodeInfo).InConnectors.ToList()[0] as ConnectorVM;
                            inconnector.TargetNode = newtargetNode;

                            if(inconnector.SourceNode==inconnector.TargetNode)
                            {
                                this.ConnectorCollection.Remove(inconnector);
                            }
                        }
                        else if ((deletingNode.Info as INodeInfo).InConnectors.Count() > 1
                                 && (deletingNode.Info as INodeInfo).OutConnectors.Count() == 1)
                        {
                            NodeVM newtargetNode = null;
                            ConnectorVM outconnector =
                                (deletingNode.Info as INodeInfo).OutConnectors.ToList()[0] as ConnectorVM;
                            newtargetNode = outconnector.TargetNode as NodeVM;
                            this.ConnectorCollection.Remove(outconnector);

                            IEnumerable<IConnector> inConnectorsCollction =
                                (deletingNode.Info as INodeInfo).InConnectors;
                            foreach (ConnectorVM connector in inConnectorsCollction.ToList())
                            {
                                connector.TargetNode = newtargetNode;
                            }
                        }
                        else if ((deletingNode.Info as INodeInfo).InConnectors.Count() == 1
                                 && (deletingNode.Info as INodeInfo).OutConnectors.Count() > 1)
                        {
                            NodeVM newtargetNode = null;
                            ConnectorVM inconnector =
                                (deletingNode.Info as INodeInfo).InConnectors.ToList()[0] as ConnectorVM;
                            newtargetNode = inconnector.SourceNode as NodeVM;
                            this.ConnectorCollection.Remove(inconnector);

                            IEnumerable<IConnector> outConnectorsCollection =
                                (deletingNode.Info as INodeInfo).OutConnectors;
                            foreach (ConnectorVM connector in outConnectorsCollection.ToList())
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
            int val = ((this.SelectedItems as FlowChartSelectorVm).Nodes as ObservableCollection<object>).Count();
            if (val == 1)
            {
                if ((param as DiagramEventArgs).Item is NodeVM)
                {
                    this.FindQuickCommandVisibility(param as DiagramEventArgs);
                }
            }
            else if (val > 1)
            {
                FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;
                sd.LeftButtonVisibility = Visibility.Hidden;
                sd.RightButtonVisibility = Visibility.Hidden;
                sd.TopButtonVisibility = Visibility.Hidden;
                sd.BottomButtonVisibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// To make shapes collection panel invisible when item is getting unselection
        /// </summary>
        /// <param name="param">
        /// </param>
        private void OnItemUnselectCommandExecute(object param)
        {
            if ((param as DiagramEventArgs).Item is NodeVM)
            {
                FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;
                sd.PanelVisibility = Visibility.Collapsed;
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
            if ((param as DiagramEventArgs).Item is NodeVM)
            {
                this.FindQuickCommandVisibility(param as DiagramEventArgs);
            }

            // Enables the allow drop constraints when node/Connector intersectes.
            ObservableCollection<ConnectorVM> ConnectorsCollections =
                this.Connectors as ObservableCollection<ConnectorVM>;
            ObservableCollection<NodeVM> NodesCollections = this.Nodes as ObservableCollection<NodeVM>;

            // To split and add the connectors when exisiting node is dropped on connector.
            if ((param as ChangeEventArgs<object, NodeChangedEventArgs>).NewValue.InteractionState
                == NodeChangedInteractionState.Dragged)
            {
                Rect nodeBounds = new Rect(0, 0, 0, 0);
                if ((((param as DiagramEventArgs).Item as NodeVM).Info as INodeInfo).InOutConnectors == null)
                {
                    nodeBounds = (((param as DiagramEventArgs).Item as NodeVM).Info as INodeInfo).Bounds;
                    ObservableCollection<ConnectorVM> ConnectorCollection =
                        this.Connectors as ObservableCollection<ConnectorVM>;
                    if (ConnectorCollection.Count > 0)
                    {
                        foreach (ConnectorVM connector in ConnectorCollection)
                        {
                            Rect Connectorbounds = (connector.Info as IConnectorInfo).Bounds;
                            if (nodeBounds.IntersectsWith(Connectorbounds))
                            {
                                ConnectorVM newConnector = new ConnectorVM
                                                               {
                                                                   SourceNode = (param as DiagramEventArgs).Item,
                                                                   TargetNode = connector.TargetNode
                                                               };
                                connector.TargetNode = (param as DiagramEventArgs).Item;
                                (this.Connectors as ObservableCollection<ConnectorVM>).Add(newConnector);
                                break;
                            }
                        }
                    }
                }
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
                ConnectorVM newConnector = new ConnectorVM { SourceNode = (param as ItemDropEventArgs).Source };
                foreach (object target in targetCollection)
                {
                    if (target is IConnector)
                    {
                        if ((target as ConnectorVM).TargetNode != null)
                        {
                            newConnector.TargetNode = (target as ConnectorVM).TargetNode;
                            (this.Connectors as ObservableCollection<ConnectorVM>).Add(newConnector);
                        }

                        (target as ConnectorVM).TargetNode = (param as ItemDropEventArgs).Source;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// The symbols dropping command execute.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private void SymbolsDroppingCommandExecute(object param)
        {
        }
    }
}