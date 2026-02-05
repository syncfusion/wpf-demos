#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.mapdemos.wpf
{
    using syncfusion.demoscommon.wpf;

    /// <summary>
    /// Interaction logic for LocationIndicator.xaml
    /// </summary>
    public partial class LocationIndicator : DemoControl
    {
        public LocationIndicator()
        {
            InitializeComponent();
        }

        public LocationIndicator(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.map != null)
            {
                this.map.Dispose();
                this.map = null;
            }

            base.Dispose(disposing);
        }
    }
}