#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Runtime.Serialization;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Syncfusion.Windows.Shared;
using Syncfusion.UI.Xaml.Diagram.Theming;

namespace GettingStarted_Localization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //To Represent ResourceManager
        System.Resources.ResourceManager manager;

        public MainWindow()
        {
            InitializeComponent();

            //Get CultureInfo 
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr");//French

            //Initialize Assembly
            Assembly assembly = Application.Current.GetType().Assembly;
            manager = new System.Resources.ResourceManager("Localization.Resources.Syncfusion.SfDiagram.WPF", assembly);

            //Graph constraints is used here to enable/disable the undoable process.
            diagram.Constraints.Add(GraphConstraints.Undoable);

            (diagramcontrol.Info as IGraphInfo).ItemAdded += MainWindow_ItemAdded;

            //Create Nodes and Connections
            CreateNodesAndConnectors();
        }

        private void MainWindow_ItemAdded(object sender, ItemAddedEventArgs args)
        {
            if(args.Item is NodeViewModel)
            {
                foreach (TextAnnotationViewModel anno in (args.Item as NodeViewModel).Annotations as ObservableCollection<IAnnotation>)
                {
                    anno.FontFamily = new FontFamily("Calibri");
                }
            }
            else if(args.Item is ConnectorViewModel)
            {
                foreach (TextAnnotationViewModel anno in (args.Item as ConnectorViewModel).Annotations as ObservableCollection<IAnnotation>)
                {
                    anno.FontFamily = new FontFamily("Calibri");
                }
            }
        }

        //Create Nodes and Connections
        private void CreateNodesAndConnectors()
        {
           // diagram.Nodes = new ObservableCollection<NodeViewModel>();
           // diagram.Connectors = new ObservableCollection<ConnectorViewModel>();
            ///Add and Creating Nodes
            //Create and Add NewIdea Node  
            NodeViewModel NewIdea = AddNode(150, 60, 245, 40, "Ellipse", "NewIdea");

            //Create and Add Meeting Node 
            NodeViewModel Meeting = AddNode(150, 60, 245, 145, "Process", "Meeting");

            //Create and Add BoardDecision Node 
            NodeViewModel BoardDecision = AddNode(160, 100, 245, 265, "Decision", "BoardDecision");

            //Create and Add project Node 
            NodeViewModel Project = AddNode(160, 100, 245, 420, "Decision", "project");

            //Create and Add End Node 
            NodeViewModel End = AddNode(120, 60, 245, 550, "Process", "End");

            //Create and Add Decision Node 
            NodeViewModel Decision = AddNode(200, 60, 500, 50, "Card", "Decision");

            //Create and Add Reject Node 
            NodeViewModel Reject = AddNode(150, 60, 465, 265, "Process", "Reject");

            //Create and Add Resources Node 
            NodeViewModel Resources = AddNode( 150, 60, 465, 420, "Process", "Resources");

            ///Add and Creating Connectors
            //Create Connections between NewIdea Node and Meeting Node
            AddConnector(NewIdea, Meeting, "");

            //Create Connections between Meeting Node and BoardDecision Node
            AddConnector(Meeting, BoardDecision, "");

            //Create Connections between BoardDecision Node and Reject Node
            AddConnector(BoardDecision, Reject, "No");

            //Create Connections between BoardDecision Node and Project Node
            AddConnector(BoardDecision, Project, "Yes");

            //Create Connections between Project Node and Resources Node
            AddConnector(Project, Resources, "No");

            //Create Connections between Project Node and End Node
            AddConnector(Project, End, "Yes");
        }

        //Create and Add Nodes
        private NodeViewModel AddNode(double width, double height, double offsetx, double offsety, string shape, string text)
        {
            NodeViewModel node = new NodeViewModel();
            node.UnitWidth = width;
            node.UnitHeight = height;
            node.OffsetX = offsetx;
            node.OffsetY = offsety;
            node.Annotations = new ObservableCollection<IAnnotation>()
            {
                new TextAnnotationViewModel()
                {
                    Text = manager.GetString(text),
                    ReadOnly = true,
                    RotationReference= Syncfusion.UI.Xaml.Diagram.RotationReference.Page,
                    TextWrapping=TextWrapping.Wrap,
                    TextHorizontalAlignment=TextAlignment.Center,
                    TextVerticalAlignment=VerticalAlignment.Center,
                    UnitWidth=90,
                    FontFamily = new FontFamily("Calibri"),
                }
            };
            node.Shape = Application.Current.Resources[shape];
            (diagram.Nodes as ObservableCollection<NodeViewModel>).Add(node);
            return node;
        }

        //Create and Add Connectors
        private void AddConnector(NodeViewModel sourceNode, NodeViewModel targetNode, string text)
        {
            TextAnnotationViewModel textannotation = new TextAnnotationViewModel();
            if (text == "Yes")
            {
                textannotation.Text = manager.GetString(text);
                textannotation.ReadOnly = true;
                textannotation.RotationReference = Syncfusion.UI.Xaml.Diagram.RotationReference.Page;
                textannotation.TextHorizontalAlignment = TextAlignment.Center;
                textannotation.TextVerticalAlignment = VerticalAlignment.Center;
                textannotation.Margin = new Thickness(10, 0, 0, 0);
            }
            else
            {
                textannotation.Text = manager.GetString(text);
                textannotation.ReadOnly = true;
                textannotation.RotationReference = Syncfusion.UI.Xaml.Diagram.RotationReference.Page;
                textannotation.TextHorizontalAlignment = TextAlignment.Center;
                textannotation.TextVerticalAlignment = VerticalAlignment.Center;
                textannotation.Margin = new Thickness(0, 10, 0, 0);
            }

            ConnectorViewModel connector = new ConnectorViewModel();
            connector.SourceNode = sourceNode;
            connector.TargetNode = targetNode;
            connector.Annotations = new ObservableCollection<IAnnotation>()
            {
                textannotation
            };
            (diagram.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector);
        }
    }
}
