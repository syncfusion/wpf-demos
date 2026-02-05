#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
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
    public partial class ColorEditDemo : DemoControl
    {
        public ColorEditDemo()
        {
            InitializeComponent();
        }

        public ColorEditDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.ColorEdit1 != null)
            {
                this.ColorEdit1.Dispose();
                this.ColorEdit1 = null;
            }
            if (this.ColorEdit4 != null)
            {
                this.ColorEdit4.Dispose();
                this.ColorEdit4 = null;
            }
            if (this.ColorEdit3 != null)
            {
                this.ColorEdit3.Dispose();
                this.ColorEdit3 = null;
            }
            if (stackPanel != null)
            {
                stackPanel.Children.Clear();
                stackPanel = null;
            }
            if (stackPanel1 != null)
            {
                stackPanel1.Children.Clear();
                stackPanel1 = null;
            }
            if (stackPanel2 != null)
            {
                stackPanel2.Children.Clear();
                stackPanel2 = null;
            }

            this.DataContext = null;
            base.Dispose(disposing);
        }
    }
}
