// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDiagramBuilderVM.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the DiagramBuilderVM interface class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder
{
    using System.Threading.Tasks;
    using System.Windows.Input;

    /// <summary>
    ///     Represents the DiagramBuilderVM interface class.
    /// </summary>
    public interface IDiagramBuilderVM
    {
        /// <summary>
        ///     Gets or sets the draw.
        /// </summary>
        ICommand Draw { get; set; }

        /// <summary>
        ///     Gets or sets the import.
        /// </summary>
        ICommand Import { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether drawing tool can be enabled or not.
        /// </summary>
        bool IsDrawingToolEnable { get; set; }

        /// <summary>
        ///     Gets or sets the new.
        /// </summary>
        ICommand New { get; set; }

        /// <summary>
        ///     Gets or sets the open.
        /// </summary>
        ICommand Open { get; set; }

        /// <summary>
        ///     Gets or sets the print.
        /// </summary>
        ICommand Print { get; set; }

        /// <summary>
        ///     Gets or sets the save.
        /// </summary>
        ICommand Save { get; set; }

        /// <summary>
        ///     Gets or sets the save all.
        /// </summary>
        ICommand SaveAll { get; set; }

        /// <summary>
        ///     Gets or sets the zoom in.
        /// </summary>
        ICommand ZoomIn { get; set; }

        /// <summary>
        ///     Gets or sets the zoom out.
        /// </summary>
        ICommand ZoomOut { get; set; }

        /// <summary>
        ///     The prepare exit.
        /// </summary>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        Task PrepareExit();
    }
}