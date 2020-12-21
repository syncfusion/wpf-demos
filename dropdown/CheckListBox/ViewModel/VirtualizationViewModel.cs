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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.dropdowndemos.wpf
{
    class VirtualizationViewModel
    {
        private ObservableCollection<Model> collection = new ObservableCollection<Model>();

        public ObservableCollection<Model> Collection
        {
            get
            {
                return collection;
            }
            set
            {
                collection = value;
            }
        }
        public VirtualizationViewModel()
        {
            Collection = new ObservableCollection<Model>();
            for (int i = 0; i < 10000; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Model myitem = new Model() { Name = "Module " + i.ToString(), GroupName = "Group" + j.ToString() };
                    Collection.Add(myitem);
                }
            }
        }
    }
}
