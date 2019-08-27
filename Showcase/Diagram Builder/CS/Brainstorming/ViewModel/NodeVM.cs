#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DiagramBuilder;
using DiagramBuilder.ViewModel;
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;

namespace Brainstorming.ViewModel
{
    public class BrainstormingNodeVM : NodeVM
    {
        #region Private Fields
        private string _type;
        private int _mLevel;
        private int _mChildCount = 0;        
        #endregion
        #region Constructor
        public BrainstormingNodeVM()
        {
            ShapeName = "Rectangle";
            //Shape = App.Current.Resources["Rectangle"];
            ID = Guid.NewGuid();
        }

        #endregion
        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);
            if (name.Equals("Annotations"))
            {
                //if (Annotations is List<IAnnotation> && (Annotations as AnnotationCollection).Count > 0
                //    && (Annotations as AnnotationCollection)[0] is TextAnnotationViewModel)
                //{
                //    TextAnnotationViewModel annotation = (Annotations as AnnotationCollection)[0] as TextAnnotationViewModel;
                //    annotation.PropertyChanged += Annotation_PropertyChanged;
                //}
                if ((Annotations as List<IAnnotation>).Count > 0)
                {
                    LabelVM annotation = (Annotations as List<IAnnotation>)[0] as LabelVM;
                    annotation.PropertyChanged += Annotation_PropertyChanged;
                }
            }
            else if (name.Equals("ShapeName"))
            {
                LabelVM annotation = (Annotations as List<IAnnotation>)[0] as LabelVM;
                if (ShapeName.Equals("Line"))
                {                    
                    Shape = null;
                    ContentTemplate = App.Current.Resources["LineShapeTemplate"] as DataTemplate;
                    Content = this;
                    annotation.TextVerticalAlignment = VerticalAlignment.Stretch;
                    annotation.LabelForeground = Brushes.Black;
                    if (this.Ports != null)
                    {
                        if ((this.Info as INodeInfo).InConnectors != null && (this.Info as INodeInfo).InConnectors.Count() > 0)
                        {
                            foreach (IConnector connector in (this.Info as INodeInfo).InConnectors.ToList())
                            {
                                if (this.Type.Contains("left"))
                                {
                                    connector.TargetPort = (this.Ports as ObservableCollection<IPort>)[3];
                                }
                                else if (this.Type.Contains("right"))
                                {
                                    connector.TargetPort = (this.Ports as ObservableCollection<IPort>)[0];
                                }
                            }
                        }
                        if((this.Info as INodeInfo).OutConnectors != null && (this.Info as INodeInfo).OutConnectors.Count() > 0)
                        {
                            foreach (IConnector connector in (this.Info as INodeInfo).OutConnectors.ToList())
                            {
                                if (this.Type.Contains("left"))
                                {
                                    connector.SourcePort = (this.Ports as ObservableCollection<IPort>)[0];
                                }
                                else if (this.Type.Contains("right"))
                                {
                                    connector.SourcePort = (this.Ports as ObservableCollection<IPort>)[3];
                                }
                            }
                        }
                    }
                }
                else
                {
                    Shape = App.Current.Resources[ShapeName];
                    ContentTemplate = null;
                    Content = null;                    
                    annotation.TextVerticalAlignment = VerticalAlignment.Center;
                    if (ShapeName.Equals("Freehand"))
                    {
                        annotation.LabelForeground = Brushes.Black;
                    }
                    else
                    {                        
                        OnThemeStyleIdChanged();
                    }
                    if (ShapeName.Equals("Wave"))
                    {
                        if (this.Ports != null)
                        {
                            if ((this.Info as INodeInfo).InConnectors != null && (this.Info as INodeInfo).InConnectors.Count() > 0)
                            {
                                foreach (IConnector connector in (this.Info as INodeInfo).InConnectors.ToList())
                                {
                                    if (this.Type.Contains("left"))
                                    {
                                        connector.TargetPort = (this.Ports as ObservableCollection<IPort>)[2];
                                    }
                                    else if (this.Type.Contains("right"))
                                    {
                                        connector.TargetPort = (this.Ports as ObservableCollection<IPort>)[1];
                                    }
                                }
                            }
                            if((this.Info as INodeInfo).OutConnectors != null && (this.Info as INodeInfo).OutConnectors.Count() > 0)
                            {
                                foreach (IConnector connector in (this.Info as INodeInfo).OutConnectors.ToList())
                                {
                                    if (this.Type.Contains("left"))
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
            }
        }
        #region Public Properties
        private string shapeName;

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

        public int ChildCount
        {
            get { return _mChildCount; }
            set
            {
                if (_mChildCount != value)
                {
                    _mChildCount = value;
                    OnPropertyChanged("ChildCount");
                }
            }
        }

        [DataMember]
        public string Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged("Type");
                }
            }
        }

        [DataMember]
        public int Level
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

        #region Public Commands
        private DelegateCommand<object> expandCollapseCommand;

        public DelegateCommand<object> ExpandCollapseCommand
        {
            get
            {
                return expandCollapseCommand ??
                    (expandCollapseCommand = new DelegateCommand<object>(ExpandCollapseCommandExecute));
            }
        }
        #endregion
        #region Private Methods
        private void ExpandCollapseCommandExecute(object param)
        {
            ExpandCollapseParameter parameter = new ExpandCollapseParameter()
            {
                node = this,
                IsUpdateLayout = true
            };
            ((this.Info as INodeInfo).Graph as IGraphInfo).Commands.ExpandCollapse.Execute(parameter);
        }
        private void Annotation_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Mode"))
            {
                LabelVM annotaiton = sender as LabelVM;
                if (annotaiton != null && annotaiton.Mode == ContentEditorMode.View)
                {
                    TextBlock textblock = new TextBlock();
                    textblock.RenderTransformOrigin = new Point(0.5, 0.5);
                    textblock.Width = this.UnitWidth;
                    textblock.Text = annotaiton.Content.ToString();
                    textblock.TextWrapping = annotaiton.WrapText;
                    textblock.FontStyle = annotaiton.FontStyle;
                    textblock.FontSize = annotaiton.FontSize;
                    textblock.Foreground = annotaiton.LabelForeground;
                    textblock.FontWeight = annotaiton.FontWeight;
                    textblock.FontFamily = annotaiton.Font;
                    textblock.HorizontalAlignment = annotaiton.HorizontalAlignment;
                    textblock.VerticalAlignment = annotaiton.VerticalAlignment;
                    textblock.TextAlignment = annotaiton.TextHorizontalAlignment;
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
        #endregion
    }
}
