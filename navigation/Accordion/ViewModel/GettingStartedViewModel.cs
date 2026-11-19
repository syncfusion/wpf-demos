using syncfusion.demoscommon.wpf;
using System.Windows;
using System.Windows.Input;

namespace syncfusion.navigationdemos.wpf
{
    public class GettingStartedViewModel 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GettingStartedViewModel" /> class.
        /// </summary>    
        public GettingStartedViewModel()
        {
            DownloadCommand = new DelegateCommand(Execute);
        }

        /// <summary>
        /// Command implementation for download button in accordion <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand DownloadCommand { get; set; }

        /// <summary>
        /// Method which is used to implement button action.
        /// </summary>
        /// <param name="parameter">Button to show the action.</param>
        public void Execute(object parameter)
        {
            MessageBox.Show("Click operation has been performed.");
        }
    }
}
