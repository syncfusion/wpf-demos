using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.UI.Xaml.Diagram;
using System.Windows;
using System.Windows.Controls;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;
using Syncfusion.UI.Xaml.Diagram.Theming;

namespace syncfusion.diagrambuilder.wpf.Network
{
    public class NetworkDiagramVM : DiagramViewModel
    {
        private DataTemplate nodeTemplatePath;
        double src;
        double target;

        ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/syncfusion.diagrambuilder.wpf;component/Network/NetworkDiagramResources.xaml", UriKind.RelativeOrAbsolute)
        };

        public NetworkDiagramVM()
        {
            DefaultConnectorType = ConnectorType.Line;
            PortVisibility = PortVisibility.Visible;
            Nodes = new NodeCollection();
            Connectors = new ConnectorCollection();
            Groups = new GroupCollection();
            PageSettings = new PageSettings();
            HorizontalRuler = new Ruler();
            VerticalRuler = new Ruler() { Orientation = Orientation.Vertical };
            Constraints |= GraphConstraints.Undoable;
            AnnotationConstraints |= AnnotationConstraints.Selectable | AnnotationConstraints.Draggable | AnnotationConstraints.Editable | AnnotationConstraints.Resizable;
            SelectedItems = new SelectorViewModel();
            SnapSettings = new SnapSettings()
            {
                SnapConstraints = SnapConstraints.ShowLines | SnapConstraints.SnapToLines,
                SnapToObject = SnapToObject.All,
            };
            DragEnterCommand = new DelegateCommand(OnDragEnterCommand);
            DragOverCommand = new DelegateCommand(OnDragOverCommand);
            ItemAddedCommand = new DelegateCommand(OnItemAddedCommand);
            DropCommand = new DelegateCommand(OnDropCommand);
        }

