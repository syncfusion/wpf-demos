#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.RegularExpressions;
namespace MindMap
{
    public class CustomNode : NodeViewModel
    {
        public CustomNode()
        {
            AllowDelete = true;
            Childs = new ObservableCollection<CustomNode>();
            Content = new NodeCustom();
            ContentTemplate = App.Current.Resources["CNodeTemplate"] as DataTemplate;
            Annotations = new ObservableCollection<IAnnotation>()
            {
                new CustomLabel(){Content="Node"}
            };
            ID = Guid.NewGuid();
        }
        internal bool _havetoUpdateLayout = false;
        private double _from;

        public double From
        {
            get { return _from; }
            set
            {
                if (_from != value)
                {
                    _from = value;
                    OnPropertyChanged("From");
                }
            }
        }

        private double _to;

        public double To
        {
            get { return _to; }
            set
            {
                if (_to != value)
                {
                    _to = value;
                    OnPropertyChanged("To");
                }
            }
        }

        private string _pname;

        public string Pname
        {
            get { return _pname; }
            set
            {
                if (_pname != value)
                {
                    _pname = value;
                    OnPropertyChanged("Pname");
                }
            }
        }

        private bool _isautoreverse;

        public bool IsAutoReverse
        {
            get { return _isautoreverse; }
            set
            {
                if (_isautoreverse != value)
                {
                    _isautoreverse = value;
                    OnPropertyChanged("IsAutoReverse");
                }
            }
        }
        private string _type = "";

