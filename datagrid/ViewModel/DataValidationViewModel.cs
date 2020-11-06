#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using Syncfusion.UI.Xaml.Grid;

namespace syncfusion.datagriddemos.wpf
{
    public class DataValidationViewModel :NotificationObject
    {
        Random r = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="DataValidationViewModel"/> class.
        /// </summary>
        public DataValidationViewModel()
        {
            UserDetails = GetUserDetails(100);
        }

        private ObservableCollection<UserInfo> userDetails;
        public ObservableCollection<UserInfo> UserDetails
        {
            get { return userDetails; }
            set { userDetails = value; RaisePropertyChanged("UserDetails"); }
        }

        internal ObservableCollection<UserInfo> GetUserDetails(int count)
        {
            ObservableCollection<UserInfo> userdetails = new ObservableCollection<UserInfo>();
            for (int i = 0; i < count; i++)
            {
                var user = new UserInfo();
                user.UserId = 1001 + i;
                user.City = cityNames[r.Next(0, cityNames.Count() - 1)];
                user.ContactNo = contactNos[r.Next(0, contactNos.Count() - 1)];
                user.DateofBirth = new DateTime(r.Next(1960, 2000), r.Next(1, 12), r.Next(1, 28));
                user.Name = names[r.Next(0, names.Count() - 1)];
                user.EMail = user.Name + "@" + mail[r.Next(0, mail.Count() - 1)] + ".com";
                user.Salary = r.Next(9000, 31000);
                userdetails.Add(user);
            }

            return userdetails;
        }

        string[] cityNames = new string[]
        {
            "Candelaria",
            "McGuffey",
            "Daguao",
            "Driscoll",
            "Lake Wylie",
            "Evans Mills",
            "Maumelle",
            "Ripley",
            "Talbotton",
            "Makakilo",
            "Lorain",
            "Chunchula",
            "Newburg",
            "Joiner",
            "Fort Atkinson",
            "Matawan",
            "Council",
            "Copenhagen",
            "Sciotodale"
        };

        string[] contactNos = new string[] {
        "(833) 215-6503",
        "(855) 727-4387",
        "(844) 479-2783",
        "(855) 055-5922",
        "(899) 378-8810",
        "(833) 389-76618",
        "(855) 313-1072",
        "(899) 287-1193",
        "(844) 613-4240",
        "(833) 293-9651",
        "(899) 751-7249",
        "(833) 266-3598",
        "(855) 117-36707",
        "(811) 638-39931",
        "(833) 444-7832",
        "(899) 995-59379",
        "(899) 544-1240",
        "(811) 892-78532",
        "(844) 080-8130",
        "(899) 256-2942"
        };

        string[] names = new string[]
        {
            "Hatomlor", "Anech",    "Polormundara", "Omemiaore-Yon",    "Moreng",   "Sernn",    "Dariech Jhon",
"Vesrisum", "Tai'aty",  "Omat", "Drashther",    "Umm-que",  "Kinyer",   "Orothe",
"Belawpol", "Sedlor*",  "Orgar",    "Serem",    "Oslory",   "Isia"

        };

        string[] mail = new string[]
        {
            "gmail", "yahoo", "msn", "hotmail","ymail", "live"
        };
    }
}
