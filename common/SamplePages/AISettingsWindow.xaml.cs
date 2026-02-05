#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
        /// <summary>
        /// Initializes a new instance of the <see cref="AISettingsWindow"/> class.
        /// </summary>
        public AISettingsWindow()
        {
            InitializeComponent();
            
        }
        
        /// <summary>
        /// A reference to the main view model used for data binding and state management.
        /// </summary>
        private DemoBrowserViewModel viewModel = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AISettingsWindow"/> class with a specific view model.
        /// </summary>
        /// <param name="demoBrowserViewModel">the view model instance that this window will bind to.</param>
        public AISettingsWindow(DemoBrowserViewModel demoBrowserViewModel)
        {
            InitializeComponent();
            this.DataContext = demoBrowserViewModel;
            viewModel = demoBrowserViewModel;
        }

        /// <summary>
        /// Handles the click event for the buttons in the window.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguement.</param>
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

        /// <summary>
        /// Handles the local event of the window. Applies a blur effect to the main application window to give a model appearance
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguement.</param>
        private void ChromelessWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var mainWindow = DemosNavigationService.MainWindow;
            mainWindow.Effect = new BlurEffect() { RenderingBias = RenderingBias.Quality, KernelType = KernelType.Gaussian, Radius = 5 };
            var viewModel = mainWindow.DataContext as DemoBrowserViewModel;
            viewModel.BlurVisibility = Visibility.Visible;

        }

        /// <summary>
        /// Handles the Closing event of the window. Removes the blur effect from the owner window.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguement.</param>
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

        /// <summary>
        /// Handles the Closed event of the window. Resets view model properties to their original state and cleans up resource.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguement.</param>
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
