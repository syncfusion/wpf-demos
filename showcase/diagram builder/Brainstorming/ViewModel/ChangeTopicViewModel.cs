// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangeTopicViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The change topic view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Brainstorming.ViewModel
{
    using System.Collections.ObjectModel;

    using Syncfusion.UI.Xaml.Diagram;
    using Syncfusion.Windows.Shared;

    /// <summary>
    ///     The change topic view model.
    /// </summary>
    public class ChangeTopicViewModel : DiagramElementViewModel
    {
        /// <summary>
        ///     The cancel command.
        /// </summary>
        private DelegateCommand<object> cancelCommand;

        /// <summary>
        ///     The key down command.
        /// </summary>
        private DelegateCommand<object> keyDownCommand;

        /// <summary>
        ///     The ok command.
        /// </summary>
        private DelegateCommand<object> okCommand;

        /// <summary>
        ///     The selected item.
        /// </summary>
        private object selectedItem = "Rectangle";

        /// <summary>
        ///     The topics.
        /// </summary>
        private ObservableCollection<string> topics;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeTopicViewModel"/> class.
        /// </summary>
        /// <param name="diagramBuilderVM">
        /// The diagram builder vm.
        /// </param>
        public ChangeTopicViewModel(BrainstormingBuilderVM diagramBuilderVM)
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
        ///     Gets the key down command.
        /// </summary>
        public DelegateCommand<object> KeyDownCommand
        {
            get
            {
                return this.keyDownCommand
                       ?? (this.keyDownCommand = new DelegateCommand<object>(this.KeyDownCommandExecute));
            }
        }

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
        ///     Gets or sets selected topic.
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
        ///     Gets or sets collection of Topics.
        /// </summary>
        public ObservableCollection<string> Topics
        {
            get
            {
                return this.topics;
            }

            set
            {
                if (this.topics != value)
                {
                    this.topics = value;
                    this.OnPropertyChanged("Topics");
                }
            }
        }

        /// <summary>
        ///     The update topics.
        /// </summary>
        internal void UpdateTopics()
        {
            if (this.DiagramBuilderVM.SelectedDiagram != null
                && (this.DiagramBuilderVM.SelectedDiagram as BrainstormingVM).Rootnode.IsSelected)
            {
                this.Topics = new ObservableCollection<string> { "Oval", "Cloud", "Rectangle", "Starburst" };
            }
            else
            {
                this.Topics = new ObservableCollection<string>
                                  {
                                      "Oval",
                                      "Cloud",
                                      "Rectangle",
                                      "Line",
                                      "Freehand",
                                      "Wave"
                                  };
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
            this.DiagramBuilderVM.OpenCloseWindowBehavior.OpenTopicChangeWindow = false;
        }

        /// <summary>
        /// Method will execute when KeyDownCommand executed
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void KeyDownCommandExecute(object obj)
        {
            this.OkCommand.Execute(this.SelectedItem);
        }

        /// <summary>
        /// Method will execute when OkCommand executed
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void OkCommandExecute(object obj)
        {
            (this.DiagramBuilderVM.SelectedDiagram as BrainstormingVM).ChangeItemShape(obj.ToString());
            this.DiagramBuilderVM.OpenCloseWindowBehavior.OpenTopicChangeWindow = false;
        }
    }
}