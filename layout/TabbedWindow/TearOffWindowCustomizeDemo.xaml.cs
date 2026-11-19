using syncfusion.layoutdemos.wpf.ViewModel;
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Controls;
using Syncfusion.Windows.Shared;
using System.Windows;
using System.Windows.Media;

namespace syncfusion.layoutdemos.wpf
{
    /// <summary>
    /// Interaction logic for TearOffWindowCustomizeDemo.xaml
    /// </summary>
    public partial class TearOffWindowCustomizeDemo : SfChromelessWindow
    {
        public TearOffWindowCustomizeDemo()
        {
            InitializeComponent();
        }

        private void MainTabControl_NewWindowCreating(object sender, NewWindowCreatingEventArgs e)
        {
            // Get the ViewModel from the window's DataContext
            var viewModel = this.DataContext as TearOffWindowCustomizationViewModel;
            if (viewModel == null)
            {
                e.Cancel = true;
                return;
            }
            
            // Access the SelectedWindowType through the WindowTypeSelector ViewModel
            string selectedWindowType = viewModel.WindowTypeSelector.SelectedWindowType;
            
            e.NewWindow = CreateWindowByType(selectedWindowType, e.NewWindow);
            SfSkinManager.SetTheme(e.NewWindow, SfSkinManager.GetTheme(this));
        }

        /// <summary>
        /// Factory method to create window based on selected type.
        /// </summary>
        private Window CreateWindowByType(string windowType, Window defaultWindow)
        {
             switch(windowType)
            {
                case "Custom Window":
                    return new CustomWindow(300, 600, windowType)
                    {
                        Topmost = true,
                        ResizeMode = ResizeMode.NoResize,
                        Background = Brushes.DarkSlateGray,
                        Foreground = Brushes.White,
                        Opacity = 0.95,
                        DataContext = this.DataContext,
                    };

                case "MS-Window":
                    return new Window()
                    {
                        Title = windowType,
                        Height = 400,
                        Width = 600,
                        Background = Brushes.WhiteSmoke,
                        DataContext = this.DataContext,
                    };

                case "SfChromelessWindow":
                default:
                    return defaultWindow;
            };
        }
    }

    public class CustomWindow : Window
    {
        public CustomWindow(double height, double width, string title)
        {
            this.Height = height;
            this.Width = width;
            this.Title = title;
        }
    }

}
