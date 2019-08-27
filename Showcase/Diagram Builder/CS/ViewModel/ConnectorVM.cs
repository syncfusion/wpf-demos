#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Syncfusion.UI.Xaml.Diagram.Controller;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Theming;

namespace DiagramBuilder.ViewModel
{
    public class ConnectorVM : GroupableVM, IConnectorVM,IUndoRedo
    {
        public ConnectorState _mCollectionData;
        public ConnectorVM()
        {
            ZIndex = -10;
            Stroke = new SolidColorBrush(new Color() { A = 0xFF, R = 0x5B, G = 0x9B, B = 0xD5 });
            _mCollectionData = new ConnectorState(Stroke, DashDot, Thickness, SourceCap, TargetCap, SourceDecorator, TargetDecorator, SourceDecoratorStyle, TargetDecoratorStyle, ConnectorGeometryStyle, Decorator);
            //Work around
            this.ThemeStyleId = Syncfusion.UI.Xaml.Diagram.Theming.StyleId.Accent1 | Syncfusion.UI.Xaml.Diagram.Theming.StyleId.Subtly;
        }

        #region IConnector
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
                    OnPropertyChanged(ConnectorConstants.AnnotationConstraints);
                }
            }
        }
        double _mHitPadding = 10d;
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
                    OnPropertyChanged(ConnectorConstants.HitPadding);
                }
            }
        }
        object _mSegmentDecorators = null;
        /// <summary>
        ///  SegmentDecorators
        /// </summary>
        public object SegmentDecorators
        {
            get
            {
                return _mSegmentDecorators;
            }
            set
            {
                if (_mSegmentDecorators != value)
                {
                    _mSegmentDecorators = value;
                    OnPropertyChanged(ConnectorConstants.SegmentDecorators);
                }
            }
        }

        Style _mSegmentDecoratorStyle = null;
        /// <summary>
        ///  SegmentDecoratorStyle
        /// </summary>
        public Style SegmentDecoratorStyle
        {
            get
            {
                return _mSegmentDecoratorStyle;
            }
            set
            {
                if (_mSegmentDecoratorStyle != value)
                {
                    _mSegmentDecoratorStyle = value;
                    OnPropertyChanged(ConnectorConstants.SegmentDecoratorStyle);
                }
            }
        }

        Point _mSourceDecoratorPivot = new Point(0.5, 0.5);
        public Point SourceDecoratorPivot
        {
            get
            {
                return _mSourceDecoratorPivot;
            }
            set
            {
                if (_mSourceDecoratorPivot != value)
                {
                    _mSourceDecoratorPivot = value;
                    OnPropertyChanged(ConnectorConstants.SourceDecoratorPivot);
                }
            }
        }

        Point _mTargetDecoratorPivot = new Point(1, 0.5);
        public Point TargetDecoratorPivot
        {
            get
            {
                return _mTargetDecoratorPivot;
            }
            set
            {
                if (_mTargetDecoratorPivot != value)
                {
                    _mTargetDecoratorPivot = value;
                    OnPropertyChanged(ConnectorConstants.TargetDecoratorPivot);
                }
            }
        }

        object _mSourceNode = null;
        public object SourceNode
        {
            get
            {
                return _mSourceNode;
            }
            set
            {
                if (_mSourceNode == null || !_mSourceNode.Equals(value))
                {
                    _mSourceNode = value;
                    OnPropertyChanged(ConnectorConstants.SourceNode);
                }
            }
        }


        object _mTargetNode = null;
        public object TargetNode
        {
            get
            {
                return _mTargetNode;
            }
            set
            {
                if (_mTargetNode == null || !_mTargetNode.Equals(value))
                {
                    _mTargetNode = value;
                    OnPropertyChanged(ConnectorConstants.TargetNode);
                }
            }
        }


        IPort _mSourcePort = null;
        public IPort SourcePort
        {
            get
            {
                return _mSourcePort;
            }
            set
            {
                if (_mSourcePort != value)
                {
                    _mSourcePort = value;
                    OnPropertyChanged(ConnectorConstants.SourcePort);
                }
            }
        }


        IPort _mTargetPort = null;
        public IPort TargetPort
        {
            get
            {
                return _mTargetPort;
            }
            set
            {
                if (_mTargetPort != value)
                {
                    _mTargetPort = value;
                    OnPropertyChanged(ConnectorConstants.TargetPort);
                }
            }
        }


     

        Point _mSourcePoint = new Point(0, 0);
        public Point SourcePoint
        {
            get
            {
                return _mSourcePoint;
            }
            set
            {
                if (_mSourcePoint != value)
                {
                    _mSourcePoint = value;
                    OnPropertyChanged(ConnectorConstants.SourcePoint);
                }
            }
        }


        Point _mTargetPoint = new Point(0, 0);
        public Point TargetPoint
        {
            get
            {
                return _mTargetPoint;
            }
            set
            {
                if (_mTargetPoint != value)
                {
                    _mTargetPoint = value;
                    OnPropertyChanged(ConnectorConstants.TargetPoint);
                }
            }
        }


        Style _mConnectorGeometryStyle = null;
        public Style ConnectorGeometryStyle
        {
            get
            {
                return _mConnectorGeometryStyle;
            }
            set
            {
                if (_mConnectorGeometryStyle != value)
                {
                    _mConnectorGeometryStyle = value;
                    OnPropertyChanged(ConnectorConstants.ConnectorGeometryStyle);
                }
            }
        }


        object _mSourceDecorator = null;
        public object SourceDecorator
        {
            get
            {
                return _mSourceDecorator;
            }
            set
            {
                if (_mSourceDecorator != value)
                {
                    _mSourceDecorator = value;
                    OnPropertyChanged(ConnectorConstants.SourceDecorator);
                }
            }
        }


        object _mTargetDecorator = "M0,0 L10,5 L0,10 L 0,0Z";
        public object TargetDecorator
        {
            get
            {
                return _mTargetDecorator;
            }
            set
            {
                if (_mTargetDecorator != value)
                {
                    _mTargetDecorator = value;
                    OnPropertyChanged(ConnectorConstants.TargetDecorator);
                }
            }
        }


        Style _mSourceDecoratorStyle = null;
        public Style SourceDecoratorStyle
        {
            get
            {
                return _mSourceDecoratorStyle;
            }
            set
            {
                if (_mSourceDecoratorStyle != value)
                {
                    _mSourceDecoratorStyle = value;
                    OnPropertyChanged(ConnectorConstants.SourceDecoratorStyle);
                }
            }
        }


        Style _mTargetDecoratorStyle = null;
        public Style TargetDecoratorStyle
        {
            get
            {
                return _mTargetDecoratorStyle;
            }
            set
            {
                if (_mTargetDecoratorStyle != value)
                {
                    _mTargetDecoratorStyle = value;
                    OnPropertyChanged(ConnectorConstants.TargetDecoratorStyle);
                }
            }
        }


        ConnectorConstraints _mConstraints = ConnectorConstraints.Default | ConnectorConstraints.Draggable;
        public ConnectorConstraints Constraints
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
                    OnPropertyChanged(ConnectorConstants.Constraints);
                }
            }
        }


        BezierSmoothness _mBezierSmoothness = BezierSmoothness.None;
        public BezierSmoothness BezierSmoothness
        {
            get
            {
                return _mBezierSmoothness;
            }
            set
            {
                if (_mBezierSmoothness != value)
                {
                    _mBezierSmoothness = value;
                    OnPropertyChanged(ConnectorConstants.BezierSmoothness);
                }
            }
        }


        double _mBridgeSpace = 15d;
        public double BridgeSpace
        {
            get
            {
                return _mBridgeSpace;
            }
            set
            {
                if (_mBridgeSpace != value)
                {
                    _mBridgeSpace = value;
                    OnPropertyChanged(ConnectorConstants.BridgeSpace);
                }
            }
        }

        public double CornerRadius
        {
            get;
            set;
        }

        #endregion

        #region IConnectorVM
        string _mconnectorGallaryName;
        [DataMember]
        public string ConnectorGallaryName
        {
            get
            {
                return _mconnectorGallaryName;
            }
            set
            {
                if (_mconnectorGallaryName != value)
                {
                    _mconnectorGallaryName = value;
                    OnPropertyChanged(ConnectorConstants.ConnectorGallaryName);
                }
            }
        }
        List<Arrows> _mCaps;
        public List<Arrows> Caps
        {
            get
            {
                return _mCaps;
            }
            set
            {
                if (_mCaps != value)
                {
                    _mCaps = value;
                    OnPropertyChanged(ConnectorConstants.Caps);
                }
            }
        }
  
        string _mSourceCap = "M0,0 z";
        [DataMember]
        public string SourceCap
        {
            get
            {
                return _mSourceCap;
            }
            set
            {
                if (_mSourceCap != value)
                {
                    _mSourceCap = value;
                    OnPropertyChanged(ConnectorConstants.SourceCap);
                }
            }
        }
        string _mDecorator = "M0,0 z";
        [DataMember]
        public string Decorator
        {
            get
            {
                return _mDecorator;
            }
            set
            {
                if (_mDecorator != value)
                {
                    _mDecorator = value;
                    OnPropertyChanged(ConnectorConstants.Decorator);
                }
            }
        }
        string _mTargetCap = "M0,0 L10,5 L0,10 L 0,0";
        [DataMember]
        public string TargetCap
        {
            get
            {
                return _mTargetCap;
            }
            set
            {
                if (_mTargetCap != value)
                {
                    _mTargetCap = value;
                    OnPropertyChanged(ConnectorConstants.TargetCap);
                }
            }
        }

        ConnectType _mType = ConnectType.Orthogonal;
        [DataMember]
        public ConnectType Type
        {
            get
            {
                return _mType;
            }
            set
            {
                if (_mType != value)
                {
                    _mType = value;
                    OnPropertyChanged(ConnectorConstants.Type);
                }
            }
        }
        #endregion
        #region Undo/Redo
        public void LogData(object data)
        {
            var info = this.Info as IConnectorInfo;
            if (info != null && info.Graph != null)
            {
                info.Graph.HistoryManager.LogData(this, data);
            }
        }
        public object Undo(object data)
        {
            if (data is ConnectorState)
            {
                return RevertTo(data);
            }
            else
                return data;
        }

        public object Redo(object data)
        {
            if (data is ConnectorState)
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
            if (data is ConnectorState)
            {
                var current = GetData();
                ConnectorState toState = (ConnectorState)data;

                if (toState.ConnectorGeometryStyle != this.ConnectorGeometryStyle)
                {
                    this.ConnectorGeometryStyle = toState.ConnectorGeometryStyle;
                }

                if (toState.Decorator != this.Decorator)
                {
                    this.Decorator = toState.Decorator;
                }
                if (toState.DashDot != this.DashDot)
                {
                    this.DashDot = toState.DashDot;
                }
                if (toState.Stroke != this.Stroke)
                {
                    this.Stroke = toState.Stroke;
                }
                if (toState.Thickness != this.Thickness)
                {
                    this.Thickness = toState.Thickness;
                }
                if (toState.SourceCap != this.SourceCap)
                {
                    this.SourceCap = toState.SourceCap;
                }
                if(toState.TargetCap!=TargetCap)
                {
                    this.TargetCap = toState.TargetCap;
                }
                if (toState.SourceDecoratorStyle != this.SourceDecoratorStyle)
                {
                    this.SourceDecoratorStyle = toState.SourceDecoratorStyle;
                }
                if (toState.TargetDecoratorStyle != TargetDecoratorStyle)
                {
                    this.TargetDecoratorStyle = toState.TargetDecoratorStyle;
                }
                if (toState.SourceDecorator != this.SourceDecorator)
                {
                    this.SourceDecorator = toState.SourceDecorator;
                }
                if (toState.TargetDecorator != TargetDecorator)
                {
                    this.TargetDecorator = toState.TargetDecorator;
                }
                return current;
            }
            return data;
        }
        public object GetData()
        {
            return _mCollectionData;
        }
        protected override void OnPropertyChanged(string name)
        {
            var info = this.Info as IConnectorInfo;
            if (info != null && info.Graph != null && info.Graph.HistoryManager != null && AllowLogData(name))
            {

                if (info.Graph.HistoryManager.CanLogData(info.Graph.HistoryManager, _mCollectionData))
                {
                    LogData(_mCollectionData);
                }
            }
            base.OnPropertyChanged(name);
            switch (name)
            {
                case ConnectorConstants.SourceCap:
                    OnSourceCapChanged();
                    _mCollectionData.SourceCap = SourceCap;
                    break;
                case ConnectorConstants.TargetCap:
                    OnTargetCapChanged();
                    _mCollectionData.TargetCap = TargetCap;
                    break;
                case ConnectorConstants.Type:
                    OnTypeChanged();
                    break;
                case ConnectorConstants.Decorator:
                    OnDecoratorChanged();
                    _mCollectionData.Decorator = Decorator;
                    break;
                case ConnectorConstants.SourceDecoratorStyle:
                case ConnectorConstants.TargetDecoratorStyle:
                case ConnectorConstants.ConnectorGeometryStyle:
                case ConnectorConstants.SourceDecorator:
                case ConnectorConstants.TargetDecorator:
                case "Thickness":
                case "Stroke":
                case "DashDot":
                    _mCollectionData.SourceDecoratorStyle = SourceDecoratorStyle;
                    _mCollectionData.TargetDecoratorStyle = TargetDecoratorStyle;
                    _mCollectionData.SourceDecorator = SourceDecorator;
                    _mCollectionData.TargetDecorator = TargetDecorator;
                    _mCollectionData.Thickness = Thickness;
                    _mCollectionData.DashDot = DashDot;
                    _mCollectionData.Stroke = Stroke;
                    _mCollectionData.ConnectorGeometryStyle = ConnectorGeometryStyle;
                    break;
            }
        }

        private bool AllowLogData(string name)
        {
            if (name == "SourceCap" || name == "Decorator" || name == "SourceDecoratorStyle" 
                || name == "TargetDecoratorStyle" || name== "SourceDecorator" ||
                name== "TargetDecorator" || name== "Thickness" || name== "DashDot" 
                || name== "Stroke" || name== "ConnectorGeometryStyle")
            {
                return true;
            }

            return false;
        }

        private void OnTypeChanged()
        {
            switch (Type)
            {
                case ConnectType.Bezier:
                    Segments = new ObservableCollection<IConnectorSegment> {new CubicCurveSegment()};
                    break;
                case ConnectType.Orthogonal:
                    Segments = new ObservableCollection<IConnectorSegment> {new OrthogonalSegment()};
                    break;
                case ConnectType.Straight:
                    Segments = new ObservableCollection<IConnectorSegment> {new StraightSegment()};
                    break;
            }
        }

        private void OnTargetCapChanged()
        {
            TargetDecorator = TargetCap;
        }

        private void OnSourceCapChanged()
        {
            SourceDecorator = SourceCap;
        }
         private void  OnDecoratorChanged()
        {

        }
       
        protected override void ApplyStyle(Style style)
        {
            ConnectorGeometryStyle = style;

            SourceDecoratorStyle = getDecoratorStyle();
            TargetDecoratorStyle = getDecoratorStyle();
        }

        private Style getDecoratorStyle()
        {
            Style decoratorStyle = GetCustomStyle();
            decoratorStyle.Setters.Add(new Setter(Path.StrokeThicknessProperty, Thickness));
            decoratorStyle.Setters.Add(new Setter(Path.StretchProperty, Stretch.Fill));
            if (Stroke != null)
            {
                decoratorStyle.Setters.Add(new Setter(Path.FillProperty, Stroke));
            }
            return decoratorStyle;
        }

        
        public double SourcePadding { get; set; }

        public double TargetPadding { get; set; }

        object _mSegments = null;
        public object Segments
        {
            get
            {
                return _mSegments;
            }
            set
            {
                if (_mSegments != value)
                {
                    _mSegments = value;
                    OnPropertyChanged(ConnectorConstants.Segments);
                }
            }
        }

        public object SourceConnector { get; set; }

        public object TargetConnector
        {
            get;
            set;
        }

        public object TargetNodeID
        {
            get;
            set;
        }

        public object TargetConnectorID
        {
            get;
            set;
        }

        public object SourceNodeID
        {
            get;
            set;
        }

        public object SourceConnectorID
        {
            get;
            set;
        }

        public object TargetPortID
        {
            get;
            set;
        }

        public object SourcePortID
        {
            get;
            set;
        }
        public DiagramMenu Menu
        {
            get;
            set;
        }

        public object Ports
        {
            get;
            set;
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
                    OnPropertyChanged(ConnectorConstants.PortVisibility);
                }
            }
        }
        ///// <summary>
        ///// Gets or sets ThemeStyleId.
        ///// </summary>
        
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

    public interface IConnectorVM : IGroupableVM, IConnector
    {
        List<Arrows> Caps { get; set; }
        string SourceCap { get; set; }
        string Decorator { get; set; }
        string TargetCap { get; set; }
        ConnectType Type { get; set; }
        string ConnectorGallaryName { get; set; }

    }

    internal static class ConnectorConstants
    {
        public const string AnnotationConstraints = "AnnotationConstraints";
        public const string ConnectorGallaryName = "ConnectorGallaryName";
        public const string SourceNode = "SourceNode";
        public const string TargetNode = "TargetNode";
        public const string SourcePort = "SourcePort";
        public const string TargetPort = "TargetPort";
        public const string Segments = "Segments";
        public const string SourcePoint = "SourcePoint";
        public const string TargetPoint = "TargetPoint";
        public const string ConnectorGeometryStyle = "ConnectorGeometryStyle";
        public const string SourceDecorator = "SourceDecorator";
        public const string TargetDecorator = "TargetDecorator";
        public const string SourceDecoratorStyle = "SourceDecoratorStyle";
        public const string TargetDecoratorStyle = "TargetDecoratorStyle";
        public const string AutoBind = "AutoBind";
        public const string ID = "ID";
        public const string Key = "Key";
        public const string IsSelected = "IsSelected";
        public const string ZIndex = "ZIndex";
        public const string BridgeSpace = "BridgeSpace";
        public const string Annotations = "Annotations";
        public const string Constraints = "Constraints";
        public const string BezierSmoothness = "BezierSmoothness";
        public const string ParentGroup = "ParentGroup";
        public const string PortVisibility = "PortVisibility";
        public const string SourceDecoratorPivot = "SourceDecoratorPivot";
        public const string TargetDecoratorPivot = "TargetDecoratorPivot";
        public const string HitPadding = "HitPadding";
        public const string SegmentDecorators = "SegmentDecorators";
        public const string SegmentDecoratorStyle = "SegmentDecoratorStyle";
        public const string PortDragMode = "PortDragMode";



        public const string Caps = "Caps";
        public const string SourceCap = "SourceCap";
        public const string TargetCap = "TargetCap";
        public const string Decorator = "Decorator";
        public const string Type = "Type";
        public const string Types = "Types";
     }

    public class Arrows
    {
       public string decorator { get; set; }
       public bool Issourcecap { get; set; }
       public bool Istargetcap { get; set; }
       public bool Isbothcap { get; set; }
       public string LineData { get; set; }
       public bool IsCap { get; set; }
       public string HorizontalAlignment { get; set; }
       public int Angle { get; set; }
    }
    public struct ConnectorState
    {
        public ConnectorState(Brush stroke, string dasdot, double thickness, string scap, string tcap, object sdecorator, object Tdecorator, Style sdecoratorstyle, Style tdecoratorstyle, Style style,string decorator)
        {
            _mConnectorGeometryStyle = style;
            _mStroke = stroke;
            _mDashDot = dasdot;
            _mThickness = thickness;
            _mSourceCap = scap;
            _mTargetCap = tcap;
            _mSourceDecorator = sdecorator;
            _mTargetDecorator = Tdecorator;
            _mSourceDecoratorStyle = sdecoratorstyle;
            _mTargetDecoratorStyle = tdecoratorstyle;
            _mDecorator = decorator;
        }
        Style _mConnectorGeometryStyle;
        public Style ConnectorGeometryStyle
        {
            get
            {
                return _mConnectorGeometryStyle;
            }
            set
            {
                if (_mConnectorGeometryStyle != value)
                {
                    _mConnectorGeometryStyle = value;
                }
            }
        }

        private string _mSourceCap;
        public string SourceCap
        {
            get
            {
                return _mSourceCap;
            }
            set
            {
                if (_mSourceCap != value)
                {
                    _mSourceCap = value;
                }
            }
        }
        string _mDecorator;
        public string Decorator
        {
            get
            {
                return _mDecorator;
            }
            set
            {
                if (_mDecorator != value)
                {
                    _mDecorator = value;
                }
            }
        }
        string _mTargetCap;
        public string TargetCap
        {
            get
            {
                return _mTargetCap;
            }
            set
            {
                if (_mTargetCap != value)
                {
                    _mTargetCap = value;
                }
            }
        }
        object _mSourceDecorator;
        public object SourceDecorator
        {
            get
            {
                return _mSourceDecorator;
            }
            set
            {
                if (_mSourceDecorator != value)
                {
                    _mSourceDecorator = value;
                }
            }
        }


        object _mTargetDecorator;
        public object TargetDecorator
        {
            get
            {
                return _mTargetDecorator;
            }
            set
            {
                if (_mTargetDecorator != value)
                {
                    _mTargetDecorator = value;
                }
            }
        }


        Style _mSourceDecoratorStyle;
        public Style SourceDecoratorStyle
        {
            get
            {
                return _mSourceDecoratorStyle;
            }
            set
            {
                if (_mSourceDecoratorStyle != value)
                {
                    _mSourceDecoratorStyle = value;
                }
            }
        }


        Style _mTargetDecoratorStyle;
        public Style TargetDecoratorStyle
        {
            get
            {
                return _mTargetDecoratorStyle;
            }
            set
            {
                if (_mTargetDecoratorStyle != value)
                {
                    _mTargetDecoratorStyle = value;
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
        
    }
}
