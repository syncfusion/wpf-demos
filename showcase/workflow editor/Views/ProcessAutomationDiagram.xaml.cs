#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.diagrambackstage.wpf;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Syncfusion.UI.Xaml.Diagram.Layout;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media;
using Syncfusion.UI.Xaml.Diagram.Utility;
using SPath = System.Windows.Shapes.Path;
using System.Windows;
using Syncfusion.Windows.Controls.Notification;
using System.Windows.Media.Animation;
using Syncfusion.Windows.Controls.Navigation;
using System.Windows.Shapes;
using System.Windows.Markup;
using Syncfusion.Windows.Shared;
//The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace syncfusion.workfloweditor.wpf
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProcessAutomationDiagram : UserControl
    {

        ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/Syncfusion.workfloweditor.wpf;component/Template/ProcessNodeEditorTemplate.xaml", UriKind.RelativeOrAbsolute)
        };

        #region Variables
        IScrollInfo sv = null;
        Point TapPosition = new Point();
        ObservableCollection<ProcessAutomationNode> nodescollection = null;
        ObservableCollection<Node> animationNodes = null;
        List<ProcessAutomationNode> checknode = null;
        ObservableCollection<ProcessAutomationConnector> outcheck = null;
        Random r = new Random();
        ProcessAutomationNode PreviousSelectedNode = null;
        ObservableCollection<ProcessAutomationNode> intersectednodes = new ObservableCollection<ProcessAutomationNode>(); 
        #endregion

        public ProcessAutomationDiagram()
        {
            this.InitializeComponent();
            InitializeDiagram();
        }

        private void InitializeDiagram()
        {
            IGraphInfo graphInfo = sfdiagram.Info as IGraphInfo;
            //Decide Connetor Type
            sfdiagram.DefaultConnectorType = ConnectorType.Line;

            //Style for Selector
            sfdiagram.SFSelector.Style = this.Resources["selector"] as Style;
            //SnapConstraints
           sfdiagram.SnapSettings.SnapConstraints = SnapConstraints.All;
            //To tell type to Serializer
            sfdiagram.KnownTypes = () => new List<Type>()
                {
                    typeof(NodeContent)
                };
            //PageCustomization Properties
            sfdiagram.PageSettings = null;
            //Menu for SfDiagram
            sfdiagram.Menu = null;
            //Event to notify the Selection on Node/Connetcor
            graphInfo.ItemSelectedEvent += sfdiagram_ItemSelectedEvent;
            //Event to notify Click or Tap on Node/Connetcor
            graphInfo.ItemTappedEvent += sfdiagram_ItemTappedEvent;
            //Event to notify the Changes in TargetNode/Point/Port of Connector
            graphInfo.ConnectorTargetChangedEvent += sfdiagram_ConnectorTargetChangedEvent;
            //Event to notify Changes in Collection
            graphInfo.ItemAdded += graphInfo_ItemAdded;

            //Event for Diagram
            sfdiagram.MouseDown += sfdiagram_Tapped;
            this.Unloaded += ProcessAutomationDiagram_Unloaded;

            (sfdiagram.SelectedItems as SelectorViewModel).Commands = new QuickCommandCollection();

            ((sfdiagram.SelectedItems as SelectorViewModel).Commands as QuickCommandCollection).Add(new QuickCommandViewModel()
            {
                Margin = new Thickness(40, 0, 0, 0),
                OffsetX = 1,
                OffsetY = 0.5,
                //Content = "F1M423.144,677.5312L423.144,671.2692L410.147,671.2692L410.147,666.4982L423.144,666.4982L423.144,661.0822L431.368,669.3062z",
                ContentTemplate = this.Resources["drawQucikCommandTemplate"] as DataTemplate,
                Command = graphInfo.Commands.Draw,
                DragCommand = graphInfo.Commands.Draw,
                Shape = "F1M23.467,11.733C23.467,18.213 18.214,23.466 11.734,23.466 5.253,23.466 0,18.213 0,11.733 0,5.253 5.253,0 11.734,0 18.214,0 23.467,5.253 23.467,11.733",
                //ShapeStyle = GetQuickCommandShapeStyle(),
                CommandParameter = new DrawParameter(DrawingTool.Connector, null, null, null, null, NullSourceTarget.SelectionAsSource | NullSourceTarget.CloneSourceAsTarget),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                VisibilityMode = VisibilityMode.Node,
            });


            ((sfdiagram.SelectedItems as SelectorViewModel).Commands as QuickCommandCollection).Add(new QuickCommandViewModel()
            {
                Margin = new Thickness(0, -38, 0, 0),
                OffsetX = 0.5,
                OffsetY = 0,
                //Content = "F1M423.144,677.5312L423.144,671.2692L410.147,671.2692L410.147,666.4982L423.144,666.4982L423.144,661.0822L431.368,669.3062z",
                ContentTemplate = this.Resources["editQuickCommand"] as DataTemplate,
                //Command = graphInfo.Commands.Draw,
                //DragCommand = graphInfo.Commands.Draw,
                Shape = "F1M23.467,11.733C23.467,18.213 18.214,23.466 11.734,23.466 5.253,23.466 0,18.213 0,11.733 0,5.253 5.253,0 11.734,0 18.214,0 23.467,5.253 23.467,11.733",
                //ShapeStyle = GetQuickCommandShapeStyle(),
                //CommandParameter = new DrawParameter(DrawingTool.Connector, null, null, null, null, NullSourceTarget.SelectionAsSource | NullSourceTarget.CloneSourceAsTarget),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                VisibilityMode = VisibilityMode.Node,
            });


        }
        public Style GetQuickCommandShapeStyle()
        {
            const string cTemplate = "<Style TargetType=\"Path\"" +
                      " xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" >" +
                      " <Setter Property=\"Fill\" Value=\"#4D4D4D\">" +
                       " </Setter>" +
                       " <Setter Property=\"StrokeThickness\" Value=\"1\">" +
                       " </Setter>" +
                       " </Style>";

            return LoadXaml(cTemplate) as Style;
        }

        public object LoadXaml(string xaml)
        {
            return XamlReader.Parse(xaml);
        }


        #region Events
        void graphInfo_ItemAdded(object sender, ItemAddedEventArgs args)
        {
            if ((sfdiagram.Nodes as DiagramCollection).Count > 0 && (sfdiagram.Connectors as DiagramCollection).Count > 0)
            {
                ProcessAutomationViewModel.IsPlay = true;
            }
            ProcessAutomationViewModel.IsItemEnabled = true;
        }

        void ProcessAutomationDiagram_Unloaded(object sender, RoutedEventArgs e)
        {
            IGraphInfo graphInfo = sfdiagram.Info as IGraphInfo;
            if (sfdiagram != null)
            {
                graphInfo.ItemTappedEvent -= sfdiagram_ItemTappedEvent;
                graphInfo.ItemSelectedEvent -= sfdiagram_ItemSelectedEvent;
                graphInfo.ConnectorTargetChangedEvent -= sfdiagram_ConnectorTargetChangedEvent;

            }
            this.Unloaded -= ProcessAutomationDiagram_Unloaded;
            foreach (INode item in (IEnumerable<object>)sfdiagram.Nodes)
            {
                NodeContent cont = item.Content as NodeContent;
                if (cont != null)
                {
                    cont.Dispose();
                }
            }
            (sfdiagram.Nodes as DiagramCollection).Clear();
            (sfdiagram.Connectors as DiagramCollection).Clear();
            sfdiagram.Nodes = null;
            sfdiagram.Connectors = null;
            graphInfo = null;
            sfdiagram = null;
            DataContext = null;
            this.ProcessAutomationViewModel = null;
            foreach (SfRadialMenuItem item in radialMenu.Items)
            {
                if (item != null)
                {
                    item.Click -= SfRadialMenuItem_Click_1;
                    Button but = item.Header as Button;
                    if (but != null)
                    {
                        but.Click -= Button_Click_2;
                    }
                }
            }
            radialMenu.Items.Clear();
        }

        void sfdiagram_ItemTappedEvent(object sender, DiagramEventArgs args)
        {
            if (args.Item is IConnector)
            {
                (sfdiagram.SelectedItems as CustomSelector).SelectedObject = args.Item as ProcessAutomationConnector;
                ProcessAutomationViewModel.SelectedObject = args.Item as ProcessAutomationConnector;
            }
            else if (args.Item is INode)
            {
                if (PreviousSelectedNode != null)
                {
                    UpdatePreviousSelection(PreviousSelectedNode);
                }
                (sfdiagram.SelectedItems as CustomSelector).SelectedObject = args.Item as ProcessAutomationNode;
                PreviousSelectedNode = (args.Item as ProcessAutomationNode);
                ProcessAutomationViewModel.SelectedObject = args.Item as ProcessAutomationNode;
            }
        }

        void sfdiagram_ItemSelectedEvent(object sender, DiagramEventArgs args)
        {
            if (args.Item is IConnector)
            {
                (sfdiagram.SelectedItems as CustomSelector).SelectedObject = args.Item as ProcessAutomationConnector;

            }
            else if (args.Item is INode)
            {
                (sfdiagram.SelectedItems as CustomSelector).SelectedObject = args.Item as ProcessAutomationNode;
                ProcessAutomationViewModel.SelectedObject = args.Item as ProcessAutomationNode;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ClearSelection();
            Button sf = (sender as Button);
            switch (sf.Name)
            {
                case "Starts":
                    CreateStartNode(35, 35, "Ellipse", "Start");
                    break;
                case "Tasks":
                    CreateStartNode(50, 50, "Rectangle", "Task1");
                    break;
                case "Ends":
                    CreateStartNode(35, 35, "Ellipse", "End");
                    break;
                case "Decisions":
                    CreateStartNode(75, 75, "Decision", "Decision");
                    break;
            }
            if ((sfdiagram.Nodes as DiagramCollection).Count > 0 && (sfdiagram.Connectors as DiagramCollection).Count > 0)
            {
                ProcessAutomationViewModel.IsPlay = true;
            }

            HideRadialMenu();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (((sender as Button).Parent as Viewbox).Parent is SelectorItem)
            {
               
            }

            OnSave1(null);
        }

        private void Grid_Unloaded_1(object sender, RoutedEventArgs e)
        {
            //Grid send = sender as Grid;
            //send.Unloaded -= Grid_Unloaded_1;
            //send.MouseEnter -= Grid_MouseEnter;
            //send.MouseLeave -= Grid_MouseLeave;
            //send.MouseLeftButtonDown -= Grid_MouseLeftButtonDown;
            //send.MouseLeftButtonUp -= Grid_MouseLeftButtonUp;
        }

        private void Button_Unload_3(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;
            if (but != null)
            {
                but.Unloaded -= Button_Unload_3;
                but.Click -= Button_Click_3;
            }
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            (sfdiagram.SelectedItems as CustomSelector).fillbrush = new SolidColorBrush(Colors.LightGray);
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            (sfdiagram.SelectedItems as CustomSelector).fillbrush = new SolidColorBrush(Colors.White);
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            (sfdiagram.SelectedItems as CustomSelector).fillbrush = new SolidColorBrush(Colors.Black);
        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            (sfdiagram.SelectedItems as CustomSelector).fillbrush = new SolidColorBrush(Colors.White);
        }

        void sfdiagram_ConnectorTargetChangedEvent(object sender, ChangeEventArgs<object, ConnectorChangedEventArgs> args)
        {
            if (args.NewValue.DragState == DragState.Completed)
            {
                UpdatePreviousSelection((args.Item as ProcessAutomationConnector).SourceNode as ProcessAutomationNode);
                if (args.NewValue.Node == null)
                {
                    (args.Item as ProcessAutomationConnector).SourceNode = null;
                    (args.Item as ProcessAutomationConnector).TargetNode = null;
                    (sfdiagram.Connectors as DiagramCollection).Remove(args.Item as ProcessAutomationConnector);
                }

                foreach (Node n in sfdiagram.Page.Children.OfType<Node>())
                {
                    foreach (ProcessAutomationNode o in intersectednodes)
                    {
                        if (n.DataContext == o)
                        {
                            (n.Content as NodeContent).FillBrush = new SolidColorBrush(Colors.Transparent);
                        }
                    }
                }


            }
            else if (args.NewValue.DragState == DragState.Dragging)
            {
                if (args.NewValue.Node != null)
                {
                    if (!intersectednodes.Contains((args.Item as ProcessAutomationConnector).TargetNode as ProcessAutomationNode))
                    {
                        intersectednodes.Add((args.Item as ProcessAutomationConnector).TargetNode as ProcessAutomationNode);
                    }
                    foreach (Node n in sfdiagram.Page.Children.OfType<Node>())
                    {
                        if (n.DataContext == (args.Item as ProcessAutomationConnector).TargetNode)
                        {
                            (n.Content as NodeContent).FillBrush = new SolidColorBrush(Colors.Black);
                        }
                    }
                }
                else
                {
                    foreach (Node n in sfdiagram.Page.Children.OfType<Node>())
                    {
                        foreach (ProcessAutomationNode o in intersectednodes)
                        {
                            if (n.DataContext == o)
                            {
                                (n.Content as NodeContent).FillBrush = new SolidColorBrush(Colors.Transparent);
                            }
                        }
                    }
                }

            }
            (sfdiagram.SelectedItems as CustomSelector).fillbrush = new SolidColorBrush(Colors.White);
        }

        void n_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as Control).Loaded -= n_Loaded;
            Ellipse e1 = (sender as Node).FindName("start") as Ellipse;
        }

        private void SfRadialMenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ClearSelection();
        }

        void sfdiagram_Tapped(object sender, MouseButtonEventArgs e)
        {

            VisualTreeHelper.HitTest(this,
                                    e1 => HitTestFilterBehavior.Continue,
                                    e1 =>
                                    {
                                        DependencyObject item = e1.VisualHit.FindVisualParent<Node>();
                                        if (item != null)
                                        {
                                            ProcessAutomationViewModel.SelectedObject = (item as Node).DataContext as ProcessAutomationNode;
                                            if ((item as Node).DataContext != null &&
                                                ((item as Node).DataContext as ProcessAutomationNode) != null &&
                                                (((item as Node).DataContext as ProcessAutomationNode).Content as NodeContent).IsTask)
                                                ShowContextMenu();

                                            HideRadialMenu();
                                            return HitTestResultBehavior.Stop;
                                        }
                                        if (item == null)
                                        {
                                            item = e1.VisualHit.FindVisualParent<Connector>();
                                            if (item != null)
                                            {
                                                HideContextMenu();
                                                HideRadialMenu();
                                                HideEditors();
                                                return HitTestResultBehavior.Stop;
                                            }

                                        }
                                        if (item == null)
                                        {
                                            item = e1.VisualHit.FindVisualParent<SfDiagram>();
                                            if (item != null)
                                            {
                                                ClearSelection();
                                                ShowRadailMenu(e.GetPosition(this));
                                                TapPosition = e.GetPosition(this);
                                                HideEditors();
                                                HideContextMenu();

                                                return HitTestResultBehavior.Stop;
                                            }

                                        }

                                        return HitTestResultBehavior.Continue;
                                    },
                                    new PointHitTestParameters(e.GetPosition(this))
               );

            foreach (ProcessAutomationNode nodes in ((IEnumerable<object>)sfdiagram.Nodes).OfType<ProcessAutomationNode>())
            {
                if ((nodes.Content as NodeContent).DispalyText == "Start")
                {
                    Start.Opacity = 0.40;
                    Starts.IsEnabled = false;
                }
                else if ((nodes.Content as NodeContent).DispalyText == "End")
                {
                    End.Opacity = 0.40;
                    Ends.IsEnabled = false;
                }
            }

            if (((IEnumerable<object>)sfdiagram.Nodes).OfType<ProcessAutomationNode>().Count() == 0)
            {
                Start.Opacity = 1;
                End.Opacity = 1;
                Starts.IsEnabled = true;
                Ends.IsEnabled = true;
            }


        }

        private void Back_Clicked(object sender, RoutedEventArgs e)
        {
            //this.GetParent<syncfusion.workfloweditor.wpf.MainPage>().BottomAppBar.IsSticky = false;
            //this.GetParent<syncfusion.workfloweditor.wpf.MainPage>().BottomAppBar.IsOpen = false;
            this.ProcessAutomationViewModel.Back.Execute(null);
        }
        #endregion

        #region Property

        public ProcessAutomationViewModel ProcessAutomationViewModel
        {
            get { return (ProcessAutomationViewModel)GetValue(ProcessAutomationViewModelProperty); }
            set { SetValue(ProcessAutomationViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChartViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProcessAutomationViewModelProperty =
            DependencyProperty.Register("ProcessAutomationViewModel", typeof(ProcessAutomationViewModel), typeof(ProcessAutomationDiagram), new PropertyMetadata(null, OnPropertyChangedCallBack));

        private static void OnPropertyChangedCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ProcessAutomationDiagram p = d as ProcessAutomationDiagram;
            if (e.OldValue != null)
            {
                ProcessAutomationViewModel vm = e.OldValue as ProcessAutomationViewModel;
                vm.Save = null;
                vm.Load = null;
                vm.Create = null;
                vm.Back = null;
                vm.Play = null;
                vm.Delete = null;
                vm.Clear = null;
                vm.IsItemEnabled = false;
            }
            if (e.NewValue == null)
            {
                return;
            }
            p.ProcessAutomationViewModel = e.NewValue as ProcessAutomationViewModel;
            p.ProcessAutomationViewModel.Save = new DelegateCommand<object>(p.OnSave, args => { return true; });
            p.ProcessAutomationViewModel.Load = new DelegateCommand<object>(p.OnLoad, args => { return true; });
            p.ProcessAutomationViewModel.Create = new DelegateCommand<object>(p.OnCreate, args => { return true; });
            p.ProcessAutomationViewModel.Back = new DelegateCommand<object>(p.OnBack, args => { return true; });
            p.ProcessAutomationViewModel.Play = new DelegateCommand<object>(p.OnPlay, args => { return true; });
            p.ProcessAutomationViewModel.Delete = new DelegateCommand<object>(p.OnDelete, args => { return true; });
            p.ProcessAutomationViewModel.Clear = new DelegateCommand<object>(p.OnClear, args => { return true; });
            p.ProcessAutomationViewModel.IsItemEnabled = true;
        } 
        #endregion

        #region HelperMethods
        private void UpdatePreviousSelection(ProcessAutomationNode processAutomationNode)
        {
            foreach (Node node in sfdiagram.Page.Children.OfType<Node>())
            {
                if (node.DataContext == processAutomationNode)
                {
                    (node.Content as NodeContent).BorderBrush = new SolidColorBrush(Colors.Transparent);
                    (node.Content as NodeContent).BorderThick = new Thickness(0);
                }
            }
        }

        private SolidColorBrush ColorConverter(string hexaColor)
        {
            if (hexaColor != null)
            {
                byte r = Convert.ToByte(hexaColor.Substring(1, 2), 16);
                byte g = Convert.ToByte(hexaColor.Substring(3, 2), 16);
                byte b = Convert.ToByte(hexaColor.Substring(5, 2), 16);
                byte a = Convert.ToByte(hexaColor.Substring(7, 2), 16);
                SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(r, g, b, a));
                return myBrush;
            }
            return null;
        }

        private Style GetNodeStyle()
        {
            //string stroke=
            Style s = new Style(typeof(SPath));
            s.Setters.Add(new Setter(SPath.FillProperty, ColorHelper.GetColorFromHexa("#70C923")));
            //s.Setters.Add(new Setter(SPath.StrokeProperty, new SolidColorBrush(Colors.Black)));
            s.Setters.Add(new Setter(SPath.StrokeThicknessProperty, 3d));
            //s.Setters.Add(new Setter(SPath.DataProperty, "M41.58,0 L52.2686,10.6886 L41.58,21.3773 L41.58,13.8557 L6.49995,13.8557 L6.49995,7.85574 L41.58,7.85574 z"));
            s.Setters.Add(new Setter(SPath.StretchProperty, Stretch.Fill));
            return s;
        }

        private void ClearSelection()
        {
            if (sfdiagram.SelectedItems != null)
            {
                CustomSelector selector = sfdiagram.SelectedItems as CustomSelector;
                if (selector.SelectedObject != null)
                {
                    if (selector.SelectedObject is ProcessAutomationNode)
                    {
                        (selector.SelectedObject as ProcessAutomationNode).IsSelected = false;
                    }
                    else if (selector.SelectedObject != null)
                    {
                        (selector.SelectedObject as ProcessAutomationConnector).IsSelected = false;
                    }
                }
            }
        }

        private void ShowRadailMenu(Point position)
        {
            radialMenu.Visibility = Visibility.Visible;
            //radialMenu.IsOpen = false;
            //radialMenu.UpdateLayout();
            radialMenu.Focus();
            //radialMenu.IsOpen = true;

            Point tap = sfdiagram.Page.TransformToVisual(sfdiagram.Page).Transform(position);
            double x = tap.X - radialMenu.RadiusX;
            double y = tap.Y - radialMenu.RadiusY;
            x = Math.Min(Math.Max(0, x), ActualWidth - radialMenu.RadiusX * 2);
            y = Math.Min(Math.Max(0, y), ActualHeight - radialMenu.RadiusY * 2);
            radialMenu.RenderTransform = new TranslateTransform() { X = x, Y = y };
            radialMenu.Focus();
        }

        private void OnClear(object obj)
        {
            (sfdiagram.Nodes as DiagramCollection).Clear();
            (sfdiagram.Connectors as DiagramCollection).Clear();
            if ((sfdiagram.Nodes as DiagramCollection).Count == 0 &&
                (sfdiagram.Connectors as DiagramCollection).Count == 0)
            {
                this.ProcessAutomationViewModel.IsItemEnabled = false;
            }

            HideContextMenu();
        }

        private void OnDelete(object obj)
        {
            if (this.ProcessAutomationViewModel.SelectedObject is ProcessAutomationNode)
            {
                ObservableCollection<ProcessAutomationConnector> outcon = new ObservableCollection<ProcessAutomationConnector>();
                ObservableCollection<ProcessAutomationConnector> incon = new ObservableCollection<ProcessAutomationConnector>();
                if (((this.ProcessAutomationViewModel.SelectedObject as ProcessAutomationNode).Info as INodeInfo).OutConnectors != null)
                {
                    foreach (ProcessAutomationConnector con in ((this.ProcessAutomationViewModel.SelectedObject as ProcessAutomationNode).Info as INodeInfo).OutConnectors)
                    {
                        outcon.Add(con);

                    }
                    foreach (ProcessAutomationConnector c in outcon)
                    {
                        (c as ProcessAutomationConnector).TargetNode = null;
                        (c as ProcessAutomationConnector).SourceNode = null;
                        (sfdiagram.Connectors as DiagramCollection).Remove(c as ProcessAutomationConnector);
                    }
                }


                if (((this.ProcessAutomationViewModel.SelectedObject as ProcessAutomationNode).Info as INodeInfo).InConnectors != null)
                {
                    foreach (ProcessAutomationConnector con in ((this.ProcessAutomationViewModel.SelectedObject as ProcessAutomationNode).Info as INodeInfo).InConnectors)
                    {
                        incon.Add(con);
                    }
                    foreach (ProcessAutomationConnector c in incon)
                    {
                        (c as ProcessAutomationConnector).TargetNode = null;
                        (c as ProcessAutomationConnector).SourceNode = null;
                        (sfdiagram.Connectors as DiagramCollection).Remove(c as ProcessAutomationConnector);
                    }
                }
                (sfdiagram.Nodes as DiagramCollection).Remove(this.ProcessAutomationViewModel.SelectedObject as ProcessAutomationNode);
            }
            else if ((sfdiagram.SelectedItems as SelectorViewModel).Connectors != null)
            {
                foreach (var con in ((IEnumerable<object>)(sfdiagram.SelectedItems as SelectorViewModel).Connectors)
                                    .OfType<ProcessAutomationConnector>().ToList())
                {
                    con.TargetNode = null;
                    con.SourceNode = null;
                    (sfdiagram.Connectors as DiagramCollection).Remove(con);
                }
            }
            HideContextMenu();
        }

        private void OnBack(object obj)
        {
            this.ProcessAutomationViewModel.DiagramVisibility = Visibility.Collapsed;
            this.ProcessAutomationViewModel.Save.Execute(null);
            HideContextMenu();
            HideRadialMenu();
        }

        private  void OnCreate(object parameter)
        {
            (sfdiagram.Nodes as DiagramCollection).Clear();
            (sfdiagram.Connectors as DiagramCollection).Clear();
            string installedlocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string pathString = System.IO.Path.Combine(installedlocation, "WorkFlow");
            string file = parameter.ToString() + ".xml";
            {
                System.IO.File.Create(file);
                this.ProcessAutomationViewModel.CurrentlyLoaded = parameter.ToString();
            }
            {
                using (FileStream fileStream = File.OpenWrite(pathString + "/" + file))
                {
                    SfDiagram empty = new SfDiagram();
                    empty.Nodes = new ObservableCollection<Node>();
                    empty.Connectors = new ObservableCollection<Connector>();
                    empty.Save(fileStream);
                }
                OnLoad(parameter);
                ProcessAutomationViewModel.DiagramVisibility = Visibility.Visible;
            }
        }

        private  void OnLoad(object param)
        {
            (sfdiagram.Nodes as DiagramCollection).Clear();
            (sfdiagram.Connectors as DiagramCollection).Clear();

            string installedlocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string pathString = System.IO.Path.Combine(installedlocation, "WorkFlow");

            if (param != null)
            {
                this.ProcessAutomationViewModel.CurrentlyLoaded = param.ToString();
                DirectoryInfo DI = new DirectoryInfo(param.ToString());

                using (FileStream fileStream = File.OpenRead(pathString + "/" + param.ToString() + ".xml"))
                {
                    sfdiagram.Load(fileStream);

                    if ((sfdiagram.Nodes as DiagramCollection).Count > 0 && (sfdiagram.Connectors as DiagramCollection).Count > 0)
                    {
                        ProcessAutomationViewModel.IsPlay = true;
                    }
                    if ((sfdiagram.Nodes as DiagramCollection).Count == 0 && (sfdiagram.Connectors as DiagramCollection).Count == 0)
                    {
                        ProcessAutomationViewModel.IsItemEnabled = false;
                    }
                    else
                    {
                        ProcessAutomationViewModel.IsItemEnabled = true;
                    }

                    DiagramCollection delete = new DiagramCollection();
                    foreach (ProcessAutomationNode node in ((IEnumerable<object>)sfdiagram.Nodes).OfType<ProcessAutomationNode>())
                    {
                        node.Constraints = node.Constraints | NodeConstraints.Draggable;
                        node.Content = new NodeContent();

                        if (node.NodeContent != null)
                        {
                            (node.Content as NodeContent).DispalyText = node.NodeContent.DispalyText;
                            (node.Content as NodeContent).Save = new DelegateCommand<object>(OnSave1, args => { return true; });
                            (node.Content as NodeContent).OpenEditor = new DelegateCommand<object>(OnOpen, args => { return true; });
                            (node.Content as NodeContent).Done = new DelegateCommand<object>(OnDone, args => { return true; });

                            if ((node.NodeContent is NodeContent) && (node.NodeContent as NodeContent).IsTask)
                            {
                                node.ContentTemplate = resourceDictionary["tasknodetemplate"] as DataTemplate;
                            }
                            else
                            {
                                if (node.NodeType == "Decision")
                                {
                                    node.ContentTemplate = resourceDictionary["decisionnodetemplate"] as DataTemplate;
                                }
                                else
                                {
                                    if ((node.Content as NodeContent).DispalyText == "Start")
                                    {
                                        node.ContentTemplate = resourceDictionary["Startnodetemplate"] as DataTemplate;
                                    }
                                    else if ((node.Content as NodeContent).DispalyText == "End")
                                    {
                                        node.ContentTemplate = resourceDictionary["Endnodetemplate"] as DataTemplate;
                                    }
                                    else
                                    {
                                        node.ContentTemplate = resourceDictionary["nodetemplate"] as DataTemplate;
                                    }
                                }
                            }
                        }
                        else
                        {
                            delete.Add(node);
                        }
                    }

                    foreach (ProcessAutomationNode n in delete)
                    {
                        (sfdiagram.Nodes as DiagramCollection).Remove(n);
                    }

                    this.ProcessAutomationViewModel.DiagramVisibility = Visibility.Visible;
                }
            }
            //CreateNodes();
        }

        private  void OnSave(object param)
        {
            string installedlocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string pathString = System.IO.Path.Combine(installedlocation, "WorkFlow");
            string file = string.Empty;
            if (param == null)
            {
                if (!string.IsNullOrEmpty(this.ProcessAutomationViewModel.CurrentlyLoaded))
                {
                    //System.IO.File.Create(pathString + "/" + this.ProcessAutomationViewModel.CurrentlyLoaded);
                    file = this.ProcessAutomationViewModel.CurrentlyLoaded;
                }
            }
            else
            {
                //System.IO.File.Create(".//PreSavedWorkFlow/" + param + ".xml");
                this.ProcessAutomationViewModel.CurrentlyLoaded = param.ToString();
                file = this.ProcessAutomationViewModel.CurrentlyLoaded;
            }

            if (!string.IsNullOrEmpty(file))
            {
                if (File.Exists(pathString + "/" + file.ToString() + ".xml"))
                {
                    File.Delete(pathString + "/" + file.ToString() + ".xml");
                }

                File.Create(pathString + "/" + file.ToString() + ".xml").Close();
                using (FileStream fileStream = File.OpenWrite(pathString + "/" + file.ToString() + ".xml"))
                {
                    sfdiagram.Save(fileStream);
                }
            }

        }

        private void ShowContextMenu()
        {
            //if (!contextmenu.IsOpen)
            //{
            //    Rect node;
            //    if (this.ProcessAutomationViewModel.SelectedObject is ProcessAutomationNode)
            //    {
            //        ProcessAutomationNode n = this.ProcessAutomationViewModel.SelectedObject as ProcessAutomationNode;
            //        node = (n.Info as INodeInfo).Bounds;
            //    }
            //    else
            //    {
            //        return;
            //    }

            //    node = sfdiagram.Page.TransformToVisual(this).TransformBounds(node);
            //    contextmenu.Visibility = Windows.UI.Xaml.Visibility.Visible;
            //    //contextmenu.IsOpen = false;
            //    contextmenu.UpdateLayout();
            //    contextmenu.Focus(Windows.UI.Xaml.FocusState.Keyboard);
            //    contextmenu.IsOpen = true;

            //    double x = node.Right + 150 - contextmenu.RadiusX;
            //    double y = node.Bottom - node.Height / 2 - contextmenu.RadiusY;
            //    x = Math.Min(Math.Max(0, x), ActualWidth - contextmenu.RadiusX * 2);
            //    y = Math.Min(Math.Max(0, y), ActualHeight - contextmenu.RadiusY * 2);
            //    contextmenu.RenderTransform = new TranslateTransform() { X = x, Y = y };
            //    contextmenu.Focus(Windows.UI.Xaml.FocusState.Keyboard);
            //}
            //else
            //{
            //    contextmenu.IsOpen = false;
            //}
        }

        private void HideRadialMenu()
        {
            radialMenu.IsOpen = false;
            radialMenu.Visibility = Visibility.Collapsed;
        }

        public void HideEditors()
        {
            {
                if (NodeContentEditor.Visibility != Visibility.Collapsed)
                {
                    (NodeContentEditor.Resources["PropertyEditor_Storyboard_Collapse"] as Storyboard).Begin();
                    NodeContentEditor.Visibility = Visibility.Collapsed;
                }

                //((NodeValueEditor.Resources["PropertyEditor_Storyboard_Collapse"] as Storyboard).GetCurrentState() == ClockState.Stopped ||
                //   (NodeValueEditor.Resources["PropertyEditor_Storyboard_Collapse"] as Storyboard).GetCurrentState() == ClockState.Filling))

                if (NodeValueEditor.Visibility != Visibility.Collapsed)
                {
                    (NodeValueEditor.Resources["PropertyEditor_Storyboard_Collapse"] as Storyboard).Begin();
                    NodeValueEditor.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void CreateStartNode(double p1, double p2, string p3, string label)
        {
            ScrollSettings scrollsettings = sfdiagram.ScrollSettings;
            double scale = scrollsettings.ScrollInfo.CurrentZoom;
            ProcessAutomationNode node = new ProcessAutomationNode()
            {
                Content = new NodeContent()
                {
                    DispalyText = label
                },
                NodeType = p3
            };

            if (label == "Task1")
            {
                (node.Content as NodeContent).IsTask = true;
                (node.Content as NodeContent).Properties.Add(new Property() { Name = "", Type = "String" });
            }

            node.IsSelected = true;
            ProcessAutomationViewModel.SelectedObject = node;
            Point position = this.TransformToVisual(sfdiagram.Page).Transform(TapPosition);
            node.OffsetX = position.X;
            node.OffsetY = position.Y;
            if ((node.Content is NodeContent) && (node.Content as NodeContent).IsTask)
            {
                node.ContentTemplate = resourceDictionary["tasknodetemplate"] as DataTemplate;
                OnOpen(null);
            }
            else
            {
                if (p3 == "Decision")
                {
                    OnOpen(null);
                    (node.Content as NodeContent).IsNotDecision = false;
                    node.UnitHeight = 50;
                    node.ContentTemplate = resourceDictionary["decisionnodetemplate"] as DataTemplate;
                    for (int i = 0; i <= 1; i++)
                    {
                        ProcessAutomationNode node1 = new ProcessAutomationNode()
                        {
                            UnitWidth = 35,
                            UnitHeight = 35,
                            ContentTemplate = resourceDictionary["nodetemplate"] as DataTemplate,
                        };


                        if (i == 0)
                        {
                            node1.OffsetX = node.OffsetX + 100;
                            node1.OffsetY = node.OffsetY;

                            node1.Content = new NodeContent()
                                {
                                    DispalyText = "Yes"
                                };
                        }
                        else if (i == 1)
                        {
                            node1.OffsetX = node.OffsetX;
                            node1.OffsetY = node.OffsetY + 100;

                            node1.Content = new NodeContent()
                                {
                                    DispalyText = "No"
                                };
                        }
                        node1.NodeContent = node1.Content as NodeContent;
                        (sfdiagram.Nodes as DiagramCollection).Add(node1);
                        ProcessAutomationConnector cvm = new ProcessAutomationConnector()
                        {
                            SourceNode = node,
                            TargetNode = node1
                        };
                        cvm.ConnectorGeometryStyle = SetDefaultStyle();
                        (sfdiagram.Connectors as DiagramCollection).Add(cvm);

                    }
                }
                else
                {
                    node.UnitWidth = p1;
                    node.UnitHeight = p2;
                    if (label == "Start")
                    {
                        node.ContentTemplate = resourceDictionary["Startnodetemplate"] as DataTemplate;
                        //ProcessAutomationViewModel.IsStartAdded = true;
                    }
                    else if (label == "End")
                    {
                        node.ContentTemplate = resourceDictionary["Endnodetemplate"] as DataTemplate;
                        //ProcessAutomationViewModel.IsEndAdded = true;
                    }

                }
            }

            node.NodeContent = node.Content as NodeContent;
            (node.Content as NodeContent).Save = new DelegateCommand<object>(OnSave1, args => { return true; });
            (node.Content as NodeContent).OpenEditor = new DelegateCommand<object>(OnOpen, args => { return true; });
            (node.Content as NodeContent).Done = new DelegateCommand<object>(OnDone, args => { return true; });
            (sfdiagram.Nodes as DiagramCollection).Add(node);

            sfdiagram.Page.InvalidateMeasure();

            foreach (Node n in sfdiagram.Page.Children.OfType<Node>())
            {
                if (n.DataContext == node)
                {
                    n.Loaded += n_Loaded;
                }
            }
        }

        private void OnDone(object obj)
        {
            HideEditors();
        }

        private void OnOpen(object obj)
        {
            NodeValueEditor.DataContext = null;
            NodeContentEditor.Visibility = Visibility.Collapsed;
            NodeValueEditor.DataContext = (ProcessAutomationViewModel.SelectedObject as ProcessAutomationNode).Content;
            NodeValueEditor.Visibility = Visibility.Visible;
            (NodeValueEditor.Resources["PropertyEditor_Storyboard_Visible"] as Storyboard).Begin();
        }

        private void OnSave1(object obj)
        {
            NodeContentEditor.DataContext = null;
            NodeValueEditor.Visibility = Visibility.Collapsed;
            NodeContentEditor.DataContext = (ProcessAutomationViewModel.SelectedObject as ProcessAutomationNode).Content;
            NodeContentEditor.Visibility = Visibility.Visible;
            (NodeContentEditor.Resources["PropertyEditor_Storyboard_Visible"] as Storyboard).Begin();
        }

        private void HideContextMenu()
        {
            //contextmenu.Visibility = Visibility.Collapsed;
        }

        private void OnPlay(object obj)
        {
            ProcessAutomationViewModel.IsPlay = false;
            outcheck = new ObservableCollection<ProcessAutomationConnector>();
            foreach (ProcessAutomationConnector con in ((IEnumerable<object>)sfdiagram.Connectors).OfType<ProcessAutomationConnector>())
            {
                con.ConnectorGeometryStyle = SetDefaultStyle();
                con.IsAnimationApplied = false;
            }

            ObservableCollection<Node> nodes = new ObservableCollection<Node>();

            foreach (Node n in ((IEnumerable<object>)sfdiagram.Nodes).OfType<Node>())
            {
                nodes.Add(n);
            }

            foreach (Node n1 in nodes)
            {
                (sfdiagram.Nodes as DiagramCollection).Remove(n1);
            }
            nodescollection = new ObservableCollection<ProcessAutomationNode>();
            animationNodes = new ObservableCollection<Node>();
            foreach (ProcessAutomationNode node1 in ((IEnumerable<object>)sfdiagram.Nodes).OfType<ProcessAutomationNode>())
            {
                node1.Constraints = node1.Constraints & ~NodeConstraints.Draggable;
                nodescollection.Add(node1);
            }

            foreach (ProcessAutomationNode aninode in nodescollection)
            {
                if ((aninode.Content as NodeContent).DispalyText == "Start")
                {
                    if ((aninode.Info as INodeInfo).OutConnectors != null)
                        ApplyAnimation(aninode);
                }
            }
        } 
        #endregion

        #region Animation
        private void ApplyAnimation(ProcessAutomationNode node)
        {
            if (sfdiagram != null)
            {
                ScrollSettings scrollsettings = sfdiagram.ScrollSettings;
                sv = scrollsettings.ScrollInfo;
                if ((node.Info as INodeInfo).OutConnectors != null)
                {
                    IConnector dec = null;
                    if ((node.Info as INodeInfo).OutConnectors.Count() > 1)
                    {
                        if (r.Next(0, 100) > 50)
                        {
                            //if (node.NodeType == "Decision")
                            //{

                            //}
                            //else
                            //{
                            dec = ((node.Info as INodeInfo).OutConnectors.ToList())[0];
                            //}
                        }
                        else
                        {
                            dec = ((node.Info as INodeInfo).OutConnectors.ToList())[1];
                        }
                    }


                    foreach (ProcessAutomationConnector con in (node.Info as INodeInfo).OutConnectors)
                    {
                        if (con.TargetNode != null)
                        {
                            ProcessAutomationNode checknode = (con.TargetNode as ProcessAutomationNode);
                            //if (!sfdiagram.Viewport.Contains(new Point(checknode.OffsetX , checknode.OffsetY )))
                            {
                                if (sv != null)
                                {
                                    (sv as Syncfusion.UI.Xaml.Diagram.Controls.ScrollViewer).BringIntoViewport((checknode.Info as INodeInfo).Bounds);
                                }
                            }
                        }
                        Node animation = null;
                        if (node.NodeType == "Decision")
                        {
                            foreach (ProcessAutomationConnector c in (node.Info as INodeInfo).OutConnectors)
                            {
                                //if (((c.TargetNode as ProcessAutomationNode).Content as NodeContent).DispalyText == "New issue")
                                //{
                                //    dec = c;
                                //}
                                //else if (((c.TargetNode as ProcessAutomationNode).Content as NodeContent).DispalyText == "Yes")
                                //{
                                //    dec = c;
                                //}
                                //else
                                //{
                                //    c.UseforDecisionAnimation = true;
                                //}

                                if (!c.UseforDecisionAnimation)
                                {
                                    dec = c;
                                }
                            }
                            if (con == dec)
                            {
                                if (!con.UseforDecisionAnimation)
                                {
                                    animation = AddNode();
                                }
                            }
                        }
                        else
                        {
                            animation = AddNode();
                        }

                        if (animation != null)
                        {
                            animation.OffsetX = con.SourcePoint.X - (animation.UnitWidth / 2);
                            animation.OffsetY = con.SourcePoint.Y - (animation.UnitHeight / 2);


                            double xDiff = animation.OffsetX - (con.TargetPoint.X - (animation.UnitWidth / 2));
                            double yDiff = animation.OffsetY - (con.TargetPoint.Y - (animation.UnitHeight / 2));
                            double angle = Math.Atan2(yDiff, xDiff) * (180 / Math.PI);
                            TranslateTransform tt = ((animation.RenderTransform as TransformGroup).Children[2] as TranslateTransform);
                            RotateTransform rt = ((animation.RenderTransform as TransformGroup).Children[1] as RotateTransform);

                            DoubleAnimation x = new DoubleAnimation();
                            x.From = con.SourcePoint.X - (animation.UnitWidth / 2);
                            x.To = con.TargetPoint.X - (animation.UnitWidth / 2);
                            x.Duration = TimeSpan.FromSeconds(5);


                            DoubleAnimation y = new DoubleAnimation();
                            y.From = con.SourcePoint.Y - (animation.UnitHeight / 2);
                            y.To = con.TargetPoint.Y - (animation.UnitHeight / 2);
                            y.Duration = TimeSpan.FromSeconds(5);


                            con.ConnectorGeometryStyle = GetConStyle();



                            y.Completed += (sender, args) =>
                            {
                                if (sfdiagram != null)
                                {
                                //(sender as Storyboard).Stop();
                                con.ConnectorGeometryStyle = SetConStyle();
                                //if ((sender as DoubleAnimation).GetCurrentValue() == ClockState.Stopped)
                                {
                                        con.IsAnimationApplied = true;
                                        (((IEnumerable<object>)sfdiagram.Nodes) as DiagramCollection).Remove(animation);
                                        ObservableCollection<ProcessAutomationConnector> check = new ObservableCollection<ProcessAutomationConnector>();
                                        if (con.TargetNode != null && ((con.TargetNode as ProcessAutomationNode).Info as INodeInfo).InConnectors != null && ((con.TargetNode as ProcessAutomationNode).Info as INodeInfo).InConnectors.Count() > 1)
                                        {
                                        //if (!con.IsAnimationApplied)
                                        //{
                                        //checknode = null;
                                        foreach (ProcessAutomationConnector v in
                                                    ((con.TargetNode as ProcessAutomationNode).Info as INodeInfo).InConnectors)
                                            {
                                                if (v.SourceNode != null && ((v.SourceNode as ProcessAutomationNode).Content as NodeContent).DispalyText != "No")
                                                {
                                                    checknode = new List<ProcessAutomationNode>();
                                                    outcheck = new ObservableCollection<ProcessAutomationConnector>();
                                                    if (CheckforCycleInConnectors(v.SourceNode as ProcessAutomationNode))
                                                    {
                                                        check.Add(con);
                                                    }
                                                }

                                            }
                                        //if (outcheck != null && outcheck.Count > 0)
                                        //    {
                                        //        foreach (ProcessAutomationConnector c in outcheck)
                                        //        {
                                        //            //c.IsAnimationApplied = true;
                                        //            check.Add(c);
                                        //        }
                                        //    }

                                        //}
                                        foreach (ProcessAutomationConnector checkline in ((con.TargetNode as ProcessAutomationNode).Info as INodeInfo).InConnectors)
                                            {
                                                if (checkline.IsAnimationApplied)
                                                {
                                                    check.Add(checkline);
                                                }
                                                if (check.Count == ((con.TargetNode as ProcessAutomationNode).Info as INodeInfo).InConnectors.OfType<ProcessAutomationConnector>().Count())
                                                {
                                                    if (checkline.IsAnimationApplied)
                                                        ApplyWaitingAnimation((con.TargetNode as ProcessAutomationNode));
                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (con.IsAnimationApplied)
                                                ApplyWaitingAnimation((con.TargetNode as ProcessAutomationNode));
                                        }

                                    }
                                }

                            };

                            tt.BeginAnimation(TranslateTransform.YProperty, y);
                            tt.BeginAnimation(TranslateTransform.XProperty, x);
                        }
                    }

                    ObservableCollection<Node> watingnodes = new ObservableCollection<Node>();
                    if ((node.Content as NodeContent).DispalyText == "End")
                    {
                        foreach (Node n in ((IEnumerable<object>)sfdiagram.Nodes).OfType<Node>())
                        {
                            watingnodes.Remove(n);
                        }

                        foreach (Node n1 in watingnodes)
                        {
                            (sfdiagram.Nodes as DiagramCollection).Remove(n1);
                        }

                        foreach (ProcessAutomationNode con in ((IEnumerable<object>)sfdiagram.Nodes).OfType<ProcessAutomationNode>())
                        {
                            con.Constraints = con.Constraints | NodeConstraints.Draggable;
                        }

                        ProcessAutomationViewModel.IsPlay = true;
                    }

                }
            }
        }

        private bool CheckforCycleInConnectors(ProcessAutomationNode processAutomationNode)
        {
            if (processAutomationNode != null)
            {
                checknode.Add(processAutomationNode);
                if (((processAutomationNode).Info as INodeInfo).InConnectors != null)
                {
                    foreach (ProcessAutomationConnector con in ((processAutomationNode).Info as INodeInfo).InConnectors)
                    {
                        if (checknode.Contains(con.SourceNode as ProcessAutomationNode))
                        {
                            return true;
                        }
                        else
                        {
                            if (CheckforCycleInConnectors((con.SourceNode as ProcessAutomationNode)))
                            {
                                return true;
                            }
                        }
                    }
                    checknode.Remove(processAutomationNode);
                }
            }
            return false;
        }

        private async void ApplyWaitingAnimation(ProcessAutomationNode processAutomationNode)
        {
            for (int i = 0; i < sfdiagram.Page.Children.OfType<Node>().Count(); i++)
            {
                Node n = sfdiagram.Page.Children.OfType<Node>().ToList()[i] as Node;
                if (n.DataContext == processAutomationNode)
                {
                    Node node = AddWatingNode();
                    node.OffsetX = processAutomationNode.OffsetX + (processAutomationNode.Info as INodeInfo).Bounds.Width / 2;
                    node.OffsetY = processAutomationNode.OffsetY - ((processAutomationNode.Info as INodeInfo).Bounds.Height / 2) - 20;
                    Storyboard sb = new Storyboard();
                    ColorAnimationUsingKeyFrames ca = new ColorAnimationUsingKeyFrames();
                    EasingColorKeyFrame ca1 = new EasingColorKeyFrame()
                    {
                        KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0)),
                        Value = new SolidColorBrush(Colors.DeepSkyBlue).Color
                    };

                    EasingColorKeyFrame ca2 = new EasingColorKeyFrame()
                    {
                        KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 1, 7)),
                        Value = ColorConverter("#FF5CE02A").Color
                    };
                    EasingColorKeyFrame ca3 = new EasingColorKeyFrame()
                       {
                           KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 2, 7)),
                           Value = new SolidColorBrush(Colors.DeepSkyBlue).Color
                       };

                    ca.KeyFrames.Add(ca1);
                    ca.KeyFrames.Add(ca2);
                    ca.KeyFrames.Add(ca3);
                    sb.Children.Add(ca);
                    await WaitAnimation(processAutomationNode, node);
                }
            }
        }

        private async System.Threading.Tasks.Task WaitAnimation(ProcessAutomationNode processAutomationNode, Node node)
        {

            await System.Threading.Tasks.Task.Delay(new TimeSpan(0, 0, 0, 4, 4));
            node.Content = null;
            node.Constraints = node.Constraints & ~NodeConstraints.Draggable;
            node.Content = CreatePath(node);
            ApplyAnimation(processAutomationNode);
        }

        private object CreatePath(Node node)
        {
            SPath path = new SPath();
            path.Stroke = new SolidColorBrush(Colors.White);
            path.StrokeThickness = 2d;
            path.Data = Geometry.Parse("F1M368.6064,37.5254L366.0004,35.3794L366.6354,34.6074L368.4964,36.1384L372.4714,31.6374L373.2214,32.2994z");
            node.Shape = Geometry.Parse("M305.772,123.75C305.772,191.819095416645,237.434535075173,247,153.136,247C68.837464924827,247,0.5,191.819095416645,0.5,123.75C0.5,55.6809045833547,68.837464924827,0.5,153.136,0.5C237.434535075173,0.5,305.772,55.6809045833547,305.772,123.75z");
            node.ShapeStyle = ApplyStyle();
            path.Stretch = Stretch.Fill;
            path.MaxHeight = 10;
            path.MaxWidth = 10;
            path.Width = 10;
            path.Height = 15;
            return path;
        }

        private Style ApplyStyle()
        {
            Style s = new Style(typeof(SPath));
            s.Setters.Add(new Setter(SPath.FillProperty, new SolidColorBrush(Colors.Green)));
            //s.Setters.Add(new Setter(SPath.StrokeThicknessProperty, 2d));
            //s.Setters.Add(new Setter(SPath.DataProperty, "M305.772,123.75C305.772,191.819095416645,237.434535075173,247,153.136,247C68.837464924827,247,0.5,191.819095416645,0.5,123.75C0.5,55.6809045833547,68.837464924827,0.5,153.136,0.5C237.434535075173,0.5,305.772,55.6809045833547,305.772,123.75z"));
            s.Setters.Add(new Setter(SPath.StretchProperty, Stretch.Fill));
            return s;
        }

        private Node AddWatingNode()
        {
            Node node = new Node()
            {
                UnitWidth = 20,
                UnitHeight = 20,

            };

            //node.Content = new TextBlock() { Text = "sdfdsfdsfsdf", Foreground = new SolidColorBrush(Colors.Red) };
            SfBusyIndicator busyIndicator = new SfBusyIndicator();
            busyIndicator.ViewboxWidth = 20;
            busyIndicator.ViewboxHeight = 20;
            busyIndicator.Foreground = new SolidColorBrush(Colors.DeepSkyBlue);
            busyIndicator.AnimationType = Syncfusion.Windows.Controls.Notification.AnimationTypes.Rotation;
            node.Content = busyIndicator;
            //node.ShapeStyle = GetNodeStyle2();
            (sfdiagram.Nodes as DiagramCollection).Add(node);
            return node;
        }

        private Style GetConStyle()
        {
            Style s = new Style(typeof(SPath));
            s.Setters.Add(new Setter(SPath.StrokeProperty, ColorConverter("#FEDAE324")));
            s.Setters.Add(new Setter(SPath.StrokeThicknessProperty, 1d));
            return s;
        }

        private Style SetDefaultStyle()
        {
            Style s = new Style(typeof(SPath));
            s.Setters.Add(new Setter(SPath.StrokeProperty, new SolidColorBrush(Colors.Black)));
            s.Setters.Add(new Setter(SPath.StrokeThicknessProperty, 1d));
            return s;
        }

        private Style SetConStyle()
        {
            Style s = new Style(typeof(SPath));
            s.Setters.Add(new Setter(SPath.StrokeProperty, ColorConverter("#FF1DBB32")));
            s.Setters.Add(new Setter(SPath.StrokeThicknessProperty, 1d));
            return s;
        }

        private Node AddNode()
        {
            string ellipse = "M305.772,123.75C305.772,191.819095416645,237.434535075173,247,153.136,247C68.837464924827,247,0.5,191.819095416645,0.5,123.75C0.5,55.6809045833547,68.837464924827,0.5,153.136,0.5C237.434535075173,0.5,305.772,55.6809045833547,305.772,123.75z";
            Node node = new Node()
            {
                UnitWidth = 10,
                UnitHeight = 10,
                Shape = Geometry.Parse(ellipse)

            };


            //TranslateTransform _mXY = new TranslateTransform();
            //ScaleTransform _mScale = new ScaleTransform();
            //RotateTransform _mrotate = new RotateTransform();

            //TransformGroup g = new TransformGroup();
            //g.Children = new TransformCollection();
            //g.Children.Add(_mScale);
            //g.Children.Add(_mrotate);
            //g.Children.Add(_mXY);



            //node.RenderTransform = g;
            node.RenderTransformOrigin = new Point(0.5, 0.5);
            node.ZIndex = 0;
            node.ShapeStyle = GetNodeStyle();
            (sfdiagram.Nodes as DiagramCollection).Add(node);
            return node;
        } 
        #endregion
    }

    public static class Extension
    {
        public static T GetParent<T>(this DependencyObject child) where T : DependencyObject
        {
            DependencyObject parent = null;
            try
            {
                if (child.Dispatcher != null)
                {
                    parent = (child as FrameworkElement).Parent ?? VisualTreeHelper.GetParent(child);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            if (parent is T)
            {
                return parent as T;
            }
            else if (parent == null)
            {
                return null;
            }
            else
            {
                return parent.GetParent<T>();
            }
        }

        public static T FindChild<T>(this DependencyObject parent) where T : DependencyObject
        {
            if (parent == null)
            {
                return null;
            }

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (!(child is T))
                {
                    foundChild = FindChild<T>(child);

                    if (foundChild != null)
                        break;
                }
                else
                {
                    foundChild = (T)child;
                    break;
                }
            }
            return foundChild;
        }
    }

    public static class ColorHelper
    {
        public static SolidColorBrush GetColorFromHexa(string hexaColor)
        {
            return new SolidColorBrush(
                Color.FromArgb(
                    255, Convert.ToByte(hexaColor.Substring(1, 2), 16),
                    Convert.ToByte(hexaColor.Substring(3, 2), 16),
                    Convert.ToByte(hexaColor.Substring(5, 2), 16)
                )
            );
        }
    }

    public class SelectorItem : ContentControl
    {
        private bool isPressed = false;
        public bool DragCommand { get; set; }



        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(SelectorItem), new PropertyMetadata(null));

        public SelectorItem()
        {
            this.MouseDown += SelectorItem_MouseDown;
            this.MouseLeftButtonDown += SelectorItem_MouseLeftButtonDown;
            this.MouseLeftButtonUp += SelectorItem_MouseLeftButtonUp;
            this.MouseMove += SelectorItem_MouseMove;
            this.Unloaded += SelectorItem_Unloaded;
        }

        

        void SelectorItem_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.MouseDown -= SelectorItem_MouseDown;
            this.MouseLeftButtonDown -= SelectorItem_MouseLeftButtonDown;
            this.MouseLeftButtonUp -= SelectorItem_MouseLeftButtonUp;
            this.MouseMove -= SelectorItem_MouseMove;
            this.Unloaded -= SelectorItem_Unloaded;
        }

        void SelectorItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isPressed = false;
        }

        void SelectorItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isPressed = true;
        }

        void SelectorItem_MouseMove(object sender, MouseEventArgs e)
        {
            CustomSelector selectorViewModel = this.DataContext as CustomSelector;
            if (isPressed && e.LeftButton == MouseButtonState.Pressed)
            {
                //DrawParam param = new DrawParam(e, selectorViewModel.Nodes.FirstOrDefault(),(selectorViewModel.Nodes.FirstOrDefault() as ProcessAutomationNode).Ports.FirstOrDefault());
                DrawParameter param = new DrawParameter(DrawingTool.Connector, e, null, ((IEnumerable<object>)selectorViewModel.Nodes).FirstOrDefault(), null, NullSourceTarget.SelectionAsSource);
                if (this.Command != null)
                {
                    this.Command.Execute(param);
                }
                isPressed = false;
            }
        }

        void SelectorItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Command != null)
            {
                Command.Execute(null);
            }
        }
    }

    public static class FrameworkElementExtensions
    {
        public static FrameworkElement FindDescendantByName(this FrameworkElement element, string name)
        {
            if (element == null || string.IsNullOrWhiteSpace(name)) { return null; }

            if (name.Equals(element.Name, StringComparison.OrdinalIgnoreCase))
            {
                return element;
            }
            var childCount = VisualTreeHelper.GetChildrenCount(element);
            for (int i = 0; i < childCount; i++)
            {
                var result = (VisualTreeHelper.GetChild(element, i) as FrameworkElement).FindDescendantByName(name);
                if (result != null) { return result; }
            }
            return null;
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
