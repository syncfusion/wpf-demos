#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Theming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
            // Apply new theme, Snapsettings, Ruler  for Diagram.
            Theme = new OfficeTheme();

            HorizontalRuler = new Ruler() { Orientation = Orientation.Horizontal };

            VerticalRuler = new Ruler() { Orientation = Orientation.Vertical };

            NodeViewModel Node1 = CreateNode(600, 150, "Rectangle", "");
            NodeViewModel Node2 = CreateNode(800, 150, "RoundedRectangle", "");
            NodeViewModel Node3 = CreateNode(600, 300, "Ellipse", "Start/Stop");
            NodeViewModel Node4 = CreateNode(800, 300, "PredefinedProcess", "Decision");
            NodeViewModel Node5 = CreateNode(600, 450, "Rectangle", "Process");

            CreateGroup(Node1, Node2);
        }

        #region Helper Methods

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
