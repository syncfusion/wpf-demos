#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
using System.Windows.Controls;
using System.Windows.Media;

namespace syncfusion.diagrambuilder.wpf.LogicCircuit
{
    public class LogicCircuitDiagramVM : DiagramViewModel
    {
        private DataTemplate nodeTemplatePath;

        ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/syncfusion.diagrambuilder.wpf;component/LogicCircuit/LogicCircuitResources.xaml", UriKind.RelativeOrAbsolute)
        };

        public LogicCircuitDiagramVM()
        {
            PortVisibility = PortVisibility.Visible;
            DefaultConnectorType = ConnectorType.Orthogonal;
            Nodes = new NodeCollection();
            Connectors = new ConnectorCollection();
            HorizontalRuler = new Ruler();
            VerticalRuler = new Ruler() { Orientation = Orientation.Vertical };
            Constraints |= GraphConstraints.Undoable | GraphConstraints.AllowPan | GraphConstraints.Bridging;
            SelectedItems = new SelectorViewModel()
            {
                SelectorConstraints = SelectorConstraints.Default & ~SelectorConstraints.Resizer,
            };
            PageSettings = new PageSettings();
            SnapSettings = new SnapSettings()
            {
                SnapConstraints = SnapConstraints.ShowLines,
                SnapToObject = SnapToObject.All,
            };
            DragEnterCommand = new DelegateCommand(OnDragEnterCommand);
            DragOverCommand = new DelegateCommand(OnDragOverCommand);
            ItemAddedCommand = new DelegateCommand(OnItemAddedCommand);
            DropCommand = new DelegateCommand(OnDropCommand);
        }

        public void OnDragOverCommand(object parameter)
        {
            ItemDropEventArgs args = parameter as ItemDropEventArgs;
            if (args != null)
            {
                if (args.Source is NodeViewModel && ((args.Source as NodeViewModel).Shape == null) && ((args.Source as NodeViewModel).ContentTemplate) == null)
                {
                    string itemName = (args.Source as NodeViewModel).Name;
                    (args.Source as NodeViewModel).ContentTemplate = nodeTemplatePath;
                    UpdateShapeSize(itemName, args.Source as NodeViewModel);
                }
            }
        }

        private void UpdateShapeSize(string itemName, NodeViewModel nodeViewModel)
        {
            if (itemName != null)
            {
                switch (itemName)
                {
                    case "Toggle_switch":
                        nodeViewModel.UnitHeight = 52;
                        nodeViewModel.UnitWidth = 70.5;
                        break;
                    case "Push_button":
                        nodeViewModel.UnitHeight = 43;
                        nodeViewModel.UnitWidth = 71;
                        break;
                    case "Clock":
                        nodeViewModel.UnitHeight = 36;
                        nodeViewModel.UnitWidth = 72;
                        break;
                    case "High_Constant":
                        nodeViewModel.UnitHeight = 42;
                        nodeViewModel.UnitWidth = 70;
                        break;
                    case "LowConstant":
                        nodeViewModel.UnitHeight = 42;
                        nodeViewModel.UnitWidth = 70;
                        break;
                    case "LightBulb":
                        nodeViewModel.UnitHeight = 83;
                        nodeViewModel.UnitWidth = 38;
                        break;
                    case "4-BitDigit":
                        nodeViewModel.UnitHeight = 65;
                        nodeViewModel.UnitWidth = 80;
                        break;
                    case "Buffer":
                    case "NOTGate":
                    case "ANDGate":
                    case "NANDGate":
                    case "ORGate":
                    case "NORGate":
                        nodeViewModel.UnitHeight = 32;
                        nodeViewModel.UnitWidth = 89;
                        break;
                    case "XORGate":
                    case "XNORGate":
                        nodeViewModel.UnitHeight = 33.474;
                        nodeViewModel.UnitWidth = 89;
                        break;
                    case "Tri-State":
                        nodeViewModel.UnitHeight = 52.485;
                        nodeViewModel.UnitWidth = 89;
                        break;
                    case "SRFlip-Flop":
                        nodeViewModel.UnitHeight = 85;
                        nodeViewModel.UnitWidth = 136;
                        break;
                    case "DFlip-Flop":
                    case "TFlip-Flop":
                        nodeViewModel.UnitHeight = 127;
                        nodeViewModel.UnitWidth = 149;
                        break;
                    case "JKFlip-Flop":
                        nodeViewModel.UnitHeight = 145;
                        nodeViewModel.UnitWidth = 149;
                        break;
                    case "Label":
                        nodeViewModel.UnitHeight = 26;
                        nodeViewModel.UnitWidth = 36;
                        break;
                    case "Bus":
                        nodeViewModel.UnitHeight = 42;
                        nodeViewModel.UnitWidth = 99;
                        break;
                    case "PullUp":
                    case "PullDown":
                        nodeViewModel.UnitHeight = 52;
                        nodeViewModel.UnitWidth = 99;
                        break;
                }
            }
        }

