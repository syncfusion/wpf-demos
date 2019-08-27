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
using System.Windows.Input;
using DiagramBuilder.Utility;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System.Windows.Controls;
using Syncfusion.UI.Xaml.Diagram;
using System.Windows;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;

namespace FlowChart.ViewModel
{
    public class FlowDiagramVm : DiagramVM
    {
        public FlowDiagramVm()
        {
            
        }

        public FlowDiagramVm(string file, bool isValidXml) : base(file, isValidXml)
        {
            DiagramType = DiagramType.FlowChart;
            this.SelectedItems = new FlowChartSelectorVm(this);
            ItemUnSelectedCommand = new Command(OnItemUnselectCommandExecute);
            DropCommand = new Command(OnSymbolDropCommandExecute);
            NodeChangedCommand = new Command(OnNodeChangedCommandExecute);
            this.VerticalRuler = new Ruler() { Orientation = Orientation.Vertical };
            this.HorizontalRuler = new Ruler() { Orientation = Orientation.Horizontal };
            ItemSelectedCommand = new Command(OnItemSelectionCommandExecute);
            SymbolDroppingCommand = new Command(SymbolsDroppingCommandExecute);
            ItemAddedCommand = new Command(ItemAddedCommandExcecute);
            ItemDeletingCommand = new DelegateCommand<object>(ItemDeletingCommandExecute);
            this.Constraints |= GraphConstraints.Undoable;
        }


        void ItemDeletingCommandExecute(object param)
        {
            int val = ((this.SelectedItems as FlowChartSelectorVm).Connectors as IEnumerable<object>).Count();
            if (val == 0)
            {
                NodeVM deletingNode = (param as ItemDeletingEventArgs).Item as NodeVM;

                if ((param as ItemDeletingEventArgs).Item is NodeVM && (deletingNode.Info as INodeInfo).InConnectors != null &&
                    (deletingNode.Info as INodeInfo).OutConnectors != null)
                {
                    if (((deletingNode.Info as INodeInfo).InConnectors.Count() > 1 && (deletingNode.Info as INodeInfo).OutConnectors.Count() > 1)
                        || ((deletingNode.Info as INodeInfo).InConnectors.Count() == 1 && (deletingNode.Info as INodeInfo).OutConnectors.Count() == 0)
                        || ((deletingNode.Info as INodeInfo).InConnectors.Count() == 0 && (deletingNode.Info as INodeInfo).OutConnectors.Count() == 1)
                        || (((deletingNode.Info as INodeInfo).InConnectors.Count() == 0) && (deletingNode.Info as INodeInfo).OutConnectors.Count() > 1)
                        || (((deletingNode.Info as INodeInfo).InConnectors.Count() > 1) && (deletingNode.Info as INodeInfo).OutConnectors.Count() == 0))
                    {
                        (param as ItemDeletingEventArgs).DeleteDependentConnector = true;
                    }
                    else
                    {
                        (param as ItemDeletingEventArgs).DeleteDependentConnector = false;

                        if ((deletingNode.Info as INodeInfo).InConnectors.Count() == 1 && (deletingNode.Info as INodeInfo).OutConnectors.Count() == 1)
                        {
                            NodeVM newtargetNode = null;
                            ConnectorVM outconnector = (deletingNode.Info as INodeInfo).OutConnectors.ToList()[0] as ConnectorVM;
                            newtargetNode = outconnector.TargetNode as NodeVM;
                            this.ConnectorCollection.Remove(outconnector);

                            var inconnector = (deletingNode.Info as INodeInfo).InConnectors.ToList()[0] as ConnectorVM;
                            inconnector.TargetNode = newtargetNode;
                        }
                        else if ((deletingNode.Info as INodeInfo).InConnectors.Count() > 1 && (deletingNode.Info as INodeInfo).OutConnectors.Count() == 1)
                        {
                            NodeVM newtargetNode = null;
                            ConnectorVM outconnector = (deletingNode.Info as INodeInfo).OutConnectors.ToList()[0] as ConnectorVM;
                            newtargetNode = outconnector.TargetNode as NodeVM;
                            this.ConnectorCollection.Remove(outconnector);

                            var inConnectorsCollction = (deletingNode.Info as INodeInfo).InConnectors;
                            foreach (ConnectorVM connector in inConnectorsCollction.ToList())
                            {
                                connector.TargetNode = newtargetNode;
                            }
                        }
                        else if ((deletingNode.Info as INodeInfo).InConnectors.Count() == 1 && (deletingNode.Info as INodeInfo).OutConnectors.Count() > 1)
                        {
                            NodeVM newtargetNode = null;
                            ConnectorVM inconnector = (deletingNode.Info as INodeInfo).InConnectors.ToList()[0] as ConnectorVM;
                            newtargetNode = inconnector.SourceNode as NodeVM;
                            this.ConnectorCollection.Remove(inconnector);

                            var outConnectorsCollection = (deletingNode.Info as INodeInfo).OutConnectors;
                            foreach (ConnectorVM connector in outConnectorsCollection.ToList())
                            {
                                connector.SourceNode = newtargetNode;
                            }
                        }

                    }
                }
            }
        }


