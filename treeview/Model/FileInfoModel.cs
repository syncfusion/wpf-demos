#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.treeviewdemos.wpf
{
    public class FileInfoModel : INotifyPropertyChanged, IEditableObject
    {
        #region Fields

        private string name;
        internal FileInfoModel backUpData;
        private FileInfoModel currentData;

        private string header = string.Empty;
        private BitmapImage imageSource = null;
        private bool isexpanded = true;
        private ObservableCollection<FileInfoModel> childs = null;

        #endregion

        #region Constructor

        public FileInfoModel()
        {

        }

        public FileInfoModel(string name):base()
        {
            Childs = new ObservableCollection<FileInfoModel>();
            this.currentData = new FileInfoModel();
            this.currentData.name = name;
        }

        #endregion

        #region Properties

        public string Header
        {
            get
            {
                return currentData.name;
            }
            set
            {
                currentData.name = value;
                this.RaisePropertyChanged("Header");
            }
        }

        public BitmapImage Image
        {
            get
            {
                return imageSource;
            }
            set
            {
                imageSource = value;
                this.RaisePropertyChanged("Image");
            }
        }

        public bool IsExpanded
        {
            get
            {
                return isexpanded;
            }
            set
            {
                isexpanded = value;
                this.RaisePropertyChanged("IsExpanded");
            }
        }

        public ObservableCollection<FileInfoModel> Childs
        {
            get
            {
                return childs;
            }
            set
            {
                childs = value;
                this.RaisePropertyChanged("Childs");
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }

        #endregion

        #region IEditableObject

        public void BeginEdit()
        {
            backUpData = new FileInfoModel();
            backUpData.name = this.currentData.name;
        }

        public void EndEdit()
        {
            
        }

        public void CancelEdit()
        {
            this.currentData = backUpData;
        }

        #endregion
    }
}
