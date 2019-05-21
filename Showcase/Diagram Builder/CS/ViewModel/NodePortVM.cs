#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Runtime.Serialization;
using DiagramBuilder.Utility;
using System.Collections.ObjectModel;

namespace DiagramBuilder.ViewModel
{
    public class NodePortVM : DiagramElementViewModel, INodePortVM
    {
        public NodePortVM()
        {

        }
        private Brush _mStroke = new SolidColorBrush(Colors.Black);

        public Brush Stroke
        {
            get
            {
                return _mStroke;
            }
            set
            {
                _mStroke = value;
                OnPropertyChanged(NodePortConstants.Stroke);
            }
        }

        [DataMember]
        public string StrokeDummy
        {
            get
            {
                if (Stroke != null && Stroke is SolidColorBrush)
                    return (Stroke as SolidColorBrush).Color.ToString();
                else
                    return null;
            }
            set
            {
                Stroke = new SolidColorBrush(value.ToColor());
            }
        }

        public ConnectionDirection ConnectionDirection
        {
            get;
            set;
        }

        double _mConnectorPadding = 0d;
        /// <summary>
        ///  ConnectorPadding
        /// </summary>
        public double ConnectorPadding
        {
            get
            {
                return _mConnectorPadding;
            }
            set
            {
                if (_mConnectorPadding != value)
                {
                    _mConnectorPadding = value;
                    OnPropertyChanged(NodePortConstants.ConnectorPadding);
                }
            }
        }
        private bool _misselected = false;

        public bool IsSelected
        {
            get { return _misselected; }
            set
            {
                if (value != _misselected)
                {
                    _misselected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }
        Thickness _mDisplacement = new Thickness(0, 0, 0, 0);
        /// <summary>
        ///  Displacement
        /// </summary>
        public Thickness Displacement
        {
            get
            {
                return _mDisplacement;
            }
            set
            {
                if (_mDisplacement != value)
                {
                    _mDisplacement = value;
                    OnPropertyChanged(NodePortConstants.Displacement);
                }
            }
        }
        public object Info
        {
            get;

            set;
        }
        public object Key
        {
            get;

            set;
        }

        object _mNode = null;
        /// <summary>
        ///  Node
        /// </summary>
        public object Node
        {
            get
            {
                return _mNode;
            }
            set
            {
                if (_mNode == null || !_mNode.Equals(value))
                {
                    _mNode = value;
                    OnPropertyChanged(NodePortConstants.Node);
                }
            }
        }
        double _mNodeOffsetX = 0.5d;
        /// <summary>
        ///  NodeOffsetX
        /// </summary>
        public double NodeOffsetX
        {
            get
            {
                return _mNodeOffsetX;
            }
            set
            {
                if (_mNodeOffsetX != value)
                {
                    _mNodeOffsetX = value;
                    OnPropertyChanged(NodePortConstants.NodeOffsetX);
                }
            }
        }

        double _mNodeOffsetY = 0.5d;
        /// <summary>
        ///  NodeOffsetY
        /// </summary>
        public double NodeOffsetY
        {
            get
            {
                return _mNodeOffsetY;
            }
            set
            {
                if (_mNodeOffsetY != value)
                {
                    _mNodeOffsetY = value;
                    OnPropertyChanged(NodePortConstants.NodeOffsetY);
                }
            }
        }

        object _mID = null;
        /// <summary>
        ///  ID
        /// </summary>
        public object ID
        {
            get
            {
                return _mID;
            }
            set
            {
                if (_mID == null || !_mID.Equals(value))
                {
                    _mID = value;
                    OnPropertyChanged(NodePortConstants.ID);
                }
            }
        }

        object _mShape = null;
        /// <summary>
        ///  Shape
        /// </summary>
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
                    OnPropertyChanged(NodePortConstants.Shape);
                }
            }
        }

