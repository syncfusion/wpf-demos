#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// Interaction logic for ProgressWindow.xaml
    /// </summary>
    public partial class ErrorWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorWindow"/> class.
        /// </summary>
        public ErrorWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the main error message text displayed in the window. 
        /// </summary>
        public string Message
        {
            get { return message.Text; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    message.Text = value;
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="System.Windows.Window.Closed"/> event. this override ensures that the owner of the window is set to null to prevent memory leak.
        /// </summary>
        /// <param name="e">An <see cref="System.EventArgs"/> that contains the event data.</param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.Owner = null;
        }

        /// <summary>
        /// Handles the click event for the close button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguement.</param>
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Creates, configure and display a new <see cref="ErrorWindow"/> as a modal dialog.
        /// </summary>
        /// <param name="message">The error message to be display.</param>
        public static void Show(string message)
        {
            ErrorLogging.LogError(message);
            var errorWindow = new ErrorWindow();
            errorWindow.Message = message;
            if (DemosNavigationService.MainWindow != null)
            {
                errorWindow.Owner = DemosNavigationService.MainWindow;
            }
            errorWindow.ShowDialog();
        }
    }
}
