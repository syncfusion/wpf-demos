using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// Interaction logic for ProductDemosWindow.xaml
    /// </summary>
    public partial class ProductDemosWindow : ChromelessWindow
    {
        public ProductDemosWindow(DemoBrowserViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
            this.Loaded += ChromelessWindow_Loaded;
            if (DemoBrowserViewModel.IsIOSDKSample)
            {
                this.Title = DemoBrowserViewModel.HeaderTitleText;
            }
            else
            {
                this.Title = viewModel.SelectedProduct.Product + " Demos";
            }
            if (DemosNavigationService.MainWindow?.Width < this.Width ||
                 DemosNavigationService.MainWindow?.Height < this.Height)
            {
                this.Width = DemosNavigationService.MainWindow.Width * 0.95;
                this.Height = DemosNavigationService.MainWindow.Height * 0.95;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            var navigationService = DemosNavigationService.DemoNavigationService;
            var window = DemosNavigationService.MainWindow;
            if (window != null) 
            window.Effect = null;
            var viewModel = this.DataContext as DemoBrowserViewModel;
            if (viewModel != null)
            {
               viewModel.BlurVisibility = Visibility.Collapsed;
            }
           
            if (navigationService != null && navigationService.Content != null)
            {
                var demoControl = navigationService.Content as DemoControl;
                if (demoControl != null)
                {
                    demoControl.Dispose();
                    SfSkinManager.Dispose(demoControl);
                }
            }
            DemosNavigationService.DemoNavigationService = null;
            if (viewModel != null)
            {
                viewModel.SelectedProduct = null;
                viewModel.SelectedSample = null;
                viewModel.ThemePanelVisibility = false;
                viewModel.ThemeChanged = null;
                viewModel.SelectedTheme = null;
                viewModel.SelectedPalette = null;
                viewModel.TitleBarBackground = null;
                viewModel.TitleBarForeground = null;
                viewModel.SelectedDemo = null;
            }
            if (this.TitleBarTemplate != null)
                this.TitleBarTemplate = null;
            this.DataContext = null;
            DemosNavigationService.MainWindow.Activate();
            SfSkinManager.Dispose(this);
            base.OnClosing(e);
        }

        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new FakeWindowsPeer(this);
        }

        public void ChromelessWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var mainWindow = DemosNavigationService.MainWindow;
            if (mainWindow is MainWindow)
            {
                mainWindow.Effect = new BlurEffect() { RenderingBias = RenderingBias.Quality, KernelType = KernelType.Gaussian, Radius = 5 };
                var viewModel = this.DataContext as DemoBrowserViewModel;
                viewModel.BlurVisibility = Visibility.Visible;
            }
        }
    }

}
