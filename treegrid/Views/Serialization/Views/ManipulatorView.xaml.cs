#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;

namespace syncfusion.treegriddemos.wpf
{
    /// <summary>
    /// Interaction logic for ManipulatorView.xaml
    /// </summary>
    public partial class ManipulatorView : Window
    {
        public static ManipulatorView manipulatorView;
        public ManipulatorView()
        {
            InitializeComponent();
            manipulatorView = this;
        }
    }
}
