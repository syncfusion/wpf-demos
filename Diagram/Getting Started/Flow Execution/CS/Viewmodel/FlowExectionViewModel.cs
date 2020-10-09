#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using GettingStarted_Flow_Execution.Utility;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Theming;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Getting_Started_Flow_Execution.Viewmodel
{
    public class FlowExectionViewModel : DiagramViewModel
    {
        private ICommand _FlowCommand;
        private string selectedradiobutton = "None";

        public FlowExectionViewModel()
        {
            SelectedItems = new SelectorViewModel()
            {
                SelectorConstraints = SelectorConstraints.Default & ~SelectorConstraints.QuickCommands,
            };

            SnapSettings = new SnapSettings()
            {
                SnapConstraints = SnapConstraints.ShowLines,
            };

            HorizontalRuler = new Ruler() { Orientation = Orientation.Horizontal };

            VerticalRuler = new Ruler() { Orientation = Orientation.Vertical };

            FlowCommand = new Command(FlowExecution);

            NodeViewModel Node1 = CreateNode(200, 100, "Ellipse", "Begin");
            NodeViewModel Node2 = CreateNode(400, 100, "Rectangle", "Specify collection");
            NodeViewModel Node3 = CreateNode(600, 100, "Diamond", "Particulars required");
            Node3.IsSelected = true;
            NodeViewModel Node4 = CreateNode(800, 100, "Rectangle", "Specify particulars");
            NodeViewModel Node5 = CreateNode(600, 250, "Rectangle", "Design collection");
            NodeViewModel Node6 = CreateNode(600, 400, "Rectangle", "Cluster of events");
            NodeViewModel Node7 = CreateNode(800, 400, "Rectangle", "Record and analyze results");
            NodeViewModel Node8 = CreateNode(600, 550, "Rectangle", "Start the process");
            NodeViewModel Node9 = CreateNode(800, 550, "Ellipse", "End");

            ConnectorViewModel Con1 = CreateConnector(Node1, Node2, "");
            ConnectorViewModel Con2 = CreateConnector(Node2, Node3, "");
            ConnectorViewModel Con3 = CreateConnector(Node3, Node4, "Yes");
            ConnectorViewModel Con4 = CreateConnector(Node3, Node5, "No");
            ConnectorViewModel Con5 = CreateConnector(Node4, Node5, "Seg");
            ConnectorViewModel Con6 = CreateConnector(Node5, Node6, "");
            ConnectorViewModel Con7 = CreateConnector(Node7, Node6, "");
            ConnectorViewModel Con8 = CreateConnector(Node6, Node8, "");
            ConnectorViewModel Con9 = CreateConnector(Node8, Node9, "");

            ItemSelectedCommand = new Command(ItemselectedExecution);
        }

        public ICommand FlowCommand
        {
            get { return _FlowCommand; }
            set { _FlowCommand = value; }
        }

        #region Helper Methods

        /// <summary>
        /// This method is used to execute itemselected command
        /// </summary>
        /// <param name="obj"></param>
        private void ItemselectedExecution(object obj)
        {
            FlowExecution(selectedradiobutton);
        }

        /// <summary>
        /// This method is used to execute Flow command
        /// </summary>
        /// <param name="obj"></param>
        private void FlowExecution(object obj)
        {
            selectedradiobutton = obj.ToString();
            if ((SelectedItems as SelectorViewModel).Nodes as IEnumerable<object> != null && ((SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).Count() > 0)
            {
                ClearAll();
                NodeViewModel node = ((SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).First() as NodeViewModel;
                if (obj.ToString() == "Incoming Connections")
                {
                    if((node.Info as INodeInfo).InConnectors as IEnumerable<object> != null && ((node.Info as INodeInfo).InConnectors as IEnumerable<object>).Count() > 0)
                    {
                        foreach(ConnectorViewModel con in (node.Info as INodeInfo).InConnectors as IEnumerable<object>)
                        {
                            con.ConnectorGeometryStyle = App.Current.MainWindow.Resources["ConnectorGeometryStyle"] as Style;
                            con.TargetDecoratorStyle = App.Current.MainWindow.Resources["TargetDecoratorStyle"] as Style;
                        }
                    }
                }
                else if (obj.ToString() == "Outgoing Connections")
                {
                    if ((node.Info as INodeInfo).OutConnectors as IEnumerable<object> != null && ((node.Info as INodeInfo).OutConnectors as IEnumerable<object>).Count() > 0)
                    {
                        foreach (ConnectorViewModel con in (node.Info as INodeInfo).OutConnectors as IEnumerable<object>)
                        {
                            con.ConnectorGeometryStyle = App.Current.MainWindow.Resources["ConnectorGeometryStyle"] as Style;
                            con.TargetDecoratorStyle = App.Current.MainWindow.Resources["TargetDecoratorStyle"] as Style;
                        }
                    }
                }
                else if (obj.ToString() == "Incoming and Outgoing Connections")
                {
                    if ((node.Info as INodeInfo).InOutConnectors as IEnumerable<object> != null && ((node.Info as INodeInfo).InOutConnectors as IEnumerable<object>).Count() > 0)
                    {
                        foreach (ConnectorViewModel con in (node.Info as INodeInfo).InOutConnectors as IEnumerable<object>)
                        {
                            con.ConnectorGeometryStyle = App.Current.MainWindow.Resources["ConnectorGeometryStyle"] as Style;
                            con.TargetDecoratorStyle = App.Current.MainWindow.Resources["TargetDecoratorStyle"] as Style;
                        }
                    }                    
                }
                else if (obj.ToString() == "Incoming Nodes")
                {
                    if ((node.Info as INodeInfo).InNeighbors as IEnumerable<object> != null && ((node.Info as INodeInfo).InNeighbors as IEnumerable<object>).Count() > 0)
                    {
                        foreach (NodeViewModel innode in (node.Info as INodeInfo).InNeighbors as IEnumerable<object>)
                        {
                            if (node != innode)
                            {
                                innode.ShapeStyle = App.Current.MainWindow.Resources["NodeStyle"] as Style;
                            }
                        }
                    }
                }
                else if (obj.ToString() == "Outgoing Nodes")
                {
                    if ((node.Info as INodeInfo).OutNeighbors as IEnumerable<object> != null && ((node.Info as INodeInfo).OutNeighbors as IEnumerable<object>).Count() > 0)
                    {
                        foreach (NodeViewModel outnode in (node.Info as INodeInfo).OutNeighbors as IEnumerable<object>)
                        {
                            if (node != outnode)
                            {
                                outnode.ShapeStyle = App.Current.MainWindow.Resources["NodeStyle"] as Style;
                            }
                        }
                    }
                }
                else if (obj.ToString() == "Incoming and Outgoing Nodes")
                {
                    if ((node.Info as INodeInfo).InNeighbors as IEnumerable<object> != null && ((node.Info as INodeInfo).InNeighbors as IEnumerable<object>).Count() > 0)
                    {
                        foreach (NodeViewModel innode in (node.Info as INodeInfo).InNeighbors as IEnumerable<object>)
                        {
                            if (node != innode)
                            {
                                innode.ShapeStyle = App.Current.MainWindow.Resources["NodeStyle"] as Style;
                            }
                        }
                    }
                    if ((node.Info as INodeInfo).OutNeighbors as IEnumerable<object> != null && ((node.Info as INodeInfo).OutNeighbors as IEnumerable<object>).Count() > 0)
                    {
                        foreach (NodeViewModel outnode in (node.Info as INodeInfo).OutNeighbors as IEnumerable<object>)
                        {
                            if (node != outnode)
                            {
                                outnode.ShapeStyle = App.Current.MainWindow.Resources["NodeStyle"] as Style;
                            }
                        }
                    }
                }
                else if(obj.ToString() == "Flow of execution")
                {
                    if ((node.Info as INodeInfo).OutConnectors as IEnumerable<object> != null && ((node.Info as INodeInfo).OutConnectors as IEnumerable<object>).Count() > 0)
                    {
                        foreach (ConnectorViewModel con in (node.Info as INodeInfo).OutConnectors as IEnumerable<object>)
                        {
                            AdjacentStyle(con);
                        }
                    }
                }
                else
                {
                    ClearAll();
                }
            }
            else
            {
                MessageBox.Show("Select any Node to find its Flow Execution");
            }
        }

        private void AdjacentStyle(ConnectorViewModel con)
        {
            if (con.TargetNode != null)
            {
                NodeViewModel node = con.TargetNode as NodeViewModel;
                if ((node.Info as INodeInfo).OutConnectors as IEnumerable<object> != null && ((node.Info as INodeInfo).OutConnectors as IEnumerable<object>).Count() > 0)
                {
                    foreach (ConnectorViewModel conn in (node.Info as INodeInfo).OutConnectors as IEnumerable<object>)
                    {
                        AdjacentStyle(conn);
                    }
                }
            }
            if (con.Annotations != null && con.Annotations is AnnotationCollection)
            {
                if (((con.Annotations as AnnotationCollection).ElementAt(0) as AnnotationEditorViewModel).Content.ToString() != "No")
                {
                    con.ConnectorGeometryStyle = App.Current.MainWindow.Resources["ConnectorGeometryStyle"] as Style;
                    con.TargetDecoratorStyle = App.Current.MainWindow.Resources["TargetDecoratorStyle"] as Style;
                }
            }
            else
            {
                con.ConnectorGeometryStyle = App.Current.MainWindow.Resources["ConnectorGeometryStyle"] as Style;
                con.TargetDecoratorStyle = App.Current.MainWindow.Resources["TargetDecoratorStyle"] as Style;
            }
        }

        /// <summary>
        /// This method is used to clear all the styles.
        /// </summary>
        private void ClearAll()
        {
            foreach(NodeViewModel node in Nodes as NodeCollection)
            {
                node.ShapeStyle = App.Current.MainWindow.Resources["DefaultNodeStyle"] as Style;
            }
            foreach(ConnectorViewModel con in Connectors as ConnectorCollection)
            {
                con.ConnectorGeometryStyle = App.Current.MainWindow.Resources["DefaultConnectorGeometryStyle"] as Style;
                con.TargetDecoratorStyle = App.Current.MainWindow.Resources["DefaultTargetDecoratorStyle"] as Style;
            }
        }

        /// <summary>
        /// This method is used to create Node
        /// </summary>
        /// <param name="offsetx"></param>
        /// <param name="offsety"></param>
        /// <param name="shape"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private NodeViewModel CreateNode(double offsetx, double offsety, string shape, string content)
        {
            NodeViewModel node = new NodeViewModel()
            {
                UnitHeight = 70,
                UnitWidth = 118,
                OffsetX = offsetx,
                OffsetY = offsety,
                Shape = App.Current.Resources[shape],
                ShapeStyle = App.Current.MainWindow.Resources["DefaultNodeStyle"] as Style,
            };
            if (content != "")
            {
                node.Annotations = new AnnotationCollection()
                {
                    new AnnotationEditorViewModel()
                    {
                        Content = content,
                    },
                };
            }

            (Nodes as NodeCollection).Add(node);

            return node;
        }

        /// <summary>
        /// This method is used to create Connectors
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        private ConnectorViewModel CreateConnector(NodeViewModel sourcenode, NodeViewModel targetnode, string content)
        {
            ConnectorViewModel con = new ConnectorViewModel()
            {
                SourceNode = sourcenode,
                TargetNode = targetnode,
                ConnectorGeometryStyle = App.Current.MainWindow.Resources["DefaultConnectorGeometryStyle"] as Style,
                TargetDecoratorStyle = App.Current.MainWindow.Resources["DefaultTargetDecoratorStyle"] as Style,
                Annotations = null,
            };

            if (content != "" && content != "Seg")
            {
                if (content == "No")
                {
                    con.Annotations = new AnnotationCollection()
                    {
                        new AnnotationEditorViewModel()
                        {
                            Content = content,
                            RotateAngle = -90,
                        },
                    };
                }
                else
                {
                    con.Annotations = new AnnotationCollection()
                    {
                        new AnnotationEditorViewModel()
                        {
                            Content = content,
                        },
                    };
                }
            }

            if(content == "Seg")
            {
                con.Segments = new ConnectorSegments()
                {
                    new StraightSegment()
                    {
                        Point = new System.Windows.Point(800,250),
                    },
                };
            }

            (Connectors as ConnectorCollection).Add(con);

            return con;
        }

        #endregion
    }
}
