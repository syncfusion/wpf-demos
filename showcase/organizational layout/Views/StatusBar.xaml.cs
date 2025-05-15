#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.organizationallayout.wpf
{
    /// <summary>
    /// Interaction logic for StatusBar.xaml
    /// </summary>
    public partial class StatusBar : UserControl
    {
        public StatusBar()
        {
            InitializeComponent();
        }
        private void Text_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock text = sender as TextBlock;
            if (text != null)
            {
                ZoomPanWindow zoomWindow = new ZoomPanWindow();
                zoomWindow.DataContext = this.DataContext;
                zoomWindow.ShowDialog();
            }
        }

    }
}
