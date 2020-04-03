// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileInfo.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the file info.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.Model
{
    /// <summary>
    ///     Represents the file info.
    /// </summary>
    public class FileInfo
    {
        /// <summary>
        ///     Gets or sets the file name.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        ///     Gets or sets the index.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether selected.
        /// </summary>
        public bool Selected { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
    }
}