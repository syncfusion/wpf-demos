#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
using System.Windows.Data;
using Syncfusion.Windows.Chart;
using System.Windows.Input;

namespace IListDataBindingDemo
{
    public class DataViewModel : INotifyPropertyChanged
    {


        public DataViewModel()
        {
            this.MarkList = new List<DataModel>();
            GenerateData();
        }

        public string[] YPathsCollection
        {
            get
            {
                return (new string[] { "Probability", "SystemSoftware", "DigitalSignal", "MobileComputing" });
            }
        }
        private void GenerateData()
        {
           this.MarkList.Add(new DataModel() { StudentID = 0, Name = "John", Probability = 89, SystemSoftware = 90, DigitalSignal = 85, MobileComputing = 92 });
           this.MarkList.Add(new DataModel() { StudentID = 1, Name = "James", Probability = 45, SystemSoftware = 35, DigitalSignal = 48, MobileComputing = 42 });
           this.MarkList.Add(new DataModel() { StudentID = 2, Name = "Sam", Probability = 32, SystemSoftware = 65, DigitalSignal = 67, MobileComputing = 78 });
            this.MarkList.Add(new DataModel() { StudentID = 3, Name = "Victor", Probability = 30, SystemSoftware = 39, DigitalSignal = 38, MobileComputing = 56 });
            this.MarkList.Add(new DataModel() { StudentID = 4, Name = "Faith", Probability = 25, SystemSoftware = 45, DigitalSignal = 77, MobileComputing = 19 });
            this.MarkList.Add(new DataModel() { StudentID = 5, Name = "Joyce", Probability = 50, SystemSoftware = 35, DigitalSignal = 54, MobileComputing = 55 });
            this.MarkList.Add(new DataModel() { StudentID = 6, Name = "Silvy", Probability = 70, SystemSoftware = 28, DigitalSignal = 35, MobileComputing = 45 });
            this.MarkList.Add(new DataModel() { StudentID = 7, Name = "Ian", Probability = 45, SystemSoftware = 85, DigitalSignal = 77, MobileComputing = 19 });
            this.MarkList.Add(new DataModel() { StudentID = 8, Name = "Mandy", Probability = 90, SystemSoftware = 45, DigitalSignal = 54, MobileComputing = 55 });
            this.MarkList.Add(new DataModel() { StudentID = 9, Name = "Alan", Probability = 50, SystemSoftware = 28, DigitalSignal = 25, MobileComputing = 45 });
        }

        public Array PaletteCollection
        {
            get
            {
                return new ChartColorPalette[] { ChartColorPalette.Nature, 
                                          ChartColorPalette.Metro, 
                                          ChartColorPalette.Default, 
                                          ChartColorPalette.DefaultDark,
                                        };
            }
        }
        public List<DataModel> markList;

        public List<DataModel> MarkList
        {
            get
            {
                return markList;
            }
            set
            {
                markList = value;
                OnPropertyChanged("MarkList");
            }
        }

        private ICommand mRemove;
        public ICommand RemoveCommand
        {
            get
            {
                if (mRemove == null)
                    mRemove = new Remove(this);
                return mRemove;
            }
            set
            {
                mRemove = value;
            }
        }

        private DataModel _selecteditem;
        public DataModel SelectedItem
        {
            get
            {
                if (_selecteditem == null)
                    _selecteditem = new DataModel();
                return _selecteditem;
            }
            set
            {
                _selecteditem = value;
                 OnPropertyChanged("SelectedItem");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property.ToString()));
            }
        }

        #endregion
    }

    public class Remove : ICommand
    {
        #region ICommand Members
        public DataViewModel model
        {
            get;
            set;
        }
        public Remove(DataViewModel Sm)
        {
            this.model = Sm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this.model.MarkList.Remove(this.model.SelectedItem);
        }

        #endregion
    }
    public class YPathConverter : IValueConverter
    {


        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
                return new string[] {value.ToString() };
            else
            return  value;


        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        #endregion
    }
}
