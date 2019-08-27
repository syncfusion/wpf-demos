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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Controls.Notification;
using Syncfusion.Windows.Controls;
using Syncfusion.Windows.Controls.Input;

namespace SfHubTile
{
    /// <summary>
    /// Interaction logic for HubTileDemo.xaml
    /// </summary>
    public partial class HubTileDemo : UserControl
    {
        public HubTileDemo()
        {
            InitializeComponent();
            this.Loaded += HubTileDemo_Loaded;
            title.MaxLength = 66;
            header.MaxLength = 18;
        }

        void HubTileDemo_Loaded(object sender, RoutedEventArgs e)
        {
            hubtile.Interval = TimeSpan.FromSeconds(3.0);
        }

        private HubTileTransitionCollection collection = new HubTileTransitionCollection();

        private SlideTransition slidetransition = new SlideTransition();

        private RotateTransition rotatetransition = new RotateTransition();

        private FadeTransition fadetransition = new FadeTransition();      

        private void hubtile_Loaded_1(object sender, RoutedEventArgs e)
        {
            hubtile.Interval = TimeSpan.FromSeconds(3.0);
            hubtile.HubTileTransitions = collection;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ComboBox)sender).SelectedItem.ToString() == "FadeTransition")
            {
                if (collection.Contains(slidetransition))
                    collection.Remove(slidetransition);

                if (collection.Contains(rotatetransition))
                    collection.Remove(rotatetransition);

                collection.Add(fadetransition);
            }
            else
            {
                if (collection.Contains(fadetransition))
                    collection.Remove(fadetransition);

                if (collection.Contains(rotatetransition))
                    collection.Remove(rotatetransition);

                collection.Add(slidetransition);
            }
        }
       
    }
}
