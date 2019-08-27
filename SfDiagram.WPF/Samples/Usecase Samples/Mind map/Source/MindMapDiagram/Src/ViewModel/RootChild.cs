#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.MindMapDiagram.Utility;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Theming;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Runtime.Serialization;
using Syncfusion.UI.Xaml.Diagram.Utility;

namespace Syncfusion.UI.Xaml.MindMapDiagram.ViewModel
{
    public class RootChild : NodeViewModel, IRootChild
    {
        #region Private Fields
        private ObservableCollection<Child> children;
        private MindMapNodeStyle nodeStyle;
        private Direction direction;
        private int _mLevel;
        private string shapeName;
        private bool hasChildren = false;
        #endregion
        public RootChild()
        {
            Direction = Direction.Right;
            Children = new ObservableCollection<Child>();            
        }
        public RootChild(Direction direction)
        {
            Direction = direction;
            Children = new ObservableCollection<Child>();
            this.Annotations = new AnnotationCollection()
            {
                new TextAnnotationViewModel(){ Text = "New Topic", EditTemplate = GetEditTemplate(), TextWrapping = TextWrapping.Wrap }
            };
            Constraints &= ~(NodeConstraints.InheritDraggable | NodeConstraints.InheritResizable
                | NodeConstraints.InheritRotatable);
            if (direction == Direction.Right)
            {
                Constraints |= (NodeConstraints.ResizeEast);
            }
            else if (direction == Direction.Left)
            {
                Constraints |= (NodeConstraints.ResizeWest);
            }
            ShapeName = "Rectangle";
            ThemeStyleId = StyleId.Variant3;
        }

