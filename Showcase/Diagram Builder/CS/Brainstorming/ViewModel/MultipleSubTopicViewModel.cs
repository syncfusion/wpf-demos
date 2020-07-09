// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MultipleSubTopicViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The multiple sub topic view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Brainstorming.ViewModel
{
    using Syncfusion.UI.Xaml.Diagram;
    using Syncfusion.Windows.Shared;

    /// <summary>
    ///     The multiple sub topic view model.
    /// </summary>
    public class MultipleSubTopicViewModel : DiagramElementViewModel
    {
        /// <summary>
        ///     The cancel command.
        /// </summary>
        private DelegateCommand<object> cancelCommand;

        /// <summary>
        ///     The ok command.
        /// </summary>
        private DelegateCommand<object> okCommand;

        /// <summary>
        ///     The selected item.
        /// </summary>
        private object selectedItem = "Topic 1";

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleSubTopicViewModel"/> class.
        /// </summary>
        /// <param name="diagramBuilderVM">
        /// The diagram builder vm.
        /// </param>
        public MultipleSubTopicViewModel(BrainstormingBuilderVM diagramBuilderVM)
        {
            this.DiagramBuilderVM = diagramBuilderVM;
        }

        /// <summary>
        ///     Gets the cancel command.
        /// </summary>
        public DelegateCommand<object> CancelCommand
        {
            get
            {
                return this.cancelCommand
                       ?? (this.cancelCommand = new DelegateCommand<object>(this.CancelCommandExecute));
            }
        }

        /// <summary>
        ///     Gets applications diagram builder vm.
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
        ///     Gets or sets text to add multiple sub topics
        /// </summary>
        public object SelectedItem
        {
            get
            {
                return this.selectedItem;
            }

            set
            {
                if (this.selectedItem != value)
                {
                    this.selectedItem = value;
                    this.OnPropertyChanged("SelectedItem");
                }
            }
        }

        /// <summary>
        /// Method will execute when CancelCommand executed
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void CancelCommandExecute(object obj)
        {
            this.DiagramBuilderVM.OpenCloseWindowBehavior.OpenMultipleSubTopicWindow = false;
        }

        /// <summary>
        /// Method will execute when OkCommand executed
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void OkCommandExecute(object obj)
        {
            (this.DiagramBuilderVM.SelectedDiagram as BrainstormingVM).AddMultipleSubTopics(
                this.SelectedItem.ToString(),
                this.DiagramBuilderVM.SubTopicCommand);
            this.DiagramBuilderVM.OpenCloseWindowBehavior.OpenMultipleSubTopicWindow = false;
        }
    }
}