#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Animation;
using syncfusion.diagrambackstage.wpf;
using Syncfusion.Windows.Shared;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Utility;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Media;
using Syncfusion.Windows.Controls.Navigation;
using SPath = System.Windows.Shapes.Path;
using System.Windows.Controls;
using Syncfusion.Windows.Tools.Controls;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace syncfusion.floorplanner.wpf
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FloorPlannerDiagram : UserControl
    {
        #region Constructor

        private ObservableCollection<FloorPlanNode> _nodes = new ObservableCollection<FloorPlanNode>();
        private ObservableCollection<FloorPlanConnector> _connectors = new ObservableCollection<FloorPlanConnector>();
        private IGraphInfo graphInfo;
        private bool textNodeAdded = false;
        public FloorPlannerDiagram()
        {
            this.InitializeComponent();
            floorplan.Nodes = _nodes;
            floorplan.Connectors = _connectors;
            floorplan.DefaultConnectorType = ConnectorType.Line;
            graphInfo = floorplan.Info as IGraphInfo;
            Events();
            floorplan.PageSettings = null;
            floorplan.Menu = null;
            //createwallinfo();
            this.Unloaded += FloorPlannerDiagram_Unloaded;
            (floorplan.SelectedItems as SelectorViewModel).SelectorConstraints = (floorplan.SelectedItems as SelectorViewModel).SelectorConstraints & ~SelectorConstraints.QuickCommands;
        }

        private void Events()
        {
            _nodes.CollectionChanged += FloorPlannerDiagram_CollectionChanged;
            _connectors.CollectionChanged += ConnectorsChanged;
            floorplan.SnapSettings.SnapConstraints = SnapConstraints.All;
            floorplan.SnapSettings.SnapToObject = SnapToObject.All;
            floorplan.MouseLeftButtonDown += floorplan_MouseLeftButtonDown;
            floorplan.MouseLeftButtonUp += floorplan_MouseLeftButtonUp;
            //floorplan.PointerReleased += floorplan_PointerReleased;
            graphInfo.ItemAdded += graphInfo_ItemAdded;
            graphInfo.ItemSelectedEvent += floorplan_ItemSelectedEvent;
            graphInfo.ItemUnSelectedEvent += floorplan_ItemUnSelectedEvent;
            graphInfo.ConnectorSourceChangedEvent += floorplan_ConnectorSourceChangedEvent;
            graphInfo.ConnectorTargetChangedEvent += floorplan_ConnectorTargetChangedEvent;
            //floorplan.PointerMoved += floorplan_PointerMoved;
            graphInfo.MenuOpening += GraphInfo_DiagramMenuOpening;
        }

        private void GraphInfo_DiagramMenuOpening(object sender, MenuOpeningEventArgs args)
        {
            args.Cancel = true;
        }

        void FloorPlannerDiagram_Unloaded(object sender, RoutedEventArgs e)
        {
            goBackGrid.MouseLeftButtonUp -= back_clicked;
            this.Unloaded -= FloorPlannerDiagram_Unloaded;

            foreach (FloorPlanNode node in _nodes)
            {
                node.Loaded -= node_Loaded;
                node.PropertyChanged -= node_PropertyChanged;
            }

            foreach (FloorPlanConnector con in _connectors)
            {
                con.Loaded -= FloorPlannerDiagram_Loaded;
            }
            _nodes.CollectionChanged -= FloorPlannerDiagram_CollectionChanged;
            _connectors.CollectionChanged -= ConnectorsChanged;
            _nodes = null;
            _connectors = null;
            floorplan.MouseLeftButtonDown -= floorplan_MouseLeftButtonDown;
            floorplan.MouseLeftButtonUp -= floorplan_MouseLeftButtonUp;
            //floorplan.PointerReleased -= floorplan_PointerReleased;
            graphInfo.ItemSelectedEvent -= floorplan_ItemSelectedEvent;
            graphInfo.ItemUnSelectedEvent -= floorplan_ItemUnSelectedEvent;
            graphInfo.ConnectorSourceChangedEvent -= floorplan_ConnectorSourceChangedEvent;
            graphInfo.ConnectorTargetChangedEvent -= floorplan_ConnectorTargetChangedEvent;
            //floorplan.PointerMoved -= floorplan_PointerMoved;
            floorplan = null;
            graphInfo = null;
        }
        #endregion

        #region private variables
        FloorPlanConnector wallInfo = null;
        FloorPlanNode optionnode = null;
        StackPanel st;
        int enable = 0;
        Storyboard sb = new Storyboard();
        Button b;
        bool IsPickerClicked { get; set; }
        SfColorPalette c = new SfColorPalette();
        //private bool infoSizeRotate = false;
        Popup p = new Popup();
        FloorPlanNode f;

        SfRadialSlider sf = null;
        Size arrowSize = new Size(13, 23);
        private double dist = 25;
        Button StartButton;
        ToggleButton EndButton;
        Button CenterButton;
        #endregion

        #region Events

        private void graphInfo_ItemAdded(object sender, ItemAddedEventArgs args)
        {
            ResourceDictionary resourceDictionary = new ResourceDictionary()
            {
                Source = new Uri(@"/syncfusion.floorplanner.wpf;component/Template/FloorPlanDictionary.xaml", UriKind.RelativeOrAbsolute)
            };

            if (args.Item == (args.Item as FloorPlanNode))
            {
                if ((args.Item as FloorPlanNode).ContentName != null)
                    (args.Item as FloorPlanNode).ContentTemplate = resourceDictionary[(args.Item as FloorPlanNode).ContentName.ToString()] as DataTemplate;
            }
        }


        void floorplan_ConnectorTargetChangedEvent(object sender, ChangeEventArgs<object, ConnectorChangedEventArgs> args)
        {
            if (args.NewValue.DragState == DragState.Completed)
            {
                updateWallInfo(null, tail: true);
                if (!args.NewValue.Point.Equals(new Point(0, 0)))
                {
                    FloorPlanConnector con = args.Item as FloorPlanConnector;
                    if (optionnode != null)
                    {
                        UpdateOptionnode(con);
                    }
                }
            }
            else if (args.NewValue.DragState == DragState.Dragging)
            {
                updateWallInfo((args.Item as FloorPlanConnector), tail: true);
                FloorPlanConnector con = args.Item as FloorPlanConnector;
                if (optionnode != null)
                {
                    UpdateOptionnode(null);
                }
            }
        }

        void floorplan_ConnectorSourceChangedEvent(object sender, ChangeEventArgs<object, ConnectorChangedEventArgs> args)
        {
            if (args.NewValue.DragState == DragState.Completed)
            {
                if (!args.NewValue.Point.Equals(new Point(0, 0)))
                {
                    FloorPlanConnector con = args.Item as FloorPlanConnector;
                    updateWallInfo(null, head: true);
                    if (optionnode != null)
                    {
                        UpdateOptionnode(con);
                    }
                }
            }
            else if (args.NewValue.DragState == DragState.Dragging)
            {
                updateWallInfo((args.Item as FloorPlanConnector), head: true);
                FloorPlanConnector con = args.Item as FloorPlanConnector;
                if (optionnode != null)
                {
                    UpdateOptionnode(null);
                }
            }
        }



        void floorplan_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UIElement elemen = e.OriginalSource as UIElement;
            Control n = elemen.GetParent<FloorPlanNode>();
            if (n != null)
            {
                if ((n as FloorPlanNode).IsTextNode)
                {
                    ShowEditors();
                }
                else
                {
                    HideEditors();
                }
            }
            else
            {
                n = elemen.GetParent<FloorPlanConnector>();
                if (n != null)
                {
                    // st.Visibility = Visibility.Visible;
                }
                else
                {

                    n = elemen.GetParent<FloorPlanDiagram>();
                    if (n != null)
                    {
                        if (FloorPlannerViewModel.IsTextAdd)
                        {
                            foreach (FloorPlanNode node in _nodes)
                            {
                                node.IsSelected = false;
                            }

                            foreach (FloorPlanConnector con in _connectors)
                            {
                                con.IsSelected = false;
                            }
                            if (TextNode != null)
                            {
                                TextNode.IsSelected = false;
                                TextNode = null;
                            }
                            Point p= (floorplan.Info as IGraphInfo).GetCurrentPosition(e);
                            AddTextNode(p);
                        }
                        else
                        {
                            if (TextNode != null)
                            {
                                if (!(elemen is DiagramThumb) && ((TextNode.NodeAnnotations.ToArray()[0] as AnnotationEditorViewModel).Content as TextBox).Text == "Text")
                                {
                                    _nodes.Remove(TextNode);
                                }
                            }
                            n = elemen.GetParent<FloorPlanNode>();
                            if (n != null)
                            {
                                HideEditors();
                            }
                            if (f != null)
                            {
                                f.Visibility = Visibility.Collapsed;

                            }
                            //UpdateOptionnode(null);
                            if (sf != null)
                            {
                                sf.Visibility = Visibility.Collapsed;
                            }
                        }
                    }
                }
            }
        }


        private void ConnectorsChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                if (e.NewItems[0] is FloorPlanConnector)
                {
                    FloorPlanConnector newCon = (e.NewItems[0] as FloorPlanConnector);
                    if (newCon.IsWallInfo)
                    {
                        newCon.IsHitTestVisible = false;
                        newCon.ZIndex = 100000;
                        newCon.Constraints = ConnectorConstraints.None;
                    }
                    else
                    {
                        newCon.ZIndex = 1;
                        newCon.TargetDecorator = null;
                        newCon.ConnectorGeometryStyle = SetStyle();
                        newCon.Loaded += FloorPlannerDiagram_Loaded;
                    }
                }
            }
        }

        private void CreateOptionnode()
        {
            if (optionnode == null)
            {
                optionnode = new FloorPlanNode()
                {
                    UnitWidth = 275,
                    UnitHeight = 150
                };
                optionnode.OffsetY = 0;
                optionnode.OffsetX = 0;
                optionnode.ContentTemplate = this.Resources["optionnode"] as DataTemplate;
                optionnode.Constraints = NodeConstraints.None;
                optionnode.IsOption = true;
                optionnode.Loaded += optionnode_Loaded;
            }
        }

        private Style SetStyle()
        {
            Style s = new Style(typeof(SPath));
            s.Setters.Add(new Setter(SPath.StrokeProperty, new SolidColorBrush(Colors.Black)));
            s.Setters.Add(new Setter(SPath.StrokeThicknessProperty, 6d));
            return s;
        }

        void FloorPlannerDiagram_Loaded(object sender, RoutedEventArgs e)
        {
            floorplan.CommandManager.View = (Control)Application.Current.MainWindow;

        }

        void floorplan_ItemUnSelectedEvent(object sender, DiagramEventArgs args)
        {
            //TabItemExt txt= tabControl.Items[2] as TabItemExt;
            //  txt.Visibility = Visibility.Collapsed;

            //  TabItemExt txt1 = tabControl.Items[0] as TabItemExt;
            //  txt1.IsSelected = true;
            if (args.Item is FloorPlanNode)
            {
                if ((args.Item as FloorPlanNode).IsTextNode)
                {
                    this.FloorPlannerViewModel.SelectedObject = null;
                    RemoveTextNode();
                    HideEditors();
                }
            }
            else if (args.Item is FloorPlanConnector)
            {
                (args.Item as FloorPlanConnector).ZIndex = 1;
            }
            if (((IEnumerable<object>)(floorplan.SelectedItems as CustomSelector).Nodes).Count() >= 0)
            {
                if (b != null)
                    b.Visibility = Visibility.Visible;
            }
            else if (((IEnumerable<object>)(floorplan.SelectedItems as CustomSelector).Connectors).Count() >= 0)
            {
                b.Visibility = Visibility.Visible;
            }
            else
            {
                b.Visibility = Visibility.Collapsed;
            }

            if (sf != null)
            {
                sf.Visibility = Visibility.Collapsed;
            }
            //ShowEditor("props");
            if(optionnode !=null)
            optionnode.Visibility = Visibility.Collapsed;
        }

        void floorplan_ItemSelectedEvent(object sender, DiagramEventArgs args)
        {
            //tabControl.Height = 500;
            //PropertyEditor.Height = 0;
            if (args.Item is FloorPlanNode)
            {
                if (b != null)
                {
                    b.Visibility = Visibility.Visible;
                }
                UpdateOptionnode(null);
                // UpdateInfo(size: true);
                if ((args.Item as FloorPlanNode).Content != null && Enum.GetNames(typeof(BasicShapes)).Any(w => w == (args.Item as FloorPlanNode).Content.ToString()))
                {
                    (args.Item as FloorPlanNode).IsShapeNode = true;
                }
                (floorplan.SelectedItems as CustomSelector).SelectedObject = (args.Item as FloorPlanNode);

                if ((args.Item as FloorPlanNode).IsTextNode)
                {
                    //tabControl.Height = 0;
                    //PropertyEditor.Height = 500;
                    this.FloorPlannerViewModel.SelectedObject = (args.Item as FloorPlanNode);
                    this.TextNode = (args.Item as FloorPlanNode);
                    FloorPlannerViewModel.TitleText = ((this.TextNode.NodeAnnotations.ToList()[0] as AnnotationEditorViewModel).Content as TextBox).Text;
                    FloorPlannerViewModel.TextFont = ((this.TextNode.NodeAnnotations.ToList()[0] as AnnotationEditorViewModel).Content as TextBox).FontFamily.Source.ToString();
                    FloorPlannerViewModel.TextSize = ((this.TextNode.NodeAnnotations.ToList()[0] as AnnotationEditorViewModel).Content as TextBox).FontSize;
                    FloorPlannerViewModel.TextColor = (((this.TextNode.NodeAnnotations.ToList()[0] as AnnotationEditorViewModel).Content as TextBox).Foreground as SolidColorBrush).Color.ToString();
                  
                       ShowEditors();
                }
                else
                {
                   //HideEditors();
                }
            }
            else if (args.Item is FloorPlanConnector)
            {
                if (b != null)
                    b.Visibility = Visibility.Visible;
                (floorplan.SelectedItems as CustomSelector).SelectedObject = (args.Item as FloorPlanConnector);
                FloorPlanConnector con = (floorplan.SelectedItems as CustomSelector).SelectedObject as FloorPlanConnector;
                con.ZIndex = 2000;
                if (optionnode == null)
                {
                    CreateOptionnode();
                }
                if (optionnode != null)
                {
                    
                    if (!_nodes.Contains(optionnode))
                    {
                        _nodes.Add(optionnode);
                    }
                    UpdateOptionnode(con);

                }
                if (st != null)
                {
                    if (EndButton == null)
                        EndButton = st.Children[1] as ToggleButton;
                    if (CenterButton == null)
                        CenterButton = st.Children[2] as Button;
                }
                if (EndButton != null)
                {
                    if (con.IsBesizer)
                    {
                        EndButton.IsChecked = true;
                        CenterButton.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        EndButton.IsChecked = false;
                        CenterButton.Visibility = Visibility.Visible;
                    }
                }

                if (CenterButton != null)
                {
                    if (con.IsSplit)
                    {
                        EndButton.Visibility = Visibility.Collapsed;
                        CenterButton.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        EndButton.Visibility = Visibility.Visible;
                        if (!con.IsBesizer)
                        {
                            CenterButton.Visibility = Visibility.Visible;
                        }
                    }
                }
            }
        }

        private void UpdateOptionnode(FloorPlanConnector con)
        {
            if (con != null)
            {
                double angle = FindAngle(con.SourcePoint, con.TargetPoint);
                Point p = Transform1(new Point((con.SourcePoint.X + con.TargetPoint.X) / 2, (con.SourcePoint.Y + con.TargetPoint.Y) / 2), 28, (angle - 90));
                optionnode.OffsetX = p.X;
                optionnode.OffsetY = p.Y;
                optionnode.Visibility = Visibility.Visible;
                optionnode.RotateAngle = angle;
            }
            else
            {
                if (optionnode != null)
                {
                    optionnode.Visibility = Visibility.Collapsed;
                    optionnode.OffsetX = 0;
                    optionnode.OffsetY = 0;
                }
            }
        }

        private Point Transform1(Point s, int length, double angle)
        {
            return new Point()
            {
                X = s.X + length * Math.Cos(angle * Math.PI / 180),
                Y = s.Y + length * Math.Sin(angle * Math.PI / 180)
            };
        }

        void LoadSt(object sender, RoutedEventArgs e)
        {
            st = (sender as StackPanel);
        }

        void optionnode_Loaded(object sender, RoutedEventArgs e)
        {
            st = (sender as FloorPlanNode).FindDescendantByName("buttonpanel") as StackPanel;
            //  st = (sender as FloorPlanNode).FindDescendantByName("buttonpanel") as StackPanel;
            StartButton = (sender as FloorPlanNode).FindDescendantByName("start") as Button;
            EndButton = (sender as FloorPlanNode).FindDescendantByName("end") as ToggleButton;
            CenterButton = (sender as FloorPlanNode).FindDescendantByName("center") as Button;
            if ((floorplan.SelectedItems as CustomSelector).SelectedObject is FloorPlanConnector)
            {
                if (st != null && (st.Children[0] as Button).Name == "start")
                {
                    StartButton = (st.Children[0] as Button);
                    // StartButton.Tag = ((floorplan.SelectedItems as CustomSelector).SelectedObject as FloorPlanConnector).SourcePoint;
                }
            }
        }

        private void ShowEditors()
        {
            PropertyEditor.DataContext = null;
            PropertyEditor.Visibility = Visibility.Visible;
            FloorPlannerViewModel.ValueType = "Text";
            PropertyEditor.DataContext = this.FloorPlannerViewModel;
            (PropertyEditor.Resources["PropertyEditor_Storyboard_Visible"] as Storyboard).Begin();


            if (FloorPlannerViewModel.textbox != null)
            {
                if (FloorPlannerViewModel.textbox.Text == "Text")
                {
                    FloorPlannerViewModel.textbox.SelectionLength = 4;
                }
                FloorPlannerViewModel.textbox.Focus();

            }
        }


        void floorplan_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HideEditors();
            //if (IsPickerClicked)
            //    p.IsOpen = false;
            //else
            //    IsPickerClicked = false;
            //foreach (var element in VisualTreeHelper.FindElementsInHostCoordinates(e.GetCurrentPoint(null).Position, null))
            //{
            //    if (element is FloorPlanNode)
            //    {
            //        if ((element as FloorPlanNode).IsTextNode)
            //        {
            //            ShowEditors();
            //        }
            //        else
            //        {
            //            HideEditors();
            //        }
            //    }
            //    else if (element is FloorPlanDiagram)
            //    {
            //        if (FloorPlannerViewModel.IsTextAdd)
            //        {
            //            foreach (FloorPlanNode node in _nodes)
            //            {
            //                node.IsSelected = false;
            //            }

            //            foreach (FloorPlanConnector con in _connectors)
            //            {
            //                con.IsSelected = false;
            //            }
            //            if (TextNode != null)
            //            {
            //                TextNode.IsSelected = false;
            //                TextNode = null;
            //            }
            //            Point point = e.GetCurrentPoint(null).Position;
            //            AddTextNode(point);
            //        }
            //        else
            //        {
            //            if (TextNode != null)
            //            {
            //                if (((TextNode.NodeAnnotations.ToArray()[0] as AnnotationEditorViewModel).Content as TextBox).Text == "Text")
            //                {
            //                    _nodes.Remove(TextNode);
            //                }
            //            }
            //            HideEditors();
            //            if (f != null)
            //            {
            //                f.Visibility = Visibility.Collapsed;

            //            }
            //            UpdateOptionnode(null);
            //            if (sf != null)
            //            {
            //                sf.Visibility = Visibility.Collapsed;
            //            }
            //        }
            //    }
            //}
        }
        #endregion

        #region Helpers
        public FloorPlannerViewModel FloorPlannerViewModel
        {
            get { return (FloorPlannerViewModel)GetValue(FloorPlannerViewModelProperty); }
            set { SetValue(FloorPlannerViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FloorPlannerViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FloorPlannerViewModelProperty =
            DependencyProperty.Register("FloorPlannerViewModel", typeof(FloorPlannerViewModel), typeof(FloorPlannerDiagram), new PropertyMetadata(null, OnPropertyChanged));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FloorPlannerDiagram f = d as FloorPlannerDiagram;
            FloorPlannerViewModel vm = e.NewValue as FloorPlannerViewModel;
            if (vm != null)
            {
                vm.Save = new DelegateCommand<object>(f.OnSave, args => { return true; });
                vm.Load = new DelegateCommand<object>(f.OnLoad, args => { return true; });

                vm.Clear = new DelegateCommand<object>(f.OnClear, args => { return true; });
                vm.Delete = new DelegateCommand<object>(f.OnDelete, args => { return true; });
                vm.Back = new DelegateCommand<object>(f.OnBack, args => { return true; });
                vm.AddProp = new DelegateCommand<object>(f.OnAddProp, args => { return true; });
                vm.AddShape = new DelegateCommand<object>(f.OnAddShape, args => { return true; });
                vm.AddText = new DelegateCommand<object>(f.OnAddText, args => { return true; });
                vm.AddWall = new DelegateCommand<object>(f.OnAddWall, args => { return true; });
                vm.BoldCommand = new DelegateCommand<object>(f.OnBold, args => { return true; });
                vm.ItalicCommand = new DelegateCommand<object>(f.OnItalic, args => { return true; });
                vm.ForgroundColor = new DelegateCommand<object>(f.OnColorChanged, args => { return true; });
                vm.TextChanged = new DelegateCommand<object>(f.OnTextChanged, args => { return true; });
                vm.Strokes = new DelegateCommand<object>(f.OnStrokeChanged, args => { return true; });
                vm.TitleFont = new DelegateCommand<object>(f.OnFontChanged, args => { return true; });
                vm.TitleFontSize = new DelegateCommand<object>(f.OnSizeChanged, args => { return true; });
                vm.CancelCommand = new DelegateCommand<object>(f.OnCancel, args => { return true; });
                vm.OKCommand = new DelegateCommand<object>(f.OnOkCommand, args => { return true; });
              //  vm.SelectEditor = new DelegateCommand<object>(f.OnSelectEditor, args => { return true; });
                // vm.DeleteSelectedObject = new DelegateCommand<object>(f.OnDeletecommand, f.CanDelete);
                vm.Create = new DelegateCommand<object>(f.OnCreate, args => { return true; });
                vm.ForeColorChanged = new DelegateCommand<object>(f.OnColorCommand, args => { return true; });
               // f.ShowEditor("Props");
            }
        }

        //internal void ShowEditor(string p)
        //{
        //    PropertyEditor.DataContext = null;
        //    PropertyEditor.Visibility = Visibility.Visible;
        //    FloorPlannerViewModel.ValueType = "Prop";
        //    PropertyEditor.DataContext = FloorPlannerViewModel;
        //    (PropertyEditor.Resources["PropertyEditor_Storyboard_Visible"] as Storyboard).Begin();
        //    PropertyEditor.InvalidateMeasure();
        //    PropertyEditor.InvalidateArrange();
        //}

        private void HideEditors()
        {
            if (PropertyEditor.Visibility != Visibility.Collapsed)
            {

                (PropertyEditor.Resources["PropertyEditor_Storyboard_Collapse"] as Storyboard).Begin();
            }
        }

        private void createwallinfo()
        {
            wallInfo = new FloorPlanConnector();
            wallInfo.SourceDecorator = GetArrow();
            wallInfo.TargetDecorator = GetArrow();
            wallInfo.SourceDecoratorStyle = GetArrowStyle();
            wallInfo.TargetDecoratorStyle = GetArrowStyle();
            wallInfo.ConnectorGeometryStyle = GetLineStyle();
            wallInfo.Visibility = Visibility.Collapsed;
            wallInfo.IsWallInfo = true;
            wallInfo.Annotations = new ObservableCollection<IAnnotation>()
            {
                new AnnotationEditorViewModel()
                {
                    ViewTemplate = this.Resources["ViewTemplate1"] as DataTemplate,
                    Alignment = ConnectorAnnotationAlignment.Center
                
                }
            };

        }
        #endregion

        #region Commands

        private void OnDeletecommand(object obj)
        {
            if (floorplan.SelectedItems != null)
            {
                if ((floorplan.SelectedItems as CustomSelector).Nodes != null)
                {
                    ObservableCollection<FloorPlanNode> f = new ObservableCollection<FloorPlanNode>();
                    foreach (FloorPlanNode node in (IEnumerable<object>)(floorplan.SelectedItems as CustomSelector).Nodes)
                    {
                        f.Add(node);
                    }

                    foreach (FloorPlanNode node in f)
                    {
                        _nodes.Remove(node);
                    }
                }

                if ((floorplan.SelectedItems as CustomSelector).Connectors != null)
                {
                    ObservableCollection<FloorPlanConnector> c = new ObservableCollection<FloorPlanConnector>();
                    foreach (FloorPlanConnector con in (IEnumerable<object>)(floorplan.SelectedItems as CustomSelector).Connectors)
                    {
                        c.Add(con);
                    }

                    foreach (FloorPlanConnector con in c)
                    {
                        _connectors.Remove(con);
                    }
                }


            }
        }

        private void OnColorCommand(object obj)
        {
            if (this.FloorPlannerViewModel.TitleText != string.Empty)
            {
                if (TextNode != null)
                {
                    ((this.TextNode.NodeAnnotations.ToList()[0] as AnnotationEditorViewModel).Content as TextBox).Foreground = ColorConverter(obj.ToString());
                    this.TextNode.ForeColor = obj.ToString();
                    this.FloorPlannerViewModel.TextColor = obj.ToString();
                }
            }
        }

        private void OnCancel(object obj)
        {
            if (TextNode != null)
            {
                _nodes.Remove(TextNode);
            }
            HideEditors();
        }

        private void OnOkCommand(object obj)
        {
            if (sb != null)
                sb.Stop();
            TextNode = null;
            PropertyEditor.DataContext = null;
            HideEditors();

        }

        private void OnSizeChanged(object obj)
        {
            if (this.FloorPlannerViewModel.TitleText != string.Empty)
            {
                if (TextNode != null)
                {
                    ((this.TextNode.NodeAnnotations.ToList()[0] as AnnotationEditorViewModel).Content as TextBox).FontSize = double.Parse(obj.ToString());
                    this.TextNode.TextFontSize = ((this.TextNode.NodeAnnotations.ToList()[0] as AnnotationEditorViewModel).Content as TextBox).FontSize;
                    this.FloorPlannerViewModel.TextSize = ((this.TextNode.NodeAnnotations.ToList()[0] as AnnotationEditorViewModel).Content as TextBox).FontSize;
                }
            }
        }

        private void OnFontChanged(object obj)
        {
            if (this.FloorPlannerViewModel.TitleText != string.Empty)
            {
                if (TextNode != null)
                {
                    if ((this.TextNode.NodeAnnotations.ToList()[0] as AnnotationEditorViewModel).Content != null)
                    {
                        TextBox tb = (this.TextNode.NodeAnnotations.ToList()[0] as AnnotationEditorViewModel).Content as TextBox;
                        if (tb != null)
                        {
                            tb.FontFamily = new FontFamily(obj.ToString());
                            this.TextNode.Font = obj.ToString();
                            this.FloorPlannerViewModel.TextFont = obj.ToString();
                            if (sb != null)
                                sb.Stop();
                        }
                    }
                }
            }
        }

        private void OnStrokeChanged(object obj)
        {
            if (this.FloorPlannerViewModel.TitleText != string.Empty)
            {
                // if((this.FloorPlannerViewModel.NodeText as TextBlock).fontv
            }
        }

        private void OnTextChanged(object obj)
        {
            if (TextNode != null)
                if ((this.TextNode.NodeAnnotations.ToList()[0] as AnnotationEditorViewModel).Content != null)
                {
                    TextBox tb = (this.TextNode.NodeAnnotations.ToList()[0] as AnnotationEditorViewModel).Content as TextBox;
                    if (tb != null)
                    {
                        tb.Text = obj.ToString();
                        TextNode.NodeText = obj.ToString();
                        if (sb != null)
                           sb.Stop();
                    }
                }
        }

        private void OnColorChanged(object obj)
        {
            if (enable % 2 == 0)
            {
                this.FloorPlannerViewModel.Enabled = true;
            }
            else
            {
                this.FloorPlannerViewModel.Enabled = false;
            }
            if (this.FloorPlannerViewModel.TitleText != string.Empty)
            {

            }
            enable += 1;
            if (sb != null)
                sb.Stop();
        }

        private void OnItalic(object obj)
        {
            if (this.FloorPlannerViewModel.TitleText != string.Empty)
            {
                if (TextNode != null)
                {
                    if ((this.TextNode.NodeAnnotations.ToList()[0] as AnnotationEditorViewModel).Content != null)
                    {
                        TextBox tb = (this.TextNode.NodeAnnotations.ToList()[0] as AnnotationEditorViewModel).Content as TextBox;
                        if (tb != null)
                        {
                            if (tb.FontStyle == FontStyles.Italic)
                            {
                                tb.FontStyle = FontStyles.Normal;
                            }
                            else
                            {
                                tb.FontStyle = FontStyles.Italic;
                            }
                            if (sb != null)
                                sb.Stop();
                            tb.FontStyle = tb.FontStyle;
                        }
                    }
                }
            }
        }

        private void OnBold(object obj)
        {
            if (this.FloorPlannerViewModel.TitleText != string.Empty)
            {
                if (TextNode != null)
                {
                    CheckFontWeight(TextNode);
                    if (sb != null)
                        sb.Stop();
                }
            }
        }

        private void CheckFontWeight(FloorPlanNode t)
        {
            if (t.NodeAnnotations != null && this.TextNode!=null)
            {
                if ((this.TextNode.NodeAnnotations.ToList()[0] as AnnotationEditorViewModel).Content != null)
                {
                    TextBox tb = (t.NodeAnnotations.ToList()[0] as AnnotationEditorViewModel).Content as TextBox;
                    if (tb != null)
                    {
                        if (tb.FontWeight.Equals(FontWeights.Bold))
                        {
                            tb.FontWeight = FontWeights.Normal;
                            t.TextWeight = "Normal";
                        }
                        else
                        {
                            tb.FontWeight = FontWeights.Bold;
                            t.TextWeight = "Bold";
                        }
                    }
                }
            }
        }

        #region AppBar

        private void OnAddText(object obj)
        {
            RemoveTextNode();
            FloorPlannerViewModel.IsTextAdd = true;
            HideEditors();

        }

        private void RemoveTextNode()
        {
            if (TextNode != null)
            {
                if (TextNode.NodeAnnotations!=null &&
                    ((TextNode.NodeAnnotations.ToArray()[0] as AnnotationEditorViewModel).Content as TextBox).Text == "Text")
                {
                    _nodes.Remove(TextNode);
                }
            }
        }

        FloorPlanNode TextNode = null;

        private void AddTextNode(Point point)
        {
            TextNode = new FloorPlanNode();
            TextNode.UnitWidth = 50;
            TextNode.UnitHeight = 30;
            TextNode.IsTextNode = true;
            TextNode.IsSelected = true;

            TextBox t = new TextBox() { BorderBrush = new SolidColorBrush(Colors.LightGray), BorderThickness = new Thickness(0), Foreground = ColorConverter("#FFC40C0C"), FontSize = 12, FontFamily = new FontFamily("Segoe UI") };

            t.TextChanged += t_TextChanged;
            // t.Text = this.FloorPlannerViewModel.TitleText;          
            TextNode.NodeAnnotations = new ObservableCollection<object>()
            {
                new AnnotationEditorViewModel()
                {
                    UnitHeight=100,
                    UnitWidth=100,
                    Content=t,ViewTemplate=this.Resources["ViewTemplate"] as DataTemplate,
                    EditTemplate=this.Resources["EditTemplate"] as DataTemplate,
                    TextHorizontalAlignment= TextAlignment.Center,
                    TextVerticalAlignment= System.Windows.VerticalAlignment.Center,
                }
            };
            t.Text = "Text";
            TextNode.OffsetX = point.X;
            TextNode.OffsetY = point.Y;
            TextNode.Loaded += TextNode_Loaded;
            _nodes.Add(TextNode);

            //// TextNode.InvalidateMeasure();
            // TextNode.InvalidateArrange();
            //TextNode.Loaded += (s, e) =>
            //    {
            //        // ExpandAnimation(TextNode);
            //    };
            if (FloorPlannerViewModel.textbox != null)
            {
                if (FloorPlannerViewModel.textbox.Text == "Text")
                {
                    FloorPlannerViewModel.textbox.SelectionLength = 4;
                }
                FloorPlannerViewModel.textbox.Focus();

            }
            FloorPlannerViewModel.IsTextAdd = false;
        }

        void TextNode_Loaded(object sender, RoutedEventArgs e)
        {
            (((sender as FloorPlanNode).NodeAnnotations.ToList()[0] as AnnotationEditorViewModel).Content as TextBox).IsTabStop = true;
            (((sender as FloorPlanNode).NodeAnnotations.ToList()[0] as AnnotationEditorViewModel).Content as TextBox).UpdateLayout();
            (((sender as FloorPlanNode).NodeAnnotations.ToList()[0] as AnnotationEditorViewModel).Content as TextBox).Focus();

        }

        void t_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextNode != null && this.TextNode.Content != null)
                TextNode.NodeText = (this.TextNode.Content as TextBox).Text.ToString();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (TextNode != null)
                TextNode.NodeText = (sender as TextBox).Text.ToString();
            FloorPlannerViewModel.TitleText = (sender as TextBox).Text.ToString();
        }

        private void OnAddWall(object obj)
        {
            RemoveTextNode();
            FloorPlannerViewModel.IsTextAdd = false;
            floorplan.DefaultConnectorType = ConnectorType.Line;
            floorplan.Tool = floorplan.Tool | Tool.DrawOnce;
            if (wallInfo == null)
            {
                createwallinfo();
            }


            if (wallInfo != null)
            {
                if (_connectors != null)
                {
                    if (!_connectors.Contains(wallInfo))
                    {
                        _connectors.Add(wallInfo);
                    }
                }
            }
            //if (st != null)
            //{
            //    st.Visibility = Visibility.Collapsed;
            //}
        }

        private void OnAddShape(object obj)
        {
            RemoveTextNode();
            TextNode = null;
            FloorPlannerViewModel.IsTextAdd = false;
            PropertyEditor.DataContext = null;
            PropertyEditor.InvalidateMeasure();
            PropertyEditor.Visibility = Visibility.Visible;
            SymbolCollectionType s = new SymbolCollectionType();
            FloorPlannerViewModel.ValueType = "Shape";
            PropertyEditor.DataContext = FloorPlannerViewModel;
            (PropertyEditor.Resources["PropertyEditor_Storyboard_Visible"] as Storyboard).Begin();
            PropertyEditor.InvalidateMeasure();
            PropertyEditor.InvalidateArrange();
        }

        private void OnAddProp(object obj)
        {
            RemoveTextNode();
            TextNode = null;
            FloorPlannerViewModel.IsTextAdd = false;
            PropertyEditor.DataContext = null;
            PropertyEditor.Visibility = Visibility.Visible;
            FloorPlannerViewModel.ValueType = "Prop";
            PropertyEditor.DataContext = FloorPlannerViewModel;
            (PropertyEditor.Resources["PropertyEditor_Storyboard_Visible"] as Storyboard).Begin();
            PropertyEditor.InvalidateMeasure();
            PropertyEditor.InvalidateArrange();
        }

        private void OnSelectEditor(object obj)
        {
            //this.FloorPlannerViewModel.DiagramVisibility = Visibility.Collapsed;
            if (PropertyEditor.Visibility == Visibility.Collapsed)
            {
                PropertyEditor.Visibility = Visibility.Visible;
            }
            else
            {
                PropertyEditor.Visibility = Visibility.Collapsed;
            }
        }

        private void OnBack(object obj)
        {
            this.FloorPlannerViewModel.DiagramVisibility = Visibility.Collapsed;
            this.FloorPlannerViewModel.Save.Execute(null);
        }

        private void OnDelete(object obj)
        {
            if (obj != null)
            {
                if (obj is Button)
                {
                    b = obj as Button;
                }
                else
                {

                    if ((floorplan.SelectedItems as CustomSelector).Nodes != null)
                    {
                        ObservableCollection<FloorPlanNode> fn = new ObservableCollection<FloorPlanNode>();

                        foreach (FloorPlanNode f in (IEnumerable<object>)(floorplan.SelectedItems as CustomSelector).Nodes)
                        {
                            fn.Add(f);
                        }

                        foreach (FloorPlanNode f1 in fn)
                        {
                            _nodes.Remove(f1);
                        }
                    }

                    if ((floorplan.SelectedItems as CustomSelector).Connectors != null)
                    {
                        ObservableCollection<FloorPlanConnector> con = new ObservableCollection<FloorPlanConnector>();
                        foreach (FloorPlanConnector c in (IEnumerable<object>)(floorplan.SelectedItems as CustomSelector).Connectors)
                        {
                            con.Add(c);
                        }

                        foreach (FloorPlanConnector c1 in con)
                        {
                            _connectors.Remove(c1);
                        }
                    }
                    b.Visibility = Visibility.Collapsed;
                    UpdateOptionnode(null);
                }
            }
        }

        private void OnClear(object obj)
        {
            _nodes.Clear();
            _connectors.Clear();
        }
        #endregion

        #region Options
        //Wall Thickness
        private void start_Click_1(object sender, RoutedEventArgs e)
        {
            f = new FloorPlanNode();
            f.Constraints = NodeConstraints.None;
            f.UnitWidth = 115;
            f.UnitHeight = 115;
            Grid g = new Grid();
            sf = new SfRadialSlider() { Width = 110, Height = 110 };
            //sf.SmallChange = 0.2;
            //sf.TickFrequency = 1;
            sf.SmallChange = 2;
            sf.TickFrequency = 2;
            sf.LabelVisibility = Visibility.Visible;
            sf.Minimum = 2;
            sf.Maximum = 10;
            sf.LabelTemplate = this.Resources["SliderTemplate"] as DataTemplate;
            sf.Content = new TextBlock() { Text = "6''", Foreground = new SolidColorBrush(Colors.Black) };
            sf.InnerRimRadiusFactor = 0.40;
            f.Content = sf;
            f.IsOption = true;
            _nodes.Add(f);
            sf.Visibility = Visibility.Visible;
            if ((floorplan.SelectedItems as CustomSelector).SelectedObject is FloorPlanConnector)
            {
                FloorPlanConnector con = ((floorplan.SelectedItems as CustomSelector).SelectedObject as FloorPlanConnector);
                sf.Value = con.ConThickness;
                sf.ValueChanged += sf_ValueChanged;
                double angle = FindAngle(con.SourcePoint, con.TargetPoint);
                Point p = Transform(new Point(((con.SourcePoint.X - (f.UnitWidth / 2)) + (con.TargetPoint.X - (f.UnitWidth) / 2)) / 2, ((con.SourcePoint.Y - (f.UnitHeight / 2)) + (con.TargetPoint.Y - (f.UnitHeight / 2))) / 2), 15, (angle - 90));
                f.OffsetX = p.X;
                f.OffsetY = p.Y;
            }
            UpdateOptionnode(null);
        }



        //Besizer
        private void end_Click_1(object sender, RoutedEventArgs e)
        {
            if ((floorplan.SelectedItems as CustomSelector).SelectedObject is FloorPlanConnector)
            {
                FloorPlanConnector con = ((floorplan.SelectedItems as CustomSelector).SelectedObject as FloorPlanConnector);
                con.Constraints = con.Constraints | ConnectorConstraints.SegmentThumbs;
                if (!con.IsBesizer)
                {
                    con.Segments = new ObservableCollection<IConnectorSegment>()
                    {
                        new CubicCurveSegment()
                    };
                    con.IsBesizer = true;
                }
                else
                {
                    con.Segments = new ObservableCollection<IConnectorSegment>()
                    {
                        new LineSegmentLength()
                    };
                  
                    con.IsBesizer = false;
                }
            }
            UpdateOptionnode(null);
        }

        //Split
        private void center_Click_1(object sender, RoutedEventArgs e)
        {
            if ((floorplan.SelectedItems as CustomSelector).SelectedObject is FloorPlanConnector)
            {
                FloorPlanConnector con = ((floorplan.SelectedItems as CustomSelector).SelectedObject as FloorPlanConnector);
                con.Constraints = con.Constraints | ConnectorConstraints.SegmentThumbs;
                Point centerpoint = new Point((con.SourcePoint.X + con.TargetPoint.X) / 2, (con.SourcePoint.Y + con.TargetPoint.Y) / 2);
                Point center = new Point((con.SourcePoint.X + centerpoint.X) / 2, (con.SourcePoint.Y + centerpoint.Y) / 2);
                //con.Segments.Insert(new CubicCurveSegment() { Point1 = centerpoint, Point2 = null });
                con.Segments = new ConnectorSegments()
                {
                    new StraightSegment(){Point=centerpoint},
                    new StraightSegment()
                };
                con.IsSplit = true;
            }
            UpdateOptionnode(null);
        }
        #endregion

        #region Save & Load
        private void OnLoad(object param)
        {
            _nodes.Clear();
            _connectors.Clear();

            string installedlocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string pathString = System.IO.Path.Combine(installedlocation, "FloorPlan");

            if (param != null)
            {
                this.FloorPlannerViewModel.CurrentlyLoaded = param.ToString();

                DirectoryInfo DI = new DirectoryInfo(param.ToString());
                using (FileStream fileStream = File.OpenRead(pathString + "/" + param.ToString() + ".xml"))
                {
                    floorplan.Load(fileStream);
                    UpdateLoad();
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

        private void OnSave(object param)
        {
            string installedlocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string pathString = System.IO.Path.Combine(installedlocation, "FloorPlan");
            string file = string.Empty;

            if (param == null)
            {
                if (!string.IsNullOrEmpty(this.FloorPlannerViewModel.CurrentlyLoaded))
                {
                    //System.IO.File.Create(".//PresavedFloorPlan/" + this.FloorPlannerViewModel.CurrentlyLoaded + ".xml");
                    file = this.FloorPlannerViewModel.CurrentlyLoaded;
                }
            }
            else
            {
                //System.IO.File.Create(".//PresavedFloorPlan/" + param + ".xml");
                this.FloorPlannerViewModel.CurrentlyLoaded = param.ToString();
                file = this.FloorPlannerViewModel.CurrentlyLoaded;

            }




            if (!string.IsNullOrEmpty(file))
            {

                if (File.Exists(pathString + "/" + file.ToString() + ".xml"))
                {
                    File.Delete(pathString + "/" + file.ToString() + ".xml");
                }

                File.Create(pathString + "/" + file.ToString() + ".xml").Close();
                Updatesave();

                using (FileStream fileStream = File.OpenWrite(pathString + "/" + file.ToString() + ".xml"))
                {
                    floorplan.Save(fileStream);
                }
            }
        }

        private void UpdateLoad()
        {
            wallInfo = null;
            optionnode = null;

            ResourceDictionary resourceDictionary = new ResourceDictionary()
            {
                Source = new Uri(@"/syncfusion.floorplanner.wpf;component/Template/FloorPlanDictionary.xaml", UriKind.RelativeOrAbsolute)
            };

            foreach (FloorPlanConnector c in _connectors)
            {
                if (!c.IsWallInfo)
                {
                    c.ConnectorGeometryStyle = SetStyle(c.ConThickness);
                    if (c.BezierString != string.Empty)
                    {
                        string[] splits = c.BezierString.Split(',');
                        c.Segments = new ConnectorSegments();
                        CubicCurveSegment cc = new CubicCurveSegment();
                        if (splits.Length == 3)
                        {
                            cc.Point1 = new Point(double.Parse(splits[1]), double.Parse(splits[2]));
                        }
                        else if (splits.Length == 5)
                        {
                            cc.Point1 = new Point(double.Parse(splits[1]), double.Parse(splits[2]));
                            cc.Point2 = new Point(double.Parse(splits[3]), double.Parse(splits[4]));
                        }
                        else if (splits.Length == 7)
                        {
                            cc.Point1 = new Point(double.Parse(splits[1]), double.Parse(splits[2]));
                            cc.Point2 = new Point(double.Parse(splits[3]), double.Parse(splits[4]));
                            cc.Point3 = new Point(double.Parse(splits[5]), double.Parse(splits[6]));
                        }
                        (c.Segments as ICollection<IConnectorSegment>).Add(cc);
                    }
                    if (c.IntermediateString != string.Empty)
                    {
                        string[] splits = c.IntermediateString.Split(',');
                        if (splits.Length == 3)
                        {
                            if (c.Segments == null)
                            {
                                c.Segments = new ConnectorSegments()
                                            {
                                                new StraightSegment()
                                                {
                                                    Point=new Point(double.Parse(splits[1]),double.Parse(splits[2]))
                                                }
                                            };
                            }
                            else
                            {
                                (c.Segments as ICollection<IConnectorSegment>).Add(new StraightSegment()
                                {
                                    Point = new Point(double.Parse(splits[1]), double.Parse(splits[2]))
                                });
                            }
                        }
                        else if (splits.Length == 4)
                        {
                            c.Segments = new ConnectorSegments()
                                            {
                                                new StraightSegment()
                                                {
                                                    Point=new Point(double.Parse(splits[1]),double.Parse(splits[2]))
                                                }
                                            };

                            if (splits[3] == "S")
                            {
                                (c.Segments as ICollection<IConnectorSegment>).Add(new StraightSegment());
                            }
                        }
                    }
                }
            }
            foreach (FloorPlanNode f1 in _nodes)
            {
                if (f1.IsTextNode)
                {
                    TextBox t = new TextBox() { Foreground = ColorConverter(f1.ForeColor), FontSize = f1.TextFontSize, FontFamily = new FontFamily(f1.Font.ToString()), Text = f1.NodeText, FontStyle = f1.TextStyle };
                    // f1.Content = t;
                    f1.NodeAnnotations = new ObservableCollection<object>()
                     {
                        new AnnotationEditorViewModel()
                          {
                             Content=t,ViewTemplate=this.Resources["ViewTemplate"] as DataTemplate,EditTemplate=this.Resources["EditTemplate"] as DataTemplate
                          }
                     };
                    CheckFontWeight(f1);
                    if ((f1 as FloorPlanNode).TextWeight == "Bold")
                    {
                        t.FontWeight = FontWeights.Bold;
                    }
                    else if (f1.TextWeight == "Normal")
                    {
                        t.FontWeight = FontWeights.Normal;
                    }

                }
                else
                {
                    if (f1.ContentName != null)
                    {
                        if (!f1.IsOption)
                        {
                            f1.ContentTemplate = resourceDictionary[f1.ContentName.ToString()] as DataTemplate;
                            if (f1.ContentName == "Window")
                            {
                                // node.Width = 5;
                                f1.UnitHeight = 6;
                            }
                        }
                    }
                    else if (f1.IsShapeNode)
                    {
                        f1.ShapeStyle = GetStyle(f1.SelectedColor.ToString());
                    }
                }

            }
            this.FloorPlannerViewModel.DiagramVisibility = Visibility.Visible;
        }

        private void Updatesave()
        {
            List<FloorPlanConnector> flc = new List<FloorPlanConnector>();
            List<FloorPlanNode> fpn = new List<FloorPlanNode>();
            if (p != null)
            {
                p.IsOpen = false;
            }

            foreach (FloorPlanConnector pc in _connectors)
            {
                pc.IsSelected = false;
                if (pc.IsWallInfo)
                {
                    flc.Add(pc);
                }
                if (pc.Segments != null)
                {
                    if (pc.Segments is ICollection<IConnectorSegment>)
                    {
                        if ((pc.Segments as ICollection<IConnectorSegment>).ToList()[0] is CubicCurveSegment)
                        {
                            pc.BezierString = "C";
                            if (((pc.Segments as ICollection<IConnectorSegment>).ToList()[0] as CubicCurveSegment).Point1 != null)
                            {
                                pc.BezierString += "," + ((pc.Segments as ICollection<IConnectorSegment>).ToList()[0] as CubicCurveSegment).Point1.ToString();
                            }
                            if (((pc.Segments as ICollection<IConnectorSegment>).ToList()[0] as CubicCurveSegment).Point2 != null)
                            {
                                pc.BezierString += "," + ((pc.Segments as ICollection<IConnectorSegment>).ToList()[0] as CubicCurveSegment).Point2.ToString();
                            }
                            if (((pc.Segments as ICollection<IConnectorSegment>).ToList()[0] as CubicCurveSegment).Point3 != null)
                            {
                                pc.BezierString += "," + ((pc.Segments as ICollection<IConnectorSegment>).ToList()[0] as CubicCurveSegment).Point3.ToString();
                            }
                        }
                        if ((pc.Segments as ICollection<IConnectorSegment>).ToList().Count > 1)
                        {
                            if ((pc.Segments as ICollection<IConnectorSegment>).ToList()[0] is StraightSegment)
                            {
                                pc.IntermediateString = "S";
                                if (
                                    ((pc.Segments as ICollection<IConnectorSegment>).ToList()[0] as StraightSegment)
                                        .Point != null)
                                {
                                    pc.IntermediateString += "," +
                                                             ((pc.Segments as ICollection<IConnectorSegment>).ToList()[0
                                                                 ] as StraightSegment).Point.ToString();
                                }
                            }
                            if ((pc.Segments as ICollection<IConnectorSegment>).ToList()[1] is StraightSegment)
                            {
                                pc.IntermediateString += "," + "S";
                                if (
                                    ((pc.Segments as ICollection<IConnectorSegment>).ToList()[1] as StraightSegment)
                                        .Point != null)
                                {
                                    pc.IntermediateString += "," +
                                                             ((pc.Segments as ICollection<IConnectorSegment>).ToList()[1
                                                                 ] as StraightSegment).Point.ToString();
                                }
                            }
                        }
                        else if (pc.Segments != null && pc.Segments is ICollection<object>)
                        {
                            if ((pc.Segments as ICollection<object>).ToList()[0] is CubicCurveSegment)
                            {
                                pc.BezierString = "C";
                                if (((pc.Segments as ICollection<object>).ToList()[0] as CubicCurveSegment).Point1 !=
                                    null)
                                {
                                    pc.BezierString += "," +
                                                       ((pc.Segments as ICollection<object>).ToList()[0] as
                                                           CubicCurveSegment).Point1.ToString();
                                }
                                if (((pc.Segments as ICollection<object>).ToList()[0] as CubicCurveSegment).Point2 !=
                                    null)
                                {
                                    pc.BezierString += "," +
                                                       ((pc.Segments as ICollection<object>).ToList()[0] as
                                                           CubicCurveSegment).Point2.ToString();
                                }
                                if (((pc.Segments as ICollection<object>).ToList()[0] as CubicCurveSegment).Point3 !=
                                    null)
                                {
                                    pc.BezierString += "," +
                                                       ((pc.Segments as ICollection<object>).ToList()[0] as
                                                           CubicCurveSegment).Point3.ToString();
                                }
                            }
                            if ((pc.Segments as ICollection<object>).ToList().Count > 1)
                            {
                                if ((pc.Segments as ICollection<object>).ToList()[0] is StraightSegment)
                                {
                                    pc.IntermediateString = "S";
                                    if (
                                        ((pc.Segments as ICollection<object>).ToList()[0] as StraightSegment)
                                            .Point != null)
                                    {
                                        pc.IntermediateString += "," +
                                                                 ((pc.Segments as ICollection<object>).ToList()[0
                                                                     ] as StraightSegment).Point.ToString();
                                    }
                                }
                                if ((pc.Segments as ICollection<object>).ToList()[1] is StraightSegment)
                                {
                                    pc.IntermediateString += "," + "S";
                                    if (
                                        ((pc.Segments as ICollection<object>).ToList()[1] as StraightSegment)
                                            .Point != null)
                                    {
                                        pc.IntermediateString += "," +
                                                                 ((pc.Segments as ICollection<object>).ToList()[1
                                                                     ] as StraightSegment).Point.ToString();
                                    }
                                }

                            }
                        }
                    }
                }
            }


            foreach (FloorPlanConnector f in flc)
            {
                _connectors.Remove(f);
            }

            foreach (FloorPlanNode f in _nodes)
            {
                if (f.IsOption)
                {
                    fpn.Add(f);
                }
                else if (f.IsTextNode)
                {
                    if (f.NodeAnnotations != null && ((f.NodeAnnotations.ToList()[0] as AnnotationEditorViewModel).Content as TextBox).Text == "Text")
                    {
                        fpn.Add(f);
                    }
                }
            }
            foreach (FloorPlanNode f1 in fpn)
            {
                int i = _nodes.ToList().IndexOf(f1);
                _nodes.RemoveAt(i);
            }
        }

        private void OnCreate(object parameter)
        {
            if (_nodes != null)
                _nodes.Clear();
            if (_connectors != null)
                _connectors.Clear();


            string installedlocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string pathString = System.IO.Path.Combine(installedlocation, "FloorPlan");
            wallInfo = null;
            optionnode = null;
            string file = parameter.ToString() + ".xml";
            //if (EnsureUnsnapped())
            {
                System.IO.File.Create(file);
                this.FloorPlannerViewModel.CurrentlyLoaded = parameter.ToString();
            }

            using (FileStream fileStream = File.OpenWrite(pathString + "/" + file))
            {
                SfDiagram empty = new SfDiagram();
                empty.Nodes = new ObservableCollection<Node>();
                empty.Connectors = new ObservableCollection<Connector>();
                empty.Save(fileStream);
            }

            FloorPlannerViewModel.DiagramVisibility = Visibility.Visible;
        }
        #endregion


        #endregion

        #region Shapes
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            IsPickerClicked = true;
            if ((floorplan.SelectedItems as CustomSelector).SelectedObject is FloorPlanNode && !(p.IsOpen))
            {
                FloorPlanNode SelectedNode = ((floorplan.SelectedItems as CustomSelector).SelectedObject as FloorPlanNode);
                double x = SelectedNode.OffsetX;
                double y = SelectedNode.OffsetY;
                double w1 = (SelectedNode.Info as INodeInfo).ActualWidth;
                double h1 = (SelectedNode.Info as INodeInfo).ActualHeight;
                double w = graphInfo.Viewport.Width;
                double h = graphInfo.Viewport.Height;
                double x1 = graphInfo.Viewport.Left;
                double y1 = graphInfo.Viewport.Top;
                double width = (((c as SfColorPalette).Tag as Grid).Children[0] as SfColorPalette).Width;
                double height = (((c as SfColorPalette).Tag as Grid).Children[0] as SfColorPalette).Height;
                if (width > (w - x + w1 + x1))
                    p.HorizontalOffset = SelectedNode.OffsetX - width - (SelectedNode.Info as INodeInfo).DesiredSize.Width / 2 - x1;
                else
                    p.HorizontalOffset = (SelectedNode.OffsetX + (SelectedNode.Info as INodeInfo).DesiredSize.Width / 2) - x1;
                if (height > h - y + y1)
                    p.VerticalOffset = SelectedNode.OffsetY - height - y1;
                else
                    p.VerticalOffset = SelectedNode.OffsetY - y1;
                p.Child = c;
                (p.Child as SfColorPalette).DataContext = SelectedNode;
                p.IsOpen = true;
            }
        }

        void sf_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if ((floorplan.SelectedItems as CustomSelector).SelectedObject is FloorPlanConnector)
            {
                FloorPlanConnector con = ((floorplan.SelectedItems as CustomSelector).SelectedObject as FloorPlanConnector);
                con.ConThickness = (double)e.NewValue;                    //* 50) / 12;
                ((sender as SfRadialSlider).Content as TextBlock).Text = con.ConThickness.ToString() + "''";
                con.ConnectorGeometryStyle = SetStyle(con.ConThickness);
            }
        }

        private Style SetStyle(double p)
        {
            Style s = new Style(typeof(SPath));
            s.Setters.Add(new Setter(SPath.StrokeProperty, new SolidColorBrush(Colors.Black)));
            s.Setters.Add(new Setter(SPath.StrokeThicknessProperty, p));
            return s;
        }
        #endregion

        #region Info

        private Geometry GetArrow()
        {
            PathGeometry arrow = new PathGeometry();
            PathFigure fig = new PathFigure();
            fig.StartPoint = new Point(0, dist - arrowSize.Height / 2);
            fig.Segments = new PathSegmentCollection();
            fig.Segments.Add(new LineSegment() { Point = new Point(arrowSize.Width - 2, dist) });
            fig.Segments.Add(new LineSegment() { Point = new Point(0, dist + arrowSize.Height / 2) });
            fig.IsFilled = true;
            fig.IsClosed = true;
            arrow.Figures.Add(fig);
            fig = new PathFigure();
            fig.StartPoint = new Point(arrowSize.Width - 2, 0);
            fig.Segments.Add(new LineSegment() { Point = new Point(arrowSize.Width - 2, (dist * 2)) });
            arrow.Figures.Add(fig);
            return arrow;
        }

        private Style GetArrowStyle()
        {
            Style style = new Style(typeof(SPath));
            style.Setters.Add(new Setter(SPath.WidthProperty, arrowSize.Width));
            style.Setters.Add(new Setter(SPath.HeightProperty, dist));
            style.Setters.Add(new Setter(SPath.StretchProperty, Stretch.Fill));
            style.Setters.Add(new Setter(SPath.StrokeThicknessProperty, 1d));
            style.Setters.Add(new Setter(SPath.FillProperty, ColorConverter("#FFBF2121")));
            style.Setters.Add(new Setter(SPath.StrokeProperty, ColorConverter("#FFBF2121")));
            return style;
        }

        private Style GetLineStyle()
        {
            Style style = new Style(typeof(SPath));
            style.Setters.Add(new Setter(SPath.StrokeThicknessProperty, 1d));
            style.Setters.Add(new Setter(SPath.StrokeProperty, new SolidColorBrush(Colors.Red)));
            return style;
        }

        private void updateWallInfo(FloorPlanConnector con, bool head = false, bool tail = false)
        {
            if (con != null)
            {
                if (wallInfo == null)
                {
                    createwallinfo();
                    if (wallInfo != null)
                    {
                        if (_connectors != null)
                        {
                            if (!_connectors.Contains(wallInfo))
                            {
                                _connectors.Add(wallInfo);
                            }
                        }
                    }
                }
                if (!con.IsSplit)
                {
                    if (wallInfo != null)
                    {
                        wallInfo.Visibility = Visibility.Visible;
                        double angle = FindAngle(con.SourcePoint, con.TargetPoint);
                        wallInfo.SourcePoint = Transform(con.SourcePoint, dist, (angle - 90));
                        wallInfo.TargetPoint = Transform(con.TargetPoint, dist, (angle - 90));
                        double val = FindLength(wallInfo.SourcePoint, wallInfo.TargetPoint);
                        ((wallInfo.Annotations as ICollection<IAnnotation>).ToList()[0] as IAnnotation).Content = val.Feetwithinches();
                        //  wallInfo.ZIndex = 2000;
                    }
                }
                else
                {
                    wallInfo.Visibility = Visibility.Visible;
                    double angle = FindAngle(con.SourcePoint, con.TargetPoint);
                    Point centerpoint;
                    //new Point((con.SourcePoint.X + con.TargetPoint.X) / 2, (con.SourcePoint.Y + con.TargetPoint.Y) / 2);
                    if (head)
                    {
                        centerpoint = (Point)((con.Segments as ICollection<IConnectorSegment>).ToList()[0] as StraightSegment).Point;
                        wallInfo.SourcePoint = Transform(con.SourcePoint, dist, (angle - 90));
                        wallInfo.TargetPoint = Transform(centerpoint, dist, (angle - 90));
                        double val = FindLength(wallInfo.SourcePoint, centerpoint);
                        ((wallInfo.Annotations as ICollection<IAnnotation>).ToList()[0] as IAnnotation).Content = val.Feetwithinches();
                    }
                    if (tail)
                    {
                        centerpoint = (Point)((con.Segments as ICollection<IConnectorSegment>).ToList()[0] as StraightSegment).Point;
                        wallInfo.SourcePoint = Transform(centerpoint, dist, (angle - 90));
                        wallInfo.TargetPoint = Transform(con.TargetPoint, dist, (angle - 90));
                        double val = FindLength(centerpoint, wallInfo.TargetPoint);
                        ((wallInfo.Annotations as ICollection<IAnnotation>).ToList()[0] as IAnnotation).Content = val.Feetwithinches();
                    }
                }
            }
            else
            {
                if (wallInfo != null)
                {
                    wallInfo.Visibility = Visibility.Collapsed;
                    wallInfo.ZIndex = 0;
                }
            }
        }

        public static double FindLength(Point s, Point e)
        {
            double length;
            length = Math.Sqrt(Math.Pow((s.X - e.X), 2) + Math.Pow((s.Y - e.Y), 2));
            return length;
        }

        public static double FindAngle(Point s, Point e)
        {
            if (s.Equals(e))
            {
                return 0d;
            }
            Point r = new Point(e.X, s.Y);
            double sr = FindLength(s, r);
            double re = FindLength(r, e);
            double es = FindLength(e, s);
            double ang = Math.Asin(re / es);
            ang = ang * 180 / Math.PI;
            if (s.X < e.X)
            {
                if (s.Y < e.Y)
                {

                }
                else
                {
                    ang = 360 - ang;
                }
            }
            else
            {
                if (s.Y < e.Y)
                {
                    ang = 180 - ang;
                }
                else
                {
                    ang = 180 + ang;
                }
            }
            return ang;
        }

        public static Point Transform(Point s, double length, double angle)
        {
            return new Point()
            {
                X = s.X + length * Math.Cos(angle * Math.PI / 180),
                Y = s.Y + length * Math.Sin(angle * Math.PI / 180)
            };
        }

        //private void floorplan_PointerMoved(object sender, PointerRoutedEventArgs e)
        //{
        //    if (e.Pointer.IsInContact && !infoSizeRotate)
        //    {
        //        UpdateInfo(size: true);
        //    }
        //}

        //private void thumb_ResizeStarting(object sender, DiagramThumbDragEventArgs args)
        //{
        //    UpdateInfo(size: true);
        //}

        //private void thumb_ResizeComplete(object sender, DiagramThumbDragEventArgs args)
        //{
        //    UpdateInfo();
        //}

        //private void thumb_RotateStarting(object sender, DiagramThumbDragEventArgs args)
        //{
        //    UpdateInfo(angle: true);
        //}

        //private void UpdateInfo(bool size = false, bool angle = false, bool pos = false)
        //{
        //    CustomSelector sel = this.floorplan.SelectedItems as CustomSelector;
        //    ISelectorInfo info = sel.Info as ISelectorInfo;
        //    if (size)
        //    {
        ////        infoSizeRotate = true;
        ////        string val = info.ActualWidth.Feetwithinches();
        ////        string val1 = info.ActualHeight.Feetwithinches();
        ////        sel.Information = "W: " + val + ", H: " + val1;
        ////    }
        ////    else if (angle)
        ////    {
        ////        infoSizeRotate = true;
        ////        sel.Information = "Angle: " + (int)sel.RotateAngle % 360;
        ////    }
        ////    else if (pos)
        ////    {
        ////        infoSizeRotate = false;
        ////        //string x = c.Feetwithinches();
        ////        //string y = info.OffsetY.Feetwithinches();
        ////        // sel.Information = "X: " + (int)info.OffsetX + ", Y: " + (int)info.OffsetY;
        ////    }
        ////    else
        ////    {
        ////        infoSizeRotate = false;
        ////        sel.Information = "";
        ////    }
        ////}

        //private void thumb_RotateComplete(object sender, DiagramThumbDragEventArgs args)
        //{
        //    UpdateInfo();
        //}
        #endregion

        #region TestPurpose
        void FloorPlannerDiagram_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                FloorPlanNode node = e.NewItems[0] as FloorPlanNode;
                node.Background = new SolidColorBrush(Colors.Transparent);
                node.Loaded += node_Loaded;
                node.PropertyChanged += node_PropertyChanged;
                if (node.ContentName != null)
                {
                    node.Content = node.ContentName;
                }
                UpdateOptionnode(null);
                if (p != null)
                {
                    p.IsOpen = false;
                }
                if (textNodeAdded)
                {
                    //PropertyEditor.Height = 500;
                    //tabControl.Height = 0;
                    textNodeAdded = false;
                }
            }
            else
            {

            }
        }

        void node_Loaded(object sender, RoutedEventArgs e)
        {
            if ((sender as FloorPlanNode).Content != null)
            {
                if ((sender as FloorPlanNode).IsShapeNode)
                {
                    (sender as FloorPlanNode).ContentName = (sender as FloorPlanNode).Content.ToString();
                    if (Enum.GetNames(typeof(BasicShapes)).Any(w => w == (sender as FloorPlanNode).Content.ToString()))
                    {
                        (sender as FloorPlanNode).IsShapeNode = true;

                        foreach (BasicShapes b in Enum.GetValues(typeof(BasicShapes)))
                        {
                            if (b.ToString() == (sender as FloorPlanNode).Content.ToString())
                            {
                                (sender as FloorPlanNode).Shape = Geometry.Parse(ShapeHelper.GeometryDictionary[b]);
                                (sender as FloorPlanNode).ShapeStyle = GetStyle("#FFFFFFFF");
                            }
                        }
                        (sender as FloorPlanNode).Content = null;
                        (sender as FloorPlanNode).ContentTemplate = null;
                    }
                }
                else
                {
                    if (!(sender as FloorPlanNode).IsTextNode)
                    {

                        (sender as FloorPlanNode).ContentName = (sender as FloorPlanNode).Content.ToString();
                    }
                }
                if ((sender as FloorPlanNode).ContentName == "Window")
                {

                    // node.Width = 5;
                    (sender as FloorPlanNode).UnitHeight = 6;
                }
            }
        }

        private Style GetStyle(string p)
        {
            Style s = new Style(typeof(SPath));
            s.Setters.Add(new Setter(SPath.StrokeProperty, ColorConverter("#FFC4C4C4")));
            s.Setters.Add(new Setter(SPath.FillProperty, ColorConverter(p)));
            s.Setters.Add(new Setter(SPath.StretchProperty, Stretch.Fill));
            s.Setters.Add(new Setter(SPath.StrokeThicknessProperty, 2d));
            return s;
        }

        void node_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Content")
            {
                (sender as FloorPlanNode).ContentName = (sender as FloorPlanNode).Content.ToString();
                if ((sender as FloorPlanNode).ContentName == "Window")
                {
                    // node.Width = 5;
                    (sender as FloorPlanNode).UnitHeight = 6;
                }
            }
            else if (e.PropertyName == "SelectedColor")
            {
                (sender as FloorPlanNode).ShapeStyle = GetStyle((sender as FloorPlanNode).SelectedColor.ToString());
            }
        }

        //void node_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        //{
        //    if ((sender as FloorPlanNode).Content.ToString() == "Door" || (sender as FloorPlanNode).Content.ToString() == "Door1")
        //    {

        //        FloorPlanConnector Hconn = null;
        //        foreach (FloorPlanConnector con in _connectors)
        //        {
        //            if (Math.Round(con.SourcePoint.Y) > Math.Round(con.TargetPoint.Y) || Math.Round(con.SourcePoint.Y) < Math.Round(con.TargetPoint.Y))
        //            {
        //                if (Math.Round((con.SourcePoint.X) - ((sender as FloorPlanNode).OffsetX - ((sender as FloorPlanNode).UnitWidth / 2))) <= 25)
        //                {
        //                    (sender as FloorPlanNode).OffsetX = con.SourcePoint.X - ((sender as FloorPlanNode).UnitWidth / 2);
        //                    (sender as FloorPlanNode).OffsetY = (con.SourcePoint.Y + con.TargetPoint.Y) / 2;
        //                    Hconn = con;
        //                }
        //            }
        //            else if (Math.Round(con.SourcePoint.X) < Math.Round(con.TargetPoint.X))
        //            {
        //                if (Math.Round((con.SourcePoint.Y) - ((sender as FloorPlanNode).OffsetY - ((sender as FloorPlanNode).UnitHeight / 2))) <= 25)
        //                {
        //                    (sender as FloorPlanNode).OffsetY = con.SourcePoint.Y - ((sender as FloorPlanNode).UnitHeight / 2);
        //                    (sender as FloorPlanNode).OffsetX = (con.SourcePoint.X + con.TargetPoint.X) / 2;
        //                    Hconn = con;
        //                }
        //            }

        //            if (Hconn != null)
        //            {
        //                return;
        //            }

        //        }
        //    }
        //}

        //void node_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        //{

        //}

        //void node_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        //{

        //}

        //private bool Filter(Syncfusion.UI.Xaml.Diagram.Stencil.SymbolFilterProvider sender, Syncfusion.UI.Xaml.Diagram.Stencil.ISymbol symbol)
        //{
        //    return true;
        //}

        private void CreateNodes()
        {
            Node singlebed = AddNode(Shapes.SingleBed, 400, 250, 100, 50, "#FFEA8C1C");
            Node singlebed1 = AddNode(Shapes.SingleBed, 400, 450, 100, 50, "#FF2D8BBA");
            Node doublebed = AddNode(Shapes.DoubleBed, 600, 250, 100, 80, "#FF749E19");
            Node doublebed1 = AddNode(Shapes.DoubleBed, 900, 250, 100, 80, "#FFC93667");
            Node dinningNode = AddNode(Shapes.DinningTable, 610, 450, 50, 100, "#FF5B1B02");
            Node chairNode = AddNode(Shapes.Chair, 560, 450, 15, 12, "#FFBA8E2A");
            Node chairNode1 = AddNode(Shapes.Chair, 690, 450, 15, 12, "#FFBA8E2A");
            Node chairNode2 = AddNode(Shapes.Chair, 585, 420, 15, 12, "#FFBA8E2A");
            Node chairNode3 = AddNode(Shapes.Chair, 615, 420, 15, 12, "#FFBA8E2A");
            Node chairNode4 = AddNode(Shapes.Chair, 645, 420, 15, 12, "#FFBA8E2A");
            Node chairNode5 = AddNode(Shapes.Chair, 585, 480, 15, 12, "#FFBA8E2A");
            Node chairNode6 = AddNode(Shapes.Chair, 615, 480, 15, 12, "#FFBA8E2A");
            Node chairNode7 = AddNode(Shapes.Chair, 645, 480, 15, 12, "#FFBA8E2A");
            Node SofaNode = AddNode(Shapes.CenterSofa, 625, 600, 50, 100, "sofa");
            Node sofaNode1 = AddNode(Shapes.SideSofa, 550, 700, 50, 50, "sofa");
            Node sofanode2 = AddNode(Shapes.SideSofa, 700, 700, 50, 50, "sofa");
            Node tablenode = AddNode(Shapes.Table, 625, 700, 50, 80, "sofa");
        }

        private Node AddNode(Shapes shapes, double offx, double offy, double hei, double wid, string color)
        {
            FloorPlanNode n = new FloorPlanNode();
            n.UnitWidth = wid;
            n.UnitHeight = hei;
            n.OffsetX = offx;
            n.OffsetY = offy;
            //Shape = shapes.ToGeometry(),
            n.ShapeStyle = GetBedStyle(color);
            _nodes.Add(n);
            return n;
        }

        private Brush ColorConverter(string hexaColor)
        {
            if (hexaColor != null)
            {
                if (hexaColor.StartsWith("#"))
                {
                    byte r = Convert.ToByte(hexaColor.Substring(1, 2), 16);
                    byte g = Convert.ToByte(hexaColor.Substring(3, 2), 16);
                    byte b = Convert.ToByte(hexaColor.Substring(5, 2), 16);
                    byte a = Convert.ToByte(hexaColor.Substring(7, 2), 16);
                    SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(r, g, b, a));
                    return myBrush;
                }
                else
                {
                    return this.Resources["sofa"] as LinearGradientBrush;
                }
            }
            return null;
        }

        private Style GetBedStyle(string colorvalue)
        {
            Style s = new Style();
            s.TargetType = typeof(SPath);
            s.Setters.Add(new Setter(SPath.FillProperty, ColorConverter(colorvalue)));
            s.Setters.Add(new Setter(SPath.StretchProperty, Stretch.Fill));
            return s;
        }

        private void con_Click_1(object sender, RoutedEventArgs e)
        {
            FloorPlanConnector c = new FloorPlanConnector()

            {
                SourcePoint = new Point(200, 200),
                TargetPoint = new Point(400, 200)

            };
            c.TargetDecorator = null;
            _connectors.Add(c);
        }



        private void del_Click_1(object sender, RoutedEventArgs e)
        {
            if (floorplan.SelectedItems != null)
            {
                if ((floorplan.SelectedItems as CustomSelector).Nodes != null)
                {
                    ObservableCollection<FloorPlanNode> v = new ObservableCollection<FloorPlanNode>();
                    foreach (FloorPlanNode fnode in (IEnumerable<object>)(floorplan.SelectedItems as CustomSelector).Nodes)
                    {
                        v.Add(fnode);
                    }

                    foreach (FloorPlanNode fnode in v)
                    {
                        _nodes.Remove(fnode);
                    }
                }
                if ((floorplan.SelectedItems as CustomSelector).Connectors != null)
                {
                    ObservableCollection<FloorPlanConnector> c = new ObservableCollection<FloorPlanConnector>();
                    foreach (FloorPlanConnector fnode in (IEnumerable<object>)(floorplan.SelectedItems as CustomSelector).Connectors)
                    {
                        c.Add(fnode);
                    }

                    foreach (FloorPlanConnector fnode in c)
                    {
                        _connectors.Remove(fnode);
                    }
                }
            }
        }
        #endregion

        private void back_clicked(object sender, MouseButtonEventArgs e)
        {
            this.FloorPlannerViewModel.Back.Execute(null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textNodeAdded = true;
        }
    }


    public class CustomSelector : SelectorViewModel
    {
        public IGraph Graph { get; set; }

        public CustomSelector()
        {
            this.Nodes = new ObservableCollection<object>();
            this.Connectors = new ObservableCollection<object>();
            this.Groups = new ObservableCollection<object>();
            //Information = "Test";
            InfoVis = Visibility.Collapsed;
        }

        private bool allowdelete;

        public bool AllowDelete
        {
            get
            {
                return allowdelete;
            }
            set
            {
                if (allowdelete != value)
                {
                    allowdelete = value;
                    OnPropertyChanged("AllowDelete");
                }
            }
        }
        private IGroupable _SelectedObject;
        public IGroupable SelectedObject
        {
            get { return _SelectedObject; }
            set
            {
                _SelectedObject = value;

                OnPropertyChanged("SelectedObject");
            }
        }

        //private string _information;
        private Visibility _infoVis;

        //public string Information
        //{
        //    get { return _information; }
        //    set
        //    {
        //        _information = value;
        //        OnPropertyChanged("Information");
        //        if (string.IsNullOrEmpty(value))
        //        {
        //            InfoVis = Visibility.Collapsed;
        //        }
        //        else
        //        {
        //            InfoVis = Visibility.Visible;
        //        }
        //    }
        //}

        public Visibility InfoVis
        {
            get { return _infoVis; }
            set { _infoVis = value; OnPropertyChanged("InfoVis"); }
        }
    }

    public static class StringExtensions
    {
        public static string Feetwithinches(this double display)
        {
            int defaultvalue = 50;
            var value = display / defaultvalue;
            var feet = Math.Floor(value);
            var inches = Math.Round((value - feet) * 12);
            return feet + "'" + inches + "''";
        }
    }

}
