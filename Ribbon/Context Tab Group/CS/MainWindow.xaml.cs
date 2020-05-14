#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using Syncfusion.Windows.Tools.Controls;
using Microsoft.Win32;
using System.IO;
using System.Windows.Markup;
using Syncfusion.Windows.Shared;
using System.Windows.Threading;


namespace ContextTabGroupSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        #region Constructor
        /// <summary>
        ///  Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            try
            {

                InitializeComponent();
                Editor.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(Editor_MouseUp);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Handles the Loaded event of the ribbonwindow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        /// 
        private void ribbonwindow_Loaded(object sender, RoutedEventArgs e)
        {
            //SkinStorage.SetVisualStyle(this, "Metro");
        }
       
        /// <summary>
        /// Method which invokes when mouse up.
        /// </summary>
        /// <param name="sender">The mouse up click event.</param>
        /// <param name="e">The <see cref="System.Windows.MouseButtonEventArgs"/> instance containing the event data.</param>
        void Editor_MouseUp(object sender, MouseButtonEventArgs e)
        {
            pictureTools.IsGroupVisible = false;
            imgborder.BorderThickness = new Thickness(0);
        }

        /// <summary>
        /// Method which is used to return from backstage.
        /// </summary>
        /// <param name="sender">Backstage.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Return(object sender, RoutedEventArgs e)
        {
            ribbon1.HideBackStage();
        }

        /// <summary>
        /// Method which is used to exit from the window.
        /// </summary>
        /// <param name="sender">Window</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Method which invokes when the image clicked.
        /// </summary>
        /// <param name="sender">Button left click.</param>
        /// <param name="e">The <see cref="System.Windows.MouseButtonEventArgs"/> instance containing the event data.</param>
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            pictureTools.IsGroupVisible = true;            
            imgborder.BorderThickness = new Thickness(1);
        }
        #endregion
    }
}


