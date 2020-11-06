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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using syncfusion.demoscommon.wpf;

namespace syncfusion.treeviewdemos.wpf
{
    public class File : NotificationObject, IFile
    {
        private ObservableCollection<SubFile> subFiles;

        public ObservableCollection<SubFile> SubFiles
        {
            get { return subFiles; }
            set
            {
                subFiles = value;
                RaisePropertyChanged("SubFiles");
            }
        }

        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                RaisePropertyChanged("FileName");
            }
        }

        private BitmapImage imageIcon;

        public BitmapImage ImageIcon
        {
            get { return imageIcon; }
            set
            {
                imageIcon = value;
                RaisePropertyChanged("ImageIcon");
            }
        }

        public string Name
        {
            get;

            set;
        }

        public DateTime DateModified
        {
            get;

            set;
        }

        public string FileType
        {
            get;

            set;
        }

        public double Size
        {
            get;

            set;
        }

        public object Info
        {
            get;

            set;
        }

        public ImageSource Icon
        {
            get;

            set;
        }

        private bool isSelected;

        public bool IsSelected
        {
            get 
            { 
                return isSelected; 
            }
            set 
            { 
                isSelected = value;
                RaisePropertyChanged("IsSelected");
            }
        }
    }

    public class Directory : File
    {
        public Directory()
        {
            Files = new ObservableCollection<IFile>();
            Items = new ObservableCollection<IFile>();
        }

        private ObservableCollection<IFile> files;

        public ObservableCollection<IFile> Files
        {
            get
            {
                return files;
            }

            set
            {
                files = value;
                base.RaisePropertyChanged("Files");
            }
        }

        private ObservableCollection<IFile> items;

        public ObservableCollection<IFile> Items
        {
            get
            {
                return items;
            }

            set
            {
                items = value;
               base.RaisePropertyChanged("Items");
            }
        } 
    }
}
