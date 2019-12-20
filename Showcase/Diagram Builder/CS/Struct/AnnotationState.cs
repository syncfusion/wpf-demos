// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnnotationState.cs" company="">
//   
// </copyright>
// <summary>
//   Customizing the annotation appearance using the annotation state class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder
{
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    ///     Customizing the annotation appearance using the annotation state class.
    /// </summary>
    public struct AnnotationState
    {
        /// <summary>
        ///     Represents the _m font.
        /// </summary>
        private FontFamily _mFont;

        /// <summary>
        ///     Represents the _m font weight.
        /// </summary>
        private FontWeight _mFontWeight;

        /// <summary>
        ///     Represents the _m font style.
        /// </summary>
        private FontStyle _mFontStyle;

        /// <summary>
        ///     Represents the _text alignment.
        /// </summary>
        private TextAlignment _textAlignment;

        /// <summary>
        ///     Represents the _m font size.
        /// </summary>
        private int _mFontSize;

        /// <summary>
        ///     Represents the _ rotate angle.
        /// </summary>
        private double _RotateAngle;

        /// <summary>
        ///     Represents the _decoration.
        /// </summary>
        private TextDecorationCollection _decoration;

        /// <summary>
        ///     Represents the _m label background.
        /// </summary>
        private Brush _mLabelBackground;

        /// <summary>
        ///     Represents the _m label foreground.
        /// </summary>
        private Brush _mLabelForeground;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnotationState"/> struct.
        /// </summary>
        /// <param name="mfont">
        /// The mfont value applies to the font property of annotation.
        /// </param>
        /// <param name="mFontWeight">
        /// The m font weight value applies to the font weight property of annotation.
        /// </param>
        /// <param name="mFontStyle">
        /// The m font style value applies to the font style property of annotation.
        /// </param>
        /// <param name="mTextAlignment">
        /// The m text alignment value applies to the text alignment property of annotation.
        /// </param>
        /// <param name="fsize">
        /// The fsize value applies to the font size property of annotation.
        /// </param>
        /// <param name="mLabelBackground">
        /// The m label background value applies to the label background property of annotation.
        /// </param>
        /// <param name="mLabelForeground">
        /// The m label foreground value applies to the label foreground property of annotation.
        /// </param>
        /// <param name="rotateAngle">
        /// The rotate angle value applies to the rotate angle property of annotation.
        /// </param>
        /// <param name="decoration">
        /// The decoration value applies to the decoration property of annotation.
        /// </param>
        public AnnotationState(
            FontFamily mfont,
            FontWeight mFontWeight,
            FontStyle mFontStyle,
            TextAlignment mTextAlignment,
            int fsize,
            Brush mLabelBackground,
            Brush mLabelForeground,
            double rotateAngle,
            TextDecorationCollection decoration)
        {
            this._mFont = mfont;
            this._mFontWeight = mFontWeight;
            this._mFontStyle = mFontStyle;
            this._textAlignment = mTextAlignment;
            this._mFontSize = fsize;
            this._mLabelBackground = mLabelBackground;
            this._mLabelForeground = mLabelForeground;
            this._RotateAngle = rotateAngle;
            this._decoration = decoration;
        }

        /// <summary>
        ///     Gets or sets the decoration.
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
                }
            }
        }

        /// <summary>
        ///     Gets or sets the font weight.
        /// </summary>
        public FontWeight FontWeight
        {
            get
            {
                return this._mFontWeight;
            }

            set
            {
                if (this._mFontWeight != value)
                {
                    this._mFontWeight = value;
                }
            }
        }

        /// <summary>
        ///     Gets or sets the font style.
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
                }
            }
        }

        /// <summary>
        ///     Gets or sets the font size.
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
                }
            }
        }

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
                }
            }
        }

        /// <summary>
        ///     Gets or sets the rotate angle.
        /// </summary>
        public double RotateAngle
        {
            get
            {
                return this._RotateAngle;
            }

            set
            {
                if (this._RotateAngle != value)
                {
                    this._RotateAngle = value;
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
                }
            }
        }
    }
}