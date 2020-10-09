// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagramVM.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the custom class for DiagramViewModel.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Brainstorming.ViewModel;
using DiagramBuilder.Utility;
using FlowChart.ViewModel;

using Microsoft.Win32;
using OrganizationChart.ViewModel;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Layout;

namespace DiagramBuilder.ViewModel
{
    /// <summary>
    ///     Represents the custom class for DiagramViewModel.
    /// </summary>
    public class DiagramVM : DiagramViewModel, IDiagramViewModel
    {
        /// <summary>
        ///     The _file.
        /// </summary>
        private string _file;

        /// <summary>
        ///     The _is export.
        /// </summary>
        private bool _isExport;

        /// <summary>
        ///     The _is selected.
        /// </summary>
        private bool _isSelected;

        /// <summary>
        ///     The _is valid xml.
        /// </summary>
        private bool _isValidXml;

        /// <summary>
        ///     The _m diagram type.
        /// </summary>
        private DiagramType _mDiagramType;

        /// <summary>
        ///     The _m enable pan zoom.
        /// </summary>
        private bool _mEnablePanZoom;

        /// <summary>
        ///     The _m enable size position.
        /// </summary>
        private bool _mEnableSizePosition;

        /// <summary>
        ///     The _m is busy.
        /// </summary>
        private Visibility _mIsBusy = Visibility.Visible;

        /// <summary>
        ///     The _m is draw text node.
        /// </summary>
        private bool _mIsDrawTextNode;

        /// <summary>
        ///     The _m is non empty.
        /// </summary>
        private bool _mIsNonEmpty;

        /// <summary>
        ///     The _m shape.
        /// </summary>
        private string _mShape = "Rectangle";

        /// <summary>
        ///     The _name.
        /// </summary>
        private string _name;

        /// <summary>
        ///     The installed location.
        /// </summary>
        private string installedLocation;

        /// <summary>
        /// visibility for Organization chart
        /// </summary>
        private Visibility _mOrgChart = Visibility.Collapsed; 
        

        /// <summary>
        ///     Initializes a new instance of the <see cref="DiagramVM" /> class.
        /// </summary>
        public DiagramVM()
        {
        }

        // StorageFile file, 
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagramVM"/> class.
        /// </summary>
        /// <param name="file">
        /// The file.
        /// </param>
        /// <param name="isValidXml">
        /// The is valid xml.
        /// </param>
        public DiagramVM(string file, bool isValidXml)
        {
            this._isValidXml = isValidXml;
            this._file = file;
            this.Title = "Page";
            if (this is OrganizationChartDiagramVM)
            {
                this.DiagramType = DiagramType.OrganizationChart;
            }
            else if(this is BrainstormingVM)
            {
                this.DiagramType = DiagramType.Brainstorming;
            }
            else if(this is FlowDiagramVm)
            {
                this.DiagramType = DiagramType.FlowChart;
            }
            else
            {
                this.DiagramType = DiagramType.Blank;
            }
            this.Nodes = new ObservableCollection<NodeVM>();
            this.Connectors = new ObservableCollection<ConnectorVM>();
            this.Groups = new ObservableCollection<GroupVM>();
            this.SelectedItems = new SelectorVM(this);
            this.PortVisibility = PortVisibility.MouseOverOnConnect;
            this.FirstLoad = new Command(this.OnViewLoaded);
            this.HistoryManager = new CustomHistoryManager();
            this.SnapSettings = new SnapSettings
                                    {
                                        SnapConstraints = SnapConstraints.All, SnapToObject = SnapToObject.All
                                    };

            // Theme = new OfficeTheme();
            this.PreviewSettings = new PreviewSettings { PreviewMode = PreviewMode.Preview };
            LayoutManager = new LayoutManager();
            DataSourceSettings = new DataSourceSettings();
            this.PageSettings = new PageVM();
            this.ScrollSettings = new ScrollSettings();
            (this.PageSettings as PageVM).InitDiagram(this);

            this.HorizontalRuler = new Ruler { Orientation = Orientation.Horizontal };
            this.VerticalRuler = new Ruler { Orientation = Orientation.Vertical };
            this.InitLocation();
            this.PrintingService = new PrintingService();
            this.ExportSettings = new ExportSettings
                                      {
                                          ImageStretch = Stretch.Uniform, ExportMode = ExportMode.PageSettings
                                      };
#if SyncfusionFramework4_5_1
            ExportSettings = new ExportSettings()
            {
                ImageStretch = Stretch.Uniform,
                ExportMode = ExportMode.PageSettings
            };
            PrintingService = new PrintingService();
#endif
            this.FlipCommand = new Command(this.OnFlipCommand);
            this.ExportCommand = new Command(this.OnExportCommand);
            this.PrintCommand = new Command(this.OnPrintCommand);
            this.AddImageNode = new Command(this.OnAddImageNodeCommand);
            this.PageOrientationCommand = new Command(this.OnPageOrientationCommand);
            this.PageSizeCommand = new Command(this.OnPageSizeCommand);
            this.ConnectTypeCommand = new Command(this.OnConnectTypeCommand);
            this.SingleSelect = new Command(this.OnSingleSelectCommand);
            this.SizeAndPositionCommand = new Command(this.OnSizeAndPositionCommand);
            this.PanZoomCommand = new Command(this.OnPanZoomCommand);
            this.FitToWidthCommand = new Command(this.OnFitToWidthCommand);
            this.FitToPageCommand = new Command(this.OnFitToPageCommand);
            this.Constraints |= GraphConstraints.Undoable;
        }

