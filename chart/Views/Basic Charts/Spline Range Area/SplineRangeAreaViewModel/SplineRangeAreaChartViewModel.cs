#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
    public class SplineRangeAreaChartViewModel
    {
        public ObservableCollection<SplineRangeAreaModel> SplineRangeAreaData { get; set; }

        public SplineRangeAreaChartViewModel()
        {
            SplineRangeAreaData = new ObservableCollection<SplineRangeAreaModel>
            {
                new SplineRangeAreaModel(new DateTime(2022, 08, 01),59.60,56.74),
                new SplineRangeAreaModel(new DateTime(2022, 08, 02),59.37,58.02),
                new SplineRangeAreaModel(new DateTime(2022, 08, 03),58.78,57.81),
                new SplineRangeAreaModel(new DateTime(2022, 08, 04),58.27,57.42),
                new SplineRangeAreaModel(new DateTime(2022, 08, 05),58.58,57.14),
                new SplineRangeAreaModel(new DateTime(2022, 08, 08),59.94,58.44),
                new SplineRangeAreaModel(new DateTime(2022, 08, 09),59.40,58.45),
                new SplineRangeAreaModel(new DateTime(2022, 08, 10),60.73,59.26),
                new SplineRangeAreaModel(new DateTime(2022, 08, 11),61.83,60.86),
                new SplineRangeAreaModel(new DateTime(2022, 08, 12),62.43,61.33),
                new SplineRangeAreaModel(new DateTime(2022, 08, 15),62.57,61.73),
                new SplineRangeAreaModel(new DateTime(2022, 08, 16),63.47,61.78),
                new SplineRangeAreaModel(new DateTime(2022, 08, 17),62.75,61.87),
                new SplineRangeAreaModel(new DateTime(2022, 08, 18),62.37,61.68),
                new SplineRangeAreaModel(new DateTime(2022, 08, 19),61.35,60.32),
                new SplineRangeAreaModel(new DateTime(2022, 08, 22),59.46,58.05),
                new SplineRangeAreaModel(new DateTime(2022, 08, 23),60.34,58.49),
                new SplineRangeAreaModel(new DateTime(2022, 08, 24),60.33,59.23),
                new SplineRangeAreaModel(new DateTime(2022, 08, 25),62.20,60.35),
                new SplineRangeAreaModel(new DateTime(2022, 08, 26),61.37,58.71),
                new SplineRangeAreaModel(new DateTime(2022, 08, 29),59.98,57.99),
                new SplineRangeAreaModel(new DateTime(2022, 08, 30),60.25,58.02),
            };
        }
    }
}
