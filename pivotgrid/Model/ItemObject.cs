#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.pivotgriddemos.wpf
{
    using System;
    using System.Collections.ObjectModel;

    #region ItemObjects

    public class ItemObjects
    {
        private static Random r = new Random(1123);

        public static ObservableCollection<ItemObject> GetList()
        {
            ObservableCollection<ItemObject> list = new ObservableCollection<ItemObject>();
            DateTime date0 = DateTime.Now;
            DateTime date1 = DateTime.Now;
            int k;
            int clientCount = 245;
            int campaignCount = 5;
            int yearCount = 1;
            int colorCount = 5;
            int shapeCount = 5;
            for (int i = 0; i < 30000; i++)
            {
                list.Add(new ItemObject()
                {
                    Id = i,
                    Client = string.Format("cli_{0}", k = r.Next(clientCount)),
                    // Campaign = string.Format("cam_{0}", r.Next(campaignCount)),
                    Campaign = string.Format("cam_{0}", k + r.Next(campaignCount)),
                    Date = date1 = new DateTime(date0.Year - r.Next(yearCount), r.Next(12) + 1, 1),
                    Date1 = date1,
                    Color = string.Format("col_{0}", r.Next(colorCount)),
                    Shape = string.Format("sha_{0}", r.Next(shapeCount)),
                    ColH = string.Format("H_{0}", r.Next(100)),
                    ColI = string.Format("I_{0}", r.Next(100)),
                    ColJ = string.Format("J_{0}", r.Next(100)),
                    Price = (int)(100000 * r.NextDouble()) / 100,
                    Spend = (int)(100000 * r.NextDouble()) / 100,
                    Quantity = r.Next(1000) + 100
                });
            }
            return list;
        }

        public static ObservableCollection<ItemObject> GetList(int count, int clientCount, int campaignCount, int yearCount, int colorCount, int shapeCount)
        {
            int Hs = 5;
            ObservableCollection<ItemObject> list = new ObservableCollection<ItemObject>();

            for (int i = 0; i < count; i++)
            {
                list.Add(new ItemObject()
                {
                    Id = i,
                    Client = string.Format("cli_{0}", r.Next(clientCount)),
                    Campaign = string.Format("cam_{0}", r.Next(campaignCount)),
                    Color = string.Format("col_{0}", r.Next(colorCount)),
                    Shape = string.Format("sha_{0}", r.Next(shapeCount)),
                   
                    Date = DateTime.Now.Date.AddDays(-r.Next(600)),
                    ColH = string.Format("H_{0}", r.Next(Hs)),
                    ColI = string.Format("I_{0}", r.Next(Hs)),
                    ColJ = string.Format("J_{0}", r.Next(Hs)),
                    Price = (int)(100000 * r.NextDouble()) / 100,
                    Spend = (int)(100000 * r.NextDouble()) / 100,
                    Quantity = r.Next(1000) + 100
                });
            }
            return list;
        }
    }

    #endregion

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
}