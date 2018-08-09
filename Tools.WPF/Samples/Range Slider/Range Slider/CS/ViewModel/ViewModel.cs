using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Tools.Controls;


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

        private ICommand rangestartchanged;
        public ICommand RangeStartChanged
        {
            get { return rangestartchanged; }
            set
            {
                rangestartchanged = value;
                this.RaisePropertyChanged("RangeStartChanged");
            }
        }

        private ICommand rangeendchanged;
        public ICommand RangeEndChanged
        {
            get { return rangeendchanged; }
            set
            {
                rangeendchanged = value;
                this.RaisePropertyChanged("RangeEndChanged");
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
                endval = value;
                this.RaisePropertyChanged(() => this.EndValue);
            }
        }



        private ObservableCollection<Items> itemssource;
        public ObservableCollection<Items> Itemssource
        {
            get { return itemssource; }
            set { itemssource = value; }
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
        #endregion

        #region Constructor
        public ViewModel()
        {
            rangechanged = new DelegateCommand<object>(rangeslider_RangeChanged);
            rangestartchanged = new DelegateCommand<object>(rangestart_ValueChanged);
            rangeendchanged = new DelegateCommand<object>(rangeend_ValueChanged);
        }
        #endregion


        #region methods
       
        private void rangeslider_RangeChanged(object param)
        {
            if (param != null && param is DoubleRange)
            {
                coll.Add("Start= " + (param as DoubleRange).Start.ToString() + " :  End= " + (param as DoubleRange).End.ToString());
                EventLogsCollection = coll;
            }
        }

        private void rangestart_ValueChanged(object param)
        {
            RangeVal = new DoubleRange(StartValue, EndValue);
            coll.Add("Start= " + (rangeval as DoubleRange).Start.ToString() + " :  End= " + (rangeval as DoubleRange).End.ToString());
            EventLogsCollection = coll;
        }

        private void rangeend_ValueChanged(object param)
        {

            RangeVal = new DoubleRange(StartValue, EndValue);
            coll.Add("Start= " + (RangeVal as DoubleRange).Start.ToString() + " :  End= " + (RangeVal as DoubleRange).End.ToString());
            EventLogsCollection = coll;

        }
        #endregion
    }
}
