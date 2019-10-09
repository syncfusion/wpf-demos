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
using Syncfusion.Windows.Edit;
using Syncfusion.Windows.Shared;

namespace EditDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    
    public partial class Window1 : Window
    {
        #region Intialization

        /// <summary>
        /// Window Constructor and events initialization
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth * (0.50);
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight * (0.67);
#if NETCORE
            Edit1.DocumentSource = "../../../Content.txt";
#else
            Edit1.DocumentSource = "../../Content.txt";
#endif
            fontlst.SelectedItem = new FontFamily("Verdana");
        }

        #endregion

        #region Helper Methods and Events

        /// <summary>
        /// Closes the window when exit menuitem is clicked
        /// </summary>
        private void menuitem_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (themecombo.SelectedIndex == 0)
                SkinStorage.SetVisualStyle(this, "Blend");
            else if (themecombo.SelectedIndex == 1)
                SkinStorage.SetVisualStyle(this, "VS2010");
            else if (themecombo.SelectedIndex == 2)
                SkinStorage.SetVisualStyle(this, "Office2007Blue");
            else if (themecombo.SelectedIndex == 3)
                SkinStorage.SetVisualStyle(this, "Office2007Black");
            else if (themecombo.SelectedIndex == 4)
                SkinStorage.SetVisualStyle(this, "Office2007Silver");
            else if (themecombo.SelectedIndex == 5)
                SkinStorage.SetVisualStyle(this, "ShinyRed");
            else if (themecombo.SelectedIndex == 6)
                SkinStorage.SetVisualStyle(this, "ShinyBlue");
        }

        private void TabKeyVS(object sender, RoutedEventArgs e)
        {
            Edit1.TabKeyBehavior = TabKeyBehavior.VS;
            tabKeyDefault.IsChecked = false;
            tabKeyVS.IsChecked = true;
        }

        private void TabKeyDefault(object sender, RoutedEventArgs e)
        {
            Edit1.TabKeyBehavior = TabKeyBehavior.Default;
            tabKeyVS.IsChecked = false;
            tabKeyDefault.IsChecked = true;
        }
#endregion
    }
}
