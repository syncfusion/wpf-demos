// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectorState.cs" company="">
//   
// </copyright>
// <summary>
//   Customizing the connector appearance using connectorstate class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder
{
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    ///     Customizing the connector appearance using connectorstate class.
    /// </summary>
    public struct ConnectorState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectorState"/> struct.
        /// </summary>
        /// <param name="stroke">
        /// The stroke values applies to the stroke property of the connector.
        /// </param>
        /// <param name="dasdot">
        /// The dasdot values applies to the dashdot property of the connector..
        /// </param>
        /// <param name="thickness">
        /// The thickness values applies to the thickness property of the connector..
        /// </param>
        /// <param name="scap">
        /// The scap values applies to the sourcecap property of the connector..
        /// </param>
        /// <param name="tcap">
        /// The tcap values applies to the targetcap property of the connector..
        /// </param>
        /// <param name="sdecorator">
        /// The sdecorator values applies to the sourcedecorator property of the connector..
        /// </param>
        /// <param name="Tdecorator">
        /// The tdecorator value applies to the targetdecorator property of the connector.
        /// </param>
        /// <param name="sdecoratorstyle">
        /// The sdecoratorstyle value applies to the sourcedecorator style property of the connector..
        /// </param>
        /// <param name="tdecoratorstyle">
        /// The tdecoratorstyle value applies to the targetdecorator style property of the connector..
        /// </param>
        /// <param name="style">
        /// The style value applies to the connectorgeometrystyle property of the connector..
        /// </param>
        /// <param name="decorator">
        /// The decorator value applies to the decorator property of the connector.
        /// </param>
        public ConnectorState(
            Brush stroke,
            string dasdot,
            double thickness,
            string scap,
            string tcap,
            object sdecorator,
            object Tdecorator,
            Style sdecoratorstyle,
            Style tdecoratorstyle,
            Style style,
            string decorator)
        {
            this._mConnectorGeometryStyle = style;
            this.mStroke = stroke;
            this._mDashDot = dasdot;
            this.mThickness = thickness;
            this._mSourceCap = scap;
            this.mTargetCap = tcap;
            this._mSourceDecorator = sdecorator;
            this._mTargetDecorator = Tdecorator;
            this._mSourceDecoratorStyle = sdecoratorstyle;
            this._mTargetDecoratorStyle = tdecoratorstyle;
            this._mDecorator = decorator;
        }

        /// <summary>
        ///     Represents the _m connector geometry style.
        /// </summary>
        private Style _mConnectorGeometryStyle;

        /// <summary>
        ///     Gets or sets the connector geometry style.
        /// </summary>
        public Style ConnectorGeometryStyle
        {
            get
            {
                return this._mConnectorGeometryStyle;
            }

            set
            {
                if (this._mConnectorGeometryStyle != value)
                {
                    this._mConnectorGeometryStyle = value;
                }
            }
        }

        /// <summary>
        ///     Represents the _m source cap.
        /// </summary>
        private string _mSourceCap;

        /// <summary>
        ///     Gets or sets the source cap.
        /// </summary>
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
                }
            }
        }

        /// <summary>
        ///     Represents the _m decorator.
        /// </summary>
        private string _mDecorator;

        /// <summary>
        ///     Gets or sets the decorator.
        /// </summary>
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
                }
            }
        }

        /// <summary>
        ///     Represents the _m target cap.
        /// </summary>
        private string mTargetCap;

        /// <summary>
        ///     Gets or sets the target cap.
        /// </summary>
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
                }
            }
        }

        /// <summary>
        ///     Represents the _m source decorator.
        /// </summary>
        private object _mSourceDecorator;

        /// <summary>
        ///     Gets or sets the source decorator.
        /// </summary>
        public object SourceDecorator
        {
            get
            {
                return this._mSourceDecorator;
            }

            set
            {
                if (this._mSourceDecorator != value)
                {
                    this._mSourceDecorator = value;
                }
            }
        }

        /// <summary>
        ///     Represents the _m target decorator.
        /// </summary>
        private object _mTargetDecorator;

        /// <summary>
        ///     Gets or sets the target decorator.
        /// </summary>
        public object TargetDecorator
        {
            get
            {
                return this._mTargetDecorator;
            }

            set
            {
                if (this._mTargetDecorator != value)
                {
                    this._mTargetDecorator = value;
                }
            }
        }

        /// <summary>
        ///     Represents the _m source decorator style.
        /// </summary>
        private Style _mSourceDecoratorStyle;

        /// <summary>
        ///     Gets or sets the source decorator style.
        /// </summary>
        public Style SourceDecoratorStyle
        {
            get
            {
                return this._mSourceDecoratorStyle;
            }

            set
            {
                if (this._mSourceDecoratorStyle != value)
                {
                    this._mSourceDecoratorStyle = value;
                }
            }
        }

        /// <summary>
        ///     Represents the _m target decorator style.
        /// </summary>
        private Style _mTargetDecoratorStyle;

        /// <summary>
        ///     Gets or sets the target decorator style.
        /// </summary>
        public Style TargetDecoratorStyle
        {
            get
            {
                return this._mTargetDecoratorStyle;
            }

            set
            {
                if (this._mTargetDecoratorStyle != value)
                {
                    this._mTargetDecoratorStyle = value;
                }
            }
        }

        /// <summary>
        ///     Represents the _m stroke.
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
        ///     Represents the _m dash dot.
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
        ///     Represents the _m thickness.
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
    }
}