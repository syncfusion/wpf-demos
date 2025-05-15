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
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using System.ComponentModel;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using syncfusion.demoscommon.wpf;
using System.IO;
using System.Drawing;
using Color = System.Drawing.Color;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class GroupShapes : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public GroupShapes()
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
                //Creates a new Word document 
                using (WordDocument document = new WordDocument())
                {
                    //Adds new section to the document
                    IWSection section = document.AddSection();
                    //Sets page setup options
                    section.PageSetup.Orientation = PageOrientation.Landscape;
                    section.PageSetup.Margins.All = 72;
                    section.PageSetup.PageSize = new SizeF(792f, 612f);
                    //Adds new paragraph to the section
                    WParagraph paragraph = section.AddParagraph() as WParagraph;
                    //Creates new group shape
                    GroupShape groupShape = new GroupShape(document);
                    //Adds group shape to the paragraph.
                    paragraph.ChildEntities.Add(groupShape);

                    //Create a RoundedRectangle shape with "Management" text
                    CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(324f, 107.7f, 144f, 45f), 0, false, false, Color.FromArgb(50, 48, 142), "Management", groupShape, document);

                    //Create a BentUpArrow shape to connect with "Development" shape
                    CreateChildShape(AutoShapeType.BentUpArrow, new RectangleF(177.75f, 176.25f, 210f, 50f), 180, false, false, Color.White, null, groupShape, document);

                    //Create a BentUpArrow shape to connect with "Sales" shape
                    CreateChildShape(AutoShapeType.BentUpArrow, new RectangleF(403.5f, 175.5f, 210f, 50f), 180, true, false, Color.White, null, groupShape, document);

                    //Create a DownArrow shape to connect with "Production" shape
                    CreateChildShape(AutoShapeType.DownArrow, new RectangleF(381f, 153f, 29.25f, 72.5f), 0, false, false, Color.White, null, groupShape, document);

                    //Create a RoundedRectangle shape with "Development" text
                    CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(135f, 226.45f, 110f, 40f), 0, false, false, Color.FromArgb(104, 57, 157), "Development", groupShape, document);

                    //Create a RoundedRectangle shape with "Production" text
                    CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(341f, 226.5f, 110f, 40f), 0, false, false, Color.FromArgb(149, 50, 118), "Production", groupShape, document);

                    //Create a RoundedRectangle shape with "Sales" text
                    CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(546.75f, 226.5f, 110f, 40f), 0, false, false, Color.FromArgb(179, 63, 62), "Sales", groupShape, document);

                    //Create a DownArrow shape to connect with "Software" and "Hardware" shape
                    CreateChildShape(AutoShapeType.DownArrow, new RectangleF(177f, 265.5f, 25.5f, 20.25f), 0, false, false, Color.White, null, groupShape, document);

                    //Create a DownArrow shape to connect with "Series" and "Parts" shape
                    CreateChildShape(AutoShapeType.DownArrow, new RectangleF(383.25f, 265.5f, 25.5f, 20.25f), 0, false, false, Color.White, null, groupShape, document);

                    //Create a DownArrow shape to connect with "North" and "South" shape            
                    CreateChildShape(AutoShapeType.DownArrow, new RectangleF(588.75f, 266.25f, 25.5f, 20.25f), 0, false, false, Color.White, null, groupShape, document);

                    //Create a BentUpArrow shape to connect with "Software" shape
                    CreateChildShape(AutoShapeType.BentUpArrow, new RectangleF(129.5f, 286.5f, 60f, 33f), 180, false, false, Color.White, null, groupShape, document);

                    //Create a BentUpArrow shape to connect with "Hardware" shape
                    CreateChildShape(AutoShapeType.BentUpArrow, new RectangleF(190.5f, 286.5f, 60f, 33f), 180, true, false, Color.White, null, groupShape, document);

                    //Create a BentUpArrow shape to connect with "Series" shape
                    CreateChildShape(AutoShapeType.BentUpArrow, new RectangleF(336f, 287.25f, 60f, 33f), 180, false, false, Color.White, null, groupShape, document);

                    //Create a BentUpArrow shape to connect with "Parts" shape
                    CreateChildShape(AutoShapeType.BentUpArrow, new RectangleF(397f, 287.25f, 60f, 33f), 180, true, false, Color.White, null, groupShape, document);

                    //Create a BentUpArrow shape to connect with "North" shape
                    CreateChildShape(AutoShapeType.BentUpArrow, new RectangleF(541.5f, 288f, 60f, 33f), 180, false, false, Color.White, null, groupShape, document);

                    //Create a BentUpArrow shape to connect with "South" shape
                    CreateChildShape(AutoShapeType.BentUpArrow, new RectangleF(602.5f, 288f, 60f, 33f), 180, true, false, Color.White, null, groupShape, document);

                    //Create a RoundedRectangle shape with "Software" text
                    CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(93f, 320.25f, 90f, 40f), 0, false, false, Color.FromArgb(23, 187, 189), "Software", groupShape, document);

                    //Create a RoundedRectangle shape with "Hardware" text
                    CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(197.2f, 320.25f, 90f, 40f), 0, false, false, Color.FromArgb(24, 159, 106), "Hardware", groupShape, document);

                    //Create a RoundedRectangle shape with "Series" text
                    CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(299.25f, 320.25f, 90f, 40f), 0, false, false, Color.FromArgb(23, 187, 189), "Series", groupShape, document);

                    //Create a RoundedRectangle shape with "Parts" text
                    CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(404.2f, 320.25f, 90f, 40f), 0, false, false, Color.FromArgb(24, 159, 106), "Parts", groupShape, document);

                    //Create a RoundedRectangle shape with "North" text
                    CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(505.5f, 321.75f, 90f, 40f), 0, false, false, Color.FromArgb(23, 187, 189), "North", groupShape, document);

                    //Create a RoundedRectangle shape with "South" text
                    CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(609.7f, 321.75f, 90f, 40f), 0, false, false, Color.FromArgb(24, 159, 106), "South", groupShape, document);

                    //Save as docx format
                    if (worddocx.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document as .docx
                            document.Save("Group Shapes.docx", FormatType.Docx);
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Group Shapes.docx") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Group Shapes.doc" + ") then try generating the document.", "File is already open",
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
                            pdfDoc.Save("Group Shapes.pdf");
                            pdfDoc.Close();
                            converter.Dispose();
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Group Shapes.pdf") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Group Shapes.doc" + ") then try generating the document.", "File is already open",
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
        /// Create a child shape with its specified properties and add into specified group shape
        /// </summary>
        /// <param name="autoShapeType">Represent the AutoShapeType of child shape</param>
        /// <param name="bounds">Represent the bounds of child shape to be placed</param>
        /// <param name="rotation">Represent the rotation of child shape</param>
        /// <param name="flipH">Represent the horizontal flip of child shape</param>
        /// <param name="flipV">Represent the vertical flip of child shape</param>
        /// <param name="fillColor">Represent the fill color of child shape</param>
        /// <param name="text">Represent the text that to be append in child shape</param>
        /// <param name="groupShape">Represent the group shape to add a child shape</param>
        /// <param name="wordDocument">Represent the Word document instance</param>
        private static void CreateChildShape(AutoShapeType autoShapeType, RectangleF bounds, float rotation, bool flipH, bool flipV, Color fillColor, string text, GroupShape groupShape, WordDocument wordDocument)
        {
            //Creates new shape to add into group
            Shape shape = new Shape(wordDocument, autoShapeType);
            //Sets height and width for shape
            shape.Height = bounds.Height;
            shape.Width = bounds.Width;
            //Sets horizontal and vertical position
            shape.HorizontalPosition = bounds.X;
            shape.VerticalPosition = bounds.Y;
            //Set rotation and flipH for the shape
            if (rotation != 0)
                shape.Rotation = rotation;
            if (flipH)
                shape.FlipHorizontal = true;
            if (flipV)
                shape.FlipVertical = true;
            //Applies fill color for shape
            if (fillColor != Color.White)
            {
                shape.FillFormat.Fill = true;
                shape.FillFormat.Color = fillColor;
            }
            //Set wrapping style for shape
            shape.WrapFormat.TextWrappingStyle = TextWrappingStyle.InFrontOfText;
            //Sets horizontal and vertical origin
            shape.HorizontalOrigin = HorizontalOrigin.Page;
            shape.VerticalOrigin = VerticalOrigin.Page;
            //Sets no line to RoundedRectangle shapes
            if (autoShapeType == AutoShapeType.RoundedRectangle)
                shape.LineFormat.Line = false;
            //Add paragraph for the shape textbody
            if (text != null)
            {
                IWParagraph paragraph = shape.TextBody.AddParagraph();
                //Set required textbody alignments
                shape.TextFrame.TextVerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                //Set required paragraph alignments
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                IWTextRange textRange = paragraph.AppendText(text);
                //Applies a required text formatting's
                textRange.CharacterFormat.FontName = "Calibri";
                textRange.CharacterFormat.FontSize = 15;
                textRange.CharacterFormat.TextColor = Color.White;
                textRange.CharacterFormat.Bold = true;
                textRange.CharacterFormat.Italic = true;
            }
            //Adds the specified shape to group shape
            groupShape.Add(shape);
        }
        #endregion
    }
}