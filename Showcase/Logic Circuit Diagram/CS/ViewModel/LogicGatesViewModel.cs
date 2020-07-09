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
using System.Windows.Media;
using System.Xml;

namespace Logic_Circuit_Diagram
{
    public class LogicGatesViewModel : DiagramViewModel
    {
        #region Fields
        private string _SavedPath;
        private DataTemplate nodeTemplatePath;
        private bool selectToolProperty = true;
        private bool panToolProperty = false;
        private bool isItemSelected = false;
        private bool landscapeProperty = true;
        private bool straightProperty = false;
        private bool orthogonalProperty = true;
        private bool bezierProperty = false;
        private bool letterProperty = true;
        private bool folioProperty = false;
        private bool legalProperty = false;
        private bool a5Property = false;
        private bool a3Property = false;
        private bool a2Property = false;
        private bool ledgerProperty = false;
        private bool a1Property = false;
        private bool a4Property = false;
        private bool portraitProperty = false;
        private string zoomPercentageValue = "30%";
        private bool a0Property = false;
        private bool _ZoomInEnabled = true;
        private bool _ZoomOutEnabled = true;
        private double _currentZoom = 1;

        #endregion

        #region Variables
        public ICommand NewPageCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand PrintCommand { get; set; }
        public ICommand ExportCommand { get; set; }
        public ICommand SelectToolCommand { get; set; }
        public ICommand PanToolCommand { get; set; }
        public ICommand RotateColockwiseCommand { get; set; }
        public ICommand RotateCounterColockwiseCommand { get; set; }
        public ICommand SelectNoneCommand { get; set; }
        public ICommand ZoomInCommand { get; set; }
        public ICommand ZoomOutCommand { get; set; }
        public ICommand SnapToGridCommand { get; set; }
        public ICommand ShowLinesCommand { get; set; }
        public ICommand SnapToObjectCommand { get; set; }
        public ICommand ShowRulerCommand { get; set; }
        public ICommand LoadBasicNetworkCommand { get; set; }
        public ICommand LoadBlankNetworkCommand { get; set; }
        public ICommand LoadFullAdderCircuit { get; set; }
        public ICommand LoadCustomFullAdderCircuit { get; set; }
        public ICommand ChangeConnectorTypeCommand { get; set; }
        public ICommand SelectAllNodesCommand { get; set; }
        public ICommand SelectAllConnectorsCommand { get; set; }
        public ICommand PageSizeCommand { get; set; }
        public ICommand ShowPageBreaksCommand { get; set; }
        public ICommand FitToWidthCommand { get; set; }
        public ICommand FitToPageCommand { get; set; }
        public ICommand OrientationCommand { get; set; }
        public ICommand ButtonMenuOpeningCommand { get; set; }
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
        public LogicGatesViewModel()
        {
            PortVisibility = PortVisibility.Visible;
            this.DefaultConnectorType = ConnectorType.Orthogonal;
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
            this.Constraints |= GraphConstraints.Undoable | GraphConstraints.AllowPan | GraphConstraints.Bridging;
            this.SelectedItems = new SelectorViewModel()
            {
            };
            (this.SelectedItems as SelectorViewModel).SelectorConstraints &= ~(SelectorConstraints.Resizer | SelectorConstraints.QuickCommands | SelectorConstraints.Rotator);

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
            Symbolfilters = new SymbolFilters();

            SymbolFilterProvider all = new SymbolFilterProvider { Content = "All", SymbolFilter = Filter };
            SymbolFilterProvider inputshapes = new SymbolFilterProvider { Content = "Input Controls", SymbolFilter = Filter };
            SymbolFilterProvider outputhapes = new SymbolFilterProvider { Content = "Output Controls", SymbolFilter = Filter };
            SymbolFilterProvider logicgateshapes = new SymbolFilterProvider { Content = "Logic Gates", SymbolFilter = Filter };
            SymbolFilterProvider flipflophapes = new SymbolFilterProvider { Content = "Flip-Flops", SymbolFilter = Filter };
            SymbolFilterProvider othershapes = new SymbolFilterProvider { Content = "Other", SymbolFilter = Filter };

            this.Symbolfilters.Add(all);
            this.Symbolfilters.Add(inputshapes);
            this.Symbolfilters.Add(outputhapes);
            this.Symbolfilters.Add(logicgateshapes);
            this.Symbolfilters.Add(flipflophapes);
            this.Symbolfilters.Add(othershapes);
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
            ViewPortChangedCommand = new Command(OnViewPortChangedCommand);
            ItemUnSelectedCommand = new Command(OnItemUnSelectedCommand);
            LoadBasicNetworkCommand = new Command(OnLoadBasicNetworkCommand);
            LoadFullAdderCircuit = new Command(OnLoadFullAdderCircuitCommand);
            LoadCustomFullAdderCircuit = new Command(OnLoadCustomFullAdderCircuit);
            LoadBlankNetworkCommand = new Command(OnLoadBlankNetworkCommand);
            ChangeConnectorTypeCommand = new Command(OnChangeConnectorTypeCommand);
            SelectAllNodesCommand = new Command(OnSelectAllNodesCommand);
            SelectAllConnectorsCommand = new Command(OnSelectAllConnectorsCommand);
            PageSizeCommand = new Command(OnPageSizeCommand);
            ShowPageBreaksCommand = new Command(OnShowPageBreaksCommand);
            OrientationCommand = new Command(OnOrientationCommand);
            FitToWidthCommand = new Command(OnFitToWidthCommand);
            FitToPageCommand = new Command(OnFitToPageCommand);
            ButtonMenuOpeningCommand = new Command(OnButtonMenuOpeningCommand);
        }
        #endregion

