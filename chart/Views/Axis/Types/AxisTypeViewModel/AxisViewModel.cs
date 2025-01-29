#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.wpf
{
    public class AxisViewModel
    {
        public ObservableCollection<AxisModel> InternetUsers { get; set; }

        public ObservableCollection<AxisModel> MatchScores { get; set; }

        public ObservableCollection<AxisModel> EuroToUSDValue { get; set; }

        public ObservableCollection<AxisModel> SalesRevenue { get; set; }

        public ObservableCollection<AxisModel> DataCollection { get; set; }
        public AxisViewModel()
        {
            //Category Axis
            this.InternetUsers = new ObservableCollection<AxisModel>();
            InternetUsers.Add(new AxisModel() { CountryName = "Indonesia", InternetUsersRate = 212.9 });
            InternetUsers.Add(new AxisModel() { CountryName = "Brazil", InternetUsersRate = 181.8 });
            InternetUsers.Add(new AxisModel() { CountryName = "Nigeria", InternetUsersRate = 122.5 });
            InternetUsers.Add(new AxisModel() { CountryName = "Russia", InternetUsersRate = 127.6 });
            InternetUsers.Add(new AxisModel() { CountryName = "Mexico", InternetUsersRate = 100.6 });

            //Numeric Axis
            this.MatchScores = new ObservableCollection<AxisModel>();
            MatchScores.Add(new AxisModel() { MatchRound = "1", IndiaScore = 240, AustraliaScore = 236 });
            MatchScores.Add(new AxisModel() { MatchRound = "2", IndiaScore = 250, AustraliaScore = 242 });
            MatchScores.Add(new AxisModel() { MatchRound = "3", IndiaScore = 281, AustraliaScore = 313 });
            MatchScores.Add(new AxisModel() { MatchRound = "4", IndiaScore = 358, AustraliaScore = 359 });
            MatchScores.Add(new AxisModel() { MatchRound = "5", IndiaScore = 237, AustraliaScore = 272 });

            //Datetime Axis
            this.EuroToUSDValue = new ObservableCollection<AxisModel>();
            EuroToUSDValue.Add(new AxisModel() { Date = new DateTime(2015, 1,01), DollerValue = 1.1615 });
            EuroToUSDValue.Add(new AxisModel() { Date = new DateTime(2015, 2, 01), DollerValue = 1.1350 });
            EuroToUSDValue.Add(new AxisModel() { Date = new DateTime(2015, 3, 01), DollerValue = 1.0819 });
            EuroToUSDValue.Add(new AxisModel() { Date = new DateTime(2015, 4, 01), DollerValue = 1.0822 });
            EuroToUSDValue.Add(new AxisModel() { Date = new DateTime(2015, 5, 01), DollerValue = 1.1167 });
            EuroToUSDValue.Add(new AxisModel() { Date = new DateTime(2015, 6, 01), DollerValue = 1.1226 });
            EuroToUSDValue.Add(new AxisModel() { Date = new DateTime(2015, 7, 01), DollerValue = 1.0997 });
            EuroToUSDValue.Add(new AxisModel() { Date = new DateTime(2015, 8, 01), DollerValue = 1.1136 });
            EuroToUSDValue.Add(new AxisModel() { Date = new DateTime(2015, 9, 01), DollerValue = 1.1229 });
            EuroToUSDValue.Add(new AxisModel() { Date = new DateTime(2015, 10, 01), DollerValue = 1.1228 });
            EuroToUSDValue.Add(new AxisModel() { Date = new DateTime(2015, 11, 01), DollerValue = 1.0727 });
            EuroToUSDValue.Add(new AxisModel() { Date = new DateTime(2015, 12, 01), DollerValue = 1.0889 });

            //DateTimeCategory Axis
            this.SalesRevenue = new ObservableCollection<AxisModel>();
            SalesRevenue.Add(new AxisModel() { Date = new DateTime(2017, 12, 24), SalesRate = 40 });
            SalesRevenue.Add(new AxisModel() { Date = new DateTime(2017, 12, 25), SalesRate = 60 });
            SalesRevenue.Add(new AxisModel() { Date = new DateTime(2017, 12, 31), SalesRate = 57});
            SalesRevenue.Add(new AxisModel() { Date = new DateTime(2018, 01, 01), SalesRate = 64 });
            SalesRevenue.Add(new AxisModel() { Date = new DateTime(2018, 01, 02), SalesRate = 60 });
            SalesRevenue.Add(new AxisModel() { Date = new DateTime(2018, 01, 14), SalesRate = 50 });

            //Log Axis
            DataCollection = new ObservableCollection<AxisModel>();
            this.DataCollection.Add(new AxisModel() { Year = "1995", SalesRate = 80 });
            this.DataCollection.Add(new AxisModel() { Year = "1996", SalesRate = 200 });
            this.DataCollection.Add(new AxisModel() { Year = "1997", SalesRate = 400 });
            this.DataCollection.Add(new AxisModel() { Year = "1998", SalesRate = 600 });
            this.DataCollection.Add(new AxisModel() { Year = "1999", SalesRate = 700 });
            this.DataCollection.Add(new AxisModel() { Year = "2000", SalesRate = 1400 });
            this.DataCollection.Add(new AxisModel() { Year = "2001", SalesRate = 2000 });
            this.DataCollection.Add(new AxisModel() { Year = "2002", SalesRate = 4000 });
            this.DataCollection.Add(new AxisModel() { Year = "2003", SalesRate = 6000 });
            this.DataCollection.Add(new AxisModel() { Year = "2005", SalesRate = 11000 });
        }
    }
}
