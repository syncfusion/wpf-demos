using syncfusion.brainstormingdiagram.wpf.Utility;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.brainstormingdiagram.wpf.ViewModel
{
    public class ChangeTopicViewModel : DiagramElementViewModel
    {
        #region Constructor
        public ChangeTopicViewModel(MindMapViewModel mindMapVM)
        {
            MindMapVM = mindMapVM;            
        }
        #endregion
        #region Public Properties

        private ObservableCollection<string> topics;
        private object selectedItem = "Rectangle";

        /// <summary>
        /// Gets or sets collection of Topics.
        /// </summary>
        public ObservableCollection<string> Topics
        {
            get { return topics; }
            set
            {
                if (topics != value)
                {
                    topics = value;
                    OnPropertyChanged("Topics");
                }
            }
        }

        /// <summary>
        /// Gets or sets selected topic.
        /// </summary>
        public object SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    OnPropertyChanged("SelectedItem");
                }
            }
        }

        /// <summary>
        /// Gets applications diagram builder vm.
        /// </summary>
        public MindMapViewModel MindMapVM { get; private set; }
        #endregion
        #region Public Commands
        DelegateCommand<object> okCommand;
        DelegateCommand<object> cancelCommand;
        DelegateCommand<object> keyDownCommand;
        public DelegateCommand<object> OkCommand
        {
            get
            {
                return okCommand ??
                    (okCommand = new DelegateCommand<object>(OkCommandExecute));
            }
        }
        public DelegateCommand<object> CancelCommand
        {
            get
            {
                return cancelCommand ??
                    (cancelCommand = new DelegateCommand<object>(CancelCommandExecute));
            }
        }
        public DelegateCommand<object> KeyDownCommand
        {
            get
            {
                return keyDownCommand ??
                    (keyDownCommand = new DelegateCommand<object>(KeyDownCommandExecute));
            }
        }
        #endregion
        #region Internal Methods
        internal void UpdateTopics()
        {
            if (MindMapVM.Root.IsSelected)
            {
                Topics = new ObservableCollection<string>() { "Oval", "Cloud", "Rectangle", "Starburst" };
            }
            else
            {
                Topics = new ObservableCollection<string>() { "Oval", "Cloud", "Rectangle", "Line", "Freehand", "Wave" };
            }
        }
        #endregion
        #region Private Methods
        /// <summary>
        /// Method will execute when KeyDownCommand executed
        /// </summary>
        private void KeyDownCommandExecute(object obj)
        {
            OkCommand.Execute(SelectedItem);
        }

        /// <summary>
        /// Method will execute when CancelCommand executed
        /// </summary>
        private void CancelCommandExecute(object obj)
        {
            MindMapVM.OpenCloseWindowBehavior.OpenTopicChangeWindow = false;
        }

        /// <summary>
        /// Method will execute when OkCommand executed
        /// </summary>
        private void OkCommandExecute(object obj)
        {
            MindMapVM.ChangeItemShape(obj.ToString());
            MindMapVM.OpenCloseWindowBehavior.OpenTopicChangeWindow = false;
        }
        #endregion
    }
}
