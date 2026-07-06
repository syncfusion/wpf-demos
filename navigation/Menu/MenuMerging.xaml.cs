
using Syncfusion.SfSkinManager;
using System;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Interaction logic for MenuMerging.xaml
    /// </summary>
    public partial class MenuMerging
    {
        public MenuMerging()
        {
            InitializeComponent();
            this.Unloaded += MenuMerging_Unloaded;
        }

        public MenuMerging(string themename)
        {
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });
            InitializeComponent();
            this.Unloaded += MenuMerging_Unloaded;
        }

        private void MenuMerging_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.menuGrid != null)
            {
                this.menuGrid.Children.Clear();
                this.menuGrid = null;
            }

            if (this.MDIView != null)
                this.MDIView = null;

            if (this.menuView != null)
                this.menuView = null;

            if (this.toolBarView != null)
                this.toolBarView = null;

            if (this.DataContext != null)
            {
                this.DataContext = null;
            }
            
            this.Unloaded -= MenuMerging_Unloaded;
        }
    }
}
