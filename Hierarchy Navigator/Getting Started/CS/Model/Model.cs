#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.ComponentModel;

namespace HierarchyNavigator_2008
{
    public class Model : INotifyPropertyChanged
    {        
        private string content;
        public string Content 
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }

        private ImageSource folderImage;
        public ImageSource FolderImage 
        { 
            get
            {
                return folderImage;
            }
            set
            {
                folderImage = value;
                OnPropertyChanged("FolderImage");
            }
        }

        private ObservableCollection<Model> folderItems;
        public ObservableCollection<Model> FolderItems 
        { 
            get
            {
                return folderItems;
            }
            set
            {
                folderItems = value;
                OnPropertyChanged("FolderItems");
            }
        }

        public Model()
        {
            folderItems = new ObservableCollection<Model>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
