#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Windows.Data;
using System.Windows.Controls;

namespace syncfusion.editordemos.wpf
{
    /// <summary>
    /// Interaction logic for DomainUpDownDemo.xaml
    /// </summary>
    public partial class DomainUpDownDemo : DemoControl
    {
        /// <summary>
        /// Constructor for DomainUpDownDemo.
        /// </summary>
        public DomainUpDownDemo()
        {
            InitializeComponent();
        }

        public DomainUpDownDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if(this.DataContext is DomainUpDownViewModel disposableViewModel)
        {
                disposableViewModel.Dispose();
            }
            this.DataContext = null;
            
            this.DomainUpDown.Children.Clear();
            if (DomainUpDown != null)
            {
                DomainUpDown = null;
            }
            if (SfDomainUpDown1 != null)
            {
                this.SfDomainUpDown1.ItemsSource = null;
                this.SfDomainUpDown1.Dispose();
                this.SfDomainUpDown1 = null;
            }

            if (SfDomainUpDown2 != null)
            {
                this.SfDomainUpDown2.ItemsSource = null;
                this.SfDomainUpDown2.Dispose();
                this.SfDomainUpDown2 = null;
            }
            if (SfDomainUpDown3 != null)
            {
                this.SfDomainUpDown3.ItemsSource = null;
                this.SfDomainUpDown3.Dispose();
                this.SfDomainUpDown3 = null;
            }
            if (SfDomainUpDown4 != null)
            {
                this.SfDomainUpDown4.ItemsSource = null;
                this.SfDomainUpDown4.Dispose();
                this.SfDomainUpDown4 = null;
            }
            if (SfDomainUpDown5 != null)
            {
                this.SfDomainUpDown5.ItemsSource = null;
                this.SfDomainUpDown5.Dispose();
                this.SfDomainUpDown5 = null;
            }
            if (SfDomainUpDown6 != null)
            {
                this.SfDomainUpDown6.ItemsSource = null;
                this.SfDomainUpDown6.Dispose();
                this.SfDomainUpDown6 = null;
            }
            this.Scroll.Content = null;
            Scroll = null;


            base.Dispose(disposing);
        }

    }
}
