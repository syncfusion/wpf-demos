// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrentBrush.cs" company="">
//   
// </copyright>
// <summary>
//   Specifies the current brush value.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder
{
    /// <summary>
    ///     Specifies the current brush value.
    /// </summary>
    public enum CurrentBrush
    {
        /// <summary>
        ///     No color applied to the current brush.
        /// </summary>
        None,

        /// <summary>
        ///     Specifies the stroke color of the current brush.
        /// </summary>
        Stroke,

        /// <summary>
        ///     Specifies the fill color of the current brush.
        /// </summary>
        Fill,

        /// <summary>
        ///     Specifies the label foreground color of the current brush.
        /// </summary>
        LabelForeground,

        /// <summary>
        ///     Specifies the label background color of the current brush.
        /// </summary>
        LabelBackground
    }
}