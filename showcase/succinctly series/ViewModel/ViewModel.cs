#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace syncfusion.succinctlyseries.wpf
{
    public class ViewModel : INotifyPropertyChanged
    {
        PDFViewerPage m_viewerPage = new PDFViewerPage();
        int m_selectedBookIndex = 0;
        ObservableCollection<Book> m_books = new ObservableCollection<Book>();
        Book m_previousBook;
        ICommand m_backCommand;

        /// <summary>
        /// Gets the collection of books
        /// </summary>
        public ObservableCollection<Book> Books
        {
            get
            {
                return m_books;
            }
        }

        /// <summary>
        /// Data context
        /// </summary>
        public ViewModel()
        {
            m_viewerPage.DataContext = this;
            m_books.Add(GetBook("HTTP_Succinctly", @"04-Http.png", "HTTP Succinctly", Visibility.Visible));
            m_books.Add(GetBook("jQuery_Succinctly", "01 Jquery.png", "jQuery Succinctly", Visibility.Collapsed));
            m_books.Add(GetBook("JavaScript_Succinctly", "05-Java-Script.png", "JavaScript Succinctly", Visibility.Collapsed));
            m_books.Add(GetBook("WindowsStoreApps_Succinctly", "15-Win-Store-Apps.png", "Windows Store Apps Succinctly", Visibility.Collapsed));
            m_books.Add(GetBook("LightSwitch_Succinctly", "06-LightSwitch.png", "LightSwitch Succinctly", Visibility.Collapsed));
            m_books.Add(GetBook("aspnetmvc4_Succinctly", "07-Asp.net-MVC-4-Mob-Web.png", "ASP.NET MVC 4 Succinctly", Visibility.Collapsed));
            m_books.Add(GetBook("Knockoutjs_Succinctly", "09-Knockout-JS.png", "Knockout JS Succinctly", Visibility.Collapsed));
            m_books.Add(GetBook("GIS Succinctly", "13-GIS.png", "GIS Succinctly", Visibility.Collapsed));
            m_books.Add(GetBook("iOS_Succinctly", "16 iOS ebook.png", "iOS Succinctly", Visibility.Collapsed));
            m_previousBook = Books[0];
            m_backCommand = new DelegateCommand(OnBackCommand);
        }

        Book GetBook(string fileName, string imageName, string bookName, Visibility readVisibility)
        {
            Book book = new Book();
            book.Name = fileName;
            book.BookName = bookName;
            book.Image = GetImageSource(imageName);
            book.ReadVisibility = readVisibility;
            book.ViewerPage = m_viewerPage;
            return book;
        }

        public ICommand BackCommand
        {
            get
            {
                return m_backCommand;
            }
        }

        void OnBackCommand(object sender)
        {
            if (Navigator.Frame != null)
            {
                if (m_viewerPage != null)
                    m_viewerPage.Unload();
                Navigator.Frame.GoBack();
            }
        }

        ImageSource GetImageSource(string filePath)
        {
            return new BitmapImage(new Uri(@"/syncfusion.succinctlyseries.wpf;component/Assets/Succinctly Series/" + filePath, UriKind.RelativeOrAbsolute));
        }

        public int SelectedBookIndex
        {
            get
            {
                return m_selectedBookIndex;
            }
            set
            {
                if (value != m_selectedBookIndex)
                {
                    if (m_previousBook != null)
                        m_previousBook.ReadVisibility = System.Windows.Visibility.Collapsed;
                    m_previousBook = Books[value];
                    m_previousBook.ReadVisibility = System.Windows.Visibility.Visible;
                }
                m_selectedBookIndex = value;
                RaisePropertyChanged(new PropertyChangedEventArgs("SelectedBookIndex"));
                RaisePropertyChanged(new PropertyChangedEventArgs("DocumentStream"));
                RaisePropertyChanged(new PropertyChangedEventArgs("SelectedBookName"));
            }
        }

        public Stream DocumentStream
        {
            get
            {
                if (Books != null && Books.Count > 0)
                    return GetFileStream(Books[SelectedBookIndex].Name);
                else
                    return GetFileStream(Books[0].Name);
            }
        }

        public string SelectedBookName
        {
            get
            {
                if (Books != null && Books.Count > 0)
                    return Books[SelectedBookIndex].BookName;
                else
                    return Books[0].BookName;
            }
        }

        private Stream GetFileStream(string fileName)
        {
            Uri uriResource = new Uri(@"/syncfusion.succinctlyseries.wpf;component/Assets/Succinctly Series/" + fileName + ".pdf", UriKind.Relative);
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(uriResource);
            return streamResourceInfo.Stream;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public void Dispose()
        {
            if (DocumentStream != null)
                DocumentStream.Dispose();
            if (Books != null && Books.Count > 0)
                Books.Clear();
        }
    }
}