        #region Methods
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

        public void OnFitToWidthCommand(object parameter)
        {
            (this.Info as IGraphInfo).Commands.FitToPage.Execute(new FitToPageParameter { FitToPage = FitToPage.FitToWidth, Region = Region.PageSettings });
        }

        public void OnShowPageBreaksCommand(object parameter)
        {
            if ((bool)parameter)
                this.PageSettings.ShowPageBreaks = true;
            else
                this.PageSettings.ShowPageBreaks = false;
        }
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

        private void OnLoadBlankNetworkCommand(object parameter)
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

        private void OnLoadCustomFullAdderCircuit(object parameter)
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
#if WPF
            using (FileStream fileStream = File.OpenRead(@"..\..\PredefinedDiagram\CustomFullAdder.xml"))
#else
            using (FileStream fileStream = File.OpenRead(@"..\..\..\PredefinedDiagram\CustomFullAdder.xml"))
#endif
            {
                (this.Info as IGraphInfo).Load(fileStream);
            }
        }

        private void OnLoadFullAdderCircuitCommand(object parameter)
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
#if WPF
            using(FileStream fileStream = File.OpenRead(@"..\..\PredefinedDiagram\FullAdderCircuit.xml"))
#else
            using(FileStream fileStream = File.OpenRead(@"..\..\..\PredefinedDiagram\FullAdderCircuit.xml"))
#endif
            {
                (this.Info as IGraphInfo).Load(fileStream);
            }
        }

        private void OnLoadBasicNetworkCommand(object parameter)
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
            this.LoadDiagramFromFile(@"..\..\PredefinedDiagram\BasicLogicCircuit.xml");
