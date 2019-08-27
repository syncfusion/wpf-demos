#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Dynamic;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using DiagramBuilder.Utility;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Syncfusion.UI.Xaml.Diagram.Controller;
using Syncfusion.UI.Xaml.Diagram.Theming;
using Syncfusion.UI.Xaml.Diagram.Controls;

namespace DiagramBuilder.ViewModel
{
    public class NodeVM : GroupableVM, INodeVM,IUndoRedo
    {
        public NodeState _mCollectionData;
        public NodeVM()
        {
            Stroke = new SolidColorBrush(new Color() {A = 0xFF, R = 0xC8, G = 0xC8, B = 0xC8});
            OnConstraintsChanged();
            _mCollectionData = new NodeState(ShapeStyle,Fill,this.QuickFill,this.Stroke,this.DashDot,this.Thickness);
            _mCollectionData.ShapeStyle = ShapeStyle;
        }

        #region INode

        double _mHitPadding = 3d;
        /// <summary>
        ///  HitPadding
        /// </summary>
        public double HitPadding
        {
            get
            {
                return _mHitPadding;
            }
            set
            {
                if (_mHitPadding != value)
                {
                    _mHitPadding = value;
                    OnPropertyChanged(NodeConstants.HitPadding);
                }
            }
        }

        AnnotationConstraints _mAnnotationConstraints = AnnotationConstraints.Default;
        /// <summary>
        ///  AnnotationConstraints
        /// </summary>
        public AnnotationConstraints AnnotationConstraints
        {
            get
            {
                return _mAnnotationConstraints;
            }
            set
            {
                if (_mAnnotationConstraints != value)
                {
                    _mAnnotationConstraints = value;
                    OnPropertyChanged(GroupableConstants.AnnotationConstraints);
                }
            }
        }
        double _mOffsetX = 0d;
        public double OffsetX
        {
            get
            {
                return _mOffsetX;
            }
            set
            {
                if (_mOffsetX != value)
                {
                    _mOffsetX = value;
                    OnPropertyChanged(GroupableConstants.OffsetX);
                }
            }
        }


        double _mOffsetY = 0d;
        public double OffsetY
        {
            get
            {
                return _mOffsetY;
            }
            set
            {
                if (_mOffsetY != value)
                {
                    _mOffsetY = value;
                    OnPropertyChanged(GroupableConstants.OffsetY);
                }
            }
        }       

        FlipMode _mFlipMode = FlipMode.FlipMode;
        /// <summary>
        ///  FlipMode
        /// </summary>
        public FlipMode FlipMode
        {
            get
            {
                return _mFlipMode;
            }
            set
            {
                if (_mFlipMode != value)
                {
                    _mFlipMode = value;
                    OnPropertyChanged(NodeConstants.FlipMode);
                }
            }
        }

        Thickness _mAnnotationBounds = new Thickness(0, 0, 0, 0);
        /// <summary>
        ///  AnnotationBounds
        /// </summary>
        public Thickness AnnotationBounds
        {
            get
            {
                return _mAnnotationBounds;
            }
            set
            {
                if (_mAnnotationBounds != value)
                {
                    _mAnnotationBounds = value;
                    OnPropertyChanged(NodeConstants.AnnotationBounds);
                }
            }
        }

        double _mRotateAngle = 0d;
        public double RotateAngle
        {
            get
            {
                return _mRotateAngle;
            }
            set
            {
                if (_mRotateAngle != value)
                {
                    _mRotateAngle = value;
                    OnPropertyChanged(GroupableConstants.RotateAngle);
                }
            }
        }


        SnapToObject _mGuidelines = SnapToObject.None;
        public SnapToObject SnapToObject
        {
            get
            {
                return _mGuidelines;
            }
            set
            {
                if (_mGuidelines != value)
                {
                    _mGuidelines = value;
                    OnPropertyChanged(NodeConstants.SnapToObject);
                }
            }
        }


