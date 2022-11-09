#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.NavigationDrawer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace syncfusion.navigationdemos.wpf
{
    public partial class FooterItems : DemoControl
    {
        public FooterItems()
        {
            InitializeComponent();
        }

        public FooterItems(string themename) : base(themename)
        {
            InitializeComponent();
            UserControl userControl = new SamplePage3();
            contentView.Content = userControl.Content;
        }
    }
}