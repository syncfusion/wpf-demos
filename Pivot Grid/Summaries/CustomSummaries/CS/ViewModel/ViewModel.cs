#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.Collections.Generic;
using System.Collections.ObjectModel;
using CustomSummaries.Model;
using Syncfusion.PivotAnalysis.Base;

namespace CustomSummary.ViewModel
{
    public class ViewModel
    {
        private List<DataPoint> data;

        public List<DataPoint> Data
        {
            get
            {
                this.data = this.data ?? new List<DataPoint>
                {
                    new DataPoint(1, "Animals", "Turtle","India","Chennai", 10583.32M, 1000, 8000.22, 1583.10),
                    new DataPoint(1, "Animals", "Cat","India","Chennai" ,10583.32M, 2000, 7000.22, 1583.10),
                    new DataPoint(1, "Trees", "Dog","India","Chennai", 10583.32M, 3000, 6000.22, 1583.10),
                    new DataPoint(1, "Trees", "Pig","India","Chennai", 10583.32M, 4000, 5000.22, 1583.10),
                    new DataPoint(1, "Trees", "Dog","India","Bombay", 10583.32M, 3000, 6000.22, 1583.10),
                    new DataPoint(1, "Trees", "Pig","India","Bombay", 10583.32M, 4000, 5000.22, 1583.10),
                    new DataPoint(1, "Trees", "Dog","India","Bombay", 10583.32M, 3000, 6000.22, 1583.10),
                    new DataPoint(1, "Trees", "Pig","India","Bombay", 10583.32M, 4000, 5000.22, 1583.10),
                    new DataPoint(1, "Animals", "Pig","India","Chennai", 10583.32M, 4000, 5000.22, 1583.10),
                    new DataPoint(1, "Animals", "Dog","India","Bombay", 10583.32M, 3000, 6000.22, 1583.10),
                    new DataPoint(1, "Animals", "Pig","India","Bombay", 10583.32M, 4000, 5000.22, 1583.10),
                    new DataPoint(1, "Animals", "Dog","India","Bombay", 10583.32M, 3000, 6000.22, 1583.10),
                    new DataPoint(1, "Animals", "Pig","India","Bombay", 10583.32M, 4000, 5000.22, 1583.10),
                    new DataPoint(1, "Animals", "Horse","India","Chennai", 10583.32M, 5000, 4000.22, 1583.10),
                    new DataPoint(1, "Animals", "Cow","India","Chennai", 10583.32M, 6000, 3000.22, 1583.10),
                    new DataPoint(1, "Animals", "Chicken?!","India","Chennai", 10583.32M, 7000, 2000.22, 1583.10),
                    new DataPoint(1, "Trees", "Oak","India","Chennai", 10583.32M, 1500, 8000.22, 1683.10),
                    new DataPoint(1, "Animals", "Cherry","England","Paris", 10583.32M, 1600, 8000.22, 1783.10),
                    new DataPoint(1, "Trees", "Maple","England","Paris", 10583.32M, 1700, 8000.22, 1783.10),
                    new DataPoint(1, "Animals", "Poplar","England","Paris", 10583.32M, 1800, 8000.22, 1383.10),
                    new DataPoint(1, "Trees", "Cedar","England","Albania", 10583.32M, 1900, 8000.22, 1183.10),
                    new DataPoint(1, "Animals", "Cherry","England","Albania", 10583.32M, 1600, 8000.22, 1783.10),
                    new DataPoint(1, "Trees", "Maple","England","Albania", 10583.32M, 1700, 8000.22, 1783.10),
                    new DataPoint(1, "Animals", "Poplar","England","Albania", 10583.32M, 1800, 8000.22, 1383.10),
                    new DataPoint(1, "Trees", "Cedar","England","Albania", 10583.32M, 1900, 8000.22, 1183.10),
                    new DataPoint(1, "Animals", "Birch","United States","Newyork", 10583.32M, 1010, 8000.22, 1383.10),
                    new DataPoint(1, "Trees", "Pine","United States","Newyork", 10583.32M, 1200, 8000.22, 1783.10),
                    new DataPoint(1, "Animals", "Spruce","United States","Newyork", 10583.32M, 1300, 8000.22, 1383.10),
                    new DataPoint(1, "Trees", "Spruce","United States","Newyork", 3333.32M, 1600, 9000.22, 3453.10),
                    new DataPoint(1, "Animals", "Spruce","United States","Newyork", 10583.32M, 1300, 8000.22, 1383.10),
                    new DataPoint(1, "Trees", "Spruce","United States","Newyork", 3333.32M, 1600, 9000.22, 3453.10),
                    new DataPoint(1, "Animals", "Birch","United States","Chicago", 10583.32M, 1010, 8000.22, 1383.10),
                    new DataPoint(1, "Trees", "Pine","United States","Chicago", 10583.32M, 1200, 8000.22, 1783.10),
                    new DataPoint(1, "Animals", "Spruce","United States","Chicago", 10583.32M, 1300, 8000.22, 1383.10),
                    new DataPoint(1, "Trees", "Spruce","United States","Chicago", 3333.32M, 1600, 9000.22, 3453.10),
                    new DataPoint(1, "Animals", "Spruce","United States","Chicago", 10583.32M, 1300, 8000.22, 1383.10),
                    new DataPoint(1, "Trees", "Spruce","United States","Chicago", 3333.32M, 1600, 9000.22, 3453.10)
              
                };
                return this.data;
            }
            set { this.data = value; }
        }

        public ObservableCollection<SummaryBase> CustomSummaryBaseClasses
        {
            get
            {
                return new ObservableCollection<SummaryBase> { new MyCustomSummaryBase2() };
            }
        }
    }
}