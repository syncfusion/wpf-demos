#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Windows.Shared;


namespace Split_Document
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Private Members
        PdfLoadedDocument ldoc;
        # endregion

        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Window1()
        {
		   
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
            string file = @"..\..\..\..\..\..\..\Common\images\PDF\pdf_header.png";
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
			this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\images\PDF\pdf_button.png"); 
            this.comboBoxPage.Items.Add("1");
            ldoc = new PdfLoadedDocument(@"..\..\..\..\..\..\..\Common\Data\PDF\Essential_XlsIO.pdf");
            this.textBoxSplit.TextChanged += new TextChangedEventHandler(textBoxSplit_TextChanged);
        }
        # endregion

        # region Events
        /// <summary>
        /// Updates the page combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void textBoxSplit_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ldoc != null)
            {
                comboBoxPage.Items.Clear();
                for (int i = 1; i < ldoc.Pages.Count; i++)
                    comboBoxPage.Items.Add(i);
                this.comboBoxPage.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Gets the input file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "PDF Documents (*.pdf)|*.PDF";

            if (file.ShowDialog().Value)
            {
                ldoc = new PdfLoadedDocument(file.FileName);
                textBoxSplit.Text = file.FileName;
            }
        }

        /// <summary>
        /// Creates PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Create two pdf documents
            PdfDocument doc1 = new PdfDocument();
            PdfDocument doc2 = new PdfDocument();

            //Split the source document into two based on the split-at page value.
            int splitAtPage = (int)comboBoxPage.SelectedValue;
            for (int i = 0; i < splitAtPage; i++)
                doc1.ImportPage(ldoc, i);

            for (int j = splitAtPage; j < ldoc.Pages.Count; j++)
                doc2.ImportPage(ldoc, j);

            //Save pdf document1
            doc1.Save("Document1.pdf");

            //Save pdf document2
            doc2.Save("Document2.pdf");

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process.Start("Document1.pdf");
                System.Diagnostics.Process.Start("Document2.pdf");
                this.Close();
            }
            else
                // Exit
                this.Close();
        }

        /// <summary>
        /// Validates the page number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Convert.ToInt32(comboBoxPage.SelectedValue) > ldoc.Pages.Count)
                MessageBox.Show("Invalid page number");
        }

        /// <summary>
        /// Window Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textBoxSplit.Text = @"Essential_Studio.pdf";
        }

        # endregion
    }
}