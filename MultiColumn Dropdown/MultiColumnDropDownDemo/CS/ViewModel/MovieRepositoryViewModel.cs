#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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

namespace MultiColumnDropDownDemo_2010
{
    class MovieRepositoryViewModel : INotifyPropertyChanged
    {
        #region Properties
        private ObservableCollection<GrossingMoviesList> moviesList;
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

        #endregion

        #region Ctor
        public MovieRepositoryViewModel()
        {
            MoviesLists = new MovieListRepository();
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
