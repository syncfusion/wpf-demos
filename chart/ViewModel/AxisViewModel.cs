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
    public class AxisViewModel
    {
        public AxisViewModel()
        {
            this.DataPoints = new ObservableCollection<AxisModel>();
            DateTime year = new DateTime(1995, 1, 1);

            DataPoints.Add(new AxisModel() { Year = year.AddYears(0), Profit = 80 });
            DataPoints.Add(new AxisModel() { Year = year.AddYears(1), Profit = 200 });
            DataPoints.Add(new AxisModel() { Year = year.AddYears(2), Profit = 400 });
            DataPoints.Add(new AxisModel() { Year = year.AddYears(3), Profit = 600 });
            DataPoints.Add(new AxisModel() { Year = year.AddYears(4), Profit = 700 });
            DataPoints.Add(new AxisModel() { Year = year.AddYears(5), Profit = 1400 });
            DataPoints.Add(new AxisModel() { Year = year.AddYears(6), Profit = 2000 });
            DataPoints.Add(new AxisModel() { Year = year.AddYears(7), Profit = 4000 });
            DataPoints.Add(new AxisModel() { Year = year.AddYears(8), Profit = 6000 });
            DataPoints.Add(new AxisModel() { Year = year.AddYears(9), Profit = 8000 });
            DataPoints.Add(new AxisModel() { Year = year.AddYears(10), Profit = 11000 });

            this.CategoryData1 = new ObservableCollection<AxisModel>();
            CategoryData1.Add(new AxisModel() { XValue = "South Korea", YValue = 39 });
            CategoryData1.Add(new AxisModel() { XValue = "India", YValue = 20 });
            CategoryData1.Add(new AxisModel() { XValue = "China", YValue = 65 });

            this.CategoryData2 = new ObservableCollection<AxisModel>();
            CategoryData2.Add(new AxisModel() { XValue = "France", YValue = 55 });
            CategoryData2.Add(new AxisModel() { XValue = "Italy", YValue = 34 });
            CategoryData2.Add(new AxisModel() { XValue = "United Kingdom", YValue = 31 });

            this.DateTimeData = new ObservableCollection<AxisModel>();

            Random rand = new Random();
            double value = 100;
            DateTime date = new DateTime(2017, 1, 1);

            for (int i = 0; i < 365; i++)
            {
                if (rand.NextDouble() > 0.5)
                    value += rand.NextDouble();
                else
                    value -= rand.NextDouble();

                DateTimeData.Add(new AxisModel { Growth = value, Date = date });
                date = date.AddDays(1);

            }

            NumericData = new ObservableCollection<AxisModel>();
            NumericData.Add(new AxisModel() { Value = 16, Size = 5  });
            NumericData.Add(new AxisModel() { Value = 17, Size = 14 });
            NumericData.Add(new AxisModel() { Value = 18, Size = 7  });
            NumericData.Add(new AxisModel() { Value = 19, Size = 13  });
            NumericData.Add(new AxisModel() { Value = 20, Size = 18 });

            NumericData1 = new ObservableCollection<AxisModel>();
            NumericData1.Add(new AxisModel() { Value = 16, Size = 12 });
            NumericData1.Add(new AxisModel() { Value = 17, Size = 7  });
            NumericData1.Add(new AxisModel() { Value = 18, Size = 11});
            NumericData1.Add(new AxisModel() { Value = 19, Size = 17 });
            NumericData1.Add(new AxisModel() { Value = 20, Size = 24 });

        }

        public ObservableCollection<AxisModel> DataPoints
        {
            get;
            set;
        }

        public ObservableCollection<AxisModel> CategoryData1
        {
            get;
            set;
        }

        public ObservableCollection<AxisModel> CategoryData2
        {
            get;
            set;
        }
        public ObservableCollection<AxisModel> DateTimeData
        {
            get;
            set;
        }

        public ObservableCollection<AxisModel> NumericData
        {
            get;
            set;
        }
        public ObservableCollection<AxisModel> NumericData1
        {
            get;
            set;
        }
    }
}
