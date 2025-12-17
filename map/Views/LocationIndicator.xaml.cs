namespace syncfusion.mapdemos.wpf
{
    using syncfusion.demoscommon.wpf;

    /// <summary>
    /// Interaction logic for LocationIndicator.xaml
    /// </summary>
    public partial class LocationIndicator : DemoControl
    {
        public LocationIndicator()
        {
            InitializeComponent();
        }

        public LocationIndicator(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.map != null)
            {
                this.map.Dispose();
                this.map = null;
            }

            base.Dispose(disposing);
        }
    }
}