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
using Microsoft.Win32;
using Syncfusion.XPS;
using Syncfusion.Pdf;
using Syncfusion.Windows.Shared;


namespace XPS_to_PDF_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Private Members
        private string m_fullPath;
        private const string m_dataPath = @"..\..\..\..\..\..\..\Common\";
        # endregion

        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Window1()
        {
		   
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
            string file = System.IO.Path.Combine(m_dataPath, @"images\PDF\pdf_header.png");
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
            imglabel.Source = (ImageSource)img.ConvertFromString(System.IO.Path.Combine(m_dataPath, @"Images\PDF\label_Image.gif"));
            this.Icon = (ImageSource)img.ConvertFromString(System.IO.Path.Combine(m_dataPath, @"Images\PDF\pdf_button.png"));

            m_fullPath = System.IO.Path.Combine(m_dataPath, @"Data\PDF\XPStoPDF.xps");
            textBox1.Text = "XPStoPDF.xps";
        }
        # endregion

        # region Events
        /// <summary>
        /// Creates PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTopdf_Click(object sender, RoutedEventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                System.Windows.MessageBox.Show("Please select a PDF document");
                textBox1.Focus();
            }
            else
            {
                // Initialize XPS converter.
                XPSToPdfConverter converter = new XPSToPdfConverter();

                // Convert XPS document into PDF document.
                PdfDocument document = converter.Convert(m_fullPath);

                // Save & close the pdf file.
                document.Save("Sample.pdf");
                document.Close(true);

                //Message box confirmation to view the created PDF document.
                if (System.Windows.MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    //Launching the PDF file using the default Application.[Acrobat Reader]
                    System.Diagnostics.Process.Start("Sample.pdf");
                    this.Close();
                }
                else
                    // Exit
                    this.Close();
            }
        }

        /// <summary>
        /// Gets the source document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog file = new Microsoft.Win32.OpenFileDialog();
            file.Filter = "XPS Documents (*.xps)|*.XPS";
            file.Title = "Choose XPS document";

            if (file.ShowDialog().Value)
            {
                textBox1.Text = file.SafeFileName;
                m_fullPath = file.FileName;
            }
        }

        # endregion
    }
}
