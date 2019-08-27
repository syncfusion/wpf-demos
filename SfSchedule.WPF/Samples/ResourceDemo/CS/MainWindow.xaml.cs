#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Schedule;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ResourceDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    #region MainWindow Class

    public partial class MainWindow : ChromelessWindow
    {
        #region Properties

        private ScheduleAppointmentCollection appcollection;
        public ScheduleAppointmentCollection AppCollection
        {
            get { return appcollection; }
            set { appcollection = value; }
        }
        string[] subject = new string[] 
        { 
            "Heart Surgery","Lung Surgery",
            "Nose(Rhinoplasty)",
            "Ear Pinning (Otoplasty)",
            "Upper Eyelid Surgery",
            "Brow Lift",
            "Face & Neck Lift (Rhytidectomy)",
            "Botox injection",
            "Cheek Implants",
            "Chin Implant",
            "Thread Vein Removal By laser",
            "Laser and Intense Pulsed Light Therapies",
            "Varicose Treatment",
            "Varicose by Laser",
            "Scar revision",
            "Scar Reduction",
            "Tattoo Removal",
            "Mole removal",
            "Split Earlobe Repair",
            "Anti-Wrinkle Treatment",
            "Hair Reduction by laser",
            "Chemical Peels",
            "Dermabrasion",
            "Fat Transfer"
        };

        private ObservableCollection<DateTime> datecoll = new ObservableCollection<DateTime>();
        DateTime currentdate;

        #endregion

        #region Constructor

        public MainWindow()
        {
            this.InitializeComponent();
            this.OrderByDate.IsChecked = true;
            Random ran = new Random();
            DateTime today = DateTime.Now;
            if (today.Month == 12)
            {
               today= today.AddMonths(-1);
            }
            else if (today.Month == 1)
            {
               today= today.AddMonths(1);
            }
            int day = (int)today.DayOfWeek;
            DateTime currentWeek = DateTime.Now.AddDays(-day);

            DateTime startMonth = new DateTime(today.Year, today.Month - 1, 1, 0, 0, 0);
            for (int i = 1; i < 30; i += 2)
            {
                for (int j = -7; j < 14; j++)
                {
                    datecoll.Add(currentWeek.Date.AddDays(j).AddHours(ran.Next(9, 18)));
                }
            }

            ObservableCollection<SolidColorBrush> brush = new ObservableCollection<SolidColorBrush>();
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xA2, 0xC1, 0x39)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xD8, 0x00, 0x73)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x1B, 0xA1, 0xE2)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xE6, 0x71, 0xB8)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xF0, 0x96, 0x09)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x33, 0x99, 0x33)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0xAB, 0xA9)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xE6, 0x71, 0xB8)));

            AppCollection = new ScheduleAppointmentCollection();
            ScheduleAppointmentCollection tempcollection = new ScheduleAppointmentCollection();

            AppCollection = tempcollection;
            int count = 0;
            for (int m = 0; m < 30; m++)
            {
                currentdate = datecoll[ran.Next(0, datecoll.Count)];
                DateTime nextdate = datecoll[ran.Next(0, datecoll.Count)];
                count++;
                ScheduleAppointment appointment1 = new ScheduleAppointment() { StartTime = currentdate, EndTime = currentdate.AddHours(ran.Next(0, 2)), Subject = subject[count % subject.Length], Location = "Chennai", AppointmentBackground = brush[m % 3] };
                appointment1.ResourceCollection.Add(new Resource() { TypeName = "Doctors", ResourceName = "Dr.Jacob" });
                count++;
                ScheduleAppointment appointment2 = new ScheduleAppointment() { StartTime = nextdate, EndTime = nextdate.AddHours(ran.Next(0, 2)), Subject = subject[count % subject.Length], Location = "Chennai", AppointmentBackground = brush[(m + 2) % 3] };
                appointment2.ResourceCollection.Add(new Resource() { TypeName = "Doctors", ResourceName = "Dr.Darsy" });
                tempcollection.Add(appointment1);
                tempcollection.Add(appointment2);
            }

            Schedule1.AppointmentStatusCollection.Add(new ScheduleAppointmentStatus() { Status = "Temporary" });
            this.DataContext = this;

            (this.Schedule1.ScheduleResourceTypeCollection[0].ResourceCollection[0] as CustomResource).ResourceImageUri = new BitmapImage(new Uri("pack://application:,,,/ResourceDemo;Component/Assets/emp1.png"));
            (this.Schedule1.ScheduleResourceTypeCollection[0].ResourceCollection[1] as CustomResource).ResourceImageUri = new BitmapImage(new Uri("pack://application:,,,/ResourceDemo;Component/Assets/emp2.png"));
        }

        #endregion

        #region Events

        private void HeaderOrder_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as RadioButton).Name)
            {
                case "OrderByResource":
                    Schedule1.DayHeaderOrder = DayHeaderOrder.OrderByResource;
                    break;
                case "OrderByDate":
                    Schedule1.DayHeaderOrder = DayHeaderOrder.OrderByDate;
                    break;
            }
        }

        #endregion
    }

    #endregion

    #region CustomResource Class

    public class CustomResource : Resource
    {

        #region Public Properties

        public ImageSource ResourceImageUri { get; set; }

        public Brush BackgroundBrush { get; set; }

        #endregion
    }

    #endregion
}
