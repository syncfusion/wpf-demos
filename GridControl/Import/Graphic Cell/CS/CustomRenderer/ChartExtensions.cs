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
using System.Data;
using Syncfusion.Linq;
using Syncfusion.XlsIO;
using Syncfusion.Windows.Chart;
using System.Windows;
using System.Windows.Media;
using Syncfusion.XlsIO.Implementation.Charts;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using ChartImportingDemo;

namespace ImportingDemo.CustomRenderer
{
    public static class ChartExtensions
    {

        static DataTemplate pielegendtemplate = App.Current.Resources["LegendTemplate1"] as DataTemplate;
        static bool SecondaryAxisflag = false;
        /// <summary>
        /// To load Embedded Chart
        /// </summary>
        /// <param name="chartShape"></param>
        /// <returns></returns>
        public static Chart CreateChart(this IChartShape chartShape)
        {
            Chart chart = new Chart();
            ChartArea chartArea = new ChartArea();
            IChart iChart = chartShape as IChart;
            CreateChartSeries(chartArea, iChart);
            chart.Areas.Add(chartArea);
            return chart;
        }

        /// <summary>
        /// To load WorkSheet chart
        /// </summary>
        /// <param name="iChart"></param>
        /// <returns></returns>
        public static Chart CreateChart(this IChart iChart)
        {
            Chart chart = new Chart();
            ChartArea chartArea = new ChartArea();
            CreateChartSeries(chartArea, iChart);
            chart.Areas.Add(chartArea);
            return chart;
        }

