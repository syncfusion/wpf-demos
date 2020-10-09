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
using System.ComponentModel;

namespace syncfusion.patientmonitor.wpf
{
    public class PatientDataRandomModel
    {
        #region Fields Initialization

        public int[] yValues1 = new int[] { 2, 4, 8, 4, 2, 1, 2, 1, 2, 0, 2, 3, 7, 14, 7, 3, 0, 2 };

        public int[] yValues2 = new int[] { 2, 0, 2, 3, 6, 8, 10, 5, 1, 3, 5, 3, 2, 1, 2, 4, 2, 1 };

        public int[] yValues3 = new int[] { 2, 1, 0, 2, 3, 7, 3, 1, -1, 3, 6, 9, 6, 2, 3, 0, 2, 3 };

        public ObservableCollection<ChartPoint> randomData = new ObservableCollection<ChartPoint>();

        public ObservableCollection<ChartPoint> randomData2 = new ObservableCollection<ChartPoint>();

        public ObservableCollection<ChartPoint> randomData3 = new ObservableCollection<ChartPoint>();

        #endregion

        #region Constructor
        public PatientDataRandomModel()
        {
            int xval = 0;

            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < yValues1.Length; j++)
                {
                    randomData.Add(new ChartPoint(xval++, yValues1[j]));
                    randomData2.Add(new ChartPoint(xval++, yValues2[j]));
                    randomData3.Add(new ChartPoint(xval++, yValues3[j]));
                }
            }            
        }
        #endregion
    }    
}
