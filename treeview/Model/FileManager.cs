#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.treeviewdemos.wpf
{
    public class FileManager : NotificationObject
    {
        #region Fields

        private string fileName;
        private BitmapImage imageIcon;
        private ObservableCollection<FileManager> subFiles;
        private string fileDescription;
        //"Books for recording periodic entries by the user, such as daily information about a journey, are called logbooks or simply logs. A similar book for writing the owner's daily private personal events, information, and ideas is called a diary or personal journal.";

        #endregion

        #region Constructor
        public FileManager()
        {
        }

        #endregion

        #region Properties
        public ObservableCollection<FileManager> SubFiles
        {
            get { return subFiles; }
            set
            {
                subFiles = value;
                RaisePropertyChanged("SubFiles");
            }
        }

        public string FileDescription
        {
            get { return fileDescription; }
            set
            {
                fileDescription = value;
                RaisePropertyChanged("FileDescription");
            }
        }
        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                RaisePropertyChanged("FileName");
            }
        }
        public BitmapImage ImageIcon
        {
            get { return imageIcon; }
            set
            {
                imageIcon = value;
                RaisePropertyChanged("ImageIcon");
            }
        }

        private Visibility visibility = Visibility.Visible;

        public Visibility Visibility
        {
            get { return visibility; }
            set
            {
                visibility = value;
                RaisePropertyChanged("Visibility");
            }
        }

        #endregion
    }
}
