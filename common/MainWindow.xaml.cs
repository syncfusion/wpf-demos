using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Navigation;
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Shared;

namespace syncfusion.demoscommon.wpf
{
    public static class DemosNavigationService
    {
        public static ContentPresenter RootNavigationService
        {
            get; 
            set;
        }

        public static ContentPresenter DemoNavigationService
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
            SfSkinManager.ApplyThemeAsDefaultStyle = true;
            InitializeComponent();
            txtTitleName.Inlines.Add(DemoBrowserViewModel.HeaderTitleText);
            this.DataContext = viewModel;
            AISettings.DemoBrowserViewModel = viewModel;
            DemosNavigationService.MainWindow = this;
            ValidateCrendentials();
            DemosNavigationService.RootNavigationService = this.ROOTFRAME;
            DemosNavigationService.RootNavigationService.Content = (new ProductsListView() { DataContext = viewModel });
            //DemosNavigationService.RootNavigationService.DataContextChanged += RootNavigationService_DataContextChanged;
            //this.ROOTFRAME.NavigationService.Navigated += NavigationService_Navigated;
        }

        /// <summary>
        /// Helps to validate AI Credentials.
        /// </summary>
        private void ValidateCrendentials()
        {
            AISettings.DemoBrowserViewModel.ModelName = AISettings.ModelName;
            AISettings.DemoBrowserViewModel.Key = AISettings.Key;
            AISettings.DemoBrowserViewModel.EndPoint = AISettings.EndPoint;
            Task.Run(async () =>
            {
                await AISettings.ValidateCredentials();
            });
        }

        /// <summary>
        ///  Occurs when the content that is being navigated to has been found
        /// </summary>
        //private void NavigationService_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        //{
        //    if (DemosNavigationService.RootNavigationService.CanGoForward)
        //    {
        //        (this.DataContext as DemoBrowserViewModel).SelectedProduct = null;
        //    }
        //}

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
