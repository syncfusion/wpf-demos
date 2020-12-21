#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;

namespace syncfusion.demoscommon.wpf
{
    public static class DemosNavigationService
    {
        public static NavigationService RootNavigationService
        {
            get; 
            set;
        }

        public static NavigationService DemoNavigationService
        {
            get;set;
        }

        public static Window MainWindow { get; set; }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow(DemoBrowserViewModel viewModel)
        {
#if DEBUG
            if (DemoBrowserViewModel.CanAutomate)
            {
                BindingErrorListener.Listen(errorMessage => OnBindingError(errorMessage, viewModel));
            }
#endif
            InitializeComponent();
            this.DataContext = viewModel;
            DemosNavigationService.MainWindow = this;
            DemosNavigationService.RootNavigationService = this.ROOTFRAME.NavigationService;
            DemosNavigationService.RootNavigationService.Navigate(new ProductsListView() { DataContext = viewModel });
            this.ROOTFRAME.NavigationService.Navigated += NavigationService_Navigated;
            this.Loaded += MainWindow_Loaded;
            
        }


#if DEBUG
        /// <summary>
        /// Helps to log the Binding Error
        /// </summary>
        private void OnBindingError(string errorMessage, DemoBrowserViewModel viewModel)
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
#endif

        /// <summary>
        ///  Occurs when the element is laid out, rendered, and ready for interaction.
        /// </summary>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.TitleBar.MouseDown += TitleBar_MouseDown;
        }

        /// <summary>
        /// Occurs when any mouse button is pressed while the pointer is over this element.
        /// </summary>
        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        ///  Occurs when the content that is being navigated to has been found
        /// </summary>
        private void NavigationService_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (DemosNavigationService.RootNavigationService.CanGoForward)
            {
                (this.DataContext as DemoBrowserViewModel).SelectedProduct = null;
            }
        }
    }
}
