#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using System.Collections.ObjectModel;
using PortfolioManager1.Helpers;

namespace PortfolioManager1.Behaviors
{
    public class ContributionChartTriggerAction : TargetedTriggerAction<Chart>
    {
        protected override void Invoke(object parameter)
        {
            this.Target.Areas[0].ColorModel.Palette = ChartColorPalette.Office2007Blue;
            ObservableCollection<PortfolioAccounts> seriesPoints = new ObservableCollection<PortfolioAccounts>();
            foreach (Queries.AcountNameAndValue value in Queries.GetAcountNameAndValue())
            {
                seriesPoints.Add(new PortfolioAccounts(value.AccountName, Convert.ToDouble(value.AssetValue)));
            }

            this.Target.Areas[0].Series[0].DataSource = seriesPoints;
            this.Target.Areas[0].Series[0].BindingPathX = "AccountName";
            this.Target.Areas[0].Series[0].BindingPathsY = new string[] { "AssetValue" };
            this.Target.Areas[0].Series[0].MouseClick += new ChartMouseEventHandler(PortfolioGrid_MouseClick);

            RefreshContributionChart(1);
        }

        void PortfolioGrid_MouseClick(object sender, ChartMouseEventArgs e)
        {
            RefreshContributionChart((int)e.Segment.CorrespondingPoints[0].DataPoint.X);
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

            Chart ContributionChart = this.AssociatedObject as Chart;
            if (ContributionChart != null)
            {
                ContributionChart.Areas[0].Series[0].DataSource = contributionSeries;
                ContributionChart.Areas[0].Series[0].BindingPathX = "ExchangeName";
                ContributionChart.Areas[0].Series[0].BindingPathsY = new string[] { "Value" };
            }
        }
    }
}
