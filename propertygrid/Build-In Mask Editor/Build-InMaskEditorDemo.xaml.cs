using syncfusion.demoscommon.wpf;

namespace syncfusion.propertygriddemos.wpf
{
    /// <summary>
    /// Interaction logic for BuildInEditorDemo.xaml
    /// </summary>
    public partial class BuildInMaskEditorDemo : DemoControl
    {
        public BuildInMaskEditorDemo()
        {
            InitializeComponent();
        }
        public BuildInMaskEditorDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            //Release all managed resources
            if (this.propertygrid != null)
            {
                this.propertygrid.Dispose();
                this.propertygrid = null;
            }

            if (this.tabControlExt != null)
            {
                this.tabControlExt.Dispose();
                this.tabControlExt = null;
            }

            base.Dispose(disposing);
        }
    }
}
