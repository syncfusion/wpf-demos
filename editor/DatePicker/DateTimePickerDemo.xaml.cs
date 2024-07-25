#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
