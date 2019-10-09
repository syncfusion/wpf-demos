#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;
using Syncfusion.Windows.Shared;

namespace FilteringDemo
{
    class EmployeeInfoViewModel : INotifyPropertyChanged
    {
        public EmployeeInfoViewModel()
        {
            EmployeeDetails = new EmployeeInfoRespository().GetEmployeesDetails(2000);
        }

        internal FilterChanged filterChanged;
        private ICommand textchanged;

        public ICommand TextChanged
        {
            get { return new DelegateCommand<object>(TextChangeEvent, args => true); }
            set { textchanged = value; OnPropertyChanged("TextChanged"); }
        }

        public ICommand ComboChanged
        {
            get { return new DelegateCommand<object>(ComboxChangedEvent, args => { return true; }); }
		}

        public ICommand FilterComboChanged
        {
            get { return new DelegateCommand<object>(FilterComboxChangedEvent, args => { return true; }); }
        }

        private void FilterComboxChangedEvent(object pram)
        {
            if (pram != null)
            {
                this.FilterOption = (pram as ComboBoxItem).Content.ToString();
                filterChanged();
            }
        }

        private void ComboxChangedEvent(object pram)
        {
            if (pram != null)
            {
                this.FilterCondition = (pram as ComboBoxItem).Content.ToString();
                filterChanged();
            }
        }

        private void TextChangeEvent(object pram)
        {
            if (pram != null)
            {
                this.FilterText = pram.ToString();
                filterChanged();
            }
        }

        private bool MakeStringFilter(Employees o, string option, string condition)
        {
            var value = o.GetType().GetProperty(option);
            var exactValue = value.GetValue(o,null);
            exactValue = exactValue.ToString().ToLower();
            string text = FilterText.ToLower();
            var methods = typeof(string).GetMethods();
            if (methods.Count() != 0)
            {
                var methodInfo = methods.FirstOrDefault(method => method.Name == condition);
                bool result1 = (bool)methodInfo.Invoke(exactValue, new object[] { text });
                return result1;
            }
            else
                return false;
        }

        private bool MakeNumericFilter(Employees o, string option, string condition)
        {
            var value = o.GetType().GetProperty(option);
            var exactValue = value.GetValue(o,null);
            double res;
            bool checkNumeric = double.TryParse(exactValue.ToString(), out res);
            if (checkNumeric)
            {
                switch (condition)
                {
                    case "Equals":
                        if (Convert.ToDouble(exactValue) == (Convert.ToDouble(FilterText)))
                            return true;
                        break;
                    case "GreaterThan":
                        if (Convert.ToDouble(exactValue) > Convert.ToDouble(FilterText))
                            return true;
                        break;
                    case "LessThan":
                        if (Convert.ToDouble(exactValue) < Convert.ToDouble(FilterText))
                            return true;
                        break;
                    case "NotEquals":
                        if (Convert.ToDouble(FilterText) != Convert.ToDouble(exactValue))
                            return true;
                        break;
                }
            }
            return false;
        }

        public bool FilerRecords(object o)
        {
            double res;
            bool checkNumeric = double.TryParse(FilterText, out res);
            var item = o as Employees;
            if (item != null && FilterText.Equals(""))
            {
                return true;
            }
            else
            {
                if (item != null)
                {
                    if (checkNumeric && !FilterOption.Equals("All Columns"))
                    {
                        if (FilterCondition == null || FilterCondition.Equals("Contains") || FilterCondition.Equals("StartsWith") || FilterCondition.Equals("EndsWith"))
                            FilterCondition = "Equals";
                        bool result = MakeNumericFilter(item, FilterOption, FilterCondition);
                        return result;
                    }
                    else if (FilterOption.Equals("All Columns"))
                    {
                        if (item.Name.ToLower().Contains(FilterText.ToLower()) ||
                            item.Title.ToLower().Contains(FilterText.ToLower()) ||
                            item.Salary.ToString().ToLower().Contains(FilterText.ToLower()) || item.EmployeeID.ToString().ToLower().Contains(FilterText.ToLower()) ||
                            item.Gender.ToLower().Contains(FilterText.ToLower()) )
                            return true;
                        return false;
                    }
                    else
                    {
                        if (FilterCondition == null || FilterCondition.Equals("Equals") || FilterCondition.Equals("LessThan") || FilterCondition.Equals("GreaterThan") || FilterCondition.Equals("NotEquals"))
                            FilterCondition = "Contains";
                        bool result = MakeStringFilter(item, FilterOption, FilterCondition);
                        return result;
                    }
                }
            }
            return false;
        }

        private string filterOption = "All Columns";

        public string FilterOption
        {
            get { return filterOption; }
            set
            {
                filterOption = value;
                OnPropertyChanged("FilterOption");
            }
        }

        private string filterText = string.Empty;

        public string FilterText
        {
            get { return filterText; }
            set
            {
                filterText = value;
                OnPropertyChanged("FilterText");
            }
        }

        private string filterCondition;

        public string FilterCondition
        {
            get { return filterCondition; }
            set
            {
                filterCondition = value;
                OnPropertyChanged("FilterCondition");
            }
        }

        private ObservableCollection<Employees> employeeDetails;
        public ObservableCollection<Employees> EmployeeDetails
        {
            get
            {
                return employeeDetails;
            }
            set
            {
                employeeDetails = value;
                OnPropertyChanged("EmployeeDetails");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
    }
    internal delegate void FilterChanged();
}
