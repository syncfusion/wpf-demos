#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
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

namespace syncfusion.imageeditordemos.wpf
{
    class BannerCreatorBehavior : Behavior<BannerCreator>
    {
        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new RoutedEventHandler(AssociatedObject_Loaded);
        }

        /// <summary>
        /// Handles the Loaded event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.comboBox.SelectionChanged += new SelectionChangedEventHandler(comboBox_SelectionChanged);
        }

        /// <summary>
        /// Handles the SelectionChanged event of the comboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AssociatedObject.imageEditor == null ) return;
            var combo = sender as ComboBox;
            var viewModel = (sender as ComboBox).DataContext as BannerCreatorViewModel;
            if (viewModel != null)
            {
                viewModel.IsEnabled = combo.SelectedIndex == 6 ? false : true;
            }

            if (combo.SelectedIndex == 0)
                AssociatedObject.imageEditor.ToggleCropping(1200, 900);
            else if (combo.SelectedIndex == 1)
                AssociatedObject.imageEditor.ToggleCropping(851, 315);
            else if (combo.SelectedIndex == 2)
                AssociatedObject.imageEditor.ToggleCropping(1024, 512);
            else if (combo.SelectedIndex == 3)
                AssociatedObject.imageEditor.ToggleCropping(1500, 500);
            else if (combo.SelectedIndex == 4)
                AssociatedObject.imageEditor.ToggleCropping(2560, 1440);
            else if (combo.SelectedIndex == 5)
                AssociatedObject.imageEditor.ToggleCropping(new Rect());
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.comboBox.SelectionChanged -= new SelectionChangedEventHandler(comboBox_SelectionChanged);
            this.AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }
    }
}
