#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.Windows.Shared;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace TitleBarCustomization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        #region Constructor
        /// <summary>
        /// Constructor of the Main window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Implementation
        /// <summary>
        /// This event is raised when help button is clicked
        /// </summary>
        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://help.syncfusion.com/wpf/chromeless-window/getting-started");
        }
        #endregion
    }
}
