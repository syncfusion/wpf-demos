#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Pdf;
using Syncfusion.Presentation;
using Syncfusion.PresentationToPdfConverter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Syncfusion.Licensing;
using System.Reflection;
using System.Text;

namespace syncfusion.powerpointviewer.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PowerPointViewerDemo : Window
    {

        #region Declaration
        private readonly BackgroundWorker displayBackroundWorker = new BackgroundWorker();
        private readonly BackgroundWorker pdfBackroundWorker = new BackgroundWorker();
        private IPresentation presentation = null;
        private List<ImageSource> slideImageSources = new List<ImageSource>();
        private List<ImageSource> thumbnailImageSource = new List<ImageSource>();
        private List<System.Drawing.Image> printImages = new List<System.Drawing.Image>();
        private int currentSlideNumber = 0;
        private string filePath = string.Empty;
        private int borderHighlightThickness = 3;
        private float borderDefaultThickness = 0.3f;
        private double scrolPosition = 0;
        private float imageWidth;
        private float imageHeight;
        private const float pageWidth = 720;
        private const float pageHeight = 1000;
        private int slideNumber = 1;
        private bool IsNavigationDown;
        private int printFromPage;
        private int printToPage;
        #endregion

        #region Constructor
        public PowerPointViewerDemo()
        {
            InitializeComponent();
            displayBackroundWorker.DoWork += worker_DoWork;
            displayBackroundWorker.RunWorkerCompleted += worker_RunWorkerCompleted;
            pdfBackroundWorker.DoWork += pdfBackroundWorker_DoWork;
            pdfBackroundWorker.RunWorkerCompleted += pdfBackroundWorker_RunWorkerCompleted;
            this.Background = new SolidColorBrush(Color.FromRgb(244, 244, 244));
            filePath = "Assets/PowerPoint Viewer/Template.pptx";
            HideControls();
            InitializeNonUITasks();
            InitializeUITasks(filePath);
            DisplayControls();
        }
        #endregion

        #region HelperMethods
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            HideControls();
            InitializeNonUITasks();
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            InitializeUITasks(filePath);
            DisplayControls();
        }

        private void DisplayControls()
        {
            Dispatcher.Invoke(new Action(() => { this.loadingIndicatorCanvas.Visibility = Visibility.Collapsed; }));
            Dispatcher.Invoke(new Action(() => { this.centerSlideImage.Visibility = Visibility.Visible; }));
            Dispatcher.Invoke(new Action(() => { this.scrollViewer.Visibility = Visibility.Visible; }));
            Dispatcher.Invoke(new Action(() => { this.openDocument.IsEnabled = true; }));
            Dispatcher.Invoke(new Action(() => { this.printDocument.IsEnabled = true; }));
            Dispatcher.Invoke(new Action(() => { this.createPdfDocument.IsEnabled = true; }));
            Dispatcher.Invoke(new Action(() => { this.prevDocument.IsEnabled = true; }));
            Dispatcher.Invoke(new Action(() => { this.NextDocumentIconImage.IsEnabled = true; }));
            Dispatcher.Invoke(new Action(() => { this.lblPageDisplay.IsEnabled = true; }));
        }

        private void HideControls()
        {
            Dispatcher.Invoke(new Action(() => { this.loadingIndicatorCanvas.Visibility = Visibility.Visible; }));
            Dispatcher.Invoke(new Action(() => { this.scrollViewer.Visibility = Visibility.Collapsed; }));
            Dispatcher.Invoke(new Action(() => { this.centerSlideImage.Visibility = Visibility.Collapsed; }));
            Dispatcher.Invoke(new Action(() => { this.openDocument.IsEnabled = false; }));
            Dispatcher.Invoke(new Action(() => { this.printDocument.IsEnabled = false; }));
            Dispatcher.Invoke(new Action(() => { this.createPdfDocument.IsEnabled = false; }));
            Dispatcher.Invoke(new Action(() => { this.prevDocument.IsEnabled = false; }));
            Dispatcher.Invoke(new Action(() => { this.NextDocumentIconImage.IsEnabled = false; }));
            Dispatcher.Invoke(new Action(() => { this.lblPageDisplay.IsEnabled = false; }));
        }

        private void InitializeNonUITasks()
        {
            try
            {
                presentation = Presentation.Open(filePath);
            }
            catch
            {
                MessageBox.Show("This PowerPoint Presentation cannot be opened properly, please contact Syncfusion support");
                return;
            }
            slideImageSources.Clear();
            thumbnailImageSource.Clear();
            printImages.Clear();
            currentSlideNumber = 0;
            try
            {
                foreach (ISlide slide in presentation.Slides)
                {
                    using (System.Drawing.Image image = slide.ConvertToImage(Syncfusion.Drawing.ImageType.Bitmap))
                    {
                        System.Drawing.Image.GetThumbnailImageAbort myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                        printImages.Add(image.Clone() as System.Drawing.Image);
                        System.Drawing.Image newImage = image.GetThumbnailImage(170, 100, myCallback, System.IntPtr.Zero);
                        using (Stream ms = new MemoryStream())
                        {
                            newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            var decoder = BitmapDecoder.Create(ms, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                            thumbnailImageSource.Add(decoder.Frames[0]);
                        }

                        using (Stream ms = new MemoryStream())
                        {
                            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            var decoder = BitmapDecoder.Create(ms, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                            slideImageSources.Add(decoder.Frames[0]);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("This PowerPoint Presentation cannot be converted to images properly, please contact Syncfusion support");
                return;
            }
        }

        private void InitializeUITasks(string filePath)
        {
            this.stackpanel.Children.Clear();
            this.scrollViewer.ScrollToVerticalOffset(0);
            this.titleBarTextBlock.Text = System.IO.Path.GetFileName(filePath);
            this.prevDocument.Source = new BitmapImage(new Uri(@"/syncfusion.powerpointviewer.wpf;component/Assets/PowerPoint Viewer/Navigation_Prev _Disabled.png", UriKind.Relative));
            this.prevDocument.IsHitTestVisible = false;

            foreach (ImageSource imgSource in thumbnailImageSource)
            {
                StackPanel panel = new StackPanel();

                Label lblThumbnailSlideNumber = new Label();
                lblThumbnailSlideNumber.FontFamily = new FontFamily("Segoe UI");
                lblThumbnailSlideNumber.FontSize = 15;
                int xMargin = (int.Parse(slideNumber.ToString().Length.ToString()) * 15) - slideNumber.ToString().Length;
                lblThumbnailSlideNumber.Margin = new Thickness(-xMargin, 10, 0, 0);
                lblThumbnailSlideNumber.Content = slideNumber.ToString();
                lblThumbnailSlideNumber.Padding = new Thickness(1);
                panel.Children.Add(lblThumbnailSlideNumber);

                Border myBorder1 = new Border();
                myBorder1.Background = Brushes.SkyBlue;
                myBorder1.Margin = new Thickness(0, -23, 0, 30);
                myBorder1.BorderBrush = new SolidColorBrush(Color.FromRgb(210, 71, 38));
                myBorder1.BorderThickness = new Thickness(0.7f);

                Image imageControl = new Image();
                imageControl.Name = "Image_" + slideNumber.ToString();
                imageControl.MouseDown += ImageControl_MouseDown;
                imageControl.Source = imgSource;
                myBorder1.Child = imageControl;
                panel.Children.Add(myBorder1);

                stackpanel.Children.Add(panel);

                slideNumber++;
            }
            //Initiating the first slide
            if (slideImageSources.Count > 0)
            {
                centerSlideImage.Source = slideImageSources[0];
                SetPageDisplayLabel(1);
                Panel panel = stackpanel.Children[0] as Panel;
                Border border = panel.Children[1] as Border;
                border.BorderThickness = new Thickness(borderHighlightThickness);
                currentSlideNumber = 1;
            }
        }

        private void Minimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Maximize(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                lblPageDisplay.Padding = new Thickness(35, 0, 0, 0);
                this.WindowState = WindowState.Maximized;
                btnWindowSatate.Content = 2;
            }
            else
            {
                lblPageDisplay.Padding = new Thickness(20, 0, 0, 0);
                this.WindowState = WindowState.Normal;
                btnWindowSatate.Content = 1;
            }
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SetPageDisplayLabel(int pageNumber)
        {
            lblPageDisplay.Content = pageNumber.ToString() + "/" + slideImageSources.Count;
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        #endregion HelperMethods

        #region Thumbnail navigation
        private void PaintBorder(int currentSlideNumber)
        {
            if (currentSlideNumber > 0)
            {
                Panel panel = stackpanel.Children[currentSlideNumber] as Panel;
                Border border = panel.Children[1] as Border;
                border.BorderThickness = new Thickness(borderHighlightThickness);
            }
            else if (currentSlideNumber == 0)
            {
                Panel panel = stackpanel.Children[currentSlideNumber + 1] as Panel;
                Border border = panel.Children[1] as Border;
                border.BorderThickness = new Thickness(borderHighlightThickness);
            }
        }

        private void PaintBorderClick(int currentSlideNumber)
        {
            Panel panel = stackpanel.Children[currentSlideNumber - 1] as Panel;
            Border border = panel.Children[1] as Border;
            border.BorderThickness = new Thickness(borderHighlightThickness);
        }

        private void PaintBorderUp(int currentSlideNumber)
        {
            if (currentSlideNumber > 0)
            {
                Panel panel = stackpanel.Children[currentSlideNumber - 1] as Panel;
                Border border = panel.Children[1] as Border;
                border.BorderThickness = new Thickness(borderHighlightThickness);
            }
        }

        private void RemoveBorder(int currentSlideNumber)
        {
            if (currentSlideNumber > 0)
            {
                Panel panel = stackpanel.Children[currentSlideNumber - 1] as Panel;
                Border border = panel.Children[1] as Border;
                border.BorderThickness = new Thickness(borderDefaultThickness);
            }
            else if (currentSlideNumber == 0)
            {
                Panel panel = stackpanel.Children[currentSlideNumber] as Panel;
                Border border = panel.Children[1] as Border;
                border.BorderThickness = new Thickness(borderDefaultThickness);
            }
        }

        private void RemoveBorderUp(int currentSlideNumber)
        {
            if (currentSlideNumber > 0 && currentSlideNumber < stackpanel.Children.Count)
            {
                Panel panel = stackpanel.Children[currentSlideNumber] as Panel;
                Border border = panel.Children[1] as Border;
                border.BorderThickness = new Thickness(borderDefaultThickness);
            }
        }

        private void MoveDown()
        {
            this.prevDocument.Source = new BitmapImage(new Uri(@"/syncfusion.powerpointviewer.wpf;component/Assets/PowerPoint Viewer/ppt__back.png", UriKind.Relative));
            this.prevDocument.IsHitTestVisible = true;

            if (!IsNavigationDown && currentSlideNumber != 1)
                currentSlideNumber++;
            IsNavigationDown = true;
            RemoveBorder(currentSlideNumber);
            PaintBorder(currentSlideNumber);

            if (currentSlideNumber == slideImageSources.Count - 1)
            {
                this.NextDocumentIconImage.Source = new BitmapImage(new Uri(@"/syncfusion.powerpointviewer.wpf;component/Assets/PowerPoint Viewer/Navigation_Next _Disabled.png", UriKind.Relative));
                this.NextDocumentIconImage.IsHitTestVisible = false;
            }

            if (currentSlideNumber <= slideImageSources.Count - 1)
            {
                centerSlideImage.Source = slideImageSources[currentSlideNumber];
                currentSlideNumber++;
                SetPageDisplayLabel(currentSlideNumber);

                int scrollHeight = (int)(this.scrollViewer.ExtentHeight - this.scrollViewer.ViewportHeight);
                int thumbnailHeight = (int)(stackpanel.Children[0] as Panel).ActualHeight;

                scrolPosition = ((stackpanel.Children[0] as Panel).ActualHeight) * currentSlideNumber;
                if (scrolPosition > this.scrollViewer.ViewportHeight)
                {
                    this.scrollViewer.ScrollToVerticalOffset(scrolPosition - thumbnailHeight);
                    this.scrollViewer.UpdateLayout();
                }
            }
            if (currentSlideNumber == slideImageSources.Count - 1)
            {
                SetPageDisplayLabel(currentSlideNumber);
            }
            if (currentSlideNumber >= slideImageSources.Count)
                currentSlideNumber = slideImageSources.Count - 1;
        }

        private void MoveUp()
        {
            if (IsNavigationDown && currentSlideNumber != slideImageSources.Count - 1)
                currentSlideNumber--;

            if (this.currentSlideNumber == 1)
            {
                this.prevDocument.Source = new BitmapImage(new Uri(@"/syncfusion.powerpointviewer.wpf;component/Assets/PowerPoint Viewer/Navigation_Prev _Disabled.png", UriKind.Relative));
                this.prevDocument.IsHitTestVisible = false;
            }

            this.NextDocumentIconImage.Source = new BitmapImage(new Uri(@"/syncfusion.powerpointviewer.wpf;component/Assets/PowerPoint Viewer/ppt__for.png", UriKind.Relative));
            this.NextDocumentIconImage.IsHitTestVisible = true;

            IsNavigationDown = false;
            RemoveBorderUp(currentSlideNumber);
            PaintBorderUp(currentSlideNumber);
            if (currentSlideNumber == slideImageSources.Count)
                currentSlideNumber--;
            if (currentSlideNumber == 0)
            {
                centerSlideImage.Source = slideImageSources[currentSlideNumber];
                SetPageDisplayLabel(currentSlideNumber);
                this.scrollViewer.ScrollToVerticalOffset(0);
                this.scrollViewer.UpdateLayout();
            }
            else if (currentSlideNumber > 0 && currentSlideNumber - 1 <= slideImageSources.Count)
            {
                centerSlideImage.Source = slideImageSources[currentSlideNumber - 1];
                if (currentSlideNumber != 1)
                {
                    currentSlideNumber--;
                    SetPageDisplayLabel(currentSlideNumber + 1);
                }
                else
                {
                    SetPageDisplayLabel(currentSlideNumber);
                }

                int scrollHeight = (int)(this.scrollViewer.ExtentHeight - this.scrollViewer.ViewportHeight);
                int thumbnailHeight = (int)(stackpanel.Children[0] as Panel).ActualHeight;

                scrolPosition = (((stackpanel.Children[0] as Panel).ActualHeight) * currentSlideNumber) - (stackpanel.Children[0] as Panel).ActualHeight;


                if (scrolPosition > thumbnailHeight)
                    this.scrollViewer.ScrollToVerticalOffset(scrolPosition + thumbnailHeight);
                else
                    this.scrollViewer.ScrollToVerticalOffset(scrolPosition);
                this.scrollViewer.UpdateLayout();

            }
        }
        #endregion

        #region Events

        private void openDocument_MouseEnter(object sender, MouseEventArgs e)
        {
            Image image = sender as Image;
            image.Source = new BitmapImage(new Uri(@"/syncfusion.powerpointviewer.wpf;component/Assets/PowerPoint Viewer/ppt__open_Red.png", UriKind.Relative));
        }

        private void openDocument_MouseLeave(object sender, MouseEventArgs e)
        {
            Image image = sender as Image;
            image.Source = new BitmapImage(new Uri(@"/syncfusion.powerpointviewer.wpf;component/Assets/PowerPoint Viewer/ppt__open.png", UriKind.Relative));
        }

        private void printDocument_MouseEnter(object sender, MouseEventArgs e)
        {
            Image image = sender as Image;
            image.Source = new BitmapImage(new Uri(@"/syncfusion.powerpointviewer.wpf;component/Assets/PowerPoint Viewer/ppt__Print_Red.png", UriKind.Relative));
        }

        private void printDocument_MouseLeave(object sender, MouseEventArgs e)
        {
            Image image = sender as Image;
            image.Source = new BitmapImage(new Uri(@"/syncfusion.powerpointviewer.wpf;component/Assets/PowerPoint Viewer/ppt__Print.png", UriKind.Relative));
        }

        private void createPdfDocument_MouseEnter(object sender, MouseEventArgs e)
        {
            Image image = sender as Image;
            image.Source = new BitmapImage(new Uri(@"/syncfusion.powerpointviewer.wpf;component/Assets/PowerPoint Viewer/ppt_pdf_Red.png", UriKind.Relative));
        }

        private void createPdfDocument_MouseLeave(object sender, MouseEventArgs e)
        {
            Image image = sender as Image;
            image.Source = new BitmapImage(new Uri(@"/syncfusion.powerpointviewer.wpf;component/Assets/PowerPoint Viewer/ppt_pdf.png", UriKind.Relative));
        }

        private void prevDocument_MouseEnter(object sender, MouseEventArgs e)
        {
            Image image = sender as Image;
            image.Source = new BitmapImage(new Uri(@"/syncfusion.powerpointviewer.wpf;component/Assets/PowerPoint Viewer/ppt__back_Red.png", UriKind.Relative));
        }

        private void prevDocument_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.currentSlideNumber == 1)
            {
                this.prevDocument.Source = new BitmapImage(new Uri(@"/syncfusion.powerpointviewer.wpf;component/Assets/PowerPoint Viewer/Navigation_Prev _Disabled.png", UriKind.Relative));
                this.prevDocument.IsHitTestVisible = false;
            }
            else
            {
                Image image = sender as Image;
                image.Source = new BitmapImage(new Uri(@"/syncfusion.powerpointviewer.wpf;component/Assets/PowerPoint Viewer/ppt__back.png", UriKind.Relative));
            }
        }

        private void NextDocument_MouseEnter(object sender, MouseEventArgs e)
        {
            Image image = sender as Image;
            image.Source = new BitmapImage(new Uri(@"/syncfusion.powerpointviewer.wpf;component/Assets/PowerPoint Viewer/ppt__for_Red.png", UriKind.Relative));
        }

        private void NextDocument_MouseLeave(object sender, MouseEventArgs e)
        {
            if (currentSlideNumber == slideImageSources.Count - 1)
            {
                this.NextDocumentIconImage.Source = new BitmapImage(new Uri(@"/syncfusion.powerpointviewer.wpf;component/Assets/PowerPoint Viewer/Navigation_Next _Disabled.png", UriKind.Relative));
                this.NextDocumentIconImage.IsHitTestVisible = false;
            }
            else
            {
                Image image = sender as Image;
                image.Source = new BitmapImage(new Uri(@"/syncfusion.powerpointviewer.wpf;component/Assets/PowerPoint Viewer/ppt__for.png", UriKind.Relative));
            }
        }

        private void ImageControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RemoveBorder(currentSlideNumber);
            Image imageControl = sender as Image;
            string imageName = imageControl.Name.Replace("Image_", string.Empty);
            int slideNumber = int.Parse(imageName);
            ImageSource imageSource = null;
            if (slideImageSources.Count > 0 && slideNumber - 1 < slideImageSources.Count)
            {
                imageSource = slideImageSources[slideNumber - 1];
            }
            if (imageSource != null)
                centerSlideImage.Source = imageSource;
            currentSlideNumber = slideNumber;
            PaintBorderClick(currentSlideNumber);
            SetPageDisplayLabel(slideNumber);

            if (slideNumber == 1)
            {
                this.prevDocument.Source = new BitmapImage(new Uri(@"/syncfusion.powerpointviewer.wpf;component/Assets/PowerPoint Viewer/Navigation_Prev _Disabled.png", UriKind.Relative));
                this.prevDocument.IsHitTestVisible = false;
            }
            else
            {
                this.prevDocument.Source = new BitmapImage(new Uri(@"/syncfusion.powerpointviewer.wpf;component/Assets/PowerPoint Viewer/ppt__back.png", UriKind.Relative));
                this.prevDocument.IsHitTestVisible = true;
            }

            if (slideNumber == slideImageSources.Count)
            {
                this.NextDocumentIconImage.Source = new BitmapImage(new Uri(@"/syncfusion.powerpointviewer.wpf;component/Assets/PowerPoint Viewer/Navigation_Next _Disabled.png", UriKind.Relative));
                this.NextDocumentIconImage.IsHitTestVisible = false;
            }
            else
            {
                this.NextDocumentIconImage.Source = new BitmapImage(new Uri(@"/syncfusion.powerpointviewer.wpf;component/Assets/PowerPoint Viewer/ppt__for.png", UriKind.Relative));
                this.NextDocumentIconImage.IsHitTestVisible = true;
            }
        }

        private void openDocument_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "PowerPoint Presentations|*.pptx";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                filePath = filename;
                slideNumber = 1;
                displayBackroundWorker.RunWorkerAsync();
            }
        }

        private void printDocument_MouseDown(object sender, MouseButtonEventArgs e)
        {
            printFromPage = 1;
            printToPage = printImages.Count;
            System.Windows.Forms.PrintDialog printDialog = new System.Windows.Forms.PrintDialog();
            printDialog.AllowSomePages = true;
            printDialog.PrinterSettings.FromPage = 1;
            printDialog.PrinterSettings.ToPage = printImages.Count;
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(OnPrintPage);
            if (printDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                printFromPage = printDialog.PrinterSettings.FromPage;
                printToPage = printDialog.PrinterSettings.ToPage;
                printDoc.Print();
            }
        }

        private void OnPrintPage(object sender, PrintPageEventArgs args)
        {
            using (System.Drawing.Image image = printImages[printFromPage - 1])
            {
                System.Drawing.Graphics g = args.Graphics;
                Syncfusion.Pdf.Graphics.PdfUnitConvertor convertor = new Syncfusion.Pdf.Graphics.PdfUnitConvertor();
                imageWidth = convertor.ConvertFromPixels(image.Width, Syncfusion.Pdf.Graphics.PdfGraphicsUnit.Point);
                imageHeight = convertor.ConvertFromPixels(image.Height, Syncfusion.Pdf.Graphics.PdfGraphicsUnit.Point);
                int graphicsHeight = (int)convertor.ConvertFromPixels(args.Graphics.VisibleClipBounds.Height, Syncfusion.Pdf.Graphics.PdfGraphicsUnit.Point);
                int graphicsWidth = (int)convertor.ConvertFromPixels(args.Graphics.VisibleClipBounds.Width, Syncfusion.Pdf.Graphics.PdfGraphicsUnit.Point);
                float printDocumentHeight = convertor.ConvertFromPixels(args.PageSettings.PaperSize.Height, Syncfusion.Pdf.Graphics.PdfGraphicsUnit.Point) / 2;
                g.DrawImage(image, 1, printDocumentHeight - (imageHeight / 2), imageWidth, imageHeight);
            }

            printFromPage++;

            if (printFromPage <= printToPage)
            {

                args.HasMorePages = true;
            }
            else
            {
                args.HasMorePages = false;
            }
        }

        private void createPdfDocument_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!pdfBackroundWorker.IsBusy)
            {
                loadingIndicatorCanvas.Visibility = Visibility.Visible;
                pdfBackroundWorker.RunWorkerAsync();
            }
        }

        void pdfBackroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadingIndicatorCanvas.Visibility = Visibility.Hidden;
        }

        void pdfBackroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                PresentationToPdfConverterSettings settings = new PresentationToPdfConverterSettings();
                settings.ShowHiddenSlides = true;
                using (IPresentation presentation = Presentation.Open(filePath))
                {
                    using (PdfDocument doc = PresentationToPdfConverter.Convert(presentation, settings))
                    {
                        doc.Save(@"Sample.pdf");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("This PowerPoint Presentation cannot be converted to PDF properly, please contact Syncfusion support");
                return;
            }

            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
				System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Sample.pdf") { UseShellExecute = true };
                process.Start();
            }
        }

        private void prevDocument_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MoveUp();
        }

        private void NextDocument_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MoveDown();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down || e.Key == Key.Right)
            {
                MoveDown();
            }

            if (e.Key == Key.Up || e.Key == Key.Left)
            {
                MoveUp();
            }
        }
        #endregion Events

        #region Dispose
        protected override void OnClosing(CancelEventArgs e)
        {
            if (presentation != null)
            {
                presentation.Close();
                presentation = null;
            }
            if(slideImageSources != null)
            {
                slideImageSources.Clear();
                slideImageSources = null;
            }
            if (thumbnailImageSource != null)
            {
                thumbnailImageSource.Clear();
                thumbnailImageSource = null;
            }
            if (printImages != null)
            {
                foreach (System.Drawing.Image image in printImages)
                    image.Dispose();
                printImages.Clear();
                printImages = null;
            }
            base.OnClosing(e);
        }
        #endregion
    }
}
