using syncfusion.demoscommon.wpf;

namespace syncfusion.editordemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TimeSpanEditDemo : DemoControl
    {
        /// <summary>
        /// Constructor for window1.
        /// </summary>
        public TimeSpanEditDemo()
        {
            InitializeComponent();
        }

        public TimeSpanEditDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.myTimeSpanEdit != null)
            {
                this.myTimeSpanEdit.Dispose();
                this.myTimeSpanEdit = null;
            }

            if (this.mintimespanedit != null)
            {
                this.mintimespanedit.Dispose();
                this.mintimespanedit = null;
            }

            if (this.maxtimespanedit != null)
            {
                this.maxtimespanedit.Dispose();
                this.maxtimespanedit = null;
            }

            base.Dispose(disposing);
        }
    }
}
