#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Diagnostics;
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
using Syncfusion.XlsIO;
using Syncfusion.Windows.Shared;

namespace EmbeddedChart
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        private string fileName;
        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
#if NETCORE
            string file = @"..\..\..\..\..\..\..\Common\Images\XlsIO\xlsio_header.png";
#else
            string file = @"..\..\..\..\..\..\Common\Images\XlsIO\xlsio_header.png";
#endif
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            #region Workbook Initialize
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel application object.
            IWorkbook workbook = null;
            //Set the default version as Excel97to2003
            IApplication application = excelEngine.Excel;
            if (this.rdButtonxls.IsChecked.Value)
            {
                application.DefaultVersion = ExcelVersion.Excel97to2003;
#if NETCORE
                workbook = application.Workbooks.Open(@"..\..\..\..\..\..\..\Common\Data\XlsIO\EmbeddedChart.xls");
#else
                workbook = application.Workbooks.Open(@"..\..\..\..\..\..\Common\Data\XlsIO\EmbeddedChart.xls");
#endif
                fileName = "ChartWorksheet.xls";
            }
            //Set the default version as Excel 2007;
            else if (this.rdButtonxlsx.IsChecked.Value)
            {
#if NETCORE
                workbook = application.Workbooks.Open(@"..\..\..\..\..\..\..\Common\Data\XlsIO\EmbeddedChart.xlsx");
#else
                workbook = application.Workbooks.Open(@"..\..\..\..\..\..\Common\Data\XlsIO\EmbeddedChart.xlsx");
#endif
                workbook.Version = ExcelVersion.Excel2007;
                fileName = "ChartWorksheet.xlsx";
            }
            //Set the default version as Excel 2010;
            else if (this.rdButtonexcel2010.IsChecked.Value)
            {
#if NETCORE
                workbook = application.Workbooks.Open(@"..\..\..\..\..\..\..\Common\Data\XlsIO\EmbeddedChart.xlsx");
#else
                workbook = application.Workbooks.Open(@"..\..\..\..\..\..\Common\Data\XlsIO\EmbeddedChart.xlsx");
#endif
                workbook.Version = ExcelVersion.Excel2010;
                fileName = "ChartWorksheet.xlsx";
            }
            //Set the default version as Excel 2010;
            else if (this.rdButtonexcel2013.IsChecked.Value)
            {
#if NETCORE
                workbook = application.Workbooks.Open(@"..\..\..\..\..\..\..\Common\Data\XlsIO\EmbeddedChart.xlsx");
#else
                workbook = application.Workbooks.Open(@"..\..\..\..\..\..\Common\Data\XlsIO\EmbeddedChart.xlsx");
#endif
                workbook.Version = ExcelVersion.Excel2013;
                fileName = "ChartWorksheet.xlsx";
            }        
            
            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet worksheet = workbook.Worksheets[0];
            #endregion
           
            // Adding a New chart to the Existing Worksheet   
            IChartShape chart = workbook.Worksheets[0].Charts.Add();


            chart.DataRange = worksheet.Range["A3:C15"];
            chart.ChartTitle = "Crescent City, CA";
            chart.IsSeriesInRows = false;

            chart.PrimaryValueAxis.Title = "Precipitation,in.";
            chart.PrimaryValueAxis.TitleArea.TextRotationAngle = 90;
            chart.PrimaryValueAxis.MaximumValue = 14.0;
            chart.PrimaryValueAxis.NumberFormat = "0.0";

            chart.PrimaryCategoryAxis.Title = "Month";

            #region Format Series
            IChartSerie serieOne = chart.Series[0];
             
                chart.ChartType = ExcelChartType.Column_Clustered_3D;

                //set the Backwall fill option
                chart.BackWall.Fill.FillType = ExcelFillType.Gradient;

                //set the Texture Type
                chart.BackWall.Fill.GradientColorType = ExcelGradientColor.TwoColor;
                chart.BackWall.Fill.GradientStyle = ExcelGradientStyle.Diagonl_Down;
                chart.BackWall.Fill.ForeColor = System.Drawing.Color.WhiteSmoke;
                chart.BackWall.Fill.BackColor = System.Drawing.Color.LightBlue;

                //set the Border Linecolor 
                chart.BackWall.Border.LineColor = System.Drawing.Color.Wheat;

                //set the Picture Type     
                chart.BackWall.PictureUnit = ExcelChartPictureType.stretch;

                //set the Backwall thickness
                chart.BackWall.Thickness = 10;

                //set the sidewall fill option
                chart.SideWall.Fill.FillType = ExcelFillType.SolidColor;

                //set the sidewall foreground and backcolor
                chart.SideWall.Fill.BackColor = System.Drawing.Color.White;
                chart.SideWall.Fill.ForeColor = System.Drawing.Color.White;

                //set the side wall Border color
                chart.SideWall.Border.LineColor = System.Drawing.Color.Beige;

                //set floor fill option
                chart.Floor.Fill.FillType = ExcelFillType.Pattern;

                //set the floor pattern Type
                chart.Floor.Fill.Pattern = ExcelGradientPattern.Pat_Divot;

                //Set the floor fore and Back ground color
                chart.Floor.Fill.ForeColor = System.Drawing.Color.Blue ;
                chart.Floor.Fill.BackColor = System.Drawing.Color.White;

                //set the floor thickness
                chart.Floor.Thickness = 3;
            
             IChartSerie serieTwo = chart.Series[1];
            //Show value as data labels
            serieOne.DataPoints.DefaultDataPoint.DataLabels.IsValue = true;
            serieTwo.DataPoints.DefaultDataPoint.DataLabels.IsValue = true;

            //Embedded Chart Position
            chart.TopRow = 2;
            chart.BottomRow = 30;
            chart.LeftColumn = 5;
            chart.RightColumn = 18;
            serieTwo.Name = "Temperature,deg.F";
            #endregion


            #region Legend setting
            chart.Legend.Position = ExcelLegendPosition.Right;
            chart.Legend.IsVerticalLegend = false;
            #endregion

            if (this.rdButtonexcel2013.IsChecked.Value)
            {
                chart.Series[0].IsFiltered = true;
                chart.Categories[0].IsFiltered = true;
                chart.Categories[1].IsFiltered = true;
            }
           
            //chart.Scale(50, 50);

            try
            {
                workbook.SaveAs(fileName);

                //Close the workbook.
                workbook.Close();

                //No exception will be thrown if there are unsaved workbooks.
                excelEngine.ThrowNotSavedOnDestroy = false;
                excelEngine.Dispose();

                //Message box confirmation to view the created spreadsheet.
                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
#if NETCORE
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo(fileName)
                    {
                        UseShellExecute = true
                    };
                    process.Start();
#else
                    Process.Start(fileName);
#endif
                    //Exit
                    this.Close();
                }
                else
                    // Exit
                    this.Close();
            }
            catch
            {
                MessageBox.Show("Sorry, Excel can't open two workbooks with the same name at the same time.\nPlease close the workbook and try again.", "File is already open", MessageBoxButton.OK);
            }
        }
    }
}