        Flip _mFlip = Flip.None;
        public Flip Flip
        {
            get
            {
                return _mFlip;
            }
            set
            {
                if (_mFlip != value)
                {
                    _mFlip = value;
                    OnPropertyChanged(NodeConstants.Flip);
                }
            }
        }


        double _mMinWidth = 0d;
        public double MinWidth
        {
            get
            {
                return _mMinWidth;
            }
            set
            {
                if (_mMinWidth != value)
                {
                    _mMinWidth = value;
                    OnPropertyChanged(NodeConstants.MinWidth);
                }
            }
        }


        double _mMaxWidth = double.PositiveInfinity;
        public double MaxWidth
        {
            get
            {
                return _mMaxWidth;
            }
            set
            {
                if (_mMaxWidth != value)
                {
                    _mMaxWidth = value;
                    OnPropertyChanged(NodeConstants.MaxWidth);
                }
            }
        }


        double _mUnitWidth = double.NaN;
        public double UnitWidth
        {
            get
            {
                return _mUnitWidth;
            }
            set
            {
                if (_mUnitWidth != value)
                {
                    _mUnitWidth = value;
                    OnPropertyChanged(GroupableConstants.UnitWidth);
                }
            }
        }


        double _mMinHeight = 0d;
        public double MinHeight
        {
            get
            {
                return _mMinHeight;
            }
            set
            {
                if (_mMinHeight != value)
                {
                    _mMinHeight = value;
                    OnPropertyChanged(NodeConstants.MinHeight);
                }
            }
        }


        double _mMaxHeight = double.PositiveInfinity;
        public double MaxHeight
        {
            get
            {
                return _mMaxHeight;
            }
            set
            {
                if (_mMaxHeight != value)
                {
                    _mMaxHeight = value;
                    OnPropertyChanged(NodeConstants.MaxHeight);
                }
            }
        }


        double _mUnitHeight = double.NaN;
        public double UnitHeight
        {
            get
            {
                return _mUnitHeight;
            }
            set
            {
                if (_mUnitHeight != value)
                {
                    _mUnitHeight = value;
                    OnPropertyChanged(GroupableConstants.UnitHeight);
                }
            }
        }


        object _mContent = null;
        public object Content
        {
            get
            {
                return _mContent;
            }
            set
            {
                if (_mContent != value)
                {
                    _mContent = value;
                    OnPropertyChanged(NodeConstants.Content);
                }
            }
        }


        DataTemplate _mContentTemplate = null;
        public DataTemplate ContentTemplate
        {
            get
            {
                return _mContentTemplate;
            }
            set
            {
                if (_mContentTemplate != value)
                {
                    _mContentTemplate = value;
                    OnPropertyChanged(NodeConstants.ContentTemplate);
                }
            }
        }


        object _mShape = null;
        public object Shape
        {
            get
            {
                return _mShape;
            }
            set
            {
                if (_mShape != value)
                {
                    _mShape = value;
                    OnPropertyChanged(NodeConstants.Shape);
                }
            }
        }


        Style _mShapeStyle = null;
        public Style ShapeStyle
        {
            get
            {
                return _mShapeStyle;
            }
            set
            {
                if (_mShapeStyle != value)
                {
                    _mShapeStyle = value;
                    OnPropertyChanged(NodeConstants.ShapeStyle);
                }
            }
        }


        bool _mIsExpanded = true;
        public bool IsExpanded
        {
            get
            {
                return _mIsExpanded;
            }
            set
            {
                if (_mIsExpanded != value)
                {
                    _mIsExpanded = value;
                    OnPropertyChanged(NodeConstants.IsExpanded);
                }
            }
        }


        Point _mPivot = new Point(0.5, 0.5);
        public Point Pivot
        {
            get
            {
                return _mPivot;
            }
            set
            {
                if (_mPivot != value)
                {
                    _mPivot = value;
                    OnPropertyChanged(NodeConstants.Pivot);
                }
            }
        }

        public string itemname
        {
            get; set;
        }

        NodeConstraints _mConstraints = NodeConstraints.Default;
        public NodeConstraints Constraints
        {
            get
            {
                return _mConstraints;
            }
            set
            {
                if (_mConstraints != value)
                {
                    _mConstraints = value;
                    OnPropertyChanged(NodeConstants.Constraints);
                }
            }
        }


