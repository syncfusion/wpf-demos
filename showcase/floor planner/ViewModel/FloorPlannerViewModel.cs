#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
using Syncfusion.Windows.Shared;
using Syncfusion.XPS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using IOPath = System.IO.Path;

namespace syncfusion.floorplanner.wpf
{
    public class FloorPlannerViewModel : DiagramViewModel
    {
        private bool showBackStage = true;
        private bool showMainView = false;
        private string selectedFileName;
        private string selectedFolderPath;
        private bool zoomInEnabled = true;
        private bool zoomOutEnabled = true;
        private double currentZoom = 1;
        private string zoomPercentageValue = "100%";
        private Rect contentBounds = Rect.Empty;
        private ShadowNode shadowNode = null;
        private ShadowConnector shadowConnector = null;
        private FloorPlannerDemo view;
        /// <summary>
        ///     The _ zoom parameter.
        /// </summary>
        private ZoomParameter _ZoomParameter;
        private string[] predefinedDiagram = new string[] { "Home Floor Plan" };
        private SymbolFilters symbolfilters;
        private SymbolFilterProvider selectedfilter;
        private QuickCommandViewModel splitQuickCommand;
        private QuickCommandViewModel strokeQuickCommand;

        public FloorPlannerViewModel() : base()
        {
            this.SelectedItems = new SelectorViewModel() { Commands = new QuickCommandCollection() };
            this.Nodes = new ObservableCollection<FloorPlanNode>();
            this.Connectors = new ObservableCollection<FloorPlanConnector>();
            this.Groups = new GroupCollection();
            this.Constraints |= GraphConstraints.Undoable;
            this.DefaultConnectorType = ConnectorType.Line;
            this.HorizontalRuler = new Ruler() { Orientation = Orientation.Horizontal };
            this.VerticalRuler = new Ruler() { Orientation = Orientation.Vertical };
            this.Theme = null;

            this.PrintingService = new PrintingService();
            this.PageSettings = new PageSettings()
            {
                PageOrientation = PageOrientation.Landscape,
                PageWidth = 1123,
                PageHeight = 794,
                MultiplePage = true,
                ShowPageBreaks = true,
                PageBackground = new System.Windows.Media.SolidColorBrush(Colors.Transparent)
            };
            this.SnapSettings = new SnapSettings()
            {
                SnapConstraints = SnapConstraints.Rotation | SnapConstraints.ShowLines,
                SnapToObject = SnapToObject.All, SnapAngle = 90
            };
            this.ScrollSettings = new ScrollSettings() { MinZoom = 0.3, MaxZoom = 3 };
            this.ExportSettings = new ExportSettings();
            this.CommandManager = new Syncfusion.UI.Xaml.Diagram.CommandManager() { Commands = new CommandCollection() };

            this.BackStageOpeningCommand = new DelegateCommand(OnBackStageOpening);
            this.CreateCommand = new DelegateCommand(OnCreate);
            this.OpenCommand = new DelegateCommand(OnOpen);
            this.ExternalOpenCommand = new DelegateCommand(OnExternalOpen);
            this.LoadTemplateCommand = new DelegateCommand(OnTemplateLoad);
            this.SaveCommand = new DelegateCommand(OnSave);
            this.PrintCommand = new DelegateCommand(OnPrint);
            this.ExportCommand = new DelegateCommand(OnExport);

            this.ItemAddedCommand = new DelegateCommand(OnItemAdded);
            this.ItemSelectingCommand = new DelegateCommand(OnItemSelecting);
            this.ItemUnSelectingCommand = new DelegateCommand(OnItemUnSelecting);
            this.ViewPortChangedCommand = new DelegateCommand(OnViewPortChanged);
            this.ConnectorEditingCommand = new DelegateCommand(OnConnectorEditing);
            this.ZoomInCommand = new DelegateCommand(OnZoomInCommand);
            this.ZoomOutCommand = new DelegateCommand(OnZoomOutCommand);
            this.SplitCommand = new DelegateCommand(OnWallSpliting);
            this.StrokeChangeCommand = new DelegateCommand(OnStrokeChanging);

            this.Symbolfilters = new SymbolFilters();
            this.Symbolfilters.Add(new SymbolFilterProvider { Content = "Doors", IsChecked = true, SymbolFilter = Filter });
            this.Symbolfilters.Add(new SymbolFilterProvider { Content = "Dining Room", IsChecked = true, SymbolFilter = Filter });
            this.Symbolfilters.Add(new SymbolFilterProvider { Content = "Living Room", IsChecked = true, SymbolFilter = Filter });
            this.Symbolfilters.Add(new SymbolFilterProvider { Content = "Bedroom", IsChecked = true, SymbolFilter = Filter });
            this.Symbolfilters.Add(new SymbolFilterProvider { Content = "Kitchen", IsChecked = true, SymbolFilter = Filter });
            this.Symbolfilters.Add(new SymbolFilterProvider { Content = "Bathroom", IsChecked = true, SymbolFilter = Filter });
            this.Symbolfilters.Add(new SymbolFilterProvider { Content = "Basic Shapes", IsChecked = false, SymbolFilter = Filter });

            this.Selectedfilter = Symbolfilters[2];
            this.ZoomParameter = new ZoomParameter();
            this.UpdateQuickCommands();
            this.UpdateCommandGesture();
        }
        /// <summary>
        ///     Gets or sets the zoom parameter.
        /// </summary>
        public ZoomParameter ZoomParameter
        {
            get
            {
                return this._ZoomParameter;
            }

            set
            {
                if (this._ZoomParameter != value)
                {
                    this._ZoomParameter = value;
                    this.OnPropertyChanged("ZoomParameter");
                }
            }
        }

