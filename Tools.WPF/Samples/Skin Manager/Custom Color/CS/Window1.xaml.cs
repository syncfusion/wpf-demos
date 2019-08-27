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
using System.Reflection;
using System.Windows.Shapes;
using Syncfusion.Windows.Tools;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;


namespace CustomColor_Demo_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        #region Private Members 

        /// <summary>
        /// Private Members 
        /// </summary>
        BrushConverter conv = new BrushConverter();
        SolidColorBrush brush = new SolidColorBrush();       

        #endregion 

        #region Constructor 

        /// <summary>
        /// Initializes a new instance of the <see cref="Window1"/> class.
        /// </summary>
        public Window1()
        {
            
            InitializeComponent();
            GameCollect.gameCollection();
            InitializeLog();           
        }

        /// <summary>
        /// Initializes the log.
        /// </summary>
        public void InitializeLog()
        {
            Type br = typeof(Brushes);

            object[] parameters = new object[0];
            foreach (MemberInfo info in br.GetMembers())
            {
                if (info is PropertyInfo)
                {
                    PropertyInfo pi = info as PropertyInfo;

                    string fullcolorname = info.ToString();
                    string[] splitcolorname = fullcolorname.Split('.');
                    string[] colorname = splitcolorname[3].Split(' ');
                    colorItem.Items.Add(colorname[1]);
                    colorItem1.Items.Add(colorname[1]);

                    string fonthead = "Arial";
                    string fontbody = "Calibri";

                    fontlist.ThemeFonts.Add(new ThemeFontFamily(fonthead.ToString(), "(heading)"));
                    fontlist.ThemeFonts.Add(new ThemeFontFamily(fontbody.ToString(), "(body)"));

                }
            }
            string noColor="None";
            colorItem.Items.Add(noColor);
            colorItem.SelectedValue="None";
            colorItem1.Items.Add(noColor);
            colorItem1.SelectedValue = "None";
            List<String> cs = new List<String>();
            cs.Add("www.syncfusion.com");
            cs.Add("www.google.com");
            cs.Add("www.yahoo.com");
            autocomplete.CustomSource = cs;
        }

       
        #endregion

        #region Helper Methods

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Window.Closed"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnClosed(EventArgs e)
        {
            try
            {
                autocomplete.SaveHistory();
            }
            catch (Exception) { }
            base.OnClosed(e);
        }

        /// <summary>
        /// Gets the game collection.
        /// </summary>
        /// <value>The game collection.</value>
        public ObservableCollection<GameData> GameCollection
        { get { return GameCollect._GameCollection; } }

        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button1 = sender as Button;
            if (tabcheck.IsChecked == false && treecheck.IsChecked == false && editcheck.IsChecked == false && autocheck.IsChecked == false && fontcheck.IsChecked == false &&
                groupcheck.IsChecked == false && calendarcheck.IsChecked == false && clockcheck.IsChecked == false && colorcheck.IsChecked == false && gallerycheck.IsChecked == false && microcheck.IsChecked == false)
            {
                SkinStorage.SetVisualStyle(window1, button1.Tag.ToString());
                  if (button1.Tag.ToString() == "Transparent")
                    this.maingrid.Background = FindResource("TransparentBrush1") as ImageBrush;
                else
                    this.maingrid.Background = Brushes.Transparent;
            }
            
            else
            {
                SkinStorage.SetVisualStyle(window1, button1.Tag.ToString());

                if (tabcheck.IsChecked == false)
                {
                    SkinStorage.SetVisualStyle(TabControlTask, button1.Tag.ToString());
                    SkinStorage.SetVisualStyle(tabcontrol, button1.Tag.ToString());
                }
                if (treecheck.IsChecked == false)
                {
                    SkinStorage.SetVisualStyle(TreeViewTask, button1.Tag.ToString());

                    SkinStorage.SetVisualStyle(treeview, button1.Tag.ToString());
                }
                if (editcheck.IsChecked == false)
                {
                    SkinStorage.SetVisualStyle(EditorTask, button1.Tag.ToString());

                    SkinStorage.SetVisualStyle(integers, button1.Tag.ToString());
                    SkinStorage.SetVisualStyle(doubles, button1.Tag.ToString());
                    SkinStorage.SetVisualStyle(updown, button1.Tag.ToString());
                    SkinStorage.SetVisualStyle(masked, button1.Tag.ToString());
                    SkinStorage.SetVisualStyle(currency, button1.Tag.ToString());
                    SkinStorage.SetVisualStyle(percents, button1.Tag.ToString());
                }
                if (autocheck.IsChecked == false)
                {
                    SkinStorage.SetVisualStyle(AutoCompleteTask, button1.Tag.ToString());

                    SkinStorage.SetVisualStyle(autocomplete, button1.Tag.ToString());
                    SkinStorage.SetVisualStyle(fontcombo, button1.Tag.ToString());
                    SkinStorage.SetVisualStyle(datetime, button1.Tag.ToString());
                }
                if (fontcheck.IsChecked == false)
                {
                    SkinStorage.SetVisualStyle(FontListTask, button1.Tag.ToString());

                    SkinStorage.SetVisualStyle(fontlist, button1.Tag.ToString());
                    SkinStorage.SetVisualStyle(scrolls, button1.Tag.ToString());
                }
                if (groupcheck.IsChecked == false)
                {
                    SkinStorage.SetVisualStyle(GroupBarTask, button1.Tag.ToString());

                    SkinStorage.SetVisualStyle(groupbar, button1.Tag.ToString());
                }
                if (calendarcheck.IsChecked == false)
                {
                    SkinStorage.SetVisualStyle(CalendarTask, button1.Tag.ToString());

                    SkinStorage.SetVisualStyle(calendaredit, button1.Tag.ToString());
                }
                if (clockcheck.IsChecked == false)
                {
                    SkinStorage.SetVisualStyle(ClockTask, button1.Tag.ToString());

                    SkinStorage.SetVisualStyle(clockcontrol, button1.Tag.ToString());
                }
                if (colorcheck.IsChecked == false)
                {
                    SkinStorage.SetVisualStyle(ColorPickerTask, button1.Tag.ToString());

                    SkinStorage.SetVisualStyle(colorpicker, button1.Tag.ToString());
                }
                if (gallerycheck.IsChecked == false)
                {
                    SkinStorage.SetVisualStyle(GalleryTask, button1.Tag.ToString());

                    SkinStorage.SetVisualStyle(Gallery1, button1.Tag.ToString());
                }
                if (microcheck.IsChecked == false)
                {                   
                    SkinStorage.SetVisualStyle(microsoftcontrol, button1.Tag.ToString());
                }
            }
        }

        /// <summary>
        /// Handles the SelectionChanged event of the colorItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void colorItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (window1 != null)
            {
                BrushConverter conv = new BrushConverter();
                if (colorItem.SelectedItem != null)
                {
                    string color = colorItem.SelectedItem.ToString();
                    if (color != "None")
                    {
                        SolidColorBrush brush = conv.ConvertFromString(color) as SolidColorBrush;
                        SkinManager.SetActiveColorScheme(window1, brush);
                    }
                }
            }
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
        /// Handles the 1 event of the Button_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button button1 = sender as Button;
            if (tabcheck.IsChecked == true)
            {
                SkinStorage.SetVisualStyle(tabcontrol, button1.Tag.ToString());
            }
            if (treecheck.IsChecked == true)
            {
                SkinStorage.SetVisualStyle(treeview, button1.Tag.ToString());
            }
            if (editcheck.IsChecked == true)
            {
                SkinStorage.SetVisualStyle(integers, button1.Tag.ToString());
                SkinStorage.SetVisualStyle(doubles, button1.Tag.ToString());
                SkinStorage.SetVisualStyle(updown, button1.Tag.ToString());
                SkinStorage.SetVisualStyle(masked, button1.Tag.ToString());
                SkinStorage.SetVisualStyle(currency, button1.Tag.ToString());
                SkinStorage.SetVisualStyle(percents, button1.Tag.ToString());
            }
            if (autocheck.IsChecked == true)
            {
                SkinStorage.SetVisualStyle(autocomplete, button1.Tag.ToString());
                SkinStorage.SetVisualStyle(fontcombo, button1.Tag.ToString());
                SkinStorage.SetVisualStyle(datetime, button1.Tag.ToString());
            }
            if (fontcheck.IsChecked == true)
            {
                SkinStorage.SetVisualStyle(fontlist, button1.Tag.ToString());
                SkinStorage.SetVisualStyle(scrolls, button1.Tag.ToString());
            }
            if (groupcheck.IsChecked == true)
            {
                SkinStorage.SetVisualStyle(groupbar, button1.Tag.ToString());
            }
            if (calendarcheck.IsChecked == true)
            {
                SkinStorage.SetVisualStyle(calendaredit, button1.Tag.ToString());
            }
            if (clockcheck.IsChecked == true)
            {
                SkinStorage.SetVisualStyle(clockcontrol, button1.Tag.ToString());
            }
            if (colorcheck.IsChecked == true)
            {
                SkinStorage.SetVisualStyle(colorpicker, button1.Tag.ToString());
            }
            if (gallerycheck.IsChecked == true)
            {
                SkinStorage.SetVisualStyle(Gallery1, button1.Tag.ToString());
            }
            if (microcheck.IsChecked == true)
            {
                SkinStorage.SetVisualStyle(microsoftcontrol, button1.Tag.ToString());
            }
        }

        /// <summary>
        /// Handles the Checked event of the tabcheck control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void tabcheck_Checked(object sender, RoutedEventArgs e)
        {
            blend.Visibility = Visibility.Collapsed;
            defaults.Visibility = Visibility.Collapsed;
            office.Visibility = Visibility.Collapsed;
            blue.Visibility = Visibility.Collapsed;
            silver.Visibility = Visibility.Collapsed;
            black.Visibility = Visibility.Collapsed;
            orange.Visibility = Visibility.Collapsed;
            blend1.Visibility = Visibility.Visible;
            default1.Visibility = Visibility.Visible;
            office1.Visibility = Visibility.Visible;
            blue1.Visibility = Visibility.Visible;
            silver1.Visibility = Visibility.Visible;
            black1.Visibility = Visibility.Visible;
            orange1.Visibility = Visibility.Visible;
            shinyblue1.Visibility = Visibility.Visible;
            shinyred1.Visibility = Visibility.Visible;
            vs20101.Visibility = Visibility.Visible;
            colorItem.Visibility = Visibility.Collapsed;
            colorItem1.Visibility = Visibility.Visible;
            shinyred.Visibility = Visibility.Collapsed;
            shinyblue.Visibility = Visibility.Collapsed;
            vs2010.Visibility = Visibility.Collapsed;
            black2010.Visibility = Visibility.Collapsed;
            off2010black.Visibility = Visibility.Visible;
            blue2010.Visibility = Visibility.Collapsed;
            Off2010blue.Visibility = Visibility.Visible;
            silver2010.Visibility = Visibility.Collapsed;
            off2010silver.Visibility = Visibility.Visible;
            metro.Visibility = Visibility.Collapsed;
            metro1.Visibility = Visibility.Visible;
            transparent.Visibility = Visibility.Collapsed;
            transparent1.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Handles the Unchecked event of the tabcheck control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void tabcheck_Unchecked(object sender, RoutedEventArgs e)
        {

            colorItem.Visibility = Visibility.Visible;
            colorItem1.Visibility = Visibility.Collapsed;
            blend1.Visibility = Visibility.Collapsed;
            default1.Visibility = Visibility.Collapsed;
            office1.Visibility = Visibility.Collapsed;
            blue1.Visibility = Visibility.Collapsed;
            silver1.Visibility = Visibility.Collapsed;
            black1.Visibility = Visibility.Collapsed;
            orange1.Visibility = Visibility.Collapsed;
            blend.Visibility = Visibility.Visible;
            defaults.Visibility = Visibility.Visible;
            office.Visibility = Visibility.Visible;
            blue.Visibility = Visibility.Visible;
            silver.Visibility = Visibility.Visible;
            black.Visibility = Visibility.Visible;
            orange.Visibility = Visibility.Visible;
            shinyblue.Visibility = Visibility.Visible;
            shinyblue1.Visibility = Visibility.Collapsed;
            vs20101.Visibility = Visibility.Collapsed;
            shinyred.Visibility = Visibility.Visible;
            vs2010.Visibility = Visibility.Visible;
            shinyred1.Visibility = Visibility.Collapsed;
            black2010.Visibility = Visibility.Visible;
            off2010black.Visibility = Visibility.Collapsed;
            blue2010.Visibility = Visibility.Visible;
            Off2010blue.Visibility = Visibility.Collapsed;
            silver2010.Visibility = Visibility.Visible;
            off2010silver.Visibility = Visibility.Collapsed;
            metro1.Visibility = Visibility.Collapsed;
            metro.Visibility = Visibility.Visible;
            transparent1.Visibility = Visibility.Collapsed;
            transparent.Visibility = Visibility.Visible;

        }

        /// <summary>
        /// Handles the SelectionChanged event of the colorItem1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void colorItem1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string color=null;
            if (window1 != null)
            {
                if (colorItem1.SelectedItem != null)
                {
                    color = colorItem1.SelectedItem.ToString();
                    if (color != "None")
                    {
                        brush = conv.ConvertFromString(color) as SolidColorBrush;
                    }
                }
            }
            if (color != "None")
            {
                if (tabcheck.IsChecked == true)
                {
                    SkinManager.SetActiveColorScheme(tabcontrol, brush);
                }
                if (gallerycheck.IsChecked == true)
                {
                    SkinManager.SetActiveColorScheme(Gallery1, brush);
                }
                if (microcheck.IsChecked == true)
                {
                    SkinManager.SetActiveColorScheme(microsoftcontrol, brush);
                }
                if (calendarcheck.IsChecked == true)
                {
                    SkinManager.SetActiveColorScheme(calendaredit, brush);
                }
                if (clockcheck.IsChecked == true)
                {
                    SkinManager.SetActiveColorScheme(clockcontrol, brush);
                }
                if (colorcheck.IsChecked == true)
                {
                    SkinManager.SetActiveColorScheme(colorpicker, brush);
                }
                if (treecheck.IsChecked == true)
                {
                    SkinManager.SetActiveColorScheme(treeview, brush);
                }
                if (groupcheck.IsChecked == true)
                {
                    SkinManager.SetActiveColorScheme(groupbar, brush);
                }
                if (autocheck.IsChecked == true)
                {
                    SkinManager.SetActiveColorScheme(autocomplete, brush);
                    SkinManager.SetActiveColorScheme(datetime, brush);
                    SkinManager.SetActiveColorScheme(fontcombo, brush);
                }
                if (fontcheck.IsChecked == true)
                {
                    SkinManager.SetActiveColorScheme(fontlist, brush);
                    SkinManager.SetActiveColorScheme(scrolls, brush);
                }
                if (editcheck.IsChecked == true)
                {
                    SkinManager.SetActiveColorScheme(currency, brush);
                    SkinManager.SetActiveColorScheme(percents, brush);
                    SkinManager.SetActiveColorScheme(integers, brush);
                    SkinManager.SetActiveColorScheme(doubles, brush);
                    SkinManager.SetActiveColorScheme(updown, brush);
                    SkinManager.SetActiveColorScheme(masked, brush);
                }
            }
        }

        /// <summary>
        /// Colorpicker_s the color changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void colorpicker_ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            colorpick.Foreground = new SolidColorBrush(colorpicker.Color);
        }

        /// <summary>
        /// Fontlist_s the selected font family changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void fontlist_SelectedFontFamilyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            fonttext.FontFamily = fontlist.SelectedFontFamily;
        }
        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        #endregion     

        private void window1_Loaded(object sender, RoutedEventArgs e)
        {
            SkinStorage.SetVisualStyle(this, "Metro");
        }
       
    }
}
