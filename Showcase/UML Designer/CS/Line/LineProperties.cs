#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Globalization;
using DiagramFrontPageUtility;
using System.Windows.Media;
using System.Xml.Serialization;
using System.Windows;

namespace UMLDiagramDesigner
{
    public class LineProperties : INotifyPropertyChanged, ILine
    {
        public LineProperties()
        {
            this.PropertyChanged += LineProperties_PropertyChanged;

            this.Inherit = new DelegateCommand<object>(OnInherit, args => { return this.CanGeneralize || this.CanRealize; });
            this.Generalize = new DelegateCommand<object>(OnGeneralize, args => { return this.CanGeneralize; });
            this.Realize = new DelegateCommand<object>(OnRealize, args => { return this.CanRealize; });

            this.AggOrAss = new DelegateCommand<object>(OnAggOrAss, args => { return this.CanAssociateOrAggregate; });

            this.BasicAggregate = new DelegateCommand<object>(OnBasicAggregate, args => { return this.CanAssociateOrAggregate; });
            this.CompositionAggregate = new DelegateCommand<object>(OnCompositionAggregate, args => { return this.CanAssociateOrAggregate; });
            this.NoAggregate = new DelegateCommand<object>(OnNoAggregate, args => { return this.CanAssociateOrAggregate; });

            this.BiDirected = new DelegateCommand<object>(OnBiDirected, args => { return this.CanAssociateOrAggregate; });
            this.UniDirected = new DelegateCommand<object>(OnUniDirected, args => { return this.CanAssociateOrAggregate; });
        }

        public void InvalidateBinding()
        {
            this.OnPropertyChanged("LineType");
            this.OnPropertyChanged("Aggregation");
            this.OnPropertyChanged("Association");
        }

        #region Head, Tail

        private object m_Head;

        [XmlIgnore]
        public object Head
        {
            get { return m_Head; }
            set
            {
                if (m_Head != value)
                {
                    m_Head = value;
                    OnPropertyChanged("Head");
                }
            }
        }

        private object m_Tail;

        [XmlIgnore]
        public object Tail
        {
            get { return m_Tail; }
            set
            {
                if (m_Tail != value)
                {
                    m_Tail = value;
                    OnPropertyChanged("Tail");
                }
            }
        }

        private string m_HeadID;

        public string HeadID
        {
            get
            {
                if (Head != null)
                {
                    return (Head as INode).ID;
                }
                else
                {
                    return m_HeadID;
                }
            }
            set { m_HeadID = value; }
        }

        private string m_TailID;

        public string TailID
        {
            get
            {
                if (Tail != null)
                {
                    return (Tail as INode).ID;
                }
                else
                {
                    return m_TailID;
                }
            }
            set { m_TailID = value; }
        }

        #endregion

        #region PropertyChanged

        void LineProperties_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Head" ||
                e.PropertyName == "Tail")
            {
                // Note node
                if (Head is TextNode || Tail is TextNode)
                {
                    throw new InvalidOperationException("Text node should not be connected");
                }
                if (Head is NoteNode || Tail is NoteNode)
                {
                    LineType = LineType.Note;
                }
                if (Head != null && Tail != null)
                {
                    Update();
                }
            }

