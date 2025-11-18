#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
    /// <summary>
    /// A static class that contains the extension methods for launching demos.
    /// </summary>
    public static class DemoLaucherExtension
    {
        /// <summary>
        /// Launches a demos of a specific file.
        /// </summary>
        /// <typeparam name="T">The type of the demo to launch.</typeparam>
        /// <param name="viewmodel">The viewmodel for the demo launcher.</param>
        /// <param name="demoInfo">Information about the demo to launch.</param>
        /// <returns>Launch demo</returns>
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

    /// <summary>
    /// A trigger action that launches a demo when a button is clicked.
    /// </summary>
    public class LaunchDemoAction : TriggerAction<Button>
    {
        /// <summary>
        /// Invokes the action.
        /// </summary>
        /// <param name="parameter">The paramter of the action.</param>
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

        /// <summary>
        /// Handled the Closed event of the window
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguement.</param>
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
