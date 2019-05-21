#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Syncfusion.Windows.Tools.Controls;
using Microsoft.Win32;
using System.IO;
using System.Windows.Markup;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools;

namespace LocalizationDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {  
     

        //Initialization

        #region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {           
          InitializeComponent();             
        }


        #endregion

        private void ribbonwindow_Loaded(object sender, RoutedEventArgs e)
        {
            SkinStorage.SetVisualStyle(this, "Office2010Silver");         
        } 

    }
}
