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
using Syncfusion.OfficeChart;
using System.Data;
using System.IO;
using syncfusion.demoscommon.wpf;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PieChart : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public PieChart()
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
                //Getting Data files path.
                string dataPath = @"Assets\DocIO\";
                //A new document is created.
                using (WordDocument document = new WordDocument(dataPath + "PieChart.docx"))
                {
                    //Get chart data from xml file
                    DataSet ds = new DataSet();
                    ds.ReadXml(dataPath + "Products.xml");
                    //Merge the product table in the Word document
                    document.MailMerge.ExecuteGroup(ds.Tables["Product"]);
                    //Find the Placeholder of Pie chart to insert
                    Syncfusion.DocIO.DLS.TextSelection selection = document.Find("<Pie Chart>", false, false);
                    WParagraph paragraph = selection.GetAsOneRange().OwnerParagraph;
                    paragraph.ChildEntities.Clear();
                    //Create and Append chart to the paragraph
                    WChart pieChart = paragraph.AppendChart(446, 270);
                    //Set chart data
                    pieChart.ChartType = OfficeChartType.Pie;
                    pieChart.ChartTitle = "Best Selling Products";
                    pieChart.ChartTitleArea.FontName = "Calibri (Body)";
                    pieChart.ChartTitleArea.Size = 14;

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        pieChart.ChartData.SetValue(i + 2, 1, ds.Tables[0].Rows[i].ItemArray[1]);
                        pieChart.ChartData.SetValue(i + 2, 2, ds.Tables[0].Rows[i].ItemArray[2]);
                    }
                    //Create a new chart series with the name “Sales”
                    IOfficeChartSerie pieSeries = pieChart.Series.Add("Sales");
                    pieSeries.Values = pieChart.ChartData[2, 2, 11, 2];
                    //Setting data label
                    pieSeries.DataPoints.DefaultDataPoint.DataLabels.IsPercentage = true;
                    pieSeries.DataPoints.DefaultDataPoint.DataLabels.Position = OfficeDataLabelPosition.Outside;
                    //Setting background color
                    pieChart.ChartArea.Fill.ForeColor = System.Drawing.Color.FromArgb(242, 242, 242);
                    pieChart.PlotArea.Fill.ForeColor = System.Drawing.Color.FromArgb(242, 242, 242);
                    pieChart.ChartArea.Border.LinePattern = OfficeChartLinePattern.None;
                    pieChart.PrimaryCategoryAxis.CategoryLabels = pieChart.ChartData[2, 1, 11, 1];
                    try
                    {
                        //Saving the document as .docx
                        document.Save("Pie Chart.docx", FormatType.Docx);
                        //Close the document
                        document.Close();
                        //Message box confirmation to view the created document.
                        if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Pie Chart.docx") { UseShellExecute = true };
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
                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Pie Chart.docx" + ") then try generating the document.", "File is already open",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
                        else
                            MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                    }
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