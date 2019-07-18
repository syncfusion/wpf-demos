#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
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
                (this.Content as Invoice.MainPage).WordExport.FontSize = 12;
            }
            else
            {
                (this.Content as Invoice.MainPage).WordExport.FontSize = 16;
            }
        }

        
    }
}
