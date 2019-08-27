#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows;

namespace Invoice
{
    /// <summary>
    /// Helper Class to export invoice details to a Word document
    /// </summary>
    class ExportWord
    {
        /// <summary>
        /// Export the UI data to Word document.
        /// </summary>
        /// <param name="invoiceItems">The InvoiceItems.</param>
        /// <param name="billInfo">The BillingInformation.</param>
        /// <param name="totalDue">The TotalDue.</param>
        public void CreateWord(IList<InvoiceItem> invoiceItems, BillingInformation billInfo, double totalDue)
        {
            try
            {
                //Load Template document stream
                Assembly assembly = typeof(MainPage).Assembly;
                Stream inputStream = assembly.GetManifestResourceStream("Invoice.Assets.Template.docx");
                //Create instance
                WordDocument document = new WordDocument();
                //Open Template document
                document.Open(inputStream, FormatType.Word2013);
                //Dispose input stream
                inputStream.Dispose();

                //Set Clear Fields to false
                document.MailMerge.ClearFields = false;
                //Create Mail Merge Data Table
                MailMergeDataTable mailMergeDataTable = new MailMergeDataTable("Invoice", invoiceItems);
                //Executes mail merge using the data generated in the app.
                document.MailMerge.ExecuteGroup(mailMergeDataTable);

                //Mail Merge Billing information
                string[] fieldNames = { "Name", "Address", "Date", "InvoiceNumber", "DueDate", "TotalDue" };
                string[] fieldValues = { billInfo.Name, billInfo.Address, billInfo.Date.ToString("d"), billInfo.InvoiceNumber, billInfo.DueDate.ToString("d"), totalDue.ToString("#,###.00", CultureInfo.InvariantCulture) };
                document.MailMerge.Execute(fieldNames, fieldValues);
                try
                {
                    //Create Output file in Document library location
                    document.Save("Invoice.docx", FormatType.Docx);

                    //Save as Docx format
                    //Message box confirmation to view the created PDF document.
                    if (MessageBox.Show("Do you want to view the Word file?", "Word Document  Created",
                         MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            //Launching the PDF file using the default Application.[Acrobat Reader]
                            System.Diagnostics.Process.Start("Invoice.docx");
                            //this.Close();
                        }
                        catch (Win32Exception ex)
                        {
                            MessageBox.Show("Word 2013 is not installed in this system");
                            Console.WriteLine(ex.ToString());
                        }
                    }
                    //Close instance
                    document.Close();
                }
                catch (Exception ex)
                {
                    if (ex is IOException)
                        MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Invoice.docx" + ") then try generating the document using DocIO.", "File is already open",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                        MessageBox.Show("The input document could not be processed, Could you please email the document to support@syncfusion.com for trouble shooting", "Error",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
