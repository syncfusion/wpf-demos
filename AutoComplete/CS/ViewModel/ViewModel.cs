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
using System.ComponentModel;
using Syncfusion.Windows.Controls.Input;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace SfAutoCompleteDemo
{
    #region ViewModel
    public class ViewModel : NotificationObject
    {
        #region Fields

        private AutoCompleteMode autoCompleteMode = AutoCompleteMode.SuggestAppend;

        private SuggestionMode suggestionMode = SuggestionMode.StartsWith;

        private bool isCaseSesitive;

        private bool isOrdinal;

        private ObservableCollection<Person> employee;

        private ObservableCollection<string> countries;

        private ObservableCollection<string> diacriticCollection;

        #endregion

        #region Properties      

        public AutoCompleteMode AutoCompleteMode
        {
            get
            {
                return autoCompleteMode;
            }
            set
            {
                autoCompleteMode = value;
                RaisePropertyChanged("AutoCompleteMode");
            }
        }

        public SuggestionMode SuggestionMode
        {
            get
            {
                return suggestionMode;
            }
            set
            {
                suggestionMode = value;
                RaisePropertyChanged("SuggestionMode");
            }
        }

        public bool IsCaseSesitive
        {
            get
            {
                return isCaseSesitive;
            }
            set
            {
                isCaseSesitive = value;
                RaisePropertyChanged("IsCaseSesitive");
            }
        }

        public bool IsOrdinal
        {
            get
            {
                return isOrdinal;
            }
            set
            {
                isOrdinal = value;
                RaisePropertyChanged("IsOrdinal");
            }
        }

        public ObservableCollection<Person> Employee
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


        #endregion

        #region Constructor
        public ViewModel()
        {
            Employee = new ObservableCollection<Person>();
            Employee.Add(new Person("Eric Joplin", 38, "/Assets/Emp_06.png", "Team Lead"));
            Employee.Add(new Person("Paul Vent", 28, "/Assets/Emp_04.png", "Product Manager"));
            Employee.Add(new Person("Clara Venus", 25, "/Assets/Emp_06.png", "Manager"));
            Employee.Add(new Person("Maria Even", 30, "/Assets/Emp_11.png", "General Manager"));
            Employee.Add(new Person("Mark Zuen", 33, "/Assets/Emp_13.png", "Scrum Master"));
            Employee.Add(new Person("Robin Rane", 40, "/Assets/Emp_16.png", "Manager"));
            Employee.Add(new Person("Chris Marker", 33, "/Assets/Emp_16.png", "Product Manager"));
            Employee.Add(new Person("Seria Sum", 32, "/Assets/Emp_23.png", "Scrum Master"));
            Employee.Add(new Person("Mathew Fleming", 36, "/Assets/Emp_25.png", "Scrum Master"));
            Employee.Add(new Person("Steven Joplin", 43, "/Assets/Emp_02.png", "Team Lead"));
            Employee.Add(new Person("Carl Vent", 43, "/Assets/Emp_04.png", "Product Manager"));
            Employee.Add(new Person("James Venus", 25, "/Assets/Emp_06.png", "Assistant General Manager"));
            Employee.Add(new Person("Maria Strauss", 27, "/Assets/Emp_11.png", "Product Manager"));
            Employee.Add(new Person("Kate Zuen", 28, "/Assets/Emp_13.png", "Team Lead"));
            Employee.Add(new Person("Niko Rane", 21, "/Assets/Emp_16.png", "Manager"));
            Employee.Add(new Person("Chris gayle", 28, "/Assets/Emp_21.png", "Team Manager"));
            Employee.Add(new Person("Sloth Sum", 26, "/Assets/Emp_23.png", "Product Manager"));
            Employee.Add(new Person("Thomas Fleming", 31, "/Assets/Emp_25.png", "Team Lead"));

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

        #endregion
    }

    #endregion

    #region EnumToBooleanConverter
    public class EnumBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string parameterString = parameter as string;
            if (parameterString == null)
                return DependencyProperty.UnsetValue;

            if (Enum.IsDefined(value.GetType(), value) == false)
                return DependencyProperty.UnsetValue;                      

            object parameterValue = Enum.Parse(value.GetType(), parameterString);

            return parameterValue.Equals(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string parameterString = parameter as string;
            if (parameterString == null)
                return DependencyProperty.UnsetValue;
           
            return Enum.Parse(targetType, parameterString);
        }
    }

    #endregion

    #region MultiValueConverter
    public class MultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string temp = string.Empty;
            object suggestionMode = values[0];
            object isCaseSesitive = values[1];
            object isOrdinal = values[2];

            if (suggestionMode != null && suggestionMode != DependencyProperty.UnsetValue)
            {
                if ((isCaseSesitive != null && isCaseSesitive != DependencyProperty.UnsetValue) && (isOrdinal != null && isOrdinal != DependencyProperty.UnsetValue))
                {
                    if (suggestionMode.ToString() != "None" && (bool)isCaseSesitive && (bool)isOrdinal)
                    {
                        temp += suggestionMode.ToString() + "Ordinal" + "CaseSensitive";
                    }
                    else if (suggestionMode.ToString() != "None" && (bool)isCaseSesitive)
                    {
                        temp += suggestionMode.ToString() + "CaseSensitive";
                    }
                    else if (suggestionMode.ToString() != "None" && (bool)isOrdinal)
                    {
                        temp += suggestionMode.ToString() + "Ordinal";
                    }
                    else
                    {
                        temp += suggestionMode.ToString();
                    }
                }                
            }

            return Enum.Parse(suggestionMode.GetType(), temp);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    #endregion
}