        public FloorPlannerDemo View
        {
            get
            {
                return this.view;
            }
            set
            {
                if (this.view != value)
                {
                    this.view = value;
                    this.PopulateRecentFiles();
                    this.PopulateTemplateFiles();
                    this.OnPropertyChanged("View");
                }
            }
        }

        public ICommand BackStageOpeningCommand { get; set; }

        public ICommand CreateCommand { get; set; }

        public ICommand OpenCommand { get; set; }

        public ICommand ExternalOpenCommand { get; set; }

        public ICommand LoadTemplateCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        public ICommand PrintCommand { get; set; }

        public ICommand ExportCommand { get; set; }
        
        public ICommand ZoomInCommand { get; set; }
        
        public ICommand ZoomOutCommand { get; set; }

        public ICommand SplitCommand { get; set; }

        public ICommand StrokeChangeCommand { get; set; }

        public bool ShowBackStage
        {
            get
            {
                return showBackStage;
            }
            set
            {
                if (showBackStage != value)
                {
                    showBackStage = value;
                    this.OnPropertyChanged("ShowBackStage");
                }
            }
        }

        public bool ShowMainView
        {
            get
            {
                return showMainView;
            }
            set
            {
                if (showMainView != value)
                {
                    showMainView = value;
                    this.OnPropertyChanged("ShowMainView");
                }
            }
        }

        public string SelectedFileName
        {
            get
            {
                return selectedFileName;
            }
            set
            {
                if (selectedFileName != value)
                {
                    selectedFileName = value;
                    this.OnPropertyChanged("SelectedFileName");
                }
            }
        }

        public string SelectedFolderPath
        {
            get
            {
                return selectedFolderPath;
            }
            set
            {
                if (selectedFolderPath != value)
                {
                    selectedFolderPath = value;
                    this.OnPropertyChanged("SelectedFolderName");
                }
            }
        }

        public bool ZoomInEnabled
        {
            get
            {
                return zoomInEnabled;
            }
            set
            {
                if (zoomInEnabled != value)
                {
                    zoomInEnabled = value;
                    OnPropertyChanged("ZoomInEnabled");
                }
            }
        }

