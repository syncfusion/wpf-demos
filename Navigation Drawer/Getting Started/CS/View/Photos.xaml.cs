#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using NavigationDrawer;
using Syncfusion.UI.Xaml.NavigationDrawer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GettingStarted
{
    /// <summary>
    /// Interaction logic for Photos.xaml
    /// </summary>
    public partial class Photos : UserControl
    {
        public SfNavigationDrawer NavigationDrawer { get; set; }
        public ObservableCollection<PeopleData> photodata = new ObservableCollection<PeopleData>();
        public Photos()
        {
            this.InitializeComponent();
            this.DataContext = photodata;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (NavigationDrawer != null)
            {
                if (NavigationDrawer.IsOpen)
                    NavigationDrawer.ToggleDrawer();
                else
                {
                    NavigationDrawer.ToggleDrawer();
                }
            }
        }

        private void mainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateGrid();
        }

        private void mainGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            mainGrid.ColumnDefinitions.Clear();
            mainGrid.RowDefinitions.Clear();
            mainGrid.Children.Clear();
            TileViewProperties tileCollection = new TileViewProperties();
            int imageWidth = 130;
            int imageHeight = 130;

            Random random = new Random();

            int columnCount = Convert.ToInt32((rootGrid.ActualWidth - 20) / (imageWidth + 20));
            int rowCount = Convert.ToInt32((rootGrid.ActualHeight - 110) / (imageHeight + 20));
            
            for (int i = 0; i < rowCount; i++)
            {
                mainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(imageHeight + 10) });
            }

            for (int i = 0; i < columnCount; i++)
            {
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(imageWidth + 10) });
            }

            int index = 0;

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    if (index == 8)
                        index = 0;
                    PhotosView photosview = new PhotosView();
                    photosview.DataContext = tileCollection.Images[index];
                    Grid.SetRow(photosview, i);
                    Grid.SetColumn(photosview, j);
                    mainGrid.Children.Add(photosview);
                    index++;
                }
            }
        }
    }

    public class PeopleData
    {
        public BitmapImage Icon { get; set; }
        public string Title { get; set; }
    }

}
