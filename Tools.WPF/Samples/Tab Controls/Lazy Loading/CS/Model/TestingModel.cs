using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;

namespace TabControlExtDemo
{
    public class TestingModel :NotificationObject
    {
        double _x;
        double _y;

        public double X 
        { 
            get
            {
                return _x;
            }
            set
            {
                _x = value;
                RaisePropertyChanged("X");
            }
        }

        public double Y 
        { 
            get
            {
                return _y;
            }
            set
            {
                _y = value;
                RaisePropertyChanged("Y");
            }
        }
    }
}
