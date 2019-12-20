#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyPointSupportDemo
{
    public class ViewModel : INotifyPropertyChanged
    {
        public List<Model> Data { get; set; }

        private object emptyPointInteriorItem;

        public object EmptyPointInteriorItem
        {
            get
            {
                return emptyPointInteriorItem;
            }

            set
            {
                emptyPointInteriorItem = value;
                OnPropertyChanged("EmptyPointInteriorItem");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Array EmptyPointStyles
        {
            get
            {
                return Enum.GetValues(typeof(EmptyPointStyle));
            }
        }

        public Array EmptyPointValues
        {
            get
            {
                return Enum.GetValues(typeof(EmptyPointValue));
            }
        }

        public ViewModel()
        {
            Data = new List<Model>();
            Data.Add(new Model("1984", double.NaN));
            Data.Add(new Model("1985", 2));
            Data.Add(new Model("1986", 1));
            Data.Add(new Model("1987", null));
            Data.Add(new Model("1988", 3));
            Data.Add(new Model("1989", double.NaN));
            Data.Add(new Model("1990", 1));
            Data.Add(new Model("1991", null));
            Data.Add(new Model("1992", 1));
            Data.Add(new Model("1993", 4));

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
