#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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

namespace syncfusion.chartdemos.wpf
{
    public class AnnotationToolTipViewModel
    {
        public AnnotationToolTipViewModel()
        {
            DataModel = new ObservableCollection<AnnotationToolTipModel>();
            DataModel.Add(new AnnotationToolTipModel() { Over = 1, Runs = 4 });
            DataModel.Add(new AnnotationToolTipModel() { Over = 2, Runs = 8, PlayerName = "CL White", Score = "10 (6)" });
            DataModel.Add(new AnnotationToolTipModel() { Over = 3, Runs = 12 });
            DataModel.Add(new AnnotationToolTipModel() { Over = 4, Runs = 3 });
            DataModel.Add(new AnnotationToolTipModel() { Over = 5, Runs = 10 });
            DataModel.Add(new AnnotationToolTipModel() { Over = 6, Runs = 6 });
            DataModel.Add(new AnnotationToolTipModel() { Over = 7, Runs = 11, PlayerName = "AJ Finch", Score = "30 (24)" });
            DataModel.Add(new AnnotationToolTipModel() { Over = 8, Runs = 5 });
            DataModel.Add(new AnnotationToolTipModel() { Over = 9, Runs = 4 });
            DataModel.Add(new AnnotationToolTipModel() { Over = 10, Runs = 12 });
            DataModel.Add(new AnnotationToolTipModel() { Over = 11, Runs = 8 });
            DataModel.Add(new AnnotationToolTipModel() { Over = 12, Runs = 14, PlayerName = "GJ Smith", Score = "25 (14)" });
            DataModel.Add(new AnnotationToolTipModel() { Over = 13, Runs = 12 });
            DataModel.Add(new AnnotationToolTipModel() { Over = 14, Runs = 15 });
            DataModel.Add(new AnnotationToolTipModel() { Over = 15, Runs = 10 });
            DataModel.Add(new AnnotationToolTipModel() { Over = 16, Runs = 14 });
            DataModel.Add(new AnnotationToolTipModel() { Over = 17, Runs = 16 });
            DataModel.Add(new AnnotationToolTipModel() { Over = 18, Runs = 9 });
            DataModel.Add(new AnnotationToolTipModel() { Over = 19, Runs = 10, PlayerName = "GJ Bailey", Score = "78 (40)" });
            DataModel.Add(new AnnotationToolTipModel() { Over = 20, Runs = 18 });
        }
        public ObservableCollection<AnnotationToolTipModel> DataModel
        {
            get;
            set;
        }
    }   
}
