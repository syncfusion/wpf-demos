#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using syncfusion.demoscommon.wpf;
using System;
using System.Windows.Data;

namespace syncfusion.notificationdemos.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GettingStartedDemo : DemoControl
    {
        public GettingStartedDemo()
        {
            InitializeComponent();
        }

        public GettingStartedDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Dispose the data context objects.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (DataContext is IDisposable disposable)
            {
                disposable.Dispose();
            }
            if (this.ComboBoxAdv1 != null)
            {
                ComboBoxAdv1.Dispose();
                ComboBoxAdv1 = null;
            }
            if (this.ComboBoxAdv2 != null)
            {
                ComboBoxAdv2.Dispose();
                ComboBoxAdv2 = null;
            }
            if (this.ComboBoxAdv3 != null)
            {
                ComboBoxAdv3.Dispose();
                ComboBoxAdv3 = null;
            }
            if (this.ComboBoxAdv4 != null)
            {
                ComboBoxAdv4.Dispose();
                ComboBoxAdv4 = null;
            }
            if (this.ComboBoxAdv5 != null)
            {
                ComboBoxAdv5.Dispose();
                ComboBoxAdv5 = null;
            }
            if (this.ComboBoxAdv6 != null)
            {
                ComboBoxAdv6.Dispose();
                ComboBoxAdv6 = null;
            }
            if (this.ComboBoxAdv7 != null)
            {
                ComboBoxAdv7.Dispose();
                ComboBoxAdv7 = null;
            }
            if (custom_Alignment_and_Anchors != null)
            {
                custom_Alignment_and_Anchors.Children.Clear();
                custom_Alignment_and_Anchors = null;
            }            
            this.OuterGrid.Children.Clear();
            BindingOperations.ClearAllBindings(this);
            base.Dispose(disposing);
        }
    }
}
