#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
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
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;

namespace SkinManagerDemo_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
       

        #region Constructor 

        /// <summary>
        /// Initializes a new instance of the <see cref="Window1"/> class.
        /// </summary>
        public Window1()
        {            
            InitializeComponent();
            GameCollect.GameCollections();
        }

       

        #endregion

        #region Helper Methods 

        /// <summary>
        /// Handles the Click event of the Hyperlink control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.syncfusion.com/");
        }

        /// <summary>
        /// Gets the game collection.
        /// </summary>
        /// <value>The game collection.</value>
        public ObservableCollection<GameData> GameCollection
        { get { return GameCollect._GameCollection; } }

        /// <summary>
        /// Handles the Click event of the app control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void app_Click(object sender, RoutedEventArgs e)
        {
            this.tab.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the Click event of the selitem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void selitem_Click(object sender, RoutedEventArgs e)
        {
            this.tab.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the Click event of the selfolder control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void selfolder_Click(object sender, RoutedEventArgs e)
        {
            this.tab.SelectedIndex = 7;
        }

        /// <summary>
        /// Handles the Click event of the exit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the software control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void software_Click(object sender, RoutedEventArgs e)
        {
            this.tab.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the Click event of the hardware control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void hardware_Click(object sender, RoutedEventArgs e)
        {
            this.tab.SelectedIndex = 1;
        }

        /// <summary>
        /// Handles the Click event of the callcenter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void callcenter_Click(object sender, RoutedEventArgs e)
        {
            this.tab.SelectedIndex = 2;
        }

        /// <summary>
        /// Handles the Click event of the bpo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void bpo_Click(object sender, RoutedEventArgs e)
        {
            this.tab.SelectedIndex = 3;
        }

        /// <summary>
        /// Handles the Click event of the faculty control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void faculty_Click(object sender, RoutedEventArgs e)
        {
            this.tab.SelectedIndex = 4;
        }

        /// <summary>
        /// Handles the Click event of the other control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void other_Click(object sender, RoutedEventArgs e)
        {
            this.tab.SelectedIndex = 5;
        }

        /// <summary>
        /// Handles the Click event of the open control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void open_Click(object sender, RoutedEventArgs e)
        {
            this.tab.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the Click event of the home control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void home_Click(object sender, RoutedEventArgs e)
        {
            this.tab.SelectedIndex = 1;
        }

        /// <summary>
        /// Handles the Selected event of the ComboBoxItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            if (tab != null)
            {
                ComboBoxItem item = sender as ComboBoxItem;
                switch (item.Tag.ToString())
                {
                    case "1":
                        this.tab.SelectedIndex = 0;
                        break;
                    case "2":
                        this.tab.SelectedIndex = 1;
                        break;
                    case "3":
                        this.tab.SelectedIndex = 2;
                        break;
                    case "4":
                        this.tab.SelectedIndex = 3;
                        break;
                    case "5":
                        this.tab.SelectedIndex = 4;
                        break;
                    case "6":
                        this.tab.SelectedIndex = 5;
                        break;
                }
            }
        }

        /// <summary>
        /// Handles the Selected event of the TreeViewItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            if (tab != null)
            {
                TreeViewItem item = sender as TreeViewItem;

                switch (item.Tag.ToString())
                {
                    case "0":
                        this.tab.SelectedIndex = 0;
                        break;
                    case "1":
                        this.tab.SelectedIndex = 1;
                        break;
                    case "2":
                        this.tab.SelectedIndex = 2;
                        break;
                    case "3":
                        this.tab.SelectedIndex = 3;
                        break;
                    case "4":
                        this.tab.SelectedIndex = 4;
                        break;
                    case "5":
                        this.tab.SelectedIndex = 5;
                        break;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SfSkinManager.SetVisualStyle(this, VisualStyles.Default);
            window.Background = System.Windows.Media.Brushes.GhostWhite;
        }

        /// <summary>
        /// Handles the 1 event of the Button_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            window.Background = System.Windows.Media.Brushes.White;
            SfSkinManager.SetVisualStyle(this, VisualStyles.Office2013White);
        }

        /// <summary>
        /// Handles the 2 event of the Button_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            window.Background = System.Windows.Media.Brushes.DarkGray;
            SfSkinManager.SetVisualStyle(this, VisualStyles.Office2013DarkGray);
        }

        /// <summary>
        /// Handles the 3 event of the Button_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            window.Background = System.Windows.Media.Brushes.LightGray;
            SfSkinManager.SetVisualStyle(this, VisualStyles.Office2013LightGray);
        }

        /// <summary>
        /// Handles the 4 event of the Button_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            window.Background = System.Windows.Media.Brushes.White;
            SfSkinManager.SetVisualStyle(this, VisualStyles.Metro);
        }

        /// <summary>
        /// Handles the 5 event of the Button_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            window.Background = System.Windows.Media.Brushes.Black;
            SfSkinManager.SetVisualStyle(this, VisualStyles.Blend);
        }


        /// <summary>
        /// Handles the 10 event of the Button_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            window.Background = System.Windows.Media.Brushes.AliceBlue;
            SfSkinManager.SetVisualStyle(this, VisualStyles.Office2010Blue);
        }

        /// <summary>
        /// Handles the 11 event of the Button_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            window.Background = System.Windows.Media.Brushes.LightGray;
            SfSkinManager.SetVisualStyle(this, VisualStyles.Office2010Black);
        }

        /// <summary>
        /// Handles the 12 event of the Button_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            window.Background = System.Windows.Media.Brushes.Silver;
            SfSkinManager.SetVisualStyle(this, VisualStyles.Office2010Silver);
        }

        /// <summary>
        /// Handles the Checked event of the ShowJob control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void ShowJob_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Name == "rbTodayJob")
            {
                this.tab1.Visibility = Visibility.Visible;
                this.tab.Visibility = Visibility.Collapsed;
                selected.IsEnabled = false;
                treeview.IsEnabled = false;  
            }
            else
            {
                this.tab1.Visibility = Visibility.Collapsed;
                this.tab.Visibility = Visibility.Visible;
                selected.IsEnabled = true;
                treeview.IsEnabled = true;  
            }
        }

        #endregion

        private void ButtonBase2_OnClick(object sender, RoutedEventArgs e)
        {
            window.Background = System.Windows.Media.Brushes.White;
            SfSkinManager.SetVisualStyle(this, VisualStyles.Lime);
        }

        private void SystemThemeButton_OnClick(object sender, RoutedEventArgs e)
        {
            window.Background = SystemColors.ControlBrush;
            SfSkinManager.SetVisualStyle(this, VisualStyles.SystemTheme);
        }

        private void ButtonBase1_OnClick(object sender, RoutedEventArgs e)
        {
            window.Background = System.Windows.Media.Brushes.White;
            SfSkinManager.SetVisualStyle(this, VisualStyles.Saffron);
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            window.Background = System.Windows.Media.Brushes.White;
            SfSkinManager.SetVisualStyle(this, VisualStyles.VisualStudio2013);
        }

        private void Office365_Button_Click(object sender, RoutedEventArgs e)
        {
            window.Background = System.Windows.Media.Brushes.White;
            SfSkinManager.SetVisualStyle(this, VisualStyles.Office365);
        }

        private void Office2016White_Button_Click(object sender, RoutedEventArgs e)
        {
            window.Background = System.Windows.Media.Brushes.White;
            SfSkinManager.SetVisualStyle(this, VisualStyles.Office2016White);
        }

        private void Office2016DarkGray_Button_Click(object sender, RoutedEventArgs e)
        {
            window.Background = System.Windows.Media.Brushes.DarkGray;
            SfSkinManager.SetVisualStyle(this, VisualStyles.Office2016DarkGray);
        }

        private void Office2016Colorful_Button_Click(object sender, RoutedEventArgs e)
        {
            window.Background = System.Windows.Media.Brushes.White;
            SfSkinManager.SetVisualStyle(this, VisualStyles.Office2016Colorful);
        }

        private void VisualStudio2015_Button_Click(object sender, RoutedEventArgs e)
        {
            window.Background = System.Windows.Media.Brushes.White;
            SfSkinManager.SetVisualStyle(this, VisualStyles.VisualStudio2015);
        }
    }
 }
