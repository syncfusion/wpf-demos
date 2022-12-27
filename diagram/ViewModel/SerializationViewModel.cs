#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    class SerializationViewModel : DiagramViewModel
    {
        #region Fields

        private ICommand _NewCommand;
        private ICommand _SaveCommand;
        private ICommand _LoadCommand;
        private bool _enabled;
        private bool _bold;
        private bool _italic;
        private bool _underline;
        private Brush _fillcolor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
        private Brush _strokecolor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

        #endregion

        ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/Syncfusion.SfDiagram.Wpf;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
        };

        public SerializationViewModel()
        {
            SelectedItems = new SelectorViewModel();

            HorizontalRuler = new Ruler() { Orientation = Orientation.Horizontal };
            VerticalRuler = new Ruler() { Orientation = Orientation.Vertical };

            NodeViewModel Node1 = CreateNode(450, 60, "Ellipse", "Start", (SolidColorBrush)(new BrushConverter().ConvertFrom("#D0F0F1")), (SolidColorBrush)(new BrushConverter().ConvertFrom("#797979")));
            NodeViewModel Node2 = CreateNode(450, 210, "Rectangle", "Alarm Rings", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FBFDC5")), (SolidColorBrush)(new BrushConverter().ConvertFrom("#797979")));
            NodeViewModel Node3 = CreateNode(450, 360, "Diamond", "Ready to Get Up?", (SolidColorBrush)(new BrushConverter().ConvertFrom("#C5EFAF")), (SolidColorBrush)(new BrushConverter().ConvertFrom("#797979")));
            NodeViewModel Node4 = CreateNode(700, 360, "Rectangle", "Hit Snooze Button", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FBFDC5")), (SolidColorBrush)(new BrushConverter().ConvertFrom("#797979")));
            NodeViewModel Node5 = CreateNode(700, 210, "Delay", "Delay", (SolidColorBrush)(new BrushConverter().ConvertFrom("#F8EEE5")), (SolidColorBrush)(new BrushConverter().ConvertFrom("#797979")));
            NodeViewModel Node6 = CreateNode(450, 510, "Rectangle", "Climb Out of Bed", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FBFDC5")), (SolidColorBrush)(new BrushConverter().ConvertFrom("#797979")));
            NodeViewModel Node7 = CreateNode(450, 660, "Ellipse", "End", (SolidColorBrush)(new BrushConverter().ConvertFrom("#D0F0F1")), (SolidColorBrush)(new BrushConverter().ConvertFrom("#797979")));

            ConnectorViewModel Con1 = CreateConnector(Node1, Node2, "");
            ConnectorViewModel Con2 = CreateConnector(Node2, Node3, "");
            ConnectorViewModel Con3 = CreateConnector(Node3, Node4, "No");
            ConnectorViewModel Con4 = CreateConnector(Node3, Node6, "Yes");
            ConnectorViewModel Con5 = CreateConnector(Node5, Node2, "After 5 mins");
            ConnectorViewModel Con6 = CreateConnector(Node4, Node5, "");
            ConnectorViewModel Con7 = CreateConnector(Node6, Node7, "");

            NewCommand = new DelegateCommand(OnNew);
            LoadCommand = new DelegateCommand(OnLoad);
            SaveCommand = new DelegateCommand(OnSave);
            ItemAddedCommand = new DelegateCommand(ItemAddedExecution);
            ItemSelectedCommand = new DelegateCommand(OnItemSelectedCommand);
            ItemUnSelectedCommand = new DelegateCommand(OnItemUnSelected);
        }

        #region Commands

        public ICommand NewCommand
        {
            get { return _NewCommand; }
            set { _NewCommand = value; }
        }

        public ICommand LoadCommand
        {
            get { return _LoadCommand; }
            set { _LoadCommand = value; }
        }

        public ICommand SaveCommand
        {
            get { return _SaveCommand; }
            set { _SaveCommand = value; }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Strokecolor for Nodes
        /// </summary>
        public Brush Strokecolor
        {
            get
            {
                return _strokecolor;
            }
            set
            {
                if (_strokecolor != value)
                {
                    _strokecolor = value;
                    OnPropertyChanged("Strokecolor");
                    OnStrokeColorChanged(_strokecolor);
                }
            }
        }

        /// <summary>
        /// Gets or sets the Fillcolor for Nodes
        /// </summary>
        public Brush Fillcolor
        {
            get
            {
                return _fillcolor;
            }
            set
            {
                if (_fillcolor != value)
                {
                    _fillcolor = value;
                    OnPropertyChanged("Fillcolor");
                    OnFillColorChanged(_fillcolor);
                }
            }
        }

        /// <summary>
        /// Gets or sets whether to enable or disable
        /// </summary>
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                if (_enabled != value)
                {
                    _enabled = value;
                    OnPropertyChanged("Enabled");
                }
            }
        }

        /// <summary>
        /// Gets or sets whether to enable or disable
        /// </summary>
        public bool ToggleBold
        {
            get
            {
                return _bold;
            }
            set
            {
                if (_bold != value)
                {
                    _bold = value;
                    OnPropertyChanged("ToggleBold");
                }
            }
        }

        /// <summary>
        /// Gets or sets whether to enable or disable
        /// </summary>
        public bool ToggleItalic
        {
            get
            {
                return _italic;
            }
            set
            {
                if (_italic != value)
                {
                    _italic = value;
                    OnPropertyChanged("ToggleItalic");
                }
            }
        }

        /// <summary>
        /// Gets or sets whether to enable or disable
        /// </summary>
        public bool ToggleUnderline
        {
            get
            {
                return _underline;
            }
            set
            {
                if (_underline != value)
                {
                    _underline = value;
                    OnPropertyChanged("ToggleUnderline");
                }
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Method for ItemSelected Command
        /// </summary>
        /// <param name="obj"></param>
        private void OnItemSelectedCommand(object obj)
        {
            if ((obj as ItemSelectedEventArgs).Item is INode)
            {
                NodeViewModel node = (obj as ItemSelectedEventArgs).Item as NodeViewModel;

                if (node.ShapeStyle != null)
                {
                    foreach (Setter set in node.ShapeStyle.Setters)
                    {
                        if (set.Property.Name == "Fill")
                        {
                            this.Fillcolor = (SolidColorBrush)(new BrushConverter().ConvertFrom(set.Value.ToString()));
                        }
                        if (set.Property.Name == "Stroke")
                        {
                            this.Strokecolor = (SolidColorBrush)(new BrushConverter().ConvertFrom(set.Value.ToString()));
                        }
                    }
                }

                if(node.Annotations != null && (node.Annotations as AnnotationCollection).Count > 0)
                {
                    IAnnotation anno = (node.Annotations as AnnotationCollection).First() as IAnnotation;

                    if (anno != null)
                    {
                        if (anno.FontWeight == FontWeights.Bold)
                        {
                            ToggleBold = true;
                        }
                        else
                        {
                            ToggleBold = false;
                        }

                        if (anno.FontStyle == FontStyles.Italic)
                        {
                            ToggleItalic = true;
                        }
                        else
                        {
                            ToggleItalic = false;
                        }

                        if (anno.TextDecorations == null)
                        {
                            ToggleUnderline = false;
                        }
                        else
                        {
                            if (anno.TextDecorations.Any(i => i.Location == TextDecorationLocation.Underline))
                            {
                                ToggleUnderline = true;
                            }
                            else
                            {
                                ToggleUnderline = false;
                            }
                        }
                    }
                }
                else
                {
                    ToggleBold = false;
                    ToggleItalic = false;
                    ToggleUnderline = false;
                }

                Enabled = true;
            }
        }

        /// <summary>
        /// This method is used to execute ItemUnselected command.
        /// </summary>
        /// <param name="obj"></param>
        private void OnItemUnSelected(object obj)
        {
            ToggleBold = false;
            ToggleItalic = false;
            ToggleUnderline = false;
            Enabled = false;
        }

        /// <summary>
        /// This method is used to change the StrokeColor of the Node
        /// </summary>
        /// <param name="strokecolor"></param>
        private void OnStrokeColorChanged(Brush strokecolor)
        {
            Brush value = strokecolor;
            if (this.Info != null && (this.Info as IGraph).SelectedItems != null)
            {
                SelectorViewModel selectorvm = (this.Info as IGraph).SelectedItems as SelectorViewModel;
                if ((selectorvm.Nodes as ObservableCollection<object>).Count > 0)
                {
                    NodeViewModel node = (selectorvm.Nodes as ObservableCollection<object>).ElementAt(0) as NodeViewModel;

                    Style newstyle = new Style(typeof(System.Windows.Shapes.Path));

                    foreach(Setter set in node.ShapeStyle.Setters)
                    {
                        if(set.Property.Name == "Stroke")
                        {
                            newstyle.Setters.Add(new Setter(System.Windows.Shapes.Path.StrokeProperty, value));
                        }
                        else
                        {
                            newstyle.Setters.Add(set);
                        }
                    }

                    node.ShapeStyle = newstyle;

                }
            }
        }

        /// <summary>
        /// This method is used to change the FillColor of the Node
        /// </summary>
        /// <param name="fillcolor"></param>
        private void OnFillColorChanged(Brush fillcolor)
        {
            Brush value = fillcolor;
            if (this.Info != null && (this.Info as IGraph).SelectedItems != null)
            {
                SelectorViewModel selectorvm = (this.Info as IGraph).SelectedItems as SelectorViewModel;
                if ((selectorvm.Nodes as ObservableCollection<object>).Count > 0)
                {
                    NodeViewModel node = (selectorvm.Nodes as ObservableCollection<object>).ElementAt(0) as NodeViewModel;
                    Style newstyle = new Style(typeof(System.Windows.Shapes.Path));

                    foreach (Setter set in node.ShapeStyle.Setters)
                    {
                        if (set.Property.Name == "Fill")
                        {
                            newstyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, value));
                        }
                        else
                        {
                            newstyle.Setters.Add(set);
                        }
                    }

                    node.ShapeStyle = newstyle;
                }
            }
        }

        /// <summary>
        /// This method is used to execute Item Added command
        /// </summary>
        /// <param name="obj"></param>
        private void ItemAddedExecution(object obj)
        {
            var args = obj as ItemAddedEventArgs;
            if (args.ItemSource == ItemSource.Load || args.ItemSource == ItemSource.ClipBoard)
            {

            }
        }

        /// <summary>
        /// This method is used to execute Save command
        /// </summary>
        /// <param name="obj"></param>
        private void OnSave(object obj)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save XML";
            dialog.Filter = "XML File (*.xml)|*.xml";
            if (dialog.ShowDialog() == true)
            {
                using (Stream s = File.Open(dialog.FileName, FileMode.OpenOrCreate))
                {
                    s.SetLength(0);
                    (Info as IGraphInfo).Save(s);
                }
            }
        }

        /// <summary>
        /// This method is used to execute load command
        /// </summary>
        /// <param name="obj"></param>
        private void OnLoad(object obj)
        {
            if (this.HasChanges)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show(
                            "Do you want to save the Diagram?",
                            "SfDiagram",
                            MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    this.OnSave(null);
                }
            }

            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                using (Stream myStream = dialog.OpenFile())
                {
                    (Info as IGraphInfo).Load(myStream);
                }
            }
        }

        /// <summary>
        /// This method is used to execute new command
        /// </summary>
        /// <param name="obj"></param>
        private void OnNew(object obj)
        {
            if (this.HasChanges)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show(
                            "Do you want to save the Diagram?",
                            "SfDiagram",
                            MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    this.OnSave(null);
                }
            }
                
            Nodes = new NodeCollection();
            Connectors = new ConnectorCollection();
        }

        /// <summary>
        /// This method is used to create Node
        /// </summary>
        /// <param name="offsetx"></param>
        /// <param name="offsety"></param>
        /// <param name="shape"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private NodeViewModel CreateNode(double offsetx, double offsety, string shape, string content, Brush fillcolor, Brush strokecolor)
        {
            NodeViewModel node = new NodeViewModel()
            {
                UnitHeight = 70,
                UnitWidth = 145,
                OffsetX = offsetx,
                OffsetY = offsety,
                Shape = resourceDictionary[shape],
            };

            Style style = new Style(typeof(System.Windows.Shapes.Path));
            style.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, fillcolor));
            style.Setters.Add(new Setter(System.Windows.Shapes.Path.StrokeProperty, strokecolor));
            style.Setters.Add(new Setter(System.Windows.Shapes.Path.StrokeThicknessProperty, 2d));
            style.Setters.Add(new Setter(System.Windows.Shapes.Path.StretchProperty, Stretch.Fill));

            node.ShapeStyle = style;

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

            (Nodes as NodeCollection).Add(node);

            return node;
        }

        /// <summary>
        /// This method is used to create Connectors
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        private CustomConnector CreateConnector(NodeViewModel sourcenode, NodeViewModel targetnode, string content)
        {
            CustomConnector con = new CustomConnector()
            {
                SourceNode = sourcenode,
                TargetNode = targetnode,
                Annotations = null,
                ConnectorStyleKey = "ConnectorGeometryStyleSerialization",
                TargetStyleKey = "TargetDecoratorStyleSerialization",

            };

            if (content != "")
            {
                if (content == "No" || content == "After 5 mins")
                {
                    con.Annotations = new AnnotationCollection()
                    {
                        new TextAnnotationViewModel()
                        {
                            Text = content,
                            Pivot = new Point(0.5,0),
                        },
                    };
                }
                else
                {
                    con.Annotations = new AnnotationCollection()
                    {
                        new TextAnnotationViewModel()
                        {
                            Text = content,
                            RotateAngle = -90,
                            Pivot = new Point(0,0.6),
                        },
                    };
                }
            }

            (Connectors as ConnectorCollection).Add(con);

            return con;
        }


        #endregion
    }

    public class CustomConnector : ConnectorViewModel
    {
        private string _ConnectorStyleKey;
        private string _TargetStyleKey;
        public CustomConnector()
        {

        }

        [DataMember]
        public string ConnectorStyleKey
        {
            get
            {
                return _ConnectorStyleKey;
            }
            set
            {
                if (value != _ConnectorStyleKey)
                {
                    _ConnectorStyleKey = value;
                    OnPropertyChanged("ConnectorStyleKey");
                }
            }
        }

        [DataMember]
        public string TargetStyleKey
        {
            get
            {
                return _TargetStyleKey;
            }
            set
            {
                if (value != _TargetStyleKey)
                {
                    _TargetStyleKey = value;
                    OnPropertyChanged("TargetStyleKey");
                }
            }
        }
    }

    //Collection of Symbols
    public class SerializationSymbolCollection : ObservableCollection<object>
    {

    }
}
