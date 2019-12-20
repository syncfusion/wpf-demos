#region Copyright Syncfusion Inc. 2001 - 2019
//
//  Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Any infringement will be prosecuted under
//  applicable laws. 
//
#endregion
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using System.Data;
using System.ComponentModel;
using System.IO;
using System.Data.SqlServerCe;
using Syncfusion.Windows.Shared;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;

namespace LetterFormatting
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Private Members
        DataTable table;
        DataRow dr;
        # endregion

        # region Constructor and Window Load
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
        SqlCeConnection conn; SqlCeDataAdapter adapter;
        /// <summary>
        /// Gets the datasource and updates the listview on window load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Access the database and get the NorthWind
            conn = new SqlCeConnection();
            if (conn.ServerVersion.StartsWith("3.5"))
                conn.ConnectionString = "Data Source = " + (@"..\..\..\..\..\..\Common\Data\NorthwindIO_3.5.sdf");
            else
                conn.ConnectionString = "Data Source = " + (@"..\..\..\..\..\..\Common\Data\NorthwindIO.sdf");
            conn.Open();
            DataSet dataset = new DataSet();
            adapter = new SqlCeDataAdapter("Select CompanyName, ContactName, Address, City, Region, Country, Phone, Fax from Customers", conn);
            adapter.Fill(dataset);

            table = new DataTable();
            table = dataset.Tables[0];

            //Create a grid view
            GridView gridView1 = new GridView();
            gridView1.AllowsColumnReorder = true;

            //Update the grid view columns
            foreach (DataColumn column in table.Columns)
            {
                GridViewColumn column1 = new GridViewColumn();
                column1.DisplayMemberBinding = new Binding(column.ColumnName);
                column1.Header = column.ColumnName;
                gridView1.Columns.Add(column1);
            }

            //Bind the listview
            Binding bind = new Binding();
            listView1.DataContext = table;
            listView1.SetBinding(ListView.ItemsSourceProperty, bind);

            //Use gridview as listview item
            listView1.View = gridView1;
            listView1.SelectionMode = SelectionMode.Single;

            //Selects the first row as default
            listView1.SelectedIndex = 0;
        }

        # endregion

        # region Events

        /// <summary>
        /// Creates word document and executes mail merge
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            // Get Template document and database path.
            string dataPath = @"..\..\..\..\..\..\Common\Data\DocIO\";

            try
            {
                // Create a new document.
                WordDocument document = new WordDocument();

                // Loading Template.                
                document.Open(System.IO.Path.Combine(dataPath, @"Letter Formatting.doc"), FormatType.Doc);

                // Merge Template fields with user entered data.

                // Checks if data field mapping should be enabled
                if (checkBoxChoose.IsChecked.Value)
                {
                    // Merge Template fields with user entered data.
                    document.MailMerge.RemoveEmptyParagraphs = true;

                    //To clear the fields with empty value
                    document.MailMerge.ClearFields = true;

                    //Clear the map fields
                    document.MailMerge.MappedFields.Clear();

                    //Update the mapping fields
                    document.MailMerge.MappedFields.Add("Contact Name", "ContactName");
                    document.MailMerge.MappedFields.Add("Company Name", "CompanyName");
                    document.MailMerge.MappedFields.Add("CompanyAddress", "Address");
                    document.MailMerge.MappedFields.Add("Residing City", "City");
                    document.MailMerge.MappedFields.Add("Current Region", "Region");
                    document.MailMerge.MappedFields.Add("Home Country", "Country");
                }

                // Gets the selected row from the listview
                dr = table.Rows[this.listView1.SelectedIndex];

                //Mailmerge can be performed with the input as either DataRow, DataField, DataView, IDataReader 
                //or a set of merge field names and values. Here, one particular row is extraced from the table and used.

                //Executes mail merge for the selected record or row
                document.MailMerge.Execute(dr);
                conn.Close(); adapter.Dispose();

                //Add Text Watermark
                document.Watermark = new TextWatermark();
                (document.Watermark as TextWatermark).Text = "Demo";
                (document.Watermark as TextWatermark).Size = 144;

                //Save as doc format
                if (worddoc.IsChecked.Value)
                {
                    try
                    {
                        //Saving the document to disk.
                        document.Save("Sample.doc");

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
                        document.Save("Sample.docx", FormatType.Docx);
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
                        PdfDocument pdfDoc = converter.ConvertToPDF(document);
                        //Save the pdf file
                        pdfDoc.Save("Sample.pdf");
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
                else
                {
                    // Exit
                    this.Close();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSubmit_Click1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to the Template document", "Template document", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                System.Diagnostics.Process.Start(@"..\..\..\..\..\..\Common\Data\DocIO\Letter Formatting.doc");
            }
        }
        # endregion
    }
}