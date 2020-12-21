#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Interaction logic for MenuGettingStartedDemosView.xaml
    /// </summary>
    public partial class MenuGettingStartedDemosView: DemoControl
    {
        public MenuGettingStartedDemosView()
        {
            InitializeComponent();                       
        }

        public MenuGettingStartedDemosView(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.MenuAdv != null)
            {
                this.MenuAdv.Dispose();
                this.MenuAdv = null;
            }
            base.Dispose(disposing);
        }
    } 
}
