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
    /// <summary>
    /// Provides the static service for accessing key navigation-related components form anywhere in the application. This acts as a service locator for manuaging UI navigation.
    /// </summary>
    public static class DemosNavigationService
    {
        /// <summary>
        /// Gets or sets the primary content presenter for top-level navigation, such as swicthing between main product list and a specific product's demo page
        /// </summary>
        public static ContentPresenter RootNavigationService
        {
            get; 
            set;
        }


        /// <summary>
        /// Gets or sets the content presenter used for navigation between individual demos within a productpage.
        /// </summary>
        public static ContentPresenter DemoNavigationService
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets a static reference to the main window of the demo application.
        /// </summary>
        public static Window MainWindow { get; set; }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        /// <param name="viewModel">The main view model for the entire demo browser application</param>
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

    /// <summary>
    /// A custom <see cref="WindowAutomationPeer"/> that modifies the UI automation tree. This is used to hide the child elements of the window from UI automation clients.
    /// </summary>
    public class FakeWindowsPeer : WindowAutomationPeer
    {
        /// <summary>
        /// Intializes a new instance of the <see cref="FakeWindowsPeer"/> class.
        /// </summary>
        /// <param name="window">The  window to create a peer for.</param>
        public FakeWindowsPeer(Window window)
            : base(window)
        { }

        /// <summary>
        /// Overriden to return null, which effectively hides all child controls of the window from UI automation tools.
        /// </summary>
        /// <returns>A null list, preventing discovery of child elements.</returns>
        protected override List<AutomationPeer> GetChildrenCore()
        {
            return null;
        }
    }
}
