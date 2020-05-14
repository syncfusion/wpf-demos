#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
        #region Field
        /// <summary>
        /// Maintains previous value.
        /// </summary>
        private double previousValue;
        #endregion

        #region Property
        /// <summary>
        /// Gets and sets the previous value.
        /// </summary>
        public double PreviousValue
        {
            get
            {
                return previousValue;
            }
            set
            {
                if (previousValue != value)
                    previousValue = value;
            }
        }
        #endregion

        #region constructor
        /// <summary>
        ///  Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            myGroupBar.SelectedTabChanged += myGroupBar_SelectedTabChanged;
            myGroupBar.CollapsedChanged += myGroupBar_CollapsedChanged;
            splitter.DragStarted += splitter_DragStarted;
            this.DataContext = new ViewModel();
            SelectedContent.Content = new MailView() { };
        }
        #endregion

        #region HelperMethods
        /// <summary>
        /// Method which is used to start the drag action.
        /// </summary>
        /// <param name="sender">Sender as files which is to be drag</param>
        /// <param name="e">Event handler for darg started method</param>
        void splitter_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
        }

        /// <summary>
        /// Selected changed event for groupbar.
        /// </summary>
        /// <param name="d">Parameter to collapse the dragged files</param>
        /// <param name="e">Event handler for collapsed changed method</param>
        void myGroupBar_CollapsedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                PreviousValue = rootgrid.ColumnDefinitions[0].ActualWidth;
                rootgrid.ColumnDefinitions[0].Width = new GridLength(34d);
            }
            else
                rootgrid.ColumnDefinitions[0].Width = new GridLength(PreviousValue);
        }

        /// <summary>
        /// Selected tab change event for groupbar.
        /// </summary>
        /// <param name="sender">Sender as groupbar to change the selected tab</param>
        /// <param name="e">Event handler to change the tab</param>
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
        #endregion
    }
}
