#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Windows.Controls;

namespace TileViewConfigurationDemo
{
    /// <summary>
    /// Interaction logic for PropertyView.xaml
    /// </summary>
    public partial class PropertyView : UserControl
    {
        public PropertyView()
        {
            InitializeComponent();
            row.MinValue = 3;
            col.MinValue = 3;
            AnimationSpan.MinValue = new TimeSpan(0, 0, 0, 0, 1);
            AnimationSpan.MaxValue = new TimeSpan(0, 0, 0, 30, 1);
        }

      
    }
}
