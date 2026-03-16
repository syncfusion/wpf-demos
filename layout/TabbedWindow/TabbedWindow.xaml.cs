#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.layoutdemos.wpf.ViewModel;
using Syncfusion.Windows.Controls;
using System;
using System.ComponentModel;
using System.Windows;

namespace syncfusion.layoutdemos.wpf
{
    public partial class TabbedWindow : Syncfusion.Windows.Controls.SfChromelessWindow
    {
        public TabbedWindow()
        {
            InitializeComponent();
            this.Topmost = true;
            Application.Current.Activated += Current_Activated;
            Application.Current.Deactivated += Current_Deactivated;
        }

        private void Current_Activated(object sender, EventArgs e)
        {
            foreach (Window windows in Application.Current.Windows)
            {
                if (windows is SfChromelessWindow)
                {
                    windows.Topmost = true;
                }
            }
        }

        private void Current_Deactivated(object sender, EventArgs e)
        {
            foreach (Window windows in Application.Current.Windows)
            {
                if (windows is SfChromelessWindow)
                {
                    windows.Topmost = false;
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (sfTabControl != null)
            {
                if (sfTabControl.ItemTemplate != null)
                {
                    sfTabControl.ItemTemplate = null;
                }
                if (sfTabControl.ContentTemplate != null)
                {
                    sfTabControl.ContentTemplate = null;
                }
                if (sfTabControl.ItemContainerStyle != null)
                {
                    sfTabControl.ItemContainerStyle = null;
                }

                sfTabControl.Dispose();
                sfTabControl = null;
            }
            base.OnClosing(e);
        }
    }
}
