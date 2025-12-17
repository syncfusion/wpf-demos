
using syncfusion.demoscommon.wpf;

namespace syncfusion.notificationdemos.wpf
{
    /// <summary>
    /// Interaction logic for PulsingTileDemo.xaml
    /// </summary>
    public partial class PulsingTileView : DemoControl
    {
        public PulsingTileView()
        {
            InitializeComponent();
        }

        public PulsingTileView(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.pulsingTile != null)
            {
                this.pulsingTile.Dispose();
                this.pulsingTile = null;
            }
            if (this.headerTextBlock != null)
                this.headerTextBlock = null;
            if (this.header != null)
                this.header = null;
            if (this.pulseDurationTextBlock != null)
                this.pulseDurationTextBlock = null;
            if (this.timeSpanEdit != null)
                this.timeSpanEdit = null;
            if (this.pulseScaleTextBlock != null)
                this.pulseScaleTextBlock = null;
            if (this.pulsingScaleUpDown != null)
                this.pulsingScaleUpDown = null;
            base.Dispose(disposing);
        }
    }  
}
