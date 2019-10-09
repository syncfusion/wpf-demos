#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Xml;
using System.ComponentModel;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Shared;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace AutoHideDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        #region Private Members

        /// <summary>
        /// Private Members
        /// </summary>
        private const String DefaultName = "Default";
        private const String BlendName = "Blend";
        private const String Office2007Blue = "Office2007Blue";
        private const String Office2007Black = "Office2007Black";
        private const String Office2007Silver = "Office2007Silver";
        private Random rand;
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for window1.
        /// </summary>

        public Window1()
        {
            InitializeComponent();
            InitializeLog();
        }
        /// <summary>
        /// Initialization while creating object
        /// </summary>  
        public void InitializeLog()
        {
            // Define the Height and Width of the window
            window1.Width = System.Windows.SystemParameters.PrimaryScreenWidth * (0.67);
            window1.Height = System.Windows.SystemParameters.PrimaryScreenHeight * (0.67);
            // Set the random number
            rand = new Random(300);
            animationSpeed.SelectedIndex = 2;            
        }
        #endregion

        #region Helper Methods
        
        /// <summary>
        /// Set animation delay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SetCustomDelay();
            }
        }

        #endregion

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetCustomDelay();
        }

        private void SetCustomDelay()
        {
            
            long l;
            if (long.TryParse(textBox1.Text, out l))
            {
                l = l * 10000;
                DockingManager.SetAnimationDelay(dockingManager, new Duration(new TimeSpan(l)));
            }
            else
            {
                DockingManager.SetAnimationDelay(dockingManager, new Duration(TimeSpan.FromMilliseconds(200)));
            }
        }

        private void AnimationSpeed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (sender as ComboBox).SelectedItem as ComboBoxItem;
            
            // Set animation speed as very slow
            if (selectedItem.Content.ToString() == "Very Slow")
                DockingManager.SetAnimationDelay(dockingManager, new Duration(new TimeSpan(30000000)));
            // Set animation speed as slow
            else if (selectedItem.Content.ToString() == "Slow")
                DockingManager.SetAnimationDelay(dockingManager, new Duration(new TimeSpan(10000000)));
            // Set animation speed as normal
            else if (selectedItem.Content.ToString() == "Normal")
                DockingManager.SetAnimationDelay(dockingManager, new Duration(new TimeSpan(5000000)));
            // Set animation speed as fast
            else if (selectedItem.Content.ToString() == "Fast")
                DockingManager.SetAnimationDelay(dockingManager, new Duration(new TimeSpan(1000000)));
            // Set animation speed as very fast
            else if (selectedItem.Content.ToString() == "Very Fast")
                DockingManager.SetAnimationDelay(dockingManager, new Duration(new TimeSpan(10000)));
            valueLabel.IsEnabled = false;
            textBox1.IsEnabled = false;
            if (selectedItem.Content.ToString() == "Custom(ms)")
            {
                valueLabel.IsEnabled = true;
                textBox1.IsEnabled = true;
            }
        }
    }
}



