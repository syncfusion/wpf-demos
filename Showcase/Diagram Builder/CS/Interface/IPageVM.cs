// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPageVM.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the PageVM interface class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder
{
    using Syncfusion.UI.Xaml.Diagram;

    /// <summary>
    ///     Represents the PageVM interface class.
    /// </summary>
    public interface IPageVM
    {
        /// <summary>
        ///     Gets or sets a value indicating whether grid lines.
        /// </summary>
        bool GridLines { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether ruler.
        /// </summary>
        bool Ruler { get; set; }

        /// <summary>
        ///     Gets or sets the selected format.
        /// </summary>
        PageSize SelectedFormat { get; set; }

        /// <summary>
        ///     Gets or sets the selected unit.
        /// </summary>
        LengthUnits SelectedUnit { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether snap to grid.
        /// </summary>
        bool SnapToGrid { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether snap to object.
        /// </summary>
        bool SnapToObject { get; set; }
    }
}