#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Shared;

namespace UnBoundRowDemo
{
    public class SalesInfoViewModel : NotificationObject
    {
        public SalesInfoViewModel()
        {
            _SalesDetails = GetSalesInfo();
        }

        private ObservableCollection<SalesByYear> _SalesDetails = null;

        public ObservableCollection<SalesByYear> YearlySalesDetails
        {
            get { return _SalesDetails; }

        }      

        /// <summary>
        /// Gets the supplier info.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<SalesByYear> GetSalesInfo()
        {
            if (!LayoutControl.IsInDesignMode)
            {                
                string connectionString = string.Format(@"Data Source = {0}",
                                                        LayoutControl.FindFile("AdventureWorksExt.sdf"));
                var sales = new ObservableCollection<SalesByYear>();
                using (var c = new SqlCeConnection(connectionString))
                {
                    c.Open();
                    using (var com = new SqlCeCommand("SELECT *  FROM Sales_QuarterSalesProductView", c))
                    {
                        var reader = com.ExecuteReader();                        
                        int i = 0;
                        var r = new Random();
                        while (reader.Read() && i < 13)
                        {
                            var salesByYear=new SalesByYear()
                                {
                                    Name = reader["Name"].ToString(),
                                    QS1 = r.Next(10000, 100000) * 0.01,
                                    QS2 = r.Next(10000, 100000) * 0.01,
                                    QS3 = r.Next(10000, 100000) * 0.01,
                                    QS4 = r.Next(10000, 100000) * 0.01,
                                    QS5 = r.Next(10000, 100000) * 0.01,
                                    QS6 = r.Next(10000, 100000) * 0.01,
                                    Year = Int32.Parse(reader["Year"].ToString()),                                    
                                };
                            salesByYear.Total = salesByYear.QS1 + salesByYear.QS2 + salesByYear.QS3 + salesByYear.QS4 + salesByYear.QS5 + salesByYear.QS6;
                            sales.Add(salesByYear);
                            i++;
                        }
                    }
                    c.Close();
                }
                return sales;
            }
            return null;
        }
    }
}
