#region Copyright Syncfusion Inc. 2001 - 2020
//
//  Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Any infringement will be prosecuted under
//  applicable laws. 
//
#endregion
using System;
using System.Windows;
using System.Windows.Media;
using System.Data;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using System.ComponentModel;
using System.IO;
using System.Data.SqlServerCe;
using Syncfusion.Windows.Shared;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;

namespace SalesInvoice
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Private Members
        string dataPath = null;
        WordDocument doc = null;
        SqlCeConnection conn;
        string connectionstring;
        # endregion

        # region Constructor and Load
        /// <summary>
        /// Window constructor
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
            image1.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\Common\Images\DocIO\docio_header.png");
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\Common\Images\DocIO\sfLogo.ico");
        }

        /// <summary>
        /// Window load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Get all customer ID's from database and add to the list box.
            try
            {
                // Get Template document and database path.
                dataPath = @"..\..\..\..\..\..\Common\Data\DocIO\";
                //Access the database and get the NorthWind
                conn = new SqlCeConnection();
                if (conn.ServerVersion.StartsWith("3.5"))
                    conn.ConnectionString = "Data Source = " + @"..\..\..\..\..\..\Common\Data\NorthwindIO_3.5.sdf";
                else
                    conn.ConnectionString = "Data Source = " + @"..\..\..\..\..\..\Common\Data\NorthwindIO.sdf";
                conn.Open();
                SqlCeDataAdapter adapter = new SqlCeDataAdapter("select OrderID  from SyncOrders Order By OrderID", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                adapter.Dispose();
                // Add Customer ID to the list box.
                foreach (DataRow row in dt.Rows)
                    listCustomer.Items.Add(row["OrderID"]);
                listCustomer.SelectedIndex = 0;
            }
            catch (Exception Ex)
            {
                // Shows the Message box with Exception message, if an exception is thrown.
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        # endregion

        # region Events
        /// <summary>
        /// Merge field event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void MailMerge_MergeField(object sender, MergeFieldEventArgs args)
        {
            // Conditionally format data during Merge.
            if (args.RowIndex % 2 == 0)
                args.CharacterFormat.TextColor = System.Drawing.Color.DarkBlue;
        }

        /// <summary>
        /// Creates word document with mail merge
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listCustomer.SelectedItems.Count > 0)
                {
                    // Generate Invoice for the selected ID.
                    ExecuteMail_Doc((int)listCustomer.SelectedItem);

                    if (worddoc.IsChecked.Value)
                    {
                        //Message box confirmation to view the created document.
                        if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                System.Diagnostics.Process.Start("Sample.doc");
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

                    else if (worddocx.IsChecked.Value)
                    {
                        //Message box confirmation to view the created document.
                        if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                System.Diagnostics.Process.Start("Sample.docx");
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

                    else if (pdf.IsChecked.Value)
                    {
                        //Message box confirmation to view the created document.
                        if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                System.Diagnostics.Process.Start("Sample.pdf");
                                //Exit
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("PDF Viewer is not installed in this system");
                                Console.WriteLine(ex.ToString());
                            }
                        }
                    }
                    else
                    {
                        // Exit
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select the Customers From ListBox");
                }
            }
            catch (Exception Ex)
            {
                // Shows the Message box with Exception message, if an exception is thrown.
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        /// <summary>
        /// Opens the template document.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonView_Click(object sender, RoutedEventArgs e)
        {
            //Opens the template document.
            //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
            System.Diagnostics.Process.Start(System.IO.Path.Combine(dataPath, @"SalesInvoiceDemo.doc"));
        }
        # endregion

        # region Helpher Methods
        /// <summary>
        /// Mail merge
        /// </summary>
        /// <param name="ID"></param>
        private void ExecuteMail_Doc(int ID)
        {

            // Create a new document
            doc = new WordDocument();

            // Load the template.
            doc.Open(System.IO.Path.Combine(dataPath, @"SalesInvoiceDemo.doc"), FormatType.Automatic);
            // Execute Mail Merge with groups.
            doc.MailMerge.ExecuteGroup(GetTestOrder(ID));
            doc.MailMerge.ExecuteGroup(GetTestOrderTotals(ID));

            // Using Merge events to do conditional formatting during runtime.
            doc.MailMerge.MergeField += new MergeFieldEventHandler(MailMerge_MergeField);

            DataView orderDetails = new DataView(GetTestOrderDetails(ID));
            orderDetails.Sort = "ExtendedPrice DESC";
            doc.MailMerge.ExecuteGroup(orderDetails);

            //Save as doc  format
            if (worddoc.IsChecked.Value)
            {
                try
                {
                    //Saving the document to disk.
                    doc.Save("Sample.doc", FormatType.Doc);
                }
                catch (Exception ex)
                {
                    if (ex is IOException)
                        MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Sample.doc" + ") then try generating the document.", "File is already open",
                              MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                        MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting"+ "\r\n" + ex.ToString(), "Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            //Save as docx format
            else if (worddocx.IsChecked.Value)
            {
                try
                {
                    //Saving the document as .docx
                    doc.Save("Sample.docx", FormatType.Docx);
                }
                catch (Exception ex)
                {
                    if (ex is IOException)
                        MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Sample.doc" + ") then try generating the document.", "File is already open",
                             MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                        MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting"+ "\r\n" + ex.ToString(), "Error",
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
                    PdfDocument pdfDoc = converter.ConvertToPDF(doc);
                    //Save the pdf file
                    pdfDoc.Save("Sample.pdf");
                }
                catch (Exception ex)
                {
                    if (ex is IOException)
                        MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Sample.doc" + ") then try generating the document.", "File is already open",
                             MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                        MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting"+ "\r\n" + ex.ToString(), "Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private DataTable GetTestOrder(int TestOrderId)
        {
            DataTable table = new DataTable();
            table = ExecuteDataTable(string.Format("SELECT * FROM SyncOrders WHERE OrderId = {0}", TestOrderId));
            table.TableName = "Orders";
            return table;
        }

        private DataTable GetTestOrderDetails(int TestOrderId)
        {
            DataTable table = new DataTable();
            table = ExecuteDataTable(string.Format("SELECT * FROM SyncOrderDetails WHERE OrderId = {0} ORDER BY ProductID", TestOrderId)); table.TableName = "Order";
            return table;
        }

        private DataTable GetTestOrderTotals(int TestOrderId)
        {
            DataTable table = ExecuteDataTable(string.Format("SELECT * FROM SyncOrderTotals WHERE OrderId = {0}", TestOrderId));
            table.TableName = "OrderTotals";
            return table;
        }

        private DataTable ExecuteDataTable(string commandText)
        {
            // Return DataTable
            try
            {
                SqlCeDataAdapter adapter = new SqlCeDataAdapter(commandText, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            finally
            {
            }
        }
        # endregion
    }
}
