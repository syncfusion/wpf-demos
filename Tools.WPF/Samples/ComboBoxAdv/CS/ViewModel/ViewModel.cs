#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboBoxAdv_Demo
{
    class ViewModel : INotifyPropertyChanged
    {

        #region Variables
        private ObservableCollection<Country> collection;
        private ObservableCollection<Country> delimiterCollection;
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Country> defaultSelectedItemCollection = new ObservableCollection<Country>();
        private ObservableCollection<Country> delimiterSelectedItemCollection = new ObservableCollection<Country>();
        #endregion

        #region Properties
        public ObservableCollection<Country> Collection
        {
            get { return collection; }
            set
            {
                collection = value;
                RaisePropertyChanged("Collection");
            }
        }

        public ObservableCollection<Country> DelimiterCollection
        {
            get { return delimiterCollection; }
            set
            {
                delimiterCollection = value;
                RaisePropertyChanged("DelimiterCollection");
            }
        }        

        public ObservableCollection<Country> DefaultSelectedItemCollection
        {
            get { return defaultSelectedItemCollection; }
            set
            {
                defaultSelectedItemCollection = value;
                RaisePropertyChanged("defaultSelectedItemCollection");
            }
        }        

        public ObservableCollection<Country> DelimiterSelectedItemCollection
        {
            get { return delimiterSelectedItemCollection; }
            set
            {
                delimiterSelectedItemCollection = value;
                RaisePropertyChanged("DelimiterSelectedItemCollection");
            }
        }

        #endregion

        #region Constructors
        public ViewModel()
        {
            UpdateCollection();         
        }
        #endregion

        #region Methods
        public void UpdateCollection()
        {
            Collection = new ObservableCollection<Country>();

            Collection.Add(new Country()
            {
                Name = "United Kindom",
                Code = "UK"
            });

            Collection.Add(new Country()
            {
                Name = "Canada",
                Code = "CA"
            });

            Collection.Add(new Country()
            {
                Name = "Germany",
                Code = "DE"
            });

            Collection.Add(new Country()
            {
                Name = "India",
                Code = "IN"
            });

            Collection.Add(new Country()
            {
                Name = "United States of America",
                Code = "USA"
            });

            defaultSelectedItemCollection.Add(Collection[0]);
            defaultSelectedItemCollection.Add(Collection[1]);
            defaultSelectedItemCollection.Add(Collection[2]);

            DelimiterCollection = new ObservableCollection<Country>(Collection);
            DelimiterSelectedItemCollection = new ObservableCollection<Country>(DefaultSelectedItemCollection);
        }
       
        public void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
