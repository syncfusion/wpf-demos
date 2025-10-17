using Syncfusion.Windows.Shared;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Effects;

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// Interaction logic for AISettingsWindow.xaml
    /// </summary>
    public partial class AISettingsWindow : ChromelessWindow
    {
        public AISettingsWindow()
        {
            InitializeComponent();
            
        }
        
        private DemoBrowserViewModel viewModel = null;
        
        public AISettingsWindow(DemoBrowserViewModel demoBrowserViewModel)
        {
            InitializeComponent();
            this.DataContext = demoBrowserViewModel;
            viewModel = demoBrowserViewModel;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if((sender as Button).Name == "CancelButton")
            {
                this.Close();
                return;
            }

            try
            {
                viewModel.IsAISettingsWindowBusy = true;
                await AISettings.ValidateCredentials();
                viewModel.IsAISettingsWindowBusy = false;
                if (string.IsNullOrEmpty(AISettings.ErrorMessage))
                {
                    MessageBox.Show("Successfully entered valid input.", "Success", MessageBoxButton.OK);
                    Button button = sender as Button;
                    ICommand command = button.Command = viewModel.ClickCommand;
                    if (command != null && command.CanExecute("Submit"))
                    {
                        command.Execute("Submit");
                    }
                }
                else
                {
                    MessageBox.Show(AISettings.ErrorMessage, "Error", MessageBoxButton.OK);
                }
            }
            catch 
            {
                viewModel.IsAISettingsWindowBusy = false;
            }
        }

        private void ChromelessWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var mainWindow = DemosNavigationService.MainWindow;
            mainWindow.Effect = new BlurEffect() { RenderingBias = RenderingBias.Quality, KernelType = KernelType.Gaussian, Radius = 5 };
            var viewModel = mainWindow.DataContext as DemoBrowserViewModel;
            viewModel.BlurVisibility = Visibility.Visible;

        }

        private void ChromelessWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var mainWindow = DemosNavigationService.MainWindow;
            var viewModel = mainWindow.DataContext as DemoBrowserViewModel;

            Window productDemoWindow = null;
            WindowCollection windows = Application.Current.Windows;
            foreach (Window window in windows)
            {
                if (window is ProductDemosWindow)
                {
                    productDemoWindow = window as Window;
                }
            }

            if (productDemoWindow != null && productDemoWindow.IsVisible && mainWindow != productDemoWindow)
            {
                mainWindow.Effect = new BlurEffect() { RenderingBias = RenderingBias.Quality, KernelType = KernelType.Gaussian, Radius = 5 };
                viewModel.BlurVisibility = Visibility.Visible;
            }
            else
            {
                mainWindow.Effect = null;
                viewModel.BlurVisibility = Visibility.Collapsed;
                mainWindow.Loaded -= ChromelessWindow_Loaded;
                mainWindow.Closing -= ChromelessWindow_Closing;
            }

        }

        private void ChromelessWindow_Closed(object sender, System.EventArgs e)
        {
            viewModel.ModelName = AISettings.ModelName;
            viewModel.Key = AISettings.Key;
            viewModel.EndPoint = AISettings.EndPoint;
            viewModel.IsAISettingsWindowBusy = false;
            (sender as ChromelessWindow).Closed -= ChromelessWindow_Closed;
            (sender as ChromelessWindow).Owner = null;
        }
    }
}
