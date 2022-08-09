#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;

namespace syncfusion.dockingmanagerdemos.wpf
{
    /// <summary>
    /// Interaction logic for CaptionRestriction.xaml
    /// </summary>
    public partial class CaptionRestriction : DemoControl
    {
        /// <summary>
        /// Construtor for CaptionRestriction
        /// </summary>
        public CaptionRestriction()
		{
			InitializeComponent();
		}

        public CaptionRestriction(string themename) : base(themename)
        {
            InitializeComponent();
        }
        protected override void Dispose(bool disposing)
        {
            //Release all managed resources
            if (this.dockingManager != null)
            {
                this.dockingManager.Dispose();
                this.dockingManager = null;
            }
            base.Dispose(disposing);
        }
    }
}
