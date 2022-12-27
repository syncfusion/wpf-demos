#region Copyright Syncfusion Inc. 2001 - 2022
// Copyright Syncfusion Inc. 2001 - 2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Shared;
using System.Windows;

namespace syncfusion.dropdowndemos.wpf
{
    /// <summary>
    /// Interaction logic for MultiColumnDropDownDemo.xaml
    /// </summary>
    public partial class MultiColumnDropDownDemo : DemoControl
    {
        public MultiColumnDropDownDemo()
        {
            InitializeComponent();
        }

        public MultiColumnDropDownDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            this.Resources.Clear();

            if (this.MultiColumnControl != null)
            {
                this.MultiColumnControl.Dispose();
                this.MultiColumnControl = null;
            }

            if (this.label1 != null)
                this.label1 = null;

            if (this.MultiColumnControl1 != null)
            {
                this.MultiColumnControl1.Dispose();
                this.MultiColumnControl1 = null;
            }

            if (this.label2 != null)
                this.label2 = null;

            if (this.MultiColumnControl2 != null)
            {
                this.MultiColumnControl2.Dispose();
                this.MultiColumnControl2 = null;
            }

            if (this.label3 != null)
                this.label3 = null;

            if (this.MultiColumnControl3 != null)
            {
                this.MultiColumnControl3.Dispose();
                this.MultiColumnControl3 = null;
            }

            if (this.label4 != null)
                this.label4 = null;

            if (this.MultiColumnControl4 != null)
            {
                this.MultiColumnControl4.Dispose();
                this.MultiColumnControl4 = null;
            }

            if (this.label5 != null)
                this.label5 = null;

            if (this.MultiColumnControl5 != null)
            {
                this.MultiColumnControl5.Dispose();
                this.MultiColumnControl5 = null;
            }

            if (this.label6 != null)
                this.label6 = null;

            if (this.DataContext != null)
                this.DataContext = null;

            base.Dispose(disposing);
        }
    }
}
