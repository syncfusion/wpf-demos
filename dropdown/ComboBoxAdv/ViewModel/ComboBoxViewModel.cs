#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Collections.ObjectModel;

namespace syncfusion.dropdowndemos.wpf
{
    /// <summary>
    /// Represents the combo box viewmodel class
    /// </summary>
    public class ComboBoxViewModel : NotificationObject
    {
        /// <summary>
        /// Maintains a collection for the items to be populated in combo box
        /// </summary>
        private ObservableCollection<Country> collection;

        /// <summary>
        /// Maintains a collection for delimiter combo box
        /// </summary>
        private ObservableCollection<Country> delimiterCollection;

        /// <summary>
        /// Represents the collection for default selected item in combo box
        /// </summary>        
        private ObservableCollection<Country> defaultSelectedItemCollection = new ObservableCollection<Country>();

        /// <summary>
        /// Represents a collection for delimiter  selected item in  delimiter combo box
        /// </summary>
        private ObservableCollection<Country> delimiterSelectedItemCollection = new ObservableCollection<Country>();

        /// <summary>
        /// Initializes the instance of <see cref="ComboBoxViewModel"/>class
        /// </summary>
        public ComboBoxViewModel()
        {
            UpdateCollection();
        }
        /// <summary>
        /// Gets or sets a collection for storing the items to be populated in combo box
        /// </summary>
        public ObservableCollection<Country> Collection
        {
            get
            {
                return collection;
            }
            set
            {
                collection = value;
                RaisePropertyChanged("Collection");
            }
        }

        /// <summary>
        /// Gets or sets a collection for delimiter to be displayed in combo box
        /// </summary>
        public ObservableCollection<Country> DelimiterCollection
        {
            get
            {
                return delimiterCollection;
            }
            set
            {
                delimiterCollection = value;
                RaisePropertyChanged("DelimiterCollection");
            }
        }

        /// <summary>
        /// Gets or sets a collection for default selected item
        /// </summary>
        public ObservableCollection<Country> DefaultSelectedItemCollection
        {
            get
            {
                return defaultSelectedItemCollection;
            }
            set
            {
                defaultSelectedItemCollection = value;
                RaisePropertyChanged("defaultSelectedItemCollection");
            }
        }

        /// <summary>
        /// Gets or sets a collection for delimiter selected item 
        /// </summary>
        public ObservableCollection<Country> DelimiterSelectedItemCollection
        {
            get
            {
                return delimiterSelectedItemCollection;
            }
            set
            {
                delimiterSelectedItemCollection = value;
                RaisePropertyChanged("DelimiterSelectedItemCollection");
            }
        }

        /// <summary>
        /// Method for populating items in combo box
        /// </summary>
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
    }
}
