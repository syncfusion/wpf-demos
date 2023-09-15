#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows.Input;
using System.Data;
using Syncfusion.UI.Xaml.Spreadsheet;

namespace syncfusion.spreadsheetdemos.wpf
{
    public static class ImportCommand
    {
        static ImportCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(SfSpreadsheet), new CommandBinding(ImportFromDataTable, OnExecuteImportFromDataTable, OnCanExecuteImportFromDataTable));
        }

        public static RoutedCommand ImportFromDataTable = new RoutedCommand("ImportFromDataTable", typeof(SfSpreadsheet));

        private static DataSet ReadXml(DataSet ds, string filePath)
        {
            ds.ReadXml(filePath);
            return ds;
        }
        private static void OnExecuteImportFromDataTable(object sender, ExecutedRoutedEventArgs args)
        {
            SfSpreadsheet Spreadsheet = args.Source as SfSpreadsheet;
            if (Spreadsheet != null && args.Parameter != null)
            {
                Spreadsheet.Create(3);
                string SelectedItem = args.Parameter.ToString();
                DataSet ds = new DataSet();
                if (SelectedItem.Contains("Products"))                  
                    ds = ReadXml(ds, @"Data\Spreadsheet\Products.xml");
                else if (SelectedItem.Contains("Orders"))
                    ds = ReadXml(ds, @"Data\Spreadsheet\Orders.xml");       
                else
                    ds = ReadXml(ds, @"Data\Spreadsheet\Customers.xml");

                Spreadsheet.ActiveSheet.ImportDataTable(ds.Tables[0], true, 1, 1);
                for (int i = 1; i <= Spreadsheet.ActiveSheet.UsedRange.LastColumn; i++)
                {
                    Spreadsheet.ActiveSheet.AutofitColumn(i);
                    Spreadsheet.ActiveGrid.SetColumnWidth(i, i, Spreadsheet.ActiveSheet.GetColumnWidthInPixels(i));
                }
                Spreadsheet.ActiveGrid.InvalidateCells();
            }
        }

        private static void OnCanExecuteImportFromDataTable(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}
