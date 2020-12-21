#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.navigationdemos.wpf
{ 
    public class MusicModel
    {
        public ObservableCollection<MusicModel> SubItems { get; set; }
        private string item;
        public string Item
        {
            get { return item; }
            set { item = value; }
        }

        private string header;
        public string Header
        {
            get { return header; }
            set { header = value; }
        }

        private string icon;
        public string Icon
        {
            get { return icon; }
            set { icon = value; }
        }
        private object path;
        public object Path
        {
            get { return path; }
            set { path = value; }
        }
    }
}
