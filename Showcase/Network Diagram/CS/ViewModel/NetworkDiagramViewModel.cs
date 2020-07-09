#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using Syncfusion.Pdf;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using Syncfusion.Windows.Controls;
using Syncfusion.XPS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Network_Diagram
{
    public class NetworkDiagramViewModel: DiagramViewModel
    {
        #region private variables

        private string _SavedPath;
        private DataTemplate nodeTemplatePath;
        private bool selectToolProperty = true;
        private bool panToolProperty = false;
        private bool drawToolProperty = false;
        private bool isItemSelected = false;
        private string zoomPercentageValue = "30%";
        private bool letterProperty = true;
        private bool folioProperty = false;
        private bool legalProperty = false;
        private bool ledgerProperty = false;
        private bool a5Property = false;
        private bool a4Property = false;
        private bool a3Property = false;
        private bool a2Property = false;
        private bool a1Property = false;
        private bool a0Property = false;
        private bool straightProperty = false;
        private bool orthogonalProperty = true;
        private bool bezierProperty = false;
        private bool landscapeProperty = true;
        private bool portraitProperty = false;
        private bool _ZoomInEnabled = true;
        private bool _ZoomOutEnabled = true;
        private double _currentZoom = 1;
        double src;
        double target;

        #endregion

        #region public variables
        public ICommand NewPageCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand PrintCommand { get; set; }
        public ICommand ExportCommand { get; set; }
        public ICommand SelectToolCommand { get; set; }
        public ICommand PanToolCommand { get; set; }
        public ICommand DrawConnectorCommand { get; set; }
        public ICommand RotateColockwiseCommand { get; set; }
        public ICommand RotateCounterColockwiseCommand { get; set; }
        public ICommand SelectNoneCommand { get; set; }
        public ICommand ZoomInCommand { get; set; }
        public ICommand ZoomOutCommand { get; set; }
        public ICommand SnapToGridCommand { get; set; }
        public ICommand ShowLinesCommand { get; set; }
        public ICommand SnapToObjectCommand { get; set; }
        public ICommand SelectAllNodesCommand { get; set; }
        public ICommand SelectAllConnectorsCommand { get; set; }
        public ICommand LoadBlankDiagramCommand { get; set; }
        public ICommand LoadDefaultNetworkDiagramCommand { get; set; }
        public ICommand ChangeConnectorTypeCommand { get; set; }
        public ICommand OrientationCommand { get; set; }
        public ICommand PageSizeCommand { get; set; }
        public ICommand ShowRulerCommand { get; set; }
        public ICommand ShowPageBreaksCommand { get; set; }
        public ICommand FitToWidthCommand { get; set; }
        public ICommand FitToPageCommand { get; set; }
        public ICommand TemplateLoadingCommand { get; set; }
        public ICommand ButtonMenuOpeningCommand { get; set; }
        public ICommand LoadOfficeNetworkDiagram { get; set; }
        public ICommand LoadEthernetCommunicationNetwork { get; set; }
        public ICommand LoadHomeNetworkDiagram { get; set; }
        public bool SelectToolProperty
        {
            get
            {
                return selectToolProperty;
            }
            set
            {
                if (selectToolProperty != value)
                {
                    selectToolProperty = value;
                    this.OnSelectToolCommand(value);
                    OnPropertyChanged("SelectToolProperty");
                }
            }
        }
        public string ZoomPercentageValue
        {
            get
            {
                return zoomPercentageValue;
            }
            set
            {
                if (zoomPercentageValue != value)
                {
                    zoomPercentageValue = value + "%";
                    OnPropertyChanged("ZoomPercentageValue");
                }
            }
        }

        public bool PanToolProperty
        {
            get
            {
                return panToolProperty;
            }
            set
            {
                if (panToolProperty != value)
                {
                    panToolProperty = value;
                    this.OnPanToolCommand(value);
                    OnPropertyChanged("PanToolProperty");
                }
            }
        }

        public bool StraightProperty
        {
            get
            {
                return straightProperty;
            }
            set
            {
                if (straightProperty != value)
                {
                    straightProperty = value;
                    OnPropertyChanged("StraightProperty");
                }
            }
        }

        public bool OrthogonalProperty
        {
            get
            {
                return orthogonalProperty;
            }
            set
            {
                if (orthogonalProperty != value)
                {
                    orthogonalProperty = value;
                    OnPropertyChanged("OrthogonalProperty");
                }
            }
        }

        public bool BezierProperty
        {
            get
            {
                return bezierProperty;
            }
            set
            {
                if (bezierProperty != value)
                {
                    bezierProperty = value;
                    OnPropertyChanged("BezierProperty");
                }
            }
        }

        public bool DrawToolProperty
        {
            get
            {
                return drawToolProperty;
            }
            set
            {
                if (drawToolProperty != value)
                {
                    drawToolProperty = value;
                    this.OnDrawConnectorCommand(value);
                    OnPropertyChanged("DrawToolProperty");
                }
            }
        }

        public bool IsSelectToolSelected
        {
            get
            {
                return selectToolProperty;
            }
            set
            {
                if (selectToolProperty != value)
                {
                    selectToolProperty = value;
                    this.OnSelectToolCommand(value);
                    OnPropertyChanged("IsSelectToolSelected");
                }
            }
        }

        


        public bool LandscapeProperty
        {
            get
            {
                return landscapeProperty;
            }
            set
            {
                if (landscapeProperty != value)
                {
                    landscapeProperty = value;
                    OnPropertyChanged("LandscapeProperty");
                }
            }
        }
        public bool PortraitProperty
        {
            get
            {
                return portraitProperty;
            }
            set
            {
                if (portraitProperty != value)
                {
                    portraitProperty = value;
                    OnPropertyChanged("PortraitProperty");
                }
            }
        }
        public bool IsPanToolSelected
        {
            get
            {
                return panToolProperty;
            }
            set
            {
                if (panToolProperty != value)
                {
                    panToolProperty = value;
                    this.OnPanToolCommand(value);
                    OnPropertyChanged("IsPanToolSelected");
                }
            }
        }

        public bool IsItemSelected
        {
            get
            {
                return isItemSelected;
            }
            set
            {
                if (isItemSelected != value)
                {
                    isItemSelected = value;
                    OnPropertyChanged("IsItemSelected");
                }
            }
        }

        public bool LetterProperty
        {
            get
            {
                return letterProperty;
            }
            set
            {
                if (letterProperty != value)
                {
                    letterProperty = value;
                    OnPropertyChanged("LetterProperty");
                }
            }
        }
        public bool FolioProperty
        {
            get
            {
                return folioProperty;
            }
            set
            {
                if (folioProperty != value)
                {
                    folioProperty = value;
                    OnPropertyChanged("FolioProperty");
                }
            }
        }
        public bool LedgerProperty
        {
            get
            {
                return ledgerProperty;
            }
            set
            {
                if (ledgerProperty != value)
                {
                    legalProperty = value;
                    OnPropertyChanged("LedgerProperty");
                }
            }
        }

        public bool LegalProperty
        {
            get
            {
                return legalProperty;
            }
            set
            {
                if (legalProperty != value)
                {
                    legalProperty = value;
                    OnPropertyChanged("LegalProperty");
                }
            }
        }
        public bool A5Property
        {
            get
            {
                return a5Property;
            }
            set
            {
                if (a5Property != value)
                {
                    a5Property = value;
                    OnPropertyChanged("A5Property");
                }
            }
        }

        public bool A4Property
        {
            get
            {
                return a4Property;
            }
            set
            {
                if (a4Property != value)
                {
                    a4Property = value;
                    OnPropertyChanged("A4Property");
                }
            }
        }

        public bool A3Property
        {
            get
            {
                return a3Property;
            }
            set
            {
                if (a3Property != value)
                {
                    a3Property = value;
                    OnPropertyChanged("A3Property");
                }
            }
        }

        public bool A2Property
        {
            get
            {
                return a2Property;
            }
            set
            {
                if (a2Property != value)
                {
                    a2Property = value;
                    OnPropertyChanged("A2Property");
                }
            }
        }

        public bool A1Property
        {
            get
            {
                return a1Property;
            }
            set
            {
                if (a1Property != value)
                {
                    a1Property = value;
                    OnPropertyChanged("A1Property");
                }
            }
        }

        public bool A0Property
        {
            get
            {
                return a0Property;
            }
            set
            {
                if (a0Property != value)
                {
                    a0Property = value;
                    OnPropertyChanged("A0Property");
                }
            }
        }


        public bool ZoomInEnabled
        {
            get
            {
                return _ZoomInEnabled;
            }
            set
            {
                if (value != _ZoomInEnabled)
                {
                    _ZoomInEnabled = value;
                    OnPropertyChanged("ZoomInEnabled");
                }
            }
        }

        public bool ZoomOutEnabled
        {
            get
            {
                return _ZoomOutEnabled;
            }
            set
            {
                if (value != _ZoomOutEnabled)
                {
                    _ZoomOutEnabled = value;
                    OnPropertyChanged("ZoomOutEnabled");
                }
            }
        }

        public double CurrentZoom
        {
            get
            {
                return _currentZoom;
            }
            set
            {
                if (value != _currentZoom)
                {
                    _currentZoom = value;
                    (this.Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParameter()
                    {
                        ZoomCommand = ZoomCommand.Zoom,
                        ZoomTo = _currentZoom,
                    });
                    OnPropertyChanged("CurrentZoom");
                }
            }
        }

        public ObservableCollection<SymbolFilterProvider> Symbolfilters { get; set; }

        public SymbolFilterProvider Selectedfilter { get; set; }
        #endregion

        #region Constructor

        public NetworkDiagramViewModel()
        {
            this.DefaultConnectorType = ConnectorType.Line;
            PortVisibility = PortVisibility.Visible;
            this.Nodes = new ObservableCollection<CustomNode>();
            this.Connectors = new ObservableCollection<ConnectorViewModel>();
            this.PageSettings = new PageSettings()
            {
                PageWidth = 1056,
                PageHeight = 816,
                ShowPageBreaks = true,
                MultiplePage = true,
            };
            this.HorizontalRuler = new Ruler();
            this.VerticalRuler = new Ruler() { Orientation = Orientation.Vertical };
            this.PrintingService = new PrintingService();
            this.Constraints |= GraphConstraints.Undoable | GraphConstraints.AllowPan;
            this.SelectedItems = new SelectorViewModel()
            {
            };
            this.ExportSettings = new ExportSettings()
            {
            };
            this.SnapSettings = new SnapSettings()
            {
                SnapConstraints = SnapConstraints.ShowLines | SnapConstraints.SnapToLines,
                SnapToObject = SnapToObject.All,
            };
            this.ScrollSettings = new ScrollSettings()
            {
            };
            this.Symbolfilters = new SymbolFilters();

            SymbolFilterProvider all = new SymbolFilterProvider { Content = "All", SymbolFilter = Filter };
            SymbolFilterProvider computershapes = new SymbolFilterProvider { Content = "Computers and Moniters", SymbolFilter = Filter };
            SymbolFilterProvider networkshapes = new SymbolFilterProvider { Content = "Network and Peripherals", SymbolFilter = Filter };

            this.Symbolfilters.Add(all);
            this.Symbolfilters.Add(computershapes);
            this.Symbolfilters.Add(networkshapes);
            this.Selectedfilter = Symbolfilters[0];
            NewPageCommand = new Command(this.OnNewCommand);
            OpenCommand = new Command(this.OnOpenCommand);
            SaveCommand = new Command(this.OnSaveCommand);
            PrintCommand = new Command(this.OnPrintCommand);
            ExportCommand = new Command(this.OnExportCommand);
            SelectToolCommand = new Command(this.OnSelectToolCommand);
            PanToolCommand = new Command(this.OnPanToolCommand);
            RotateColockwiseCommand = new Command(OnRotateColockwiseCommand);
            RotateCounterColockwiseCommand = new Command(OnRotateCounterColockwiseCommand);            
            SelectNoneCommand = new Command(OnSelectNoneCommand);
            ZoomInCommand = new Command(OnZoomInCommand);
            ZoomOutCommand = new Command(OnZoomOutCommand);
            SnapToGridCommand = new Command(OnSnapToGridCommand);
            ShowLinesCommand = new Command(OnShowLinesCommand);
            SnapToObjectCommand = new Command(OnSnapToObjectCommand);
            ShowRulerCommand = new Command(OnShowRulerCommand);
            DragEnterCommand = new Command(OnDragEnterCommand);
            DragOverCommand = new Command(OnDragOverCommand);
            ItemAddedCommand = new Command(OnItemAddedCommand);
            ItemSelectedCommand = new Command(OnItemSelectedCommand);
            DropCommand = new Command(OnDropCommand);
            ItemUnSelectedCommand = new Command(OnItemUnSelectedCommand);
            FitToWidthCommand = new Command(OnFitToWidthCommand);
            FitToPageCommand = new Command(OnFitToPageCommand);
            ViewPortChangedCommand = new Command(OnViewPortChangedCommand);
            SelectAllNodesCommand = new Command(OnSelectAllNodesCommand);
            SelectAllConnectorsCommand = new Command(OnSelectAllConnectorsCommand);
            LoadBlankDiagramCommand = new Command(OnLoadBlankDiagramCommand);
            LoadDefaultNetworkDiagramCommand = new Command(OnLoadDefaultNetworkDiagramCommand);
            ChangeConnectorTypeCommand = new Command(OnChangeConnectorTypeCommand);
            DrawConnectorCommand = new Command(OnDrawConnectorCommand);
            OrientationCommand = new Command(OnOrientationCommand);
            PageSizeCommand = new Command(OnPageSizeCommand);
            ShowPageBreaksCommand = new Command(OnShowPageBreaksCommand);
            TemplateLoadingCommand = new Command(OnTemplateLoadingCommand);
            ButtonMenuOpeningCommand = new Command(OnButtonMenuOpeningCommand);
            LoadOfficeNetworkDiagram = new Command(OnLoadOfficeNetworkDiagram);
            LoadEthernetCommunicationNetwork = new Command(OnLoadEthernetCommunicationNetwork);
            LoadHomeNetworkDiagram = new Command(OnLoadHomeNetworkDiagram);
        }

        #endregion
        private bool Filter(SymbolFilterProvider sender, object symbol)
        {
            if (sender.Content.ToString() == "All")
            {
                return true;
            }
            if (sender.Content.ToString() == (symbol as NodeViewModel).Key.ToString())
            {
                return true;
            }
            return false;
        }
        private void OnLoadHomeNetworkDiagram(object parameter)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show(
                       "Do you want to save Diagram?",
                       "Logic Circuit Diagram",
                       MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.OnSaveCommand(null);
            }
#if WPF
            this.LoadDiagramFromFile(@"..\..\PredefinedDiagram\HomeNetwork.xml");
#else
            this.LoadDiagramFromFile(@"..\..\..\PredefinedDiagram\HomeNetwork.xml");
#endif
        }

        private void OnLoadOfficeNetworkDiagram(object parameter)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show(
                       "Do you want to save Diagram?",
                       "Logic Circuit Diagram",
                       MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.OnSaveCommand(null);
            }
#if WPF
            this.LoadDiagramFromFile(@"..\..\PredefinedDiagram\OfficeNetworkDiagram.xml");
#else
            this.LoadDiagramFromFile(@"..\..\..\PredefinedDiagram\OfficeNetworkDiagram.xml");
#endif
        }

        private void OnLoadEthernetCommunicationNetwork(object parameter)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show(
                       "Do you want to save Diagram?",
                       "Logic Circuit Diagram",
                       MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.OnSaveCommand(null);
            }
