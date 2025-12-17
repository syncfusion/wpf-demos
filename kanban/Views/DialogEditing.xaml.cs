namespace syncfusion.kanbandemos.wpf
{
    using syncfusion.demoscommon.wpf;

    /// <summary>
    /// Interaction logic for DialogEditing.xaml
    /// </summary>
    public partial class DialogEditing : DemoControl
    {
        #region Properties

        /// <summary>
        /// Gets or sets the instance of <see cref="SwimlaneViewModel"/> that serves as the data context for this window.
        /// </summary>
        public SwimlaneViewModel ViewModel { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogEditing"/> class.
        /// </summary>
        public DialogEditing(string themename) : base(themename)
        {
            this.InitializeComponent();
            this.ViewModel = this.DataContext as SwimlaneViewModel;       
        }

        #endregion

        #region Methods

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