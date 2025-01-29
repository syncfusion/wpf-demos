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
using System.IO;
using Syncfusion.DocIO;
using System.ComponentModel;
using Microsoft.Win32;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using syncfusion.demoscommon.wpf;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CloneandMerge : DemoControl
    {
        #region Fields
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string file1, file2, path;
        #endregion

        #region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public CloneandMerge()
        {
            InitializeComponent();
            path = @"Assets\DocIO\";
            textBox1.Text = "Northwind.docx";
            file1 = new DirectoryInfo(path + "Northwind.docx").FullName;
            textBox2.Text = "Adventure.docx";
            file2 = new DirectoryInfo(path + "Adventure.docx").FullName;
            openFileDialog1.InitialDirectory = new DirectoryInfo(path).FullName;
            openFileDialog1.Filter = "Word Document(*.doc *.docx *.rtf)|*.doc;*.docx;*.rtf";
            this.label1.IsEnabled = false;
            this.comboBox1.IsEnabled = false;
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
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
                // Creating a new document.
                WordDocument doc = new WordDocument();
                if ((bool)importRadioBtn.IsChecked)
                {
                    // Opens the destination template document
                    if ((string)textBox1.Text != string.Empty)
                    {
                        if (textBox1.Text.Contains("//"))
                            file1 = textBox1.Text;
                        doc = new WordDocument(file1);
                    }
                    else
                        MessageBox.Show("Browse a Word document to import", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    // Imports the source template document to destination.
                    if ((string)textBox2.Text != string.Empty)
                    {
                        if (textBox2.Text.Contains("//"))
                            file2 = textBox2.Text;
                        doc.ImportContent(new WordDocument(file2), GetImportOption(comboBox1.SelectedIndex));
                    }
                    else
                        MessageBox.Show("Browse a Word document to import", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    // Clones the first template document
                    if (textBox1.Text != string.Empty)
                    {
                        if (textBox1.Text.Contains("//"))
                            file1 = textBox1.Text;
                        CloneDocument(doc, file1);
                    }
                    else
                        MessageBox.Show("Browse a Word document to clone", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    // Clones the second template document
                    if (textBox2.Text != string.Empty)
                    {
                        if (textBox2.Text.Contains("//"))
                            file2 = textBox2.Text;
                        CloneDocument(doc, file2);
                    }
                    else
                        MessageBox.Show("Browse a Word document to clone", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                //Save as doc format
                if (worddoc.IsChecked.Value)
                {
                    try
                    {
                        //Saving the document to disk.
                        doc.Save("Clone and Merge.doc");

                        //Message box confirmation to view the created document.
                        if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Clone and Merge.doc") { UseShellExecute = true };
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
                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Clone and Merge.doc" + ") then try generating the document.", "File is already open",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
                        else
                            MessageBox.Show("Document could not be generated, Could you please email the error details with along input document to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                //Save as docx format
                else if (worddocx.IsChecked.Value)
                {
                    try
                    {
                        //Saving the document as .docx
                        doc.Save("Clone and Merge.docx", FormatType.Docx);
                        //Message box confirmation to view the created document.
                        if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Clone and Merge.docx") { UseShellExecute = true };
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
                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Clone and Merge.doc" + ") then try generating the document.", "File is already open",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
                        else
                            MessageBox.Show("Document could not be generated, Could you please email the error details with along input document to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
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
                        pdfDoc.Save("Clone and Merge.pdf");
                        pdfDoc.Close();
                        converter.Dispose();
                        //Message box confirmation to view the created document.
                        if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Clone and Merge.pdf") { UseShellExecute = true };
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
                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Clone and Merge.doc" + ") then try generating the document.", "File is already open",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
                        else
                            MessageBox.Show("Document could not be generated, Could you please email the error details with along input document to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                doc.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Returns the ImportOption.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private ImportOptions GetImportOption(int value)
        {
            switch (value)
            {
                case 0:
                    return ImportOptions.KeepSourceFormatting;
                case 1:
                    return ImportOptions.MergeFormatting;
                case 2:
                    return ImportOptions.KeepTextOnly;
                case 3:
                    return ImportOptions.UseDestinationStyles;
                case 4:
                    return ImportOptions.ListContinueNumbering;
                case 5:
                    return ImportOptions.ListRestartNumbering;
            }
            return ImportOptions.UseDestinationStyles;
        }
        /// <summary>
        /// Clones the document.
        /// </summary>
        /// <param name="srcDoc">The SRC doc.</param>
        /// <param name="fileName">Name of the file.</param>
        private void CloneDocument(WordDocument srcDoc, string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    // Read the template document
                    WordDocument document = new WordDocument(fileName);
                    // Enumerate all the sections from the template document.
                    foreach (IWSection sec in document.Sections)
                    {
                        // Cloning all the sections one by one and merging it to the new document.
                        srcDoc.Sections.Add(sec.Clone());
                        // Setting section break code to be the same as the template.
                        srcDoc.LastSection.BreakCode = sec.BreakCode;
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
                MessageBox.Show("File doesn’t exist");
        }
        /// <summary>
        /// Handles the Click event of the btnBrowse control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog().Value)
            {
                this.textBox1.Text = openFileDialog1.SafeFileName;
                file1 = openFileDialog1.FileName;
            }
        }
        /// <summary>
        /// Handles the Click event of the btnBrowse1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void btnBrowse1_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog().Value)
            {
                this.textBox2.Text = openFileDialog1.SafeFileName;
                file2 = openFileDialog1.FileName;
            }
        }
        private void ImportRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            this.comboBox1.IsEnabled = true;
            this.label1.IsEnabled = true;
        }
        private void cloneRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (this.comboBox1 != null && this.label1 != null)
            {
                this.comboBox1.IsEnabled = false;
                this.label1.IsEnabled = false;
            }
        }
        #endregion
    }
}