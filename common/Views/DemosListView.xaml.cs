using Syncfusion.SfSkinManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// Interaction logic for DemoView.xaml
    /// </summary>
    public partial class DemosListView : UserControl
    {
        public DemosListView()
        {
            InitializeComponent();
            if(DemoBrowserViewModel.IsIOSDKSample)
            {
                AllProducts.Visibility = Visibility.Collapsed;
            }
            DemosNavigationService.DemoNavigationService = this.DEMOSFRAME;
            //this.DEMOSFRAME.Navigated += DEMOSFRAME_Navigated;
            this.Unloaded += DemosListView_Unloaded;
            this.DataContextChanged += DemosListView_DataContextChanged;
        }

        private DemoBrowserViewModel viewModel = null;
        private void DemosListView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            viewModel = this.DataContext as DemoBrowserViewModel;
            if (viewModel != null)
            {
                viewModel.ThemeChanged = ThemeChanged;
            }
        }

        /// <summary>
        /// This method is used to remove the border of the items in  themepanel on mousehover for FluentTheme
        /// </summary>
        private void ThemeChanged()
        {
            if (viewModel.SelectedThemeName.Contains("Fluent"))
            {
                SfSkinManager.SetTheme(ThemePanel, new FluentTheme() { ThemeName = viewModel.SelectedThemeName, HoverEffectMode = HoverEffect.Background });
            }
            else
            {
                SfSkinManager.SetTheme(ThemePanel, Syncfusion.SfSkinManager.Theme.GetTheme(viewModel.SelectedThemeName));
            }
        }

        private void DemosListView_Unloaded(object sender, RoutedEventArgs e)
        {
            //this.DEMOSFRAME.Navigated -= DEMOSFRAME_Navigated;
            this.Unloaded -= DemosListView_Unloaded;
            this.DataContextChanged -= DemosListView_DataContextChanged;
            if (ThemeList != null)
            {
                ThemeList.RemoveHandler(MouseWheelEvent, new RoutedEventHandler(mousehandler));
            }
            if (PaletteList != null)
            {
                PaletteList.RemoveHandler(MouseWheelEvent, new RoutedEventHandler(mousehandler));
            }
            this.DEMOSFRAME = null;
        }

        /// <summary>
        ///  Occurs when the content that is being navigated to has been found
        /// </summary>
        private void DEMOSFRAME_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            //this.DEMOSFRAME.RemoveBackEntry();
        }

        private void scrollviewver_Loaded(object sender, RoutedEventArgs e)
        {
            ThemeList.AddHandler(MouseWheelEvent, new RoutedEventHandler(mousehandler), true);
            PaletteList.AddHandler(MouseWheelEvent, new RoutedEventHandler(mousehandler), true);

        }
        /// <summary>
        /// This  handler is used for scrolling the Items in themePanel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mousehandler(object sender, RoutedEventArgs e)
        {
            MouseWheelEventArgs eargs = (MouseWheelEventArgs)e;

            double x = (double)eargs.Delta;

            double y = ThemePanelScrollViewer.VerticalOffset;

            ThemePanelScrollViewer.ScrollToVerticalOffset(y - x);
        }

        /// <summary>
        /// This event handler assigns a command (viewModel.NavigateAllProductsCommand) to the button's command property when the left mouse button is released 
        /// and executes the command if it is not null and can be executed.
        /// /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAllProductsPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RepeatButton button = (RepeatButton)sender;
            ICommand command = button.Command = viewModel.NavigateAllProductsCommand;
            if (command != null && command.CanExecute(null) && button.IsPressed)
            {
                command.Execute(null);
            }
        }
    }
}
