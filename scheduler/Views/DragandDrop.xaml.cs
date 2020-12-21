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
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace syncfusion.schedulerdemos.wpf
{
    /// <summary>
    /// Interaction logic for DragandDrop.xaml
    /// </summary>
    public partial class DragandDropDemo : DemoControl
    {
        public DragandDropDemo()
        {
            InitializeComponent();
        }

        public DragandDropDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.Schedule != null && this.listView != null)
            {
                this.Schedule.Dispose();
                this.Schedule = null;
                this.listView = null;
            }
            base.Dispose(disposing);
        }

        private void Viewtypecombobox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedValue = this.viewtypecombobox.SelectedValue.ToString();
            if (selectedValue == "TimelineDay" || selectedValue == "TimelineWeek" || selectedValue == "TimelineWorkWeek" || selectedValue == "TimelineMonth")
            {
                this.Schedule.DisplayDate = DateTime.Now.Date;
            }
            else
                this.Schedule.DisplayDate = DateTime.Now.Date.AddHours(9);
        }
    }
}
