#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;
using System;
using System.ComponentModel;

namespace syncfusion.ribbondemos.wpf
{
    /// <summary>
    /// Code behind logic for Window1.xaml
    /// </summary>
    public partial class GettingStarted : DemoControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GettingStarted"/> class.
        /// </summary>
        public GettingStarted()
        {
            InitializeComponent();
        }

        public GettingStarted(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.Resources != null)
                this.Resources.Clear();
            if (this.mainRibbon != null)
            {
                this.mainRibbon.Dispose();
                this.mainRibbon = null;
            }
            if (this.editor != null)
            {
                this.editor = null;
            }
            if (mainGrid != null)
            {
                mainGrid.Children.Clear();
                mainGrid = null;
            }
            GettingStartedViewModel.Dispose();
            base.Dispose(disposing);
        }
    }
}