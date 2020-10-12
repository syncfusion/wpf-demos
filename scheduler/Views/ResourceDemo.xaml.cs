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
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using syncfusion.demoscommon.wpf;

namespace syncfusion.schedulerdemos.wpf
{
    /// <summary>
    /// Interaction logic for ResourceDemo.xaml
    /// </summary>
    public partial class ResourceDemo : DemoControl
    {
        public ResourceDemo()
        {
            InitializeComponent();
        }
        public ResourceDemo(string themename) : base(themename)
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

        private void SchedulerViewTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.schedulerViewTypeComboBox.SelectedValue.ToString() == "Timeline")
            {
                this.Schedule.DisplayDate = DateTime.Now.Date;
            }
            else
                this.Schedule.DisplayDate = DateTime.Now.Date.AddHours(9);
        }
    }
}
