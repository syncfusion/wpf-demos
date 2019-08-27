#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Scroll;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.GridCommon;
using System.Windows.Media;


namespace Syncfusion.WpfGridSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : ChromelessWindow
    {

        public Window1()
        {
            InitializeComponent();
            // An Optimization. Allow live controls inside cell to be reused when scrolled out of view.
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.grid.MouseControllerDispatcher.TrackMouse = this.grid.GetClipRect(ScrollAxisRegion.Body, ScrollAxisRegion.Body);
        }

    }
}