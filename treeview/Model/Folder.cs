#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using syncfusion.demoscommon.wpf;

namespace syncfusion.treeviewdemos.wpf
{
    public class Folder : NotificationObject
    {
        private string fileName;
        private BitmapImage imageIcon;
        private ObservableCollection<File> files; 

        public ObservableCollection<File> Files
        {
            get { return files; }
            set
            {
                files = value;
                RaisePropertyChanged("Files");
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
    }

    public class SubFile : NotificationObject
    {
        #region Fields

        private string fileName;
        private BitmapImage imageIcon;

        #endregion 

        #region Properties

        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                RaisePropertyChanged("FolderName");
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

        #endregion  
    }
}
