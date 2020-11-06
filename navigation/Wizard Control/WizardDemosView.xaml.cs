#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;
using System;
using System.ComponentModel;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Interaction logic for WizardDemosView.xaml
    /// </summary>
    public partial class WizardDemosView
    {
        public WizardDemosView()
        {
            InitializeComponent();
        }

        public WizardDemosView(string themename)
        {
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // Release all managed resources
            if (this.wizardControl != null)
            {
                this.wizardControl = null;
            }
            base.OnClosing(e);
        }
    }
}
