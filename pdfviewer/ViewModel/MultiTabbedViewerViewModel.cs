#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Linq;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.PdfViewer;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using Microsoft.Win32;
using System.IO;
using System.Windows.Resources;

namespace syncfusion.pdfviewerdemos.wpf
{
    public class MultiTabbedViewerViewModel
    {
        # region Private Members
        string[] m_files = new string[] { "MultiColumnReports.pdf", "Invoice.pdf", "SyncfusionBrochure.pdf" };
        DocumentContainer container = null;
        DocumentToolbar toolbar1 = null;
        PdfDocumentView m_activeView;
        int[] zoomValues = new int[]{
           50, 75, 100, 125, 150, 200, 400};
        int itemsCount;
        # endregion

        #region Constructor
        public MultiTabbedViewerViewModel()
        {
            PdfDocumentView pdfDocumentView = new PdfDocumentView();
        }
        #endregion

        #region Events
        /// <summary>
        /// Occurs when the window is about to close
        /// </summary>
        public void Closed(object sender, EventArgs e)
        {
            foreach (PdfDocumentView view in container.Items)
            {
                UnWireEvents();
                view.Unload(true);
            }
        }
        public void Loaded(object sender, RoutedEventArgs e)
        {
            Window mainWindow = sender as Window;

            PdfDocumentView viewer1 = mainWindow.FindName("pdfviewer1") as PdfDocumentView;
            PdfDocumentView viewer2 = mainWindow.FindName("pdfviewer2") as PdfDocumentView;
            PdfDocumentView viewer3 = mainWindow.FindName("pdfviewer3") as PdfDocumentView;
            viewer1.Load(GetFileStream(m_files[0]));
            viewer1.ToolTip = m_files[0];

            viewer2.Load(GetFileStream(m_files[1]));
            viewer2.ToolTip = m_files[1];

            viewer3.Load(GetFileStream(m_files[2]));
            viewer3.ToolTip = m_files[2];

            container = mainWindow.FindName("documentContainer") as DocumentContainer;

            container.ActiveDocument = viewer1;

            toolbar1 = mainWindow.FindName("documentToolbar1") as DocumentToolbar;
            m_activeView = viewer1;
            toolbar1.btnOpen.Click += new RoutedEventHandler(btnOpen_Click);
            Initialize(m_activeView);
            container.ActiveDocumentChanged += new PropertyChangedCallback(documentContainer_ActiveDocumentChanged);
        }

