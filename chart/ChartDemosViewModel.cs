#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
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

            DemoInfo ColumnDemo = new DemoInfo() { SampleName = "Column", GroupName = "BASIC CHARTS", Description = "Column chart is one among the most common chart types that are being used. It uses vertical bar(s) to display different values of one or more items. Points from adjacent series are drawn as bars next to each other.", DemoViewType = typeof(ColumnChartDemo) };
            List<Documentation> ColumnChartHelpDocuments = new List<Documentation>();
            ColumnChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            ColumnChartHelpDocuments.Add(new Documentation() { Content = "Chart-Column and Bar", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/columnandbar#column-chart") });
            ColumnDemo.Documentations = ColumnChartHelpDocuments;
            this.Demos.Add(ColumnDemo);

            DemoInfo BarDemo = new DemoInfo() { SampleName = "Bar", GroupName = "BASIC CHARTS", Description = "Bar chart is the simplest and one of the most versatile statistical diagrams. It displays horizontal bar(s) for each points in the series and points from adjacent series are drawn as bars next to each other, similar to Column chart.", DemoViewType = typeof(BarChartDemo) };
            List<Documentation> BarChartHelpDocuments = new List<Documentation>();
            BarChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            BarChartHelpDocuments.Add(new Documentation() { Content = "Chart-Column and Bar", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/columnandbar#bar-chart") });
            BarDemo.Documentations = BarChartHelpDocuments;
            this.Demos.Add(BarDemo);

            DemoInfo AreaDemo = new DemoInfo() { SampleName = "Area", GroupName = "BASIC CHARTS", Description = "Area chart connects the Y-points using straight lines and forms an area covered by the above lines and X-axis. This area is then shaded with a specified color or gradient.", DemoViewType = typeof(AreaChartDemo) };
            List<Documentation> AreaChartHelpDocuments = new List<Documentation>();
            AreaChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            AreaChartHelpDocuments.Add(new Documentation() { Content = "Chart-Area charts", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/area#area-chart") });
            AreaDemo.Documentations = AreaChartHelpDocuments;
            this.Demos.Add(AreaDemo);

            DemoInfo BubbleDemo = new DemoInfo() { SampleName = "Bubble", GroupName = "BASIC CHARTS", Description = "Bubble chart is an extension of the Scatter chart (or XY-chart) where each data point is represented by a circle. But here the circle size determined based on Size property. Consequently, bubble charts allow three-variable comparisons for easy visualization of complex interdependencies that are not apparent in two-variable charts.", DemoViewType = typeof(BubbleChartDemo) };
            List<Documentation> BubbleChartHelpDocuments = new List<Documentation>();
            BubbleChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            BubbleChartHelpDocuments.Add(new Documentation() { Content = "Chart-Bubble and Scatter", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/bubbleandscatter#bubble-chart") });
            BubbleDemo.Documentations = BubbleChartHelpDocuments;
            this.Demos.Add(BubbleDemo);

            DemoInfo ScatterDemo = new DemoInfo() { SampleName = "Scatter", GroupName = "BASIC CHARTS", Description = "Scatter chart displays the relationships between the two set of data. It represents each data point as circle with fixed dimension.", DemoViewType = typeof(ScatterChartDemo) };
            List<Documentation> ScatterChartHelpDocuments = new List<Documentation>();
            ScatterChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            ScatterChartHelpDocuments.Add(new Documentation() { Content = "Chart-Bubble and Scatter", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/bubbleandscatter#scatter-chart") });
            ScatterDemo.Documentations = ScatterChartHelpDocuments;
            this.Demos.Add(ScatterDemo);

            DemoInfo LineDemo = new DemoInfo() { SampleName = "Line", GroupName = "BASIC CHARTS", Description = "Line chart is very simple statistical diagram and widely used chart type. They are ideal for representing time-series data and displaying trends in data at equal intervals.", DemoViewType = typeof(LineChartDemo) };
            List<Documentation> LineChartHelpDocuments = new List<Documentation>();
            LineChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            LineChartHelpDocuments.Add(new Documentation() { Content = "Chart-Line and StepLine", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/lineandstepline#line-chart") });
            LineDemo.Documentations = LineChartHelpDocuments;
            this.Demos.Add(LineDemo);

            DemoInfo SplineDemo = new DemoInfo() { SampleName = "Spline", GroupName = "BASIC CHARTS", Description = "Spline chart is similar to line chart except that it connects the two data points using curves instead of straight lines.", DemoViewType = typeof(SplineChartDemo) };
            List<Documentation> SplineChartHelpDocuments = new List<Documentation>();
            SplineChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            SplineChartHelpDocuments.Add(new Documentation() { Content = "Chart-Spline charts", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/spline#spline-chart") });
            SplineDemo.Documentations = SplineChartHelpDocuments;
            this.Demos.Add(SplineDemo);

            DemoInfo RangeAreaDemo = new DemoInfo() { SampleName = "Range Area", GroupName = "BASIC CHARTS", Description = "This chart is a variation of area chart type that lets you plot bands of data in a chart, like Bollinger bands, weather patterns, etc. Here each point is having two Y-values, the lower and higher end of the band.", DemoViewType = typeof(RangeAreaChartDemo) };
            List<Documentation> RangeAreaChartHelpDocuments = new List<Documentation>();
            RangeAreaChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            RangeAreaChartHelpDocuments.Add(new Documentation() { Content = "Chart-Range charts", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/range#range-area-chart") });
            RangeAreaDemo.Documentations = RangeAreaChartHelpDocuments;
            this.Demos.Add(RangeAreaDemo);

            DemoInfo RangeColumnDemo = new DemoInfo() { SampleName = "Range Column", GroupName = "BASIC CHARTS", Description = "Range Column is similar to the column chart type except that each bar(s) are rendered over a range. Therefore the user must specify the y-axis starting and ending values for each point like range area.", DemoViewType = typeof(RangeColumnChartDemo) };
            List<Documentation> RangeColumnChartHelpDocuments = new List<Documentation>();
            RangeColumnChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            RangeColumnChartHelpDocuments.Add(new Documentation() { Content = "Chart-Range charts", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/range#range-column-chart") });
            RangeColumnDemo.Documentations = RangeColumnChartHelpDocuments;
            this.Demos.Add(RangeColumnDemo);

            DemoInfo SplineAreaDemo = new DemoInfo() { SampleName = "Spline Area", GroupName = "BASIC CHARTS", Description = "Spline Area is similar to an area chart type with the only difference, being the way in which the points of a series are connected. It connects each series of points by a smooth spline curve.", DemoViewType = typeof(SplineAreaChartDemo) };
            List<Documentation> SplineAreaChartHelpDocuments = new List<Documentation>();
            SplineAreaChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            SplineAreaChartHelpDocuments.Add(new Documentation() { Content = "Chart-Spline charts", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/spline#spline-area-chart") });
            SplineAreaDemo.Documentations = SplineAreaChartHelpDocuments;
            this.Demos.Add(SplineAreaDemo);

            DemoInfo SplineRangeAreaDemo = new DemoInfo() { SampleName = "Spline Range Area", GroupName = "BASIC CHARTS", Description = "This chart is a variation of area chart type that lets you plot bands of data in a chart, like Bollinger bands, weather patterns, etc. Here each point is having two Y-values, the lower and higher end of the band.", DemoViewType = typeof(SplineRangeAreaChartDemo) };
            List<Documentation> SplineRangeAreaHelpDocuments = new List<Documentation>();
            SplineRangeAreaHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            SplineRangeAreaHelpDocuments.Add(new Documentation() { Content = "Chart-Range charts", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/range#spline-range-area-chart") });
            SplineRangeAreaDemo.Documentations = SplineRangeAreaHelpDocuments;
            this.Demos.Add(SplineRangeAreaDemo);

            DemoInfo StepAreaDemo = new DemoInfo() { SampleName = "Step Area", GroupName = "BASIC CHARTS", Description = "Step Area also comes under area type charts but it is similar to regular area chart except that instead of a straight line tracing the shortest path between points, the values are connected by continuous vertical and horizontal line(s) forming a step like progression.", DemoViewType = typeof(StepAreaChartDemo) };
            List<Documentation> StepAreaChartHelpDocuments = new List<Documentation>();
            StepAreaChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            StepAreaChartHelpDocuments.Add(new Documentation() { Content = "Chart-Area charts", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/area#step-area-chart") });
            StepAreaDemo.Documentations = StepAreaChartHelpDocuments;
            this.Demos.Add(StepAreaDemo);

            DemoInfo StepLineDemo = new DemoInfo() { SampleName = "Step Line", GroupName = "BASIC CHARTS", Description = "Step line chart uses horizontal and vertical line(s) to connect data points resulting in a step like progression.", DemoViewType = typeof(StepLineChartDemo) };
            List<Documentation> StepLineChartHelpDocuments = new List<Documentation>();
            StepLineChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            StepLineChartHelpDocuments.Add(new Documentation() { Content = "Chart-Line and StepLine", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/lineandstepline#step-line-chart") });
            StepLineDemo.Documentations = StepLineChartHelpDocuments;
            this.Demos.Add(StepLineDemo);

            DemoInfo PieDemo = new DemoInfo() { SampleName = "Pie", GroupName = "CIRCULAR CHARTS", Description = "Pie chart is ideal for the display of proportionate values expressed in either percentage or fractional formats.", DemoViewType = typeof(PieChartDemo) };
            List<Documentation> PieChartHelpDocuments = new List<Documentation>();
            PieChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            PieChartHelpDocuments.Add(new Documentation() { Content = "Chart-Pie and Doughnut", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/pieanddoughnut#pie-chart") });
            PieDemo.Documentations = PieChartHelpDocuments;
            this.Demos.Add(PieDemo);

            DemoInfo DoughnutDemo = new DemoInfo() { SampleName = "Doughnut", GroupName = "CIRCULAR CHARTS", Description = "Doughnut chart is like pie chart with a hole and the value is specified as the doughnut coefficient. The Doughnut Chart is best suited for presenting data in proportions.", DemoViewType = typeof(DoughnutChartDemo) };
            List<Documentation> DoughnutChartHelpDocuments = new List<Documentation>();
            DoughnutChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            DoughnutChartHelpDocuments.Add(new Documentation() { Content = "Chart-Pie and Doughnut", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/pieanddoughnut#doughnut-chart") });
            DoughnutDemo.Documentations = DoughnutChartHelpDocuments;
            this.Demos.Add(DoughnutDemo);

            DemoInfo StackedDoughnutDemo = new DemoInfo() { SampleName = "Stacked Doughnut", GroupName = "CIRCULAR CHARTS", Description = " Stacked Doughnut chart is like pie chart with a hole and the value is specified as the doughnut coefficient. The Doughnut Chart is best suited for presenting data in proportions.", DemoViewType = typeof(StackedDoughnutDemo) };
            List<Documentation> StackedDoughnutDocuments = new List<Documentation>();
            StackedDoughnutDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            StackedDoughnutDocuments.Add(new Documentation() { Content = "Chart-Pie and Doughnut", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/pieanddoughnut#stacked-doughnut") });
            StackedDoughnutDemo.Documentations = StackedDoughnutDocuments;
            this.Demos.Add(StackedDoughnutDemo);

            DemoInfo HiLoDemo = new DemoInfo() { SampleName = "HiLo", GroupName = "FINANCIAL CHARTS", Description = "HiLo is a special kind of chart that is normally used in stock analysis. They are typically used to display error bars or the trading range of a stock for each period.", DemoViewType = typeof(HiLoChartDemo) };
            List<Documentation> HiLoChartHelpDocuments = new List<Documentation>();
            HiLoChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            HiLoChartHelpDocuments.Add(new Documentation() { Content = "Chart-Range charts", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/range#hilo-chart") });
            HiLoDemo.Documentations = HiLoChartHelpDocuments;
            this.Demos.Add(HiLoDemo);

            DemoInfo OHLCDemo = new DemoInfo() { SampleName = "OHLC", GroupName = "FINANCIAL CHARTS", Description = "OHLC is a special kind of chart that is normally used in stock analysis. This chart type represents the High, Low, Open and Close values of the stock.", DemoViewType = typeof(HiLoOpenCloseChartDemo) };
            List<Documentation> OHLCChartHelpDocuments = new List<Documentation>();
            OHLCChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            OHLCChartHelpDocuments.Add(new Documentation() { Content = "Chart-Financial charts", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/financial#ohlc-chart") });
            OHLCDemo.Documentations = OHLCChartHelpDocuments;
            this.Demos.Add(OHLCDemo);

            DemoInfo CandleDemo = new DemoInfo() { SampleName = "Candle", GroupName = "FINANCIAL CHARTS", Description = "Candle displays stock information using the High, Low, Open and Close values. The high and low values are represented by the wick of a candle. The candle represents open and close values.", DemoViewType = typeof(CandleChartDemo) };
            List<Documentation> CandleChartHelpDocuments = new List<Documentation>();
            CandleChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            CandleChartHelpDocuments.Add(new Documentation() { Content = "Chart-Finanacial charts", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/financial#candle-chart") });
            CandleDemo.Documentations = CandleChartHelpDocuments;
            this.Demos.Add(CandleDemo);

            DemoInfo PolarDemo = new DemoInfo() { SampleName = "Polar", GroupName = "POLAR AND RADAR CHARTS", Description = "Polar chart is a circular graph on which data is displayed in terms of values and angles. X-values define the angles at which the data points will be plotted. Y-value defines the distance of the data points from the center of the graph, with the center of the graph usually starting at 0.", DemoViewType = typeof(PolarChartDemo) };
            List<Documentation> PolarChartHelpDocuments = new List<Documentation>();
            PolarChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            PolarChartHelpDocuments.Add(new Documentation() { Content = "Chart-Polar and Radar", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/radarandpolar#polar-chart") });
            PolarDemo.Documentations = PolarChartHelpDocuments;
            this.Demos.Add(PolarDemo);

            DemoInfo RadarDemo = new DemoInfo() { SampleName = "Radar", GroupName = "POLAR AND RADAR CHARTS", Description = "Radar chart is a circular graph on which data is displayed in terms of values and angles. X-values define the angles at which the data points will be plotted. Y-value defines the distance of the data points from the center of the graph, with the center of the graph usually starting at 0.", DemoViewType = typeof(RadarChartDemo) };
            List<Documentation> RadarChartHelpDocuments = new List<Documentation>();
            RadarChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            RadarChartHelpDocuments.Add(new Documentation() { Content = "Chart-Polar and Radar", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/radarandpolar#radar-chart") });
            RadarDemo.Documentations = RadarChartHelpDocuments;
            this.Demos.Add(RadarDemo);

            DemoInfo StackedColumnDemo = new DemoInfo() { SampleName = "Column", GroupName = "STACKED CHARTS", Description = "Stacking Column is similar to regular Column charts except that the Y-values stack on top of each other in the order of the series specified. This helps visualize the relationship of parts to the whole.", DemoViewType = typeof(StackingColumnChartDemo) };
            List<Documentation> StackedColumnHelpDocuments = new List<Documentation>();
            StackedColumnHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            StackedColumnHelpDocuments.Add(new Documentation() { Content = "Chart-Stacked charts", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/stacking#stacked-column-chart") });
            StackedColumnDemo.Documentations = StackedColumnHelpDocuments;
            this.Demos.Add(StackedColumnDemo);

            DemoInfo StackedBarDemo = new DemoInfo() { SampleName = "Bar", GroupName = "STACKED CHARTS", Description = "Stacking Bar is similar to regular bar charts except that the data points are stacked on top of each other in the specified series order. This helps visualize the relationship of parts to the whole.", DemoViewType = typeof(StackingBarChartDemo) };
            List<Documentation> StackedBarHelpDocuments = new List<Documentation>();
            StackedBarHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            StackedBarHelpDocuments.Add(new Documentation() { Content = "Chart-Stacked charts", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/stacking#stacked-bar-chart") });
            StackedBarDemo.Documentations = StackedBarHelpDocuments;
            this.Demos.Add(StackedBarDemo);

            DemoInfo StackedAreaDemo = new DemoInfo() { SampleName = "Area", GroupName = "STACKED CHARTS", Description = "Stacked Area is similar to regular area charts except that the data points are stacked on top of each other in the order of the series specified. This helps to visualize the relationship of parts to the whole.", DemoViewType = typeof(StackingAreaChartDemo) };
            List<Documentation> StackedAreaHelpDocuments = new List<Documentation>();
            StackedAreaHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            StackedAreaHelpDocuments.Add(new Documentation() { Content = "Chart-Stacked charts", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/stacking#stacked-area-chart") });
            StackedAreaDemo.Documentations = StackedAreaHelpDocuments;
            this.Demos.Add(StackedAreaDemo);

            DemoInfo StackedLineDemo = new DemoInfo() { SampleName = "Line", GroupName = "STACKED CHARTS", Description = "Stacked Line is similar to regular line charts except that the data points are stacked on top of each other in the order of the series specified. This helps to visualize the relationship of parts to the whole.", DemoViewType = typeof(StackingLineChartDemo) };
            List<Documentation> StackedLineHelpDocuments = new List<Documentation>();
            StackedLineHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            StackedLineHelpDocuments.Add(new Documentation() { Content = "Chart-Stacked charts", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/stacking#stacked-line-chart") });
            StackedLineDemo.Documentations = StackedLineHelpDocuments;
            this.Demos.Add(StackedLineDemo);

            DemoInfo GroupingDemo = new DemoInfo() { SampleName = "Grouping", GroupName = "STACKED CHARTS", Description = "Stacking series can be grouped based on any category to visualize the comparative relationship of parts to the whole.", DemoViewType = typeof(StackedGroupChartDemo) };
            List<Documentation> GroupingHelpDocuments = new List<Documentation>();
            GroupingHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            GroupingHelpDocuments.Add(new Documentation() { Content = "Chart-Grouping Stacked charts", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/groupingstacked") });
            GroupingDemo.Documentations = GroupingHelpDocuments;
            this.Demos.Add(GroupingDemo);

            DemoInfo StackedColumn100Demo = new DemoInfo() { SampleName = "Column", GroupName = "100% STACKED CHARTS", Description = "100% Stacking column charts are similar to regular column charts except that the Y-values stack on top of each other in the specified series order. This helps visualize the relationship of parts to the whole in terms of percentage.", DemoViewType = typeof(StackingColumn100ChartDemo) };
            List<Documentation> StackedColumn100HelpDocuments = new List<Documentation>();
            StackedColumn100HelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            StackedColumn100HelpDocuments.Add(new Documentation() { Content = "Chart-Stacked 100 charts", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/stacking#stacked-column100-chart") });
            StackedColumn100Demo.Documentations = StackedColumn100HelpDocuments;
            this.Demos.Add(StackedColumn100Demo);

            DemoInfo StackedBar100Demo = new DemoInfo() { SampleName = "Bar", GroupName = "100% STACKED CHARTS", Description = "100% Stacking bar charts are similar to regular bar charts except that the Y-values stack on top of each other in the specified series order. This helps visualize the relationship of parts to the whole in terms of percentage.", DemoViewType = typeof(StackingBar100ChartDemo) };
            List<Documentation> StackedBar100HelpDocuments = new List<Documentation>();
            StackedBar100HelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            StackedBar100HelpDocuments.Add(new Documentation() { Content = "Chart-Stacked 100 charts", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/stacking#stacked-bar100-chart") });
            StackedBar100Demo.Documentations = StackedBar100HelpDocuments;
            this.Demos.Add(StackedBar100Demo);

            DemoInfo StackedArea100Demo = new DemoInfo() { SampleName = "Area", GroupName = "100% STACKED CHARTS", Description = "100% Stacking area charts are similar to regular area charts except that the Y-values stack on top of each other in the specified series order. This helps visualize the relationship of parts to the whole in terms of percentage.", DemoViewType = typeof(StackingArea100ChartDemo) };
            List<Documentation> StackedArea100HelpDocuments = new List<Documentation>();
            StackedArea100HelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            StackedArea100HelpDocuments.Add(new Documentation() { Content = "Chart-Stacked 100 charts", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/stacking#stacked-area100-chart") });
            StackedArea100Demo.Documentations = StackedArea100HelpDocuments;
            this.Demos.Add(StackedArea100Demo);

            DemoInfo StackedLine100Demo = new DemoInfo() { SampleName = "Line", GroupName = "100% STACKED CHARTS", Description = "100% Stacking line charts are similar to regular line charts except that the Y-values stack on top of each other in the specified series order. This helps visualize the relationship of parts to the whole in terms of percentage.", DemoViewType = typeof(StackingLine100Chart) };
            List<Documentation> StackedLine100HelpDocuments = new List<Documentation>();
            StackedLine100HelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            StackedLine100HelpDocuments.Add(new Documentation() { Content = "Chart-Stacked 100 charts", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/stacking#stacked-line100-chart") });
            StackedLine100Demo.Documentations = StackedLine100HelpDocuments;
            this.Demos.Add(StackedLine100Demo);

            DemoInfo FunnelDemo = new DemoInfo() { SampleName = "Funnel", GroupName = "OTHER CHARTS", Description = "Funnel chart is a single series chart representing the data as portions of 100%, and this chart does not use any axes.", DemoViewType = typeof(FunnelChartDemo) };
            List<Documentation> FunnelChartHelpDocuments = new List<Documentation>();
            FunnelChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            FunnelChartHelpDocuments.Add(new Documentation() { Content = "Chart-Funnel and Pyramid", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/funnelandpyramid#funnel-chart") });
            FunnelDemo.Documentations = FunnelChartHelpDocuments;
            this.Demos.Add(FunnelDemo);

            DemoInfo PyramidDemo = new DemoInfo() { SampleName = "Pyramid", GroupName = "OTHER CHARTS", Description = "Pyramid chart is similar to the funnel chart. It is often used for geographical purposes. The Pyramid Chart type displays the data which when totaled will be 100%. This type of chart is a single series chart representing the data as portions of 100%, and this chart does not use any axes.", DemoViewType = typeof(PyramidChartDemo) };
            List<Documentation> PyramidChartHelpDocuments = new List<Documentation>();
            PyramidChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            PyramidChartHelpDocuments.Add(new Documentation() { Content = "Chart-Funnel and Pyramid", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/funnelandpyramid#pyramid-chart") });
            PyramidDemo.Documentations = PyramidChartHelpDocuments;
            this.Demos.Add(PyramidDemo);

            DemoInfo HistogramDemo = new DemoInfo() { SampleName = "Histogram", GroupName = "OTHER CHARTS", Description = "Histogram chart is a collection of vertical columns drawn continuously at finite intervals. Each column in the series represents the frequency of an output factor value measured during a specific finite interval.", DemoViewType = typeof(HistogramChartDemo) };
            List<Documentation> HistogramChartHelpDocuments = new List<Documentation>();
            HistogramChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            HistogramChartHelpDocuments.Add(new Documentation() { Content = "Chart-Histogram chart", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/distribution") });
            HistogramDemo.Documentations = HistogramChartHelpDocuments;
            this.Demos.Add(HistogramDemo);

            DemoInfo BoxAndWhiskerDemo = new DemoInfo() { SampleName = "Box and Whisker", GroupName = "OTHER CHARTS", Description = "Box And Whisker Chart is one among the most common chart types that are being used. It uses vertical bar(s) to display mainly five ranges of dispersed values. Points from adjacent series are drawn as box rectange next to each other.", DemoViewType = typeof(BoxAndWhiskerChartDemo) };
            List<Documentation> BoxAndWhiskerHelpDocuments = new List<Documentation>();
            BoxAndWhiskerHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            BoxAndWhiskerHelpDocuments.Add(new Documentation() { Content = "Chart-Other charts", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/other#box-and-whisker-chart") });
            BoxAndWhiskerDemo.Documentations = BoxAndWhiskerHelpDocuments;
            this.Demos.Add(BoxAndWhiskerDemo);

            DemoInfo WaterfallDemo = new DemoInfo() { SampleName = "Waterfall", GroupName = "OTHER CHARTS", Description = "Waterfall chart is helpful in understanding the cumulative effect of sequentially introduced positive and negative values.", DemoViewType = typeof(WaterfallChartDemo) };
            List<Documentation> WaterfallChartHelpDocuments = new List<Documentation>();
            WaterfallChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            WaterfallChartHelpDocuments.Add(new Documentation() { Content = "Chart-Other charts", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/other#waterfall-chart") });
            WaterfallDemo.Documentations = WaterfallChartHelpDocuments;
            this.Demos.Add(WaterfallDemo);

            DemoInfo FastColumnDemo = new DemoInfo() { SampleName = "Column", GroupName = "FAST CHARTS", Description = "Column chart type is a raster implementation of the regular column chart that has much better performance. It can be used to render large number of data points very quickly.", DemoViewType = typeof(FastColumnChartDemo) };
            List<Documentation> FastColumnHelpDocuments = new List<Documentation>();
            FastColumnHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            FastColumnHelpDocuments.Add(new Documentation() { Content = "Chart-Fast Bitmap series", Uri = new Uri("https://help.syncfusion.com/wpf/charts/fastchart/fast-bitmapseries#fast-column-bitmap") });
            FastColumnDemo.Documentations = FastColumnHelpDocuments;
            this.Demos.Add(FastColumnDemo);

            DemoInfo FastBarDemo = new DemoInfo() { SampleName = "Bar", GroupName = "FAST CHARTS", Description = "Bar chart type is a raster implementation of the regular bar chart that has much better performance. It can be used to render large number of data points very quickly.", DemoViewType = typeof(FastBarChartDemo) };
            List<Documentation> FastBarChartHelpDocuments = new List<Documentation>();
            FastBarChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            FastBarChartHelpDocuments.Add(new Documentation() { Content = "Chart-Fast Bitmap series", Uri = new Uri("https://help.syncfusion.com/wpf/charts/fastchart/fast-bitmapseries#fast-bar-bitmap") });
            FastBarDemo.Documentations = FastBarChartHelpDocuments;
            this.Demos.Add(FastBarDemo);

            DemoInfo FastLineDemo = new DemoInfo() { SampleName = "Line", GroupName = "FAST CHARTS", Description = "Line chart type is a raster implementation of the regular Line chart that has much better performance. It can be used to render large number of data points very quickly. It is widely used chart type for high performance requirement.", DemoViewType = typeof(FastLineChartDemo) };
            List<Documentation> FastLineChartHelpDocuments = new List<Documentation>();
            FastLineChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            FastLineChartHelpDocuments.Add(new Documentation() { Content = "Chart-Fast Bitmap series", Uri = new Uri("https://help.syncfusion.com/wpf/charts/fastchart/fast-bitmapseries#fast-line-bitmap") });
            FastLineDemo.Documentations = FastLineChartHelpDocuments;
            this.Demos.Add(FastLineDemo);

            DemoInfo FastStepLineDemo = new DemoInfo() { SampleName = "Step Line", GroupName = "FAST CHARTS", Description = "Step Line is a raster implementation of the regular step line chart with better performance. It can be used to render large number of data points very quickly.", DemoViewType = typeof(FastStepLineChartDemo) };
            List<Documentation> FastStepLineHelpDocuments = new List<Documentation>();
            FastStepLineHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            FastStepLineHelpDocuments.Add(new Documentation() { Content = "Chart-Fast Bitmap series", Uri = new Uri("https://help.syncfusion.com/wpf/charts/fastchart/fast-bitmapseries#fast-step-line-bitmap") });
            FastStepLineDemo.Documentations = FastStepLineHelpDocuments;
            this.Demos.Add(FastStepLineDemo);

            DemoInfo FastScatterDemo = new DemoInfo() { SampleName = "Scatter", GroupName = "FAST CHARTS", Description = "Scatter chart type is a raster implementation of the regular scatter chart that has much better performance. It can be used to render large number of data points very quickly.", DemoViewType = typeof(FastScatterChartDemo) };
            List<Documentation> FastScattertHelpDocuments = new List<Documentation>();
            FastScattertHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            FastScattertHelpDocuments.Add(new Documentation() { Content = "Chart-Fast Bitmap series", Uri = new Uri("https://help.syncfusion.com/wpf/charts/fastchart/fast-bitmapseries#fast-scatter-bitmap") });
            FastScatterDemo.Documentations = FastScattertHelpDocuments;
            this.Demos.Add(FastScatterDemo);

            DemoInfo FastRangeAreaDemo = new DemoInfo() { SampleName = "Range Area", GroupName = "FAST CHARTS", Description = "Range area chart type is a raster implementation of the regular range area chart that has much better performance. It can be used to render large number of data points very quickly.", DemoViewType = typeof(FastRangeAreaChartDemo) };
            List<Documentation> FastRangeAreaHelpDocuments = new List<Documentation>();
            FastRangeAreaHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            FastRangeAreaHelpDocuments.Add(new Documentation() { Content = "Chart-Fast Bitmap series", Uri = new Uri("https://help.syncfusion.com/wpf/charts/fastchart/fast-bitmapseries#fast-range-area") });
            FastRangeAreaDemo.Documentations = FastRangeAreaHelpDocuments;
            this.Demos.Add(FastRangeAreaDemo);

            DemoInfo FastStackedColumnDemo = new DemoInfo() { SampleName = "Stacked Column", GroupName = "FAST CHARTS", Description = "Stacked Column is a raster implementation of the regular stacking column chart that has much better performance. It can be used to render large number of data points very quickly.", DemoViewType = typeof(FastStackingColumnChartDemo) };
            List<Documentation> FastStackedColumnHelpDocuments = new List<Documentation>();
            FastStackedColumnHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            FastStackedColumnHelpDocuments.Add(new Documentation() { Content = "Chart-Fast Bitmap series", Uri = new Uri("https://help.syncfusion.com/wpf/charts/fastchart/fast-series#fast-stacking-column") });
            FastStackedColumnDemo.Documentations = FastStackedColumnHelpDocuments;
            this.Demos.Add(FastStackedColumnDemo);

            DemoInfo FastHiLoDemo = new DemoInfo() { SampleName = "HiLo", GroupName = "FAST CHARTS", Description = "HiLo chart type is a raster implementation of the regular HiLo chart that has much better performance. It can be used to render large number of data points very quickly.", DemoViewType = typeof(FastHiloChartDemo) };
            List<Documentation> FastHiLoHelpDocuments = new List<Documentation>();
            FastHiLoHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            FastHiLoHelpDocuments.Add(new Documentation() { Content = "Chart-Fast Bitmap series", Uri = new Uri("https://help.syncfusion.com/wpf/charts/fastchart/fast-bitmapseries#fast-hilo-bitmap") });
            FastHiLoDemo.Documentations = FastHiLoHelpDocuments;
            this.Demos.Add(FastHiLoDemo);
 
            DemoInfo FastOHLCDemo = new DemoInfo() { SampleName = "OHLC", GroupName = "FAST CHARTS", Description = "OHLC is a raster implementation of the regular financial chart with high, low, open and close values with better performance. It can be used to render large number of data points very quickly.", DemoViewType = typeof(FastHiloOpenCloseChartDemo) };
            List<Documentation> FastOHLCHelpDocuments = new List<Documentation>();
            FastOHLCHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            FastOHLCHelpDocuments.Add(new Documentation() { Content = "Chart-Fast Bitmap series", Uri = new Uri("https://help.syncfusion.com/wpf/charts/fastchart/fast-bitmapseries#fast-ohlc-bitmap") });
            FastOHLCDemo.Documentations = FastOHLCHelpDocuments;
            this.Demos.Add(FastOHLCDemo);

            DemoInfo FastCandleDemo = new DemoInfo() { SampleName = "Candle", GroupName = "FAST CHARTS", Description = "Candle chart is a raster implementation of the regular candle chart that has much better performance. It can be used to render large number of data points very quickly.", DemoViewType = typeof(FastCandleChartDemo) };
            List<Documentation> FastCandleHelpDocuments = new List<Documentation>();
            FastCandleHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            FastCandleHelpDocuments.Add(new Documentation() { Content = "Chart-Fast Bitmap series", Uri = new Uri("https://help.syncfusion.com/wpf/charts/fastchart/fast-bitmapseries#fast-candle-bitmap") });
            FastCandleDemo.Documentations = FastCandleHelpDocuments;
            this.Demos.Add(FastCandleDemo);

            DemoInfo CustomSeriesDemo = new DemoInfo() { SampleName = "Series Template", GroupName = "SERIES CUSTOMIZATION", Description = "The default template of the series can be customized to any other shape using CustomTemplate property.", DemoViewType = typeof(CustomSeriesDemo) };
            List<Documentation> CustomSeriesHelpDocuments = new List<Documentation>();
            CustomSeriesHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            CustomSeriesHelpDocuments.Add(new Documentation() { Content = "Chart-Custom chart", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/custom") });
            CustomSeriesDemo.Documentations = CustomSeriesHelpDocuments;
            this.Demos.Add(CustomSeriesDemo);

            DemoInfo EmptyPointsDemo = new DemoInfo() { SampleName = "Empty Values", GroupName = "SERIES CUSTOMIZATION", Description = "Empty values are unavoidable with real time values and we can handle these values (double.NaN) in SfChart. This sample demonstrates handlings of empty points in the chart.", DemoViewType = typeof(EmptyPointSupportDemo) };
            List<Documentation> EmptyPointsHelpDocuments = new List<Documentation>();
            EmptyPointsHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            EmptyPointsHelpDocuments.Add(new Documentation() { Content = "Chart-Empty Points", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/emptypoints") });
            EmptyPointsDemo.Documentations = EmptyPointsHelpDocuments;
            this.Demos.Add(EmptyPointsDemo);

            DemoInfo AxisTypesDemo = new DemoInfo() { SampleName = "Axis Type", GroupName = "AXIS", Description = "Axis type helps plotting data in different scale.", DemoViewType = typeof(AxisDemo) };
            List<Documentation> AxisTypesHelpDocuments = new List<Documentation>();
            AxisTypesHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            AxisTypesHelpDocuments.Add(new Documentation() { Content = "Chart-Axis Types", Uri = new Uri("https://help.syncfusion.com/wpf/charts/axis#types-of-axis") });
            AxisTypesDemo.Documentations = AxisTypesHelpDocuments;
            this.Demos.Add(AxisTypesDemo);

            DemoInfo CustomAxisDemo = new DemoInfo() { SampleName = "Axis Customization", GroupName = "AXIS", Description = "This sample demonstrates SfChart axis and its customization options.", DemoViewType = typeof(AxisConfigurationDemo) };
            List<Documentation> CustomAxisHelpDocuments = new List<Documentation>();
            CustomAxisHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            CustomAxisHelpDocuments.Add(new Documentation() { Content = "Chart-Axis Customization", Uri = new Uri("https://help.syncfusion.com/wpf/charts/axis#customize-individual-axis-elements") });
            CustomAxisDemo.Documentations = CustomAxisHelpDocuments;
            this.Demos.Add(CustomAxisDemo);

            DemoInfo AxisLabelIntersectionDemo = new DemoInfo() { SampleName = "Labels Intersection", GroupName = "AXIS", Description = "This sample demonstrates axis label positionings when the labels are intersected.", DemoViewType = typeof(LabelsIntersectionDemo) };
            List<Documentation> LabelIntersectionHelpDocuments = new List<Documentation>();
            LabelIntersectionHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            LabelIntersectionHelpDocuments.Add(new Documentation() { Content = "Chart-Multiple Rows", Uri = new Uri("https://help.syncfusion.com/wpf/charts/axis#axis-labels") });
            AxisLabelIntersectionDemo.Documentations = LabelIntersectionHelpDocuments;
            this.Demos.Add(AxisLabelIntersectionDemo);

            DemoInfo FlexibleChartAxisDemo = new DemoInfo() { SampleName = "Flexible Axis", GroupName = "AXIS", Description = "This sample demonstrates how to make flexible axis layout and share with multiple series.", DemoViewType = typeof(FlexibleAxisDemo) };
            List<Documentation> FlexibleAxisHelpDocuments = new List<Documentation>();
            FlexibleAxisHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            FlexibleAxisHelpDocuments.Add(new Documentation() { Content = "Chart-Multiple Axes", Uri = new Uri("https://help.syncfusion.com/wpf/charts/axis#multiple-axes") });
            FlexibleChartAxisDemo.Documentations = FlexibleAxisHelpDocuments;
            this.Demos.Add(FlexibleChartAxisDemo);

            DemoInfo AutoScrollingDemo = new DemoInfo() { SampleName = "Auto Scrolling", GroupName = "AXIS", ShowBusyIndicator = false, Description = "This sample demonstrates the automatic scrolling of axis during real time update.", DemoViewType = typeof(ChartAutoScrollingDemo) };
            List<Documentation> AutoScrollingHelpDocuments = new List<Documentation>();
            AutoScrollingHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            AutoScrollingHelpDocuments.Add(new Documentation() { Content = "Chart-Auto Scrolling Delta", Uri = new Uri("https://help.syncfusion.com/wpf/charts/axis#autoscrollingdelta") });
            AutoScrollingDemo.Documentations = AutoScrollingHelpDocuments;
            this.Demos.Add(AutoScrollingDemo);

            DemoInfo AxisScaleBreakDemo = new DemoInfo() { SampleName = "ScaleBreak", GroupName = "AXIS", Description = "This sample demonstrates scale breaks in SfChart.", DemoViewType = typeof(ScaleBreakDemo) };
            List<Documentation> ScaleBreakHelpDocuments = new List<Documentation>();
            ScaleBreakHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            ScaleBreakHelpDocuments.Add(new Documentation() { Content = "Chart-Scale Breaks", Uri = new Uri("https://help.syncfusion.com/wpf/charts/scalebreaks") });
            AxisScaleBreakDemo.Documentations = ScaleBreakHelpDocuments;
            this.Demos.Add(AxisScaleBreakDemo);

            DemoInfo MultiLevelLabelDemo = new DemoInfo() { SampleName = "Multi Level Labels", GroupName = "AXIS", Description = "This sample demonstrates multi level labels support for chart axis.", DemoViewType = typeof(MultiLevelLabelsDemo) };
            List<Documentation> MultiLevelLabelHelpDocuments = new List<Documentation>();
            MultiLevelLabelHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            MultiLevelLabelHelpDocuments.Add(new Documentation() { Content = "Chart-Multi Level Labels", Uri = new Uri("https://help.syncfusion.com/wpf/charts/axis#multi-level-labels") });
            MultiLevelLabelDemo.Documentations = MultiLevelLabelHelpDocuments;
            this.Demos.Add(MultiLevelLabelDemo);

            DemoInfo MVVMPatternDemo = new DemoInfo() { SampleName = "MVVM Pattern", GroupName = "DATA BINDING", Description = "This sample demonstrates the data binding of chart in MVVM pattern.", DemoViewType = typeof(MVVMBindingDemo) };
            List<Documentation> MVVMBindingHelpDocuments = new List<Documentation>();
            MVVMBindingHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            MVVMBindingHelpDocuments.Add(new Documentation() { Content = "Chart-MVVM Databinding", Uri = new Uri("https://help.syncfusion.com/wpf/charts/databinding") });
            MVVMPatternDemo.Documentations = MVVMBindingHelpDocuments;
            this.Demos.Add(MVVMPatternDemo);

            DemoInfo DataTableDemo = new DemoInfo() { SampleName = "DataTable Binding", GroupName = "DATA BINDING", Description = "This sample demonstrates the data binding of chart with the DataTable.", DemoViewType = typeof(DataTableBindingDemo) };
            List<Documentation> DataTableBindingHelpDocuments = new List<Documentation>();
            DataTableBindingHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            DataTableBindingHelpDocuments.Add(new Documentation() { Content = "Chart-DataTabel Binding", Uri = new Uri("https://support.syncfusion.com/kb/article/5196/how-to-bind-data-table-in-wpf-chart-sfchart") });
            DataTableDemo.Documentations = DataTableBindingHelpDocuments;
            this.Demos.Add(DataTableDemo);

            DemoInfo DataGridBindingDemo = new DemoInfo() { SampleName = "Chart Grid Binding", GroupName = "DATA BINDING", Description = "This sample demonstrates the binding of data between SfChart and SfDataGrid.", DemoViewType = typeof(ChartDataEditingDemo) };
            List<Documentation> DataGridBindingHelpDocuments = new List<Documentation>();
            DataGridBindingHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            DataGridBindingHelpDocuments.Add(new Documentation() { Content = "Chart-Datagrid Binding", Uri = new Uri("https://support.syncfusion.com/kb/article/3753/how-to-synchronize-the-selection-between-wpf-chart-sfchart-and-datagrid") });
            DataGridBindingDemo.Documentations = DataGridBindingHelpDocuments;
            this.Demos.Add(DataGridBindingDemo);

            DemoInfo DataEditingDemo = new DemoInfo() { SampleName = "Data Editing", GroupName = "DATA EDITING", Description = "Visual Data Editing allows you to edit an entire series or a single data point dynamically by interacting directly with the chart series, by dragging.", DemoViewType = typeof(VisualDataEditingDemo) };
            List<Documentation> ChartDataEditingHelpDocuments = new List<Documentation>();
            ChartDataEditingHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            ChartDataEditingHelpDocuments.Add(new Documentation() { Content = "Chart-Data Editing", Uri = new Uri("https://help.syncfusion.com/wpf/charts/interactive-features/visual-data-editing") });
            DataEditingDemo.Documentations = ChartDataEditingHelpDocuments;
            this.Demos.Add(DataEditingDemo);

            DemoInfo ScatterChartEditingDemo = new DemoInfo() { SampleName = "Scatter Data Editing", GroupName = "DATA EDITING", Description = "Scatter Series Data Editing allows you to edit a single data point dynamically by interacting directly with the chart series, by dragging in x and y co-ordinates.", DemoViewType = typeof(ScatterDataEditingDemo) };
            List<Documentation> ScatterChartEditingHelpDocuments = new List<Documentation>();
            ScatterChartEditingHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            ScatterChartEditingHelpDocuments.Add(new Documentation() { Content = "Chart-Scatter DataEditing", Uri = new Uri("https://help.syncfusion.com/wpf/charts/interactive-features/visual-data-editing#segment-dragging") });
            ScatterChartEditingDemo.Documentations = ScatterChartEditingHelpDocuments;
            this.Demos.Add(ScatterChartEditingDemo);

            DemoInfo AnnotationTooltipDemo = new DemoInfo() { SampleName = "Tooltip", GroupName = "ANNOTATIONS", Description = "This sample demonstrates the tooltip usage in annotations.", DemoViewType = typeof(AnnotationToolTip) };
            List<Documentation> AnnotationTooltipHelpDocuments = new List<Documentation>();
            AnnotationTooltipHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            AnnotationTooltipHelpDocuments.Add(new Documentation() { Content = "Chart-Annotation Tooltip", Uri = new Uri("https://help.syncfusion.com/wpf/charts/annotations#tooltip") });
            AnnotationTooltipDemo.Documentations = AnnotationTooltipHelpDocuments;
            this.Demos.Add(AnnotationTooltipDemo);

            DemoInfo InteractiveAnnotationDemo = new DemoInfo() { SampleName = "Interactivity", GroupName = "ANNOTATIONS", Description = "This sample demonstrates how the user can interact with the annotations by resizing and dragging the annotation to different points at run time.", DemoViewType = typeof(AnnotationInteractionDemo) };
            List<Documentation> AnnotationInteractionHelpDocuments = new List<Documentation>();
            AnnotationInteractionHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            AnnotationInteractionHelpDocuments.Add(new Documentation() { Content = "Chart-Interaction", Uri = new Uri("https://help.syncfusion.com/wpf/charts/annotations#interaction") });
            InteractiveAnnotationDemo.Documentations = AnnotationInteractionHelpDocuments;
            this.Demos.Add(InteractiveAnnotationDemo);

            DemoInfo VerticalChartDemo = new DemoInfo() { SampleName = "Vertical Chart", GroupName = "VERTICAL CHART", ShowBusyIndicator = false, Description = "Vertical chart is like normal chart except that the axis and series area are rotated to 90 degree.", DemoViewType = typeof(VerticalChartDemo) };
            List<Documentation> VerticalChartHelpDocuments = new List<Documentation>();
            VerticalChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            VerticalChartHelpDocuments.Add(new Documentation() { Content = "Chart-Vertical chart", Uri = new Uri("https://help.syncfusion.com/wpf/charts/vertical-charts") });
            VerticalChartDemo.Documentations = VerticalChartHelpDocuments;
            this.Demos.Add(VerticalChartDemo);

            DemoInfo StripLineDemo = new DemoInfo() { SampleName = "Strip Lines", GroupName = "STRIP LINES", Description = "Striplines are used to highlight data and are drawn at the background of a chart. They can be horizontal or vertical, and also be made to optionally repeat at specific intervals (for example, to indicate weekends every seven days).", DemoViewType = typeof(StripLineDemo) };
            List<Documentation> StripLineHelpDocuments = new List<Documentation>();
            StripLineHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            StripLineHelpDocuments.Add(new Documentation() { Content = "Chart-Strip Lines", Uri = new Uri("https://help.syncfusion.com/wpf/charts/striplines") });
            StripLineDemo.Documentations = StripLineHelpDocuments;
            this.Demos.Add(StripLineDemo);

            DemoInfo MultiLegendDemo = new DemoInfo() { SampleName = "Multi Legends", GroupName = "LEGENDS", Description = "This sample demonstrates how to add multiple legends in the chart and its functionalities.", DemoViewType = typeof(MultipleLegendsDemo) };
            List<Documentation> MultipleLegendHelpDocuments = new List<Documentation>();
            MultipleLegendHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            MultipleLegendHelpDocuments.Add(new Documentation() { Content = "Chart-Multiple Legends", Uri = new Uri("https://help.syncfusion.com/wpf/charts/legend#multiple-legends") });
            MultiLegendDemo.Documentations = MultipleLegendHelpDocuments;
            this.Demos.Add(MultiLegendDemo);

            DemoInfo MultipleSeriesDemo = new DemoInfo() { SampleName = "Multiple Series", GroupName = "PERFORMANCE", Description = "This sample illustrates the performance of SfChart when multiple series are used. SfChart has been designed to handle loading large number of series without loss in performance.", DemoViewType = typeof(MultipleSeriesDemo) };
            List<Documentation> MultipleSeriesHelpDocuments = new List<Documentation>();
            MultipleSeriesHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            MultipleSeriesHelpDocuments.Add(new Documentation() { Content = "Chart-Multiple Series", Uri = new Uri("https://help.syncfusion.com/wpf/charts/overview") });
            MultipleSeriesDemo.Documentations = MultipleSeriesHelpDocuments;
            this.Demos.Add(MultipleSeriesDemo);

            DemoInfo RealTimeDemo = new DemoInfo() { SampleName = "Real Time Chart", GroupName = "REAL TIME CHART", ShowBusyIndicator = false, Description = "This sample illustrates the performance of SfChart in real time update scenario.", DemoViewType = typeof(RealTimeChartDemo) };
            List<Documentation> RealTimeChartHelpDocuments = new List<Documentation>();
            RealTimeChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            RealTimeChartHelpDocuments.Add(new Documentation() { Content = "Chart-Real-Time Chart", Uri = new Uri("https://help.syncfusion.com/wpf/charts/performance#deferred-real-time-updates") });
            RealTimeDemo.Documentations = RealTimeChartHelpDocuments;
            this.Demos.Add(RealTimeDemo);

            DemoInfo SerializationDemo = new DemoInfo() { SampleName = "Serialization", GroupName = "SERIALIZATION", Description = "This sample demonstrates how to serialize and deserialize the SfChart.", DemoViewType = typeof(Serialization) };
            List<Documentation> SerializationHelpDocuments = new List<Documentation>();
            SerializationHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            SerializationHelpDocuments.Add(new Documentation() { Content = "Chart-Serialization", Uri = new Uri("https://help.syncfusion.com/wpf/charts/serialization") });
            SerializationDemo.Documentations = SerializationHelpDocuments;
            this.Demos.Add(SerializationDemo);

            DemoInfo TooltipDemo = new DemoInfo() { SampleName = "Tooltip", GroupName = "CHART INTERACTIVITY", Description = "ToolTip feature allows you to display any information over a chart series like a metadata. It appears when the mouse hovers any chart segment.", DemoViewType = typeof(CustomTooltip) };
            List<Documentation> ChartTooltipHelpDocuments = new List<Documentation>();
            ChartTooltipHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            ChartTooltipHelpDocuments.Add(new Documentation() { Content = "Chart-Tooltip", Uri = new Uri("https://help.syncfusion.com/wpf/charts/interactive-features/tooltip") });
            TooltipDemo.Documentations = ChartTooltipHelpDocuments;
            this.Demos.Add(TooltipDemo);

            DemoInfo TrackballDemo = new DemoInfo() { SampleName = "Trackball", GroupName = "CHART INTERACTIVITY", Description = "Trackball enables you to track a data point closer to the touch position or touch contact point. It consists of only one vertical line moving along the Primary axis and the series. X-values are determined from the position of the vertical line in the axis and Y-values are determined from the tooltip.", DemoViewType = typeof(TrackBall) };
            List<Documentation> ChartTrackballHelpDocuments = new List<Documentation>();
            ChartTrackballHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            ChartTrackballHelpDocuments.Add(new Documentation() { Content = "Chart-Trackball", Uri = new Uri("https://help.syncfusion.com/wpf/charts/interactive-features/trackball") });
            TrackballDemo.Documentations = ChartTrackballHelpDocuments;
            this.Demos.Add(TrackballDemo);

            DemoInfo CrossHairDemo = new DemoInfo() { SampleName = "Crosshair", GroupName = "CHART INTERACTIVITY", Description = "Crosshair is used to view the values at the current mouse point. It consists of two lines; a horizontal line and a vertical line, perpendicular to each other, fixed at a point.", DemoViewType = typeof(CrossHairBehavior) };
            List<Documentation> ChartCrossHairHelpDocuments = new List<Documentation>();
            ChartCrossHairHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            ChartCrossHairHelpDocuments.Add(new Documentation() { Content = "Chart-Cross hair", Uri = new Uri("https://help.syncfusion.com/wpf/charts/interactive-features/crosshair") });
            CrossHairDemo.Documentations = ChartCrossHairHelpDocuments;
            this.Demos.Add(CrossHairDemo);

            DemoInfo SelectionDemo = new DemoInfo() { SampleName = "Selection", GroupName = "CHART INTERACTIVITY", Description = "Selection allows you to select either a data point or series. This behavior highlights the particular segment of the series or a series based on the segment or series selection.", DemoViewType = typeof(SelectionBehavior) };
            List<Documentation> ChartSelectionHelpDocuments = new List<Documentation>();
            ChartSelectionHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            ChartSelectionHelpDocuments.Add(new Documentation() { Content = "Chart-Selection", Uri = new Uri("https://help.syncfusion.com/wpf/charts/interactive-features/selection") });
            SelectionDemo.Documentations = ChartSelectionHelpDocuments;
            this.Demos.Add(SelectionDemo);

            DemoInfo ZoomPanDemo = new DemoInfo() { SampleName = "Zoom and Pan", GroupName = "CHART INTERACTIVITY", Description = "Zooming and panning features allow you to take a closer look at the data point plotted in the series. We can also zoom by using the zooming toolkit.", DemoViewType = typeof(ZoomPanBehavior) };
            List<Documentation> ChartZoomPanHelpDocuments = new List<Documentation>();
            ChartZoomPanHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            ChartZoomPanHelpDocuments.Add(new Documentation() { Content = "Chart-Zoom and Pan", Uri = new Uri("https://help.syncfusion.com/wpf/charts/interactive-features/zoompan") });
            ZoomPanDemo.Documentations = ChartZoomPanHelpDocuments;
            this.Demos.Add(ZoomPanDemo);

            DemoInfo ErrorBarDemo = new DemoInfo() { SampleName = "Error Bars", GroupName = "LINE STUDIES", Description = "Error bar is a graphical representation used to indicate the errors or uncertainty in the reported values. It is used to find possible variations in measurements.", DemoViewType = typeof(ErrorBarSeriesDemo) };
            List<Documentation> ErrorBarChartHelpDocuments = new List<Documentation>();
            ErrorBarChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            ErrorBarChartHelpDocuments.Add(new Documentation() { Content = "Chart-Error Bar", Uri = new Uri("https://help.syncfusion.com/wpf/charts/seriestypes/errorbars") });
            ErrorBarDemo.Documentations = ErrorBarChartHelpDocuments;
            this.Demos.Add(ErrorBarDemo);

            DemoInfo TrendLineDemo = new DemoInfo() { SampleName = "Trendline", GroupName = "LINE STUDIES", Description = "Trend lines are used to analyze and display the trends in the data graphically. It is built on the assumptions based on current and past price trends. This analysis is also called as regression analysis.", DemoViewType = typeof(TrendlineDemo) };
            List<Documentation> ChartTrendLineHelpDocuments = new List<Documentation>();
            ChartTrendLineHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            ChartTrendLineHelpDocuments.Add(new Documentation() { Content = "Chart-Trendline", Uri = new Uri("https://help.syncfusion.com/wpf/charts/trendlines") });
            TrendLineDemo.Documentations = ChartTrendLineHelpDocuments;
            this.Demos.Add(TrendLineDemo);

            DemoInfo IndicatorDemo = new DemoInfo() { SampleName = "Technical Indicator", GroupName = "LINE STUDIES", Description = "Technical indicators are the base for technical analysis, which is used to determine the future of financial, stock or economic trends.", DemoViewType = typeof(Indicator) };
            List<Documentation> TechnicalIndicatorHelpDocuments = new List<Documentation>();
            TechnicalIndicatorHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            TechnicalIndicatorHelpDocuments.Add(new Documentation() { Content = "Chart-Technical Indicator", Uri = new Uri("https://help.syncfusion.com/wpf/charts/technical-indicators") });
            IndicatorDemo.Documentations = TechnicalIndicatorHelpDocuments;
            this.Demos.Add(IndicatorDemo);

            DemoInfo ChartExportDemo = new DemoInfo() { SampleName = "Export and Print", GroupName = "EXPORTING", Description = "This sample demonstrates the exporting and printing support in SfChart. Chart can be exported to bitmap image.", DemoViewType = typeof(ExportChartDemo) };
            List<Documentation> ExportPrintChartHelpDocuments = new List<Documentation>();
            ExportPrintChartHelpDocuments.Add(new Documentation() { Content = "Chart-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/charts/getting-started") });
            ExportPrintChartHelpDocuments.Add(new Documentation() { Content = "Chart-Export support", Uri = new Uri("https://help.syncfusion.com/wpf/charts/exporting") });
            ExportPrintChartHelpDocuments.Add(new Documentation() { Content = "Chart-Printing support", Uri = new Uri("https://help.syncfusion.com/wpf/charts/printing") });
            ChartExportDemo.Documentations = ExportPrintChartHelpDocuments;
            this.Demos.Add(ChartExportDemo);

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
            this.ControlDescription = "The 3D-Charts are used to view two-dimensional data in a three-dimensional view, and can be rotated in all 3 dimensions to get the best possible view of the data.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/3D-Charts.png", UriKind.RelativeOrAbsolute));

            DemoInfo ColumnChart3DDemo = new DemoInfo() { SampleName = "Column", GroupName = "BASIC CHARTS 3D", Description = "Column is among the most common chart types that is being used. It uses vertical bars (called columns) to display different values of one or more items. It is similar to a bar chart and the points from adjacent series are drawn as bars next to each other.", DemoViewType = typeof(ColumnChart3D) };
            List<Documentation> ColumnChart3DHelpDocuments = new List<Documentation>();
            ColumnChart3DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/gettingstarted") });
            ColumnChart3DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Column chart", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/3dseries#column-charts") });
            ColumnChart3DDemo.Documentations = ColumnChart3DHelpDocuments;
            this.Demos.Add(ColumnChart3DDemo);

            DemoInfo BarChart3DDemo = new DemoInfo() { SampleName = "Bar", GroupName = "BASIC CHARTS 3D", Description = "Bar displays horizontal bars (rectangles) for each point in the series and the points from adjacent series are drawn as bars next to each other.", DemoViewType = typeof(BarChart3D) };
            List<Documentation> BarChart3DHelpDocuments = new List<Documentation>();
            BarChart3DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/gettingstarted") });
            BarChart3DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Bar chart", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/3dseries#bar-charts") });
            BarChart3DDemo.Documentations = BarChart3DHelpDocuments;
            this.Demos.Add(BarChart3DDemo);

            DemoInfo AreaChart3DDemo = new DemoInfo() { SampleName = "Area", GroupName = "BASIC CHARTS 3D", Description = "Area is the simplest and most versatile of statistical diagrams. It displays area for each point in the series and points from adjacent series are covered by area series.", DemoViewType = typeof(AreaSeriesChart3DDemo) };
            List<Documentation> AreaChart3DHelpDocuments = new List<Documentation>();
            AreaChart3DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/gettingstarted") });
            AreaChart3DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Area chart", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/3dseries#area-chart") });
            AreaChart3DDemo.Documentations = AreaChart3DHelpDocuments;
            this.Demos.Add(AreaChart3DDemo);

            DemoInfo LineChart3DDemo = new DemoInfo() { SampleName = "Line", GroupName = "BASIC CHARTS 3D", Description = "Line is also the simplest and widely used statistical diagrams. It displays line for each point in the series and the points from adjacent series are drawn as lines.", DemoViewType = typeof(LineSeriesChart3D) };
            List<Documentation> LineChart3DHelpDocuments = new List<Documentation>();
            LineChart3DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/gettingstarted") });
            LineChart3DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Line chart", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/3dseries#line-charts") });
            LineChart3DDemo.Documentations = LineChart3DHelpDocuments;
            this.Demos.Add(LineChart3DDemo);

            DemoInfo ScatterChart3DDemo = new DemoInfo() { SampleName = "Scatter", GroupName = "BASIC CHARTS 3D", Description = "Scatter displays cube for each data points in the series.", DemoViewType = typeof(ScatterSeriesChart3D) };
            List<Documentation> ScatterChart3DHelpDocuments = new List<Documentation>();
            ScatterChart3DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/gettingstarted") });
            ScatterChart3DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Scatter chart", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/3dseries#scatter-chart") });
            ScatterChart3DDemo.Documentations = ScatterChart3DHelpDocuments;
            this.Demos.Add(ScatterChart3DDemo);

            DemoInfo StackedColumn3DDemo = new DemoInfo() { SampleName = "Column", GroupName = "STACKED CHARTS 3D", Description = "Column is similar to Bar charts except that the adjacent series are stacked on top of another chart.", DemoViewType = typeof(StackingColumnChart3D) };
            List<Documentation> StackedColumn3DHelpDocuments = new List<Documentation>();
            StackedColumn3DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/gettingstarted") });
            StackedColumn3DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Stacked Column chart", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/3dseries#stacking-column") });
            StackedColumn3DDemo.Documentations = StackedColumn3DHelpDocuments;
            this.Demos.Add(StackedColumn3DDemo);

            DemoInfo StackedBar3DDemo = new DemoInfo() { SampleName = "Bar", GroupName = "STACKED CHARTS 3D", Description = "Bar displays horizontal bars for each point in the series and points from adjacent series are drawn as bars next to each other similar to bar charts. Here the adjacent series are stacked on top of each other.", DemoViewType = typeof(StackingBarChart3D) };
            List<Documentation> StackedBar3DHelpDocuments = new List<Documentation>();
            StackedBar3DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/gettingstarted") });
            StackedBar3DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Stacked Bar chart", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/3dseries#stacking-bar") });
            StackedBar3DDemo.Documentations = StackedBar3DHelpDocuments;
            this.Demos.Add(StackedBar3DDemo);

            DemoInfo StackedColumn1003DDemo = new DemoInfo() { SampleName = "Column", GroupName = "STACKED CHARTS 3D 100%", Description = "Column is similar to Stacked Column but this is used to visualize the relationship of parts to the whole in terms of percentage.", DemoViewType = typeof(StackingColumn100Chart3D) };
            List<Documentation> StackedColumn1003DHelpDocuments = new List<Documentation>();
            StackedColumn1003DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/gettingstarted") });
            StackedColumn1003DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Stacked Column100 chart", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/3dseries#stacking-column-100") });
            StackedColumn1003DDemo.Documentations = StackedColumn1003DHelpDocuments;
            this.Demos.Add(StackedColumn1003DDemo);

            DemoInfo StackedBar1003DDemo = new DemoInfo() { SampleName = "Bar", GroupName = "STACKED CHARTS 3D 100%", Description = "Bar is similar to Stacked Bar but this is used to visualize the relationship of parts to the whole in terms of percentage.", DemoViewType = typeof(StackingBar100Chart3D) };
            List<Documentation> StackedBar1003DHelpDocuments = new List<Documentation>();
            StackedBar1003DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/gettingstarted") });
            StackedBar1003DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Stacked Bar100 chart", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/3dseries#stacking-bar-100") });
            StackedBar1003DDemo.Documentations = StackedBar1003DHelpDocuments;
            this.Demos.Add(StackedBar1003DDemo);

            DemoInfo DepthAxis3DDemo = new DemoInfo() { SampleName = "Depth Axis", GroupName = "DEPTH AXIS", Description = "This sample illustrates the various 3D Chart types with X, Y and Z Axis.", DemoViewType = typeof(DepthAxis) };
            List<Documentation> DepthAxis3DHelpDocuments = new List<Documentation>();
            DepthAxis3DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/gettingstarted") });
            DepthAxis3DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Depth Axis", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/axis#depth-axis") });
            DepthAxis3DDemo.Documentations = DepthAxis3DHelpDocuments;
            this.Demos.Add(DepthAxis3DDemo);

            DemoInfo PieChart3DDemo = new DemoInfo() { SampleName = "Pie", GroupName = "CIRCULAR CHARTS 3D", Description = "Pie is an ideal for the display of proportionate values expressed in either percentage or fractional formats.", DemoViewType = typeof(PieChart3D) };
            List<Documentation> PieChart3DHelpDocuments = new List<Documentation>();
            PieChart3DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/gettingstarted") });
            PieChart3DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Pie chart", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/3dseries#pie-chart") });
            PieChart3DDemo.Documentations = PieChart3DHelpDocuments;
            this.Demos.Add(PieChart3DDemo);

            DemoInfo DoughnutChart3DDemo = new DemoInfo() { SampleName = "Doughnut", GroupName = "CIRCULAR CHARTS 3D", Description = "Doughnut is like pie chart with a hole and the value is specified as the doughnut coefficient. The Doughnut Chart is best suited for presenting data in proportions.", DemoViewType = typeof(DoughnutChart3D) };
            List<Documentation> DoughnutChart3DHelpDocuments = new List<Documentation>();
            DoughnutChart3DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/gettingstarted") });
            DoughnutChart3DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Doughnut chart", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/3dseries#doughnut-chart") });
            DoughnutChart3DDemo.Documentations = DoughnutChart3DHelpDocuments;
            this.Demos.Add(DoughnutChart3DDemo);

            DemoInfo SemiPieAndDoughnut3DDemo = new DemoInfo() { SampleName = "Semi Pie and Doughnut", GroupName = "CIRCULAR CHARTS 3D", Description = "Pie and Doughnut charts can be customized to semicircular shape or any other angles using Start Angle and End Angle.", DemoViewType = typeof(SemiPieAndDoughnutSeries3D) };
            List<Documentation> SemiPieDoughnut3DHelpDocuments = new List<Documentation>();
            SemiPieDoughnut3DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/gettingstarted") });
            SemiPieDoughnut3DHelpDocuments.Add(new Documentation() { Content = "SfChart3D-Semi Pie and Doughnut", Uri = new Uri("https://help.syncfusion.com/wpf/sfchart3d/3dseries#semi-pie-and-doughnut") });
            SemiPieAndDoughnut3DDemo.Documentations = SemiPieDoughnut3DHelpDocuments;
            this.Demos.Add(SemiPieAndDoughnut3DDemo);

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
            this.ControlDescription = "The Range Navigator control is a time bound data visualization control. Its purpose is to allow scrolling and navigation through long periods of time. This control can be easily integrated with other controls such as chart and grid view to create rich and powerful dashboards.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Range Navigator.png", UriKind.RelativeOrAbsolute));

            DemoInfo GettingStartedDemo = new DemoInfo() { SampleName = "Getting Started", GroupName = "DATETIME RANGE NAVIGATOR", Description = "This Sample demonstrate Range Navigator with chart Zooming.", DemoViewType = typeof(GettingStartedDemo) };
            List<Documentation> DateTimeRangeNavigatorHelpDocuments = new List<Documentation>();
            DateTimeRangeNavigatorHelpDocuments.Add(new Documentation() { Content = "DateTime Range Navigator-Getting started", Uri = new Uri("https://help.syncfusion.com/wpf/range-selector/getting-started") });
            GettingStartedDemo.Documentations = DateTimeRangeNavigatorHelpDocuments;
            this.Demos.Add(GettingStartedDemo);
        }
    }

}
