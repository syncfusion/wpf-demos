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
using Syncfusion.Windows.Chart;

namespace UtilityFunctionsSample
{
    class UtilityFunctionsDemoBehavior:Behavior<MainWindow>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }

        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.probability.Items.Add(0.1);
            this.AssociatedObject.probability.Items.Add(0.2);
            this.AssociatedObject.probability.Items.Add(0.3);
            this.AssociatedObject.probability.Items.Add(0.4);
            this.AssociatedObject.probability.Items.Add(0.5);
            this.AssociatedObject.probability.Items.Add(0.6);
            this.AssociatedObject.probability.Items.Add(0.7);
            this.AssociatedObject.probability.Items.Add(0.8);
            this.AssociatedObject.probability.Items.Add(0.9);
            this.AssociatedObject.n.Items.Add(0.1);
            this.AssociatedObject.n.Items.Add(0.2);
            this.AssociatedObject.n.Items.Add(0.3);
            this.AssociatedObject.n.Items.Add(0.4);
            this.AssociatedObject.n.Items.Add(0.5);
            this.AssociatedObject.n.Items.Add(0.6);
            this.AssociatedObject.n.Items.Add(0.7);
            this.AssociatedObject.n.Items.Add(0.8);
            this.AssociatedObject.n.Items.Add(0.9);
            this.AssociatedObject.m.Items.Add(0.1);
            this.AssociatedObject.m.Items.Add(0.2);
            this.AssociatedObject.m.Items.Add(0.3);
            this.AssociatedObject.m.Items.Add(0.4);
            this.AssociatedObject.m.Items.Add(0.5);
            this.AssociatedObject.m.Items.Add(0.6);
            this.AssociatedObject.m.Items.Add(0.7);
            this.AssociatedObject.m.Items.Add(0.8);
            this.AssociatedObject.m.Items.Add(0.9);
           

            this.AssociatedObject.distribution.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(distribution_SelectionChanged);
            this.AssociatedObject.probability.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(probability_SelectionChanged);
            this.AssociatedObject.isinverse.Checked += new System.Windows.RoutedEventHandler(isinverse_Checked);
            this.AssociatedObject.isinverse.Unchecked += new System.Windows.RoutedEventHandler(isinverse_Unchecked);
            this.AssociatedObject.n.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(probability_SelectionChanged);
            this.AssociatedObject.m.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(probability_SelectionChanged);
            this.AssociatedObject.probability.SelectedIndex = 0;
            this.AssociatedObject.m.SelectedIndex = 3;
            this.AssociatedObject.n.SelectedIndex = 4;
            this.AssociatedObject.distribution.SelectedIndex = 0;
        }

        void isinverse_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            valueChanged();
        }

        void isinverse_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            valueChanged();
        }

        void probability_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            valueChanged();
        }

        protected void InitializeNormalDistributionChart()
        {
            this.AssociatedObject.series1.Type = ChartTypes.SplineArea;

            double coef = 1.0 / Math.Sqrt(2 * Math.PI);
            ChartListData data = new ChartListData();
            for (int x = -50; x <= 50; x++)
            {
                double doubleX = x / 10.0;
                double y = coef * Math.Exp(doubleX * doubleX / -2);

                //Add the data points to the series.
                data.Add(new ChartPoint(doubleX - 0.05, y));

            }
            this.AssociatedObject.series1.Data = data;
        }
        protected void InitializeFDistributionChart()
        {


            // Set degrees of freedom
            double n1 = (double)this.AssociatedObject.n.SelectedItem;
            double m1 = (double)this.AssociatedObject.m.SelectedItem;

            // Calculate the Beta function
            double beta = UtilityFunctions.Beta(n1 / 2.0, m1 / 2.0);

            // Find coefficient
            double coef = Math.Pow(n1 / m1, n1 / 2.0) / beta;

            // Go through all data points and calculate values
            ChartListData data = new ChartListData();
            for (double x = 0.01; x <= 15; x += 0.1)
            {
                double doubleX = x;
                double y = coef * (Math.Pow(doubleX, n1 / 2.0 - 1.0) / Math.Pow(1.0 + n1 * doubleX / m1, (n1 + m1) / 2.0));

                // Add data points to the series.
                data.Add(new ChartPoint(doubleX, y));

            }
            this.AssociatedObject.series1.Data = data;

        }
        protected void InitializeTDistributionChart()
        {
            //Set the degree of freedom.
            double n1 = (double)this.AssociatedObject.n.SelectedItem;

            //Calculates the Beta function.
            double beta = UtilityFunctions.Beta(0.5, n1 / 2.0);

            // Calculate coefficient of T Distribution.
            double coef = Math.Pow(n1, -0.5) / beta;

            // Calculate Data Points
            ChartListData data = new ChartListData();
            for (int x = -120; x <= 120; x++)
            {
                double doubleX = x / 10.0;
                double y = coef / Math.Pow(1.0 + doubleX * doubleX / n1, (n1 + 1.0) / 2.0);

                //Add data points to the series.
                data.Add(new ChartPoint(doubleX, y));
            }
            this.AssociatedObject.series1.Data = data;

        }

        void valueChanged()
        {
            if (this.AssociatedObject.value != null)
            {
                switch (this.AssociatedObject.distribution.SelectedIndex)
                {
                    case 0:
                        {
                            InitializeNormalDistributionChart();
                            if ((bool)this.AssociatedObject.isinverse.IsChecked)
                                this.AssociatedObject.value.Text = UtilityFunctions.InverseNormalDistribution((double)this.AssociatedObject.probability.SelectedItem).ToString();
                            else
                                this.AssociatedObject.value.Text = UtilityFunctions.NormalDistribution((double)this.AssociatedObject.probability.SelectedItem).ToString();

                            this.AssociatedObject.n.IsEnabled = false;
                            this.AssociatedObject.m.IsEnabled = false;
                        }
                        break;
                    case 1:
                        {
                            InitializeTDistributionChart();
                            if ((bool)this.AssociatedObject.isinverse.IsChecked)
                                this.AssociatedObject.value.Text = UtilityFunctions.InverseTCumulativeDistribution((double)this.AssociatedObject.probability.SelectedItem, (double)this.AssociatedObject.n.SelectedItem, true).ToString();
                            else
                                this.AssociatedObject.value.Text = UtilityFunctions.TCumulativeDistribution((double)this.AssociatedObject.probability.SelectedItem, (double)this.AssociatedObject.n.SelectedItem, true).ToString();
                            this.AssociatedObject.n.IsEnabled = true;
                            this.AssociatedObject.m.IsEnabled = false;
                        }
                        break;
                    case 2:
                        {
                            InitializeFDistributionChart();
                            if ((bool)this.AssociatedObject.isinverse.IsChecked)
                                this.AssociatedObject.value.Text = UtilityFunctions.InverseFCumulativeDistribution((double)this.AssociatedObject.probability.SelectedItem, (double)this.AssociatedObject.n.SelectedItem, (double)this.AssociatedObject.m.SelectedItem).ToString();
                            else
                                this.AssociatedObject.value.Text = UtilityFunctions.FCumulativeDistribution((double)this.AssociatedObject.probability.SelectedItem, (double)this.AssociatedObject.n.SelectedItem, (double)this.AssociatedObject.m.SelectedItem).ToString();
                            this.AssociatedObject.n.IsEnabled = true;
                            this.AssociatedObject.m.IsEnabled = true;
                        }
                        break;
                }
            }
        }

        void distribution_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            valueChanged();
        }
    }
}