        public bool ZoomOutEnabled
        {
            get
            {
                return zoomOutEnabled;
            }
            set
            {
                if (zoomOutEnabled != value)
                {
                    zoomOutEnabled = value;
                    OnPropertyChanged("ZoomOutEnabled");
                }
            }
        }

        public double CurrentZoom
        {
            get
            {
                return currentZoom;
            }
            set
            {
                if (currentZoom != value)
                {
                    currentZoom = value;
                    OnPropertyChanged("CurrentZoom");
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
                    zoomPercentageValue = value;
                    OnPropertyChanged("ZoomPercentageValue");
                }
            }
        }

        public SymbolFilters Symbolfilters
        {
            get
            {
                return symbolfilters;
            }
            set
            {
                symbolfilters = value;
                OnPropertyChanged("Symbolfilters");
            }
        }

        public SymbolFilterProvider Selectedfilter
        {
            get
            {
                return selectedfilter;
            }
            set
            {
                selectedfilter = value;
                OnPropertyChanged("Selectedfilter");
            }
        }

        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);

            if (name == "CurrentZoom")
            {
                (this.Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParameter()
                {
                    ZoomCommand = ZoomCommand.Zoom,
                    ZoomTo = currentZoom,
                });
            }
            else if (name == "ZoomPercentageValue")
            {
                var zoomValue = Convert.ToDouble(zoomPercentageValue.Split('%')[0]) / 100;
                (this.Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParameter()
                {
                    ZoomCommand = ZoomCommand.Zoom,
                    ZoomTo = zoomValue,
                });
            }
        }

        private void OnBackStageOpening(object obj)
        {
            if (!string.IsNullOrEmpty(this.selectedFileName))
            {
                this.SaveSelectedFile();

                RecentFileButton currentFileButton = null;
                foreach (var element in this.View.RecentArea.Children)
                {
                    if ((element as RecentFileButton).FileName == this.selectedFileName)
                    {
                        currentFileButton = element as RecentFileButton;
                        break;
                    }
                }

                if (currentFileButton != null)
                {
                    this.View.RecentArea.Children.Remove(currentFileButton);
                    this.View.RecentArea.Children.Insert(0, currentFileButton);
                }

                this.SelectedFileName = String.Empty;
                this.ShowMainView = false;
                this.ShowBackStage = true;
            }
        }

        private void OnCreate(object fileName)
        {
            this.CreateFile(fileName.ToString(), true);
            FocusManager.SetFocusedElement(this.View, this.View.Diagram);
            this.ShowMainView = true;
            this.ShowBackStage = false;
        }

        private void CreateFile(string fileName, bool resetDiagram = false)
        {
            this.SelectedFileName = IOPath.GetFileNameWithoutExtension(fileName.ToString());
            this.SelectedFolderPath = IOPath.GetDirectoryName(fileName.ToString());
            if (File.Exists(IOPath.Combine(this.selectedFolderPath, this.selectedFileName + ".xml")))
            {
                int i = 1;
                do
                {
                    i++;
                }
                while (File.Exists(IOPath.Combine(this.selectedFolderPath, this.selectedFileName + "(" + i + ")" + ".xml")));
                this.SelectedFileName = string.Format("{0}({1})", this.selectedFileName, i);
            }

            using (Stream stream = File.Create(this.selectedFolderPath + @"\" + this.selectedFileName + ".xml"))
            {
                stream.SetLength(0);
                if (resetDiagram)
                {
                    this.Nodes = new ObservableCollection<FloorPlanNode>();
                    this.Connectors = new ObservableCollection<FloorPlanConnector>();
                    this.Groups = new GroupCollection();
                    this.PageSettings.PageBackground = new System.Windows.Media.SolidColorBrush(Colors.Transparent);
                    if (this.ScrollSettings.ScrollInfo != null)
                    {
                        (this.Info as IGraphInfo).Commands.Reset.Execute(null);
                    }

                    //(this.Info as IGraphInfo).Save(stream);
                    this.AddShadowObject(true);
                    this.AddShadowObject();
                    (this.Info as IGraphInfo).ClearHistory();
                }
            }

            this.PopulateRecentFiles(true);
        }

        private void OnTemplateLoad(object fileName)
        {
            this.SelectedFileName = IOPath.GetFileNameWithoutExtension(fileName.ToString());
            this.SelectedFolderPath = IOPath.GetDirectoryName(fileName.ToString());
            this.PopulateRecentFiles(true);
            this.OnOpenSelectedFile();
        }

        private void OnExternalOpen(object obj)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                this.SelectedFileName = IOPath.GetFileNameWithoutExtension(dialog.FileName);
                this.SelectedFolderPath = IOPath.GetDirectoryName(dialog.FileName);
                this.PopulateRecentFiles(true);
                this.OnOpenSelectedFile();
            }
        }

        private void OnOpen(object fileName)
        {
            this.SelectedFileName = IOPath.GetFileNameWithoutExtension(fileName.ToString());
            this.SelectedFolderPath = IOPath.GetDirectoryName(fileName.ToString());
            this.OnOpenSelectedFile();
        }

        private void OnOpenSelectedFile()
        {
            var fileName = IOPath.Combine(this.selectedFolderPath, this.selectedFileName + ".xml");
            if (File.Exists(fileName))
            {
                using (Stream stream = File.Open(fileName, FileMode.Open))
                {
                    (this.Info as IGraphInfo).Load(stream);
                }

                var shadowNode1 = (this.Nodes as ObservableCollection<FloorPlanNode>).FirstOrDefault(e => e is ShadowNode);
                if(shadowNode1 != null)
                {
                    (this.Nodes as ObservableCollection<FloorPlanNode>).Remove(shadowNode1);
                }

                var shadowConnector1 = (this.Connectors as ObservableCollection<FloorPlanConnector>).FirstOrDefault(e => e is ShadowConnector);
                if (shadowConnector1 != null)
                {
                    (this.Connectors as ObservableCollection<FloorPlanConnector>).Remove(shadowConnector1);
                }

                this.AddShadowObject(true);
                this.AddShadowObject();

                (this.Info as IGraphInfo).ClearHistory();
                FocusManager.SetFocusedElement(this.View, this.View.Diagram);
                this.ShowMainView = true;
                this.ShowBackStage = false;
            }
        }

        private void AddShadowObject(bool isNode = false)
        {
            if (isNode)
            {
                shadowNode = new ShadowNode();
                (this.Nodes as ObservableCollection<FloorPlanNode>).Add(shadowNode);
            }
            else
            {
                shadowConnector = new ShadowConnector();
                (this.Connectors as ObservableCollection<FloorPlanConnector>).Add(shadowConnector);
            }
        }

        private void OnSave(object parameter)
        {
            if (parameter != null && parameter.ToString() == "Save As")
            {
                var dialog = new SaveFileDialog()
                {
                    Title = "Save Plan",
                    Filter = "XML File (*.xml)|*.xml",
                    InitialDirectory = IOPath.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FloorPlanner")
                };
                if (dialog.ShowDialog() == true)
                {
                    this.CreateFile(dialog.FileName);
                    this.SaveSelectedFile();
                }
            }
            else if (!(string.IsNullOrEmpty(this.selectedFolderPath) || string.IsNullOrEmpty(this.selectedFileName)))
            {
                this.SaveSelectedFile();
            }
        }

        private void SaveSelectedFile()
        {
            var fullFileName = IOPath.Combine(this.selectedFolderPath, selectedFileName + ".xml");
            if (File.Exists(fullFileName))
            {
                using (Stream stream = File.Open(fullFileName, FileMode.OpenOrCreate))
                {
                    stream.SetLength(0);
                    (this.Info as IGraphInfo).Save(stream);
                }
            }
        }

        private void OnPrint(object parameter)
        {
            if (!string.IsNullOrEmpty(this.selectedFileName))
            {
                this.PrintingService.ShowDialog = true;
                this.PrintingService.Print();
            }
        }

        private void OnExport(object parameter)
        {
            var Extension = "BMP File (*.bmp)|*.bmp|WDP File (*.wdp)|*.wdp|JPG File(*.jpg)|*.jpg|PNG File(*.png)|*.png|TIF File(*.tif)|*.tif|GIF File(*.gif)|*.gif|XPS File(*.xps)|*.xps|PDF File(*.pdf)|*.pdf";
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = Extension;            
            ExportSettings.ExportBackground = new System.Windows.Media.SolidColorBrush(Colors.White);

            if (saveFileDialog.ShowDialog() == true)
            {
                string filenamechanged;
                var extension = IOPath.GetExtension(saveFileDialog.FileName).TrimStart('.');
                string fileName = System.IO.Path.ChangeExtension(saveFileDialog.FileName, null);
                if (extension != "")
                {
                    if (extension.ToLower() != this.ExportSettings.ExportType.ToString().ToLower())
                    {
                        switch (extension.ToLower())
                        {
                            case "png":
                                this.ExportSettings.ExportType = ExportType.PNG;
                                break;
                            case "jpg":
                                this.ExportSettings.ExportType = ExportType.JPEG;
                                break;
                            case "bmp":
                                this.ExportSettings.ExportType = ExportType.BMP;
                                break;
                            case "wdp":
                                this.ExportSettings.ExportType = ExportType.WDP;
                                break;
                            case "gif":
                                this.ExportSettings.ExportType = ExportType.GIF;
                                break;
                            case "tif":
                                this.ExportSettings.ExportType = ExportType.TIF;
                                break;
                        }
                    }

                    if (extension.ToLower() == "pdf")
                    {
                        filenamechanged = fileName + ".xps";
                        ExportSettings.IsSaveToXps = true;
                        this.ExportSettings.FileName = filenamechanged;
                        
                        // Method to Export the SfDiagram
                        (this.Info as IGraphInfo).Export();
                        
                        var converter = new XPSToPdfConverter { };
                        var document = new PdfDocument();
                        document = converter.Convert(filenamechanged);
                        fileName = fileName + ".pdf";
                        document.Save(fileName);
                        document.Close(true);
                    }
                    else
                    {
                        if (extension.ToLower() == "xps")
                        {
                            ExportSettings.IsSaveToXps = true;
                        }

                        this.ExportSettings.FileName = fileName;
                        (this.Info as IGraphInfo).Export();
                    }
                }
            }
        }

        private void OnItemAdded(object parameter)
        {
            var args = parameter as ItemAddedEventArgs;
            if (args.Item is INode)
            {
                var node = args.Item as INode;
                if (View.Resources[node.Name] is DataTemplate)
                {
                    node.ContentTemplate = View.Resources[node.Name] as DataTemplate;
                    node.Annotations = null;
                }
                else if (View.Resources[node.Name] is string)
                {
                    node.Shape = View.Resources[node.Name] as string;
                    node.Annotations = null;
                }
            }
            if (args.Item is IConnector)
                (args.Item as IConnector).Constraints = ConnectorConstraints.Default | ConnectorConstraints.Draggable;
        }

        private void OnItemSelecting(object parameter)
        {
            var args = parameter as DiagramPreviewEventArgs;
            this.ShowQuickCommand(args.Item as FloorPlanConnector);
        }

        private void OnItemUnSelecting(object parameter)
        {
            shadowNode.Hide();
        }

        private void ShowQuickCommand(FloorPlanConnector connector)
        {
            splitQuickCommand.VisibilityMode = VisibilityMode.Connector;
            strokeQuickCommand.VisibilityMode = VisibilityMode.Connector;

            if (connector != null)
            {
                if ((connector.Segments as IEnumerable<IConnectorSegment>).Count() > 1)
                {
                    splitQuickCommand.VisibilityMode = VisibilityMode.Node;
                }
            }
        }

        private void OnViewPortChanged(object parameter)
        {
            var args = parameter as ChangeEventArgs<object, ScrollChanged>;
            ZoomInEnabled = !(args.NewValue.CurrentZoom >= this.ScrollSettings.MaxZoom);
            ZoomOutEnabled = !(args.NewValue.CurrentZoom <= this.ScrollSettings.MinZoom);
            CurrentZoom = args.NewValue.CurrentZoom;
            ZoomPercentageValue = Math.Round(currentZoom * 100, 2).ToString() + "%";
            contentBounds = args.NewValue.ContentBounds;
            if (this.ZoomParameter != null)
            {
                var text = this.ZoomParameter.PercentageText;
                this.ZoomParameter.IsFiftyPercentZoom = this.ZoomParameter.IsHundredPercentZoom = this.ZoomParameter.IsOneFiftyPercentZoom = this.ZoomParameter.IsPageWidthZoom = this.ZoomParameter.IsPercentageZoom =
                    this.ZoomParameter.IsSeventyFivePercentZoom = this.ZoomParameter.IsTwoHundredPercentZoom = this.ZoomParameter.IsWholePageZoom = false;
                if (text != "Width" && text != "Page")
                {
                    this.ZoomParameter.PercentageText = Math.Floor(this.CurrentZoom * 100).ToString();

                    if (text == "200")
                    {
                        this.ZoomParameter.IsTwoHundredPercentZoom = true;
                    }
                    else if (text == "150")
                    {
                        this.ZoomParameter.IsOneFiftyPercentZoom = true;
                    }
                    else if (text == "100")
                    {
                        this.ZoomParameter.IsHundredPercentZoom = true;
                    }
                    else if (text == "75")
                    {
                        this.ZoomParameter.IsSeventyFivePercentZoom = true;
                    }
                    else if (text == "50")
                    {
                        this.ZoomParameter.IsFiftyPercentZoom = true;
                    }
                    else
                    {
                        this.ZoomParameter.IsPercentageZoom = true;
                    }
                }
                else if (text == "Width")
                {
                    this.ZoomParameter.IsPageWidthZoom = true;
                }
                else if (text == "Page")
                {
                    this.ZoomParameter.IsWholePageZoom = true;
                }
                else
                {
                    this.ZoomParameter.IsPercentageZoom = true;
                }
            }

        }

        private void OnConnectorEditing(object parameter)
        {
            var args = parameter as ConnectorEditingEventArgs;
            if (args.DragState == DragState.Started)
            {
                shadowNode.Hide();
            }
            else if (args.DragState == DragState.Dragging)
            {
                var connector = args.Item as FloorPlanConnector;
                var startPoint = connector.SourcePoint;
                var endPoint = connector.TargetPoint;
                var segments = connector.Segments as IEnumerable<IConnectorSegment>;
                if (segments.Count() > 1)
                {
                    if (args.ControlPointType == ControlPointType.TargetPoint)
                    {
                        startPoint = (segments.First() as StraightSegment).Point.Value;
                    }
                    else
                    {
                        endPoint = (segments.First() as StraightSegment).Point.Value;
                    }
                }

                var length = startPoint.FindLength(endPoint);
                var angle = startPoint.FindAngle(endPoint);
                shadowConnector.SourcePoint = startPoint.Transform(25, angle - 90);
                shadowConnector.TargetPoint = endPoint.Transform(25, angle - 90);
                (shadowConnector.Annotations as AnnotationCollection)[0].Content = length.Feetwithinches();
                shadowConnector.Show();
            }
            else if (args.DragState == DragState.Completed)
            {
                shadowConnector.Hide();
                this.ShowQuickCommand(args.Item as FloorPlanConnector);
            }
        }

        private void PopulateTemplateFiles()
        {
            foreach (var name in predefinedDiagram)
            {
                var templateFileButton = new TemplateFileButton() { FileName = name, Command = LoadTemplateCommand, ImagePath = "/syncfusion.floorplanner.wpf;component/Asset/FloorPlanner.png" };
                this.View.TemplateArea.Children.Add(templateFileButton);
            }
        }

        private void PopulateRecentFiles(bool singleFile = false)
        {
            if (!singleFile)
            {
                var folderPath = IOPath.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FloorPlanner");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                DirectoryInfo info = new DirectoryInfo(folderPath);
                FileInfo[] files = info.GetFiles().OrderByDescending(p => p.LastWriteTime).ToArray();
                foreach (var file in files)
                {
                    string extension = IOPath.GetExtension(file.Name);
                    string recentFileName = file.Name.Substring(0, file.Name.Length - extension.Length);
                    var recentFileButton = new RecentFileButton() { FileName = recentFileName, FolderPath = folderPath, Command = OpenCommand };
                    this.View.RecentArea.Children.Add(recentFileButton);
                }
            }
            else
            {
                var recentFileButton = new RecentFileButton() { FileName = this.selectedFileName, FolderPath = this.selectedFolderPath, Command = OpenCommand };
                this.View.RecentArea.Children.Insert(0, recentFileButton);
            }
        }
        /// <summary>
        /// Represents the zoom command execution.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public void OnZoomCommand(object value)
        {
            if (value != null)
            {
                if (this.IsDigitsOnly(value.ToString()) && value.ToString() != string.Empty)
                {
                    double _mZoomValue = Convert.ToDouble(value) / 100;
                    (this.Info as IGraphInfo).Commands.Zoom.Execute(
                        new ZoomPositionParameter { ZoomTo = _mZoomValue, ZoomCommand = ZoomCommand.Zoom });
                }
                else if (value.ToString() == "Whole Page")
                {
                    (this.Info as IGraphInfo).Commands.FitToPage.Execute(
                        new FitToPageParameter { FitToPage = FitToPage.FitToPage, Region = Region.PageSettings });
                }
                else if (value.ToString() == "Page Width")
                {
                    (this.Info as IGraphInfo).Commands.FitToPage.Execute(
                        new FitToPageParameter { FitToPage = FitToPage.FitToWidth, Region = Region.PageSettings });
                }
            }
        }
        /// <summary>
        /// The is digits only.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsDigitsOnly(string value)
        {
            foreach (char c in value)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return true;
        }

        private void OnZoomInCommand(object parameter)
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

        private void OnZoomOutCommand(object parameter)
        {
            (this.Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParameter()
            {
                ZoomCommand = ZoomCommand.ZoomOut,
                ZoomFactor = 0.2,
            });
        }

        private void OnWallSpliting(object parameter)
        {
            var selectedItem = this.SelectedItems as SelectorViewModel;
            var selectedConnector = (selectedItem.Connectors as IEnumerable<object>).FirstOrDefault() as IConnector;
            if (selectedConnector != null)
            {
                splitQuickCommand.VisibilityMode = VisibilityMode.Node;
                var x = (selectedConnector.SourcePoint.X + selectedConnector.TargetPoint.X) / 2;
                var y = (selectedConnector.SourcePoint.Y + selectedConnector.TargetPoint.Y) / 2;
                selectedConnector.Segments = new ConnectorSegments()
                {
                    new StraightSegment() { Point = new Point(x,y) },
                    new StraightSegment()
                };
            }
        }

        private void OnStrokeChanging(object parameter)
        {
            var selectedItem = this.SelectedItems as SelectorViewModel;
            var selectedConnector = (selectedItem.Connectors as IEnumerable<object>).FirstOrDefault() as IConnector;
            if (selectedConnector != null)
            {
                splitQuickCommand.VisibilityMode = VisibilityMode.Node;
                strokeQuickCommand.VisibilityMode = VisibilityMode.Node;
                
                var startPoint = selectedConnector.SourcePoint;
                var endPoint = selectedConnector.TargetPoint;
                var segments = selectedConnector.Segments as IEnumerable<IConnectorSegment>;
                if (segments.Count() > 1)
                {
                    endPoint = (segments.First() as StraightSegment).Point.Value;
                }

                var angle = startPoint.FindAngle(endPoint);
                var x = (startPoint.X + endPoint.X) / 2;
                var y = (startPoint.Y + endPoint.Y) / 2;
                var newOffset = new Point(x, y).Transform(70, angle - 90);
                shadowNode.OffsetX = newOffset.X;
                shadowNode.OffsetY = newOffset.Y;
                shadowNode.TargetConnector = selectedConnector as FloorPlanConnector;
                shadowNode.Show();
            }
        }

        private bool Filter(SymbolFilterProvider sender, object symbol)
        {
            if (sender.Content.ToString() == (symbol as FloorPlanNode).Key.ToString())
            {
                return true;
            }

            return false;
        }

        private void UpdateQuickCommands()
        {
            var fillColor = (System.Windows.Media.SolidColorBrush)new BrushConverter().ConvertFromString("White");
            var strokeColor = (System.Windows.Media.SolidColorBrush)new BrushConverter().ConvertFromString("#444444");
            var resource = new System.Windows.ResourceDictionary() { Source = new Uri(@"/syncfusion.floorplanner.wpf;component/Template/FloorPlanDictionary.xaml", UriKind.RelativeOrAbsolute) };
            var quickCommandStyle = new Style() { TargetType = typeof(System.Windows.Shapes.Path) };
            quickCommandStyle.Setters.Add(new Setter() { Property = System.Windows.Shapes.Path.StretchProperty, Value = Stretch.Fill });
            quickCommandStyle.Setters.Add(new Setter() { Property = System.Windows.Shapes.Path.FillProperty, Value = fillColor });
            quickCommandStyle.Setters.Add(new Setter() { Property = System.Windows.Shapes.Path.StrokeProperty, Value = strokeColor });

            splitQuickCommand = new QuickCommandViewModel()
            {
                Shape = new EllipseGeometry() { RadiusX = 28, RadiusY = 28 },
                ShapeStyle = quickCommandStyle,
                Length = 1,
                Margin = new Thickness(0, -25, 0, 0),
                VisibilityMode = VisibilityMode.Connector,
                Command = this.SplitCommand,
                ContentTemplate = resource["SplitCommandIcon"] as DataTemplate
            };

            strokeQuickCommand = new QuickCommandViewModel()
            {
                Shape = new EllipseGeometry() { RadiusX = 28, RadiusY = 28 },
                ShapeStyle = quickCommandStyle,
                Length = 0,
                Margin = new Thickness(0, -25, 0, 0),
                VisibilityMode = VisibilityMode.Connector,
                Command = this.StrokeChangeCommand,
                ContentTemplate = resource["StrokeCommandIcon"] as DataTemplate,
            };

            var quickCommandCollection = (this.SelectedItems as SelectorViewModel).Commands as QuickCommandCollection;
            quickCommandCollection.Add(splitQuickCommand);
            quickCommandCollection.Add(strokeQuickCommand);
        }

        private void UpdateCommandGesture()
        {
            var saveGesture = new GestureCommand()
            {
                Command = SaveCommand,
                Gesture = new Gesture
                {
                    KeyModifiers = ModifierKeys.Control,
                    KeyState = KeyStates.Down,
                    Key = System.Windows.Input.Key.S
                }
            };

            var printGesture = new GestureCommand()
            {
                Command = PrintCommand,
                Gesture = new Gesture
                {
                    KeyModifiers = ModifierKeys.Control,
                    KeyState = KeyStates.Down,
                    Key = System.Windows.Input.Key.P
                }
            };

            this.CommandManager.Commands.Add(saveGesture);
            this.CommandManager.Commands.Add(printGesture);
        }
    }
}
