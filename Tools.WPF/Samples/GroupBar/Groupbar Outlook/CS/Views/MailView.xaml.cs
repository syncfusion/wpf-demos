#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace GroupbarOutlookDemo
{
    /// <summary>
    /// Interaction logic for MailView.xaml
    /// </summary>
    public partial class MailView : UserControl , INotifyPropertyChanged
    {
        public MailView()
        {
            InitializeComponent();
        }

        private bool showAll;

        public bool ShowAll
        {
            get { return showAll; }
            set { showAll = value; Notify("ShowAll"); }
        }
        ObservableCollection<SortedMailCollection> unreadCollection = new ObservableCollection<SortedMailCollection>();
        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            PopupLabel.Content = ((sender as ListBox).SelectedItem as ListBoxItem).Content;
        }
        DispatcherTimer timer = new DispatcherTimer();
        private void unReadMail_Checked_1(object sender, RoutedEventArgs e)
        {
        //    timer.Tick += timer_Tick;
         //   timer.Interval = new TimeSpan(15);
         //   timer.Start();
            GetUnread(); 
            allMail.IsChecked = false;
            
            UnreadTreeview.Visibility = System.Windows.Visibility.Visible;
            ShowAllTreeView.Visibility = System.Windows.Visibility.Collapsed;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            SetUnread(); 
            GetUnread();
            //throw new NotImplementedException();
        }

        private void SetUnread()
        {
            if (this.DataContext != null)
            {
                var collection = (this.DataContext as ViewModel).SelectedMailCollection;
                if (collection != null)
                {
                    foreach (var collection1 in unreadCollection)
                    {
                        foreach (var collection2 in unreadCollection)
                        {
                            if (collection1.Header == collection2.Header)
                            {
                                foreach (MailModel mail2 in collection2.MailCollection)
                                {
                                    foreach (MailModel mail1 in collection1.MailCollection)
                                    {
                                        if (mail1.Subject == mail2.Subject)
                                        {
                                            mail1.IsUnRead = mail2.IsUnRead;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void GetUnread()
        {
            unreadCollection.Clear();
            var collection = (this.DataContext as ViewModel).SelectedMailCollection;
            if (collection != null)
            {
                foreach (SortedMailCollection sorted in collection)
                {
                    SortedMailCollection sortedCollection = new SortedMailCollection();
                    sortedCollection.Header = sorted.Header;
                    foreach (MailModel mail in sorted.MailCollection)
                    {
                        if (mail.IsUnRead)
                        {
                            sortedCollection.MailCollection.Add(mail);
                        }
                    }
                    if (sortedCollection.MailCollection.Count > 0)
                    {
                        unreadCollection.Add(sortedCollection);
                    }
                }
            }
            UnreadTreeview.ItemsSource = unreadCollection;
        }
        private void allMail_Checked_1(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            SetUnread();
            ShowAll = true;
            if (unReadMail != null && unReadMail.IsChecked.Value)
                unReadMail.IsChecked = false;
            if (UnreadTreeview != null && ShowAllTreeView != null)
            {
                UnreadTreeview.ItemsSource = null;
                UnreadTreeview.Visibility = System.Windows.Visibility.Collapsed;
                ShowAllTreeView.Visibility = System.Windows.Visibility.Visible;
            }
          
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private void ShowAllTreeView_Loaded_1(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
