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
using Syncfusion.Windows.Shared;
using Syncfusion.OfficeChart;
using System.IO;

namespace BarChart
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
            image1.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\DocIO\docio_header.png");
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\DocIO\sfLogo.ico");
        }
        # endregion

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
                //Getting data from file
                string dataPath = @"..\..\..\..\..\..\..\Common\Data\DocIO\";

                //A new document is created.
                WordDocument document = new WordDocument();
                //Add new section to the Word document
                IWSection section = document.AddSection();
                //Set page margins of the section
                section.PageSetup.Margins.All = 72;
                //Add new paragraph to the section
                IWParagraph paragraph = section.AddParagraph();
                //Apply heading style to the title paragraph
                paragraph.ApplyStyle(BuiltinStyle.Heading1);
                //Apply center alignment to the paragraph
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                //Append text to the paragraph
                paragraph.AppendText("Northwind Management Report").CharacterFormat.TextColor = System.Drawing.Color.FromArgb(46, 116, 181);
                //Add new paragraph
                paragraph = section.AddParagraph();
                //Set before spacing to the paragraph
                paragraph.ParagraphFormat.BeforeSpacing = 20;

                //Load the excel template as stream
                Stream excelStream = File.OpenRead(dataPath + "Excel_Template.xlsx");

                //Create and Append chart to the paragraph with excel stream as parameter
                WChart BarChart = paragraph.AppendChart(excelStream, 1, "B2:C6", 470, 300);
                //Set chart data
                BarChart.ChartType = OfficeChartType.Bar_Clustered;
                BarChart.ChartTitle = "Purchase Details";
                BarChart.ChartTitleArea.FontName = "Calibri (Body)";
                BarChart.ChartTitleArea.Size = 14;

                //Set name to chart series            
                BarChart.Series[0].Name = "Sum of Purchases";
                BarChart.Series[1].Name = "Sum of Future Expenses";

                //Set Chart Data table
                BarChart.HasDataTable = true;
                BarChart.DataTable.HasBorders = true;
                BarChart.DataTable.HasHorzBorder = true;
                BarChart.DataTable.HasVertBorder = true;
                BarChart.DataTable.ShowSeriesKeys = true;
                BarChart.HasLegend = false;
                //Setting background color
                BarChart.ChartArea.Fill.ForeColor = System.Drawing.Color.FromArgb(208, 206, 206);
                BarChart.PlotArea.Fill.ForeColor = System.Drawing.Color.FromArgb(208, 206, 206);
                //Setting line pattern to the chart area
                BarChart.PrimaryCategoryAxis.Border.LinePattern = OfficeChartLinePattern.None;
                BarChart.PrimaryValueAxis.Border.LinePattern = OfficeChartLinePattern.None;
                BarChart.ChartArea.Border.LinePattern = OfficeChartLinePattern.None;
                BarChart.PrimaryValueAxis.MajorGridLines.Border.LineColor = System.Drawing.Color.FromArgb(175, 171, 171);
                //Set label for primary catagory axis
                BarChart.PrimaryCategoryAxis.CategoryLabels = BarChart.ChartData[2, 1, 6, 1];


                try
                {
                    //Saving the document as .docx
                    document.Save("Sample.docx", FormatType.Docx);
                    //Message box confirmation to view the created document.
                    if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                            System.Diagnostics.Process.Start("Sample.docx");
                            //Exit
                            this.Close();
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
                        MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Sample.docx" + ") then try generating the document.", "File is already open",
                             MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                        MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}