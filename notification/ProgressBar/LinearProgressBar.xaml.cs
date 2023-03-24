#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using syncfusion.demoscommon.wpf;

namespace syncfusion.notificationdemos.wpf
{
    /// <summary>
    /// Interaction logic for LinearProgressBar.xaml
    /// </summary>
    public partial class LinearProgressBar : DemoControl
    {
        public LinearProgressBar()
        {
            InitializeComponent();
        }

        public LinearProgressBar(string themename) : base(themename)
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
            base.Dispose(disposing);
        }
    } 
}
