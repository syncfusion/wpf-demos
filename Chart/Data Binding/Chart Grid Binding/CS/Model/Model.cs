#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartDataEditing
{
    public class Model : INotifyPropertyChanged
    {
        public DateTime XValue
        {
            get { return xValue; }
            set
            {
                if (value != xValue)
                {
                    xValue = value;
                    OnPropertyChanged("XValue");
                }
            }
        }

        public double YValue
        {
            get { return yValue; }
            set
            {
                if (value != yValue)
                {
                    yValue = value;
                    OnPropertyChanged("YValue");
                }
            }
        }

        public double Scatter
        {
            get { return scatter; }
            set
            {
                if (value != scatter)
                {
                    scatter = value;
                    OnPropertyChanged("Scatter");
                }
            }
        }

        private DateTime xValue;
        private double yValue;
        private double scatter;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
