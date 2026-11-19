
using syncfusion.demoscommon.wpf;

namespace syncfusion.syntaxeditordemos.wpf
{
    /// <summary>
    /// Interaction logic for CustomLanguage.xaml
    /// </summary>
    public partial class CustomLanguage : DemoControl
    {
        /// <summary>
        /// Window Constructor and events initialization
        /// </summary>
        public CustomLanguage()
        {
            InitializeComponent();
           
        }

        public CustomLanguage(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            this.Resources.Clear();

            if (this.editControl != null)
            {
                this.editControl = null;
            }

            if (this.Mainmenu != null)
                this.Mainmenu = null;

            if (this.Toolbar != null)
                this.Toolbar = null;

            if (this.DataContext != null)
                this.DataContext = null;

            base.Dispose(disposing);
        }
    }
}
