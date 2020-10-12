// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelVM.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the custom class for AnnotationEditorViewModel.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.ViewModel
{
    using System.IO;
    using System.Windows;
    using System.Windows.Markup;
    using System.Windows.Media;
    using System.Xml;

    using Syncfusion.UI.Xaml.Diagram;
    using Syncfusion.Windows.Tools.Controls;

    /// <summary>
    ///     Represents the custom class for AnnotationEditorViewModel.
    /// </summary>
    public class LabelVM : AnnotationEditorViewModel, IUndoRedo
    {
        /// <summary>
        ///     The _decoration.
        /// </summary>
        private TextDecorationCollection _decoration;

        /// <summary>
        ///     The _m collection data.
        /// </summary>
        private AnnotationState _mCollectionData;

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
        private string _mHyperLink = string.Empty;

        /// <summary>
        ///     The _m label background.
        /// </summary>
        private Brush _mLabelBackground = new SolidColorBrush(Colors.White);

        /// <summary>
        ///     The _m label foreground.
        /// </summary>
        private Brush _mLabelForeground = new SolidColorBrush(Colors.Black);

        /// <summary>
        ///     The _m label margin.
        /// </summary>
        private Thickness _mLabelMargin = new Thickness(0);

        /// <summary>
        ///     The _text alignment.
        /// </summary>
        private TextAlignment _textAlignment;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LabelVM" /> class.
        /// </summary>
        public LabelVM()
        {
            // "TextDecorations=\"{Binding Path=Decoration}\"" +
            const string vTemplate =
                "<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">"
                + "<Border Padding=\"0\" BorderThickness =\"0\">"
                + "<TextBlock TextAlignment=\"{Binding Path=TextHorizontalAlignment}\""
                + " VerticalAlignment=\"{Binding Path=TextVerticalAlignment}\"" + " FontFamily=\"{Binding Path=Font}\""
                + " FontWeight=\"{Binding Path=FontWeight}\"" + " FontStyle=\"{Binding Path=FontStyle}\""
                + " FontSize=\"{Binding Path=FontSize}\"" + " TextWrapping=\"{Binding Path=WrapText}\""
                + " Margin=\"{Binding Path=LabelMargin}\"" + " Foreground=\"{Binding Path=LabelForeground}\""
                + " TextDecorations=\"{Binding Path=Decoration}\"" + " Text=\"{Binding Path=Content, Mode=TwoWay}\"/>"
                + "</Border>" + "</DataTemplate>";

            const string eTemplate = "<DataTemplate"
                                     + " xmlns:util=\"clr-namespace:Syncfusion.UI.Xaml.Diagram.Utility;assembly=Syncfusion.SfDiagram.Wpf\""
                                     + " xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">"
                                     + "<TextBox util:FocusUtility.FocusOnLoad=\"True\" "
                                     + "TextAlignment =\"{Binding Path=TextHorizontalAlignment}\""
                                     + " FontFamily=\"{Binding Path=Font}\""
                                     + " TextWrapping=\"{Binding Path=WrapText}\""
                                     + " FontWeight=\"{Binding Path=FontWeight}\""
                                     + " FontStyle=\"{Binding Path=FontStyle}\""
                                     + " FontSize=\"{Binding Path=FontSize}\""
                                     + " Margin=\"{Binding Path=LabelMargin}\"" + " AcceptsReturn=\"True\""
                                     + " TextDecorations=\"{Binding Path=Decoration}\""
                                     + " Background=\"{Binding Path=LabelBackground}\""
                                     + " Text=\"{Binding Path=Content, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}\"/>"
                                     + "</DataTemplate>";
            StringReader srReader = new StringReader(vTemplate);
            StringReader srReader1 = new StringReader(eTemplate);
            XmlReader ms = XmlReader.Create(srReader);
            XmlReader ms1 = XmlReader.Create(srReader1);
            this.ViewTemplate = XamlReader.Load(ms) as DataTemplate;
            this.EditTemplate = XamlReader.Load(ms1) as DataTemplate;

            // this.WrapText = TextWrapping.Wrap;
            this._mCollectionData = new AnnotationState(
                this.Font,
                this.FontWeight,
                this.FontStyle,
                this.TextAlignment,
                this.FontSize,
                this.LabelBackground,
                this.LabelForeground,
                this.RotateAngle,
                this.Decoration);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelVM"/> class.
        /// </summary>
        /// <param name="hyperlink">
        /// The hyperlink.
        /// </param>
        public LabelVM(string hyperlink)
        {
        }

        /// <summary>
        ///     Gets or sets the decoration of the text.
        /// </summary>
        public TextDecorationCollection Decoration
        {
            get
            {
                return this._decoration;
            }

            set
            {
                if (this._decoration != value)
                {
                    this._decoration = value;
                    this.OnPropertyChanged(GroupableConstants.Decoration);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the fontfamily style of the text.
        /// </summary>
        public FontFamily Font
        {
            get
            {
                return this._mFont;
            }

            set
            {
                {
                    // if (_mFontWeight != value)
                    this._mFont = value;
                    this.OnPropertyChanged(GroupableConstants.Font);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the font size of the text.
        /// </summary>
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
                    this.OnPropertyChanged(GroupableConstants.FontStyle);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the font weight of the text.
        /// </summary>
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
                    this.OnPropertyChanged(GroupableConstants.FontWeight);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the hyper link to the text.
        /// </summary>
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
        ///     Gets or sets the label margin.
        /// </summary>
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
                    this.OnPropertyChanged(GroupableConstants.LabelMargin);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the state.
        /// </summary>
        public UndoRedoState State { get; set; }

        /// <summary>
        ///     Gets or sets the text alignment.
        /// </summary>
        public TextAlignment TextAlignment
        {
            get
            {
                return this._textAlignment;
            }

            set
            {
                if (this._textAlignment != value)
                {
                    this._textAlignment = value;
                    this.OnPropertyChanged("TextAlignment");
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
        ///     Represents the collection of the data.
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
            DiagramVM info = null;
            foreach (Window win in Application.Current.Windows)
            {
                if (win.DataContext is DiagramBuilderVM)
                {
                    info = (win.DataContext as DiagramBuilderVM).SelectedDiagram;
                }
            }
            
            if (info != null)
            {
                info.HistoryManager.LogData(this, data);
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
            if (data is AnnotationState)
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
            if (data is AnnotationState)
            {
                object current = this.GetData();
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
            if (data is AnnotationState)
            {
                return this.RevertTo(data);
            }

            return data;
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

            DiagramVM info = null;
            foreach (Window win in Application.Current.Windows)
            {
                if(win.DataContext is DiagramBuilderVM)
                {
                    info = (win.DataContext as DiagramBuilderVM).SelectedDiagram;
                }
            }

            if (info != null && info.HistoryManager != null && this.AllowToLogData(name))
            {
                if (info.HistoryManager.CanLogData(info.HistoryManager, this._mCollectionData))
                {
                    this.LogData(this._mCollectionData);
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
                    this._mCollectionData.LabelForeground = this.LabelForeground;
                    this._mCollectionData.Font = this.Font;
                    this._mCollectionData.FontSize = this.FontSize;
                    this._mCollectionData.FontStyle = this.FontStyle;
                    this._mCollectionData.FontWeight = this.FontWeight;
                    this._mCollectionData.LabelBackground = this.LabelBackground;
                    this._mCollectionData.TextAlignment = this.TextAlignment;
                    this._mCollectionData.RotateAngle = this.RotateAngle;
                    this._mCollectionData.Decoration = this.Decoration;
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
            if (name == "FontSize" || name == "Font" || name == "FontStyle" || name == "FontWeight"
                || name == "TextAlignment" || name == "LabelBackground" || name == "LabelForeground"
                || name == "RotateAngle" || name == "Decoration")
            {
                return true;
            }

            return false;
        }
    }
}