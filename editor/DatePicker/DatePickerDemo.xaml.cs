#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;

namespace syncfusion.editordemos.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class DatePickerDemo : DemoControl
    {
        public DatePickerDemo()
        {
           InitializeComponent();
        }

        public DatePickerDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.Resources != null)
            {
                this.Resources.Clear();
            }

            if (this.DefaultDatePicker != null)
            {
                this.DefaultDatePicker.Dispose();
                this.DefaultDatePicker = null;
            }

            if (this.EditDatePicker != null)
            {
                this.EditDatePicker.Dispose();
                this.EditDatePicker = null;
            }

            if (this.CustomDatePicker != null)
            {
                this.CustomDatePicker.Dispose();
                this.CustomDatePicker = null;
            }

            if (this.NullableDatePicker != null)
            {
                this.NullableDatePicker.Dispose();
                this.NullableDatePicker = null;
            }

            if (this.FormatDatePicker != null)
            {
                this.FormatDatePicker.Dispose();
                this.FormatDatePicker = null;
            }

            if (this.ReadableDatePicker != null)
            {
                this.ReadableDatePicker.Dispose();
                this.ReadableDatePicker = null;
            }

            if (this.MinMaxDatePicker != null)
            {
                this.MinMaxDatePicker.Dispose();
                this.MinMaxDatePicker = null;
            }

            if (this.CustomTemplateDatePicker != null)
            {
                this.CustomTemplateDatePicker.Dispose();
                this.CustomTemplateDatePicker = null;
            }

            if (this.CustomDropDownHeightDatePicker != null)
            {
                this.CustomDropDownHeightDatePicker.Dispose();
                this.CustomDropDownHeightDatePicker = null;
            }

            base.Dispose(disposing);
        }
    }
}
