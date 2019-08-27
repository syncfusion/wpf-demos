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
using Syncfusion.Windows.Shared;

namespace Invoice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = System.Windows.WindowState.Maximized;
            this.Content = new Invoice.MainPage();
            this.Closed += (sender, e) => this.Dispatcher.InvokeShutdown();
        }

        private void ChromelessWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Height == 675)
            {
                (this.Content as Invoice.MainPage).ExcelExport.FontSize = 12;
                (this.Content as Invoice.MainPage).PDFExport.FontSize = 12;
                (this.Content as Invoice.MainPage).WordExport.FontSize = 12;
            }
            else
            {
                (this.Content as Invoice.MainPage).ExcelExport.FontSize = 16;
                (this.Content as Invoice.MainPage).PDFExport.FontSize = 16;
                (this.Content as Invoice.MainPage).WordExport.FontSize = 16;
            }
        }

        
    }
}
