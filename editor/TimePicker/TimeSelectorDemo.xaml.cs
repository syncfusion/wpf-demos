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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TimeSelectorDemo : DemoControl
    {
        public TimeSelectorDemo()
        {
            InitializeComponent();
        }

        public TimeSelectorDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.TimeSelector != null)
            {
                this.TimeSelector.Dispose();
                this.TimeSelector = null;
            }

            base.Dispose(disposing);
        }
    }
}