#if WPF
            this.LoadDiagramFromFile(@"..\..\PredefinedDiagram\EthernetCommunication.xml");
#else
            this.LoadDiagramFromFile(@"..\..\..\PredefinedDiagram\EthernetCommunication.xml");
#endif
        }

        private void LoadDiagramFromFile(string file)
        {
            (this.Nodes as ObservableCollection<CustomNode>).Clear();
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Clear();
            if (this.Info != null)
            {
                using (FileStream fileStream = File.OpenRead(file))
                {
                    (this.Info as IGraphInfo).Load(fileStream);
                }
            }
        }

        public void OnButtonMenuOpeningCommand(object parameter)
        {
            Button source = parameter as Button;
            if (source != null && source.ContextMenu != null)
            {
                source.ContextMenu.PlacementTarget = source;
                source.ContextMenu.Placement = PlacementMode.Bottom;
                source.ContextMenu.IsOpen = true;
            }
        }

        public void OnTemplateLoadingCommand(object parameter)
        {
            (parameter as ContextMenu).IsOpen = true;
        }

        private void OnPageSizeCommand(object parameter)
        {
            this.LetterProperty = FolioProperty = LegalProperty = LedgerProperty = A5Property = A4Property = A3Property = A2Property = A1Property = A0Property = false;
            if (parameter != null)
            {
                string value = parameter.ToString();
                switch (value)
                {
                    case "Letter":
                        this.PageSettings.PageWidth = 1056;
                        this.PageSettings.PageHeight = 816;
                        LetterProperty = true;
                        break;
                    case "Folio":
                        this.PageSettings.PageWidth = 1248;
                        this.PageSettings.PageHeight = 816;
                        FolioProperty = true;
                        break;
                    case "Legal":
                        this.PageSettings.PageWidth = 1344;
                        this.PageSettings.PageHeight = 816;
                        LegalProperty = true;
                        break;
                    case "Ledger":
                        this.PageSettings.PageWidth = 1632;
                        this.PageSettings.PageHeight = 1056;
                        LedgerProperty = true;
                        break;
                    case "A5":
                        this.PageSettings.PageWidth = 793;
                        this.PageSettings.PageHeight = 559;
                        A5Property = true;
                        break;
                    case "A4":
                        this.PageSettings.PageWidth = 1122;
                        this.PageSettings.PageHeight = 793;
                        A4Property = true;
                        break;
                    case "A3":
                        this.PageSettings.PageWidth = 1587;
                        this.PageSettings.PageHeight = 1122;
                        A3Property = true;
                        break;
                    case "A2":
                        this.PageSettings.PageWidth = 2245;
                        this.PageSettings.PageHeight = 1587;
                        A2Property = true;
                        break;
                    case "A1":
                        this.PageSettings.PageWidth = 3178;
                        this.PageSettings.PageHeight = 2245;
                        A1Property = true;
                        break;
                    case "A0":
                        this.PageSettings.PageWidth = 4493;
                        this.PageSettings.PageHeight = 3178;
                        A0Property = true;
                        break;
                }
            }
        }

        private void OnOrientationCommand(object parameter)
        {
            if (parameter != null)
            {
                if (parameter.ToString() == "Landscape")
                {
                    this.PageSettings.PageOrientation = PageOrientation.Landscape;
                    this.LandscapeProperty = true;
                    this.PortraitProperty = false;
                }
                else
                {
                    this.PageSettings.PageOrientation = PageOrientation.Portrait;
                    this.LandscapeProperty = false;
                    this.PortraitProperty = true;
                }
            }
        }

        private void OnChangeConnectorTypeCommand(object parameter)
        {
            this.StraightProperty = OrthogonalProperty = BezierProperty = false;
            string paramValue = parameter != null ? parameter.ToString() : null;
            if (paramValue != null)
            {
                switch (paramValue)
                {
                    case "Orthogonal":
                        {
                            this.DefaultConnectorType = ConnectorType.Orthogonal;
                            this.OrthogonalProperty = true;
                            foreach (var item in (this.SelectedItems as SelectorViewModel).Connectors as IEnumerable<object>)
                            {
                                (item as IConnector).Segments = new ObservableCollection<IConnectorSegment>()
                            {
                                new OrthogonalSegment()
                                {
                                }
                            };
                            }
                        }
                        break;
                    case "Straight":
                        {
                            this.DefaultConnectorType = ConnectorType.Line;
                            this.StraightProperty = true;
                            foreach (var item in (this.SelectedItems as SelectorViewModel).Connectors as IEnumerable<object>)
                            {
                                (item as IConnector).Segments = new ObservableCollection<IConnectorSegment>()
                            {
                                new StraightSegment()
                                {
                                }
                            };
                            }
                        }
                        break;
                    case "Bezier":
                        {
                            this.DefaultConnectorType = ConnectorType.CubicBezier;
                            this.BezierProperty = true;
                            foreach (var item in (this.SelectedItems as SelectorViewModel).Connectors as IEnumerable<object>)
                            {
                                (item as IConnector).Segments = new ObservableCollection<IConnectorSegment>()
                            {
                                new CubicCurveSegment()
                                {
                                }
                            };
                            }
                        }
                        break;
                }
            }
        }

        private void OnLoadDefaultNetworkDiagramCommand(object parameter)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show(
                      "Do you want to save Diagram?",
                      "Logic Circuit Diagram",
                      MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.OnSaveCommand(null);
            }
                        
            (this.Nodes as ObservableCollection<CustomNode>).Clear();
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Clear();
        }

        private void OnLoadBlankDiagramCommand(object parameter)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show(
                     "Do you want to save Diagram?",
                     "Logic Circuit Diagram",
                     MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.OnSaveCommand(null);
            }
                        
            (this.Nodes as ObservableCollection<CustomNode>).Clear();
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Clear();
        }

        private void OnSelectAllConnectorsCommand(object parameter)
        {
            ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>).Clear();
            ((this.SelectedItems as SelectorViewModel).Connectors as ObservableCollection<object>).Clear();
            foreach (IConnector connector in this.Connectors as IEnumerable<object>)
            {
                connector.IsSelected = true;
            }
        }

        private void OnSelectAllNodesCommand(object parameter)
        {
            ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>).Clear();
            ((this.SelectedItems as SelectorViewModel).Connectors as ObservableCollection<object>).Clear();
            foreach (CustomNode node in this.Nodes as IEnumerable<object>)
            {
                node.IsSelected = true;
            }
        }

        public void OnViewPortChangedCommand(object parameter)
        {
            int val = Convert.ToInt32(this.ScrollSettings.ScrollInfo.CurrentZoom * 100);
            CurrentZoom = this.ScrollSettings.ScrollInfo.CurrentZoom;
            ZoomPercentageValue = val.ToString();
            var args = parameter as ChangeEventArgs<object, ScrollChanged>;
            if (args.NewValue.CurrentZoom >= 3)
            {
                ZoomInEnabled = false;
            }
            else
            {
                ZoomInEnabled = true;
            }
            if (args.NewValue.CurrentZoom == 0.3)
            {
                ZoomOutEnabled = false;
            }
            else
            {
                ZoomOutEnabled = true;
            }
        }
        public void OnFitToWidthCommand(object parameter)
        {
            (this.Info as IGraphInfo).Commands.FitToPage.Execute(new FitToPageParameter { FitToPage = FitToPage.FitToWidth, Region = Region.PageSettings });
        }
        public void OnFitToPageCommand(object parameter)
        {
            (this.Info as IGraphInfo).Commands.FitToPage.Execute(null);
        }

        private void OnItemUnSelectedCommand(object parameter)
        {
            if (((this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).Count() > 0 ||
                ((this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).Count() > 0)
            {
                IsItemSelected = true;
            }
            else
            {
                IsItemSelected = false;
            }
        }

        private void OnDropCommand(object parameter)
        {
            if ((parameter as ItemDropEventArgs).Source is INode && ((parameter as ItemDropEventArgs).Source as CustomNode).Name.ToString() == "Connector")
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
                    }
                };
                (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(con);
            }
        }
        public void OnItemSelectedCommand(object parameter)
        {
            if (((this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).Count() > 0 ||
               ((this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).Count() > 0)
            {
                IsItemSelected = true;
            }
            else
            {
                IsItemSelected = false;
            }
        }

        public void OnItemAddedCommand(object parameter)
        {
            if ((parameter as ItemAddedEventArgs).Item is CustomNode)
            {
                string itemName = ((parameter as ItemAddedEventArgs).Item as CustomNode).Name;
                if (itemName != null && (parameter as ItemAddedEventArgs).ItemSource != ItemSource.Stencil && (parameter as ItemAddedEventArgs).Item is CustomNode)
                {
                    switch (itemName)
                    {
                        case "PC":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["PCNode"] as DataTemplate;
                            break;
                        case "VirtualPC":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["VirtualPCNode"] as DataTemplate;
                            break;
                        case "Terminal":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["TerminalNode"] as DataTemplate;
                            break;
                        case "Wavelength":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["WavelengthNode"] as DataTemplate;
                            break;
                        case "DataPipe":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["DataPipeNode"] as DataTemplate;
                            break;
                        case "SlateDevice":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["SlateDivceNode"] as DataTemplate;
                            break;
                        case "TabletDevice":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["TabletDeviceNode"] as DataTemplate;
                            break;
                        case "Laptop":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["LaptopNode"] as DataTemplate;
                            break;
                        case "PDA":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["PDANode"] as DataTemplate;
                            break;
                        case "CRTMoniter":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["CRTMoniterNode"] as DataTemplate;
                            break;
                        case "Wireless":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["WirelessNode"] as DataTemplate;
                            break;
                        case "RingNetwork":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["RingNetworkNode"] as DataTemplate;
                            break;
                        case "Ethernet":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["EthernetNode"] as DataTemplate;
                            break;
                        case "Server":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["ServerNode"] as DataTemplate;
                            break;
                        case "Mainframe":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["MainframeNode"] as DataTemplate;
                            break;
                        case "Router":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["RouterNode"] as DataTemplate;
                            break;
                        case "Switch":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["SwitchNode"] as DataTemplate;
                            break;
                        case "Firewall":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["FirewallNode"] as DataTemplate;
                            break;
                        case "CommLink":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["CommLinkNode"] as DataTemplate;
                            break;
                        case "SuperComputer":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["SuperComputerNode"] as DataTemplate;
                            break;
                        case "Printer":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["PrinterNode"] as DataTemplate;
                            break;
                        case "VirtualServer":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["ServerNode"] as DataTemplate;
                            break;
                        case "Plotter":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["PlotterNode"] as DataTemplate;
                            break;
                        case "Scanner":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["ScannerNode"] as DataTemplate;
                            break;
                        case "Copier":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["CopierNode"] as DataTemplate;
                            break;
                        case "MultiFunction":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["MultiFunctionNode"] as DataTemplate;
                            break;
                        case "Fax":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["FaxNode"] as DataTemplate;
                            break;
                        case "Projector":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["ProjectorNode"] as DataTemplate;
                            break;
                        case "ProjectorScreen":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["ProjectorScreenNode"] as DataTemplate;
                            break;
                        case "Bridge":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["BridgeNode"] as DataTemplate;
                            break;
                        case "Hub":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["HubNode"] as DataTemplate;
                            break;
                        case "Modem":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["ModemNode"] as DataTemplate;
                            break;
                        case "Telephone":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["TelephoneNode"] as DataTemplate;
                            break;
                        case "CellPhone":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["CellPhoneNode"] as DataTemplate;
                            break;
                        case "SmartPhone":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["SmartPhoneNode"] as DataTemplate;
                            break;
                        case "VideoPhone":
                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["VideoPhoneNode"] as DataTemplate;
                            break;
                        case "DigitalCamera":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["DigitalCameraNode"] as DataTemplate;
                            break;
                        case "VideoCamera":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["VideoCameraNode"] as DataTemplate;
                            break;
                        case "ExternalMediaDevice":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["ExternalMediaDeviceNode"] as DataTemplate;
                            break;
                        case "User":

                            ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = App.Current.Resources["UserNode"] as DataTemplate;
                            break;

                    }
                }
            }
        }

        public void OnNewCommand(object parameter)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show(
                       "Do you want to save Diagram?",
                       "Logic Circuit Diagram",
                       MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.OnSaveCommand(null);
            }
            (this.Nodes as ObservableCollection<CustomNode>).Clear();
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Clear();
        }

        public void OnDragOverCommand(object parameter)
        {
            ItemDropEventArgs args = parameter as ItemDropEventArgs;
            if(args != null)
            {
                string itemName = args.Source is CustomNode ? (args.Source as CustomNode).Name : null;
                if(args.Source is INode && ((args.Source as INode).Shape == null && (args.Source as INode).ContentTemplate == null))
                {
                    (args.Source as INode).ContentTemplate = nodeTemplatePath;
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

                                ((parameter as ItemDropEventArgs).Source as INode).UnitWidth = 96;
                                ((parameter as ItemDropEventArgs).Source as INode).UnitHeight = 96;
                                break;
                            case "Wavelength":
                            case "Ethernet":
                            case "Router":
                            case "Switch":
                            case "Scanner":
                                ((parameter as ItemDropEventArgs).Source as INode).UnitWidth = 96;
                                ((parameter as ItemDropEventArgs).Source as INode).UnitHeight = 56;
                                break;
                            case "Plotter":
                            case "Copier":
                            case "Fax":
                            case "MultiFunction":
                                ((parameter as ItemDropEventArgs).Source as INode).UnitWidth = 96;
                                ((parameter as ItemDropEventArgs).Source as INode).UnitHeight = 76;
                                break;
                            case "DataPipe":
                            case "CommLink":
                                ((parameter as ItemDropEventArgs).Source as INode).UnitWidth = 96;
                                ((parameter as ItemDropEventArgs).Source as INode).UnitHeight = 26;
                                break;
                            case "Wireless":
                            case "Server":
                            case "SuperComputer":
                            case "VirtualServer":
                                ((parameter as ItemDropEventArgs).Source as INode).UnitWidth = 56;
                                ((parameter as ItemDropEventArgs).Source as INode).UnitHeight = 96;
                                break;
                            case "PDA":
                            case "Mainframe":
                                ((parameter as ItemDropEventArgs).Source as INode).UnitWidth = 76;
                                ((parameter as ItemDropEventArgs).Source as INode).UnitHeight = 96;
                                break;
                            case "Projector":
                            case "Bridge":
                            case "Hub":
                            case "Modem":
                            case "DigitalCamera":
                            case "VideoCamera":
                            case "ExternalMediaDevice":
                                ((parameter as ItemDropEventArgs).Source as INode).UnitWidth = 80;
                                ((parameter as ItemDropEventArgs).Source as INode).UnitHeight = 40;
                                break;
                            case "Telephone":
                            case "CellPhone":
                                ((parameter as ItemDropEventArgs).Source as INode).UnitWidth = 30;
                                ((parameter as ItemDropEventArgs).Source as INode).UnitHeight = 80;
                                break;
                            case "SmartPhone":
                                ((parameter as ItemDropEventArgs).Source as INode).UnitWidth = 35;
                                ((parameter as ItemDropEventArgs).Source as INode).UnitHeight = 70;
                                break;
                            case "VideoPhone":
                                ((parameter as ItemDropEventArgs).Source as INode).UnitWidth = 60;
                                ((parameter as ItemDropEventArgs).Source as INode).UnitHeight = 70;
                                break;
                            case "User":
                                ((parameter as ItemDropEventArgs).Source as INode).UnitWidth = 40;
                                ((parameter as ItemDropEventArgs).Source as INode).UnitHeight = 70;
                                break;
                            case "Connector":
                                ((parameter as ItemDropEventArgs).Source as INode).UnitWidth = 70;
                                ((parameter as ItemDropEventArgs).Source as INode).UnitHeight = 72.5;
                                break;
                        }
                    }
                }
            }
        }

        public void OnDragEnterCommand(object parameter)
        {
            nodeTemplatePath = null;
            ItemDropEventArgs args = parameter as ItemDropEventArgs;
            string itemName = args.Source is CustomNode ? (args.Source as CustomNode).Name : null;
            if (args.Source is INode && (args.Source as INode).ContentTemplate != null)
            {
                if(itemName != null)
                {
                    switch (itemName)
                    {
                        case "PC":

                            nodeTemplatePath = App.Current.Resources["PCNode"] as DataTemplate;
                            break;
                        case "VirtualPC":

                            nodeTemplatePath = App.Current.Resources["VirtualPCNode"] as DataTemplate;
                            break;
                        case "Terminal":

                            nodeTemplatePath = App.Current.Resources["TerminalNode"] as DataTemplate;
                            break;
                        case "Wavelength":

                            nodeTemplatePath = App.Current.Resources["WavelengthNode"] as DataTemplate;
                            break;
                        case "DataPipe":

                            nodeTemplatePath = App.Current.Resources["DataPipeNode"] as DataTemplate;
                            break;
                        case "SlateDevice":

                            nodeTemplatePath = App.Current.Resources["SlateDivceNode"] as DataTemplate;
                            break;
                        case "TabletDevice":

                            nodeTemplatePath = App.Current.Resources["TabletDeviceNode"] as DataTemplate;
                            break;
                        case "Laptop":

                            nodeTemplatePath = App.Current.Resources["LaptopNode"] as DataTemplate;
                            break;
                        case "PDA":

                            nodeTemplatePath = App.Current.Resources["PDANode"] as DataTemplate;
                            break;
                        case "CRTMoniter":

                            nodeTemplatePath = App.Current.Resources["CRTMoniterNode"] as DataTemplate;
                            break;
                        case "LCDMoniter":

                            nodeTemplatePath = App.Current.Resources["LCDMoniterNode"] as DataTemplate;
                            break;
                        case "Connector":

                            nodeTemplatePath = App.Current.Resources["DynamicConnectorNode"] as DataTemplate;
                            break;
                        case "Wireless":

                            nodeTemplatePath = App.Current.Resources["WirelessNode"] as DataTemplate;
                            break;
                        case "RingNetwork":

                            nodeTemplatePath = App.Current.Resources["RingNetworkNode"] as DataTemplate;
                            break;
                        case "Ethernet":

                            nodeTemplatePath = App.Current.Resources["EthernetNode"] as DataTemplate;
                            break;
                        case "Server":

                            nodeTemplatePath = App.Current.Resources["ServerNode"] as DataTemplate;
                            break;
                        case "Mainframe":

                            nodeTemplatePath = App.Current.Resources["MainframeNode"] as DataTemplate;
                            break;
                        case "Router":

                            nodeTemplatePath = App.Current.Resources["RouterNode"] as DataTemplate;
                            break;
                        case "Switch":

                            nodeTemplatePath = App.Current.Resources["SwitchNode"] as DataTemplate;
                            break;
                        case "Firewall":

                            nodeTemplatePath = App.Current.Resources["FirewallNode"] as DataTemplate;
                            break;
                        case "CommLink":

                            nodeTemplatePath = App.Current.Resources["CommLinkNode"] as DataTemplate;
                            break;
                        case "SuperComputer":

                            nodeTemplatePath = App.Current.Resources["SuperComputerNode"] as DataTemplate;
                            break;
                        case "Printer":

                            nodeTemplatePath = App.Current.Resources["PrinterNode"] as DataTemplate;
                            break;
                        case "VirtualServer":

                            nodeTemplatePath = App.Current.Resources["ServerNode"] as DataTemplate;
                            break;
                        case "Plotter":

                            nodeTemplatePath = App.Current.Resources["PlotterNode"] as DataTemplate;
                            break;
                        case "Scanner":

                            nodeTemplatePath = App.Current.Resources["ScannerNode"] as DataTemplate;
                            break;
                        case "Copier":

                            nodeTemplatePath = App.Current.Resources["CopierNode"] as DataTemplate;
                            break;
                        case "Fax":

                            nodeTemplatePath = App.Current.Resources["FaxNode"] as DataTemplate;
                            break;
                        case "MultiFunction":

                            nodeTemplatePath = App.Current.Resources["MultiFunctionNode"] as DataTemplate;
                            break;
                        case "Projector":

                            nodeTemplatePath = App.Current.Resources["ProjectorNode"] as DataTemplate;
                            break;
                        case "ProjectorScreen":

                            nodeTemplatePath = App.Current.Resources["ProjectorScreenNode"] as DataTemplate;
                            break;
                        case "Bridge":

                            nodeTemplatePath = App.Current.Resources["BridgeNode"] as DataTemplate;
                            break;
                        case "Hub":

                            nodeTemplatePath = App.Current.Resources["HubNode"] as DataTemplate;
                            break;
                        case "Modem":

                            nodeTemplatePath = App.Current.Resources["ModemNode"] as DataTemplate;
                            break;
                        case "Telephone":

                            nodeTemplatePath = App.Current.Resources["TelephoneNode"] as DataTemplate;
                            break;
                        case "CellPhone":

                            nodeTemplatePath = App.Current.Resources["CellPhoneNode"] as DataTemplate;
                            break;
                        case "SmartPhone":

                            nodeTemplatePath = App.Current.Resources["SmartPhoneNode"] as DataTemplate;
                            break;
                        case "VideoPhone":

                            nodeTemplatePath = App.Current.Resources["VideoPhoneNode"] as DataTemplate;
                            break;
                        case "DigitalCamera":

                            nodeTemplatePath = App.Current.Resources["DigitalCameraNode"] as DataTemplate;
                            break;
                        case "VideoCamera":

                            nodeTemplatePath = App.Current.Resources["VideoCameraNode"] as DataTemplate;
                            break;
                        case "ExternalMediaDevice":

                            nodeTemplatePath = App.Current.Resources["ExternalMediaDeviceNode"] as DataTemplate;
                            break;
                        case "User":

                            nodeTemplatePath = App.Current.Resources["UserNode"] as DataTemplate;
                            break;
                    }
                }
            }
        }

        public void OnShowRulerCommand(object parameter)
        {
            if ((bool)parameter)
            {
                this.HorizontalRuler = new Ruler();
                this.VerticalRuler = new Ruler() { Orientation = Orientation.Vertical };
            }
            else
            {
                this.HorizontalRuler = null;
                this.VerticalRuler = null;
            }
        }

        public void OnShowLinesCommand(object parameter)
        {
            if ((bool)parameter)
                this.SnapSettings.SnapConstraints |= SnapConstraints.ShowLines;
            else
                this.SnapSettings.SnapConstraints &= ~SnapConstraints.ShowLines;
        }
        
        public void OnShowPageBreaksCommand(object parameter)
        {
            if ((bool)parameter)
                this.PageSettings.ShowPageBreaks = true;
            else
                this.PageSettings.ShowPageBreaks = false;
        }

        public void OnSnapToGridCommand(object parameter)
        {
            if ((bool)parameter)
                this.SnapSettings.SnapConstraints |= SnapConstraints.SnapToLines;
            else
                this.SnapSettings.SnapConstraints &= ~SnapConstraints.SnapToLines;
        }

        public void OnSnapToObjectCommand(object parameter)
        {
            if ((bool)parameter)
                this.SnapSettings.SnapToObject = SnapToObject.All;
            else
                this.SnapSettings.SnapToObject = SnapToObject.None;
        }

        public void OnZoomOutCommand(object parameter)
        {
            (this.Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParameter()
            {
                ZoomCommand = ZoomCommand.ZoomOut,
                ZoomFactor = 0.2,
            });
        }

        public void OnZoomInCommand(object parameter)
        {
            double zoomValue = (this.ScrollSettings.ScrollInfo.CurrentZoom * 0.2d) + this.ScrollSettings.ScrollInfo.CurrentZoom;
            if (zoomValue > 3)
            {
                (this.Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParameter()
                {
                    ZoomCommand = ZoomCommand.Zoom,
                    ZoomTo = 3,
                });
            }
            else
            {
                (this.Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParameter()
                {
                    ZoomCommand = ZoomCommand.ZoomIn,
                    ZoomFactor = 0.2,
                });
            }
        }

        public void OnSelectNoneCommand(object parameter)
        {
            ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>).Clear();
            ((this.SelectedItems as SelectorViewModel).Connectors as ObservableCollection<object>).Clear();
        }

        public void OnRotateCounterColockwiseCommand(object parameter)
        {
            foreach (var item in (this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>)
            {
                (item as INode).RotateAngle -= 90;
            }
        }

        public void OnRotateColockwiseCommand(object parameter)
        {
            foreach (var item in (this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>)
            {
                (item as INode).RotateAngle += 90;
            }
        }

        public void OnPanToolCommand(object parameter)
        {
            if (parameter != null)
            {
                if ((bool)parameter)
                {
                    this.Tool = Tool.ZoomPan;
                    this.SelectToolProperty = false;
                    this.DrawToolProperty = false;
                    this.PanToolProperty = true;
                    this.IsPanToolSelected = true;
                    this.IsSelectToolSelected = false;
                }
                else
                {
                    this.IsSelectToolSelected = true;
                    this.IsPanToolSelected = false;
                }
            }
        }

        public void OnDrawConnectorCommand(object parameter)
        {
            if (parameter != null)
            {
                if ((bool)parameter)
                {
                    this.Tool = Tool.ContinuesDraw;
                    this.DrawToolProperty = true;
                }
                else
                {
                    this.DrawToolProperty = false;
                }
            }
        }

        public void OnSelectToolCommand(object parameter)
        {
            if (parameter != null)
            {
                if ((bool)parameter)
                {
                    this.Tool = Tool.MultipleSelect;
                    this.SelectToolProperty = true;
                    this.DrawToolProperty = false;
                    this.PanToolProperty = false;
                    this.IsSelectToolSelected = true;
                    this.IsPanToolSelected = false;
                }
                else
                {
                    PanToolProperty = true;
                    SelectToolProperty = false;
                }
            }
        }

        public void OnPrintCommand(object parameter)
        {
            PrintingService.ShowDialog = true;
            PrintingService.Print();
        }

        public void OnExportCommand(object parameter)
        {
            String Extension = "BMP File (*.bmp)|*.bmp|WDP File (*.wdp)|*.wdp|JPG File(*.jpg)|*.jpg|PNG File(*.png)|*.png|TIF File(*.tif)|*.tif|GIF File(*.gif)|*.gif|XPS File(*.xps)|*.xps|PDF File(*.pdf)|*.pdf";

            //To Represent SaveFile Dialog Box
            SaveFileDialog m_SaveFileDialog = new SaveFileDialog();

            //Assign the selected extension to the SavefileDialog filter
            m_SaveFileDialog.Filter = Extension;

            //To display savefiledialog       
            bool? istrue = m_SaveFileDialog.ShowDialog();
            string filenamechanged;

            if (istrue == true)
            {
                //assign the filename to a local variable
                string extension = System.IO.Path.GetExtension(m_SaveFileDialog.FileName).TrimStart('.');
                string fileName = m_SaveFileDialog.FileName;
                if (extension != "")
                {
                    if (extension.ToLower() == "pdf")
                    {
                        filenamechanged = fileName + ".xps";

                        ExportSettings.IsSaveToXps = true;

                        //Assigning exportstream from the saved file
                        this.ExportSettings.FileName = filenamechanged;
                        // Method to Export the SfDiagram
                        (this.Info as IGraphInfo).Export();

                        var converter = new XPSToPdfConverter { };

                        var document = new PdfDocument();

                        document = converter.Convert(filenamechanged);
                        document.Save(fileName);
                        document.Close(true);

                    }
                    {
                        if (extension.ToLower() == "xps")
                        {
                            ExportSettings.IsSaveToXps = true;
                        }
                        //Assigning exportstream from the saved file
                        this.ExportSettings.FileName = fileName;
                        // Method to Export the SfDiagram
                        (this.Info as IGraphInfo).Export();
                    }
                }
            }
        }

        public void OnSaveCommand(object parameter)
        {
            SaveFileDialog saveAsFileDialog = new SaveFileDialog { Title = "Save ", DefaultExt = ".xml" };
            saveAsFileDialog.Filter = "Text file (*.xml)|*.xml";

            if (saveAsFileDialog.ShowDialog() == true)
            {
                this._SavedPath = saveAsFileDialog.FileName;
                IGraphInfo graph = this.Info as IGraphInfo;
                using (Stream fileStream = saveAsFileDialog.OpenFile())
                {
                    graph.Save(fileStream);
                }
            }
        }

        public void OnOpenCommand(object parameter)
        {
            OpenFileDialog openDialogBox = new OpenFileDialog();
            openDialogBox.Title = "Load";
            openDialogBox.RestoreDirectory = true;
            openDialogBox.DefaultExt = "xml";
            openDialogBox.Filter = "xml files (*.xml)|*.xml";
            bool? isFileChosen = openDialogBox.ShowDialog();
            if (isFileChosen == true)
            {
                this._SavedPath = openDialogBox.FileName;
                using (FileStream fileStream = File.OpenRead(this._SavedPath))
                {
                    this.Nodes = new ObservableCollection<CustomNode>();
                    this.Connectors = new ObservableCollection<ConnectorViewModel>();
                    (this.Info as IGraphInfo).Load(fileStream);
                }
            }
        }
    }

    public class CustomNode : NodeViewModel
    {
        private string name;
        [DataMember]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
    }
}
