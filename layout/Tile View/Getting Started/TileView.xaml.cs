using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;
using System.Windows.Data;

namespace syncfusion.layoutdemos.wpf
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class TileViewDemo : DemoControl
    {
        public TileViewDemo()
        {
            InitializeComponent();
        }
        public TileViewDemo(string themename):base(themename)
        {
            InitializeComponent();
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = "Windows11Light" });
        }

        protected override void Dispose(bool disposing)
        {
            if (this.AnimationTimeSpan != null)
            {
                this.AnimationTimeSpan.Dispose();
                this.AnimationTimeSpan = null;
            }

            if (this.columnIntegerTextBox != null)
            {
                this.columnIntegerTextBox.Dispose();
                this.columnIntegerTextBox = null;
            }

            if (this.rowIntegerTextBox != null)
            {
                this.rowIntegerTextBox.Dispose();
                this.rowIntegerTextBox = null;
            }

            if (this.tileViewControl != null)
            {
                this.tileViewControl.Dispose();
                this.tileViewControl = null;
            }


            var viewModel = this.DataContext as TileViewViewModel;
            if (viewModel != null)
            {
                viewModel.BookModelItems.Clear();
                viewModel.BookModelItems = null;
                viewModel = null;
            }

            if (this.DataContext != null)
            {
                this.DataContext = null;
            }
            BindingOperations.ClearAllBindings(this);
            base.Dispose(disposing);
        }
    }
}
