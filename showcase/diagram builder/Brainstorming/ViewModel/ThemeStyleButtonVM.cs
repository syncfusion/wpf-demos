// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThemeStyleButtonVM.cs" company="">
//   
// </copyright>
// <summary>
//   The theme style button vm.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Brainstorming.ViewModel
{
    using Syncfusion.UI.Xaml.Diagram;
    using Syncfusion.UI.Xaml.Diagram.Theming;

    /// <summary>
    ///     The theme style button vm.
    /// </summary>
    public class ThemeStyleButtonVM : DiagramElementViewModel
    {
        /// <summary>
        ///     The _m column number.
        /// </summary>
        private int _mColumnNumber;

        /// <summary>
        ///     The _m row number.
        /// </summary>
        private int _mRowNumber;

        /// <summary>
        ///     The _m shape style.
        /// </summary>
        private DiagramItemStyle _mShapeStyle;

        /// <summary>
        ///     The _m theme style id.
        /// </summary>
        private StyleId _mThemeStyleID;

        /// <summary>
        ///     Gets or sets the column number.
        /// </summary>
        public int ColumnNumber
        {
            get
            {
                return this._mColumnNumber;
            }

            set
            {
                if (this._mColumnNumber != value)
                {
                    this._mColumnNumber = value;
                    this.OnPropertyChanged("ColumnNumber");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the row number.
        /// </summary>
        public int RowNumber
        {
            get
            {
                return this._mRowNumber;
            }

            set
            {
                if (this._mRowNumber != value)
                {
                    this._mRowNumber = value;
                    this.OnPropertyChanged("RowNumber");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the shape style.
        /// </summary>
        public DiagramItemStyle ShapeStyle
        {
            get
            {
                return this._mShapeStyle;
            }

            set
            {
                if (this._mShapeStyle != value)
                {
                    this._mShapeStyle = value;
                    this.OnPropertyChanged("ShapeStyle");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the theme style id.
        /// </summary>
        public StyleId ThemeStyleId
        {
            get
            {
                return this._mThemeStyleID;
            }

            set
            {
                if (this._mThemeStyleID != value)
                {
                    this._mThemeStyleID = value;
                }
            }
        }
    }
}