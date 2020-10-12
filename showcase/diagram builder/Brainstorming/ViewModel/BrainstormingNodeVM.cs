// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BrainstormingNodeVM.cs" company="">
//   
// </copyright>
// <summary>
//   The brainstorming node vm.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Brainstorming.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    using DiagramBuilder.ViewModel;

    using Syncfusion.UI.Xaml.Diagram;
    using Syncfusion.UI.Xaml.Diagram.Controls;
    using Syncfusion.Windows.Shared;

    /// <summary>
    ///     The brainstorming node vm.
    /// </summary>
    public class BrainstormingNodeVM : NodeVM
    {
        ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/syncfusion.diagrambuilder.Wpf;component/Brainstorming/Theme/BrainstormingUI.xaml", UriKind.RelativeOrAbsolute)
        };

        /// <summary>
        ///     The _m child count.
        /// </summary>
        private int _mChildCount;

        /// <summary>
        ///     The _m level.
        /// </summary>
        private int _mLevel;

        /// <summary>
        ///     The _type.
        /// </summary>
        private string _type;

        /// <summary>
        ///     The expand collapse command.
        /// </summary>
        private DelegateCommand<object> expandCollapseCommand;

        /// <summary>
        ///     The shape name.
        /// </summary>
        private string shapeName;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BrainstormingNodeVM" /> class.
        /// </summary>
        public BrainstormingNodeVM()
        {
            this.ShapeName = "Rectangle";

            // Shape = App.Current.Resources["Rectangle"];
            this.ID = Guid.NewGuid();
        }

        /// <summary>
        ///     Gets or sets the child count.
        /// </summary>
        public int ChildCount
        {
            get
            {
                return this._mChildCount;
            }

            set
            {
                if (this._mChildCount != value)
                {
                    this._mChildCount = value;
                    this.OnPropertyChanged("ChildCount");
                }
            }
        }

        /// <summary>
        ///     Gets the expand collapse command.
        /// </summary>
        public DelegateCommand<object> ExpandCollapseCommand
        {
            get
            {
                return this.expandCollapseCommand ?? (this.expandCollapseCommand =
                                                          new DelegateCommand<object>(
                                                              this.ExpandCollapseCommandExecute));
            }
        }

        /// <summary>
        ///     Gets or sets the level.
        /// </summary>
        [DataMember]
        public int Level
        {
            get
            {
                return this._mLevel;
            }

            set
            {
                if (this._mLevel != value)
                {
                    this._mLevel = value;
                    this.OnPropertyChanged("Level");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the shape name.
        /// </summary>
        public string ShapeName
        {
            get
            {
                return this.shapeName;
            }

            set
            {
                if (this.shapeName != value)
                {
                    this.shapeName = value;
                    this.OnPropertyChanged("ShapeName");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        [DataMember]
        public string Type
        {
            get
            {
                return this._type;
            }

            set
            {
                if (this._type != value)
                {
                    this._type = value;
                    this.OnPropertyChanged("Type");
                }
            }
        }

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);
            if (name.Equals("Annotations"))
            {
                // if (Annotations is List<IAnnotation> && (Annotations as AnnotationCollection).Count > 0
                // && (Annotations as AnnotationCollection)[0] is TextAnnotationViewModel)
                // {
                // TextAnnotationViewModel annotation = (Annotations as AnnotationCollection)[0] as TextAnnotationViewModel;
                // annotation.PropertyChanged += Annotation_PropertyChanged;
                // }
                if (this.Annotations is List<IAnnotation> && (this.Annotations as List<IAnnotation>).Count > 0)
                {
                    LabelVM annotation = (this.Annotations as List<IAnnotation>)[0] as LabelVM;
                    annotation.PropertyChanged += this.Annotation_PropertyChanged;
                }
            }
            else if (name.Equals("ShapeName"))
            {
                INodeInfo nodeInfo = (INodeInfo)this.Info;
                LabelVM annotation = ((List<IAnnotation>)this.Annotations)[0] as LabelVM;
                ObservableCollection<IPort> ports = (ObservableCollection<IPort>)this.Ports;
                if (this.ShapeName.Equals("Line"))
                {
                    this.Shape = null;
                    this.ContentTemplate = resourceDictionary["LineShapeTemplate"] as DataTemplate;
                    this.Content = this;
                    annotation.TextVerticalAlignment = VerticalAlignment.Stretch;
                    annotation.LabelForeground = Brushes.Black;
                    if (this.Ports != null)
                    {
                        if (nodeInfo.InConnectors != null && nodeInfo.InConnectors.Any())
                        {
                            foreach (IConnector connector in nodeInfo.InConnectors.ToList())
                            {
                                if (this.Type.Contains("left"))
                                {
                                    connector.TargetPort = ports[3];
                                }
                                else if (this.Type.Contains("right"))
                                {
                                    connector.TargetPort = ports[0];
                                }
                            }
                        }

                        if (nodeInfo.OutConnectors != null && nodeInfo.OutConnectors.Any())
                        {
                            foreach (IConnector connector in nodeInfo.OutConnectors.ToList())
                            {
                                if (this.Type.Contains("left"))
                                {
                                    connector.SourcePort = ports[0];
                                }
                                else if (this.Type.Contains("right"))
                                {
                                    connector.SourcePort = ports[3];
                                }
                            }
                        }
                    }
                }
                else
                {
                    this.Shape = resourceDictionary[this.ShapeName];
                    this.ContentTemplate = null;
                    this.Content = null;
                    annotation.TextVerticalAlignment = VerticalAlignment.Center;
                    if (this.ShapeName.Equals("Freehand"))
                    {
                        annotation.LabelForeground = Brushes.Black;
                    }
                    else
                    {
                        this.OnThemeStyleIdChanged();
                    }

                    if (this.ShapeName.Equals("Wave"))
                    {
                        if (this.Ports != null)
                        {
                            if (nodeInfo.InConnectors != null && nodeInfo.InConnectors.Any())
                            {
                                foreach (IConnector connector in nodeInfo.InConnectors.ToList())
                                {
                                    if (this.Type.Contains("left"))
                                    {
                                        connector.TargetPort = ports[2];
                                    }
                                    else if (this.Type.Contains("right"))
                                    {
                                        connector.TargetPort = ports[1];
                                    }
                                }
                            }

                            if (nodeInfo.OutConnectors != null && nodeInfo.OutConnectors.Any())
                            {
                                foreach (IConnector connector in nodeInfo.OutConnectors.ToList())
                                {
                                    if (this.Type.Contains("left"))
                                    {
                                        connector.SourcePort = ports[1];
                                    }
                                    else
                                    {
                                        connector.SourcePort = ports[2];
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (this.Info != null)
                        {
                            if (nodeInfo.InConnectors != null && nodeInfo.InConnectors.Any())
                            {
                                foreach (IConnector connector in nodeInfo.InConnectors.ToList())
                                {
                                    connector.TargetPort = null;
                                }
                            }

                            if (nodeInfo.OutConnectors != null && nodeInfo.OutConnectors.Any())
                            {
                                foreach (IConnector connector in nodeInfo.OutConnectors.ToList())
                                {
                                    connector.SourcePort = null;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The annotation_ property changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Annotation_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Mode"))
            {
                LabelVM annotation = sender as LabelVM;
                if (annotation != null && annotation.Mode == ContentEditorMode.View)
                {
                    TextBlock textblock = new TextBlock();
                    textblock.RenderTransformOrigin = new Point(0.5, 0.5);
                    textblock.Width = this.UnitWidth;
                    textblock.Text = annotation.Content.ToString();
                    textblock.TextWrapping = annotation.WrapText;
                    textblock.FontStyle = annotation.FontStyle;
                    textblock.FontSize = annotation.FontSize;
                    textblock.Foreground = annotation.LabelForeground;
                    textblock.FontWeight = annotation.FontWeight;
                    textblock.FontFamily = annotation.Font;
                    textblock.HorizontalAlignment = annotation.HorizontalAlignment;
                    textblock.VerticalAlignment = annotation.VerticalAlignment;
                    textblock.TextAlignment = annotation.TextHorizontalAlignment;
                    textblock.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                    if (this.Type.Equals("root"))
                    {
                        if (this.ShapeName.Equals("Line"))
                        {
                            double height = textblock.DesiredSize.Height + 20;
                            this.UnitHeight = Math.Max(96, textblock.DesiredSize.Height + 20);
                        }
                        else
                        {
                            this.UnitHeight = Math.Max(96, textblock.DesiredSize.Height);
                        }
                    }
                    else
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

        /// <summary>
        /// The expand collapse command execute.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        private void ExpandCollapseCommandExecute(object param)
        {
            ExpandCollapseParameter parameter = new ExpandCollapseParameter { Node = this, IsUpdateLayout = true };
            ((this.Info as INodeInfo).Graph as IGraphInfo).Commands.ExpandCollapse.Execute(parameter);
        }
    }
}