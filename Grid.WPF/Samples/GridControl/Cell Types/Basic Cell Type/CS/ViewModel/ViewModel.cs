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
