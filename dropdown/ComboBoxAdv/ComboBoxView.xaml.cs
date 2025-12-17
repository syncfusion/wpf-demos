
namespace syncfusion.dropdowndemos.wpf
{
    /// <summary>
    /// Interaction logic for ComboBoxAdvDemosView.xaml
    /// </summary>
    public partial class ComboBoxView
    {
        public ComboBoxView()
        {
            InitializeComponent();
        }

        public ComboBoxView(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            this.Resources.Clear();

            if (this.label1 != null)
                this.label1 = null;

            if (this.label2 != null)
                this.label2 = null;

            if (this.label3 != null)
                this.label3 = null;

            if (this.label4 != null)
                this.label4 = null;
           
            if (this.singleSelectionComboBox != null)
            {
                this.singleSelectionComboBox.Dispose();                            
                this.singleSelectionComboBox = null;
            }

            if(this.multiSelectionComboBox != null)
            {
                this.multiSelectionComboBox.Dispose();
                this.multiSelectionComboBox = null;
            }

            if (this.delimiterComboBox != null)
            {
                this.delimiterComboBox.Dispose();
                this.delimiterComboBox = null;
            }

            if(this.waterMarkComboBox != null)
            {
                this.waterMarkComboBox.Dispose();
                this.waterMarkComboBox = null;
            }
            base.Dispose(disposing);
        }
    }
}
