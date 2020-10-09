// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDiagramViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the DiagramViewModel interface class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder
{
    using System.Windows.Input;

    using Syncfusion.UI.Xaml.Diagram;

    /// <summary>
    ///     Represents the DiagramViewModel interface class.
    /// </summary>
    public interface IDiagramViewModel : IGraph
    {
        /// <summary>
        ///     Gets or sets the delete.
        /// </summary>
        ICommand Delete { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether enable pan zoom or not.
        /// </summary>
        bool EnablePanZoom { get; set; }

        /// <summary>
        ///     Gets or sets the first load.
        /// </summary>
        ICommand FirstLoad { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether text node can draw or not.
        /// </summary>
        bool IsDrawTextNode { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether element can select or not.
        /// </summary>
        bool IsSelected { get; set; }

        /// <summary>
        ///     Gets or sets the shape.
        /// </summary>
        string Shape { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        string Title { get; set; }
    }
}