#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows;
using syncfusion.demoscommon.wpf;
 
namespace syncfusion.notificationdemos.wpf
{
    /// <summary>
    /// Interaction logic for NotifyIconDemo.xaml
    /// </summary>
    public partial class NotifyIconDemo : DemoControl
    {       
        public NotifyIconDemo()
        {
            InitializeComponent();
        }

        public NotifyIconDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.notifyIcon != null)
            {
                this.notifyIcon = null;
            }
            base.Dispose(disposing);
        }
    }
}
