namespace syncfusion.kanbandemos.wpf
{
    using syncfusion.demoscommon.wpf;
    using Syncfusion.UI.Xaml.Kanban;

    /// <summary>
    /// Interaction logic for ColumnRearrangement.xaml
    /// </summary>
    public partial class ColumnRearrangement : DemoControl
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="ColumnRearrangement"/> class.
        /// </summary>
        public ColumnRearrangement(string themename) : base(themename)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Dispose all the allocated resources.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (this.Kanban != null)
            {
                this.Kanban.Dispose();
                this.Kanban = null;
            }
            
            base.Dispose(disposing);
        }
    }    
}
