#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace OnDemandLoading
{
    using System;

    public class ItemObject
    {
        string client = string.Empty;
        string campaign = string.Empty;
        DateTime date = DateTime.Now;
        DateTime date1 = DateTime.Now;
        string color = string.Empty;
        string shape = string.Empty;
        string colH = string.Empty;
        string colI = string.Empty;
        string colJ = string.Empty;
        double price;
        double spend;
        int quantity;
        int id;

        public string Client
        {
            get { return this.client; }
            set { this.client = value; this.OnPropertyChanged("Client"); }
        }

        public string Campaign
        {
            get { return this.campaign; }
            set { this.campaign = value; this.OnPropertyChanged("Campaign"); }
        }

        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; this.OnPropertyChanged("Date"); }
        }

        public DateTime Date1
        {
            get { return this.date1; }
            set { this.date1 = value; this.OnPropertyChanged("Date1"); }
        }

        public string Color
        {
            get { return this.color; }
            set { this.color = value; this.OnPropertyChanged("Color"); }
        }

        public string Shape
        {
            get { return this.shape; }
            set { this.shape = value; this.OnPropertyChanged("Shape"); }
        }

        public string ColH
        {
            get { return this.colH; }
            set { this.colH = value; this.OnPropertyChanged("ColH"); }
        }

        public string ColI
        {
            get { return this.colI; }
            set { this.colI = value; this.OnPropertyChanged("ColI"); }
        }

        public string ColJ
        {
            get { return this.colJ; }
            set { this.colJ = value; this.OnPropertyChanged("ColJ"); }
        }

        public double Price
        {
            get { return this.price; }
            set { this.price = value; this.OnPropertyChanged("Price"); }
        }

        public double Spend
        {
            get { return this.spend; }
            set { this.spend = value; this.OnPropertyChanged("Spend"); }
        }

        public int Quantity
        {
            get { return this.quantity; }
            set { this.quantity = value; this.OnPropertyChanged("Quantity"); }
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; this.OnPropertyChanged("Id"); }
        }

        protected virtual void OnPropertyChanged(string name)
        {
        }
    }

    class ProductModel
    {
         /// <summary>
        /// Gets or Sets the Product
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// Gets or Sets the Date
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Gets or Sets the Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or Sets the State
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or Sets the Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or Sets the Amount
        /// </summary>
        public double Amount { get; set; }

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}", this.Country, this.State, this.Product);
        }
    }
}