
using syncfusion.demoscommon.wpf;

namespace syncfusion.syntaxeditordemos.wpf
{
    /// <summary>
    /// Interaction logic for GettingStarted.xaml
    /// </summary>

    public partial class GettingStarted : DemoControl
    {
        /// <summary>
        /// Window Constructor and events initialization
        /// </summary>
        public GettingStarted()
        {
            InitializeComponent();
        }

        public GettingStarted(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            this.Resources.Clear();

            if (this.editControl != null)
            {
                this.editControl.Dispose();
                this.editControl = null;
            }

            if (this.Mainmenu != null)
            {
                if(this.Mainmenu.Items != null)
                    this.Mainmenu.Items.Clear();
                
                this.Mainmenu = null;
            }
               
            if (this.Toolbar != null)
            {
                if(this.Toolbar.Items != null)
                     this.Toolbar.Items.Clear();
                
                this.Toolbar = null;
            }

            if(this.DataContext != null)
                this.DataContext = null;  

            base.Dispose(disposing);
        }
    }
}
