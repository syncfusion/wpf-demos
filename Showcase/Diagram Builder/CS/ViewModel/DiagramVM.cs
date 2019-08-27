#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DiagramBuilder.Utility;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System.IO;
using System.Collections;
using Microsoft.Win32;
using DiagramBuilder.Model;
using System.Runtime.Serialization;
using Syncfusion.UI.Xaml.Diagram.Theming;


namespace DiagramBuilder.ViewModel
{
    public class DiagramVM : DiagramViewModel, IDiagramViewModel
    {
        public bool _isValidXml = false;
        private bool _isSelected = false;
        private bool _isExport = false;
        private Brush _offPageBackground;
        private string _name;
        private DiagramType _mDiagramType;
        string _file;
        string installedLocation;
        private Visibility _mIsBusy = Visibility.Visible;

        public Visibility IsBusy
        {
            get { return _mIsBusy; }
            set
            {
                if (_mIsBusy != value)
                {
                    _mIsBusy = value;
                    OnPropertyChanged("IsBusy");
                }
            }
        }

        public DiagramVM()
        {

        }

        //StorageFile file, 
        public DiagramVM(string file,bool isValidXml) 
        {
            _isValidXml = isValidXml;
            _file = file;
            Title = "Page";
            DiagramType = DiagramType.Blank;
            Nodes = new ObservableCollection<NodeVM>();
            Connectors = new ObservableCollection<ConnectorVM>();
            Groups = new ObservableCollection<GroupVM>();
            SelectedItems = new SelectorVM(this);
            PortVisibility = PortVisibility.MouseOverOnConnect;
            Select = new Command(param => IsSelected = true);
            FirstLoad = new Command(OnViewLoaded);
            HistoryManager = new customManager();
            SnapSettings = new SnapSettings()
            {
                SnapConstraints = SnapConstraints.All,
                SnapToObject = SnapToObject.All
            };
            Theme = new OfficeTheme();
            PreviewSettings = new PreviewSettings()
            {
                PreviewMode = PreviewMode.Preview
            };

            PageSettings = new PageVM();
       
            (PageSettings as PageVM).InitDiagram(this);
          
            this.HorizontalRuler = new Ruler() { Orientation = Orientation.Horizontal };
            this.VerticalRuler = new Ruler() { Orientation = Orientation.Vertical };
            //OffPageBackground = new SolidColorBrush(new Color() { A = 0xFF, R = 0xEC, G = 0xEC, B = 0xEC });
            //OffPageBackground = new SolidColorBrush(new Color() { A = 0xFF, R = 0x2D, G = 0x2D, B = 0x2D });
            InitLocation();
            PrintingService = new PrintingService();
            ExportSettings = new ExportSettings()
            {
                ImageStretch = Stretch.Uniform,
                ExportMode = ExportMode.PageSettings
            };
#if SyncfusionFramework4_5_1
            ExportSettings = new ExportSettings()
            {
                ImageStretch = Stretch.Uniform,
                ExportMode = ExportMode.PageSettings
            };
            PrintingService = new PrintingService();
#endif
            FlipCommand = new Command(OnFlipCommand);
            ExportCommand = new Command(OnExportCommand);
            PrintCommand = new Command(OnPrintCommand);
            Captures = new Command(OnCapturesCommand);
            ClearDiagram = new Command(OnClearCommand);
            Upload = new Command(Onuploadcommand);
            Draw = new Command(OnDrawCommand);
            SingleSelect = new Command(OnSingleSelectCommand);
            SelectAll = new Command(OnSelectAllCommand);
            Manipulate = new Command(OnManipulateCommand);
            LoadExt = new Command(OnLoadExt);
            AddImageNode = new Command(OnAddImageNodeCommand);
            PageOrientationCommand = new Command(OnPageOrientationCommand);
            PageSizeCommand = new Command(OnPageSizeCommand);
            ConnectTypeCommand = new Command(OnConnectTypeCommand);
            RotateTextCommand = new Command(OnRotateTextCommand);
            //SelectTextCommand = new Command(OnSelectTextCommand);
            SizeandPositionCommand = new Command(OnSizeandPositionCommand);
            PanZoomCommand = new Command(OnPanZoomCommand);
            FitToWidthCommand = new Command(OnFitToWidthCommand);
            FitToPageCommand = new Command(OnFitToPageCommand);
            this.Constraints |= GraphConstraints.Undoable;

            //Tool = Tool.ZoomPan | Tool.SingleSelect;
            ;

            //ConnectorVM c = new ConnectorVM()
            //{
            //    SourcePoint = new Point(100, 100),
            //    TargetPoint = new Point(300, 300)
            //};

            //(this.ConnectorCollection as ICollection<ConnectorVM>).Add(c);
            
        }
        private void OnFlipCommand(object obj)
        {
            IGraphInfo graphinfo = this.Info as IGraphInfo;
            if (obj.ToString().Equals("HorizontalFlip"))
            {
                graphinfo.Commands.Flip.Execute(new FlipParameter() { Flip = Flip.HorizontalFlip, FlipMode = FlipMode.FlipMode });
            }

            else if (obj.ToString().Equals("VerticalFlip"))
            {
                graphinfo.Commands.Flip.Execute(new FlipParameter() { Flip = Flip.VerticalFlip, FlipMode = FlipMode.FlipMode });
            }
        }

