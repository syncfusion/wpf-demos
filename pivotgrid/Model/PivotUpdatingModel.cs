#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace PivotUpdating.Model
{
    using System;
    using System.ComponentModel;
    using System.Collections.ObjectModel;

    public class PivotUpdatingModel : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public static int count = 2000;
        private static ProductSalesCollection singleListDataSource;

        private string product = "";

        private string date = "";

        private string country = "";

        private string state = "";

        private int quantity;

        private double amount;

        private int extra;

        private DateTime date2;

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;
        public string Product
        {
            get
            {
                return this.product;
            }
            set
            {
                if (this.product != value)
                {
                    this.OnPropertyChanging("Product");
                    this.product = value;
                    this.OnPropertyChanged("Product");
                }
            }
        }

        public string Date
        {
            get
            {
                return this.date;
            }
            set
            {
                if (this.date != value)
                {
                    this.OnPropertyChanging("Date");
                    this.date = value;
                    this.OnPropertyChanged("Date");
                }
            }
        }

        public string Country
        {
            get
            {
                return this.country;
            }
            set
            {
                if (this.country != value)
                {
                    this.OnPropertyChanging("Country");
                    this.country = value;
                    this.OnPropertyChanged("Country");
                }
            }
        }

        public string State
        {
            get
            {
                return this.state;
            }
            set
            {
                if (this.state != value)
                {
                    this.OnPropertyChanging("State");
                    this.state = value;
                    this.OnPropertyChanged("State");
                }
            }
        }

        public int Quantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                if (this.quantity != value)
                {
                    this.OnPropertyChanging("Quantity");
                    this.quantity = value;
                    this.OnPropertyChanged("Quantity");
                }
            }
        }

        public double Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                if (this.amount != value)
                {
                    this.OnPropertyChanging("Amount");
                    this.amount = value;
                    this.OnPropertyChanged("Amount");
                }
            }
        }

        public int Extra
        {
            get
            {
                return this.extra;
            }
            set
            {
                if (this.extra != value)
                {
                    this.OnPropertyChanging("Extra");
                    this.extra = value;
                    this.OnPropertyChanged("Extra");
                }
            }
        }

        public DateTime Date2
        {
            get
            {
                return this.date2;
            }
            set
            {
                if (this.date2 != value)
                {
                    this.OnPropertyChanging("Date2");
                    this.date2 = value;
                    this.OnPropertyChanged("Date2");
                }
            }
        }


        public static ProductSalesCollection GetSalesData()
        {
            if (singleListDataSource != null)
                return singleListDataSource;

            // Geography
            string[] countries = { "Australia", "Canada", "France", "Germany", "United Kingdom", "United States" };
            string[] ausStates = { "New South Wales", "Queensland", "South Australia", "Tasmania", "Victoria" };
            string[] canadaStates = { "Alberta", "British Columbia", "Brunswick", "Manitoba", "Ontario", "Quebec" };
            string[] franceStates = { "Charente-Maritime", "Essonne", "Garonne (Haute)", "Gers", };
            string[] germanyStates = { "Bayern", "Brandenburg", "Hamburg", "Hessen", "Nordrhein-Westfalen", "Saarland" };
            string[] ukStates = { "England" };
            string[] ussStates = { "New York", "North Carolina", "Alabama", "California", "Colorado", "New Mexico", "South Carolina" };

            // Time
            string[] dates = { "FY 2005", "FY 2006", "FY 2008", "FY 2009" };
            DateTime date0 = new DateTime(2005, 1, 1);
            // Products
            string[] products = { "Bike", "Car", "Truck", "Scooters" };
            products = new[] { "Bike", "Car" };
            Random r = new Random(123345345);

            int numberOfRecords = count;
            ProductSalesCollection listOfProductSales = new ProductSalesCollection();
            for (int i = 0; i < numberOfRecords; i++)
            {
                PivotUpdatingModel sales = new PivotUpdatingModel();
                sales.Country = countries[r.Next(1, countries.GetLength(0))];
                sales.Quantity = r.Next(1, 12);
                // 1 percent discount for 1 quantity
                double discount = (30000 * sales.Quantity) * (double.Parse(sales.Quantity.ToString()) / 100);
                sales.Amount = (30000 * sales.Quantity) - discount;
                sales.Date = dates[r.Next(r.Next(dates.GetLength(0) + 1))];
                sales.Product = products[r.Next(r.Next(products.GetLength(0) + 1))];
                sales.Extra = i % 2;
                sales.Date2 = date0.AddDays(r.Next(1500));
                switch (sales.Country)
                {
                    case "Australia":
                        {
                            sales.State = ausStates[r.Next(ausStates.GetLength(0))];
                            break;
                        }
                    case "Canada":
                        {
                            sales.State = canadaStates[r.Next(canadaStates.GetLength(0))];
                            break;
                        }
                    case "France":
                        {
                            sales.State = franceStates[r.Next(franceStates.GetLength(0))];
                            break;
                        }
                    case "Germany":
                        {
                            sales.State = germanyStates[r.Next(germanyStates.GetLength(0))];
                            break;
                        }
                    case "United Kingdom":
                        {
                            sales.State = ukStates[r.Next(ukStates.GetLength(0))];
                            break;
                        }
                    case "United States":
                        {
                            sales.State = ussStates[r.Next(ussStates.GetLength(0))];
                            break;
                        }
                }
                listOfProductSales.Add(sales);
            }
            singleListDataSource = listOfProductSales;
            return listOfProductSales;
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}", this.Country, this.State, this.Product);
        }

        #region INotifyPropertyChanged Members

        protected virtual void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        #region INotifyPropertyChanging Members

        protected virtual void OnPropertyChanging(string name)
        {
            if (this.PropertyChanging != null)
            {
                this.PropertyChanging(this, new PropertyChangingEventArgs(name));
            }
        }
        #endregion

        public class ProductSalesCollection : ObservableCollection<PivotUpdatingModel>
        {
        }
    }
}