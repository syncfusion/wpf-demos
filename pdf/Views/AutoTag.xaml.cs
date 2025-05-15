#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
using Syncfusion.Pdf.Interactive;
using System.IO;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;
using System.Windows.Resources;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AutoTag : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public AutoTag()
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
        # region Fields
        System.Drawing.Color gray = System.Drawing.Color.FromArgb(255, 77, 77, 77);
        System.Drawing.Color black = System.Drawing.Color.FromArgb(255, 0, 0, 0);
        System.Drawing.Color white = System.Drawing.Color.FromArgb(255, 255, 255, 255);
        System.Drawing.Color violet = System.Drawing.Color.FromArgb(255, 151, 108, 174);
        #endregion
        # region Events
        /// <summary>
        /// Creates PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {



            #region content string
            string toc = "\r\n What can I do with C#? ..................................................................................................................................... 3 \r\n \r\n What is .NET? .................................................................................................................................................... 3 \r\n \r\n Writing, Running, and Deploying a C# Program .............................................................................................. 3 \r\n \r\n Starting a New Program..................................................................................................................................... 3";
            string Csharp = "Welcome to C# Succinctly. True to the Succinctly series concept, this book is very focused on a single topic: the C# programming language. I might briefly mention some technologies that you can write with C# or explain how a feature fits into those technologies, but the whole of this book is about helping you become familiar with C# syntax. \r\n \r\n In this chapter, Ill start with some introductory information and then jump straight into a simple C# program.";
            string whatToD0 = "C# is a general purpose, object-oriented, component-based programming language. As a general purpose language, you have a number of ways to apply C# to accomplish many different tasks. You can build web applications with ASP.NET, desktop applications with Windows Presentation Foundation (WPF), or build mobile applications for Windows Phone. Other applications include code that runs in the cloud via Windows Azure, and iOS, Android, and Windows Phone support with the Xamarin platform. There might be times when you need a different language, like C or C++, to communicate with hardware or real-time systems. However, from a general programming perspective, you can do a lot with C#.";
            string dotnet = "The runtime is more formally named the Common Language Runtime (CLR). Programming languages that target the CLR compile to an Intermediate Language (IL). The CLR itself is a virtual machine that runs IL and provides many services such as memory management, garbage collection, exception management, security, and more.\r\n \r\n The Framework Class Library (FCL) is a set of reusable code that provides both general services and technology-specific platforms. The general services include essential types such as collections, cryptography, networking, and more. In addition to general classes, the FCL includes technology-specific platforms like ASP.NET, WPF, web services, and more. The value the FCL offers is to have common components available for reuse, saving time and money without needing to write that code yourself. \r\n \r\n There is a huge ecosystem of open-source and commercial software that relies on and supports .NET. If you visit CodePlex, GitHub, or any other open-source code repository site, you will see a multitude of projects written in C#. Commercial offerings include tools and services that help you build code, manage systems, and offer applications. Syncfusion is part of this ecosystem, offering reusable components for many of the .NET technologies I have mentioned.";
            string prog = "The previous section described plenty of great things you can do with C#, but most of them are so detailed that they require their own book. To stay focused on the C# programming language, the code in this book will be for the console application. A console application runs on the command line, which you will learn about in this section. You can write your code with any editor, but this book uses Visual Studio.";

            #endregion

            //Create a new PDF document.

            PdfDocument document = new PdfDocument();
            if (rdButtonWTPDF.IsChecked == true)
            {
                document = new PdfDocument(PdfConformanceLevel.Pdf_A4);
                document.FileStructure.Version = PdfVersion.Version2_0;

            }
            else if (rdButtonPDF_UA_2.IsChecked == true)
            {
                document.FileStructure.Version = PdfVersion.Version2_0;
            }
            //Auto Tag the document 

            document.AutoTag = true;
            document.DocumentInformation.Title = "AutoTag";
            #region page1
            //Add a page to the document.

            PdfPage page1 = document.Pages.Add();

            //Load the image from the disk.

            PdfBitmap image = new PdfBitmap(GetFileStream("AutoTag.jpg"));

            //Draw the image

            page1.Graphics.DrawImage(image, 0, 0, page1.GetClientSize().Width, page1.GetClientSize().Height - 20);

            #endregion

            #region page2
            PdfPage page2 = document.Pages.Add();

            Font font = new Font("Arial", 9);
            Font title = new Font("Arial", 22);
            Font head = new Font("Arial", 10);
            Font head1 = new Font("Arial", 16);
            PdfFont fontnormal = new PdfTrueTypeFont(font, System.Drawing.FontStyle.Regular, 9, true, true);
            PdfFont fontTitle = new PdfTrueTypeFont(title, System.Drawing.FontStyle.Bold, 22, true, true);
            PdfFont fontHead = new PdfTrueTypeFont(head, System.Drawing.FontStyle.Bold, 10, true, true);
            PdfFont fontHead2 = new PdfTrueTypeFont(head1, System.Drawing.FontStyle.Bold, 16, true, true);

            page2.Graphics.DrawString("Table of Contents", fontTitle, PdfBrushes.Black, new PointF(300, 0));
            page2.Graphics.DrawLine(new PdfPen(PdfBrushes.Black,0.5f), new PointF(0, 40), new PointF(page2.GetClientSize().Width, 40));

            page2.Graphics.DrawString("Chapter 1 Introducing C# and .NET .............................................................................................................. 3 \r\n ", fontHead, PdfBrushes.Black, new PointF(0, 60));
            page2.Graphics.DrawString(toc, fontnormal, PdfBrushes.Black, new PointF(0, 80));

            #endregion

            #region page3

            PdfPage page3 = document.Pages.Add();

            page3.Graphics.DrawString("C# Succinctly", new PdfTrueTypeFont(new Font("Arial", 32), System.Drawing.FontStyle.Bold, 32, true, true), PdfBrushes.Black, new PointF(160, 0));

            page3.Graphics.DrawLine(PdfPens.Black, new PointF(0, 40), new PointF(page3.GetClientSize().Width, 40));

            page3.Graphics.DrawString("Chapter 1 Introducing C# and .NET", fontTitle, PdfBrushes.Black, new PointF(160, 60));


            PdfTextElement element1 = new PdfTextElement(Csharp, fontnormal);
            element1.Brush = new PdfSolidBrush(System.Drawing.Color.Black);
            element1.Draw(page3, new RectangleF(0, 100, page3.GetClientSize().Width, 80));

            page3.Graphics.DrawString("What can I do with C#?", fontHead2, PdfBrushes.Black, new PointF(0, 180));
            PdfTextElement element2 = new PdfTextElement(whatToD0, fontnormal);
            element2.Brush = new PdfSolidBrush(System.Drawing.Color.Black);
            element2.Draw(page3, new RectangleF(0, 210, page3.GetClientSize().Width, 80));


            page3.Graphics.DrawString("What is .Net", fontHead2, PdfBrushes.Black, new PointF(0, 300));
            PdfTextElement element3 = new PdfTextElement(dotnet, fontnormal);
            element3.Brush = new PdfSolidBrush(System.Drawing.Color.Black);
            element3.Draw(page3, new RectangleF(0, 330, page3.GetClientSize().Width, 180));


            page3.Graphics.DrawString("Writing, Running, and Deploying a C# Program", fontHead2, PdfBrushes.Black, new PointF(0, 520));
            PdfTextElement element4 = new PdfTextElement(prog, fontnormal);
            element4.Brush = new PdfSolidBrush(System.Drawing.Color.Black);
            element4.Draw(page3, new RectangleF(0, 550, page3.GetClientSize().Width, 60));

            PdfBitmap img = new PdfBitmap(GetFileStream("autotagsmall.jpg"));
            page3.Graphics.DrawImage(img, new PointF(0, 630));
            page3.Graphics.DrawString("Note: The code samples in this book can be downloaded at", fontnormal, PdfBrushes.DarkBlue, new PointF(20, 630));
            page3.Graphics.DrawString("https://bitbucket.org/syncfusiontech/c-succinctly", fontnormal, PdfBrushes.Blue, new PointF(20, 640));
            SizeF linkSize = fontnormal.MeasureString("https://bitbucket.org/syncfusiontech/c-succinctly");
            RectangleF rectangle = new RectangleF(20, 640, linkSize.Width, linkSize.Height);

            //Creates a new Uri Annotation

            PdfUriAnnotation uriAnnotation = new PdfUriAnnotation(rectangle, "https://bitbucket.org/syncfusiontech/c-succinctly");
            uriAnnotation.Color = new PdfColor(255, 255, 255);
            //Adds alternative description for annotation
            uriAnnotation.Text = "annotation";
            //Adds this annotation to a new page
            page3.Annotations.Add(uriAnnotation);

            #endregion
            //Save the document and dispose it.
            string fileName = rdButtonWTPDF.IsChecked == true ? "WTPDF.pdf" : "AutoTag.pdf";
            document.Save(fileName);
            document.Close(true);

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo(fileName) { UseShellExecute = true };
                process.Start();

            }

        }

       
        private Stream GetFileStream(string fileName)
        {
            Uri uriResource = new Uri("/syncfusion.pdfdemos.wpf;component/Assets/PDF/" + fileName, UriKind.Relative);
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(uriResource);
            return streamResourceInfo.Stream;
        }
        # endregion
    }
}
