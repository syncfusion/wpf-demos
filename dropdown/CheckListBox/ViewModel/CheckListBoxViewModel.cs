#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace syncfusion.dropdowndemos.wpf
{
    class CheckListBoxViewModel : NotificationObject
    {
        private ObservableCollection<Vegetable> vegetables = new ObservableCollection<Vegetable>();
        private ObservableCollection<object> checkedItems = new ObservableCollection<object>();
        private bool Group_checkbox = false;
        private bool Sort_checkbox = false;

        public bool Groupcheckbox
        {
            get
            {
                return Group_checkbox;
            }
            set
            {
                if (Group_checkbox != value)
                {
                    Group_checkbox = value;
                    RaisePropertyChanged("Groupcheckbox");
                }
            }
        }
        public bool Sortcheckbox
        {
            get
            {
                return Sort_checkbox;
            }
            set
            {
                if (Sort_checkbox != value)
                {
                    Sort_checkbox = value;
                    RaisePropertyChanged("Sortcheckbox");
                }
            }
        }


        public ObservableCollection<Vegetable> Vegetables
        {
            get
            {
                return vegetables;
            }
            set
            {
                vegetables = value;
                RaisePropertyChanged("Vegetables");
            }
        }

        public ObservableCollection<object> CheckedItems
        {
            get
            {
                return checkedItems;
            }
            set
            {
                checkedItems = value;
                RaisePropertyChanged("CheckedItems");
            }
        }


        public CheckListBoxViewModel()
        {
            Vegetables = new ObservableCollection<Vegetable>();
            PopulateItems();
            CheckedItems = new ObservableCollection<object>();
            CheckedItems.Add(Vegetables[0]);
            CheckedItems.Add(Vegetables[2]);
            CheckedItems.Add(Vegetables[4]);
            CheckedItems.Add(Vegetables[6]);
            CheckedItems.Add(Vegetables[8]);
        }

        public void PopulateItems()
        {
            Vegetables.Add(new Vegetable { Name = "Yarrow", Category = "Leafy and Salad" });
            Vegetables.Add(new Vegetable { Name = "Pumpkins", Category = "Leafy and Salad" });
            Vegetables.Add(new Vegetable { Name = "Cabbage", Category = "Leafy and Salad" });
            Vegetables.Add(new Vegetable { Name = "Spinach", Category = "Leafy and Salad" });
            Vegetables.Add(new Vegetable { Name = "Wheat Grass", Category = "Leafy and Salad" });
            Vegetables.Add(new Vegetable { Name = "Horse gram", Category = "Beans" });
            Vegetables.Add(new Vegetable { Name = "Chickpea", Category = "Beans" });
            Vegetables.Add(new Vegetable { Name = "Green bean", Category = "Beans" });
            Vegetables.Add(new Vegetable { Name = "Garlic", Category = "Bulb and Stem" });
            Vegetables.Add(new Vegetable { Name = "Onion", Category = "Bulb and Stem" });
            Vegetables.Add(new Vegetable { Name = "Nopal", Category = "Bulb and Stem" });
        }
    }


    
}
