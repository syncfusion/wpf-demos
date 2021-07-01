#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using syncfusion.demoscommon.wpf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Windows.PdfViewer;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace syncfusion.pdfviewerdemos.wpf
{
    /// <summary>
    /// Represents the view model class
    /// </summary>
    public class CustomToolbarViewModel : NotificationObject
    {
        #region Private Members
        private Stream m_documentStream;
        private RibbonButton m_customStampButton = null;
        private List<Image> m_imageList = new List<Image>();
        CustomToolbar m_customToolbarWindow = null;
        private string m_fileName;
        private string m_selectedItem;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomToolbarViewModel"/> class.
        /// </summary>
        public CustomToolbarViewModel()
        {
            m_documentStream = GetFileStream("HTTP Succinctly.pdf");
        }
        private Stream GetFileStream(string fileName)
        {
            Uri uriResource = new Uri("/syncfusion.pdfviewerdemos.wpf;component/Assets/" + fileName, UriKind.Relative);
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(uriResource);
            return streamResourceInfo.Stream;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the documnet path.
        /// </summary>
        public Stream DocumentStream
        {
            get
            {
                return m_documentStream;
            }
            set
            {
                m_documentStream = value;
            }
        }

        public string SelectedItem
        {
            get
            {
                return m_selectedItem;
            }
            set
            {
                if (m_selectedItem != value)
                {
                    m_selectedItem = value;
                    RaisePropertyChanged("SelectedItem");
                    OnItemSelect(m_selectedItem);
                }
            }
        }
        #endregion

        /// <summary>
        /// Loads PDF on load and initializes controls in custom toolbar.
        /// </summary>
        public void Loaded(object sender, RoutedEventArgs e)
        {
            m_customToolbarWindow = (sender as CustomToolbar).FindName("ribbonwindow") as CustomToolbar;
            m_customToolbarWindow.Btnopen.Click += new RoutedEventHandler(BtnOpen_Click);
            UnWireEvents();
            WireUpEvents();
            InitializeStamp();
            if (m_customToolbarWindow.MyRibbon.BackStageButton != null)
                m_customToolbarWindow.MyRibbon.BackStageButton.Visibility = Visibility.Collapsed;
            m_customToolbarWindow.file_tab.LauncherButton.Visibility = Visibility.Collapsed;
            m_customToolbarWindow.Navigation.LauncherButton.Visibility = Visibility.Collapsed;
            m_customToolbarWindow.Zoom.LauncherButton.Visibility = Visibility.Collapsed;
            m_customToolbarWindow.Size.LauncherButton.Visibility = Visibility.Collapsed;
            m_customToolbarWindow.find_text.LauncherButton.Visibility = Visibility.Collapsed;
            m_customToolbarWindow.Stamp.LauncherButton.Visibility = Visibility.Collapsed;
            m_customToolbarWindow.pdfviewer1.CurrentPageChanged += pdfviewer1_CurrentPageChanged;
            if (m_customToolbarWindow.pdfviewer1.LoadedDocument == null)
            {
                m_customToolbarWindow.txtCurrentPageIndex.Text = "0";
                m_customToolbarWindow.FitWidth.IsEnabled = false;
                m_customToolbarWindow.FitPage.IsEnabled = false;
                m_customToolbarWindow.Last.IsEnabled = false;
                m_customToolbarWindow.First.IsEnabled = false;
                m_customToolbarWindow.Previous.IsEnabled = false;
                m_customToolbarWindow.Next.IsEnabled = false;
                m_customToolbarWindow.Save.IsEnabled = false;
                m_customToolbarWindow.Print1.IsEnabled = false;
                m_customToolbarWindow.ZoomIn.IsEnabled = false;
                m_customToolbarWindow.ZoomOut.IsEnabled = false;
                m_customToolbarWindow.txtCurrentPageIndex.IsEnabled = false;
                m_customToolbarWindow.ZoomComboBox.IsEnabled = false;
                m_customToolbarWindow.FindText.IsEnabled = false;
                m_customToolbarWindow.pageSeparator.IsEnabled = false;
                m_customToolbarWindow.lblTotalPageCount.IsEnabled = false;
                m_customToolbarWindow.ZoomPercentage.IsEnabled = false;
                m_customToolbarWindow.Stamps.IsEnabled = false;
            }
            else
            {
                m_customToolbarWindow.lblTotalPageCount.Text = m_customToolbarWindow.pdfviewer1.PageCount.ToString();
                m_customToolbarWindow.ZoomComboBox.SelectedIndex = 2;
            }
        }
        public void Closed(object sender, EventArgs e)
        {
            m_customToolbarWindow.CustomStampContextMenu.PreviewMouseDown -= M_customStampMenu_PreviewMouseDown;
            m_customToolbarWindow.BrowseStamp.Click -= CustomStampBrowse_Click;
            UnWireEvents();
            m_customToolbarWindow.pdfviewer1.ShowToolbar = true;
            m_customToolbarWindow.pdfviewer1.Unload(true);
        }

        /// <summary>
        /// Occurs when the window size changed.
        /// </summary>
        public void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (m_customToolbarWindow != null)
            {
                m_customToolbarWindow.MyRibbon.BackStageButton.Visibility = Visibility.Collapsed;
                m_customToolbarWindow.file_tab.LauncherButton.Visibility = Visibility.Collapsed;
                m_customToolbarWindow.Navigation.LauncherButton.Visibility = Visibility.Collapsed;
                m_customToolbarWindow.Zoom.LauncherButton.Visibility = Visibility.Collapsed;
                m_customToolbarWindow.Size.LauncherButton.Visibility = Visibility.Collapsed;
                m_customToolbarWindow.find_text.LauncherButton.Visibility = Visibility.Collapsed;
                m_customToolbarWindow.Stamp.LauncherButton.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Pdf Files (.pdf)|*.pdf";
            dialog.ShowDialog();
            if (!string.IsNullOrEmpty(dialog.FileName))
            {
                LoadDocument(dialog.FileName);
                m_customToolbarWindow.txtCurrentPageIndex.Text = "1";
                m_customToolbarWindow.ribbonwindow.Title = dialog.SafeFileName;
                m_customToolbarWindow.ZoomComboBox.SelectedIndex = 2;
                m_customToolbarWindow.FitWidth.IsEnabled = true;
                m_customToolbarWindow.IsEnabled = true;
                m_customToolbarWindow.Last.IsEnabled = true;
                m_customToolbarWindow.First.IsEnabled = true;
                m_customToolbarWindow.Previous.IsEnabled = true;
                m_customToolbarWindow.Next.IsEnabled = true;
                m_customToolbarWindow.Save.IsEnabled = true;
                m_customToolbarWindow.Print1.IsEnabled = true;
                m_customToolbarWindow.ZoomIn.IsEnabled = true;
                m_customToolbarWindow.ZoomOut.IsEnabled = true;
                m_customToolbarWindow.txtCurrentPageIndex.IsEnabled = true;
                m_customToolbarWindow.ZoomComboBox.IsEnabled = true;
                m_customToolbarWindow.FindText.IsEnabled = true;
                m_customToolbarWindow.pageSeparator.IsEnabled = true;
                m_customToolbarWindow.lblTotalPageCount.IsEnabled = true;
                m_customToolbarWindow.ZoomPercentage.IsEnabled = true;
                m_customToolbarWindow.Stamps.IsEnabled = true;
            }
            m_customToolbarWindow.pdfviewer1.CurrentPageChanged += pdfviewer1_CurrentPageChanged;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (m_customToolbarWindow.pdfviewer1.LoadedDocument != null)
            {
                PdfLoadedDocument ldoc = m_customToolbarWindow.pdfviewer1.LoadedDocument;
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF Files (*.pdf)|*.pdf";
                save.FileName = m_fileName;
                if (save.ShowDialog() == true)
                {
                    FileInfo saveFi = new FileInfo(save.FileName);
                    if (save.FileName != string.Empty)
                    {

                        m_customToolbarWindow.pdfviewer1.LoadedDocument.Save(save.FileName);
                        MessageBox.Show("File saved succesfully");
                    }
                }
            }
        }

        private void OnItemSelect(string selectedItem)
        {
            if (selectedItem != null)
            {
                string[] zoomPercentage = selectedItem.ToString().Split(':');
                if (zoomPercentage[1] != "")
                {
                    m_customToolbarWindow.pdfviewer1.ZoomTo(int.Parse(zoomPercentage[1]));
                    m_customToolbarWindow.FitWidth.IsEnabled = true;
                    m_customToolbarWindow.FitPage.IsEnabled = true;
                    m_customToolbarWindow.ZoomOut.IsEnabled = true;
                    m_customToolbarWindow.ZoomIn.IsEnabled = true;
                    if (zoomPercentage[1].Equals("50"))
                    {
                        m_customToolbarWindow.ZoomOut.IsEnabled = false;
                        m_customToolbarWindow.ZoomIn.IsEnabled = true;
                    }
                    if (zoomPercentage[1].Equals("400"))
                    {
                        m_customToolbarWindow.ZoomOut.IsEnabled = true;
                        m_customToolbarWindow.ZoomIn.IsEnabled = false;
                    }
                }
            }
        }

        private void FitPage_Click(object sender, RoutedEventArgs e)
        {
            if (m_customToolbarWindow.pdfviewer1.LoadedDocument != null)
            {
                m_customToolbarWindow.pdfviewer1.ZoomMode = Syncfusion.Windows.PdfViewer.ZoomMode.FitPage;
                m_customToolbarWindow.ZoomComboBox.Text = m_customToolbarWindow.pdfviewer1.ZoomPercentage.ToString();
                m_customToolbarWindow.ZoomIn.IsEnabled = true;
                m_customToolbarWindow.ZoomOut.IsEnabled = true;
                m_customToolbarWindow.FitWidth.IsEnabled = true;
                m_customToolbarWindow.FitPage.IsEnabled = false;
            }
        }

        private void FitWidth_Click(object sender, RoutedEventArgs e)
        {
            if (m_customToolbarWindow.pdfviewer1.LoadedDocument != null)
            {
                m_customToolbarWindow.pdfviewer1.ZoomMode = Syncfusion.Windows.PdfViewer.ZoomMode.FitWidth;
                m_customToolbarWindow.ZoomComboBox.Text = m_customToolbarWindow.pdfviewer1.ZoomPercentage.ToString();
                m_customToolbarWindow.ZoomIn.IsEnabled = true;
                m_customToolbarWindow.ZoomOut.IsEnabled = true;
                m_customToolbarWindow.FitWidth.IsEnabled = false;
                m_customToolbarWindow.FitPage.IsEnabled = true;
            }
        }

        private void FindText_Click(object sender, RoutedEventArgs e)
        {
            m_customToolbarWindow.pdfviewer1.ShowTextSearchBar();
        }

        private void CustomStamps_Click(object sender, RoutedEventArgs e)
        {
            m_customStampButton = sender as RibbonButton;
            m_customStampButton.ContextMenu.IsOpen = true;
        }

        private void CustomStampBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "PNG Files(*.png)|*.png|JPEG Files(*.jpeg)|*.jpeg";
            openFileDialog.Title = "Select Image File";
            if (openFileDialog.ShowDialog().Value)
            {
                foreach (string m_fileName in openFileDialog.FileNames)
                {
                    string fileType = System.IO.Path.GetExtension(m_fileName);
                    fileType = fileType.ToLower();
                    if (fileType == ".jpeg" || fileType == ".png")
                    {
                        if (m_customStampButton != null && m_customStampButton.ContextMenu != null && m_customToolbarWindow.CustomStampContextMenu != null)
                            m_customToolbarWindow.CustomStampContextMenu.Items.Add(GetImage(m_fileName));
                    }
                }
                MessageBox.Show("Selected image(s) are added to the custom stamps collection.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private System.Windows.Controls.Image GetImage(string filePath)
        {
            System.Windows.Controls.Image image = new System.Windows.Controls.Image();
            image.Source = new BitmapImage(new Uri(filePath, UriKind.RelativeOrAbsolute));
            ValidateImage(image);
            m_imageList.Add(image);
            return image;
        }

        Image GetImageFromFolder(string filePath)
        {
            System.Windows.Controls.Image image = new System.Windows.Controls.Image();
            BitmapImage bitmapImage = new BitmapImage();
            image.Source = bitmapImage;
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.StreamSource = GetFileStream(filePath);
            bitmapImage.EndInit();
            ValidateImage(image);
            m_imageList.Add(image);
            return image;
        }

        void ValidateImage(Image image)
        {
            image.Margin = new Thickness(5);
            if (image.Source.Width > 200f || image.Source.Height > 140f)
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
        }

        private void M_customStampMenu_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Controls.Image image = e.OriginalSource as System.Windows.Controls.Image;
            if (m_customToolbarWindow.pdfviewer1 != null && image != null)
            {
                m_customToolbarWindow.pdfviewer1.AnnotationMode = PdfDocumentView.PdfViewerAnnotationMode.Stamp;
                if (m_customToolbarWindow.pdfviewer1.ToolbarSettings != null && m_customToolbarWindow.pdfviewer1.ToolbarSettings.StampAnnotations != null)
                {
                    m_customToolbarWindow.pdfviewer1.ToolbarSettings.StampAnnotations.Clear();
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
                        m_customToolbarWindow.pdfviewer1.ToolbarSettings.StampAnnotations.Add(new PdfStampAnnotation(selectedImage));
                }
            }
        }

        private void InitializeStamp()
        {
            m_customToolbarWindow.CustomStampContextMenu.PreviewMouseDown += M_customStampMenu_PreviewMouseDown;
            m_customToolbarWindow.BrowseStamp.Click += CustomStampBrowse_Click;
            m_customToolbarWindow.CustomStampContextMenu.Items.Add(GetImageFromFolder("pdfviewer/Approved.png")); 
        }

        private void LoadDocument(string fileName)
        {
            FileInfo info = new FileInfo(fileName);
            this.m_fileName = info.Name;
            m_customToolbarWindow.pdfviewer1.Load(fileName);
            m_customToolbarWindow.lblTotalPageCount.Text = m_customToolbarWindow.pdfviewer1.PageCount.ToString();
        }

        void pdfviewer1_CurrentPageChanged(object sender, EventArgs args)
        {
            m_customToolbarWindow.txtCurrentPageIndex.Text = m_customToolbarWindow.pdfviewer1.CurrentPageIndex.ToString();
            if (m_customToolbarWindow.pdfviewer1.CurrentPage == 1)
            {
                m_customToolbarWindow.First.IsEnabled = false;
                m_customToolbarWindow.Previous.IsEnabled = false;
            }
            else
            {
                m_customToolbarWindow.First.IsEnabled = true;
                m_customToolbarWindow.Previous.IsEnabled = true;
            }
            if (m_customToolbarWindow.pdfviewer1.CurrentPage == m_customToolbarWindow.pdfviewer1.LoadedDocument.Pages.Count)
            {
                m_customToolbarWindow.Last.IsEnabled = false;
                m_customToolbarWindow.Next.IsEnabled = false;
            }
            else
            {
                m_customToolbarWindow.Last.IsEnabled = true;
                m_customToolbarWindow.Next.IsEnabled = true;
            }
        }

        void WireUpEvents()
        {
            m_customToolbarWindow.Save.Click += new RoutedEventHandler(Save_Click);
            m_customToolbarWindow.FitPage.Click += new RoutedEventHandler(FitPage_Click);
            m_customToolbarWindow.FitWidth.Click += new RoutedEventHandler(FitWidth_Click);
            m_customToolbarWindow.FindText.Click += new RoutedEventHandler(FindText_Click);
            m_customToolbarWindow.Stamps.Click += new RoutedEventHandler(CustomStamps_Click);
        }

        void UnWireEvents()
        {
            m_customToolbarWindow.Save.Click -= new RoutedEventHandler(Save_Click);
            m_customToolbarWindow.FitPage.Click -= new RoutedEventHandler(FitPage_Click);
            m_customToolbarWindow.FitWidth.Click -= new RoutedEventHandler(FitWidth_Click);
            m_customToolbarWindow.Stamps.Click -= new RoutedEventHandler(CustomStamps_Click);
        }
    }
}
