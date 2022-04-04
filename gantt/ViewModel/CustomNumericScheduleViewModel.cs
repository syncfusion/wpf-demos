#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Controls.Gantt;
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

namespace syncfusion.ganttdemos.wpf
{
    public class CustomNumericScheduleViewModel
    {
        public CustomNumericScheduleViewModel()
        {
            this.CreateCountryCollection();
            _topCountriesCollection = GetData();
            _customScheduleInfo = GetCustomScheduleInfo();
        }

        /// <summary>
        /// Collection which is used to store the CountryNamesWith their Flags
        /// </summary>
        internal static Dictionary<string, string> CountryNamesandFlags = new Dictionary<string, string>();

        private ObservableCollection<GanttScheduleRowInfo> _customScheduleInfo;

        /// <summary>
        /// Gets or sets the custom schedule info.
        /// </summary>
        /// <value>The custom schedule info.</value>
        public ObservableCollection<GanttScheduleRowInfo> CustomScheduleInfo
        {
            get
            {
                return _customScheduleInfo;
            }
            set
            {
                _customScheduleInfo = value;
            }
        }

        private ObservableCollection<TopCountries> _topCountriesCollection;
        /// <summary>
        /// Gets or sets the appointment item source.
        /// </summary>
        /// <value>The appointment item source.</value>
        public ObservableCollection<TopCountries> TopCountriesCollection
        {
            get
            {
                return _topCountriesCollection;
            }
            set
            {
                _topCountriesCollection = value;
            }
        }


