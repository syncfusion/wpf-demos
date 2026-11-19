
using syncfusion.demoscommon.wpf;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Interaction logic for ToolBarDemosView.xaml
    /// </summary>
    public partial class ToolBarDemosView : DemoControl
    {
        public ToolBarDemosView()
        {
            InitializeComponent();
        }

        public ToolBarDemosView(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.toolBarManager != null)
            {
                this.toolBarManager = null;
            }
            if(toolBarGrid != null)
            {
                toolBarGrid.Children.Clear();
                toolBarGrid = null;
            }
            base.Dispose(disposing);
        }
    }
}
