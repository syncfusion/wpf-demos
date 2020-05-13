#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows;
using System.Windows.Media;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using System.ComponentModel;
using System.Data;
using Syncfusion.Windows.Shared;
using System.IO;

namespace Macro_Preservation
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Private Members
        // Create a DataSet.
        DataSet ds = new DataSet();
        # endregion

        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
#if NETCORE
            image1.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\DocIO\docio_header.png");
            this.Icon =(ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\DocIO\sfLogo.ico");
#else
            image1.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\Common\Images\DocIO\docio_header.png");
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\Common\Images\DocIO\sfLogo.ico");
#endif 
        }
        # endregion

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
                WordDocument document = new WordDocument();				
#if NETCORE
                document.OpenReadOnly(@"..\..\..\..\..\..\..\Common\Data\DocIO\MacroTemplate.dotm", FormatType.Automatic);
#else
                document.OpenReadOnly(@"..\..\..\..\..\..\Common\Data\DocIO\MacroTemplate.dotm", FormatType.Automatic);
#endif

                // Get the tables from Data Set.
                GetDataTable();

                // Execute Mail Merge with groups.
                document.MailMerge.ExecuteGroup(ds.Tables["Products"]);

                ds = null;
                ds = new DataSet();

                try
                {
                    //Saving the document as .docm
                    document.Save("Sample.docm", FormatType.Word2013Docm);
                    //Message box confirmation to view the created document.
                    if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
#if NETCORE
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            process.StartInfo = new System.Diagnostics.ProcessStartInfo("Sample.docm") { UseShellExecute = true };
                            process.Start();
#else
                            System.Diagnostics.Process.Start("Sample.docm");
#endif
                            //Exit
                            this.Close();
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
                        MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Sample.docm" + ") then try generating the document.", "File is already open",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                        MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting"+ "\r\n" + ex.ToString(), "Error",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
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

#if NETCORE
            string path = @"..\..\..\..\..\..\..\Common\Data\DocIO\MacroTemplate.dotm";
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(path) { UseShellExecute = true };
            process.Start();
#else
            string path = @"..\..\..\..\..\..\Common\Data\DocIO\MacroTemplate.dotm";
            System.Diagnostics.Process.Start(path);
#endif
        }
        # endregion
    }
}