        private static void CreateChartSeries(ChartArea chartArea, IChart iChart)
        {
            ChartAxis commonaxis = new ChartAxis() { Orientation = Orientation.Vertical, OpposedPosition = true };
            chartArea.Axes.Add(commonaxis);
            for (int count = 0; count < iChart.Series.Count; count++)
            {

                IChartSerie XlsIOChartSerie = iChart.Series[count];
                ChartSeries UIChartSeries = new ChartSeries() { ShowEmptyPoints = false };
                SetSerieType(UIChartSeries, XlsIOChartSerie);
                DataTable ct = new DataTable();
                DataTable vt = new DataTable();
                if (XlsIOChartSerie.CategoryLabels != null)
                {
                      ct = XlsIOChartSerie.CategoryLabels.Worksheet.ExportDataTable(XlsIOChartSerie.CategoryLabels, ExcelExportDataTableOptions.ComputedFormulaValues);
                        vt = XlsIOChartSerie.Values.Worksheet.ExportDataTable(XlsIOChartSerie.Values, ExcelExportDataTableOptions.ComputedFormulaValues);
                }
                else if (XlsIOChartSerie.NameRange != null)
                {
                    ct = XlsIOChartSerie.Values.Worksheet.ExportDataTable(XlsIOChartSerie.NameRange, ExcelExportDataTableOptions.ComputedFormulaValues);
                    vt = XlsIOChartSerie.Values.Worksheet.ExportDataTable(XlsIOChartSerie.Values, ExcelExportDataTableOptions.ComputedFormulaValues);
                }
                else if (iChart.DataRange != null)
                {
                    ct = XlsIOChartSerie.Values.Worksheet.ExportDataTable(iChart.DataRange, ExcelExportDataTableOptions.ComputedFormulaValues);
                    vt = XlsIOChartSerie.Values.Worksheet.ExportDataTable(XlsIOChartSerie.Values, ExcelExportDataTableOptions.ComputedFormulaValues);
                }

                List<ChartDataPoint> data = ConvertDataTableToDataPoints(ct, vt, iChart.IsSeriesInRows);
                UIChartSeries.DataSource = data;
                UIChartSeries.BindingPathX = "X";
                UIChartSeries.BindingPathsY = new List<string> { "Y" };
                UIChartSeries.Label = XlsIOChartSerie.Name;
                UIChartSeries.Resolution = 5;
                UIChartSeries.UseOptimization = true;
                UIChartSeries.ShowSmartLabels = false;

                #region Pie Chart
                if (UIChartSeries.Type == ChartTypes.Pie)
                {
                    System.Drawing.Color serieborder = new System.Drawing.Color();
                    System.Drawing.Color seriecolor = new System.Drawing.Color();
                    UIChartSeries.ColorEach = true;
                    UIChartSeries.Palette = ChartColorPalette.Custom;
                    Brush[] brushes = new Brush[iChart.Workbook.Palette.Length];
                    if (iChart.ChartType == ExcelChartType.Pie_3D)
                    {
                        int i = 0;
                        foreach (Syncfusion.XlsIO.IChartDataPoint dataPoint in XlsIOChartSerie.DataPoints)
                        {
                            if (dataPoint.DataFormat.HasInterior && !dataPoint.DataFormat.Interior.UseAutomaticFormat)
                            {
                                seriecolor = dataPoint.DataFormat.Interior.ForegroundColor;
                                brushes[i] = new SolidColorBrush(Color.FromRgb(seriecolor.R, seriecolor.G, seriecolor.B));
                                i++;
                                UIChartSeries.CustomPalette = brushes;
                            }
                        }

                    }
                    else
                    {
                        serieborder = XlsIOChartSerie.SerieFormat.LineProperties.LineColor;
                        if (XlsIOChartSerie.SerieFormat.AreaProperties.UseAutomaticFormat == false)
                            seriecolor = XlsIOChartSerie.SerieFormat.Fill.ForeColor;
                        UIChartSeries.Interior = new SolidColorBrush(Color.FromRgb(seriecolor.R, seriecolor.G, seriecolor.B));
                    }
                    if (XlsIOChartSerie.SerieFormat.HasLineProperties)
                        UIChartSeries.StrokeThickness = GetLineWidth(XlsIOChartSerie.SerieFormat.LineProperties.LineWeight);
                    else
                        UIChartSeries.StrokeThickness = 0;

                }
                #endregion

                #region Line and Scatter Chart
                else if (UIChartSeries.Type == ChartTypes.Line || UIChartSeries.Type == ChartTypes.Scatter || UIChartSeries.Type == ChartTypes.FastScatter)
                {
                    if (UIChartSeries.Type == ChartTypes.Scatter || UIChartSeries.Type == ChartTypes.FastScatter)
                        UIChartSeries.BindingPathX = "XDouble";

                    if (XlsIOChartSerie.SerieFormat.IsMarkerSupported)
                    {
                        if (!XlsIOChartSerie.SerieFormat.IsAutoMarker)
                        {
                            System.Drawing.Color markercolor = XlsIOChartSerie.SerieFormat.MarkerBackgroundColor;
                            UIChartSeries.Interior = new SolidColorBrush(Color.FromRgb(markercolor.R, markercolor.G, markercolor.B));
                            UIChartSeries.Stroke = new SolidColorBrush(Color.FromRgb(markercolor.R, markercolor.G, markercolor.B));
                        }
                    }

                    if (!XlsIOChartSerie.SerieFormat.LineProperties.IsAutoLineColor)
                    {
                        System.Drawing.Color lineColor = XlsIOChartSerie.SerieFormat.LineProperties.LineColor;
                        UIChartSeries.Stroke = new SolidColorBrush(Color.FromRgb(lineColor.R, lineColor.G, lineColor.B));
                    }
                    UIChartSeries.ColorEach = false;
                    UIChartSeries.LegendIcon = ChartLegendIcon.HorizontalLine;
                    UIChartSeries.StrokeThickness = GetLineWidth(XlsIOChartSerie.SerieFormat.LineProperties.LineWeight) + 1;
                }
                #endregion

                #region Other Charts
                else
                {
                    UIChartSeries.ColorEach = false;
                    System.Drawing.Color fcolor;
                    if (XlsIOChartSerie.SerieFormat.AreaProperties != null)
                    {
                        if (XlsIOChartSerie.SerieFormat.AreaProperties.UseAutomaticFormat == false)
                        {
                            fcolor = XlsIOChartSerie.SerieFormat.Fill.ForeColor;
                            Color fclr = Color.FromRgb(fcolor.R, fcolor.G, fcolor.B);
                            UIChartSeries.Interior = new SolidColorBrush(fclr);
                            UIChartSeries.ColorEach = false;
                        }
                    }
                }
                #endregion

                CreateDataLabels(UIChartSeries, XlsIOChartSerie);
                CreateChartSecondaryAxis(UIChartSeries, XlsIOChartSerie, chartArea, iChart);
                chartArea.Series.Add(UIChartSeries);
            }

            System.Drawing.Color areaColor = iChart.ChartArea.Fill.ForeColor;
            chartArea.Background = new SolidColorBrush(Color.FromRgb(areaColor.R, areaColor.G, areaColor.B));
            if (!iChart.PlotArea.Interior.UseAutomaticFormat)
            {
                System.Drawing.Color plotColor = iChart.PlotArea.Fill.ForeColor;
                chartArea.GridBackground = new SolidColorBrush(Color.FromRgb(plotColor.R, plotColor.G, plotColor.B));
            }
            CreateChartTitle(chartArea, iChart);
            CreateChartLegend(chartArea, iChart);
            CreateChartPrimaryAxis(chartArea, iChart);
        }

