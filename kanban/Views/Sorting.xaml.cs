namespace syncfusion.kanbandemos.wpf
{
    using syncfusion.demoscommon.wpf;

    /// <summary>
    /// Interaction logic for Sorting.xaml
    /// </summary>
    public partial class Sorting : DemoControl
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Sorting"/> class.
        /// </summary>
        public Sorting(string themename) : base(themename)
        {
            InitializeComponent();
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Dispose all the allocated resources.
        /// </summary>
        /// <param name="disposing">A boolean value indicating whether to release managed resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (this.kanban != null)
            {
                this.kanban.Dispose();
                this.kanban = null;
            }
            
            base.Dispose(disposing);
        }

        #endregion
    }
}