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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TimeSpanEditDemo : DemoControl
    {
        /// <summary>
        /// Constructor for window1.
        /// </summary>
        public TimeSpanEditDemo()
        {
            InitializeComponent();
        }

        public TimeSpanEditDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.myTimeSpanEdit != null)
            {
                this.myTimeSpanEdit.Dispose();
                this.myTimeSpanEdit = null;
            }

            if (this.mintimespanedit != null)
            {
                this.mintimespanedit.Dispose();
                this.mintimespanedit = null;
            }

            if (this.maxtimespanedit != null)
            {
                this.maxtimespanedit.Dispose();
                this.maxtimespanedit = null;
            }

            base.Dispose(disposing);
        }
    }
}
