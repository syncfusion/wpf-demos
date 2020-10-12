#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace syncfusion.dropdowndemos.wpf
{
    public class MovieInfoViewModel : NotificationObject
    {
        private ObservableCollection<GrossingMoviesList> moviesList;
        private ObservableCollection<object> defaultSelectedItemCollection;
        private ObservableCollection<object> delimiterSelectedItemCollection;
        private string searchText = string.Empty;
    
        public ObservableCollection<GrossingMoviesList> MoviesLists
        {
            get
            {
                return moviesList;
            }
            set
            {
                moviesList = value;
                RaisePropertyChanged("MoviesLists");
            }
        }

        public ObservableCollection<object> DefaultSelectedItemCollection
        {
            get { return defaultSelectedItemCollection; }
            set
            {
                defaultSelectedItemCollection = value;
                RaisePropertyChanged("DefaultSelectedItemCollection");
            }
        }

        public ObservableCollection<object> DelimiterSelectedItemCollection
        {
            get { return delimiterSelectedItemCollection; }
            set
            {
                delimiterSelectedItemCollection = value;
                RaisePropertyChanged("DelimiterSelectedItemCollection");
            }
        }

        public MovieInfoViewModel()
        {
            MoviesLists = new MovieListRepository();

            var defaultSelectedItems = new ObservableCollection<object>();
            defaultSelectedItems.Add(moviesList[0]);
            defaultSelectedItems.Add(moviesList[1]);
            defaultSelectedItems.Add(moviesList[6]);

            var selectedItemsForSepatorDropDown = new ObservableCollection<object>();
            selectedItemsForSepatorDropDown.Add(moviesList[0]);
            selectedItemsForSepatorDropDown.Add(moviesList[1]);
            selectedItemsForSepatorDropDown.Add(moviesList[6]);

            DefaultSelectedItemCollection = defaultSelectedItems;

            DelimiterSelectedItemCollection = selectedItemsForSepatorDropDown;
        }

        public string SearchText 
        {
            get
            {
                return searchText;
            }
            set
            {
                searchText = value;
                this.RaisePropertyChanged("SearchText");
            }
        }
    }
}