        private Stream GetFileStream(string fileName)
        {
            Uri uriResource = new Uri("/syncfusion.pdfviewerdemos.wpf;component/Assets/" + fileName, UriKind.Relative);
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(uriResource);
            return streamResourceInfo.Stream;
        }
        /// <summary>
        /// Opens every new PDF in a new tab.
        /// </summary>
        void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            openFileDialog.Title = "Select a PDF file";
            if (openFileDialog.ShowDialog().Value)
            {
                bool flag = false;
                foreach (PdfDocumentView view in container.Items)
                {
                    if (openFileDialog.SafeFileName.Equals(view.ToolTip))
                    {
                        container.ActiveDocument = view;
                        if (container.Items.Contains(view))
                            itemsCount = container.Items.IndexOf(view);
                        container.Items.RemoveAt(itemsCount);
                        break;
                    }
                }
                if (!flag)
                {
                    PdfDocumentView pdfViewer = new PdfDocumentView();
                    pdfViewer.Load(openFileDialog.FileName);
                    if (pdfViewer.LoadedDocument != null)
                    {
                        pdfViewer.ToolTip = openFileDialog.SafeFileName;
                        container.Items.Add(pdfViewer);
                        m_activeView = pdfViewer;
                        Syncfusion.Windows.Tools.Controls.DocumentContainer.SetHeader(pdfViewer, pdfViewer.ToolTip);
                    }
                }
            }
        }
        /// <summary>
        /// Updates the toolbar with the active document.
        /// </summary>
        void documentContainer_ActiveDocumentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            m_activeView = (e.NewValue as PdfDocumentView);
            Initialize(m_activeView);
        }
        #endregion
        //DocumentToolBar
        #region Implementation
        /// <summary>
        /// Initializes view.
        /// </summary>
        private void Initialize(PdfDocumentView view)
        {
            UnWireEvents();
            WireUpEvents();
            m_activeView = view;

            m_activeView.NavigationButtonStatesChanged += new PdfDocumentView.NavigationButtonStatesChangedEventHandler(m_activeView_NavigationButtonStatesChanged);
            m_activeView.CurrentPageChanged += new PdfDocumentView.CurrentPageChangedEventHandler(m_activeView_CurrentPageChanged);

            toolbar1.txtCurrentPageIndex.Text = m_activeView.CurrentPageIndex.ToString();
            toolbar1.lblTotalPageCount.Text = m_activeView.PageCount.ToString();
            toolbar1.cmbCurrentZoomLevel.Text = m_activeView.ZoomPercentage.ToString() + "%";


            m_activeView_NavigationButtonStatesChanged(null, null);

            m_activeView.ZoomChanged += new PdfDocumentView.ZoomChangedEventHandler(m_activeView_ZoomChanged);
        }

        /// <summary>
        /// Handles zoom.
        /// </summary>
        void m_activeView_ZoomChanged(object sender, ZoomEventArgs args)
        {
            toolbar1.cmbCurrentZoomLevel.Text = string.Format("{0}%", args.ZoomPercentage);
        }

        /// <summary>
        /// Handles current page when switching tabs.
        /// </summary>
        void m_activeView_CurrentPageChanged(object sender, EventArgs args)
        {
            SetCurrentPageIndex(m_activeView.CurrentPageIndex);
        }

        /// <summary>
        /// Handles navigation button change.
        /// </summary>
        void m_activeView_NavigationButtonStatesChanged(object sender, EventArgs args)
        {
            toolbar1.btnGoToFirstPage.IsEnabled = m_activeView.CanGoToFirstPage;
            toolbar1.btnGoToLastPage.IsEnabled = m_activeView.CanGoToLastPage;
            toolbar1.btnGoToNextPage.IsEnabled = m_activeView.CanGoToNextPage;
            toolbar1.btnGoToPreviousPage.IsEnabled = m_activeView.CanGoToPreviousPage;
        }

        /// <summary>
        /// Updates current page index in toolbar.
        /// </summary>
        void SetCurrentPageIndex(int index)
        {
            toolbar1.txtCurrentPageIndex.Text = index.ToString();
        }

        /// <summary>
        /// Updates active viewer with the zoom.
        /// </summary>
        void cmbCurrentZoomLevel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int zoomLevel = GetCurrentZoomLevel();
            m_activeView.ZoomTo(zoomLevel);
        }

        /// <summary>
        /// Handles zoom out.
        /// </summary>
        void btnZoomOut_Click(object sender, RoutedEventArgs e)
        {
            int currentZoomLevel = GetCurrentZoomLevel();
            int index = GetComboBoxItemIndex(string.Format("{0}%", currentZoomLevel));
            if (index - 1 >= 0)
            {
                toolbar1.cmbCurrentZoomLevel.SelectedIndex = index - 1;
            }
            else
            {
                for (int i = 0; i < zoomValues.Length; i++)
                {
                    if (i + 1 < zoomValues.Length)
                    {
                        if (currentZoomLevel >= zoomValues[i] && currentZoomLevel < zoomValues[i + 1])
                        {
                            toolbar1.cmbCurrentZoomLevel.SelectedIndex = i;
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles zoom in.
        /// </summary>
        void btnZoomIn_Click(object sender, RoutedEventArgs e)
        {
            int currentZoomLevel = GetCurrentZoomLevel();
            int index = GetComboBoxItemIndex(string.Format("{0}%", currentZoomLevel));
            if (index >= 0 && index + 1 < toolbar1.cmbCurrentZoomLevel.Items.Count)
            {
                toolbar1.cmbCurrentZoomLevel.SelectedIndex = index + 1;
            }
            else
            {
                for (int i = 0; i < zoomValues.Length; i++)
                {
                    if (i - 1 >= 0)
                    {
                        if (currentZoomLevel <= zoomValues[i] && currentZoomLevel > zoomValues[i - 1])
                        {
                            toolbar1.cmbCurrentZoomLevel.SelectedIndex = i;
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles current page index.
        /// </summary>
        void txtCurrentPageIndex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                m_activeView.GoToPageAtIndex(
                    GetCurrentPageIndex());
            }
        }

        /// <summary>
        /// Handles printing of active PDF>
        /// </summary>
        void btnPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        /// <summary>
        /// Handles last page navigation.
        /// </summary>
        void btnGoToLastPage_Click(object sender, EventArgs e)
        {
            m_activeView.GoToLastPage();
        }

        /// <summary>
        /// Handles next page navigation.
        /// </summary>
        void btnGoToNextPage_Click(object sender, EventArgs e)
        {
            m_activeView.GoToNextPage();
        }

        /// <summary>
        /// Handles previous page navigation.
        /// </summary>
        void btnGoToPreviousPage_Click(object sender, EventArgs e)
        {
            m_activeView.GoToPreviousPage();
        }

        /// <summary>
        /// Handles first page navigation.
        /// </summary>
        void btnGoToFirstPage_Click(object sender, EventArgs e)
        {
            m_activeView.GoToFirstPage();
        }
        #endregion

        #region Helper Methods

        /// <summary>
        /// Bind events
        /// </summary>
        void WireUpEvents()
        {
            toolbar1.btnGoToFirstPage.Click += new RoutedEventHandler(btnGoToFirstPage_Click);
            toolbar1.btnGoToPreviousPage.Click += new RoutedEventHandler(btnGoToPreviousPage_Click);
            toolbar1.btnGoToNextPage.Click += new RoutedEventHandler(btnGoToNextPage_Click);
            toolbar1.btnGoToLastPage.Click += new RoutedEventHandler(btnGoToLastPage_Click);
            toolbar1.btnPrint.Click += new RoutedEventHandler(btnPrint_Click);
            toolbar1.txtCurrentPageIndex.KeyDown += new KeyEventHandler(txtCurrentPageIndex_KeyDown);

            toolbar1.btnZoomIn.Click += new RoutedEventHandler(btnZoomIn_Click);
            toolbar1.btnZoomOut.Click += new RoutedEventHandler(btnZoomOut_Click);
            toolbar1.cmbCurrentZoomLevel.KeyDown += new KeyEventHandler(CmbCurrentZoomLevel_KeyDown);
            toolbar1.cmbCurrentZoomLevel.SelectionChanged += new SelectionChangedEventHandler(cmbCurrentZoomLevel_SelectionChanged);
        }

        private void CmbCurrentZoomLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                int currentZoomLevel = GetCurrentZoomLevel();
                if (currentZoomLevel > zoomValues.Max())
                    m_activeView.ZoomTo(zoomValues.Max());
                else
                    m_activeView.ZoomTo(currentZoomLevel);
            }
        }

        void UnWireEvents()
        {
            toolbar1.btnGoToFirstPage.Click -= new RoutedEventHandler(btnGoToFirstPage_Click);
            toolbar1.btnGoToPreviousPage.Click -= new RoutedEventHandler(btnGoToPreviousPage_Click);
            toolbar1.btnGoToNextPage.Click -= new RoutedEventHandler(btnGoToNextPage_Click);
            toolbar1.btnGoToLastPage.Click -= new RoutedEventHandler(btnGoToLastPage_Click);
            toolbar1.btnPrint.Click -= new RoutedEventHandler(btnPrint_Click);
            toolbar1.txtCurrentPageIndex.KeyDown -= new KeyEventHandler(txtCurrentPageIndex_KeyDown);

            toolbar1.btnZoomIn.Click -= new RoutedEventHandler(btnZoomIn_Click);
            toolbar1.btnZoomOut.Click -= new RoutedEventHandler(btnZoomOut_Click);
            toolbar1.cmbCurrentZoomLevel.KeyDown -= new KeyEventHandler(CmbCurrentZoomLevel_KeyDown);
            toolbar1.cmbCurrentZoomLevel.SelectionChanged -= new SelectionChangedEventHandler(cmbCurrentZoomLevel_SelectionChanged);
        }
        /// <summary>
        /// Gets the index of given zoom level.
        /// </summary>
        int GetComboBoxItemIndex(string text)
        {
            for (int i = 0; i < toolbar1.cmbCurrentZoomLevel.Items.Count; i++)
            {
                if (String.Equals(
                    (toolbar1.cmbCurrentZoomLevel.Items[i] as ComboBoxItem).Content, text))
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// Gets the current zoom level.
        /// </summary>
        int GetCurrentZoomLevel()
        {
            string text = "";
            if (toolbar1.cmbCurrentZoomLevel.SelectedValue == null)
                text = toolbar1.cmbCurrentZoomLevel.Text;
            else
                text = (toolbar1.cmbCurrentZoomLevel.SelectedValue as ComboBoxItem)
               .Content.ToString();

            text = text.TrimEnd(new char[] { '%' });
            int zoomLevel = 100;

            if (int.TryParse(text, out zoomLevel))
            {
                return zoomLevel;
            }

            return 100;
        }

        /// <summary>
        /// Gets current page index.
        /// </summary>
        int GetCurrentPageIndex()
        {
            if (string.IsNullOrEmpty(toolbar1.txtCurrentPageIndex.Text))
                return 1;

            else
            {
                int index = 1;
                if (int.TryParse(toolbar1.txtCurrentPageIndex.Text, out index))
                    return index - 1;
            }

            return -1;
        }

        /// <summary>
        /// Prints the acive PDF.
        /// </summary>
        void Print()
        {
            PrintDialog printDialog = new System.Windows.Controls.PrintDialog();
            if (printDialog.ShowDialog() == true)
                printDialog.PrintDocument(m_activeView.PrintDocument.DocumentPaginator, "Essential PDF Viewer");
        }

        #endregion

    }
}