        private static void CreateChartLegend(ChartArea chartArea, IChart iChart)
        {
            if (iChart.HasLegend)
            {
                ChartLegend cl = new ChartLegend();
                
                if (iChart.Series[0].SerieType == ExcelChartType.Pie || iChart.Series[0].SerieType == ExcelChartType.Pie_3D || iChart.Series[0].SerieType == ExcelChartType.Doughnut || iChart.Series[0].SerieType == ExcelChartType.Doughnut_Exploded)
                    cl.ItemTemplate = pielegendtemplate;

                if (iChart.Legend.TextArea != null)
                {
                    cl.FontFamily = new System.Windows.Media.FontFamily(iChart.Legend.TextArea.FontName);
                    cl.FontSize = iChart.Legend.TextArea.Size;
                    cl.FontStyle = iChart.Legend.TextArea.Italic ? FontStyles.Italic : FontStyles.Normal;
                    cl.FontWeight = iChart.Legend.TextArea.Bold ? FontWeights.Bold : FontWeights.Normal;

                    if (iChart.Legend.FrameFormat.HasLineProperties && !iChart.Legend.FrameFormat.Border.AutoFormat && iChart.Legend.FrameFormat.Border.LinePattern != ExcelChartLinePattern.None)
                        cl.BorderThickness = new Thickness(GetLineWidth(iChart.Legend.FrameFormat.LineProperties.LineWeight));
                    else
                        cl.BorderThickness = new Thickness(0);

                    System.Drawing.Color lineColor = iChart.Legend.FrameFormat.Border.LineColor;
                    Color borderColor = Color.FromRgb(lineColor.R, lineColor.G, lineColor.B);

                    if (iChart.Legend.FrameFormat.Border.Transparency != 1.0)
                        cl.BorderBrush = new SolidColorBrush(borderColor);
                    else
                        cl.BorderBrush = null;

                    if (iChart.Legend.TextArea.BackgroundMode != ExcelChartBackgroundMode.Transparent)
                    {
                        System.Drawing.Color xlBackColor = iChart.Legend.TextArea.FrameFormat.Fill.BackColor;
                        Color backColor = Color.FromArgb(xlBackColor.A, xlBackColor.R, xlBackColor.G, xlBackColor.B);
                        cl.Background = new SolidColorBrush(backColor);
                    }
                    else
                        cl.Background = Brushes.Transparent;

                    System.Drawing.Color xlForeColor = iChart.Legend.TextArea.RGBColor;
                    Color foreColor = Color.FromRgb(xlForeColor.R, xlForeColor.G, xlForeColor.B);
                    cl.Foreground = new SolidColorBrush(foreColor);
                }
                
                chartArea.Legend = cl;
                switch (iChart.Legend.Position)
                {
                    case ExcelLegendPosition.Bottom:
                        Chart.SetDock(cl, ChartDock.Bottom);
                        break;
                    case ExcelLegendPosition.Corner:
                        Chart.SetDock(cl, ChartDock.Floating);
                        break;
                    case ExcelLegendPosition.Left:
                        Chart.SetDock(cl, ChartDock.Left);
                        break;
                    case ExcelLegendPosition.NotDocked:
                        Chart.SetDock(cl, ChartDock.Floating);
                        break;
                    case ExcelLegendPosition.Right:
                        Chart.SetDock(cl, ChartDock.Right);
                        break;
                    case ExcelLegendPosition.Top:
                        Chart.SetDock(cl, ChartDock.Top);
                        break;
                    default:
                        Chart.SetDock(cl, ChartDock.Right);
                        break;
                }
            }
        }

