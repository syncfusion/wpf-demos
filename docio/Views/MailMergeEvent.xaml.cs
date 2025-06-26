#region Copyright Syncfusion Inc. 2001 - 2017
//
//  Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Any infringement will be prosecuted under
//  applicable laws. 
//
#endregion
using System;
using System.Windows;
using Syncfusion.DocIO.DLS;
using System.Data;
using Syncfusion.DocIO;
using System.ComponentModel;
using System.IO;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using syncfusion.demoscommon.wpf;
using System.Reflection;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MailMergeEvent : DemoControl
    {
        # region Private Members
        WordDocument document;
        DataSet ds = new DataSet();
        # endregion

        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public MailMergeEvent()
        {
            InitializeComponent();
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            if (document != null)
            {
                document.Close();
                document = null;
            }
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Load the template.                
                document = new WordDocument(@"Assets\DocIO\Template.doc");
                // Get the tables from Data Set.
                GetDataTable();

                // Using Merge events to do conditional formatting during runtime.
                document.MailMerge.MergeField += new MergeFieldEventHandler(AlternateRows_MergeField);
                document.MailMerge.MergeImageField += new MergeImageFieldEventHandler(MergeField_ProductImage);

                // Execute Mail Merge with groups.
                document.MailMerge.ExecuteGroup(ds.Tables["Products"]);
                document.MailMerge.ExecuteGroup(ds.Tables["Product_PriceList"]);
                ds = null;
                ds = new DataSet();
                //Save as doc format
                if (worddoc.IsChecked.Value)
                {
                    try
                    {
                        //Saving the document to disk.
                        document.Save("Mail Merge Event.doc");

                        //Message box confirmation to view the created document.
                        if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Mail Merge Event.doc") { UseShellExecute = true };
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
                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Mail Merge Event.doc" + ") then try generating the document.", "File is already open",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                        else
                            MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                //Save as docx format
                else if (worddocx.IsChecked.Value)
                {
                    try
                    {
                        //Saving the document as .docx
                        document.Save("Mail Merge Event.docx", FormatType.Docx);
                        //Message box confirmation to view the created document.
                        if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Mail Merge Event.docx") { UseShellExecute = true };
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
                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Mail Merge Event.doc" + ") then try generating the document.", "File is already open",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                        else
                            MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                //Save as pdf format
                else if (pdf.IsChecked.Value)
                {
                    try
                    {
                        DocToPDFConverter converter = new DocToPDFConverter();
                        //Convert word document into PDF document
                        PdfDocument pdfDoc = converter.ConvertToPDF(document);
                        //Save the pdf file
                        pdfDoc.Save("Mail Merge Event.pdf");
                        pdfDoc.Close();
                        converter.Dispose();
                        //Message box confirmation to view the created document.
                        if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Mail Merge Event.pdf") { UseShellExecute = true };
                                process.Start();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("PDF Viewer is not installed in this system");
                                Console.WriteLine(ex.ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex is IOException)
                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Mail Merge Event.doc" + ") then try generating the document.", "File is already open",
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

        # region Merge Events
        private void AlternateRows_MergeField(object sender, MergeFieldEventArgs args)
        {
            // Conditionally format data during Merge.
            if (args.RowIndex % 2 == 0)
            {
                args.CharacterFormat.TextColor = System.Drawing.Color.FromArgb(255, 102, 0);
            }
        }

        private void MergeField_ProductImage(object sender, MergeImageFieldEventArgs args)
        {
            // Get the image from disk during Merge.
            if (args.FieldName == "ProductImage")
            {
                string ProductFileName = args.FieldValue.ToString();
                args.Image = System.Drawing.Image.FromStream(GetFileStream(ProductFileName));
            }
        }
        # endregion

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to view the template document?", "Template Document", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]                
                string path = @"Assets\DocIO\Template.doc";
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo(path) { UseShellExecute = true };
                process.Start();
            }
        }
        # endregion

        # region Helpher Methods
        /// <summary>
        /// Creates data table
        /// </summary>
        private void GetDataTable()
        {
            // List of syncfusion products name.
            string[] products = { "Apple Juice", "Grape Juice", "Hot Soup", "Tender Coconut", "Vennila", "Strawberry", "Cherry", "Cone" };

            // Add new Tables to the data set.
            DataRow row;
            ds.Tables.Add();
            ds.Tables.Add();

            // Add fields to the Product_PriceList table.
            ds.Tables[0].TableName = "Product_PriceList";
            ds.Tables[0].Columns.Add("ProductName");
            ds.Tables[0].Columns.Add("Price");

            // Add fields to the Products table.
            ds.Tables[1].TableName = "Products";
            ds.Tables[1].Columns.Add("SNO");
            ds.Tables[1].Columns.Add("ProductName");
            ds.Tables[1].Columns.Add("ProductImage");

            int count = 0;

            // Inserting values to the tables.
            foreach (string product in products)
            {
                row = ds.Tables["Product_PriceList"].NewRow();
                row["ProductName"] = product;
                switch (product)
                {
                    case "Apple Juice":
                        row["Price"] = "$12.00"; break;
                    case "Grape Juice":
                        row["Price"] = "$15.00"; break;
                    case "Hot Soup":
                        row["Price"] = "$20.00"; break;
                    case "Tender coconut":
                        row["Price"] = "$10.00"; break;
                    case "Vennila Ice Cream":
                        row["Price"] = "$15.00"; break;
                    case "Strawberry":
                        row["Price"] = "$18.00"; break;
                    case "Cherry":
                        row["Price"] = "$25.00"; break;
                    default:
                        row["Price"] = "$20.00"; break;
                }

                ds.Tables["Product_PriceList"].Rows.Add(row);

                count++;
                row = ds.Tables["Products"].NewRow();
                row["SNO"] = count.ToString();
                row["ProductName"] = product;
                row["ProductImage"] = string.Concat(product, ".png");
                ds.Tables["Products"].Rows.Add(row);
            }
        }

        /// <summary>
        /// Get the file as stream from assets
        /// </summary>
        private Stream GetFileStream(string fileName)
        {
            Assembly assembly = typeof(MailMergeEvent).Assembly;
            return assembly.GetManifestResourceStream("syncfusion.dociodemos.wpf.Assets.DocIO." + fileName);
        }

        # endregion
    }
}