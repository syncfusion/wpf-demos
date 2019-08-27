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
using SummariesDemo;
using Syncfusion.Windows.Controls.Grid;

namespace SummariesDemo
{
    public class SalesInfoViewModel
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
                        while (reader.Read() && i < 30)
                        {
                            sales.Add(new SalesByYear()
                                {
                                    Name = reader["Name"].ToString(),
                                    QS1 = reader["QS1"].ToString() != "" ? double.Parse(reader["QS1"].ToString()) : i,
                                    QS2 = reader["QS2"].ToString() != "" ? double.Parse(reader["QS2"].ToString()) : i,
                                    QS3 = reader["QS3"].ToString() != "" ? double.Parse(reader["QS3"].ToString()) : i,
                                    QS4 = reader["QS4"].ToString() != "" ? double.Parse(reader["QS4"].ToString()) : i,
                                    Total = double.Parse(reader["Total"].ToString()),
                                    Year = Int32.Parse(reader["Year"].ToString())

                                });
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
