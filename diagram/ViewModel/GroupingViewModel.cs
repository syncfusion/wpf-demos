#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using Syncfusion.UI.Xaml.Diagram.Theming;
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
    public class GroupingViewModel : DiagramViewModel
    {
        Brush selectedFontBrush = new SolidColorBrush(Colors.Black);
        FontFamily selectedFontFamily = SystemFonts.MessageFontFamily;
        double selectedFontSize = SystemFonts.MessageFontSize;
        bool isBoldSelected;
        bool isItalicSelected;
        bool isUnderlineSelected;
        bool first = true ;

        ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/Syncfusion.SfDiagram.Wpf;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
        };
       

        public GroupingViewModel()
        {
            SelectedItems = new SelectorViewModel();
            HorizontalRuler = new Ruler() { Orientation = Orientation.Horizontal };

            VerticalRuler = new Ruler() { Orientation = Orientation.Vertical };
            
            Theme = new SimpleTheme();

            NodeViewModel Node1 = CreateNode(100, 150, "Rectangle", "");
            NodeViewModel Node2 = CreateNode(300, 150, "RoundedRectangle", "");
            CreateGroup(Node1, Node2);

            NodeViewModel Node3 = CreateNode(100, 300, "Ellipse", "Start/Stop");
            NodeViewModel Node4 = CreateNode(300, 300, "PredefinedProcess", "Decision");
            NodeViewModel Node5 = CreateNode(100, 450, "Rectangle", "Process");

            NodeViewModel Node6 = CreateNode(625, 225, "Rectangle", "Document 1");
            NodeViewModel Node7 = CreateNode(625, 325, "Rectangle", "Document 2");
            NodeViewModel Node8 = CreateNode(775, 225, "Rectangle", "Document 3");
            NodeViewModel Node9 = CreateNode(775, 325, "Rectangle", "Document 4");
            ContainerViewModel container = CreateContainer("Documents", 320, 300, 700, 250);
            container.Nodes = new NodeCollection()
            {
                Node6, Node7,Node8, Node9
            };

            ItemSelectedCommand = new DelegateCommand(OnItemSelected);
            ItemUnSelectedCommand = new DelegateCommand(OnItemUnSelected);
            ViewPortChangedCommand = new DelegateCommand(OnViewPortChangedCommand);
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

        #region Helper Methods

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
        private void OnViewPortChangedCommand(object obj)
        {
            var args = obj as ChangeEventArgs<object, ScrollChanged>;
            if (Info != null && (args.Item as SfDiagram).IsLoaded == true && args.NewValue.ContentBounds != args.OldValue.ContentBounds && first)
            {
                var bounds = args.NewValue.ContentBounds;
                bounds.Inflate(new Size(70, 70));
                if (bounds.Height > args.NewValue.ViewPort.Height)
                {
                    (Info as IGraphInfo).Commands.FitToPage.Execute(new FitToPageParameter() { FitToPage = FitToPage.FitToPage, Margin = new Thickness(20) });
                }
                else
                {
                    (Info as IGraphInfo).BringIntoCenter(bounds);
                }
                first = false;
            }
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
            SelectedFontBrush = new SolidColorBrush(Colors.Black);
            SelectedFontFamily = SystemFonts.MessageFontFamily;
            SelectedFontSize = SystemFonts.MessageFontSize;
        }

        /// <summary>
        /// This method is used to create Group
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        private void CreateGroup(NodeViewModel node1, NodeViewModel node2)
        {
            GroupViewModel group = new GroupViewModel()
            {
                Nodes = new NodeCollection()
                {
                    node1,
                    node2
                },
                Annotations = new AnnotationCollection()
                {
                    new AnnotationEditorViewModel()
                    {
                        Content = "Group 1",
                    },
                },
            };

            (Groups as GroupCollection).Add(group);
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
                },
                
            };
            container.Shape = resourceDictionary["Rectangle"];

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
        private NodeViewModel CreateNode(double offsetx, double offsety, string shape, string content)
        {
            NodeViewModel node = new NodeViewModel()
            {
                UnitHeight = 60,
                UnitWidth = 100,
                OffsetX = offsetx,
                OffsetY = offsety,
                Shape = resourceDictionary[shape],
            };
            if (content != "")
            {
                node.Annotations = new AnnotationCollection()
                {
                    new AnnotationEditorViewModel()
                    {
                        Content = content,
                    },
                };
            }

            (Nodes as NodeCollection).Add(node);

            return node;
        }

        #endregion
    }
}
