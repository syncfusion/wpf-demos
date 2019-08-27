#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace WpfApplication3
{
    class ViewModel
    {
        public ViewModel()
        {
            movieDetails = GetMovieDetails();
        }

        private List<MovieInfo> movieDetails;

        public List<MovieInfo> MovieDetails
        {
            get { return movieDetails; }
            set { movieDetails = value; }
        }

        private List<MovieInfo> GetMovieDetails()
        {
            List<MovieInfo> model = new List<MovieInfo>();

            model.Add(new MovieInfo()
            {
                MovieName = "Avatar",
                Theatre = "Lodo",
                City = "New Jersy",
                IsTicketAvailable = true,
                Poster = new BitmapImage(new Uri(@"..\..\Resources\Avatar.jpeg", UriKind.Relative))
            });

            model.Add(new MovieInfo()
            {
                MovieName = "Ice Age 3",
                Theatre = "Modern",
                City = "New York",
                IsTicketAvailable = true,
                Poster = new BitmapImage(new Uri(@"..\..\Resources\Iceage3.jpeg", UriKind.Relative))
            });

            model.Add(new MovieInfo()
            {
                MovieName = "Toy Story 3",
                Theatre = "Greek",
                City = "New York",
                IsTicketAvailable = true,
                Poster = new BitmapImage(new Uri(@"..\..\Resources\Toystory3.jpeg", UriKind.Relative))
            });

            model.Add(new MovieInfo()
            {
                MovieName = "Shrek",
                Theatre = "Lodo",
                City = "New Jersy",
                IsTicketAvailable = true,
                Poster = new BitmapImage(new Uri(@"..\..\Resources\Shrek.jpeg", UriKind.Relative))
            });

            model.Add(new MovieInfo()
            {
                MovieName = "Kung Fu Panda 2",
                Theatre = "Modern",
                City = "New York",
                IsTicketAvailable = true,
                Poster = new BitmapImage(new Uri(@"..\..\Resources\Kungfupanda2.jpeg", UriKind.Relative))
            });


            return model;
        }
    }
}
