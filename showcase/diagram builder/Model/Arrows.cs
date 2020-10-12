// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Arrows.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the arrows class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder
{
    /// <summary>
    ///     Represents the arrows class.
    /// </summary>
    public class Arrows
    {
        /// <summary>
        ///     Gets or sets the angle.
        /// </summary>
        public int Angle { get; set; }

        /// <summary>
        ///     Gets or sets the decorator.
        /// </summary>
        public string decorator { get; set; }

        /// <summary>
        ///     Gets or sets the horizontal alignment.
        /// </summary>
        public string HorizontalAlignment { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether isbothcap.
        /// </summary>
        public bool Isbothcap { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether is cap.
        /// </summary>
        public bool IsCap { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether issourcecap.
        /// </summary>
        public bool Issourcecap { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether istargetcap.
        /// </summary>
        public bool Istargetcap { get; set; }

        /// <summary>
        ///     Gets or sets the line data.
        /// </summary>
        public string LineData { get; set; }
    }
}