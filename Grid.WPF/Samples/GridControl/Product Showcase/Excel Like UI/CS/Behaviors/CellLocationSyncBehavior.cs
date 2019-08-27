#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using EXCEL.Helpers;
using EXCEL.ViewModel;

namespace EXCEL.Behaviors
{
    public class CellLocationSyncBehavior : Behavior<SampleGridControl>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.CellLocationTextChanged += new EventHandler(AssociatedObject_CellLocationTextChanged);
        }

        void AssociatedObject_CellLocationTextChanged(object sender, EventArgs e)
        {
            var dataContext = AssociatedObject.DataContext as MainViewModel;
            if (dataContext != null)
            {
                dataContext.CellLocationText = this.AssociatedObject.CellLocationText;
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.CellLocationTextChanged -= new EventHandler(AssociatedObject_CellLocationTextChanged);
        }
    }
}
