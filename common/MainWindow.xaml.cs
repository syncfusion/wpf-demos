#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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
using System.Windows.Automation.Peers;
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
                BindingErrorListener.Listen(errorMessage => BindingErrorAutomation.OnBindingError(errorMessage, viewModel));
            }
#endif
            InitializeComponent();
            this.DataContext = viewModel;
            DemosNavigationService.MainWindow = this;
            DemosNavigationService.RootNavigationService = this.ROOTFRAME.NavigationService;
            DemosNavigationService.RootNavigationService.Navigate(new ProductsListView() { DataContext = viewModel });
            this.ROOTFRAME.NavigationService.Navigated += NavigationService_Navigated;
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

        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new FakeWindowsPeer(this);
        }
    }

    public class FakeWindowsPeer : WindowAutomationPeer
    {
        public FakeWindowsPeer(Window window)
            : base(window)
        { }
        protected override List<AutomationPeer> GetChildrenCore()
        {
            return null;
        }
    }
}
