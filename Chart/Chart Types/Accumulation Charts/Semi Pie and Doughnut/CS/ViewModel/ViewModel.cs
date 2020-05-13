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

namespace Semi_PieSeries
{
    public class ViewModel : ObservableCollection<DataValues>, INotifyPropertyChanged
    {
        public double StartAngle
        {
            get
            {
                return startAngle;
            }

            set
            {
                startAngle = value;
                OnPropertyChanged("StartAngle");
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
                OnPropertyChanged("EndAngle");
            }
        }

        public string[] SeriesType
        {
            get
            {
                return new string[] { "Pie", "Doughnut" };
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private double startAngle;
        private double endAngle;

        public ViewModel()
        {
            StartAngle = 180;
            EndAngle = 360;

            Add(new DataValues(43, 32));
            Add(new DataValues(20, 34));
            Add(new DataValues(67, 41));
            Add(new DataValues(52, 42));
            Add(new DataValues(71, 48));
            Add(new DataValues(30, 45));
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
