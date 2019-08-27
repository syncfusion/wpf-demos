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
    using System.Collections.ObjectModel;

    #region ItemObject

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
                    //ColA = string.Format("A_{0}", r.Next(100)),
                    //ColB = string.Format("B_{0}", r.Next(100)),
                    //ColC = string.Format("C_{0}", r.Next(100)),
                    //ColD = string.Format("D_{0}", r.Next(100)),
                    //ColE = string.Format("E_{0}", r.Next(100)),
                    //ColF = string.Format("F_{0}", r.Next(100)),
                    //ColG = string.Format("G_{0}", r.Next(100)),
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
}