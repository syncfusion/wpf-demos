#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace ChartSeriesMouseEvents
{
    public class SalesDetailsViewModel
    {
        public SalesDetailsViewModel()
        {
            this.MouseEventsModel=new ObservableCollection<SalesModel>();
            DateTime dt = new DateTime(2012, 5, 7);
            this.MouseEventsModel.Add(new SalesModel() { Sales1 = 40, Day = dt, Stock = 30, Price = 20 });
            this.MouseEventsModel.Add(new SalesModel() { Sales1 = 20, Day = dt.AddDays(1), Stock = 30, Price = 40 });
            this.MouseEventsModel.Add(new SalesModel() { Sales1 = 30, Day = dt.AddDays(2), Stock = 40, Price = 10 });
            this.MouseEventsModel.Add(new SalesModel() { Sales1 = 50, Day = dt.AddDays(3), Stock = 10, Price = 40 });
            this.MouseEventsModel.Add(new SalesModel() { Sales1 = 10, Day = dt.AddDays(4), Stock = 30, Price = 40 });
            this.MouseEventsModel.Add(new SalesModel() { Sales1 = 50, Day = dt.AddDays(5), Stock = 20, Price = 10 });
            this.MouseEventsModel.Add(new SalesModel() { Sales1 = 20, Day = dt.AddDays(6), Stock = 40, Price = 20 });
        }

        public ObservableCollection<SalesModel> MouseEventsModel { get; set; }
    }

    
      
}
