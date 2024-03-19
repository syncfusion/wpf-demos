#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.wpf
{
    public class Axis3DChartsViewModel
    {
        public List<Axis3DChartsModel> VolcanoesData { get; set; }
        public ObservableCollection<Axis3DChartsModel> MatchScores { get; set; }
        public ObservableCollection<Axis3DChartsModel> DataCollection { get; set; }

        public Axis3DChartsViewModel()
        {
            // category 
            VolcanoesData = new List<Axis3DChartsModel>()
             {
            new Axis3DChartsModel (){Country="PH",Value= 7 },
            new Axis3DChartsModel (){Country="MX",Value= 7 },
            new Axis3DChartsModel (){Country="FR",Value= 9 },
            new Axis3DChartsModel (){Country="IS",Value= 9 },
            new Axis3DChartsModel (){Country="TO",Value= 10 },
            new Axis3DChartsModel (){Country="EC",Value= 12 },
            new Axis3DChartsModel (){Country="CL",Value= 19 },
            new Axis3DChartsModel (){Country="RU",Value= 33 },
            new Axis3DChartsModel (){Country="US", Value=42 },
            new Axis3DChartsModel (){Country="JP", Value=44 },
            new Axis3DChartsModel (){Country="ID",Value= 58 },
           };

            //Numeric Axis
            this.MatchScores = new ObservableCollection<Axis3DChartsModel>();
            MatchScores.Add(new Axis3DChartsModel() { MatchRound = "1", IndiaScore = 255, AustraliaScore = 258 });
            MatchScores.Add(new Axis3DChartsModel() { MatchRound = "2", IndiaScore = 340, AustraliaScore = 304 });
            MatchScores.Add(new Axis3DChartsModel() { MatchRound = "3", IndiaScore = 289, AustraliaScore = 286 });
            MatchScores.Add(new Axis3DChartsModel() { MatchRound = "4", IndiaScore = 308, AustraliaScore = 374 });
            MatchScores.Add(new Axis3DChartsModel() { MatchRound = "5", IndiaScore = 338, AustraliaScore = 389 });

            //Log Axis
            DataCollection = new ObservableCollection<Axis3DChartsModel>();
            this.DataCollection.Add(new Axis3DChartsModel() { Year = "2005", SalesRate = 80 });
            this.DataCollection.Add(new Axis3DChartsModel() { Year = "2006", SalesRate = 200 });
            this.DataCollection.Add(new Axis3DChartsModel() { Year = "2007", SalesRate = 400 });
            this.DataCollection.Add(new Axis3DChartsModel() { Year = "2008", SalesRate = 200 });
            this.DataCollection.Add(new Axis3DChartsModel() { Year = "2009", SalesRate = 700 });
            this.DataCollection.Add(new Axis3DChartsModel() { Year = "2010", SalesRate = 1400 });
            this.DataCollection.Add(new Axis3DChartsModel() { Year = "2011", SalesRate = 800 });
            this.DataCollection.Add(new Axis3DChartsModel() { Year = "2012", SalesRate = 4000 });
            this.DataCollection.Add(new Axis3DChartsModel() { Year = "2013", SalesRate = 6000 });
            this.DataCollection.Add(new Axis3DChartsModel() { Year = "2014", SalesRate = 11000 });
            this.DataCollection.Add(new Axis3DChartsModel() { Year = "2015", SalesRate = 8000 });
        }
    }
}
