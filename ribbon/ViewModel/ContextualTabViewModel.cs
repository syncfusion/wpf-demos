using Syncfusion.Windows.Shared;
using System.Windows;
using System.Windows.Input;

namespace syncfusion.ribbondemos.wpf
{
    /// <summary>
    /// Class represents the business or behaviour logic for MainWindow.xaml
    /// </summary>
    public class ContextualTabViewModel : NotificationObject
    {
        /// <summary>
        /// Maintains the context tab visibility.
        /// </summary>
        private bool isGroupVisible;

        /// <summary>
        /// Maintains the command to show picture tools.
        /// </summary>
        private ICommand showPictureToolsCommand;

        /// <summary>
        /// Maintains the command to hide picture tools.
        /// </summary>
        private ICommand hidePictureToolsCommand;


        /// <summary>
        /// Initializes the new instance of <see cref="ContextualTabViewModel"/> class.
        /// </summary>
        public ContextualTabViewModel()
        {
            hidePictureToolsCommand = new DelegateCommand<object>(ExecuteHidePictureToolsCommand);
            showPictureToolsCommand = new DelegateCommand<object>(ExecuteShowPictureToolsCommand);
        }

        /// <summary>
        /// Indicates whether the context tab is visible or not <see cref="ContextualTabViewModel"/> class.
        /// </summary>
        public bool IsGroupVisible
        {
            get
            {
                return isGroupVisible;
            }
            set
            {
                isGroupVisible = value;
                RaisePropertyChanged("IsGroupVisible");
            }
        }

        /// <summary>
        /// Gets the command for hide the picture tool tabs <see cref="ContextualTabViewModel"/> class.
        /// </summary>
        public ICommand HidePictureToolsCommand
        {
            get
            {
                return hidePictureToolsCommand;
            }
        }


        /// <summary>
        /// Gets the command for show the picture tool tabs <see cref="ContextualTabViewModel"/> class.
        /// </summary>
        public ICommand ShowPictureToolsCommand
        {
            get
            {
                return showPictureToolsCommand;
            }
        }

        /// <summary>
        /// Method used to execute the hidePictureToolsCommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        private void ExecuteHidePictureToolsCommand(object parameter)
        {
            IsGroupVisible = false;
        }

        /// <summary>
        /// Method used to execute the showPictureToolsCommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        private void ExecuteShowPictureToolsCommand(object parameter)
        {
            IsGroupVisible = true;
        }      
    }
}
