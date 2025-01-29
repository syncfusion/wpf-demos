#region Copyright Syncfusion Inc. 2001 - 2017
//
//  Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Any infringement will be prosecuted under
//  applicable laws. 
//
#endregion
using System;
using System.Windows;
using System.Windows.Media;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using System.ComponentModel;
using System.IO;
using Syncfusion.Office;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using syncfusion.demoscommon.wpf;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EditEquation : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public EditEquation()
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
        /// Creates word document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get XML file path.
                string dataPath = @"Assets\DocIO\";

                //Opens an existing Word document
                using (WordDocument document = new WordDocument(dataPath + "Mathematical Equation.docx"))
                {
                    //Gets the last section in the document
                    WSection section = document.LastSection;
                //Gets paragraph from Word document
                WParagraph paragraph = document.LastSection.Body.ChildEntities[3] as WParagraph;

                //Gets MathML from the paragraph
                WMath math = paragraph.ChildEntities[0] as WMath;
                //Gets the radical equation
                IOfficeMathRadical mathRadical = math.MathParagraph.Maths[0].Functions[1] as IOfficeMathRadical;
                //Gets the fraction equation in radical
                IOfficeMathFraction mathFraction = mathRadical.Equation.Functions[0] as IOfficeMathFraction;
                //Gets the n-array in fraction
                IOfficeMathNArray mathNAry = mathFraction.Numerator.Functions[0] as IOfficeMathNArray;
                //Gets the math script in n-array
                IOfficeMathScript mathScript = mathNAry.Equation.Functions[0] as IOfficeMathScript;
                //Gets the delimiter in math script
                IOfficeMathDelimiter mathDelimiter = mathScript.Equation.Functions[0] as IOfficeMathDelimiter;
                //Gets the math script in delimiter
                mathScript = mathDelimiter.Equation[0].Functions[0] as IOfficeMathScript;
                //Gets the math run element in math script
                IOfficeMathRunElement mathParaItem = mathScript.Equation.Functions[0] as IOfficeMathRunElement;
                //Modifies the math text value
                (mathParaItem.Item as WTextRange).Text = "x";

                //Gets the math bar in delimiter
                IOfficeMathBar mathBar = mathDelimiter.Equation[0].Functions[2] as IOfficeMathBar;
                //Gets the math run element in bar
                mathParaItem = mathBar.Equation.Functions[0] as IOfficeMathRunElement;
                //Modifies the math text value
                (mathParaItem.Item as WTextRange).Text = "x";

                //Gets the paragraph from Word document
                paragraph = document.LastSection.Body.ChildEntities[6] as WParagraph;
                //Gets MathML from the paragraph
                math = paragraph.ChildEntities[0] as WMath;
                //Gets the math script equation
                mathScript = math.MathParagraph.Maths[0].Functions[0] as IOfficeMathScript;
                //Gets the math run element in math script
                mathParaItem = mathScript.Equation.Functions[0] as IOfficeMathRunElement;
                //Modifies the math text value
                (mathParaItem.Item as WTextRange).Text = "x";

                //Gets the paragraph from Word document
                paragraph = document.LastSection.Body.ChildEntities[7] as WParagraph;
                //Gets MathML from the paragraph
                WMath math2 = paragraph.ChildEntities[0] as WMath;
                //Gets bar equation
                mathBar = math2.MathParagraph.Maths[0].Functions[0] as IOfficeMathBar;
                //Gets the math run element in bar
                mathParaItem = mathBar.Equation.Functions[0] as IOfficeMathRunElement;
                //Gets the math text
                (mathParaItem.Item as WTextRange).Text = "x";

                    //Save as docx format
                    if (worddocx.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document as .docx
                            document.Save("Edit Equation.docx", FormatType.Docx);
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Edit Equation.docx") { UseShellExecute = true };
                                    process.Start();
                                }
                                catch (Win32Exception ex)
                                {
                                    MessageBox.Show("Microsoft Word Viewer or Microsoft Word is not installed in this system");
                                    Console.WriteLine(ex.ToString());
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex is IOException)
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Edit Equation.docx" + ") then try generating the document.", "File is already open",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    //Save as pdf format
                    else if (pdf.IsChecked.Value)
                    {
                        try
                        {
                            DocToPDFConverter converter = new DocToPDFConverter();
                            //Convert word document into PDF document
                            PdfDocument pdfDoc = converter.ConvertToPDF(document);
                            //Save the pdf file
                            pdfDoc.Save("Edit Equation.pdf");
                            converter.Dispose();
                            pdfDoc.Close();
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Edit Equation.pdf") { UseShellExecute = true };
                                    process.Start();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("PDF Viewer is not installed in this system");
                                    Console.WriteLine(ex.ToString());
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex is IOException)
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Edit Equation.pdf" + ") then try generating the document.", "File is already open",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Opens the template document.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonView_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to view the template document?", "Template document", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Opens the template document.
                string path = System.IO.Path.Combine(@"Assets\DocIO\Mathematical Equation.docx");
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo(path) { UseShellExecute = true };
                process.Start();
            }
        }
#endregion
    }
}