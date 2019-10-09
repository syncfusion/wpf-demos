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
        private ObservableCollection<Model> models = new ObservableCollection<Model>();

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Model> GetModels
        {
            get
            {
                return models;
            }
            set
            {
                models = value;
                OnPropertyChanged("GetModels");
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
            GetModels = new ObservableCollection<Model>();
            PopulateItems();
        }

        public void PopulateItems()
        {
            GetModels.Add(new Model { Name = "Yarrow", Category = "Leafy and Salad" });
            GetModels.Add(new Model { Name = "Pumpkins", Category = "Leafy and Salad" });
            GetModels.Add(new Model { Name = "Cabbage", Category = "Leafy and Salad" });
            GetModels.Add(new Model { Name = "Spinach", Category = "Leafy and Salad" });
            GetModels.Add(new Model { Name = "Wheat Grass", Category = "Leafy and Salad" });
            GetModels.Add(new Model { Name = "Horse gram", Category = "Beans" });
            GetModels.Add(new Model { Name = "Chickpea", Category = "Beans" });
            GetModels.Add(new Model { Name = "Green bean", Category = "Beans" });
            GetModels.Add(new Model { Name = "Garlic", Category = "Bulb and Stem" });
            GetModels.Add(new Model { Name = "Onion", Category = "Bulb and Stem" });
            GetModels.Add(new Model { Name = "Nopal", Category = "Bulb and Stem" });
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
