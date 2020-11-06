#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;

namespace syncfusion.editordemos.wpf
{
    /// <summary>
    /// Interaction logic for ButtonDemosView.xaml
    /// </summary>
    public partial class ButtonView : DemoControl
    {
        public ButtonView()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.smallButtonAdv != null)
            {
                this.smallButtonAdv = null;   
            }

            if(this.dropDownButtonAdv != null)
            {
                this.dropDownButtonAdv = null;
            }

            if(this.splitButtonAdv != null)
            {
                this.splitButtonAdv = null;
            }

            if(this.normalButtonAdv != null)
            {
                this.normalButtonAdv = null;
            }

            if (this.normalDropDownButtonAdv != null)
            {
                this.normalDropDownButtonAdv = null;
            }

            if (this.normalSplitButton != null)
            {
                this.normalSplitButton = null;
            }

            if (this.largeButton != null)
            {
                this.largeButton = null;
            }

            if (this.largeDropDownButtonAdv != null)
            {
                this.largeDropDownButtonAdv = null;
            }

            if (this.largeSplitButton != null)
            {
                this.largeSplitButton = null;
            }
            base.Dispose(disposing);
        }
    }
}
