#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Theming;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class ContainersViewModel : DiagramViewModel
    {
        Brush selectedFontBrush = new SolidColorBrush(Colors.Black);
        FontFamily selectedFontFamily = SystemFonts.MessageFontFamily;
        double selectedFontSize = SystemFonts.MessageFontSize;
        bool isBoldSelected;
        bool isItalicSelected;
        bool isUnderlineSelected;
        bool first = true;

        ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/Syncfusion.SfDiagram.Wpf;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
        };

        //Style solidgeometrystyle = new Style(typeof(Path));
        //Style targetdecoratorstyle = new Style(typeof(Path));
        //Style sourcedecoratorstyle = new Style(typeof(Path));

        public ContainersViewModel()
        {
            SelectedItems = new SelectorViewModel();
            HorizontalRuler = new Ruler() { Orientation = Orientation.Horizontal };
            VerticalRuler = new Ruler() { Orientation = Orientation.Vertical };
            Constraints = GraphConstraints.Default | GraphConstraints.Bridging;
            
            #region Node, Connector and Container

            NodeViewModel node1 = CreateNode(100, 300, 60, 100, "HTTP Traffic");
            NodeViewModel node2 = CreateNode(300, 300, 60, 100, "Ingestion service");
            NodeViewModel node3 = CreateNode(450, 300, 60, 100, "Workflow service");
            NodeViewModel node4 = CreateNode(300, 415, 60, 100, "Package service");
            NodeViewModel node5 = CreateNode(450, 415, 60, 150, "Drone Scheduler service");
            NodeViewModel node6 = CreateNode(600, 415, 60, 100, "Delivery service");
            NodeViewModel node7 = CreateNode(380, 130, 60, 90, "Azure Service Bus");
            NodeViewModel node8 = CreateNode(615, 130, 60, 100, "Managed Identities");
            NodeViewModel node9 = CreateNode(800, 130, 60, 100, "Azure Key Vault");
            NodeViewModel node10 = CreateNode(300, 550, 60, 100, "Azure Cosmos DB for MongoDB API");
            NodeViewModel node11 = CreateNode(450, 550, 60, 100, "Azure Cosmos DB");
            NodeViewModel node12 = CreateNode(600, 550, 60, 100, "Azure Cache for Redis");
            NodeViewModel node13 = CreateNode(840, 255, 60, 100, "Azure Application Insights");
            NodeViewModel node14 = CreateNode(940, 350, 60, 100, "Azure Monitor");
            NodeViewModel node15 = CreateNode(840, 445, 60, 100, "Azure Log Analytics workspace");

            #region Ports

            node5.Ports = new PortCollection()
            {
                new NodePortViewModel()
                {
                    NodeOffsetX = 0.9,
                    NodeOffsetY = 0,
                    UnitHeight = 10,
                    UnitWidth = 10,
                    Shape = new RectangleGeometry(){Rect = new Rect(10,10,10,10)},
                },
            };

            node6.Ports = new PortCollection()
            {
                new NodePortViewModel()
                {
                    NodeOffsetX = 0.9,
                    NodeOffsetY = 0,
                    UnitHeight = 10,
                    UnitWidth = 10,
                    Shape = new RectangleGeometry(){Rect = new Rect(10,10,10,10)},
                },
            };

            node13.Ports = new PortCollection()
            {
                new NodePortViewModel()
                {
                    NodeOffsetX = 1,
                    NodeOffsetY = 0.5,
                    UnitHeight = 10,
                    UnitWidth = 10,
                    Shape = new RectangleGeometry(){Rect = new Rect(10,10,10,10)},
                },
            };

            node15.Ports = new PortCollection()
            {
                new NodePortViewModel()
                {
                    NodeOffsetX = 1,
                    NodeOffsetY = 0.5,
                    UnitHeight = 10,
                    UnitWidth = 10,
                    Shape = new RectangleGeometry(){Rect = new Rect(10,10,10,10)},
                },
            };

            node3.Ports = new PortCollection()
            {
                new NodePortViewModel()
                {
                    NodeOffsetX = 0.25,
                    NodeOffsetY = 1,
                    UnitHeight = 10,
                    UnitWidth = 10,
                    Shape = new RectangleGeometry(){Rect = new Rect(10,10,10,10)},                    
                },
                new NodePortViewModel()
                {
                    NodeOffsetX = 0.5,
                    NodeOffsetY = 1,
                    UnitHeight = 10,
                    UnitWidth = 10,
                    Shape = new RectangleGeometry(){Rect = new Rect(10,10,10,10)},
                },
                new NodePortViewModel()
                {
                    NodeOffsetX = 0.75,
                    NodeOffsetY = 1,
                    UnitHeight = 10,
                    UnitWidth = 10,
                    Shape = new RectangleGeometry(){Rect = new Rect(10,10,10,10)},
                },
            };

            node7.Ports = new PortCollection()
            {
                new NodePortViewModel()
                {
                    NodeOffsetX = 0,
                    NodeOffsetY = 0.5,
                    UnitHeight = 10,
                    UnitWidth = 10,
                    Shape = new RectangleGeometry(){Rect = new Rect(10,10,10,10)},
                },
                new NodePortViewModel()
                {
                    NodeOffsetX = 1,
                    NodeOffsetY = 0.5,
                    UnitHeight = 10,
                    UnitWidth = 10,
                    Shape = new RectangleGeometry(){Rect = new Rect(10,10,10,10)},
                },
            };

            node8.Ports = new PortCollection()
            {
                new NodePortViewModel()
                {
                    NodeOffsetX = 0.25,
                    NodeOffsetY = 1,
                    UnitHeight = 10,
                    UnitWidth = 10,
                    Shape = new RectangleGeometry(){Rect = new Rect(10,10,10,10)},
                },
                new NodePortViewModel()
                {
                    NodeOffsetX = 0.75,
                    NodeOffsetY = 1,
                    UnitHeight = 10,
                    UnitWidth = 10,
                    Shape = new RectangleGeometry(){Rect = new Rect(10,10,10,10)},
                },
            };

            #endregion

            ConnectorViewModel con4 = new ConnectorViewModel()
            {
                SourcePort = (node3.Ports as PortCollection).ElementAt(0),
                TargetNode = node4,
            };

            (Connectors as ConnectorCollection).Add(con4);

            ConnectorViewModel con5 = new ConnectorViewModel()
            {
                SourcePort = (node3.Ports as PortCollection).ElementAt(1),
                TargetNode = node5,
            };

            (Connectors as ConnectorCollection).Add(con5);

            ConnectorViewModel con6 = new ConnectorViewModel()
            {
                SourcePort = (node3.Ports as PortCollection).ElementAt(2),
                TargetNode = node6,
            };

            (Connectors as ConnectorCollection).Add(con6);

            ConnectorViewModel con2 = new ConnectorViewModel()
            {
                SourceNode = node2,
                TargetPort = (node7.Ports as PortCollection).ElementAt(0),
            };

            (Connectors as ConnectorCollection).Add(con2);

            ConnectorViewModel con3 = new ConnectorViewModel()
            {
                SourcePort = (node7.Ports as PortCollection).ElementAt(1),
                TargetNode = node3,
            };

            (Connectors as ConnectorCollection).Add(con3);

            ConnectorViewModel con13 = new ConnectorViewModel()
            {
                SourcePort = (node13.Ports as PortCollection).ElementAt(0),
                TargetNode = node14,
            };

            (Connectors as ConnectorCollection).Add(con13);

            ConnectorViewModel con14 = new ConnectorViewModel()
            {
                SourcePort = (node15.Ports as PortCollection).ElementAt(0),
                TargetNode = node14,
            };

            (Connectors as ConnectorCollection).Add(con14);

            ConnectorViewModel con15 = new ConnectorViewModel()
            {
                SourcePort = (node8.Ports as PortCollection).ElementAt(0),
                TargetPort = (node5.Ports as PortCollection).ElementAt(0),
            };

            (Connectors as ConnectorCollection).Add(con15);

            ConnectorViewModel con16 = new ConnectorViewModel()
            {
                SourcePort = (node8.Ports as PortCollection).ElementAt(1),
                TargetPort = (node6.Ports as PortCollection).ElementAt(0),
            };

            (Connectors as ConnectorCollection).Add(con16);


            ContainerViewModel container = CreateContainer("Azure Container Apps environment", 520, 300, 460, 350);

            ConnectorViewModel con1 = CreateConnector(node1, node2);
            ConnectorViewModel con7 = CreateConnector(node4, node10);
            ConnectorViewModel con8 = CreateConnector(node5, node11);
            ConnectorViewModel con9 = CreateConnector(node6, node12);
            ConnectorViewModel con10 = CreateConnector(node8, node9);
            ConnectorViewModel con11 = CreateConnector(container, node13);
            ConnectorViewModel con12 = CreateConnector(container, node15);

            con15.SourceDecorator = resourceDictionary["ClosedSharp"];
            con16.SourceDecorator = resourceDictionary["ClosedSharp"];

            container.Nodes = new NodeCollection() { node2, node3, node4, node5, node6};

            #endregion

            ItemSelectedCommand = new DelegateCommand(OnItemSelected);
            ItemUnSelectedCommand = new DelegateCommand(OnItemUnSelected);
            ViewPortChangedCommand = new DelegateCommand(OnViewPortChangedCommand);
        }


        #region Properties

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

        #endregion


        #region HelperMethods


        private void OnViewPortChangedCommand(object obj)
        {
            var args = obj as ChangeEventArgs<object, ScrollChanged>;
            if (Info != null && (args.Item as SfDiagram).IsLoaded == true && args.NewValue.ContentBounds != args.OldValue.ContentBounds && first)
            {
                var bounds = args.NewValue.ContentBounds;
                bounds.Inflate(new Size(50, 50));
                if (bounds.Height > args.NewValue.ViewPort.Height)
                {
                    (Info as IGraphInfo).Commands.FitToPage.Execute(new FitToPageParameter() { FitToPage = FitToPage.FitToPage, Margin = new Thickness(60) });
                }
                else
                {
                    (Info as IGraphInfo).BringIntoCenter(bounds);
                }
                first = false;
            }
        }


        private ConnectorViewModel CreateConnector(NodeViewModel node1, NodeViewModel node2)
        {
            ConnectorViewModel con = new ConnectorViewModel()
            {
                SourceNode = node1,
                TargetNode = node2,
            };

            (Connectors as ConnectorCollection).Add(con);

            return con;
        }

        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);

            IAnnotation annotation = null;
            if (this.SelectedItems is ISelector && (this.SelectedItems as ISelector).SelectedItem != null)
            {
                var selectedItem = this.SelectedItems as SelectorViewModel;
                annotation = this.GetAnnotations(selectedItem.SelectedItem as IGroupable).FirstOrDefault();
            }

            if (annotation != null)
            {
                switch (name)
                {
                    case "SelectedFontFamily":
                        annotation.FontFamily = SelectedFontFamily;
                        break;
                    case "SelectedFontSize":
                        annotation.FontSize = SelectedFontSize;
                        break;
                    case "SelectedFontBrush":
                        annotation.Foreground = SelectedFontBrush;
                        break;
                }
            }
        }

        private List<IAnnotation> GetAnnotations(IGroupable element)
        {
            var annotations = new List<IAnnotation>();

            if (element is IContainer)
            {
                var container = (IContainer)element;
                if (container.Header != null && container.Header is ContainerHeaderViewModel)
                {
                    ContainerHeaderViewModel header = container.Header as ContainerHeaderViewModel;
                    if (header.Annotation != null)
                    {
                        annotations.Add(header.Annotation);
                    }
                }
            }
            else if (element is INode)
            {
                var node = (INode)element;
                if (node.Annotations != null && node.Annotations is AnnotationCollection)
                {
                    var annotationCollection = (AnnotationCollection)node.Annotations;
                    if (annotationCollection.Count > 0)
                    {
                        foreach (var annotation in annotationCollection)
                        {
                            annotations.Add(annotation);
                        }
                    }
                }
            }

            return annotations;
        }

        private void OnItemSelected(object obj)
        {
            var selectedItems = this.SelectedItems as SelectorViewModel;
            IGroupable selectedItem = null;
            if (selectedItems != null)
            {
                if (selectedItems.Nodes is IEnumerable<object>)
                {
                    selectedItem = (selectedItems.Nodes as IEnumerable<object>).FirstOrDefault() as IGroupable;
                }

                if (selectedItem == null && selectedItems.Groups is IEnumerable<object>)
                {
                    selectedItem = (selectedItems.Groups as IEnumerable<object>).FirstOrDefault() as IGroupable;
                }

                if (selectedItem == null && selectedItems.Connectors is IEnumerable<object>)
                {
                    selectedItem = (selectedItems.Connectors as IEnumerable<object>).FirstOrDefault() as IGroupable;
                }

                if (selectedItem != null)
                {
                    var annotation = this.GetAnnotations(selectedItem).FirstOrDefault();
                    if (annotation != null)
                    {
                        IsBoldSelected = annotation.FontWeight == FontWeights.Bold;
                        IsItalicSelected = annotation.FontStyle == FontStyles.Italic;
                        IsUnderlineSelected = annotation.TextDecorations != null && annotation.TextDecorations.Count > 0;
                        SelectedFontFamily = annotation.FontFamily;
                        SelectedFontSize = annotation.FontSize;
                        SelectedFontBrush = annotation.Foreground;
                    }
                }
            }
        }

        private void OnItemUnSelected(object obj)
        {
            IsBoldSelected = false;
            IsItalicSelected = false;
            IsUnderlineSelected = false;
        }


        /// <summary>
        /// This method is used to create Group
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        private ContainerViewModel CreateContainer(string content, double width, double height, double offsetX, double offsetY)
        {
            ContainerViewModel container = new ContainerViewModel()
            {
                UnitHeight = height,
                UnitWidth = width,
                OffsetX = offsetX,
                OffsetY = offsetY,
            };
            container.Header = new ContainerHeaderViewModel()
            {
                UnitHeight = 40,
                Annotation = new AnnotationEditorViewModel()
                {
                    Content = content,
                    FontSize = 18,
                    FontWeight = FontWeights.Bold,
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#343434"))
                },
            };

            (Groups as GroupCollection).Add(container);

            return container;
        }

        /// <summary>
        /// This method is used to create Node
        /// </summary>
        /// <param name="offsetx"></param>
        /// <param name="offsety"></param>
        /// <param name="shape"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private NodeViewModel CreateNode(double offsetx, double offsety, double height, double width, string content)
        {
            NodeViewModel node = new NodeViewModel()
            {
                UnitHeight = height,
                UnitWidth = width,
                OffsetX = offsetx,
                OffsetY = offsety,
            };
            if (content != "")
            {
                node.Annotations = new AnnotationCollection()
                {
                    new AnnotationEditorViewModel()
                    {
                        Content = content,
                        UnitWidth = 90,
                        TextHorizontalAlignment = TextAlignment.Center,
                        Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#343434"))
                    },
                };
            }

            (Nodes as NodeCollection).Add(node);

            return node;
        }

        #endregion
    }
}
