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

namespace WpfApplication1
{
    class ViewModel
    {
        // local time zone
        DateTime dt1 = DateTime.Now;
        TimeZoneInfo tzi1 = TimeZoneInfo.Local;

        // New York Time
        private DateTime newyorkDateTime;
        public DateTime NewYorkDateTime
        {
            get 
            {
                TimeZoneInfo tziclock1 = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                DateTime newyorkDateTime = TimeZoneInfo.ConvertTime(dt1, tzi1, tziclock1);
                return newyorkDateTime;
            }
            set 
            { 
                newyorkDateTime = value; 
            }
        }
        //London Time 
        private DateTime londonDateTime;
        public DateTime LondonDateTime
        {
            get 
            {
                TimeZoneInfo tziclock2 = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
                DateTime londonDateTime = TimeZoneInfo.ConvertTime(dt1, tzi1, tziclock2);
                return londonDateTime; 
            }
            set
            {
                londonDateTime = value; 
             }
        }
        //Tokyo Standard Time
        private DateTime tokyoDateTime;
        public DateTime TokyoDateTime
        {
            get
            {
                TimeZoneInfo tziclock3 = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
                DateTime tokyoDateTime = TimeZoneInfo.ConvertTime(dt1, tzi1, tziclock3);   
                return tokyoDateTime; 
            }
            set
            {
                tokyoDateTime = value; 
            }
        }
        //SA Eastern Standard Time
        private DateTime buenosDateTime;
        public DateTime BuenosDateTime
        {
            get
            {
                TimeZoneInfo tziclock4 = TimeZoneInfo.FindSystemTimeZoneById("SA Eastern Standard Time");
                DateTime buenosDateTime = TimeZoneInfo.ConvertTime(dt1, tzi1, tziclock4);
               return buenosDateTime; 
            }
            set
            {
                buenosDateTime = value; 
            }
        }
        //Russian Standard Time 
        public DateTime moscowDateTime;
        public DateTime MoscowDateTime
        {
            get 
            {
                TimeZoneInfo tziclock5 = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");
                DateTime moscowDateTime = TimeZoneInfo.ConvertTime(dt1, tzi1, tziclock5);
                return moscowDateTime; 
            }
            set { moscowDateTime = value; }
        }
        //Central European Standard Time
        public DateTime parisDateTime;
        public DateTime ParisDateTime
        {
            get 
            {
                TimeZoneInfo tziclock6 = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
                DateTime parisDateTime = TimeZoneInfo.ConvertTime(dt1, tzi1, tziclock6);
                return parisDateTime; 
            }
            set
            {
                parisDateTime = value; 
            }
        }
        //Australian Western Standard Time 
        public DateTime losangels;
        public DateTime Losangels
        {
            get
            {
                TimeZoneInfo tziclock7 = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
                DateTime losangels = TimeZoneInfo.ConvertTime(dt1, tzi1, tziclock7);
                return losangels;
            }
            set
            {
                losangels = value;
            }
        }
        // India Standard Time - India
        public DateTime indiaDateTime;
        public DateTime IndiaDateTime
        {
            get
            {
                TimeZoneInfo tziclock9 = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime indiaDateTime = TimeZoneInfo.ConvertTime(dt1, tzi1, tziclock9);
                return indiaDateTime; 
            }
            set
            {
                indiaDateTime = value;
            }
        }
        // Georgian Standard Time
        public DateTime santiagoDateTime;
        public DateTime SantiagoDateTime
        {
            get {                    
                TimeZoneInfo tziclock8 = TimeZoneInfo.FindSystemTimeZoneById("SA Western Standard Time");
                DateTime santiagoDateTime = TimeZoneInfo.ConvertTime(dt1, tzi1, tziclock8);
                return santiagoDateTime; 
            }
            set { santiagoDateTime = value; }
        }

    }
}
