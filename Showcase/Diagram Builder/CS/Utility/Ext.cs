// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ext.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the extension class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.Utility
{
    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Media;

    /// <summary>
    ///     Represents the extension class.
    /// </summary>
    public static class Ext
    {
        /// <summary>
        /// This method will create the color based on the alpha channel values.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="Color"/>.
        /// </returns>
        public static Color ToColor(this string value)
        {
            Color c;
            Match match = Regex.Match(value, "#([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})");
            int a = Convert.ToInt32(match.Groups[1].Value, 16);
            int r = Convert.ToInt32(match.Groups[2].Value, 16);
            int g = Convert.ToInt32(match.Groups[3].Value, 16);
            int b = Convert.ToInt32(match.Groups[4].Value, 16);
            c = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
            return c;
        }
    }
}