        private void OnPrintCommand(object obj)
        {
            //  this.PrintingService.PrintPreviewStretch = Stretch.None;
            this.PrintingService.ShowDialog = true;
            this.PrintingService.Print();
        }

        private void OnLoadExt(object obj)
        {
            
        }

        private void OnManipulateCommand(object obj)
       {
            Tool = Tool.MultipleSelect;
          
        }

        private async void InitLocation()
        {
            installedLocation =   Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        void DiagramVM_ItemAdded(object sender, ItemAddedEventArgs args)
        {
            PageSettings.MultiplePage = true;
            if (args.ItemSource == ItemSource.Stencil)
            {
                //GroupTransactions group = new GroupTransactions();
                //group.ContinuousUndoRedo = ContinuousUndoRedo.Start;
                //this.HistoryManager.BeginComposite(this.HistoryManager, group);
                var dropedItem = args.Item as INode;
                if (dropedItem != null && dropedItem.Key.ToString() != "Electrical Shapes")
                {
                   // (dropedItem as INodeVM).Fill = new SolidColorBrush(new Color() { A = 0xFF, R = 0x5B, G = 0x9B, B = 0xD5 });
                    DiagramBuilderVM diagram=App.Current.MainWindow.DataContext as DiagramBuilderVM;
                    diagram.OnSelectTextChanged();

                }

            }
            else if (args.ItemSource == ItemSource.DrawingTool)
            {
                IConnectorVM newCon = args.Item as IConnectorVM;
                if (newCon != null)
                {
                    switch (DefaultConnectorType)
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
                //DefaultConnectorType = ConnectorType.Orthogonal;
            }
            CheckEmpty();
        }

        void DiagramVM_ItemDeleted(object sender, DiagramEventArgs args)
        {
            CheckEmpty();        
        }

        private void CheckEmpty()
        {
            if ((NodeCollection != null && NodeCollection.Count > 0) ||
                (ConnectorCollection != null && ConnectorCollection.Count > 0) ||
                (GroupCollection != null && GroupCollection.Count > 0))
            {
                IsNonEmpty = true;
            }
            else
            {
                IsNonEmpty = false;
            }
        }

        private bool _mIsNonEmpty = false;

        public bool IsNonEmpty
        {
            get { return _mIsNonEmpty; }
            set
            {
                if (_mIsNonEmpty != value)
                {
                    _mIsNonEmpty = value;
                    OnPropertyChanged("IsNonEmpty");
                }
            }
        }

        public bool _mEnablePanZoom;
        public bool EnablePanZoom
        {
            get { return _mEnablePanZoom; }
            set
            {
                if (_mEnablePanZoom != value)
                {
                    _mEnablePanZoom = value;
                    OnPropertyChanged("EnablePanZoom");
                }
            }
        }

        public bool _mEnableSizePosition;
        public bool EnableSizePosition
        {
            get { return _mEnableSizePosition; }
            set
            {
                if (_mEnableSizePosition != value)
                {
                    _mEnableSizePosition = value;
                    OnPropertyChanged("EnableSizePosition");
                }
            }
        }

        private async void OnViewLoaded(object param)
        {
            IGraphInfo graph = Info as IGraphInfo;         
            graph.ItemAdded += DiagramVM_ItemAdded;
            graph.ItemDropEvent += Graph_ItemDropEvent;        
            graph.ItemDeleted += DiagramVM_ItemDeleted;
            graph.SymbolDroppingEvent += graph_SymbolDroppingEvent;
            graph.GetDrawType += graph_GetDrawType;
            graph.NodeChangedEvent += Graph_NodeChangedEvent;
            await Load();
            PageVM page = PageSettings as PageVM;
            if (_isValidXml)
            {
                graph.Commands.Zoom.Execute(
                   new ZoomPositionParamenter()
                   {
                       ZoomTo = page.Scale
                   });
                graph.ScrollInfo.PanTo(new Point(page.HOffset, page.VOffset));
            }
            //else
            //{
            //    await Save();
            //    (Info as IGraphInfo).Commands.FitToPage.Execute(
            //        new FitToPageParameter
            //        {
            //            FitToPage = FitToPage.FitToPage,
            //            Margin = new Thickness(20)
            //        }
            //        );
            //    this.Save();
            //}
            IsBusy = Visibility.Collapsed;
            
        }

        private void Graph_NodeChangedEvent(object sender, ChangeEventArgs<object, NodeChangedEventArgs> args)
        {
        }

        private void Graph_ItemDropEvent(object sender, ItemDropEventArgs args)
        {
            if (args.ItemSource == Cause.Stencil && (args.Source as INodeVM).Key != null && (args.Source as INodeVM).Key.ToString()!= "Electrical Shapes")
            {
               // (args.Source as INodeVM).Style = App.Current.Resources["SubtleEffectAccent1Style"] as Style;
              //  (SelectedItems as SelectorVM).NodeGallaryName = "SubtleEffectAccent1";
              //  (args.Source as INodeVM).NodeGallaryName = (SelectedItems as SelectorVM).NodeGallaryName;
                //GroupTransactions group = new GroupTransactions();
                //group.ContinuousUndoRedo = ContinuousUndoRedo.End;
                //this.HistoryManager.EndComposite(this.HistoryManager, group);
            }
            if (this.DrawingTool == DrawingTool.Connector)  
            {
                if (this.Tool == Tool.ContinuesDraw | this.Tool == Tool.DrawOnce)
                {
                    if (args.Source is NodeVM)
                    {
                        (args.Source as NodeVM).IsSelected = false;
                        
                    }
                }
            }
           
        }

        void graph_SymbolDroppingEvent(object sender, SymbolDroppingEventArgs args)
        {
            args.SymbolDropMode = SymbolDropMode.Drop;
        }

        void graph_GetDrawType(object sender, DrawTypeEventArgs args)
        {
            if (IsDrawTextNode)
            {
                NodeVM node = new NodeVM();
                node.UnitWidth = 150;
                node.UnitHeight = 50;
                node.Annotations = new List<IAnnotation>();
                LabelVM label = new LabelVM();
                label.Mode = ContentEditorMode.Edit;
                label.UnitWidth = 100;
                label.UnitHeight = 100;
                label.Content = "";
                (node.Annotations as List<IAnnotation>).Add(label);
                args.DrawItem = node;
                node.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName.Equals("IsSelected"))
                    {
                        INode n = s as INode;
                        if (n.IsSelected)
                        {
                            (this.SelectedItems as SelectorVM).SelectorConstraints &= ~SelectorConstraints.QuickCommands;
                        }
                    }
                };
            }
            else if (this.Shape.Equals("Rectangle"))
            {
                args.DrawItem = new System.Windows.Shapes.Rectangle() { StrokeThickness = 1.0, Stroke = new SolidColorBrush(Colors.Black), Fill = new SolidColorBrush(Colors.White), Stretch = Stretch.Fill };
            }
            else if (this.Shape.Equals("Ellipse"))
            {
                args.DrawItem = new System.Windows.Shapes.Ellipse() { StrokeThickness = 1.0, Stroke = new SolidColorBrush(Colors.Black), Fill = new SolidColorBrush(Colors.White) };
            }
            //else if (this.Shape.Equals("Line"))
            //{
            //}
        }