        private static void CreateChartPrimaryAxis(ChartArea chartArea, IChart iChart)
        {
            if (chartArea.Series[0].Type != ChartTypes.Bar && chartArea.Series[0].Type != ChartTypes.StackingBar && chartArea.Series[0].Type != ChartTypes.StackingBar100)
            {
                #region Primary Horizontal Axis Implementation.
                if (iChart.PrimaryCategoryAxis.Visible)
                {
                    chartArea.PrimaryAxis.Header = iChart.PrimaryCategoryAxis.Title;
                    chartArea.PrimaryAxis.LabelFontFamily = new FontFamily(iChart.PrimaryCategoryAxis.Font.FontName);
                    chartArea.PrimaryAxis.LabelFontSize = iChart.PrimaryCategoryAxis.Font.Size;
                    chartArea.PrimaryAxis.LabelRotateAngle = iChart.PrimaryCategoryAxis.TextRotationAngle;

                    if (!iChart.PrimaryCategoryAxis.HasMajorGridLines && !iChart.PrimaryCategoryAxis.HasMinorGridLines)
                        ChartArea.SetShowGridLines(chartArea.PrimaryAxis, false);

                    ///In excel Primary X and Primary Y axis will be Value axis for Scatter Charts. 
                    ///For others Primary and secondary X axis is category axis
                    /// and Primary and secondary Y axis is value axis. It will work vice versily for Bar chart
                    if (chartArea.Series[0].Type == ChartTypes.Scatter || chartArea.Series[0].Type == ChartTypes.FastScatter)
                    {
                        chartArea.PrimaryAxis.IsAutoSetRange = false;
                        chartArea.PrimaryAxis.ValueType = ChartValueType.Double;
                        if (iChart.PrimaryCategoryAxis.MinimumValue == 0 && iChart.PrimaryCategoryAxis.MaximumValue == 0)
                        {
                            ComputeRange(chartArea, iChart, "CategoryAxis");
                        }
                        else
                        {
                            DoubleRange doubleRange = new DoubleRange(iChart.PrimaryCategoryAxis.MinimumValue, iChart.PrimaryCategoryAxis.MaximumValue);
                            chartArea.PrimaryAxis.Range = doubleRange;
                            chartArea.PrimaryAxis.Interval = iChart.PrimaryCategoryAxis.MajorUnit;
                        }
                    }

                    else if (!iChart.PrimaryCategoryAxis.AutoTickLabelSpacing)
                    {
                        if (iChart.PrimaryCategoryAxis.CategoryLabels != null && iChart.PrimaryCategoryAxis.CategoryLabels.HasDateTime)
                        {
                            chartArea.PrimaryAxis.ValueType = ChartValueType.DateTime;
                            chartArea.PrimaryAxis.DateTimeInterval = TimeSpan.FromDays(iChart.PrimaryCategoryAxis.TickLabelSpacing);
                            string format = iChart.PrimaryCategoryAxis.NumberFormat;
                            format = format.Replace("m", "M");
                            chartArea.PrimaryAxis.LabelDateTimeFormat = format;
                            chartArea.PrimaryAxis.IsAutoSetRange = true;

                        }
                        else if (iChart.PrimaryCategoryAxis.CategoryLabels != null && iChart.PrimaryCategoryAxis.CategoryLabels.HasNumber)
                        {
                            chartArea.PrimaryAxis.ValueType = ChartValueType.Double;
                            chartArea.PrimaryAxis.Interval = iChart.PrimaryCategoryAxis.TickLabelSpacing;
                        }
                        else
                        {
                            chartArea.PrimaryAxis.Interval = iChart.PrimaryCategoryAxis.TickLabelSpacing;
                        }
                    }

                }
                else
                    chartArea.PrimaryAxis.AxisVisibility = Visibility.Hidden;
                #endregion

                #region Primary Vertical Axis Implementation
                if (iChart.PrimaryValueAxis.Visible)
                {
                    chartArea.SecondaryAxis.IsAutoSetRange = false;
                    chartArea.SecondaryAxis.Header = iChart.PrimaryValueAxis.Title;
                    chartArea.SecondaryAxis.LabelFontFamily = new FontFamily(iChart.PrimaryValueAxis.Font.FontName);
                    chartArea.SecondaryAxis.LabelFontSize = iChart.PrimaryValueAxis.Font.Size;
                    chartArea.SecondaryAxis.LabelRotateAngle = iChart.PrimaryValueAxis.TextRotationAngle;

                    if (!iChart.PrimaryValueAxis.HasMajorGridLines && !iChart.PrimaryValueAxis.HasMinorGridLines)
                        ChartArea.SetShowGridLines(chartArea.PrimaryAxis, false);

                    if (iChart.PrimaryValueAxis.MinimumValue == 0 && iChart.PrimaryValueAxis.MaximumValue == 0)
                    {
                        ComputeRange(chartArea, iChart, "ValueAxis");
                    }
                    else
                    {
                        DoubleRange doubleRange = new DoubleRange(iChart.PrimaryValueAxis.MinimumValue, iChart.PrimaryValueAxis.MaximumValue);
                        chartArea.SecondaryAxis.Range = doubleRange;
                        chartArea.SecondaryAxis.Interval = iChart.PrimaryValueAxis.MajorUnit;
                    }
                }
                else
                {
                    chartArea.SecondaryAxis.AxisVisibility = Visibility.Hidden;
                }
                #endregion
            }
            #region Axis Implementation for Bar Chart
            else
            {
                //Axis Implementation for Bar Type Chart, because it differs from all Chart.
                //PrimaryAxis Code for BarChart.
                if (iChart.PrimaryValueAxis.Visible)
                {
                    chartArea.PrimaryAxis.Header = iChart.PrimaryValueAxis.Title;
                    chartArea.PrimaryAxis.LabelFontFamily = new FontFamily(iChart.PrimaryValueAxis.Font.FontName);
                    chartArea.PrimaryAxis.LabelFontSize = iChart.PrimaryValueAxis.Font.Size;
                    chartArea.PrimaryAxis.LabelRotateAngle = iChart.PrimaryValueAxis.TextRotationAngle;
                    chartArea.PrimaryAxis.IsAutoSetRange = false;

                    if (!iChart.PrimaryValueAxis.HasMajorGridLines && !iChart.PrimaryValueAxis.HasMinorGridLines)
                        ChartArea.SetShowGridLines(chartArea.PrimaryAxis, false);

                    if (iChart.PrimaryValueAxis.MinimumValue == 0 && iChart.PrimaryValueAxis.MaximumValue == 0)
                        chartArea.PrimaryAxis.IsAutoSetRange = false;
                    else
                    {
                        DoubleRange doubleRange = new DoubleRange(iChart.PrimaryValueAxis.MinimumValue, iChart.PrimaryValueAxis.MaximumValue);
                        chartArea.PrimaryAxis.Range = doubleRange;
                        chartArea.PrimaryAxis.Interval = iChart.PrimaryValueAxis.MajorUnit;
                    }
                }
                else
                {
                    chartArea.PrimaryAxis.AxisVisibility = Visibility.Hidden;
                }

                //Secondary Axis code for BarChart.
                if (iChart.PrimaryCategoryAxis.Visible)
                {
                    if (!iChart.PrimaryCategoryAxis.HasMajorGridLines && !iChart.PrimaryCategoryAxis.HasMinorGridLines)
                        ChartArea.SetShowGridLines(chartArea.SecondaryAxis, false);

                    if (!iChart.PrimaryCategoryAxis.AutoTickLabelSpacing)
                    {
                        chartArea.SecondaryAxis.Header = iChart.PrimaryCategoryAxis.Title;
                        chartArea.SecondaryAxis.LabelFontFamily = new FontFamily(iChart.PrimaryCategoryAxis.Font.FontName);
                        chartArea.SecondaryAxis.LabelFontSize = iChart.PrimaryCategoryAxis.Font.Size;
                        chartArea.SecondaryAxis.LabelRotateAngle = iChart.PrimaryCategoryAxis.TextRotationAngle;

                        if (iChart.PrimaryCategoryAxis.CategoryLabels != null && iChart.PrimaryCategoryAxis.CategoryLabels.HasDateTime)
                        {
                            chartArea.SecondaryAxis.ValueType = ChartValueType.DateTime;
                            chartArea.SecondaryAxis.DateTimeInterval = TimeSpan.FromDays(iChart.PrimaryCategoryAxis.TickLabelSpacing);
                            chartArea.SecondaryAxis.LabelFormat = iChart.PrimaryCategoryAxis.CategoryLabels.NumberFormat;

                        }
                        else if (iChart.PrimaryCategoryAxis.CategoryLabels != null && iChart.PrimaryCategoryAxis.CategoryLabels.HasNumber)
                        {
                            chartArea.SecondaryAxis.ValueType = ChartValueType.Double;
                            chartArea.SecondaryAxis.Interval = iChart.PrimaryCategoryAxis.TickLabelSpacing;
                        }
                        else
                        {
                            chartArea.SecondaryAxis.Interval = iChart.PrimaryCategoryAxis.TickLabelSpacing;
                        }
                    }

                }
                else
                    chartArea.SecondaryAxis.AxisVisibility = Visibility.Hidden;
            }
            

            #endregion
        }

