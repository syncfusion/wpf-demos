#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    class SerializationViewModel : DiagramViewModel
    {
        #region Fields

        private ICommand _NewCommand;
        private ICommand _SaveCommand;
        private ICommand _LoadCommand;
        private bool _enabled;
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

            SerializationCustomNode Node1 = CreateNode(450, 60, "Ellipse", "Start", (SolidColorBrush)(new BrushConverter().ConvertFrom("#D0F0F1")), (SolidColorBrush)(new BrushConverter().ConvertFrom("#797979")));
            SerializationCustomNode Node2 = CreateNode(450, 210, "Rectangle", "Alarm Rings", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FBFDC5")), (SolidColorBrush)(new BrushConverter().ConvertFrom("#797979")));
            SerializationCustomNode Node3 = CreateNode(450, 360, "Diamond", "Ready to Get Up?", (SolidColorBrush)(new BrushConverter().ConvertFrom("#C5EFAF")), (SolidColorBrush)(new BrushConverter().ConvertFrom("#797979")));
            SerializationCustomNode Node4 = CreateNode(700, 360, "Rectangle", "Hit Snooze Button", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FBFDC5")), (SolidColorBrush)(new BrushConverter().ConvertFrom("#797979")));
            SerializationCustomNode Node5 = CreateNode(700, 210, "Delay", "Delay", (SolidColorBrush)(new BrushConverter().ConvertFrom("#F8EEE5")), (SolidColorBrush)(new BrushConverter().ConvertFrom("#797979")));
            SerializationCustomNode Node6 = CreateNode(450, 510, "Rectangle", "Climb Out of Bed", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FBFDC5")), (SolidColorBrush)(new BrushConverter().ConvertFrom("#797979")));
            SerializationCustomNode Node7 = CreateNode(450, 660, "Ellipse", "End", (SolidColorBrush)(new BrushConverter().ConvertFrom("#D0F0F1")), (SolidColorBrush)(new BrushConverter().ConvertFrom("#797979")));

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
                NodeViewModel node = (obj as ItemSelectedEventArgs).Item as SerializationCustomNode;
                this.Fillcolor = (node as SerializationCustomNode).Fillcolor;
                this.Strokecolor = (node as SerializationCustomNode).Strokecolor;
                Enabled = true;
            }
        }

        /// <summary>
        /// This method is used to execute ItemUnselected command.
        /// </summary>
        /// <param name="obj"></param>
        private void OnItemUnSelected(object obj)
        {
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
                    (node as SerializationCustomNode).Strokecolor = value;
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
                    (node as SerializationCustomNode).Fillcolor = value;
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
            if (args.ItemSource == ItemSource.Load)
            {
                if (args.Item is SerializationCustomNode)
                {
                    SerializationCustomNode node = args.Item as SerializationCustomNode;
                    this.Fillcolor = node.Fillcolor;
                    this.Strokecolor = node.Strokecolor;
                }
                else if (args.Item is CustomConnector)
                {
                    CustomConnector con = args.Item as CustomConnector;
                }
            }
            else if (args.ItemSource == ItemSource.Stencil)
            {
                if (args.Item is SerializationCustomNode)
                {
                    SerializationCustomNode node = args.Item as SerializationCustomNode;
                    node.Fillcolor = new SolidColorBrush(Colors.CornflowerBlue);
                    node.Strokecolor = new SolidColorBrush(Colors.CornflowerBlue);
                }
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
        private SerializationCustomNode CreateNode(double offsetx, double offsety, string shape, string content, Brush fillcolor, Brush strokecolor)
        {
            SerializationCustomNode node = new SerializationCustomNode()
            {
                UnitHeight = 70,
                UnitWidth = 145,
                OffsetX = offsetx,
                OffsetY = offsety,
                Shape = resourceDictionary[shape],
                Fillcolor = fillcolor,
                Strokecolor = strokecolor,
            };

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

    public class SerializationCustomNode : NodeViewModel
    {
        private Brush _fillcolor;
        private Brush _strokecolor;

        public SerializationCustomNode()
        {

        }

        /// <summary>
        /// Gets or sets the Strokecolor for Nodes
        /// </summary>         
        [DataMember]
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
                }
            }
        }

        /// <summary>
        /// Gets or sets the Fillcolor for Nodes
        /// </summary>
        [DataMember]
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
                }
            }
        }
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
