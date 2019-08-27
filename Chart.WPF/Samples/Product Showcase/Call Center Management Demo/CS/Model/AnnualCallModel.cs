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
using System.ComponentModel;

namespace CallCenterDemo
{
    public class AnnualCallModel:INotifyPropertyChanged
    {
        private ObservableCollection<MonthlyCallModel> _MonthlyCallDetails;
        public ObservableCollection<MonthlyCallModel> MonthlyCallDetails
        {
            get
            {
                return _MonthlyCallDetails;
            }
            set
            {
                _MonthlyCallDetails = value;
                this.OnPropertyChanged("MonthlyCallDetails");
            }

        }

        private double _GrossCalls;
        public double GrossCalls
        {
            get
            {
                return _GrossCalls;
            }
            set
            {
                _GrossCalls = value;
                this.OnPropertyChanged("GrossCalls");
            }
        }

        private string _CallType;
        public string CallType
        {
            get
            {
                return _CallType;
            }
            set
            {
                _CallType = value;
                this.OnPropertyChanged("CallType");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(object PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("PropertyName"));
            }
        }
    }
}
