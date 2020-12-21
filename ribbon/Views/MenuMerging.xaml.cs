#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Syncfusion.SfSkinManager;
using System;
using System.ComponentModel;

namespace syncfusion.ribbondemos.wpf
{
    /// <summary>
    /// Code behind logic for MainWindow.xaml
    /// </summary>
    public partial class MenuMerging
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="MenuMerging" /> class.
        /// </summary>
        public MenuMerging()
        {
            InitializeComponent();
        }

        public MenuMerging(string themename)
        {
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // Release all managed resources
            if (this.mainRibbon != null)
            {
                this.mainRibbon.Dispose();                
                this.mainRibbon = null;
            }

            if(this.documentContainer != null)
            {
                this.documentContainer.Dispose();
                this.documentContainer = null;
            }

            base.OnClosing(e);
        }
    }
}
