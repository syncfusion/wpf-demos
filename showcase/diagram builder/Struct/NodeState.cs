// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NodeState.cs" company="">
//   
// </copyright>
// <summary>
//   Customizing the node appearance using nodestate class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder
{
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    ///     Customizing the node appearance using nodestate class.
    /// </summary>
    public struct NodeState
    {
        /// <summary>
        ///     Represents the _mfill.
        /// </summary>
        private Brush _mFill;

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
                }
            }
        }

        /// <summary>
        ///     Represents the _mquickfill.
        /// </summary>
        private Brush _mQuickFill;

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
                }
            }
        }

        /// <summary>
        ///     Represents the mstroke.
        /// </summary>
        private Brush mStroke;

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
                }
            }
        }

        /// <summary>
        ///     Represents the _mdashdot.
        /// </summary>
        private string _mDashDot;

        /// <summary>
        ///     Gets or sets the dash dot.
        /// </summary>
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
                }
            }
        }

        /// <summary>
        ///     Represents the mthickness.
        /// </summary>
        private double mThickness;

        /// <summary>
        ///     Gets or sets the thickness.
        /// </summary>
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
                }
            }
        }

        /// <summary>
        ///     Represents the mshapestyle.
        /// </summary>
        private Style mShapeStyle;

        /// <summary>
        ///     Gets or sets the style of the Node.
        /// </summary>
        public Style ShapeStyle
        {
            get
            {
                return this.mShapeStyle;
            }

            set
            {
                if (this.mShapeStyle != value)
                {
                    this.mShapeStyle = value;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeState"/> struct.
        /// </summary>
        /// <param name="style">
        /// The style value applies to the shapestyle of the node.
        /// </param>
        /// <param name="fill">
        /// The fill value applies to the Fill color of the node.
        /// </param>
        /// <param name="qfill">
        /// The qfill value applies to the QuickFill color of the node.
        /// </param>
        /// <param name="stroke">
        /// The stroke value applies to the stroke color of the node.
        /// </param>
        /// <param name="dasdot">
        /// The dasdot value applies to the DashDot property of the node.
        /// </param>
        /// <param name="thickness">
        /// The thickness value applies to the Thickness property of the node.
        /// </param>
        public NodeState(Style style, Brush fill, Brush qfill, Brush stroke, string dasdot, double thickness)
        {
            this.mShapeStyle = style;
            this._mFill = fill;
            this._mQuickFill = qfill;
            this.mStroke = stroke;
            this._mDashDot = dasdot;
            this.mThickness = thickness;
        }
    }
}