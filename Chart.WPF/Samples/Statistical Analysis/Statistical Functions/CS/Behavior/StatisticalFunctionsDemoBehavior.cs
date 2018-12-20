#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows.Controls;
using Syncfusion.Windows.Chart;

namespace StatisticalFunctions
{
  
    class StatisticalFunctionsDemoBehavior:Behavior<MainWindow>
    {
        DataCollection mycollection;
        DataCollection newcollection; 
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }

        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            mycollection = new DataCollection();
            this.AssociatedObject.series1.DataSource = mycollection;
            this.AssociatedObject.series1.BindingPathX = "X";
            this.AssociatedObject.series1.BindingPathsY = new string[] { "Y1", "Y2", "Y3" };
            this.AssociatedObject.series1.Type = ChartTypes.Histogram;
            newcollection = new DataCollection();
            this.AssociatedObject.series2.DataSource = newcollection;
            this.AssociatedObject.series2.BindingPathX = "Y1";
            this.AssociatedObject.series2.BindingPathsY = new string[] { "Y2", "Y3", "Y1" };
            this.AssociatedObject.series2.Type = ChartTypes.Histogram;
            this.AssociatedObject.sample1Mean.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(sample1Mean_ValueChanged);
            this.AssociatedObject.sample1Variance.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(sample1Variance_ValueChanged);
            this.AssociatedObject.sample2Mean.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(sample2Mean_ValueChanged);
            this.AssociatedObject.sample2Variance.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(sample2Variance_ValueChanged);
            this.AssociatedObject.meandiff.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(meandiff_ValueChanged);
            this.AssociatedObject.visible.Loaded += new System.Windows.RoutedEventHandler(visible_Loaded);
            this.AssociatedObject.button1.Click += new System.Windows.RoutedEventHandler(button1_Click);
            this.AssociatedObject.test.SelectionChanged+=new SelectionChangedEventHandler(test_SelectionChanged);
            this.InitializeChart();
        }

        void button1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            switch (this.AssociatedObject.test.SelectedIndex)
            {
                case 0: 
                    StatisticFormula();
                    //if (this.AssociatedObject.visible != null)
                        //this.AssociatedObject.visible.Visibility = System.Windows.Visibility.Collapsed;
                    break;
                case 1:
                    AnovaTest();
                    break;
                case 2:
                    FTest();
                    break;
                case 3:
                    TTest();
                    break;
                case 4:
                    ztest();
                    break;
            }
        }

        void visible_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.visible.Visibility = System.Windows.Visibility.Collapsed;
        }

        void meandiff_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            InitializeChart();
            
        }

        void sample2Variance_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            InitializeChart();
        }

        void sample2Mean_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            InitializeChart();
        }

        void sample1Variance_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            InitializeChart();
        }

        void sample1Mean_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            InitializeChart();
        }

        #region Methods
        public void StatisticFormula()
        {
            if (this.AssociatedObject.series1.Data != null && this.AssociatedObject.series2.Data != null)
            {
                this.AssociatedObject.result.Text = "Mean = " + BasicStatisticalFormulas.Mean(this.AssociatedObject.series1).ToString() + "\n" +
                               "Median = " + BasicStatisticalFormulas.Median(this.AssociatedObject.series1).ToString() + "\n" +
                               "Standard deviation = " + BasicStatisticalFormulas.StandardDeviation(this.AssociatedObject.series1, true).ToString() + "\n" +
                               "Varianve = " + BasicStatisticalFormulas.Variance(this.AssociatedObject.series1, true).ToString() + "\n" +
                "Variance Biased Estimator = " + BasicStatisticalFormulas.VarianceBiasedEstimator(this.AssociatedObject.series1).ToString() + "\n" +
                "Variance Unbiased Estimator = " + BasicStatisticalFormulas.VarianceUnbiasedEstimator(this.AssociatedObject.series1).ToString() + "\n" +
                "Co Variance = " + BasicStatisticalFormulas.Covariance(this.AssociatedObject.series1, this.AssociatedObject.series2).ToString() + "\n" +
                "Co releation = " + BasicStatisticalFormulas.Correlation(this.AssociatedObject.series1, this.AssociatedObject.series2).ToString() + "\n";
                
                ChartHistogramType.SetDrawNormalDistribution(this.AssociatedObject.series2, false);
               // ChartHistogramType.SetDrawNormalDistribution(this.AssociatedObject.series1, false);
            }
        }
        public void AnovaTest()
        {
            AnovaResult anova = BasicStatisticalFormulas.Anova(0.05, new ChartSeries[] { this.AssociatedObject.series1, this.AssociatedObject.series2 });
            this.AssociatedObject.result.Text = "F Ratio = " + anova.FRatio + "\n" +
                           "F Critical Value =" + anova.FCriticalValue + "\n" +
                           "Degree of Freedom Between Groups = " + anova.DegreeOfFreedomBetweenGroups + "\n" +
                           "Degree of Freedom within Groups = " + anova.DegreeOfFreedomWithinGroups + "\n" +
                           "Degree of Freedom total = " + anova.DegreeOfFreedomTotal + "\n" +
                           "Mean square variance beteeen groups = " + anova.MeanSquareVarianceBetweenGroups + "\n" +
                           "Mean square variance within groups = " + anova.MeanSquareVarianceWithinGroups + "\n" +
                           "Sum of square between groups = " + anova.SumOfSquaresBetweenGroups + "\n";


        }

        public void FTest()
        {
            FTestResult ftest = BasicStatisticalFormulas.FTest(0.05, this.AssociatedObject.series1, this.AssociatedObject.series2);
            this.AssociatedObject.result.Text = "FValue = " + ftest.FValue.ToString() + "\n" +
                            "F Critical Value on Tail = " + ftest.FCriticalValueOneTail.ToString() + "\n" +
                            "ProbabilityFOneTail = " + ftest.ProbabilityFOneTail.ToString() + "\n" +
                            "First Series Mean = " + ftest.FirstSeriesMean.ToString() + "\n" +
                            "Second Series Mean = " + ftest.SecondSeriesMean.ToString() + "\n" +
                            "First Series Variance = " + ftest.FirstSeriesVariance.ToString() + "\n" +
                            "Second Series Variance = " + ftest.SecondSeriesVariance.ToString() + "\n";

        }

        public void TTest()
        {
            TTestResult ttest = BasicStatisticalFormulas.TTestEqualVariances(this.AssociatedObject.meandiff.Value, 0.1, this.AssociatedObject.series1, this.AssociatedObject.series2);
            this.AssociatedObject.result.Text = "T Value = " + ttest.TValue.ToString() + "\n" +
                            "T Critical Value one Tail = " + ttest.TCriticalValueOneTail.ToString() + "\n" +
                            "T Critical value two Tail = " + ttest.TCriticalValueTwoTail.ToString() + "\n" +
                            "Probability T One Tail = " + ttest.ProbabilityTOneTail.ToString() + "\n" +
                            "Probability T Two Tail = " + ttest.ProbabilityTTwoTail.ToString() + "\n" +
                            "First Series Mean = " + ttest.FirstSeriesMean.ToString() + "\n" +
                            "First Series Variance = " + ttest.FirstSeriesVariance.ToString() + "\n" +
                            "Second Series Mean = " + ttest.SecondSeriesMean.ToString() + "\n" +
                            "Second Series Variance =" + ttest.SecondSeriesVariance.ToString() + "\n";


        }

        public void ztest()
        {
            ZTestResult ztest = BasicStatisticalFormulas.ZTest(this.AssociatedObject.meandiff.Value, 10, 5, 0.5, this.AssociatedObject.series1, this.AssociatedObject.series2);
            this.AssociatedObject.result.Text = "Z Value = " + ztest.ZValue.ToString() + "\n" +
                            "Z Critical Value One Tail = " + ztest.ZCriticalValueOneTail.ToString() + "\n" +
                            "Z Critical Value Two Tail = " + ztest.ZCriticalValueTwoTail.ToString() + "\n" +
                            "Probability Z One Tail = " + ztest.ProbabilityZOneTail.ToString() + "\n" +
                            "Probability Z Two Tail = " + ztest.ProbabilityZTwoTail.ToString() + "\n" +
                            "First Series Mean = " + ztest.FirstSeriesMean.ToString() + "\n" +
                            "Second Series Mean = " + ztest.SecondSeriesMean.ToString() + "\n" +
                            "First Series Variance = " + ztest.FirstSeriesVariance.ToString() + "\n" +
                            "Second Series Variance = " + ztest.SecondSeriesMean.ToString() + "\n";

        }

        private void test_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (this.AssociatedObject.test.SelectedIndex)
            {
                case 0:
                    InitializeChart();
                    //StatisticFormula();
                    //if (this.AssociatedObject.visible != null)
                        //this.AssociatedObject.visible.Visibility = System.Windows.Visibility.Collapsed;
                    break;
                case 1:
                    InitializeChart();
                    break;
                case 2:
                    InitializeChart();
                    break;
                case 3:
                    InitializeChart();
                    break;
                case 4:
                    InitializeChart();
                    break;
            }
        }

        private void InitializeChart()
        {
            if (this.AssociatedObject.result != null)
                this.AssociatedObject.result.Text = string.Empty;
            if (this.AssociatedObject.visible != null)
            {
                this.AssociatedObject.visible.Visibility = System.Windows.Visibility.Visible;
            }
            ChartListData data = new ChartListData();
            if (this.AssociatedObject.sample1Mean != null && this.AssociatedObject.sample1Variance != null)
            {
                for (int j = 0; j < 30; j++)
                {
                    //making normally distributed sample with meanOfFirstSeries as Mean, and sqrtVarianceOfFirstSeries as Standard deviation
                    double p = 1.0 / (30 * 30) + ((double)j) / (30);
                    double x = this.AssociatedObject.sample1Mean.Value + this.AssociatedObject.sample1Variance.Value * UtilityFunctions.InverseNormalDistribution(p);

                    //Adds the data point.
                    data.Add(new ChartPoint(x, 0));
                }

                ChartHistogramType.SetDrawNormalDistribution(this.AssociatedObject.series1, true);
                ChartHistogramType.SetIntervalOfHistogram(this.AssociatedObject.series1, this.AssociatedObject.sample1Mean.Value / 30);
                ChartHistogramType.SetSpacing(this.AssociatedObject.series1.Area, this.AssociatedObject.sample1Variance.Value);
            }

            this.AssociatedObject.series1.Data = data;

            data = new ChartListData();
            if (this.AssociatedObject.sample2Mean != null && this.AssociatedObject.sample2Variance != null)
            {
                for (int j = 0; j < 30; j++)
                {
                    //making normally distributed sample with meanOfFirstSeries as Mean, and sqrtVarianceOfFirstSeries as Standard deviation
                    double p = 1.0 / (30 * 30) + ((double)j) / (30);
                    double x = this.AssociatedObject.sample2Mean.Value + this.AssociatedObject.sample2Variance.Value * UtilityFunctions.InverseNormalDistribution(p);

                    //Adds the data point.
                    data.Add(new ChartPoint(x, 0));
                }
                ChartHistogramType.SetDrawNormalDistribution(this.AssociatedObject.series2, true);
                ChartHistogramType.SetIntervalOfHistogram(this.AssociatedObject.series2, this.AssociatedObject.sample2Mean.Value / 30);
                ChartHistogramType.SetSpacing(this.AssociatedObject.series2.Area, this.AssociatedObject.sample2Variance.Value);
            }
            this.AssociatedObject.series2.Data = data;

        }
        #endregion

    }
}
