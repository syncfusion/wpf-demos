
using syncfusion.demoscommon.wpf;

namespace syncfusion.syntaxeditordemos.wpf
{
    /// <summary>
    /// Interaction logic for IntellisenseEditor.xaml
    /// </summary>
    public partial class IntellisenseEditor:DemoControl
    {
        /// <summary>
        /// IntellisenseEditor Constructor 
        /// </summary>
        public IntellisenseEditor()
        {
            InitializeComponent();
        }

        public IntellisenseEditor(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            this.Resources.Clear();

            if (this.editCSharp != null)
            {
                this.editCSharp = null;
            }

            if (this.Mainmenu != null)
                this.Mainmenu = null;

            if (this.Toolbar != null)
                this.Toolbar = null;

            if (this.expander != null)
                this.expander = null;

            if (this.DataContext != null)
                this.DataContext = null;

            base.Dispose(disposing);
        }
    }
}




