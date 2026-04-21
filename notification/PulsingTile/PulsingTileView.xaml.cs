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
    /// Interaction logic for PulsingTileDemo.xaml
    /// </summary>
    public partial class PulsingTileView : DemoControl
    {
        public PulsingTileView()
        {
            InitializeComponent();
        }

        public PulsingTileView(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.pulsingTile != null)
            {
                this.pulsingTile.Dispose();
                this.pulsingTile = null;
            }
            if (this.headerTextBlock != null)
                this.headerTextBlock = null;
            if (this.header != null)
                this.header = null;
            if (this.pulseDurationTextBlock != null)
                this.pulseDurationTextBlock = null;
            if (this.timeSpanEdit != null)
                this.timeSpanEdit = null;
            if (this.pulseScaleTextBlock != null)
                this.pulseScaleTextBlock = null;
            if (this.pulsingScaleUpDown != null)
                this.pulsingScaleUpDown = null;
            base.Dispose(disposing);
        }
    }  
}
