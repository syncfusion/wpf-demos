#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using PatientDetailsDemo;
using System.ComponentModel;

namespace PatientDetailsDemo
{
    public class PatientDataRandomModel
    {

        public ObservableCollection<ChartPoint> randomData = new ObservableCollection<ChartPoint>();

        public ObservableCollection<ChartPoint> randomData2 = new ObservableCollection<ChartPoint>();

        public ObservableCollection<ChartPoint> randomData3 = new ObservableCollection<ChartPoint>();

        public int[] yValues1 = new int[] { 2, 4, 8, 4, 2, 1, 2, 1, 2, 0, 2, 3, 7, 14, 7, 3, 0, 2 };

        public int[] yValues2 = new int[] { 2, 0, 2, 3, 6, 8, 10, 5, 1, 3, 5, 3, 2, 1, 2, 4, 2, 1 };

        public int[] yValues3 = new int[] { 2, 1, 0, 2, 3, 7, 3, 1, -1, 3, 6, 9, 6, 2, 3, 0, 2, 3 };

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

        

    }

    public class ChartPoint:INotifyPropertyChanged
    {
        public ChartPoint(double x,double y)
        {
            this.X = x;
            this.Y = y;
        }
        private double x;

        private double y;

        public double X
        {

            get
            {

                return x;
            }
            set
            {
                x = value;
                OnPropertyChanged("X");
            }
        }

        public double Y
        {

            get
            {

                return y;
            }
            set
            {
                y = value;
                OnPropertyChanged("Y");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
