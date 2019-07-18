#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
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

namespace GroupbarOutlookDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            myGroupBar.SelectedTabChanged += myGroupBar_SelectedTabChanged;
            myGroupBar.CollapsedChanged += myGroupBar_CollapsedChanged;
            splitter.DragStarted += splitter_DragStarted;
            //sblayout.DefaultVisualStyle = "Office2013";
            this.DataContext = new ViewModel();
            SelectedContent.Content = new MailView() { };
        }

        void splitter_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
           // myGroupBar.Width = double.NaN;
        }
        double prevvalue;
        void myGroupBar_CollapsedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                prevvalue = rootgrid.ColumnDefinitions[0].ActualWidth;
                rootgrid.ColumnDefinitions[0].Width = new GridLength(34d);
            }
            else
                rootgrid.ColumnDefinitions[0].Width = new GridLength(prevvalue);
        }

        void myGroupBar_SelectedTabChanged(object sender, RoutedEventArgs e)
        {
            var selectedtab = (sender as GroupBar).SelectedTab;
            switch ((selectedtab as GroupBarItem).HeaderText)
            {
                case "Mailbox": SelectedContent.Content = new MailView() { DataContext = this.DataContext as ViewModel };
                    break;
                case "Contacts": SelectedContent.Content = null; SelectedContent.Content = new ContactsView() { DataContext = this.DataContext as ViewModel };
                    break;
                case "Tasks": SelectedContent.Content = null; SelectedContent.Content = new TaskView();
                    break;
                case "Notes": SelectedContent.Content = null; SelectedContent.Content = new NotesView() { DataContext = this.DataContext as ViewModel };
                    break;
            }
        }

        private void TreeViewAdv_SelectedItemChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void myGroupBar_SelectedItemChanged_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
