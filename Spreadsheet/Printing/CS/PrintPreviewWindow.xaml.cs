#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.ExcelToPdfConverter;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.UI.Xaml.CellGrid;
using Syncfusion.UI.Xaml.Spreadsheet;
using Syncfusion.UI.Xaml.Spreadsheet.Helpers;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Printing_2012  
{
    /// <summary>
    /// Interaction logic for PrintPreviewWindow.xaml
    /// </summary>
    public partial class PrintPreviewWindow : RibbonWindow
    {
        /// <summary>
        /// Gets or sets the sfspreadsheet.
        /// </summary>
        public SfSpreadsheet Spreadsheet
        {
            get;
            set;
        }
        MemoryStream pdfstream;
        IWorkbook workbook;

        # region Constructor

        /// <summary>
        /// Initialize the required objects through constructor.
        /// </summary>
        public PrintPreviewWindow()
        {
            InitializeComponent();
            ImageSourceConverter converter = new ImageSourceConverter();
            this.ShowHelpButton = false;

            if (Application.Current != null)
            {
                var mainWindow = Application.Current.MainWindow as ChromelessWindow;
                if (mainWindow != null)
                    this.Owner = mainWindow;
            }
            pdfViewerControl1.IsBookmarkEnabled = false;
        }

        # endregion

        # region Events


        /// <summary>
        /// Loads PDF on load and initializes controls in custom toolbar.
        /// </summary>

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            workbook = Spreadsheet.Workbook.Clone();
            var maxSize = 10000000;

            var thread = new Thread(LoadDocumentToPdfViewer, maxSize);
            thread.Start();
            thread.Join();
            //Load the pdfstream to pdfviewercontrol.
            pdfViewerControl1.Load(pdfstream);
            pdfViewerControl1.CurrentPageChanged += pdfViewerControl1_CurrentPageChanged;
            lblTotalPageCount.Text = pdfViewerControl1.PageCount.ToString();
            txtCurrentPageIndex.Text = "1";
            if (pdfViewerControl1.LoadedDocument == null)
            {
                FitWidth.IsEnabled = false;
                FitPage.IsEnabled = false;
                Last.IsEnabled = false;
                First.IsEnabled = false;
                Previous.IsEnabled = false;
                Next.IsEnabled = false;
                Print1.IsEnabled = false;
                ZoomIn.IsEnabled = false;
                ZoomOut.IsEnabled = false;
                txtCurrentPageIndex.IsEnabled = false;
                ZoomComboBox.IsEnabled = false;
                pageSeparator.IsEnabled = false;
                lblTotalPageCount.IsEnabled = false;
                ZoomPercentage.IsEnabled = false;
            }
        }

        private void LoadDocumentToPdfViewer()
        {
            workbook.Worksheets[0].EnableSheetCalculations();
            workbook.Worksheets[0].CalcEngine.AllowShortCircuitIFs = true;
            workbook.Worksheets[0].CalcEngine.MaximumRecursiveCalls = 10000;

            //Create Memory Stream to save pdfdocument.
            pdfstream = new MemoryStream();

            ExcelToPdfConverter converter = new ExcelToPdfConverter(workbook);
            //Intialize the PdfDocument
            PdfDocument pdfDoc = new PdfDocument();

            //Intialize the ExcelToPdfConverter Settings
            ExcelToPdfConverterSettings settings = new ExcelToPdfConverterSettings();
            settings.LayoutOptions = LayoutOptions.NoScaling;

            //Assign the PdfDocument to the templateDocument property of ExcelToPdfConverterSettings
            settings.TemplateDocument = pdfDoc;
            settings.DisplayGridLines = GridLinesDisplayStyle.Invisible;

            //Convert Excel Document into PDF document
            pdfDoc = converter.Convert(settings);

            //Save the PDF file
            pdfDoc.Save(pdfstream);
        }


        void pdfViewerControl1_CurrentPageChanged(object sender, EventArgs args)
        {
            txtCurrentPageIndex.Text = pdfViewerControl1.CurrentPageIndex.ToString();
            if (pdfViewerControl1.CurrentPage == 1)
            {
                First.IsEnabled = false;
                Previous.IsEnabled = false;

            }
            else
            {
                First.IsEnabled = true;
                Previous.IsEnabled = true;

            }
            if (pdfViewerControl1.CurrentPage == pdfViewerControl1.LoadedDocument.Pages.Count)
            {
                Last.IsEnabled = false;

                Next.IsEnabled = false;
            }
            else
            {
                Last.IsEnabled = true;

                Next.IsEnabled = true;
            }
        }

        /// <summary>
        /// Handles first page navigation.
        /// </summary>
        private void First_Click(object sender, RoutedEventArgs e)
        {
            if (pdfViewerControl1.LoadedDocument != null)
            {
                pdfViewerControl1.GotoPage(1);
                txtCurrentPageIndex.Text = pdfViewerControl1.CurrentPageIndex.ToString();

            }

        }

        /// <summary>
        /// Handles previous page navigation.
        /// </summary>
        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (pdfViewerControl1.LoadedDocument != null)
            {
                pdfViewerControl1.GotoPage(pdfViewerControl1.CurrentPageIndex - 1);
                txtCurrentPageIndex.Text = pdfViewerControl1.CurrentPageIndex.ToString();

            }
        }

        /// <summary>
        /// Handles next page navigation.
        /// </summary>
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (pdfViewerControl1.LoadedDocument != null)
            {
                pdfViewerControl1.GotoPage(pdfViewerControl1.CurrentPageIndex + 1);
                txtCurrentPageIndex.Text = pdfViewerControl1.CurrentPageIndex.ToString();

            }
        }

        /// <summary>
        /// Handles last page navigation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Last_Click(object sender, RoutedEventArgs e)
        {
            if (pdfViewerControl1.LoadedDocument != null)
            {
                pdfViewerControl1.GotoPage(pdfViewerControl1.LoadedDocument.Pages.Count);
                txtCurrentPageIndex.Text = pdfViewerControl1.CurrentPageIndex.ToString();

            }
        }

        /// <summary>
        /// Handles zoom selection changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Zoom_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            if (ZoomComboBox.Text != "" && ZoomComboBox.Items.Contains(ZoomComboBox.SelectedItem))
            {
                pdfViewerControl1.ZoomTo(int.Parse((ZoomComboBox.SelectedItem as ComboBoxItem).Content.ToString()));
                FitWidth.IsEnabled = true;
                FitPage.IsEnabled = true;
                ZoomOut.IsEnabled = true;
                ZoomIn.IsEnabled = true;
                if (int.Parse((ZoomComboBox.SelectedItem as ComboBoxItem).Content.ToString()) <= 50)
                {
                    ZoomOut.IsEnabled = false;
                    ZoomIn.IsEnabled = true;
                }
                if (int.Parse((ZoomComboBox.SelectedItem as ComboBoxItem).Content.ToString()) >= 400)
                {
                    ZoomOut.IsEnabled = true;
                    ZoomIn.IsEnabled = false;
                }

            }

        }
        /// <summary>
        /// Handles fitpage.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FitPage_Click(object sender, RoutedEventArgs e)
        {
            if (pdfViewerControl1.LoadedDocument != null)
            {
                pdfViewerControl1.ZoomMode = Syncfusion.Windows.PdfViewer.ZoomMode.FitPage;
                ZoomComboBox.Text = pdfViewerControl1.ZoomPercentage.ToString();
                ZoomIn.IsEnabled = true;
                ZoomOut.IsEnabled = true;
                FitWidth.IsEnabled = true;
                FitPage.IsEnabled = false;
            }

        }
        /// <summary>
        /// Handles fitwidth.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FitWidth_Click(object sender, RoutedEventArgs e)
        {
            if (pdfViewerControl1.LoadedDocument != null)
            {
                pdfViewerControl1.ZoomMode = Syncfusion.Windows.PdfViewer.ZoomMode.FitWidth;
                ZoomComboBox.Text = pdfViewerControl1.ZoomPercentage.ToString();
                ZoomIn.IsEnabled = true;
                ZoomOut.IsEnabled = true;
                FitWidth.IsEnabled = false;
                FitPage.IsEnabled = true;

            }
        }

        /// <summary>
        /// Handles print operation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Print_Click(object sender, RoutedEventArgs e)
        {
            if (pdfViewerControl1.LoadedDocument != null)
            {
                pdfViewerControl1.Print(true);
            }

        }



        int[] m_zoomValues = new int[]{
                      50, 75, 100, 125, 150, 200, 400};
        /// <summary>
        /// Handles zoomout.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomOut_Click(object sender, RoutedEventArgs e)
        {
            if (pdfViewerControl1.LoadedDocument != null)
            {

                int index = 0;
                for (int i = 0; i < ZoomComboBox.Items.Count; i++)
                {
                    if (string.Equals(
                        (ZoomComboBox.Items[i] as ComboBoxItem).Content, pdfViewerControl1.ZoomPercentage.ToString()))
                        index = i;
                }
                if (index - 1 >= 0)
                {
                    ZoomComboBox.SelectedIndex = index - 1;
                    ZoomIn.IsEnabled = true;
                    if (index - 1 == 0)
                    {
                        ZoomOut.IsEnabled = false;

                    }
                }
                else
                {
                    for (int i = 0; i < m_zoomValues.Length; i++)
                    {
                        if (i + 1 < m_zoomValues.Length)
                        {
                            if (pdfViewerControl1.ZoomPercentage >= m_zoomValues[i] && pdfViewerControl1.ZoomPercentage < m_zoomValues[i + 1])
                            {
                                ZoomComboBox.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Handles zoomin.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomIn_Click(object sender, RoutedEventArgs e)
        {
            if (pdfViewerControl1.LoadedDocument != null)
            {
                if (pdfViewerControl1.ZoomPercentage < 50)
                {
                    pdfViewerControl1.ZoomTo(50);
                    ZoomComboBox.Text = pdfViewerControl1.ZoomPercentage.ToString();
                    return;
                }
                int index = 0;
                for (int i = 0; i < ZoomComboBox.Items.Count; i++)
                {
                    if (string.Equals(
                        (ZoomComboBox.Items[i] as ComboBoxItem).Content, pdfViewerControl1.ZoomPercentage.ToString()))
                    {
                        index = i;
                        break;
                    }
                    else
                        index = -1;
                }
                if (index != -1 && index == 0 || (index - 1 >= 0 && index + 1 < ZoomComboBox.Items.Count))
                {
                    ZoomComboBox.SelectedIndex = index + 1;
                    ZoomOut.IsEnabled = true;
                    if (index + 1 == 6)
                    {
                        ZoomIn.IsEnabled = false;
                    }

                }
                else
                {
                    for (int i = 0; i < m_zoomValues.Length; i++)
                    {
                        if (i - 1 >= 0)
                        {
                            if (pdfViewerControl1.ZoomPercentage <= m_zoomValues[i] && pdfViewerControl1.ZoomPercentage > m_zoomValues[i - 1])
                            {
                                ZoomComboBox.SelectedIndex = i;
                                if (index == 6)
                                {
                                    ZoomIn.IsEnabled = false;
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Handles custom page navigation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCurrentPageIndex_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox pageNumberTextBox = sender as TextBox;
            if (e.Key == Key.Enter)
            {
                string pageEntered = pageNumberTextBox.Text;
                int pageNumber;
                int.TryParse(pageEntered, out pageNumber);
                pdfViewerControl1.GotoPage(pageNumber);
                pageNumberTextBox.Text = pdfViewerControl1.CurrentPageIndex.ToString();


            }
        }
        /// <summary>
        /// Handles text search bar dispaly operation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindText_Click(object sender, RoutedEventArgs e)
        {
            pdfViewerControl1.ShowTextSearchBar();
        }


        # endregion

        #region Helper methods
        private void LoadDocument(string fileName)
        {
            pdfViewerControl1.Load(fileName);
            lblTotalPageCount.Text = pdfViewerControl1.PageCount.ToString();
        }

        /// <summary>
        /// Gets the full path of the PDF template or image.
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <param name="image">True if image</param>
        /// <returns>Path of the file</returns>
        private string GetFullTemplatePath(string fileName, bool image)
        {
            string fullPath = @"..\..\..\..\..\..\..\..\Common\";
            string folder = image ? "Images" : "Data";

            return string.Format(@"{0}{1}\PDF\{2}", fullPath, folder, fileName);
        }
        #endregion

    }
}
