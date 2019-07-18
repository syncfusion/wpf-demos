#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace UseCaseSamples_IshikawaDiagram
{
    /// <summary>
    /// Create custom diagram class to create ishikawa sample
    /// </summary>
    public class IshikawaDiagram : DiagramViewModel
    {
        public IshikawaDiagram()
        {
            //create Ishikawa diagram sample
            CreateNodesAndConnectors();

            //Draggable and Selectable Constraints used to enable/disable the Dragging and Selection.
            Constraints = Constraints.Remove(GraphConstraints.Selectable, GraphConstraints.Draggable);
        }

        //Create Nodes and Connetors
        private void CreateNodesAndConnectors()
        {
            //Create and Add node which is source reference for center connector. It will not be visible
            NodeViewModel emptyNode = AddNode(20, 85, 60, 290, null, false, "TextNodesViewTemplate");

            //Create and Add node for HIGH PETROL CONSUMPTION IN BIKE Node
            NodeViewModel highPetrolConsumptionNode = AddNode(65, 160, 860, 290, "HIGH PETROL\nCONSUMPTION IN BIKE", true, "HighPetrolConsumptionViewTemplate");

            //Create and Add node for MACHINERY Node
            NodeViewModel machineryNode = AddNode(20, 85, 200, 70, "MACHINERY", false, "TextNodesViewTemplate");

            //Create and Add node for METHOD Node
            NodeViewModel methodNode = AddNode(20, 85, 410, 70, "METHOD", false, "TextNodesViewTemplate");

            //Create and Add node for PEOPLE Node
            NodeViewModel peopleNode = AddNode(20, 85, 620, 70, "PEOPLE", false, "TextNodesViewTemplate");

            //Create and Add node for MATERIAL Node
            NodeViewModel materialNode = AddNode(20, 85, 180, 510, "MATERIAL", false, "TextNodesViewTemplate");

            //Create and Add node for MEASUREMENT Node
            NodeViewModel measurmentNode = AddNode(20, 95, 390, 510, "MEASUREMENT", false, "TextNodesViewTemplate");

            //Create and Add node for ENVIRONMENT Node
            NodeViewModel enviromentNode = AddNode(20, 95, 610, 510, "ENVIRONMENT", false, "TextNodesViewTemplate");

            //Create lineconnector from emptyNode to highPetrolConsumptionNode
            ConnectorViewModel mainConnector = AddConnector(emptyNode, highPetrolConsumptionNode, null, null, new Point(0, 0), "",
                                                            new Thickness(0, 0, 0, 0));

            //create multiple ports in the mainConnector
            ConnectorPort machineryConnectorEndPort = AddPort(mainConnector, 0.25);
            ConnectorPort materialConnectorEndPort = AddPort(mainConnector, 0.28);
            ConnectorPort methodConnectorEndPort = AddPort(mainConnector, 0.58);
            ConnectorPort measurmentConnectorEndPort = AddPort(mainConnector, 0.60);
            ConnectorPort peopleConnectorEndPort = AddPort(mainConnector, 0.90);
            ConnectorPort enviromentConnectorPort = AddPort(mainConnector, 0.93);

            //Create connection between machineryNode and machineryConnectorEndPort
            ConnectorViewModel machineryConnector = AddConnector(machineryNode, null, machineryConnectorEndPort, mainConnector, new Point(0, 0), "",
                                                                 new Thickness(0, 0, 0, 0));

            //Create connection between materialNode and materialConnectorEndPort
            ConnectorViewModel materialConnector = AddConnector(materialNode, null, materialConnectorEndPort, mainConnector, new Point(0, 0), "",
                                                                new Thickness(0, 0, 0, 0));

            //Create connection between methodNode and methodConnectorEndPort
            ConnectorViewModel methodConnector = AddConnector(methodNode, null, methodConnectorEndPort, mainConnector, new Point(0, 0), "",
                                                              new Thickness(0, 0, 0, 0));

            //Create connection between measurmentNode and measurmentConnectorEndPort
            ConnectorViewModel measurmentConnector = AddConnector(measurmentNode, null, measurmentConnectorEndPort, mainConnector, new Point(0, 0), "",
                                                                  new Thickness(0, 0, 0, 0));

            //Create connection between peopleNode and peopleConnectorEndPort
            ConnectorViewModel peopleConnector = AddConnector(peopleNode, null, peopleConnectorEndPort, mainConnector, new Point(0, 0), "",
                                                              new Thickness(0, 0, 0, 0));

            //Create connection between enviromentNode and enviromentConnectorPort
            ConnectorViewModel enviromentConnector = AddConnector(enviromentNode, null, enviromentConnectorPort, mainConnector, new Point(0, 0), "",
                                                                    new Thickness(0, 0, 0, 0));

            //Create end point port for Worn-Out Pistons connector
            ConnectorPort WornOutPistonsPort = AddPort(machineryConnector, 0.25);

            //Create connector for Worn-Out Pistons
            ConnectorViewModel WornOutPistonsConnector = AddConnector(null, null, WornOutPistonsPort, machineryConnector, new Point(70, 133),
                                                                      "Worn-out Pistons", new Thickness(50, 15, 0, 0));

            //Create end point port for Wrong Tire Pressure Connector
            ConnectorPort WrongTirePressurePort = AddPort(machineryConnector, 0.54);

            //Create connector for Wrong Tire Pressure
            ConnectorViewModel WrongTirePressureConnector = AddConnector(null, null, WrongTirePressurePort, machineryConnector, new Point(80, 193),
                                                                         "Wrong Tire Pressure", new Thickness(55, 15, 0, 0));

            //Create end point port for Fast Driving Connector
            ConnectorPort FastDrivingPort = AddPort(methodConnector, 0.25);

            //Create connector for Fast Driving
            ConnectorViewModel FastDrivingConnector = AddConnector(null, null, FastDrivingPort, methodConnector, new Point(305, 133), "Fast Driving",
                                                                   new Thickness(35, 15, 0, 0));

            //Create end point port for Wrong Gear Connector
            ConnectorPort WrongGearPort = AddPort(methodConnector, 0.54);

            //Create connector for Wrong Gear
            ConnectorViewModel WrongGearConnector = AddConnector(null, null, WrongGearPort, methodConnector, new Point(330, 193), "Wrong Gear",
                                                                 new Thickness(35, 15, 0, 0));

            //Create end point port for Maintenance Habit Connector
            ConnectorPort MaintenanceHabitPort = AddPort(peopleConnector, 0.55);

            //Create connector for Maintenance Habit
            ConnectorViewModel MaintenanceHabitConnector = AddConnector(null, null, MaintenanceHabitPort, peopleConnector, new Point(510, 193),
                                                                        "Maintenance Habit", new Thickness(50, 15, 0, 0));

            //Create end point port for No Owner Manual Connector
            ConnectorPort NoOwnerManualConnectorPort = AddPort(MaintenanceHabitConnector, 0.77);

            //Create connector for No Owner Manual
            ConnectorViewModel NoOwnerManualConnector = AddConnector(null, null, NoOwnerManualConnectorPort, MaintenanceHabitConnector,
                                                                     new Point(600, 155), "No Owner Manual", new Thickness(0, 0, 20, 10));

            //Create end point port for Poor Quality Petrol Connector
            ConnectorPort PoorQualityPetrolPort = AddPort(materialConnector, 0.73);

            //Create connector for Poor Quality Petrol
            ConnectorViewModel PoorQualityPetrolConnector = AddConnector(null, null, PoorQualityPetrolPort, materialConnector, new Point(75, 345),
                                                                         "Poor Quality Petrol", new Thickness(50, 15, 0, 0));

            //Create end point port for FastDrivingConnector
            ConnectorPort IncorrectLubricantPort = AddPort(materialConnector, 0.26);

            //Create connector for Incorrect Lubricant
            ConnectorViewModel IncorrectLubricantConnector = AddConnector(null, null, IncorrectLubricantPort, materialConnector, new Point(70, 443),
                                                                          "Incorrect Lubricant", new Thickness(50, 15, 0, 0));

            //Create end point port for Wrong Oil Connector
            ConnectorPort WrongOilPort = AddPort(IncorrectLubricantConnector, 0.73);

            //Create connector for Wrong Oil
            ConnectorViewModel WrongOilConnector = AddConnector(null, null, WrongOilPort, WrongGearConnector, new Point(145, 410), "Wrong Oil",
                                                                new Thickness(0, 0, 10, 10));

            //Create end point port for Reset Odometer Connector
            ConnectorPort ResetOdometerPort = AddPort(measurmentConnector, 0.6);

            //Create connector for Reset Odometer
            ConnectorViewModel ResetOdometerConnector = AddConnector(null, null, ResetOdometerPort, measurmentConnector,
                new Point(300, 373), "Do not Reset\nOdometer Properly", new Thickness(50, 25, 0, 0));

            //Create end point port for Extreme Weather Conditions Connector
            ConnectorPort ExtremeWeatherConditionsPort = AddPort(enviromentConnector, 0.6);

            //Create connector for Extreme Weather Conditions 
            ConnectorViewModel ExtremeWeatherConditionsConnector = AddConnector(null, null, ExtremeWeatherConditionsPort, enviromentConnector,
                                                                   new Point(520, 373), "Extreme Weather\nConditions", new Thickness(45, 25, 0, 0));
        }

        //Create and add port for connector
        private ConnectorPort AddPort(ConnectorViewModel connector, double length)
        {
            ConnectorPort port = new ConnectorPort()
            {
                Width = 10,
                Height = 10,
                Length = length,
                Connector = connector,
                Shape = new EllipseGeometry() { RadiusX = 5, RadiusY = 5 },
                PortVisibility = PortVisibility.Visible,
                Constraints = PortConstraints.Default & ~PortConstraints.Inherit
            };
            (connector.Ports as ICollection<IConnectorPort>).Add(port);
            return port;
        }

        //Create and add Connector 
        private ConnectorViewModel AddConnector(NodeViewModel sourceNode, NodeViewModel targetNode, ConnectorPort targetPort,
                                                ConnectorViewModel targetConnector, Point sourcepoint, string content, Thickness margin)
        {
            ConnectorViewModel connector = new ConnectorViewModel();
            connector.Ports = new ObservableCollection<IConnectorPort>();
            //To Represent Annotation Properties
            connector.Annotations = new ObservableCollection<IAnnotation>()
            {
                new AnnotationEditorViewModel()
                {
                    Content = content,
                    Length=0,
                    Margin = margin,
                    ReadOnly = true,
                    RotationReference= RotationReference.Page,
                }
            };

            if (targetNode == null)
            {
                if (!Point.Equals(sourcepoint, new Point(0, 0)))
                {
                    connector.SourcePoint = sourcepoint;
                }
                else
                {
                    connector.SourceNode = sourceNode;
                }
                connector.TargetPort = targetPort;
                connector.TargetConnector = targetConnector;
            }
            else
            {
                connector.SourceNode = sourceNode;
                connector.TargetNode = targetNode;
                connector.TargetConnector = targetConnector;
            }

            (Connectors as ICollection<ConnectorViewModel>).Add(connector);

            //Selectable Constraints used to enable/disable the ConnectorViewModel Selection.
            connector.Constraints = connector.Constraints & ~ConnectorConstraints.Selectable;
            return connector;
        }

        //Add and create Nodes
        private NodeViewModel AddNode(double height, double width, double offx, double offy, string label, bool isTagertNode, string viewTemplate)
        {
            NodeViewModel node = new NodeViewModel();
            node.UnitHeight = height;
            node.UnitWidth = width;
            node.OffsetX = offx;
            node.OffsetY = offy;
            node.Shape = new RectangleGeometry() { Rect = new Rect(50, 50, 50, 50) };

            //Apply shape style for HIGH PETROL CONSUMPTION IN BIKE Node alone to differentiate from other text Nodes
            if (isTagertNode)
            {
                node.ShapeStyle = App.Current.Resources["NodeStyle"] as Style;
            }

            //To Represent Annotation Properties
            node.Annotations = new ObservableCollection<IAnnotation>()
            {
                new AnnotationEditorViewModel()
                {
                    Content = label,
                    ReadOnly = true,
                    ViewTemplate = App.Current.Resources[viewTemplate] as DataTemplate,
                },
            };

            (Nodes as ObservableCollection<NodeViewModel>).Add(node);
            return node;
        }
    }
}
