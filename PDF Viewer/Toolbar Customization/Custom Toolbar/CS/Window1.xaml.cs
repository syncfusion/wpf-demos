#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.IO;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Markup;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Tools;
using System.Threading;
using System.Collections;
using System.Diagnostics;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using System.Globalization;
using System.Windows.Threading;
using System.Windows.Interop;
using Syncfusion.Pdf.Parsing;
using System.Drawing;
using Syncfusion.Windows.PdfViewer;

namespace RibbonSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : RibbonWindow
    {

        #region Private Members
        private MenuItem m_customStampMenu = null;
        private List<System.Windows.Controls.Image> m_imageList = new List<System.Windows.Controls.Image>();
        private RibbonButton m_customStampButton = null;
        private int[] m_zoomValues = new int[]{
                      50, 75, 100, 125, 150, 200, 400};
        private string fileName;
        #endregion

        #region Constructor
        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter converter = new ImageSourceConverter();
            this.Icon = (ImageSource)converter.ConvertFromString(GetFullTemplatePath("pdf viewer.png", true));
            this.ShowHelpButton = false;
            this.Closed += Window1_Closed;
          
        }

        # endregion

        # region Events
        /// <summary>
        /// Handles the image selection
        /// </summary>
        private void CustomStampBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "PNG Files(*.png)|*.png|JPEG Files(*.jpeg)|*.jpeg";
            openFileDialog.Title = "Select Image File";
            if (openFileDialog.ShowDialog().Value)
            {
                foreach(string fileName in openFileDialog.FileNames)
                { 
                    string fileType = System.IO.Path.GetExtension(fileName);
                    fileType = fileType.ToLower();
                    if (fileType == ".jpeg" || fileType == ".png")
                    {
                        if (m_customStampButton != null && m_customStampButton.ContextMenu != null && m_customStampMenu != null)
                            m_customStampMenu.Items.Add(GetImage(fileName));                            
                    }
                }
                MessageBox.Show("Selected image(s) are added to the custom stamps collection.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        /// <summary>
        /// Handles the list of stamps
        /// </summary>
        private void CustomStamps_Click(object sender, RoutedEventArgs e)
        {
            m_customStampButton = sender as RibbonButton;
            if (m_customStampButton.ContextMenu == null)
            {
                m_customStampButton.ContextMenu = new ContextMenu();
                MenuItem browse = new MenuItem() { Header = "Browse" };
                m_customStampMenu = new MenuItem() { Header = "Custom Stamp"};                
                m_customStampMenu.PreviewMouseDown += M_customStampMenu_PreviewMouseDown;
                browse.Click += CustomStampBrowse_Click;
                m_customStampMenu.Items.Add(GetImage(GetFullTemplatePath("Approved.png", true)));
                m_customStampMenu.Items.Add(GetImage(GetFullTemplatePath("Confidential.png", true)));
                m_customStampMenu.Items.Add(GetImage(GetFullTemplatePath("Draft.png", true)));
                m_customStampMenu.Items.Add(GetImage(GetFullTemplatePath("Expired.png", true)));
                m_customStampMenu.Items.Add(GetImage(GetFullTemplatePath("Not Approved.png", true)));
                m_customStampButton.ContextMenu.Items.Add(m_customStampMenu);
                m_customStampButton.ContextMenu.Items.Add(browse);
            }
            m_customStampButton.ContextMenu.IsOpen = true;
        }


        private void M_customStampMenu_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

            System.Windows.Controls.Image image = e.OriginalSource as System.Windows.Controls.Image;
            if (pdfViewerControl1 != null && image != null)
            {
                pdfViewerControl1.AnnotationMode = PdfDocumentView.PdfViewerAnnotationMode.Stamp;
                if (pdfViewerControl1.ToolbarSettings != null && pdfViewerControl1.ToolbarSettings.StampAnnotations != null)
                {
                    pdfViewerControl1.ToolbarSettings.StampAnnotations.Clear();
                    System.Windows.Controls.Image selectedImage = new System.Windows.Controls.Image();
                    selectedImage.Source = image.Source;
                    if (selectedImage.Source.Width > selectedImage.Source.Height)
                    {
                        float widthPercentage = 200f / (float)selectedImage.Source.Width;
                        selectedImage.Width = selectedImage.Source.Width * widthPercentage;
                        selectedImage.Height = selectedImage.Source.Height * widthPercentage;
                    }
                    else
                    {
                        float heightPercentage = 50f / (float)selectedImage.Source.Height;
                        selectedImage.Width = selectedImage.Source.Width * heightPercentage;
                        selectedImage.Height = selectedImage.Source.Height * heightPercentage;
                    }
                    if (selectedImage != null && selectedImage.Source != null)
                        pdfViewerControl1.ToolbarSettings.StampAnnotations.Add(new PdfStampAnnotation(selectedImage));
                }
            }   
        }

        /// <summary>
        /// Occurs when the window is about to close
        /// </summary>
        private void Window1_Closed(object sender, EventArgs e)
        {
            pdfViewerControl1.Unload();
        }

        /// <summary>
        /// Occurs when the window size changed.
        /// </summary>
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MyRibbon.BackStageButton.Visibility = Visibility.Collapsed;
            file_tab.LauncherButton.Visibility = Visibility.Collapsed;
            Navigation.LauncherButton.Visibility = Visibility.Collapsed;
            Zoom.LauncherButton.Visibility = Visibility.Collapsed;
            Size.LauncherButton.Visibility = Visibility.Collapsed;
            find_text.LauncherButton.Visibility = Visibility.Collapsed;
            Stamp.LauncherButton.Visibility = Visibility.Collapsed;
        }
        /// <summary>
        /// Loads PDF on load and initializes controls in custom toolbar.
        /// </summary>

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MyRibbon.BackStageButton.Visibility = System.Windows.Visibility.Collapsed;
            file_tab.LauncherButton.Visibility = System.Windows.Visibility.Collapsed;
            Navigation.LauncherButton.Visibility = System.Windows.Visibility.Collapsed;
            Zoom.LauncherButton.Visibility = System.Windows.Visibility.Collapsed;
            Size.LauncherButton.Visibility = System.Windows.Visibility.Collapsed;
            find_text.LauncherButton.Visibility = System.Windows.Visibility.Collapsed;
            Stamp.LauncherButton.Visibility = Visibility.Collapsed;
			
            pdfViewerControl1.CurrentPageChanged += pdfViewerControl1_CurrentPageChanged;
            lblTotalPageCount.Text = pdfViewerControl1.PageCount.ToString();
            
            if (pdfViewerControl1.LoadedDocument == null)
            {
                txtCurrentPageIndex.Text = "0";
                FitWidth.IsEnabled = false;
                FitPage.IsEnabled = false;
                Last.IsEnabled = false;
                First.IsEnabled = false;
                Previous.IsEnabled = false;
                Next.IsEnabled = false;
                Save.IsEnabled = false;
                Print1.IsEnabled = false;
                ZoomIn.IsEnabled = false;
                ZoomOut.IsEnabled = false;
                txtCurrentPageIndex.IsEnabled = false;
                ZoomComboBox.IsEnabled = false;
                FindText.IsEnabled = false;
                pageSeparator.IsEnabled = false;
                lblTotalPageCount.IsEnabled = false;
                ZoomPercentage.IsEnabled = false;
            }
            else
            {
                txtCurrentPageIndex.Text = pdfViewerControl1.CurrentPage.ToString();
            }
        }

         /// <summary>
        /// Handles file open in custom toolbar.
        /// </summary>
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Pdf Files (.pdf)|*.pdf";
            dialog.ShowDialog();
            if (!string.IsNullOrEmpty(dialog.FileName))
            {
                LoadDocument(dialog.FileName);
                txtCurrentPageIndex.Text = "1";
                ribbonwindow.Title = dialog.SafeFileName;
                ZoomComboBox.SelectedIndex = 2;
                FitWidth.IsEnabled = true;
                FitPage.IsEnabled = true;
                Last.IsEnabled = true;
                First.IsEnabled = true;
                Previous.IsEnabled = true;
                Next.IsEnabled = true;
                Save.IsEnabled = true;
                Print1.IsEnabled = true;
                ZoomIn.IsEnabled = true;
                ZoomOut.IsEnabled = true;
                txtCurrentPageIndex.IsEnabled = true;
                ZoomComboBox.IsEnabled = true;
                FindText.IsEnabled = true;
                pageSeparator.IsEnabled = true;
                lblTotalPageCount.IsEnabled = true;
                ZoomPercentage.IsEnabled = true;
            }
           
            pdfViewerControl1.CurrentPageChanged += pdfViewerControl1_CurrentPageChanged;
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
        /// Handles zoom selection changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Zoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
        /// Handles save operation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (pdfViewerControl1.LoadedDocument != null)
            {
                PdfLoadedDocument ldoc = pdfViewerControl1.LoadedDocument;
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF Files (*.pdf)|*.pdf";
                save.FileName = fileName;
                if (save.ShowDialog() == true)
                {
                    FileInfo saveFi = new FileInfo(save.FileName);
                    if (save.FileName != string.Empty)
                    {

                        pdfViewerControl1.LoadedDocument.Save(save.FileName);

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

        #region Helper Methods
        /// <summary>
        /// Gets the image from the file path
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <returns>Image in the file path provided</returns>
        private System.Windows.Controls.Image GetImage(string filePath)
        {
            Grid imageGrid = new Grid();
            imageGrid.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 255, 255));
            System.Windows.Controls.Image image = new System.Windows.Controls.Image();
            image.Source = new BitmapImage(new Uri(filePath, UriKind.RelativeOrAbsolute));
            
            image.Margin = new Thickness(5);
            if(image.Source.Width > 200f || image.Source.Height > 140f)
            {
                image.Stretch = Stretch.Fill;
                if (image.Source.Width > image.Source.Height)
            {
                float widthPercentage = 200f / (float)image.Source.Width;
                image.Width = image.Source.Width * widthPercentage;
                image.Height = image.Source.Height * widthPercentage;
            }
                else
                {
                    float heightPercentage = 140f / (float)image.Source.Height;
                    image.Width = image.Source.Width * heightPercentage;
                    image.Height = image.Source.Height * heightPercentage;
                }
            }
            m_imageList.Add(image);
            return image;
        }
        private void LoadDocument(string fileName)
        {
            FileInfo info = new FileInfo(fileName);
            this.fileName = info.Name;
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
#if NETCORE
		    string fullPath = @"..\..\..\..\..\..\..\Common\";
#else
            string fullPath = @"..\..\..\..\..\..\Common\";
#endif
            string folder = image ? "Images" : "Data";
            return string.Format(@"{0}{1}\PDF\{2}", fullPath, folder, fileName);
        }
        #endregion



    }
}