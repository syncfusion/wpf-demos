#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SfDiagram_binding_with_TreeView.Model
{
    public class Items : INotifyPropertyChanged
    {
        #region fields

        private int _id;

        private int _parentid;

        private string _name;


        private ObservableCollection<Items> _subitems;

        #endregion

        #region Properties

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                if(_id != value)
                {
                    _id = value;
                    OnPropertyChanged("ID");
                }
            }
        }

        public int ParentID
        {
            get
            {
                return _parentid;
            }
            set
            {
                if (_parentid != value)
                {
                    _parentid = value;
                    OnPropertyChanged("ParentID");
                }
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public ObservableCollection<Items> SubItems
        {
            get
            {
                return _subitems;
            }
            set
            {
                if (_subitems != value)
                {
                    _subitems = value;
                    OnPropertyChanged("SubItems");
                }
            }
        }
        #endregion
        
        public event PropertyChangedEventHandler PropertyChanged;

        public Items()
        {

        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
