#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Schedule;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CustomizationDemo
{
    #region Appointment Class
    public enum AppointmentTypes
    {
        Office,
        Health,
        Family
    }
    public class Appointment : ScheduleAppointment, INotifyPropertyChanged
    {
        #region public properties
        private ImageSource _imageuri;
        public ImageSource AppointmentImageURI
        {
            get { return _imageuri; }
            set
            {
                _imageuri = value;
                OnPropertyChanged("AppointmentImageURI");
            }
        }
        private string _appointmentTime;
        public string AppointmentTime
        {
            get {return _appointmentTime; }
            set
            {
                _appointmentTime = value;
                OnPropertyChanged("AppointmentTime");
            }
        }

        public AppointmentTypes AppointmentType { get; set; }

        #endregion

        private void OnPropertyChanged(string propertyName)
        {
            var eventHandler = PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public new event PropertyChangedEventHandler PropertyChanged;
    }

    #endregion
}
