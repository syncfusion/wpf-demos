#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Syncfusion.SfSkinManager;
using System;

namespace RibbonSample
{
    /// <summary>
    /// Code behind logic for Window1.xaml
    /// </summary>
    public partial class Window1
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Window1"/> class.
        /// </summary>
        public Window1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the theme.
        /// </summary>
        /// <param name="e">Specifies the event.</param>
        protected override void OnInitialized(EventArgs e)
        {
            SfSkinManager.SetVisualStyle(this, VisualStyles.MaterialLight);
            base.OnInitialized(e);
        }
    }
}