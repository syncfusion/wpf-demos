// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NodePortVM.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the custom class for node viewmodel.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.ViewModel
{
    using System.Runtime.Serialization;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Shapes;

    using DiagramBuilder.Utility;

    using Syncfusion.UI.Xaml.Diagram;

    /// <summary>
    ///     Represents the custom class for node viewmodel.
    /// </summary>
    public class NodePortVM : NodePortViewModel
    {
        /// <summary>
        ///     The _m fill.
        /// </summary>
        private Brush _mFill = new SolidColorBrush(Colors.White);

        /// <summary>
        ///     The _mIsSelected.
        /// </summary>
        private bool _mIsSelected;

        /// <summary>
        ///     The _m stroke.
        /// </summary>
        private Brush mStroke = new SolidColorBrush(Colors.Black);

        /// <summary>
        ///     Gets or sets the fill value.
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
                    this.OnPropertyChanged("Fill");
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
        ///     Gets or sets a value indicating whether port is selected or not.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return this._mIsSelected;
            }

            set
            {
                if (value != this._mIsSelected)
                {
                    this._mIsSelected = value;
                    this.OnPropertyChanged("IsSelected");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the stroke color value.
        /// </summary>
        public Brush Stroke
        {
            get
            {
                return this.mStroke;
            }

            set
            {
                this.mStroke = value;
                this.OnPropertyChanged("Stroke");
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
        /// Represents the shape style.
        /// </summary>
        /// <param name="style">
        /// The style.
        /// </param>
        protected virtual void ApplyStyle(Style style)
        {
            this.ShapeStyle = style;
        }

        /// <summary>
        ///     The get custom style.
        /// </summary>
        /// <returns>
        ///     The <see cref="Style" />.
        /// </returns>
        protected virtual Style GetCustomStyle()
        {
            Style s = new Style(typeof(Path));
            if (this.Fill != null)
            {
                s.Setters.Add(new Setter(System.Windows.Shapes.Shape.FillProperty, this.Fill));
                s.Setters.Add(new Setter(System.Windows.Shapes.Shape.StretchProperty, Stretch.Fill));
            }

            if (this.Stroke != null)
            {
                s.Setters.Add(new Setter(System.Windows.Shapes.Shape.StrokeProperty, this.Stroke));
            }

            return s;
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
            switch (name)
            {
                case "Fill":
                    this.OnFillChanged();
                    break;
                case "Stroke":
                    this.OnStrokeChanged();
                    break;
            }
        }

        /// <summary>
        ///     The on fill changed.
        /// </summary>
        private void OnFillChanged()
        {
            this.ApplyStyle(this.GetCustomStyle());
        }

        /// <summary>
        ///     The on stroke changed.
        /// </summary>
        private void OnStrokeChanged()
        {
            this.ApplyStyle(this.GetCustomStyle());
        }
    }
}