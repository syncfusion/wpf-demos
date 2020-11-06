#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;

namespace syncfusion.layoutdemos.wpf
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class TileViewDemo : DemoControl
    {
        public TileViewDemo()
        {
            InitializeComponent();
        }
        public TileViewDemo(string themename):base(themename)
        {
            InitializeComponent();
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = "Office2019Colorful" });
        }

        protected override void Dispose(bool disposing)
        {
            if (this.AnimationTimeSpan != null)
            {
                this.AnimationTimeSpan.Dispose();
                this.AnimationTimeSpan = null;
            }

            if (this.columnIntegerTextBox != null)
            {
                this.columnIntegerTextBox.Dispose();
                this.columnIntegerTextBox = null;
            }

            if (this.rowIntegerTextBox != null)
            {
                this.rowIntegerTextBox.Dispose();
                this.rowIntegerTextBox = null;
            }

            if (this.tileViewControl != null)
            {
                this.tileViewControl.Dispose();
                this.tileViewControl = null;
            }

            if (this.DataContext != null)
            {
                this.DataContext = null;
            }

            base.Dispose(disposing);
        }
    }
}
