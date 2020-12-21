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
using System.Windows.Media.Imaging;

namespace syncfusion.notificationdemos.wpf
{
    /// <summary>
    /// Represents a standard  WindowsTileViewModel
    /// </summary>
    public class WindowsTileViewModel
    {
        /// <summary>
        ///  //Maintains a collection of items to be populated into the items source
        /// </summary>
        private ObservableCollection<WindowsTileModel> items;

        /// <summary>
        /// Initialize the instance of <see cref="WindowsTileViewModel"/>class
        /// </summary>
        public WindowsTileViewModel()
        {
            Items = new ObservableCollection<WindowsTileModel>();
            PopulateItems();
        }

        /// <summary>
        /// Gets or sets a collection of items to be populated into items source<see cref="WindowsTileViewModel"/>class
        /// </summary>
        public ObservableCollection<WindowsTileModel> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
            }
        }

        /// <summary>
        /// Method to populate elements of hub tile
        /// </summary>
        private void PopulateItems()
        {
            WindowsTileModel hub1 = new WindowsTileModel { Header = "Skype", ImageSource = new BitmapImage(new Uri("/syncfusion.notificationdemos.wpf;component/Assets/HubTile/New Mail.png", UriKind.RelativeOrAbsolute)), Background = Brushes.RoyalBlue };
            WindowsTileModel hub2 = new WindowsTileModel { Header = "One Note", ImageSource = new BitmapImage(new Uri("/syncfusion.notificationdemos.wpf;component/Assets/HubTile/Excel.png", UriKind.RelativeOrAbsolute)), Background = Brushes.BlueViolet };
            WindowsTileModel hub3 = new WindowsTileModel { Header = "Paint", ImageSource = new BitmapImage(new Uri("/syncfusion.notificationdemos.wpf;component/Assets/HubTile/Painting Brush.png", UriKind.RelativeOrAbsolute)), Background = Brushes.RoyalBlue, Interval = TimeSpan.FromSeconds(1.0), SecondaryContent = "Microsoft Paint is used to edit the picture, it opens and saves files." };
            WindowsTileModel hub4 = new WindowsTileModel { Header = "Sticky Notes", ImageSource = new BitmapImage(new Uri("/syncfusion.notificationdemos.wpf;component/Assets/HubTile/Note.png", UriKind.RelativeOrAbsolute)), Background = Brushes.DarkSlateGray };
            WindowsTileModel hub5 = new WindowsTileModel { Header = "Microsoft Store ", ImageSource = new BitmapImage(new Uri("/syncfusion.notificationdemos.wpf;component/Assets/HubTile/Store.png", UriKind.RelativeOrAbsolute)), Background = Brushes.RoyalBlue, Interval = TimeSpan.FromSeconds(1.5), SecondaryContent = "Microsoft Store has latest games, creativity software and apps." };
            WindowsTileModel hub6 = new WindowsTileModel { Header = "Microsoft News", ImageSource = new BitmapImage(new Uri("/syncfusion.notificationdemos.wpf;component/Assets/HubTile/Clock.png", UriKind.RelativeOrAbsolute)), Background = Brushes.Red };
            WindowsTileModel hub7 = new WindowsTileModel { Header = "Calculator", ImageSource = new BitmapImage(new Uri("/syncfusion.notificationdemos.wpf;component/Assets/HubTile/Calculator.png", UriKind.RelativeOrAbsolute)), Background = Brushes.RoyalBlue, Interval = TimeSpan.FromSeconds(2.0), SecondaryContent = "Calculator is used to perform mathematical calculations." };
            WindowsTileModel hub8 = new WindowsTileModel { Header = "Sway", ImageSource = new BitmapImage(new Uri("/syncfusion.notificationdemos.wpf;component/Assets/HubTile/MicroSoft Edge.png", UriKind.RelativeOrAbsolute)), Background = Brushes.LightSeaGreen };
            WindowsTileModel hub9 = new WindowsTileModel { Header = "Word Edge", ImageSource = new BitmapImage(new Uri("/syncfusion.notificationdemos.wpf;component/Assets/HubTile/Word.png", UriKind.RelativeOrAbsolute)), Background = Brushes.RoyalBlue };

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

