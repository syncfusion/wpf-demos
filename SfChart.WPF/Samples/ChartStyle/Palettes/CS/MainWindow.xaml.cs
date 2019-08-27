#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using Syncfusion.Windows.SampleLayout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Palettes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }   
    }
    public class Model
    {
        public string Country
        {
            get;
            set;
        }
        public string SocialNetwork
        {
            get;
            set;
        }
        public double Status
        {
            get;
            set;
        }
        public double Year2012
        {
            get;
            set;
        }
        public double Year2014
        {
            get;
            set;
        }
        public double Year2015
        {
            get;
            set;
        }
        public double YData4
        {
            get;
            set;
        }

    }
    public class ViewModel
    {
        public ObservableCollection<string> PaletteList
        {
            get;
            set;
        }
        public ObservableCollection<Model> CountryStatus
        {
            get;
            set;
        }
        public ObservableCollection<Model> ActiveUsers
        {
            get;
            set;
        }
        public ObservableCollection<Model> RegisteredUsers
        {
            get;
            set;
        }
        public ObservableCollection<Model> AnnualStatus
        {
            get;
            set;
        }

        public ViewModel()
        {
            this.PaletteList = new ObservableCollection<string>();
            PaletteList.Add("Metro");
            PaletteList.Add("AutumnBrights");
            PaletteList.Add("Florahues");
            PaletteList.Add("Pineapple");
            PaletteList.Add("TomotoSpectrum");
            PaletteList.Add("RedChrome");
            PaletteList.Add("BlueChrome");
            PaletteList.Add("PurpleChrome");
            PaletteList.Add("GreenChrome");
            PaletteList.Add("Elite");
            PaletteList.Add("LightCandy");
            PaletteList.Add("SandyBeach");

            //PieSeries
            this.CountryStatus = new ObservableCollection<Model>();
            CountryStatus.Add(new Model { Country = "Finland", Status = 12.68 });
            CountryStatus.Add(new Model { Country = "Germany", Status = 10.59 });
            CountryStatus.Add(new Model { Country = "Poland", Status = 11.16 });
            CountryStatus.Add(new Model { Country = "France", Status = 10.48 });
            CountryStatus.Add(new Model { Country = "Australia", Status = 10.13 });
            CountryStatus.Add(new Model { Country = "Israel", Status = 10.50 });
            CountryStatus.Add(new Model { Country = "Brazil", Status = 7.99 });
            CountryStatus.Add(new Model { Country = "Switzerland", Status = 7.25 });
            CountryStatus.Add(new Model { Country = "Russia", Status = 6.25 });
            CountryStatus.Add(new Model { Country = "Singapore", Status = 5.90 });

            //Active User in Year of 2012,2014,2015
            this.AnnualStatus = new ObservableCollection<Model>();
            AnnualStatus.Add(new Model { SocialNetwork = "Facebook", Year2012 = 788, Year2014 = 1440, Year2015 = 1336 });
            AnnualStatus.Add(new Model { SocialNetwork = "QZone", Year2012 = 210, Year2014 = 632, Year2015 = 629 });
            AnnualStatus.Add(new Model { SocialNetwork = "WhatsApp", Year2012 = 800, Year2014 = 800, Year2015 = 600 });
            AnnualStatus.Add(new Model { SocialNetwork = "WeChat", Year2012 = 668, Year2014 = 668, Year2015 = 468 });
            AnnualStatus.Add(new Model { SocialNetwork = "Google+", Year2012 = 549, Year2014 = 549, Year2015 = 343 });
            AnnualStatus.Add(new Model { SocialNetwork = "Twitter", Year2012 = 540, Year2014 = 540, Year2015 = 284 });
            AnnualStatus.Add(new Model { SocialNetwork = "Instagram", Year2012 = 302, Year2014 = 302, Year2015 = 300 });
            AnnualStatus.Add(new Model { SocialNetwork = "Skype", Year2012 = 300, Year2014 = 300, Year2015 = 300 });

            //Active Users
            this.ActiveUsers = new ObservableCollection<Model>();
            ActiveUsers.Add(new Model { SocialNetwork = "Twitter", Status = 302 });
            ActiveUsers.Add(new Model { SocialNetwork = "WeChat", Status = 559 });
            ActiveUsers.Add(new Model { SocialNetwork = "Instagram", Status = 300 });
            ActiveUsers.Add(new Model { SocialNetwork = "Skype", Status = 300 });
            ActiveUsers.Add(new Model { SocialNetwork = "WhatsApp", Status = 800 });
            ActiveUsers.Add(new Model { SocialNetwork = "Google+", Status = 540 });
            ActiveUsers.Add(new Model { SocialNetwork = "QZone", Status = 668 });
            ActiveUsers.Add(new Model { SocialNetwork = "Facebook", Status = 1184 });

            // Registered users
            this.RegisteredUsers = new ObservableCollection<Model>();
            RegisteredUsers.Add(new Model { SocialNetwork = "Twitter", Status = 500 });
            RegisteredUsers.Add(new Model { SocialNetwork = "WeChat", Status = 1120 });
            RegisteredUsers.Add(new Model { SocialNetwork = "Instagram", Status = 300 });
            RegisteredUsers.Add(new Model { SocialNetwork = "Skype", Status = 663 });
            RegisteredUsers.Add(new Model { SocialNetwork = "WhatsApp", Status = 800 });
            RegisteredUsers.Add(new Model { SocialNetwork = "Google+", Status = 540 });
            RegisteredUsers.Add(new Model { SocialNetwork = "QZone", Status = 1000 });
            RegisteredUsers.Add(new Model { SocialNetwork = "Facebook", Status = 2000 });
        }
    }
}
