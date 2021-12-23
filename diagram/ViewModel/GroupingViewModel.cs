#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using Syncfusion.UI.Xaml.Diagram.Theming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class GroupingViewModel : DiagramViewModel
    {

        ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/Syncfusion.SfDiagram.Wpf;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
        };


        public GroupingViewModel()
        {
            
            HorizontalRuler = new Ruler() { Orientation = Orientation.Horizontal };

            VerticalRuler = new Ruler() { Orientation = Orientation.Vertical };

            Theme = new SimpleTheme();

            NodeViewModel Node1 = CreateNode(200, 150, "Rectangle", "");
            NodeViewModel Node2 = CreateNode(400, 150, "RoundedRectangle", "");
            NodeViewModel Node3 = CreateNode(200, 300, "Ellipse", "Start/Stop");
            NodeViewModel Node4 = CreateNode(400, 300, "PredefinedProcess", "Decision");
            NodeViewModel Node5 = CreateNode(200, 450, "Rectangle", "Process");
            NodeViewModel Node6 = CreateNode(650, 150, "Rectangle", "Process");
            NodeViewModel Node7 = CreateNode(850, 150, "Rectangle", "Process");

            CreateGroup(Node1, Node2);
            CreateContainer(Node6, Node7, "Container", 340, 100, 750, 150);

            //Initialize the item adde command to container style.
            ItemAddedCommand = new DelegateCommand(OnItemAddedCommandExecute);
        }


        #region Helper Methods

        /// <summary>
        /// Command to item added event.
        /// </summary>
        /// <param name="parameter">ItemAddedEventArgs</param>
        private void OnItemAddedCommandExecute(object parameter)
        {
            if (parameter is ItemAddedEventArgs)
            {
                if ((parameter as ItemAddedEventArgs).Item is IContainer)
                {
                    ((parameter as ItemAddedEventArgs).Item as IContainer).Shape = resourceDictionary["Rectangle"];
                }
            }
        }

        /// <summary>
        /// This method is used to create Group
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        private void CreateGroup(NodeViewModel node1, NodeViewModel node2)
        {
            GroupViewModel group = new GroupViewModel()
            {
                Nodes = new NodeCollection()
                {
                    node1,
                    node2
                },
                Annotations = new AnnotationCollection()
                {
                    new AnnotationEditorViewModel()
                    {
                        Content = "Group 1",
                    },
                },
            };

            (Groups as GroupCollection).Add(group);
        }

        /// <summary>
        /// This method is used to create Group
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        private void CreateContainer(NodeViewModel node1, NodeViewModel node2, string content, double width, double height, double offsetX, double offsetY)
        {
            ContainerViewModel container = new ContainerViewModel()
            {
                UnitHeight = height,
                UnitWidth = width,
                OffsetX = offsetX,
                OffsetY = offsetY,
                Nodes = new NodeCollection()
                {
                    node1,
                    node2
                },
                Annotations = new AnnotationCollection()
                {
                    new AnnotationEditorViewModel()
                    {
                        Content = content,
                    },
                },
            };

            container.Shape = resourceDictionary["Rectangle"];

            (Groups as GroupCollection).Add(container);
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
                UnitHeight = 60,
                UnitWidth = 100,
                OffsetX = offsetx,
                OffsetY = offsety,
                Shape = resourceDictionary[shape],
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

        #endregion
    }
}
