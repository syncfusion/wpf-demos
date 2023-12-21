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

namespace syncfusion.chartdemos.wpf
{
    public class MVVMBindingViewModel
    {
        public MVVMBindingViewModel()
        {
            var date = new DateTime(2018, 1, 1);
            this.RainfallDetails = new ObservableCollection<MVVMBindingModel>();

            RainfallDetails.Add(new MVVMBindingModel() { Month = date.AddMonths(0), Rainfall = 22.86 });
            RainfallDetails.Add(new MVVMBindingModel() { Month = date.AddMonths(1), Rainfall = 70.866 });
            RainfallDetails.Add(new MVVMBindingModel() { Month = date.AddMonths(2), Rainfall = 183.642 });
            RainfallDetails.Add(new MVVMBindingModel() { Month = date.AddMonths(3), Rainfall = 85.09 });
            RainfallDetails.Add(new MVVMBindingModel() { Month = date.AddMonths(4), Rainfall = 66.294 });
            RainfallDetails.Add(new MVVMBindingModel() { Month = date.AddMonths(5), Rainfall = 52.07 });
            RainfallDetails.Add(new MVVMBindingModel() { Month = date.AddMonths(6), Rainfall = 96.52 });
            RainfallDetails.Add(new MVVMBindingModel() { Month = date.AddMonths(7), Rainfall = 94.234 });
            RainfallDetails.Add(new MVVMBindingModel() { Month = date.AddMonths(8), Rainfall = 111.252 });
            RainfallDetails.Add(new MVVMBindingModel() { Month = date.AddMonths(9), Rainfall = 130.81 });
            RainfallDetails.Add(new MVVMBindingModel() { Month = date.AddMonths(10), Rainfall = 159.512 });
            RainfallDetails.Add(new MVVMBindingModel() { Month = date.AddMonths(11), Rainfall = 91.694 });
        }

        public ObservableCollection<MVVMBindingModel> RainfallDetails { get; set; }
    }
}
