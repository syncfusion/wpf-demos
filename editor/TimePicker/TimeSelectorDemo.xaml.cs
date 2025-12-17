using syncfusion.demoscommon.wpf;

namespace syncfusion.editordemos.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TimeSelectorDemo : DemoControl
    {
        public TimeSelectorDemo()
        {
            InitializeComponent();
        }

        public TimeSelectorDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.TimeSelector != null)
            {
                this.TimeSelector.Dispose();
                this.TimeSelector = null;
            }

            base.Dispose(disposing);
        }
    }
}