        /// <summary>
        ///     Gets or sets the add image node.
        /// </summary>
        public ICommand AddImageNode { get; set; }

        /// <summary>
        ///     Gets the connector collection.
        /// </summary>
        public ObservableCollection<ConnectorVM> ConnectorCollection
        {
            get
            {
                return this.Connectors as ObservableCollection<ConnectorVM>;
            }
        }

        /// <summary>
        ///     Gets or sets the connect type command.
        /// </summary>
        public ICommand ConnectTypeCommand { get; set; }

        /// <summary>
        ///     Gets or sets the delete action.
        /// </summary>
        public ICommand Delete { get; set; }

        /// <summary>
        ///     Gets or sets the diagram type.
        /// </summary>
        [DataMember]
        public DiagramType DiagramType
        {
            get
            {
                return this._mDiagramType;
            }

            set
            {
                if (this._mDiagramType != value)
                {
                    this._mDiagramType = value;
                    this.OnPropertyChanged("Type");
                }
            }
        }

        /// <summary>
        /// Gets or sets the visibility for Organization chart
        /// </summary>
        
        [DataMember]
        public Visibility OrgChart
        {
            get { return _mOrgChart; }
            set
            {
                if (_mOrgChart != value)
                {
                    _mOrgChart = value;
                    OnPropertyChanged("OrgChart");
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether enable pan zoom or not.
        /// </summary>
        public bool EnablePanZoom
        {
            get
            {
                return this._mEnablePanZoom;
            }

            set
            {
                if (this._mEnablePanZoom != value)
                {
                    this._mEnablePanZoom = value;
                    this.OnPropertyChanged("EnablePanZoom");
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether enable size position or not.
        /// </summary>
        public bool EnableSizePosition
        {
            get
            {
                return this._mEnableSizePosition;
            }

            set
            {
                if (this._mEnableSizePosition != value)
                {
                    this._mEnableSizePosition = value;
                    this.OnPropertyChanged("EnableSizePosition");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the export command.
        /// </summary>
        public ICommand ExportCommand { get; set; }

        /// <summary>
        ///     Gets or sets the first load.
        /// </summary>
        public ICommand FirstLoad { get; set; }

        /// <summary>
        ///     Gets or sets the fit to page command.
        /// </summary>
        public ICommand FitToPageCommand { get; set; }

        // public ICommand SelectTextCommand { get; set; }
        /// <summary>
        ///     Gets or sets the fit to width command.
        /// </summary>
        public ICommand FitToWidthCommand { get; set; }

        /// <summary>
        ///     Gets or sets the flip command.
        /// </summary>
        public ICommand FlipCommand { get; set; }

        /// <summary>
        ///     Gets the group collection.
        /// </summary>
        public ObservableCollection<GroupVM> GroupCollection
        {
            get
            {
                return this.Groups as ObservableCollection<GroupVM>;
            }
        }

        /// <summary>
        ///     Gets or sets the is busy.
        /// </summary>
        public Visibility IsBusy
        {
            get
            {
                return this._mIsBusy;
            }

            set
            {
                if (this._mIsBusy != value)
                {
                    this._mIsBusy = value;
                    this.OnPropertyChanged("IsBusy");
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether text node can be draw or not.
        /// </summary>
        public bool IsDrawTextNode
        {
            get
            {
                return this._mIsDrawTextNode;
            }

            set
            {
                if (this._mIsDrawTextNode != value)
                {
                    this._mIsDrawTextNode = value;
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether export can happen or not.
        /// </summary>
        public bool IsExport
        {
            get
            {
                return this._isExport;
            }

            set
            {
                if (this._isExport != value)
                {
                    this._isExport = value;
                    this.OnPropertyChanged("IsExport");
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the value is empty or not.
        /// </summary>
        public bool IsNonEmpty
        {
            get
            {
                return this._mIsNonEmpty;
            }

            set
            {
                if (this._mIsNonEmpty != value)
                {
                    this._mIsNonEmpty = value;
                    this.OnPropertyChanged("IsNonEmpty");
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the object is selected or not.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return this._isSelected;
            }

            set
            {
                if (this._isSelected != value)
                {
                    this._isSelected = value;
                    this.OnPropertyChanged("IsSelected");
                }
            }
        }

        /// <summary>
        ///     Gets the node collection.
        /// </summary>
        public ObservableCollection<NodeVM> NodeCollection
        {
            get
            {
                return this.Nodes as ObservableCollection<NodeVM>;
            }
        }

        /// <summary>
        ///     Gets or sets the page orientation command.
        /// </summary>
        public ICommand PageOrientationCommand { get; set; }

        /// <summary>
        ///     Gets or sets the page size command.
        /// </summary>
        public ICommand PageSizeCommand { get; set; }

        /// <summary>
        ///     Gets or sets the pan zoom command.
        /// </summary>
        public ICommand PanZoomCommand { get; set; }

        /// <summary>
        ///     Gets or sets the print command.
        /// </summary>
        public ICommand PrintCommand { get; set; }

        /// <summary>
        ///     Gets or sets the shape.
        /// </summary>
        public string Shape
        {
            get
            {
                return this._mShape;
            }

            set
            {
                if (this._mShape != value)
                {
                    this._mShape = value;
                }
            }
        }

        /// <summary>
        ///     Gets or sets to select the group of the Nodes or Connectors command.
        /// </summary>
        public ICommand SingleSelect { get; set; }

        /// <summary>
        ///     Gets or sets the size and position command.
        /// </summary>
        public ICommand SizeAndPositionCommand { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        public string Title
        {
            get
            {
                return this._name;
            }

            set
            {
                if (this._name != value)
                {
                    this._name = value;
                    this.OnPropertyChanged("Title");
                }
            }
        }

        /// <summary>
        /// Represents the  addimagenode command execution.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        public void OnAddImageNodeCommand(object param)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter =
                "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));
                double offX =
                    this.ScrollSettings.ScrollInfo.HorizontalOffset / this.ScrollSettings.ScrollInfo.CurrentZoom
                    + this.ScrollSettings.ScrollInfo.ViewportWidth / 2
                    - bitmap.Width * this.ScrollSettings.ScrollInfo.CurrentZoom / 2;
                double offY = this.ScrollSettings.ScrollInfo.VerticalOffset / this.ScrollSettings.ScrollInfo.CurrentZoom
                              + this.ScrollSettings.ScrollInfo.ViewportHeight / 2
                              - bitmap.Height * this.ScrollSettings.ScrollInfo.CurrentZoom / 2;
                NodeVM nodevm = new NodeVM
                                    {
                                        OffsetX = offX,
                                        OffsetY = offY,
                                        Content = new Image { Stretch = Stretch.Fill, Source = bitmap }
                                    };
                (this.Nodes as ObservableCollection<NodeVM>).Add(nodevm);
            }
        }

        /// <summary>
        /// Represents the export command execution.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public void OnExportCommand(object value)
        {
            foreach (Window win in Application.Current.Windows)
            {
                if (win.DataContext is DiagramBuilderVM)
                {
                    (win.DataContext as DiagramBuilderVM).HideBackstageClick();
                    this.IsExport = true;
                }
            }
        }

        /// <summary>
        /// Represents the fittopage command execution.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        public void OnFitToPageCommand(object param)
        {
            (this.Info as IGraphInfo).Commands.FitToPage.Execute(
                new FitToPageParameter { FitToPage = FitToPage.FitToPage, Region = Region.PageSettings });
        }

        /// <summary>
        /// Represents the fittowidth command execution.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        public void OnFitToWidthCommand(object param)
        {
            (this.Info as IGraphInfo).Commands.FitToPage.Execute(
                new FitToPageParameter { FitToPage = FitToPage.FitToWidth, Region = Region.PageSettings });
        }

        /// <summary>
        /// Represents the panzoom command execution.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        public void OnPanZoomCommand(object param)
        {
            if (!this.EnablePanZoom)
            {
                this.EnablePanZoom = true;
            }
            else
            {
                this.EnablePanZoom = false;
            }
        }

        /// <summary>
        /// Represents the Selection command for Nodes or Connectors.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        public void OnSingleSelectCommand(object param)
        {
            string type = param as string;

            if (type == "Node" && this.Nodes != null)
            {
                if (this is BrainstormingVM)
                {
                    foreach (IConnector o in (this as BrainstormingVM).ConnectorCollection)
                    {
                        o.IsSelected = false;
                    }

                    foreach (INode o in (this as BrainstormingVM).NodeCollection)
                    {
                        o.IsSelected = true;
                    }
                }

                else if (this is OrganizationChartDiagramVM)
                {
                    foreach (IConnector o in (this as OrganizationChartDiagramVM).ConnectorCollection)
                    {
                        o.IsSelected = false;
                    }

                    foreach (INode o in (this as OrganizationChartDiagramVM).NodeCollection)
                    {
                        o.IsSelected = true;
                    }
                }
                else
                {
                    foreach (IConnector o in this.ConnectorCollection)
                    {
                        o.IsSelected = false;
                    }

                    foreach (INode o in this.NodeCollection)
                    {
                        o.IsSelected = true;
                    }
                }
            }
            else if (type == "Connector" && this.Connectors != null)
            {
                if (this is BrainstormingVM)
                {
                    foreach (INode o in (this as BrainstormingVM).NodeCollection)
                    {
                        o.IsSelected = false;
                    }

                    foreach (IConnector o in (this as BrainstormingVM).ConnectorCollection)
                    {
                        o.IsSelected = true;
                    }
                }
                else if (this is OrganizationChartDiagramVM)
                {
                    foreach (INode o in (this as OrganizationChartDiagramVM).NodeCollection)
                    {
                        o.IsSelected = false;
                    }

                    foreach (IConnector o in (this as OrganizationChartDiagramVM).ConnectorCollection)
                    {
                        o.IsSelected = true;
                    }
                }
                else
                {
                    foreach (INode o in this.NodeCollection)
                    {
                        o.IsSelected = false;
                    }

                    foreach (IConnector o in this.ConnectorCollection)
                    {
                        o.IsSelected = true;
                    }
                }
            }
        }

        /// <summary>
        /// Represents the sizeandposition command execution.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        public void OnSizeAndPositionCommand(object param)
        {
            if (!this.EnableSizePosition)
            {
                this.EnableSizePosition = true;
            }
            else
            {
                this.EnableSizePosition = false;
            }
        }

        /// <summary>
        /// Represents the save method execution
        /// </summary>
        /// <param name="savedPath">
        /// The savedPath.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task Save(string savedPath)
        {
            // try
            // {
            IGraphInfo graph = this.Info as IGraphInfo;
            PageVM page = this.PageSettings as PageVM;
            if (graph != null && this.ScrollSettings.ScrollInfo != null)
            {
                page.HOffset = this.ScrollSettings.ScrollInfo.HorizontalOffset;
                page.VOffset = this.ScrollSettings.ScrollInfo.VerticalOffset;
                page.Scale = this.ScrollSettings.ScrollInfo.CurrentZoom;

                this._file = savedPath;
                using (FileStream fileStream = File.OpenWrite(this._file))
                {
                    graph.Save(fileStream);
                }

                this._isValidXml = true;
            }

            // }
            // catch
            // { }
        }

        /// <summary>
        ///     The check empty.
        /// </summary>
        private void CheckEmpty()
        {
            if (this.NodeCollection != null && this.NodeCollection.Count > 0
                || this.ConnectorCollection != null && this.ConnectorCollection.Count > 0
                || this.GroupCollection != null && this.GroupCollection.Count > 0)
            {
                this.IsNonEmpty = true;
            }
            else
            {
                this.IsNonEmpty = false;
            }
        }

        /// <summary>
        /// The diagram v m_ got focus.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void DiagramVM_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            FrameworkElement parent = (FrameworkElement)textBox.Parent;
            while (parent != null && parent is IInputElement && !((IInputElement)parent).Focusable)
            {
                parent = (FrameworkElement)parent.Parent;
            }

            if (this.DrawingTool != DrawingTool.Node)
            {
                (this.SelectedItems as SelectorVM).Clear();
                (parent as INode).IsSelected = true;
                parent.Focus();
                textBox.GotFocus -= this.DiagramVM_GotFocus;
            }
            else
            {
                (this.SelectedItems as SelectorVM).Clear();
                (parent as INode).IsSelected = true;
            }
        }

        /// <summary>
        /// The diagram v m_ item added.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        private void DiagramVM_ItemAdded(object sender, ItemAddedEventArgs args)
        {
            this.PageSettings.MultiplePage = true;
            if (args.ItemSource == ItemSource.Stencil)
            {
                // GroupTransactions group = new GroupTransactions();
                // group.ContinuousUndoRedo = ContinuousUndoRedo.Start;
                // this.HistoryManager.BeginComposite(this.HistoryManager, group);
                INode droppedItem = args.Item as INode;
                if (droppedItem != null && droppedItem.Key.ToString() != "Electrical Shapes")
                {
                    DiagramBuilderVM diagram = null;
                    foreach (Window win in Application.Current.Windows)
                    {
                        if (win.DataContext is DiagramBuilderVM)
                        {
                            diagram = win.DataContext as DiagramBuilderVM;
                        }
                    }
                    if (diagram != null)
                    {
                        diagram.OnSelectTextChanged();
                    }
                }
            }
            else if (args.ItemSource == ItemSource.DrawingTool)
            {
                IConnectorVM newCon = args.Item as IConnectorVM;
                if (newCon != null)
                {
                    switch (this.DefaultConnectorType)
                    {
                        case ConnectorType.Orthogonal:
                            newCon.Type = ConnectType.Orthogonal;
                            break;
                        case ConnectorType.Line:
                            newCon.Type = ConnectType.Straight;
                            break;
                        case ConnectorType.CubicBezier:
                            newCon.Type = ConnectType.Bezier;
                            break;
                    }
                }
            }

            this.CheckEmpty();
        }

        /// <summary>
        /// The diagram v m_ item deleted.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        private void DiagramVM_ItemDeleted(object sender, DiagramEventArgs args)
        {
            this.CheckEmpty();
        }

        /// <summary>
        /// The graph_ get draw type.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        private void graph_GetDrawType(object sender, DrawTypeEventArgs args)
        {
            if (this.IsDrawTextNode)
            {
                NodeVM node = new NodeVM();
                node.UnitWidth = 150;
                node.UnitHeight = 50;
                node.Annotations = new List<IAnnotation>();
                LabelVM label = new LabelVM();
                label.Mode = ContentEditorMode.Edit;
                label.UnitWidth = 100;
                label.UnitHeight = 100;
                label.Content = string.Empty;
                (node.Annotations as List<IAnnotation>).Add(label);
                args.DrawItem = node;
                node.PropertyChanged += (s, e) =>
                    {
                        if (e.PropertyName.Equals("IsSelected"))
                        {
                            INode n = s as INode;
                            if (n.IsSelected)
                            {
                                (this.SelectedItems as SelectorVM).SelectorConstraints &=
                                    ~SelectorConstraints.QuickCommands;
                            }
                        }
                    };
            }
            else if (this.Shape.Equals("Rectangle"))
            {
                args.DrawItem = new Rectangle
                                    {
                                        StrokeThickness = 1.0,
                                        Stroke = new SolidColorBrush(Colors.Black),
                                        Fill = new SolidColorBrush(Colors.White),
                                        Stretch = Stretch.Fill
                                    };
            }
            else if (this.Shape.Equals("Ellipse"))
            {
                args.DrawItem = new Ellipse
                                    {
                                        StrokeThickness = 1.0,
                                        Stroke = new SolidColorBrush(Colors.Black),
                                        Fill = new SolidColorBrush(Colors.White)
                                    };
            }
        }

        /// <summary>
        /// The graph_ item drop event.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        private void Graph_ItemDropEvent(object sender, ItemDropEventArgs args)
        {
            if (args.ItemSource == Cause.Stencil && (args.Source as NodeVM).Key != null
                                                 && (args.Source as NodeVM).Key.ToString() != "Electrical Shapes")
            {
                // (args.Source as INodeVM).Style = App.Current.Resources["SubtleEffectAccent1Style"] as Style;
                // (SelectedItems as SelectorVM).NodeGalleryName = "SubtleEffectAccent1";
                // (args.Source as INodeVM).NodeGalleryName = (SelectedItems as SelectorVM).NodeGalleryName;
                // GroupTransactions group = new GroupTransactions();
                // group.ContinuousUndoRedo = ContinuousUndoRedo.End;
                // this.HistoryManager.EndComposite(this.HistoryManager, group);
            }

            if (this.DrawingTool == DrawingTool.Connector)
            {
                if ((this.Tool == Tool.ContinuesDraw) | (this.Tool == Tool.DrawOnce))
                {
                    if (args.Source is NodeVM)
                    {
                        (args.Source as NodeVM).IsSelected = false;
                    }
                }
            }
        }

        /// <summary>
        /// The graph_ node changed event.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        private void Graph_NodeChangedEvent(object sender, ChangeEventArgs<object, NodeChangedEventArgs> args)
        {
        }

        /// <summary>
        ///     The init location.
        /// </summary>
        private void InitLocation()
        {
            this.installedLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        /// <summary>
        ///     The load.
        /// </summary>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        private async Task Load()
        {
            if (this._file != null && this._isValidXml)
            {
                IGraphInfo graph = this.Info as IGraphInfo;
                using (FileStream fileStream = File.OpenRead(this._file))
                {
                    graph.Load(fileStream);
                }

                //this.PageSettings = new PageVM();
                //(this.PageSettings as PageVM).InitDiagram(this);
            }
        }

        /// <summary>
        /// The on connect type command.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private void OnConnectTypeCommand(object param)
        {
            ISelectorVM selectedItems = this.SelectedItems as ISelectorVM;
            if (param.ToString().Equals("Orthogonal"))
            {
                selectedItems.Type = ConnectType.Orthogonal;
            }
            else if (param.ToString().Equals("StraightLine"))
            {
                selectedItems.Type = ConnectType.Straight;
            }
            else if (param.ToString().Equals("CubicBezier"))
            {
                selectedItems.Type = ConnectType.Bezier;
            }
        }

        /// <summary>
        /// The on flip command.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void OnFlipCommand(object obj)
        {
            IGraphInfo graphInfo = this.Info as IGraphInfo;
            if (obj.ToString().Equals("HorizontalFlip"))
            {
                graphInfo.Commands.Flip.Execute(
                    new FlipParameter { Flip = Flip.HorizontalFlip, FlipMode = FlipMode.FlipMode });
            }
            else if (obj.ToString().Equals("VerticalFlip"))
            {
                graphInfo.Commands.Flip.Execute(
                    new FlipParameter { Flip = Flip.VerticalFlip, FlipMode = FlipMode.FlipMode });
            }
        }

        /// <summary>
        /// The on page orientation command.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private void OnPageOrientationCommand(object param)
        {
            if (param.ToString().Equals("Portrait"))
            {
                this.PageSettings.PageOrientation = PageOrientation.Portrait;
            }
            else if (param.ToString().Equals("Landscape"))
            {
                this.PageSettings.PageOrientation = PageOrientation.Landscape;
            }
        }

        /// <summary>
        /// The on page size command.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private void OnPageSizeCommand(object param)
        {
            PageVM pageSettings = this.PageSettings as PageVM;
            if (param.ToString().Equals("Letter"))
            {
                pageSettings.SelectedFormat = PageSize.Letter;
            }
            else if (param.ToString().Equals("Folio"))
            {
                pageSettings.SelectedFormat = PageSize.Folio;
            }
            else if (param.ToString().Equals("Legal"))
            {
                pageSettings.SelectedFormat = PageSize.Legal;
            }
            else if (param.ToString().Equals("Ledger"))
            {
                pageSettings.SelectedFormat = PageSize.Ledger;
            }
            else if (param.ToString().Equals("A5"))
            {
                pageSettings.SelectedFormat = PageSize.A5;
            }
            else if (param.ToString().Equals("A4"))
            {
                pageSettings.SelectedFormat = PageSize.A4;
            }
            else if (param.ToString().Equals("A3"))
            {
                pageSettings.SelectedFormat = PageSize.A3;
            }
            else if (param.ToString().Equals("A3"))
            {
                pageSettings.SelectedFormat = PageSize.A2;
            }
            else if (param.ToString().Equals("A2"))
            {
                pageSettings.SelectedFormat = PageSize.A2;
            }
            else if (param.ToString().Equals("A1"))
            {
                pageSettings.SelectedFormat = PageSize.A1;
            }
            else if (param.ToString().Equals("A0"))
            {
                pageSettings.SelectedFormat = PageSize.A0;
            }
        }

        /// <summary>
        /// The on print command.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void OnPrintCommand(object obj)
        {
            foreach (Window win in Application.Current.Windows)
            {
                if (win.DataContext is DiagramBuilderVM)
                {
                    (win.DataContext as DiagramBuilderVM).HideBackstageClick();
                    this.PrintingService.ShowDialog = true;
                    this.PrintingService.Print();
                }
            }
        }

        /// <summary>
        /// The on view loaded.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private async void OnViewLoaded(object param)
        {
            IGraphInfo graph = this.Info as IGraphInfo;
            graph.ItemAdded += this.DiagramVM_ItemAdded;
            graph.ItemDropEvent += this.Graph_ItemDropEvent;
            graph.ItemDeleted += this.DiagramVM_ItemDeleted;
            graph.GetDrawType += this.graph_GetDrawType;
            graph.NodeChangedEvent += this.Graph_NodeChangedEvent;
            await this.Load();
            PageVM page = this.PageSettings as PageVM;
            if (this._isValidXml)
            {
                graph.Commands.Zoom.Execute(new ZoomPositionParameter { ZoomTo = page.Scale });
                this.ScrollSettings.ScrollInfo.PanTo(new Point(page.HOffset, page.VOffset));
            }

            this.IsBusy = Visibility.Collapsed;

            if(this is OrganizationChartDiagramVM)
            {
                OrganizationChartNodeVM node = (this.Nodes as ObservableCollection<OrganizationChartNodeVM>).First() as OrganizationChartNodeVM;
                node.OffsetX = 550;
                node.OffsetY = 125;
               this.LayoutManager.Layout.UpdateLayout(node);
            }
        }
    }
}