        #region Public Properties    
        [DataMember]
        public Direction Direction
        {
            get { return direction; }
            internal set
            {
                if (direction != value)
                {
                    direction = value;
                    OnPropertyChanged("Direction");
                }
            }
        }
        [DataMember]
        public string ShapeName
        {
            get { return shapeName; }
            set
            {
                if (shapeName != value)
                {
                    shapeName = value;
                    OnPropertyChanged("ShapeName");
                }
            }
        }
        public ObservableCollection<Child> Children
        {
            get { return children; }
            set
            {
                if (children != value)
                {
                    children = value;
                    OnPropertyChanged("Children");
                }
            }
        }
        public MindMapNodeStyle NodeStyle
        {
            get { return nodeStyle; }
            set
            {
                if (nodeStyle != value)
                {
                    nodeStyle = value;
                    OnPropertyChanged("NodeStyle");
                }
            }
        }
        [DataMember]
        public bool HasChidren
        {
            get { return hasChildren; }
            set
            {
                if (hasChildren != value)
                {
                    hasChildren = value;
                    OnPropertyChanged("HasChidren");
                }
            }
        }
        #endregion
        #region Override Methods
        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);
            switch (name)
            {                
                case "ThemeStyleId":

                    if (!string.IsNullOrEmpty(ShapeName) && (ShapeName.Equals("Line") || ShapeName.Equals("Freehand")))
                    {
                        TextAnnotationViewModel textAnnotaiton = Annotations != null ? (Annotations as AnnotationCollection)[0] as TextAnnotationViewModel : null;
                        if (textAnnotaiton != null)
                        {
                            textAnnotaiton.Foreground = Brushes.Black;
                        }
                    }
                    if (this.Info !=null && (this.Info as INodeInfo).OutConnectors != null && (this.Info as INodeInfo).OutConnectors.Count() > 0)
                    {
                        Style connectorGeometryStyle = SetDefultConnectorGeometryStyle();
                        Style targetDecoratorStyle = SetDefaultTargetDecoratorStyle();
                        foreach (IConnector connector in (this.Info as INodeInfo).OutConnectors.ToList())
                        {
                            connector.ConnectorGeometryStyle = connectorGeometryStyle;
                            connector.TargetDecoratorStyle = targetDecoratorStyle;
                        }
                    }
                    break;
                case "Children":
                    Children.CollectionChanged += (s, e) =>
                    {
                        if (Children.Count() > 0)
                        {
                            HasChidren = true;
                        }
                        else
                        {
                            HasChidren = false;
                        }
                    };
                    break;
                case "Annotations":
                    if (Annotations != null)
                    {
                        if (Annotations != null)
                        {
                            if ((Annotations as AnnotationCollection).Count > 0)
                            {
                                if ((Annotations as AnnotationCollection)[0] is TextAnnotationViewModel)
                                {
                                    TextAnnotationViewModel textAnnotation = (Annotations as AnnotationCollection)[0] as TextAnnotationViewModel;
                                    textAnnotation.PropertyChanged += Annotation_PropertyChanged;
                                }
                            }
                            else
                            {
                                (Annotations as AnnotationCollection).CollectionChanged += (s, e) =>
                                {
                                    if (e.NewItems != null && e.NewItems[0] is TextAnnotationViewModel)
                                    {
                                        (e.NewItems[0] as TextAnnotationViewModel).EditTemplate = GetEditTemplate();
                                        (e.NewItems[0] as TextAnnotationViewModel).PropertyChanged += Annotation_PropertyChanged;
                                    }
                                };
                            }
                        }
                    }
                    //if (Annotations != null && (Annotations as AnnotationCollection).Count > 0)
                    //{
                    //    if ((Annotations as AnnotationCollection)[0] is TextAnnotationViewModel)
                    //    {
                    //        TextAnnotationViewModel textAnnotation = (Annotations as AnnotationCollection)[0] as TextAnnotationViewModel;
                    //        textAnnotation.PropertyChanged += Annotation_PropertyChanged;
                    //    }
                    //}
                    break;
                case "ShapeName":
                    TextAnnotationViewModel annotation = Annotations != null ? (Annotations as AnnotationCollection)[0] as TextAnnotationViewModel : null;
                    if (!string.IsNullOrEmpty(ShapeName) && ShapeName.Equals("Line"))
                    {
                        Shape = null;
                        ContentTemplate = GetLineTempalte();
                        Content = this;
                        if (annotation != null)
                        {
                            annotation.TextVerticalAlignment = VerticalAlignment.Stretch;
                            annotation.Foreground = Brushes.Black;
                        }
                        if (this.Ports != null)
                        {
                            if ((this.Info as INodeInfo).InConnectors != null && (this.Info as INodeInfo).InConnectors.Count() > 0)
                            {
                                foreach (IConnector connector in (this.Info as INodeInfo).InConnectors.ToList())
                                {
                                    if (this.Direction == Direction.Left)
                                    {
                                        connector.TargetPort = (this.Ports as ObservableCollection<IPort>)[3];
                                    }
                                    else if (this.Direction == Direction.Right)
                                    {
                                        connector.TargetPort = (this.Ports as ObservableCollection<IPort>)[0];
                                    }
                                }
                            }
                            if ((this.Info as INodeInfo).OutConnectors != null && (this.Info as INodeInfo).OutConnectors.Count() > 0)
                            {
                                foreach (IConnector connector in (this.Info as INodeInfo).OutConnectors.ToList())
                                {
                                    if (this.Direction == Direction.Left)
                                    {
                                        connector.SourcePort = (this.Ports as ObservableCollection<IPort>)[0];
                                    }
                                    else if (this.Direction == Direction.Right)
                                    {
                                        connector.SourcePort = (this.Ports as ObservableCollection<IPort>)[3];
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Shape = GetShapeData(ShapeName);
                        ContentTemplate = null;
                        Content = null;
                        if (annotation != null)
                        {
                            annotation.TextVerticalAlignment = VerticalAlignment.Center;
                            if (!string.IsNullOrEmpty(ShapeName) && ShapeName.Equals("Freehand"))
                            {
                                annotation.Foreground = Brushes.Black;
                            }
                            else
                            {
                                OnThemeStyleIdChanged();
                            }
                        }
                        if (!string.IsNullOrEmpty(ShapeName) && ShapeName.Equals("Wave"))
                        {
                            if (this.Ports != null && this.Info != null)
                            {
                                if ((this.Info as INodeInfo).InConnectors != null && (this.Info as INodeInfo).InConnectors.Count() > 0)
                                {
                                    foreach (IConnector connector in (this.Info as INodeInfo).InConnectors.ToList())
                                    {
                                        if (this.Direction == Direction.Left)
                                        {
                                            connector.TargetPort = (this.Ports as ObservableCollection<IPort>)[2];
                                        }
                                        else if (this.Direction == Direction.Right)
                                        {
                                            connector.TargetPort = (this.Ports as ObservableCollection<IPort>)[1];
                                        }
                                    }
                                }
                                if ((this.Info as INodeInfo).OutConnectors != null && (this.Info as INodeInfo).OutConnectors.Count() > 0)
                                {
                                    foreach (IConnector connector in (this.Info as INodeInfo).OutConnectors.ToList())
                                    {
                                        if (this.Direction == Direction.Left)
                                        {
                                            connector.SourcePort = (this.Ports as ObservableCollection<IPort>)[1];
                                        }
                                        else
                                        {
                                            connector.SourcePort = (this.Ports as ObservableCollection<IPort>)[2];
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (this.Info != null)
                            {
                                if ((this.Info as INodeInfo).InConnectors != null
                                && (this.Info as INodeInfo).InConnectors.Count() > 0)
                                {
                                    foreach (IConnector connector in (this.Info as INodeInfo).InConnectors.ToList())
                                    {
                                        connector.TargetPort = null;
                                    }
                                }
                                if ((this.Info as INodeInfo).OutConnectors != null
                                && (this.Info as INodeInfo).OutConnectors.Count() > 0)
                                {
                                    foreach (IConnector connector in (this.Info as INodeInfo).OutConnectors.ToList())
                                    {
                                        connector.SourcePort = null;
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
        }
        #endregion
        #region Public Commands
        private DelegateCommand<object> expandCollapseCommand;

        public DelegateCommand<object> ExpandCollapseCommand
        {
            get
            {
                return expandCollapseCommand ??
                    (expandCollapseCommand = new DelegateCommand<object>(OnExpandCollapseCommandExecute));
            }
        }
        #endregion
        #region Internal Properties
        internal int Level
        {
            get { return _mLevel; }
            set
            {
                if (_mLevel != value)
                {
                    _mLevel = value;
                    OnPropertyChanged("Level");
                }
            }
        }
        
        #endregion
        #region Internal Methods
        internal void Select()
        {
            ((((this.Info as INodeInfo).Graph as IGraph).SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>).Clear();
            this.IsSelected = true;
        }
        #endregion
        #region Private Methods
        private Style SetDefultConnectorGeometryStyle()
        {
            Style _mStaticGeometryStyle = null;
            var info = this.Info as INodeInfo;
            if (Constraints.Contains(NodeConstraints.ThemeStyle) && info != null && info.Graph.Theme != null)
            {
                DiagramItemStyle style = info.Graph.Theme.GetNodeStyle(ThemeStyleId);
                _mStaticGeometryStyle = new Style()
                {
                    TargetType = typeof(System.Windows.Shapes.Shape),
                };
                _mStaticGeometryStyle.Setters.Add(
                    new Setter()
                    {
                        Property = System.Windows.Shapes.Shape.StrokeProperty,
                        Value = style.Stroke
                });
                _mStaticGeometryStyle.Setters.Add(
                    new Setter()
                    {
                        Property = System.Windows.Shapes.Shape.StrokeThicknessProperty,
                        Value = 1d
                    });
            }
            return _mStaticGeometryStyle;
        }
        private Style SetDefaultTargetDecoratorStyle()
        {
            Style _mStaticTargetDecoratorStyle = null;
            var info = this.Info as INodeInfo;
            if (this.Constraints.Contains(NodeConstraints.ThemeStyle) && info != null && info.Graph.Theme != null)
            {
                DiagramItemStyle style = info.Graph.Theme.GetNodeStyle(this.ThemeStyleId);
                _mStaticTargetDecoratorStyle = new Style()
                {
                    TargetType = typeof(System.Windows.Shapes.Shape),
                };
                _mStaticTargetDecoratorStyle.Setters.Add(
                    new Setter()
                    {
                        Property = System.Windows.Shapes.Shape.StrokeProperty,
                        Value = style.Stroke
                    });
                _mStaticTargetDecoratorStyle.Setters.Add(
                    new Setter()
                    {
                        Property = System.Windows.Shapes.Shape.FillProperty,
                        Value = style.Stroke
                    });
                _mStaticTargetDecoratorStyle.Setters.Add(
                    new Setter()
                    {
                        Property = System.Windows.Shapes.Shape.StrokeThicknessProperty,
                        Value = 0d
                    });
                _mStaticTargetDecoratorStyle.Setters.Add(
                    new Setter()
                    {
                        Property = System.Windows.Shapes.Shape.StretchProperty,
                        Value = Stretch.Fill
                    });
                _mStaticTargetDecoratorStyle.Setters.Add(
                    new Setter()
                    {
                        Property = FrameworkElement.WidthProperty,
                        Value = 10d
                    });
                _mStaticTargetDecoratorStyle.Setters.Add(
                    new Setter()
                    {
                        Property = FrameworkElement.HeightProperty,
                        Value = 10d
                    });
            }
            return _mStaticTargetDecoratorStyle;
        }
        private void OnExpandCollapseCommandExecute(object param)
        {
            ExpandCollapseParameter parameter = new ExpandCollapseParameter()
            {
                node = this,
                IsUpdateLayout = true
            };
            ((this.Info as INodeInfo).Graph as IGraphInfo).Commands.ExpandCollapse.Execute(parameter);
        }
        private string GetShapeData(string name)
        {
            string data = string.Empty;
            switch (name)
            {
                case "Oval":
                    data = "M15.999998,0 C24.837005,-1.2914262E-07 31.999999,2.9099997 31.999999,6.4999999 31.999999,10.09 24.837005,13 15.999998,13 7.1639984,13 0,10.09 0,6.4999999 0,2.9099997 7.1639984,-1.2914262E-07 15.999998,0 z";
                    break;
                case "Cloud":
                    data = "M14.921997,0 C16.337997,1.5650994E-07 17.527,0.82099953 17.873001,1.9339985 18.344002,1.0140004 19.419998,0.37099861 20.673996,0.37099838 22.209,0.37099861 23.476997,1.3349995 23.694,2.5890017 24.308998,2.1370016 25.144997,1.8559996 26.068001,1.8559994 27.955002,1.8559996 29.484001,3.0210007 29.484001,4.457002 29.484001,5.0169996 29.248001,5.5350011 28.851997,5.9600008 30.625999,6.0850008 32,6.9429987 32,7.984999 32,9.1130055 30.390999,10.027999 28.404999,10.027999 27.289001,10.027999 26.290001,9.7390049 25.630997,9.2850026 L25.154999,9.2850026 C25.160995,9.346999 25.168999,9.4080037 25.168999,9.4709996 25.168999,11.009002 23.237999,12.257003 20.853996,12.257003 19.693001,12.257003 18.640999,11.958999 17.864998,11.477004 17.152,12.380004 15.700996,13 14.023003,13 11.918999,13 10.167999,12.026 9.7879982,10.740004 9.3050003,11.634002 8.2449989,12.257003 7.0119972,12.257003 5.3239975,12.257003 3.9559975,11.093001 3.9559975,9.6570042 3.9559975,9.6480015 3.9570007,9.6400059 3.9570007,9.6310032 3.7799988,9.6470021 3.6009979,9.6570042 3.4160004,9.6570042 1.5299988,9.6570042 0,8.8250035 0,7.799002 0,6.774 1.5299988,5.9420031 3.4160004,5.9420031 3.4769974,5.9420031 3.5359993,5.9460009 3.5960007,5.9470003 L3.5960007,5.8690012 C2.1459999,5.6320012 1.0789986,4.8410009 1.0789986,3.8989993 1.0789986,2.7720002 2.6079979,1.8559996 4.4949989,1.8559994 5.0909996,1.8559996 5.6520004,1.949002 6.1399994,2.1090017 6.6860008,1.2949986 7.757,0.7420009 8.9889984,0.74200108 10.272999,0.7420009 11.379997,1.3450017 11.902,2.2160006 12.121002,0.96199837 13.387001,1.5650994E-07 14.921997,0 z";
                    break;
                case "Freehand":
                    data = "M13.679207,0.0003108942 C14.437874,0.0035293069 15.19545,0.031716783 15.950712,0.083966952 14.440686,0.20397067 12.943661,0.36997222 11.459646,0.59297355 9.9806191,0.84297516 8.5175959,1.169981 7.1055752,1.6179822 5.6965534,2.0519835 4.307532,2.5979849 3.1385159,3.3749911 2.5755073,3.7689985 2.0224976,4.2100038 1.7454928,4.7170032 1.4554913,5.219006 1.4374895,5.6850127 1.682492,6.1480135 2.2125029,7.1010231 3.5515203,7.8350295 4.8475415,8.3380317 6.1775633,8.8550338 7.5995823,9.2030353 9.0386035,9.457035 11.92265,9.9640426 14.891698,10.118043 17.834742,9.9730376 20.768786,9.8470372 23.724831,9.4360389 26.441868,8.5070313 27.766894,8.0410251 29.118912,7.399022 29.883923,6.5050181 30.25693,6.0800122 30.391934,5.5680074 30.245928,5.2620057 30.109925,4.871004 29.60192,4.4100021 29.032912,4.0689963 27.876897,3.3479904 26.436871,2.932994 25.025847,2.5769888 23.597823,2.2309855 22.123803,2.0219845 20.640786,1.8949846 17.672738,1.60798 14.653695,1.7119847 11.681649,2.2699872 14.551688,1.2729786 17.629738,0.95797386 20.683785,0.92097862 22.216805,0.9279749 23.753832,1.0449801 25.284854,1.2969806 26.812876,1.5709849 28.342898,1.9309803 29.810923,2.7229861 30.524932,3.1329924 31.308947,3.6169971 31.788951,4.623001 32.287957,5.7330097 31.821955,6.8740167 31.260943,7.5820216 30.678933,8.303028 29.987929,8.8430327 29.274913,9.2440366 28.565901,9.6700419 27.82889,9.9870376 27.088881,10.282045 24.103835,11.371051 21.009787,11.793058 17.92574,11.969054 14.838695,12.087051 11.739648,11.915053 8.6846015,11.318048 7.1615759,10.999046 5.6495515,10.583043 4.1805312,9.9590377 3.446519,9.6520366 2.7255074,9.2700376 2.036498,8.801032 1.3654898,8.3090323 0.69147971,7.7040242 0.27047178,6.8130192 0.062468516,6.3730134 -0.041533163,5.8330087 0.015467081,5.3260092 0.060469584,4.8050016 0.27047187,4.3370036 0.52347419,3.9490003 1.042483,3.1559953 1.7494946,2.6779875 2.4445049,2.2629837 3.8585278,1.4699786 5.3525502,1.0099762 6.854572,0.6699775 9.117355,0.20572164 11.403202,-0.0093444324 13.679207,0.0003108942 z";
                    break;
                case "Wave":
                    data = "M31.999999,0 C31.999999,1.620507E-07 31.313003,1.2979779 29.985,2.8979362 L29.999999,2.8929466 C28.68,4.8028962 26.980003,6.4408637 24.999999,7.7138478 22.485999,9.16882 19.467002,9.1608092 17.085996,8.7928206 15.066,8.4808308 13.182996,7.6718413 11.421003,6.6688711 9.7889989,5.7398888 7.9919976,5.1228973 6.3130005,4.7058979 4.8699997,4.4229146 3.0649989,4.1429211 0.85299679,3.8879217 0.3209992,3.8589152 0,3.8569163 0,3.8569163 L0.57899853,3.8569163 C0.38599782,3.8349289 0.19899752,3.8129262 0,3.7919306 0,3.7919306 3.7649999,1.5169677 9.412,1.5169678 9.412,1.5169677 11.357999,1.5169677 17.201001,3.163937 19.04,3.6829239 20.960998,3.9079255 22.874999,3.8179158 23.224998,3.8019248 23.582,3.7779232 23.936004,3.7469181 25.524001,3.6039308 27.054,3.0659322 28.413001,2.2239541 z";
                    break;
                case "Starburst":
                    data = "M13.246002,0 L16.058998,3.4279938 21.449997,0.45700073 20.747002,4.5709991 28.249001,2.0569916 26.139999,5.9420013 32,5.7139893 26.843002,8.2279968 32,10.513992 24.029999,10.742996 27.780998,14.399994 19.574997,11.884995 19.574997,15.770996 16.058998,13.028 11.136002,16 11.136002,11.884995 2.9300003,14.399994 6.7989998,10.856995 0.23500061,9.4850006 4.6889992,7.8849945 0,4.4570007 7.0330009,5.3710022 6.0950012,1.2569885 11.136002,4.5709991 z";
                    break;
                case "Rectangle":
                    data = "M0.5,0.5L25.5,0.5L25.5,25.557L0.5,25.557z";
                    break;
            }
            return data;
        }
        private void OnThemeStyleIdChanged()
        {
            var info = this.Info as INodeInfo;
            if (Constraints.Contains(NodeConstraints.ThemeStyle) && info != null && info.Graph.Theme != null)
            {
                if (!string.IsNullOrEmpty(ShapeName) && !ShapeName.Equals("Line"))
                {
                    DiagramItemStyle style = info.Graph.Theme.GetNodeStyle(ThemeStyleId);
                    if (style != null)
                    {
                        foreach (TextAnnotationViewModel annotaiton in (this.Annotations as AnnotationCollection))
                        {
                            annotaiton.Foreground = style.Foreground;
                            annotaiton.FontSize = (int)style.FontSize;
                            annotaiton.FontFamily = style.FontFamily;
                        }
                    }
                }
            }
        }
        private void Annotation_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Mode"))
            {
                TextAnnotationViewModel annotaiton = sender as TextAnnotationViewModel;
                if (annotaiton != null && annotaiton.Mode == ContentEditorMode.View)
                {
                    TextBlock textblock = new TextBlock();
                    textblock.RenderTransformOrigin = new Point(0.5, 0.5);
                    textblock.Width = this.UnitWidth;
                    textblock.Text = annotaiton.Text;
                    textblock.TextWrapping = annotaiton.TextWrapping;
                    textblock.FontStyle = annotaiton.FontStyle;
                    textblock.FontSize = annotaiton.FontSize;
                    textblock.Foreground = annotaiton.Foreground;
                    textblock.FontWeight = annotaiton.FontWeight;
                    if (annotaiton.FontFamily != null)
                    {
                        textblock.FontFamily = annotaiton.FontFamily;
                    }
                    textblock.HorizontalAlignment = annotaiton.HorizontalAlignment;
                    textblock.VerticalAlignment = annotaiton.VerticalAlignment;
                    textblock.TextAlignment = annotaiton.TextHorizontalAlignment;
                    textblock.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                    //if (this.Type.Equals("root"))
                    //{
                    //    if (this.ShapeName.Equals("Line"))
                    //    {
                    //        double height = textblock.DesiredSize.Height + 20;
                    //        this.UnitHeight = Math.Max(96, textblock.DesiredSize.Height + 20);
                    //    }
                    //    else
                    //    {
                    //        this.UnitHeight = Math.Max(96, textblock.DesiredSize.Height);
                    //    }
                    //}
                    //else
                    {
                        if (this.ShapeName.Equals("Line"))
                        {
                            double height = textblock.DesiredSize.Height + 20;
                            this.UnitHeight = Math.Max(30, textblock.DesiredSize.Height + 20);
                        }
                        else
                        {
                            this.UnitHeight = Math.Max(30, textblock.DesiredSize.Height);
                        }
                    }

                }
            }
        }
        private DataTemplate GetLineTempalte()
        {
            const string vTemplate = "<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">" +
                                       "<Path Data=\"M0.5,0.5L25.5,0.5L25.5,25.557L0.5,25.557z\"  Height=\"2\" VerticalAlignment=\"Bottom\" RenderTransformOrigin=\"0.5,0.5\" Style=\"{Binding ShapeStyle}\">" +
                                        "</Path>" +
                                        "</DataTemplate>";

            return LoadXaml(vTemplate) as DataTemplate;
        }
        private DataTemplate GetEditTemplate()
        {
            string eTemplate = "<DataTemplate" +
                    " xmlns:util=\"clr-namespace:Syncfusion.UI.Xaml.Diagram.Utility;assembly=Syncfusion.SfDiagram.Wpf\"" +
                     " xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">" +
                     "<TextBox util:FocusUtility.FocusOnLoad=\"True\" Foreground=\"Black\" AcceptsReturn=\"True\" Text=\"{Binding Path=Text, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}\" TextWrapping=\"{Binding Path=TextWrapping, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}\" FontStyle=\"{Binding Path=FontStyle, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}\" FontSize=\"{Binding Path=FontSize, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}\"  FontFamily=\"{Binding Path=FontFamily, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}\" FontWeight=\"{Binding Path=FontWeight , Mode=TwoWay, UpdateSourceTrigger=PropertyChanged }\" TextDecorations =\"{Binding Path=TextDecorations , Mode=TwoWay, UpdateSourceTrigger=PropertyChanged }\" TextAlignment=\"{Binding Path=TextHorizontalAlignment, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}\" />" +
                     "</DataTemplate>";
            return LoadXaml(eTemplate) as DataTemplate;
        }
        private object LoadXaml(string xaml)
        {
            return XamlReader.Parse(xaml);
        }
        #endregion
    }
}
