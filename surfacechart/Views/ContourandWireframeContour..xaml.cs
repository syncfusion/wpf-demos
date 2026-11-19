using syncfusion.demoscommon.wpf;

namespace syncfusion.surfacechartdemos.wpf
{
    /// <summary>
    /// Interaction logic for ContourandWireframeContour.xaml
    /// </summary>
    public partial class ContourandWireframeContour : DemoControl
    {
        public ContourandWireframeContour()
        {
            InitializeComponent();
        }

        public ContourandWireframeContour (string themename) : base(themename)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method to dispose the Surface chart control instance.
        /// </summary>
        /// <param name="disposing">Indicates whether to release managed resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (this.surfaceChart != null)
            {
                this.surfaceChart.Dispose();
                this.surfaceChart = null;
            }
        }
    }
}