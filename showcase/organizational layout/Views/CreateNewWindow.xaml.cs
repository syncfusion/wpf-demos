using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Shared;
using System.Windows;

namespace syncfusion.organizationallayout.wpf
{
    /// <summary>
    /// Interaction logic for CreateNewWindow.xaml
    /// </summary>
    public partial class CreateNewWindow : ChromelessWindow
    {
        public CreateNewWindow()
        {
            InitializeComponent();
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = "FluentLight" });

            this.txtFileName.Focus();
            this.txtFileName.SelectionStart = 0;
            this.txtFileName.SelectionLength = this.txtFileName.Text.Length;
        }

        public string FileName { get; set; }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.FileName = txtFileName.Text;
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
