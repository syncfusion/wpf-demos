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
using Microsoft.Win32;
using Syncfusion.DocIO.DLS;
using System.IO;
using System.Drawing.Printing;
using System.ComponentModel;
using syncfusion.demoscommon.wpf;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Print : DemoControl

    {
        #region Fields
        private readonly BackgroundWorker worker = new BackgroundWorker();
        //Create a Image Instance
        System.Drawing.Image[] images = null;
        // Load the Document
        WordDocument wordDoc = null;
        //Image Start Index
        int startPageIndex = 0;
        // Image End Index
        int endPageIndex = 0;
        //File path
        private string fullPath;
        // create OpenFileDialog
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        #endregion

        #region Constructor
        public Print()
        {
            InitializeComponent();
            string path = @"Assets\DocIO\";
            fullPath = @"Assets\DocIO\Word to Image.docx";
            openFileDialog1.InitialDirectory = new DirectoryInfo(path).FullName;
            openFileDialog1.Filter = "Word Document(*.doc *.docx *.rtf)|*.doc;*.docx;*.rtf";
            this.textBox1.Text = "Word to Image.docx";
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            if(wordDoc!=null)
            {
                wordDoc.Close();
                wordDoc = null;
            }
            if(images!=null)
            {
                images = null;
            }
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        #region Print
        /// <summary>
        /// Print the document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToPrint_Click(object sender, RoutedEventArgs e)
        {
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }
        #endregion

        #region UITasks
        /// <summary>
        /// Run the UITasks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Dispatcher.Invoke(new Action(() => { this.loadingIndicatorCanvas.Visibility = Visibility.Collapsed; }));
            InitializeUITasks(fullPath);
        }
        /// <summary>
        /// Run the Print Dialog
        /// </summary>
        /// <param name="filePath"></param>
        private void InitializeUITasks(object filePath)
        {
            if (!this.textBox1.Text.EndsWith(".doc") && !this.textBox1.Text.EndsWith(".docx") &&
                !this.textBox1.Text.EndsWith(".rtf") && !this.textBox1.Text.EndsWith(".docm") &&
                !this.textBox1.Text.EndsWith(".dotx") && !this.textBox1.Text.EndsWith(".dotm") &&
                !this.textBox1.Text.EndsWith(".dot") && !this.textBox1.Text.EndsWith(".txt"))
            {
                MessageBox.Show("Could not recognize the current file path. Please browse a appropriate Word document(.docx, .doc, .rtf) ",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            if (!string.IsNullOrEmpty(this.textBox1.Text) && !string.IsNullOrEmpty(fullPath))
            {
                if (this.textBox1.Text.Contains("//"))
                {
                    fullPath = this.textBox1.Text;
                }

                #region PrintSettings
                //Create a PrintDialog
                System.Windows.Forms.PrintDialog printDialog = new System.Windows.Forms.PrintDialog();
                // dialog.PrinterSetting
                printDialog.Document = new PrintDocument();
                //Set all Possible print ranges as true
                printDialog.AllowCurrentPage = true;
                //printDialog.AllowSelection = true;
                printDialog.AllowSomePages = true;
                //Set the start and end page index
                printDialog.PrinterSettings.FromPage = 1;
                printDialog.PrinterSettings.ToPage = images.Length;

                #endregion
                loadingIndicatorCanvas.Visibility = Visibility.Hidden;
                # region Print
                //Open the Show dialog box for print dialog
                if (printDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //Check if the Page Range exceeds the End page
                    if (printDialog.PrinterSettings.FromPage > 0 && printDialog.PrinterSettings.ToPage <= images.Length)
                    {
                        //Set the start page of the document to print
                        startPageIndex = printDialog.PrinterSettings.FromPage - 1;
                        //Set the end page of the document to Print
                        endPageIndex = printDialog.PrinterSettings.ToPage;
                        //Retrieve the Page need to be rendered
                        printDialog.Document.PrintPage += new PrintPageEventHandler(OnPrintPage);
                        //Print the document
                        printDialog.Document.Print();
                    }
                    else
                    {
                        //If the Page range exceeds the 12
                        if (MessageBox.Show("The page range is invalid" + Environment.NewLine + "Enter numbers between 1 and " + images.Length.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                        {
                        }
                    }
                    //Dispose the print dialog
                    printDialog.Dispose();
                }
                #endregion
            }
            else
            {
                MessageBox.Show("Browse a Word document to Print", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        #endregion

        #region UITasks
        /// <summary>
        /// Run the UITask
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Dispatcher.Invoke(new Action(() => { this.loadingIndicatorCanvas.Visibility = Visibility.Visible; }));
            InitializeNonUITasks();
        }
        /// <summary>
        /// Render Word document as Image
        /// </summary>
        private void InitializeNonUITasks()
        {
            #region Renders the Word document as images
            if (File.Exists(fullPath))
            {
                //Open the Word document
                wordDoc = new WordDocument(fullPath);
                //convert the document to Image
                images = wordDoc.RenderAsImages(ImageType.Metafile);
                endPageIndex = images.Length;
                //Close the Word Document         
                wordDoc.Close();

            }
            # endregion
            else
            {
                MessageBox.Show("File doesn’t exist");
            }
        }
        # endregion

        #region Browse a Word Document
        /// <summary>
        /// Browse a input word document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog().Value)
            {
                this.textBox1.Text = openFileDialog1.SafeFileName;
                fullPath = openFileDialog1.FileName;
            }
        }
        #endregion

        #region PrintPage
        /// <summary>
        /// The PrintPage event is called for each page to be printed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnPrintPage(object sender, PrintPageEventArgs e)
        {
            //Current page width
            int currentPageWidth = images[startPageIndex].Width;
            //Current page height
            int currentPageHeight = images[startPageIndex].Height;
            //Visible clip bounds width
            int visibleClipBoundsWidth = (int)e.Graphics.VisibleClipBounds.Width;
            //Visible clip bounds height
            int visibleClipBoundsHeight = (int)e.Graphics.VisibleClipBounds.Height;
            //Check if the page layout is landscape or portrait
            if (currentPageWidth > currentPageHeight)
            {
                //Translate the Position 
                e.Graphics.TranslateTransform(0, visibleClipBoundsHeight);
                //Rotates the object at 270 degrees
                e.Graphics.RotateTransform(270.0f);
                //Draw the current page
                e.Graphics.DrawImage(images[startPageIndex], new System.Drawing.Rectangle(0, 0, currentPageWidth, currentPageHeight));
            }
            else
            {
                //Draw the current page
                e.Graphics.DrawImage(images[startPageIndex], new System.Drawing.Rectangle(0, 0, visibleClipBoundsWidth, visibleClipBoundsHeight));
            }
            //Dispose the current page
            images[startPageIndex].Dispose();
            //Increment the start page index 
            startPageIndex++;
            //check if the start page index is lesser than end page index
            if (startPageIndex < endPageIndex)
                e.HasMorePages = true;//if the document contain more than one pages
            else
                startPageIndex = 0;
        }
        #endregion
    }
}
