// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NodeVM.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the custom class for node viewmodel.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Shapes;

    using Brainstorming.ViewModel;

    using DiagramBuilder.Utility;
    using OrganizationChart.ViewModel;
    using Syncfusion.UI.Xaml.Diagram;
    using Syncfusion.UI.Xaml.Diagram.Controls;
    using Syncfusion.UI.Xaml.Diagram.Theming;

    /// <summary>
    ///     Represents the custom class for node viewmodel.
    /// </summary>
    public class NodeVM : NodeViewModel, INodeVM, IUndoRedo
    {
        /// <summary>
        ///     Represents the _m collection data.
        /// </summary>
        public NodeState _mCollectionData;

        /// <summary>
        ///     Represents the _content.
        /// </summary>
        private string _content;

        /// <summary>
        ///     The _decorations.
        /// </summary>
        private TextDecorationCollection _decorations;

        /// <summary>
        ///     The _line.
        /// </summary>
        private bool _line;

        /// <summary>
        ///     The _m allow drag.
        /// </summary>
        private bool _mAllowDrag = true;

        /// <summary>
        ///     The _m allow resize.
        /// </summary>
        private bool _mAllowResize = true;

        /// <summary>
        ///     The _m allow rotate.
        /// </summary>
        private bool _mAllowRotate = true;

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
        /// Node Template name
        /// </summary>
        private string _mnodeTemplateName;

        /// <summary>
        ///     The _m aspect ratio.
        /// </summary>
        private bool _mAspectRatio = true;

        /// <summary>
        ///     The _m bold.
        /// </summary>
        private bool _mBold;

        /// <summary>
        ///     The _m dash dot.
        /// </summary>
        private string _mDashDot = "1, 0";

        /// <summary>
        ///     The _m fill.
        /// </summary>
        private Brush _mFill = new SolidColorBrush(new Color { A = 0xFF, R = 0x5B, G = 0x9B, B = 0xD5 });

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
        ///     The _mNode gallary name.
        /// </summary>
        private string _mNodeGalleryName;

        /// <summary>
        ///     The _m opacity.
        /// </summary>
        private double _mOpacity = 1d;

        /// <summary>
        ///     The _m quick fill.
        /// </summary>
        private Brush _mQuickFill;

        /// <summary>
        ///     The _m strike.
        /// </summary>
        private bool _mStrike;

        /// <summary>
        ///     The _m text align.
        /// </summary>
        private TextAlignment _mTextAlign = TextAlignment.Center;

        /// <summary>
        ///     The _m tool tip.
        /// </summary>
        private string _mToolTip;

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
        ///     The _m thickness.
        /// </summary>
        private double mThickness = 1d;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NodeVM" /> class.
        /// </summary>
        public NodeVM()
        {
            this.ThemeStyleId = StyleId.Variant1;
            foreach (Window win in Application.Current.Windows)
            {
                if (win.DataContext is DiagramBuilderVM)
                {
                    bool value = (win.DataContext as DiagramBuilderVM).IsApplyTheme;
                    if (value)
                    {
                        this.Constraints |= NodeConstraints.ThemeStyle;
                    }
                    else
                    {
                        this.Constraints &= ~NodeConstraints.ThemeStyle;
                    }
                }
            }

            this.Stroke = new SolidColorBrush(new Color { A = 0xFF, R = 0xC8, G = 0xC8, B = 0xC8 });
            this.OnConstraintsChanged();
            this._mCollectionData = new NodeState(
                this.ShapeStyle,
                this.Fill,
                this.QuickFill,
                this.Stroke,
                this.DashDot,
                this.Thickness);
            this._mCollectionData.ShapeStyle = this.ShapeStyle;
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
        ///     Gets or sets a value indicating whether allow drag or not.
        /// </summary>
        [DataMember]
        public bool AllowDrag
        {
            get
            {
                return this._mAllowDrag;
            }

            set
            {
                if (this._mAllowDrag != value)
                {
                    this._mAllowDrag = value;
                    this.OnPropertyChanged(NodeConstants.AllowDrag);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether allow resize or not.
        /// </summary>
        [DataMember]
        public bool AllowResize
        {
            get
            {
                return this._mAllowResize;
            }

            set
            {
                if (this._mAllowResize != value)
                {
                    this._mAllowResize = value;
                    this.OnPropertyChanged(NodeConstants.AllowResize);
                }
            }
        }

               
        [DataMember]
        public string NodeTemplateName
        {
            get
            {
                return _mnodeTemplateName;
            }
            set
            {
                if (_mnodeTemplateName != value)
                {
                    _mnodeTemplateName = value;
                    OnPropertyChanged(NodeConstants.NodeTemplateName);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether allow rotate or not.
        /// </summary>
        [DataMember]
        public bool AllowRotate
        {
            get
            {
                return this._mAllowRotate;
            }

            set
            {
                if (this._mAllowRotate != value)
                {
                    this._mAllowRotate = value;
                    this.OnPropertyChanged(NodeConstants.AllowRotate);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether node can resize based on aspect ratio or not.
        /// </summary>
        [DataMember]
        public bool AspectRatio
        {
            get
            {
                return this._mAspectRatio;
            }

            set
            {
                if (this._mAspectRatio != value)
                {
                    this._mAspectRatio = value;
                    this.OnPropertyChanged(NodeConstants.AspectRatio);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether content can be represented in bold or not.
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
        ///     Gets or sets the dummy content property to hold the original content.
        /// </summary>
        [DataMember]
        public string ContentDummy
        {
            get
            {
                return this._content;
            }

            set
            {
                this._content = value;
                this.Shape = value;
                this.Content = null;
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
        ///     Gets or sets the text decoration.
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
        ///     Gets or sets the fill.
        /// </summary>
        public Brush Fill
        {
            get
            {
                return this._mFill;
            }

            set
            {
                if (this._mFill != value)
                {
                    this._mFill = value;
                    this.OnPropertyChanged(NodeConstants.Fill);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the filldummy property to hold the original fill value.
        /// </summary>
        [DataMember]
        public string FillDummy
        {
            get
            {
                if (this.Fill != null && this.Fill is SolidColorBrush)
                    return (this.Fill as SolidColorBrush).Color.ToString();
                return null;
            }

            set
            {
                this.Fill = new SolidColorBrush(value.ToColor());
            }
        }

        /// <summary>
        ///     Gets or sets the font style.
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
        ///     Gets or sets the font size of the text.
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
        ///     Gets or sets the font style of the text.
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
        ///     Gets or sets the font weight of the text.
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
        ///     Gets or sets a value indicating whether represent the text in italic or not.
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
        ///     Gets or sets the labelbgdummy property to hold the original value for serialization.
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
        ///     Gets or sets the labelfgdummy to hold the original value for serialization.
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
        ///     Gets or sets the label horizontal alignment.
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
        ///     Gets or sets the label vertical alignment.
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
        ///     Gets or sets the node gallary name.
        /// </summary>
        [DataMember]
        public string NodeGalleryName
        {
            get
            {
                return this._mNodeGalleryName;
            }

            set
            {
                if (this._mNodeGalleryName != value)
                {
                    this._mNodeGalleryName = value;
                    this.OnPropertyChanged(NodeConstants.NodeGalleryName);
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
        ///     Gets or sets the undo redo state.
        /// </summary>
        public UndoRedoState State { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether text can be represented with strike or not.
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
        ///     Gets or sets the strokedummy property to hold the original value for serialization.
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
        ///     Gets or sets the tool tip.
        /// </summary>
        public string ToolTip
        {
            get
            {
                return this._mToolTip;
            }

            set
            {
                if (this._mToolTip != value)
                {
                    this._mToolTip = value;
                    this.OnPropertyChanged(NodeConstants.ToolTip);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether represent the text with under line or not.
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
        /// Represents whether redo can happen or not.
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
        /// Represents whether undo can happen or not.
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
        ///     Represents the collection of data.
        /// </summary>
        /// <returns>
        ///     The <see cref="object" />.
        /// </returns>
        public object GetData()
        {
            return this._mCollectionData;
        }

        /// <summary>
        /// Represents the log data.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        public void LogData(object data)
        {
            INodeInfo info = this.Info as INodeInfo;
            if (info != null && info.Graph != null)
            {
                info.Graph.HistoryManager.LogData(this, data);
            }
        }

        /// <summary>
        /// Restore the last action that was reverted.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object Redo(object data)
        {
            if (data is NodeState)
            {
                return this.RevertTo(data);
            }

            return data;
        }

        /// <summary>
        /// Revert to the original value.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object RevertTo(object data)
        {
            if (data is NodeState)
            {
                object current = this.GetData();
                NodeState toState = (NodeState)data;

                if (toState.ShapeStyle != this.ShapeStyle)
                {
                    this.ShapeStyle = toState.ShapeStyle;
                }

                if (toState.Fill != this.Fill)
                {
                    this.Fill = toState.Fill;
                }

                if (toState.DashDot != this.DashDot)
                {
                    this.DashDot = toState.DashDot;
                }

                if (toState.Stroke != this.Stroke)
                {
                    this.DashDot = toState.DashDot;
                }

                if (toState.Thickness != this.Thickness)
                {
                    this.Thickness = toState.Thickness;
                }

                if (toState.QuickFill != this.QuickFill)
                {
                    this.QuickFill = toState.QuickFill;
                }

                return current;
            }

            return data;
        }

        /// <summary>
        /// The Undo method reverses the last editing action performed.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object Undo(object data)
        {
            if (data is NodeState)
            {
                return this.RevertTo(data);
            }

            return data;
        }

        /// <summary>
        ///     The on theme style id changed.
        /// </summary>
        internal void OnThemeStyleIdChanged()
        {
            INodeInfo info = this.Info as INodeInfo;
            if (this.Constraints.Contains(NodeConstraints.ThemeStyle) && this is BrainstormingNodeVM && info != null
                && info.Graph.Theme != null)
            {
                if (!(this as BrainstormingNodeVM).ShapeName.Equals("Line"))
                {
                    DiagramItemStyle style = info.Graph.Theme.GetNodeStyle(this.ThemeStyleId);
                    if (style != null)
                    {
                        foreach (LabelVM annotation in (List<IAnnotation>)this.Annotations)
                        {
                            annotation.LabelForeground = style.Foreground;
                            annotation.FontSize = (int)style.FontSize;
                            annotation.Font = style.FontFamily;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Represents the shape style.
        /// </summary>
        /// <param name="style">
        /// The style.
        /// </param>
        protected void ApplyStyle(Style style)
        {
            this.ShapeStyle = style;
        }

        /// <summary>
        /// The decode style.
        /// </summary>
        /// <param name="style">
        /// The style.
        /// </param>
        protected void DecodeStyle(Style style)
        {
            foreach (Setter setter in style.Setters)
            {
                if (setter.Property == System.Windows.Shapes.Shape.StrokeProperty)
                {
                    this.Stroke = setter.Value as Brush;
                }
                else if (setter.Property == System.Windows.Shapes.Shape.StrokeThicknessProperty)
                {
                    this.Thickness = (double)setter.Value;
                }
                else if (setter.Property == System.Windows.Shapes.Shape.StrokeDashArrayProperty)
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

                if (setter.Property == System.Windows.Shapes.Shape.FillProperty && this.Key != null
                                                                                && this.Key.ToString()
                                                                                != "Electrical Shapes")
                {
                    this.Fill = setter.Value as Brush;
                }
            }
        }

        /// <summary>
        ///     The get custom style.
        /// </summary>
        /// <returns>
        ///     The <see cref="Style" />.
        /// </returns>
        protected Style GetCustomStyle()
        {
            Style customStyle = new Style(typeof(Path));
            if (this.Stroke != null)
            {
                customStyle.Setters.Add(new Setter(System.Windows.Shapes.Shape.StrokeProperty, this.Stroke));
            }

            if (!double.IsNaN(this.Thickness) && !double.IsInfinity(this.Thickness))
            {
                customStyle.Setters.Add(
                    new Setter(System.Windows.Shapes.Shape.StrokeThicknessProperty, this.Thickness));
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

                customStyle.Setters.Add(new Setter(System.Windows.Shapes.Shape.StrokeDashArrayProperty, dc));
            }

            if (this.Fill != null)
            {
                customStyle.Setters.Add(new Setter(System.Windows.Shapes.Shape.FillProperty, this.Fill));
                customStyle.Setters.Add(new Setter(System.Windows.Shapes.Shape.StretchProperty, Stretch.Fill));
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
            INodeInfo info = this.Info as INodeInfo;
            if (info != null && info.Graph != null && info.Graph.HistoryManager != null && this.AllowToLogData(name))
            {
                if (info.Graph.HistoryManager.CanLogData(info.Graph.HistoryManager, this._mCollectionData))
                {
                    this.LogData(this._mCollectionData);
                }
            }

            base.OnPropertyChanged(name);
            switch (name)
            {
                case "Info":
                    this.OnThemeStyleIdChanged();
                    break;
                case NodeConstants.Content:
                    this.OnContentChanged();
                    break;
                case NodeConstants.ContentTemplate:
                    this.OnContentTemplateChanged();
                    break;
                case NodeConstants.Constraints:
                    this.OnConstraintsChanged();
                    break;
                case NodeConstants.Fill:
                    this.OnFillChanged();
                    this._mCollectionData.Fill = this.Fill;
                    break;
                case NodeConstants.AllowDrag:
                    this.OnAllowDragChanged();
                    break;
                case NodeConstants.AllowResize:
                    this.OnAllowResizeChanged();
                    break;
                case NodeConstants.AllowRotate:
                    this.OnAllowRotateChanged();
                    break;
                case NodeConstants.AspectRatio:
                    this.OnAspectRatioChanged();
                    break;
                case "QuickFill":
                case "ShapeStyle":
                    this._mCollectionData.QuickFill = this.QuickFill;
                    this._mCollectionData.ShapeStyle = this.ShapeStyle;
                    break;
                case "ThemeStyleId":
                    this.OnThemeStyleIdChanged();
                    break;
                case GroupableConstants.Bold:
                    this.OnBoldChanged();
                    break;
                case GroupableConstants.DashDot:
                    this.OnDashDotChanged();
                    this._mCollectionData.DashDot = this.DashDot;
                    break;
                case GroupableConstants.UnderLine:
                    this.OnUnderLineChanged();
                    break;
                case GroupableConstants.Strike:
                    this.OnStrikeChanged();
                    break;
                case GroupableConstants.Font:
                    this.OnFontChanged();
                    break;
                case GroupableConstants.FontSize:
                    this.OnFontSizeChanged();
                    break;
                case GroupableConstants.FontStyle:
                    this.OnFontStyleChanged();
                    break;
                case GroupableConstants.FontWeight:
                    this.OnFontWeightChanged();
                    break;
                case GroupableConstants.Italic:
                    this.OnItalicChanged();
                    break;
                case GroupableConstants.Label:
                    this.OnLabelChanged();
                    break;
                case GroupableConstants.LabelHAlign:
                    this.OnLabelHAlignChanged();
                    break;
                case GroupableConstants.LabelMargin:
                    this.OnLabelMarginChanged();
                    break;
                case GroupableConstants.LabelVAlign:
                    this.OnLabelVAlignChanged();
                    break;
                case GroupableConstants.Stroke:
                    this.OnStrokeChanged();
                    this._mCollectionData.Stroke = this.Stroke;
                    break;
                case GroupableConstants.Style:
                    this.OnStyleChanged();
                    break;
                case GroupableConstants.Opacity:
                    this.OnOpacityChanged();
                    break;
                case GroupableConstants.Thickness:
                    this.OnThicknessChanged();
                    this._mCollectionData.Thickness = this.Thickness;
                    break;
                case GroupableConstants.LabelForeground:
                    this.OnLabelForegroundChanged();
                    break;
                case GroupableConstants.LabelBackground:
                    this.OnLabelBackground();
                    break;
                case GroupableConstants.HyperLink:
                    this.OnHyperLinkChanged();
                    break;
                case "Decoration":
                    this.OnDecorationChanged();
                    break;
            }
        }

        /// <summary>
        /// The allow to log data.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool AllowToLogData(string name)
        {
            if (name == "QuickFill" || name == "Stroke" || name == "Thickness" || name == "DashDot"
                || name == "ShapeStyle" || name == "Fill")
            {
                return true;
            }

            return false;
        }

        /// <summary>
        ///     The on allow drag changed.
        /// </summary>
        private void OnAllowDragChanged()
        {
            if (this.AllowDrag)
            {
                (this as INode).Constraints |= NodeConstraints.Draggable;
            }
            else
            {
                (this as INode).Constraints &= ~NodeConstraints.Draggable;
            }
        }

        /// <summary>
        ///     The on allow resize changed.
        /// </summary>
        private void OnAllowResizeChanged()
        {
            if (this.AllowResize)
            {
                (this as INode).Constraints |= NodeConstraints.Resizable;
            }
            else
            {
                (this as INode).Constraints &= ~NodeConstraints.Resizable;
            }
        }

        /// <summary>
        ///     The on allow rotate changed.
        /// </summary>
        private void OnAllowRotateChanged()
        {
            if (this.AllowRotate)
            {
                (this as INode).Constraints |= NodeConstraints.Rotatable;
            }
            else
            {
                (this as INode).Constraints &= ~NodeConstraints.Rotatable;
            }
        }

        /// <summary>
        ///     The on aspect ratio changed.
        /// </summary>
        private void OnAspectRatioChanged()
        {
            if (this.AspectRatio)
            {
                (this as INode).Constraints |= NodeConstraints.AspectRatio;
            }
            else
            {
                (this as INode).Constraints &= ~NodeConstraints.AspectRatio;
            }
        }

        /// <summary>
        ///     The on bold changed.
        /// </summary>
        private void OnBoldChanged()
        {
            if (this.Bold)
            {
                this.FontWeight = FontWeights.Bold;
            }
            else
            {
                this.FontWeight = FontWeights.Normal;
            }
        }

        /// <summary>
        ///     The on constraints changed.
        /// </summary>
        private void OnConstraintsChanged()
        {
            if (!(this is BrainstormingNodeVM))
            {
                if (this.Constraints.Contains(NodeConstraints.Draggable))
                {
                    this.AllowDrag = true;
                }
                else
                {
                    this.AllowDrag = false;
                }

                if (this.Constraints.Contains(NodeConstraints.Resizable))
                {
                    this.AllowResize = true;
                }
                else
                {
                    this.AllowResize = false;
                }

                if (this.Constraints.Contains(NodeConstraints.Rotatable))
                {
                    this.AllowRotate = true;
                }
                else
                {
                    this.AllowRotate = false;
                }

                if (this.Constraints.Contains(NodeConstraints.AspectRatio))
                {
                    this.AspectRatio = true;
                }
                else
                {
                    this.AspectRatio = false;
                }
            }
        }

        /// <summary>
        ///     The on content changed.
        /// </summary>
        private void OnContentChanged()
        {
            if (this.Content is string)
            {
                this.ContentDummy = (string)this.Content;
                this.OnFillChanged();
            }
        }

        /// <summary>
        ///     The on content template changed.
        /// </summary>
        private void OnContentTemplateChanged()
        {
            if (!(this is BrainstormingNodeVM))
            {
                if (!(this is OrganizationChartNodeVM))
                {
                    this.ContentTemplate = null;
                }
            }
        }

        /// <summary>
        ///     The on dash dot changed.
        /// </summary>
        private void OnDashDotChanged()
        {
            this.ApplyStyle(this.GetCustomStyle());
        }

        /// <summary>
        ///     The on decoration changed.
        /// </summary>
        private void OnDecorationChanged()
        {
            foreach (LabelVM item in (List<IAnnotation>)this.Annotations)
            {
                item.Decoration = this.Decoration;
            }
        }

        /// <summary>
        ///     The on fill changed.
        /// </summary>
        private void OnFillChanged()
        {
            this.ApplyStyle(this.GetCustomStyle());
            if(this is OrganizationChartNodeVM && this.Content != null)
            {
                (this.Content as CustomContent).Templatecolor = this.Fill;
            }
        }

        /// <summary>
        ///     The on font changed.
        /// </summary>
        private void OnFontChanged()
        {
            // _mAnnotation.Font = Font; 
            foreach (LabelVM item in (List<IAnnotation>)this.Annotations)
            {
                item.Font = this.Font;
            }
        }

        /// <summary>
        ///     The on font size changed.
        /// </summary>
        private void OnFontSizeChanged()
        {
            // _mAnnotation.FontSize = FontSize;
            foreach (LabelVM item in (List<IAnnotation>)this.Annotations)
            {
                item.FontSize = this.FontSize;
            }
        }

        /// <summary>
        ///     The on font style changed.
        /// </summary>
        private void OnFontStyleChanged()
        {
            foreach (LabelVM item in (List<IAnnotation>)this.Annotations)
            {
                item.FontStyle = this.FontStyle;
            }
        }

        /// <summary>
        ///     The on font weight changed.
        /// </summary>
        private void OnFontWeightChanged()
        {
            foreach (LabelVM item in (List<IAnnotation>)this.Annotations)
            {
                item.FontWeight = this.FontWeight;
            }
        }

        /// <summary>
        ///     The on hyper link changed.
        /// </summary>
        private void OnHyperLinkChanged()
        {
            this._mAnnotationHyperLink.HyperLink = this.HyperLink;
        }

        /// <summary>
        ///     The on italic changed.
        /// </summary>
        private void OnItalicChanged()
        {
            if (this.Italic)
            {
                this.FontStyle = FontStyles.Italic;
            }
            else
            {
                this.FontStyle = FontStyles.Normal;
            }
        }

        /// <summary>
        ///     The on label background.
        /// </summary>
        private void OnLabelBackground()
        {
            foreach (LabelVM item in (List<IAnnotation>)this.Annotations)
            {
                item.LabelBackground = this.LabelBackground;
            }
        }

        /// <summary>
        ///     The on label changed.
        /// </summary>
        private void OnLabelChanged()
        {
            this._mAnnotation.Content = this.Label;
        }

        /// <summary>
        ///     The on label foreground changed.
        /// </summary>
        private void OnLabelForegroundChanged()
        {
            foreach (LabelVM item in (List<IAnnotation>)this.Annotations)
            {
                item.LabelForeground = this.LabelForeground;
            }
        }

        /// <summary>
        ///     The on label h align changed.
        /// </summary>
        private void OnLabelHAlignChanged()
        {
            if (!(this is OrganizationChartNodeVM))
            {
                foreach (LabelVM item in (List<IAnnotation>)this.Annotations)
                {
                    item.HorizontalAlignment = this.LabelHAlign;
                    switch (this.LabelHAlign)
                    {
                        case HorizontalAlignment.Left:
                            item.TextHorizontalAlignment = TextAlignment.Left;

                            // item.Alignment = ConnectorAnnotationAlignment.Source;
                            item.Offset = new Point(0, item.Offset.Y);
                            break;
                        case HorizontalAlignment.Center:
                            item.TextHorizontalAlignment = TextAlignment.Center;

                            // item.Alignment = ConnectorAnnotationAlignment.Center;
                            item.Offset = new Point(0.5, item.Offset.Y);
                            break;
                        case HorizontalAlignment.Right:
                            item.TextHorizontalAlignment = TextAlignment.Right;

                            // item.Alignment = ConnectorAnnotationAlignment.Target;
                            item.Offset = new Point(1, item.Offset.Y);
                            break;
                    }
                }
            }
        }

        /// <summary>
        ///     The on label margin changed.
        /// </summary>
        private void OnLabelMarginChanged()
        {
            this._mAnnotation.LabelMargin = this.LabelMargin;
        }

        /// <summary>
        ///     The on label v align changed.
        /// </summary>
        private void OnLabelVAlignChanged()
        {
            if (!(this is OrganizationChartNodeVM))
            {
                foreach (LabelVM item in (List<IAnnotation>)Annotations)
                {
                    item.VerticalAlignment = this.LabelVAlign;
                    switch (this.LabelVAlign)
                    {
                        case VerticalAlignment.Top:
                            item.TextVerticalAlignment = VerticalAlignment.Top;
                            item.Offset = new Point(item.Offset.X, 0);
                            break;
                        case VerticalAlignment.Center:
                            item.TextVerticalAlignment = VerticalAlignment.Center;
                            item.Offset = new Point(item.Offset.X, 0.5);
                            break;
                        case VerticalAlignment.Bottom:
                            item.TextVerticalAlignment = VerticalAlignment.Bottom;
                            item.Offset = new Point(item.Offset.X, 1);
                            break;
                    }
                }
            }
        }

        /// <summary>
        ///     The on opacity changed.
        /// </summary>
        private void OnOpacityChanged()
        {
            this.ApplyStyle(this.GetCustomStyle());
        }

        /// <summary>
        ///     The on strike changed.
        /// </summary>
        private void OnStrikeChanged()
        {
            if (this.Strike)
            {
                if (this.Decoration == null)
                {
                    this.Decoration = new TextDecorationCollection();
                    this.Decoration.Add(TextDecorations.Strikethrough);
                }
                else
                {
                    this.Decoration = new TextDecorationCollection();
                    this.Decoration.Add(TextDecorations.Strikethrough);
                    this.Decoration.Add(TextDecorations.Underline);
                }
            }
            else
            {
                if (this.Decoration.Contains(TextDecorations.Underline[0]))
                {
                    this.Decoration = new TextDecorationCollection();
                    this.Decoration.Add(TextDecorations.Underline);
                }
                else this.Decoration = null;
            }
        }

        /// <summary>
        ///     The on stroke changed.
        /// </summary>
        private void OnStrokeChanged()
        {
            this.ApplyStyle(this.GetCustomStyle());
        }

        /// <summary>
        ///     The on style changed.
        /// </summary>
        private void OnStyleChanged()
        {
            if (this.Style != null) this.DecodeStyle(this.Style);
            if(this is OrganizationChartNodeVM)
            {
                foreach(Setter set in this.Style.Setters)
                {
                    if(set.Property.Name == "Fill")
                    {
                        if(set.Value is LinearGradientBrush)
                        {
                            (this.Content as CustomContent).Templatecolor = set.Value as LinearGradientBrush; 
                        }
                        else
                        {
                            (this.Content as CustomContent).Templatecolor = set.Value.ToString();
                        }                        
                    }
                }
            }
        }

        /// <summary>
        ///     The on thickness changed.
        /// </summary>
        private void OnThicknessChanged()
        {
            this.ApplyStyle(this.GetCustomStyle());
        }

        /// <summary>
        ///     The on under line changed.
        /// </summary>
        private void OnUnderLineChanged()
        {
            if (this.UnderLine)
            {
                if (this.Decoration == null)
                {
                    this.Decoration = new TextDecorationCollection();
                    this.Decoration.Add(TextDecorations.Underline);
                }
                else
                {
                    this.Decoration = new TextDecorationCollection();
                    this.Decoration.Add(TextDecorations.Strikethrough);
                    this.Decoration.Add(TextDecorations.Underline);
                }
            }
            else
            {
                if (this.Decoration.Contains(TextDecorations.Strikethrough[0]))
                {
                    this.Decoration = new TextDecorationCollection();
                    this.Decoration.Add(TextDecorations.Strikethrough);
                }
                else this.Decoration = null;
            }
        }
    }
}