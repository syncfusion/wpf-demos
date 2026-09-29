
using syncfusion.demoscommon.wpf;

namespace syncfusion.syntaxeditordemos.wpf
{
    /// <summary>
    /// Interaction logic for CSharpEditor.xaml
    /// </summary>
    public partial class CSharpEditor : DemoControl
    {
        /// <summary>
        /// CSharpEditor Constructor 
        /// </summary>
        public CSharpEditor()
        {
            InitializeComponent();
        }

        public CSharpEditor(string themename) : base(themename)
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