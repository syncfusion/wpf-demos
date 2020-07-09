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

namespace AreaChart
{
    public class ViewModel
    {
        public ViewModel()
        {
            this.Fruits = new ObservableCollection<Model>();

            Fruits.Add(new Model() { FruitName = "Apple", People = 27 });
            Fruits.Add(new Model() { FruitName = "Orange", People = 33 });
            Fruits.Add(new Model() { FruitName = "Grapes", People = 15 });
            Fruits.Add(new Model() { FruitName = "Banana", People = 5 });
            Fruits.Add(new Model() { FruitName = "Blueberry", People = 20 });
        }

        public ObservableCollection<Model> Fruits { get; set; }
    }
}
