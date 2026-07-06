using syncfusion.demoscommon.wpf;

namespace syncfusion.dockingmanagerdemos.wpf
{
    /// <summary>
    /// Interaction logic for DockHintsRestrictionDemo.xaml
    /// </summary>
    public partial class DockHintsRestrictionDemo : DemoControl
    {
        public DockHintsRestrictionDemo()
        {
            InitializeComponent();
        }

        public DockHintsRestrictionDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }
        protected override void Dispose(bool disposing)
        {
            //Release all managed resources
            DockHintsBehaviors.Dispose();
            base.Dispose(disposing);
        }
    }
}
