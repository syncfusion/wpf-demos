#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CustomizationDemo
{
    /// <summary>
    /// Interaction logic for CustomEditor.xaml
    /// </summary>
    public partial class CustomEditor : Window, INotifyPropertyChanged
    {
        public ScheduleAppointmentCollection Appointments { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public CustomEditor()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Loaded += CustomEditor_Loaded;
            this.Closing += CustomEditor_Closing;
        }

        private void CustomEditor_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private void CustomEditor_Loaded(object sender, RoutedEventArgs e)
        {
            this.apptype.ItemsSource = Enum.GetValues(typeof(AppointmentTypes));
            this.apptype.SelectedIndex = 0;
            this.reminder.ItemsSource = Enum.GetValues(typeof(ReminderTimeType));
            reminder.SelectedIndex = 0;
        }

        public CustomEditor(ScheduleAppointmentCollection appointments):this()
        {
            this.Appointments = appointments;
        }

        private Appointment _appointment;
        public Appointment Appointment
        {
            get { return _appointment; }
            set
            {
                _appointment = value;
                this.OnPropertyChanged("Appointment");
            }
        }
        
        private void OnPropertyChanged(String name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Appointment appointment = this.Appointment;
            DateTime date = (DateTime)this.editstarttime.DateTime;
            appointment.Subject = this.sub.Text;
            appointment.ReminderTime = (ReminderTimeType)this.reminder.SelectedItem;
            appointment.StartTime = ((DateTime)this.editstartmonth.DateTime).Date.Add(new TimeSpan(date.Hour, date.Minute, date.Second));
            appointment.AppointmentTime = appointment.StartTime.ToString("hh:mm tt");
            appointment.Location = this.where.Text;
            DateTime date1 = (DateTime)this.editendtime.DateTime;
            appointment.EndTime = ((DateTime)this.editendmonth.DateTime).Date.Add(new TimeSpan(date1.Hour, date1.Minute, date1.Second));
            if (appointment.StartTime == appointment.EndTime)
                appointment.EndTime = appointment.EndTime.AddHours(1);

            if (this.apptype.SelectedItem != null)
            {
                appointment.AppointmentType = (AppointmentTypes)this.apptype.SelectedItem;
            }
            else
            {
                appointment.AppointmentType = AppointmentTypes.Family;
            }
            SetImageForAppointment(appointment);
            if (!this.Appointments.Contains(appointment))
                this.Appointments.Add(appointment);

        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;
            if (this.Appointment != null)
            {
                this.Appointments.Remove(this.Appointment);
            }
        }

        internal void EditAppointment()
        {
            this.Visibility = Visibility.Visible;
            this.delete.Visibility = Visibility.Visible;
        }

        internal void AddAppointment()
        {
            this.apptype.SelectedIndex = 0;
            this.Visibility = Visibility.Visible;
            this.delete.Visibility = Visibility.Collapsed;
        }

        public void SetImageForAppointment(Appointment appointment)
        {
            switch (appointment.AppointmentType)
            {
                case AppointmentTypes.Family:
                    {
                        appointment.AppointmentImageURI = new BitmapImage(new Uri("pack://application:,,,/CustomizationDemo;Component/Assets/Cake.png"));
                        break;
                    }
                case AppointmentTypes.Health:
                    {
                        appointment.AppointmentImageURI = new BitmapImage(new Uri("pack://application:,,,/CustomizationDemo;Component/Assets/Hospital.png"));
                        break;
                    }
                case AppointmentTypes.Office:
                    {
                        appointment.AppointmentImageURI = new BitmapImage(new Uri("pack://application:,,,/CustomizationDemo;Component/Assets/Team.png"));
                        break;
                    }
            }
        }
    }
}
