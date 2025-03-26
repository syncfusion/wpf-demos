#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfSkinManager;
using System.ComponentModel;

namespace syncfusion.ribbondemos.wpf
{
    /// <summary>
    /// Interaction logic for ApplicationMenu.xaml
    /// </summary>
    public partial class ApplicationMenu
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationMenu" /> class.
        /// </summary>
        public ApplicationMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the theme when launching the demo.
        /// </summary>
        /// <param name="themename">Specifies the theme name.</param>
        public ApplicationMenu(string themename)
        {
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });
            InitializeComponent();
        }

        /// <summary>
        /// Method used to dispose the controls used in ApplicationMenu.xaml.
        /// </summary>
        /// <param name="e">Specifies the cancel event.</param>
        protected override void OnClosing(CancelEventArgs e)
        {
            // Release all managed resources
            if (this.Resources != null)
                this.Resources.Clear();
            if (this.mainRibbon != null)
            {
                this.mainRibbon.Dispose();
                this.mainRibbon = null;
            }
            if (this.ribbonStatusBar != null)
                this.ribbonStatusBar = null;

            if (this._applicationMenu != null)
            {
                this._applicationMenu.Dispose();
                this._applicationMenu = null;
            }

            if (this.editor != null)
                this.editor = null;

            if(statusBarGrid != null)
            {
                statusBarGrid.Children.Clear();
                statusBarGrid = null;
            }

            if(statusGrid  != null)
            {
                statusGrid.Children.Clear();
                statusGrid = null;
            }
            GettingStartedViewModel.Dispose();
            base.OnClosing(e);
        }
    }
}