        public void OnDragEnterCommand(object parameter)
        {
            nodeTemplatePath = null;
            if ((parameter as ItemDropEventArgs).Source is NodeViewModel)
            {
                string itemName = ((parameter as ItemDropEventArgs).Source as NodeViewModel).Name;
                switch (itemName)
                {
                    case "Toggle_switch":
                        nodeTemplatePath = resourceDictionary["Toggle_switchNode"] as DataTemplate;
                        break;
                    case "Push_button":
                        nodeTemplatePath = resourceDictionary["Push_buttonNode"] as DataTemplate;
                        break;
                    case "Clock":
                        nodeTemplatePath = resourceDictionary["ClockNode"] as DataTemplate;
                        break;
                    case "High_Constant":
                        nodeTemplatePath = resourceDictionary["High_ConstantNode"] as DataTemplate;
                        break;
                    case "LowConstant":
                        nodeTemplatePath = resourceDictionary["LowConstantNode"] as DataTemplate;
                        break;
                    case "LightBulb":
                        nodeTemplatePath = resourceDictionary["LightBulbNode"] as DataTemplate;
                        break;
                    case "4-BitDigit":
                        nodeTemplatePath = resourceDictionary["FourBitDigitNode"] as DataTemplate;
                        break;
                    case "Buffer":
                        nodeTemplatePath = resourceDictionary["BufferNode"] as DataTemplate;
                        break;
                    case "NOTGate":
                        nodeTemplatePath = resourceDictionary["NOTGateNode"] as DataTemplate;
                        break;
                    case "ANDGate":
                        nodeTemplatePath = resourceDictionary["ANDGateNode"] as DataTemplate;
                        break;
                    case "NANDGate":
                        nodeTemplatePath = resourceDictionary["NANDGateNode"] as DataTemplate;
                        break;
                    case "ORGate":
                        nodeTemplatePath = resourceDictionary["ORGateNode"] as DataTemplate;
                        break;
                    case "NORGate":
                        nodeTemplatePath = resourceDictionary["NORGateNode"] as DataTemplate;
                        break;
                    case "XORGate":
                        nodeTemplatePath = resourceDictionary["XORGateNode"] as DataTemplate;
                        break;
                    case "XNORGate":
                        nodeTemplatePath = resourceDictionary["XNORNode"] as DataTemplate;
                        break;
                    case "Tri-State":
                        nodeTemplatePath = resourceDictionary["Tri-StateNode"] as DataTemplate;
                        break;
                    case "SRFlip-Flop":
                        nodeTemplatePath = resourceDictionary["SRFlip-FlopNode"] as DataTemplate;
                        break;
                    case "DFlip-Flop":
                        nodeTemplatePath = resourceDictionary["DFlip-FlopNode"] as DataTemplate;
                        break;
                    case "JKFlip-Flop":
                        nodeTemplatePath = resourceDictionary["JKFlip-FlopNode"] as DataTemplate;
                        break;
                    case "TFlip-Flop":
                        nodeTemplatePath = resourceDictionary["TFlip-FlopNode"] as DataTemplate;
                        break;
                    case "Label":
                        nodeTemplatePath = resourceDictionary["LabelNode"] as DataTemplate;
                        break;
                    case "Bus":
                        nodeTemplatePath = resourceDictionary["BusNode"] as DataTemplate;
                        break;
                    case "PullUp":
                        nodeTemplatePath = resourceDictionary["PullUpNode"] as DataTemplate;
                        break;
                    case "PullDown":
                        nodeTemplatePath = resourceDictionary["PullDownNode"] as DataTemplate;
                        break;
                }
            }
        }

