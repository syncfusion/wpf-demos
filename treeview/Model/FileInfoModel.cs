#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.treeviewdemos.wpf
{
    public class FileInfoModel : NotificationObject
    {
        public FileInfoModel()
        {
            Childs = new ObservableCollection<FileInfoModel>();
        }

        private string header = string.Empty;

        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
                this.RaisePropertyChanged(() => this.Header);
            }
        }

        private BitmapImage imageSource = null;

        public BitmapImage Image
        {
            get
            {
                return imageSource;
            }
            set
            {
                imageSource = value;
                this.RaisePropertyChanged(() => this.Image);
            }
        }

        private bool isexpanded = true;

        public bool IsExpanded
        {
            get
            {
                return isexpanded;
            }
            set
            {
                isexpanded = value;
                this.RaisePropertyChanged(() => this.IsExpanded);
            }
        }

        private ObservableCollection<FileInfoModel> childs = null;

        public ObservableCollection<FileInfoModel> Childs
        {
            get
            {
                return childs;
            }
            set
            {
                childs = value;
                this.RaisePropertyChanged(() => this.Childs);
            }
        }
    }
}
