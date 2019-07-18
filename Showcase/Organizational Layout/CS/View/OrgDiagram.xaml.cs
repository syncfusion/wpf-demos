#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Layout;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Utility;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;
using ScrollViewer = Syncfusion.UI.Xaml.Diagram.Controls.ScrollViewer;
using System.Xml.Linq;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Data;
using System.Windows.Controls.Primitives;
using System.Windows.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OrganizationalChartDemo
{
 public sealed partial class OrgDiagram : UserControl
    {
        #region Variables
        object PreviousSelectedItem = null;
        object CurrentItem = null;
        object PreviousItem = null;
        int click = -1;
        Stack<OrgNodeViewModel> previousstack = null;
        IEnumerator<OrgNodeViewModel> previous = null;
        Storyboard sb1;
        private object ClickedItem = "";
        Storyboard sb = null;
        #endregion

        public OrgDiagram()
        {
            this.InitializeComponent();

            InitializeEvents();
            //Style for Selector
            sfdiagram.SFSelector.Style = this.Resources["CustomSelector"] as Style;
        
            //Assign null to Menu
             sfdiagram.Menu = null;
            //ScrollLimit to decide Scrolling Limitation
            sfdiagram.ScrollSettings.ScrollLimit  = ScrollLimit.Diagram;
            //Page Customization
            sfdiagram.PageSettings.PageBorderBrush = new SolidColorBrush(Colors.Transparent);

            sfdiagram.Constraints &= ~ (GraphConstraints.PanRails);
            sfdiagram.AnnotationConstraints &= ~AnnotationConstraints.Editable;
            sfdiagram.Tool = Tool.ZoomPan;
        }

        private void InitializeEvents()
        {
            IGraphInfo graphInfo = sfdiagram.Info as IGraphInfo;
            //Tapped Event for Diagram (Item-Node or Connector)
            graphInfo.ItemTappedEvent += sfdiagram_ItemTappedEvent;

            //Events for SfDiagram
            sfdiagram.MouseMove += sfdiagram_PointerMoved;

            //To Clear Values
            sfdiagram.Loaded+=sfdiagram_Loaded;
            this.Loaded += OrgDiagram_Loaded;
            this.Unloaded += OrgDiagram_Unloaded;
        }

        #region Events

        private void Node_PointerEntered_1(object sender, MouseEventArgs e)
        {            
            if ((((sender as Node).DataContext as OrgNodeViewModel).Content as Employee).IsFocus != NodeFocusState.Focused)
            {
                (((sender as Node).DataContext as OrgNodeViewModel).Content as Employee).IsFocus = NodeFocusState.MouseHover;
            }

            foreach (OrgNodeViewModel n in ((IEnumerable<object>)sfdiagram.Nodes).OfType<OrgNodeViewModel>())
            {
                if (n != (sender as Node).DataContext as OrgNodeViewModel)
                {
                    n.CustomToolTip.IsOpen = false;
                }
            }
        }

        private void Node_PointerExited_1(object sender, MouseEventArgs e)
        {           
            if ((((sender as Node).DataContext as OrgNodeViewModel).CustomToolTip as Popup) != null)
            {
                (((sender as Node).DataContext as OrgNodeViewModel).CustomToolTip as Popup).IsOpen = false;
            }
            if ((((sender as Node).DataContext as OrgNodeViewModel).Content as Employee).IsFocus != NodeFocusState.Focused)
            {
                (((sender as Node).DataContext as OrgNodeViewModel).Content as Employee).IsFocus = NodeFocusState.Normal;
            }
        }

        private void Node_PointerPressed_1(object sender, MouseEventArgs e)
        {
            if ((((sender as Node).DataContext as OrgNodeViewModel).CustomToolTip as Popup) != null)
            {
                (((sender as Node).DataContext as OrgNodeViewModel).CustomToolTip as Popup).IsOpen = false;
            }
        }


        void sfdiagram_PointerMoved(object sender, System.Windows.Input.MouseEventArgs e)
        {
            onUpdate();
        }

        void OrgDiagram_Unloaded(object sender, RoutedEventArgs e)
        {
            sfdiagram.LayoutManager = null;
            //sfdiagram.ViewDictionary = null;
            this.Unloaded -= OrgDiagram_Unloaded;
            IGraphInfo graphInfo =sfdiagram.Info as IGraphInfo;
            ;
            foreach (IConnector connector in (IEnumerable<object>)sfdiagram.Connectors)
            {
                connector.SourceNode = null;
                connector.TargetNode = null;
            }

            foreach (FrameworkElement child in sfdiagram.Page.Children)
            {
                if (child is Node)
                {
                    OrgNodeViewModel vm = child.DataContext as OrgNodeViewModel;
                    if (vm != null)
                    {
                        vm.CustomToolTip = null;
                    }
                    child.MouseEnter -= Node_PointerEntered_1;
                    child.MouseLeave -= Node_PointerExited_1;
                    child.MouseLeftButtonDown -= Node_PointerPressed_1;
                }
                child.DataContext = null;
            }

            sfdiagram.Nodes = null;
            sfdiagram.Connectors = null;

            SelectorViewModel selec = sfdiagram.SelectedItems as SelectorViewModel;
            if (selec != null)
            {
                selec.Connectors = null;
                selec.Nodes = null;
                selec.Groups = null;
            }
            sfdiagram.DataContext = null;
            sfdiagram.SFSelector = null;
            sfdiagram.SelectedItems = null;
            this.DataContext = null;
            DiagramCommand.SetCommand(sfdiagram, null);

            this.Loaded -= OrgDiagram_Loaded;
            this.Unloaded -= OrgDiagram_Unloaded;
            if (sfdiagram != null)
            {
                sfdiagram.Loaded -= sfdiagram_Loaded;
                sfdiagram.MouseMove -= sfdiagram_PointerMoved;
            }
        }

        void OrgDiagram_Loaded(object sender, RoutedEventArgs e)
        {            
            this.Loaded -= OrgDiagram_Loaded;
            foreach (FrameworkElement child in sfdiagram.Page.Children)
            {
                if (child is Node && !(child is Syncfusion.UI.Xaml.Diagram.Selector))
                {
                    child.MouseEnter += Node_PointerEntered_1;
                    child.MouseLeave += Node_PointerExited_1;
                    child.MouseLeftButtonDown += Node_PointerPressed_1;

                    Binding vis = new Binding();
                    vis.Path = new PropertyPath("Visible");
                    vis.Mode = BindingMode.TwoWay;
                    vis.Converter = new BoolToVisibiltyConverter();
                    child.SetBinding(Node.VisibilityProperty, vis);
                }
                else if (child is Connector)
                {
                    Binding bin = new Binding();
                    bin.Path = new PropertyPath("Visible");
                    bin.Mode = BindingMode.TwoWay;
                    bin.Converter = new BoolToVisibiltyConverter();
                    child.SetBinding(Connector.VisibilityProperty, bin);


                    bin = new Binding();
                    bin.Path = new PropertyPath("ConnectorOpacity");
                    child.SetBinding(Connector.OpacityProperty, bin);
                }
            }
        }

        //Collection Changed Event of Node
        void OrgDiagram_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                if (e.NewItems[0] is OrgNodeViewModel)
                {
                    ChartViewModel.NodeCollection.Add(e.NewItems[0] as OrgNodeViewModel);
                    (e.NewItems[0] as OrgNodeViewModel).PropertyChanged += OrgDiagram_PropertyChanged;
                }
            }
        }
        //Property Changed Event of Node
        void OrgDiagram_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            NodeViewModel n = (sender as NodeViewModel);
            if (e.PropertyName.Equals("Content"))
            {
                (n.Content as Employee).PathClickCommand = new DelegateCommand<object>(OnPress, argus => { return true; });
            }
        }

        void sfdiagram_ItemTappedEvent(object sender, DiagramEventArgs args)
        {
            if (args.Item is INode)
            {
                if ((args.Item as OrgNodeViewModel).Content is Employee)
                {

                    if (PreviousSelectedItem != null)
                    {
                        ((PreviousSelectedItem as OrgNodeViewModel).Content as Employee).IsFocus = NodeFocusState.Normal;
                     }
                    ChartViewModel.SelectedObject = (args.Item as OrgNodeViewModel);
                    ((ChartViewModel.SelectedObject as OrgNodeViewModel).Content as Employee).IsFocus = NodeFocusState.Focused;
                     PreviousSelectedItem = ChartViewModel.SelectedObject;

                }
                HidePopup((args.Item as OrgNodeViewModel));
            }
            if (args.Item is OrgNodeViewModel)
            {
                ExpandCollapseParameter obj = new ExpandCollapseParameter();
                obj.node = (args.Item as INode);
                obj.IsUpdateLayout = true;
                IGraphInfo graphinfo = sfdiagram.Info as IGraphInfo;
                ChartViewModel.SelectedObject = (args.Item as OrgNodeViewModel);
                if (((args.Item as OrgNodeViewModel).Content as Employee).IsExpand == State.Expand)
                {
                    ((args.Item as OrgNodeViewModel).Content as Employee).IsExpand = State.Collapse;
                    graphinfo.Commands.ExpandCollapse.Execute(obj);

                }
                else if (((args.Item as OrgNodeViewModel).Content as Employee).IsExpand == State.Collapse)
                {
                    ((args.Item as OrgNodeViewModel).Content as Employee).IsExpand = State.Expand;
                    graphinfo.Commands.ExpandCollapse.Execute(obj);
                }

                CheckSearch((sender as OrgChartDiagram));
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

        private void OnPress(object obj)
        {

            if (PreviousSelectedItem != null)
            {
                ((PreviousSelectedItem as OrgNodeViewModel).Content as Employee).IsFocus = NodeFocusState.Normal;
            }

            if (obj != null && obj is System.Windows.Shapes.Path)
            {
                Employee dc = (Employee)(obj as System.Windows.Shapes.Path).DataContext;

                foreach (Node n in sfdiagram.Page.Children.OfType<Node>())
                {
                    if (((n.DataContext as OrgNodeViewModel).Content as Employee) == dc)
                    {
                        ChartViewModel.SelectedObject = (n as Node).DataContext as OrgNodeViewModel;
                        ((ChartViewModel.SelectedObject as OrgNodeViewModel).Content as Employee).IsFocus = NodeFocusState.Focused;
                        PreviousSelectedItem = ChartViewModel.SelectedObject;

                    }
                }
            }
            if (ChartViewModel.SelectedObject != null && ChartViewModel.SelectedObject is OrgNodeViewModel)
            {
                if ((ChartViewModel.SelectedObject as OrgNodeViewModel).Content is Employee)
                {
                    if (((ChartViewModel.SelectedObject as OrgNodeViewModel).Content as Employee).IsExpand == State.Expand)
                    {
                        ((ChartViewModel.SelectedObject as OrgNodeViewModel).Content as Employee).IsExpand = State.Collapse;
                        (ChartViewModel.SelectedObject as OrgNodeViewModel).IsExpanded = false;
                        Hide((ChartViewModel.SelectedObject as OrgNodeViewModel));
                    }
                    else if (((ChartViewModel.SelectedObject as OrgNodeViewModel).Content as Employee).IsExpand == State.Collapse)
                    {
                        ((ChartViewModel.SelectedObject as OrgNodeViewModel).Content as Employee).IsExpand = State.Expand;
                        (ChartViewModel.SelectedObject as OrgNodeViewModel).IsExpanded = true;
                        Show((ChartViewModel.SelectedObject as OrgNodeViewModel));
                    }
                    UpdateLayout(ChartViewModel.SelectedObject as OrgNodeViewModel);
                    CheckSearch((sfdiagram as OrgChartDiagram));
                }
            }
            HidePopup((ChartViewModel.SelectedObject as OrgNodeViewModel));
        }

        void sfdiagram_Loaded(object sender, RoutedEventArgs e)
        {
            GetScrollViewer((sender as SfDiagram));
                       
            (sfdiagram.Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParamenter()
            {
                ZoomTo = 0.8,
                ZoomCommand = ZoomCommand.ZoomOut
            });
        }

        private bool GetScrollViewer(DependencyObject sfd)
        {
            if (sfd is ScrollViewer)
            {
                (this.DataContext as ChartViewModel).ScrollViewer = (sfd as ScrollViewer);
                return true;
            }
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(sfd); i++)
            {
                if (GetScrollViewer(VisualTreeHelper.GetChild(sfd, i)))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Commands

        private void UpdateCollection()
        {
            DataSourceSettings settings = new DataSourceSettings();
            settings.ParentId = "ReportingPerson";
            settings.Id = "Name";
            sfdiagram.Nodes = new DiagramCollection<OrgNodeViewModel>();
            sfdiagram.Connectors = new DiagramCollection<OrgConnectorViewModel>();
            (sfdiagram.Nodes as DiagramCollection<OrgNodeViewModel>).CollectionChanged += OrgDiagram_CollectionChanged;

            ObservableCollection<Employee> employee = new ObservableCollection<Employee>();
            XDocument loadedData = XDocument.Load(".//Employee.xml");

            foreach (var item in loadedData.Descendants("Employee"))
            {
                employee.Add(new Employee()
                    {
                        Name = item.Attribute("Name").Value,
                        Destination = item.Attribute("Destination").Value,
                        Doj = item.Attribute("Doj").Value,
                        ImageUrl = item.Attribute("ImageUrl").Value,
                        RatingColor = item.Attribute("RatingColor").Value,
                        Salary = Convert.ToDouble(item.Attribute("Salary").Value),
                        IsExpand = returnValue(item.Attribute("IsExpand").Value),
                        ReportingPerson = IsCheck(item.Attribute("ReportingPerson"))

                    });
            }

            settings.DataSource = employee;
            sfdiagram.DataSourceSettings = settings;
            sfdiagram.LayoutManager = new Syncfusion.UI.Xaml.Diagram.Layout.LayoutManager()
            {
                Layout = new DirectedTreeLayout()
                {
                    Type = Syncfusion.UI.Xaml.Diagram.Layout.LayoutType.Organization,
                    HorizontalSpacing = 25,
                    VerticalSpacing = 35,
                    SpaceBetweenSubTrees = 20, 
                }
            };
            (sfdiagram.Info as IGraphInfo).GetLayoutInfo += OrgDiagram_GetLayoutInfo;
        }

        void OrgDiagram_GetLayoutInfo(object sender, LayoutInfoArgs args)
        {
                bool _mchildren = false;
                if ((args.Item.Info as INodeInfo).OutConnectors.Count() > 0)
                {
                    foreach (var item in (args.Item.Info as INodeInfo).OutNeighbors)
                    {
                        if ((item.Info as INodeInfo).OutConnectors.Count() > 0)
                        {
                            _mchildren = false;
                            break;
                        }
                        else
                            _mchildren = true;
                    }
                }

                if (_mchildren)
                    args.Type = ChartType.Right;
                else
                    args.Type = ChartType.Alternate;
               
                  
        }
     
      private string IsCheck(XAttribute xAttribute)
        {
            if (xAttribute == null)
            {
                return string.Empty;
            }

            return xAttribute.Value;
        }

        private State returnValue(string p)
        {
            foreach (State s in Enum.GetValues(typeof(State)))
            {
                if (s.ToString() == p)
                {
                    return s;
                }
            }
            return State.None;
        }
  
        private Style GetStyle(SolidColorBrush fill)
        {
            Style s = new Style(typeof(System.Windows.Shapes.Path));
            s.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, fill));
            s.Setters.Add(new Setter(System.Windows.Shapes.Path.StretchProperty, Stretch.Fill));
            return s;
        }

        private void OnSearch(object obj)
        {
            if (ChartViewModel.SelectedObject != null)
            {
                ((ChartViewModel.SelectedObject as OrgNodeViewModel).Content as Employee).IsFocus = NodeFocusState.Normal;
            }
            if (searchgrid.Visibility == Visibility.Visible)
            {
                searchgrid.Visibility = Visibility.Collapsed;
            }
            else
            {
                searchgrid.Visibility = Visibility.Visible;
            }
            ChartViewModel.Searchview = new SearchViewModel();
            Searchcombo.ClearValue(ComboBox.SelectedIndexProperty);
            textbox.Text = "";
            ChartViewModel.SearchVisibility = Visibility.Visible;
            foreach (OrgNodeViewModel org in ((IEnumerable<object>)sfdiagram.Nodes).OfType<OrgNodeViewModel>())
            {
                if ((org.Content as Employee).IsFocus == NodeFocusState.Focused || ((org as OrgNodeViewModel).Content as Employee).IsSearched==true)
                {
                    (org.Content as Employee).IsFocus = NodeFocusState.Normal;
                    ((org as OrgNodeViewModel).Content as Employee).IsSearched = false;
                    HidePopup(org as OrgNodeViewModel);
                }
            }

        }

        private void OnNext(object obj)
        {
            if (obj.ToString() == "Next")
            {
                click += 1;
                if (ChartViewModel.Item == null)
                {
                    if (CurrentItem != null)
                    {
                        ((CurrentItem as OrgNodeViewModel).Content as Employee).IsFocus = NodeFocusState.Normal;
                    }
                    if (PreviousItem != null)
                    {
                        ((PreviousItem as OrgNodeViewModel).Content as Employee).IsFocus = NodeFocusState.Normal;

                    }
                    ChartViewModel.StartSearch();
                    ChartViewModel.Item = ChartViewModel.Searchview.SearchResult.GetEnumerator();
                    MoveNext();
                    previousstack = new Stack<OrgNodeViewModel>();
                }
                else
                {
                    PreviousItem = CurrentItem;
                    if (PreviousItem != null)
                    {
                        ((PreviousItem as OrgNodeViewModel).Content as Employee).IsFocus = NodeFocusState.Normal;
                    }

                    if (PreviousItem != null && previousstack != null)
                    {
                        ((PreviousItem as OrgNodeViewModel).Content as Employee).IsFocus = NodeFocusState.Normal;
                        if (!previousstack.Contains((PreviousItem as OrgNodeViewModel)))
                        {
                            (previousstack as Stack<OrgNodeViewModel>).Push((PreviousItem as OrgNodeViewModel));
                        }
                    }
                    MoveNext();
                    if (CurrentItem == null)
                    {
                        ChartViewModel.Item.Reset();
                        MoveNext();
                    }
                }
            }
            else if (obj.ToString() == "Previous")
            {
                if (previousstack == null)
                {
                    previousstack = new Stack<OrgNodeViewModel>();
                    foreach (var item in ChartViewModel.Searchview.SearchResult)
                    {
                        previousstack.Push(item as OrgNodeViewModel);
                    }
                }
                if (previousstack != null && previousstack.Count > 0)
                {
                    if (CurrentItem != null)
                    {
                        ((CurrentItem as OrgNodeViewModel).Content as Employee).IsFocus = NodeFocusState.Normal;
                    }
                    if (previous == null)
                    {
                        previous = previousstack.GetEnumerator();
                        MovePrevious();
                    }
                    else
                    {
                        PreviousItem = previous.Current;
                        if (previous.Current != null)
                        {
                            if (previousstack.Last<OrgNodeViewModel>() == previous.Current)
                            {
                                ((PreviousItem as OrgNodeViewModel).Content as Employee).IsFocus = NodeFocusState.Normal;
                                previous.Reset();
                            }
                            else
                            {
                                ((PreviousItem as OrgNodeViewModel).Content as Employee).IsFocus = NodeFocusState.Normal;
                            }

                        }
                        else
                        {
                            previous.Reset();
                        }
                        MovePrevious();
                    }
                }

            }
        }

        private void MoveNext()
        {
            ChartViewModel.Item.MoveNext();
            CurrentItem = ChartViewModel.Item.Current;
            if (CurrentItem != null)
            {
                ((CurrentItem as OrgNodeViewModel).Content as Employee).IsFocus = NodeFocusState.Focused;
                (ChartViewModel.ScrollViewer as ScrollViewer).BringIntoCenter(((CurrentItem as OrgNodeViewModel).Info as INodeInfo).Bounds);
            }
        }

        private void MovePrevious()
        {
            previous.MoveNext();
            OrgNodeViewModel org = previous.Current;
            if (org != null)
            {
                ((org as OrgNodeViewModel).Content as Employee).IsSearched = true;
                ((org as OrgNodeViewModel).Content as Employee).IsFocus = NodeFocusState.Focused;
                (ChartViewModel.ScrollViewer as ScrollViewer).BringIntoCenter(((org as OrgNodeViewModel).Info as INodeInfo).Bounds);
            }
        }

        private void CheckSearcheItem()
        {
            foreach (var o in (ChartViewModel.Searchview as SearchViewModel).SearchResult)
            {
                if ((o.Content as Employee).IsSearched)
                {
                    (o.Content as Employee).IsSearched = false;
                    (o.Content as Employee).IsFocus = NodeFocusState.Normal;
                }
            }
        }

        private void OnPrevious(object obj)
        {
            if ((ChartViewModel.Searchview as SearchViewModel).SearchResult.Count > 0)
            {
                if (ChartViewModel.ScrollViewer != null)
                {
                    if (click < 0 || click >= (ChartViewModel.Searchview as SearchViewModel).SearchResult.Count - 1)
                    {
                        click = 0;
                    }
                    CheckSearcheItem();
                    if (click >= 0)
                    {
                        OrgNodeViewModel org = ((ChartViewModel.Searchview as SearchViewModel).SearchResult[click] as OrgNodeViewModel);
                        (ChartViewModel.ScrollViewer as ScrollViewer).BringIntoCenter((org.Info as INodeInfo).Bounds);
                        (org.Content as Employee).IsSearched = true;
                    }
                }
            }
        }

        private void onUpdate()
        {
            (this.ChartViewModel.ScrollViewer as ScrollViewer).MaxZoom = 2;
            (this.ChartViewModel.ScrollViewer as ScrollViewer).MinZoom = 0.4;
            if ((this.ChartViewModel.ScrollViewer as ScrollViewer).CurrentZoom >= 0.8)
            {
                foreach (INode org in sfdiagram.Page.Children.OfType<INode>())
                {
                    org.ContentTemplate = App.Current.Resources["employeeContentTemplate"] as DataTemplate;
                }
            }
            else if ((this.ChartViewModel.ScrollViewer as ScrollViewer).CurrentZoom < 0.6)
            {
                foreach (INode org in sfdiagram.Page.Children.OfType<INode>())
                {
                    org.ContentTemplate = App.Current.Resources["ZoomOutContentTemplate"] as DataTemplate;
                }
            }
        }

        public ChartViewModel ChartViewModel
        {
            get { return (ChartViewModel)GetValue(ChartViewModelProperty); }
            set { SetValue(ChartViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChartViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChartViewModelProperty =
            DependencyProperty.Register("ChartViewModel", typeof(ChartViewModel), typeof(OrgDiagram), new PropertyMetadata(null, OnPropertyChangedCallBack));

        private static void OnPropertyChangedCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            OrgDiagram diagram = d as OrgDiagram;

            ChartViewModel chartvm = e.NewValue as ChartViewModel;
            diagram.UpdateCollection();
            chartvm.Previous = new DelegateCommand<object>(diagram.OnPrevious, args => { return true; });
            chartvm.Next = new DelegateCommand<object>(diagram.OnNext, args => { return true; });
            chartvm.Search = new DelegateCommand<object>(diagram.OnSearch, args => { return true; });
        }
        #endregion

        #region ManipulationEvent

        private void HidePopup(OrgNodeViewModel node)
        {
            if (node != null)
            {
                if (((node as OrgNodeViewModel).CustomToolTip as Popup) != null)
                {
                    ((node as OrgNodeViewModel).CustomToolTip as Popup).IsOpen = false;
                }
            }
        }

         #endregion

        #region Helper Functions

        //Expands the Child Nodes
        private void Show(OrgNodeViewModel n)
        {
            if ((n.Content as Employee).IsExpand == State.Expand)
            {
                foreach (OrgConnectorViewModel con in (n.Info as INodeInfo).OutConnectors)
                {
                    foreach (Connector line in sfdiagram.Page.Children.OfType<Connector>())
                    {
                        if (line.DataContext == con)
                        {
                            ExpandAnimation(line);
                        }
                    }
                    con.Visible = true;

                    foreach (Node n1 in sfdiagram.Page.Children.OfType<Node>())
                    {
                        if ((con.TargetNode as OrgNodeViewModel) == n1.DataContext)
                        {
                            ExpandAnimation(n1);
                        }
                    }
                    (con.TargetNode as OrgNodeViewModel).Visible = true;
                    Show((con.TargetNode as OrgNodeViewModel));
                }
            }
        }

        //Collapses the Child Nodes
        private void Hide(OrgNodeViewModel n)
        {
            foreach (OrgNodeViewModel node in sfdiagram.Page.Children.OfType<Connector>()
                                  .Where(connector => (connector.SourceNode as OrgNodeViewModel) == n)
                                  .Select(connector => (connector.TargetNode as OrgNodeViewModel)))
            {
                foreach (Connector line in sfdiagram.Page.Children.OfType<Connector>()
                                  .Where(connector => connector.TargetNode == node || connector.SourceNode == node))
                {
                   (line.DataContext as OrgConnectorViewModel).Visible = false;
                    CollapseAnimation(line);
                }

                foreach (Node v in sfdiagram.Page.Children.OfType<Node>())
                {
                    if (v.DataContext == node)
                    {
                        CollapseAnimation(v);
                        (v.DataContext as OrgNodeViewModel).Visible = false;
                    }
                }
                Hide(node);
            }
        }

        private void ExpandAnimation(DependencyObject obj)
        {
            Duration duration = new Duration(TimeSpan.FromMilliseconds(300));
            DoubleAnimation myDoubleAnimation1 = new DoubleAnimation();
            myDoubleAnimation1.Duration = duration;
            Storyboard sb = new Storyboard();
            sb.Duration = duration;
            sb.Children.Add(myDoubleAnimation1);
            Storyboard.SetTarget(myDoubleAnimation1, obj);
            Storyboard.SetTargetProperty(myDoubleAnimation1, new PropertyPath("Opacity"));
            myDoubleAnimation1.From = 0d;
            myDoubleAnimation1.To = 1d;
            sb.Begin();
        }
        //Fade in animation 
        void ExpandAnimation1(DependencyObject obj)
        {
            sb = new Storyboard();
            DoubleAnimationUsingKeyFrames rotation = new DoubleAnimationUsingKeyFrames();
            EasingDoubleKeyFrame ed = new EasingDoubleKeyFrame()
            {

                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0)),
                Value = 0,
                EasingFunction = new BackEase()
                {
                    EasingMode = EasingMode.EaseIn
                }
            };

            EasingDoubleKeyFrame ed1 = new EasingDoubleKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 300)),
                Value = 0.556,
                EasingFunction = new BackEase()
                {
                    Amplitude = 2
                }
            };

            EasingDoubleKeyFrame ed2 = new EasingDoubleKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 600)),
                Value = 0,
                EasingFunction = new BackEase()
                {
                    Amplitude = 2
                }
            };

            rotation.KeyFrames.Add(ed);
            rotation.KeyFrames.Add(ed1);
            rotation.KeyFrames.Add(ed2);

            DoubleAnimationUsingKeyFrames scalex = new DoubleAnimationUsingKeyFrames();
            double scale = ((obj as Node).RenderTransform as TranslateTransform).X;
            EasingDoubleKeyFrame scalex1 = new EasingDoubleKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0)),
                Value = 1,
                EasingFunction = new BackEase()
                {
                    EasingMode = EasingMode.EaseIn
                }
            };

            EasingDoubleKeyFrame scalex2 = new EasingDoubleKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 300)),
                Value = 0.999,
                EasingFunction = new BackEase()
                {
                    Amplitude = 2
                }
            };

            EasingDoubleKeyFrame scalex3 = new EasingDoubleKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 600)),
                Value = 0.996,
                EasingFunction = new BackEase()
                {
                    Amplitude = 2
                }
            };


            scalex.KeyFrames.Add(scalex1);
            scalex.KeyFrames.Add(scalex2);
            scalex.KeyFrames.Add(scalex3);

            DoubleAnimationUsingKeyFrames scaley = new DoubleAnimationUsingKeyFrames();

            EasingDoubleKeyFrame scaley1 = new EasingDoubleKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0)),
                Value = 1,
                EasingFunction = new BackEase()
                {
                    EasingMode = EasingMode.EaseIn
                }
            };

            EasingDoubleKeyFrame scaley2 = new EasingDoubleKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 300)),
                Value = 0.999,
                EasingFunction = new BackEase()
                {
                    Amplitude = 2
                }
            };

            EasingDoubleKeyFrame scaley3 = new EasingDoubleKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 600)),
                Value = 0.996,
                EasingFunction = new BackEase()
                {
                    Amplitude = 2
                }
            };

            scaley.KeyFrames.Add(scaley1);
            scaley.KeyFrames.Add(scaley2);
            scaley.KeyFrames.Add(scaley3);

            DoubleAnimationUsingKeyFrames translateX = new DoubleAnimationUsingKeyFrames();
            double x = ((obj as Node).RenderTransform as TranslateTransform).X;
            EasingDoubleKeyFrame translateX1 = new EasingDoubleKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0)),
                Value = x,
                EasingFunction = new BackEase()
                {
                    EasingMode = EasingMode.EaseIn
                }
            };

            EasingDoubleKeyFrame translateX2 = new EasingDoubleKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 300)),
                Value = x - 0.096,
                EasingFunction = new BackEase()
                {
                    Amplitude = 2
                }
            };

            EasingDoubleKeyFrame translateX3 = new EasingDoubleKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 600)),
                Value = x - 0.5,
                EasingFunction = new BackEase()
                {
                    Amplitude = 2
                }
            };
            translateX.KeyFrames.Add(translateX1);
            translateX.KeyFrames.Add(translateX2);
            translateX.KeyFrames.Add(translateX3);

            DoubleAnimationUsingKeyFrames translateY = new DoubleAnimationUsingKeyFrames();
            double y = ((obj as Node).RenderTransform as TranslateTransform).Y;
            EasingDoubleKeyFrame translateY1 = new EasingDoubleKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0)),
                Value = y,
                EasingFunction = new BackEase()
                {
                    EasingMode = EasingMode.EaseIn
                }
            };

            EasingDoubleKeyFrame translateY2 = new EasingDoubleKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 300)),
                Value = y - 0.067,
                EasingFunction = new BackEase()
                {
                    Amplitude = 2
                }
            };

            EasingDoubleKeyFrame translateY3 = new EasingDoubleKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 600)),
                Value = y + 0.246,
                EasingFunction = new BackEase()
                {
                    Amplitude = 2
                }
            };
            translateY.KeyFrames.Add(translateY1);
            translateY.KeyFrames.Add(translateY2);
            translateY.KeyFrames.Add(translateY3);


            Storyboard.SetTarget(rotation, ((obj as Node).RenderTransform as TransformGroup));
            Storyboard.SetTargetProperty(rotation, new PropertyPath("Rotation"));

            Storyboard.SetTarget(scalex, ((obj as Node).RenderTransform as TransformGroup));
            Storyboard.SetTargetProperty(scalex, new PropertyPath("ScaleX"));

            Storyboard.SetTarget(scaley, ((obj as Node).RenderTransform as TransformGroup));
            Storyboard.SetTargetProperty(scaley, new PropertyPath("ScaleY"));

            Storyboard.SetTarget(translateX, ((obj as Node).RenderTransform as TransformGroup));
            Storyboard.SetTargetProperty(translateX, new PropertyPath("TranslateX"));


            Storyboard.SetTarget(translateY, ((obj as Node).RenderTransform as TransformGroup));
            Storyboard.SetTargetProperty(translateY, new PropertyPath("TranslateY"));

            sb.Children.Add(rotation);
            sb.Children.Add(scalex);
            sb.Children.Add(scaley);
            sb.Children.Add(translateX);
            sb.Children.Add(translateY);
            sb.Begin();
            sb.RepeatBehavior = RepeatBehavior.Forever;
        }

        //Fade out animation
        void CollapseAnimation(DependencyObject obj)
        {
            Duration duration = new Duration(TimeSpan.FromMilliseconds(300));
            // Create two DoubleAnimations and set their properties.
            DoubleAnimation myDoubleAnimation1 = new DoubleAnimation();
            myDoubleAnimation1.Duration = duration;
            Storyboard sb = new Storyboard();
            sb.Duration = duration;
            sb.Children.Add(myDoubleAnimation1);
            Storyboard.SetTarget(myDoubleAnimation1, obj);
            Storyboard.SetTargetProperty(myDoubleAnimation1, new PropertyPath("Opacity"));
            myDoubleAnimation1.From = 1d;
            myDoubleAnimation1.To = 0d;
            sb.Begin();
        }

        private void CheckSearch(OrgChartDiagram org)
        {
            if ((org.DataContext as ChartViewModel).SearchVisibility == Visibility.Visible)
            {
                (org.DataContext as ChartViewModel).Item = null;
            }
            else if ((org.DataContext as ChartViewModel).SearchVisibility == Visibility.Visible)
            {
                (org.DataContext as ChartViewModel).Item = null;
            }
        }

        private void UpdateLayout(INode node)
        {
            Node fixednode = null;
            foreach (Node n in sfdiagram.Page.Children.OfType<Node>())
            {
                if (n.GetType() != typeof(Syncfusion.UI.Xaml.Diagram.Selector))
                {
                    if (n.DataContext == node)
                    {
                        fixednode = n;
                    }
                }
            }

            sfdiagram.LayoutManager.Layout.UpdateLayout(node);

            foreach (Node n in sfdiagram.Page.Children.OfType<Node>())
            {
                if (n.GetType() != typeof(Syncfusion.UI.Xaml.Diagram.Selector))
                {
                    if (n.DataContext != node)
                    {
                        foreach (OrgNodeViewModel o in sfdiagram.Page.Children.OfType<Connector>()
                                  .Where(connector => connector.SourceNode == node)
                                  .Select(connector => connector.TargetNode))
                        {
                            if (n.DataContext != o)
                            {
                                ApplyMovement(n);
                            }
                        }
                    }
                }
            }

            ApplyAnimation(node as OrgNodeViewModel);
        }

        private void ApplyMovement(Node source)
        {
            Storyboard sb1 = new Storyboard();
        }

        //Expands the Child Nodes
        private void ApplyAnimation(OrgNodeViewModel n)
        {
            Connector con = null;
            if ((n.Content as Employee).IsExpand == State.Expand)
            {
                foreach (OrgConnectorViewModel con1 in (n.Info as INodeInfo).OutConnectors)
                {
                    foreach (Connector line in sfdiagram.Page.Children.OfType<Connector>()
                                 .Where(connector => connector.TargetNode == con1.TargetNode || connector.SourceNode == con1.TargetNode))
                    {
                        if (line.SourceNode == n || line.TargetNode == n)
                            con = line;
                    }

                    foreach (Node v in sfdiagram.Page.Children.OfType<Node>())
                    {
                        if (v.DataContext == con1.TargetNode)
                        {
                            ExpandAnimation(v, n as OrgNodeViewModel, con);
                        }
                    }

                    ApplyAnimation(con1.TargetNode as OrgNodeViewModel);
                }
            }
        }

        private void OpacityAnimation(DependencyObject obj)
        {
            Duration duration = new Duration(TimeSpan.FromMilliseconds(300));
            DoubleAnimation myDoubleAnimation1 = new DoubleAnimation();
            myDoubleAnimation1.Duration = duration;
            Storyboard sb = new Storyboard();
            sb.Duration = duration;
            sb.Children.Add(myDoubleAnimation1);
            Storyboard.SetTarget(myDoubleAnimation1, obj);
            Storyboard.SetTargetProperty(myDoubleAnimation1, new PropertyPath("Opacity"));
            myDoubleAnimation1.From = 0d;
            myDoubleAnimation1.To = 1d;
            sb.Begin();
        }

        private void ExpandAnimation(Node children, OrgNodeViewModel source, Connector org)
        {
            Node sourcenode = null;
            foreach (Node node in sfdiagram.Page.Children.OfType<Node>())
            {
                if (node.DataContext == source)
                {
                    sourcenode = node;
                }
            }
            OpacityAnimation(children);
            if (sourcenode != null)
            {
                DateTime dt = DateTime.Now;
                sb1 = new Storyboard();
                sb1.Completed += (s, e) =>
                    {
                        if (ChartViewModel.SelectedObject != null)
                        {
                            if (((ChartViewModel.SelectedObject as OrgNodeViewModel).Content as Employee).IsExpand == State.Expand)
                            {
                                Update((ChartViewModel.SelectedObject as OrgNodeViewModel));
                            }
                        }
                    };
            }
        }

        private void Update(OrgNodeViewModel n)
        {
            if ((n.Content as Employee).IsExpand == State.Expand)
            {
                foreach (OrgConnectorViewModel con in (n.Info as INodeInfo).OutConnectors)
                {
                    (con.TargetNode as OrgNodeViewModel).Visible = true;
                    foreach (Connector line in sfdiagram.Page.Children.OfType<Connector>()
                                 .Where(connector => connector.TargetNode == con.TargetNode || connector.SourceNode == con.TargetNode))
                    {
                        if (line.SourceNode == n || line.TargetNode == n)
                        {
                            (line.DataContext as OrgConnectorViewModel).Visible = true;
                            OpacityAnimation(line);
                        }
                    }
                    Update((con.TargetNode as OrgNodeViewModel));
                }

            }
        }       

        private void searchgrid_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ChartViewModel.Next.Execute("Next");
            }
        }

        #endregion
               
    }
}
