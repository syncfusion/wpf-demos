#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XlsIO;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;

namespace syncfusion.invoice.wpf
{
    public class ExportToExcel
    {
        public  void GenerateReport(IList<InvoiceItem> items, BillingInformation billInfo)
        {
            Assembly assembly = typeof(ExportToExcel).Assembly;
            Stream inputStream = assembly.GetManifestResourceStream("Invoice.Assets.InvoiceTemplate.xlsx");
            ExcelEngine excelEngine = new ExcelEngine();
            IWorkbook book = excelEngine.Excel.Workbooks.Open(inputStream);
            inputStream.Dispose();

            //Create Template Marker Processor
            ITemplateMarkersProcessor marker = book.CreateTemplateMarkersProcessor();
            //Binding the business object with the marker.
            marker.AddVariable("InvoiceItem", items);
            marker.AddVariable("BillInfo", billInfo);
            marker.AddVariable("Company", billInfo);
            //Applies the marker.
            marker.ApplyMarkers(UnknownVariableAction.Skip);

            book.SaveAs("Invoice.xlsx");

            //Save as Docx format
            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the Excel file?", "Excel Document  Created",
                 MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
#if !NETCORE
                System.Diagnostics.Process.Start("Invoice.xlsx");
#else
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    Arguments = "/c start Invoice.xlsx"
                };
                Process.Start(psi);
#endif
                //this.Close();
            }
            book.Close();
            excelEngine.Dispose();

            

        }
    }
}
