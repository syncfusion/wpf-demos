#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using System.Drawing;
using System.IO;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Booklet : DemoControl
    {
        private string previousText;
        private string previousText1;
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Booklet()
        {
		   
            InitializeComponent();
            
        }
        #endregion
        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion
        # region Events
        /// <summary>
        /// Creates Booklet Pdf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxSource.Text == String.Empty || textBoxWidth.Text == String.Empty || textBoxSource.Text == String.Empty)
                MessageBox.Show("Please fill all the TextBoxes","Error Creating Booklet",MessageBoxButton.OK,MessageBoxImage.Error);
            else
            {
                //Load a PDF document
                PdfLoadedDocument ldoc = new PdfLoadedDocument(textBoxSource.Text);

                //Create booklet with two sides               
                PdfDocument doc = PdfBookletCreator.CreateBooklet(ldoc, new SizeF(float.Parse(textBoxWidth.Text), float.Parse(textBoxHeight.Text)), checkBox1.IsChecked.Value);

                //Save the document
                doc.Save("Booklet.pdf");
                //Close the loaded document
                doc.Close(true);

                //Message box confirmation to view the created PDF document.
                if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information)
                    == MessageBoxResult.Yes)
                {
                    //Launching the PDF file using the default Application.[Acrobat Reader]
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Booklet.pdf") { UseShellExecute = true };
                    process.Start();
                }

            }
        }

        /// <summary>
        /// Gets the source document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSource_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "PDF Documents (*.pdf)|*.PDF";

			string path = @"Assets\PDF";

            file.InitialDirectory = new DirectoryInfo(path).FullName;

            if (file.ShowDialog().Value)
                textBoxSource.Text = file.FileName;
        }
        private void TextBoxHeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            double num = 0;
            bool success = double.TryParse(((TextBox)sender).Text, out num);
            if (success && num >= 0)
            {
                previousText = ((TextBox)sender).Text;
            }
            else if (((TextBox)sender).Text == "")
                previousText = ((TextBox)sender).Text;
            else
                ((TextBox)sender).Text = previousText;
        }

        private void TextBoxWidth_TextChanged(object sender, TextChangedEventArgs e)
        {
            double num = 0;
            bool success = double.TryParse(((TextBox)sender).Text, out num);
            if (success && num >= 0)
            {
                previousText1 = ((TextBox)sender).Text;
            }
            else if (((TextBox)sender).Text == "")
                previousText1 = ((TextBox)sender).Text;
            else
                ((TextBox)sender).Text = previousText1;
        }
        # endregion
    }
}
