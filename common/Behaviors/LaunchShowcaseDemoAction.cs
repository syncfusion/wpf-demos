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
  
    public class LaunchShowcaseDemoAction : TriggerAction<ListView>
    {
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var window = DemosNavigationService.MainWindow;
            window.Effect = null;
            var viewModel = window.DataContext as DemoBrowserViewModel;
            viewModel.BlurVisibility = Visibility.Collapsed;
            window.Loaded -= Window_Loaded;
            window.Closing -= Window_Closing;
        }

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
