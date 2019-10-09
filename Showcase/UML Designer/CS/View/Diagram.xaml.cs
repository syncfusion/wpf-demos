#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using DiagramFrontPageUtility;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.Windows.Controls.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Syncfusion.UI.Xaml.Diagram.Utility;
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236
using UMLDiagram;

namespace UMLDiagramDesigner
{
    public partial class Diagram : UserControl
    {
        private ObservableCollection<Node> nodes;
        private ObservableCollection<Connector> connectors;
        private IGraphInfo graphInfo;
        MouseButtonEventHandler tapped;
        MouseButtonEventHandler pointerRelease;

        public Diagram()
        {
            this.InitializeComponent();
            tapped = new MouseButtonEventHandler(Diagram_Tapped);
            pointerRelease = new MouseButtonEventHandler(Diagram_PointerReleased);
            nodes = new ObservableCollection<Node>();
            connectors = new ObservableCollection<Connector>();
            diagramControl1.Constraints = diagramControl1.Constraints | GraphConstraints.Undoable;
            diagramControl1.Nodes = nodes;
            diagramControl1.Connectors = connectors;
            graphInfo = diagramControl1.Info as IGraphInfo;

            graphInfo.ConnectorSourceChangedEvent += diagramControl1_ConnectorSourceChangedEvent;
            graphInfo.ConnectorTargetChangedEvent += diagramControl1_ConnectorSourceChangedEvent;
            diagramControl1.PageSettings = null;
            nodes.CollectionChanged += Nodes_CollectionChanged;
            AddEditType();
            this.AddHandler(Control.MouseLeftButtonUpEvent, tapped , true);
            this.MouseMove += Diagram_PointerMoved;
            //this.PointerReleased += Diagram_PointerReleased;
            this.AddHandler(Control.MouseLeftButtonUpEvent, pointerRelease, true);
            graphInfo.ConnectorTargetChangedEvent += diagramControl1_ConnectorTargetChangedEvent;
            connectors.CollectionChanged += Connections_CollectionChanged;
            //diagramControl1.View.ObjectDrawn += View_ObjectDrawn;
            this.MouseLeftButtonDown += Diagram_PointerPressed;
            diagramControl1.Tool = Tool.ZoomPan | Tool.SingleSelect;
            diagramControl1.DefaultConnectorType = ConnectorType.Line;
            diagramControl1.SnapSettings.SnapConstraints = SnapConstraints.All;
            diagramControl1.SnapSettings.SnapToObject = SnapToObject.All;
            diagramControl1.Menu = null;
            this.Unloaded += Diagram_Unloaded;
        }

        void Diagram_Unloaded(object sender, RoutedEventArgs e)
        {
            foreach (Node item in (IEnumerable<object>)diagramControl1.Nodes)
            {
                item.DataContext = null;
            }
            this.DataContext = null;

            if (nodes != null)
                nodes.CollectionChanged -= Nodes_CollectionChanged;
            this.MouseMove -= Diagram_PointerMoved;
            if (diagramControl1 != null)
                graphInfo.ConnectorTargetChangedEvent -= diagramControl1_ConnectorTargetChangedEvent;
            if (connectors != null)
                connectors.CollectionChanged -= Connections_CollectionChanged;
            this.MouseLeftButtonDown -= Diagram_PointerPressed;
            this.Unloaded -= Diagram_Unloaded;
            nodes.Clear();
            connectors.Clear();
            graphInfo = null;
            diagramControl1.Nodes = null;
            diagramControl1.Connectors = null;
            diagramControl1 = null;
            UMLViewModel = null;
            backbutton.MouseLeftButtonUp -= Back_Clicked;
            this.RemoveHandler(Control.MouseLeftButtonUpEvent, tapped);
            this.RemoveHandler(Control.MouseLeftButtonUpEvent, pointerRelease);
        }

        void diagramControl1_ConnectorSourceChangedEvent(object sender, ChangeEventArgs<object, ConnectorChangedEventArgs> args)
        {
            if ((args.NewValue.DragState == DragState.Completed && args.NewValue.Node == null))
            {
                connectors.Remove(args.Item as Connector);
            }
        }


        void diagramControl1_ConnectorTargetChangedEvent(object sender, ChangeEventArgs<object, ConnectorChangedEventArgs> args)
        {
            if (args.NewValue.Node != null)
            {
                Connector line = (args.Item as Connector);
                //line.Constraints = ConnectorConstraints.Selectable;
                if (line.Content != null)
                {
                    LineProperties content = line.Content as LineProperties;
                    content.PropertyChanged += proper_PropertyChanged;
                    if (line.SourceNode is Node)
                    {
                        content.Head = (line.SourceNode as Node).Content;
                    }
                    if (line.TargetNode is Node)
                    {
                        content.Tail = (line.TargetNode as Node).Content;
                    }
                    if (content.SplitPoint != new Point(0, 0))
                    {
                        ((line.Segments as ICollection<object>).ToList()[0] as StraightSegment).Point = content.SplitPoint;
                        line.InvalidateArrange();
                    }
                    if (UMLViewModel != null)
                    {
                        this.UMLViewModel.SelectedObject = line;
                    }
                }
                UpdateBinding(line);
            }
        }

        private void UpdateBinding(Connector line)
        {
            Binding bin = new Binding();
            bin.Path = new PropertyPath("Content.HeadStyle.Style");
            bin.RelativeSource = new RelativeSource() { Mode = RelativeSourceMode.Self };
            line.SetBinding(Connector.SourceDecoratorStyleProperty, bin);
            bin = new Binding();
            bin.Path = new PropertyPath("Content.LineStyle.Style");
            bin.RelativeSource = new RelativeSource() { Mode = RelativeSourceMode.Self };
            line.SetBinding(Connector.ConnectorGeometryStyleProperty, bin);
            bin = new Binding();
            bin.Path = new PropertyPath("Content.Label");
            bin.RelativeSource = new RelativeSource() { Mode = RelativeSourceMode.Self };
            bin = new Binding();
            bin.Path = new PropertyPath("Content.SourceShape");
            bin.RelativeSource = new RelativeSource() { Mode = RelativeSourceMode.Self };
            line.SetBinding(Connector.SourceDecoratorProperty, bin);
            bin = new Binding();
            bin.Path = new PropertyPath("Content.TailStyle.Style");
            bin.RelativeSource = new RelativeSource() { Mode = RelativeSourceMode.Self };
            line.SetBinding(Connector.TargetDecoratorStyleProperty, bin);
            bin = new Binding();
            bin.Path = new PropertyPath("Content.TargetShape");
            bin.RelativeSource = new RelativeSource() { Mode = RelativeSourceMode.Self };
            line.SetBinding(Connector.TargetDecoratorProperty, bin);
        }


