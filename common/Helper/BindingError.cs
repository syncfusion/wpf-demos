
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
            if (viewModel ==  null || viewModel.SelectedProduct == null || viewModel.SelectedSample == null)
            {
                return;
            }
            int selectedSampleIndex = 0;
            if (viewModel.SelectedSample.SubCategoryDemos == null)
            {
                selectedSampleIndex = viewModel.SelectedProduct.Demos.IndexOf(viewModel.SelectedSample);
            }
            int selectedProductIndex = viewModel.ProductDemos.IndexOf(viewModel.SelectedProduct);
            var timer = new DispatcherTimer();
            timer.Tick += DemoTimer_Tick;
            timer.Interval = TimeSpan.FromSeconds(6);
            foreach (DemoInfo demo in viewModel.SelectedProduct.Demos)
            {
                if (demo.ShowBusyIndicator)
                {
                    if(timer != null)
                    {
                        timer.Stop();
                        timer.Start();
                    }
                    isLiveDemo = true;
                    await timer.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        viewModel.SelectedSample = demo;
                        isLiveDemo = false;
                    }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);
                }
                else
                {
                    isLiveDemo = false;
                    viewModel.SelectedSample = demo;
                    ErrorLogging.LogLiveDemos( viewModel.SelectedProduct.Product + "\\" + demo.SampleName+ "\\ShowBusyIndicator set as false. Ensure to set as true, if this demo is not running anything in background always.");
                    await Task.Delay(6000);
                }
                if (viewModel.SelectedSample.SubCategoryDemos != null)
                {
                    viewModel.SelectedSample = demo;
                    for (int i = 1; i < viewModel.SelectedSample.SubCategoryDemos.Count; i++)
                    {
                        DemoInfo subDemo = viewModel.SelectedSample.SubCategoryDemos[i];
                        if (timer != null)
                        {
                            timer.Stop();
                            timer.Start();
                        }
                        isLiveDemo = true;
                        await timer.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            viewModel.SubCategorySelectedItem = subDemo;
                            isLiveDemo = false;
                        }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);                        
                    }
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
            if (viewModel == null)
            {
                return;
            }
            await Task.Delay(6000);
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
            if (viewModel == null)
            {
                return;
            }

            var timer = new DispatcherTimer();
            timer.Tick += ShowcaseDemoTimer_Tick;
            foreach (var demo in viewModel.ShowcaseDemos)
            {
                viewModel.SelectedShowcaseSample = demo;
                var showcasewindow = Activator.CreateInstance(demo.DemoViewType) as Window;
                showcasewindow.Show();
                if (demo.ShowBusyIndicator)
                {
                    if (timer != null)
                    {
                        timer.Stop();
                        timer.Start();
                    }
                    isLiveDemo = true;
                    timer.Interval = TimeSpan.FromSeconds(6);
                    await timer.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        isLiveDemo = false;
                        showcasewindow.Close();
                    }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);
                }
                else
                {
                    await Task.Delay(6000);
                    ErrorLogging.LogLiveDemos("Showcase\\"+ demo.SampleName+ "\\ShowBusyIndicator set as false. Ensure to set as true, if this demo is not running anything in background always.");
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
            if (viewModel == null || viewModel.SelectedProduct == null || viewModel.SelectedSample == null)
            {
                return;
            }

            try
            {
                if (isLiveDemo)
                {
                    if(viewModel.SelectedSample.ShowBusyIndicator)
                    {
                        ErrorLogging.LogLiveDemos(viewModel.SelectedProduct.Product + "\\" + viewModel.SelectedSample.SampleName + "\\Demo is not loaded after 60 secs also. Ensure to check and fix. This might be because after demo lauched application idle status not reached due to some other backgroud work in sample. Due to this busy indicator will get displayed always.");
                    }
                    int selectedSampleIndex = viewModel.SelectedProduct.Demos.IndexOf(viewModel.SelectedSample);
                    int sampleindex = selectedSampleIndex;
                    if (viewModel.SelectedProduct.Demos.Count > sampleindex + 1)
                    {
                        viewModel.SelectedSample = viewModel.SelectedProduct.Demos[selectedSampleIndex + 1];
                        if (viewModel.SelectedSample.DemoLauchMode == DemoLauchMode.Window)
                        {
                            LaunchDemo(viewModel.SelectedSample);
                        }
                    }

                    isLiveDemo = false;
                }
            }
            catch (Exception exception)
            {
                if (viewModel != null)
                {
                    if (viewModel.SelectedProduct != null && viewModel.SelectedSample != null)
                    {
                        ErrorLogging.LogError("Product Sample\\" + viewModel.SelectedProduct.Product + "\\" + viewModel.SelectedSample.SampleName + "@@" + "Assembly location details missing in app.config file, Please contact Syncfusion support." + exception.Message + "\n" + exception.StackTrace + "\n" + exception.Source);
                    }
                    else if (viewModel.SelectedShowcaseSample != null)
                    {
                        ErrorLogging.LogError("Product ShowCase\\" + viewModel.SelectedShowcaseSample.SampleName + "\\" + viewModel.SelectedShowcaseSample.SampleName + "@@" + "Assembly location details missing in app.config file, Please contact Syncfusion support." + exception.Message + "\n" + exception.StackTrace + "\n" + exception.Source);
                    }
                }
            }

        }


        /// <summary>
        /// Occurs when the showcase demos timer interval has elapsed.
        /// </summary>
        private static void ShowcaseDemoTimer_Tick(object sender, EventArgs e)
        {
            if (viewModel == null || viewModel.SelectedShowcaseSample == null)
            {
                return;
            }

            if (isLiveDemo)
            {
                CloseAllWindow();
                ErrorLogging.LogLiveDemos("Showcase\\" + viewModel.SelectedShowcaseSample.SampleName + "\\Demo is not loaded after 60 secs also. Ensure to check and fix. This might be because after demo lauched application idle status not reached due to some other backgroud work in sample. Due to this busy indicator will get displayed always.");
                isLiveDemo = false;
            }
        }

        /// <summary>
        /// Helps to launch window mode demos.
        /// </summary>
        private async static void LaunchDemo(DemoInfo demo)
        {
            if (viewModel == null || viewModel.SelectedProduct == null || viewModel.SelectedSample == null)
            {
                return;
            }

            try
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
                    await Task.Delay(6000);
                    ErrorLogging.LogLiveDemos(viewModel.SelectedProduct.Product + "\\" + viewModel.SelectedSample.SampleName + "\\ShowBusyIndicator set as false. Ensure to set as true, if this demo is not running anything in background always.");
                    window.Close();
                }
            }
            catch(Exception exception)
            {
                if (viewModel != null)
                {
                    if (viewModel.SelectedProduct != null && viewModel.SelectedSample != null)
                    {
                        ErrorLogging.LogError("Product Sample\\" + viewModel.SelectedProduct.Product + "\\" + viewModel.SelectedSample.SampleName + "@@" + "Assembly location details missing in app.config file, Please contact Syncfusion support." + exception.Message + "\n" + exception.StackTrace + "\n" + exception.Source);
                    }
                    else if (viewModel.SelectedShowcaseSample != null)
                    {
                        ErrorLogging.LogError("Product ShowCase\\" + viewModel.SelectedShowcaseSample.SampleName + "\\" + viewModel.SelectedShowcaseSample.SampleName + "@@" + "Assembly location details missing in app.config file, Please contact Syncfusion support." + exception.Message + "\n" + exception.StackTrace + "\n" + exception.Source);
                    }
                }
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

        /// <summary>
        /// Helps to log the Binding Error
        /// </summary>
        internal static void OnBindingError(string errorMessage, DemoBrowserViewModel viewModel)
        {
            if (viewModel.SelectedProduct != null && viewModel.SelectedSample != null)
            {
                ErrorLogging.LogBindingError(viewModel.SelectedProduct.Product + "\\" + viewModel.SelectedSample.SampleName + "\\" + errorMessage);
            }
            else if (viewModel.SelectedShowcaseSample != null)
            {
                ErrorLogging.LogBindingError("Showcase\\" + viewModel.SelectedShowcaseSample.SampleName + "\\" + errorMessage);
            }
            else
                ErrorLogging.LogBindingError(errorMessage);
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
