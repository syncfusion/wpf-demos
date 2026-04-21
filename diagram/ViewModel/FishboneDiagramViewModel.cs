#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace syncfusion.diagramdemos.wpf.ViewModel
{
    public class FishboneDiagramViewModel : DiagramViewModel
    {
        public DemoControl View;

        public FishboneDiagramViewModel(DemoControl demo)
        {
            View = demo;

            Tool = Tool.ZoomPan;
            DefaultConnectorType = ConnectorType.Line;

            //Creating Nodes
            NodeViewModel collate1 = CreateNodes(50, 50, 175, 425, "Ellipse", "NodeBlueStyle", "");
            NodeViewModel collate2 = CreateNodes(50, 50, 465, 425, "Ellipse", "NodeBlueStyle", "");
            NodeViewModel collate3 = CreateNodes(50, 50, 695, 425, "Ellipse", "NodeBlueStyle", "");
            NodeViewModel collate4 = CreateNodes(50, 50, 965, 425, "Ellipse", "NodeBlueStyle", "");
            NodeViewModel Productivity = CreateNodes(150, 65, 1155, 425, "Ellipse", "NodeBlueStyle", "Productivity Increase");
            NodeViewModel Equipement = CreateNodes(120, 40, 350, 130, "Paralleogram", "NodeBlueStyle", "Equipement");
            NodeViewModel Environment = CreateNodes(120, 40, 550, 130, "Paralleogram", "NodeBlueStyle", "Environment");
            NodeViewModel Person = CreateNodes(120, 40, 750, 130, "Paralleogram", "NodeBlueStyle", "Person");
            NodeViewModel Methods = CreateNodes(120, 40, 350, 700, "Paralleogram", "NodeBlueStyle", "Methods");
            NodeViewModel Machines = CreateNodes(120, 40, 550, 700, "Paralleogram", "NodeBlueStyle", "Machines");
            NodeViewModel Materials = CreateNodes(120, 40, 750, 700, "Paralleogram", "NodeBlueStyle", "Materials");
            NodeViewModel TextProgramsCollate = CreateNodes(20, 20, 350, 200, "Ellipse", "NodeTransparentStyle", "");
            NodeViewModel VentilatorsSoundCollate = CreateNodes(20, 20, 550, 200, "Ellipse", "NodeTransparentStyle", "");
            NodeViewModel EducationCollate = CreateNodes(20, 20, 750, 200, "Ellipse", "NodeTransparentStyle", "");
            NodeViewModel SoftwareCollate = CreateNodes(20, 20, 350, 600, "Ellipse", "NodeTransparentStyle", "");
            NodeViewModel ProcurementCollate = CreateNodes(20, 20, 550, 600, "Ellipse", "NodeTransparentStyle", "");
            NodeViewModel StandardizationCollate = CreateNodes(20, 20, 750, 600, "Ellipse", "NodeTransparentStyle", "");
            NodeViewModel DataBooksCollate = CreateNodes(20, 20, 380, 275, "Ellipse", "NodeTransparentStyle", "");
            NodeViewModel NoiseCollate = CreateNodes(20, 20, 580, 275, "Ellipse", "NodeTransparentStyle", "");
            NodeViewModel MotivationCollate = CreateNodes(20, 20, 780, 275, "Ellipse", "NodeTransparentStyle", "");
            NodeViewModel FixturesCollate = CreateNodes(20, 20, 420, 350, "Ellipse", "NodeTransparentStyle", "");
            NodeViewModel TirednessCollate = CreateNodes(20, 20, 620, 350, "Ellipse", "NodeTransparentStyle", "");
            NodeViewModel StorerCollate = CreateNodes(20, 20, 845, 345, "Ellipse", "NodeTransparentStyle", "");
            NodeViewModel ComputerCollate = CreateNodes(20, 20, 400, 540, "Ellipse", "NodeTransparentStyle", "");
            NodeViewModel QualityCollate = CreateNodes(20, 20, 600, 540, "Ellipse", "NodeTransparentStyle", "");
            NodeViewModel OrderCollate = CreateNodes(20, 20, 800, 540, "Ellipse", "NodeTransparentStyle", "");

            //Adding nodes into NodesCollection
            (Nodes as NodeCollection).Add(collate1);
            (Nodes as NodeCollection).Add(collate2);
            (Nodes as NodeCollection).Add(collate3);
            (Nodes as NodeCollection).Add(collate4);
            (Nodes as NodeCollection).Add(Productivity);
            (Nodes as NodeCollection).Add(Equipement);
            (Nodes as NodeCollection).Add(Environment);
            (Nodes as NodeCollection).Add(Person);
            (Nodes as NodeCollection).Add(Methods);
            (Nodes as NodeCollection).Add(Machines);
            (Nodes as NodeCollection).Add(Materials);
            (Nodes as NodeCollection).Add(TextProgramsCollate);
            (Nodes as NodeCollection).Add(VentilatorsSoundCollate);
            (Nodes as NodeCollection).Add(EducationCollate);
            (Nodes as NodeCollection).Add(SoftwareCollate);
            (Nodes as NodeCollection).Add(ProcurementCollate);
            (Nodes as NodeCollection).Add(StandardizationCollate);
            (Nodes as NodeCollection).Add(DataBooksCollate);
            (Nodes as NodeCollection).Add(NoiseCollate);
            (Nodes as NodeCollection).Add(MotivationCollate);
            (Nodes as NodeCollection).Add(FixturesCollate);
            (Nodes as NodeCollection).Add(TirednessCollate);
            (Nodes as NodeCollection).Add(StorerCollate);
            (Nodes as NodeCollection).Add(ComputerCollate);
            (Nodes as NodeCollection).Add(QualityCollate);
            (Nodes as NodeCollection).Add(OrderCollate);

            //Creating connectors
            CreateConnectors(collate1, collate2, "DashedGeometryStyle1", "");
            CreateConnectors(collate2, collate3, "DashedGeometryStyle1", "");
            CreateConnectors(collate3, collate4, "DashedGeometryStyle1", "");
            CreateConnectors(collate4, Productivity, "DashedGeometryStyle1", "");
            CreateConnectors(TextProgramsCollate, DataBooksCollate, "DashedGeometryStyle2", "");
            CreateConnectors(DataBooksCollate, FixturesCollate, "DashedGeometryStyle2", "");
            CreateConnectors(FixturesCollate, collate2, "DashedGeometryStyle2", "");
            CreateConnectors(VentilatorsSoundCollate, NoiseCollate, "DashedGeometryStyle2", "");
            CreateConnectors(NoiseCollate, TirednessCollate, "DashedGeometryStyle2", "");
            CreateConnectors(TirednessCollate, collate3, "DashedGeometryStyle2", "");
            CreateConnectors(EducationCollate, MotivationCollate, "DashedGeometryStyle2", "");
            CreateConnectors(MotivationCollate, StorerCollate, "DashedGeometryStyle2", "");
            CreateConnectors(StorerCollate, collate4, "DashedGeometryStyle2", "");
            CreateConnectors(SoftwareCollate, ComputerCollate, "DashedGeometryStyle2", "");
            CreateConnectors(ComputerCollate, collate2, "DashedGeometryStyle2", "");
            CreateConnectors(ProcurementCollate, QualityCollate, "DashedGeometryStyle2", "");
            CreateConnectors(QualityCollate, collate3, "DashedGeometryStyle2", "");
            CreateConnectors(StandardizationCollate, OrderCollate, "DashedGeometryStyle2", "");
            CreateConnectors(OrderCollate, collate4, "DashedGeometryStyle2", "");
            CreateConnectors(Equipement, TextProgramsCollate, "DashedGeometryStyle3", "TargetDecoratorStyle3");
            CreateConnectors(Environment, VentilatorsSoundCollate, "DashedGeometryStyle3", "TargetDecoratorStyle3");
            CreateConnectors(Person, EducationCollate, "DashedGeometryStyle3", "TargetDecoratorStyle3");
            CreateConnectors(Methods, SoftwareCollate, "DashedGeometryStyle3", "TargetDecoratorStyle3");
            CreateConnectors(Machines, ProcurementCollate, "DashedGeometryStyle3", "TargetDecoratorStyle3");
            CreateConnectors(Materials, StandardizationCollate, "DashedGeometryStyle3", "TargetDecoratorStyle3");
            CreateConnectorsWithSourcePoint(new Point(250, 200), TextProgramsCollate, "DashedGeometryStyle4", "TargetDecoratorStyle3", "Text Programs", new Thickness(-90, 0, 0, 0));
            CreateConnectorsWithSourcePoint(new Point(485, 200), VentilatorsSoundCollate, "DashedGeometryStyle4", "TargetDecoratorStyle3", "Ventilators Sound", new Thickness(-78, 0, 0, 0));
            CreateConnectorsWithSourcePoint(new Point(680, 200), EducationCollate, "DashedGeometryStyle4", "TargetDecoratorStyle3", "Education", new Thickness(-66, 0, 0, 0));
            CreateConnectorsWithSourcePoint(new Point(310, 275), DataBooksCollate, "DashedGeometryStyle4", "TargetDecoratorStyle3", "Data Books", new Thickness(-69, 0, 0, 0));
            CreateConnectorsWithSourcePoint(new Point(510, 275), NoiseCollate, "DashedGeometryStyle4", "TargetDecoratorStyle3", "Noise", new Thickness(-50, 0, 0, 0));
            CreateConnectorsWithSourcePoint(new Point(710, 275), MotivationCollate, "DashedGeometryStyle4", "TargetDecoratorStyle3", "Motivation", new Thickness(-65, 0, 0, 0));
            CreateConnectorsWithSourcePoint(new Point(320, 350), FixturesCollate, "DashedGeometryStyle4", "TargetDecoratorStyle3", "Fixtures", new Thickness(-70, 0, 0, 0));
            CreateConnectorsWithSourcePoint(new Point(520, 350), TirednessCollate, "DashedGeometryStyle4", "TargetDecoratorStyle3", "Tiredness", new Thickness(-75, 0, 0, 0));
            CreateConnectorsWithSourcePoint(new Point(730, 345), StorerCollate, "DashedGeometryStyle4", "TargetDecoratorStyle3", "Storer", new Thickness(-75, 0, 0, 0));
            CreateConnectorsWithSourcePoint(new Point(250, 600), SoftwareCollate, "DashedGeometryStyle4", "TargetDecoratorStyle3", "Software", new Thickness(-75, 0, 0, 0));
            CreateConnectorsWithSourcePoint(new Point(470, 600), ProcurementCollate, "DashedGeometryStyle4", "TargetDecoratorStyle3", "Procurement", new Thickness(-80, 0, 0, 0));
            CreateConnectorsWithSourcePoint(new Point(680, 600), StandardizationCollate, "DashedGeometryStyle4", "TargetDecoratorStyle3", "Standardization", new Thickness(-75, 0, 0, 0));
            CreateConnectorsWithSourcePoint(new Point(300, 540), ComputerCollate, "DashedGeometryStyle4", "TargetDecoratorStyle3", "Computer", new Thickness(-80, 0, 0, 0));
            CreateConnectorsWithSourcePoint(new Point(530, 540), QualityCollate, "DashedGeometryStyle4", "TargetDecoratorStyle3", "Quality of Element", new Thickness(-85, 0, 0, 0));
            CreateConnectorsWithSourcePoint(new Point(730, 540), OrderCollate, "DashedGeometryStyle4", "TargetDecoratorStyle3", "Order", new Thickness(-50, 0, 0, 0));
        }

        /// <summary>
        /// Method to create Nodes using NodeViewModel class.
        /// </summary>
        /// <param name="unitWidth">Node's width</param>
        /// <param name="unitHeight">Node's height</param>
        /// <param name="offsetX">Node's offset x value</param>
        /// <param name="offsetY">Node's offset y value</param>
        /// <param name="shape">Shape of the node</param>
        /// <param name="shapeStyle">Shape style of the node</param>
        /// <param name="label">Lable for the node</param>
        /// <returns></returns>
        private NodeViewModel CreateNodes(double unitWidth, double unitHeight, double offsetX, double offsetY, string shape, string shapeStyle, string label)
        {
            //Creating node
            NodeViewModel node = new NodeViewModel()
            {
                //Size of the node
                UnitWidth = unitWidth,
                UnitHeight = unitHeight,
                //Positioning the node
                OffsetX = offsetX,
                OffsetY = offsetY,
                //shape and style for the node
                Shape = View.Resources[shape],
                ShapeStyle = View.Resources[shapeStyle] as Style,
                //Initialize the annotation collection.
                Annotations = new AnnotationCollection()
                {
                    new AnnotationEditorViewModel()
                    {
                        //Adding label to the node.
                        Content = label,
                        Foreground = new SolidColorBrush(Colors.White),
                    }
                }
            };

            return node;
        }

        /// <summary>
        /// Method to create the connectors.
        /// </summary>
        /// <param name="sourceNode">Source node of the connector</param>
        /// <param name="targetNode">Target node of the connector</param>
        /// <param name="connectorGeometryPathStyle">Connector geometry path style</param>
        /// <param name="targetDecoratorStyle">Connector target decorator style</param>
        private void CreateConnectors(NodeViewModel sourceNode, NodeViewModel targetNode, string connectorGeometryPathStyle, string targetDecoratorStyle)
        {
            //Create connectors
            ConnectorViewModel connector = new ConnectorViewModel()
            {
                SourceNode = sourceNode,
                TargetNode = targetNode,
                ConnectorGeometryStyle = View.Resources[connectorGeometryPathStyle] as Style,
                //TargetDecoratorStyle = View.Resources[targetDecoratorStyle] as Style,
            };

            //Adding connector into conector collection
            (Connectors as ConnectorCollection).Add(connector);
        }

        /// <summary>
        /// Method to create connector with source point.
        /// </summary>
        /// <param name="sourcePoint">Source point of the connector</param>
        /// <param name="targetNode">Traget node of the connector</param>
        /// <param name="connectorGeometryPathStyle">Connector geometry path style</param>
        /// <param name="targetDecoratorStyle">Connector target path style</param>
        /// <param name="label">Lable of the connector</param>
        /// <param name="margin">Margin of the label added to the connector</param>
        private void CreateConnectorsWithSourcePoint(Point sourcePoint, NodeViewModel targetNode, string connectorGeometryPathStyle, string targetDecoratorStyle, string label, Thickness margin)
        {
            //Creating the connector
            ConnectorViewModel connector = new ConnectorViewModel()
            {
                SourcePoint = sourcePoint,
                TargetNode = targetNode,
                ConnectorGeometryStyle = View.Resources[connectorGeometryPathStyle] as Style,
                TargetDecoratorStyle = View.Resources[targetDecoratorStyle] as Style,
                Annotations = new AnnotationCollection()
                {
                    new AnnotationEditorViewModel()
                    {
                        Content = label,
                        Alignment = Syncfusion.UI.Xaml.Diagram.Controls.ConnectorAnnotationAlignment.Source,
                        Margin = margin,
                        Foreground = new SolidColorBrush(Colors.Black),
                    }
                }
            };

            //adding connector to the connector collection.
            (Connectors as ConnectorCollection).Add(connector);
        }

    }
}
