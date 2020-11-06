#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.olapchartdemos.wpf
{
    using System.Windows.Controls;
    using System;
    using Syncfusion.Windows.Chart.Olap;
    using System.Windows;
    using Syncfusion.Windows.Chart.Olap.Converter;
    using Microsoft.Xaml.Behaviors;

    public class ExportingCustomization : TargetedTriggerAction<OlapChart>
    {
        #region Members

        private string appLocation = AppDomain.CurrentDomain.BaseDirectory;
        OlapChartWordExport wordCoverter;
        OlapChartPdfExport pdfConverter;

        #endregion

        #region Methods

        protected override void Invoke(object parameter)
        {
            string wordpath = "";
            string pdfpath = "";
            string outputpath = "";
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries"))
            {
                wordpath = System.IO.Path.GetFullPath(@"..\Data\olapchart\TemplateDocument\Document.doc");
                outputpath = System.IO.Path.GetFullPath(@"..\Data\olapchart\OutputDocument\Document.doc");
                pdfpath = System.IO.Path.GetFullPath(@"..\Data\olapchart\TemplateDocument\PdfDocument.pdf");
            }
            else
            {
                wordpath = System.IO.Path.GetFullPath(@"..\..\Data\olapchart\TemplateDocument\Document.doc");
                outputpath = System.IO.Path.GetFullPath(@"..\..\Data\olapchart\OutputDocument\Document.doc");
                pdfpath = System.IO.Path.GetFullPath(@"..\..\Data\olapchart\TemplateDocument\PdfDocument.pdf");
            }
            if (((parameter as RoutedEventArgs).Source as Button).Name == "btn3")
            {
                try
                {
                    System.IO.File.Copy(wordpath, outputpath, true);
                    wordCoverter = new OlapChartWordExport(this.Target);
                    wordCoverter.ExportintoNewDoc(outputpath);
                    if (MessageBox.Show("Do you want to view the MS Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        System.Diagnostics.Process.Start(outputpath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (((parameter as RoutedEventArgs).Source as Button).Name == "btn4")
            {
                try
                {
                    System.IO.File.Copy(wordpath, outputpath, true);
                    wordCoverter = new OlapChartWordExport(this.Target);
                    wordCoverter.ExportIntoTemplateDoc(outputpath);
                    if (MessageBox.Show("Do you want to view the MS Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        System.Diagnostics.Process.Start(outputpath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if (((parameter as RoutedEventArgs).Source as Button).Name == "btn5")
            {
                try
                {
                    System.IO.File.Copy(wordpath, outputpath, true);
                    wordCoverter = new OlapChartWordExport(this.Target);
                    wordCoverter.ExportIntoTemplateDoc(outputpath, "MarkerString1");
                    if (MessageBox.Show("Do you want to view the MS Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        System.Diagnostics.Process.Start(outputpath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if (((parameter as RoutedEventArgs).Source as Button).Name == "btn6")
            {
                try
                {
                    pdfConverter = new OlapChartPdfExport(this.Target);
                    pdfConverter.ExportIntoNewPdf(pdfpath);
                    if (MessageBox.Show("Do you want to view the PDF document?", "PDF has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        System.Diagnostics.Process.Start(pdfpath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion
    }
}
