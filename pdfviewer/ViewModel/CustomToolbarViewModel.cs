#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
        private int[] zoomLevels = { 50, 75, 100, 125, 150, 200, 400 };
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
        /// <summary>
        /// Gets or sets the Zoom combo box selected item.
        /// </summary>
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
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event data for the RoutedEventArgs.</param>
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
            m_customToolbarWindow.pdfviewer.CurrentPageChanged += pdfviewer_CurrentPageChanged;
            m_customToolbarWindow.pdfviewer.PreviewMouseWheel += pdfviewer_PreviewMouseWheel;
            if (m_customToolbarWindow.pdfviewer.LoadedDocument == null)
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
                m_customToolbarWindow.lblTotalPageCount.Text = m_customToolbarWindow.pdfviewer.PageCount.ToString();
                m_customToolbarWindow.ZoomComboBox.SelectedIndex = 2;
            }
        }
        /// <summary>
        /// Handles cleanup operations when the custom toolbar window is closed.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event data for the EventArgs.</param>
        public void Closed(object sender, EventArgs e)
        {
            m_customToolbarWindow.CustomStampContextMenu.PreviewMouseDown -= M_customStampMenu_PreviewMouseDown;
            m_customToolbarWindow.BrowseStamp.Click -= CustomStampBrowse_Click;
            UnWireEvents();
            m_customToolbarWindow.pdfviewer.ShowToolbar = true;
            m_customToolbarWindow.pdfviewer.Unload(true);
        }

        /// <summary>
        /// Occurs when the window size changed.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event data for the SizeChangedEventArgs.</param>
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
        /// <summary>
        /// Handles the open file dialog to load a PDF document into the viewer.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event data for the RoutedEventArgs.</param>
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
            m_customToolbarWindow.pdfviewer.CurrentPageChanged += pdfviewer_CurrentPageChanged;
        }
        /// <summary>
        /// Saves the loaded PDF document to a user-selected location. 
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event data for the RoutedEventArgs.</param>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (m_customToolbarWindow.pdfviewer.LoadedDocument != null)
            {
                PdfLoadedDocument ldoc = m_customToolbarWindow.pdfviewer.LoadedDocument;
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF Files (*.pdf)|*.pdf";
                save.FileName = m_fileName;
                if (save.ShowDialog() == true)
                {
                    FileInfo saveFi = new FileInfo(save.FileName);
                    if (save.FileName != string.Empty)
                    {

                        m_customToolbarWindow.pdfviewer.LoadedDocument.Save(save.FileName);
                        MessageBox.Show("File saved succesfully");
                    }
                }
            }
        }
        /// <summary>
        /// Adjusts the PDF viewer zoom level based on the selected zoom percentage 
        /// </summary>
        /// <param name="selectedItem">The selected zoom level from the dropdown.</param>
        private void OnItemSelect(string selectedItem)
        {
            if (selectedItem != null)
            {
                string[] zoomPercentage = selectedItem.ToString().Split(':');
                if (zoomPercentage.Length > 1)
                {
                    string zoomValue = zoomPercentage[1].Trim();
                    if (!string.IsNullOrEmpty(zoomValue) && m_customToolbarWindow.ZoomComboBox.IsDropDownOpen)
                    {
                        m_customToolbarWindow.pdfviewer.ZoomTo(int.Parse(zoomValue));
                        m_customToolbarWindow.ZoomComboBox.Text = m_customToolbarWindow.pdfviewer.ZoomPercentage.ToString();
                        m_customToolbarWindow.FitWidth.IsEnabled = true;
                        m_customToolbarWindow.FitPage.IsEnabled = true;
                        m_customToolbarWindow.ZoomOut.IsEnabled = true;
                        m_customToolbarWindow.ZoomIn.IsEnabled = true;
                    }
                    if (zoomValue.Equals(zoomLevels[0].ToString()))
                    {
                        m_customToolbarWindow.ZoomOut.IsEnabled = false;
                        m_customToolbarWindow.ZoomIn.IsEnabled = true;
                    }
                    if (zoomValue.Equals(zoomLevels[6].ToString()))
                    {
                        m_customToolbarWindow.ZoomOut.IsEnabled = true;
                        m_customToolbarWindow.ZoomIn.IsEnabled = false;
                    }
                }
            }
        }

        /// <summary>
        /// Sets the PDF viewer zoom mode to Fit Page and updates the toolbar controls accordingly. 
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event data for the RoutedEventArgs.</param>
        private void FitPage_Click(object sender, RoutedEventArgs e)
        {
            if (m_customToolbarWindow.pdfviewer.LoadedDocument != null)
            {
                m_customToolbarWindow.pdfviewer.ZoomMode = Syncfusion.Windows.PdfViewer.ZoomMode.FitPage;
                m_customToolbarWindow.ZoomComboBox.Text = m_customToolbarWindow.pdfviewer.ZoomPercentage.ToString();
                m_customToolbarWindow.ZoomIn.IsEnabled = true;
                if (m_customToolbarWindow.pdfviewer.ZoomPercentage <= m_customToolbarWindow.pdfviewer.MinimumZoomPercentage)
                    m_customToolbarWindow.ZoomOut.IsEnabled = false;
                m_customToolbarWindow.FitWidth.IsEnabled = true;
                m_customToolbarWindow.FitPage.IsEnabled = false;
            }
        }
        /// <summary>
        /// Sets the PDF viewer zoom mode to Fit Width and updates the toolbar controls accordingly. 
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event data for the RoutedEventArgs.</param>
        private void FitWidth_Click(object sender, RoutedEventArgs e)
        {
            if (m_customToolbarWindow.pdfviewer.LoadedDocument != null)
            {
                m_customToolbarWindow.pdfviewer.ZoomMode = Syncfusion.Windows.PdfViewer.ZoomMode.FitWidth;
                m_customToolbarWindow.ZoomComboBox.Text = m_customToolbarWindow.pdfviewer.ZoomPercentage.ToString();
                m_customToolbarWindow.ZoomIn.IsEnabled = true;
                m_customToolbarWindow.ZoomOut.IsEnabled = true;
                if (m_customToolbarWindow.pdfviewer.ZoomPercentage >= m_customToolbarWindow.pdfviewer.MaximumZoomPercentage)
                    m_customToolbarWindow.ZoomIn.IsEnabled = false;
                m_customToolbarWindow.FitWidth.IsEnabled = false;
                m_customToolbarWindow.FitPage.IsEnabled = true;
            }
        }
        /// <summary>
        /// Increases the zoom level of the PDF viewer to the next predefined zoom level 
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event data for the RoutedEventArgs.</param>
        private void ZoomIn_Click(object sender, RoutedEventArgs e)
        {
            if (m_customToolbarWindow.pdfviewer.LoadedDocument != null)
            {
                int currentZoom = m_customToolbarWindow.pdfviewer.ZoomPercentage;
                int nextZoom = -1;
                int currentIndex = Array.IndexOf(zoomLevels, currentZoom);
                if (currentIndex != -1)
                {
                    if (currentIndex + 1 < zoomLevels.Length)
                    {
                        nextZoom = zoomLevels[currentIndex + 1];
                    }
                }
                else
                {
                    for (int i = 0; i < zoomLevels.Length; i++)
                    {
                        if (currentZoom < zoomLevels[i])
                        {
                            nextZoom = zoomLevels[i];
                            break;
                        }
                    }
                }
                if (nextZoom != -1)
                {
                    m_customToolbarWindow.pdfviewer.ZoomTo(nextZoom);
                    m_customToolbarWindow.ZoomComboBox.Text = nextZoom.ToString();
                    m_customToolbarWindow.pdfviewer.ZoomMode = Syncfusion.Windows.PdfViewer.ZoomMode.Default;
                    m_customToolbarWindow.FitWidth.IsEnabled = true;
                    m_customToolbarWindow.FitPage.IsEnabled = true;
                    if (currentZoom >= m_customToolbarWindow.pdfviewer.MinimumZoomPercentage)
                        m_customToolbarWindow.ZoomOut.IsEnabled = true;
                }
            }
        }
        /// <summary>
        /// Decreases the zoom level of the PDF viewer to the previous predefined zoom level 
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event data for the RoutedEventArgs.</param>
        private void ZoomOut_Click(object sender, RoutedEventArgs e)
        {
            if (m_customToolbarWindow.pdfviewer.LoadedDocument != null)
            {
                int currentZoom = m_customToolbarWindow.pdfviewer.ZoomPercentage;
                int nextZoom = -1;
                int currentIndex = Array.IndexOf(zoomLevels, currentZoom);
                if (currentIndex != -1)
                {
                    if (currentIndex - 1 >= 0)
                    {
                        nextZoom = zoomLevels[currentIndex - 1];
                    }
                }
                else
                {
                    for (int i = zoomLevels.Length - 1; i >= 0; i--)
                    {
                        if (currentZoom > zoomLevels[i])
                        {
                            nextZoom = zoomLevels[i];
                            break;
                        }
                    }

                }
                if (nextZoom != -1)
                {
                    m_customToolbarWindow.pdfviewer.ZoomTo(nextZoom);
                    m_customToolbarWindow.ZoomComboBox.Text = nextZoom.ToString();
                    m_customToolbarWindow.pdfviewer.ZoomMode = Syncfusion.Windows.PdfViewer.ZoomMode.Default;
                    m_customToolbarWindow.FitWidth.IsEnabled = true;
                    if (currentZoom <= m_customToolbarWindow.pdfviewer.MaximumZoomPercentage)
                        m_customToolbarWindow.ZoomIn.IsEnabled = true;
                }
            }
        }

        /// <summary>
        /// Opens the text search bar in the PDF viewer. 
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event data for the RoutedEventArgs.</param>
        private void FindText_Click(object sender, RoutedEventArgs e)
        {
            m_customToolbarWindow.pdfviewer.ShowTextSearchBar();
        }

        /// <summary>
        /// Opens the context menu for custom stamps in the PDF viewer. 
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event data for the RoutedEventArgs.</param>
        private void CustomStamps_Click(object sender, RoutedEventArgs e)
        {
            m_customStampButton = sender as RibbonButton;
            m_customStampButton.ContextMenu.IsOpen = true;
        }

        /// <summary>
        /// Allows users to select and add image files as custom stamps in the PDF viewer. 
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event data for the RoutedEventArgs.</param>
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

        /// <summary>
        /// Creates an Image control from the given file path. 
        /// </summary>
        /// <param name="filePath">File path of the document </param>
        private System.Windows.Controls.Image GetImage(string filePath)
        {
            System.Windows.Controls.Image image = new System.Windows.Controls.Image();
            image.Source = new BitmapImage(new Uri(filePath, UriKind.RelativeOrAbsolute));
            ValidateImage(image);
            m_imageList.Add(image);
            return image;
        }

        // <summary>
        /// Creates an Image control from a file in the specified folder. 
        /// </summary>
        /// <param name="filePath">File path of the document </param>
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

        /// <summary>
        /// Validates and adjusts the size of the given image.
        /// </summary>
        /// <param name="image">The Image control to be validated and resized.</param>
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

        /// <summary>
        /// Handles the selection of a custom stamp image.
        /// </summary>
        /// <param name="sender">The source of the event (custom stamp menu).</param>
        /// <param name="e">Mouse button event arguments.</param>

        private void M_customStampMenu_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Controls.Image image = e.OriginalSource as System.Windows.Controls.Image;
            if (m_customToolbarWindow.pdfviewer != null && image != null)
            {
                m_customToolbarWindow.pdfviewer.AnnotationMode = PdfDocumentView.PdfViewerAnnotationMode.Stamp;
                if (m_customToolbarWindow.pdfviewer.ToolbarSettings != null && m_customToolbarWindow.pdfviewer.ToolbarSettings.StampAnnotations != null)
                {
                    m_customToolbarWindow.pdfviewer.ToolbarSettings.StampAnnotations.Clear();
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
                        m_customToolbarWindow.pdfviewer.ToolbarSettings.StampAnnotations.Add(new PdfStampAnnotation(selectedImage));
                }
            }
        }

        /// <summary>
        /// Initializes custom stamp functionality by wiring event handlers for stamp selection 
        /// </summary>
        private void InitializeStamp()
        {
            m_customToolbarWindow.CustomStampContextMenu.PreviewMouseDown += M_customStampMenu_PreviewMouseDown;
            m_customToolbarWindow.BrowseStamp.Click += CustomStampBrowse_Click;
            m_customToolbarWindow.CustomStampContextMenu.Items.Add(GetImageFromFolder("pdfviewer/Approved.png")); 
        }

        /// <summary>
        /// Loads the specified PDF document into the viewer and updates the total page count label.
        /// </summary>
        /// <param name="fileName">The name of the file to open.</param>
        private void LoadDocument(string fileName)
        {
            FileInfo info = new FileInfo(fileName);
            this.m_fileName = info.Name;
            m_customToolbarWindow.pdfviewer.Load(fileName);
            m_customToolbarWindow.lblTotalPageCount.Text = m_customToolbarWindow.pdfviewer.PageCount.ToString();
        }

        /// <summary>
        /// Updates the current page index display and enables or disables navigation buttons 
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event data for the EventArgs.</param>
        void pdfviewer_CurrentPageChanged(object sender, EventArgs args)
        {
            m_customToolbarWindow.txtCurrentPageIndex.Text = m_customToolbarWindow.pdfviewer.CurrentPageIndex.ToString();
            if (m_customToolbarWindow.pdfviewer.CurrentPage == 1)
            {
                m_customToolbarWindow.First.IsEnabled = false;
                m_customToolbarWindow.Previous.IsEnabled = false;
            }
            else
            {
                m_customToolbarWindow.First.IsEnabled = true;
                m_customToolbarWindow.Previous.IsEnabled = true;
            }
            if (m_customToolbarWindow.pdfviewer.CurrentPage == m_customToolbarWindow.pdfviewer.LoadedDocument.Pages.Count)
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

        private void pdfviewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                if (e.Delta != 0 && m_customToolbarWindow.ZoomComboBox.Text != m_customToolbarWindow.pdfviewer.ZoomPercentage.ToString())
                {
                    m_customToolbarWindow.ZoomComboBox.Text = m_customToolbarWindow.pdfviewer.ZoomPercentage.ToString();
                    if (m_customToolbarWindow.pdfviewer.ZoomMode == Syncfusion.Windows.PdfViewer.ZoomMode.Default)
                    {
                        if (!m_customToolbarWindow.FitWidth.IsEnabled)
                        {
                            m_customToolbarWindow.FitWidth.IsEnabled = true;
                        }
                        if (!m_customToolbarWindow.FitPage.IsEnabled)
                        {
                            m_customToolbarWindow.FitPage.IsEnabled = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Enter key press in the ZoomComboBox to set the PDF viewer zoom level.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event data for the KeyEventArgs.</param>
        private void ZoomComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            ComboBox zoomBox = sender as ComboBox;
            if (e.Key == Key.Enter)
            {
                string zoomEntered = zoomBox.Text;
                int magnificationValue;
                int.TryParse(zoomEntered, out magnificationValue);
                if (magnificationValue != 0)
                {
                    int minimumZoomPercentage = m_customToolbarWindow.pdfviewer.MinimumZoomPercentage;
                    int maximumZoomPercentage = m_customToolbarWindow.pdfviewer.MaximumZoomPercentage;

                    if (magnificationValue < minimumZoomPercentage)
                        magnificationValue = minimumZoomPercentage;
                    if (magnificationValue > maximumZoomPercentage)
                        magnificationValue = maximumZoomPercentage;
                    if (magnificationValue > minimumZoomPercentage && !m_customToolbarWindow.ZoomOut.IsEnabled)
                        m_customToolbarWindow.ZoomOut.IsEnabled = true;
                    if (magnificationValue < maximumZoomPercentage && !m_customToolbarWindow.ZoomIn.IsEnabled)
                        m_customToolbarWindow.ZoomIn.IsEnabled = true;
                    m_customToolbarWindow.FitWidth.IsEnabled = true;
                    m_customToolbarWindow.FitPage.IsEnabled = true;

                    m_customToolbarWindow.pdfviewer.ZoomMode = Syncfusion.Windows.PdfViewer.ZoomMode.Default;
                    m_customToolbarWindow.pdfviewer.ZoomTo(magnificationValue);
                    m_customToolbarWindow.ZoomComboBox.Text = magnificationValue.ToString();
                }
            }
        }

        /// <summary>
        /// Wires up event handlers for various UI elements in the custom toolbar, 
        /// </summary>
        void WireUpEvents()
        {
            m_customToolbarWindow.Save.Click += new RoutedEventHandler(Save_Click);
            m_customToolbarWindow.FitPage.Click += new RoutedEventHandler(FitPage_Click);
            m_customToolbarWindow.FitWidth.Click += new RoutedEventHandler(FitWidth_Click);
            m_customToolbarWindow.FindText.Click += new RoutedEventHandler(FindText_Click);
            m_customToolbarWindow.Stamps.Click += new RoutedEventHandler(CustomStamps_Click);
            m_customToolbarWindow.ZoomIn.Click += new RoutedEventHandler(ZoomIn_Click);
            m_customToolbarWindow.ZoomOut.Click += new RoutedEventHandler(ZoomOut_Click);
            m_customToolbarWindow.ZoomComboBox.KeyDown += new KeyEventHandler(ZoomComboBox_KeyDown);
        }

        /// <summary>
        /// UnWire the event handlers from various UI elements in the custom toolbar 
        /// </summary>
        void UnWireEvents()
        {
            m_customToolbarWindow.Save.Click -= new RoutedEventHandler(Save_Click);
            m_customToolbarWindow.FitPage.Click -= new RoutedEventHandler(FitPage_Click);
            m_customToolbarWindow.FitWidth.Click -= new RoutedEventHandler(FitWidth_Click);
            m_customToolbarWindow.Stamps.Click -= new RoutedEventHandler(CustomStamps_Click);
            m_customToolbarWindow.ZoomIn.Click -= new RoutedEventHandler(ZoomIn_Click);
            m_customToolbarWindow.ZoomOut.Click -= new RoutedEventHandler(ZoomOut_Click);
            m_customToolbarWindow.ZoomComboBox.KeyDown -= new KeyEventHandler(ZoomComboBox_KeyDown);
        }
    }
}