        private static void CreateChartSecondaryAxis(ChartSeries UIChartSeries, IChartSerie XlsIOChartSerie, ChartArea chartArea, IChart iChart)
        {
            ///Secondary Axis Implementation
            if (!XlsIOChartSerie.UsePrimaryAxis)
            {
                SecondaryAxisflag = true;
                ///Secondary Horizontal Axis Implementation
                #region  Secondary Horizontal Axis
                if (iChart.SecondaryCategoryAxis.Visible)
                {
                    UIChartSeries.XAxis = chartArea.Axes[2];
                    UIChartSeries.XAxis.Header = iChart.SecondaryCategoryAxis.Title;
                    UIChartSeries.XAxis.LabelFontFamily = new FontFamily(iChart.SecondaryCategoryAxis.Font.FontName);
                    UIChartSeries.XAxis.LabelFontSize = iChart.SecondaryCategoryAxis.Font.Size;
                    UIChartSeries.XAxis.LabelRotateAngle = iChart.SecondaryCategoryAxis.TextRotationAngle;

                    if (!iChart.SecondaryCategoryAxis.HasMajorGridLines && !iChart.SecondaryCategoryAxis.HasMinorGridLines)
                        ChartArea.SetShowGridLines(UIChartSeries.XAxis, false);

                    if (!iChart.SecondaryCategoryAxis.AutoTickLabelSpacing)
                    {
                        UIChartSeries.XAxis.IsAutoSetRange = false;
                        if (iChart.SecondaryCategoryAxis.CategoryLabels != null && iChart.SecondaryCategoryAxis.CategoryLabels.HasDateTime)
                        {
                            UIChartSeries.XAxis.ValueType = ChartValueType.DateTime;
                            UIChartSeries.XAxis.DateTimeInterval = TimeSpan.FromDays(iChart.SecondaryCategoryAxis.TickLabelSpacing);
                            string format = iChart.SecondaryCategoryAxis.NumberFormat;
                            format = format.Replace("m", "M");
                            UIChartSeries.XAxis.LabelDateTimeFormat = format;
                            UIChartSeries.XAxis.IsAutoSetRange = true;
                        }
                        else if (iChart.SecondaryCategoryAxis.CategoryLabels != null && iChart.SecondaryCategoryAxis.CategoryLabels.HasNumber)
                        {
                            UIChartSeries.XAxis.ValueType = ChartValueType.Double;
                            UIChartSeries.XAxis.Interval = iChart.SecondaryCategoryAxis.TickLabelSpacing;
                            UIChartSeries.XAxis.Range = new DoubleRange(iChart.SecondaryCategoryAxis.MinimumValue, iChart.SecondaryCategoryAxis.MaximumValue);
                        }
                        else
                        {
                            UIChartSeries.XAxis.Interval = iChart.SecondaryCategoryAxis.TickLabelSpacing;
                        }
                    }
                    else
                    {
                        try
                        {
                            if (iChart.SecondaryCategoryAxis.CategoryLabels != null && iChart.SecondaryCategoryAxis.CategoryLabels.HasNumber)
                            {
                                chartArea.PrimaryAxis.ValueType = ChartValueType.Double;
                                foreach (var ser in chartArea.Series)
                                {
                                    ser.Data.ChartXValueType = ChartValueType.Double;
                                }
                                UIChartSeries.XAxis.Interval = iChart.PrimaryCategoryAxis.TickLabelSpacing;
                            }
                        }
                        catch
                        {
                            UIChartSeries.XAxis.IsAutoSetRange = true;
                        }
                    }
                }
                #endregion

                ///Secondary Vertical axis Implementation
                #region Secondary Vertical axis

                if (iChart.SecondaryValueAxis.Visible)
                {
                    UIChartSeries.YAxis = chartArea.Axes[2];
                    if (!iChart.SecondaryValueAxis.HasMajorGridLines && !iChart.SecondaryValueAxis.HasMinorGridLines)
                        ChartArea.SetShowGridLines(UIChartSeries.YAxis, false);
                    try { UIChartSeries.YAxis.Header = iChart.SecondaryValueAxis.Title; }
                    catch { }
                    UIChartSeries.YAxis.LabelFontFamily = new FontFamily(iChart.SecondaryValueAxis.Font.FontName);
                    UIChartSeries.YAxis.LabelFontSize = iChart.SecondaryValueAxis.Font.Size;
                    UIChartSeries.YAxis.LabelFontWeight = iChart.PrimaryValueAxis.Font.Bold ? FontWeights.Bold : FontWeights.Normal;
                    UIChartSeries.YAxis.LabelRotateAngle = iChart.SecondaryValueAxis.TextRotationAngle;

                    
                    if (iChart.SecondaryValueAxis.MinimumValue == 0 && iChart.SecondaryValueAxis.MaximumValue == 0)
                        ComputeRange(chartArea, iChart, "SecondaryValueAxis");
                    else
                    {
                        UIChartSeries.YAxis.IsAutoSetRange = false;
                        DoubleRange doubleRange = new DoubleRange(iChart.SecondaryValueAxis.MinimumValue, iChart.SecondaryValueAxis.MaximumValue);
                        UIChartSeries.YAxis.Range = doubleRange;
                        UIChartSeries.YAxis.Interval = iChart.SecondaryValueAxis.MajorUnit;
                    }
                }
                else
                {
                    UIChartSeries.YAxis.AxisVisibility = Visibility.Hidden;
                }
                #endregion
            }
            else if (chartArea.Axes.Count > 2 && !SecondaryAxisflag)
            {
                chartArea.Axes.RemoveAt(2);
            }
        }