        void ItemAddedCommandExcecute(object param)
        {
            if (param is ItemAddedEventArgs && ((param as ItemAddedEventArgs).Item is NodeVM))
            {
                ((param as ItemAddedEventArgs).Item as NodeVM).Constraints |= NodeConstraints.AllowDrop;
            }

        }
        void SymbolsDroppingCommandExecute(object param)
        {

        }
        void OnItemSelectionCommandExecute(object param)
        {
            int val =  ((this.SelectedItems as FlowChartSelectorVm).Nodes as ObservableCollection<object>).Count();
            if (val == 1)
            {
                if ((param as DiagramEventArgs).Item is NodeVM)
                {
                    this.FindQuickCommandVisibilty(param as DiagramEventArgs);
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
        /// To add connectors when node is dragging and on diagram page and placed over Connector
        /// </summary>
        /// <param name="param">value of NodeChangedEventArgs</param>
        void OnNodeChangedCommandExecute(object param)
        {
            if ((param as DiagramEventArgs).Item is NodeVM)
            {
                this.FindQuickCommandVisibilty(param as DiagramEventArgs);
            }

            //Enables the allow drop constraints when node/Connector intersectes.
            var ConnectorsCollections = this.Connectors as ObservableCollection<ConnectorVM>;
            var NodesCollections = this.Nodes as ObservableCollection<NodeVM>;

            //To split and add the connectors when exisiting node is dropped on connector.
            if (((param as ChangeEventArgs<object, NodeChangedEventArgs>).NewValue.InteractionState == NodeChangedInteractionState.Dragged))
            {
                Rect nodeBounds = new Rect(0, 0, 0, 0);
                if ((((param as DiagramEventArgs).Item as NodeVM).Info as INodeInfo).InOutConnectors == null)
                {
                    nodeBounds = (((param as DiagramEventArgs).Item as NodeVM).Info as INodeInfo).Bounds;
                    var ConnectorCollection = this.Connectors as ObservableCollection<ConnectorVM>;
                    if (ConnectorCollection.Count > 0)
                    {
                        foreach (ConnectorVM connector in ConnectorCollection)
                        {
                            Rect Connectorbounds = (connector.Info as IConnectorInfo).Bounds;
                            if (nodeBounds.IntersectsWith(Connectorbounds))
                            {
                                ConnectorVM newConnector = new ConnectorVM()
                                {
                                    SourceNode = (param as DiagramEventArgs).Item,
                                    TargetNode = connector.TargetNode,
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

        private void FindQuickCommandVisibilty(DiagramEventArgs param)
        {
            // right side intersecting bounds
            Rect nodebounds = (((param as DiagramEventArgs).Item as NodeVM).Info as INodeInfo).Bounds;
            double right_x = nodebounds.Right + 50;
            double right_y = ((param as DiagramEventArgs).Item as NodeVM).OffsetY - 25;
            Rect rightintersectbounds = new Rect(right_x, right_y, 100, 50);

            // left side intersecting bounds
            double left_x = nodebounds.Left - 150;
            double left_y = ((param as DiagramEventArgs).Item as NodeVM).OffsetY - 25;
            Rect leftIntersectBounds = new Rect(left_x, left_y, 100, 50);

            // bottom side intersecting bounds
            double bottom_x = ((param as DiagramEventArgs).Item as NodeVM).OffsetX - 50;
            double bottom_y = nodebounds.Bottom + 50;
            Rect bottomIntersectbounds = new Rect(bottom_x, bottom_y, 100, 50);

            // top side intersecting bounds
            double top_x = ((param as DiagramEventArgs).Item as NodeVM).OffsetX - 50;
            double top_y = nodebounds.Top - 100;
            Rect topIntersectbounds = new Rect(top_x, top_y, 100, 50);

            var nodesCollection = this.Nodes as ObservableCollection<NodeVM>;

            double Nodeangle = ((param as DiagramEventArgs).Item as NodeVM).RotateAngle;


            if (nodesCollection != null)
            {
                if ((Nodeangle >= 315 && Nodeangle <= 360) || (Nodeangle >= 0 && Nodeangle <= 45))
                {
                    //To hide or show right side button
                    foreach (var node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;
                        if (((node as NodeVM).Info as INodeInfo).Bounds.IntersectsWith(rightintersectbounds))
                        {
                            sd.RightButtonVisibility = Visibility.Hidden;
                            break;
                        }
                        else
                        {
                            sd.RightButtonVisibility = Visibility.Visible;
                        }
                    };

                    //To hide or show left side button
                    foreach (var node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;

                        if (((node as NodeVM).Info as INodeInfo).Bounds.IntersectsWith(leftIntersectBounds))
                        {
                            sd.LeftButtonVisibility = Visibility.Hidden;
                            break;
                        }
                        else
                        {
                            sd.LeftButtonVisibility = Visibility.Visible;
                        }
                    };

                    //To hide or show top side button
                    foreach (var node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;

                        if (((node as NodeVM).Info as INodeInfo).Bounds.IntersectsWith(topIntersectbounds))
                        {
                            sd.TopButtonVisibility = Visibility.Hidden;
                            break;
                        }
                        else
                        {
                            sd.TopButtonVisibility = Visibility.Visible;
                        }
                    };

                    //To hide or show bottom side button
                    foreach (var node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;

                        if (((node as NodeVM).Info as INodeInfo).Bounds.IntersectsWith(bottomIntersectbounds))
                        {
                            sd.BottomButtonVisibility = Visibility.Hidden;
                            break;
                        }
                        else
                        {
                            sd.BottomButtonVisibility = Visibility.Visible;
                        }
                    };
                }
                else if (Nodeangle >= 45 && Nodeangle <= 135)
                {
                    //To hide or show right side button
                    foreach (var node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;
                        if (((node as NodeVM).Info as INodeInfo).Bounds.IntersectsWith(rightintersectbounds))
                        {
                            sd.TopButtonVisibility = Visibility.Hidden;
                            break;
                        }
                        else
                        {
                            sd.TopButtonVisibility = Visibility.Visible;
                        }
                    };

                    //To hide or show left side button
                    foreach (var node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;

                        if (((node as NodeVM).Info as INodeInfo).Bounds.IntersectsWith(leftIntersectBounds))
                        {
                            sd.BottomButtonVisibility = Visibility.Hidden;
                            break;
                        }
                        else
                        {
                            sd.BottomButtonVisibility = Visibility.Visible;
                        }
                    };

                    //To hide or show top side button
                    foreach (var node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;

                        if (((node as NodeVM).Info as INodeInfo).Bounds.IntersectsWith(topIntersectbounds))
                        {
                            sd.LeftButtonVisibility = Visibility.Hidden;
                            break;
                        }
                        else
                        {
                            sd.LeftButtonVisibility = Visibility.Visible;
                        }
                    };

                    //To hide or show bottom side button
                    foreach (var node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;

                        if (((node as NodeVM).Info as INodeInfo).Bounds.IntersectsWith(bottomIntersectbounds))
                        {
                            sd.RightButtonVisibility = Visibility.Hidden;
                            break;
                        }
                        else
                        {
                            sd.RightButtonVisibility = Visibility.Visible;
                        }
                    };
                }
                else if (Nodeangle >= 135 && Nodeangle <= 225)
                {
                    //To hide or show right side button
                    foreach (var node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;
                        if (((node as NodeVM).Info as INodeInfo).Bounds.IntersectsWith(rightintersectbounds))
                        {
                            sd.LeftButtonVisibility = Visibility.Hidden;
                            break;
                        }
                        else
                        {
                            sd.LeftButtonVisibility = Visibility.Visible;
                        }
                    };

                    //To hide or show left side button
                    foreach (var node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;

                        if (((node as NodeVM).Info as INodeInfo).Bounds.IntersectsWith(leftIntersectBounds))
                        {
                            sd.RightButtonVisibility = Visibility.Hidden;
                            break;
                        }
                        else
                        {
                            sd.RightButtonVisibility = Visibility.Visible;
                        }
                    };

                    //To hide or show top side button
                    foreach (var node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;

                        if (((node as NodeVM).Info as INodeInfo).Bounds.IntersectsWith(topIntersectbounds))
                        {
                            sd.BottomButtonVisibility = Visibility.Hidden;
                            break;
                        }
                        else
                        {
                            sd.BottomButtonVisibility = Visibility.Visible;
                        }
                    };

                    //To hide or show bottom side button
                    foreach (var node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;

                        if (((node as NodeVM).Info as INodeInfo).Bounds.IntersectsWith(bottomIntersectbounds))
                        {
                            sd.TopButtonVisibility = Visibility.Hidden;
                            break;
                        }
                        else
                        {
                            sd.TopButtonVisibility = Visibility.Visible;
                        }
                    };
                }
                else if (Nodeangle >= 225 && Nodeangle <= 325)
                {
                    //To hide or show right side button
                    foreach (var node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;
                        if (((node as NodeVM).Info as INodeInfo).Bounds.IntersectsWith(rightintersectbounds))
                        {
                            sd.BottomButtonVisibility = Visibility.Hidden;
                            break;
                        }
                        else
                        {
                            sd.BottomButtonVisibility = Visibility.Visible;
                        }
                    };

                    //To hide or show left side button
                    foreach (var node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;

                        if (((node as NodeVM).Info as INodeInfo).Bounds.IntersectsWith(leftIntersectBounds))
                        {
                            sd.TopButtonVisibility = Visibility.Hidden;
                            break;
                        }
                        else
                        {
                            sd.TopButtonVisibility = Visibility.Visible;
                        }
                    };

                    //To hide or show top side button
                    foreach (var node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;

                        if (((node as NodeVM).Info as INodeInfo).Bounds.IntersectsWith(topIntersectbounds))
                        {
                            sd.RightButtonVisibility = Visibility.Hidden;
                            break;
                        }
                        else
                        {
                            sd.RightButtonVisibility = Visibility.Visible;
                        }
                    };

                    //To hide or show bottom side button
                    foreach (var node in nodesCollection)
                    {
                        FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;

                        if (((node as NodeVM).Info as INodeInfo).Bounds.IntersectsWith(bottomIntersectbounds))
                        {
                            sd.LeftButtonVisibility = Visibility.Hidden;
                            break;
                        }
                        else
                        {
                            sd.LeftButtonVisibility = Visibility.Visible;
                        }
                    };
                }
            }
        }

        /// <summary>
        /// Split and adding the connector when symbol is dragged form Stencil and dropped over connector
        /// </summary>
        /// <param name="param"></param>
        void OnSymbolDropCommandExecute(object param)
        {
            var targetCollection = (param as ItemDropEventArgs).Target as IEnumerable<object>;
            if (targetCollection != null)
            {
                ConnectorVM newConnector = new ConnectorVM()
                {
                    SourceNode = (param as ItemDropEventArgs).Source,
                };
                foreach (var target in targetCollection)
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
        /// To make shapes collection panel invisible when item is getting unselection 
        /// </summary>
        /// <param name="param"></param>
        void OnItemUnselectCommandExecute(object param)
        {
            if ((param as DiagramEventArgs).Item is NodeVM)
            {
                FlowChartSelectorVm sd = this.SelectedItems as FlowChartSelectorVm;
                sd.PanelVisibility = Visibility.Collapsed;
            }
        }
    }

    
}
