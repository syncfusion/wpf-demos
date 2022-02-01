#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Resources;

namespace syncfusion.succinctlyseries.wpf
{
    public class Book : INotifyPropertyChanged
    {
        Visibility m_isVisble = Visibility.Collapsed;
        public string Name { get; set; }
        public string BookName { get; set; }
        public PDFViewerPage ViewerPage { get; set; }
        public ImageSource Image { get; set; }
        ICommand m_readCommand;

        public Visibility ReadVisibility
        {
            get
            {
                return m_isVisble;
            }
            set
            {
                m_isVisble = value;
                RaisePropertyChanged(new PropertyChangedEventArgs("ReadVisibility"));
            }
        }

        public Book()
        {
            m_readCommand = new DelegateCommand(OnReadCommand);
        }

        public ICommand ReadCommand
        {
            get
            {
                return m_readCommand;
            }
        }

        void OnReadCommand(object sender)
        {
            Navigator.Frame.Navigate(ViewerPage);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }
}