        private static void ComputeRange(ChartArea chartArea, IChart iChart, string Axis)
        {
            var values = from s in chartArea.Series select s.Data;
            double min = double.MaxValue;
            double max = double.MinValue;
            foreach (var v in values)
            {
                for (int i = 0; i < v.Count; i++)
                {
                    if (v[i].Y < min)
                        min = v[i].Y;

                    if (v[i].Y > max)
                        max = v[i].Y;
                }
            }
            #region Range calculation for secondary Axis

            if (Axis == "SecondaryValueAxis")
            {
                if (!iChart.SecondaryValueAxis.IsAutoMajor)
                {
                    if (min < (max * 5 / 6))
                        chartArea.SecondaryAxis.Range = new DoubleRange(0, max + iChart.SecondaryValueAxis.MajorUnit);
                    else
                    {
                        chartArea.SecondaryAxis.Range = new DoubleRange(min - iChart.SecondaryValueAxis.MajorUnit, max + iChart.SecondaryValueAxis.MajorUnit);
                    }
                }
                else
                {
                    if (min < (max * 5 / 6))
                        chartArea.SecondaryAxis.Range = new DoubleRange(0, max);
                    else
                    {
                        chartArea.SecondaryAxis.Range = new DoubleRange(min, max);
                    }
                }
            }
            #endregion

            #region Range Calculation for Primary Horizontal Axis
            else if (Axis == "CategoryAxis")
            {
                foreach (var v in values)
                {
                    for (int i = 0; i < v.Count; i++)
                    {
                        if (v[i].X < min)
                            min = v[i].X;

                        if (v[i].X > max)
                            max = v[i].X;
                    }
                }
                if (!iChart.PrimaryCategoryAxis.IsAutoMajor)
                {
                    if (min < (max * 5 / 6))
                        chartArea.PrimaryAxis.Range = new DoubleRange(0, max + iChart.PrimaryCategoryAxis.MajorUnit);
                    else
                    {
                        chartArea.PrimaryAxis.Range = new DoubleRange(min - iChart.PrimaryCategoryAxis.MajorUnit, max + iChart.PrimaryCategoryAxis.MajorUnit);
                    }
                }
                else
                {
                    if (min < (max * 5 / 6))
                        chartArea.PrimaryAxis.Range = new DoubleRange(0, max);
                    else
                    {
                        chartArea.PrimaryAxis.Range = new DoubleRange(min, max);
                    }
                }
            }
            #endregion

            #region Range Calculation for Primary Vertical Axis
            else 
            {
                if (!iChart.PrimaryValueAxis.IsAutoMajor)
                {
                    if (min < (max * 5 / 6))
                        chartArea.SecondaryAxis.Range = new DoubleRange(0, max + iChart.PrimaryValueAxis.MajorUnit);
                    else
                    {
                        chartArea.SecondaryAxis.Range = new DoubleRange(min - iChart.PrimaryValueAxis.MajorUnit, max + iChart.PrimaryValueAxis.MajorUnit);
                    }
                }
                else
                {
                    if (min < (max * 5 / 6))
                        chartArea.SecondaryAxis.Range = new DoubleRange(0, max);
                    else
                    {
                        chartArea.SecondaryAxis.Range = new DoubleRange(min, max);
                    }
                }
            }
            
            #endregion
        }

