#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using syncfusion.demoscommon.wpf;

namespace syncfusion.notificationdemos.wpf
{
    /// <summary>
    /// Code behind logic for WindowsTileDemo.xaml
    /// </summary>
    public partial class WindowsTile :DemoControl
    {
        /// <summary>
        /// Initializes the new instance of <see cref="WindowsTileDemo"/> class.
        /// </summary>
        public WindowsTile()
        {
            InitializeComponent();
        }

        public WindowsTile(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.List != null)
            {
                this.List = null;
            }
            base.Dispose(disposing);
        }
    }
}
