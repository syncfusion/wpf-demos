#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace syncfusion.demoscommon.wpf
{
#if DEBUG

    /// <summary>
    /// Automate the binding error while sample loading.
    /// </summary>
    public class BindingErrorAutomation
    {

        /// <summary>
        /// Gets or sets the value indicating whether the  tutorial or showcase demos are live demos or not.
        /// </summary>
        private static bool isLiveDemo = false;

        /// <summary>
        /// Maintains view model refference
        /// </summary>
        private static DemoBrowserViewModel viewModel = null;

        /// <summary>
        /// Helps to run the binding error log automation
        /// </summary>
        internal static void RunBindingErrorAutomation(DemoBrowserViewModel demoBrowserViewModel)
        {

            if (demoBrowserViewModel == null)
                return;
            viewModel = demoBrowserViewModel;
            LaunchShowCaseDemo();

        }

        /// <summary>
        /// Helps to update the selected sample
        /// </summary>
        internal async static void UpdateSelectedSample()
        {
            if (viewModel.SelectedProduct == null || viewModel.SelectedSample == null)
            {
                return;
            }
            int selectedSampleIndex = viewModel.SelectedProduct.Demos.IndexOf(viewModel.SelectedSample);
            int selectedProductIndex = viewModel.ProductDemos.IndexOf(viewModel.SelectedProduct);
            var timer = new DispatcherTimer();
            timer.Tick += DemoTimer_Tick;
            timer.Interval = TimeSpan.FromSeconds(5);
            foreach (DemoInfo demo in viewModel.SelectedProduct.Demos)
            {
                if (demo.ShowBusyIndicator)
                {
                    timer.Start();
                    isLiveDemo = true;
                    await timer.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        isLiveDemo = false;
                        viewModel.SelectedSample = demo;
                    }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);
                }
                else
                {
                    viewModel.SelectedSample = demo;
                    ErrorLogging.LogLiveDemos( viewModel.SelectedProduct.Product + "\\" + viewModel.SelectedSample.SampleName+ "\\" + "Live Demos");
                    await Task.Delay(4000);
                }
                if (viewModel.SelectedProduct != null)
                {
                    if (viewModel.SelectedSample.DemoLauchMode == DemoLauchMode.Window)
                    {
                        LaunchDemo(demo);
                    }
                    if (selectedSampleIndex == viewModel.SelectedProduct.Demos.Count - 1)
                    {
                        UpdateSelectedProduct(viewModel, selectedProductIndex);
                    }
                    selectedSampleIndex++;
                }
                isLiveDemo = false;
                timer.Stop();
            }

            if (selectedProductIndex == viewModel.ProductDemos.Count - 1)
            {
                viewModel = null;
                Application.Current.Shutdown();
            }
        }

        /// <summary>
        /// Helps to update the selected product
        /// </summary>
        private async static void UpdateSelectedProduct(DemoBrowserViewModel viewModel, int selectedProductIndex)
        {
            await Task.Delay(4000);
            if (viewModel.ProductDemos.Count > selectedProductIndex + 1)
            {
                CloseAllWindow();
                viewModel.SelectedProduct = viewModel.ProductDemos[selectedProductIndex + 1];
            }
        }

        /// <summary>
        /// Helps to launch show demos .
        /// </summary>
        private async static void LaunchShowCaseDemo()
        {
            var timer = new DispatcherTimer();
            timer.Tick += ShowcaseDemoTimer_Tick;
            foreach (var demo in viewModel.ShowcaseDemos)
            {
                viewModel.SelectedShowcaseSample = demo;
                var showcasewindow = Activator.CreateInstance(demo.DemoViewType) as Window;
                showcasewindow.Show();
                if (demo.ShowBusyIndicator)
                {
                    timer.Start();
                    isLiveDemo = true;
                    timer.Interval = TimeSpan.FromSeconds(5);
                    await timer.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        isLiveDemo = false;
                        showcasewindow.Close();
                    }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);
                }
                else
                {
                    await Task.Delay(4000);
                    ErrorLogging.LogLiveDemos("Showcase\\"+ demo.SampleName+"\\"+ "Live Demos");
                    showcasewindow.Close();
                }
                isLiveDemo = false;
                timer.Stop();
            }

            if (viewModel.ProductDemos.Count > 0)
                viewModel.SelectedProduct = viewModel.ProductDemos[0];

        }

        /// <summary>
        /// Occurs when the tutorial demos timer interval has elapsed.
        /// </summary>
        private static void DemoTimer_Tick(object sender, EventArgs e)
        {
            if (isLiveDemo && viewModel != null)
            {
                int selectedSampleIndex = viewModel.SelectedProduct.Demos.IndexOf(viewModel.SelectedSample);
                if (viewModel.SelectedProduct.Demos.Count > selectedSampleIndex + 1)
                    viewModel.SelectedSample = viewModel.SelectedProduct.Demos[selectedSampleIndex + 1];
                if (viewModel.SelectedProduct != null && viewModel.SelectedSample != null)
                {
                    ErrorLogging.LogLiveDemos(viewModel.SelectedProduct.Product + "\\" + viewModel.SelectedSample.SampleName +  "\\Live Demos with BusyIndicator");
                }
                isLiveDemo = false;
            }
        }


        /// <summary>
        /// Occurs when the showcase demos timer interval has elapsed.
        /// </summary>
        private static void ShowcaseDemoTimer_Tick(object sender, EventArgs e)
        {
            if (isLiveDemo)
            {
                CloseAllWindow();
                if (viewModel != null && viewModel.SelectedShowcaseSample !=null )
                {
                    ErrorLogging.LogLiveDemos("Showcase\\" + viewModel.SelectedShowcaseSample.SampleName + "\\Live Demos with BusyIndicator");
                }
                isLiveDemo = false;
            }
        }

        /// <summary>
        /// Helps to launch window mode demos.
        /// </summary>
        private async static void LaunchDemo(DemoInfo demo)
        {
            var window = DemoLaucherExtension.LauchDemo<Window>(viewModel, demo);
            window.Show();
            if (demo.ShowBusyIndicator)
            {
                await DemosNavigationService.MainWindow.Dispatcher.BeginInvoke(new Action(() =>
                {
                    window.Close();
                }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);
            }
            else
            {
                await Task.Delay(4000);
                if (viewModel != null && viewModel.SelectedProduct != null && viewModel.SelectedSample != null)
                {
                    ErrorLogging.LogLiveDemos(viewModel.SelectedProduct.Product + "\\" + viewModel.SelectedSample.SampleName + "\\Live Demos");
                }
                window.Close();
            }
        }

        /// <summary>
        /// Helps to close the application windows
        /// </summary>
        private static void CloseAllWindow()
        {
            var Windows = Application.Current.Windows;
            foreach (Window window in Windows)
            {
                if (!(window is MainWindow))
                {
                    window.Close();
                }
            }
        }
      
    }

    /// <summary>
    ///  Trace the binding errors occurs in the application.
    /// </summary>
    public class BindingErrorListener : TraceListener
    {
        private Action<string> LogError;
        public static void Listen(Action<string> actionLog)
        {
            BindingErrorListener bindingErrorListener = new BindingErrorListener();
            bindingErrorListener.LogError = actionLog;
            PresentationTraceSources.DataBindingSource.Listeners.Add(bindingErrorListener);
        }
        public override void Write(string message) { }
        public override void WriteLine(string message)
        {
            LogError(message);
        }
    }
#endif
}
