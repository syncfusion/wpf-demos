#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Controls;
using syncfusion.demoscommon.wpf;

namespace syncfusion.schedulerdemos.wpf
{
    /// <summary>
    /// Interaction logic for LoadOnDemand.xaml
    /// </summary>
    public partial class LoadOnDemandDemo : DemoControl
    {
        public LoadOnDemandDemo()
        {
            InitializeComponent();
        }

        public LoadOnDemandDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }
        protected override void Dispose(bool disposing)
        {
            if (this.Schedule != null)
            {
                this.Schedule.Dispose();
                this.Schedule = null;
            }
            base.Dispose(disposing);
        }

        private void Viewtypecombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
