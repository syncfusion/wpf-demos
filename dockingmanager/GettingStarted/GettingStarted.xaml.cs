#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using WinForms = System.Windows.Forms;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.SfSkinManager;

namespace syncfusion.dockingmanagerdemos.wpf
{
    /// <summary>
    /// Interaction logic for GettingStarted.xaml
    /// </summary>
    public partial class GettingStarted : ChromelessWindow
    {
        #region Constructor
        /// <summary>
        /// Constructor for GettingStarted.
        /// </summary>
        public GettingStarted()
        {
            InitializeComponent();
        }

        public GettingStarted(string themename)
        {
            InitializeComponent();
            DockingManager.ActiveWindow = Integration;
        }
        #endregion
    }
}

