#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace GroupbarOutlookDemo
{
    public class GroupbarSubItem : INotifyPropertyChanged
    {
        public string Header { get; set; }
        public ImageSource Source { get; set; }
        public Object Content { get; set; }
        public object Category { get; set; }
        private Object selectedCategory;

        public object SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                Notify("SelectedCategory");
            }
        }

        private void Notify(string name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
