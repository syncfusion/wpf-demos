#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Syncfusion.SfSkinManager;
using System;

namespace GroupbarOutlookDemo
{
    /// <summary>
    /// Class represents the code behind logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();          
        }

        /// <summary>
        /// Initializes the theme.
        /// </summary>
        /// <param name="e">Specifies the event.</param>
        protected override void OnInitialized(EventArgs e)
        {
            SfSkinManager.SetVisualStyle(this, VisualStyles.Office365);
            base.OnInitialized(e);
        }
    }
}
