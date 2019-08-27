#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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

namespace SortingDemo
{
    #region Data

    public class ViewModel
    {

        public ViewModel()
        {
            int[] year = { 0, 3, 2, 2, 3, 5, 8, 3, 5, 9, 6, 2, 8, 9, 4, 5 };
            DateTime[] date = { new DateTime(2010,1,12),
                                  new DateTime(2010,3,12),
                                  new DateTime(2010,2,22),
                                  new DateTime(2010,3,1),
                                  new DateTime(2010,2,3),
                                  new DateTime(2010,4,5),
                                  new DateTime(2010,10,15),
                                  new DateTime(2010,8,30),
                                  new DateTime(2010,7,18),
                                  new DateTime(2010,12,1)};
            string[] name = { "Jan", "Mar", "Feb", "Jun", "May", "Aug", "Sep", "Oct", "Nov", "Dec" };
            Values = new ObservableCollection<ChartValue>();
            var yList1 = new double[] { 4, 5, 8, 20, 9, 14, 22, 38, 18, 9 };
            var yList2 = new double[] { 20, 12, 25, 10, 5, 10, 16, 30, 10, 2 };
            var yList3 = new double[] { 3, 4, 6, 19, 8, 11, 20, 36, 16, 5 };
            var yList4 = new double[] { 2, 3, 5, 1, 6, 5, 3, 2, 4, 7 };
            for (int i = 0; i < 9; i++)
                Values.Add(new ChartValue() { XVal = name[i], Y1 = yList1[i], Y2 = yList2[i], Y3 = yList3[i], Y4 = yList4[i], XDate = date[i].Date });
        }


        public ObservableCollection<ChartValue> Values
        {
            get;
            set;
        }

        public Array DirectionCollection
        {
            get { return Enum.GetValues(typeof(Direction)); }
        }

        public Array SortingCollection
        {
            get { return Enum.GetValues(typeof(Syncfusion.Windows.Chart.SortingAxis)); }
        }

        public Array TypesCollection
        {
            get
            {
                return new ChartTypes[] {   
                                                        ChartTypes.Column, 
                                                        ChartTypes.Line,
                                                        ChartTypes.Bubble
                                                        
                                                    };
            }
        }
    }

   



    #endregion
}

