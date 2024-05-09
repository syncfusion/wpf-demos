#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.IO;
using System.Windows;
using System.Windows.Resources;

namespace syncfusion.pdfviewerdemos.wpf
{
    public class EncryptionViewModel
    {
        private Stream m_documentStream;
        private Encryption encryption = null;

        /// <summary>
        /// Gets or sets the documnet path.
        /// </summary>
        public Stream DocumentStream
        {
            get
            {
                return m_documentStream;
            }
            set
            {
                m_documentStream = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel"/> class.
        /// </summary>
        public EncryptionViewModel()
        {
            m_documentStream = GetFileStream("Encrypted Document.pdf");
        }
        private Stream GetFileStream(string fileName)
        {
            Uri uriResource = new Uri("/syncfusion.pdfviewerdemos.wpf;component/Assets/" + fileName, UriKind.Relative);
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(uriResource);
            return streamResourceInfo.Stream;
        }

        public void Loaded(object sender, RoutedEventArgs e)
        {
            encryption = (sender as Encryption).FindName("encryption") as Encryption;
            encryption.userpassword.Click += new RoutedEventHandler(Userpassword_Click);
            encryption.ownerpassword.Click += new RoutedEventHandler(Ownerpassword_Click);
        }

        private void Ownerpassword_Click(object sender, RoutedEventArgs e)
        {
            encryption.userpassword.Visibility = Visibility.Collapsed;
            encryption.ownerpassword.Visibility = Visibility.Collapsed;
            encryption.pdfviewer1.Visibility = Visibility.Visible;
            encryption.pdfviewer1.Load(DocumentStream, "syncfusion");
        }

        private void Userpassword_Click(object sender, RoutedEventArgs e)
        {
            encryption.userpassword.Visibility = Visibility.Collapsed;
            encryption.ownerpassword.Visibility = Visibility.Collapsed;
            encryption.pdfviewer1.Visibility = Visibility.Visible;
            encryption.pdfviewer1.Load(DocumentStream, "password");
        }

        public void Closed(object sender, RoutedEventArgs e)
        {
            encryption.userpassword.Visibility = Visibility.Visible;
            encryption.ownerpassword.Visibility = Visibility.Visible;
            encryption.userpassword.Click -= Userpassword_Click;
            encryption.ownerpassword.Click -= Ownerpassword_Click;
        }
    }
}