        private static double GetLineWidth(ExcelChartLineWeight excelChartLineWeight)
        {
            double lineWeight = 0;

            switch (excelChartLineWeight)
            {
                case ExcelChartLineWeight.Narrow:
                    lineWeight = 1f;
                    break;

                case ExcelChartLineWeight.Hairline:
                    lineWeight = .5f;
                    break;

                case ExcelChartLineWeight.Medium:
                    lineWeight = 2.5f;
                    break;

                case ExcelChartLineWeight.Wide:
                    lineWeight = 3.5f;
                    break;

                default:
                    lineWeight = (int)excelChartLineWeight;
                    break;
            }
            return lineWeight;
        }

        private static void CreateChartTitle(ChartArea chartArea, IChart iChart)
        {
            chartArea.FontFamily = new System.Windows.Media.FontFamily(iChart.ChartTitleArea.FontName);
            chartArea.FontSize = iChart.ChartTitleArea.Size;
            chartArea.FontWeight = iChart.ChartTitleArea.Bold ? FontWeights.Bold : FontWeights.Normal;
            chartArea.Header = iChart.ChartTitle;
            chartArea.FontStyle = iChart.ChartTitleArea.Italic ? FontStyles.Italic : FontStyles.Normal;
        }

        private static void CreateDataLabels(ChartSeries UIChartSeries, IChartSerie XlsIOChartSerie)
        {

            UIChartSeries.AdornmentsInfo.SegmentLabelFontFamily = new System.Windows.Media.FontFamily(XlsIOChartSerie.DataPoints.DefaultDataPoint.DataLabels.FontName);
            UIChartSeries.AdornmentsInfo.SegmentLabelFontSize = (int)XlsIOChartSerie.DataPoints[0].DataLabels.Size;
            UIChartSeries.AdornmentsInfo.SegmentLabelFontWeight = XlsIOChartSerie.DataPoints[0].DataLabels.Bold ? FontWeights.Bold : FontWeights.Normal;
            UIChartSeries.AdornmentsInfo.IsLabelRotate = true;
            UIChartSeries.AdornmentsInfo.SegmentLabelRotation = XlsIOChartSerie.DataPoints.DefaultDataPoint.DataLabels.TextRotationAngle;

            if ((XlsIOChartSerie.DataPoints.DefaultDataPoint.DataLabels.Position & (ExcelDataLabelPosition.Outside | ExcelDataLabelPosition.OutsideBase | ExcelDataLabelPosition.Automatic)) == 0)
            {
                UIChartSeries.AdornmentsInfo.SegmentIsOut = true;
                UIChartSeries.AdornmentsInfo.AdornmentsPosition = AdornmentsPosition.Top;
            }
            if (XlsIOChartSerie.DataPoints.DefaultDataPoint.DataLabels.IsPercentage)
            {
                UIChartSeries.ShowDataLabels = true;
                UIChartSeries.AdornmentsInfo.SegmentLabelContent = LabelContent.Percentage;
                UIChartSeries.AdornmentsInfo.SegmentLabelFormat = "0";
            }
            if (XlsIOChartSerie.DataPoints.DefaultDataPoint.DataLabels.IsValue)
            {
                UIChartSeries.ShowDataLabels = true;
                UIChartSeries.AdornmentsInfo.SegmentLabelContent = LabelContent.YValue;
            }
        }

