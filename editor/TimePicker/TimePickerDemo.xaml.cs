using syncfusion.demoscommon.wpf;

namespace syncfusion.editordemos.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public sealed partial class TimePickerDemo : DemoControl
    {
        public TimePickerDemo()
        {
            InitializeComponent();
        }

        public TimePickerDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.Resources != null)
            {
                this.Resources.Clear();
            }

            if (this.DefaultTimePicker != null)
            {
                this.DefaultTimePicker.Dispose();
                this.DefaultTimePicker = null;
            }

            if (this.EditTimePicker != null)
            {
                this.EditTimePicker.Dispose();
                this.EditTimePicker = null;
            }

            if (this.CustomTimePicker != null)
            {
                this.CustomTimePicker.Dispose();
                this.CustomTimePicker = null;
            }

            if (this.NullableTimePicker != null)
            {
                this.NullableTimePicker.Dispose();
                this.NullableTimePicker = null;
            }

            if (this.FormatTimePicker != null)
            {
                this.FormatTimePicker.Dispose();
                this.FormatTimePicker = null;
            }

            if (this.ReadableTimePicker != null)
            {
                this.ReadableTimePicker.Dispose();
                this.ReadableTimePicker = null;
            }

            if (this.MinMaxTimePicker != null)
            {
                this.MinMaxTimePicker.Dispose();
                this.MinMaxTimePicker = null;
            }

            if (this.CustomTemplateTimePicker != null)
            {
                this.CustomTemplateTimePicker.Dispose();
                this.CustomTemplateTimePicker = null;
            }

            if (this.CustomDropDownHeightTimePicker != null)
            {
                this.CustomDropDownHeightTimePicker.Dispose();
                this.CustomDropDownHeightTimePicker = null;
            }

            base.Dispose(disposing);
        }
    }
}
