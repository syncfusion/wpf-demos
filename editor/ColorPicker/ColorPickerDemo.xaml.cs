#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;

namespace syncfusion.editordemos.wpf
{
    /// <summary>
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPickerDemo : DemoControl
    {
        public ColorPickerDemo()
        {
            InitializeComponent();
        }

        public ColorPickerDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            this.Resources = null;
            this.DataContext = null;

            if (this.ColorPicker1 != null)
            {
                this.ColorPicker1.Dispose();
                this.ColorPicker1 = null;
            }

            if(this.ColorPicker2 != null)
            {
                this.ColorPicker2.Dispose();
                this.ColorPicker2 = null;
            }

            base.Dispose(disposing);
        }
    }
}
