namespace syncfusion.mapdemos.wpf
{
    using syncfusion.demoscommon.wpf;

    /// <summary>
    /// Interaction logic for MapExportDemo.xaml
    /// </summary>
    public partial class MapExportDemo : DemoControl
    {
        #region Constructor

        /// <summary>
        ///  Initializes a new instance of the <see cref="MapExportDemo"/> class.
        /// </summary>
        public MapExportDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Dispose all the allocated resources.
        /// </summary>
        /// <param name="disposing">A boolean value indicating whether to release managed resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (this.geometryMap != null)
            {
                this.geometryMap.Dispose();
                this.geometryMap = null;
            }

            if (this.osmMap != null)
            {
                this.osmMap.Dispose();
                this.osmMap = null;
            }

            base.Dispose(disposing);
        }

        #endregion
    }
}