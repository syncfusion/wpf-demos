
using syncfusion.demoscommon.wpf;

namespace syncfusion.notificationdemos.wpf
{
    /// <summary>
    /// Code behind logic for WindowsTileDemo.xaml
    /// </summary>
    public partial class WindowsTile :DemoControl
    {
        /// <summary>
        /// Initializes the new instance of <see cref="WindowsTileDemo"/> class.
        /// </summary>
        public WindowsTile()
        {
            InitializeComponent();
        }

        public WindowsTile(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.List != null)
            {
                this.List = null;
            }
            base.Dispose(disposing);
        }
    }
}