        object _mPorts = null;
        public object Ports
        {
            get
            {
                return _mPorts;
            }
            set
            {
                if (_mPorts != value)
                {
                    _mPorts = value;
                    OnPropertyChanged(NodeConstants.Ports);
                }
            }
        }
        #endregion
        #region Undo/Redo
        public void LogData(object data)
        {
            var info = this.Info as INodeInfo;
            if (info != null && info.Graph != null)
            {
                info.Graph.HistoryManager.LogData(this, data);
            }
        }
        public object Undo(object data)
        {
            if (data is NodeState)
            {
                return RevertTo(data);
            }
            else
                return data;
        }

        public object Redo(object data)
        {
            if (data is NodeState)
            {
                return RevertTo(data);
            }
            else
                return data;
        }

        public UndoRedoState State { get; set; }
        public bool CanUndo(object data)
        {
            if (State == UndoRedoState.Idle)
            {
                return true;
            }
            return false;
        }

        public bool CanRedo(object data)
        {
            if (State == UndoRedoState.Idle)
            {
                return true;
            }
            return false;
        }
        #endregion
        public object RevertTo(object data)
        {
            if (data is NodeState)
            {
                var current = GetData();
                NodeState toState = (NodeState)data;

                if (toState.ShapeStyle != this.ShapeStyle)
                {
                    this.ShapeStyle = toState.ShapeStyle;
                }

                if (toState.Fill != this.Fill)
                {
                    this.Fill = toState.Fill;
                }
                if(toState.DashDot!=this.DashDot)
                {
                    this.DashDot = toState.DashDot;
                }
                if(toState.Stroke!=this.Stroke)
                {
                    this.DashDot = toState.DashDot;
                }
                if(toState.Thickness!=this.Thickness)
                {
                    this.Thickness = toState.Thickness;
                }
                if(toState.QuickFill!=this.QuickFill)
                {
                    this.QuickFill = toState.QuickFill;
                }
                return current;
            }
            return data;
        }
        public object GetData()
        {
            return _mCollectionData;
        }
        string _mToolTip;
        public string ToolTip
        {
            get
            {
                return _mToolTip;
            }
            set
            {
                if (_mToolTip != value)
                {
                    _mToolTip = value;
                    OnPropertyChanged(NodeConstants.ToolTip);
                }
            }
        }
        string _mnodeGallaryName;
        [DataMember]
        public string NodeGallaryName
        {
            get
            {
                return _mnodeGallaryName;
            }
            set
            {
                if (_mnodeGallaryName != value)
                {
                    _mnodeGallaryName = value;
                    OnPropertyChanged(NodeConstants.NodeGallaryName);
                }
            }
        }
        private Brush _mFill = new SolidColorBrush(new Color() {A = 0xFF, R = 0x5B, G = 0x9B, B = 0xD5});
        public Brush Fill
        {
            get
            {
                return _mFill;
            }
            set
            {
                if (_mFill != value)
                {
                    _mFill = value;
                    OnPropertyChanged(NodeConstants.Fill);
                }
            }
        }

        [DataMember]
        public string FillDummy
        {
            get
            {
                if (Fill != null && Fill is SolidColorBrush)
                    return (Fill as SolidColorBrush).Color.ToString();
                else
                    return null;
            }
            set
            {
                Fill = new SolidColorBrush(value.ToColor());                
            }
        }
        
        bool _mAllowDrag = true;
        [DataMember]
        public bool AllowDrag
        {
            get
            {
                return _mAllowDrag;
            }
            set
            {
                if (_mAllowDrag != value)
                {
                    _mAllowDrag = value;
                    OnPropertyChanged(NodeConstants.AllowDrag);
                }
            }
        }

        bool _mAllowResize = true;
        [DataMember]
        public bool AllowResize
        {
            get
            {
                return _mAllowResize;
            }
            set
            {
                if (_mAllowResize != value)
                {
                    _mAllowResize = value;
                    OnPropertyChanged(NodeConstants.AllowResize);
                }
            }
        }

