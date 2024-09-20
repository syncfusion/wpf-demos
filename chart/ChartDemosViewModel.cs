#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.chartdemos.wpf
{
    public class ChartDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new ChartProductDemos());
            productdemos.Add(new Three_DChartProductDemos());
            productdemos.Add(new SFDateTimeRangeNavigatorDemo());
            return productdemos;
        }
    }

    public class ChartProductDemos : ProductDemo
    {
        public ChartProductDemos()
        {
            this.Product = "Charts";
            Tag = Tag.Updated;
            this.ProductCategory = "CHARTS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M9.62127 0.515047C9.35337 0.448073 9.0819 0.610953 9.01493 0.87885C8.94795 1.14675 9.11084 1.41822 9.37873 1.48519L10.1502 1.67805L2.25718 6.06304C2.01579 6.19715 1.92881 6.50155 2.06292 6.74294C2.19703 6.98433 2.50143 7.0713 2.74282 6.9372L10.6192 2.56144L10.359 3.342C10.2717 3.60398 10.4132 3.88714 10.6752 3.97446C10.9372 4.06178 11.2204 3.9202 11.3077 3.65823L11.9738 1.66C12.0172 1.53127 12.0083 1.38541 11.9371 1.2573C11.8762 1.1477 11.7802 1.06994 11.6709 1.03024C11.6547 1.02435 11.6382 1.01927 11.6213 1.01505M9.62127 0.515047L11.6198 1.01469L9.62127 0.515047ZM0.5 2.00012C0.776142 2.00012 1 2.22398 1 2.50012V12.5001C1 12.7763 1.22386 13.0001 1.5 13.0001H13C13.2761 13.0001 13.5 13.224 13.5 13.5001C13.5 13.7763 13.2761 14.0001 13 14.0001H1.5C0.671573 14.0001 0 13.3285 0 12.5001V2.50012C0 2.22398 0.223858 2.00012 0.5 2.00012ZM3.5 9.00012C3.77614 9.00012 4 9.22398 4 9.50012V11.5001C4 11.7763 3.77614 12.0001 3.5 12.0001C3.22386 12.0001 3 11.7763 3 11.5001V9.50012C3 9.22398 3.22386 9.00012 3.5 9.00012ZM7 7.50012C7 7.22398 6.77614 7.00012 6.5 7.00012C6.22386 7.00012 6 7.22398 6 7.50012V11.5001C6 11.7763 6.22386 12.0001 6.5 12.0001C6.77614 12.0001 7 11.7763 7 11.5001V7.50012ZM9.5 5.00012C9.77614 5.00012 10 5.22398 10 5.50012V11.5001C10 11.7763 9.77614 12.0001 9.5 12.0001C9.22386 12.0001 9 11.7763 9 11.5001V5.50012C9 5.22398 9.22386 5.00012 9.5 5.00012ZM13 5.50012C13 5.22398 12.7761 5.00012 12.5 5.00012C12.2239 5.00012 12 5.22398 12 5.50012V11.5001C12 11.7763 12.2239 12.0001 12.5 12.0001C12.7761 12.0001 13 11.7763 13 11.5001V5.50012Z"),
                Width = 14,
                Height = 14,
            };
            this.IsHighlighted = true;
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Charts.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The Chart provides a perfect way to visualize data with a high level of user interactivity. It also provides a variety of charting features that can be used to visualize large quantities of data.";
            this.Demos = new List<DemoInfo>();
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Charts.png", UriKind.RelativeOrAbsolute));

            #region Basic charts

            #region Column

            DemoInfo columnDemo = new DemoInfo()
            {
                SampleName = "Column",
                GroupName = "Basic Charts",
                WhatsNewDescription= "This sample showcases a column chart that uses vertical bars to display different values or data points.",
            };

            DemoInfo columnChartSample = new DemoInfo() { SampleName = "Default column", GroupName = "Basic Charts", Description = "This column chart showcases the trends in population growth percentages of different countries.", DemoViewType = typeof(DefaultColumn) };
            List<Documentation> columnChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Column Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ColumnSeries.html#") },
                new Documentation(){ Content = "Column Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/columnandbar#column-chart") },
             };
            columnChartSample.Documentations = columnChartHelpDocuments;

            DemoInfo columnRoundedCornerSample = new DemoInfo() { SampleName = "Column with rounded corners", GroupName = "Basic Charts", Description = "This sample demonstrates the land area of various cities using rounded columns.", DemoViewType = typeof(ColumnRoundedEdges) };

            DemoInfo columnWidthSample = new DemoInfo() { SampleName = "Column spacing", GroupName = "Basic Charts", Description = "This sample illustrates the number of medals that were won by various countries in the 2022 Beijing Olympics, using a customized segment width for visualization.", DemoViewType = typeof(ColumnWidthCustomization) };

            DemoInfo customizedColumnSample = new DemoInfo() { SampleName = "Customized column", GroupName = "Basic Charts", Description = "This sample visualizes the comparison of literacy rates across different states by using customized columns.", DemoViewType = typeof(CustomizedColumn) };

            List<DemoInfo> subColumnDemos = new List<DemoInfo>();
            subColumnDemos.Add(columnChartSample);
            subColumnDemos.Add(columnRoundedCornerSample);
            subColumnDemos.Add(columnWidthSample);
            subColumnDemos.Add(customizedColumnSample);

            columnDemo.SubCategoryDemos = subColumnDemos;
            this.Demos.Add(columnDemo);

            #endregion

            #region Bar

            DemoInfo barDemo = new DemoInfo()
            {
                SampleName = "Bar",
                GroupName = "Basic Charts",
                WhatsNewDescription = "This sample demonstrates a bar chart utilizing horizontal columns to showcase various data points.",
            };

            DemoInfo barChartSample = new DemoInfo() { SampleName = "Default bar", GroupName = "Basic Charts", Description = "This sample showcases the widely-used Android applications that were obtainable in the Google Play Store in 2019.", DemoViewType = typeof(DefaultBar) };
            List<Documentation> barChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Bar Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.BarSeries.html#") },
                new Documentation(){ Content = "Bar Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/columnandbar#bar-chart") },
             };
            barChartSample.Documentations = barChartHelpDocuments;

            DemoInfo barRoundedCornerSample = new DemoInfo() { SampleName = "Bar with rounded corners", GroupName = "Basic Charts", Description = "This sample illustrates the comparison of miles traveled using different modes of transportation using rounded bars.", DemoViewType = typeof(BarRoundedEdge) };

            DemoInfo barWidthSample = new DemoInfo() { SampleName = "Bar spacing", GroupName = "Basic Charts", Description = "This sample illustrates the percentage growth of remote work between 2020 and 2021, with customized segment spacing.", DemoViewType = typeof(BarWidthCustomization) };

            DemoInfo customizedBarSample = new DemoInfo() { SampleName = "Customized bar", GroupName = "Basic Charts", Description = "This sample demonstrates the comparison of speed by car models using a customized bar.", DemoViewType = typeof(CustomizedBar) };

            List<DemoInfo> subBarDemos = new List<DemoInfo>();
            subBarDemos.Add(barChartSample);
            subBarDemos.Add(barRoundedCornerSample);
            subBarDemos.Add(barWidthSample);
            subBarDemos.Add(customizedBarSample);

            barDemo.SubCategoryDemos = subBarDemos;
            this.Demos.Add(barDemo);

            #endregion

            #region Line

            DemoInfo lineDemo = new DemoInfo()
            {
                SampleName = "Line",
                GroupName = "Basic Charts",
                WhatsNewDescription = "This sample showcases line chart which  represents the data trends at equal intervals by connecting points on a plot with straight lines.",
            };

            DemoInfo lineChartSample = new DemoInfo() { SampleName = "Default line", GroupName = "Basic Charts", Description = "This sample illustrates the trend in consumer price inflation between Norway and Romania from 2005 to 2011.", DemoViewType = typeof(DefaultLine) };
            List<Documentation> lineChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Line Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.LineSeries.html#") },
                new Documentation(){ Content = "Line Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/lineandstepline#line-chart") },
             };
            lineChartSample.Documentations = lineChartHelpDocuments;

            DemoInfo linewithDashesSample = new DemoInfo() { SampleName = "Line with dashes", GroupName = "Basic Charts", Description = "This sample utilizes a dotted line to illustrate the ratio of capital investment to exports during a specific time period.", DemoViewType = typeof(DashedLineChart) };

            List<DemoInfo> subLineDemos = new List<DemoInfo>();
            subLineDemos.Add(lineChartSample);
            subLineDemos.Add(linewithDashesSample);

            lineDemo.SubCategoryDemos = subLineDemos;
            this.Demos.Add(lineDemo);

            #endregion

            #region Area

            DemoInfo areaDemo = new DemoInfo() { SampleName = "Area", GroupName = "Basic Charts", Description = "This area chart illustrates the comparison of average sales for various products over different years.", DemoViewType = typeof(AreaChartDemo) };
            List<Documentation> areaChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){   Content = "Area Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.AreaSeries.html#") },
                new Documentation(){ Content = "Area Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/area#area-chart") },
             };
            areaDemo.Documentations = areaChartHelpDocuments;
            this.Demos.Add(areaDemo);

            #endregion

            #region Bubble

            DemoInfo bubbleDemo = new DemoInfo()
            {
                SampleName = "Bubble",
                GroupName = "Basic Charts",
                WhatsNewDescription = "This sample showcases a bubble chart, which is an extension of the scatter chart, where each data point is represented by a circle.",
            };

            DemoInfo bubbleChartSample = new DemoInfo() { SampleName = "Default bubble", GroupName = "Basic Charts", Description = "This bubble chart demonstrates the relationship between the literacy rate and GDP per capita across different countries in 2018.", DemoViewType = typeof(DefaultBubble) };
            List<Documentation> bubbleChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){  Content = "Bubble Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.BubbleSeries.html#") },
                new Documentation(){ Content = "Bubble Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/bubbleandscatter#bubble-chart") },
             };
            bubbleChartSample.Documentations = bubbleChartHelpDocuments;

            DemoInfo gradientBubbleSample = new DemoInfo() { SampleName = "Bubble filled with gradient", GroupName = "Basic Charts", Description = "This gradient-colored bubble chart illustrates the top-performing cross-genre movies and their box office performance.", DemoViewType = typeof(GradientBubble) };

            List<DemoInfo> subBubbleDemos = new List<DemoInfo>();
            subBubbleDemos.Add(bubbleChartSample);
            subBubbleDemos.Add(gradientBubbleSample);

            bubbleDemo.SubCategoryDemos = subBubbleDemos;
            this.Demos.Add(bubbleDemo);

            #endregion

            #region Scatter

            DemoInfo scatterDemo = new DemoInfo()
            {
                SampleName = "Scatter",
                GroupName = "Basic Charts",
            };

            DemoInfo scatterChartSample = new DemoInfo() { SampleName = "Default scatter", GroupName = "Basic Charts", Description = "This scatter chart illustrates the correlation between height and weight for both genders, with each data point represented by a circle of equal size.", DemoViewType = typeof(DefaultScatter) };
            List<Documentation> scatterChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Scatter Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ScatterSeries.html#") },
                new Documentation(){ Content = "Scatter Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/bubbleandscatter#scatter-chart") },
             };
            scatterChartSample.Documentations = scatterChartHelpDocuments;

            DemoInfo customizedScatterSample = new DemoInfo() { SampleName = "Customized scatter", GroupName = "Basic Charts", Description = "This sample illustrates the analysis of the stock market using custom templates that can be easily adjusted to fit any desired shape through the CustomTemplate property.", DemoViewType = typeof(CustomizedScatter) };

            List<DemoInfo> subScatterDemos = new List<DemoInfo>();
            subScatterDemos.Add(scatterChartSample);
            subScatterDemos.Add(customizedScatterSample);

            scatterDemo.SubCategoryDemos = subScatterDemos;
            this.Demos.Add(scatterDemo);

            #endregion

            #region Spline

            DemoInfo splineDemo = new DemoInfo()
            {
                SampleName = "Spline",
                GroupName = "Basic Charts",
                WhatsNewDescription = "This sample showcases a spline chart that connects two data points using curves instead of straight lines.",
            };

            DemoInfo splineChartSample = new DemoInfo() { SampleName = "Default spline", GroupName = "Basic Charts", Description = "This sample displays the average high and low temperatures of London using curves.", DemoViewType = typeof(DefaultSpline) };
            List<Documentation> splineChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){  Content = "Spline Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.SplineSeries.html#")  },
                new Documentation(){  Content = "Spline Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/spline#spline-chart") },
             };
            splineChartSample.Documentations = splineChartHelpDocuments;

            DemoInfo dottedSplineSample = new DemoInfo() { SampleName = "Spline with dashes", GroupName = "Basic Charts", Description = "This sample demonstrates the percentage of GDP invested using a dotted curve.", DemoViewType = typeof(DashedSplineChart) };
            DemoInfo customizedSplineSample = new DemoInfo() { SampleName = "Customized spline", GroupName = "Basic Charts", Description = "This sample showcases climate variation by utilizing customized spline series templates, which can be easily customized to fit any desired shape using the CustomTemplate property.", DemoViewType = typeof(CustomizedSpline) };

            List<DemoInfo> subSplineDemos = new List<DemoInfo>();
            subSplineDemos.Add(splineChartSample);
            subSplineDemos.Add(dottedSplineSample);
            subSplineDemos.Add(customizedSplineSample);

            splineDemo.SubCategoryDemos = subSplineDemos;
            this.Demos.Add(splineDemo);

            #endregion

            #region Spline Area

            DemoInfo splineAreaDemo = new DemoInfo() { SampleName = "Spline Area", GroupName = "Basic Charts", Description = "This sample demonstrates the percentage of inflation rates across various years by utilizing a smooth spline curve.", DemoViewType = typeof(SplineAreaChartDemo) };
            List<Documentation> splineAreaChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Spline Area Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.SplineAreaSeries.html#")  },
                new Documentation(){ Content = "Spline Area Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/spline#spline-area-chart") },
            };
            splineAreaDemo.Documentations = splineAreaChartHelpDocuments;
            this.Demos.Add(splineAreaDemo);

            #endregion

            #region Spline Range Area

            DemoInfo splineRangeAreaDemo = new DemoInfo() { SampleName = "Spline Range Area", GroupName = "Basic Charts", Description = "This sample demonstrates the general electric stock price in August 2022 using a spline range area chart.", DemoViewType = typeof(SplineRangeAreaChartDemo) };
            List<Documentation> splineRangeAreaHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Spline Range Area Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.SplineRangeAreaSeries.html#")  },
                new Documentation(){ Content = "Spline Range Area Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/range#spline-range-area-chart") },
            };
            splineRangeAreaDemo.Documentations = splineRangeAreaHelpDocuments;
            this.Demos.Add(splineRangeAreaDemo);

            #endregion

            #region Step Line

            DemoInfo stepLineDemo = new DemoInfo()
            {
                SampleName = "Step Line",
                GroupName = "Basic Charts",
                WhatsNewDescription = "This sample showcases a step line chart that connects data points using horizontal and vertical lines, resulting in a step-like progression.",
            };

            DemoInfo stepLineChartSample = new DemoInfo() { SampleName = "Default step line", GroupName = "Basic Charts", Description = "This step line chart illustrates the percentage of electricity production from oil, gas, and coal sources in Canada and France from 2000 to 2010.", DemoViewType = typeof(StepLineChartDemo) };
            List<Documentation> stepLineChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){  Content = "Step Line Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.StepLineSeries.html")  },
                new Documentation(){  Content = "Step Line Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/lineandstepline#step-line-chart") },
             };
            stepLineChartSample.Documentations = stepLineChartHelpDocuments;

            DemoInfo stepLinewithDashesSample = new DemoInfo() { SampleName = "Step line with dashes", GroupName = "Basic Charts", Description = "This dotted step line chart illustrates the CO2 emissions between India, Germany, and Kazakhstan from 2006 to 2011.", DemoViewType = typeof(DottedStepLine) };

            DemoInfo verticalStepLineSample = new DemoInfo() { SampleName = "Vertical step line", GroupName = "Basic Charts", Description = "This sample visualizes the percentage of the unemployment rate from 2000 to 2010 using a vertical step line chart.", DemoViewType = typeof(VerticalStepLine) };

            List<DemoInfo> subStepLineDemos = new List<DemoInfo>();
            subStepLineDemos.Add(stepLineChartSample);
            subStepLineDemos.Add(stepLinewithDashesSample);
            subStepLineDemos.Add(verticalStepLineSample);

            stepLineDemo.SubCategoryDemos = subStepLineDemos;
            this.Demos.Add(stepLineDemo);

            #endregion

            #region Step Area

            DemoInfo stepAreaDemo = new DemoInfo() { SampleName = "Step Area", GroupName = "Basic Charts", Description = "This step area chart illustrates the percentage of fuel exports between Canada and Mexico over the period from 2005 to 2015.", DemoViewType = typeof(StepAreaChartDemo) };
            List<Documentation> stepAreaChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Step Area Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.StepAreaSeries.html#") },
                new Documentation(){ Content = "Step Area Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/area#step-area-chart") },
            };
            stepAreaDemo.Documentations = stepAreaChartHelpDocuments;
            this.Demos.Add(stepAreaDemo);

            #endregion

            #region Range Column

            DemoInfo rangeColumnDemo = new DemoInfo() { SampleName = "Range Column", GroupName = "Basic Charts", Description = "This sample demonstrates the variation in temperature in Rome in degrees Celsius.", DemoViewType = typeof(RangeColumnChartDemo) };
            List<Documentation> rangeColumnChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Range Column Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.RangeColumnSeries.html#")  },
                new Documentation(){ Content = "Range Column Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/range#range-column-chart") },
            };
            rangeColumnDemo.Documentations = rangeColumnChartHelpDocuments;
            this.Demos.Add(rangeColumnDemo);

            #endregion

            #region Range Bar

            DemoInfo rangeBarDemo = new DemoInfo() { SampleName = "Range Bar", GroupName = "Basic Charts", WhatsNewDescription= "This sample shows a radial bar chart, a variation of the doughnut chart. It utilizes separate circles for each segment to compare values across different categories.",
                Description = "This transposed range column chart demonstrates the temperature variation in Paris in degrees Celsius.", DemoViewType = typeof(RangeBar)};
            List<Documentation> rangeBarChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Range Column Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.RangeColumnSeries.html#")  },
                new Documentation(){ Content = "Range Column Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/range#range-column-chart") },
            };
            rangeBarDemo.Documentations = rangeBarChartHelpDocuments;
            this.Demos.Add(rangeBarDemo);

            #endregion

            #region Range Area

            DemoInfo rangeAreaDemo = new DemoInfo() { SampleName = "Range Area", GroupName = "Basic Charts", Description = "This range area chart displays the temperature fluctuations in Arizona during the month of May in 2022.", DemoViewType = typeof(RangeAreaChartDemo) };
            List<Documentation> rangeAreaChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Range Area Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.RangeAreaSeries.html#") },
                new Documentation(){ Content = "Range Area Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/range#range-area-chart") },
            };
            rangeAreaDemo.Documentations = rangeAreaChartHelpDocuments;
            this.Demos.Add(rangeAreaDemo);

            #endregion

            #region Waterfall

            DemoInfo waterfallDemo = new DemoInfo()
            {
                SampleName = "Waterfall",
                GroupName = "Basic Charts",
                WhatsNewDescription= "This sample displays the waterfall chart, which shows how positive and negative changes in a dataset accumulate.",
            };

            DemoInfo waterfallChartSample = new DemoInfo() { SampleName = "Default waterfall", GroupName = "Basic Charts", Description = "This sample demonstrates the contributions of different factors and their influence on the overall net cash flow in 2021 using a waterfall chart.", DemoViewType = typeof(WaterfallChartDemo) };
            List<Documentation> waterfallChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){  Content = "Waterfall Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.WaterfallSeries.html")  },
                new Documentation(){  Content = "Waterfall Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/other#waterfall-chart") },
             };
            waterfallChartSample.Documentations = waterfallChartHelpDocuments;

            DemoInfo verticalWaterfallSample = new DemoInfo() { SampleName = "Vertical waterfall", GroupName = "Basic Charts", Description = "This sample showcases the yearly net profit based on various categories between 2015 and 2016.", DemoViewType = typeof(VerticalWaterfall) };

            List<DemoInfo> subWaterfallDemos = new List<DemoInfo>();
            subWaterfallDemos.Add(waterfallChartSample);
            subWaterfallDemos.Add(verticalWaterfallSample);

            waterfallDemo.SubCategoryDemos = subWaterfallDemos;
            this.Demos.Add(waterfallDemo);

            #endregion

            #region Box and Whisker

            DemoInfo boxAndWhiskerDemo = new DemoInfo() { SampleName = "Box plot", GroupName = "Basic Charts", Description = "This sample illustrates the distribution and variability of the Charpy impact test using a box plot chart, which plots a combination of rectangles and lines to show the distribution of the dataset.", DemoViewType = typeof(BoxAndWhiskerChartDemo) };
            List<Documentation> boxAndWhiskerHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Box and Whisker API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.BoxAndWhiskerSeries.html") },
                new Documentation(){ Content = "Box and Whisker Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/other#box-and-whisker-chart") },
            };
            boxAndWhiskerDemo.Documentations = boxAndWhiskerHelpDocuments;
            this.Demos.Add(boxAndWhiskerDemo);

            #endregion

            #region Histogram

            DemoInfo histogramDemo = new DemoInfo() { SampleName = "Histogram", GroupName = "Basic Charts", Description = "This sample illustrates the exam results, displaying the number of marks obtained according to the number of students.", DemoViewType = typeof(HistogramChartDemo) };
            List<Documentation> histogramChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Histogram API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.HistogramSeries.html#") },
                new Documentation(){ Content = "Histogram Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/distribution#histogram-chart") },
            };
            histogramDemo.Documentations = histogramChartHelpDocuments;
            this.Demos.Add(histogramDemo);

            #endregion

            #region Error Bar

            DemoInfo errorBarDemo = new DemoInfo()
            {
                SampleName = "Error Bar",
                GroupName = "Basic Charts",
                WhatsNewDescription= "This sample provides graphical representations of the variability or uncertainty in the data.",
            };

            DemoInfo errorBarSample = new DemoInfo() { SampleName = "Default error bar", GroupName = "Basic Charts", Description = "This sample illustrates the thermal expansion of different materials, demonstrating how their shape or size alters based on temperature.", DemoViewType = typeof(ErrorBarSeriesDemo) };
            List<Documentation> errorBarChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){  Content = "Error Bar API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ErrorBarSeries.html#") },
                new Documentation(){  Content = "Error Bar Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/errorbars")  },
             };
            errorBarSample.Documentations = errorBarChartHelpDocuments;

            DemoInfo customizedErrorBar = new DemoInfo() { SampleName = "Customized error bar", GroupName = "Basic Charts", Description = "This sample illustrates the distribution of car sales by region using customized error bars.", DemoViewType = typeof(CustomizedErrorBar) };

            List<DemoInfo> subErrorBarDemos = new List<DemoInfo>();
            subErrorBarDemos.Add(errorBarSample);
            subErrorBarDemos.Add(customizedErrorBar);

            errorBarDemo.SubCategoryDemos = subErrorBarDemos;
            this.Demos.Add(errorBarDemo);

            #endregion

            #region Empty Points

            DemoInfo emptyPointsDemo = new DemoInfo() { SampleName = "Empty Values", GroupName = "Basic Charts", Description = "This sample displays the number of new products introduced in different years, including years with both empty and non-empty values.", DemoViewType = typeof(EmptyPointSupportDemo) };
            List<Documentation> emptyPointsHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Empty Points API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartSeriesBase.html#Syncfusion_UI_Xaml_Charts_ChartSeriesBase_ShowEmptyPoints") },
                new Documentation(){ Content = "Empty Points Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/emptypoints") },
             };
            emptyPointsDemo.Documentations = emptyPointsHelpDocuments;
            this.Demos.Add(emptyPointsDemo);

            #endregion

            #endregion

            #region Circular 

            #region Pie

            DemoInfo pieDemo = new DemoInfo()
            {
                SampleName = "Pie",
                GroupName = "Circular Charts",
                WhatsNewDescription= "This sample represents parts of a whole by dividing a circle into sectors, where each sector's angle corresponds to the proportion of the data it represents.",
            };

            DemoInfo pieChartSample = new DemoInfo() { SampleName = "Default pie", GroupName = "Circular Charts", Description = "This pie chart illustrates the percentage contribution of each individual to sales.", DemoViewType = typeof(PieChartDemo) };
            List<Documentation> pieChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Pie Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.PieSeries.html#")},
                new Documentation(){ Content = "Pie Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/pieanddoughnut#pie-chart") },
             };
            pieChartSample.Documentations = pieChartHelpDocuments;

            DemoInfo semiPieSample = new DemoInfo() { SampleName = "Semi-pie", GroupName = "Circular Charts", Description = "This sample displays the distribution percentage of favorite book genres using various shapes, such as semi-pie or quarter-pie.", DemoViewType = typeof(SemiPie) };
            List<Documentation> semiPieChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Pie Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.PieSeries.html#")},
                new Documentation(){ Content = " Semi Pie Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/pieanddoughnut#semi-pie-and-doughnut") },
             };
            semiPieSample.Documentations = semiPieChartHelpDocuments;

            DemoInfo pieGroupingSample = new DemoInfo() { SampleName = "Grouping", GroupName = "Circular Charts", Description = "This sample showcases the world economy in 2021 with grouping support, which is used to group all small segments into a single segment.", DemoViewType = typeof(PieGrouping) };
            List<Documentation> pieGroupingHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Circular Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.CircularSeriesBase.html")},
                new Documentation(){ Content = "Grouping Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/pieanddoughnut#group-small-data-points-into-others") },
             };
            pieGroupingSample.Documentations = pieGroupingHelpDocuments;

            List<DemoInfo> subPieDemos = new List<DemoInfo>();
            subPieDemos.Add(pieChartSample);
            subPieDemos.Add(semiPieSample);
            subPieDemos.Add(pieGroupingSample);

            pieDemo.SubCategoryDemos = subPieDemos;
            this.Demos.Add(pieDemo);

            #endregion

            #region Doughnut

            DemoInfo doughnutDemo = new DemoInfo()
            {
                SampleName = "Doughnut",
                GroupName = "Circular Charts",
                WhatsNewDescription= "This sample visualizes a pie chart with a hole in the center, presenting the proportions of data segments.",
            };

            DemoInfo doughnutChartSample = new DemoInfo() { SampleName = "Default doughnut", GroupName = "Circular Charts", Description = "This doughnut chart displays the individual's various monthly expenditures.", DemoViewType = typeof(DoughnutChartDemo) };
            List<Documentation> doughnutChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Doughnut Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.DoughnutSeries.html#") },
                new Documentation(){ Content = "Doughnut Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/pieanddoughnut#doughnut-chart") },
             };
            doughnutChartSample.Documentations = doughnutChartHelpDocuments;

            DemoInfo semiDoughnutSample = new DemoInfo() { SampleName = "Semi-doughnut", GroupName = "Circular Charts", Description = "This sample showcases the expansion of products 2015, represented in various forms such as semi-doughnut or quarter-doughnut.", DemoViewType = typeof(SemiDoughnut) };
            List<Documentation> emiDoughnutChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Doughnut Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.DoughnutSeries.html#")},
                new Documentation(){ Content = " Semi Doughnut Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/pieanddoughnut#semi-pie-and-doughnut") },
             };
            semiDoughnutSample.Documentations = emiDoughnutChartHelpDocuments;

            DemoInfo doughnutGroupingSample = new DemoInfo() { SampleName = "Grouping", GroupName = "Circular Charts", Description = "This sample showcases the global bond market with grouping support, which is used to group all small segments into a single segment.", DemoViewType = typeof(DoughnutGrouping) };
            List<Documentation> doughnutGroupingHelpDocuments = new List<Documentation>()
            {
                 new Documentation(){ Content = "Circular Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.CircularSeriesBase.html")},
                new Documentation(){ Content = "Grouping Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/pieanddoughnut#group-small-data-points-into-others") },
             };
            doughnutGroupingSample.Documentations = doughnutGroupingHelpDocuments;


            List<DemoInfo> subDoughnutDemos = new List<DemoInfo>();
            subDoughnutDemos.Add(doughnutChartSample);
            subDoughnutDemos.Add(semiDoughnutSample);
            subDoughnutDemos.Add(doughnutGroupingSample);

            doughnutDemo.SubCategoryDemos = subDoughnutDemos;
            this.Demos.Add(doughnutDemo);

            #endregion

            #region Radial Bar

            DemoInfo radialBarDemo = new DemoInfo()
            {
                SampleName = "Radial Bar",
                GroupName = "Circular Charts",
                WhatsNewDescription= "This sample shows a radial bar chart, a variation of the doughnut chart. It utilizes separate circles for each segment to compare values across different categories.",
            };

            DemoInfo radialBarChartSample = new DemoInfo() { SampleName = "Default radial bar", GroupName = "Circular Charts", Description = "This sample displays the distribution of costs for various expenses related to the project.", DemoViewType = typeof(StackedDoughnutDemo) };
            List<Documentation> radialBarHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Stacked Doughnut API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.DoughnutSeries.html#Syncfusion_UI_Xaml_Charts_DoughnutSeries_IsStackedDoughnut") },
                new Documentation(){ Content = "Stacked Doughnut Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/pieanddoughnut#stacked-doughnut") },
             };
            radialBarChartSample.Documentations = radialBarHelpDocuments;

            DemoInfo customizedRadialBarSample = new DemoInfo() { SampleName = "Customized radial bar", GroupName = "Circular Charts", Description = "This sample demonstrates the rate at which loans are successfully repaid or settled, along with a customized legend that provides additional information about the categories.", DemoViewType = typeof(CustomizedStackedDoughnut) };

            List<DemoInfo> subRadialBarDemos = new List<DemoInfo>();
            subRadialBarDemos.Add(radialBarChartSample);
            subRadialBarDemos.Add(customizedRadialBarSample);

            radialBarDemo.SubCategoryDemos = subRadialBarDemos;
            this.Demos.Add(radialBarDemo);

            #endregion

            #endregion

            #region Pyramid chart

            DemoInfo defaultPyramidDemo = new DemoInfo() { SampleName = "Default Pyramid", GroupName = "Pyramid Charts", Description = "This sample demonstrates how the percentage of listeners was distributed among various categories in 2007.", DemoViewType = typeof(PyramidChartDemo) };
            List<Documentation> pyramidChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Pyramid Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.PyramidSeries.html")},
                new Documentation(){ Content = "Pyramid Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/funnelandpyramid#pyramid-chart") },
             };
            defaultPyramidDemo.Documentations = pyramidChartHelpDocuments;
            this.Demos.Add(defaultPyramidDemo);

            DemoInfo pyramidLegendDemo = new DemoInfo() { SampleName = "Customized Pyramid", GroupName = "Pyramid Charts", WhatsNewDescription= "This sample showcases a pyramid chart with different mode options and customized tooltips and data labels.",
                Description = "This sample showcases a pyramid chart with different mode options and customized tooltips that offer additional information about the distribution of operation costs across categories in the year 2020.", DemoViewType = typeof(PyramidMode),};
            this.Demos.Add(pyramidLegendDemo);

            #endregion

            #region Funnel chart

            DemoInfo funnelDemo = new DemoInfo() { SampleName = "Default Funnel", GroupName = "Funnel Charts", Description = "This sample illustrates the percentage of website conversion rates and its efficiency in converting visitors into customers.", DemoViewType = typeof(FunnelChartDemo) };
            List<Documentation> funnelChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Funnel Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.FunnelSeries.html")  },
                new Documentation(){ Content = "Funnel Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/funnelandpyramid#funnel-chart") },
             };
            funnelDemo.Documentations = funnelChartHelpDocuments;
            this.Demos.Add(funnelDemo);

            DemoInfo funnelLegendDemo = new DemoInfo() { SampleName = "Customized Funnel", GroupName = "Funnel Charts", WhatsNewDescription= "This sample showcases a funnel chart with different mode options and customized tooltips and data labels.",
                Description = "This funnel chart showcases the various stages of the sales funnel, with mode options and customized tooltips that provide additional information about each stage.", DemoViewType = typeof(FunnelMode),};
            this.Demos.Add(funnelLegendDemo);

            #endregion

            #region Polar and Radar

            #region Polar

            DemoInfo polarSample = new DemoInfo() { SampleName = "Polar", GroupName = "Polar and Radar Charts", Description = "This sample shows a sales comparison of each product using a polar chart, which visualizes the data in terms of values and angles.", DemoViewType = typeof(Polar) };
            List<Documentation> polarAreaDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Polar Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.PolarSeries.html#")},
                new Documentation(){ Content = "Polar Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/radarandpolar#polar-chart") },
             };
            polarSample.Documentations = polarAreaDocumentation;
            this.Demos.Add(polarSample);

            #endregion

            #region Radar

            DemoInfo radarSample = new DemoInfo() { SampleName = "Radar", GroupName = "Polar and Radar Charts", Description = "This sample demonstrates the examination of plant details based on the direction using a radar chart, which visualizes the data in terms of values and angles.", DemoViewType = typeof(RadarChartDemo) };
            List<Documentation> radarDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Radar Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.RadarSeries.html#")},
                new Documentation(){ Content = "Radar Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/radarandpolar#radar-chart") },
             };

            radarSample.Documentations = radarDocumentation;
            this.Demos.Add(radarSample);

            #endregion

            #endregion

            #region Financial chart

            DemoInfo hiLoDemo = new DemoInfo() { SampleName = "HiLo", GroupName = "Financial Charts", Description = "This sample illustrates the range of sales analysis for each month in 2016 using a Hilo chart.", DemoViewType = typeof(HiLoChartDemo) };
            List<Documentation> hiLoChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "HiLo API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.HiLoSeries.html#")  },
                new Documentation(){ Content = "HiLo Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/range#hilo-chart")},
             };
            hiLoDemo.Documentations = hiLoChartHelpDocuments;
            this.Demos.Add(hiLoDemo);

            DemoInfo OHLCDemo = new DemoInfo() { SampleName = "OHLC", GroupName = "Financial Charts", Description = "This sample illustrates the stock information of ABM Industries in 2000 using an OHLC chart.", DemoViewType = typeof(HiLoOpenCloseChartDemo) };
            List<Documentation> OHLCChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "OHLC API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.HiLoOpenCloseSeries.html#")  },
                new Documentation(){ Content = "OHLC Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/financial#ohlc-chart") },
             };
            OHLCDemo.Documentations = OHLCChartHelpDocuments;
            this.Demos.Add(OHLCDemo);

            DemoInfo candleDemo = new DemoInfo() { SampleName = "Candle", GroupName = "Financial Charts", Description = "This candle chart demonstrates the stock information in 2020 using the high, low, open, and close values.", DemoViewType = typeof(CandleChartDemo) };
            List<Documentation> candleChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Candle Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.CandleSeries.html#") },
                new Documentation(){ Content = "Candle Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/financial#candle-chart") },
             };
            candleDemo.Documentations = candleChartHelpDocuments;
            this.Demos.Add(candleDemo);

            #endregion

            #region Stacked Chart

            #region Stacked Column Chart
            
            DemoInfo stackedColumn = new DemoInfo()
            {
                SampleName = "Stacked Column",
                GroupName = "Stacked Charts",
                WhatsNewDescription= "This sample visualizes stacked vertical bars to show both individual and cumulative values for different categories.",
            };
            
            DemoInfo stackedColumnDemo = new DemoInfo()
            {
                SampleName = "Default stacked column", 
                GroupName = "Stacked Charts", 
                Description = "This stacked column chart represents the statistics of the Olympic Games medals across different countries.", 
                DemoViewType = typeof(StackingColumnChartDemo) 
            };
            List<Documentation> stackedColumnHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Stacked Column Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.StackingColumnSeries.html?tabs=tabid-1") },
                new Documentation(){ Content = "Stacked Column Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/stacking#stacked-column-chart") },
             };
            stackedColumnDemo.Documentations = stackedColumnHelpDocuments;
            

            DemoInfo stackedColumnGroup = new DemoInfo()
            {
                SampleName = "Cluster stacked column",
                GroupName = "Stacked Charts",
                Description = "This cluster stacked column represents the company's growth with a grouping of quarters, allowing easy visualization of the relationship of parts to the whole.",
                DemoViewType = typeof(StackedGroupChartDemo)
            };
            List<Documentation> groupingHelpDocuments = new List<Documentation>()
            {
                 new Documentation(){ Content = "Grouping API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.StackingSeriesBase.html#Syncfusion_UI_Xaml_Charts_StackingSeriesBase_GroupingLabel") },
                new Documentation(){ Content = "Grouping Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/groupingstacked") },
             };
            stackedColumnGroup.Documentations = groupingHelpDocuments;

            List<DemoInfo> subStackColumnDemos = new List<DemoInfo>();
            subStackColumnDemos.Add(stackedColumnDemo);
            subStackColumnDemos.Add(stackedColumnGroup);

            stackedColumn.SubCategoryDemos = subStackColumnDemos;
            this.Demos.Add(stackedColumn);

            #endregion

            #region Stacked Bar Chart

            DemoInfo StackedBarDemo = new DemoInfo() 
            { 
                SampleName = "Stacked Bar", 
                GroupName = "Stacked Charts", 
                Description = "This sample shows the sales analysis of the Apple's iOS devices, helping visualize the relationship of parts to the whole.", 
                DemoViewType = typeof(StackingBarChartDemo) 
            };
            List<Documentation> StackedBarHelpDocuments = new List<Documentation>();
            StackedBarHelpDocuments.Add(new Documentation() { Content = "Stacked Bar Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.StackingBarSeries.html?tabs=tabid-1") });
            StackedBarHelpDocuments.Add(new Documentation() { Content = "Stacked Bar Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/stacking#stacked-bar-chart") });
            StackedBarDemo.Documentations = StackedBarHelpDocuments;
            this.Demos.Add(StackedBarDemo);

            #endregion

            #region Stacked Area Chart
            
            DemoInfo stackedAreaDemo = new DemoInfo()
            { 
                SampleName = "Stacked Area", 
                GroupName = "Stacked Charts",
                Description = "This sample demonstrates Nestle's worldwide confectionery sales between 2014 and 2021.", 
                DemoViewType = typeof(StackingAreaChartDemo) 
            };
            List<Documentation> stackedAreaHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Stacked Area Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.StackingAreaSeries.html#") },
                new Documentation(){ Content = "Stacked Area Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/stacking#stacked-area-chart") },
             };
            stackedAreaDemo.Documentations = stackedAreaHelpDocuments;
            this.Demos.Add(stackedAreaDemo);
            
            #endregion

            #region Stacked Line Chart
            
            DemoInfo stackedLineDemo = new DemoInfo() 
            { 
                SampleName = "Stacked Line", 
                GroupName = "Stacked Charts", 
                Description = "This sample illustrates the percentage of GDP growth from 2010 to 2015 using a stacked line chart.", 
                DemoViewType = typeof(StackingLineChartDemo) 
            };
            List<Documentation> stackedLineHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Stacked Line Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.StackingLineSeries.html") },
                new Documentation(){ Content = "Stacked Line Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/stacking#stacked-line-chart") },
             };
            stackedLineDemo.Documentations = stackedLineHelpDocuments;
            this.Demos.Add(stackedLineDemo);

            #endregion

            #endregion

            #region 100% Stacked Chart

            #region Stacked Column 100 Chart

            DemoInfo stackedColumn100Demo = new DemoInfo()
            {
                SampleName = "100 Stacked Column",
                GroupName = "100 Stacked Charts",
                WhatsNewDescription= "This sample demonstrates the relative proportions of multiple data series as stacked columns, where each column represents a percentage of the total.",
            };
            DemoInfo stackedColumn100 = new DemoInfo() 
            { 
                SampleName = "Default 100 stacked column",
                GroupName = "100 Stacked Charts", 
                Description = "This sample demonstrates the electricity consumption by various sections for the year 2022. Each section's contribution to the total consumption is represented as a percentage.", 
                DemoViewType = typeof(StackingColumn100ChartDemo) 
            };
            List<Documentation> stackedColumn100HelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Stacked Column 100 Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.StackingColumn100Series.html#") },
                new Documentation(){ Content = "Stacked Column 100 Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/stacking#stacked-column100-chart")  },
             };
            stackedColumn100.Documentations = stackedColumn100HelpDocuments;

            DemoInfo stacked100ColumnGroup = new DemoInfo()
            {
                SampleName = "Cluster 100 stacked column",
                GroupName = "100 Stacked Charts",
                Description = "This sample displays the electricity consumption from various sources using 100 stacked columns, where the total of each stacked column always equals to 100%.",
                DemoViewType = typeof(StackingGroup100ChartDemo)
            };

            List<DemoInfo> subStack100ColumnDemos = new List<DemoInfo>();
            subStack100ColumnDemos.Add(stackedColumn100);
            subStack100ColumnDemos.Add(stacked100ColumnGroup);

            stackedColumn100Demo.SubCategoryDemos = subStack100ColumnDemos;
            this.Demos.Add(stackedColumn100Demo);

            #endregion

            #region Stacked Bar 100 Chart

            DemoInfo stackedBar100Demo = new DemoInfo() 
            { 
                SampleName = "100 Stacked Bar", 
                GroupName = "100 Stacked Charts", 
                Description = "This 100% Stacked Bar chart shows the electric vehicle market share globally. Each section's contribution to the total market share is represented as a percentage.", 
                DemoViewType = typeof(StackingBar100ChartDemo) 
            };
            List<Documentation> stackedBar100HelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Stacked Bar 100 Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.StackingBar100Series.html#") },
                new Documentation(){ Content = "Stacked Bar 100 Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/stacking#stacked-bar100-chart") },
             };

            stackedBar100Demo.Documentations = stackedBar100HelpDocuments;
            this.Demos.Add(stackedBar100Demo);
            
            #endregion

            #region Stacked Area 100 Chart
            
            DemoInfo stackedArea100Demo = new DemoInfo()
            { 
                SampleName = "100 Stacked Area", 
                GroupName = "100 Stacked Charts", 
                Description = "This sample showcases the methane emissions from 2000 to 2010 using a 100% stacked area chart.", 
                DemoViewType = typeof(StackingArea100ChartDemo) 
            };
            List<Documentation> stackedArea100HelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Stacked Area 100 Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.StackingArea100Series.html") },
                new Documentation(){ Content = "Stacked Area 100 Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/stacking#stacked-area100-chart") },
             };
            stackedArea100Demo.Documentations = stackedArea100HelpDocuments;
            this.Demos.Add(stackedArea100Demo);
            
            #endregion

            #region Stacked Line 100 Chart
            
            DemoInfo stackedLine100Demo = new DemoInfo()
            { 
                SampleName = "100 Stacked Line", 
                GroupName = "100 Stacked Charts", 
                Description = "This 100% stacked line chart displays a smartphone market share analysis globally, where the total of each stacked line always equals to 100%.", 
                DemoViewType = typeof(StackingLine100Chart) 
            };
            List<Documentation> stackedLine100HelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Stacked Line 100 Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.StackingLine100Series.html") },
                new Documentation(){ Content = "Stacked Line 100 Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/stacking#stacked-line100-chart") },
             };
            stackedLine100Demo.Documentations = stackedLine100HelpDocuments;
            this.Demos.Add(stackedLine100Demo);
            
            #endregion

            #endregion

            #region Fast Chart

            #region Fast Column Chart
            
            DemoInfo fastColumnDemo = new DemoInfo()
            { 
                SampleName = "Column", 
                GroupName = "Fast Charts", 
                Description = "This Fast Column chart effectively displays stock details, and it handles large quantities of data.",
                DemoViewType = typeof(FastColumnChartDemo) 
            };
            List<Documentation> fastColumnHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Fast Column Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.FastColumnBitmapSeries.html#") },
                new Documentation(){ Content = "Fast Column Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/fastchart/fast-bitmapseries#fast-column-bitmap") },
             };
            fastColumnDemo.Documentations = fastColumnHelpDocuments;
            this.Demos.Add(fastColumnDemo);
            
            #endregion

            #region Fast Bar Chart
            
            DemoInfo fastBarDemo = new DemoInfo()
            { 
                SampleName = "Bar", 
                GroupName = "Fast Charts", 
                Description = "This sample demonstrates the details of the stock market using the fast bar series, which enables the rendering of vast collections of data points in a fraction of a millisecond.", 
                DemoViewType = typeof(FastBarChartDemo) 
            };
            List<Documentation> fastBarChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Fast Bar Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.FastBarBitmapSeries.html") },
                new Documentation(){  Content = "Fast Bar Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/fastchart/fast-bitmapseries#fast-bar-bitmap") },
             };
            fastBarDemo.Documentations = fastBarChartHelpDocuments;
            this.Demos.Add(fastBarDemo);
            
            #endregion

            #region Fast Line Chart
            
            DemoInfo fastLineDemo = new DemoInfo()
            { 
                SampleName = "Line", 
                GroupName = "Fast Charts",
                Description = "This sample demonstrates the use of fast line series in weather prediction, which allows for the display of large data point collections in less than a millisecond.", 
                DemoViewType = typeof(FastLineChartDemo)
            };
            List<Documentation> fastLineChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Fast Line Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.FastLineSeries.html") },
                new Documentation(){ Content = "Fast Line Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/fastchart/fast-series#fast-line") },
             };
            fastLineDemo.Documentations = fastLineChartHelpDocuments;
            this.Demos.Add(fastLineDemo);

            #endregion

            #region Fast StepLine Chart
            
            DemoInfo fastStepLineDemo = new DemoInfo() 
            {
                SampleName = "Step Line", 
                GroupName = "Fast Charts",
                Description = "This sample effectively displays the monitoring of heart rate variability using a fast step line chart.", 
                DemoViewType = typeof(FastStepLineChartDemo)
            };
            List<Documentation> fastStepLineHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Fast Step Line Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.FastStepLineBitmapSeries.html#") },
                new Documentation(){ Content = "Fast Step Line Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/fastchart/fast-bitmapseries#fast-step-line-bitmap") },
             };
            fastStepLineDemo.Documentations = fastStepLineHelpDocuments;
            this.Demos.Add(fastStepLineDemo);

            #endregion

            #region Fast Scatter Chart
            
            DemoInfo fastScatterDemo = new DemoInfo() 
            { 
                SampleName = "Scatter",
                GroupName = "Fast Charts", 
                Description = "This sample illustrates the duration and waiting time of eruptions using a fast scatter series, which handles large quantities of data.",
                DemoViewType = typeof(FastScatterChartDemo) 
            };
            List<Documentation> fastScatterHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Fast Scatter Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.FastScatterBitmapSeries.html?tabs=tabid-1") },
                new Documentation(){ Content = "Fast Scatter Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/fastchart/fast-bitmapseries#fast-scatter-bitmap") },
             };
            fastScatterDemo.Documentations = fastScatterHelpDocuments;
            this.Demos.Add(fastScatterDemo);

            #endregion

            #region Fast RangeArea Chart
            
            DemoInfo fastRangeAreaDemo = new DemoInfo()
            { 
                SampleName = "Range Area", 
                GroupName = "Fast Charts", 
                Description = "This sample showcases the temperature analysis using a fast range area series, which performs a high-performance version of the range area chart.", 
                DemoViewType = typeof(FastRangeAreaChartDemo) 
            };
            List<Documentation> fastRangeAreaHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Fast Range Area Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.FastRangeAreaBitmapSeries.html#") },
                new Documentation(){ Content = "Fast Range Area Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/fastchart/fast-bitmapseries#fast-range-area") },
             };
            fastRangeAreaDemo.Documentations = fastRangeAreaHelpDocuments;
            this.Demos.Add(fastRangeAreaDemo);

            #endregion

            #region Fast Stacked Column Chart
            
            DemoInfo fastStackedColumnDemo = new DemoInfo()
            { 
                SampleName = "Stacked Column",
                GroupName = "Fast Charts", 
                Description = "This fast stacked column chart effectively displays the Microsoft stock market trend analysis, which is capable of handling large volumes of data.",
                DemoViewType = typeof(FastStackingColumnChartDemo) 
            };
            List<Documentation> fastStackedColumnHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Fast Stacked Column Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.FastStackingColumnBitmapSeries.html#")  },
                new Documentation(){ Content = "Fast Stacked Column Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/fastchart/fast-series#fast-stacking-column")  },
             };
            fastStackedColumnDemo.Documentations = fastStackedColumnHelpDocuments;
            this.Demos.Add(fastStackedColumnDemo);

            #endregion

            #region Fast HiLo Chart
            
            DemoInfo fastHiLoDemo = new DemoInfo() 
            { 
                SampleName = "HiLo", 
                GroupName = "Fast Charts",
                Description = "This sample showcases the details of the stock exchange using a fast Hilo chart with high and low values.", 
                DemoViewType = typeof(FastHiloChartDemo) 
            };
            List<Documentation> fastHiLoHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Fast HiLo Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.FastHiLoBitmapSeries.html#") },
                new Documentation(){ Content = "Fast HiLo Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/fastchart/fast-bitmapseries#fast-hilo-bitmap")},
             };
            fastHiLoDemo.Documentations = fastHiLoHelpDocuments;
            this.Demos.Add(fastHiLoDemo);

            #endregion

            #region OHLC Chart
            
            DemoInfo fastOHLCDemo = new DemoInfo()
            { 
                SampleName = "OHLC", 
                GroupName = "Fast Charts", 
                Description = "This sample showcases stock market trends in the cosmetics industry using a fast OHCL series and effectively manages large quantities of data.", 
                DemoViewType = typeof(FastHiloOpenCloseChartDemo)
            };
            List<Documentation> fastOHLCHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Fast OHLC Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.FastHiLoOpenCloseBitmapSeries.html#") },
                new Documentation(){ Content = "Fast OHLC Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/fastchart/fast-bitmapseries#fast-ohlc-bitmap")},
             };
            fastOHLCDemo.Documentations = fastOHLCHelpDocuments;
            this.Demos.Add(fastOHLCDemo);

            #endregion

            #region Fast Candle Chart

            DemoInfo fastCandleDemo = new DemoInfo()
            { 
                SampleName = "Candle", 
                GroupName = "Fast Charts", 
                Description = "This sample demonstrates forex market analysis using fast candle series that handle huge collections of data points in just a millisecond.", 
                DemoViewType = typeof(FastCandleChartDemo)
            };
            List<Documentation> fastCandleHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Fast Candle Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.FastCandleBitmapSeries.html") },
                new Documentation(){ Content = "Fast Candle Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/fastchart/fast-bitmapseries#fast-candle-bitmap") },
             };
            fastCandleDemo.Documentations = fastCandleHelpDocuments;
            this.Demos.Add(fastCandleDemo);

            #endregion

            #endregion

            #region Axis

            #region  Axis Type

            DemoInfo axisTypesDemo = new DemoInfo()
            {
                SampleName = "Axis Type",
                GroupName = "Axis",
                WhatsNewDescription= "This sample showcases the different types of axes: category, numerical, date time, logarithm, and date time category.",
            };

            DemoInfo categorySample = new DemoInfo() 
            { 
                SampleName = "Category", 
                GroupName = "Axis", 
                Description = "This sample demonstrates the internet user in 2023 by using a category axis. It plots values based on the index or labels of the data points collection.", 
                DemoViewType = typeof(CategoryAxisDemo) 
            };
            List<Documentation> categoryAxisHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Category Axis API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.CategoryAxis.html#") },
                new Documentation(){ Content = "Category Axis Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/axis#categoryaxis") },
             };
            categorySample.Documentations = categoryAxisHelpDocuments;

            DemoInfo numericalSample = new DemoInfo() 
            { 
                SampleName = "Numerical", 
                GroupName = "Axis", 
                Description = "This sample showcases the score of Australia vs India match by using a numerical axis. The axis is divided into equal intervals or units based on the range of values in the data set.", 
                DemoViewType = typeof(NumericalAxisDemo) 
            };
            List<Documentation> numericalHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Numerical Axis API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.NumericalAxis.html#") },
                new Documentation(){ Content = "Numerical Axis Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/axis#numericalaxis") },
             };
            numericalSample.Documentations = numericalHelpDocuments;

            DemoInfo dateTimeSample = new DemoInfo() 
            { 
                SampleName = "Date time",
                GroupName = "Axis", 
                Description = "This sample demonstrates the Euro to USD monthly exchange rate with DateTime. The labels are positioned at regular intervals based on the month.", 
                DemoViewType = typeof(DateTimeAxisDemo) 
            };
            List<Documentation> dateTimeAxisHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Date Time Axis API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.DateTimeAxis.html#") },
                new Documentation(){ Content = "Date Time Axis Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/axis#datetimeaxis") },
             };
            dateTimeSample.Documentations = dateTimeAxisHelpDocuments;

            DemoInfo logarithmicAxisSample = new DemoInfo() 
            { 
                SampleName = "Logarithm", 
                GroupName = "Axis", 
                Description = "This sample illustrates the growth of the product between 1995 and 2005 by using a logarithmic axis.", 
                DemoViewType = typeof(LogAxisDemo)
            };
            List<Documentation> logAxisHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Logarithm Axis API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.LogarithmicAxis.html#") },
                new Documentation(){ Content = "Logarithm Axis Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/axis#logarithmicaxis") },
             };
            logarithmicAxisSample.Documentations = logAxisHelpDocuments;

            DemoInfo dateTimeCategoryAxisSample = new DemoInfo()
            {
                SampleName = "Date time category",
                GroupName = "Axis",
                Description = "This sample demonstrates the comparison of sales revenue for Christmas and New Year sales by utilizing a date-time category axis.",
                DemoViewType = typeof(DateTimeCategoryAxis)
            };
            List<Documentation> dateTimeCategoryAxisHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "DateTimeCategory Axis API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.DateTimeCategoryAxis.html#") },
                new Documentation(){ Content = "DateTimeCategory Axis Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/axis#datetimecategoryaxis") },
             };
            dateTimeCategoryAxisSample.Documentations = dateTimeCategoryAxisHelpDocuments;

            List<DemoInfo> subAxisDemos = new List<DemoInfo>();
            subAxisDemos.Add(categorySample);
            subAxisDemos.Add(numericalSample);
            subAxisDemos.Add(dateTimeSample);
            subAxisDemos.Add(logarithmicAxisSample);
            subAxisDemos.Add(dateTimeCategoryAxisSample);

            axisTypesDemo.SubCategoryDemos = subAxisDemos;
            this.Demos.Add(axisTypesDemo);

            #endregion

            DemoInfo customAxisDemo = new DemoInfo() 
            { 
                SampleName = "Axis Customization", 
                GroupName = "Axis", 
                Description = "This sample displays the production details of different materials while also providing various options to customize the axis elements.", 
                DemoViewType = typeof(AxisConfigurationDemo) 
            };
            List<Documentation> customAxisHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Axis API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartAxis.html") },
                new Documentation(){ Content = "Axis Customization Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/axis#customize-individual-axis-elements") },
             };
            customAxisDemo.Documentations = customAxisHelpDocuments;
            this.Demos.Add(customAxisDemo);

            DemoInfo flexibleChartAxisDemo = new DemoInfo() { SampleName = "Flexible Axis", GroupName = "Axis", Description = "This sample demonstrates the stock details with the support of a flexible axis layout with multiple series.", DemoViewType = typeof(FlexibleAxisDemo) };
            List<Documentation> flexibleAxisHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Axis API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartAxis.html")  },
                new Documentation(){ Content = "Multiple Axes Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/axis#multiple-axes") },
             };
            flexibleChartAxisDemo.Documentations = flexibleAxisHelpDocuments;
            this.Demos.Add(flexibleChartAxisDemo);

            DemoInfo autoScrollingDemo = new DemoInfo() { SampleName = "Auto Scrolling", GroupName = "Axis", ShowBusyIndicator = false, Description = "This sample showcases the heart pulse rate by using auto scrolling of the axis during real-time updates.", DemoViewType = typeof(ChartAutoScrollingDemo) };
            List<Documentation> autoScrollingHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Auto Scrolling Delta API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Chart.ChartAxis.html#Syncfusion_Windows_Chart_ChartAxis_AutoScrollingDelta") },
                new Documentation(){ Content = "Auto Scrolling Delta Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/axis#autoscrollingdelta") },
             };
            autoScrollingDemo.Documentations = autoScrollingHelpDocuments;
            this.Demos.Add(autoScrollingDemo);

            DemoInfo axisScaleBreakDemo = new DemoInfo() { SampleName = "Scale Break", GroupName = "Axis", Description = "This sample demonstrates the elevation details of mountains with scale break support.", DemoViewType = typeof(ScaleBreakDemo) };
            List<Documentation> scaleBreakHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Scale Break API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartAxisScaleBreak.html")  },
                new Documentation(){ Content = "Scale Break Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/scalebreaks") },
             };
            axisScaleBreakDemo.Documentations = scaleBreakHelpDocuments;
            this.Demos.Add(axisScaleBreakDemo);

            DemoInfo multiLevelLabelDemo = new DemoInfo() { SampleName = "Multi Level Labels", GroupName = "Axis", Description = "This sample demonstrates the high and low temperature of Sydney with multi-level label support for the chart axis.", DemoViewType = typeof(MultiLevelLabelsDemo) };
            List<Documentation> multiLevelLabelHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Multi Level Labels API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartAxisBase2D.html#Syncfusion_UI_Xaml_Charts_ChartAxisBase2D_MultiLevelLabels") },
                new Documentation(){ Content = "Multi Level Labels Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/axis#multi-level-labels") },
             };
            multiLevelLabelDemo.Documentations = multiLevelLabelHelpDocuments;
            this.Demos.Add(multiLevelLabelDemo);

            #endregion

            #region Interaction

            #region Selection

            DemoInfo selectionDemo = new DemoInfo()
            {
                SampleName = "Selection",
                GroupName = "Interaction",
                WhatsNewDescription= "This sample showcases the selection support, which allows highlighting the series or segment by tapping.",
            };

            DemoInfo dataPointSelectionSample = new DemoInfo() { SampleName = "Data point selection", GroupName = "Interaction", Description = "This sample shows how to track daily activity with selection functionality, allowing you to highlight specific segments with a single tap.", DemoViewType = typeof(DataPointSelection) };
            List<Documentation> dataPointSelectionDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Segment Selection API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartSelectionBehavior.html#Syncfusion_UI_Xaml_Charts_ChartSelectionBehavior_EnableSegmentSelection") },
                new Documentation(){ Content = "Segment Selection Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/interactive-features/selection#segmentselection") },
             };
            dataPointSelectionSample.Documentations = dataPointSelectionDocumentation;

            DemoInfo seriesSelectionSample = new DemoInfo() { SampleName = "Series selection", GroupName = "Interaction", Description = "This sample displays the age distribution by country, with the added functionality to select specific series. When tapped, the selected series are highlighted.", DemoViewType = typeof(SeriesSelection) };
            List<Documentation> seriesSelectionDocumentation = new List<Documentation>()
            {
                new Documentation(){ Content = "Series Selection API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartSelectionBehavior.html#Syncfusion_UI_Xaml_Charts_ChartSelectionBehavior_EnableSeriesSelection") },
                new Documentation(){ Content = "Series Selection Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/interactive-features/selection#series-selection") },
             };
            seriesSelectionSample.Documentations = seriesSelectionDocumentation;

            List<DemoInfo> subSelectionDemos = new List<DemoInfo>();
            subSelectionDemos.Add(dataPointSelectionSample);
            subSelectionDemos.Add(seriesSelectionSample);

            selectionDemo.SubCategoryDemos = subSelectionDemos;
            this.Demos.Add(selectionDemo);

            #endregion

            DemoInfo tooltipDemo = new DemoInfo() { SampleName = "Tooltip", GroupName = "Interaction", Description = "This sample visualizes the labor force from 2004 to 2012, with interactive tooltips that provide additional details about the data.", DemoViewType = typeof(CustomTooltip) };
            List<Documentation> chartTooltipHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Tooltip API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartTooltipBehavior.html") },
                new Documentation(){Content = "Tooltip Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/interactive-features/tooltip") },
             };
            tooltipDemo.Documentations = chartTooltipHelpDocuments;
            this.Demos.Add(tooltipDemo);

            DemoInfo trackballDemo = new DemoInfo() { SampleName = "Trackball", GroupName = "Interaction", Description = "This sample uses trackball support to demonstrate the sales percentage, providing additional information about data points when hovered over or dragged on the chart.", DemoViewType = typeof(TrackBall) };
            List<Documentation> chartTrackballHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Trackball API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartTrackBallBehavior.html#") },
                new Documentation(){ Content = "Trackball Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/interactive-features/trackball") },
             };
            trackballDemo.Documentations = chartTrackballHelpDocuments;
            this.Demos.Add(trackballDemo);

            DemoInfo zoomPanDemo = new DemoInfo() { SampleName = "Zooming and Panning", GroupName = "Interaction", Description = "This sample shows a summary of activity with zooming capabilities. It enables you to examine the data points plotted in the series more closely.", DemoViewType = typeof(ZoomPanBehavior) };
            List<Documentation> chartZoomPanHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Zooming and Panning API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartZoomPanBehavior.html") },
                new Documentation(){ Content = "Zooming and Panning Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/interactive-features/zoompan") },
             };
            zoomPanDemo.Documentations = chartZoomPanHelpDocuments;
            this.Demos.Add(zoomPanDemo);

            DemoInfo crossHairDemo = new DemoInfo() { SampleName = "Crosshair", GroupName = "Interaction", Description = "This sample demonstrates stock market analysis using crosshair behavior, which displays the values at the current mouse pointer location.", DemoViewType = typeof(CrossHairBehavior) };
            List<Documentation> chartCrossHairHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Crosshair API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartCrossHairBehavior.html#") },
                new Documentation(){ Content = "Crosshair Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/interactive-features/crosshair") },
             };
            crossHairDemo.Documentations = chartCrossHairHelpDocuments;
            this.Demos.Add(crossHairDemo);

            #endregion

            #region Legend

            DemoInfo legendToggleSample = new DemoInfo() { SampleName = "Default Legend", GroupName = "Legend", WhatsNewDescription= "This sample showcases the toggled legend, which allows individuals to enable or disable series by tapping on the legend.",
                Description = "This sample illustrates a sales comparison in a fruit shop with toggle functionality, which allows for enabling or disabling series by tapping on the legend.", DemoViewType = typeof(ToggledLegend)};
            List<Documentation> legendHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Legend API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartLegend.html") },
                new Documentation(){ Content = "Legend Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/legend")  },
             };
            legendToggleSample.Documentations = legendHelpDocuments;
            this.Demos.Add(legendToggleSample);

            DemoInfo customizedLegendSample = new DemoInfo() { SampleName = "Customized Legend", GroupName = "Legend", WhatsNewDescription= "This sample showcases the customized legend, which allows individuals to personalize both its appearance and content to suit their preferences.",
                Description = "This sample visualizes the production of automobiles by category, with a customized legend that provides additional information about productivity.", DemoViewType = typeof(CustomizedLegend)};
            List<Documentation> customizedLegendHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Legend Icon Template API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartSeriesBase.html#Syncfusion_UI_Xaml_Charts_ChartSeriesBase_LegendIconTemplate") },
                new Documentation(){ Content = "Legend Template Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/legend#customization")  },
             };
            customizedLegendSample.Documentations = customizedLegendHelpDocuments;
            this.Demos.Add(customizedLegendSample);

            DemoInfo multipleLegendSample = new DemoInfo() { SampleName = "Multiple Legend", GroupName = "Legend", Description = "This sample visualizes the details of sales and targets achieved using multiple legends, which are used to view the legends clearly when multiple areas are present.", DemoViewType = typeof(MultipleLegendsDemo)};
            List<Documentation> multipleLegendHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Legend Collection API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartLegendCollection.html") },
                new Documentation(){ Content = "Multiple Legend Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/legend#multiple-legends")  },
             };
            multipleLegendSample.Documentations = multipleLegendHelpDocuments;
            this.Demos.Add(multipleLegendSample);

            #endregion

            #region Data Binding

            DemoInfo MVVMPatternDemo = new DemoInfo() { SampleName = "MVVM Pattern", GroupName = "Data Binding", Description = "This sample demonstrates the annual rainfall details in millimeters in New York.", DemoViewType = typeof(MVVMBindingDemo) };
            List<Documentation> MVVMBindingHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Data Binding Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/databinding") },
             };
            MVVMPatternDemo.Documentations = MVVMBindingHelpDocuments;
            this.Demos.Add(MVVMPatternDemo);

            DemoInfo dataTableDemo = new DemoInfo() { SampleName = "DataTable Binding", GroupName = "Data Binding", Description = "This sample illustrates the analysis of sales and target details for electronic items.", DemoViewType = typeof(DataTableBindingDemo) };
            List<Documentation> dataTableBindingHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Data Table Binding Documentation", Uri = new Uri("https://support.syncfusion.com/kb/article/5196/how-to-bind-data-table-in-wpf-chart-sfchart") },
             };
            dataTableDemo.Documentations = dataTableBindingHelpDocuments;
            this.Demos.Add(dataTableDemo);

            DemoInfo dataGridBindingDemo = new DemoInfo() { SampleName = "Chart Grid Binding", GroupName = "Data Binding", Description = "This sample demonstrates the binding of data between the SfChart and SfDataGrid.", DemoViewType = typeof(ChartDataEditingDemo) };
            List<Documentation> dataGridBindingHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Data Grid Binding Documentation", Uri = new Uri("https://support.syncfusion.com/kb/article/3753/how-to-synchronize-the-selection-between-wpf-chart-sfchart-and-datagrid") },
             };
            dataGridBindingDemo.Documentations = dataGridBindingHelpDocuments;
            this.Demos.Add(dataGridBindingDemo);

            #endregion

            #region Data Editing

            DemoInfo dataEditingDemo = new DemoInfo() { SampleName = "Data Editing", GroupName = "Data Editing", Description = "This sample showcases the analysis of sales performance with support for visual data editing. It allows you to dynamically edit an entire series or a single data point by directly interacting with the chart series through dragging.", DemoViewType = typeof(VisualDataEditingDemo) };
            List<Documentation> chartDataEditingHelpDocuments = new List<Documentation>()
            {
               new  Documentation(){ Content = "Data Editing API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.XySegmentDraggingBase.html") },
                new Documentation(){ Content = "Data Editing Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/interactive-features/visual-data-editing")  },
             };
            dataEditingDemo.Documentations = chartDataEditingHelpDocuments;
            this.Demos.Add(dataEditingDemo);

            DemoInfo scatterChartEditingDemo = new DemoInfo() { SampleName = "Scatter Data Editing", GroupName = "Data Editing", Description = "This sample demonstrates the sales prediction of various products using scatter series with data editing support.", DemoViewType = typeof(ScatterDataEditingDemo) };
            List<Documentation> scatterChartEditingHelpDocuments = new List<Documentation>()
            {
               new  Documentation(){ Content = "Data Editing API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.XySegmentDraggingBase.html") },
                new Documentation(){ Content = "Data Editing Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/interactive-features/visual-data-editing")  },
             };
            scatterChartEditingDemo.Documentations = scatterChartEditingHelpDocuments;
            this.Demos.Add(scatterChartEditingDemo);

            #endregion

            #region Annotation 

            DemoInfo annotationTooltipDemo = new DemoInfo() { SampleName = "Tooltip", GroupName = "Annotations", Description = "This sample demonstrates score details with tooltip annotation support, which allows you to view the tooltip when hovering the mouse over the annotation.", DemoViewType = typeof(AnnotationToolTip) };
            List<Documentation> annotationTooltipHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Annotations API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.SfChart.html#Syncfusion_UI_Xaml_Charts_SfChart_Annotations") },
                new Documentation(){ Content = "Annotation Tooltip Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/annotations#tooltip")  },
             };
            annotationTooltipDemo.Documentations = annotationTooltipHelpDocuments;
            this.Demos.Add(annotationTooltipDemo);

            DemoInfo interactiveAnnotationDemo = new DemoInfo() { SampleName = "Interactivity", GroupName = "Annotations", Description = "This sample illustrates the stock details with annotations by resizing and dragging the annotations to different points at runtime.", DemoViewType = typeof(AnnotationInteractionDemo) };
            List<Documentation> annotationInteractionHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Shape Annotations API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ShapeAnnotation.html") },
                new Documentation(){ Content = "Annotation Interaction Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/annotations#interaction")},
             };
            interactiveAnnotationDemo.Documentations = annotationInteractionHelpDocuments;
            this.Demos.Add(interactiveAnnotationDemo);

            #endregion

            #region Line Studies

            DemoInfo trendLineDemo = new DemoInfo() { SampleName = "Trendline", GroupName = "Line Studies", Description = "This sample showcases graphical trend lines representing stock price details based on the assumptions derived from current and past trends.", DemoViewType = typeof(TrendlineDemo) };
            List<Documentation> chartTrendLineHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Trendline API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.TrendlineBase.html") },
                new Documentation(){ Content = "Trendline Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/trendlines") },
             };
            trendLineDemo.Documentations = chartTrendLineHelpDocuments;
            this.Demos.Add(trendLineDemo);

            DemoInfo indicatorDemo = new DemoInfo() { SampleName = "Technical Indicator", GroupName = "Line Studies", Description = "This sample showcases the Google stock price along with technical indicators, which serve as the foundation for technical analysis. Technical analysis is used to determine future financial, stock, or economic trends.", DemoViewType = typeof(Indicator) };
            List<Documentation> technicalIndicatorHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Technical Indicator API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.SfChart.html#Syncfusion_UI_Xaml_Charts_SfChart_TechnicalIndicators")  },
                new Documentation(){ Content = "Technical Indicator Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/technical-indicators") },
             };
            indicatorDemo.Documentations = technicalIndicatorHelpDocuments;
            this.Demos.Add(indicatorDemo);

            DemoInfo stripLineDemo = new DemoInfo() { SampleName = "Strip Lines", GroupName = "Line Studies", Description = "This sample demonstrates the temperature range using Striplines, which are utilized to highlight the axis range by being drawn in the background of a chart.", DemoViewType = typeof(StripLineDemo) };
            List<Documentation> stripLineHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Strip Line API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartStripLine.html") },
                new Documentation(){  Content = "Strip Line Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/striplines") },
             };
            stripLineDemo.Documentations = stripLineHelpDocuments;
            this.Demos.Add(stripLineDemo);

            #endregion

            #region Real Time Chart

            DemoInfo realTimeDemo = new DemoInfo() { SampleName = "Real-time Line Chart", GroupName = "Real-time Charts", ShowBusyIndicator = false, Description = "The sample demonstrates how to monitor network performance using a live chart. New data points are added to the end of the chart, and old data points are removed at the start of a specified time interval.", DemoViewType = typeof(RealTimeChartDemo) };
            List<Documentation> realTimeChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Real-Time Chart Documentation", Uri = new Uri("https://support.syncfusion.com/kb/article/10039/how-to-create-a-real-time-chart-sfchart-using-mvvm-in-wpf") },
             };
            realTimeDemo.Documentations = realTimeChartHelpDocuments;
            this.Demos.Add(realTimeDemo);

            DemoInfo verticalChartDemo = new DemoInfo() { SampleName = "Vertical Live Chart", GroupName = "Real-time Charts", ShowBusyIndicator = false, Description = "The sample shows how to analyze seismograph data using a live chart. The chart continuously adds new data points at the end of a specified time interval.", DemoViewType = typeof(VerticalChartDemo) };
            List<Documentation> verticalChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Transposed API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.CartesianSeries.html#Syncfusion_UI_Xaml_Charts_CartesianSeries_IsTransposed") },
                new Documentation(){ Content = "Vertical chart Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/vertical-charts") },
             };
            verticalChartDemo.Documentations = verticalChartHelpDocuments;
            this.Demos.Add(verticalChartDemo);

            #endregion

            #region Serialization

            DemoInfo serializationDemo = new DemoInfo() { SampleName = "Serialization", GroupName = "Serialization", Description = "This sample demonstrates the process of serializing and deserializing the chart that illustrates the defect rate of various components.", DemoViewType = typeof(Serialization) };
            List<Documentation> serializationHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Serialization Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/serialization") },
             };
            serializationDemo.Documentations = serializationHelpDocuments;
            this.Demos.Add(serializationDemo);

            #endregion

            #region Performance 

            DemoInfo multipleSeriesDemo = new DemoInfo() { SampleName = "Multiple Series", GroupName = "Performance", Description = "This sample demonstrates the SfChart's high-performance capabilities with multiple series, handling large numbers of series without any performance loss.", DemoViewType = typeof(MultipleSeriesDemo) };
            List<Documentation> multipleSeriesHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Multiple Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/area#multiple-area") },
             };
            multipleSeriesDemo.Documentations = multipleSeriesHelpDocuments;
            this.Demos.Add(multipleSeriesDemo);

            #endregion

            #region Exporting

            DemoInfo chartExportDemo = new DemoInfo() 
            { 
                SampleName = "Export and Print",
                GroupName = "Exporting", 
                Description = "This sample demonstrates the exporting and printing support in the chart that illustrates the details of a weather report.", 
                DemoViewType = typeof(ExportChartDemo) 
            };
            List<Documentation> exportPrintChartHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Export Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/exporting") },
                new Documentation(){ Content = "Printing Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/printing") },
             };
            chartExportDemo.Documentations = exportPrintChartHelpDocuments;
            this.Demos.Add(chartExportDemo);

            #endregion

            #region WaterMark

            DemoInfo watermarkDemo = new DemoInfo() 
            {
                SampleName = "WaterMark", 
                GroupName = "WaterMark", 
                Description = "This sample showcases the product sales between two products across different years with watermark support, which illustrates the desired view being added in the chart area.",
                DemoViewType = typeof(WaterMark)
            };
            List<Documentation> waterMarkHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Watermark API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.SfChart.html#Syncfusion_UI_Xaml_Charts_SfChart_Watermark") },
                new Documentation(){ Content = "Watermark Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/charts/watermark") },
             };
            watermarkDemo.Documentations = waterMarkHelpDocuments;
            this.Demos.Add(watermarkDemo);

            #endregion

            #region Open AI

            DemoInfo openAIDemo = new DemoInfo()
            {
                SampleName = "Smart Data Preprocessing",
                GroupName = "AI-Powered",
                Description = "This sample demonstrates how AI-powered data cleaning and preprocessing works with the smart chart component. (Note: If you do not provide your AI key and endpoint, random data will be generated here.)",
                DemoViewType = typeof(DataCleaning_Preprocessing),
                IsAISample = true, 
                Tag=Tag.New,
                AISampleDescription= "AI-powered smart chart data cleaning and preprocessing."
            };
           
            this.Demos.Add(openAIDemo);

            #endregion
        }
    }

    public class Three_DChartProductDemos : ProductDemo
    {
        public Three_DChartProductDemos()
        {
            this.Product = "3D-Charts";
            this.ProductCategory = "CHARTS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M6.00542 1.95849L7.24699 1.54004L7.70887 1.77354L6.4673 2.192L6.00542 1.95849ZM6.92857 3.0918L8.5 2.56217V11.259L6.98573 12.4705L6.92857 8.36254V3.0918ZM5.5 13.3349L5.99513 13.1525L5.93976 9.17341L5.21429 9.54017V11.7448L5.5 11.9163V13.3349ZM5.38957 14.4413L6.74899 13.9405L9.23729 11.9498C9.40334 11.817 9.5 11.6159 9.5 11.4032V1.55853L7.58605 0.590921C7.41868 0.50631 7.22437 0.492392 7.04665 0.552288L4.21429 1.5069V6.75853L2.5 7.6252V10.7163L0.5 11.9163V14.0639C0.5 14.3502 0.674265 14.6076 0.940026 14.7139L3 15.5379L5.05997 14.7139C5.19869 14.6584 5.31248 14.5617 5.38957 14.4413ZM3.5 10.7163L4.21429 11.1448V9.48103L3.5 8.93936V10.7163ZM5.92857 3.04017V7.35934L5.21429 6.81768V2.67906L5.92857 3.04017ZM3.93978 8.01784L4.66108 7.65318L5.48879 8.28086L4.76749 8.64552L3.93978 8.01784ZM2.12161 12.1095L3 11.5824L3.87839 12.1095L3 12.4608L2.12161 12.1095ZM3.5 13.3379L4.5 12.9379V13.8608L3.5 14.2608V13.3379ZM2.5 13.3379V14.2608L1.5 13.8608V12.9379L2.5 13.3379Z"),
                Width = 10,
                Height = 16,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Charts.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The 3D Charts are used to view two-dimensional data in a three-dimensional view and can be rotated in all three dimensions to get the best possible data view.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/3D-Charts.png", UriKind.RelativeOrAbsolute));

            #region Column3DSeries

            DemoInfo column3DDemo = new DemoInfo()
            {
                SampleName = "Column",
                GroupName = "Basic Charts",
                WhatsNewDescription= "This sample showcases a 3D column chart that uses vertical bars to display various values or data points.",
            };
            List<DemoInfo> columnDemos = new List<DemoInfo>();

            DemoInfo columnChart3DDemo = new DemoInfo() { SampleName = "Default column", GroupName = "Basic Charts", Description = "This sample illustrates the diverse calorie content across different types of fruit, which is crucial for effective nutritional planning.", DemoViewType = typeof(ColumnChart3D) };
            List<Documentation> columnChart3DHelpDocuments = new List<Documentation>();
            columnChart3DHelpDocuments.Add(new Documentation() { Content = "Column Series 3D API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ColumnSeries3D.html") });
            columnChart3DHelpDocuments.Add(new Documentation() { Content = "Column Series 3D Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/3dseries#column-charts") });
            columnChart3DDemo.Documentations = columnChart3DHelpDocuments;

            DemoInfo columnWidthDemo = new DemoInfo() { SampleName = "Column spacing", GroupName = "BASIC CHARTS 3D", Description = "This sample demonstrates the expenditure details of the military between Sudan and Togo for various years from 2016 to 2020.", DemoViewType = typeof(Column3DSegmentSpacing) };
           
            columnDemos.Add(columnChart3DDemo);
            columnDemos.Add(columnWidthDemo);
            column3DDemo.SubCategoryDemos = columnDemos;
            this.Demos.Add(column3DDemo);

            #endregion

            #region Bar3DSeries

            DemoInfo bar3DDemo = new DemoInfo()
            {
                SampleName = "Bar",
                GroupName = "Basic Charts",
                WhatsNewDescription= "This sample demonstrates a 3D bar chart with horizontal columns showcasing various data points."
            };

            List<DemoInfo> barDemos = new List<DemoInfo>();

            DemoInfo barChart3DDemo = new DemoInfo() { SampleName = "Default bar", GroupName = "Basic Charts", Description = "This sample illustrates the number of employees in the renewable energy sector worldwide in 2022.", DemoViewType = typeof(BarChart3D) };
            List<Documentation> barChart3DHelpDocuments = new List<Documentation>();
            barChart3DHelpDocuments.Add(new Documentation() { Content = "Bar Chart 3D API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.BarSeries3D.html") });
            barChart3DHelpDocuments.Add(new Documentation() { Content = "Bar Chart 3D Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/3dseries#bar-charts") });
            barChart3DDemo.Documentations = barChart3DHelpDocuments;

            DemoInfo barWidthDemo = new DemoInfo() { SampleName = "Bar spacing", GroupName = "Basic Charts", Description = "This sample showcases the merchandise of ore and metal exports between Bolivia and Brazil for different years, ranging from 2020 to 2022.", DemoViewType = typeof(BarChart3DSegmentSpacing) };
            barDemos.Add(barChart3DDemo);
            barDemos.Add(barWidthDemo);
            bar3DDemo.SubCategoryDemos = barDemos;
            this.Demos.Add(bar3DDemo);

            #endregion

            #region Area3DSeries

            DemoInfo areaChart3DDemo = new DemoInfo() { SampleName = "Area", GroupName = "Basic Charts", Description = "This sample shows how average sales of different fast food items have varied over a range of years, from 2000 to 2014.", DemoViewType = typeof(AreaSeriesChart3DDemo) };
            List<Documentation> areaChart3DHelpDocuments = new List<Documentation>();
            areaChart3DHelpDocuments.Add(new Documentation() { Content = "Area Series 3D API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.AreaSeries3D.html#") });
            areaChart3DHelpDocuments.Add(new Documentation() { Content = "Area Series 3D Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/3dseries#area-chart") });
            areaChart3DDemo.Documentations = areaChart3DHelpDocuments;
            this.Demos.Add(areaChart3DDemo);

            #endregion

            #region Line3DSeries

            DemoInfo lineChart3DDemo = new DemoInfo() { SampleName = "Line", GroupName = "Basic Charts", Description = "This sample showcases the percentage of population growth between the Netherlands and Sweden from 2004 to 2020.", DemoViewType = typeof(LineSeriesChart3D) };
            List<Documentation> lineChart3DHelpDocuments = new List<Documentation>();
            lineChart3DHelpDocuments.Add(new Documentation() { Content = "Line Series 3D API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.LineSeries3D.html#") });
            lineChart3DHelpDocuments.Add(new Documentation() { Content = "Line Series 3D Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/3dseries#line-charts") });
            lineChart3DDemo.Documentations = lineChart3DHelpDocuments;
            this.Demos.Add(lineChart3DDemo);

            #endregion

            #region Scatter3DSeries

            DemoInfo scatterChart3DDemo = new DemoInfo() { SampleName = "Scatter", GroupName = "Basic Charts", Description = "This sample demonstrates the details of football spending and earnings in euros, measured in millions, of different teams using a scatter series.", DemoViewType = typeof(ScatterSeriesChart3D) };
            List<Documentation> scatterChart3DHelpDocuments = new List<Documentation>();
            scatterChart3DHelpDocuments.Add(new Documentation() { Content = "Scatter Series 3D API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ScatterSeries3D.html#") });
            scatterChart3DHelpDocuments.Add(new Documentation() { Content = "Scatter Series 3D Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/3dseries#scatter-chart") });
            scatterChart3DDemo.Documentations = scatterChart3DHelpDocuments;
            this.Demos.Add(scatterChart3DDemo);

            #endregion

            #region Pie3DSeries

            DemoInfo pie3DDemo = new DemoInfo()
            {
                SampleName = "Pie",
                GroupName = "Circular Charts",
                WhatsNewDescription= "This sample represents parts of a whole by dividing a circle into sectors, where each sector's angle corresponds to the proportion of the data it represents.",
            };
            List<DemoInfo> pieDemo = new List<DemoInfo>();

            DemoInfo pieChart3DDemo = new DemoInfo() { SampleName = "Default pie", GroupName = "Circular Charts", Description = "This sample demonstrates the daily food composition of a healthy diet, which includes the percentage of rice, vegetables, milk, and cereals.", DemoViewType = typeof(PieChart3D) };
            List<Documentation> pieChart3DHelpDocuments = new List<Documentation>();
            pieChart3DHelpDocuments.Add(new Documentation() { Content = "Pie Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.PieSeries3D.html#") });
            pieChart3DHelpDocuments.Add(new Documentation() { Content = "Pie Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/3dseries#pie-chart") });
            pieChart3DDemo.Documentations = pieChart3DHelpDocuments;
           
            DemoInfo semiPie = new DemoInfo() { SampleName = "Semi-pie", GroupName = "Circular Charts", DemoViewType=typeof(SemiPieSeries3D), Description= "This sample demonstrates the biggest cash crops in the United States in 2022 using various pie shapes, such as semi-pie and quarter-pie." };
            List<Documentation> semiPieChart3DHelpDocuments = new List<Documentation>();
            semiPieChart3DHelpDocuments.Add(new Documentation() { Content = "Pie Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.PieSeries3D.html#") });
            semiPieChart3DHelpDocuments.Add(new Documentation() { Content = "Semi Pie Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/3dseries#semi-pie-and-doughnut") });
            semiPie.Documentations = semiPieChart3DHelpDocuments;

            DemoInfo explodePie = new DemoInfo() { SampleName = "Exploded pie", GroupName = "Circular Charts", DemoViewType = typeof(ExplodePieChart3D), Description= "This sample demonstrates the major uranium suppliers of Europe in 2022 using a sliced pie chart." };
            pieDemo.Add(pieChart3DDemo);
            pieDemo.Add(semiPie);
            pieDemo.Add(explodePie);
            pie3DDemo.SubCategoryDemos = pieDemo;

            this.Demos.Add(pie3DDemo);

            #endregion

            #region Doughnut3DSeries

            DemoInfo doughnut3DDemo = new DemoInfo()
            {
                SampleName = "Doughnut",
                GroupName = "Circular Charts",
                WhatsNewDescription= "This sample visualizes a pie chart with a hole in the center, presenting the proportions of data segments."
            };
            List<DemoInfo> doughnutDemo = new List<DemoInfo>();

            DemoInfo doughnutChart3DDemo = new DemoInfo() { SampleName = "Doughnut", GroupName = "Circular Charts", Description = "This sample represents the percentage of a day spent on certain activities using a doughnut chart.", DemoViewType = typeof(DoughnutChart3D) };
            List<Documentation> doughnutChart3DHelpDocuments = new List<Documentation>();
            doughnutChart3DHelpDocuments.Add(new Documentation() { Content = "Doughnut Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.DoughnutSeries3D.html#") });
            doughnutChart3DHelpDocuments.Add(new Documentation() { Content = "Doughnut Series Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/3dseries#doughnut-chart") });
            doughnutChart3DDemo.Documentations = doughnutChart3DHelpDocuments;
          
            DemoInfo semiDoughnut = new DemoInfo() { SampleName = "Semi-doughnut", GroupName = "Circular Charts", DemoViewType=typeof(SemiDoughnutSeries3D), Description = "This sample illustrates the world's biggest rice exporters in 2022. Rice exports significantly impact global trade dynamics because rice is a staple food around the world." };
            List<Documentation> semiDoughnutHelpDocuments = new List<Documentation>();
            semiDoughnutHelpDocuments.Add(new Documentation() { Content = "Doughnut Series API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.DoughnutSeries3D.html#") });
            semiDoughnutHelpDocuments.Add(new Documentation() { Content = "Semi Doughnut Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/3dseries#semi-pie-and-doughnut") });
            semiDoughnut.Documentations = semiDoughnutHelpDocuments;
           
            doughnutDemo.Add(doughnutChart3DDemo);
            doughnutDemo.Add(semiDoughnut);

            doughnut3DDemo.SubCategoryDemos = doughnutDemo;
            this.Demos.Add(doughnut3DDemo);

            #endregion

            #region StackedColumn3DSeries

            DemoInfo stackedColumn3DDemo = new DemoInfo()
            {
                SampleName = "Stacked Column",
                GroupName = "Stacked Charts",
                WhatsNewDescription= "This sample visualizes stacked vertical bars to show both individual and cumulative values for different categories.",
            };

            DemoInfo stackedColumnDemo = new DemoInfo() { SampleName = "Default stacked column", GroupName = "Stacked Charts", Description = "This sample displays the annual patents filed for electric vehicle technologies using stacked columns.", DemoViewType = typeof(StackingColumnChart3D) };
            List<Documentation> stackedColumnHelpDocuments = new List<Documentation>();
            stackedColumnHelpDocuments.Add(new Documentation() { Content = "Stacked Column Series 3D API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.StackingColumnSeries3D.html#") });
            stackedColumnHelpDocuments.Add(new Documentation() { Content = "Stacked Column Series 3D Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/3dseries#stacking-column") });
            stackedColumnDemo.Documentations = stackedColumnHelpDocuments;

            List<DemoInfo> stackedDemos = new List<DemoInfo>();
            DemoInfo stackedGroupedSample = new DemoInfo() { SampleName = "Cluster stacked column", GroupName = "Stacked Charts",Description= "This cluster-stacked column represents the company's growth with a grouping of quarters, allowing easy visualization of the relationship of parts to the whole.", DemoViewType = typeof(ClusterStakingColumn3D) };
            stackedDemos.Add(stackedColumnDemo);
            stackedDemos.Add(stackedGroupedSample);
            stackedColumn3DDemo.SubCategoryDemos = stackedDemos;
            this.Demos.Add(stackedColumn3DDemo);

            #endregion

            #region StackedBar3DSeries

            DemoInfo stackedBar3DDemo = new DemoInfo()
            {
                SampleName = "Stacked Bar",
                GroupName = "Stacked Charts",
                WhatsNewDescription= "This sample visualizes stacked horizontal columns to display both individual and cumulative values for different categories."
            };

            DemoInfo stackedBarDemo = new DemoInfo() { SampleName = "Default stacked bar", GroupName = "Stacked Charts", Description = "Using a stacked bar chart, this sample demonstrates the profit details of cosmetic products across various regions.", DemoViewType = typeof(StackingBarChart3D) };
            List<Documentation> stackedBarHelpDocuments = new List<Documentation>();
            stackedBarHelpDocuments.Add(new Documentation() { Content = "Stacked Bar Series 3D API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.StackingBarSeries3D.html#") });
            stackedBarHelpDocuments.Add(new Documentation() { Content = "Stacked Bar Series 3D Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/3dseries#stacking-bar") });
            stackedBarDemo.Documentations = stackedBarHelpDocuments;

            List<DemoInfo> stackedBarDemos = new List<DemoInfo>();
            DemoInfo stackedBarGroupedSample = new DemoInfo() { SampleName = "Cluster stacked bar", GroupName = "Stacked Charts", DemoViewType = typeof(ClusterStackingBar3D), Description= "Using a grouped stacked bar, this sample showcases worldwide energy production across different years (2018, 2020, and 2022)." };
            stackedBarDemos.Add(stackedBarDemo);
            stackedBarDemos.Add(stackedBarGroupedSample);
            stackedBar3DDemo.SubCategoryDemos = stackedBarDemos;
            this.Demos.Add(stackedBar3DDemo);

            #endregion

            #region StackedColumn100%3DSeries

            DemoInfo stacked100Column3DDemo = new DemoInfo()
            {
                SampleName = "100 Stacked Column ",
                GroupName = "100 Stacked Charts",
                WhatsNewDescription= "This sample demonstrates the relative proportions of multiple data series as stacked columns, each representing a percentage of the total."
            };

            DemoInfo stackedColumn1003DDemo = new DemoInfo() { SampleName = "Default 100 stacked column ", GroupName = "100 Stacked Charts", Description = "This 100% stacked column demonstrates the global distribution of cloud provider data centers.", DemoViewType = typeof(StackingColumn100Chart3D) };
            List<Documentation> stackedColumn1003DHelpDocuments = new List<Documentation>();
            stackedColumn1003DHelpDocuments.Add(new Documentation() { Content = "Stacked Column 100% Series 3D API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.StackingColumn100Series3D.html#") });
            stackedColumn1003DHelpDocuments.Add(new Documentation() { Content = "Stacked Column 100% Series 3D Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/3dseries#stacking-column-100") });
            stackedColumn1003DDemo.Documentations = stackedColumn1003DHelpDocuments;

            List<DemoInfo> stackedColumn100Demos = new List<DemoInfo>();
            DemoInfo stackedColumn100GroupedSample = new DemoInfo() { SampleName = "Cluster 100 stacked column", GroupName = "100 Stacked Charts",Description= "This sample demonstrates the access to drinking water facilities among various population shares from 2018 to 2020.", DemoViewType=typeof(ClusterStackingColumn100Chart3D) };
            stackedColumn100Demos.Add(stackedColumn1003DDemo);
            stackedColumn100Demos.Add(stackedColumn100GroupedSample);
            stacked100Column3DDemo.SubCategoryDemos = stackedColumn100Demos;
            this.Demos.Add(stacked100Column3DDemo);

            #endregion

            #region StackedBar100%3DSeries

            DemoInfo stacked100Bar3DDemo = new DemoInfo()
            {
                SampleName = "100 Stacked Bar",
                GroupName = "100 Stacked Charts",
                WhatsNewDescription= "This sample illustrates the comparative ratios of various data series using stacked bars, each signifying a percentage of the overall total."
            };

            DemoInfo stackedBar1003DDemo = new DemoInfo() { SampleName = "Default 100 stacked bar", GroupName = "100 Stacked Charts", Description = "This sample illustrates the various pet preferences from pet shops, streets, breeders, and other sources.", DemoViewType = typeof(StackingBar100Chart3D) };
            List<Documentation> stackedBar1003DHelpDocuments = new List<Documentation>();
            stackedBar1003DHelpDocuments.Add(new Documentation() { Content = "Stacked Bar 100% Series 3D API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.StackingBar100Series3D.html#") });
            stackedBar1003DHelpDocuments.Add(new Documentation() { Content = "Stacked Bar 100% Series 3D Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/3dseries#stacking-bar-100") });
            stackedBar1003DDemo.Documentations = stackedBar1003DHelpDocuments;

            List<DemoInfo> stackedBar100Demos = new List<DemoInfo>();
            stackedBar100Demos.Add(stackedBar1003DDemo);
            stacked100Bar3DDemo.SubCategoryDemos = stackedBar100Demos;
            this.Demos.Add(stacked100Bar3DDemo);

            #endregion

            #region Axis

            #region Category Axis

            DemoInfo categoryAxis3DDemo = new DemoInfo() { SampleName = "Category Axis", GroupName = "Axis", DemoViewType=typeof(CategoryAxis3DChart) , Description= "Using a category axis, this sample demonstrates the world's most active volcanoes since 1950 across different countries.",
                                                WhatsNewDescription= "This sample illustrates a category axis, an indexed-based axis with equally spaced points plotted according to the index of the data point collection."};
            List<Documentation> categoryAxis3DHelpDocuments = new List<Documentation>();
            categoryAxis3DHelpDocuments.Add(new Documentation() { Content = "Category Axis 3D API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.CategoryAxis3D.html#") });
            categoryAxis3DHelpDocuments.Add(new Documentation() { Content = "Category Axis 3D Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/axis#category-axis") });
            categoryAxis3DDemo.Documentations = categoryAxis3DHelpDocuments;
            this.Demos.Add(categoryAxis3DDemo);

            #endregion

            #region Numerical Axis

            DemoInfo numericalAxis3DDemo = new DemoInfo() { SampleName = "Numerical Axis",  GroupName = "Axis", DemoViewType=typeof(NumericalAxis3DChart), Description= "This sample demonstrates the score of the Australia vs India match by using a numerical axis. The axis is divided into equal intervals or units based on the range of values in the data set.",
                                                WhatsNewDescription= "This sample demonstrates the numerical axis, which is used to plot numerical values on the chart and can be defined for both the PrimaryAxis and SecondaryAxis."};
            List<Documentation> numericalAxis3DHelpDocuments = new List<Documentation>();
            numericalAxis3DHelpDocuments.Add(new Documentation() { Content = "Numerical Axis 3D API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.NumericalAxis3D.html#") });
            numericalAxis3DHelpDocuments.Add(new Documentation() { Content = "Numerical Axis 3D Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/axis#numerical-axis") });
            numericalAxis3DDemo.Documentations = numericalAxis3DHelpDocuments;
            this.Demos.Add(numericalAxis3DDemo);

            #endregion

            #region DateTime Axis

            DemoInfo dateTimeAxis3DDemo = new DemoInfo() { SampleName = "DateTime Axis",  GroupName = "Axis", DemoViewType=typeof(DateTimeAxis3DChart) , Description= "This sample demonstrates the production trends of different food items on a monthly basis using a date-time axis.",
                                                      WhatsNewDescription= "This sample displays the date-time axis that is used to plot DateTime values, and it is widely used to create financial charts in various places."};
            List<Documentation> DateTimeAxis3DHelpDocuments = new List<Documentation>();
            DateTimeAxis3DHelpDocuments.Add(new Documentation() { Content = "DateTime Axis 3D API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.DateTimeAxis3D.html#") });
            DateTimeAxis3DHelpDocuments.Add(new Documentation() { Content = "DateTime Axis 3D Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/axis#datetime-axis") });
            dateTimeAxis3DDemo.Documentations = DateTimeAxis3DHelpDocuments;
            this.Demos.Add(dateTimeAxis3DDemo);

            #endregion

            #region Logarithmic Axis

            DemoInfo logAxis3DDemo = new DemoInfo() { SampleName = "Logarithmic Axis",  GroupName = "Axis", DemoViewType = typeof(LogaritmicAxis3DChart), Description = "This sample illustrates the growth of a product throughout a period, from 2005 to 2015, using a logarithmic axis.",
                                                        WhatsNewDescription= "This sample illustrates the use of a logarithmic axis to plot the logarithmic scale for the chart. The logarithmic values will be plotted using a logarithmic base value of 10."};
            List<Documentation> logAxis3DHelpDocuments = new List<Documentation>();
            logAxis3DHelpDocuments.Add(new Documentation() { Content = "Logarithmic Axis 3D API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.LogarithmicAxis3D.html#") });
            logAxis3DHelpDocuments.Add(new Documentation() { Content = "Logarithmic Axis 3D Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/axis#logarithmic-axis") });
            logAxis3DDemo.Documentations = logAxis3DHelpDocuments;
            this.Demos.Add(logAxis3DDemo);

            #endregion

            #region DepthAxis

            DemoInfo depthAxis3DDemo = new DemoInfo() { SampleName = "Depth Axis", GroupName = "Axis", Description = "This sample showcases the percentage of total sales each kind of fruit contributes using the depth axis.", DemoViewType = typeof(DepthAxis) };
            List<Documentation> depthAxis3DHelpDocuments = new List<Documentation>();
            depthAxis3DHelpDocuments.Add(new Documentation() { Content = "Depth Axis API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.SfChart3D.html#Syncfusion_UI_Xaml_Charts_SfChart3D_DepthAxis") });
            depthAxis3DHelpDocuments.Add(new Documentation() { Content = "Depth Axis Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/axis#depth-axis") });
            depthAxis3DDemo.Documentations = depthAxis3DHelpDocuments;
            this.Demos.Add(depthAxis3DDemo);

            #endregion

            #endregion
        }
    }

    public class SFDateTimeRangeNavigatorDemo : ProductDemo
    {
        public SFDateTimeRangeNavigatorDemo()
        {
            this.Product = "Range Navigator";
            this.ProductCategory = "CHARTS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M0.5 0C0.223858 0 0 0.223858 0 0.5C0 0.776142 0.223858 1 0.5 1H3L3 3.58535C2.4174 3.79127 2 4.34689 2 5C2 5.65311 2.4174 6.20873 3 6.41465L3 9H0.5C0.223858 9 0 9.22386 0 9.5C0 9.77614 0.223858 10 0.5 10H13.5C13.7761 10 14 9.77614 14 9.5C14 9.22386 13.7761 9 13.5 9H11V6.41465C11.5826 6.20873 12 5.65311 12 5C12 4.34689 11.5826 3.79127 11 3.58535V1H13.5C13.7761 1 14 0.776142 14 0.5C14 0.223858 13.7761 0 13.5 0H0.5ZM10 3.58535V1H4L4 3.58535C4.5826 3.79127 5 4.34689 5 5C5 5.65311 4.5826 6.20873 4 6.41465L4 9H10V6.41465C9.4174 6.20873 9 5.65311 9 5C9 4.34689 9.4174 3.79127 10 3.58535Z"),
                Width = 14,
                Height = 10,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Charts.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The Range Navigator control is a time-bound data visualization control. Its purpose is to allow scrolling and navigation through long periods. This control can be easily integrated with other controls, such as chart and grid view, to create rich and powerful dashboards.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Range Navigator.png", UriKind.RelativeOrAbsolute));
          
            DemoInfo interactiveNavigatorDemo = new DemoInfo()
            {
                SampleName = "Default Range Navigator",
                GroupName = "Date Time Range Navigator",
                Description = "This sample showcases the stock market history over a selected time period using a date-time range navigator.",
                DemoViewType = typeof(InteractiveNavigator),
            };
            List<Documentation> interactiveNavigatorHelpDocuments = new List<Documentation>();
            interactiveNavigatorHelpDocuments.Add(new Documentation() { Content = "DateTime Range Navigator API Reference", Uri = new Uri("https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.SfDateTimeRangeNavigator.html") });
            interactiveNavigatorHelpDocuments.Add(new Documentation() { Content = "DateTime Range Navigator Documentation", Uri = new Uri("https://help.syncfusion.com/wpf/range-selector/getting-started") });
            interactiveNavigatorDemo.Documentations = interactiveNavigatorHelpDocuments;
            this.Demos.Add(interactiveNavigatorDemo);
        }
    }
}