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

namespace StickyNotesGadget
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SectionAdv section;

        public MainWindow()
        {
            InitializeComponent();

            rte.Loaded += (sender, e) =>
                {
                    section = rte.Document.Sections[0];
                    section.PageBackground = content.Background;
                };
        }

        private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ResizeGrip_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void ApplyBrush(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            Brush TitleBrush = Application.Current.Resources[item.Header.ToString() + "Title"] as Brush;
            Brush ContentBrush = Application.Current.Resources[item.Header.ToString() + "Content"] as Brush;
            title.Background = TitleBrush;
            content.Background = ContentBrush;
            section.PageBackground = ContentBrush;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure want to delete this note?", "Sticky Notes", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            try
            {
                Root.Width += e.HorizontalChange;
                Root.Height += e.VerticalChange;
            }
            catch (Exception)
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.ShowInTaskbar = false;
            win.Owner = this;
            win.Show();
        }
    }
}
