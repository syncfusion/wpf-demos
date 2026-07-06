using Syncfusion.Windows.Shared;
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.workfloweditor.wpf
{
    /// <summary>
    /// Interaction logic for WorkFlowEditorDemo.xaml
    /// </summary>
    public partial class WorkFlowEditorDemo : ChromelessWindow
    {
        public WorkFlowEditorDemo()
        {
            InitializeComponent();            
            this.Template = this.Resources["ChromelessWindowTemplate"] as ControlTemplate;

            //DataContext for syncfusion.workfloweditor.wpf
            ProcessAutomationViewModel VM = new ProcessAutomationViewModel();
            VM.GoBack = new DelegateCommand<object>(OnGoBack);
            VM.MinimizeCommand = new DelegateCommand<object>(OnMinimize);
            VM.ToggleMaximizeCommand = new DelegateCommand<object>(OnToggleMaximize);
            VM.CloseWindowCommand = new DelegateCommand<object>(OnCloseWindow);
            this.DataContext = VM;
        }

        private void OnGoBack(object parameter)
        {
            ProcessAutomationViewModel VM = this.DataContext as ProcessAutomationViewModel;
            VM.GoBack = null;
            this.DataContext = null;            
        }

        /// <summary>
        /// Represents a method to minimize the workflow editor window.
        /// </summary>
        private void OnMinimize(object parameter)
        {
            this.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Represents a method to toggle the workflow editor window between maximized and normal state.
        /// </summary>
        private void OnToggleMaximize(object parameter)
        {
            this.WindowState = this.WindowState == WindowState.Maximized
                ? WindowState.Normal
                : WindowState.Maximized;
        }

        /// <summary>
        /// Represents a method to close the workflow editor window.
        /// </summary>
        private void OnCloseWindow(object parameter)
        {
            this.Close();
        }
    }
}
