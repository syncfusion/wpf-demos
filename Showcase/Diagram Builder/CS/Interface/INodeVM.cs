// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INodeVM.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the NodeVM interface class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder
{
    using System.Windows.Media;

    /// <summary>
    ///     Represents the NodeVM interface class.
    /// </summary>
    public interface INodeVM : IGroupableVM
    {
        /// <summary>
        ///     Gets or sets a value indicating whether allow drag or not.
        /// </summary>
        bool AllowDrag { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether allow resize or not.
        /// </summary>
        bool AllowResize { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether allow rotate or not.
        /// </summary>
        bool AllowRotate { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether node can resize based on aspect ratio or not.
        /// </summary>
        bool AspectRatio { get; set; }

        /// <summary>
        ///     Gets or sets the fill.
        /// </summary>
        Brush Fill { get; set; }

        /// <summary>
        ///     Gets or sets the node gallary name.
        /// </summary>
        string NodeGalleryName { get; set; }

        /// <summary>
        ///  Gets or sets the node template name.
        /// </summary>
        string NodeTemplateName { get; set; }
    }
}