        void View_ObjectDrawn(object sender, DrawingToolEventArgs evtArgs)
        {
            //if (evtArgs.DrawingObject is Connector)
            //{
            //    this.UMLViewModel.SelectedObject = evtArgs.DrawingObject;
            //    this.UMLViewModel.ShowProperties.Execute(this);
            //}
        }
        bool ischecktap = false;
        void Diagram_PointerPressed(object sender, MouseButtonEventArgs e)
        {
            ////foreach (var element in VisualTreeHelper.FindElementsInHostCoordinates(e.GetCurrentPoint(null).Position, null))
            //{
            //    if (element is SfRadialMenuItem)
            //    {                   
            //        ischecktap = false;
            //        return;
            //    }
            //    else if(element is Grid)
            //    {
            //        if((element as Grid).Name=="backbutton")
            //        {
            //            ischecktap = false;
            //            return;
            //        }
                  
            //    }               
            //}

            ////foreach (var element in VisualTreeHelper.FindElementsInHostCoordinates(e.GetCurrentPoint(null).Position, null))
            //{
            //    ischecktap = true;
            //    return;
            //}
            //Syncfusion.UI.Xaml.Controls.Navigation.SfRadialMenu menu = (e.OriginalSource as UIElement).GetParent<Syncfusion.UI.Xaml.Controls.Navigation.SfRadialMenu>();
            //if (menu == null)
            //{
            //    HideContextMenu();
            //    HideRadialMenu();
            //}
        }

        public UMLViewModel UMLViewModel
        {
            get { return (UMLViewModel)GetValue(UMLViewModelProperty); }
            set { SetValue(UMLViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UMLViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UMLViewModelProperty =
            DependencyProperty.Register("UMLViewModel", typeof(UMLViewModel), typeof(Diagram), new PropertyMetadata(null, OnUMLViewModelChanged));

        private static void OnUMLViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Diagram diagram = d as Diagram;
            UMLViewModel vm = e.NewValue as UMLViewModel;
            if (e.OldValue != null)
            {
                vm = e.OldValue as UMLViewModel;
                vm.AddINodeType = null;
                vm.Delete = null;
                vm.Connector = null;
                vm.ShowProperties = null;
                vm.Split = null;

                vm.Save = null;
                vm.Load = null;
                vm.Create = null;
                vm.Back = null;
                vm.Clear = null;

                vm.Undo = null;
                vm.Redo = null;

                vm.PageEditing = null;
                vm.PanEnabled = null;
                vm.ZoomEnabled = null;
            }
            if (e.NewValue == null)
            {
                return;
            }
            if (vm != null)
            {
                vm.AddINodeType = new DelegateCommand<NewNodeType>(diagram.OnAddINodeType);
                vm.Delete = new DelegateCommand<object>(diagram.OnDelete);
                vm.Connector = new DelegateCommand<object>(diagram.OnConnect, diagram.CanConnect);
                vm.ShowProperties = new DelegateCommand<object>(diagram.OnShowProperties, diagram.CanShowProperties);
                vm.Split = new DelegateCommand<object>(diagram.OnSplit, diagram.CanSplit);

                vm.Save = new DelegateCommand<object>(diagram.OnSave);
                vm.Load = new DelegateCommand<object>(diagram.OnLoad);
                vm.Create = new DelegateCommand<object>(diagram.OnCreate);
                vm.Back = new DelegateCommand<object>(diagram.OnBack);
                vm.Clear = new DelegateCommand<object>(diagram.OnClear);

                vm.Undo = new DelegateCommand<object>(diagram.OnUndo);
                vm.Redo = new DelegateCommand<object>(diagram.OnRedo);

                vm.PageEditing = new DelegateCommand<object>(diagram.OnPageEditing);
                vm.PanEnabled = new DelegateCommand<object>(diagram.OnPanEnabled);
                vm.ZoomEnabled = new DelegateCommand<object>(diagram.OnZoomCommand);
            }
        }

        void Diagram_PointerReleased(object sender, MouseButtonEventArgs e)
        {
            IsLineSplitEnabled = false;
        }

        void Nodes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                Node node = e.NewItems[0] as Node;                  
               node.ContentTemplate = App.Current.Resources[node.Content.GetType().Name] as DataTemplate;
                
                //node.ContentTemplateSelector = new NodeDataTemplateSelector();
                //var c = node.Content;
                //node.Content = null;
                //node.Content = c;

                //node.Style = this.Resources["NodeStyle"] as Style;
                if (node.Content is TextNode)
                {
                    node.Constraints = NodeConstraints.Selectable | NodeConstraints.Draggable;
                }
                else
                {
                    node.Constraints = NodeConstraints.Selectable | NodeConstraints.Draggable | NodeConstraints.Connectable;
                }
            }
        }

