
namespace syncfusion.dropdowndemos.wpf
{
    /// <summary>
    /// Interaction logic for AutoComplete.xaml
    /// </summary>
    public partial class AutoComplete
    {
        /// <summary>
        /// Initializes the instance of <see cref="AutoComplete"/>class.
        /// </summary>
        public AutoComplete()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the themes.
        /// </summary>
        /// <param name="themename"></param>
        public AutoComplete(string themename) : base(themename)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method used to dipose the controls.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            this.Resources.Clear();


            if(this.multiSelectionComboBox != null)
            {
                this.multiSelectionComboBox.Dispose();
                this.multiSelectionComboBox = null;
            }
            base.Dispose(disposing);
        }
    }
}
