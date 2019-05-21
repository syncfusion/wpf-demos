#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Syncfusion.Windows.PdfViewer;
using Syncfusion.Windows.Shared;

namespace ExportasImage_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Private Members
        private PdfDocumentView pdfViewer1;
        # endregion

        # region Constructor
        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter converter = new ImageSourceConverter();
            this.Icon = (ImageSource)converter.ConvertFromString(GetFullTemplatePath("pdf viewer.png", true));
			string filePath = @"..\..\..\..\..\..\..\Common\";
            string file = System.IO.Path.Combine(filePath, @"images\PDF\pdf_header.png");
            this.image1.Source = (ImageSource)converter.ConvertFromString(file);
            this.Closed += Window1_Closed; ;
            pdfViewer1 = new PdfDocumentView();
            SkinStorage.SetMetroBrush(this, new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)));
        }
        # endregion

        # region Events
        /// <summary>
        /// Occurs when the window is about to close
        /// </summary>
        private void Window1_Closed(object sender, EventArgs e)
        {
            pdfViewer1.Unload();
        }
        /// <summary>
        /// Handles selected / all pages option.
        /// </summary>
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (allRadioBtn.IsChecked.Value)
            {
                rangeStackPanel.IsEnabled = false;
                TextFrom.Foreground = Brushes.Gray;
                TextTo.Foreground = Brushes.Gray;
            }
            else
            {
                rangeStackPanel.IsEnabled = true;
                TextFrom.Foreground = Brushes.Black;
                TextTo.Foreground = Brushes.Black;
            }
        }

        /// <summary>
        /// Export the select pages as Image.
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int from = comboBoxFrom.SelectedIndex;
            int to = comboBoxTo.SelectedIndex;

            if (from > to)
            {
                MessageBox.Show("The 'From' value cannot be greater than the 'To' value.", "Error");
                return;
            }
            BitmapSource image = null;
            BitmapSource[] images = null;

            if (from == to)
                image = pdfViewer1.ExportAsImage(from);
            else
                images = pdfViewer1.ExportAsImage(from, to);

            string output = @"..\..\Output\Image";

            System.IO.Directory.CreateDirectory(@"..\..\Output\");

            BitmapEncoder encoder = null;
            if (image != null)
            {
                encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                FileStream stream = new FileStream(output + Guid.NewGuid().ToString() + ".png", FileMode.Create);
                encoder.Save(stream);
            }
            else
            {
                foreach (BitmapSource img in images)
                {
                    encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(img));
                    FileStream stream = new FileStream(output + Guid.NewGuid().ToString() + ".png", FileMode.Create);
                    encoder.Save(stream);
                }
            }

            if (image != null || images != null)
            {
                //Message box confirmation to view the created PDF document.
                if (System.Windows.MessageBox.Show("Do you want to view the exported image files?", "Image Exported",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    //Launching the PDF file using the default Application.[Acrobat Reader]
                    System.Diagnostics.Process.Start(@"..\..\Output\");
                    this.Close();
                }
                else
                    // Exit
                    this.Close();
            }
        }

        /// <summary>
        /// Loads PDF into PdfViewer.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            pdfViewer1.Load(GetFullTemplatePath("EmpDetails.pdf", false));

            int count = pdfViewer1.PageCount;
            for (int i = 1; i < count + 1; i++)
            {
                comboBoxFrom.Items.Add(i);
                comboBoxTo.Items.Add(i);
            }

            comboBoxFrom.SelectedIndex = 0;
            comboBoxTo.SelectedIndex = count - 1;
            rangeStackPanel.IsEnabled = false;
        }
        #endregion

        # region Helper Methods
        /// <summary>
        /// Gets the full path of the PDF template or image.
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <param name="image">True if image</param>
        /// <returns>Path of the file</returns>
        private string GetFullTemplatePath(string fileName, bool image)
        {
            string fullPath = @"..\..\..\..\..\..\..\Common\";
            string folder = image ? "Images" : "Data";

            return string.Format(@"{0}{1}\PDF\{2}", fullPath, folder, fileName);
        }
        # endregion
    }
}