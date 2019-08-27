#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Windows.Xps.Packaging;
using Syncfusion.Windows.Shared;

namespace Hello_World
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Private Members
        private string m_fullPath;
        private const string m_dataPath = @"..\..\..\..\..\..\..\Common\";        
        Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
        #endregion

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
            this.Icon = (ImageSource)img.ConvertFromString(System.IO.Path.Combine(m_dataPath, @"Images\PDF\pdf_button.png"));
           
            m_fullPath = System.IO.Path.Combine(m_dataPath, @"Data\PDF\XAMLtoPDF.xaml");
            openFileDialog.InitialDirectory = new DirectoryInfo(m_dataPath).FullName;
            textBox1.Text = "XAMLtoPDF.xaml";  
        }
        # endregion

        # region Events
        /// <summary>
        /// Creates PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Get the xaml file          
            if (this.textBox1.Text == "")
            {
                System.Windows.MessageBox.Show("Please select a PDF document");
                textBox1.Focus();
            }
            else
            {
                //Convert xaml to xps 
                Stream xpsFile = GetXPSDocument(m_fullPath);

                if (xpsFile != null)
                {
                    xpsFile.Position = 0;

                    //Converting the xps file into pdf
                    Syncfusion.XPS.XPSToPdfConverter converter = new Syncfusion.XPS.XPSToPdfConverter();

                    //Convert XPS document into PDF document
                    PdfDocument document = converter.Convert(xpsFile);

                    //save and close the document 
                    document.Save("sample.pdf");
                    document.Close(true);
                    xpsFile.Dispose();
                }
            }

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you wan to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                Process.Start("Sample.pdf");
                this.Close();
            }
            else
                // Exit
                this.Close();
        }
        # endregion

        /// <summary>
        /// Convert the xaml flow document into xps file
        /// </summary>
        /// <param name="fileName"></param>
        private Stream GetXPSDocument(string fileName)
        {

            UIElement visual = System.Windows.Markup.XamlReader.Load(System.Xml.XmlReader.Create(fileName)) as UIElement;
            FixedDocument doc = new FixedDocument();
            PageContent pageContent = new PageContent();
            FixedPage fixedPage = new FixedPage();
            
            //Create first page of document
            fixedPage.Children.Add(visual);
            ((System.Windows.Markup.IAddChild)pageContent).AddChild(fixedPage);
            doc.Pages.Add(pageContent);
           
            MemoryStream xpsStream = new MemoryStream();
            XpsDocument xpsd = new XpsDocument(System.IO.Packaging.Package.Open(xpsStream,FileMode.Create));
            System.Windows.Xps.XpsDocumentWriter xw = XpsDocument.CreateXpsDocumentWriter(xpsd);
            xw.Write(doc);
            xpsd.Close();
            return xpsStream;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
            openFileDialog.Filter = "XAML Documents (*.xaml)|*.XAML";
            openFileDialog.Title = "Choose XAML document";

            if (openFileDialog.ShowDialog().Value)
            {
                textBox1.Text = openFileDialog.SafeFileName;
                m_fullPath = openFileDialog.FileName;
            }
        }
    }
}