        [DataMember]
        public string Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    if (value.StartsWith("sub"))
                    {
                        (this.Content as NodeCustom).type = value;
                    }
                    OnPropertyChanged("Type");
                }
            }
        }
        
        [DataMember]
        public string Label
        {
            get
            {
                if (Annotations != null)
                    return (Annotations as ObservableCollection<IAnnotation>).First().Content.ToString();
                else
                    return null;
            }
            set
            {
                (Annotations as ObservableCollection<IAnnotation>).First().Content = value;
            }
        }

        private bool _isIntersect;

        public bool IsIntersect
        {
            get { return _isIntersect; }
            set
            {
                if (_isIntersect != value)
                {
                    _isIntersect = value;
                    OnPropertyChanged("IsIntersect");
                }
            }
        }

        private Nodepair _initialpair = null;

        public Nodepair InitialPair
        {
            get { return _initialpair; }
            set
            {
                if (_initialpair != value)
                {
                    _initialpair = value;
                    OnPropertyChanged("InitialPair");
                }
            }
        }

        private Nodepair _pair;

        public Nodepair Pair
        {
            get
            {
                if (_initialpair != null)
                    return _initialpair;
                else
                {
                    _pair = new Nodepair(this);
                    return _pair;
                }
            }
            set
            {
                if (_pair != value)
                {
                    _pair = value;
                    OnPropertyChanged("Pair");
                }
            }
        }

        private bool _AllowDelete = true;

        [DataMember]
        public bool AllowDelete
        {
            get { return _AllowDelete; }
            set
            {
                if (_AllowDelete != value)
                {
                    _AllowDelete = value;
                    OnPropertyChanged("AllowDelete");
                }
            }
        }


        private ObservableCollection<CustomNode> childs;

        public ObservableCollection<CustomNode> Childs
        {
            get
            {
                if ((this.Info as INodeInfo).OutNeighbors != null)
                {
                    childs.Clear();
                    for (int i = 0; i < (this.Info as INodeInfo).OutNeighbors.Count(); i++)
                        childs.Add((this.Info as INodeInfo).OutNeighbors.ElementAt(i) as CustomNode);
                    return childs;
                }
                else
                    return null;
            }
            set
            {
                childs = value;
                OnPropertyChanged("Childs");
            }
        }


        private double _angle;
        public double Angle
        {
            get { return _angle; }
            set
            {
                if (_angle != value)
                {
                    if (value <= 22 && value >= -23)
                        _angle = 0;
                    else if (value <= 67 && value >= 23)
                        _angle = 45;
                    else if (value <= 112 && value >= 68)
                        _angle = 90;
                    else if (value <= 160 && value >= 113)
                        _angle = 135;
                    else if ((value <= 180 && value >= 160) || (value <= -160 && value >= -180))
                        _angle = 180;
                    else if (value <= -112 && value >= -160)
                        _angle = -135;
                    else if (value <= -67 && value >= -113)
                        _angle = -90;
                    else if (value <= -22 && value >= -68)
                        _angle = -45;
                    OnPropertyChanged("Angle");
                }
            }
        }

        [DataMember]
        public double NodeAngle
        {
            get
            {
                return Angle;
            }
            set
            {
                Angle = value;
            }
        }
        [DataMember]
        public NodeCustom DummyContent
        {
            get { return this.Content as NodeCustom; }
            set { this.Content = value; }
        }

        public ObservableCollection<IAnnotation> NodeAnnotations
        {
            get
            {
                return (ObservableCollection<IAnnotation>)this.Annotations;
            }
            set
            {
                if ((ObservableCollection<IAnnotation>)this.Annotations != value)
                {
                    this.Annotations = value;
                    OnPropertyChanged("NodeAnnotations");
                }
            }
        }

        public ObservableCollection<INodePort> NodePorts
        {
            get
            {
                return (ObservableCollection<INodePort>)this.Ports;
            }
            set
            {
                if ((ObservableCollection<INodePort>)this.Ports != value)
                {
                    this.Ports = value;
                    OnPropertyChanged("NodePorts");
                }
            }
        }

        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);
        }
    }


    public class CustomConnector : Connector
    {
        public CustomConnector()
        {
            this.Constraints = ConnectorConstraints.Default ^ ConnectorConstraints.Selectable;
            this.TargetDecorator = null;
            ConnectorGeometryStyle = App.Current.Resources["NormalLine"] as Style;
        }
    }

    [DataContract]
    public class Nodepair : INotifyPropertyChanged
    {
        public Nodepair(CustomNode Root)
        {
            if ((Root.Info as INodeInfo).InNeighbors != null && (Root.Info as INodeInfo).InConnectors != null)
            {
                if ((Root.Info as INodeInfo).InNeighbors.Count() > 0)
                    this.Root = ((Root.Info as INodeInfo).InNeighbors.First() as CustomNode) as CustomNode;
                else
                    this.Root = null;
                this.Child = Root;
                if ((Root.Info as INodeInfo).InConnectors.Count() > 0)
                    this.Link = (Root.Info as INodeInfo).InConnectors.First() as CustomConnector;
                else
                    this.Link = null;
            }
            else
            {
                this.Root = null;
                this.Child = null;
                this.Link = null;
            }

        }

        public Nodepair(CustomNode Root, CustomNode Child, CustomConnector Link)
        {
            this.Root = Root;
            this.Child = Child;
            this.Link = Link;
        }

        private CustomNode _root;

        [DataMember]
        public CustomNode Root
        {
            get { return _root; }
            set
            {
                if (_root != value)
                {
                    _root = value;
                    OnPropertyChanged("Root");
                }

            }
        }

        private CustomNode _child;

        [DataMember]
        public CustomNode Child
        {
            get { return _child; }
            set
            {
                if (_child != value)
                {
                    _child = value;
                    OnPropertyChanged("Child");
                }

            }
        }

        private CustomConnector _link;

        [DataMember]
        public CustomConnector Link
        {
            get { return _link; }
            set
            {
                if (_link != value)
                {
                    _link = value;
                    OnPropertyChanged("Link");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(null, new PropertyChangedEventArgs(name));
            }
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
        }

        private Visibility allowdelete;

        public Visibility AllowDelete
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
        private CustomNode _SelectedObject;
        public CustomNode SelectedObject
        {
            get { return _SelectedObject; }
            set
            {
                _SelectedObject = value;
                
                OnPropertyChanged("SelectedObject");
            }
        }
      
    }


    [DataContract]
    public class NodeCustom : INotifyPropertyChanged
    {

        private SolidColorBrush _selectbrush = new SolidColorBrush(Colors.DarkCyan);

        [DataMember]
        public SolidColorBrush SelectedBrush
        {
            get 
            {
             
                //Foreground = new SolidColorBrush(PerceivedBrightness(_selectbrush.Color) > 130 ? Colors.Black : Colors.White);
                return _selectbrush; 
            }
            set
            {
                if (_selectbrush != value)
                {
                    if (type !=null && type.StartsWith("sub") && value!=null)
                    {
                        Foreground = value;
                    }
                    _selectbrush = value;
                    OnPropertyChanged("SelectedBrush");
                }
            }
        }

        private SolidColorBrush _foreground = new SolidColorBrush(Colors.White);
        public SolidColorBrush Foreground
        {
            get
            {
                if (type!=null && type.StartsWith("sub"))
                {
                    return SelectedBrush;
                }
                return _foreground;
            }
            set
            {
                if (_foreground != value)
                {
                    _foreground = value;
                    OnPropertyChanged("Foreground");
                }
                
            }
        }

        private string _type;

        public string type
        {
            get { return _type; }
            set { _type = value;
            OnPropertyChanged("type");
            }
        }
        private LineGeometry _path;

        public LineGeometry path
        {
            get { return _path; }
            set
            {
                _path = value;
                OnPropertyChanged("path");
            }
        }
        [DataMember]
        public string ColorName
        {
            get 
            {
                if (SelectedBrush != null)
                    return SelectedBrush.Color.ToString();
                else
                    return null;
            }
            set 
            {
                Color c;
                var match = Regex.Match(value, "#([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})");
                int a = Convert.ToInt32(match.Groups[1].Value, 16);
                int r = Convert.ToInt32(match.Groups[2].Value, 16);
                int g = Convert.ToInt32(match.Groups[3].Value, 16);
                int b = Convert.ToInt32(match.Groups[4].Value, 16);
                c = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
                SelectedBrush = new SolidColorBrush(c);
            }
        }

        private int PerceivedBrightness(Color c)
        {
            return (int)Math.Sqrt(
            c.R * c.R * .241 +
            c.G * c.G * .691 +
            c.B * c.B * .068);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                //MindMapDiagram.dis.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    //{
                        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
                    //});
            }
        }
    }

    public class CustomLabel : AnnotationEditorViewModel
    {

        public CustomLabel()
        {
            ViewTemplate = App.Current.Resources["vtemplate"] as DataTemplate;
            EditTemplate = App.Current.Resources["etempalte"] as DataTemplate;
        }

    }

    public class CNode : Node
    {
        public CNode()
        {
            Loaded += CNode_Loaded;
            ManipulationStarted += CNode_ManipulationStarted;

            this.ManipulationStarted += CNode_ManipulationStarted;
        }

       

        void CNode_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void CNode_Loaded(object sender, RoutedEventArgs e)
        {
            this.IsManipulationEnabled = true;
            //ManipulationMode = ManipulationModes.TranslateX | ManipulationModes.TranslateY | ManipulationModes.Scale |
            //                  ManipulationModes.Rotate;
            NodeViewModel vm = this.DataContext as NodeViewModel;
            INodeInfo info = vm.Info as INodeInfo;
            //this.Padding = new Thickness(5);
            if (info.InNeighbors != null)
            {
                INode parent = info.InNeighbors.FirstOrDefault();
                if (parent != null)
                {
                    this.UpdateLayout();
                    //Dispatcher.RunAsync(CoreDispatcherPriority.High, () =>
                        {

                            Point diff = new Point(parent.OffsetX - OffsetX, parent.OffsetY - OffsetY);
                            TranslateTransform trans = (RenderTransform as TransformGroup).Children[2] as TranslateTransform;
                            Point to = new Point(trans.X, trans.Y);
                            Point from = new Point(to.X + diff.X, to.Y + diff.Y);


                            //DoubleAnimation x = new DoubleAnimation();
                            //x.EasingFunction = new ExponentialEase() {EasingMode = EasingMode.EaseOut, Exponent = 5};
                            //DoubleAnimation y = new DoubleAnimation();
                            //y.EasingFunction = new ExponentialEase() { EasingMode = EasingMode.EaseOut, Exponent = 5 };
                            //x.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                            //y.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                            //x.From = from.X;
                            //y.From = from.Y;
                            ////x.To = to.X;
                            ////y.To = to.Y;
                            //Storyboard.SetTarget(x, RenderTransform);
                            //Storyboard.SetTarget(y, RenderTransform);
                            //Storyboard.SetTargetProperty(x, new PropertyPath("X"));
                            //Storyboard.SetTargetProperty(y, new PropertyPath("Y"));
                            //Storyboard sb = new Storyboard();
                            //sb.Children.Add(x);
                            //sb.Children.Add(y);
                            //sb.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                            //sb.Begin();
                        }//);
                    //Storyboard storyboard = new Storyboard();
                    //RepositionThemeAnimation xani = new RepositionThemeAnimation();
                    //xani.FromHorizontalOffset = parent.OffsetX - OffsetX;
                    //xani.FromVerticalOffset = parent.OffsetY - OffsetY;
                    //xani.Duration = new Duration(TimeSpan.FromMilliseconds(200));
                    //Storyboard.SetTarget(xani, this);
                    //storyboard.Children.Add(xani);
                    //storyboard.Begin();
                       
                }
            }
            if ((this.DataContext as CustomNode).NodeAnnotations != null)
            {
                (((IEnumerable<object>)(this.DataContext as CustomNode).NodeAnnotations).ElementAt(0) as CustomLabel).PropertyChanged += CNode_PropertyChanged;
            }
        }

        
        void CNode_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CustomNode node=this.DataContext as CustomNode;
            string Type = node.Type;
            if (Type!=null && !Type.Equals(""))
            {
                TextBlock box = (sender as CustomLabel).ViewTemplate.LoadContent() as TextBlock;
                string str = (sender as CustomLabel).Content.ToString();
                string[] stringSeparators = new string[] { "\n" };
                string[] splitted = str.Split(stringSeparators, StringSplitOptions.None);
                string i = splitted.OrderByDescending(s => s.Length).First();
                int n = str.Length - str.Replace("\n", "").Length + 1;
                int len = i.Length;
                int count = splitted.Length;
                double size = len * 8 + 30;
                double ht = count * 11 + 30 +(count-1)*7;
                node.UnitHeight = ht > 30 ? ht : 30;
                node.UnitWidth = size > 50 ? size : 50;
                if (Type != null && Type.StartsWith("sub"))
                {
                    LineGeometry line = new LineGeometry();
                    if (line != null)
                    {
                        line.StartPoint = new Point(0, UnitHeight);
                        line.EndPoint = new Point(UnitWidth, UnitHeight);
                    }
                    (node.Content as NodeCustom).path = line;

                }
                node._havetoUpdateLayout=true;
                this.InvalidateMeasure();
                this.UpdateLayout();
            }
        }
        public double From
        {
            get { return (double) GetValue(FromProperty); }
            set { SetValue(FromProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FromProperty =
            DependencyProperty.Register("From", typeof (double), typeof (CNode), new PropertyMetadata(0d, OnChanged));

        private static void OnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }


        public double To
        {
            get { return (double)GetValue(ToProperty); }
            set { SetValue(ToProperty, value); }
        }

        // Using a DependencyProperty as the backing store for To.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToProperty =
            DependencyProperty.Register("To", typeof(double), typeof(CNode), new PropertyMetadata(0d, OnToChanged));

        private static void OnToChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CNode n = d as CNode;
            //n.Animate();
        }

        

        public string Pname
        {
            get { return (string)GetValue(PnameProperty); }
            set { SetValue(PnameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PnameProperty =
            DependencyProperty.Register("Pname", typeof(string), typeof(CNode), new PropertyMetadata(""));

        private bool _isautoreverse;

        public bool IsAutoReverse
        {
            get { return _isautoreverse; }
            set
            {
                if (_isautoreverse != value)
                {
                    _isautoreverse = value;
                    OnPropertyChanged("IsAutoReverse");
                }
            }
        }
    }
}
