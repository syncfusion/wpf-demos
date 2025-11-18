using syncfusion.demoscommon.wpf;

namespace syncfusion.editordemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public sealed partial class DateTimePickerDemo : DemoControl
    {
        public DateTimePickerDemo()
        {
            InitializeComponent();
        }

        public DateTimePickerDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.DatePicker != null)
            {
                this.DatePicker.Dispose();
                this.DatePicker = null;
            }

            if (this.TimePicker != null)
            {
                this.TimePicker.Dispose();
                this.TimePicker = null;
            }

            base.Dispose(disposing);
        }
    }
}