#else
            this.LoadDiagramFromFile(@"..\..\..\PredefinedDiagram\BasicLogicCircuit.xml");
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

        private void OnViewPortChangedCommand(object parameter)
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
            foreach (CustomNode node in this.Nodes as IEnumerable<object>)
            {
                foreach (NodePortViewModel nodeport in node.Ports as PortCollection)
                {
                    nodeport.UnitHeight = 11 * (parameter as ChangeEventArgs<object, ScrollChanged>).NewValue.CurrentZoom;
                    nodeport.UnitWidth = 11 * (parameter as ChangeEventArgs<object, ScrollChanged>).NewValue.CurrentZoom;
                }
            }
        }

        public void OnFitToPageCommand(object parameter)
        {
            (this.Info as IGraphInfo).Commands.FitToPage.Execute(null);
        }
        public void OnDropCommand(object parameter)
        {
            if ((parameter as ItemDropEventArgs).Source is CustomNode && ((parameter as ItemDropEventArgs).Source as CustomNode).Name.ToString() == "Label")
            {
                foreach (NodePortViewModel nodeport in ((parameter as ItemDropEventArgs).Source as CustomNode).Ports as PortCollection)
                {
                    nodeport.UnitHeight = 11 * this.ScrollSettings.ScrollInfo.CurrentZoom;
                    nodeport.UnitWidth = 11 * this.ScrollSettings.ScrollInfo.CurrentZoom;
                }
                ((parameter as ItemDropEventArgs).Source as CustomNode).ContentTemplate = null;
                nodeTemplatePath = null;
                //((parameter as ItemDropEventArgs).Source as CustomNode).UnitHeight = double.NaN;
                //((parameter as ItemDropEventArgs).Source as CustomNode).UnitWidth = double.NaN;
                ((parameter as ItemDropEventArgs).Source as CustomNode).Shape = App.Current.Resources["Rectangle"];
                ((parameter as ItemDropEventArgs).Source as CustomNode).ShapeStyle = App.Current.Resources["ShapeStyle"] as Style;
                ((parameter as ItemDropEventArgs).Source as CustomNode).Annotations = new AnnotationCollection()
                    {
                        new TextAnnotationViewModel()
                        {
                            Text = "Text",
                            Foreground = new System.Windows.Media.SolidColorBrush(Colors.White),
                            FontSize = 16,
                            FontWeight = FontWeights.Bold,
                        }
                    };
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
                foreach (NodePortViewModel nodeport in ((parameter as ItemAddedEventArgs).Item as CustomNode).Ports as PortCollection)
                {
                    nodeport.UnitHeight = 11 * this.ScrollSettings.ScrollInfo.CurrentZoom;
                    nodeport.UnitWidth = 11 * this.ScrollSettings.ScrollInfo.CurrentZoom;
                }
                string itemName = ((parameter as ItemAddedEventArgs).Item as CustomNode).Name;
                if (itemName != null && (parameter as ItemAddedEventArgs).ItemSource != ItemSource.Stencil && ((parameter as ItemAddedEventArgs).Item is CustomNode))
                {
                    switch (itemName)
                    {
                        case "Toggle_switch":
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).ContentTemplate = App.Current.Resources["Toggle_switchNode"] as DataTemplate;
                            break;
                        case "Push_button":
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).ContentTemplate = App.Current.Resources["Push_buttonNode"] as DataTemplate;
                            break;
                        case "Clock":
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).ContentTemplate = App.Current.Resources["ClockNode"] as DataTemplate;
                            break;
                        case "High_Constant":
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).ContentTemplate = App.Current.Resources["High_ConstantNode"] as DataTemplate;
                            break;
                        case "LowConstant":
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).ContentTemplate = App.Current.Resources["LowConstantNode"] as DataTemplate;
                            break;
                        case "LightBulb":
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).ContentTemplate = App.Current.Resources["LightBulbNode"] as DataTemplate;
                            break;
                        case "4-BitDigit":
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).ContentTemplate = App.Current.Resources["FourBitDigitNode"] as DataTemplate;
                            break;
                        case "Buffer":
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).ContentTemplate = App.Current.Resources["BufferNode"] as DataTemplate;
                            break;
                        case "NOTGate":
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).ContentTemplate = App.Current.Resources["NOTGateNode"] as DataTemplate;
                            break;
                        case "ANDGate":
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).ContentTemplate = App.Current.Resources["ANDGateNode"] as DataTemplate;
                            break;
                        case "NANDGate":
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).ContentTemplate = App.Current.Resources["NANDGateNode"] as DataTemplate;
                            break;
                        case "ORGate":
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).ContentTemplate = App.Current.Resources["ORGateNode"] as DataTemplate;
                            break;
                        case "NORGate":
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).ContentTemplate = App.Current.Resources["NORGateNode"] as DataTemplate;
                            break;
                        case "XORGate":
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).ContentTemplate = App.Current.Resources["XORGateNode"] as DataTemplate;
                            break;
                        case "XNORGate":
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).ContentTemplate = App.Current.Resources["XNORGateNode"] as DataTemplate;
                            break;
                        case "Tri-State":
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).ContentTemplate = App.Current.Resources["Tri-StateNode"] as DataTemplate;
                            break;
                        case "SRFlip-Flop":
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).ContentTemplate = App.Current.Resources["SRFlip-FlopNode"] as DataTemplate;
                            break;
                        case "DFlip-Flop":
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).ContentTemplate = App.Current.Resources["DFlip-FlopNode"] as DataTemplate;
                            break;
                        case "JKFlip-Flop":
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).ContentTemplate = App.Current.Resources["JKFlip-FlopNode"] as DataTemplate;
                            break;
                        case "TFlip-Flop":
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).ContentTemplate = App.Current.Resources["TFlip-FlopNode"] as DataTemplate;
                            break;
                        case "Label":
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).ContentTemplate = null;
                            string content = "";
                            foreach (IAnnotation annotation in ((parameter as ItemAddedEventArgs).Item as CustomNode).Annotations as ObservableCollection<IAnnotation>)
                            {
                                content = (annotation as TextAnnotationViewModel).Text;
                            }

                            nodeTemplatePath = null;
                            //((parameter as ItemAddedEventArgs).Item as CustomNode).UnitHeight = double.NaN;
                            //((parameter as ItemAddedEventArgs).Item as CustomNode).UnitWidth = double.NaN;
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).Shape = App.Current.Resources["Rectangle"];
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).ShapeStyle = App.Current.Resources["ShapeStyle"] as Style;
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).Annotations = new AnnotationCollection()
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
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).ContentTemplate = App.Current.Resources["BusNode"] as DataTemplate;
                            break;
                        case "PullUp":
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).ContentTemplate = App.Current.Resources["PullUpNode"] as DataTemplate;
                            break;
                        case "PullDown":
                            ((parameter as ItemAddedEventArgs).Item as CustomNode).ContentTemplate = App.Current.Resources["PullDownNode"] as DataTemplate;
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
            if (args != null)
            {
                string itemName = (args.Source as CustomNode).Name;
                if (args.Source is CustomNode && ((args.Source as CustomNode).Shape == null) && ((args.Source as CustomNode).ContentTemplate) == null)
                {
                    foreach (NodePortViewModel nodeport in ((parameter as ItemDropEventArgs).Source as CustomNode).Ports as PortCollection)
                    {
                        nodeport.UnitHeight = 11 * this.ScrollSettings.ScrollInfo.CurrentZoom;
                        nodeport.UnitWidth = 11 * this.ScrollSettings.ScrollInfo.CurrentZoom;
                    }
                    (args.Source as CustomNode).ContentTemplate = nodeTemplatePath;
                    if (itemName != null)
                    {
                        switch (itemName)
                        {
                            case "Toggle_switch":
                                (args.Source as CustomNode).UnitHeight = 52;
                                (args.Source as CustomNode).UnitWidth = 70.5;
                                break;
                            case "Push_button":
                                (args.Source as CustomNode).UnitHeight = 43;
                                (args.Source as CustomNode).UnitWidth = 71;
                                break;
                            case "Clock":
                                (args.Source as CustomNode).UnitHeight = 36;
                                (args.Source as CustomNode).UnitWidth = 72;
                                break;
                            case "High_Constant":
                                (args.Source as CustomNode).UnitHeight = 42;
                                (args.Source as CustomNode).UnitWidth = 70;
                                break;
                            case "LowConstant":
                                (args.Source as CustomNode).UnitHeight = 42;
                                (args.Source as CustomNode).UnitWidth = 70;
                                break;
                            case "LightBulb":
                                (args.Source as CustomNode).UnitHeight = 83;
                                (args.Source as CustomNode).UnitWidth = 38;
                                break;
                            case "4-BitDigit":
                                (args.Source as CustomNode).UnitHeight = 65;
                                (args.Source as CustomNode).UnitWidth = 80;
                                break;
                            case "Buffer":
                            case "NOTGate":
                            case "ANDGate":
                            case "NANDGate":
                            case "ORGate":
                            case "NORGate":
                                (args.Source as CustomNode).UnitHeight = 32;
                                (args.Source as CustomNode).UnitWidth = 89;
                                break;
                            case "XORGate":
                            case "XNORGate":
                                (args.Source as CustomNode).UnitHeight = 33.474;
                                (args.Source as CustomNode).UnitWidth = 89;
                                break;
                            case "Tri-State":
                                (args.Source as CustomNode).UnitHeight = 52.485;
                                (args.Source as CustomNode).UnitWidth = 89;
                                break;
                            case "SRFlip-Flop":
                                (args.Source as CustomNode).UnitHeight = 85;
                                (args.Source as CustomNode).UnitWidth = 136;
                                break;
                            case "DFlip-Flop":
                            case "TFlip-Flop":
                                (args.Source as CustomNode).UnitHeight = 127;
                                (args.Source as CustomNode).UnitWidth = 149;
                                break;
                            case "JKFlip-Flop":
                                (args.Source as CustomNode).UnitHeight = 145;
                                (args.Source as CustomNode).UnitWidth = 149;
                                break;
                            case "Label":
                                (args.Source as CustomNode).UnitHeight = 26;
                                (args.Source as CustomNode).UnitWidth = 36;
                                break;
                            case "Bus":
                                (args.Source as CustomNode).UnitHeight = 42;
                                (args.Source as CustomNode).UnitWidth = 99;
                                break;
                            case "PullUp":
                            case "PullDown":
                                (args.Source as CustomNode).UnitHeight = 52;
                                (args.Source as CustomNode).UnitWidth = 99;
                                break;
                        }
                    }
                }
            }
        }

        public void OnDragEnterCommand(object parameter)
        {
            nodeTemplatePath = null;
            string itemName = ((parameter as ItemDropEventArgs).Source as CustomNode).Name;
            if ((parameter as ItemDropEventArgs).Source is CustomNode)
            {
                foreach (NodePortViewModel nodeport in ((parameter as ItemDropEventArgs).Source as CustomNode).Ports as PortCollection)
                {
                    nodeport.UnitHeight = 11 * this.ScrollSettings.ScrollInfo.CurrentZoom;
                    nodeport.UnitWidth = 11 * this.ScrollSettings.ScrollInfo.CurrentZoom;
                }
                switch (itemName)
                {
                    case "Toggle_switch":
                        nodeTemplatePath = App.Current.Resources["Toggle_switchNode"] as DataTemplate;
                        break;
                    case "Push_button":
                        nodeTemplatePath = App.Current.Resources["Push_buttonNode"] as DataTemplate;
                        break;
                    case "Clock":
                        nodeTemplatePath = App.Current.Resources["ClockNode"] as DataTemplate;
                        break;
                    case "High_Constant":
                        nodeTemplatePath = App.Current.Resources["High_ConstantNode"] as DataTemplate;
                        break;
                    case "LowConstant":
                        nodeTemplatePath = App.Current.Resources["LowConstantNode"] as DataTemplate;
                        break;
                    case "LightBulb":
                        nodeTemplatePath = App.Current.Resources["LightBulbNode"] as DataTemplate;
                        break;
                    case "4-BitDigit":
                        nodeTemplatePath = App.Current.Resources["FourBitDigitNode"] as DataTemplate;
                        break;
                    case "Buffer":
                        nodeTemplatePath = App.Current.Resources["BufferNode"] as DataTemplate;
                        break;
                    case "NOTGate":
                        nodeTemplatePath = App.Current.Resources["NOTGateNode"] as DataTemplate;
                        break;
                    case "ANDGate":
                        nodeTemplatePath = App.Current.Resources["ANDGateNode"] as DataTemplate;
                        break;
                    case "NANDGate":
                        nodeTemplatePath = App.Current.Resources["NANDGateNode"] as DataTemplate;
                        break;
                    case "ORGate":
                        nodeTemplatePath = App.Current.Resources["ORGateNode"] as DataTemplate;
                        break;
                    case "NORGate":
                        nodeTemplatePath = App.Current.Resources["NORGateNode"] as DataTemplate;
                        break;
                    case "XORGate":
                        nodeTemplatePath = App.Current.Resources["XORGateNode"] as DataTemplate;
                        break;
                    case "XNORGate":
                        nodeTemplatePath = App.Current.Resources["XNORNode"] as DataTemplate;
                        break;
                    case "Tri-State":
                        nodeTemplatePath = App.Current.Resources["Tri-StateNode"] as DataTemplate;
                        break;
                    case "SRFlip-Flop":
                        nodeTemplatePath = App.Current.Resources["SRFlip-FlopNode"] as DataTemplate;
                        break;
                    case "DFlip-Flop":
                        nodeTemplatePath = App.Current.Resources["DFlip-FlopNode"] as DataTemplate;
                        break;
                    case "JKFlip-Flop":
                        nodeTemplatePath = App.Current.Resources["JKFlip-FlopNode"] as DataTemplate;
                        break;
                    case "TFlip-Flop":
                        nodeTemplatePath = App.Current.Resources["TFlip-FlopNode"] as DataTemplate;
                        break;
                    case "Label":
                        nodeTemplatePath = App.Current.Resources["LabelNode"] as DataTemplate;
                        break;
                    case "Bus":
                        nodeTemplatePath = App.Current.Resources["BusNode"] as DataTemplate;
                        break;
                    case "PullUp":
                        nodeTemplatePath = App.Current.Resources["PullUpNode"] as DataTemplate;
                        break;
                    case "PullDown":
                        nodeTemplatePath = App.Current.Resources["PullDownNode"] as DataTemplate;
                        break;
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
            if ((this.SelectedItems as SelectorViewModel).Nodes != null && ((this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).Count() > 0)
            {
                foreach (var item in (this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>)
                {
                    (item as CustomNode).RotateAngle -= 90;
                }
            }
        }

        public void OnRotateColockwiseCommand(object parameter)
        {
            if ((this.SelectedItems as SelectorViewModel).Nodes != null && ((this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).Count() > 0)
            {
                foreach (var item in (this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>)
                {
                    (item as CustomNode).RotateAngle += 90;
                }
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
                    this.PanToolProperty = true;
                    this.IsPanToolSelected = true;
                    this.IsSelectToolSelected = false;
                }
                else
                {
                    this.IsSelectToolSelected = true;
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
            //("WDP File(*.wdp)|*.wdp") + ("BMP File(*.bmp)|*.bmp");

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
#endregion
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
