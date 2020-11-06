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
    public partial class ContextualTab
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="ContextualTab" /> class.
        /// </summary>
        public ContextualTab()
        {
            InitializeComponent();         
        }

        public ContextualTab(string themename)
        {
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // Release all managed resources
            if (this.ribbon != null)
            {
                this.ribbon.Dispose();
                this.ribbon = null;
            }

            if (this.editor != null)
            {               
                this.editor = null;
            }

            base.OnClosing(e);
        }
    }
}


