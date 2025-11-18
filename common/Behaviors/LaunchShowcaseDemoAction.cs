#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;

namespace syncfusion.demoscommon.wpf
{
  
    /// <summary>
    /// Represents a trigger action that launches a showcase demo when invoked. Typically associated with a ListView control.
    /// </summary>
    public class LaunchShowcaseDemoAction : TriggerAction<ListView>
    {
        /// <summary>
        /// Invokes the action, launching the selected showcase demo in a new window.
        /// </summary>
        /// <param name="parameter">The parameter passed to the action.</param>
        protected override async void Invoke(object parameter)
        {
            if (this.AssociatedObject == null)
                return;

            var viewmodel = this.AssociatedObject.DataContext as DemoBrowserViewModel;
            if (viewmodel == null)
                return;
            if (AssociatedObject != null && AssociatedObject.SelectedItem is DemoInfo && viewmodel != null)
            {
                try
                {
                    DemoInfo demo = AssociatedObject.SelectedItem as DemoInfo;
                    if (demo.ShowBusyIndicator)
                    {
                        viewmodel.IsShowCaseDemoBusy = true;
                    }
                    var window = Activator.CreateInstance(demo.DemoViewType) as Window;
                    window.Loaded += Window_Loaded;
                    window.Closing += Window_Closing;
                    viewmodel.SelectedShowcaseSample = demo;
                    AssociatedObject.SelectedItem = null;

                    await Task.Delay(100);
                    viewmodel.IsShowCaseDemoBusy = false;
                    if (window != null)
                    {
                        window.Owner = DemosNavigationService.MainWindow;
                        window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                        window.Closed += Window_Closed;
                        window.ShowDialog();
                    }
                }
                catch (Exception exception)
                {
                    viewmodel.IsShowCaseDemoBusy = false;
                    if (viewmodel != null)
                    {
                        if (viewmodel.SelectedProduct != null && viewmodel.SelectedSample != null)
                        {
                            ErrorLogging.LogError("Product Sample\\" + viewmodel.SelectedProduct.Product + "\\" + viewmodel.SelectedSample.SampleName + "@@" + exception.Message + "\n" + exception.StackTrace + "\n" + exception.Source);
                        }
                        else if (viewmodel.SelectedShowcaseSample != null)
                        {
                            ErrorLogging.LogError("Product ShowCase\\" + viewmodel.SelectedShowcaseSample.SampleName + "\\" + viewmodel.SelectedShowcaseSample.SampleName + "@@" + exception.Message + "\n" + exception.StackTrace + "\n" + exception.Source);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handled the Closing event of the demo window. Removes the blur effect from the main window. 
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Contains the event data.</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var window = DemosNavigationService.MainWindow;
            window.Effect = null;
            var viewModel = window.DataContext as DemoBrowserViewModel;
            viewModel.BlurVisibility = Visibility.Collapsed;
            window.Loaded -= Window_Loaded;
            window.Closing -= Window_Closing;
        }

        /// <summary>
        /// Handled the Loaded event of the demo window. Applying a blur effect from the main window. 
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Contains the event data.</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var mainWindow = DemosNavigationService.MainWindow;
            mainWindow.Effect = new BlurEffect() { RenderingBias = RenderingBias.Quality, KernelType = KernelType.Gaussian, Radius = 5 };
            var viewModel = mainWindow.DataContext as DemoBrowserViewModel;
            viewModel.BlurVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Occurs when the window is about to close. 
        /// </summary>
        private void Window_Closed(object sender, EventArgs e)
        {
            (sender as Window).Closed -= Window_Closed;
            (sender as Window).Owner = null;
        }
    }
}
