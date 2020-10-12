#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
using syncfusion.demoscommon.wpf;

namespace syncfusion.datagriddemos.wpf
{
    public class SalesInfoViewModel : NotificationObject
    {
        public SalesInfoViewModel()
        {
            _SalesDetails = GetSalesInfo();
        }
        internal ObservableCollection<SalesByDate> _SalesDetails = null;

        public ObservableCollection<SalesByDate> YearlySalesDetails
        {
            get
            {
                return _SalesDetails;
            }
        }

        #region Public Members

        private double _Average;
        private int _Count;
        private int _NumCount;
        private double _Min;
        private double _Max;
        private double _Sum;

        /// <summary>
        /// Gets or sets the Average value of the cells.
        /// </summary>
        /// <value>The Average Value.</value>
        public double Average
        {
            get { return _Average; }
            set { _Average = value; RaisePropertyChanged("Average"); }
        }

        /// <summary>
        /// Gets or sets the Count of the cells.
        /// </summary>
        /// <value>The Count.</value>
        public int Count
        {
            get { return _Count; }
            set { _Count = value; RaisePropertyChanged("Count"); }
        }

        /// <summary>
        /// Gets or sets the Numerical Count of the cells.
        /// </summary>
        /// <value>The Numerical Count.</value>
        public int NumCount
        {
            get { return _NumCount; }
            set { _NumCount = value; RaisePropertyChanged("NumCount"); }
        }

        /// <summary>
        /// Gets or sets the Minimum value of the cells.
        /// </summary>
        /// <value>The Minimum Value.</value>
        public double Min
        {
            get { return _Min; }
            set { _Min = value; RaisePropertyChanged("Min"); }
        }

        /// <summary>
        /// Gets or sets the Maximum value of the cells.
        /// </summary>
        /// <value>The Maximum Value.</value>
        public double Max
        {
            get { return _Max; }
            set { _Max = value; RaisePropertyChanged("Max"); }
        }

        /// <summary>
        /// Gets or sets the Sum of the cells.
        /// </summary>
        /// <value>The Sum.</value>
        public double Sum
        {
            get { return _Sum; }
            set { _Sum = value; RaisePropertyChanged("Sum"); }
        }

        #endregion

        /// <summary>
        /// Gets the supplier info.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<SalesByDate> GetSalesInfo()
        {
            var sales = new ObservableCollection<SalesByDate>();
            int i = 0;
            var r = new Random();
            while (i < 60)
            {
                var salesByYear = new SalesByDate()
                {
                    Name = productName[r.Next(0, 45)],
                    QS1 = quartarSale[r.Next(0, 35)],
                    QS2 = quartarSale[r.Next(0, 35)],
                    QS3 = quartarSale[r.Next(0, 35)],
                    QS4 = quartarSale[r.Next(0, 35)],
                    QS5 = quartarSale[r.Next(0, 35)],
                    QS6 = quartarSale[r.Next(0, 35)],
                    Year = r.Next(2000, 2015),
                };
                salesByYear.Total = salesByYear.QS1 + salesByYear.QS2 + salesByYear.QS3 + salesByYear.QS4 + salesByYear.QS5 + salesByYear.QS6;
                sales.Add(salesByYear);
                i++;
            }

            return sales;
        }

        internal string[] productName = new string[]
            {
             "S-100 Helmet, R",
             "S-100 Helmet, B",
             "AWC Logo Cap",
             "Long-Sleeve Logo Jersy, XL",
             "LL Road Frame - Red, 62",
             "LL Road Frame - Black, 58",
             "LL Road Frame - Red, 48",
             "LL Road Frame - Red, 52",
             "LL Road Frame - Red, 60",
             "ML Road Frame - Red, 48",
             "ML Road Frame - Red, 48",
             "LL Road Frame - Red, 52",
             "LL Road Frame - Red, 44",
             "HL Mountain Frame - Silver, 42",
             "HL Mountain Frame - Silver, 46",
             "HL Mountain Frame - Black, 42",
             "Road-150 Red, 62",
             "Road-150 Red, 44",
             "Road-450 Red, 60",
             "Road-650 Red, 58",
             "Road-450 Red, 58",
             "Road-650 Red, 60",
             "Mountain-100 Silver, 38",
             "Mountain-100 Silver, 42",
             "Mountain-100 Silver, 44",
             "Mountain-200 Silver, 38",
             "Mountain-200 Silver, 46",
             "Mountain-200 Black, 38",
             "Mountain-200 Black, 42",
             "Road-250 Red, 48",
             "Road-250 Black, 44",
             "Road-550-W Yellow, 40",
             "Road-550-W Yellow, 42",
             "ML Mountain Handlebars",
             "HL Mountain Handlebars",
             "LL Road Handlebars",
             "ML Mountain Frame - Black, 38",
             "LL Mountain Front Wheel",
             "ML Mountain Front Wheel",
             "HL Mountain Front Wheel",
             "ML Road Frame-W - Yellow, 38",
             "LL Road Rear Wheel",
             "HL Road Rear Wheel",
             "ML Mountain Frame-Black, 44",
             "S-100 Helmet, R",
             "S-100 Helmet, Bk",
             "Mountain Bike Socks, M",
             "AWC Logo Cap"
            };

        internal double[] quartarSale = new double[]
        {
            989530.36,210083.1,589572,981735.52,109872,296735.52,998644.5,689072.05,370358.52,1780213.77,157057.07,588110.35,66959747,757518.76,0,917557.25,1181566.16,523566.19,253299.35,945435.29,146823.02,157574.67,387865.35,108462.26,1356048.07,150981.04,487571.18,912477.04,145789.45,
            853223.66,3225657.66,988256.45,716788.57,923558.01,390228.07,933694.96,511673.03,195638.07,613856,532289.85
            
        };
    }
}
