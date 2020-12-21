#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.datagriddemos.wpf
{
    public class CustomGroupingViewModel : NotificationObject
    { 
        public CustomGroupingViewModel()
        {
            this.DailySalesDetails = GetSalesDetailsByDay(60);
        }
        private ObservableCollection<SalesByDate> _DailySalesDetails = new ObservableCollection<SalesByDate>();

        public ObservableCollection<SalesByDate> DailySalesDetails
        {
            get
            {
                return _DailySalesDetails;
            }
            set
            {
                _DailySalesDetails = value;
                RaisePropertyChanged("DailySalesDetails");
            }

        }


        private readonly List<string> _salesParsonNames = new List<string>()
            {
                "Gary Drury",
                "Maciej Dusza",
                "Shelley Dyck",
                "Linda Ecoffey",
                "Carla Eldridge",
                "Carol Elliott",
                "Shannon Elliott",
                "Jauna Elson",
                "Michael Emanuel",
                "Terry Eminhizer",
                "John Emory",
                "Gail Erickson",
                "Mark Erickson",
                "Martha Espinoza",
                "Julie Estes",
                "Janeth Esteves",
                "Twanna Evans"
            };

        public ObservableCollection<SalesByDate> GetSalesDetailsByDay(int days)
        {
            var collection = new ObservableCollection<SalesByDate>();
            var r = new Random();
            for (var i = 0; i < days; i++)
            {
                var dt = DateTime.Now;
                foreach (var person in _salesParsonNames)
                {
                    if (r.Next(0, 3) == 0) continue;
                    var s = new SalesByDate
                    {
                        Name = person,
                        QS1 = r.Next(100000, 1000000) * 0.01,
                        QS2 = r.Next(100000, 1000000) * 0.01,
                        QS3 = r.Next(100000, 1000000) * 0.01,
                        QS4 = r.Next(100000, 1000000) * 0.01,
                    };
                    s.Total = s.QS1 + s.QS2 + s.QS3 + s.QS4;
                    s.Date = dt.AddDays(-1 * i);
                    collection.Add(s);
                }
            }
            return collection;
        }
    }
}
