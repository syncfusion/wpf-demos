#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows;
using System.Windows.Input;

namespace syncfusion.treeviewdemos.wpf
{
    public class Model : INotifyPropertyChanged
    {
        public Model()
        {
            subItems = new ObservableCollection<Model>();
        }

        private ObservableCollection<Model> subItems;
        public ObservableCollection<Model> SubItems
        {
            get
            {
                return subItems;
            }

            set
            {
                subItems = value;
                RaisePropertyChanged("SubItems");
            }
        }

        private string header;

        /// <summary>
        /// Gets or sets a value indicating the Header of the TreeViewItemAdv.
        /// </summary>        
        public string Header
        {
            get
            {
                return header;
            }

            set
            {
                header = value;
                this.RaisePropertyChanged("Header");
            }
        }      


        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }
}