        bool _mAllowRotate = true;
        [DataMember]
        public bool AllowRotate
        {
            get
            {
                return _mAllowRotate;
            }
            set
            {
                if (_mAllowRotate != value)
                {
                    _mAllowRotate = value;
                    OnPropertyChanged(NodeConstants.AllowRotate);
                }
            }
        }

        bool _mAspectRatio = true;
        [DataMember]
        public bool AspectRatio
        {
            get
            {
                return _mAspectRatio;
            }
            set
            {
                if (_mAspectRatio != value)
                {
                    _mAspectRatio = value;
                    OnPropertyChanged(NodeConstants.AspectRatio);
                }
            }
        }

        private string _content;

        [DataMember]
        public string ContentDummy
        {
            get { return _content; }
            set
            {
                _content = value;
                Shape = value; //Clone(value);
                Content = null;
            }
        }

        protected override void OnPropertyChanged(string name)
        {
            var info = this.Info as INodeInfo;
            if (info != null && info.Graph != null && info.Graph.HistoryManager != null && AllowToLogData(name))
            {

                if (info.Graph.HistoryManager.CanLogData(info.Graph.HistoryManager, _mCollectionData))
                {
                    LogData(_mCollectionData);
                }
            }
            base.OnPropertyChanged(name);
            switch (name)
            {
                case "Info":
                    OnThemeStyleIdChanged();
                    break;
                case NodeConstants.Content:
                    OnContentChanged();
                    break;
                case NodeConstants.ContentTemplate:
                    OnContentTemplateChanged();
                    break;
                case NodeConstants.Constraints:
                    OnConstraintsChanged();
                    break;
                case NodeConstants.Fill:
                    OnFillChanged();
                    _mCollectionData.Fill = this.Fill;
                    break;
                case NodeConstants.AllowDrag:
                    OnAllowDragChanged();
                    break;
                case NodeConstants.AllowResize:
                    OnAllowResizeChanged();
                    break;
                case NodeConstants.AllowRotate:
                    OnAllowRotateChanged();
                    break;
                case NodeConstants.AspectRatio:
                    OnAspectRatioChanged();
                    break;
                case "QuickFill":
                case "Stroke":
                case "Thickness":
                case "DashDot":
                case "ShapeStyle":
                    _mCollectionData.QuickFill = this.QuickFill;
                    _mCollectionData.Stroke = this.Stroke;
                    _mCollectionData.Thickness = this.Thickness;
                    _mCollectionData.DashDot = this.DashDot;
                    _mCollectionData.ShapeStyle = this.ShapeStyle;
                    break;
                case "ThemeStyleId":
                    OnThemeStyleIdChanged();
                    break;
            }
        }

        internal void OnThemeStyleIdChanged()
        {
            var info = this.Info as INodeInfo;
            if (Constraints.Contains(NodeConstraints.ThemeStyle) && (this is Brainstorming.ViewModel.BrainstormingNodeVM) &&  info != null && info.Graph.Theme != null)
            {
                if (!(this as Brainstorming.ViewModel.BrainstormingNodeVM).ShapeName.Equals("Line"))
                {
                    DiagramItemStyle style = info.Graph.Theme.GetNodeStyle(ThemeStyleId);
                    if (style != null)
                    {
                        foreach (LabelVM annotaiton in (this.Annotations as List<IAnnotation>))
                        {
                            annotaiton.LabelForeground = style.Foreground;
                            annotaiton.FontSize = (int)style.FontSize;
                            annotaiton.Font = style.FontFamily;
                        }
                    }
                }
            }
        }
        private bool AllowToLogData(string name)
        {
            if (name== "QuickFill" || name == "Stroke" || name == "Thickness" || name == "DashDot" 
                || name== "ShapeStyle" || name=="Fill" )
            {
                return true;
            }

            return false;
        }

