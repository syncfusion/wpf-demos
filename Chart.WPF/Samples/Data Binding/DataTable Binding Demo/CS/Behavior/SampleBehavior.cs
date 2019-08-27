#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Windows.Interactivity;

namespace DataTableBindingDemo
{
    public class SampleBehavior:Behavior<Window1>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            DataViewModel datamodel = new DataViewModel();
            this.AssociatedObject.SyncUIChart.Areas[0].PrimaryAxis.LabelsSource = datamodel.Data;
            this.AssociatedObject.SyncUIChart.Areas[0].Series[0].DataSource = datamodel.Data;
            this.AssociatedObject.SyncUIChart.Areas[0].Series[1].DataSource = datamodel.Data;
        }
    }
}
