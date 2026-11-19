using syncfusion.demoscommon.wpf;
namespace syncfusion.layoutdemos.wpf
{
    /// <summary>
    /// Interaction logic for DataBinding.xaml
    /// </summary>
    public partial class DataBindingDemo : DemoControl
    {
        public DataBindingDemo()
        {
            InitializeComponent();
        }
        public DataBindingDemo(string themename):base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.tileViewControl != null)
            {
                this.tileViewControl.Dispose();
                this.tileViewControl = null;
            }

            var viewModel = this.DataContext as DataBindingViewModel;
            if (viewModel != null)
            {
                viewModel.Applications = null;
            }

            this.DataContext = null;
            base.Dispose(disposing);
        }
    }
}
