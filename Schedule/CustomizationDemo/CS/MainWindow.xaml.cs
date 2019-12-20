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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using Syncfusion.UI.Xaml.Schedule;
using System.Globalization;
using System.Threading;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Controls.Navigation;
using System.Reflection;

namespace CustomizationDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    #region MainWindow Class

    public partial class MainWindow : Window
    {
        CustomEditor customeEditor;
        Reminder reminder;
        double XPosition;
        double YPosition;
        Appointment copiedAppointment;
        public Appointment Appointment { get; set; }
        public DateTime CurrentSelectedDate { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            customeEditor = new CustomEditor(this.Schedule.Appointments);
            SourceInitialized += (s, a) =>
            {
                customeEditor.Owner = this;
            };
        
        }

        #region Events
        void Schedule_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (RadialPopup != null)
                RadialPopup.IsOpen = false;
        }

        void Schedule_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (RadialPopup != null)
                RadialPopup.IsOpen = false;
        }

        void Schedule_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            XPosition = e.GetPosition(this).X;
            YPosition = e.GetPosition(this).Y;
        }

        private void Schedule_ReminderOpening(object sender, ReminderControlOpeningEventArgs e)
        {
            e.Cancel = true;
            this.IsHitTestVisible = false;

            reminder = new Reminder();
            reminder.Owner = this;
            reminder.Closed += reminder_Closed;
            reminder.ReminderAppCollection = e.RemindAppCollection as ScheduleAppointmentCollection;
            reminder.Show();
        }

        void reminder_Closed(object sender, EventArgs e)
        {
            this.IsHitTestVisible = true;
        }

        void Schedule_AppointmentEditorOpening(object sender, AppointmentEditorOpeningEventArgs e)
        {
            e.Cancel = true;
            if (e.Action == EditorAction.Add)
            {
                this.AddnewAppointment(new Appointment() { StartTime = e.StartTime, EndTime = e.StartTime });
            }
            else
                this.EditAppointment(e.Appointment as Appointment);
        }

        private void EditAppointment(Appointment appointment)
        {
            customeEditor.Appointment = appointment;
            customeEditor.EditAppointment();
            customeEditor.ShowDialog();
        }

        private void AddnewAppointment(Appointment newappointment)
        {
            customeEditor.Appointment = newappointment;
            customeEditor.AddAppointment();
            if (customeEditor.ShowDialog() == true)
                this.Schedule.Appointments.Add(newappointment);
        }

        void MainWindow_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (RadialPopup != null)
                RadialPopup.IsOpen = false;
        }

        void Schedule_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!RadialPopup.IsMouseOver && RadialPopup.IsOpen)
                RadialPopup.IsOpen = false;
        }

        void Schedule_PopupMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            if (XPosition > ActualWidth / 2)
            {
                RadialPopup.HorizontalOffset = -50;
            }
            else
            {
                RadialPopup.HorizontalOffset = 200;
            }
            if (YPosition > ActualHeight - 250)
            {
                RadialPopup.VerticalOffset = -200;
            }
            else
            {
                RadialPopup.VerticalOffset = 50;
            }

            RadialPopup.IsOpen = false;
            e.Cancel = true;
            RadialPopup.IsOpen = true;
            radialMenu.IsOpen = true;
            if (e.CurrentSelectedDate != null)
            {
                CurrentSelectedDate = (DateTime)e.CurrentSelectedDate;
            }

            if (e.Appointment != null)
            {
                for (int i = 0; i < radialMenu.Items.Count; i++)
                {
                    if (i == 3 && copiedAppointment == null)
                    {
                        (radialMenu.Items[i] as SfRadialMenuItem).IsEnabled = false;
                        (radialMenu.Items[i] as SfRadialMenuItem).Opacity = 0.5;
                    }
                    else
                    {
                        (radialMenu.Items[i] as SfRadialMenuItem).IsEnabled = true;
                        (radialMenu.Items[i] as SfRadialMenuItem).Opacity = 1;
                    }
                }

            }
            else
            {
                (radialMenu.Items[1] as SfRadialMenuItem).IsEnabled = false;
                (radialMenu.Items[1] as SfRadialMenuItem).Opacity = 0.5;
                (radialMenu.Items[2] as SfRadialMenuItem).IsEnabled = false;
                (radialMenu.Items[2] as SfRadialMenuItem).Opacity = 0.5;
                (radialMenu.Items[5] as SfRadialMenuItem).IsEnabled = false;
                (radialMenu.Items[5] as SfRadialMenuItem).Opacity = 0.5;
                (radialMenu.Items[0] as SfRadialMenuItem).IsEnabled = true;
                if (copiedAppointment != null)
                {
                    (radialMenu.Items[3] as SfRadialMenuItem).IsEnabled = true;
                    (radialMenu.Items[3] as SfRadialMenuItem).Opacity = 1;
                }
                else
                {
                    (radialMenu.Items[3] as SfRadialMenuItem).IsEnabled = false;
                    (radialMenu.Items[3] as SfRadialMenuItem).Opacity = 0.5;
                }

            }
        }

        void pasteButton_Click(object sender, RoutedEventArgs e)
        {
            RadialPopup.IsOpen = false;
            if (this.copiedAppointment != null)
            {
                Appointment app = this.copiedAppointment;
                TimeSpan appTimeDiff = app.EndTime - app.StartTime;
                Appointment appointment = new Appointment();
                appointment.Subject = app.Subject;
                appointment.Notes = app.Notes;
                appointment.Location = app.Location;
                appointment.ReadOnly = app.ReadOnly;
                appointment.AppointmentBackground = app.AppointmentBackground;
                appointment.AppointmentTime = this.CurrentSelectedDate.ToString("hh:mm tt");
                appointment.AppointmentType = app.AppointmentType;
                customeEditor.SetImageForAppointment(appointment);
                appointment.StartTime = (DateTime)this.CurrentSelectedDate;
                appointment.EndTime = ((DateTime)this.CurrentSelectedDate).Add(appTimeDiff);
                Schedule.Appointments.Add(appointment);
            }
        }

        void copyButton_Click(object sender, RoutedEventArgs e)
        {
            RadialPopup.IsOpen = false;
            copiedAppointment = (Appointment)Schedule.SelectedAppointment;
        }

        void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            RadialPopup.IsOpen = false;
            if (Schedule.SelectedAppointment != null)
                Schedule.Appointments.Remove(Schedule.SelectedAppointment);
        }

        void editButton_Click(object sender, RoutedEventArgs e)
        {
            RadialPopup.IsOpen = false;
            customeEditor.EditAppointment();
            this.EditAppointment(this.Schedule.SelectedAppointment as Appointment);
        }

        void addButton_Click(object sender, RoutedEventArgs e)
        {
            RadialPopup.IsOpen = false;
            if (customeEditor.Appointment != null)
                this.Schedule.Appointments.Add(customeEditor.Appointment);
            customeEditor.AddAppointment();
            if (CurrentSelectedDate != null)
                this.AddnewAppointment(new Appointment() { StartTime = CurrentSelectedDate, EndTime = CurrentSelectedDate });
        }

        #endregion
    }

    #endregion

   
}
