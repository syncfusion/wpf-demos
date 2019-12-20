#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CheckListBox_Demo
{
    class ViewModel
    {
        private ObservableCollection<Vegetable> vegetables = new ObservableCollection<Vegetable>();
        private ObservableCollection<object> checkedItems = new ObservableCollection<object>();

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Vegetable> Vegetables
        {
            get
            {
                return vegetables;
            }
            set
            {
                vegetables = value;
                OnPropertyChanged("Vegetables");
            }
        }

        public ObservableCollection<object> CheckedItems
        {
            get
            {
                return checkedItems;
            }
            set
            {
                checkedItems = value;
                OnPropertyChanged("CheckedItems");
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public ViewModel()
        {
            Vegetables = new ObservableCollection<Vegetable>();
            PopulateItems();
            CheckedItems = new ObservableCollection<object>();
            CheckedItems.Add(Vegetables[0]);
            CheckedItems.Add(Vegetables[2]);
            CheckedItems.Add(Vegetables[4]);
            CheckedItems.Add(Vegetables[6]);
            CheckedItems.Add(Vegetables[8]);
        }

        public void PopulateItems()
        {
            Vegetables.Add(new Vegetable { Name = "Yarrow", Category = "Leafy and Salad" });
            Vegetables.Add(new Vegetable { Name = "Pumpkins", Category = "Leafy and Salad" });
            Vegetables.Add(new Vegetable { Name = "Cabbage", Category = "Leafy and Salad" });
            Vegetables.Add(new Vegetable { Name = "Spinach", Category = "Leafy and Salad" });
            Vegetables.Add(new Vegetable { Name = "Wheat Grass", Category = "Leafy and Salad" });
            Vegetables.Add(new Vegetable { Name = "Horse gram", Category = "Beans" });
            Vegetables.Add(new Vegetable { Name = "Chickpea", Category = "Beans" });
            Vegetables.Add(new Vegetable { Name = "Green bean", Category = "Beans" });
            Vegetables.Add(new Vegetable { Name = "Garlic", Category = "Bulb and Stem" });
            Vegetables.Add(new Vegetable { Name = "Onion", Category = "Bulb and Stem" });
            Vegetables.Add(new Vegetable { Name = "Nopal", Category = "Bulb and Stem" });
        }
    }


    internal class GroupConverter : IValueConverter
    {
        ObservableCollection<GroupDescription> groupDescriptors = new ObservableCollection<GroupDescription>
            {
                new PropertyGroupDescription{PropertyName="Category"}
            };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
            {
                return groupDescriptors;
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    internal class SortConverter : IValueConverter
    {
        SortDescriptionCollection sortDescriptors = new SortDescriptionCollection
        {
            new SortDescription{ PropertyName="Name", Direction = ListSortDirection.Ascending },
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
            {
                return sortDescriptors;
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
