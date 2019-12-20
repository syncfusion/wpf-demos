#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CustomizationDemo
{
    public class ViewModel
    {
        public ViewModel()
        {
            this.LoadAppointments();
        }

        private ScheduleAppointmentCollection appointments;

        public ScheduleAppointmentCollection Appointments
        {
            get { return appointments; }
            set { appointments = value; }
        }

        private void LoadAppointments()
        {
            Appointments = new ScheduleAppointmentCollection();
            DateTime currentdate = DateTime.Now.Date;
            if (currentdate.DayOfWeek == System.DayOfWeek.Friday || currentdate.DayOfWeek == System.DayOfWeek.Saturday)
                currentdate = currentdate.SubtractDays(3);
            else if (currentdate.DayOfWeek == System.DayOfWeek.Sunday || currentdate.DayOfWeek == System.DayOfWeek.Monday)
                currentdate = currentdate.AddDays(3);
            Appointments.Add(new Appointment()
            {
                AppointmentImageURI = new BitmapImage(new Uri("pack://application:,,,/CustomizationDemo;Component/Assets/Hospital.png")),
                AppointmentType = AppointmentTypes.Health,
                Status = new ScheduleAppointmentStatus { Brush = new SolidColorBrush(Colors.Green), Status = "Free" },
                StartTime = currentdate.AddHours(12),
                AppointmentTime = currentdate.AddHours(12).ToString("hh:mm tt"),
                EndTime = currentdate.AddHours(15),
                Subject = "Checkup",
                Location = "Chennai",
                AppointmentBackground = new SolidColorBrush(Color.FromArgb(255, 236, 12, 12))
            });
            currentdate = currentdate.AddHours(4);
            Appointments.Add(new Appointment()
            {
                AppointmentImageURI = new BitmapImage(new Uri("pack://application:,,,/CustomizationDemo;Component/Assets/Cake.png")),
                AppointmentType = AppointmentTypes.Family,
                Status = new ScheduleAppointmentStatus { Brush = new SolidColorBrush(Colors.Green), Status = "Free" },
                StartTime = currentdate.Date.SubtractDays(2).AddHours(1),
                AppointmentTime = currentdate.Date.SubtractDays(2).AddHours(1).ToString("hh:mm tt"),
                EndTime = currentdate.Date.SubtractDays(2).AddHours(4),
                Subject = "My B'day",
                AppointmentBackground = new SolidColorBrush(Color.FromArgb(255, 180, 31, 125))
            });
            Appointments.Add(new Appointment()
            {
                AppointmentImageURI = new BitmapImage(new Uri("pack://application:,,,/CustomizationDemo;Component/Assets/Team.png")),
                AppointmentType = AppointmentTypes.Office,
                Status = new ScheduleAppointmentStatus { Brush = new SolidColorBrush(Colors.Green), Status = "Free" },
                StartTime = currentdate.Date.AddDays(2).AddHours(9),
                AppointmentTime = currentdate.Date.AddDays(2).AddHours(9).ToString("hh:mm tt"),
                EndTime = currentdate.Date.AddDays(2).AddHours(12),
                Subject = "Meeting",
                AppointmentBackground = new SolidColorBrush(Color.FromArgb(255, 60, 181, 75))
            });
        }
    }
}
