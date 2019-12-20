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


       
      
        #region Events


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


       
        #endregion 

      
        void Editor_MouseUp(object sender, MouseButtonEventArgs e)
        {
            pictureTools.IsGroupVisible = false;
            imgborder.BorderThickness = new Thickness(0);
        }

        private void Return(object sender, RoutedEventArgs e)
        {
            ribbon1.HideBackStage();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            pictureTools.IsGroupVisible = true;            
            imgborder.BorderThickness = new Thickness(1);
           
        }    

      
    
    
    }
}

