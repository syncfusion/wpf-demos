#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.ComponentModel;

namespace syncfusion.dropdowndemos.wpf
{
    public class GrossingMoviesList : NotificationObject
    {
        #region Properties
        private int serialNumber;
        private string title;
        private string cast;
        private string director;
        private string genre;
        private string ratingMPAA;

        public int SerialNumber
        {
            get
            {
                return serialNumber;
            }
            set
            {
                serialNumber = value;
                RaisePropertyChanged("SerialNumber");
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                RaisePropertyChanged("Title");
            }
        }

        public string Cast
        {
            get
            {
                return cast;
            }
            set
            {
                cast = value;
                RaisePropertyChanged("Cast");
            }
        }

        public string Director
        {
            get
            {
                return director;
            }
            set
            {
                director = value;
                RaisePropertyChanged("Director");
            }
        }

        public string Genre
        {
            get
            {
                return genre;
            }
            set
            {
                genre = value;
                RaisePropertyChanged("Genre");
            }
        }

        public string Rating
        {
            get
            {
                return ratingMPAA;
            }
            set
            {
                ratingMPAA = value;
                RaisePropertyChanged("Rating");
            }
        }
        #endregion

        #region Ctor

        public GrossingMoviesList(int serialNumber, string title, string cast, string director, string genre, string ratingMPAA)
        {
            this.serialNumber = serialNumber;
            this.title = title;
            this.cast = cast;
            this.director = director;
            this.genre = genre;
            this.ratingMPAA = ratingMPAA;
        }
        #endregion  
    }
}
