// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagramButtonViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   REpresents the diagram button view model class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.ViewModel
{
    using System.Collections.ObjectModel;

    /// <summary>
    ///     REpresents the diagram button view model class.
    /// </summary>
    public class DiagramButtonViewModel
    {
        /// <summary>
        ///     Gets or sets the display control.
        /// </summary>
        public Controls DisplayControl { get; set; }

        /// <summary>
        ///     Gets or sets the galary items collection.
        /// </summary>
        public ObservableCollection<string> GalleryItems { get; set; }

        /// <summary>
        ///     Gets or sets the galary line items collection.
        /// </summary>
        public ObservableCollection<string> GalleryLineItems { get; set; }

        /// <summary>
        ///     Gets or sets the galary themes collection.
        /// </summary>
        public ObservableCollection<string> GalleryThemes { get; set; }

        /// <summary>
        /// Gets or sets the galary line item
        /// </summary>
        public ObservableCollection<string> GalaryNodeTemplates { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        ///     Gets or sets the items collection.
        /// </summary>
        public ObservableCollection<DiagramDropdownViewModel> Items { get; set; }

        /// <summary>
        ///     Gets or sets the label.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        ///     Gets or sets the small icon.
        /// </summary>
        public string SmallIcon { get; set; }

        /// <summary>
        ///     Gets or sets the tool tip message.
        /// </summary>
        public string ToolTipMessage { get; set; }
    }
}