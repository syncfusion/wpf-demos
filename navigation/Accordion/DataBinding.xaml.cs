
using syncfusion.demoscommon.wpf;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Interaction logic for DataBinding.xaml
    /// </summary>
    public partial class DataBinding : DemoControl
    {
        /// <summary>
        /// Initializes the new instance of <see cref="DataBinding"/> class.
        /// </summary>
        public DataBinding()
        {
            InitializeComponent();
        }

        public DataBinding(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.accordion != null)
            {
                this.accordion = null;
            }
            if (this.selectedItemTextBlock != null)
                this.selectedItemTextBlock = null;
            if (this.selectedItemComboBox != null)
                this.selectedItemComboBox = null;
            base.Dispose(disposing);
        }
    }
}
