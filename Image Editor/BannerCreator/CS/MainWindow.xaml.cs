#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Syncfusion.UI.Xaml.ImageEditor;
using System;
using System.Collections.Generic;
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

namespace BannerCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (imageEditor == null || !IsLoaded) return;
            var combo = sender as ComboBox;
            var viewModel = (sender as ComboBox).DataContext as ViewModel;
            if (viewModel != null)
            {
                viewModel.IsEnabled = combo.SelectedIndex == 6 ? false : true;
            }

            if (combo.SelectedIndex == 0)
                imageEditor.ToggleCropping(1200, 900);
            else if (combo.SelectedIndex == 1)
                imageEditor.ToggleCropping(851, 315);
            else if (combo.SelectedIndex == 2)
                imageEditor.ToggleCropping(1024, 512);
            else if (combo.SelectedIndex == 3)
                imageEditor.ToggleCropping(1500, 500);
            else if (combo.SelectedIndex == 4)
                imageEditor.ToggleCropping(2560, 1440);
            else if (combo.SelectedIndex == 5)
                imageEditor.ToggleCropping(new Rect());
        }
    }
}
