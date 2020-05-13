#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using System.IO;


namespace FreeText
{
    /// <summary>
    /// Represents the view model class
    /// </summary>
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string m_filePath;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the documnet path.
        /// </summary>
        public string FilePath
        {
            get
            {
                return m_filePath;
            }
            set
            {
                m_filePath = value;
                RaisePropertyChanged(new PropertyChangedEventArgs("FilePath"));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel"/> class.
        /// </summary>
        public MainPageViewModel()
        {
            string filePath = (GetFullTemplatePath("Free text.pdf", false));
            FilePath = filePath;
        }

        internal void RaisePropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private string GetFullTemplatePath(string fileName, bool image)
        {
#if NETCORE
            string fullPath = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\..\..\..\Common\";
#else
            string fullPath = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\..\..\Common\";
#endif
            string folder = image ? "Images" : "Data";

            return string.Format(@"{0}{1}\PDF\{2}", fullPath, folder, fileName);

        }
    }
}
