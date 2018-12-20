#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
    public class GrossCallModel : INotifyPropertyChanged
    {

        public GrossCallModel()
        {
            AnnualCallModel callType1 = new AnnualCallModel() { GrossCalls = 1000, CallType = "Home Phone" };
            AnnualCallModel callType2 = new AnnualCallModel() { GrossCalls = 3000, CallType = "Mobile Phone" };
            callType1.MonthlyCallDetails = new ObservableCollection<MonthlyCallModel>();
            callType2.MonthlyCallDetails = new ObservableCollection<MonthlyCallModel>();
            string[] month = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

            Random rand = new Random();
            for (int i = 0; i < 12; i++)
            {
                callType1.MonthlyCallDetails.Add(new MonthlyCallModel() { EmployeeRetention = rand.Next(0, 100), EmployeeRetention2 = rand.Next(0, 100), Monthname = month[i], ScheduleEfficiency = rand.Next(0, 100), ScheduleEfficiency2 = rand.Next(0, 100), ServiceUtilization = rand.Next(0, 100), ServiceUtilization2 = rand.Next(0, 100), TotalCalls = rand.Next(750, 1000), ResolvedCalls = rand.Next(500, 750) });
                callType2.MonthlyCallDetails.Add(new MonthlyCallModel() { EmployeeRetention = rand.Next(0, 100), EmployeeRetention2 = rand.Next(0, 100), Monthname = month[i], ScheduleEfficiency = rand.Next(0, 100), ScheduleEfficiency2 = rand.Next(0, 100), ServiceUtilization = rand.Next(0, 100), ServiceUtilization2 = rand.Next(0, 100), TotalCalls = rand.Next(750, 1000), ResolvedCalls = rand.Next(0, 750) });
            }
            CallDetails = new ObservableCollection<AnnualCallModel>();
            CallDetails.Add(callType1);
            CallDetails.Add(callType2);

            this._SelectedCallDetails = new AnnualCallModel();
        }
        private ObservableCollection<AnnualCallModel> _CallDetails;
        public ObservableCollection<AnnualCallModel> CallDetails
        {
            get
            {
                return _CallDetails;
            }
            set
            {
                _CallDetails = value;
                this.OnPropertyChanged("CallDetails");
            }
        }

        private AnnualCallModel _SelectedCallDetails = new AnnualCallModel();
        public AnnualCallModel SelectedCallDetails
        {
            get
            {
                return _SelectedCallDetails;
            }
            set
            {
                _SelectedCallDetails = value;
                this.OnPropertyChanged("SelectedCallDetails");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(object Property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Property"));
            }
        }

    }
}
