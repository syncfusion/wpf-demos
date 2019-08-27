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
    /// Interaction logic for Reminder.xaml
    /// </summary>
    /// 
    #region Reminder Class

    public partial class Reminder : Window
    {
        #region Constructor

        public Reminder()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        #endregion

        #region DependencyProperties

     #region ReminderAppCollection

        public ScheduleAppointmentCollection ReminderAppCollection
        {
            get { return (ScheduleAppointmentCollection)GetValue(ReminderAppCollectionProperty); }
            set { SetValue(ReminderAppCollectionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ReminderAppointmentCollection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReminderAppCollectionProperty =
            DependencyProperty.Register("ReminderAppCollection", typeof(ScheduleAppointmentCollection), typeof(Reminder), new PropertyMetadata(null));

        #endregion


     #endregion

        #region Events

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Remind_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.listbox.SelectedItem != null)
            {
                ScheduleAppointment app = this.listbox.SelectedItem as ScheduleAppointment;
                app.ReminderTime = ReminderTimeType.None;
                this.ReminderAppCollection.Remove(app);
            }
            if (this.ReminderAppCollection.Count == 0)
            {
                this.Close();
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ScheduleAppointment app = (sender as ListBox).SelectedItem as ScheduleAppointment;
            if (app != null)
            {
               
                DismissAll.IsEnabled = true;
            }
            else
            {
               
                DismissAll.IsEnabled = false;
            }
        }
               
        private void DismissAll_Click(object sender, RoutedEventArgs e)
        {
            if (ReminderAppCollection.Count > 0)
            {
                foreach (ScheduleAppointment app in ReminderAppCollection)
                {
                    app.ReminderTime = ReminderTimeType.None;

                }
                this.ReminderAppCollection.Clear();
                this.Close();
            }
        }

        #endregion
    }

    #endregion
}