        Style _mShapeStyle = null;
        /// <summary>
        ///  ShapeStyle
        /// </summary>
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
                    OnPropertyChanged(NodePortConstants.ShapeStyle);
                }
            }
        }

        PortVisibility _mPortVisibility = PortVisibility.MouseOver;
        /// <summary>
        ///  PortVisibility
        /// </summary>
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
                    OnPropertyChanged(NodePortConstants.PortVisibility);
                }
            }
        }

        PortConstraints _mConstraints = PortConstraints.Default;
        /// <summary>
        ///  Constraints
        /// </summary>
        public PortConstraints Constraints
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
                    OnPropertyChanged(NodePortConstants.Constraints);
                }
            }
        }

        double _mUnitWidth = double.NaN;
        /// <summary>
        ///  UnitWidth
        /// </summary>
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
                    OnPropertyChanged(NodePortConstants.UnitWidth);
                }
            }
        }

        double _mUnitHeight = double.NaN;
        /// <summary>
        ///  UnitHeight
        /// </summary>
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
                    OnPropertyChanged(NodePortConstants.UnitHeight);
                }
            }
        }

        UnitMode _mUnitMode = UnitMode.Fraction;
        /// <summary>
        ///  UnitMode
        /// </summary>
        public UnitMode UnitMode
        {
            get
            {
                return _mUnitMode;
            }
            set
            {
                if (_mUnitMode != value)
                {
                    _mUnitMode = value;
                    OnPropertyChanged(NodePortConstants.UnitMode);
                }
            }
        }

        private Brush _mFill = new SolidColorBrush(Colors.White);
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
                    OnPropertyChanged(NodePortConstants.Fill);
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

        public double HitPadding
        {
            get;set;
        }

        private void OnFillChanged()
        {
            ApplyStyle(GetCustomStyle());
        }
        protected virtual void DecodeStyle(Style style)
        {
            foreach (Setter setter in style.Setters)
            {
                if (setter.Property == Path.FillProperty)
                {
                    Fill = setter.Value as Brush;
                }
                else if (setter.Property == Path.StrokeProperty)
                {
                    Stroke = setter.Value as Brush;
                }
            }
        }

        protected virtual Style GetCustomStyle()
        {
            Style s = new Style(typeof(Path));
            if (Fill != null)
            {
                s.Setters.Add(new Setter(Path.FillProperty, Fill));
                s.Setters.Add(new Setter(Path.StretchProperty, Stretch.Fill));
            }
            if (Stroke != null)
            {
                s.Setters.Add(new Setter(Path.StrokeProperty, Stroke));
            }
            return s;
        }

        protected virtual void ApplyStyle(Style style)
        {
            ShapeStyle = style;
        }
        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);
            switch (name)
            {
                case NodePortConstants.Fill:
                    OnFillChanged();
                    break;
                case NodePortConstants.Stroke:
                    OnStrokeChanged();
                    break;
            }
        }

        private void OnStrokeChanged()
        {
            ApplyStyle(GetCustomStyle());
        }
    }
    public interface INodePortVM : INodePort
    {
        Brush Fill { get; set; }
        bool IsSelected { get; set; }

    }
    internal static class NodePortConstants
    {
        public const string IsSelected = "IsSelected";
        public const string NodeOffsetX = "NodeOffsetX";
        public const string NodeOffsetY = "NodeOffsetY";
        public const string Node = "Node";
        public const string UnitMode = "UnitMode";
        public const string ID = "ID";
        public const string Key = "Key";
        public const string Fill = "Fill";
        public const string Stroke = "Stroke";
        public const string Shape = "Shape";
        public const string ShapeStyle = "ShapeStyle";
        public const string PortVisibility = "PortVisibility";
        public const string Constraints = "Constraints";
        public const string ConnectorPadding = "ConnectorPadding";
        public const string Displacement = "Displacement";
        public const string UnitWidth = "UnitWidth";
        public const string UnitHeight = "UnitHeight";
        public const string PortDragMode = "PortDragMode";
        public const string IsPortDragging = "IsPortDragging";
        public const string Content = "Content";
        //public const string Flip = "Flip";
    }
    public class PortCollection : ObservableCollection<NodePortVM>
    {

    }
}