        public void OnDropCommand(object parameter)
        {
            if ((parameter as ItemDropEventArgs).Source is NodeViewModel && ((parameter as ItemDropEventArgs).Source as NodeViewModel).Name.ToString() == "Label")
            {
                ((parameter as ItemDropEventArgs).Source as NodeViewModel).ContentTemplate = null;
                nodeTemplatePath = null;
                //((parameter as ItemDropEventArgs).Source as NodeViewModel).UnitHeight = double.NaN;
                //((parameter as ItemDropEventArgs).Source as NodeViewModel).UnitWidth = double.NaN;
                ((parameter as ItemDropEventArgs).Source as NodeViewModel).Shape = resourceDictionary["Rectangle"];
                ((parameter as ItemDropEventArgs).Source as NodeViewModel).ShapeStyle = resourceDictionary["ShapeStyle"] as Style;
                ((parameter as ItemDropEventArgs).Source as NodeViewModel).Annotations = new AnnotationCollection()
                    {
                        new TextAnnotationViewModel()
                        {
                            Text = "Text",
                            Foreground = new System.Windows.Media.SolidColorBrush(Colors.Black),
                            FontSize = 16,
                            FontWeight = FontWeights.Bold,
                        }
                    };
            }
        }

        public void OnItemAddedCommand(object parameter)
        {
            if ((parameter as ItemAddedEventArgs).Item is NodeViewModel)
            {
                NodeViewModel node = (parameter as ItemAddedEventArgs).Item as NodeViewModel;
                node.Constraints = NodeConstraints.Default & ~NodeConstraints.Connectable;
                foreach (NodePortViewModel nodeport in ((parameter as ItemAddedEventArgs).Item as NodeViewModel).Ports as PortCollection)
                {
                    nodeport.Constraints = PortConstraints.Default & ~PortConstraints.InheritConnectable | PortConstraints.Connectable;
                }
                string itemName = ((parameter as ItemAddedEventArgs).Item as NodeViewModel).Name;
                if (itemName != null && ((parameter as ItemAddedEventArgs).Item is NodeViewModel))
                {
                    if((parameter as ItemAddedEventArgs).ItemSource == ItemSource.Stencil)
                    {
                        if (((parameter as ItemAddedEventArgs).Item as NodeViewModel).ContentTemplate != null)
                        {
                            return;
                        }
                        else
                        {
                            this.UpdateShapeSize(itemName, (parameter as ItemAddedEventArgs).Item as NodeViewModel);
                        }
                    }

                    switch (itemName)
                    {
                        case "Toggle_switch":
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).ContentTemplate = resourceDictionary["Toggle_switchNode"] as DataTemplate;
                            break;
                        case "Push_button":
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).ContentTemplate = resourceDictionary["Push_buttonNode"] as DataTemplate;
                            break;
                        case "Clock":
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).ContentTemplate = resourceDictionary["ClockNode"] as DataTemplate;
                            break;
                        case "High_Constant":
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).ContentTemplate = resourceDictionary["High_ConstantNode"] as DataTemplate;
                            break;
                        case "LowConstant":
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).ContentTemplate = resourceDictionary["LowConstantNode"] as DataTemplate;
                            break;
                        case "LightBulb":
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).ContentTemplate = resourceDictionary["LightBulbNode"] as DataTemplate;
                            break;
                        case "4-BitDigit":
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).ContentTemplate = resourceDictionary["FourBitDigitNode"] as DataTemplate;
                            break;
                        case "Buffer":
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).ContentTemplate = resourceDictionary["BufferNode"] as DataTemplate;
                            break;
                        case "NOTGate":
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).ContentTemplate = resourceDictionary["NOTGateNode"] as DataTemplate;
                            break;
                        case "ANDGate":
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).ContentTemplate = resourceDictionary["ANDGateNode"] as DataTemplate;
                            break;
                        case "NANDGate":
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).ContentTemplate = resourceDictionary["NANDGateNode"] as DataTemplate;
                            break;
                        case "ORGate":
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).ContentTemplate = resourceDictionary["ORGateNode"] as DataTemplate;
                            break;
                        case "NORGate":
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).ContentTemplate = resourceDictionary["NORGateNode"] as DataTemplate;
                            break;
                        case "XORGate":
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).ContentTemplate = resourceDictionary["XORGateNode"] as DataTemplate;
                            break;
                        case "XNORGate":
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).ContentTemplate = resourceDictionary["XNORGateNode"] as DataTemplate;
                            break;
                        case "Tri-State":
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).ContentTemplate = resourceDictionary["Tri-StateNode"] as DataTemplate;
                            break;
                        case "SRFlip-Flop":
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).ContentTemplate = resourceDictionary["SRFlip-FlopNode"] as DataTemplate;
                            break;
                        case "DFlip-Flop":
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).ContentTemplate = resourceDictionary["DFlip-FlopNode"] as DataTemplate;
                            break;
                        case "JKFlip-Flop":
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).ContentTemplate = resourceDictionary["JKFlip-FlopNode"] as DataTemplate;
                            break;
                        case "TFlip-Flop":
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).ContentTemplate = resourceDictionary["TFlip-FlopNode"] as DataTemplate;
                            break;
                        case "Label":
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).Constraints = NodeConstraints.Default;
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).ContentTemplate = null;
                            string content = "";
                            foreach (IAnnotation annotation in ((parameter as ItemAddedEventArgs).Item as NodeViewModel).Annotations as ObservableCollection<IAnnotation>)
                            {
                                if (annotation is AnnotationEditorViewModel)
                                {
                                    if ((annotation as AnnotationEditorViewModel).Content != null)
                                    {
                                        content = (annotation as AnnotationEditorViewModel).Content.ToString();
                                    }
                                    else
                                    {
                                        content = "Text";
                                    }
                                }
                                else if (annotation is TextAnnotationViewModel)
                                {
                                    content = (annotation as TextAnnotationViewModel).Text;
                                }
                            }

                            nodeTemplatePath = null;
                            //((parameter as ItemAddedEventArgs).Item as NodeViewModel).UnitHeight = double.NaN;
                            //((parameter as ItemAddedEventArgs).Item as NodeViewModel).UnitWidth = double.NaN;
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).Shape = resourceDictionary["Rectangle"];
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).ShapeStyle = resourceDictionary["ShapeStyle"] as Style;
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).Annotations = new AnnotationCollection()
                        {
                            new TextAnnotationViewModel()
                            {
                                Text = content,
                                Foreground = new System.Windows.Media.SolidColorBrush(Colors.Black),
                                FontSize = 16,
                                FontWeight = FontWeights.Bold,
                            }
                        };
                            break;
                        case "Bus":
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).ContentTemplate = resourceDictionary["BusNode"] as DataTemplate;
                            break;
                        case "PullUp":
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).ContentTemplate = resourceDictionary["PullUpNode"] as DataTemplate;
                            break;
                        case "PullDown":
                            ((parameter as ItemAddedEventArgs).Item as NodeViewModel).ContentTemplate = resourceDictionary["PullDownNode"] as DataTemplate;
                            break;
                    }
                }
            }
        }
    }
}
