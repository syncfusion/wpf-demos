#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class VirtualizationViewModel : DiagramViewModel
    {
        public VirtualizationViewModel()
        {
            Constraints = Constraints.Add(GraphConstraints.Virtualize, GraphConstraints.Outline, GraphConstraints.AllowPan);
            Constraints = Constraints.Remove(GraphConstraints.PageEditing);

            //Arrange Node
            CreateNode();

            //Connect Nodes 
            CreateConnection();
        }

        //Arrange the Nodes for Hexagon shape.
        private void CreateNode()
        {
            double commonfortop = 0;
            double alternate = 0;
            double levelfortop = 50;
            double levelforremaining = 0;
            for (int j = 1; j < 101; j++)
            {
                for (int i = 0; i < 100; ++i)
                {
                    NodeViewModel node = new NodeViewModel();
                    node.UnitWidth = 50;
                    node.UnitHeight = 30;

                    if (i == 0)
                    {
                        node.OffsetX = 100 + (levelfortop);
                        commonfortop = node.OffsetX;
                    }
                    else
                    {
                        alternate += 1;
                        if (alternate <= 2)
                        {
                            node.OffsetX = 40 + levelforremaining;

                        }
                        else
                        {
                            node.OffsetX = commonfortop;
                        }

                        if (alternate == 4)
                        {
                            alternate = 0;
                        }
                    }

                    node.OffsetY = 20 + (80 * i);
                    node.Shape = new RectangleGeometry() { Rect = new Rect(0, 0, 50, 50) };
                    (Nodes as ObservableCollection<NodeViewModel>).Add(node);
                }
                levelfortop += 220;
                levelforremaining += 220;
                alternate = 0;
            }
        }

        //Connects the Hexagon arrangment Nodes.
        private void CreateConnection()
        {
            int increment = 0;
            int altenate = 0;
            for (int j = 1; j < 101; j++)
            {
                for (int i = 0; i < 100; i++)
                {
                    if ((i + increment + 1) % 100 != 0)
                    {
                        ConnectorViewModel cv1 = new ConnectorViewModel()
                        {
                            SourceNode = (Nodes as ObservableCollection<NodeViewModel>).ToList()[i + increment],
                            TargetNode = (Nodes as ObservableCollection<NodeViewModel>).ToList()[i + 1 + increment],
                        };
                        (Connectors as ObservableCollection<ConnectorViewModel>).Add(cv1);
                    }
                    if (j == 1 && i == 0)
                    {
                        ConnectorViewModel cv1 = new ConnectorViewModel()
                        {
                            SourceNode = (Nodes as ObservableCollection<NodeViewModel>).ToList()[i],
                            TargetNode = (Nodes as ObservableCollection<NodeViewModel>).ToList()[i + 101],
                        };
                        (Connectors as ObservableCollection<ConnectorViewModel>).Add(cv1);
                    }
                    if (j != 1)
                    {
                        if (i == 0)
                        {
                            if (!((increment + 100) > 9900))
                            {
                                ConnectorViewModel cv1 = new ConnectorViewModel()
                                {
                                    SourceNode = (Nodes as ObservableCollection<NodeViewModel>).ToList()[i + increment],
                                    TargetNode = (Nodes as ObservableCollection<NodeViewModel>).ToList()[i + 1 + (increment + 100)],
                                };
                                (Connectors as ObservableCollection<ConnectorViewModel>).Add(cv1);
                            }
                        }
                        else
                        {
                            altenate += 1;
                            if (altenate == 2 || altenate == 5)
                            {
                                if (altenate == 2)
                                {
                                    ConnectorViewModel cv1 = new ConnectorViewModel()
                                    {
                                        SourceNode = (Nodes as ObservableCollection<NodeViewModel>).ToList()[i + increment],
                                        TargetNode = (Nodes as ObservableCollection<NodeViewModel>).ToList()[i + 1 + (increment - 100)],
                                    };
                                    (Connectors as ObservableCollection<ConnectorViewModel>).Add(cv1);
                                }
                                else
                                {
                                    ConnectorViewModel cv1 = new ConnectorViewModel()
                                    {
                                        SourceNode = (Nodes as ObservableCollection<NodeViewModel>).ToList()[i + increment],
                                        TargetNode = (Nodes as ObservableCollection<NodeViewModel>).ToList()[i - 1 + (increment - 100)],
                                    };
                                    (Connectors as ObservableCollection<ConnectorViewModel>).Add(cv1);
                                }
                            }
                            if (altenate == 5)
                            {
                                altenate = 0;
                                altenate += 1;
                            }
                        }
                    }
                }
                increment += 100;
                altenate = 0;
            }
        }
    }
}
