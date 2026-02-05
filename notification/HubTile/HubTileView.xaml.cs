#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using syncfusion.demoscommon.wpf;

namespace syncfusion.notificationdemos.wpf
{
    /// <summary>
    /// Interaction logic for HubTileDemo.xaml
    /// </summary>
    public partial class HubTileView : DemoControl
    {
        public HubTileView()
        {
            InitializeComponent();        
        }

        public HubTileView(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.hubTile != null)
            {
                this.hubTile.Dispose();
                this.hubTile = null;
            }
            if (this.titleTextBlock != null)
                this.titleTextBlock = null;
            if (this.title != null)
                this.title = null;
            if (this.headerTextBlock != null)
                this.headerTextBlock = null;
            if (this.header != null)
                this.header = null;
            if (this.transitionTextBlock != null)
                this.transitionTextBlock = null;
            if (this.transitionComboBox != null)
                this.transitionComboBox = null;
            base.Dispose(disposing);
        }
    }
}