        void Connections_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                Connector line = (e.NewItems[0] as Connector);
                line.Constraints &= ~ConnectorConstraints.SegmentThumbs;
                line.Style = this.Resources["LineStyle"] as Style;
                if (line.Content == null)
                {
                    LineProperties proper = new LineProperties();
                    line.Content = proper;
                    proper.PropertyChanged += proper_PropertyChanged;
                }
                line.Annotations = new ObservableCollection<IAnnotation>()
                    {
                        new AnnotationEditorViewModel()
                            {
                                Content = (line.Content as LineProperties).Label,
                                RotationReference= RotationReference.Page
                            }
                    };
                line.ZIndex = 1;
            }
        }



        void proper_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Label")
            {
                LineProperties lineprop = (sender as LineProperties);
                if (UMLViewModel.SelectedObject != null)
                {
                    if (UMLViewModel.SelectedObject is Connector)
                    {
                        Connector connector = (UMLViewModel.SelectedObject as Connector);
                        //connector.Annotations.ToList().Remove((
                        (((IEnumerable<object>)connector.Annotations).ToArray()[0] as AnnotationEditorViewModel).Content = lineprop.Label;
                        //(connector.Annotations as ObservableCollection<IAnnotation>).Add(new AnnotationEditorViewModel() { Content = lineprop.Label });
                    }
                }
            }
        }

        #region Command

        private void OnZoomCommand(object param)
        {
            UMLViewModel.IsZoomEnabled = !UMLViewModel.IsZoomEnabled;
            if (UMLViewModel.IsZoomEnabled)
            {
                diagramControl1.Constraints |= GraphConstraints.Zoomable;
            }
            else
            {
                diagramControl1.Constraints &= ~GraphConstraints.Zoomable;
            }
        }

        private void OnPanEnabled(object param)
        {
            UMLViewModel.IsPanEnabled = !UMLViewModel.IsPanEnabled;
            if (UMLViewModel.IsPanEnabled)
            {
                //diagramControl1.Tool |= Tool.ZoomPan;  
                diagramControl1.Constraints |= GraphConstraints.Pannable;
            }
            else
            {
                diagramControl1.Constraints &= ~GraphConstraints.Pannable;
            }
        }

        private void OnPageEditing(object param)
        {

            UMLViewModel.IsPageEdit = !UMLViewModel.IsPageEdit;

            if (!UMLViewModel.IsPageEdit)
            {
                diagramControl1.Constraints &= ~GraphConstraints.Pannable;
                diagramControl1.Constraints &= ~GraphConstraints.Zoomable;
                diagramControl1.Tool &= ~(Tool.MultipleSelect | Tool.SingleSelect | Tool.ZoomPan);
            }
            else
            {
                diagramControl1.Tool |= Tool.MultipleSelect | Tool.SingleSelect | Tool.ZoomPan;


                if (UMLViewModel.IsZoomEnabled)
                {
                    diagramControl1.Constraints |= GraphConstraints.Zoomable;
                }
                else
                {
                    diagramControl1.Constraints &= ~GraphConstraints.Zoomable;
                }
                if (UMLViewModel.IsPanEnabled)
                {
                    //diagramControl1.Tool |= Tool.ZoomPan;  
                    diagramControl1.Constraints |= GraphConstraints.Pannable;
                }
                else
                {
                    diagramControl1.Constraints &= ~GraphConstraints.Pannable;
                }
            }
        }

        private void OnUndo(object param)
        {
            graphInfo.Commands.Undo.Execute(null);
        }

        private void OnRedo(object param)
        {
            graphInfo.Commands.Redo.Execute(null);
        }

        private void OnClear(object param)
        {
            List<Node> deleteNodes = nodes.Where(node => node.Content is INode).ToList();
            foreach (Node n in deleteNodes)
            {
                nodes.Remove(n);
            }

            List<Connector> deleteLines = connectors.OfType<Connector>().Where(line => line.Content is ILine).ToList();
            foreach (Connector l in deleteLines)
            {
                connectors.Remove(l);
            }
            HideContextMenu();
        }

        private void OnAddINodeType(NewNodeType type)
        {
            FrameworkElement Root = (Application.Current.MainWindow as FrameworkElement);
            Point center = new Point(Root.ActualWidth / 2, Root.ActualHeight / 2);
            center = Root.TransformToVisual(diagramControl1.Page).Transform(center);
            AddNewNodeType(type, center, true);
        }

        private void OnBack(object param)
        {
            this.UMLViewModel.DiagramVisibility = Visibility.Collapsed;
            this.UMLViewModel.Save.Execute(null);
            HideContextMenu();
            HideRadialMenu();
            HideEditType();
        }

        private async void OnSave(object param)
        {
            string installedlocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string pathString = System.IO.Path.Combine(installedlocation, "UML");
            string file = string.Empty;
            if (param == null)
            {
                file = this.UMLViewModel.CurrentlyLoaded;
            }
            else
            {
                this.UMLViewModel.CurrentlyLoaded = param.ToString();
                file = this.UMLViewModel.CurrentlyLoaded;
            }
            if (!string.IsNullOrEmpty(file))
            {
                if (File.Exists(pathString + "/" + file.ToString() + ".xml"))
                {
                    File.Delete(pathString + "/" + file.ToString() + ".xml");
                }

                File.Create(pathString + "/" + file.ToString() + ".xml").Close();

                DirectoryInfo DI = new DirectoryInfo(file);
                
                using (FileStream fileStream = File.OpenWrite(pathString + "/" + file.ToString() + ".xml"))
                {
                    Model mod = new Model();
                    mod.Serialize(diagramControl1, fileStream);
                }

            }
        }

        internal async System.Threading.Tasks.Task SaveAs(object param)
        {
            //StorageFile s = null;
            ////if (EnsureUnsnapped())
            //{
            //    if (param == null)
            //    {
            //        if (!string.IsNullOrEmpty(this.UMLViewModel.CurrentlyLoaded))
            //        {
            //            StorageFolder installedLocation = ApplicationData.Current.RoamingFolder;
            //            StorageFolder st = await installedLocation.GetFolderAsync("UML");
            //            s = await st.CreateFileAsync(this.UMLViewModel.CurrentlyLoaded + ".xml", CreationCollisionOption.ReplaceExisting);
            //        }
            //    }
            //    else
            //    {
            //        StorageFolder installedLocation = ApplicationData.Current.RoamingFolder;
            //        StorageFolder st = await installedLocation.GetFolderAsync("UML");
            //        s = await st.CreateFileAsync(param.ToString() + ".xml", CreationCollisionOption.ReplaceExisting);
            //        this.UMLViewModel.CurrentlyLoaded = param.ToString();
            //    }
            //    if (s != null)
            //    {
            //        using (StorageStreamTransaction writeStream = await s.OpenTransactedWriteAsync())
            //        {
            //            Model mod = new Model();
            //            mod.Serialize(diagramControl1, writeStream.Stream.AsStreamForWrite());
            //            await writeStream.CommitAsync();
            //        }
            //    }
            //}
        }

        private async void OnCreate(object parameter)
        {
            //StorageFile s = null;
            ////if (EnsureUnsnapped())
            //{
            //    StorageFolder installedLocation = ApplicationData.Current.RoamingFolder;
            //    StorageFolder st = await installedLocation.GetFolderAsync("UML");
            //    s = await st.CreateFileAsync(parameter.ToString() + ".xml", CreationCollisionOption.FailIfExists);
            //    this.UMLViewModel.CurrentlyLoaded = parameter.ToString();
            //}
            //if (s != null)
            //{
            //    using (StorageStreamTransaction writeStream = await s.OpenTransactedWriteAsync())
            //    {
            //        Model mod = new Model();
            //        SfDiagram empty = new SfDiagram();
            //        empty.Nodes = new ObservableCollection<Node>();
            //        empty.Connectors = new ObservableCollection<Connector>();
            //        mod.Serialize(empty, writeStream.Stream.AsStreamForWrite());
            //        await writeStream.CommitAsync();
            //    }
            //    OnLoad(parameter);
            //}

            string installedlocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string pathString = System.IO.Path.Combine(installedlocation, "UML");
            string file = parameter.ToString() + ".xml";
            {
                
                System.IO.File.Create(file);
                this.UMLViewModel.CurrentlyLoaded = parameter.ToString();
            }

            using (FileStream fileStream = File.OpenWrite(pathString + "/" + file))
            {
                Model mod = new Model();
                SfDiagram empty = new SfDiagram();
                empty.Nodes = new ObservableCollection<Node>();
                empty.Connectors = new ObservableCollection<Connector>();
                mod.Serialize(empty, fileStream);
            }
            OnLoad(parameter);
            UMLViewModel.DiagramVisibility = Visibility.Visible;
        }

        //internal bool EnsureUnsnapped()
        //{
        //    bool unsnapped = ((ApplicationView.Value != ApplicationViewState.Snapped) || ApplicationView.TryUnsnap());
        //    if (!unsnapped)
        //    {
        //        //NotifyUser("Cannot unsnap the sample.", NotifyType.StatusMessage);
        //    }
        //    return unsnapped;
        //}

        private bool m_IsLoading = false;

        private async void OnLoad(object param)
        {
           m_IsLoading = true;
            ////if (EnsureUnsnapped())
            //{
            //    StorageFile s;

            //    if (param == null)
            //    {
            //        FileOpenPicker file = new FileOpenPicker();
            //        file.CommitButtonText = "Load";
            //        file.FileTypeFilter.Add(".xml");
            //        this.UMLViewModel.CurrentlyLoaded = string.Empty;
            //        s = await file.PickSingleFileAsync();
            //    }
            //    else
            //    {
            //        StorageFolder installedLocation = ApplicationData.Current.RoamingFolder;
            //        StorageFolder st = await installedLocation.GetFolderAsync("UML");
            //        s = await st.GetFileAsync(param.ToString() + ".xml");
            //        this.UMLViewModel.CurrentlyLoaded = param.ToString();
            //    }
            string installedlocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string pathString = System.IO.Path.Combine(installedlocation, "UML");

            if (param != null)
            {
                List<Node> deleteNodes = nodes.Where(node => node.Content is INode).ToList();
                foreach (Node n in deleteNodes)
                {
                    nodes.Remove(n);
                }

                List<Connector> deleteLines = connectors.Where(line => line.Content is ILine).ToList();
                foreach (Connector l in deleteLines)
                {
                    connectors.Remove(l);
                }

                this.UMLViewModel.CurrentlyLoaded = param.ToString();

                DirectoryInfo DI = new DirectoryInfo(param.ToString());
                using (FileStream fileStream = File.OpenRead(pathString + "/" + param.ToString()+".xml"))
                {
                    Model mod = new Model();
                    mod.DeSerialize(fileStream, diagramControl1);
                }
                foreach (Node newNode in nodes.Where(node => node.Content is INode))
                {
                    BindPosition(newNode, newNode.Content as INode);
                }
                this.UMLViewModel.DiagramVisibility = Visibility.Visible;
                //diagramControl1.View.ClearUndoRedoStack();
                diagramControl1.CommandManager.View = (Control)Application.Current.MainWindow;

            }
            //    if (s != null)
            //    {
            //        List<Node> deleteNodes = nodes.Where(node => node.Content is INode).ToList();
            //        foreach (Node n in deleteNodes)
            //        {
            //            nodes.Remove(n);
            //        }

            //        List<Connector> deleteLines = connectors.Where(line => line.Content is ILine).ToList();
            //        foreach (Connector l in deleteLines)
            //        {
            //            connectors.Remove(l);
            //        }

            //        using (Stream readStream = await s.OpenStreamForReadAsync())
            //        {
            //            Model mod = new Model();
            //            mod.DeSerialize(readStream, diagramControl1);
            //        }

            //        foreach (Node newNode in nodes.Where(node => node.Content is INode))
            //        {
            //            BindPosition(newNode, newNode.Content as INode);
            //        }
            //        this.UMLViewModel.DiagramVisibility = Visibility.Visible;
            //        //diagramControl1.View.ClearUndoRedoStack();
            //        diagramControl1.CommandManager.View = (Control)Window.Current.Content;
            //    }
            //}
          m_IsLoading = false;
        }

        private bool CanSplit(object parameter)
        {
            if (this.UMLViewModel.SelectedObject is Node)
            {
                return false;
            }
            else if (this.UMLViewModel.SelectedObject is Connector)
            {
                LineProperties properties = (this.UMLViewModel.SelectedObject as Connector).Content as LineProperties;
                if (properties.LineType == LineType.AggregateOrAssociate || properties.LineType == LineType.Inheritance)
                {
                    return true;
                }
            }
            return false;
        }

        private Connector SplitLine = null;

        private void OnSplit(object parameter)
        {
            ShowConnectorEditType(this.UMLViewModel.SelectedObject as Connector);
            HideContextMenu();
            if (this.UMLViewModel.SelectedObject is Connector)
            {
                SplitLine = this.UMLViewModel.SelectedObject as Connector;
            }
            //HideEditType();
            //HideNewNodeCarousel();
        }

        private void OnDelete(object parameter)
        {
            if (this.UMLViewModel.SelectedObject is Node)
            {
                nodes.Remove(this.UMLViewModel.SelectedObject as Node);
            }
            else if (this.UMLViewModel.SelectedObject is Connector)
            {
                connectors.Remove(this.UMLViewModel.SelectedObject as Connector);
            }
            HideContextMenu();
            //HideEditType();
            //HideNewNodeCarousel();
        }

        private bool CanDelete(object parameter)
        {
            if (this.UMLViewModel.SelectedObject == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CanShowProperties(object parameter)
        {
            if (this.UMLViewModel.SelectedObject is Node)
            {
                return true;
            }
            else if (this.UMLViewModel.SelectedObject is Connector)
            {
                Connector line = this.UMLViewModel.SelectedObject as Connector;
                if ((line.SourceNode as Node).Content is NoteNode || (line.TargetNode as Node).Content is NoteNode)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        private void OnShowProperties(object parameter)
        {
            EditProperties();
            HideContextMenu();
            //HideEditType();
            //HideNewNodeCarousel();
        }

        private bool CanConnect(object parameter)
        {
            if (this.UMLViewModel.SelectedObject is Connector)
            {
                return false;
            }
            else if (this.UMLViewModel.SelectedObject is Node)
            {
                if ((this.UMLViewModel.SelectedObject as Node).Content is TextNode)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        private Node ConnectFrom = null;

        private void OnConnect(object parameter)
        {
            //diagramControl1.View.SetDrawingToolStartPosition(this.UMLViewModel.SelectedObject as Node);
            //diagramControl1.View.EnableDrawingTools = true;

            //diagramControl1.DrawingTool = DrawingTool.Straight;
            //diagramControl1.Tool = Tool.DrawOnce;

            HideContextMenu();
            //HideEditType();
            //HideNewNodeCarousel();
            if (this.UMLViewModel.SelectedObject is Node)
            {
                ConnectFrom = this.UMLViewModel.SelectedObject as Node;
                //diagramControl1.Tool = Tool.DrawOnce;
                //ConnectFrom.PointerPressed += (s, e) => diagramControl1.StartDraw(DrawingTool.Straight, e, new Point(100, 100), s);
                ShowNodeEditType(this.UMLViewModel.SelectedObject as Node);
            }
            else if (this.UMLViewModel.SelectedObject is Connector)
            {

            }
        }

        #endregion

        void Diagram_PointerMoved(object sender, MouseEventArgs e)
        {
            //PointerPointProperties properties = e.GetCurrentPoint(this).Properties;
            //if (properties.IsLeftButtonPressed ||
            //    properties.IsMiddleButtonPressed ||
            //    properties.IsRightButtonPressed)

            if(e.LeftButton==MouseButtonState.Pressed)
            {
                if (IsLineSplitEnabled)
                {
                    Connector line = this.SplitLine;
                    if (line != null)
                    {
                        Point pos =new Point(e.GetPosition(diagramControl1.Page).X,e.GetPosition(diagramControl1.Page).Y);
                        ((line.Segments as ICollection<object>).ToList()[0] as StraightSegment).Point = pos;
                        (line.Content as LineProperties).SplitPoint = pos;
                        line.InvalidateArrange();
                    }
                }
                //HideContextMenu();
                //HideRadialMenu();

                //HideNewNodeCarousel();
                //HideEditType();
                if (e.OriginalSource is SfDiagram)
                {
                    HideEditors();

                }
            }
        }

        void Diagram_Tapped(object sender, MouseButtonEventArgs e)
        {

            VisualTreeHelper.HitTest(this,
                                    e1 => HitTestFilterBehavior.Continue,
                                    e1 =>
                                    {
                                        DependencyObject item = e1.VisualHit.FindVisualParent<Node>();
                                        if (item != null)
                                        {
                                            this.UMLViewModel.SelectedObject = (item as Node);
                                            HideEditors();
                                            HideRadialMenu();
                                            ShowContextMenu();
                                            return HitTestResultBehavior.Stop;
                                        }
                                        if (item == null)
                                        {
                                             item = e1.VisualHit.FindVisualParent<Connector>();
                                            if (item != null)
                                            {
                                                this.UMLViewModel.SelectedObject = (item as Connector);
                                                HideEditors();
                                                HideRadialMenu();
                                                ShowContextMenu();
                                                return HitTestResultBehavior.Stop;
                                            }
                                            if (item == null)
                                            {
                                                item = e1.VisualHit.FindVisualParent<SfDiagram>();
                                                if(item!=null)
                                                {
                                                    if (ischecktap)
                                                    {
                                                        HideContextMenu();
                                                        HideRadialMenu();
                                                    }
                                                    else
                                                    {
                                                        HideContextMenu();
                                                        HideEditors();
                                                        ShowRadialMenu(e.GetPosition(this));
                                                    }
                                                    ischecktap = false;
                                                    TapPosition = e.GetPosition(this);
                                                    return HitTestResultBehavior.Stop;
                                                }
                                            }
                                            
                                        }
                                        return HitTestResultBehavior.Continue;
                                    },
                                    new PointHitTestParameters(e.GetPosition(this))
               );
            //UIElement elemen = e.OriginalSource as UIElement;           
            //    foreach (var element in VisualTreeHelper.FindElementsInHostCoordinates(e.GetPosition(null), null))
            //    {
            //        if (element is Node)
            //        {
            //            this.UMLViewModel.SelectedObject = (element as Node);
            //            //ShowNodeEditType(n as Node);
            //            //HideNewNodeCarousel();
            //            HideRadialMenu();
            //            HideEditors();
            //            ShowContextMenu();
            //            return;
            //        }
            //        else if (element is Connector)
            //        {
            //            this.UMLViewModel.SelectedObject = (element as Connector);
            //            //ShowConnectorEditType(n as LineConnector);
            //            //HideNewNodeCarousel();
            //            HideRadialMenu();
            //            HideEditors();
            //            ShowContextMenu();
            //            return;
            //        }
            //        else if (element is SfDiagram)
            //        {
            //            if (ischecktap)
            //            {
            //                HideEditors();
            //                HideContextMenu();
            //                ShowRadialMenu(e.GetPosition(this));
            //            }
            //            else
            //            {
            //                HideContextMenu();
            //                HideRadialMenu();
                            
            //            }

                       
            //            TapPosition = e.GetPosition(this);
            //            return;
            //        }

            //    }
            //    //Control n = elemen.GetParent<Node>();
            //    //// If clicked on a Node
            //    //if (n != null)
            //    //{
            //    //    //if (!carousel.Contains(n))
            //    //    //&& !editType.Contains(n))
            //    //    {
            //    //        this.UMLViewModel.SelectedObject = n;
            //    //        //ShowNodeEditType(n as Node);
            //    //        //HideNewNodeCarousel();
            //    //        HideRadialMenu();
            //    //        HideEditors();
            //    //        ShowContextMenu();
            //    //        return;
            //    //    }
            //    //}
            //    //else
            //    //{
            //    //    n = elemen.GetParent<Connector>();
            //    //    if (elemen.GetParent<TextBox>() != null)
            //    //    {
            //    //        return;
            //    //    }
            //    //    // If clicked on LineConnector
            //    //    if (n != null)
            //    //    {
            //    //        this.UMLViewModel.SelectedObject = n;
            //    //        //ShowConnectorEditType(n as LineConnector);
            //    //        //HideNewNodeCarousel();
            //    //        HideRadialMenu();
            //    //        HideEditors();
            //    //        ShowContextMenu();
            //    //        return;
            //    //    }
            //    //}

            //    ////this.UMLViewModel.SelectedObject = null;
            //    ////If not clicked on node a Node or LineConnector

            //    //if (n == null)
            //    //{
            //    //    n = elemen.GetParent<SfDiagram>();
            //    //    if (n == null)
            //    //    {
            //    //        //HideEditType();
            //    //        return;
            //    //    }
            //    //    HideEditors();
            //    //    HideContextMenu();

            //    //    ShowRadialMenu(e.GetPosition(this));
            //    //    TapPosition = e.GetPosition(this);
            //    //    return;
            //    //    //ShowNewNodeCarousel(e.GetPosition(diagramControl1.View.Page));
            //    //    //HideEditType();
            //    //}
            //    //else
            //    //{
            //    //    //HideNewNodeCarousel();
            //    //    //HideEditType();
            //    //}

            //    return;
        }

        #region Edit

        private Point TapPosition = new Point(0, 0);

        private List<Node> editType = new List<Node>();

        public void AddEditType()
        {
            addEditType(EditingType.Connect);
            //addEditType(EditingType.Delete);
            //addEditType(EditingType.EditProperty);
            addEditType(EditingType.Split);
        }

        private void addEditType(EditingType option)
        {
            EditingOption newNode = new EditingOption();
            newNode.EditType = option;

            Node node = new Node();
            node.Content = newNode;
           
            node.Visibility = Visibility.Collapsed;
            if (false)
            {
                throw new NotImplementedException();
                //node.AllowMove = false;
            }
            node.BringToFront();
            node.CenterNode();

            //node.PointerPressed += (s, e) =>
            //    {

            //    };

            nodes.Add(node);
            editType.Add(node);
            node.ContentTemplate = App.Current.Resources["EditingOption" + "_" + option.ToString()] as DataTemplate;
            //if (option == EditingType.Connect)
            //{
            node.MouseMove += node_PointerMoved;
            //}
            //    foreach (var item in editType)
            //    {
            //        EditingOption content = item.Content as EditingOption;
            //        switch (content.EditType)
            //        {
            //            case EditingType.Connect:
            //                item.PointerPressed += (s, e) => 
            //                break;
            //        }
            //    }

            //    //node.PointerPressed += (s, e) => diagram.StartDraw(DrawingTool.Straight, e, new Point(100, 100), s);

            //    //    {
            //    //        if (this.ConnectFrom != null)
            //    //        {
            //    //            throw new NotImplementedException();
            //    //            //diagramControl1.View.SetDrawingToolStartPosition(this.ConnectFrom);
            //    //            //diagramControl1.View.EnableDrawingTools = true;
            //    //        }
            //    //        else
            //    //        {
            //    //            this.ConnectFrom = null;
            //    //        }
            //    //    };
            //}
        }

        private void node_PointerMoved(object sender, MouseEventArgs e)
        {
            //if (e.Pointer.IsInContact)
            if(e.LeftButton==MouseButtonState.Pressed)
            {
                DoEdit((sender as Node));
                HideEditType();
                EditingOption content = (sender as Node).Content as EditingOption;
                if (content.EditType == EditingType.Connect)
                {
                    //diagramControl1.StartDraw(DrawingTool.Connector, e, new Point(100, 100),
                    //                          (this.UMLViewModel.SelectedObject as Node));
                    if (this.UMLViewModel.SelectedObject is Node)
                    {
                        Point p = e.GetPosition((sender as Node));
                        DrawParameter param = new DrawParameter(DrawingTool.Connector, e, p, this.UMLViewModel.SelectedObject,null,NullSourceTarget.SelectionAsSource);

                        graphInfo.Commands.Draw.Execute(param);
                    }
                    //new DrawCommandParameter(DrawingTool.Connector, e, node: this.UMLViewModel.SelectedObject));
                }
            }
            e.Handled = true;
        }

        public void HideEditType()
        {
            foreach (var item in editType)
            {
                item.Visibility = Visibility.Collapsed;
                item.OffsetX = 0;
                item.OffsetY = 0;
                item.ReleaseMouseCapture();
            }
        }

        public void HideEditors()
        {
            //if (NodeEditor != null)
            {
                if (PropertyEditor.Visibility != Visibility.Collapsed)
                {

                    (PropertyEditor.Resources["PropertyEditor_Storyboard_Collapse"] as Storyboard).Begin();
                }
            }
        }

        private Grid root;
        public void ShowNodeEditType(Node node)
        {
            foreach (var item in editType)
            {
                EditingOption content = item.Content as EditingOption;
                switch (content.EditType)
                {
                    case EditingType.Connect:
                        item.Visibility = Visibility.Visible;
                        item.UpdateLayout();
                        if (root == null)
                        {
                            root = item.FindChild<Grid>("LayoutRoot");
                        }
                        (root.Resources["8"] as Storyboard).Stop();
                        (root.Resources["8"] as Storyboard).Begin();
                        item.OffsetX = node.OffsetX + node.ActualWidth - (item.ActualWidth / 2);
                        item.OffsetY = node.OffsetY;
                        break;
                    //case EditingType.Delete:
                    //    item.Visibility = Visibility.Visible;
                    //    item.UpdateLayout();
                    //    item.OffsetX = node.OffsetX - item.ActualWidth;
                    //    item.OffsetY = node.OffsetY - item.ActualHeight;
                    //    break;
                    //case EditingType.EditProperty:
                    //    item.Visibility = Visibility.Visible;
                    //    item.UpdateLayout();
                    //    item.OffsetX = node.OffsetX + node.ActualWidth;
                    //    item.OffsetY = node.OffsetY - item.ActualHeight;
                    //    break;
                    //case EditingType.Split:
                    //    item.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    //    break;
                }
            }
        }

        //void item_PointerPressed(object sender, PointerRoutedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        public void ShowConnectorEditType(Connector line)
        {
            foreach (var item in editType)
            {
                //item.Visibility = Visibility.Visible;
                //item.UpdateLayout();
                EditingOption content = item.Content as EditingOption;
                //Rect bounds = line.ConnectorPathGeometry.Bounds;
                //Point center = new Point(bounds.Left + bounds.Width / 2,
                //    bounds.Top + bounds.Height / 2);
                //if (line.IntermediatePoints.Count == 1)
                //{
                //    center = line.IntermediatePoints[0];
                //}
                //double width = (item.DesiredSize.Width + 10) * 1;
                //double left = center.X - width / 2;
                //double top = center.Y - item.DesiredSize.Height / 2;
                switch (content.EditType)
                {
                    //case EditingType.Connect:
                    //    item.Visibility = Visibility.Collapsed;
                    //    item.UpdateLayout();
                    //    break;
                    //case EditingType.Delete:
                    //    item.OffsetX = left + 0 * (item.ActualWidth + 10);
                    //    item.OffsetY = top;
                    //    break;
                    case EditingType.Split:
                        item.Visibility = Visibility.Visible;
                        item.UpdateLayout();
                        Rect bounds = line.Geometry.Bounds;
                        Point center = new Point(bounds.Left + bounds.Width / 2,
                                                 bounds.Top + bounds.Height / 2);
                        center = ((line.Segments as ICollection<object>).ToList()[0] as StraightSegment).Point ?? center;
                        Storyboard sb = (item.FindChild<Ellipse>("ellipse").Resources["9"] as Storyboard);
                        //if (sb.GetCurrentState() == ClockState.Filling || sb.GetCurrentState() == ClockState.Stopped)
                        {
                            sb.RepeatBehavior = RepeatBehavior.Forever;
                            sb.Begin();
                        }
                        item.OffsetX = center.X;
                        item.OffsetY = center.Y;
                        break;
                    //case EditingType.EditProperty:
                    //    item.OffsetX = left + 2 * (item.ActualWidth + 10);
                    //    item.OffsetY = top;
                    //    break;
                }
            }
        }

        public void DoEdit(Node editType)
        {
            EditingOption work = editType.Content as EditingOption;
            switch (work.EditType)
            {
                case EditingType.Connect:
                    break;
                case EditingType.Delete:
                    break;
                case EditingType.EditProperty:
                    break;
                case EditingType.Split:
                    if (this.SplitLine != null)
                    {
                        IsLineSplitEnabled = true;
                    }
                    break;
            }
            //HideEditType();
        }

        private void EditProperties()
        {
            if (!m_IsLoading)
            {
                PropertyEditor.DataContext = null;
                Node source = this.UMLViewModel.SelectedObject as Node;
                Connector line = this.UMLViewModel.SelectedObject as Connector;
                if (this.UMLViewModel.SelectedObject is Node)
                {
                    PropertyEditor.DataContext = source.Content;
                    PropertyEditor.Visibility = Visibility.Visible;
                    (PropertyEditor.Resources["PropertyEditor_Storyboard_Visible"] as Storyboard).Begin();

                }
                if (line != null)
                {
                    PropertyEditor.DataContext = line.Content;
                    PropertyEditor.Visibility = Visibility.Visible;
                    LineProperties properties = line.Content as LineProperties;
                    //properties.InvalidateBinding();

                    (PropertyEditor.Resources["PropertyEditor_Storyboard_Visible"] as Storyboard).Begin();
                }
            }
        }

        #endregion

        private bool IsLineSplitEnabled = false;

        public void AddNewNodeType(NewNodeType type, Point position, bool animate)
        {
            if ((diagramControl1.SelectedItems as SelectorViewModel).Nodes != null)
            {
                List<Node> ver = ((IEnumerable<object>)(diagramControl1.SelectedItems as SelectorViewModel).Nodes).OfType<Node>().ToList();
                foreach (Node v in ver)
                {
                    v.IsSelected = false;
                }
            }

            if ((diagramControl1.SelectedItems as SelectorViewModel).Connectors != null)
            {
                List<Connector> ver = ((IEnumerable<object>)(diagramControl1.SelectedItems as SelectorViewModel).Connectors).OfType<Connector>().ToList();
                foreach (Connector v in ver)
                {
                    v.IsSelected = false;
                }
            }

            INode content = null;
            switch (type)
            {
                case NewNodeType.Class:
                    content = new ClassNode()
                    {
                        Name = "Class",
                        Functions = new ObservableCollection<Property>() { new Property { Name = "Function1()" } },
                        Properties = new ObservableCollection<Property>() { new Property { Name = "+Property1" } }
                    };
                    break;
                case NewNodeType.Interface:
                    content = new InterfaceNode()
                    {
                        Name = "Interface",
                        Functions = new ObservableCollection<Property>() { new Property { Name = "Function1()" } },
                        Properties = new ObservableCollection<Property>() { new Property { Name = "+Property1" } }
                    };
                    break;
                case NewNodeType.Note:
                    content = new NoteNode();
                    break;
                case NewNodeType.Text:
                    content = new TextNode();
                    break;
                case NewNodeType.Save:
                    //HideNewNodeCarousel();
                    OnSave(null);
                    return;
                case NewNodeType.Load:
                    //HideNewNodeCarousel();
                    OnLoad(null);
                    return;
            }

            Node newNode = new Node();

            if (animate)
            {
                newNode.Loaded += (sender1, event1) =>
                    {
                        Storyboard animation = newNode.FindChild<Border>("LayoutRoot").Resources["Animation"] as Storyboard;
                        animation.Stop();
                        if (animation.GetCurrentState() == ClockState.Filling || animation.GetCurrentState() == ClockState.Stopped)
                        {
                            animation.RepeatBehavior = RepeatBehavior.Forever;
                            animation.Begin();
                        }
                        newNode.MouseLeftButtonDown += (send, evt) =>
                            {
                                animation.Stop();
                            };
                    };
            }
            newNode.Content = content;
            newNode.CenterNode();
            content.ID = newNode.ID.ToString();
            BindPosition(newNode, content);
            ((IEnumerable<object>)(diagramControl1.SelectedItems as SelectorViewModel).Nodes).ToList().Clear();
            newNode.IsSelected = true;
            this.UMLViewModel.SelectedObject = newNode;
            newNode.OffsetX = position.X;
            newNode.OffsetY = position.Y;
            newNode.Constraints = NodeConstraints.Selectable | NodeConstraints.Draggable | NodeConstraints.Connectable;
            nodes.Add(newNode);
        }

        private void BindPosition(Node newNode, INode content)
        {
            Binding bin = new Binding();
            bin.Path = new PropertyPath("X");
            bin.Source = content;
            bin.Mode = BindingMode.TwoWay;
            newNode.SetBinding(Node.OffsetXProperty, bin);

            bin = new Binding();
            bin.Path = new PropertyPath("Y");
            bin.Source = content;
            bin.Mode = BindingMode.TwoWay;
            newNode.SetBinding(Node.OffsetYProperty, bin);
        }

        private void Back_Clicked(object sender, MouseButtonEventArgs e)
        {
            this.UMLViewModel.Back.Execute(null);
        }

        #region Radial

        private void ShowContextMenu()
        {
            if (UMLViewModel.IsPageEdit)//!diagramControl1.View.IsPageEditable)
            {
                Rect node;
                if (this.UMLViewModel.SelectedObject is Node)
                {
                    Node n = this.UMLViewModel.SelectedObject as Node;
                    node = new Rect(new Point(n.OffsetX, n.OffsetY),
                                    new Size(n.ActualWidth, n.ActualHeight));
                }
                else if (this.UMLViewModel.SelectedObject is Connector)
                {
                    Connector l = this.UMLViewModel.SelectedObject as Connector;
                    node = l.Geometry.Bounds;
                }
                else
                {
                    return;
                }
                node = diagramControl1.Page.TransformToVisual(this).TransformBounds(node);

                objectRadialMenu.Visibility = Visibility.Visible;
                //if (!objectRadialMenu.IsOpen)
                //{
                //    objectRadialMenu.IsOpen = true;
                //}
                //else
                //{
                //    objectRadialMenu.Show();
                //}

                objectRadialMenu.IsOpen = false;
                objectRadialMenu.UpdateLayout();
                objectRadialMenu.Focus();
                objectRadialMenu.IsOpen = true;

                double x = node.Right + 150 - objectRadialMenu.RadiusX;
                double y = node.Bottom - node.Height / 2 - objectRadialMenu.RadiusY;
                x = Math.Min(Math.Max(0, x), ActualWidth - objectRadialMenu.RadiusX * 2);
                y = Math.Min(Math.Max(0, y), ActualHeight - objectRadialMenu.RadiusY * 2);

                objectRadialMenu.RenderTransform = new TranslateTransform() { X = x, Y = y };
                objectRadialMenu.Focus();
            }
        }

        private void ShowRadialMenu(Point position)
        {
            if (UMLViewModel.IsPageEdit)//!diagramControl1.View.IsPageEditable)
            {

                radialMenu.Visibility =Visibility.Visible;
                //if (!radialMenu.IsOpen)
                //{
                //    radialMenu.IsOpen = true;
                //}
                //else
                //{
                //    radialMenu.Show();
                //}
                radialMenu.IsOpen = false;
                radialMenu.UpdateLayout();
                radialMenu.Focus();
                radialMenu.IsOpen = true;

                double x = position.X - radialMenu.RadiusX;
                double y = position.Y - radialMenu.RadiusY;
                x = Math.Min(Math.Max(0, x), ActualWidth - radialMenu.RadiusX * 2);
                y = Math.Min(Math.Max(0, y), ActualHeight - radialMenu.RadiusY * 2);

                radialMenu.RenderTransform = new TranslateTransform() { X = x, Y = y };
                radialMenu.Focus();
            }
        }

        private void HideRadialMenu()
        {
            //radialMenu.IsOpen = false;
            radialMenu.Visibility = Visibility.Collapsed;
        }

        private void HideContextMenu()
        {
            //objectRadialMenu.IsOpen = false;
            objectRadialMenu.Visibility = Visibility.Collapsed;
        }

        private void NewTextNode_Clicked(object sender, RoutedEventArgs e)
        {
            Point pos = this.TransformToVisual(diagramControl1.Page).Transform(TapPosition);
            this.AddNewNodeType(NewNodeType.Text, pos, false);
            HideRadialMenu();
            ischecktap = true;
            this.UMLViewModel.ShowProperties.Execute(null);
        }

        private void NewNoteNode_Clicked(object sender, RoutedEventArgs e)
        {
            Point pos = this.TransformToVisual(diagramControl1.Page).Transform(TapPosition);
            this.AddNewNodeType(NewNodeType.Note, pos, false);
            radialMenu.IsOpen = false;
            HideRadialMenu();
            ischecktap = true;
            this.UMLViewModel.ShowProperties.Execute(null);
        }

        private void NewInterfaceNode_Clicked(object sender, RoutedEventArgs e)
        {
            Point pos = this.TransformToVisual(diagramControl1.Page).Transform(TapPosition);
            this.AddNewNodeType(NewNodeType.Interface, pos, false);
            radialMenu.IsOpen = false;
            HideRadialMenu();
            ischecktap = true;
            this.UMLViewModel.ShowProperties.Execute(null);
        }

        private void NewClassNode_Clicked(object sender, RoutedEventArgs e)
        {
            Point pos = this.TransformToVisual(diagramControl1.Page).Transform(TapPosition);
            this.AddNewNodeType(NewNodeType.Class, pos, false);
            radialMenu.IsOpen = false;
            HideRadialMenu();
            ischecktap = true;
            this.UMLViewModel.ShowProperties.Execute(null);
        }

        private void Settings_Clicked(object sender, RoutedEventArgs e)
        {
            ischecktap = true;
            this.UMLViewModel.ShowProperties.Execute(null);
        }

        private void Split_Clicked(object sender, RoutedEventArgs e)
        {
            ischecktap = true;
            this.UMLViewModel.Split.Execute(null);
        }

        private void Connect_Clicked(object sender, RoutedEventArgs e)
        {
            ischecktap = true;
            this.UMLViewModel.Connector.Execute(null);
        }

        private void Delete_Clicked(object sender, RoutedEventArgs e)
        {
            ischecktap = true;
            this.UMLViewModel.Delete.Execute(null);
        }

        private void Clear_pressed(object sender, RoutedEventArgs e)
        {
            ischecktap = true;
            this.UMLViewModel.Clear.Execute(null);
        }

        private void Redo_Clicked(object sender, RoutedEventArgs e)
        {
            ischecktap = true;
            this.UMLViewModel.Redo.Execute(null);
        }

        private void UndoClicked(object sender, RoutedEventArgs e)
        {
            ischecktap = true;
            this.UMLViewModel.Undo.Execute(null);
        }

        private void SplitConnect_Clicked(object sender, RoutedEventArgs e)
        {
            ischecktap = true;
            if (this.CanSplit(null))
            {
                this.UMLViewModel.Split.Execute(null);
            }
            else
            {
                this.UMLViewModel.Connector.Execute(null);
            }
        }

        #endregion
    }

    class DrawingToolEventArgs
    {
        public bool DrawingObject { get; set; }
    }

    public class SfDiagram1 : SfDiagram
    {
        protected override object GetNewConnector(Type desiredType)
        {
            return new Connector() { Segments = new ConnectorSegments() { new StraightSegment() } };
        }
    }
    public class DrawParam : IDrawParameter
    {
        public DrawingTool Tool { get; set; }
        public Point? Point { get; set; }
        public object Node { get; set; }
        public object Port { get; set; }
        public MouseEventArgs PressedEventArgs { get; set; }
        public NullSourceTarget NullSourceTarget { get; private set; }

        public DrawParam(MouseEventArgs args, object node)
        {
            Tool = DrawingTool.Connector;
            PressedEventArgs = args;
            Node = node;
            NullSourceTarget = NullSourceTarget.None;
        }


    }

    public class ContentPresenters : ContentPresenter
    {

        public ContentPresenters()
        {

        }

        public SolidColorBrush Foreground
        {
            get { return (SolidColorBrush)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Foreground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.Register("Foreground", typeof(SolidColorBrush), typeof(ContentPresenters), new PropertyMetadata(new SolidColorBrush(Colors.DarkGray)));


    }
}
