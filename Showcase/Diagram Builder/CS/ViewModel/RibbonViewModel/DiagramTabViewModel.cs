// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagramTabViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the diagram tab view model class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.ViewModel
{
    using System.Collections.ObjectModel;

    /// <summary>
    ///     Represents the diagram tab view model class.
    /// </summary>
    public class DiagramTabViewModel
    {
        /// <summary>
        ///     Gets or sets the diagram groups collection.
        /// </summary>
        public ObservableCollection<DiagramBarViewModel> DiagramGroups { get; set; }

        /// <summary>
        ///     Gets or sets the header.
        /// </summary>
        public string Header { get; set; }
    }
}