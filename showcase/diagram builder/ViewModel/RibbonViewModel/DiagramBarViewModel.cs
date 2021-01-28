// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagramBarViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the diagram bar view model class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.ViewModel
{
    using System.Collections.ObjectModel;

    /// <summary>
    ///     Represents the diagram bar view model class.
    /// </summary>
    public class DiagramBarViewModel
    {
        /// <summary>
        ///     Gets or sets the diagram buttons collection.
        /// </summary>
        public ObservableCollection<DiagramButtonViewModel> DiagramButtons { get; set; }

        /// <summary>
        ///     Gets or sets the header.
        /// </summary>
        public string Header { get; set; }
    }
}