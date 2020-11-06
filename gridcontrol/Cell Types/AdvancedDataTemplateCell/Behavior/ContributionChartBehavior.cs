#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Charts;

namespace syncfusion.gridcontroldemos.wpf
{
    public class ContributionChartTriggerAction : TargetedTriggerAction<SfChart>
    {
        protected override void Invoke(object parameter)
        {
            ObservableCollection<PortfolioAccounts> seriesPoints = new ObservableCollection<PortfolioAccounts>();
            foreach (Queries.AcountNameAndValue value in Queries.GetAcountNameAndValue())
            {
                seriesPoints.Add(new PortfolioAccounts(value.AccountName, Convert.ToDouble(value.AssetValue)));
            }

            (this.Target.Series[0] as ColumnSeries).ItemsSource = seriesPoints;
            (this.Target.Series[0] as ColumnSeries).XBindingPath = "AccountName";
            (this.Target.Series[0] as ColumnSeries).YBindingPath = "AssetValue";
            this.Target.SelectionChanged += Target_SelectionChanged;
            RefreshContributionChart(1);
        }

        private void Target_SelectionChanged(object sender, ChartSelectionChangedEventArgs e)
        {
            RefreshContributionChart(e.SelectedIndex);
        }

        List<Queries.ExchangeAndValue> exchangeList = null;
        public void RefreshContributionChart(int accountID)
        {
            exchangeList = Queries.GetExchangeNamesAndValues(accountID);
            ObservableCollection<Contributions> contributionSeries = new ObservableCollection<Contributions>();
            foreach (Queries.ExchangeAndValue exchange in exchangeList)
            {
                contributionSeries.Add(new Contributions(exchange.ExchangeName, Convert.ToDouble(exchange.Value)));
            }

            SfChart ContributionChart = this.AssociatedObject as SfChart;
            if (ContributionChart != null)
            {
                (ContributionChart.Series[0] as PieSeries).ItemsSource = contributionSeries;
                (ContributionChart.Series[0] as PieSeries).XBindingPath = "ExchangeName";
                (ContributionChart.Series[0] as PieSeries).YBindingPath = "Value";
            }
        }
    }
}
