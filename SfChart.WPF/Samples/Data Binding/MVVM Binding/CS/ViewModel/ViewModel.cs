#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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

namespace MVVMBinding
{
    public class ViewModel
    {
        public ViewModel()
        {
            var date = new DateTime(2018, 1, 1);
            this.SneakersDetail = new ObservableCollection<Model>();

            SneakersDetail.Add(new Model() { Month = date.AddMonths(0), Rainfall = 22.86 });
            SneakersDetail.Add(new Model() { Month = date.AddMonths(1), Rainfall = 70.866 });
            SneakersDetail.Add(new Model() { Month = date.AddMonths(2), Rainfall = 183.642 });
            SneakersDetail.Add(new Model() { Month = date.AddMonths(3), Rainfall = 85.09 });
            SneakersDetail.Add(new Model() { Month = date.AddMonths(4), Rainfall = 66.294 });
            SneakersDetail.Add(new Model() { Month = date.AddMonths(5), Rainfall = 52.07 });
            SneakersDetail.Add(new Model() { Month = date.AddMonths(6), Rainfall = 96.52 });
            SneakersDetail.Add(new Model() { Month = date.AddMonths(7), Rainfall = 94.234 });
            SneakersDetail.Add(new Model() { Month = date.AddMonths(8), Rainfall = 111.252 });
            SneakersDetail.Add(new Model() { Month = date.AddMonths(9), Rainfall = 130.81 });
            SneakersDetail.Add(new Model() { Month = date.AddMonths(10), Rainfall = 159.512 });
            SneakersDetail.Add(new Model() { Month = date.AddMonths(11), Rainfall = 91.694 });
        }

        public ObservableCollection<Model> SneakersDetail { get; set; }
    }
}
