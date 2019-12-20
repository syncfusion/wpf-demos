#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace MultiColumnDropDownDemo_2010
{
    class MovieRepositoryViewModel : INotifyPropertyChanged
    {
        #region Properties
        private ObservableCollection<GrossingMoviesList> moviesList;
        private ObservableCollection<object> defaultSelectedItemCollection;
        private ObservableCollection<object> delimiterSelectedItemCollection;
        private BaseCommand textChanged;
        private BaseCommand popupOpeningCommand;
        private TextBox searchTextBox;
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

        public BaseCommand TextChanged
        {
            get
            {
                if (textChanged == null)
                    textChanged = new BaseCommand(OnTextChangedExecuted);
                return textChanged;
            }
        }

        public BaseCommand PopupOpening
        {
            get
            {
                if (popupOpeningCommand == null)
                    popupOpeningCommand = new BaseCommand(OnPopupOpening);
                return popupOpeningCommand;
            }
        }

        #endregion

        #region Ctor
        public MovieRepositoryViewModel()
        {
            MoviesLists = new MovieListRepository();

            ObservableCollection<object> defaultSelectedItems = new ObservableCollection<object>();
            defaultSelectedItems.Add(moviesList[0]);
            defaultSelectedItems.Add(moviesList[1]);
            defaultSelectedItems.Add(moviesList[6]);

            ObservableCollection<object> selectedItemsForSepatorDropDown = new ObservableCollection<object>();
            selectedItemsForSepatorDropDown.Add(moviesList[0]);
            selectedItemsForSepatorDropDown.Add(moviesList[1]);
            selectedItemsForSepatorDropDown.Add(moviesList[6]);

            DefaultSelectedItemCollection = defaultSelectedItems;

            DelimiterSelectedItemCollection = selectedItemsForSepatorDropDown;
        }
        #endregion

        #region Methods
        private void OnTextChangedExecuted(object obj)
        {
            var param = (object[])obj;
            var multiColumnControl = param[0] as SfMultiColumnDropDownControl;
            searchTextBox = param[1] as TextBox;
            var grid = multiColumnControl.GetDropDownGrid();
            ObservableCollection<object> selectedItems = new ObservableCollection<object>();
            foreach (var selectedItem in grid.SelectedItems.ToList())
                selectedItems.Add(selectedItem);
            if (grid != null && grid.View != null && grid.View.Filter != null)
                grid.View.RefreshFilter();
            grid.ClearSelections(false);
            grid.SelectedItems = selectedItems;
        }

        private void OnPopupOpening(object obj)
        {
            var multiColumnControl = obj as SfMultiColumnDropDownControl;
            var grid = multiColumnControl.GetDropDownGrid();
            if (grid != null)
            {
                grid.View.Filter = CustomerFilter;
                grid.View.RefreshFilter();
            }
        }

        private bool CustomerFilter(object item)
        {
            if (searchTextBox == null)
                return true;
            var movie = item as GrossingMoviesList;
            return movie.Title.ToLower().Contains(searchTextBox.Text.ToLower());
        }

        #endregion
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
