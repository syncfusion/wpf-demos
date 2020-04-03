#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
        private ObservableCollection<Collection> collection = new ObservableCollection<Collection>();

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Collection> Collection
        {
            get
            {
                return collection;
            }
            set
            {
                collection = value;
                OnPropertyChanged("Collection");
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
            Collection = new ObservableCollection<Collection>();
            PopulateItems();
        }

        public void PopulateItems()
        {
            Collection.Add(new Collection { CountryName = "Canada", FlagImage = "Images/canada.png" });
            Collection.Add(new Collection { CountryName = "China", FlagImage = "Images/china.png" });
            Collection.Add(new Collection { CountryName = "Germany", FlagImage = "Images/germany.png" });
            Collection.Add(new Collection { CountryName = "India", FlagImage = "Images/india.png" });
            Collection.Add(new Collection { CountryName = "United kingdom", FlagImage = "Images/uk.png" });
            Collection.Add(new Collection { CountryName = "Ukraine", FlagImage = "Images/ukraine.png" });
        }
    }    
}
