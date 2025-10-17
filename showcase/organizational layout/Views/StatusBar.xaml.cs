using Syncfusion.SfSkinManager;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.organizationallayout.wpf
{
    /// <summary>
    /// Interaction logic for StatusBar.xaml
    /// </summary>
    public partial class StatusBar : UserControl
    {
        public StatusBar()
        {
            InitializeComponent();
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = "FluentLight" });
        }
        private void Text_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock text = sender as TextBlock;
            if (text != null)
            {
                ZoomPanWindow zoomWindow = new ZoomPanWindow();
                zoomWindow.DataContext = this.DataContext;
                zoomWindow.ShowDialog();
            }
        }

    }
}
