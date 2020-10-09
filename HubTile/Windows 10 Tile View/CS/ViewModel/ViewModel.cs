#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace HubTile_Data_Binding
{
    /// <summary>
    /// Represents a standard  ViewModel
    /// </summary>
    public class ViewModel
    {
        /// <summary>
        ///  //Maintains a collection of items to be populated into the items source
        /// </summary>
        private ObservableCollection<Model> items;

        /// <summary>
        /// Initialize the instance of <see cref="ViewModel"/>class
        /// </summary>
        public ViewModel()
        {
            Items = new ObservableCollection<Model>();
            PopulateItems();
        }

        /// <summary>
        /// Gets or sets a collection of items to be populated into items source<see cref="ViewModel"/>class
        /// </summary>
        public ObservableCollection<Model> Items
        {
            get { return items; }
            set { items = value; }
        }

        /// <summary>
        /// Method to populate elements of hub tile
        /// </summary>
        private void PopulateItems()
        {

            Model hub1 = new Model { Header = "Skype", ImageSource = @"/Assets/skype48.png",Background=Brushes.RoyalBlue};
            Model hub2 = new Model { Header = "One Note", ImageSource = @"/Assets/oneNote48.png", Background = Brushes.BlueViolet};
            Model hub3 = new Model { Header = "Paint", ImageSource = @"/Assets/paint48.png", Background = Brushes.RoyalBlue, Interval = TimeSpan.FromSeconds(1.0), SecondraryContent = "Microsoft Paint is used to edit the picture, it opens and saves files." };
            Model hub4 = new Model { Header = "Sticky Notes", ImageSource = @"/Assets/stickeynote48.png",Background=Brushes.DarkSlateGray };
            Model hub5 = new Model { Header = "Microsoft Store ", ImageSource = @"/Assets/store48.png", Background = Brushes.RoyalBlue, Interval = TimeSpan.FromSeconds(1.5), SecondraryContent = "Microsoft Store has latest games, creativity software and apps." };
            Model hub6 = new Model { Header = "Microsoft News", ImageSource = @"/Assets/news48.png", Background = Brushes.Red };
            Model hub7 = new Model { Header = "Calculator", ImageSource = @"/Assets/calculate48.png", Background = Brushes.RoyalBlue, Interval = TimeSpan.FromSeconds(2.0), SecondraryContent = "Calculator is used to perform mathematical calculations." };
            Model hub8 = new Model { Header = "Sway", ImageSource = @"/Assets/sway48.png", Background = Brushes.LightSeaGreen };
            Model hub9 = new Model { Header = "Word", ImageSource = @"/Assets/wordnew48.png", Background = Brushes.RoyalBlue };

            Items.Add(hub1);
            Items.Add(hub2);
            Items.Add(hub3);
            Items.Add(hub4);
            Items.Add(hub5);
            Items.Add(hub6);
            Items.Add(hub7);
            Items.Add(hub8);
            Items.Add(hub9);
        }
    }
}

