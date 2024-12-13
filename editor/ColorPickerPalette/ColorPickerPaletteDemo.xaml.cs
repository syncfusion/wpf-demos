#region Copyright Syncfusion Inc. 2001 - 2024
// Copyright Syncfusion Inc. 2001 - 2024. All rights reserved.
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
    public partial class ColorPickerPaletteDemo : DemoControl
    {
        public ColorPickerPaletteDemo()
        {
            InitializeComponent();
        }

        public ColorPickerPaletteDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if(this.ColorPickerPalette1 != null)
            {
                this.ColorPickerPalette1.Dispose();
                this.ColorPickerPalette1 = null;
            }

            if (this.ColorPickerPalette2 != null)
            {
                this.ColorPickerPalette2.Dispose();
                this.ColorPickerPalette2 = null;
            }

            if (this.ColorPickerPalette3 != null)
            {
                this.ColorPickerPalette3.Dispose();
                this.ColorPickerPalette3 = null;
            }

            if (cmbothemecolors != null)
            {
                cmbothemecolors.Dispose();
                cmbothemecolors = null;
            }

            base.Dispose(disposing);
        }
    }
}
