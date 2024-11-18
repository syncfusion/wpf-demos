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
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing;
using System.Diagnostics;
using Syncfusion.Pdf.Interactive;
using System.IO;
using Syncfusion.Windows.Shared;
using Syncfusion.Pdf.Parsing;
using syncfusion.demoscommon.wpf;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class FindPDFCorruption : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public FindPDFCorruption()
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
            //Create a new instance for the PDF analyzer.
            PdfDocumentAnalyzer analyzer = new PdfDocumentAnalyzer(@"Assets\PDF\CorruptedDocument.pdf");

            //Get the syntax errors.
            SyntaxAnalyzerResult result = analyzer.AnalyzeSyntax();
			analyzer.Close();

            //Check whether the document is corrupted or not.
            if (result.IsCorrupted)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine("The PDF document is corrupted.");
                int count = 1;
                foreach (PdfException exception in result.Errors)
                {
                    builder.AppendLine(count++.ToString() + ": " + exception.Message);
                }
                MessageBox.Show(builder.ToString(), "Result");
            }
            else
                MessageBox.Show("No syntax issues found", "Result");
        }

        #endregion
    }
}