        void DiagramVM_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            FrameworkElement parent = (FrameworkElement)textBox.Parent;
            if (parent is INode)
            {
                (parent as INode).IsSelected = false;
            }
            textBox.GotFocus += DiagramVM_GotFocus;
        }

        void DiagramVM_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            FrameworkElement parent = (FrameworkElement)textBox.Parent;
            while (parent != null && parent is IInputElement && !((IInputElement)parent).Focusable)
            {
                parent = (FrameworkElement)parent.Parent;
            }
            if (this.DrawingTool != Syncfusion.UI.Xaml.Diagram.DrawingTool.Node)
            {                
                (SelectedItems as SelectorVM).Clear();
                (parent as INode).IsSelected = true;
                parent.Focus();
                textBox.GotFocus -= DiagramVM_GotFocus;
            }
            else
            {
                (SelectedItems as SelectorVM).Clear();
                (parent as INode).IsSelected = true;
            }
        }

        void DiagramVM_Loaded(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            FrameworkElement parent = (FrameworkElement)textBox.Parent;
            //(parent as INode).Annotations = null;
            foreach (LabelVM _mAnnotation in (parent as INode).Annotations as List<IAnnotation>)
            {
                _mAnnotation.PropertyChanged += (s, e1) =>
                {
                    if (e1.PropertyName == "Mode")
                    {
                        if ((s as LabelVM).Mode == ContentEditorMode.Edit)
                            (s as LabelVM).Mode = ContentEditorMode.View;
                    }
                };
            }
            textBox.Focus();
        } 

        public string Title
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        [DataMember]
        public DiagramType DiagramType
        {
            get { return _mDiagramType; }
            set
            {
                if (_mDiagramType != value)
                {
                    _mDiagramType = value;
                    OnPropertyChanged("Type");
                }
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }
        public bool IsExport
        {
            get { return _isExport; }
            set
            {
                if (_isExport != value)
                {
                    _isExport = value;
                    OnPropertyChanged("IsExport");
                }
            }
        }
        public FileInfo FileInfo 
        { 
            get 
            {
                return new FileInfo()
                {
                    FileName = GetFileName(),
                    Selected = IsSelected,
                    Title = Title
                };
            } 
        }

        private string _mComments = string.Empty;
        public string Comments
        {
            get { return _mComments; }
            set
            {
                if (_mComments != value)
                {
                    _mComments = value;
                    OnPropertyChanged("Comments");
                }
            }
        }
        

        public ObservableCollection<NodeVM> NodeCollection
        {
            get { return Nodes as ObservableCollection<NodeVM>; }
        }
        public ObservableCollection<ConnectorVM> ConnectorCollection
        {
            get { return Connectors as ObservableCollection<ConnectorVM>; }
        }
        public ObservableCollection<GroupVM> GroupCollection
        {
            get { return Groups as ObservableCollection<GroupVM>; }
        }

        public ICommand FlipCommand { get; set; }
        public ICommand Select { get; set; }
        public ICommand FirstLoad { get; set; }
        public ICommand Export { get; set; }
        public ICommand ClearDiagram { get; set; }
        public ICommand Delete { get; set; }
        public ICommand Draw { get; set; }
        public ICommand SingleSelect { get; set; }
        public ICommand SelectAll { get; set; }
        public ICommand Upload { get; set; }
        public ICommand Captures { get; set; }
        public ICommand Manipulate { get; set; }
        public ICommand LoadExt { get; set; }
        public ICommand AddImageNode { get; set; }
        public ICommand PageOrientationCommand { get; set; }
        public ICommand PageSizeCommand { get; set; }
        public ICommand ConnectTypeCommand { get; set; }
        public ICommand SizeandPositionCommand { get; set; }
        public ICommand PanZoomCommand { get; set; }
        public ICommand RotateTextCommand { get; set; }
        //public ICommand SelectTextCommand { get; set; }
        public ICommand FitToWidthCommand { get; set; }
        public ICommand FitToPageCommand { get; set; }
        public ICommand PrintCommand { get; set; }
        public ICommand ExportCommand { get; set; }

        private string _mShape = "Rectangle";
        public string Shape
        {
            get { return _mShape; }
            set
            {
                if (_mShape != value)
                {
                    _mShape = value;
                }
            }
        }

        private bool _mIsDrawTextNode = false;
        public bool IsDrawTextNode
        {
            get { return _mIsDrawTextNode; }
            set
            {
                if (_mIsDrawTextNode != value)
                {
                    _mIsDrawTextNode = value;
                }
            }
        }
        

        public Brush OffPageBackground
        {
            get { return _offPageBackground; }
            set
            {
                _offPageBackground = value;
                OnPropertyChanged("OffpageBackground");
            }
        }

        private async Task Load()
        {
            if (_file != null && _isValidXml)
            {
                IGraphInfo graph = this.Info as IGraphInfo;
                using (FileStream fileStream = File.OpenRead(_file))
                {
                    graph.Load(fileStream);
                }
                PageSettings = new PageVM();
                (PageSettings as PageVM).InitDiagram(this);
            }
        }

        public async Task Save(string savedpath)
        {
            //try
            //{
            IGraphInfo graph = this.Info as IGraphInfo;
            PageVM page = PageSettings as PageVM;
            if (graph != null && graph.ScrollInfo != null)
            {
                page.HOffset = graph.ScrollInfo.HorizontalOffset;
                page.VOffset = graph.ScrollInfo.VerticalOffset;
                page.Scale = graph.ScrollInfo.CurrentZoom;

                _file = savedpath;
                using (FileStream fileStream = File.OpenWrite(_file))
                {
                    graph.Save(fileStream);
                }
                _isValidXml = true;
            }
            //  }
            //catch
            //{ }
        }

        public async Task DeleteFile()
        {
            //try
            //{
            //    if (_file != null)
            //    {
            //        await _file.DeleteAsync();
            //    }
            //}
            //catch
            //{ }
        }

        public string GetFileName()
        {
            if (_file != null)
            {
                DirectoryInfo di = new DirectoryInfo(_file);
                return di.Name;
            }
            else
            {
                return string.Empty;
            }
        }

        public void OnExportCommand(object param)
        {
            IsExport = true;
        }

        private async void SinglePageExporting(string p, Guid guid)
        {
#if SyncfusionFramework4_5_1
            IGraphInfo graph = this.Info as IGraphInfo;
            if (graph != null)
            {
                var savePicker = new FileSavePicker();
                savePicker.DefaultFileExtension = "." + p;
                savePicker.FileTypeChoices.Add("." + p, new List<string> { "." + p });
                savePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                savePicker.SuggestedFileName = Title;

                // Prompt the user to select a file
                var saveFile = await savePicker.PickSaveFileAsync();

                // Verify the user selected a file
                if (saveFile == null)
                    return;
                // Encode the image to the selected file on disk
                using (var fileStream = await saveFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    ExportSettings.ExportBitmapEncoder = await BitmapEncoder.CreateAsync(guid, fileStream);
                    //Method to Export the SfDiagram
                    await graph.Export();
                }
            } 
#endif
        }

        public void OnClearCommand(object param)
        {
            NodeCollection.Clear();
            ConnectorCollection.Clear();
            GroupCollection.Clear();
        }

       async private void Onuploadcommand(object obj)
        {
            //var picker = new FileOpenPicker();
            //picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            //picker.ViewMode = PickerViewMode.Thumbnail;
            //picker.FileTypeFilter.Add(".jpg");
            //picker.FileTypeFilter.Add(".jpeg");
            //var file = await picker.PickSingleFileAsync();
            //if (file == null) return;
            //var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            //BitmapImage image = new BitmapImage();
            //image.SetSource(stream);           
            //IGraphInfo graph = this.Info as IGraphInfo;          
            //NodeVM node = new NodeVM();          
            //node.OffsetX = (graph.ScrollInfo.ViewportWidth) / 2;
            //node.OffsetY = (graph.ScrollInfo.ViewportHeight)/2;
            //node.UnitHeight = 100;
            //node.UnitWidth = 100;
            //node.Content = new Image() { Source = image,Stretch=Stretch.Fill};
            //(Nodes as ObservableCollection<NodeVM>).Add(node);           
            
        }
        async public void OnCapturesCommand(object param)
        {

            //var ui = new CameraCaptureUI();
            //var file = await ui.CaptureFileAsync(CameraCaptureUIMode.PhotoOrVideo);
            //if (file != null)
            //{
            //    IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            //    BitmapImage bitmap = new BitmapImage();
            //    bitmap.SetSource(fileStream);
           
            //    IGraphInfo graph = this.Info as IGraphInfo;
            //    NodeVM node = new NodeVM();
            //    node.OffsetX = (graph.ScrollInfo.ViewportWidth) / 2;
            //    node.OffsetY = (graph.ScrollInfo.ViewportHeight) / 2;
            //    node.UnitHeight = 100;
            //    node.UnitWidth = 100;
            //    node.Content = new Image() { Source = bitmap, Stretch = Stretch.Fill };
            //    (Nodes as ObservableCollection<NodeVM>).Add(node);

            //}
        }
        public void OnDrawCommand(object param)
        {
            string type = param as string;
            switch (type)
            { 
                case "Straight":
                    DefaultConnectorType = ConnectorType.Line;
                    break;
                case "Ortho":
                    DefaultConnectorType = ConnectorType.Orthogonal;
                    break;
                case "Bezier":
                    DefaultConnectorType = ConnectorType.CubicBezier;
                    break;
                //case "FreeHand":
                //    DefaultConnectorType = ConnectorType.PolyCubicBezier;
                //    break;
            }
            Tool |= Tool.ContinuesDraw;
        }
        public void OnSingleSelectCommand(object param)
        {
            string type = param as string;

            if (type == "Node" && Nodes != null)
            {
                foreach (IConnector o in ConnectorsE)
                {
                    o.IsSelected = false;
                }

                foreach (INode o in NodesE)
                {
                    o.IsSelected = true;
                }
            }
            else if (type == "Connector" && ConnectorsE != null)
            {
                foreach (INode o in NodesE)
                {
                    o.IsSelected = false;
                }

                foreach (IConnector o in ConnectorsE)
                {
                    o.IsSelected = true;
                }
            }
        }
        public void OnSelectAllCommand(object param)
        {
            string type = param as string;

            if (type == "Node" && Nodes != null)
            {
                foreach (IConnector o in ConnectorsE)
                {
                    o.IsSelected = false;
                }

                foreach (INode o in NodesE)
                {
                    o.IsSelected = true;
                }
            }
            if (type == "Connector" && ConnectorsE != null)
            {
                foreach (INode o in NodesE)
                {
                    o.IsSelected = false;
                }

                foreach (IConnector o in ConnectorsE)
                {
                    o.IsSelected = true;
                }
            }
        }
        public void OnAddImageNodeCommand(object param)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if(openFileDialog.ShowDialog() == true)
            {
                BitmapImage bitmap=new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));
                double offX = ((this.Info as IGraphInfo).ScrollInfo.HorizontalOffset / (this.Info as IGraphInfo).ScrollInfo.CurrentZoom) + (this.Info as IGraphInfo).ScrollInfo.ViewportWidth / 2 - (bitmap.Width * (this.Info as IGraphInfo).ScrollInfo.CurrentZoom) / 2;
                double offY = ((this.Info as IGraphInfo).ScrollInfo.VerticalOffset / (this.Info as IGraphInfo).ScrollInfo.CurrentZoom) + (this.Info as IGraphInfo).ScrollInfo.ViewportHeight / 2 - (bitmap.Height * (this.Info as IGraphInfo).ScrollInfo.CurrentZoom) / 2;
                NodeVM nodevm = new NodeVM()
                {
                    OffsetX = offX,
                    OffsetY = offY,
                    Content = new Image() { Stretch = Stretch.Fill, Source = bitmap }
                };
                (Nodes as ObservableCollection<NodeVM>).Add(nodevm);
            }
        }
        private void OnPageOrientationCommand(object param)
        {
            if(param.ToString().Equals("Portrait"))
            {
                PageSettings.PageOrientation = PageOrientation.Portrait;
            }
            else if (param.ToString().Equals("Landscape"))
            {
                PageSettings.PageOrientation = PageOrientation.Landscape;
            }
        }
        private void OnPageSizeCommand(object param)
        {
            if (param.ToString().Equals("Letter"))
            {
                (PageSettings as PageVM).SelectedFormat = PageSize.Letter;
            }
            else if (param.ToString().Equals("Folio"))
            {
                (PageSettings as PageVM).SelectedFormat = PageSize.Folio;
            }
            else if (param.ToString().Equals("Legal"))
            {
                (PageSettings as PageVM).SelectedFormat = PageSize.Legal;
            }
            else if (param.ToString().Equals("Ledger"))
            {
                (PageSettings as PageVM).SelectedFormat = PageSize.Ledger;
            }
            else if (param.ToString().Equals("A5"))
            {
                (PageSettings as PageVM).SelectedFormat = PageSize.A5;
            }
            else if (param.ToString().Equals("A4"))
            {
                (PageSettings as PageVM).SelectedFormat = PageSize.A4;
            }
            else if (param.ToString().Equals("A3"))
            {
                (PageSettings as PageVM).SelectedFormat = PageSize.A3;
            }
            else if (param.ToString().Equals("A3"))
            {
                (PageSettings as PageVM).SelectedFormat = PageSize.A2;
            }
            else if (param.ToString().Equals("A2"))
            {
                (PageSettings as PageVM).SelectedFormat = PageSize.A2;
            }
            else if (param.ToString().Equals("A1"))
            {
                (PageSettings as PageVM).SelectedFormat = PageSize.A1;
            }
            else if (param.ToString().Equals("A0"))
            {
                (PageSettings as PageVM).SelectedFormat = PageSize.A0;
            }
        }

        private void OnConnectTypeCommand(object param)
        {
            if (param.ToString().Equals("Orthogonal"))
            {
                (this.SelectedItems as ISelectorVM).Type = ConnectType.Orthogonal;
            }
            else if (param.ToString().Equals("StraightLine"))
            {
                (this.SelectedItems as ISelectorVM).Type = ConnectType.Straight;
            }
            else if (param.ToString().Equals("CubicBezier"))
            {
                (this.SelectedItems as ISelectorVM).Type = ConnectType.Bezier;
            }
        }

        private void OnRotateTextCommand(object param)
        {                               
            //if (param.ToString().Equals("RotateText"))
            //{             
            //    foreach (NodeVM nv in Nodes as ObservableCollection<NodeVM>)
            //    {
            //        if (nv.IsSelected)
            //        {
            //            foreach (LabelVM av in nv.Annotations as List<IAnnotation>)
            //            {                           
            //                av.RotateAngle += 90;                         
            //            }
            //        }
            //    }
            //    foreach (ConnectorVM cv in Connectors as ObservableCollection<ConnectorVM>)
            //    {
            //        if (cv.IsSelected)
            //        {
            //            foreach (LabelVM av in cv.Annotations as List<IAnnotation>)
            //            {
            //                av.RotateAngle += 90;
            //            }
            //        }
            //    }
            //}
        }


        //private void OnSelectTextCommand(object param)
        //{
        //    if (param.ToString().Equals("SelectText"))
        //    {
        //        foreach (NodeVM nv in Nodes as ObservableCollection<NodeVM>)
        //        {
        //            foreach (LabelVM av in nv.Annotations as List<IAnnotation>)
        //            {
        //                av.Constraints = AnnotationConstraints.Default | AnnotationConstraints.Selectable;
        //                av.Constraints = AnnotationConstraints.Default | AnnotationConstraints.Draggable;
        //            }                
        //        }
        //    }
        //}
        public void OnSizeandPositionCommand(object param)
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
        public void OnFitToPageCommand(Object param)
        {
            (this.Info as IGraphInfo).Commands.FitToPage.Execute(new FitToPageParameter() { FitToPage = FitToPage.FitToPage });
        }
        public void OnFitToWidthCommand(Object param)
        {           
                (this.Info as IGraphInfo).Commands.FitToPage.Execute(new FitToPageParameter() { FitToPage = FitToPage.FitToWidth });                  
        }
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
    
        public IEnumerable ConnectorsE
        {
            get { return this.Connectors as IEnumerable; }
        }
        public IEnumerable NodesE
        {
            get { return this.Nodes as IEnumerable; }
        }
        public IEnumerable GroupsE
        {
            get { return this.Groups as IEnumerable; }
        }
    }
    
    public enum DiagramType
    {
        Blank,
        Brainstorming,
        FlowChart
    }
    public interface IDiagramViewModel : IGraph
    {
        ICommand Select { get; set; }
        ICommand FirstLoad { get; set; }
        string Title { get; set; }
        bool IsSelected { get; set; }
        bool EnablePanZoom { get; set; }
        ICommand Export { get; set; }
        ICommand ClearDiagram { get; set; }
        ICommand Delete { get; set; }
        ICommand Draw { get; set; }
        ICommand SingleSelect { get; set; }
        ICommand SelectAll { get; set; }
        ICommand Manipulate { get; set; }
        string Shape { get; set; }
        bool IsDrawTextNode { get; set; }
    }
}
