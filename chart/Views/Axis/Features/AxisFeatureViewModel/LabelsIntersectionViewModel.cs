#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.UI.Xaml.Charts;
using System.Windows;

namespace syncfusion.chartdemos.wpf
{
    public class LabelsIntersectionViewModel
    {
        public ObservableCollection<LabelsIntersectionModel> PlayersGoalsDetails { get; set; }
        public Array LabelsIntersectionArray 
        {
            get
            {
                return new string[]
                {
                    "None",
                    "MultipleRows",
                    "Hide",
                    "Auto"
                };
            }
        }

        public LabelsIntersectionViewModel()
        {
            PlayersGoalsDetails = new ObservableCollection<LabelsIntersectionModel>();

            PlayersGoalsDetails.Add(new LabelsIntersectionModel("Cristiano Ronaldo", 847));
            PlayersGoalsDetails.Add(new LabelsIntersectionModel("Lionel Messi", 818));
            PlayersGoalsDetails.Add(new LabelsIntersectionModel("Pele", 762));
            PlayersGoalsDetails.Add(new LabelsIntersectionModel("Gerd Muller", 634));
            PlayersGoalsDetails.Add(new LabelsIntersectionModel("Romario", 755));
            PlayersGoalsDetails.Add(new LabelsIntersectionModel("Ferenc Puskas", 724));
            PlayersGoalsDetails.Add(new LabelsIntersectionModel("Eusebio", 619));
            PlayersGoalsDetails.Add(new LabelsIntersectionModel("Joe Bambrick", 629));
            PlayersGoalsDetails.Add(new LabelsIntersectionModel("Glenn Ferguson", 563));
            PlayersGoalsDetails.Add(new LabelsIntersectionModel("Abe Lenstra", 624));
            PlayersGoalsDetails.Add(new LabelsIntersectionModel("Jimmy Jones", 648));
            PlayersGoalsDetails.Add(new LabelsIntersectionModel("Josef Bican", 722));
            PlayersGoalsDetails.Add(new LabelsIntersectionModel("Uwe Seeler", 552));
        }
    }
}
