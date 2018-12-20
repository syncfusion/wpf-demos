#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
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
using Syncfusion.Windows.Chart;

namespace FastChartTypesDemo
{
   

    public class TestingValuesCollection
    {
        public TestingValuesCollection()
        {
            this.TestingModel = new ObservableCollection<TestingValues>();
            Random rd = new Random();
            for (int i = 0; i < 51; i++)
            {
                this.TestingModel.Add(new TestingValues() { X = i+1000, Y = rd.Next(30, 49), Y1 = rd.Next(0, 20), Y2 = rd.Next(10, 20), Y3 = rd.Next(30, 40) });
                //this.TestingModel.Add(new TestingValues() { X = i, Y = rd.Next(50, 100) });
            }           
        }

        public ObservableCollection<TestingValues> TestingModel { get; set; }        

        public class HiLoTestingValues
        {
            public double X { get; set; }

            public double Low { get; set; }

            public double Open { get; set; }

            public double High { get; set; }

            public double Close { get; set; }
        }

        public Array TypesCollection
        {
            get
            {
                return new ChartTypes[] { ChartTypes.FastLine, 
                                                    ChartTypes.FastScatter, 
                                                    ChartTypes.FastColumn,
                                                    ChartTypes.FastBar,
                                                    ChartTypes.FastStackingColumn,
                                                    ChartTypes.FastHiLoOpenClose,
													ChartTypes.FastSpline
                                                    };
            }
        }
    }
}