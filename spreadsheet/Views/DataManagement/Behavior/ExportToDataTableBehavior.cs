#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Microsoft.Xaml.Behaviors;
using System.Data;
using Syncfusion.UI.Xaml.Spreadsheet;

namespace syncfusion.spreadsheetdemos.wpf
{
    class ExportToDataTableBehavior : Behavior<SfSpreadsheet>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }

        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = ReadXml(ds, @"Data\Spreadsheet\Customers.xml");
                this.AssociatedObject.ActiveSheet.ImportDataTable(ds.Tables[0], true, 1, 1);
                this.AssociatedObject.ActiveGrid.InvalidateCells();
            }
            catch (Exception)
            { }
        }
        internal DataSet ReadXml(DataSet ds,string filePath)
        {
            ds.ReadXml(filePath);
            return ds;
        }
        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }
    }
}
