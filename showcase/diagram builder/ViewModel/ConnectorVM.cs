// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectorVM.cs" company="">
//   
// </copyright>
// <summary>
//   The connector vm.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Runtime.Serialization;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Shapes;

    using DiagramBuilder.Utility;

    using Syncfusion.UI.Xaml.Diagram;
    using Syncfusion.UI.Xaml.Diagram.Controls;
    using Syncfusion.UI.Xaml.Diagram.Theming;

    /// <summary>
    ///     The connector vm.
    /// </summary>
    public class ConnectorVM : ConnectorViewModel, IConnectorVM, IUndoRedo
    {
        /// <summary>
        ///     The _m collection data.
        /// </summary>
        public ConnectorState _mCollectionData;

        /// <summary>
        ///     The _decorations.
        /// </summary>
        private TextDecorationCollection _decorations;

        /// <summary>
        ///     The _line.
        /// </summary>
        private bool _line;

        /// <summary>
        ///     The _m annotation.
        /// </summary>
        private LabelVM _mAnnotation = new LabelVM
                                           {
                                               UnitWidth = 100,
                                               UnitHeight = 100,
                                               TextHorizontalAlignment = TextAlignment.Center,
                                               TextVerticalAlignment = VerticalAlignment.Center
                                           };

        /// <summary>
        ///     The _m annotation hyper link.
        /// </summary>
        private LabelVM _mAnnotationHyperLink = new LabelVM("hyperlink");

        /// <summary>
        ///     The _m bold.
        /// </summary>
        private bool _mBold;

        /// <summary>
        ///     The _m caps.
        /// </summary>
        private List<Arrows> _mCaps;

        /// <summary>
        ///     The _mConnector gallary name.
        /// </summary>
        private string _mConnectorGalleryName;

        /// <summary>
        ///     The _m dash dot.
        /// </summary>
        private string _mDashDot = "1, 0";

        /// <summary>
        ///     The _m decorator.
        /// </summary>
        private string _mDecorator = "M0,0 z";

        /// <summary>
        ///     The _m font.
        /// </summary>
        private FontFamily _mFont = DiagramBuilderVM.Fonts[0];

        /// <summary>
        ///     The _m font size.
        /// </summary>
        private int _mFontSize = 12;

        /// <summary>
        ///     The _m font style.
        /// </summary>
        private FontStyle _mFontStyle = FontStyles.Normal;

        /// <summary>
        ///     The _m font weight.
        /// </summary>
        private FontWeight _mFontWeight = FontWeights.Normal;

        /// <summary>
        ///     The _m hyper link.
        /// </summary>
        private string _mHyperLink = "http://";

        /// <summary>
        ///     The _m italic.
        /// </summary>
        private bool _mItalic;

        /// <summary>
        ///     The _m label.
        /// </summary>
        private string _mLabel = string.Empty;

        /// <summary>
        ///     The _m label background.
        /// </summary>
        private Brush _mLabelBackground = new SolidColorBrush(Colors.Transparent);

        /// <summary>
        ///     The _m label foreground.
        /// </summary>
        private Brush _mLabelForeground = new SolidColorBrush(Colors.Black);

        /// <summary>
        ///     The _m label h align.
        /// </summary>
        private HorizontalAlignment _mLabelHAlign = HorizontalAlignment.Center;

        /// <summary>
        ///     The _m label margin.
        /// </summary>
        private Thickness _mLabelMargin = new Thickness(5);

        /// <summary>
        ///     The _m label v align.
        /// </summary>
        private VerticalAlignment _mLabelVAlign = VerticalAlignment.Center;

        /// <summary>
        ///     The _m name.
        /// </summary>
        private string _mName = string.Empty;

        /// <summary>
        ///     The _m opacity.
        /// </summary>
        private double _mOpacity = 1d;

        /// <summary>
        ///     The _m quick fill.
        /// </summary>
        private Brush _mQuickFill;

        /// <summary>
        ///     The _m source cap.
        /// </summary>
        private string _mSourceCap = "M0,0 z";

        /// <summary>
        ///     The _m strike.
        /// </summary>
        private bool _mStrike;

        /// <summary>
        ///     The _m text align.
        /// </summary>
        private TextAlignment _mTextAlign = TextAlignment.Center;

        /// <summary>
        ///     The _m type.
        /// </summary>
        private ConnectType _mType = ConnectType.Orthogonal;

        /// <summary>
        ///     The _m visibility.
        /// </summary>
        private Visibility _mVisibility = Visibility.Visible;

        /// <summary>
        ///     The _m stroke.
        /// </summary>
        private Brush mStroke = new SolidColorBrush(Colors.Red);

        /// <summary>
        ///     The _m style.
        /// </summary>
        private Style mStyle;

        /// <summary>
        ///     The _m target cap.
        /// </summary>
        private string mTargetCap = "M0,0 L10,5 L0,10 L 0,0";

        /// <summary>
        ///     The _m thickness.
        /// </summary>
        private double mThickness = 1d;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConnectorVM" /> class.
        /// </summary>
        public ConnectorVM()
        {
            this.ThemeStyleId = StyleId.Variant1;
            this.Constraints |= ConnectorConstraints.ThemeStyle | ConnectorConstraints.Draggable;
            this.ZIndex = -10;
            this.Stroke = new SolidColorBrush(new Color { A = 0xFF, R = 0x5B, G = 0x9B, B = 0xD5 });
            this._mCollectionData = new ConnectorState(
                this.Stroke,
                this.DashDot,
                this.Thickness,
                this.SourceCap,
                this.TargetCap,
                this.SourceDecorator,
                this.TargetDecorator,
                this.SourceDecoratorStyle,
                this.TargetDecoratorStyle,
                this.ConnectorGeometryStyle,
                this.Decorator);

            // Work around
            this.ThemeStyleId = StyleId.Accent1 | StyleId.Subtly;
            this.Annotations = new List<IAnnotation> { this._mAnnotation, this._mAnnotationHyperLink };
            this._mAnnotation.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == "Content")
                    {
                        this.Label = (string)this._mAnnotation.Content;
                        this.HyperLink = this._mAnnotationHyperLink.HyperLink;
                    }
                };
        }

        /// <summary>
        ///     Gets or sets a value indicating whether bold.
        /// </summary>
        [DataMember]
        public bool Bold
        {
            get
            {
                return this._mBold;
            }

            set
            {
                if (this._mBold != value)
                {
                    this._mBold = value;
                    this.OnPropertyChanged(GroupableConstants.Bold);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the caps.
        /// </summary>
        public List<Arrows> Caps
        {
            get
            {
                return this._mCaps;
            }

            set
            {
                if (this._mCaps != value)
                {
                    this._mCaps = value;
                    this.OnPropertyChanged(ConnectorConstants.Caps);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the connector gallary name.
        /// </summary>
        [DataMember]
        public string ConnectorGalleryName
        {
            get
            {
                return this._mConnectorGalleryName;
            }

            set
            {
                if (this._mConnectorGalleryName != value)
                {
                    this._mConnectorGalleryName = value;
                    this.OnPropertyChanged(ConnectorConstants.ConnectorGalleryName);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the dash dot.
        /// </summary>
        [DataMember]
        public string DashDot
        {
            get
            {
                return this._mDashDot;
            }

            set
            {
                if (this._mDashDot != value)
                {
                    this._mDashDot = value;
                    this.OnPropertyChanged(GroupableConstants.DashDot);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the decoration.
        /// </summary>
        [DataMember]
        public TextDecorationCollection Decoration
        {
            get
            {
                return this._decorations;
            }

            set
            {
                this._decorations = value;

                // _mAnnotation.Decoration = value;
                this.OnPropertyChanged(GroupableConstants.Decoration);
            }
        }

        /// <summary>
        ///     Gets or sets the decorator.
        /// </summary>
        [DataMember]
        public string Decorator
        {
            get
            {
                return this._mDecorator;
            }

            set
            {
                if (this._mDecorator != value)
                {
                    this._mDecorator = value;
                    this.OnPropertyChanged(ConnectorConstants.Decorator);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the font.
        /// </summary>
        public FontFamily Font
        {
            get
            {
                return this._mFont;
            }

            set
            {
                if (this._mFont != value)
                {
                    this._mFont = value;
                    this.OnPropertyChanged(GroupableConstants.Font);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the font size.
        /// </summary>
        [DataMember]
        public int FontSize
        {
            get
            {
                return this._mFontSize;
            }

            set
            {
                if (this._mFontSize != value)
                {
                    this._mFontSize = value;
                    this.OnPropertyChanged(GroupableConstants.FontSize);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the font style.
        /// </summary>
        [DataMember]
        public FontStyle FontStyle
        {
            get
            {
                return this._mFontStyle;
            }

            set
            {
                if (this._mFontStyle != value)
                {
                    this._mFontStyle = value;

                    // _mAnnotation.FontStyle = value;
                    this.OnPropertyChanged(GroupableConstants.FontStyle);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the font weight.
        /// </summary>
        [DataMember]
        public FontWeight FontWeight
        {
            get
            {
                return this._mFontWeight;
            }

            set
            {
                {
                    // if (_mFontWeight != value)
                    this._mFontWeight = value;

                    // _mAnnotation.FontWeight = value;
                    this.OnPropertyChanged(GroupableConstants.FontWeight);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the hyper link.
        /// </summary>
        [DataMember]
        public string HyperLink
        {
            get
            {
                return this._mHyperLink;
            }

            set
            {
                if (this._mHyperLink != value)
                {
                    this._mHyperLink = value;
                    this.OnPropertyChanged(GroupableConstants.HyperLink);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether italic.
        /// </summary>
        [DataMember]
        public bool Italic
        {
            get
            {
                return this._mItalic;
            }

            set
            {
                if (this._mItalic != value)
                {
                    this._mItalic = value;
                    this.OnPropertyChanged(GroupableConstants.Italic);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the label.
        /// </summary>
        [DataMember]
        public string Label
        {
            get
            {
                return this._mLabel;
            }

            set
            {
                if (this._mLabel != value)
                {
                    this._mLabel = value;
                    this.OnPropertyChanged(GroupableConstants.Label);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the label background.
        /// </summary>
        public Brush LabelBackground
        {
            get
            {
                return this._mLabelBackground;
            }

            set
            {
                if (this._mLabelBackground != value)
                {
                    this._mLabelBackground = value;
                    this.OnPropertyChanged(GroupableConstants.LabelBackground);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the label bg dummy.
        /// </summary>
        [DataMember]
        public string LabelBgDummy
        {
            get
            {
                if (this.LabelBackground != null && this.LabelBackground is SolidColorBrush)
                    return (this.LabelBackground as SolidColorBrush).Color.ToString();
                return null;
            }

            set
            {
                this.LabelBackground = new SolidColorBrush(value.ToColor());
            }
        }

        /// <summary>
        ///     Gets or sets the label fg dummy.
        /// </summary>
        [DataMember]
        public string LabelFgDummy
        {
            get
            {
                if (this.LabelForeground != null && this.LabelForeground is SolidColorBrush)
                    return (this.LabelForeground as SolidColorBrush).Color.ToString();
                return null;
            }

            set
            {
                this.LabelForeground = new SolidColorBrush(value.ToColor());
            }
        }

        /// <summary>
        ///     Gets or sets the label foreground.
        /// </summary>
        public Brush LabelForeground
        {
            get
            {
                return this._mLabelForeground;
            }

            set
            {
                if (this._mLabelForeground != value)
                {
                    this._mLabelForeground = value;
                    this.OnPropertyChanged(GroupableConstants.LabelForeground);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the label h align.
        /// </summary>
        [DataMember]
        public HorizontalAlignment LabelHAlign
        {
            get
            {
                return this._mLabelHAlign;
            }

            set
            {
                if (this._mLabelHAlign != value)
                {
                    this._mLabelHAlign = value;
                    this.OnPropertyChanged(GroupableConstants.LabelHAlign);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the label margin.
        /// </summary>
        [DataMember]
        public Thickness LabelMargin
        {
            get
            {
                return this._mLabelMargin;
            }

            set
            {
                if (this._mLabelMargin != value)
                {
                    this._mLabelMargin = value;
                    this._mAnnotation.LabelMargin = value;
                    this.OnPropertyChanged(GroupableConstants.LabelMargin);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the label v align.
        /// </summary>
        [DataMember]
        public VerticalAlignment LabelVAlign
        {
            get
            {
                return this._mLabelVAlign;
            }

            set
            {
                if (this._mLabelVAlign != value)
                {
                    this._mLabelVAlign = value;
                    this.OnPropertyChanged(GroupableConstants.LabelVAlign);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        [DataMember]
        public string Name
        {
            get
            {
                return this._mName;
            }

            set
            {
                if (this._mName != value)
                {
                    this._mName = value;
                    this.OnPropertyChanged(GroupableConstants.Name);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the opacity.
        /// </summary>
        [DataMember]
        public double Opacity
        {
            get
            {
                return this._mOpacity;
            }

            set
            {
                if (this._mOpacity != value)
                {
                    this._mOpacity = value;
                    this.OnPropertyChanged(GroupableConstants.Opacity);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the quick fill.
        /// </summary>
        public Brush QuickFill
        {
            get
            {
                return this._mQuickFill;
            }

            set
            {
                if (this._mQuickFill != value)
                {
                    this._mQuickFill = value;
                    this.OnPropertyChanged(GroupableConstants.QuickFill);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the source cap.
        /// </summary>
        [DataMember]
        public string SourceCap
        {
            get
            {
                return this._mSourceCap;
            }

            set
            {
                if (this._mSourceCap != value)
                {
                    this._mSourceCap = value;
                    this.OnPropertyChanged(ConnectorConstants.SourceCap);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the state.
        /// </summary>
        public UndoRedoState State { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether strike.
        /// </summary>
        [DataMember]
        public bool Strike
        {
            get
            {
                return this._mStrike;
            }

            set
            {
                if (this._mStrike != value)
                {
                    this._mStrike = value;
                    this.OnPropertyChanged(GroupableConstants.Strike);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the stroke.
        /// </summary>
        public Brush Stroke
        {
            get
            {
                return this.mStroke;
            }

            set
            {
                if (this.mStroke != value)
                {
                    this.mStroke = value;
                    this.OnPropertyChanged(GroupableConstants.Stroke);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the stroke dummy.
        /// </summary>
        [DataMember]
        public string StrokeDummy
        {
            get
            {
                if (this.Stroke != null && this.Stroke is SolidColorBrush)
                    return (this.Stroke as SolidColorBrush).Color.ToString();
                return null;
            }

            set
            {
                this.Stroke = new SolidColorBrush(value.ToColor());
            }
        }

        /// <summary>
        ///     Gets or sets the style.
        /// </summary>
        public Style Style
        {
            get
            {
                return this.mStyle;
            }

            set
            {
                if (this.mStyle != value)
                {
                    this.mStyle = value;
                    this.OnPropertyChanged(GroupableConstants.Style);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the target cap.
        /// </summary>
        [DataMember]
        public string TargetCap
        {
            get
            {
                return this.mTargetCap;
            }

            set
            {
                if (this.mTargetCap != value)
                {
                    this.mTargetCap = value;
                    this.OnPropertyChanged(ConnectorConstants.TargetCap);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the text alignment.
        /// </summary>
        [DataMember]
        public TextAlignment TextAlignment
        {
            get
            {
                return this._mTextAlign;
            }

            set
            {
                if (this._mTextAlign != value)
                {
                    this._mTextAlign = value;
                    this.OnPropertyChanged(GroupableConstants.TextAlignment);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the thickness.
        /// </summary>
        [DataMember]
        public double Thickness
        {
            get
            {
                return this.mThickness;
            }

            set
            {
                if (this.mThickness != value)
                {
                    this.mThickness = value;
                    this.OnPropertyChanged(GroupableConstants.Thickness);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        [DataMember]
        public ConnectType Type
        {
            get
            {
                return this._mType;
            }

            set
            {
                if (this._mType != value)
                {
                    this._mType = value;
                    this.OnPropertyChanged(ConnectorConstants.Type);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether under line.
        /// </summary>
        [DataMember]
        public bool UnderLine
        {
            get
            {
                return this._line;
            }

            set
            {
                if (this._line != value)
                {
                    this._line = value;
                    this.OnPropertyChanged(GroupableConstants.UnderLine);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the visibility.
        /// </summary>
        [DataMember]
        public Visibility Visibility
        {
            get
            {
                return this._mVisibility;
            }

            set
            {
                if (this._mVisibility != value)
                {
                    this._mVisibility = value;
                    this.OnPropertyChanged(GroupableConstants.Visibility);
                }
            }
        }

        /// <summary>
        /// The can redo.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CanRedo(object data)
        {
            if (this.State == UndoRedoState.Idle)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The can undo.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CanUndo(object data)
        {
            if (this.State == UndoRedoState.Idle)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        ///     The get data.
        /// </summary>
        /// <returns>
        ///     The <see cref="object" />.
        /// </returns>
        public object GetData()
        {
            return this._mCollectionData;
        }

        /// <summary>
        /// The log data.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        public void LogData(object data)
        {
            IConnectorInfo info = this.Info as IConnectorInfo;
            if (info != null && info.Graph != null)
            {
                info.Graph.HistoryManager.LogData(this, data);
            }
        }

        /// <summary>
        /// The redo.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object Redo(object data)
        {
            if (data is ConnectorState)
            {
                return this.RevertTo(data);
            }

            return data;
        }

        /// <summary>
        /// The revert to.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object RevertTo(object data)
        {
            if (data is ConnectorState)
            {
                object current = this.GetData();
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

                if (toState.TargetCap != this.TargetCap)
                {
                    this.TargetCap = toState.TargetCap;
                }

                if (toState.SourceDecoratorStyle != this.SourceDecoratorStyle)
                {
                    this.SourceDecoratorStyle = toState.SourceDecoratorStyle;
                }

                if (toState.TargetDecoratorStyle != this.TargetDecoratorStyle)
                {
                    this.TargetDecoratorStyle = toState.TargetDecoratorStyle;
                }

                if (toState.SourceDecorator != this.SourceDecorator)
                {
                    this.SourceDecorator = toState.SourceDecorator;
                }

                if (toState.TargetDecorator != this.TargetDecorator)
                {
                    this.TargetDecorator = toState.TargetDecorator;
                }

                return current;
            }

            return data;
        }

        /// <summary>
        /// The undo.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object Undo(object data)
        {
            if (data is ConnectorState)
            {
                return this.RevertTo(data);
            }

            return data;
        }

        /// <summary>
        /// The apply style.
        /// </summary>
        /// <param name="style">
        /// The style.
        /// </param>
        protected void ApplyStyle(Style style)
        {
            this.ConnectorGeometryStyle = style;

            this.SourceDecoratorStyle = this.getDecoratorStyle();
            this.TargetDecoratorStyle = this.getDecoratorStyle();
        }

        /// <summary>
        /// The decode style.
        /// </summary>
        /// <param name="style">
        /// The style.
        /// </param>
        protected virtual void DecodeStyle(Style style)
        {
            foreach (Setter setter in style.Setters)
            {
                if (setter.Property == Shape.StrokeProperty)
                {
                    this.Stroke = setter.Value as Brush;
                }
                else if (setter.Property == Shape.StrokeThicknessProperty)
                {
                    this.Thickness = (double)setter.Value;
                }
                else if (setter.Property == Shape.StrokeDashArrayProperty)
                {
                    string data = string.Empty;
                    foreach (double item in setter.Value as DoubleCollection)
                    {
                        data += item + ", ";
                    }

                    if (!string.IsNullOrEmpty(data))
                    {
                        data = data.Substring(0, data.Length - 2);
                        this.DashDot = data;
                    }
                }
                else if (setter.Property == UIElement.OpacityProperty)
                {
                    this.Opacity = (double)setter.Value;
                }
            }
        }

        /// <summary>
        ///     The get custom style.
        /// </summary>
        /// <returns>
        ///     The <see cref="Style" />.
        /// </returns>
        protected virtual Style GetCustomStyle()
        {
            Style customStyle = new Style(typeof(Path));
            if (this.Stroke != null)
            {
                customStyle.Setters.Add(new Setter(Shape.StrokeProperty, this.Stroke));
            }

            if (!double.IsNaN(this.Thickness) && !double.IsInfinity(this.Thickness))
            {
                customStyle.Setters.Add(new Setter(Shape.StrokeThicknessProperty, this.Thickness));
            }

            customStyle.Setters.Add(new Setter(UIElement.OpacityProperty, this.Opacity));
            if (this.DashDot != null)
            {
                DoubleCollection dc = new DoubleCollection();
                string[] split = this.DashDot.Split(',');
                foreach (string s in split)
                {
                    dc.Add(Convert.ToDouble(s));
                }

                customStyle.Setters.Add(new Setter(Shape.StrokeDashArrayProperty, dc));
            }

            return customStyle;
        }

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        protected override void OnPropertyChanged(string name)
        {
            IConnectorInfo info = this.Info as IConnectorInfo;
            if (info != null && info.Graph != null && info.Graph.HistoryManager != null && this.AllowLogData(name))
            {
                if (info.Graph.HistoryManager.CanLogData(info.Graph.HistoryManager, this._mCollectionData))
                {
                    this.LogData(this._mCollectionData);
                }
            }

            base.OnPropertyChanged(name);
            switch (name)
            {
                case ConnectorConstants.SourceCap:
                    this.SourceDecorator = this.SourceCap;
                    this._mCollectionData.SourceCap = this.SourceCap;
                    break;
                case ConnectorConstants.TargetCap:
                    this.TargetDecorator = this.TargetCap;
                    this._mCollectionData.TargetCap = this.TargetCap;
                    break;
                case ConnectorConstants.Type:
                    this.OnTypeChanged();
                    break;
                case ConnectorConstants.Decorator:
                    this._mCollectionData.Decorator = this.Decorator;
                    break;
                case ConnectorConstants.SourceDecoratorStyle:
                case ConnectorConstants.TargetDecoratorStyle:
                case ConnectorConstants.ConnectorGeometryStyle:
                case ConnectorConstants.SourceDecorator:
                case ConnectorConstants.TargetDecorator:
                    this._mCollectionData.SourceDecoratorStyle = this.SourceDecoratorStyle;
                    this._mCollectionData.TargetDecoratorStyle = this.TargetDecoratorStyle;
                    this._mCollectionData.SourceDecorator = this.SourceDecorator;
                    this._mCollectionData.TargetDecorator = this.TargetDecorator;
                    this._mCollectionData.ConnectorGeometryStyle = this.ConnectorGeometryStyle;
                    break;
                case GroupableConstants.Stroke:
                    this._mCollectionData.Stroke = this.Stroke;
                    this.ApplyStyle(this.GetCustomStyle());
                    break;
                case GroupableConstants.Style:
                    if (this.Style != null) this.DecodeStyle(this.Style);
                    break;
                case GroupableConstants.Opacity:
                    this.ApplyStyle(this.GetCustomStyle());
                    break;
                case GroupableConstants.Thickness:
                    this._mCollectionData.Thickness = this.Thickness;
                    this.ApplyStyle(this.GetCustomStyle());
                    break;
                case GroupableConstants.DashDot:
                    this._mCollectionData.DashDot = this.DashDot;
                    this.ApplyStyle(this.GetCustomStyle());
                    break;
            }
        }

        /// <summary>
        /// The allow log data.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool AllowLogData(string name)
        {
            if (name == "SourceCap" || name == "Decorator" || name == "SourceDecoratorStyle"
                || name == "TargetDecoratorStyle" || name == "SourceDecorator" || name == "TargetDecorator"
                || name == "Thickness" || name == "DashDot" || name == "Stroke" || name == "ConnectorGeometryStyle")
            {
                return true;
            }

            return false;
        }

        /// <summary>
        ///     The get decorator style.
        /// </summary>
        /// <returns>
        ///     The <see cref="Style" />.
        /// </returns>
        private Style getDecoratorStyle()
        {
            Style decoratorStyle = this.GetCustomStyle();
            decoratorStyle.Setters.Add(new Setter(Shape.StrokeThicknessProperty, this.Thickness));
            decoratorStyle.Setters.Add(new Setter(Shape.StretchProperty, Stretch.Fill));
            if (this.Stroke != null)
            {
                decoratorStyle.Setters.Add(new Setter(Shape.FillProperty, this.Stroke));
            }

            return decoratorStyle;
        }

        /// <summary>
        ///     The on type changed.
        /// </summary>
        private void OnTypeChanged()
        {
            switch (this.Type)
            {
                case ConnectType.Bezier:
                    this.Segments = new ObservableCollection<IConnectorSegment> { new CubicCurveSegment() };
                    break;
                case ConnectType.Orthogonal:
                    this.Segments = new ObservableCollection<IConnectorSegment> { new OrthogonalSegment() };
                    break;
                case ConnectType.Straight:
                    this.Segments = new ObservableCollection<IConnectorSegment> { new StraightSegment() };
                    break;
            }
        }
    }
}