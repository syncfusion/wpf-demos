#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;

namespace MultiColumnDropDownDemo_2010
{
    class MovieListRepository : ObservableCollection<GrossingMoviesList>
    {
        public MovieListRepository()
        {
            this.Add(new GrossingMoviesList(1, "Iron Man 3", "Robert Downney Jr", "Shane Black", "Sci-Fi", "PG-13"));
            this.Add(new GrossingMoviesList(2, "The Croods", "Nicolas Cage", "Kirk De Micco, Chris Sanders", "Animation", "PG"));
            this.Add(new GrossingMoviesList(3, "Oz the Great and Powerful", "James Franco", "Sam Raimi", "Adventure", "PG"));
            this.Add(new GrossingMoviesList(4, "G.I Joe Retaliation", "Dwayne Johnson", "Jon M.Chu", "Action", "PG-13"));
            this.Add(new GrossingMoviesList(5, "A Good Day to Die Hard", "Bruce Wills", "John Moore", "Crime", "R"));
            this.Add(new GrossingMoviesList(6, "Hansel and Gretel Witch Hunters", "Jermy Renner", "Tommy Wirkola", "Fantasy", "R"));
            this.Add(new GrossingMoviesList(7, "Oblivion", "Tom Cruise", "Joseph Kosinski", "Mystery", "PG-13"));
            this.Add(new GrossingMoviesList(8, "Journey to the West Conquering the Demons", "Qi Shu", "Stephen Chow", "Fantasy", "R"));
            this.Add(new GrossingMoviesList(9, "Jack the Giant Slayer", "Nicholas Hoult", "Bryan Singer", "Fantasy", "PG-13"));
            this.Add(new GrossingMoviesList(10, "Identity Thief", "Jason Batman", "Seth Gordon", "Crime", "R"));
        }
    }
}
