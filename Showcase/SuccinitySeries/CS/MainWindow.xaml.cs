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
using System.Collections.ObjectModel;
using System.IO;
using Syncfusion.Windows.Shared;

namespace SuccinitySeries
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow :ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MinWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 7/ 8;
            this.MinHeight = System.Windows.SystemParameters.PrimaryScreenHeight * (3 / 2) - 50;
            this.Left = System.Windows.SystemParameters.PrimaryScreenWidth/22;
            this.Top = 5;
        }

        #region Fields
        List<Viewer> viewers = new List<Viewer>();
        #endregion

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var book = (sender as Grid).DataContext as Book;
            if (carousel1.SelectedValue == book)
            {
                Viewer view = new Viewer();
                string fileName = @"PDF\" + book.Name + ".pdf";
                view.Title = book.Name;
                view.LoadPdf(fileName);
                viewers.Add(view);
                view.Show();
            }   
        }

        #region Dispose
        private void ChromelessWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (Viewer viewer in viewers)
            {
                viewer.Close();
            }
            viewers.Clear();
        }
        #endregion

    }
}
