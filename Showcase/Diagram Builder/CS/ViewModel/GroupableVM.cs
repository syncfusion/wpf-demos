#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xml;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Serializer;
using System.Runtime.Serialization;
using DiagramBuilder.Utility;
using System.ComponentModel;
using System.Collections;
using Syncfusion.UI.Xaml.Diagram.Controller;
using Path = System.Windows.Shapes.Path;

namespace DiagramBuilder.ViewModel
{
    public abstract class GroupableVM : GroupableViewModel, IGroupableVM
    {
        LabelVM _mAnnotation = new LabelVM() { UnitWidth = 100, UnitHeight = 100, TextHorizontalAlignment = TextAlignment.Center, TextVerticalAlignment = VerticalAlignment.Center };
        LabelVM _mAnnotationHyperLink = new LabelVM("hyperlink");

        public GroupableVM()
        {
            this.Annotations = new List<IAnnotation>() { _mAnnotation, _mAnnotationHyperLink};
            _mAnnotation.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == "Content")
                    {
                        this.Label = (string)_mAnnotation.Content;
                        this.HyperLink = (string)_mAnnotationHyperLink.HyperLink;
                      
                    }
                };
        }

        #region Shape

        #region Prop
        private Brush _mQuickFill = null;
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
                    OnPropertyChanged(GroupableConstants.QuickFill);
                }
            }
        }

        Brush _mStroke = new SolidColorBrush(Colors.Red);
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
                    OnPropertyChanged(GroupableConstants.Stroke);
                }
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

        double _mThickness = 1d;
        [DataMember]
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
                    OnPropertyChanged(GroupableConstants.Thickness);
                }
            }
        }

        string _mDashDot = "1, 0";
        [DataMember]
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
                    OnPropertyChanged(GroupableConstants.DashDot);
                }
            }
        }

        Style _mStyle = null;
        public Style Style
        {
            get
            {
                return _mStyle;
            }
            set
            {
                if (_mStyle != value)
                {
                    _mStyle = value;
                    OnPropertyChanged(GroupableConstants.Style);
                }
            }
        }

        double _mOpacity = 1d;
        [DataMember]
        public double Opacity
        {
            get
            {
                return _mOpacity;
            }
            set
            {
                if (_mOpacity != value)
                {
                    _mOpacity = value;
                    OnPropertyChanged(GroupableConstants.Opacity);
                }
            }
        }
        #endregion

        private void OnThicknessChanged()
        {
            ApplyStyle(GetCustomStyle());
        }

        private void OnStyleChanged()
        {
           if (Style != null)
            DecodeStyle(Style);
        }

        private void OnStrokeChanged()
        {
            ApplyStyle(GetCustomStyle());
        }
        
        private void OnDashDotChanged()
        {
            ApplyStyle(GetCustomStyle());
        }

        private void OnOpacityChanged()
        {
            ApplyStyle(GetCustomStyle());
        }

        protected virtual void DecodeStyle(Style style)
        {
            foreach (Setter setter in style.Setters)
            {
                if (setter.Property == Path.StrokeProperty)
                {
                    Stroke = setter.Value as Brush;
                }
                else if (setter.Property == Path.StrokeThicknessProperty)
                {
                    Thickness = (double)setter.Value;
                }
                else if (setter.Property == Path.StrokeDashArrayProperty)
                {
                    string data = "";
                    foreach (double item in setter.Value as DoubleCollection)
                    {
                        data += item + ", ";
                    }
                    if (!String.IsNullOrEmpty(data))
                    {
                        data = data.Substring(0, data.Length - 2);
                        DashDot = data;
                    }
                }
                else if (setter.Property == Path.OpacityProperty)
                {
                    Opacity = (double)setter.Value;
                }
            }
        }

        protected virtual Style GetCustomStyle()
        {
            Style customStyle = new Style(typeof(Path));
            if (Stroke != null)
            {
                customStyle.Setters.Add(new Setter(Path.StrokeProperty, Stroke));
            }
            if (!double.IsNaN(Thickness) && !double.IsInfinity(Thickness))
            {
                customStyle.Setters.Add(new Setter(Path.StrokeThicknessProperty, Thickness));
            }
            customStyle.Setters.Add(new Setter(Path.OpacityProperty, Opacity));
            if (DashDot != null)
            {
                DoubleCollection dc=new DoubleCollection();
                var split = DashDot.Split(',');
                foreach (string s in split)
                {
                    dc.Add(Convert.ToDouble(s));
                }
                customStyle.Setters.Add(new Setter(Path.StrokeDashArrayProperty, dc));
            }
            return customStyle;
        }

        protected abstract void ApplyStyle(Style style);

        #endregion

        #region Label
        string _mLabel = string.Empty;
        [DataMember]
        public string Label
        {
            get
            {
                return _mLabel;
            }
            set
            {
                if (_mLabel != value)
                {
                    _mLabel = value;
                    OnPropertyChanged(GroupableConstants.Label);
                }
            }
        }

        FontFamily _mFont = DiagramBuilderVM.Fonts[0];
        public FontFamily Font
        {
            get
            {
                return _mFont;
            }
            set
            {
                if (_mFont != value)
                {
                    _mFont = value;
                    OnPropertyChanged(GroupableConstants.Font);
                }
            }
        }

        public string FontDummy
        {
            get
            {
                if (Font != null)
                {
                    return Font.Source;
                }
                return null;
            }
            set
            {
                Font = DiagramBuilderVM.Fonts.Where(ft => ft.Source == value).FirstOrDefault();
            }
        }

        int _mFontSize = 12;
        [DataMember]
        public int FontSize
        {
            get
            {
                return _mFontSize;
            }
            set
            {
                if (_mFontSize != value)
                {
                    _mFontSize = value;
                    OnPropertyChanged(GroupableConstants.FontSize);
                }
            }
        }

        FontWeight _mFontWeight = FontWeights.Normal;
        [DataMember]
        public FontWeight FontWeight
        {
            get
            {
                return _mFontWeight;
            }
            set
            {
                //if (_mFontWeight != value)
                {
                    _mFontWeight = value;
                    //_mAnnotation.FontWeight = value;
                    OnPropertyChanged(GroupableConstants.FontWeight);
                }
            }
        }

        private TextDecorationCollection _decorations;
        [DataMember]
        public TextDecorationCollection Decoration
        {
            get { return _decorations; }
            set
            {
                _decorations = value;
                //_mAnnotation.Decoration = value;
                OnPropertyChanged(GroupableConstants.Decoration);
            }
        }
        private FontStyle _mFontStyle = FontStyles.Normal;
        [DataMember]
        public FontStyle FontStyle
        {
            get
            {
                return _mFontStyle;
            }
            set
            {
                if (_mFontStyle != value)
                {
                    _mFontStyle = value;
                    //_mAnnotation.FontStyle = value;
                    OnPropertyChanged(GroupableConstants.FontStyle);
                }
            }
        }

        bool _mBold = false;
        [DataMember]
        public bool Bold
        {
            get
            {
                return _mBold;
            }
            set
            {
                if (_mBold != value)
                {
                    _mBold = value;
                    OnPropertyChanged(GroupableConstants.Bold);
                }
            }
        }

        bool _line=false;
        [DataMember]
        public bool UnderLine
        {
            get { return _line; }
            set
            {
                if (_line != value)
                {
                    _line = value;
                    OnPropertyChanged(GroupableConstants.UnderLine);
                }
            }
        }

        bool _mStrike = false;
        [DataMember]
        public bool Strike
        {
            get { return _mStrike; }
            set
            {
                if (_mStrike != value)
                {
                    _mStrike = value;
                    OnPropertyChanged(GroupableConstants.Strike);
                }
            }
        }

        bool _mItalic = false;
        [DataMember]
        public bool Italic
        {
            get
            {
                return _mItalic;
            }
            set
            {
                if (_mItalic != value)
                {
                    _mItalic = value;
                    OnPropertyChanged(GroupableConstants.Italic);
                }
            }
        }

        TextAlignment _mTextAlign = TextAlignment.Center;
        [DataMember]
        public TextAlignment TextAlignment
        {
            get
            {
                return _mTextAlign;
            }
            set
            {
                if (_mTextAlign != value)
                {
                    _mTextAlign = value;
                    OnPropertyChanged(GroupableConstants.TextAlignment);
                }
            }
        }

        HorizontalAlignment _mLabelHAlign = HorizontalAlignment.Center;
        [DataMember]
        public HorizontalAlignment LabelHAlign
        {
            get
            {
                return _mLabelHAlign;
            }
            set
            {
                if (_mLabelHAlign != value)
                {
                    _mLabelHAlign = value;
                    OnPropertyChanged(GroupableConstants.LabelHAlign);
                }
            }
        }

        VerticalAlignment _mLabelVAlign = VerticalAlignment.Center;
        [DataMember]
        public VerticalAlignment LabelVAlign
        {
            get
            {
                return _mLabelVAlign;
            }
            set
            {
                if (_mLabelVAlign != value)
                {
                    _mLabelVAlign = value;
                    OnPropertyChanged(GroupableConstants.LabelVAlign);
                }
            }
        }

        Thickness _mLabelMargin = new Thickness(5);
        [DataMember]
        public Thickness LabelMargin
        {
            get
            {
                return _mLabelMargin;
            }
            set
            {
                if (_mLabelMargin != value)
                {
                    _mLabelMargin = value;
                    _mAnnotation.LabelMargin = value;
                    OnPropertyChanged(GroupableConstants.LabelMargin);
                }
            }
        }
        
        private Brush _mLabelBackground = new SolidColorBrush(Colors.Transparent);
        public Brush LabelBackground
        {
            get { return _mLabelBackground; }
            set
            {
                if (_mLabelBackground != value)
                {
                    _mLabelBackground = value;
                    OnPropertyChanged(GroupableConstants.LabelBackground);
                }
            }
        }

        private Brush _mLabelForeground = new SolidColorBrush(Colors.Black);
        public Brush LabelForeground
        {
            get { return _mLabelForeground; }
            set
            {
                if (_mLabelForeground != value)
                {
                    _mLabelForeground = value;
                    OnPropertyChanged(GroupableConstants.LabelForeground);
                }
            }
        }
        
        [DataMember]
        public string LabelBgDummy
        {
            get
            {
                if (LabelBackground != null && LabelBackground is SolidColorBrush)
                    return (LabelBackground as SolidColorBrush).Color.ToString();
                else
                    return null;
            }
            set
            {
                LabelBackground = new SolidColorBrush(value.ToColor());
            }
        }

        [DataMember]
        public string LabelFgDummy
        {
            get
            {
                if (LabelForeground != null && LabelForeground is SolidColorBrush)
                    return (LabelForeground as SolidColorBrush).Color.ToString();
                else
                    return null;
            }
            set
            {
                LabelForeground = new SolidColorBrush(value.ToColor());
            }
        }

        #endregion
        
        public IEnumerable<IAnnotation> AnnotationsE
        {
            get { return this.Annotations as IEnumerable<IAnnotation>; }
        }

        string _mName = string.Empty;
        [DataMember]
        public string Name
        {
            get
            {
                return _mName;
            }
            set
            {
                if (_mName != value)
                {
                    _mName = value;
                    OnPropertyChanged(GroupableConstants.Name);
                }
            }
        }
        
        #region State

        private Visibility _mVisibility = Visibility.Visible;
        [DataMember]
        public Visibility Visibility
        {
            get
            {
                return _mVisibility;
            }
            set
            {
                if (_mVisibility != value)
                {
                    _mVisibility = value;
                    OnPropertyChanged(GroupableConstants.Visibility);
                }
            }
        }
        
        #endregion

        string _mHyperLink = "http://";
        [DataMember]
        public string HyperLink
        {
            get
            {
                return _mHyperLink;
            }
            set
            {
                if (_mHyperLink != value)
                {
                    _mHyperLink = value;
                    OnPropertyChanged(GroupableConstants.HyperLink);
                }
            }
        }

        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);
            switch (name)
            {
                case GroupableConstants.RotateAngle:
                    OnAngleChanged();
                    break;
                case GroupableConstants.Bold:
                    OnBoldChanged();
                    break;
                case GroupableConstants.DashDot:
                    OnDashDotChanged();
                    break;
                case GroupableConstants.UnderLine:
                    OnUnderLineChanged();
                    break;
                case GroupableConstants.Strike:
                    OnStrikeChanged();
                    break;
                case GroupableConstants.Font:
                    OnFontChanged();
                    break;
                case GroupableConstants.FontSize:
                    OnFontSizeChanged();
                    break;
                case GroupableConstants.FontStyle:
                    OnFontStyleChanged();
                    break;
                case GroupableConstants.FontWeight:
                    OnFontWeightChanged();
                    break;
                case GroupableConstants.UnitHeight:
                    OnHeightChanged();
                    break;
                case GroupableConstants.Italic:
                    OnItalicChanged();
                    break;
                case GroupableConstants.Label:
                    OnLabelChanged();
                    break;
                case GroupableConstants.TextAlignment:
                    OnTextAlignmentChanged();
                    break;
                case GroupableConstants.LabelHAlign:
                    OnLabelHAlignChanged();
                    break;
                case GroupableConstants.LabelMargin:
                    OnLabelMarginChanged();
                    break;
                case GroupableConstants.LabelVAlign:
                    OnLabelVAlignChanged();
                    break;
                case GroupableConstants.Name:
                    OnNameChanged();
                    break;
                case GroupableConstants.Stroke:
                    OnStrokeChanged();
                    break;
                case GroupableConstants.Style:
                    OnStyleChanged();
                    break;
                case GroupableConstants.Opacity:
                    OnOpacityChanged();
                    break;
                case GroupableConstants.Thickness:
                    OnThicknessChanged();
                    break;
                case GroupableConstants.Visibility:
                    OnVisibilityChanged();
                    break;
                case GroupableConstants.UnitWidth:
                    OnWidthChanged();
                    break;
                case GroupableConstants.OffsetX:
                    OnXChanged();
                    break;
                case GroupableConstants.OffsetY:
                    OnYChanged();
                    break;
                case GroupableConstants.LabelForeground:
                    OnLabelForegroundChanged();
                    break;
                case GroupableConstants.LabelBackground:
                    OnLabelBackground();
                    break;
                case "Annotations":
                    //if (AnnotationsE != null &&
                    //    AnnotationsE.FirstOrDefault() == null ||
                    //    (AnnotationsE.FirstOrDefault() != null &&
                    //    AnnotationsE.FirstOrDefault() != _mAnnotation))
                    //{
                    //    this.Annotations = new List<IAnnotation>() { _mAnnotation }; 
                    //}
                    break;
                case GroupableConstants.HyperLink:
                    OnHyperLinkChanged();
                    break;
                case "Decoration":
                    OnDecorationChanged();
                    break;
            }
        }

        private void OnLabelBackground()
        {
            //_mAnnotation.LabelBackground = LabelBackground;
            foreach (LabelVM item in (this.Annotations as List<IAnnotation>))
            {
                item.LabelBackground = LabelBackground;
            }
        }

        private void OnLabelForegroundChanged()
        {
            //_mAnnotation.LabelForeground = LabelForeground;
            foreach (LabelVM item in (this.Annotations as List<IAnnotation>))
            {
                item.LabelForeground = LabelForeground;
            }
        }

        private void OnTextAlignmentChanged()
        {
        }

        private void OnVisibilityChanged()
        {
        }

        private void OnNameChanged()
        {
            //throw new NotImplementedException();
        }

        #region Label
        private void OnLabelVAlignChanged()
        {
            foreach (LabelVM item in (this.Annotations as List<IAnnotation>))
            {
                item.VerticalAlignment = LabelVAlign;
                switch (LabelVAlign)
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

        private void OnLabelMarginChanged()
        {
            _mAnnotation.LabelMargin = LabelMargin;
        }

        private void OnLabelHAlignChanged()
        {
            foreach (LabelVM item in (this.Annotations as List<IAnnotation>))
            {
                item.HorizontalAlignment = LabelHAlign;
                switch (LabelHAlign)
                {
                    case HorizontalAlignment.Left:
                        item.TextHorizontalAlignment = TextAlignment.Left;
                        //item.Alignment = ConnectorAnnotationAlignment.Source;
                        item.Offset = new Point(0, item.Offset.Y);
                        break;
                    case HorizontalAlignment.Center:
                        item.TextHorizontalAlignment = TextAlignment.Center;
                        //item.Alignment = ConnectorAnnotationAlignment.Center;
                        item.Offset = new Point(0.5, item.Offset.Y);
                        break;
                    case HorizontalAlignment.Right:
                        item.TextHorizontalAlignment = TextAlignment.Right;
                        //item.Alignment = ConnectorAnnotationAlignment.Target;
                        item.Offset = new Point(1, item.Offset.Y);
                        break;
                }
            }
        }

        private void OnLabelChanged()
        {
            _mAnnotation.Content = Label;            
        }

        private void OnItalicChanged()
        {
            if (Italic)
            {
                FontStyle = FontStyles.Italic;
            }
            else
            {
                FontStyle = FontStyles.Normal;
            }
        }

        private void OnFontStyleChanged()
        {
            foreach (LabelVM item in (this.Annotations as List<IAnnotation>))
            {
                item.FontStyle = FontStyle;
            }
        }

        private void OnBoldChanged()
        {
            if (Bold)
            {
                FontWeight = FontWeights.Bold;
            }
            else
            {
                FontWeight = FontWeights.Normal;
            }
        }

        private void OnUnderLineChanged()
        {
            if (UnderLine)
            {
                if (Decoration == null)
                {
                    Decoration = new TextDecorationCollection();
                    Decoration.Add(TextDecorations.Underline);
                }
                else
                {
                    Decoration = new TextDecorationCollection();
                    Decoration.Add(TextDecorations.Strikethrough);
                    Decoration.Add(TextDecorations.Underline);
                }
            }
            else
            {
                if (Decoration.Contains(TextDecorations.Strikethrough[0]))
                {
                    Decoration = new TextDecorationCollection();
                    Decoration.Add(TextDecorations.Strikethrough);
                }
                else
                    Decoration = null;
            }
        }

        private void OnStrikeChanged()
        {
            if (Strike)
            {
                if (Decoration == null)
                {
                    Decoration = new TextDecorationCollection();
                    Decoration.Add(TextDecorations.Strikethrough);
                }
                else
                {
                    Decoration = new TextDecorationCollection();
                    Decoration.Add(TextDecorations.Strikethrough);
                    Decoration.Add(TextDecorations.Underline);
                }
            }
            else
            {
                if (Decoration.Contains(TextDecorations.Underline[0]))
                {
                    Decoration = new TextDecorationCollection();
                    Decoration.Add(TextDecorations.Underline);
                }
                else
                    Decoration = null;
            }
        }

        private void OnFontWeightChanged()
        {
            foreach (LabelVM item in (this.Annotations as List<IAnnotation>))
            {
                item.FontWeight = FontWeight;
            }
        }

        private void OnFontSizeChanged()
        {
            //_mAnnotation.FontSize = FontSize;
            foreach (LabelVM item in (this.Annotations as List<IAnnotation>))
            {
                item.FontSize = FontSize;
            }
        }

        private void OnFontChanged()
        {
            //_mAnnotation.Font = Font; 
            foreach (LabelVM item in (this.Annotations as List<IAnnotation>))
            {
                item.Font = Font;
            }
        }
        #endregion

        private void OnYChanged()
        {
        }

        private void OnXChanged()
        {
        }

        private void OnWidthChanged()
        {
        }

        private void OnHeightChanged()
        {
        }
        
        private void OnAngleChanged()
        {
        }

        private void OnHyperLinkChanged()
        {
            _mAnnotationHyperLink.HyperLink = HyperLink;
        }

        private void OnDecorationChanged()
        {
            foreach (LabelVM item in (this.Annotations as List<IAnnotation>))
            {
                item.Decoration = Decoration;
            }
        }
     
    }

    internal static class GroupableConstants
    {
        public const string QuickFill = "QuickFill";
        public const string AnnotationConstraints = "AnnotationConstraints";
        public const string OffsetX = "OffsetX";
        public const string OffsetY = "OffsetY";
        public const string RotateAngle = "RotateAngle";
        public const string UnitWidth = "UnitWidth";
        public const string UnitHeight = "UnitHeight";
        public const string Stroke = "Stroke";
        public const string Thickness = "Thickness";
        public const string DashDot = "DashDot";
        public const string DashDots = "DashDots";
        public const string Opacity = "Opacity";
        public const string Style = "Style";
        public const string Label = "Label";
        public const string Fonts = "Fonts";
        public const string Font = "Font";
        public const string FontSize = "FontSize";
        public const string FontWeight = "FontWeight";
        public const string FontStyle = "FontStyle";
        public const string Bold = "Bold";
        public const string Italic = "Italic";
        public const string UnderLine = "UnderLine";
        public const string Strike = "Strike"; 
        public const string TextLeft = "TextLeft";
        public const string TextCenter = "TextCenter";
        public const string TextRight = "TextRight";
        public const string TextAlignment = "TextAlignment";
        public const string Decoration = "Decoration";
        public const string TopLeft = "TopLeft";
        public const string Top = "Top";
        public const string TopRight = "TopRight";
        public const string RotateText = "RotateText";
        public const string Left = "Left";
        public const string Center = "Center";
        public const string Right = "Right";

        public const string BottomLeft = "BottomLeft";
        public const string Bottom = "Bottom";
        public const string BottomRight = "BottomRight";
        public const string Middle = "Middle";

        public const string LabelHAlign = "LabelHAlign";
        public const string LabelVAlign = "LabelVAlign";
        public const string LabelMargin = "LabelMargin";
        public const string Name = "Name";
        public const string Visibility = "Visibility";
        public const string LabelForeground = "LabelForeground";
        public const string LabelBackground = "LabelBackground";
        public const string HyperLink = "HyperLink";
    }

    public interface IGroupableVM : INotifyPropertyChanged
    {
        Brush Stroke { get; set; }
        double Thickness { get; set; }
        string DashDot { get; set; }
        Style Style { get; set; }
        double Opacity { get; set; }

        string Label { get; set; }
        FontFamily Font { get; set; }
        int FontSize { get; set; }
        FontWeight FontWeight { get; set; }
        FontStyle FontStyle { get; set; }
        bool Bold { get; set; }
        bool Italic { get; set; }
        bool UnderLine { get; set; }
        bool Strike { get; set; } 
        TextAlignment TextAlignment { get; set; }
        HorizontalAlignment LabelHAlign { get; set; }
        VerticalAlignment LabelVAlign { get; set; }
        Thickness LabelMargin { get; set; }
        Brush LabelForeground { get; set; }
        Brush LabelBackground { get; set; }

        string Name { get; set; }
        Visibility Visibility { get; set; }
        string HyperLink { get; set; }
        Brush QuickFill { get; set; }
    }

    public class LabelVM : AnnotationEditorViewModel,IUndoRedo
    {
        private AnnotationState _mCollectionData;
        FontFamily _mFont = DiagramBuilderVM.Fonts[0];
        FontWeight _mFontWeight = FontWeights.Normal;
        private FontStyle _mFontStyle = FontStyles.Normal;
        private TextAlignment _textAlignment;

        public LabelVM()
        {
            //"TextDecorations=\"{Binding Path=Decoration}\"" +
            const string vTemplate = "<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">" +
                                     "<Border Padding=\"0\" BorderThickness =\"0\">" +
                                     "<TextBlock TextAlignment=\"{Binding Path=TextHorizontalAlignment}\"" +
                                      " VerticalAlignment=\"{Binding Path=TextVerticalAlignment}\"" +
                                                " FontFamily=\"{Binding Path=Font}\"" +
                                                " FontWeight=\"{Binding Path=FontWeight}\"" +
                                                " FontStyle=\"{Binding Path=FontStyle}\"" +
                                                " FontSize=\"{Binding Path=FontSize}\"" +
                                                " TextWrapping=\"{Binding Path=WrapText}\"" +
                                                " Margin=\"{Binding Path=LabelMargin}\"" +
                                                " Foreground=\"{Binding Path=LabelForeground}\"" +
                                               " TextDecorations=\"{Binding Path=Decoration}\"" +
                                                " Text=\"{Binding Path=Content, Mode=TwoWay}\"/>" +
                                     "</Border>" +
                                     "</DataTemplate>";

            const string eTemplate = "<DataTemplate" +
                                     " xmlns:util=\"clr-namespace:Syncfusion.UI.Xaml.Diagram.Utility;assembly=Syncfusion.SfDiagram.Wpf\"" +
                                     " xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">" +
                                      "<TextBox util:FocusUtility.FocusOnLoad=\"True\" " +
                                      "TextAlignment =\"{Binding Path=TextHorizontalAlignment}\"" +
                                      " FontFamily=\"{Binding Path=Font}\"" +
                                      " TextWrapping=\"{Binding Path=WrapText}\"" +
                                                " FontWeight=\"{Binding Path=FontWeight}\"" +
                                                " FontStyle=\"{Binding Path=FontStyle}\"" +
                                                " FontSize=\"{Binding Path=FontSize}\"" +
                                                " Margin=\"{Binding Path=LabelMargin}\"" +
                                                " AcceptsReturn=\"True\""+
                                                " TextDecorations=\"{Binding Path=Decoration}\"" +
                                                
                                                " Background=\"{Binding Path=LabelBackground}\"" +
                                                " Text=\"{Binding Path=Content, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}\"/>" +
                                      "</DataTemplate>";
            StringReader srReader = new StringReader(vTemplate);
            StringReader srreader1 = new StringReader(eTemplate);
            XmlReader ms = XmlReader.Create(srReader);
            XmlReader ms1 = XmlReader.Create(srreader1);
            ViewTemplate = XamlReader.Load(ms) as DataTemplate;
            EditTemplate = XamlReader.Load(ms1) as DataTemplate;
            // this.WrapText = TextWrapping.Wrap;
            _mCollectionData=new AnnotationState(Font,FontWeight,FontStyle,TextAlignment,FontSize,LabelBackground,LabelForeground, RotateAngle, Decoration);
        }
        public LabelVM(string hyperlink)
        {
            //const string vTemplate = "<DataTemplate" +
            //                        " xmlns:viewModel=\"clr-namespace:DiagramBuilder.ViewModel\"" +
            //                        " xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">" +
            //                        "<Border Padding=\"0\" BorderThickness=\"0\" Background=\"{Binding Path=LabelBackground}\">" +
            //                        "<viewModel:CustomHyperlinkButton" +
            //                                   " FontFamily=\"{Binding Path=Font}\"" +
            //                                   " FontWeight=\"{Binding Path=FontWeight}\"" +
            //                                   " FontStyle=\"{Binding Path=FontStyle}\"" +
            //                                   " FontSize=\"{Binding Path=FontSize}\"" +
            //                                   " Margin=\"{Binding Path=LabelMargin}\"" +
            //                                   " Foreground=\"{Binding Path=LabelForeground}\"" +
            //                                   " Content=\"{Binding Path=HyperLink, Mode=TwoWay}\"/>" +
            //                        "</Border>" +
            //                        "</DataTemplate>";

            //const string eTemplate = "<DataTemplate" +
            //                         " xmlns:util=\" clr-namespace:Syncfusion.UI.Xaml.Diagram.Utility;assembly=Syncfusion.SfDiagram.Wpf\"" +
            //                         " xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">" +
            //                          "<TextBox util:FocusUtility.FocusOnLoad=\"True\" " +
            //                                    " FontFamily=\"{Binding Path=Font}\"" +
            //                                    " FontWeight=\"{Binding Path=FontWeight}\"" +
            //                                    " FontStyle=\"{Binding Path=FontStyle}\"" +
            //                                    " TextAlignment=\"{Binding Path=TextAlignment}\" AcceptsReturn=\"True\"" +
            //                                    " FontSize=\"{Binding Path=FontSize}\"" +
            //                                    " Margin=\"{Binding Path=LabelMargin}\"" +
            //                                    " Foreground=\"{Binding Path=LabelForeground}\"" +
            //                                    " Background=\"{Binding Path=LabelBackground}\"" +
            //                                    " Text=\"{Binding Path=Content, Mode=TwoWay}\"/>" +
            //                          "</DataTemplate>";


            //StringReader srReader = new StringReader(vTemplate);
            //StringReader srreader1 = new StringReader(eTemplate);
            //XmlReader ms = XmlReader.Create(srReader);
            //XmlReader ms1 = XmlReader.Create(srreader1);
            //ViewTemplate = XamlReader.Load(ms) as DataTemplate;
            //EditTemplate = XamlReader.Load(ms1) as DataTemplate;
            //HorizontalAlignment = HorizontalAlignment.Right;
            //VerticalAlignment = VerticalAlignment.Bottom;
        }
        
        public FontFamily Font
        {
            get
            {
                return _mFont;
            }
            set
            {
                //if (_mFontWeight != value)
                {
                    _mFont = value;
                    OnPropertyChanged(GroupableConstants.Font);
                }
            }
        }

        public FontWeight FontWeight
        {
            get
            {
                return _mFontWeight;
            }
            set
            {
                //if (_mFontWeight != value)
                {
                    _mFontWeight = value;
                    OnPropertyChanged(GroupableConstants.FontWeight);
                }
            }
        }

        private TextDecorationCollection _decoration;
        public TextDecorationCollection Decoration
        {
            get
            {
                return _decoration;
            }
            set
            {
                if (_decoration != value)
                {
                    _decoration = value;
                    OnPropertyChanged(GroupableConstants.Decoration);
                }
            }
        }

        public FontStyle FontStyle
        {
            get
            {
                return _mFontStyle;
            }
            set
            {
                if (_mFontStyle != value)
                {
                    _mFontStyle = value;
                    OnPropertyChanged(GroupableConstants.FontStyle);
                }
            }
        }

        int _mFontSize = 12;
        public int FontSize
        {
            get
            {
                return _mFontSize;
            }
            set
            {
                if (_mFontSize != value)
                {
                    _mFontSize = value;
                    OnPropertyChanged(GroupableConstants.FontSize);
                }
            }
        }

        public TextAlignment TextAlignment
        {
            get { return _textAlignment; }
            set
            {
                if (_textAlignment != value)
                {
                    _textAlignment = value;
                    OnPropertyChanged("TextAlignment");
                }
            }
        }

        Thickness _mLabelMargin = new Thickness(0);
        public Thickness LabelMargin
        {
            get
            {
                return _mLabelMargin;
            }
            set
            {
                if (_mLabelMargin != value)
                {
                    _mLabelMargin = value;
                    OnPropertyChanged(GroupableConstants.LabelMargin);
                }
            }
        }


        private Brush _mLabelBackground = new SolidColorBrush(Colors.White);
        public Brush LabelBackground
        {
            get { return _mLabelBackground; }
            set
            {
                if (_mLabelBackground != value)
                {
                    _mLabelBackground = value;
                    OnPropertyChanged(GroupableConstants.LabelBackground);
                }
            }
        }

        private Brush _mLabelForeground = new SolidColorBrush(Colors.Black);
        public Brush LabelForeground
        {
            get { return _mLabelForeground; }
            set
            {
                if (_mLabelForeground != value)
                {
                    _mLabelForeground = value;
                    OnPropertyChanged(GroupableConstants.LabelForeground);
                }
            }
        }

        private string _mHyperLink = string.Empty;
        public string HyperLink
        {
            get
            {
                return _mHyperLink;
            }
            set
            {
                if (_mHyperLink != value)
                {
                    _mHyperLink = value;
                    OnPropertyChanged(GroupableConstants.HyperLink);
                }
            }
        }
        #region Undo/Redo
        public void LogData(object data)
        {
            DiagramVM info = (App.Current.MainWindow.DataContext as DiagramBuilderVM).SelectedDiagram as DiagramVM;
            if (info != null)
            {
                info.HistoryManager.LogData(this, data);
            }
        }
        public object Undo(object data)
        {
            if (data is AnnotationState)
            {
                return RevertTo(data);
            }
            else
                return data;
        }

        public object Redo(object data)
        {
            if (data is AnnotationState)
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
            if (data is AnnotationState)
            {
                var current = GetData();
                AnnotationState toState = (AnnotationState)data;

                if (toState.Font != this.Font)
                {
                    this.Font = toState.Font;
                }
                if (toState.TextAlignment != this.TextAlignment)
                {
                    this.TextAlignment = toState.TextAlignment;
                }
                if (toState.FontSize != this.FontSize)
                {
                    this.FontSize = toState.FontSize;
                }
                if (toState.FontStyle != this.FontStyle)
                {
                    this.FontStyle = toState.FontStyle;
                }
                if (toState.FontWeight != this.FontWeight)
                {
                    this.FontWeight = toState.FontWeight;
                }
                if (toState.LabelForeground != this.LabelForeground)
                {
                    this.LabelForeground = toState.LabelForeground;
                }
                if (toState.LabelBackground != this.LabelBackground)
                {
                    this.LabelBackground = toState.LabelBackground;
                }
                if (toState.RotateAngle != this.RotateAngle)
                {
                    this.RotateAngle = toState.RotateAngle;
                }

                if (toState.Decoration != this.Decoration)
                {
                    this.Decoration = toState.Decoration;
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
            base.OnPropertyChanged(name);
            DiagramVM info = (App.Current.MainWindow.DataContext as DiagramBuilderVM).SelectedDiagram as DiagramVM;
            if (info != null && info.HistoryManager != null && AllowToLogData(name))
            {
                if (info.HistoryManager.CanLogData(info.HistoryManager, _mCollectionData))
                {
                    LogData(_mCollectionData);
                }
            }

            switch (name)
            {
                case GroupableConstants.FontSize:
                case GroupableConstants.Font:
                case GroupableConstants.FontStyle:
                case GroupableConstants.FontWeight:
                case GroupableConstants.TextAlignment:
                case GroupableConstants.LabelBackground:
                case GroupableConstants.LabelForeground:
                case GroupableConstants.Decoration:
                case "RotateAngle":
                    _mCollectionData.LabelForeground = LabelForeground;
                    _mCollectionData.Font = Font;
                    _mCollectionData.FontSize = FontSize;
                    _mCollectionData.FontStyle = FontStyle;
                    _mCollectionData.FontWeight = FontWeight;
                    _mCollectionData.LabelBackground = LabelBackground;
                    _mCollectionData.TextAlignment = TextAlignment;
                    _mCollectionData.RotateAngle = RotateAngle;
                    _mCollectionData.Decoration = Decoration;
                    break;
            }
        }

        private bool AllowToLogData(string name)
        {
            if (name == "FontSize" || name == "Font" || name == "FontStyle" || name == "FontWeight" ||
                name == "TextAlignment" || name == "LabelBackground" || name == "LabelForeground" || name== "RotateAngle" || name== "Decoration")
            {
                return true;
            }

            return false;
        }
    }
    public struct AnnotationState 
    {
        FontFamily _mFont ;
        FontWeight _mFontWeight;
        private FontStyle _mFontStyle;
        private TextAlignment _textAlignment;
        private int _mFontSize;
        private double _RotateAngle;

        public AnnotationState(FontFamily mfont, FontWeight mFontWeight, FontStyle mFontStyle, TextAlignment mTextAlignment,int fsize,Brush mLabelBackground,Brush mLabelForeground,double rotateAngle, TextDecorationCollection decoration)
        {
            _mFont = mfont;
            _mFontWeight = mFontWeight;
            _mFontStyle = mFontStyle;
            _textAlignment = mTextAlignment;
            _mFontSize = fsize;
            _mLabelBackground = mLabelBackground;
            _mLabelForeground = mLabelForeground;
            _RotateAngle = rotateAngle;
            _decoration = decoration;
        }
        private TextDecorationCollection _decoration;
        public TextDecorationCollection Decoration
        {
            get
            {
                return _decoration;
            }
            set
            {
                if (_decoration != value)
                {
                    _decoration = value;
                }
            }
        }
        public FontFamily Font
        {
            get
            {
                return _mFont;
            }
            set
            {
                if(_mFont != value)
                {
                    _mFont = value;
                }
            }
        }

        public FontWeight FontWeight
        {
            get
            {
                return _mFontWeight;
            }
            set
            {
                if (_mFontWeight != value)
                {
                    _mFontWeight = value;
                }
            }
        }

        public FontStyle FontStyle
        {
            get
            {
                return _mFontStyle;
            }
            set
            {
                if (_mFontStyle != value)
                {
                    _mFontStyle = value;
                }
            }
        }

        public int FontSize
        {
            get
            {
                return _mFontSize;
            }
            set
            {
                if (_mFontSize != value)
                {
                    _mFontSize = value;
                }
            }
        }

        public TextAlignment TextAlignment
        {
            get { return _textAlignment; }
            set
            {
                if (_textAlignment != value)
                {
                    _textAlignment = value;
                }
            }
        }
        public double RotateAngle
        {
            get { return _RotateAngle; }
            set
            {
                if (_RotateAngle != value)
                {
                    _RotateAngle = value;
                }
            }
        }
        //Thickness _mLabelMargin = new Thickness(0);
        //public Thickness LabelMargin
        //{
        //    get
        //    {
        //        return _mLabelMargin;
        //    }
        //    set
        //    {
        //        if (_mLabelMargin != value)
        //        {
        //            _mLabelMargin = value;
        //        }
        //    }
        //}


        private Brush _mLabelBackground;
        public Brush LabelBackground
        {
            get { return _mLabelBackground; }
            set
            {
                if (_mLabelBackground != value)
                {
                    _mLabelBackground = value;
                }
            }
        }

        private Brush _mLabelForeground;


        public Brush LabelForeground
        {
            get { return _mLabelForeground; }
            set
            {
                if (_mLabelForeground != value)
                {
                    _mLabelForeground = value;
                }
            }
        }

    }
    //public class CustomHyperlinkButton : Hyperlink
    //{
    //    public CustomHyperlinkButton()
    //    {
    //        this.Click += CustomHyperlinkButton_Click;
    //    }

    //    async void CustomHyperlinkButton_Click(object sender, RoutedEventArgs e)
    //    {
    //        //string uriToLaunch = (sender as Hyperlink);//.Content.ToString();
    //        //if (!uriToLaunch.Contains("http://")) { uriToLaunch = "http://" + uriToLaunch; }
    //        //var uri = new Uri(uriToLaunch);
    //        //await System.Launcher.LaunchUriAsync(uri);
    //    }
    //}
}
