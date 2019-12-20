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
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Tools.Controls;
using System.Windows.Data;

namespace RangeSliderDemo
{
    public class ViewModel : NotificationObject
    {
        #region Properties
        private ICommand rangechanged;
        public ICommand RangeChanged
        {
            get { return rangechanged; }
            set
            {
                rangechanged = value;
                this.RaisePropertyChanged("RangeChanged");
            }
        }

        private DoubleRange rangeval = new DoubleRange(4.0, 8.0);
        public DoubleRange RangeVal
        {
            get { return rangeval; }
            set
            {
                rangeval = value;
                this.RaisePropertyChanged("RangeVal");
            }
        }

        private double startval = 4.0;
        public double StartValue
        {
            get { return startval; }
            set
            {
                if (value <= endval && value != StartValue)
                {
                    rangestart_ValueChanged(value, EndValue);
                }
                startval = value;
                this.RaisePropertyChanged(() => this.StartValue);
            }
        }

        private double endval = 8.0;
        public double EndValue
        {
            get { return endval; }
            set
            {
                if (value >= startval && value != EndValue)
                {
                    rangeend_ValueChanged(StartValue, value);
                }
                endval = value;
                this.RaisePropertyChanged(() => this.EndValue);
            }
        }

        private ObservableCollection<string> eventLogsCollection;
        public ObservableCollection<string> EventLogsCollection
        {
            get { return eventLogsCollection; }
            set
            {
                eventLogsCollection = value;
                this.RaisePropertyChanged(() => this.EventLogsCollection);
            }
        }

        public ObservableCollection<string> coll = new ObservableCollection<string>();

        private ObservableCollection<Syncfusion.Windows.Controls.Input.Items> customCollection = new ObservableCollection<Syncfusion.Windows.Controls.Input.Items>();

        public ObservableCollection<Syncfusion.Windows.Controls.Input.Items> CustomCollection
        {
            get { return customCollection; }
            set { customCollection = value; this.RaisePropertyChanged(() => this.CustomCollection); }
        }

        #endregion

        #region Constructor
        public ViewModel()
        {
            customCollection.Add(new Syncfusion.Windows.Controls.Input.Items() { label = "Zero", value = 0 });
            customCollection.Add(new Syncfusion.Windows.Controls.Input.Items() { label = "Two", value = 2 });
            customCollection.Add(new Syncfusion.Windows.Controls.Input.Items() { label = "Four", value = 4 });
            customCollection.Add(new Syncfusion.Windows.Controls.Input.Items() { label = "Six", value = 6 });
            customCollection.Add(new Syncfusion.Windows.Controls.Input.Items() { label = "Eight", value = 8 });
            customCollection.Add(new Syncfusion.Windows.Controls.Input.Items() { label = "Ten", value = 10 });       
    }
        #endregion


        #region methods

        private void rangestart_ValueChanged(double _StartValue, double _EndValue)
        {
            RangeVal = new DoubleRange(_StartValue, _EndValue);
            coll.Add("Start= " + (rangeval as DoubleRange).Start.ToString() + " :  End= " + (rangeval as DoubleRange).End.ToString());
            EventLogsCollection = coll;
        }

        private void rangeend_ValueChanged(double _StartValue, double _EndValue)
        {

            RangeVal = new DoubleRange(_StartValue, _EndValue);
            coll.Add("Start= " + (RangeVal as DoubleRange).Start.ToString() + " :  End= " + (RangeVal as DoubleRange).End.ToString());
            EventLogsCollection = coll;

        }
        #endregion
    }

    public class InverseBooleanConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

    }
}