        public void OnItemAddedCommand(object parameter)
        {
            if ((parameter as ItemAddedEventArgs).Item is NodeViewModel)
            {
                string itemName = ((parameter as ItemAddedEventArgs).Item as NodeViewModel).Name;
                if (itemName != null && (parameter as ItemAddedEventArgs).Item is NodeViewModel)
                {
                    if ((parameter as ItemAddedEventArgs).ItemSource == ItemSource.Stencil)
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
                        case "PC":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["PCNode"] as DataTemplate;
                            break;
                        case "VirtualPC":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["VirtualPCNode"] as DataTemplate;
                            break;
                        case "Terminal":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["TerminalNode"] as DataTemplate;
                            break;
                        case "Wavelength":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["WavelengthNode"] as DataTemplate;
                            break;
                        case "DataPipe":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["DataPipeNode"] as DataTemplate;
                            break;
                        case "SlateDevice":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["SlateDivceNode"] as DataTemplate;
                            break;
                        case "TabletDevice":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["TabletDeviceNode"] as DataTemplate;
                            break;
                        case "Laptop":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["LaptopNode"] as DataTemplate;
                            break;
                        case "PDA":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["PDANode"] as DataTemplate;
                            break;
                        case "CRTMoniter":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["CRTMoniterNode"] as DataTemplate;
                            break;
                        case "Wireless":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["WirelessNode"] as DataTemplate;
                            break;
                        case "RingNetwork":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["RingNetworkNode"] as DataTemplate;
                            break;
                        case "Ethernet":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["EthernetNode"] as DataTemplate;
                            break;
                        case "Server":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["ServerNode"] as DataTemplate;
                            break;
                        case "Mainframe":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["MainframeNode"] as DataTemplate;
                            break;
                        case "Router":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["RouterNode"] as DataTemplate;
                            break;
                        case "Switch":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["SwitchNode"] as DataTemplate;
                            break;
                        case "Firewall":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["FirewallNode"] as DataTemplate;
                            break;
                        case "CommLink":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["CommLinkNode"] as DataTemplate;
                            break;
                        case "SuperComputer":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["SuperComputerNode"] as DataTemplate;
                            break;
                        case "Printer":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["PrinterNode"] as DataTemplate;
                            break;
                        case "VirtualServer":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["ServerNode"] as DataTemplate;
                            break;
                        case "Plotter":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["PlotterNode"] as DataTemplate;
                            break;
                        case "Scanner":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["ScannerNode"] as DataTemplate;
                            break;
                        case "Copier":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["CopierNode"] as DataTemplate;
                            break;
                        case "MultiFunction":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["MultiFunctionNode"] as DataTemplate;
                            break;
                        case "Fax":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["FaxNode"] as DataTemplate;
                            break;
                        case "Projector":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["ProjectorNode"] as DataTemplate;
                            break;
                        case "ProjectorScreen":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["ProjectorScreenNode"] as DataTemplate;
                            break;
                        case "Bridge":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["BridgeNode"] as DataTemplate;
                            break;
                        case "Hub":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["HubNode"] as DataTemplate;
                            break;
                        case "Modem":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["ModemNode"] as DataTemplate;
                            break;
                        case "Telephone":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["TelephoneNode"] as DataTemplate;
                            break;
                        case "CellPhone":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["CellPhoneNode"] as DataTemplate;
                            break;
                        case "SmartPhone":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["SmartPhoneNode"] as DataTemplate;
                            break;
                        case "VideoPhone":
                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["VideoPhoneNode"] as DataTemplate;
                            break;
                        case "DigitalCamera":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["DigitalCameraNode"] as DataTemplate;
                            break;
                        case "VideoCamera":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["VideoCameraNode"] as DataTemplate;
                            break;
                        case "ExternalMediaDevice":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["ExternalMediaDeviceNode"] as DataTemplate;
                            break;
                        case "User":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = resourceDictionary["UserNode"] as DataTemplate;
                            break;

                    }
                }
            }
        }

        public void OnDragOverCommand(object parameter)
        {
            ItemDropEventArgs args = parameter as ItemDropEventArgs;
            if (args != null)
            {
                string itemName = args.Source is NodeViewModel ? (args.Source as NodeViewModel).Name : null;
                if (args.Source is INode && ((args.Source as INode).Shape == null && (args.Source as INode).ContentTemplate == null))
                {
                    (args.Source as INode).ContentTemplate = nodeTemplatePath;
                    this.UpdateShapeSize(itemName, args.Source as INode);
                }
            }
        }

        private void UpdateShapeSize(string itemName, INode nodeViewModel)
        {
            if (itemName != null)
            {
                switch (itemName)
                {
                    case "PC":
                    case "VirtualPC":
                    case "Terminal":
                    case "Laptop":
                    case "CRTMoniter":
                    case "LCDMoniter":
                    case "SlateDevice":
                    case "TabletDevice":
                    case "RingNetwork":
                    case "Printer":
                    case "Firewall":
                    case "ProjectorScreen":

                        nodeViewModel.UnitWidth = 96;
                        nodeViewModel.UnitHeight = 96;
                        break;
                    case "Wavelength":
                    case "Ethernet":
                    case "Router":
                    case "Switch":
                    case "Scanner":
                        nodeViewModel.UnitWidth = 96;
                        nodeViewModel.UnitHeight = 56;
                        break;
                    case "Plotter":
                    case "Copier":
                    case "Fax":
                    case "MultiFunction":
                        nodeViewModel.UnitWidth = 96;
                        nodeViewModel.UnitHeight = 76;
                        break;
                    case "DataPipe":
                    case "CommLink":
                        nodeViewModel.UnitWidth = 96;
                        nodeViewModel.UnitHeight = 26;
                        break;
                    case "Wireless":
                    case "Server":
                    case "SuperComputer":
                    case "VirtualServer":
                        nodeViewModel.UnitWidth = 56;
                        nodeViewModel.UnitHeight = 96;
                        break;
                    case "PDA":
                    case "Mainframe":
                        nodeViewModel.UnitWidth = 76;
                        nodeViewModel.UnitHeight = 96;
                        break;
                    case "Projector":
                    case "Bridge":
                    case "Hub":
                    case "Modem":
                    case "DigitalCamera":
                    case "VideoCamera":
                    case "ExternalMediaDevice":
                        nodeViewModel.UnitWidth = 80;
                        nodeViewModel.UnitHeight = 40;
                        break;
                    case "Telephone":
                    case "CellPhone":
                        nodeViewModel.UnitWidth = 30;
                        nodeViewModel.UnitHeight = 80;
                        break;
                    case "SmartPhone":
                        nodeViewModel.UnitWidth = 35;
                        nodeViewModel.UnitHeight = 70;
                        break;
                    case "VideoPhone":
                        nodeViewModel.UnitWidth = 60;
                        nodeViewModel.UnitHeight = 70;
                        break;
                    case "User":
                        nodeViewModel.UnitWidth = 40;
                        nodeViewModel.UnitHeight = 70;
                        break;
                    case "Connector":
                        nodeViewModel.UnitWidth = 70;
                        nodeViewModel.UnitHeight = 72.5;
                        break;
                }
            }
        }

        public void OnDragEnterCommand(object parameter)
        {
            nodeTemplatePath = null;
            ItemDropEventArgs args = parameter as ItemDropEventArgs;
            string itemName = args.Source is NodeViewModel ? (args.Source as NodeViewModel).Name : null;
            if (args.Source is INode && (args.Source as INode).ContentTemplate != null)
            {
                if (itemName != null)
                {
                    switch (itemName)
                    {
                        case "PC":

                            nodeTemplatePath = resourceDictionary["PCNode"] as DataTemplate;
                            break;
                        case "VirtualPC":

                            nodeTemplatePath = resourceDictionary["VirtualPCNode"] as DataTemplate;
                            break;
                        case "Terminal":

                            nodeTemplatePath = resourceDictionary["TerminalNode"] as DataTemplate;
                            break;
                        case "Wavelength":

                            nodeTemplatePath = resourceDictionary["WavelengthNode"] as DataTemplate;
                            break;
                        case "DataPipe":

                            nodeTemplatePath = resourceDictionary["DataPipeNode"] as DataTemplate;
                            break;
                        case "SlateDevice":

                            nodeTemplatePath = resourceDictionary["SlateDivceNode"] as DataTemplate;
                            break;
                        case "TabletDevice":

                            nodeTemplatePath = resourceDictionary["TabletDeviceNode"] as DataTemplate;
                            break;
                        case "Laptop":

                            nodeTemplatePath = resourceDictionary["LaptopNode"] as DataTemplate;
                            break;
                        case "PDA":

                            nodeTemplatePath = resourceDictionary["PDANode"] as DataTemplate;
                            break;
                        case "CRTMoniter":

                            nodeTemplatePath = resourceDictionary["CRTMoniterNode"] as DataTemplate;
                            break;
                        case "LCDMoniter":

                            nodeTemplatePath = resourceDictionary["LCDMoniterNode"] as DataTemplate;
                            break;
                        case "Connector":

                            nodeTemplatePath = resourceDictionary["DynamicConnectorNode"] as DataTemplate;
                            break;
                        case "Wireless":

                            nodeTemplatePath = resourceDictionary["WirelessNode"] as DataTemplate;
                            break;
                        case "RingNetwork":

                            nodeTemplatePath = resourceDictionary["RingNetworkNode"] as DataTemplate;
                            break;
                        case "Ethernet":

                            nodeTemplatePath = resourceDictionary["EthernetNode"] as DataTemplate;
                            break;
                        case "Server":

                            nodeTemplatePath = resourceDictionary["ServerNode"] as DataTemplate;
                            break;
                        case "Mainframe":

                            nodeTemplatePath = resourceDictionary["MainframeNode"] as DataTemplate;
                            break;
                        case "Router":

                            nodeTemplatePath = resourceDictionary["RouterNode"] as DataTemplate;
                            break;
                        case "Switch":

                            nodeTemplatePath = resourceDictionary["SwitchNode"] as DataTemplate;
                            break;
                        case "Firewall":

                            nodeTemplatePath = resourceDictionary["FirewallNode"] as DataTemplate;
                            break;
                        case "CommLink":

                            nodeTemplatePath = resourceDictionary["CommLinkNode"] as DataTemplate;
                            break;
                        case "SuperComputer":

                            nodeTemplatePath = resourceDictionary["SuperComputerNode"] as DataTemplate;
                            break;
                        case "Printer":

                            nodeTemplatePath = resourceDictionary["PrinterNode"] as DataTemplate;
                            break;
                        case "VirtualServer":

                            nodeTemplatePath = resourceDictionary["ServerNode"] as DataTemplate;
                            break;
                        case "Plotter":

                            nodeTemplatePath = resourceDictionary["PlotterNode"] as DataTemplate;
                            break;
                        case "Scanner":

                            nodeTemplatePath = resourceDictionary["ScannerNode"] as DataTemplate;
                            break;
                        case "Copier":

                            nodeTemplatePath = resourceDictionary["CopierNode"] as DataTemplate;
                            break;
                        case "Fax":

                            nodeTemplatePath = resourceDictionary["FaxNode"] as DataTemplate;
                            break;
                        case "MultiFunction":

                            nodeTemplatePath = resourceDictionary["MultiFunctionNode"] as DataTemplate;
                            break;
                        case "Projector":

                            nodeTemplatePath = resourceDictionary["ProjectorNode"] as DataTemplate;
                            break;
                        case "ProjectorScreen":

                            nodeTemplatePath = resourceDictionary["ProjectorScreenNode"] as DataTemplate;
                            break;
                        case "Bridge":

                            nodeTemplatePath = resourceDictionary["BridgeNode"] as DataTemplate;
                            break;
                        case "Hub":

                            nodeTemplatePath = resourceDictionary["HubNode"] as DataTemplate;
                            break;
                        case "Modem":

                            nodeTemplatePath = resourceDictionary["ModemNode"] as DataTemplate;
                            break;
                        case "Telephone":

                            nodeTemplatePath = resourceDictionary["TelephoneNode"] as DataTemplate;
                            break;
                        case "CellPhone":

                            nodeTemplatePath = resourceDictionary["CellPhoneNode"] as DataTemplate;
                            break;
                        case "SmartPhone":

                            nodeTemplatePath = resourceDictionary["SmartPhoneNode"] as DataTemplate;
                            break;
                        case "VideoPhone":

                            nodeTemplatePath = resourceDictionary["VideoPhoneNode"] as DataTemplate;
                            break;
                        case "DigitalCamera":

                            nodeTemplatePath = resourceDictionary["DigitalCameraNode"] as DataTemplate;
                            break;
                        case "VideoCamera":

                            nodeTemplatePath = resourceDictionary["VideoCameraNode"] as DataTemplate;
                            break;
                        case "ExternalMediaDevice":

                            nodeTemplatePath = resourceDictionary["ExternalMediaDeviceNode"] as DataTemplate;
                            break;
                        case "User":

                            nodeTemplatePath = resourceDictionary["UserNode"] as DataTemplate;
                            break;
                    }
                }
            }
        }

        private void OnDropCommand(object parameter)
        {
            if ((parameter as ItemDropEventArgs).Source is INode && ((parameter as ItemDropEventArgs).Source as NodeViewModel).Name.ToString() == "Connector")
            {
                src = ((parameter as ItemDropEventArgs).Source as INode).OffsetX;
                target = ((parameter as ItemDropEventArgs).Source as INode).OffsetY;
                (parameter as ItemDropEventArgs).Cancel = true;
                ConnectorViewModel con = new ConnectorViewModel()
                {
                    SourcePoint = new Point(src - 30, target - 30),
                    TargetPoint = new Point(src + 30, target + 30),
                    Segments = new ObservableCollection<IConnectorSegment>()
                    {
                        //Specify the segment as orthogonal segment
                        new OrthogonalSegment()
                        {
                            Direction = OrthogonalDirection.Bottom,
                            Length = 60,
                        },
                        new OrthogonalSegment()
                        {
                            Direction = OrthogonalDirection.Right,
                            Length = 55,
                        },
                    },
                    Annotations = new ObservableCollection<IAnnotation>()
                    {
                        new AnnotationEditorViewModel()
                        {
                            Constraints = AnnotationConstraints.Editable | AnnotationConstraints.Selectable | AnnotationConstraints.Resizable,
                        }
                    },
                };
                (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(con);
            }
        }
    }
}
