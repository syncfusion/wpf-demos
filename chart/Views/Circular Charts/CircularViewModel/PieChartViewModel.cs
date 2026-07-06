#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Provides data and angle settings for pie and semi-pie charts.</summary>
    public class PieChartViewModel : NotificationObject , IDisposable
    {
        private double startAngle;
        private double endAngle;

        /// <summary>Gets or sets the pie chart data.</summary>
        public IList<PieChartModel> PieData { get; set; }

        /// <summary>Gets or sets the semi pie chart data.</summary>
        public IList<PieChartModel> SemiPieData { get; set; }

        /// <summary>Gets or sets the pie start angle.</summary>
        public double StartAngle
        {
            get
            {
                return startAngle;
            }

            set
            {
                startAngle = value;
                RaisePropertyChanged(nameof(this.StartAngle));
            }
        }

        /// <summary>Gets or sets the pie end angle.</summary>
        public double EndAngle
        {
            get
            {
                return endAngle;
            }

            set
            {
                endAngle = value;
                RaisePropertyChanged(nameof(this.EndAngle));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PieChartViewModel"/> class.
        /// </summary>
        public PieChartViewModel()
        {
            StartAngle = 180;
            EndAngle = 360;

            // Pie
            PieData = new List<PieChartModel>
            {
                new PieChartModel("David", 16.6),
                new PieChartModel("Steve", 14.6),
                new PieChartModel("Jack", 18.6),
                new PieChartModel("John", 20.5),
                new PieChartModel("Regev", 39.5),
           };

            // Semi Pie
            SemiPieData = new List<PieChartModel>
            {
                 new PieChartModel("Mystery", 30),
                new PieChartModel("Horror", 7),
                new PieChartModel("Romance", 30),
                new PieChartModel("Biographies", 15),
                new PieChartModel("Science Fiction", 10),
                new PieChartModel("Self-help", 8),
            };
        }

        /// <summary>Releases resources and performs cleanup operations.</summary>
        public void Dispose()
        {
            if(PieData != null)
                PieData.Clear();

            if(SemiPieData != null)
                SemiPieData.Clear();
        }
    }
}
