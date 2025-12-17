using syncfusion.demoscommon.wpf;


namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Interaction logic for AutoScroll.xaml
    /// </summary>
    public partial class AutoScrollDemosView : DemoControl
    {
        public AutoScrollDemosView()
        {
            InitializeComponent();
        }

        public AutoScrollDemosView(string themename):base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if(this.TabControl != null)
            {
                this.TabControl.Dispose();
                this.TabControl = null;
            }

            base.Dispose(disposing);
        }
    }
}
