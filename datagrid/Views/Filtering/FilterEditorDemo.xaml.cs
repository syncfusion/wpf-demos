using syncfusion.demoscommon.wpf;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Demonstrates the standalone Filter Editor integration and the built-in Filter Editor Panel configuration in SfDataGrid.
    /// </summary>
    public partial class FilterEditorDemo : DemoControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterEditorDemo"/> class with the specified theme.
        /// </summary>
        /// <param name="themename">The name of the theme applied to the demo.</param>
        public FilterEditorDemo(string themename): base(themename)
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterEditorDemo"/> class.
        /// </summary>
        public FilterEditorDemo()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Releases the resources used by the Filter Editor demo.
        /// </summary>
        /// <param name="disposing">Indicates whether managed resources must be released.</param>
        protected override void Dispose(bool disposing)
        {
            if (this.filterEditor != null)
            {
                // Releases the DataGrid filtering context so the standalone editor does not retain the disposed DataGrid.
                this.filterEditor.FilteringContext = null;
                this.filterEditor = null;
            }

            if (this.sfgrid != null)
            {
                this.sfgrid.Dispose();
                this.sfgrid = null;
            }

            this.DataContext = null;
            this.Resources.Clear();

            base.Dispose(disposing);
        }
    }
}