#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.wpf
{
    public class PaletteViewModel
    {
        public ObservableCollection<ChartColorPalette> PaletteList
        {
            get;
            set;
        }
        public ObservableCollection<PaletteModel> FacebookStatistics
        {
            get;
            set;
        }
        public ObservableCollection<PaletteModel> ActiveUsers
        {
            get;
            set;
        }
        public ObservableCollection<PaletteModel> RegisteredUsers
        {
            get;
            set;
        }
        public ObservableCollection<PaletteModel> Users
        {
            get;
            set;
        }

        public PaletteViewModel()
        {
            this.PaletteList = new ObservableCollection<ChartColorPalette>();
            PaletteList.Add(ChartColorPalette.Metro);
            PaletteList.Add(ChartColorPalette.AutumnBrights);
            PaletteList.Add(ChartColorPalette.FloraHues);
            PaletteList.Add(ChartColorPalette.Pineapple);
            PaletteList.Add(ChartColorPalette.TomotoSpectrum);
            PaletteList.Add(ChartColorPalette.RedChrome);
            PaletteList.Add(ChartColorPalette.BlueChrome);
            PaletteList.Add(ChartColorPalette.PurpleChrome);
            PaletteList.Add(ChartColorPalette.GreenChrome);
            PaletteList.Add(ChartColorPalette.Elite);
            PaletteList.Add(ChartColorPalette.LightCandy);
            PaletteList.Add(ChartColorPalette.SandyBeach);
            PaletteList.Add(ChartColorPalette.Custom);

            //PieSeries
            this.FacebookStatistics = new ObservableCollection<PaletteModel>();
            FacebookStatistics.Add(new PaletteModel { Country = "Finland", UsersCount = 12.68 });
            FacebookStatistics.Add(new PaletteModel { Country = "Germany", UsersCount = 10.59 });
            FacebookStatistics.Add(new PaletteModel { Country = "Poland", UsersCount = 11.16 });
            FacebookStatistics.Add(new PaletteModel { Country = "France", UsersCount = 10.48 });
            FacebookStatistics.Add(new PaletteModel { Country = "Australia", UsersCount = 10.13 });
            FacebookStatistics.Add(new PaletteModel { Country = "Brazil", UsersCount = 7.99 });
            FacebookStatistics.Add(new PaletteModel { Country = "Russia", UsersCount = 6.25 });
            FacebookStatistics.Add(new PaletteModel { Country = "Israel", UsersCount = 10.50 });

            //Active User in Year of 2012,2014,2015
            this.Users = new ObservableCollection<PaletteModel>();
            Users.Add(new PaletteModel { SocialSite = "Facebook", Year2012 = 788, Year2014 = 1240, Year2015 = 1550 });
            Users.Add(new PaletteModel { SocialSite = "QZone", Year2012 = 310, Year2014 = 632, Year2015 = 900 });
            Users.Add(new PaletteModel { SocialSite = "Google+", Year2012 = 500, Year2014 = 743, Year2015 = 890 });
            Users.Add(new PaletteModel { SocialSite = "Twitter", Year2012 = 250, Year2014 = 540, Year2015 = 784 });
            Users.Add(new PaletteModel { SocialSite = "Skype", Year2012 = 120, Year2014 = 300, Year2015 = 520 });
            Users.Add(new PaletteModel { SocialSite = "WeChat", Year2012 = 180, Year2014 = 390, Year2015 = 550 });
            Users.Add(new PaletteModel { SocialSite = "Instagram", Year2012 = 120, Year2014 = 250, Year2015 = 850 });
            Users.Add(new PaletteModel { SocialSite = "WhatsApp", Year2012 = 100, Year2014 = 300, Year2015 = 300 });

            //Active Users
            this.ActiveUsers = new ObservableCollection<PaletteModel>();
            ActiveUsers.Add(new PaletteModel { SocialSite = "Twitter", UsersCount = 302 });
            ActiveUsers.Add(new PaletteModel { SocialSite = "Skype", UsersCount = 300 });
            ActiveUsers.Add(new PaletteModel { SocialSite = "WeChat", UsersCount = 559 });
            ActiveUsers.Add(new PaletteModel { SocialSite = "Google+", UsersCount = 650 });
            ActiveUsers.Add(new PaletteModel { SocialSite = "WhatsApp", UsersCount = 800 });
            ActiveUsers.Add(new PaletteModel { SocialSite = "Facebook", UsersCount = 1184 });

            // Registered users
            this.RegisteredUsers = new ObservableCollection<PaletteModel>();
            RegisteredUsers.Add(new PaletteModel { SocialSite = "Twitter", UsersCount = 500 });
            RegisteredUsers.Add(new PaletteModel { SocialSite = "Skype", UsersCount = 663 });
            RegisteredUsers.Add(new PaletteModel { SocialSite = "WeChat", UsersCount = 1120 });
            RegisteredUsers.Add(new PaletteModel { SocialSite = "Google+", UsersCount = 540 });
            RegisteredUsers.Add(new PaletteModel { SocialSite = "WhatsApp", UsersCount = 920 });
            RegisteredUsers.Add(new PaletteModel { SocialSite = "Facebook", UsersCount = 1600 });
        }
    }
}