        private void OnContentChanged()
        {
            if (Content is string)
            {
                ContentDummy = (string)Content;
                OnFillChanged();
            }
            //if (this.ContentTemplate != App.Current.Resources["NodeShapeTemplate"])
            //{
            //    this.ContentTemplate = App.Current.Resources["NodeShapeTemplate"] as DataTemplate;
            //}
        }

        private void OnContentTemplateChanged()
        {
            if (!(this is Brainstorming.ViewModel.BrainstormingNodeVM))
            {
                this.ContentTemplate = null;
            }
        }

        //public static PathGeometry Clone(string data)
        //{
        //    string p = "<Path xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" Data=\"" + data + "\"/>";
        //    Path o = XamlReader.Load(p) as Path;
        //    PathGeometry geo = Clone(o.Data as PathGeometry);
        //    return geo;
        //}

        //private static PathGeometry Clone(PathGeometry pathGeometry)
        //{
        //    PathFigureCollection collClone = new PathFigureCollection();
        //    foreach (PathFigure item in pathGeometry.Figures)
        //    {
        //        PathFigure clone = new PathFigure()
        //        {
        //            IsClosed = item.IsClosed,
        //            IsFilled = item.IsFilled,
        //            Segments = Clone(item.Segments),
        //            StartPoint = item.StartPoint
        //        };
        //        collClone.Add(clone);
        //    }
        //    return new PathGeometry()
        //    {
        //        Figures = collClone,
        //        FillRule = pathGeometry.FillRule,
        //        Transform = pathGeometry.Transform
        //    };
        //}

        //private static PathSegmentCollection Clone(PathSegmentCollection pathSegColl)
        //{
        //    PathSegmentCollection collClone = new PathSegmentCollection();

        //    foreach (PathSegment item in pathSegColl)
        //    {
        //        PathSegment clone = null;
        //        if (item is LineSegment)
        //        {
        //            LineSegment seg = item as LineSegment;
        //            clone = new LineSegment() { Point = seg.Point };
        //        }
        //        else if (item is PolyLineSegment)
        //        {
        //            PolyLineSegment seg = item as PolyLineSegment;
        //            clone = new PolyLineSegment() { Points = getPoints(seg.Points) };
        //        }
        //        else if (item is BezierSegment)
        //        {
        //            BezierSegment seg = item as BezierSegment;
        //            clone = new BezierSegment()
        //            {
        //                Point1 = seg.Point1,
        //                Point2 = seg.Point2,
        //                Point3 = seg.Point3
        //            };
        //        }
        //        else if (item is PolyBezierSegment)
        //        {
        //            PolyBezierSegment seg = item as PolyBezierSegment;
        //            clone = new PolyBezierSegment() { Points = getPoints(seg.Points) };
        //        }
        //        else if (item is PolyQuadraticBezierSegment)
        //        {
        //            PolyQuadraticBezierSegment seg = item as PolyQuadraticBezierSegment;
        //            clone = new PolyQuadraticBezierSegment() { Points = getPoints(seg.Points) };
        //        }
        //        else if (item is QuadraticBezierSegment)
        //        {
        //            QuadraticBezierSegment seg = item as QuadraticBezierSegment;
        //            clone = new QuadraticBezierSegment() { Point1 = seg.Point1, Point2 = seg.Point2 };
        //        }
        //        else if (item is ArcSegment)
        //        {
        //            ArcSegment seg = item as ArcSegment;
        //            clone = new ArcSegment()
        //            {
        //                IsLargeArc = seg.IsLargeArc,
        //                Point = seg.Point,
        //                RotationAngle = seg.RotationAngle,
        //                Size = seg.Size,
        //                SweepDirection = seg.SweepDirection
        //            };
        //        }

        //        collClone.Add(clone);
        //    }
        //    return collClone;
        //}

        //private static PointCollection getPoints(PointCollection pointCollection)
        //{
        //    PointCollection coll = new PointCollection();
        //    foreach (var item in pointCollection)
        //    {
        //        coll.Add(item);
        //    }
        //    return coll;
        //}

