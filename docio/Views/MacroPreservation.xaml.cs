#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using System.ComponentModel;
using System.Data;
using System.IO;
using syncfusion.demoscommon.wpf;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for MacroPreservation.xaml
    /// </summary>
    public partial class MacroPreservation : DemoControl
    {
        # region Private Members
        // Create a DataSet.
        DataSet ds = new DataSet();
        # endregion

        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public MacroPreservation()
        {
            InitializeComponent();
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            ds.Clear();
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        # region Events
        /// <summary>
        /// Creates word document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Load the macro-enabled template.
                using (WordDocument document = new WordDocument())
                {
                    document.OpenReadOnly(@"Assets\DocIO\MacroTemplate.dotm", FormatType.Automatic);

                    // Get the tables from Data Set.
                    GetDataTable();

                    // Execute Mail Merge with groups.
                    document.MailMerge.ExecuteGroup(ds.Tables["Products"]);

                    ds = null;
                    ds = new DataSet();

                    try
                    {
                        //Saving the document as .docm
                        document.Save("Macro Preservation.docm", FormatType.Word2013Docm);
                        //Message box confirmation to view the created document.
                        if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Macro Preservation.docm") { UseShellExecute = true };
                                process.Start();
                            }
                            catch (Win32Exception ex)
                            {
                                MessageBox.Show("Microsoft Word Viewer or Microsoft Word is not installed in this system");
                                Console.WriteLine(ex.ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex is IOException)
                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Macro Preservation.docm" + ") then try generating the document.", "File is already open",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                        else
                            MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void GetDataTable()
        {
            // List of syncfusion products name.
            string[] products = { "DocIO", "PDF", "XlsIO" };

            // Add new Tables to the data set.
            DataRow row;
            ds.Tables.Add();

            // Add fields to the Products table.
            ds.Tables[0].TableName = "Products";
            ds.Tables[0].Columns.Add("ProductName");
            ds.Tables[0].Columns.Add("Binary");
            ds.Tables[0].Columns.Add("Source");

            // Inserting values to the tables.
            foreach (string product in products)
            {
                row = ds.Tables["Products"].NewRow();
                row["ProductName"] = string.Concat("Essential ", product);
                row["Binary"] = "$895.00";
                row["Source"] = "$1,295.00";
                ds.Tables["Products"].Rows.Add(row);
            }
        }
        /// <summary>
        /// The source template document.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click1(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Do you want to view the template document?", "Template document", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                string path = @"Assets\DocIO\MacroTemplate.dotm";
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo(path) { UseShellExecute = true };
                process.Start();
            }
        }
        # endregion
    }
}