        private static List<ChartDataPoint> ConvertDataTableToDataPoints(DataTable CategoryTable, DataTable ValuesTable, bool IsSeriesInRows)
        {
            List<ChartDataPoint> data = new List<ChartDataPoint>();
            if (IsSeriesInRows)
            {
                for (int col = 0; col < CategoryTable.Columns.Count; col++)
                {
                    double y = 0;
                    string x = CategoryTable.Rows[0][col].ToString();
                    double.TryParse(ValuesTable.Rows[0][col].ToString(), out y);
                    data.Add(new ChartDataPoint(x, y));
                }
            }
            else
            {
                for (int row = 0; row < CategoryTable.Rows.Count; row++)
                {
                    if (row < ValuesTable.Rows.Count)
                    {
                        if (CategoryTable.Rows.Count < ValuesTable.Rows.Count)
                        {
                            for (int valueRow = 0; valueRow < ValuesTable.Rows.Count; valueRow++)
                            {
                                double y = 0;
                                string x = CategoryTable.Rows[row][0].ToString();
                                double.TryParse(ValuesTable.Rows[valueRow][0].ToString(), out y);
                                data.Add(new ChartDataPoint(x, y));
                            }
                        }
                        else
                        {
                            double y = 0;
                            string x = CategoryTable.Rows[row][0].ToString();
                            double.TryParse(ValuesTable.Rows[row][0].ToString(), out y);
                            data.Add(new ChartDataPoint(x, y));
                        }
                    }
                }
            }
            return data;
        }

        private static void SetSerieType(ChartSeries UIChartSeries, IChartSerie XlsIOChartSerie)
        {
            switch (XlsIOChartSerie.SerieType)
            {

                case ExcelChartType.Column_Clustered_3D:
                    UIChartSeries.Type = ChartTypes.Column;
                    break;
                case ExcelChartType.Column_Clustered:
                    UIChartSeries.Type = ChartTypes.Column;
                    break;
                case ExcelChartType.Column_Stacked:
                    UIChartSeries.Type = ChartTypes.StackingColumn;
                    break;
                case ExcelChartType.Column_Stacked_100:
                    UIChartSeries.Type = ChartTypes.StackingColumn100;
                    break;
                case ExcelChartType.Line:
                    UIChartSeries.Type = ChartTypes.Line;
                    break;
                case ExcelChartType.Line_Markers:
                    UIChartSeries.Type = ChartTypes.Line;
                    UIChartSeries.EnableEffects = true;
                    break;
                case ExcelChartType.Pie:
                    UIChartSeries.Type = ChartTypes.Pie;
                    break;
                case ExcelChartType.Pie_Exploded:
                    UIChartSeries.Type = ChartTypes.Pie;
                    ChartPieType.SetExplodedAll(UIChartSeries, true);
                    break;
                case ExcelChartType.Bar_Clustered:
                    UIChartSeries.Type = ChartTypes.Bar;
                    break;
                case ExcelChartType.Bar_Stacked:
                    UIChartSeries.Type = ChartTypes.StackingBar;
                    break;
                case ExcelChartType.Bar_Stacked_100:
                    UIChartSeries.Type = ChartTypes.StackingBar100;
                    break;
                case ExcelChartType.Area:
                    UIChartSeries.Type = ChartTypes.Area;
                    break;
                case ExcelChartType.Area_Stacked:
                    UIChartSeries.Type = ChartTypes.StackingArea;
                    break;
                case ExcelChartType.Scatter_Line:
                case ExcelChartType.Scatter_Markers:
                case ExcelChartType.Scatter_Line_Markers:
                case ExcelChartType.Scatter_SmoothedLine:
                case ExcelChartType.Scatter_SmoothedLine_Markers:
                    UIChartSeries.Type = ChartTypes.Scatter;
                    break;

                case ExcelChartType.Stock_HighLowClose:
                    UIChartSeries.Type = ChartTypes.HiLo;//4
                    break;
                case ExcelChartType.Stock_OpenHighLowClose:
                    UIChartSeries.Type = ChartTypes.HiLoOpenClose;//4
                    break;
                case ExcelChartType.Stock_VolumeHighLowClose:
                    UIChartSeries.Type = ChartTypes.Candle;//4
                    break;
                case ExcelChartType.Doughnut:
                    UIChartSeries.Type = ChartTypes.Doughnut;
                    break;
                case ExcelChartType.Doughnut_Exploded:
                    UIChartSeries.Type = ChartTypes.Doughnut;
                    ChartPieType.SetExplodedAll(UIChartSeries, true);
                    break;
                case ExcelChartType.Bubble:
                    UIChartSeries.Type = ChartTypes.Bubble;//2
                    break;
                case ExcelChartType.Radar:
                    UIChartSeries.Type = ChartTypes.Radar;
                    break;
                case ExcelChartType.Pie_3D:
                    UIChartSeries.Type = ChartTypes.Pie;
                    break;
                default:
                    return;
            }
        }
    }

    public class ChartDataPoint
    {
        public ChartDataPoint(string x, double y)
        {
            X = x;
            Y = y;
        }

        private string x;
        public string X
        {
            get 
            {
                return x;

            }
            set
            {
                x = value;
                double number;
                if(double.TryParse(value, out number))
                    XDouble = number;
            }
        }

        public double XDouble {get; set;}

        public double Y { get; set; }
    }
}
