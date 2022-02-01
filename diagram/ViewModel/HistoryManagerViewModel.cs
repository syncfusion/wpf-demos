#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class HistoryManagerViewModel : DiagramViewModel, IUndoRedo
    {
        private bool first = true;
        private string _redotext;
        private string _undotext;
        Brush selectedFillBrush = new SolidColorBrush(Colors.White);
        Brush selectedStrokeBrush = new SolidColorBrush(Colors.Black);
        Brush selectedFontBrush = new SolidColorBrush(Colors.Black);
        FontFamily selectedFontFamily = SystemFonts.MessageFontFamily;
        double selectedFontSize = SystemFonts.MessageFontSize;
        bool isFillBrushEnabled;
        bool isStrokeBrushEnabled;
        bool isBoldSelected;
        bool isItalicSelected;
        bool isUnderlineSelected;
        bool isGroupAction;

        private ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/Syncfusion.SfDiagram.Wpf;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
        };

        public HistoryManagerViewModel()
        {
            this.Nodes = new ObservableCollection<SfNodeViewModel>();
            this.Connectors = new ObservableCollection<SfConnectorViewModel>();
            this.SelectedItems = new SelectorViewModel();
            Constraints = Constraints.Add(GraphConstraints.Undoable);
            HistoryManager = new HistoryManager();
            ViewPortChangedCommand = new DelegateCommand(OnViewPortChanged);
            HistoryChangedCommand = new DelegateCommand(OnHistoryChanged);
            ItemSelectedCommand = new DelegateCommand(OnItemSelected);
            ItemUnSelectedCommand = new DelegateCommand(OnItemUnSelected);

            var Node1 = CreateNode(450, 60, "Ellipse", "Start", "Pink");
            var Node2 = CreateNode(450, 150, "Rectangle", "Design", "Grey");
            var Node3 = CreateNode(450, 240, "Rectangle", "Coding", "Grey");
            var Node4 = CreateNode(450, 330, "Rectangle", "Testing", "Grey");
            var Node5 = CreateNode(450, 440, "Diamond", "Errors?", "Green");
            var Node6 = CreateNode(200, 240, "Diamond", "Design Error?", "Green");
            var Node7 = CreateNode(450, 540, "Ellipse", "End", "Green");

            var Con1 = CreateConnector(Node1, Node2, "");
            var Con2 = CreateConnector(Node2, Node3, "");
            var Con3 = CreateConnector(Node3, Node4, "");
            var Con4 = CreateConnector(Node4, Node5, "");
            var Con5 = CreateConnector(Node5, Node7, "No");
            var Con6 = CreateConnector(Node5, Node6, "Yes");
            var Con7 = CreateConnector(Node6, Node2, "Yes");
            var Con8 = CreateConnector(Node6, Node3, "No");
        }

        public string RedoText
        {
            get
            {
                return _redotext;
            }
            set
            {
                _redotext = value;
                OnPropertyChanged("RedoText");
            }
        }

        public string UndoText
        {
            get
            {
                return _undotext;
            }
            set
            {
                _undotext = value;
                OnPropertyChanged("UndoText");
            }
        }

        public Brush SelectedFillBrush
        {
            get
            {
                return selectedFillBrush;
            }
            set
            {
                if (selectedFillBrush != value)
                {
                    selectedFillBrush = value;
                    this.OnPropertyChanged("SelectedFillBrush");
                }
            }
        }

        public Brush SelectedStrokeBrush
        {
            get
            {
                return selectedStrokeBrush;
            }
            set
            {
                if (selectedStrokeBrush != value)
                {
                    selectedStrokeBrush = value;
                    this.OnPropertyChanged("SelectedStrokeBrush");
                }
            }
        }

        public Brush SelectedFontBrush
        {
            get
            {
                return selectedFontBrush;
            }
            set
            {
                if (selectedFontBrush != value)
                {
                    selectedFontBrush = value;
                    this.OnPropertyChanged("SelectedFontBrush");
                }
            }
        }

        public FontFamily SelectedFontFamily
        {
            get
            {
                return selectedFontFamily;
            }
            set
            {
                if (selectedFontFamily != value)
                {
                    selectedFontFamily = value;
                    this.OnPropertyChanged("SelectedFontFamily");
                }
            }
        }

        public double SelectedFontSize
        {
            get
            {
                return selectedFontSize;
            }
            set
            {
                if (selectedFontSize != value)
                {
                    selectedFontSize = value;
                    this.OnPropertyChanged("SelectedFontSize");
                }
            }
        }

        public bool IsFillBrushEnabled
        {
            get
            {
                return isFillBrushEnabled;
            }
            set
            {
                if (isFillBrushEnabled != value)
                {
                    isFillBrushEnabled = value;
                    this.OnPropertyChanged("IsFillBrushEnabled");
                }
            }
        }

        public bool IsStrokeBrushEnabled
        {
            get
            {
                return isStrokeBrushEnabled;
            }
            set
            {
                if (isStrokeBrushEnabled != value)
                {
                    isStrokeBrushEnabled = value;
                    this.OnPropertyChanged("IsStrokeBrushEnabled");
                }
            }
        }

        public bool IsBoldSelected
        {
            get
            {
                return isBoldSelected;
            }
            set
            {
                if (isBoldSelected != value)
                {
                    isBoldSelected = value;
                    this.OnPropertyChanged("IsBoldSelected");
                }
            }
        }

        public bool IsItalicSelected
        {
            get
            {
                return isItalicSelected;
            }
            set
            {
                if (isItalicSelected != value)
                {
                    isItalicSelected = value;
                    this.OnPropertyChanged("IsItalicSelected");
                }
            }
        }

        public bool IsUnderlineSelected
        {
            get
            {
                return isUnderlineSelected;
            }
            set
            {
                if (isUnderlineSelected != value)
                {
                    isUnderlineSelected = value;
                    this.OnPropertyChanged("IsUnderlineSelected");
                }
            }
        }

        public bool IsGroupAction
        {
            get
            {
                return isGroupAction;
            }
            set
            {
                if (isGroupAction != value)
                {
                    isGroupAction = value;
                    this.OnPropertyChanged("IsGroupAction");
                }
            }
        }

        public UndoRedoState State { get; set; }

        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);

            var selectedItem = this.SelectedItems as SelectorViewModel;
            switch (name)
            {
                case "SelectedFontFamily":
                    this.UpdateFormatingProperties(updateFontFamily: true);
                    break;
                case "SelectedFontSize":
                    this.UpdateFormatingProperties(updateFontSize: true);
                    break;
                case "SelectedFontBrush":
                    this.UpdateFormatingProperties(updateFontColor: true);
                    break;
                case "SelectedFillBrush":
                    if (canLogData && !isGroupAction)
                        this.HistoryManager.BeginComposite();

                    foreach (SfNodeViewModel node in selectedItem.Nodes as IEnumerable<object>)
                    {
                        if (canLogData && !isGroupAction)
                        {
                            var data = new System.Tuple<SfNodeViewModel, NodeState>(node, node.GetCurrentState());
                            this.HistoryManager.LogData(this, data);
                        }

                        node.FillColor = selectedFillBrush;
                    }

                    if (canLogData && !isGroupAction)
                        this.HistoryManager.EndComposite();
                    break;
                case "SelectedStrokeBrush":
                    if (canLogData && !isGroupAction)
                        this.HistoryManager.BeginComposite();
                    foreach (SfNodeViewModel node in selectedItem.Nodes as IEnumerable<object>)
                    {
                        if (canLogData && !isGroupAction)
                        {
                            var data = new System.Tuple<SfNodeViewModel, NodeState>(node, node.GetCurrentState());
                            this.HistoryManager.LogData(this, data);
                        }

                        node.StrokeColor = selectedStrokeBrush;
                    }

                    foreach (SfConnectorViewModel connector in selectedItem.Connectors as IEnumerable<object>)
                    {
                        if (canLogData && !isGroupAction)
                        {
                            var data = new System.Tuple<SfConnectorViewModel, ConnectorState>(connector, connector.GetCurrentState());
                            this.HistoryManager.LogData(this, data);
                        }

                        connector.StrokeColor = selectedStrokeBrush;
                    }

                    if (canLogData && !isGroupAction)
                        this.HistoryManager.EndComposite();
                    break;
                case "IsGroupAction":
                    if (isGroupAction)
                    {
                        HistoryManager.BeginComposite();
                    }
                    else
                    {
                        HistoryManager.EndComposite();
                    }
                    break;
            }
        }

        private void UpdateFormatingProperties(bool updateFontFamily = false, bool updateFontSize = false, bool updateFontColor = false)
        {
            if (canLogData && !isGroupAction)
                this.HistoryManager.BeginComposite();
            var selectedItem = this.SelectedItems as SelectorViewModel;
            foreach (INode node in selectedItem.Nodes as IEnumerable<object>)
            {
                if (node.Annotations is IEnumerable<IAnnotation>)
                {
                    foreach (IAnnotation annotation in node.Annotations as IEnumerable<IAnnotation>)
                    {
                        if (canLogData && !isGroupAction)
                        {
                            var data = new System.Tuple<IAnnotation, AnnotationState>(annotation, annotation.GetCurrentState());
                            this.HistoryManager.LogData(this, data);
                        }

                        if (updateFontFamily)
                            annotation.FontFamily = selectedFontFamily;

                        if (updateFontSize)
                            annotation.FontSize = selectedFontSize;

                        if (updateFontColor)
                            annotation.Foreground = selectedFontBrush;
                    }
                }
            }

            foreach (IConnector connector in selectedItem.Connectors as IEnumerable<object>)
            {
                if (connector.Annotations is IEnumerable<IAnnotation>)
                {
                    foreach (IAnnotation annotation in connector.Annotations as IEnumerable<IAnnotation>)
                    {
                        if (canLogData && !isGroupAction)
                        {
                            var data = new System.Tuple<IAnnotation, AnnotationState>(annotation, annotation.GetCurrentState());
                            this.HistoryManager.LogData(this, data);
                        }

                        if (updateFontFamily)
                            annotation.FontFamily = selectedFontFamily;

                        if (updateFontSize)
                            annotation.FontSize = selectedFontSize;

                        if (updateFontColor)
                            annotation.Foreground = selectedFontBrush;
                    }
                }
            }

            if (canLogData && !isGroupAction)
                this.HistoryManager.EndComposite();
        }

        private bool canLogData = true;
        private void OnItemSelected(object obj)
        {
            canLogData = false;
            var selector = this.SelectedItems as SelectorViewModel;
            var selectedItem = selector.SelectedItem;
            if (selectedItem == null)
            {
                selectedItem = (selector.Nodes as IEnumerable<object>).FirstOrDefault();
            }
            if (selectedItem == null)
            {
                selectedItem = (selector.Connectors as IEnumerable<object>).FirstOrDefault();
            }

            IAnnotation annotation = null;
            bool isNodeSelected = false;
            bool isConnectorSelected = false;
            if (selectedItem is INode)
            {
                var node = selectedItem as INode;
                if (node.Shape != null && node.ShapeStyle != null)
                {
                    isNodeSelected = true;
                    foreach (Setter setter in node.ShapeStyle.Setters)
                    {
                        if (setter.Property.Name == "Fill")
                        {
                            SelectedFillBrush = setter.Value as SolidColorBrush;
                        }
                        else if (setter.Property.Name == "Stroke")
                        {
                            SelectedStrokeBrush = setter.Value as SolidColorBrush;
                        }
                    }
                }

                if (node.Annotations is IEnumerable<IAnnotation>)
                {
                    annotation = (node.Annotations as IEnumerable<IAnnotation>).FirstOrDefault();
                }
            }
            else if (selectedItem is IConnector)
            {
                isConnectorSelected = true;
                var connector = selectedItem as IConnector;
                if (connector.ConnectorGeometryStyle != null)
                {
                    foreach (Setter setter in connector.ConnectorGeometryStyle.Setters)
                    {
                        if (setter.Property.Name == "Stroke")
                        {
                            SelectedStrokeBrush = setter.Value as SolidColorBrush;
                        }
                    }
                }

                if (connector.Annotations is IEnumerable<IAnnotation>)
                {
                    annotation = (connector.Annotations as IEnumerable<IAnnotation>).FirstOrDefault();
                }
            }

            IsFillBrushEnabled = isNodeSelected;
            IsStrokeBrushEnabled = isNodeSelected || isConnectorSelected;

            if (annotation != null)
            {
                IsBoldSelected = annotation.FontWeight == FontWeights.Bold;
                IsItalicSelected = annotation.FontStyle == FontStyles.Italic;
                IsUnderlineSelected = annotation.TextDecorations != null && annotation.TextDecorations.Any() &&
                    annotation.TextDecorations.First().Location == TextDecorationLocation.Underline;
                SelectedFontBrush = annotation.Foreground as SolidColorBrush;
                SelectedFontFamily = annotation.FontFamily;
                SelectedFontSize = Math.Round(annotation.FontSize, 0);
            }
            else
            {
                IsBoldSelected = false;
                IsItalicSelected = false;
                IsUnderlineSelected = false;
            }

            canLogData = true;
        }

        private void OnItemUnSelected(object obj)
        {
            IsFillBrushEnabled = false;
            IsStrokeBrushEnabled = false;
        }

        private void OnViewPortChanged(object obj)
        {
            var args = obj as ChangeEventArgs<object, ScrollChanged>;
            if (Info != null && (args.Item as SfDiagram).IsLoaded == true && first && args.NewValue.ContentBounds != args.OldValue.ContentBounds)
            {
                (Info as IGraphInfo).BringIntoCenter(args.NewValue.ContentBounds);
                first = false;
            }
        }

        private void OnHistoryChanged(object obj)
        {
            UndoText = string.Empty;
            foreach (HistoryEntry entry in HistoryManager.UndoStack as Stack<HistoryEntry>)
            {
                if (UndoText == string.Empty)
                {
                    UndoText = entry.Action.ToString();
                }
                else
                {
                    UndoText = UndoText + "\n" + entry.Action.ToString();
                }
            }

            RedoText = string.Empty;
            foreach (HistoryEntry entry in HistoryManager.RedoStack as Stack<HistoryEntry>)
            {
                if (RedoText == string.Empty)
                {
                    RedoText = entry.Action.ToString();
                }
                else
                {
                    RedoText = RedoText + "\n" + entry.Action.ToString();
                }
            }
        }

        private SfConnectorViewModel CreateConnector(SfNodeViewModel sourcenode, SfNodeViewModel targetnode, string content)
        {
            var con = new SfConnectorViewModel()
            {
                SourceNode = sourcenode,
                TargetNode = targetnode,
                Annotations = null,
                TargetDecorator = resourceDictionary["ClosedSharp"],
            };

            if(targetnode.Ports != null && (targetnode.Ports as PortCollection).Count > 0 && content != "")
            {
                con.TargetPort = (targetnode.Ports as PortCollection).First() as NodePortViewModel;
            }

            if(sourcenode.Ports != null && (sourcenode.Ports as PortCollection).Count > 0 && content != "" && content == "Yes")
            {
                con.SourcePort = (sourcenode.Ports as PortCollection).First() as NodePortViewModel;
            }

            if (content != "")
            {
                if (content == "Yes")
                {
                    con.Annotations = new AnnotationCollection()
                    {
                        new TextAnnotationViewModel()
                        {
                            Text = content,
                            Pivot = new Point(0.5, 0),
                        },
                    };
                }

                else if(content == "No" && ((targetnode.Annotations as AnnotationCollection).First() as TextAnnotationViewModel).Text == "End") 
                {
                    con.Annotations = new AnnotationCollection()
                    {
                        new TextAnnotationViewModel()
                        {
                            Text = content,
                            Pivot = new Point(0,1),
                            Margin = new Thickness(0,0,0,10),
                            RotateAngle = -90,
                        },
                    };
                }

                else if(content == "No")
                {
                    con.Annotations = new AnnotationCollection()
                    {
                        new TextAnnotationViewModel()
                        {
                            Text = content,
                            Pivot = new Point(0.5, 0)
                        },
                    };
                }
            }

            (Connectors as ObservableCollection<SfConnectorViewModel>).Add(con);

            return con;
        }

        private SfNodeViewModel CreateNode(double offsetx, double offsety, string shape, string content, string shapestylecolor)
        {
            var node = new SfNodeViewModel()
            {
                OffsetX = offsetx,
                OffsetY = offsety,
                Shape = resourceDictionary[shape],
                UnitWidth = 120,
            };

            if(content == "Design")
            {
                node.Ports = new PortCollection()
                {
                    new NodePortViewModel()
                    {
                        NodeOffsetX = 0,
                        NodeOffsetY = 0.5,
                        ConnectionDirection = ConnectionDirection.Left,
                        Constraints = PortConstraints.Default | PortConstraints.ConnectionDirection,
                    },
                };
            }

            if (content == "Design Errors?")
            {
                node.Ports = new PortCollection()
                {
                    new NodePortViewModel()
                    {
                        NodeOffsetX = 0.5,
                        NodeOffsetY = 1,
                        ConnectionDirection = ConnectionDirection.Bottom,
                        Constraints = PortConstraints.Default | PortConstraints.ConnectionDirection,
                    },
                };
            }

            if (content == "Errors?")
            {
                node.Ports = new PortCollection()
                {
                    new NodePortViewModel()
                    {
                        NodeOffsetX = 0,
                        NodeOffsetY = 0.5,
                        ConnectionDirection = ConnectionDirection.Left,
                        Constraints = PortConstraints.Default | PortConstraints.ConnectionDirection,
                    },
                };
            }

            Style shapestyle = new Style(typeof(Path));
            shapestyle.Setters.Add(new Setter(Path.StrokeProperty, Brushes.WhiteSmoke));
            shapestyle.Setters.Add(new Setter(Path.StrokeThicknessProperty, 1d));
            shapestyle.Setters.Add(new Setter(Path.StretchProperty, Stretch.Fill));

            if (shapestylecolor == "Pink")
            {
                shapestyle.Setters.Add(new Setter(Path.FillProperty, Brushes.LightPink));
            }
            else if (shapestylecolor == "Grey")
            {
                shapestyle.Setters.Add(new Setter(Path.FillProperty, Brushes.LightGray));
            }
            else if (shapestylecolor == "Green")
            {
                shapestyle.Setters.Add(new Setter(Path.FillProperty, Brushes.LightGreen));
            }

            node.ShapeStyle = shapestyle;

            if (shape != "Diamond")
            {
                node.UnitHeight = 40;
            }
            else
            {
                node.UnitHeight = 100;
            }

            if (content != "")
            {
                node.Annotations = new AnnotationCollection()
                {
                    new TextAnnotationViewModel()
                    {
                        Text = content,
                        WrapText = TextWrapping.NoWrap,
                    },
                };
            }

            (Nodes as ObservableCollection<SfNodeViewModel>).Add(node);

            return node;
        }

        public bool CanUndo(object data)
        {
            return true;
        }

        public bool CanRedo(object data)
        {
            return true;
        }

        public object Undo(object data)
        {
            if (data is System.Tuple<SfNodeViewModel, NodeState>)
            {
                var node = (data as System.Tuple<SfNodeViewModel, NodeState>).Item1;
                var currentData = new System.Tuple<SfNodeViewModel, NodeState>(node, node.GetCurrentState());
                node.UpdateState((data as System.Tuple<SfNodeViewModel, NodeState>).Item2);
                return currentData;
            }
            else if (data is System.Tuple<SfConnectorViewModel, ConnectorState>)
            {
                var connector = (data as System.Tuple<SfConnectorViewModel, ConnectorState>).Item1;
                var currentData = new System.Tuple<SfConnectorViewModel, ConnectorState>(connector, connector.GetCurrentState());
                connector.UpdateState((data as System.Tuple<SfConnectorViewModel, ConnectorState>).Item2);
                return currentData;
            }
            else if (data is System.Tuple<IAnnotation, AnnotationState>)
            {
                var annotation = (data as System.Tuple<IAnnotation, AnnotationState>).Item1;
                var currentData = new System.Tuple<IAnnotation, AnnotationState>(annotation, annotation.GetCurrentState());
                annotation.UpdateState((data as System.Tuple<IAnnotation, AnnotationState>).Item2);
                return currentData;
            }

            return null;
        }

        public object Redo(object data)
        {
            if (data is System.Tuple<SfNodeViewModel, NodeState>)
            {
                var node = (data as System.Tuple<SfNodeViewModel, NodeState>).Item1;
                var currentData = new System.Tuple<SfNodeViewModel, NodeState>(node, node.GetCurrentState());
                node.UpdateState((data as System.Tuple<SfNodeViewModel, NodeState>).Item2);
                return currentData;
            }
            else if (data is System.Tuple<SfConnectorViewModel, ConnectorState>)
            {
                var connector = (data as System.Tuple<SfConnectorViewModel, ConnectorState>).Item1;
                var currentData = new System.Tuple<SfConnectorViewModel, ConnectorState>(connector, connector.GetCurrentState());
                connector.UpdateState((data as System.Tuple<SfConnectorViewModel, ConnectorState>).Item2);
                return currentData;
            }
            else if (data is System.Tuple<IAnnotation, AnnotationState>)
            {
                var annotation = (data as System.Tuple<IAnnotation, AnnotationState>).Item1;
                var currentData = new System.Tuple<IAnnotation, AnnotationState>(annotation, annotation.GetCurrentState());
                annotation.UpdateState((data as System.Tuple<IAnnotation, AnnotationState>).Item2);
                return currentData;
            }

            return null;
        }
    }

    public class SfNodeViewModel: NodeViewModel
    {
        private Brush fillColor = (SolidColorBrush)new BrushConverter().ConvertFromString("White");
        private Brush strokeColor = (SolidColorBrush)new BrushConverter().ConvertFromString("#444444");

        public SfNodeViewModel() : base()
        {
            this.UpdateStyle();
        }

        public Brush FillColor
        {
            get
            {
                return fillColor;
            }
            set
            {
                if (fillColor != value)
                {
                    this.fillColor = value;
                    this.OnPropertyChanged("FillColor");
                }
            }
        }

        public Brush StrokeColor
        {
            get
            {
                return strokeColor;
            }
            set
            {
                if (strokeColor != value)
                {
                    this.strokeColor = value;
                    this.OnPropertyChanged("StrokeColor");
                }
            }
        }

        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);

            switch (name)
            {
                case "FillColor":
                    this.UpdateStyle("Fill");
                    break;
                case "StrokeColor":
                    this.UpdateStyle("Stroke");
                    break;
            }
        }

        private void UpdateStyle(string propertyName = default(string))
        {
            var newStyle = new Style() { TargetType = typeof(System.Windows.Shapes.Path) };
            if (this.ShapeStyle == null)
            {
                newStyle.Setters.Add(new Setter() { Property = Path.StretchProperty, Value = Stretch.Fill });
                newStyle.Setters.Add(new Setter() { Property = Path.FillProperty, Value = this.fillColor });
                newStyle.Setters.Add(new Setter() { Property = Path.StrokeProperty, Value = this.strokeColor });
                newStyle.Setters.Add(new Setter() { Property = Path.StrokeThicknessProperty, Value = 1d });
            }
            else
            {
                foreach (Setter setter in this.ShapeStyle.Setters)
                {
                    if (setter.Property.Name == propertyName)
                    {
                        if (propertyName == "Fill")
                        {
                            var newSetter = new Setter()
                            {
                                Property = Path.FillProperty,
                                Value = this.fillColor
                            };
                            newStyle.Setters.Add(newSetter);
                        }
                        else if (propertyName == "Stroke")
                        {
                            var newSetter = new Setter()
                            {
                                Property = Path.StrokeProperty,
                                Value = this.strokeColor
                            };
                            newStyle.Setters.Add(newSetter);
                        }

                        continue;
                    }

                    newStyle.Setters.Add(setter);
                }
            }

            this.ShapeStyle = newStyle;
        }
    }

    public class SfConnectorViewModel : ConnectorViewModel
    {
        private Brush strokeColor = (SolidColorBrush)new BrushConverter().ConvertFromString("#444444");

        public SfConnectorViewModel() : base()
        {
            this.UpdateStyle();
            this.UpdateDecoratorStyle();
        }

        public Brush StrokeColor
        {
            get
            {
                return strokeColor;
            }
            set
            {
                if (strokeColor != value)
                {
                    this.strokeColor = value;
                    this.OnPropertyChanged("StrokeColor");
                }
            }
        }

        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);

            switch (name)
            {
                case "StrokeColor":
                    this.UpdateStyle("Stroke");
                    this.UpdateDecoratorStyle("Fill");
                    break;
            }
        }

        private void UpdateStyle(string propertyName = default(string))
        {
            var newStyle = new Style() { TargetType = typeof(Path) };
            if (propertyName == default(string))
            {
                newStyle.Setters.Add(new Setter() { Property = Path.StrokeProperty, Value = this.strokeColor });
                newStyle.Setters.Add(new Setter() { Property = Path.StrokeThicknessProperty, Value = 1d });
            }
            else
            {
                foreach (Setter setter in this.ConnectorGeometryStyle.Setters)
                {
                    if (setter.Property.Name == propertyName)
                    {
                        if (propertyName == "Stroke")
                        {
                            var newSetter = new Setter()
                            {
                                Property = Path.StrokeProperty,
                                Value = this.strokeColor
                            };
                            newStyle.Setters.Add(newSetter);
                        }

                        continue;
                    }

                    newStyle.Setters.Add(setter);
                }
            }

            this.ConnectorGeometryStyle = newStyle;
        }

        private void UpdateDecoratorStyle(string propertyName = default(string))
        {
            var newStyle = new Style() { TargetType = typeof(Path) };
            if (propertyName == default(string))
            {
                newStyle.Setters.Add(new Setter() { Property = Path.FillProperty, Value = this.strokeColor });
                newStyle.Setters.Add(new Setter() { Property = Path.StrokeThicknessProperty, Value = 1d });
                newStyle.Setters.Add(new Setter() { Property = Path.StretchProperty, Value = Stretch.Fill });
            }
            else
            {
                foreach (Setter setter in this.TargetDecoratorStyle.Setters)
                {
                    if (setter.Property.Name == propertyName)
                    {
                        if (propertyName == "Fill")
                        {
                            var newSetter = new Setter()
                            {
                                Property = Path.FillProperty,
                                Value = this.strokeColor
                            };
                            newStyle.Setters.Add(newSetter);
                        }

                        continue;
                    }

                    newStyle.Setters.Add(setter);
                }
            }

            this.TargetDecoratorStyle = newStyle;
        }
    }

    public struct NodeState
    {
        public Brush Fill { get; set; }
        public Brush Stroke { get; set; }
    }

    public struct ConnectorState
    {
        public Brush Stroke { get; set; }
    }

    public struct AnnotationState
    {
        public Brush Foreground { get; set; }
        public FontFamily FontFamily {get; set;}
        public double FontSize { get; set; }
    }

    public static class Utility
    {
        public static NodeState GetCurrentState(this SfNodeViewModel node)
        {
            return new NodeState() { Fill = node.FillColor, Stroke = node.StrokeColor };
        }

        public static ConnectorState GetCurrentState(this SfConnectorViewModel connector)
        {
            return new ConnectorState() { Stroke = connector.StrokeColor };
        }

        public static AnnotationState GetCurrentState(this IAnnotation annotation)
        {
            return new AnnotationState() { Foreground = annotation.Foreground as SolidColorBrush, FontFamily = annotation.FontFamily, FontSize = annotation.FontSize };
        }

        public static void UpdateState(this SfNodeViewModel node, NodeState state)
        {
            node.FillColor = state.Fill;
            node.StrokeColor = state.Stroke;
        }

        public static void UpdateState(this SfConnectorViewModel connector, ConnectorState state)
        {
            connector.StrokeColor = state.Stroke;
        }

        public static void UpdateState(this IAnnotation annotation, AnnotationState state)
        {
            annotation.Foreground = state.Foreground;
            annotation.FontFamily = state.FontFamily;
            annotation.FontSize = state.FontSize;
        }
    }
}
