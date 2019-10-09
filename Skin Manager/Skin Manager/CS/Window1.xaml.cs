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
using Syncfusion.Windows.Shared;

namespace SkinManager_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {

        #region Methods

        public static int index=0;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Window1"/> class.
        /// </summary>
        public Window1()
        {
            InitializeComponent();
        }
        #endregion

        #region Helper Methods 
        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            SkinStorage.SetVisualStyle(this, button.Tag.ToString());
            if (button.Tag.ToString() == "Transparent")
            {
                rect.Fill = Brushes.Transparent;
                expander.Background = Brushes.Transparent;
            }
            else
            {
                rect.Fill = Brushes.White;
                expander.Background = Brushes.White;
            }
            TabControlArea.SelectedIndex = index;
            SetText();
        }

        /// <summary>
        /// Handles the Selected event of the TreeViewItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = sender as TreeViewItem;
            TabControlArea.SelectedIndex = Convert.ToInt32(item.Tag);
            index = TabControlArea.SelectedIndex;
            SetText();
        }

        /// <summary>
        /// Sets the text.
        /// </summary>
        public void SetText()
        {
            TreeViewItem item = treeViewControlslist.SelectedItem as TreeViewItem;
            if (item != null)

            TextBox1.Text = item.Header + " - " + SkinStorage.GetVisualStyle(this).ToString() + " Skin";
        }

        #endregion
    }
}
