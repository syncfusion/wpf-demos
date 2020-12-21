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

namespace syncfusion.diagramdemo.wpf.Model
{
    public class ExpandandCollapseModel : INotifyPropertyChanged
    {
        private string id;
        private string heatmap = "#FFC34444";
        private string parentId;
        private bool isRoot;
        private State isexpand;

        public ExpandandCollapseModel()
        {
            Models = new ObservableCollection<ExpandandCollapseModel>();
        }

        private string _mDesignation;
        public string Designation
        {
            get { return _mDesignation; }
            set
            {
                if (_mDesignation != value)
                {
                    _mDesignation = value;
                    OnPropertyChanged("Designation");
                }
            }
        }

        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(("Id"));
                }
            }
        }

        public string ParentId
        {
            get
            {
                return parentId;
            }
            set
            {
                if (parentId != value)
                {
                    parentId = value;
                    OnPropertyChanged(("ParentId"));
                }
            }
        }


        public string RatingColor
        {
            get
            {
                return heatmap;
            }
            set
            {
                if (heatmap != value)
                {
                    if (value != null)
                    {
                        heatmap = value;
                        OnPropertyChanged(("RatingColor"));
                    }
                }
            }
        }
        public bool IsRoot
        {
            get
            {
                return isRoot;
            }
            set
            {
                if (isRoot != value)
                {
                    isRoot = value;
                    OnPropertyChanged(("IsChild"));
                }
            }
        }
        public State IsExpand
        {
            get
            {
                return isexpand;
            }
            set
            {
                if (isexpand != value)
                {
                    isexpand = value;
                    OnPropertyChanged(("IsExpand"));
                }
            }
        }

        private ObservableCollection<ExpandandCollapseModel> models;


        public ObservableCollection<ExpandandCollapseModel> Models
        {
            get { return models; }
            set
            {
                models = value;
                OnPropertyChanged(("Models"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public enum State
    {
        Expand,
        Collapse,
        None
    };

    public class ExpandandCollapseModels : ObservableCollection<ExpandandCollapseModel>
    {

    }
}