            if (e.PropertyName == "LineType" ||
                e.PropertyName == "Association" ||
                e.PropertyName == "Aggregation" ||
                e.PropertyName == "Inheritance")
            {
                if (Head != null && Tail != null)
                {
                    Update();
                }
            }
        }

        private void Update()
        {
            switch (LineType)
            {
                case LineType.AggregateOrAssociate:
                    if (CanAssociateOrAggregate)
                    {
                        switch (Aggregation)
                        {
                            case Aggregation.Basic:
                                this.HeadStyle = BasicAggregateStyle();
                                this.LineStyle = SolidStyle();
                                break;
                            case Aggregation.Composition:
                                this.HeadStyle = CompositionAggregateStyle();
                                this.LineStyle = SolidStyle();
                                break;
                            case UMLDiagramDesigner.Aggregation.None:
                                this.HeadStyle = null;
                                this.LineStyle = SolidStyle();
                                break;
                        }
                        switch (Association)
                        {
                            case Association.BiDirectional:
                                this.LineStyle = SolidStyle();
                                this.TailStyle = null;
                                break;
                            case Association.UniDirectional:
                                this.LineStyle = SolidStyle();
                                this.TailStyle = UniDirectionalStyle();
                                break;
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("Aggregation/Association can take place only between two Class/Interface");
                    }
                    break;

                case LineType.Inheritance:
                    switch (Inheritance)
                    {
                        case Inheritance.Generalization:
                            if (CanGeneralize)
                            {
                                this.HeadStyle = null;
                                this.LineStyle = SolidStyle();
                                this.TailStyle = InheritStyle();
                            }
                            else
                            {
                                //throw new InvalidOperationException("Generalization can be done only between two classes");
                                if (CanRealize)
                                {
                                    Inheritance = Inheritance.Realization;
                                }
                            }
                            break;
                        case Inheritance.Realization:
                            {
                                if (CanRealize)
                                {
                                    this.HeadStyle = null;
                                    this.LineStyle = DotedStyle();
                                    this.TailStyle = InheritStyle();
                                }
                                else
                                {
                                    //throw new InvalidOperationException("Realization can be done only between a Class and Interface or between 2 Interfaces");
                                    if (CanGeneralize)
                                    {
                                        Inheritance = Inheritance.Generalization;
                                    }
                                }
                            }
                            break;
                    }
                    break;
                case LineType.Note:
                    if (CanNote)
                    {
                        this.Color = "Red";
                        this.HeadStyle = null;
                        this.LineStyle = DotedStyle();
                        this.TailStyle = null;
                    }
                    else
                    {
                        throw new InvalidOperationException("Either head or tail should be a Note node");
                    }
                    break;
            }
        }

        #endregion

        #region Styles

        private PathStyle BasicAggregateStyle()
        {
            PathStyle style = new PathStyle();
            this.SourceShape = Geometry.Parse("M50,0 L100,50 L50,100 L0,50 z");
                //Shapes.Basic.ToGeometry();
            //style.Data = "M50,0 L100,50 L50,100 L0,50 z";
            style.Fill = "White";
            style.Stroke = Color;
            style.StrokeThickness = 1;
            style.Width = 20;
            style.Height = 15;
            style.Stretch = Stretch.Fill;
            return style;
        }

        private PathStyle CompositionAggregateStyle()
        {
            PathStyle style = new PathStyle();
            this.SourceShape = Geometry.Parse("M50,0 L100,50 L50,100 L0,50 z");
            //style.Data = "M50,0 L100,50 L50,100 L0,50 z";
            style.Fill = Color;
            style.Stroke = Color;
            style.StrokeThickness = 1;
            style.Stretch = Stretch.Fill;
            style.Width = 20;
            style.Height = 15;
            return style;
        }

        private PathStyle UniDirectionalStyle()
        {
            PathStyle style = new PathStyle();
            this.TargetShape = Geometry.Parse("M7,0.5 L56.5,50 L7,99.5 L0.5,93 L43.5,50 L0.5,7 z");
            //style.Data = "M0,0 L60,25 L0,50"; //"M7,0.5 L56.5,50 L7,99.5 L0.5,93 L43.5,50 L0.5,7 z";
            //style.Fill = Color;
            style.Stroke = Color;
            style.StrokeThickness = 1;
            style.Width = 15;
            style.Height = 15;
            style.Stretch = Stretch.Fill;
            return style;
        }

        private PathStyle DotedStyle()
        {
            PathStyle style = new PathStyle();
            style.Stroke = Color;
            style.StrokeThickness = 1;
            style.StrokeDashArray = new DoubleCollection() { 5, 5 };
            return style;
        }

        private PathStyle SolidStyle()
        {
            PathStyle style = new PathStyle();
            style.Stroke = Color;
            style.StrokeThickness = 1;
            return style;
        }

        private PathStyle InheritStyle()
        {
            PathStyle style = new PathStyle();
            this.TargetShape = Geometry.Parse("M2,0.5 L51.5,50 L2,99.5 L0.5,98 L0.5,2 z");
            //style.Data = "M2,0.5 L51.5,50 L2,99.5 L0.5,98 L0.5,2 z";
            style.Fill = "White";
            style.Stroke = Color;
            style.StrokeThickness = 1;
            style.Width = 20;
            style.Height = 15;
            style.Stretch = Stretch.Fill;
            return style;
        }

        #endregion

        #region Commands

        private ICommand m_Inherit;

        [XmlIgnore]
        public ICommand Inherit
        {
            get { return m_Inherit; }
            set
            {
                if (m_Inherit != value)
                {
                    m_Inherit = value;
                    OnPropertyChanged("Inherit");
                }
            }
        }

        private ICommand m_AggOrAss;

        [XmlIgnore]
        public ICommand AggOrAss
        {
            get { return m_AggOrAss; }
            set
            {
                if (m_AggOrAss != value)
                {
                    m_AggOrAss = value;
                    OnPropertyChanged("AggOrAss");
                }
            }
        }

        private void OnAggOrAss(object param)
        {
            LineType = LineType.AggregateOrAssociate;
        }

        private void OnInherit(object param)
        {
            if (CanRealize)
            {
                OnRealize(param);
            }
            else if (CanGeneralize)
            {
                OnGeneralize(param);
            }
        }

        private ICommand m_NoAggregate;

        [XmlIgnore]
        public ICommand NoAggregate
        {
            get { return m_NoAggregate; }
            set
            {
                if (m_NoAggregate != value)
                {
                    m_NoAggregate = value;
                    OnPropertyChanged("NoAggregate");
                }
            }
        }

        private void OnNoAggregate(object param)
        {
            this.LineType = LineType.AggregateOrAssociate;
            this.Aggregation = Aggregation.None;
        }

        private ICommand m_Generalize;

        [XmlIgnore]
        public ICommand Generalize
        {
            get { return m_Generalize; }
            set
            {
                if (m_Generalize != value)
                {
                    m_Generalize = value;
                    OnPropertyChanged("Generalize");
                }
            }
        }

        private void OnGeneralize(object param)
        {
            this.LineType = LineType.None;
            this.Inheritance = Inheritance.Generalization;
            this.LineType = LineType.Inheritance;
        }

        private ICommand m_Realize;

        [XmlIgnore]
        public ICommand Realize
        {
            get { return m_Realize; }
            set
            {
                if (m_Realize != value)
                {
                    m_Realize = value;
                    OnPropertyChanged("Realize");
                }
            }
        }

        private void OnRealize(object param)
        {
            this.LineType = LineType.None;
            this.Inheritance = Inheritance.Realization;
            this.LineType = LineType.Inheritance;
        }

        private ICommand m_BasicAggregate;

        [XmlIgnore]
        public ICommand BasicAggregate
        {
            get { return m_BasicAggregate; }
            set
            {
                if (m_BasicAggregate != value)
                {
                    m_BasicAggregate = value;
                    OnPropertyChanged("BasicAggregate");
                }
            }
        }

        private void OnBasicAggregate(object param)
        {
            this.LineType = LineType.None;
            this.Aggregation = Aggregation.Basic;
            this.LineType = LineType.AggregateOrAssociate;
        }

        private ICommand m_CompositionAggregate;

        [XmlIgnore]
        public ICommand CompositionAggregate
        {
            get { return m_CompositionAggregate; }
            set
            {
                if (m_CompositionAggregate != value)
                {
                    m_CompositionAggregate = value;
                    OnPropertyChanged("CompositionAggregate");
                }
            }
        }

        private void OnCompositionAggregate(object param)
        {
            this.LineType = LineType.None;
            this.Aggregation = Aggregation.Composition;
            this.LineType = LineType.AggregateOrAssociate;
        }

        private ICommand m_BiDirected;

        [XmlIgnore]
        public ICommand BiDirected
        {
            get { return m_BiDirected; }
            set
            {
                if (m_BiDirected != value)
                {
                    m_BiDirected = value;
                    OnPropertyChanged("BiDirected");
                }
            }
        }

        private void OnBiDirected(object param)
        {
            this.Association = Association.BiDirectional;
        }

        private ICommand m_UniDirected;

        [XmlIgnore]
        public ICommand UniDirected
        {
            get { return m_UniDirected; }
            set
            {
                if (m_UniDirected != value)
                {
                    m_UniDirected = value;
                    OnPropertyChanged("UniDirected");
                }
            }
        }

        private void OnUniDirected(object param)
        {
            this.Association = Association.UniDirectional;
        }

        #endregion

        #region Validation

        public bool CanGeneralize
        {
            get
            {
                return Head is ClassNode && Tail is ClassNode;
            }
        }

        public bool CanRealize
        {
            get
            {
                return (Head is ClassNode || Head is InterfaceNode) && Tail is InterfaceNode;
            }
        }

        public bool CanAssociateOrAggregate
        {
            get
            {
                if (Head is NoteNode || Head is TextNode || Tail is NoteNode || Head is TextNode)
                {
                    return false;
                }
                return true;
            }
        }

        public bool CanNote
        {
            get { return Head is NoteNode || Tail is NoteNode; }
        }

        #endregion

        #region Type

        private LineType m_LineType = LineType.AggregateOrAssociate;

        public LineType LineType
        {
            get { return m_LineType; }
            set
            {
                if (m_LineType != value)
                {
                    m_LineType = value;
                    OnPropertyChanged("LineType");
                }
            }
        }

        private Inheritance m_Inheritance;

        public Inheritance Inheritance
        {
            get { return m_Inheritance; }
            set
            {
                if (m_Inheritance != value)
                {
                    m_Inheritance = value;
                    OnPropertyChanged("Inheritance");
                }
            }
        }

        private Aggregation m_Aggregation = Aggregation.None;

        public Aggregation Aggregation
        {
            get { return m_Aggregation; }
            set
            {
                if (m_Aggregation != value)
                {
                    m_Aggregation = value;
                    OnPropertyChanged("Aggregation");
                }
            }
        }

        private Association m_Association = Association.BiDirectional;

        public Association Association
        {
            get { return m_Association; }
            set
            {
                if (m_Association != value)
                {
                    m_Association = value;
                    OnPropertyChanged("Association");
                }
            }
        }

        #endregion

        #region LineAppearence

        private Point m_SplitPoint;

        public Point SplitPoint
        {
            get { return m_SplitPoint; }
            set
            {
                if (m_SplitPoint != value)
                {
                    m_SplitPoint = value;
                    OnPropertyChanged("SplitPoint");
                }
            }
        }

        private string m_Color = "Black";

        public string Color
        {
            get { return m_Color; }
            set
            {
                if (m_Color != value)
                {
                    m_Color = value;
                    OnPropertyChanged("Color");
                }
            }
        }

        private PathStyle m_HeadStyle;

        [XmlIgnore]
        public PathStyle HeadStyle
        {
            get { return m_HeadStyle; }
            set
            {
                if (m_HeadStyle != value)
                {
                    m_HeadStyle = value;
                    OnPropertyChanged("HeadStyle");
                }
            }
        }

        private Geometry m_SourceShape;

        [XmlIgnore]
        public Geometry SourceShape
        {
            get
            {
                return m_SourceShape;
            }
            set
            {
                if (m_SourceShape != value)
                {
                    m_SourceShape = value;
                    OnPropertyChanged("SourceShape");
                }
            }
        }

        private Geometry m_TargetShape = Geometry.Parse("M 9,2 11,7 17,7 12,10 14,15 9,12 4,15 6,10 1,7 7,7 Z");
        
        
        //= new PathGeometry()
        //        {
        //            Figures = new PathFigureCollection()
        //                {
        //                    new PathFigure()
        //                        {
        //                            StartPoint = new Point(0, 0),
        //                            Segments = new PathSegmentCollection()
        //                                {
        //                                    new PolyLineSegment()
        //                                        {
        //                                            Points = new PointCollection()
        //                                                {
        //                                                    new Point(10, 5),
        //                                                    new Point(0, 10),
        //                                                    new Point(0,0)
        //                                                }
        //                                        }
        //                                }
        //                        }
        //                }
        //        };

        [XmlIgnore]
        public Geometry TargetShape
        {
            get
            {
                return m_TargetShape;
            }
            set
            {
                if (m_TargetShape != value)
                {
                    m_TargetShape = value;
                    OnPropertyChanged("TargetShape");
                }
            }
        }

        private PathStyle m_TailStyle;

        [XmlIgnore]
        public PathStyle TailStyle
        {
            get { return m_TailStyle; }
            set
            {
                if (m_TailStyle != value)
                {
                    m_TailStyle = value;
                    OnPropertyChanged("TailStyle");
                }
            }
        }

        private PathStyle m_LineStyle;

        [XmlIgnore]
        public PathStyle LineStyle
        {
            get { return m_LineStyle; }
            set
            {
                if (m_LineStyle != value)
                {
                    m_LineStyle = value;
                    OnPropertyChanged("LineStyle");
                }
            }
        }

        private string m_Label;

        public string Label
        {
            get { return m_Label; }
            set
            {
                if (m_Label != value)
                {
                    m_Label = value;
                    OnPropertyChanged("Label");
                }
            }
        }

        #endregion

        #region INotifyPropertyChanged

        protected virtual void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }

}