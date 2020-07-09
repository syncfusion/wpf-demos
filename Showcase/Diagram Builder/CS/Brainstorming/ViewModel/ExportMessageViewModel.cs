// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExportMessageViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The export message view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Brainstorming.ViewModel
{
    using Syncfusion.Windows.Shared;

    /// <summary>
    ///     The export message view model.
    /// </summary>
    public class ExportMessageViewModel
    {
        /// <summary>
        ///     The ok command.
        /// </summary>
        private DelegateCommand<object> okCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportMessageViewModel"/> class.
        /// </summary>
        /// <param name="diagramBuilderVM">
        /// The diagram builder vm.
        /// </param>
        public ExportMessageViewModel(BrainstormingBuilderVM diagramBuilderVM)
        {
            this.DiagramBuilderVM = diagramBuilderVM;
        }

        /// <summary>
        ///     Gets the diagram builder vm.
        /// </summary>
        public BrainstormingBuilderVM DiagramBuilderVM { get; private set; }

        /// <summary>
        ///     Gets the ok command.
        /// </summary>
        public DelegateCommand<object> OkCommand
        {
            get
            {
                return this.okCommand ?? (this.okCommand = new DelegateCommand<object>(this.OkCommandExecute));
            }
        }

        /// <summary>
        /// Method will execute when OkCommand executed
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void OkCommandExecute(object obj)
        {
            this.DiagramBuilderVM.OpenCloseWindowBehavior.OpenExportMessageWindow = false;
        }
    }
}