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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Charts;

namespace syncfusion.chartdemos.wpf
{
    public class PieChartViewModel : NotificationObject
    {
        private double startAngle;
        private double endAngle;
        public IList<PieChartModel> PieData { get; set; }
        public IList<PieChartModel> SemiPieData { get; set; }


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
    }
}
