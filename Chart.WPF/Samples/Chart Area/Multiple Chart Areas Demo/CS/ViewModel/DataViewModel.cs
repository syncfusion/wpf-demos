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

namespace MultipleChartArea
{
    public class DataViewModel
    {
        public DataViewModel()
        {
            this.StockExchange = new ObservableCollection<DataModel>();
            StockExchange.Add(new DataModel() { Quaterly = "Qua1", Price = 6, Stock = 4, Volume = 5 });
            StockExchange.Add(new DataModel() { Quaterly = "Qua2", Price = 10, Stock = 10, Volume = 4 });
            StockExchange.Add(new DataModel() { Quaterly = "Qua3", Price = 6, Stock = 2, Volume = 5 });
            StockExchange.Add(new DataModel() { Quaterly = "Qua4", Price = 1, Stock = 8, Volume = 2 });
            StockExchange.Add(new DataModel() { Quaterly = "Qua5", Price = 5, Stock = 6, Volume = 4 });
            StockExchange.Add(new DataModel() { Quaterly = "Qua6", Price = 3, Stock = 8, Volume = 1 });


        }

        public ObservableCollection<DataModel> StockExchange { get; set; }
    }
}