        private void OnConstraintsChanged()
        {
            if (!(this is Brainstorming.ViewModel.BrainstormingNodeVM))
            {
                if (Constraints.Contains(NodeConstraints.Draggable))
                {
                    AllowDrag = true;
                }
                else
                {
                    AllowDrag = false;
                }
                if (Constraints.Contains(NodeConstraints.Resizable))
                {
                    AllowResize = true;
                }
                else
                {
                    AllowResize = false;
                }
                if (Constraints.Contains(NodeConstraints.Rotatable))
                {
                    AllowRotate = true;
                }
                else
                {
                    AllowRotate = false;
                }
                if (Constraints.Contains(NodeConstraints.AspectRatio))
                {
                    AspectRatio = true;
                }
                else
                {
                    AspectRatio = false;
                }
            }
        }
        
        #region Shape

        private void OnFillChanged()
        {
            ApplyStyle(GetCustomStyle());
        }

        private void OnAllowRotateChanged()
        {
            if (AllowRotate)
            {
                (this as INode).Constraints |= NodeConstraints.Rotatable;
            }
            else
            {
                (this as INode).Constraints &= ~NodeConstraints.Rotatable;
            }
        }

        private void OnAllowResizeChanged()
        {
            if (AllowResize)
            {
                (this as INode).Constraints |= NodeConstraints.Resizable;
            }
            else
            {
                (this as INode).Constraints &= ~NodeConstraints.Resizable;
            }
        }

        private void OnAllowDragChanged()
        {
            if (AllowDrag)
            {
                (this as INode).Constraints |= NodeConstraints.Draggable;
            }
            else
            {
                (this as INode).Constraints &= ~NodeConstraints.Draggable;
            }
            //else if (this is IConnector)
            //{
            //    if (AllowDrag)
            //    {
            //        (this as IConnector).Constraints |= ConnectorConstraints.EndDraggable;
            //    }
            //    else
            //    {
            //        (this as IConnector).Constraints &= ~ConnectorConstraints.EndDraggable;
            //    }
            //}
        }

        private void OnAspectRatioChanged()
        {
            if (AspectRatio)
            {
                (this as INode).Constraints |= NodeConstraints.AspectRatio;
            }
            else
            {
                (this as INode).Constraints &= ~NodeConstraints.AspectRatio;
            }
        }

        #endregion
        
        protected override void DecodeStyle(Style style)
        {
            base.DecodeStyle(style);

            foreach (Setter setter in style.Setters)
            {
                if (setter.Property == Path.FillProperty && this.Key != null && this.Key.ToString() != "Electrical Shapes")
                {
                    Fill = setter.Value as Brush;
                }
            }
        }

        protected override Style GetCustomStyle()
        {
            Style s = base.GetCustomStyle();
            if (Fill != null)
            {
                s.Setters.Add(new Setter(Path.FillProperty, Fill));
                s.Setters.Add(new Setter(Path.StretchProperty, Stretch.Fill));
            }
            return s;
        }

        protected override void ApplyStyle(Style style)
        {
            ShapeStyle = style;
        }


        PortVisibility _mPortVisibility = PortVisibility.MouseOver;
       
        public PortVisibility PortVisibility
        {
            get
            {
                return _mPortVisibility;
            }
            set
            {
                if (_mPortVisibility != value)
                {
                    _mPortVisibility = value;
                    OnPropertyChanged(NodeConstants.PortVisibility);
                }
            }
        }


        public double ConnectorPadding { get; set; }
        public bool ExcludeFromLayout { get; set; }

        public Syncfusion.UI.Xaml.Diagram.Controls.DiagramMenu Menu
        {
            get;
            set;
        }

        private StyleId _mThemeStyleID;

        public StyleId ThemeStyleId
        {
            get { return _mThemeStyleID; }
            set
            {
                if (_mThemeStyleID != value)
                {
                    _mThemeStyleID = value;
                    OnPropertyChanged("ThemeStyleId");
                }
            }
        }
    }

    public static class Ext
    {
        public static bool Contains(this NodeConstraints s, NodeConstraints t)
        {
            return ((s & t) != NodeConstraints.None);
        }
    }

