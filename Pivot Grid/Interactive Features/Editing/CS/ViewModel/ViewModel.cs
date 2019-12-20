#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace PivotEditing.ViewModel
{
    using Model;
    using System.Data;

    public class ViewModel
    {
        private DataView dataTableViewSource;

        public DataView BusinessObjectAsDataView
        {
            get 
            {
                this.dataTableViewSource = this.dataTableViewSource ?? BusinessObjectsDataView.GetDataTable(200);
                return this.dataTableViewSource;
            }
            set { this.dataTableViewSource = value; }
        }
    }
}