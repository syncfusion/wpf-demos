#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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

namespace GettingStarted_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        #region Constructor
        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter converter = new ImageSourceConverter();
            this.Icon = (ImageSource)converter.ConvertFromString(GetFullTemplatePath("pdf viewer.png", true));

            // Position and size the window.
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 2 / 3;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight * (3 / 2) - 50;
            this.Left = System.Windows.SystemParameters.PrimaryScreenWidth / 6;
            this.Top = 5;
            this.WindowState = WindowState.Maximized;
            this.UseNativeChrome = true;

        }
        #endregion

        private string GetFullTemplatePath(string fileName, bool image)
        {
#if NETCORE
		    string fullPath = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\..\..\..\Common\";
#else
            string fullPath = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\..\..\Common\";
#endif
            string folder = image ? "Images" : "Data";

            return string.Format(@"{0}{1}\PDF\{2}", fullPath, folder, fileName);
        }
    }
}