    public interface INodeVM : IGroupableVM, INode
    {
        Brush Fill { get; set; }
        bool AllowDrag { get; set; }
        bool AllowResize { get; set; }
        bool AllowRotate { get; set; }
        string NodeGallaryName { get; set; }
        bool AspectRatio { get; set; }
    }

    internal static class NodeConstants
    {
        //public const string OffsetX = "OffsetX";
        //public const string OffsetY = "OffsetY";
        //public const string RotateAngle = "RotateAngle";
        public const string ToolTip = "ToolTip";
        public const string NodeGallaryName = "NodeGallaryName";
        public const string SnapToObject = "SnapToObject";
        public const string Flip = "Flip";
        public const string MinWidth = "MinWidth";
        public const string MaxWidth = "MaxWidth";
        //public const string UnitWidth = "UnitWidth";
        public const string MinHeight = "MinHeight";
        public const string MaxHeight = "MaxHeight";
        //public const string UnitHeight = "UnitHeight";
        public const string Content = "Content";
        public const string ContentTemplate = "ContentTemplate";
        public const string Shape = "Shape";
        public const string ShapeStyle = "ShapeStyle";
        public const string ParentGroup = "ParentGroup";
        public const string IsExpanded = "IsExpanded";
        public const string Pivot = "Pivot";
        public const string AutoBind = "AutoBind";
        public const string ID = "ID";
        public const string Key = "Key";
        public const string IsSelected = "IsSelected";
        public const string ZIndex = "ZIndex";
        public const string Annotations = "Annotations";
        public const string Constraints = "Constraints";
        public const string Ports = "Ports";
        public const string InternalPorts = "InternalPorts";
        public const string PortVisibility = "PortVisibility";
        public const string HitPadding = "HitPadding";
        public const string Fill = "Fill";
        public const string AllowDrag = "AllowDrag";
        public const string AllowResize = "AllowResize";
        public const string AllowRotate = "AllowRotate";
        public const string AspectRatio = "AspectRatio";
        public const string AnnotationBounds = "AnnotationBounds";
        public const string FlipMode = "FlipMode";
        public const string PortDragMode = "PortDragMode";
    }
    public struct NodeState
    {

        private Brush _mFill;
        public Brush Fill
        {
            get
            {
                return _mFill;
            }
            set
            {
                if (_mFill != value)
                {
                    _mFill = value;
                }
            }
        }
        private Brush _mQuickFill;
        public Brush QuickFill
        {
            get
            {
                return _mQuickFill;
            }
            set
            {
                if (_mQuickFill != value)
                {
                    _mQuickFill = value;
                }
            }
        }

        Brush _mStroke;
        public Brush Stroke
        {
            get
            {
                return _mStroke;
            }
            set
            {
                if (_mStroke != value)
                {
                    _mStroke = value;
                }
            }
        }
        string _mDashDot;
        public string DashDot
        {
            get
            {
                return _mDashDot;
            }
            set
            {
                if (_mDashDot != value)
                {
                    _mDashDot = value;
                }
            }
        }
        double _mThickness;
        public double Thickness
        {
            get
            {
                return _mThickness;
            }
            set
            {
                if (_mThickness != value)
                {
                    _mThickness = value;
                }
            }
        }
        private Style mShapeStyle;

        /// <summary>
        /// Gets or sets the style of the Node.
        /// </summary>
        public Style ShapeStyle
        {
            get
            {
                return mShapeStyle;
            }
            set
            {
                if (mShapeStyle != value)
                {
                    mShapeStyle = value;
                }
            }
        }
        public NodeState(Style style,Brush fill,Brush qfill,Brush stroke,string dasdot,double thickness)
        {
            mShapeStyle = style;
            _mFill = fill;
            _mQuickFill = qfill;
            _mStroke = stroke;
            _mDashDot = dasdot;
            _mThickness = thickness;

        }



    }
    public class customManager : HistoryManager
    {
        public customManager()
        {

        }
        public override object Undo(object data)
        {
            return data;
        }

        public override object Redo(object data)
        {
            return data;
        }
    }
}