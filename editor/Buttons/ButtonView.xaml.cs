#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;

namespace syncfusion.editordemos.wpf
{
    /// <summary>
    /// Interaction logic for ButtonDemosView.xaml
    /// </summary>
    public partial class ButtonView : DemoControl, IDisposable
    {
        public ButtonView()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.smallButtonAdv != null)
                {
                    this.smallButtonAdv = null;
                }

                if (this.dropDownButtonAdv != null)
                {
                    this.dropDownButtonAdv.Dispose();
                    this.dropDownButtonAdv = null;
                }

                if (this.splitButtonAdv != null)
                {
                    this.splitButtonAdv.Dispose();
                    this.splitButtonAdv = null;
                }

                if (this.normalButtonAdv != null)
                {
                    this.normalButtonAdv = null;
                }

                if (this.normalDropDownButtonAdv != null)
                {
                    this.normalDropDownButtonAdv.Dispose();
                    this.normalDropDownButtonAdv = null;
                }

                if (this.normalSplitButton != null)
                {
                    this.normalSplitButton.Dispose();
                    this.normalSplitButton = null;
                }

                if (this.largeButton != null)
                {
                    this.largeButton = null;
                }

                if (this.largeDropDownButtonAdv != null)
                {
                    this.largeDropDownButtonAdv.Dispose();
                    this.largeDropDownButtonAdv = null;
                }

                if (this.largeSplitButton != null)
                {
                    this.largeSplitButton.Dispose();
                    this.largeSplitButton = null;
                }

                if (this.buttonGrid != null)
                {
                    this.buttonGrid = null;
                }
                base.Dispose(disposing);
            }
        }
    }
}
