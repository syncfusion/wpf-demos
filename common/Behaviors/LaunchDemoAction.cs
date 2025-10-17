using Microsoft.Xaml.Behaviors;
using Syncfusion.SfSkinManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.demoscommon.wpf
{
    public static class DemoLaucherExtension
    {
        public static T LauchDemo<T>(DemoBrowserViewModel viewmodel, DemoInfo demoInfo) where T : DependencyObject
        {
            T demo = null;
            var constructorInfo = demoInfo.DemoViewType?.GetConstructors().FirstOrDefault(cinfo => cinfo.IsPublic && cinfo.GetParameters().Length == 1 && cinfo.GetParameters()[0].Name == "themename");
            if (demoInfo.ThemeMode != ThemeMode.None && constructorInfo != null)
            {
                demo = Activator.CreateInstance(demoInfo.DemoViewType,
                    demoInfo.ThemeMode == ThemeMode.Inherit ? viewmodel.SelectedThemeName : DemoBrowserViewModel.DefaultThemeName) as T;
            }
            else if(demoInfo.DemoViewType != null)
            {
                demo = Activator.CreateInstance(demoInfo.DemoViewType) as T;
                if (demoInfo.ThemeMode == ThemeMode.Inherit)
                {
                    SfSkinManager.SetTheme(demo, Theme.GetTheme(viewmodel.SelectedThemeName));
                }
                else if (demoInfo.ThemeMode == ThemeMode.Default)
                {
                    SfSkinManager.SetTheme(demo, Theme.GetTheme(DemoBrowserViewModel.DefaultThemeName));
                }
            }
            return demo;
        }
    }

    public class LaunchDemoAction : TriggerAction<Button>
    {
        protected override void Invoke(object parameter)
        {
            if (this.AssociatedObject == null)
                return;

            var viewmodel = this.AssociatedObject.DataContext as DemoBrowserViewModel;
            if (viewmodel == null)
                return;

            if ((viewmodel.SelectedProduct != null && viewmodel.SelectedProduct.DemoLauchMode == DemoLauchMode.Window)
                || (viewmodel.SelectedSample != null && viewmodel.SelectedSample.DemoLauchMode == DemoLauchMode.Window))
            {
                try
                {
                    if (viewmodel.SelectedSample.ShowBusyIndicator)
                    {
                        viewmodel.IsProductDemoBusy = true;
                    }
                    var window = DemoLaucherExtension.LauchDemo<Window>(viewmodel, viewmodel.SelectedSample);
                    DemosNavigationService.MainWindow.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        viewmodel.IsProductDemoBusy = false;
                    }),
                     System.Windows.Threading.DispatcherPriority.ApplicationIdle);

                    if (window != null)
                    {
                        window.Title = viewmodel.SelectedSample.Title;
                        window.Owner = DemosNavigationService.MainWindow;
                        window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                        window.Closed += Window_Closed;
                        window.ShowDialog();
                    }
                }
                catch (Exception exception)
                {
                    viewmodel.IsProductDemoBusy = false;
                    ErrorWindow.Show(exception.Message + "\n" + exception.StackTrace);
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            (sender as Window).Closed -= Window_Closed;
            (sender as Window).Owner = null;
            if (this.AssociatedObject != null)
                return;

            var viewmodel = this.AssociatedObject.DataContext as DemoBrowserViewModel;
            if (viewmodel == null)
                return;

            viewmodel.SelectedProduct = null;
            viewmodel.SelectedSample = null;
        }
    }
}
