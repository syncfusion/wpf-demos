#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Syncfusion.UI.Xaml.Diagram.Layout;
using System.Runtime.Serialization;
using Syncfusion.Windows.Controls.Media;
using Syncfusion.UI.Xaml.Diagram.Utility;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MindMap
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MindMapDiagram : UserControl
    {
        CustomNode SelectedNode;
        Popup p = new Popup();
        //ColorPicker c = new ColorPicker();
        ColorPicker c = new ColorPicker();
        MapViewModel m;
        bool IsPickerClicked = false;
        private IGraphInfo graphInfo;
        public static string _Layoutype;
        //ManipulationStartedEventHandler started;
        //ManipulationCompletedEventHandler complete;
        //ManipulationDeltaEventHandler delta;
        private ObservableCollection<CustomNode> _nodes = new ObservableCollection<CustomNode>();
        private ObservableCollection<CustomConnector> _connectors = new ObservableCollection<CustomConnector>();
        public MindMapDiagram()
        {
            this.InitializeComponent();
            diagramcontrol.Nodes = _nodes;
            diagramcontrol.Connectors = _connectors;
            graphInfo = diagramcontrol.Info as IGraphInfo;
            this.gird.Children.Add(p);
            diagramcontrol.MouseLeftButtonDown += diagramcontrol_PointerPressed;
            diagramcontrol.DefaultConnectorType = ConnectorType.Line;
            graphInfo.ItemTappedEvent += diagramcontrol_ItemTappedEvent;
            graphInfo.ItemSelectedEvent += diagramcontrol_ItemSelectedEvent;
            diagramcontrol.MouseDoubleClick += diagramcontrol_DoubleTapped;
            diagramcontrol.MouseLeftButtonUp += diagramcontrol_Tapped;
            diagramcontrol.KnownTypes = () => new List<Type>
                {
                    typeof(CustomLabel),
                    typeof(NodeCustom),
                    typeof(Nodepair),
                    typeof(MatrixTransform)
                };

            diagramcontrol.started = new MouseButtonEventHandler(n_ManipulationStarted);
            diagramcontrol.complete = new MouseButtonEventHandler(n_ManipulationCompleted);
            diagramcontrol.delta = new MouseEventHandler(n_ManipulationDelta);
            diagramcontrol.PageSettings = null;
            diagramcontrol.Menu = null;
            //LayoutType = "Bowtie";
            diagramcontrol.LayoutUpdated += diagramcontrol_LayoutUpdated;
            this.Unloaded += MindMapDiagram_Unloaded;
            graphInfo.ItemAdded += graphInfo_ItemAdded;
            (diagramcontrol.SelectedItems as SelectorViewModel).SelectorConstraints &=
                ~SelectorConstraints.QuickCommands;
        }

        void graphInfo_ItemAdded(object sender, ItemAddedEventArgs args)
        {
            if(args.Item is INode)
            {
                INode node = args.Item as INode;
                if(node.Annotations != null)
                {
                    ((node.Annotations as ObservableCollection<IAnnotation>)[0] as IAnnotation).WrapText = TextWrapping.NoWrap;
                }
            }
        }

        void MindMapDiagram_Unloaded(object sender, RoutedEventArgs e)
        {
            this.Unloaded -= MindMapDiagram_Unloaded;
            if (diagramcontrol != null)
            {
                diagramcontrol.LayoutUpdated -= diagramcontrol_LayoutUpdated;
                diagramcontrol.MouseLeftButtonDown -= diagramcontrol_PointerPressed;
                graphInfo.ItemTappedEvent -= diagramcontrol_ItemTappedEvent;
                graphInfo.ItemSelectedEvent -= diagramcontrol_ItemSelectedEvent;
                diagramcontrol.MouseDoubleClick -= diagramcontrol_DoubleTapped;
                diagramcontrol.MouseLeftButtonUp -= diagramcontrol_Tapped;
                foreach (Node node in diagramcontrol.Page.Children.OfType<CNode>())
                {
                    node.RemoveHandler(Node.MouseLeftButtonDownEvent, diagramcontrol.started);
                    node.RemoveHandler(Node.MouseLeftButtonUpEvent, diagramcontrol.complete);
                    node.RemoveHandler(Node.MouseMoveEvent, diagramcontrol.delta);
                }
            }
            //diagramcontrol.RemoveHandler(Node.ManipulationStartedEvent, started);
            //diagramcontrol.RemoveHandler(Node.ManipulationCompletedEvent, complete);
            //diagramcontrol.RemoveHandler(Node.ManipulationDeltaEvent, delta);
            MapViewModel.Nodes.Clear();
            MapViewModel.Lines.Clear();
            _nodes = null;
            _connectors = null;
            diagramcontrol.started = null;
            diagramcontrol.complete = null;
            diagramcontrol.delta = null;
            this.DataContext = null;
            MapViewModel = null;
            backButton.MouseLeftButtonUp -= Back_Clicked;
            diagramcontrol = null;


        }

        void diagramcontrol_Tapped(object sender, MouseButtonEventArgs e)
        {
            var v = MapViewModel.Nodes.ToList().Find(c => (c as CustomNode)._havetoUpdateLayout);
            if (SelectedNode != null && v != null && diagramcontrol.LayoutType.Equals("Bowtie"))
            {
                Updatebowtielayout("left");
                Updatebowtielayout("right");
                (v as CustomNode)._havetoUpdateLayout = false;
            }
        }

        void diagramcontrol_PointerPressed(object sender, MouseButtonEventArgs e)
        {
            if (IsPickerClicked)
                p.IsOpen = false;
            else
                IsPickerClicked = false;
        }

        public MapViewModel MapViewModel
        {
            get { return (MapViewModel)GetValue(MapViewModelProperty); }
            set { SetValue(MapViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MapViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MapViewModelProperty =
            DependencyProperty.Register("MapViewModel", typeof(MapViewModel), typeof(MindMapDiagram), new PropertyMetadata(null, OnPropertyChanged));


        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MindMapDiagram md = d as MindMapDiagram;
            if (e.OldValue != null)
            {
                MapViewModel vm = e.OldValue as MapViewModel;
                //md.m = md.MapViewModel;
                //md.m.Data = md;
                //md.UpdateCollection();
                md.m.Data = null;
                md.m = null;
                vm.Back = null;
                vm.Create = null;
                vm.Save = null;
                vm.Load = null;
                vm.Clear = null;
            }
            if (e.NewValue == null)
            {
                return;
            }
            md.MapViewModel = e.NewValue as MapViewModel;
            md.m = md.MapViewModel;
            md.m.Data = md;
            md.UpdateCollection();
            md.MapViewModel.Load = new DelegateCommand<object>(md.OnLoad, args => { return true; });
            md.MapViewModel.Back = new DelegateCommand<object>(md.OnBack, args => { return true; });
            md.MapViewModel.Create = new DelegateCommand<object>(md.OnCreate, args => { return true; });

            md.MapViewModel.Save = new DelegateCommand<object>(md.OnSave, args => { return true; });

            md.MapViewModel.Clear = new DelegateCommand<object>(md.OnClear, args => { return true; });
        }

        private void OnLoad(object param)
        {
            //if (EnsureUnsnapped())
            {
                _nodes.Clear();
                _connectors.Clear();
                diagramcontrol.Nodes = _nodes;
                diagramcontrol.Connectors = _connectors;

                string installedlocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string pathString = System.IO.Path.Combine(installedlocation, "MindMap");
                string file = string.Empty;

                if (param == null)
                {
                    file = this.MapViewModel.CurrentlyLoaded;
                }
                else
                {
                    this.MapViewModel.CurrentlyLoaded = param.ToString();
                    file = this.MapViewModel.CurrentlyLoaded;
                }
                if (file.Equals("ElementTree") || file.Equals("MindMap") || file.Equals("Feelings"))
                {

                }
                if (!string.IsNullOrEmpty(file))
                {

                    using (FileStream fileStream = File.Open(pathString + "/" + file + ".xml",FileMode.Open,FileAccess.ReadWrite))
                    {
                        if (fileStream != null)
                        {                           
                            Stream str = fileStream;
                            diagramcontrol.Upgrade(str);
                            str.Position = 0;
                            diagramcontrol.Load(str);
                            this.MapViewModel.DiagramVisibility = Visibility.Visible;
                        }
                    }
                }
                LayoutType = diagramcontrol.LayoutType;
                MindMapDiagram._Layoutype = diagramcontrol.LayoutType;
                if (diagramcontrol.LayoutType.Equals("Bowtie"))
                {
                    diagramcontrol.DefaultConnectorType = ConnectorType.CubicBezier;
                    foreach (CustomNode node in _nodes)
                    {
                        if (node.IsSelected)
                        {
                            MapViewModel.SelectedObject = node;
                            (diagramcontrol.SelectedItems as CustomSelector).SelectedObject = MapViewModel.SelectedObject;
                        }
                        if (node.Type.Equals("root") || node.Type.Equals("left") || node.Type.Equals("right"))
                        {
                            if (node.Type.Equals("root"))
                            {
                                Rootnode = node;
                            }
                            node.ContentTemplate = App.Current.Resources["CNodeTemplate"] as DataTemplate;
                            (node.Content as NodeCustom).type = node.Type;
                        }
                        else
                        {
                            LineGeometry path = CreateContent(0, node.UnitWidth, node.UnitHeight);
                            (node.Content as NodeCustom).path = path;
                            node.ContentTemplate = App.Current.Resources["LeafNodeTemplate"] as DataTemplate;
                            (node.Content as NodeCustom).Foreground = (node.Content as NodeCustom).SelectedBrush;
                            (node.Content as NodeCustom).type = node.Type;
                        }

                        if ((node.Content as NodeCustom).type != null && ((node.Content as NodeCustom).type.Equals("root")
                            || (node.Content as NodeCustom).type.Equals("left") || (node.Content as NodeCustom).type.Equals("right")))
                        {
                            (node.Content as NodeCustom).Foreground = new SolidColorBrush(Colors.White);
                        }
                        else
                        {
                            (node.Content as NodeCustom).Foreground = new SolidColorBrush(Colors.Black);
                        }
                        CustomLabel cl =(CustomLabel)(node.Annotations as ICollection<IAnnotation>).First();
                        cl.Offset = new Point(0.5, 0.5);
                       
                    }
                    _isloaded = true;
                }
                else
                {
                    diagramcontrol.DefaultConnectorType = ConnectorType.Line;
                    foreach (CustomNode node in _nodes)
                    {
                        if (node.IsSelected)
                        {
                            MapViewModel.SelectedObject = node;
                            (diagramcontrol.SelectedItems as CustomSelector).SelectedObject =
                                MapViewModel.SelectedObject;
                            (node.Content as NodeCustom).Foreground = new SolidColorBrush(Colors.White);



                            (node.Content as NodeCustom).Foreground = new SolidColorBrush(Colors.White);
                        }
                        else
                        {
                            (node.Content as NodeCustom).Foreground = new SolidColorBrush(Colors.White);
                            //foreach (IAnnotation ann in (node.Annotations as ICollection<IAnnotation>))
                            //{
                            //    ann.ViewTemplate = this.Resources["vtemplate1"] as DataTemplate;
                            //}
                        }
                        CustomLabel cl = (CustomLabel)(node.Annotations as ICollection<IAnnotation>).First();
                        cl.Offset = new Point(0.5, 0.5);

                    }

                }
            }
        }
        bool _isloaded = false;
        void diagramcontrol_LayoutUpdated(object sender, object e)
        {
            if (Rootnode != null && _isloaded && diagramcontrol.LayoutType.Equals("Bowtie"))
            {
                Updatebowtielayout("left");
                Updatebowtielayout("right");
                diagramcontrol.InvalidateMeasure();
                diagramcontrol.InvalidateArrange();
                _isloaded = false;
            }
            //throw new NotImplementedException();
        }

        private string _type;

        public string LayoutType
        {
            get { return _type; }
            set
            {
                _type = value;

                {
                    OnLayoutTypeChanged(_type);
                }

            }
        }
        private CustomNode _rootnode = null;


        [DataMember]
        public CustomNode Rootnode
        {
            get { return _rootnode; }
            set
            {
                _rootnode = value;

            }
        }

        private void OnLayoutTypeChanged(string _type)
        {
            if (_type.Equals("Bowtie") && diagramcontrol.LayoutManager == null)
            {
                diagramcontrol.LayoutManager = new Syncfusion.UI.Xaml.Diagram.Layout.LayoutManager()
                {
                    Layout = new CustomLayout()
                };

                (diagramcontrol.LayoutManager.Layout as CustomLayout).HorizontalSpacing
                    = 20;
                (diagramcontrol.LayoutManager.Layout as CustomLayout).VerticalSpacing = 50;
                (diagramcontrol.LayoutManager.Layout as CustomLayout).SpaceBetweenSubTrees = 30;
                diagramcontrol.DefaultConnectorType = ConnectorType.CubicBezier;              
            }
            else if (diagramcontrol.LayoutManager != null && _type.Equals("Circular"))
            {
                diagramcontrol.DefaultConnectorType = ConnectorType.Line;

            }

          
            //throw new NotImplementedException();
        }

     
     
        private NodePort AddPort(double p1, double p2)
        {
            NodePort port = new NodePort();

            port.NodeOffsetX = p1;

            port.NodeOffsetY = p2;
            return port;
        }

        private void Updatebowtielayout(string type)
        {
            if ((Rootnode.Info as INodeInfo).OutNeighbors != null && (Rootnode.Info as INodeInfo).OutNeighbors.ToList().Find(c => (c as CustomNode).Type == "left") != null && type != null && type.EndsWith("left"))
            {
                foreach (CustomNode item in MapViewModel.Nodes)
                {
                    if (item.Type.Equals("left") || item.Type.Equals("root") || item.Type.Equals("subleft"))
                    {
                        item.Constraints = item.Constraints & ~NodeConstraints.ExcludeFromLayout;
                    }
                    else
                    {
                        item.Constraints = item.Constraints | NodeConstraints.ExcludeFromLayout;
                    }
                }
                (diagramcontrol.LayoutManager.Layout as CustomLayout).Orientation = TreeOrientation.RightToLeft;
                (diagramcontrol.LayoutManager.Layout as CustomLayout).UpdateLayout(Rootnode);
            }
            if ((Rootnode.Info as INodeInfo).OutNeighbors != null && (Rootnode.Info as INodeInfo).OutNeighbors.ToList().Find(c => (c as CustomNode).Type == "right") != null && type != null && type.EndsWith("right"))
            {
                foreach (CustomNode item in MapViewModel.Nodes)
                {
                    if (item.Type.Equals("right") || item.Type.Equals("root") || item.Type.Equals("subright"))
                    {
                        item.Constraints = item.Constraints & ~NodeConstraints.ExcludeFromLayout;
                    }
                    else
                    {
                        item.Constraints = item.Constraints | NodeConstraints.ExcludeFromLayout;
                    }
                }
                (diagramcontrol.LayoutManager.Layout as CustomLayout).Orientation = TreeOrientation.LeftToRight;
                (diagramcontrol.LayoutManager.Layout as CustomLayout).UpdateLayout(Rootnode);
            }

        }

        private void OnSave(object param)
        {
            string installedlocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string pathString = System.IO.Path.Combine(installedlocation, "MindMap");
            string file = string.Empty;
            if (param == null)
            {
                file = this.MapViewModel.CurrentlyLoaded;
            }
            else
            {
                this.MapViewModel.CurrentlyLoaded = param.ToString();
                file = this.MapViewModel.CurrentlyLoaded;
            }

            if (!string.IsNullOrEmpty(file))
            {
                if (File.Exists(pathString + "/" + file.ToString() + ".xml"))
                {
                    File.Delete(pathString + "/" + file.ToString() + ".xml");
                }

                File.Create(pathString + "/" + file.ToString() + ".xml").Close();
                DirectoryInfo DI = new DirectoryInfo(file.ToString());
                using (FileStream fileStream = File.OpenWrite(pathString + "/" + file.ToString() + ".xml"))
                {
                    diagramcontrol.Save(fileStream);
                }
            }
        }

        //private bool EnsureUnsnapped()
        //{
        //    bool unsnapped = ((ApplicationView.Value != ApplicationViewState.Snapped) || ApplicationView.TryUnsnap());
        //    if (!unsnapped)
        //    {

        //    }
        //    return unsnapped;
        //}


        private void OnCreate(object parameter)
        {
            int index = parameter.ToString().IndexOf("_type");
            string sttr = parameter.ToString().Substring(index + 5);
            parameter = parameter.ToString().Substring(0, index);


            string installedlocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string pathString = System.IO.Path.Combine(installedlocation, "MindMap");
            string file = parameter.ToString() + ".xml";
            //if (EnsureUnsnapped())
            {

                System.IO.File.Create(file);
                this.MapViewModel.CurrentlyLoaded = parameter.ToString();
            }

            using (FileStream fileStream = File.OpenWrite(pathString + "/" + file))
            {
                SfDiagram empty = new SfDiagram();
                empty.Nodes = new ObservableCollection<Node>();
                empty.Connectors = new ObservableCollection<Connector>();
                empty.Save(fileStream);
            }

            MapViewModel.DiagramVisibility = Visibility.Visible;
            diagramcontrol.LayoutType = sttr;
            LayoutType = sttr;
            OnLoad(parameter);
            Rootnode = MapViewModel.RootNode();
            Rootnode.Type = "root";
            MindMapDiagram._Layoutype = sttr;
            if (LayoutType.Equals("Bowtie"))
            {
                Rootnode.Type = "root";
                Rootnode.UnitWidth = 90;
                Rootnode.UnitHeight = 40;
                Rootnode.Constraints = Rootnode.Constraints & ~NodeConstraints.Draggable;
            }

        }

        private void OnClear(object parameter)
        {
            foreach (CustomNode n in MapViewModel.Nodes.Where(n => n.AllowDelete.Equals(true)).ToList())
            {
                _nodes.Remove(n);
            }
            foreach (CustomConnector conn in MapViewModel.Lines)
            {
                conn.SourceNode = null;
                conn.TargetNode = null;
            }
            MapViewModel.Lines.Clear();
        }

        private void Back_Clicked(object sender, MouseButtonEventArgs e)
        {
            this.MapViewModel.Back.Execute(null);
        }

        private void OnBack(object obj)
        {
            p.IsOpen = false;
            this.MapViewModel.DiagramVisibility = Visibility.Collapsed;
            this.MapViewModel.Save.Execute(null);
        }

        private void UpdateCollection()
        {
            _nodes = MapViewModel.Nodes;
            _connectors = MapViewModel.Lines;
        }



        void diagramcontrol_DoubleTapped(object sender, MouseButtonEventArgs e)
        {
            p.IsOpen = false;
        }

        void diagramcontrol_ItemSelectedEvent(object sender, DiagramEventArgs args)
        {
            if (args.Item is INode)
            {
                MapViewModel.SelectedObject = args.Item as CustomNode;
                (diagramcontrol.SelectedItems as CustomSelector).SelectedObject = MapViewModel.SelectedObject;
                SelectedNode = args.Item as CustomNode;
            }
        }

        void diagramcontrol_ItemTappedEvent(object sender, DiagramEventArgs args)
        {
            if (args.Item is INode)
            {
                p.IsOpen = false;
                MapViewModel.SelectedObject = args.Item as CustomNode;
                (diagramcontrol.SelectedItems as CustomSelector).SelectedObject = MapViewModel.SelectedObject;
                if (!(args.Item as CustomNode).AllowDelete)
                    (diagramcontrol.SelectedItems as CustomSelector).AllowDelete = Visibility.Collapsed;
                else (diagramcontrol.SelectedItems as CustomSelector).AllowDelete = Visibility.Visible;
                SelectedNode = args.Item as CustomNode;
            }
        }



        public Node GetNode(CustomNode c)
        {
            Node n = new Node();
            foreach (Node node in diagramcontrol.Page.Children.OfType<Node>())
            {
                CustomNode cus = (node.DataContext as CustomNode);
                if (cus == c)
                    n = node;
            }
            return n;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((diagramcontrol.SelectedItems as SelectorViewModel).Nodes != null && diagramcontrol.LayoutType.Equals("Bowtie"))
            {
                SelectedNode = ((IEnumerable<object>)(diagramcontrol.SelectedItems as SelectorViewModel).Nodes).First() as CustomNode;
                if (SelectedNode is CustomNode)
                {
                    if ((SelectedNode as CustomNode).Type.Equals("root"))
                    {
                        CustomNode n = new CustomNode();
                        n.UnitWidth = 60;
                        n.UnitHeight = 40;
                        n.Type = "right";
                        n.Constraints = n.Constraints ^ NodeConstraints.Draggable;
                        NodePort port = AddPort(1, 0.5);
                        NodePort port1 = AddPort(0, 0.5);

                        n.NodePorts = new ObservableCollection<INodePort>()
            {
                port,
                port1
            };
                        n.ContentTemplate = App.Current.Resources["CNodeTemplate"] as DataTemplate;
                        MapViewModel.Nodes.Add(n);
                        Connect(SelectedNode, n, null);
                    }
                    else
                    {
                        CreateNode(SelectedNode, "subright");
                    }
                }
                Updatebowtielayout("right");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if ((diagramcontrol.SelectedItems as SelectorViewModel).Nodes != null)
            {
                SelectedNode = ((IEnumerable<object>)(diagramcontrol.SelectedItems as SelectorViewModel).Nodes).First() as CustomNode;
                if (diagramcontrol.LayoutType.Equals("Bowtie"))
                {
                    CreateBowtieLayout(SelectedNode);
                }
                else
                {
                    CustomNode n = new CustomNode();
                    // n.Constraints = n.Constraints &~ NodeConstraints.Draggable;
                    CustomConnector line = new CustomConnector();
                    n.InitialPair = new Nodepair(SelectedNode, n, line);
                    MapViewModel.Nodes.Add(n);
                    MapViewModel.Lines.Add(line);
                    MapViewModel.AddNode(n.Pair);
                }
            }
        }

        private void CreateBowtieLayout(CustomNode SelectedNode)
        {
            string type = null;

            if (SelectedNode is CustomNode)
            {
                CustomNode n = null;
                CustomConnector line = null;
                if ((SelectedNode as CustomNode).Type.Equals("root"))
                {
                    n = new CustomNode();
                    n.Constraints = n.Constraints ^ NodeConstraints.Draggable;
                    n.UnitWidth = 60;
                    n.UnitHeight = 40;
                    n.Type = "left";
                    type = "left";
                    NodePort port = AddPort(0, 0.5);
                    NodePort port1 = AddPort(1, 0.5);
                    n.NodePorts = new ObservableCollection<INodePort>()
            {
                port,
                port1
            };
                    n.ContentTemplate = App.Current.Resources["CNodeTemplate"] as DataTemplate;
                    MapViewModel.Nodes.Add(n);
                    line = Connect(SelectedNode, n, null);
                }
                else
                {
                    if (SelectedNode.Type.Equals("right") || SelectedNode.Type.Equals("subright"))
                    {
                        CreateNode(SelectedNode, "subright");
                        type = "right";
                    }
                    else
                    {
                        CreateNode(SelectedNode, "subleft");
                        type = "left";
                    }
                }

            }

            Updatebowtielayout(type);
        }
        //throw new NotImplementedException();


        private void CreateNode(CustomNode SelectedNode, string type)
        {
            CustomNode n = new CustomNode();
            n.UnitWidth = 60;
            n.UnitHeight = 40;
            n.Type = type;
            string name = "node";
            n.Constraints = n.Constraints ^ NodeConstraints.Draggable;
            NodePort port = null;
            NodePort port1 = null;
            if (type.StartsWith("sub"))
            {
                port = AddPort(0, 0.98);
                port1 = AddPort(1, 0.98);
            }

            if (type.Equals("subleft") || type.Equals("subright"))
            {
                LineGeometry path = CreateContent(0, n.UnitWidth, n.UnitHeight);
                (n.Content as NodeCustom).path = path;
                n.ContentTemplate = App.Current.Resources["LeafNodeTemplate"] as DataTemplate;
            }

            if (port != null)
            {
                n.NodePorts = new ObservableCollection<INodePort>()
            {
                port,
                port1
            };
            }
            n.NodeAnnotations = new ObservableCollection<IAnnotation>()
            {
                new CustomLabel(){Content=name,Offset=new Point(0.5,0.5)}
                
            };
            MapViewModel.Nodes.Add(n);
            if (type.Equals("subleft"))
                Connect(SelectedNode, n, port1);
            else
                Connect(SelectedNode, n, port);
        }

        private LineGeometry CreateContent(double p1, double p2, double p3)
        {
            LineGeometry line = new LineGeometry();
            line.StartPoint = new Point(p1, p3);
            line.EndPoint = new Point(p2, p3);
            return line;

            // throw new NotImplementedException();
        }

        private CustomConnector Connect(CustomNode SelectedNode, CustomNode n, NodePort port)
        {
            CustomConnector conn = new CustomConnector();
            MapViewModel.Lines.Add(conn);
            conn.SourceNode = SelectedNode;
            conn.TargetNode = n;
            if (SelectedNode.NodePorts != null && SelectedNode.NodePorts.Count() > 1 && SelectedNode.Type.StartsWith("sub"))
            {
                if (SelectedNode.Type.Equals("subleft"))
                {
                    conn.SourcePort = SelectedNode.NodePorts.ElementAt(0);
                    conn.TargetPort = n.NodePorts.ElementAt(1);
                }
                else
                {
                    conn.SourcePort = SelectedNode.NodePorts.ElementAt(1);
                    conn.TargetPort = n.NodePorts.ElementAt(0);
                }
            }
            else if (SelectedNode.Type.Equals("left") || SelectedNode.Type.Equals("right"))
            {
                if (SelectedNode.Type.Equals("left"))
                {
                    conn.SourcePort = SelectedNode.NodePorts.ElementAt(0);
                    conn.TargetPort = n.NodePorts.ElementAt(1);
                }
                else
                {
                    conn.SourcePort = SelectedNode.NodePorts.ElementAt(0);
                    conn.TargetPort = n.NodePorts.ElementAt(0);
                }

            }
            //else if (SelectedNode.Type.Equals("right"))
            //{
            //    if (SelectedNode.NodePorts != null && SelectedNode.NodePorts.Count() > 0)
            //    {
            //        conn.SourcePort = SelectedNode.NodePorts.ElementAt(0);
            //    }
            //}
            else if (SelectedNode.Type.Equals("root"))
            {
                if (n.Type.Equals("left"))
                {
                    conn.SourcePort = SelectedNode.NodePorts.ElementAt(0);
                    conn.TargetPort = n.NodePorts.ElementAt(1);
                }
                else
                {
                    conn.SourcePort = SelectedNode.NodePorts.ElementAt(1);
                    conn.TargetPort = n.NodePorts.ElementAt(1);

                }
            }
            conn.TargetDecorator = null;
            //conn.Style=App.Current.Resources
         
            conn.Loaded += conn_Loaded;
            return conn;
        }

        void conn_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as CustomConnector).Loaded -= conn_Loaded;
        }

        private void n_ManipulationDelta(object sender, MouseEventArgs e)
        {
            {
                if (!ManipulateOnNode(e))
                {
                    return;
                }

                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    Node n1 = ((e.OriginalSource as UIElement).FindVisualParent<Node>());
                    if (n1 != null)
                    {
                        CustomNode c = n1.DataContext as CustomNode;
                        if (diagramcontrol.LayoutType.Equals("Circular"))
                        {
                            foreach (CustomNode n in _nodes)
                            {

                                n.IsIntersect = false;
                                if (c != null)
                                {
                                    if (c.Pair.Root != null)
                                    {
                                        if (c != (n as CustomNode) && (n as CustomNode != (c.Pair.Root)) && (c != n.Pair.Root))
                                        {
                                            Rect r = (n.Info as INodeInfo).Bounds;
                                            m.CheckingNode = n;
                                            if ((r.Contains(new Point((c.Info as INodeInfo).Bounds.Left, (c.Info as INodeInfo).Bounds.Top)) || r.Contains(new Point((c.Info as INodeInfo).Bounds.Right, (c.Info as INodeInfo).Bounds.Top)) || r.Contains(new Point((c.Info as INodeInfo).Bounds.Left, (c.Info as INodeInfo).Bounds.Bottom)) || r.Contains(new Point((c.Info as INodeInfo).Bounds.Right, (c.Info as INodeInfo).Bounds.Bottom)) || r.Contains(new Point(c.OffsetX, c.OffsetY))) && !m.ChildCheck(c))
                                            {
                                                n.IsIntersect = true;
                                                if (n.Pair.Link != null)
                                                    n.Pair.Link.ConnectorGeometryStyle = App.Current.Resources["IntersectLine"] as Style;
                                                n.ContentTemplate = App.Current.Resources["IntersectTemplate"] as DataTemplate;
                                            }
                                        }
                                    }
                                }
                                if (!n.IsIntersect && n != SelectedNode)
                                {
                                    if (n.Pair.Link != null)
                                        n.Pair.Link.ConnectorGeometryStyle = App.Current.Resources["NormalLine"] as Style;
                                    n.ContentTemplate = App.Current.Resources["CNodeTemplate"] as DataTemplate;
                                }
                                n.IsIntersect = false;
                            }
                        }
                    }
                }
            }
            e.Handled = true;
        }

        private bool ManipulateOnNode(RoutedEventArgs e)
        {
            UIElement element = e.OriginalSource as UIElement;
            if (element is Node) { return true; }
            if (element == null)
                return false;
            Node n = FindVisualParent<Node>(element);
            if (n == null)
                return false;
            return true;
        }

        void n_ManipulationStarted(object sender, MouseButtonEventArgs e)
        {
            if (diagramcontrol.LayoutType.Equals("Circular"))
            {
                try
                {
                    graphInfo.Commands.BringToFront.Execute(diagramcontrol);
                }
                catch { }
            }
            e.Handled = true;
        }

        public T FindVisualParent<T>(DependencyObject dobj) where T : DependencyObject
        {
            DependencyObject parent = VisualTreeHelper.GetParent(dobj);
            if (parent == null && parent is FrameworkElement)
            {
                parent = (parent as FrameworkElement).Parent;
            }
            if (parent is T)
            {
                return parent as T;
            }
            else if (parent != null)
            {
                return FindVisualParent<T>(parent);
            }
            else
            {
                return null;
            }
        }

        void n_ManipulationCompleted(object sender, MouseButtonEventArgs e)
        {
            //if (diagramcontrol.LayoutType.Equals("Circular"))
            //{
            //    if (!ManipulateOnNode(e))
            //    {
            //        return;
            //    }
            //    CustomNode c = (e.OriginalSource as Node).DataContext as CustomNode;
            //    if (c != null)
            //    {
            //        if (c.Pair.Link != null)
            //            c.Pair.Link.ConnectorGeometryStyle = App.Current.Resources["NormalLine"] as Style;
            //        c.ContentTemplate = App.Current.Resources["CNodeTemplate"] as DataTemplate;
            //        c.Angle = MapViewModel.FindAngle(c);
            //        ObservableCollection<CustomNode> coll = new ObservableCollection<CustomNode>();
            //        foreach (CustomNode n in _nodes)
            //        {
            //            if (!n.IsIntersect && n != SelectedNode)
            //            {
            //                if (n.Pair.Link != null)
            //                    n.Pair.Link.ConnectorGeometryStyle = App.Current.Resources["NormalLine"] as Style;
            //                n.ContentTemplate = App.Current.Resources["CNodeTemplate"] as DataTemplate;
            //            }
            //            if (c != (n as CustomNode))
            //            {
            //                Rect r = (n.Info as INodeInfo).Bounds;
            //                if (r.Contains(new Point((c.Info as INodeInfo).Bounds.Left, (c.Info as INodeInfo).Bounds.Top)) || r.Contains(new Point((c.Info as INodeInfo).Bounds.Right, (c.Info as INodeInfo).Bounds.Top)) || r.Contains(new Point((c.Info as INodeInfo).Bounds.Left, (c.Info as INodeInfo).Bounds.Bottom)) || r.Contains(new Point((c.Info as INodeInfo).Bounds.Right, (c.Info as INodeInfo).Bounds.Bottom)) || r.Contains(new Point(c.OffsetX, c.OffsetY)))
            //                {
            //                    m.CheckingNode = n;
            //                    if (!m.ChildCheck(c))
            //                    {
            //                        m.AllowUpdate = true;
            //                        c.InitialPair = new Nodepair(n, c, c.Pair.Link);
            //                        m.AddNode(c.Pair);
            //                    }
            //                }
            //            }
            //        }
            //        if (c.Childs != null)
            //        {
            //            foreach (CustomNode node in c.Childs)
            //                coll.Add(node);
            //            if (m.AllowUpdate && !m.ChildCheck(c))
            //            {
            //                foreach (CustomNode cn in coll)
            //                {
            //                    m.RemoveNode(cn);
            //                }
            //                m.Update(c);
            //            }
            //        }
            //    }
            //    MapViewModel.AllowUpdate = false;
            //}
            //e.Handled = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if ((diagramcontrol.SelectedItems as SelectorViewModel).Nodes != null && ((IEnumerable<object>)(diagramcontrol.SelectedItems as SelectorViewModel).Nodes).Count() > 0)
            {
                SelectedNode = ((IEnumerable<object>)(diagramcontrol.SelectedItems as SelectorViewModel).Nodes).First() as CustomNode;
                if (SelectedNode.AllowDelete)
                {
                    if (diagramcontrol.LayoutType.Equals("Circular"))
                    {
                        SelectedNode.Pair.Root.Childs.Remove(SelectedNode);
                        MapViewModel.RemoveNode(SelectedNode);
                        
                    }
                    else
                    {
                        DeleteNode(SelectedNode);

                        Updatebowtielayout(SelectedNode.Type);
                    }
                }
            }
            this.p.IsOpen = false;
            this.IsPickerClicked = false;
        }


        private void DeleteNode(CustomNode SelectedNode)
        {
            if ((SelectedNode.Info as INodeInfo).OutNeighbors != null && (SelectedNode.Info as INodeInfo).OutNeighbors.Count() > 0)
            {
                for (int i = (SelectedNode.Info as INodeInfo).OutNeighbors.Count() - 1; (SelectedNode.Info as INodeInfo).OutNeighbors.Count() - 1 >= i && i >= 0; i--)
                {
                    CustomNode c = (SelectedNode.Info as INodeInfo).OutNeighbors.ElementAt(i) as CustomNode;
                    DeleteNode(c);
                }
            }
            if ((SelectedNode.Info as INodeInfo).InOutConnectors != null)
            {
                for (int i = (SelectedNode.Info as INodeInfo).InOutConnectors.Count() - 1; (SelectedNode.Info as INodeInfo).InOutConnectors.Count() - 1 >= i && i >= 0; i--)
                {
                    CustomConnector con = (SelectedNode.Info as INodeInfo).InOutConnectors.ElementAt(i) as CustomConnector;
                    con.SourceNode = null;
                    con.TargetNode = null;
                    MapViewModel.Lines.Remove(con);
                }
            }
            MapViewModel.Nodes.Remove(SelectedNode);

            //throw new NotImplementedException();
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            IsPickerClicked = true;
           
            if (SelectedNode is CustomNode && !(p.IsOpen))
            {
                double x = SelectedNode.OffsetX;
                double y = SelectedNode.OffsetY;
                double w1 = (SelectedNode.Info as INodeInfo).ActualWidth;
                double h1 = (SelectedNode.Info as INodeInfo).ActualHeight;
                double w = graphInfo.Viewport.Width;
                double h = graphInfo.Viewport.Height;
                double x1 = graphInfo.Viewport.Left;
                double y1 = graphInfo.Viewport.Top;
                double width = 300;
                double height = 300;
                //double width = 
                //(((c as ColorPicker).Content as Grid).Children.First() as Syncfusion.UI.Xaml.Controls.Media.SfColorPicker).Width;
                //double height = 
                //(((c as ColorPicker).Content as Grid).Children.First() as Syncfusion.UI.Xaml.Controls.Media.SfColorPicker).Height;
                if (width > (w - x + w1 + x1))
                    p.HorizontalOffset = SelectedNode.OffsetX - (SelectedNode.Info as INodeInfo).DesiredSize.Width - x1;
                else
                    p.HorizontalOffset = (SelectedNode.OffsetX + (SelectedNode.Info as INodeInfo).DesiredSize.Width + width) - x1;
                if (height > h - y + y1)
                    p.VerticalOffset = SelectedNode.OffsetY - height - y1;
                else
                    p.VerticalOffset = SelectedNode.OffsetY - y1;

                p.Placement = PlacementMode.AbsolutePoint;
                p.Child = c;
                (p.Child as ColorPicker).DataContext = (m.SelectedObject as CustomNode).Content;
                (p.Child as ColorPicker).Picker.MoreColorWindowOpening += Picker_MoreColorWindowOpening;
                ((m.SelectedObject as CustomNode).Content as NodeCustom).PropertyChanged += MainPage_PropertyChanged;
                p.IsOpen = true;
            }

        }

        private void Picker_MoreColorWindowOpening(object sender, MoreColorCancelEventArgs args)
        {
            this.p.IsOpen = false;
            this.IsPickerClicked = false;
        }

        void MainPage_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("SelectedBrush"))
            {
                if ( (SelectedNode.Content as NodeCustom).type != null &&  (SelectedNode.Content as NodeCustom).type.StartsWith("sub"))
                {
                    Color forecolor = (SelectedNode.Content as NodeCustom).SelectedBrush.Color;
                    Node n = GetNode(SelectedNode);
                    n.Foreground = new SolidColorBrush(forecolor);
                }
            }

        }

        private int PerceivedBrightness(Color c)
        {
            return (int)Math.Sqrt(
            c.R * c.R * .241 +
            c.G * c.G * .691 +
            c.B * c.B * .068);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //StorageFile s = null;
            //FileSavePicker save = new FileSavePicker();
            //StorageFolder installedLocation = ApplicationData.Current.RoamingFolder;
            //save.FileTypeChoices.Add("xml", new List<string>() { ".xml" });
            //s = await save.PickSaveFile();
            //if (s != null)
            //{
            //    using (IRandomAccessStream writeStream = await s.Open(FileAccessMode.ReadWrite))
            //    {
            //        if (writeStream != null)
            //        {
            //            Stream str = writeStream.AsStream();
            //            diagramcontrol.Save(str);
            //        }
            //    }
            //}

            string installedlocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string pathString = System.IO.Path.Combine(installedlocation, "MindMap");

            //if (param != null)
            {
                System.IO.File.Create(".//MindMap/" + "empty" + ".xml");
                this.MapViewModel.CurrentlyLoaded = "empty" + ".xml";

                DirectoryInfo DI = new DirectoryInfo("empty" + ".xml");
                using (FileStream fileStream = File.OpenRead(".//MindMap/" + "empty" + ".xml"))
                {
                    diagramcontrol.Save(fileStream);
                }

            }
        }

        private void Button_Unloaded(object sender, RoutedEventArgs e)
        {
            (sender as Button).Unloaded -= Button_Unloaded;
            (sender as Button).Click -= Button_Click;
        }
        private void Button_Unloaded_1(object sender, RoutedEventArgs e)
        {
            (sender as Button).Unloaded -= Button_Unloaded_1;
            (sender as Button).Click -= Button_Click_1;
        }
        private void Button_Unloaded_2(object sender, RoutedEventArgs e)
        {
            (sender as Button).Unloaded -= Button_Unloaded_2;
            (sender as Button).Click -= Button_Click_2;
        }
        private void Button_Unloaded_3(object sender, RoutedEventArgs e)
        {
            (sender as Button).Unloaded -= Button_Unloaded_3;
            (sender as Button).Click -= Button_Click_3;
        }


    }

    public class CustomConverter : IValueConverter
    {


        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ColortoBrushConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                SolidColorBrush s = value as SolidColorBrush;
                return s.Color;
            }
            else
                return null;
            //throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Color c = (Color)value;
            return new SolidColorBrush(Color.FromArgb(c.A, c.R, c.G, c.B));
        }
    }

    public class VisibilityConverter1 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                object obj = (object)value;

                if (obj.GetType() == typeof(CustomNode))
                {
                    if (MindMapDiagram._Layoutype != null)
                    {
                        if (MindMapDiagram._Layoutype.Equals("Bowtie"))
                        {
                            if ((obj as CustomNode).Type != null && ((obj as CustomNode).Type.Equals("root") || (obj as CustomNode).Type.EndsWith("right")))
                            {
                                return Visibility.Visible;
                            }
                        }
                    }
                }
                return Visibility.Collapsed;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                object obj = (object)value;

                if (obj.GetType() == typeof(CustomNode))
                {
                    if (MindMapDiagram._Layoutype != null)
                    {
                        if (MindMapDiagram._Layoutype.Equals("Bowtie"))
                        {
                            if ((obj as CustomNode).Type != null && ((obj as CustomNode).Type.Equals("root") || (obj as CustomNode).Type.EndsWith("left")))
                            {
                                return Visibility.Visible;
                            }
                        }
                        else
                        {
                            return Visibility.Visible;
                        }
                    }

                }
                return Visibility.Collapsed;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DeleteVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                object obj = (object)value;

                if (obj.GetType() == typeof(CustomNode))
                {
                    if (MindMapDiagram._Layoutype != null)
                    {
                        if (MindMapDiagram._Layoutype.Equals("Bowtie"))
                        {
                            if ((obj as CustomNode).Type != null && (obj as CustomNode).Type.EndsWith("left"))
                            {
                                return Visibility.Visible;
                            }
                        }
                        else if ((obj as CustomNode).Type != null && !((obj as CustomNode).Type.Equals("root")) && (obj as CustomNode).AllowDelete)
                        {
                            return Visibility.Visible;
                        }
                    }
                }
                return Visibility.Collapsed;
            }

            return Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

    public class InvertDeleteVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                object obj = (object)value;

                if (obj.GetType() == typeof(CustomNode))
                {

                    if ((obj as CustomNode).Type != null && (obj as CustomNode).Type.EndsWith("right"))
                    {
                        return Visibility.Visible;
                    }


                }
                return Visibility.Collapsed;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }


    class CustomLayout : DirectedTreeLayout
    {
        protected override INodeInfo GetNextSibling(INode node)
        {
            INodeInfo nodeinfo = node.Info as INodeInfo;
            INode _parent = nodeinfo.InNeighbors.ElementAt(0) as CustomNode;
            INodeInfo parent = _parent.Info as INodeInfo;
            if ((_parent as CustomNode).Type.Equals("root"))
            {
                if (Orientation == TreeOrientation.RightToLeft)
                {
                    if (parent != null)
                    {
                        return GetNextChild(parent, node, "left");

                    }
                    else
                        return null;
                }
                else if (Orientation == TreeOrientation.LeftToRight)
                {
                    if (parent != null)
                    {
                        return GetNextChild(parent, node, "right");

                    }
                    else
                        return null;
                }
                else
                {
                    return base.GetNextSibling(node);
                }
            }
            else
            {
                return base.GetNextSibling(node);
            }
        }

        private INodeInfo GetNextChild(INodeInfo parent, INode node, string type)
        {
            var children = parent.OutNeighbors.ToList().FindAll(c => (c as CustomNode).Type.Equals(type));
            if (children.Contains(node as CustomNode))
            {
                int index = children.IndexOf(node as CustomNode);
                if (children != null && index < children.Count() - 1 && index >= 0)
                {
                    return (children.ElementAt(index + 1) as CustomNode).Info as INodeInfo;
                }
                else
                    return null;
            }
            return null;
        }

        protected override INodeInfo GetPreviousSibling(INode node)
        {
            INodeInfo nodeinfo = node.Info as INodeInfo;
            INode _parent = nodeinfo.InNeighbors.ElementAt(0) as CustomNode;
            INodeInfo parent = _parent.Info as INodeInfo;
            if ((_parent as CustomNode).Type.Equals("root"))
            {
                if (Orientation == TreeOrientation.RightToLeft)
                {
                    if (parent != null)
                    {
                        return GetPrevChild(parent, node, "left");

                    }
                    else
                        return null;
                }
                else if (Orientation == TreeOrientation.LeftToRight)
                {
                    if (parent != null)
                    {
                        return GetPrevChild(parent, node, "right");
                    }
                    else
                        return null;
                }
                else
                    return base.GetPreviousSibling(node);
            }
            else
            {
                return base.GetPreviousSibling(node);
            }
        }

        private INodeInfo GetPrevChild(INodeInfo parent, INode node, string type)
        {
            var children = parent.OutNeighbors.ToList().FindAll(c => (c as CustomNode).Type.Equals(type));
            if (children.Contains(node as CustomNode))
            {
                int index = children.IndexOf(node as CustomNode);
                if (children != null && index > 0 && index <= children.Count())
                {
                    return (children.ElementAt(index - 1) as CustomNode).Info as INodeInfo;

                }
                else
                    return null;
            }
            else
                return null;
        }

        protected override INodeInfo GetFirstChild(INode node)
        {
            if ((node as CustomNode).Type.Equals("root"))
            {
                INodeInfo parent = node.Info as INodeInfo;
                if (Orientation == TreeOrientation.RightToLeft && parent.OutNeighbors.Count() > 0)
                {
                    return parent.OutNeighbors.ToList().Find(c => (c as CustomNode).Type == "left").Info as INodeInfo;
                }
                else if (Orientation == TreeOrientation.LeftToRight && parent.OutNeighbors.Count() > 0)
                {
                    return parent.OutNeighbors.ToList().Find(c => (c as CustomNode).Type == "right").Info as INodeInfo;
                }
                else
                    return base.GetFirstChild(node);
            }
            else
            {
                return base.GetFirstChild(node);
            }
        }

        protected override INodeInfo GetLastChild(INode node)
        {
            if ((node as CustomNode).Type.Equals("root"))
            {
                INodeInfo parent = node.Info as INodeInfo;
                if (Orientation == TreeOrientation.RightToLeft && parent.OutNeighbors.Count() > 0)
                {
                    return (parent.OutNeighbors.ToList().FindAll(c => (c as CustomNode).Type == "left")).Last().Info as INodeInfo;
                }
                else if (Orientation == TreeOrientation.LeftToRight && parent.OutNeighbors.Count() > 0)
                {
                    return (parent.OutNeighbors.ToList().FindAll(c => (c as CustomNode).Type == "right")).Last().Info as INodeInfo;
                }
                else
                    return base.GetLastChild(node);
            }
            else
            {
                return base.GetLastChild(node);
            }
        }
    }


    public class CustomDiagram : SfDiagram
    {
        public MouseButtonEventHandler started { get; set; }
        public MouseButtonEventHandler complete { get; set; }
        public MouseEventHandler delta { get; set; }
        private string _type = "";
        [DataMember]
        public string LayoutType
        {
            get { return _type; }
            set { _type = value; }
        }

        protected override Node GetNodeForItemOverride(object item)
        {
            CNode n = new CNode()
            {
                HorizontalContentAlignment = HorizontalAlignment.Stretch,
                VerticalContentAlignment = VerticalAlignment.Stretch
            };
            Binding foregroundBinding = new Binding();
            foregroundBinding.Path = new PropertyPath("Content.Foreground");
            foregroundBinding.Source = n;
            n.SetBinding(ForegroundProperty, foregroundBinding);
            n.AddHandler(Node.MouseLeftButtonDownEvent, started, true);
            n.AddHandler(Node.MouseLeftButtonUpEvent, complete, true);
            n.AddHandler(Node.MouseMoveEvent, delta, true);
            n.Unloaded += n_Unloaded;
            return n;
        }

        void n_Unloaded(object sender, RoutedEventArgs e)
        {
            if (started != null && complete != null && delta != null)
            {
                (sender as Node).RemoveHandler(Node.MouseLeftButtonDownEvent, started);
                (sender as Node).RemoveHandler(Node.MouseLeftButtonUpEvent, complete);
                (sender as Node).RemoveHandler(Node.MouseMoveEvent, delta);


            }
            (sender as Node).Unloaded -= n_Unloaded;
        }
    }
}
