#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using Syncfusion.Windows.Controls.Input;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using System.Globalization;
using System.Windows.Data;
using System.Windows;
using System.Windows.Input;

namespace syncfusion.dropdowndemos.wpf
{
    public class AutoCompleteViewModel : NotificationObject
    {
        private ObservableCollection<PersonDetails> employee;

        private ObservableCollection<string> countries;

        private ObservableCollection<string> diacriticCollection;

        public ObservableCollection<PersonDetails> Employee
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
                RaisePropertyChanged("Employee");
            }
        }

        public ObservableCollection<string> Countries
        {
            get
            {
                return countries;
            }
            set
            {
                countries = value;
                RaisePropertyChanged("Countries");
            }
        }


        public ObservableCollection<string> DiacriticCollection
        {
            get
            {
                return diacriticCollection;
            }
            set
            {
                diacriticCollection = value;
                RaisePropertyChanged("DiacriticCollection");
            }
        }

        public ICommand AutoCompleteLoaded
        {
            get;
            private set;
        }


        public AutoCompleteViewModel()
        {
            AutoCompleteLoaded = new DelegateCommand(AutoCompleteLoadedMethod);
            Employee = new ObservableCollection<PersonDetails>();
            Employee.Add(new PersonDetails("Eric Joplin", 38, "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle5.png", "Team Lead"));
            Employee.Add(new PersonDetails("Paul Vent", 28, "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle8.png", "Product Manager"));
            Employee.Add(new PersonDetails("Clara Venus", 25, "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle0.png", "Manager"));
            Employee.Add(new PersonDetails("Maria Even", 30, "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle3.png", "General Manager"));
            Employee.Add(new PersonDetails("Mark Zuen", 33, "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle18.png", "Scrum Master"));
            Employee.Add(new PersonDetails("Robin Rane", 40, "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle23.png", "Manager"));
            Employee.Add(new PersonDetails("Chris Marker", 33, "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle23.png", "Product Manager"));
            Employee.Add(new PersonDetails("Seria Sum", 32, "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle17.png", "Scrum Master"));
            Employee.Add(new PersonDetails("Mathew Fleming", 36, "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle26.png", "Scrum Master"));
            Employee.Add(new PersonDetails("Steven Joplin", 43, "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle13.png", "Team Lead"));
            Employee.Add(new PersonDetails("Carl Vent", 43, "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle8.png", "Product Manager"));
            Employee.Add(new PersonDetails("James Venus", 25, "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle0.png", "Assistant General Manager"));
            Employee.Add(new PersonDetails("Maria Strauss", 27, "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle24.png", "Product Manager"));
            Employee.Add(new PersonDetails("Kate Zuen", 28, "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle14.png", "Team Lead"));
            Employee.Add(new PersonDetails("Niko Rane", 21, "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle23.png", "Manager"));
            Employee.Add(new PersonDetails("Chris gayle", 28, "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle12.png", "Team Manager"));
            Employee.Add(new PersonDetails("Sloth Sum", 26, "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle21.png", "Product Manager"));
            Employee.Add(new PersonDetails("Thomas Fleming", 31, "/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle26.png", "Team Lead"));

            DiacriticCollection = new ObservableCollection<string>()
            {
                "Hów tó gâin wéight?",
                "Hów tó drâw ân éléphânt?",
                "Whéré cân I buy â câmérâ?",
                "Guidé mé âll thé wây",
                "Hów tó mâké â câké?",
                "Sây, Hélló Wórld!",
                "Whât timé nów in Indiâ?"
            };

            Countries = new ObservableCollection<string>();
            RegionInfo country = new RegionInfo(new CultureInfo("en-US", false).LCID);

            //To get the Country Names from the CultureInfo installed in windows
            foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                country = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                if(!Countries.Contains(country.DisplayName.ToString()))
                    Countries.Add(country.DisplayName.ToString());                
            }            
        }

        private void AutoCompleteLoadedMethod(object obj)
        {
            var autocomplete = obj as SfTextBoxExt;
            if (autocomplete != null)
            {
                autocomplete.Filter = MyFilter;
            }
        }

        public bool MyFilter(string search, object item)
        {
            var model = item as PersonDetails;
            if (model != null)
            {
                if (model.Name.ToLower().Contains(search))
                {
                    return true;
                }
                else if (model.Designation.ToLower().Contains(search))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
