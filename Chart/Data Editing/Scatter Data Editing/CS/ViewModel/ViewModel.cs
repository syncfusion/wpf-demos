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
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScatterDataEditing
{
    public class ViewModel
    {
        public Array DragDirectionArray
        {
            get
            {
                return Enum.GetValues(typeof(DragType));
            }
        }

        public ViewModel()
        {
            var date = new DateTime(2015, 1, 1);

            Data1 = new ObservableCollection<Model>();

            Data1.Add(new Model(date.AddMonths(1), 698));
            Data1.Add(new Model(date.AddMonths(2), 903));
            Data1.Add(new Model(date.AddMonths(3), 807));
            Data1.Add(new Model(date.AddMonths(4), 1058));
            Data1.Add(new Model(date.AddMonths(5), 954));

            Data2 = new ObservableCollection<Model>();

            Data2.Add(new Model(date.AddMonths(1), 948));
            Data2.Add(new Model(date.AddMonths(2), 1203));
            Data2.Add(new Model(date.AddMonths(3), 1107));
            Data2.Add(new Model(date.AddMonths(4), 1408));
            Data2.Add(new Model(date.AddMonths(5), 1154));
        }

        public ObservableCollection<Model> Data1 { get; set; }
        public ObservableCollection<Model> Data2 { get; set; }
    }
}
