#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using System.Windows.Controls;
using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.SmithChart;
using System;

namespace syncfusion.smithchartdemos.wpf
{
    /// <summary>
    /// Interaction logic for Customization.xaml
    /// </summary>
    public partial class Customization : DemoControl
    {
        public Customization()
        {
            InitializeComponent();
        }

        public Customization(string themename) : base(themename)
        {
            InitializeComponent();
        }
    }
}
