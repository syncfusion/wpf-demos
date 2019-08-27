#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Controls.Layout;
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

namespace Accordion
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
        private void LoadValues(object sender, RoutedEventArgs e)
        {
            Mode.Items.Clear();
            Mode.Items.Add(AccordionSelectionMode.One);
            Mode.Items.Add(AccordionSelectionMode.OneOrMore);
            Mode.Items.Add(AccordionSelectionMode.ZeroOrMore);
            Mode.Items.Add(AccordionSelectionMode.ZeroOrOne);
            Mode.SelectedIndex = 0;
        }

        /// <summary>
        /// To load the VisualStyles
        /// </summary>
        /// <param name="sender">VisualStyle Combobox</param>
        /// <param name="e">RoutedEventArgs</param>
        private void LoadStyle(object sender, RoutedEventArgs e)
        {
            VisualStyle.Items.Clear();
            VisualStyle.Items.Add("Metro");
            VisualStyle.Items.Add("Blend");
            VisualStyle.Items.Add("Office365");
            VisualStyle.Items.Add("Office2010Blue");
            VisualStyle.Items.Add("Office2010Black");
            VisualStyle.Items.Add("Office2010Silver");
            VisualStyle.Items.Add("Office2013White");
            VisualStyle.Items.Add("Office2013Darkgray");
            VisualStyle.Items.Add("Office2013Lightgray");
            VisualStyle.Items.Add("Office2016White");
            VisualStyle.Items.Add("Office2016Darkgray");
            VisualStyle.Items.Add("Office2016Colorful");
            VisualStyle.Items.Add("VisualStudio2013");
            VisualStyle.Items.Add("VisualStudio2015");
            VisualStyle.Items.Add("Lime");
            VisualStyle.Items.Add("Saffron");
            VisualStyle.SelectedIndex = 0;
        }

        /// <summary>
        /// Invoked when the Theme Selection changed.
        /// </summary>
        /// <param name="sender">VisualStyle ComboBox</param>
        /// <param name="e">SelectionChangedEventArgs</param>
        private void VisualStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VisualStyle.SelectedIndex == 0)
            {
                SfSkinManager.SetVisualStyle(accordion, VisualStyles.Metro);
            }
            else if(VisualStyle.SelectedIndex == 1)
            {
                SfSkinManager.SetVisualStyle(accordion, VisualStyles.Blend);
            }
            else if (VisualStyle.SelectedIndex == 2)
            {
                SfSkinManager.SetVisualStyle(accordion, VisualStyles.Office365);
            }
            else if (VisualStyle.SelectedIndex == 3)
            {
                SfSkinManager.SetVisualStyle(accordion, VisualStyles.Office2010Blue);
            }
            else if (VisualStyle.SelectedIndex == 4)
            {
                SfSkinManager.SetVisualStyle(accordion, VisualStyles.Office2010Black);
            }
            else if (VisualStyle.SelectedIndex == 5)
            {
                SfSkinManager.SetVisualStyle(accordion, VisualStyles.Office2010Silver);
            }
            else if (VisualStyle.SelectedIndex == 6)
            {
                SfSkinManager.SetVisualStyle(accordion, VisualStyles.Office2013White);
            }
            else if (VisualStyle.SelectedIndex == 7)
            {
                SfSkinManager.SetVisualStyle(accordion, VisualStyles.Office2013DarkGray);
            }
            else if (VisualStyle.SelectedIndex == 8)
            {
                SfSkinManager.SetVisualStyle(accordion, VisualStyles.Office2013LightGray);
            }
            else if (VisualStyle.SelectedIndex == 9)
            {
                SfSkinManager.SetVisualStyle(accordion, VisualStyles.Office2016White);
            }
            else if (VisualStyle.SelectedIndex == 10)
            {
                SfSkinManager.SetVisualStyle(accordion, VisualStyles.Office2016DarkGray);
            }
            else if (VisualStyle.SelectedIndex == 11)
            {
                SfSkinManager.SetVisualStyle(accordion, VisualStyles.Office2016Colorful);
            }
            else if (VisualStyle.SelectedIndex == 12)
            {
                SfSkinManager.SetVisualStyle(accordion, VisualStyles.VisualStudio2013);
            }
            else if (VisualStyle.SelectedIndex == 13)
            {
                SfSkinManager.SetVisualStyle(accordion, VisualStyles.VisualStudio2015);
            }
            else if (VisualStyle.SelectedIndex == 14)
            {
                SfSkinManager.SetVisualStyle(accordion, VisualStyles.Lime);
            }
            else if (VisualStyle.SelectedIndex == 15)
            {
                SfSkinManager.SetVisualStyle(accordion, VisualStyles.Saffron);
            }
        }
    }
}
