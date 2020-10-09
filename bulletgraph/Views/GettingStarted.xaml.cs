#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using Syncfusion.SfSkinManager;


namespace syncfusion.bulletgraphdemos.wpf
{
    /// <summary>
    /// Interaction logic for GettingStarted.xaml
    /// </summary>
    public partial class GettingStarted : DemoControl
    {
        public GettingStarted()
        {
            InitializeComponent();
        }

        public GettingStarted(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (SfBulletGraph1 != null)
            {
                SfBulletGraph1.Dispose();
                SfBulletGraph1 = null;
            }

            if (SfBulletGraph2 != null)
            {
                SfBulletGraph2.Dispose();
                SfBulletGraph2 = null;
            }

            if (SfBulletGraph3 != null)
            {
                SfBulletGraph3.Dispose();
                SfBulletGraph3 = null;
            }

            base.Dispose(disposing);
        }
    }
}
