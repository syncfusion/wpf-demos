#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
using syncfusion.demoscommon.wpf;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.avatarviewdemo.wpf.Views
{
    /// <summary>
    /// Interaction logic for GroupViewDemo.xaml
    /// </summary>
    public partial class GroupViewDemo : DemoControl, IDisposable
    {
        public GroupViewDemo()
        {
            InitializeComponent();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.listView != null)
                {
                    this.listView.ItemsSource = null;
                    this.listView = null;
                }
                base.Dispose(disposing);
            }
        }
    }
}