        /// <summary>
        /// Gets the Numeric Schedule Items Info
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<GanttScheduleRowInfo> GetCustomScheduleInfo()
        {
            ObservableCollection<GanttScheduleRowInfo> RowInfo = new ObservableCollection<GanttScheduleRowInfo>();
            RowInfo.Add(new GanttScheduleRowInfo() { CellsPerUnit = 5 });
            RowInfo.Add(new GanttScheduleRowInfo() { CellsPerUnit = 2, PixelsPerUnit = 30d });
            return RowInfo;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<TopCountries> GetData()
        {
            var data = new ObservableCollection<TopCountries>();

            data.Add(new TopCountries() { Id = 1, Name = "Afghanistan", Start = 0, End = 8.227, Rank = 17 });
            data.Add(new TopCountries() { Id = 2, Name = "Argentina", Start = 0, End = 9.161, Rank = 8 });
            data.Add(new TopCountries() { Id = 3, Name = "Belarus", Start = 0, End = 7.6, Rank = 27 });
            data.Add(new TopCountries() { Id = 4, Name = "Botswana", Start = 0, End = 8.562, Rank = 13 });
            data.Add(new TopCountries() { Id = 5, Name = "Brazil", Start = 0, End = 7.49, Rank = 31 });
            data.Add(new TopCountries() { Id = 6, Name = "Democratic Republic of the Congo", Start = 0, End = 7.245, Rank = 32 });
            data.Add(new TopCountries() { Id = 7, Name = "Dominican Republic", Start = 0, End = 7.751, Rank = 23 });
            data.Add((new TopCountries() { Id = 8, Name = "Ethiopia", Start = 0, End = 8.008, Rank = 20 }));
            data.Add((new TopCountries() { Id = 9, Name = "India", Start = 0, End = 11.1, Rank = 4 }));
            data.Add((new TopCountries() { Id = 10, Name = "Laos", Start = 0, End = 7.747, Rank = 24 }));
            data.Add((new TopCountries() { Id = 11, Name = "Lebanon", Start = 0, End = 7.5, Rank = 30, }));
            data.Add((new TopCountries() { Id = 12, Name = "Malaysia", Start = 0, End = 7.156, Rank = 33 }));
            data.Add(new TopCountries() { Id = 13, Name = "Maldives", Start = 0, End = 7.969, Rank = 21, });
            data.Add((new TopCountries() { Id = 14, Name = "Mozambique", Start = 0, End = 7.009, Rank = 35 }));
            data.Add((new TopCountries() { Id = 15, Name = "Niger", Start = 0, End = 7.53, Rank = 28, }));
            data.Add((new TopCountries() { Id = 16, Name = "Nigeria", Start = 0, End = 8.394, Rank = 16, }));
            data.Add((new TopCountries() { Id = 17, Name = "Panama", Start = 0, End = 7.505, Rank = 29, }));
            data.Add(new TopCountries() { Id = 18, Name = "Papua New Guinea", Start = 0, End = 7.03, Rank = 34 });
            data.Add((new TopCountries() { Id = 19, Name = "Paraguay", Start = 0, End = 14.40, Rank = 3 }));
            data.Add((new TopCountries() { Id = 20, Name = "People's Republic of China", Start = 0, End = 10.3, Rank = 6 }));
            data.Add((new TopCountries() { Id = 21, Name = "Peru", Start = 0, End = 8.795, Rank = 12 }));
            data.Add((new TopCountries() { Id = 22, Name = "Philippines", Start = 0, End = 7.6, Rank = 26 }));
            data.Add((new TopCountries() { Id = 23, Name = "Qatar", Start = 0, End = 16.272, Rank = 1 }));
            data.Add(new TopCountries() { Id = 24, Name = "Republic of China(Taiwan)", Start = 0, End = 10.8, Rank = 6 });
            data.Add((new TopCountries() { Id = 25, Name = "Republic of the Congo", Start = 0, End = 9.09, Rank = 10 }));
            data.Add((new TopCountries() { Id = 26, Name = "Singapore", Start = 0, End = 15.27, Rank = 2 }));
            data.Add((new TopCountries() { Id = 27, Name = "Sri Lanka", Start = 0, End = 9.134, Rank = 9 }));
            data.Add((new TopCountries() { Id = 28, Name = "Thailand", Start = 0, End = 7.803, Rank = 22 }));
            data.Add(new TopCountries() { Id = 29, Name = "Turkey", Start = 0, End = 8.2, Rank = 18 });
            data.Add((new TopCountries() { Id = 30, Name = "Turkmenistan", Start = 0, End = 9.222, Rank = 7 }));
            data.Add((new TopCountries() { Id = 31, Name = "Uruguay", Start = 0, End = 8.468, Rank = 15 }));
            data.Add((new TopCountries() { Id = 32, Name = "Uzbekistan", Start = 0, End = 8.5, Rank = 14 }));
            data.Add((new TopCountries() { Id = 33, Name = "Yemen", Start = 0, End = 8.016, Rank = 19 }));
            data.Add(new TopCountries() { Id = 34, Name = "Zambia", Start = 0, End = 7.601, Rank = 25 });
            data.Add((new TopCountries() { Id = 35, Name = "Zimbabwe", Start = 0, End = 9.006, Rank = 11 }));

            return data;
        }

        #region Image and Country Collection
        /// <summary>
        /// Creates the country collection with the corresponding Image.
        /// </summary>
        void CreateCountryCollection()
        {
            CountryNamesandFlags.Add("Afghanistan", "Flag_Afghanistan.png");
            CountryNamesandFlags.Add("Argentina", "Flag_Argentina.png");
            CountryNamesandFlags.Add("Belarus", "Flag_Belarus.png");
            CountryNamesandFlags.Add("Botswana", "Flag_Botswana.png");
            CountryNamesandFlags.Add("Brazil", "Flag_Brazil.png");
            CountryNamesandFlags.Add("Democratic Republic of the Congo", "Flag_Democratic_Republic_of_the_Congo.png");
            CountryNamesandFlags.Add("Dominican Republic", "Flag_Dominican_Republic.png");
            CountryNamesandFlags.Add("Ethiopia", "Flag_Ethiopia.png");
            CountryNamesandFlags.Add("India", "Flag_India.png");
            CountryNamesandFlags.Add("Laos", "Flag_Laos.png");
            CountryNamesandFlags.Add("Lebanon", "Flag_Lebanon.png");
            CountryNamesandFlags.Add("Malaysia", "Flag_Malaysia.png");
            CountryNamesandFlags.Add("Maldives", "Flag_Maldives.png");
            CountryNamesandFlags.Add("Mozambique", "Flag_Mozambique.png");
            CountryNamesandFlags.Add("Niger", "Flag_Niger.png");
            CountryNamesandFlags.Add("Nigeria", "Flag_Nigeria.png");
            CountryNamesandFlags.Add("Panama", "Flag_Panama.png");
            CountryNamesandFlags.Add("Papua New Guinea", "Flag_Papua_New_Guinea.png");
            CountryNamesandFlags.Add("Paraguay", "Flag_Paraguay.png");
            CountryNamesandFlags.Add("People's Republic of China", "Flag_People's_Republic_of_China.png");
            CountryNamesandFlags.Add("Peru", "Flag_Peru.png");
            CountryNamesandFlags.Add("Philippines", "Flag_Philippines.png");
            CountryNamesandFlags.Add("Qatar", "Flag_Qatar.png");
            CountryNamesandFlags.Add("Republic of China(Taiwan)", "Flag_Republic_of_China.png");
            CountryNamesandFlags.Add("Republic of the Congo", "Flag_Republic_of_the_Congo.png");
            CountryNamesandFlags.Add("Singapore", "Flag_Singapore.png");
            CountryNamesandFlags.Add("Sri Lanka", "Flag_Sri_Lanka.png");
            CountryNamesandFlags.Add("Thailand", "Flag_Thailand.png");
            CountryNamesandFlags.Add("Turkey", "Flag_Turke.png");
            CountryNamesandFlags.Add("Turkmenistan", "Flag_Turkmenistan.png");
            CountryNamesandFlags.Add("Uruguay", "Flag_Uruguay.png");
            CountryNamesandFlags.Add("Uzbekistan", "Flag_Uzbekistan.png");
            CountryNamesandFlags.Add("Yemen", "Flag_Yemen.png");
            CountryNamesandFlags.Add("Zambia", "Flag_Zambia.png");
            CountryNamesandFlags.Add("Zimbabwe", "Flag_Zimbabwe.png");

        }
        #endregion

        internal void Dispose()
        {
            if (CountryNamesandFlags != null && CountryNamesandFlags.Count > 0)
            {
                CountryNamesandFlags.Clear();
            }

            foreach(var topCountry in TopCountriesCollection)
            {
                topCountry.Dispose();
            }
        }
    }

}