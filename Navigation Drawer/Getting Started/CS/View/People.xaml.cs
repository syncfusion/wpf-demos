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
    /// Interaction logic for People.xaml
    /// </summary>
    public partial class People : UserControl
    {
        public SfNavigationDrawer NavigationDrawer { get; set; }
        public ObservableCollection<PeopleData> Img
        {
            get;
            set;
        }
        public People()
        {
            this.InitializeComponent();
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
            int imageWidth = 302;
            int imageHeight = 180;

            Random random = new Random();

            int columnCount = Convert.ToInt32((rootGrid.ActualWidth - 50) / (imageWidth + 20));
            int rowCount = Convert.ToInt32((rootGrid.ActualHeight - 120) / (imageHeight + 20));
            
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
                    ContactView contactView = new ContactView();
                    contactView.Margin = new Thickness(10);
                    contactView.DataContext = tileCollection.Images[index];
                    Grid.SetRow(contactView, i);
                    Grid.SetColumn(contactView, j);
                    mainGrid.Children.Add(contactView);
                    index++;
                    if (index == 9)
                        index = 0;
                }
            }
        }
    }
}
