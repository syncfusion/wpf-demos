#region Copyright Syncfusion Inc. 2001 - 2011
// Copyright Syncfusion Inc. 2001 - 2011. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Reflection;

namespace CompanySales
{
    public class AdventureWorks
    {
        public string ProdCat { get; set; }
        public string SubCat { get; set; }
        public string OrderYear { get; set; }
        public string OrderQtr { get; set; }
        public double Sales { get; set; }
        public IList GetData()
        {
            List<AdventureWorks> AdventureWorksCollection = new List<AdventureWorks>();
            AdventureWorks AdventureWork = null;
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Accessories",
                SubCat = "Helmets",
                OrderYear = "2002",
                OrderQtr = "Q1",
                Sales = 4945.6925
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Road Frames",
                OrderYear = "2002",
                OrderQtr = "Q3",
                Sales = 957715.1942
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Forks",
                OrderYear = "2002",
                OrderQtr = "Q4",
                Sales = 23543.1060
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Bikes",
                SubCat = "Road Bikes",
                OrderYear = "2002",
                OrderQtr = "Q1",
                Sales = 3171787.6112
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Accessories",
                SubCat = "Helmets",
                OrderYear = "2002",
                OrderQtr = "Q3",
                Sales = 33853.1033
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Wheels",
                OrderYear = "2002",
                OrderQtr = "Q4",
                Sales = 163921.8870
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Bikes",
                SubCat = "Road Bikes",
                OrderYear = "2003",
                OrderQtr = "Q2",
                Sales = 4119658.6506
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Clothing",
                SubCat = "Socks",
                OrderYear = "2003",
                OrderQtr = "Q3",
                Sales = 6968.6884
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Bikes",
                SubCat = "Road Bikes",
                OrderYear = "2003",
                OrderQtr = "Q4",
                Sales = 3734891.6389
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Mountain Frames",
                OrderYear = "2002",
                OrderQtr = "Q3",
                Sales = 608352.8754
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Handlebars",
                OrderYear = "2002",
                OrderQtr = "Q4",
                Sales = 18309.4452
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Road Frames",
                OrderYear = "2003",
                OrderQtr = "Q4",
                Sales = 286591.8208
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Accessories",
                SubCat = "Tires and Tubes",
                OrderYear = "2003",
                OrderQtr = "Q3",
                Sales = 41940.3364
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Mountain Frames",
                OrderYear = "2003",
                OrderQtr = "Q2",
                Sales = 440260.9831
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Road Frames",
                OrderYear = "2003",
                OrderQtr = "Q2",
                Sales = 457688.8401
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Clothing",
                SubCat = "Vests",
                OrderYear = "2003",
                OrderQtr = "Q4",
                Sales = 66882.6450
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Accessories",
                SubCat = "Pumps",
                OrderYear = "2002",
                OrderQtr = "Q4",
                Sales = 3226.3860
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Clothing",
                SubCat = "Tights",
                OrderYear = "2003",
                OrderQtr = "Q2",
                Sales = 51600.6190
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Chains",
                OrderYear = "2003",
                OrderQtr = "Q3",
                Sales = 3476.0176
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Handlebars",
                OrderYear = "2003",
                OrderQtr = "Q2",
                Sales = 17194.2146
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Mountain Frames",
                OrderYear = "2003",
                OrderQtr = "Q4",
                Sales = 565229.8810
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Clothing",
                SubCat = "Tights",
                OrderYear = "2003",
                OrderQtr = "Q4",
                Sales = 243.7175
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Road Frames",
                OrderYear = "2002",
                OrderQtr = "Q2",
                Sales = 155311.4063
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Mountain Frames",
                OrderYear = "2002",
                OrderQtr = "Q2",
                Sales = 220935.1648
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Accessories",
                SubCat = "Locks",
                OrderYear = "2003",
                OrderQtr = "Q4",
                Sales = 15.0000
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Mountain Frames",
                OrderYear = "2003",
                OrderQtr = "Q3",
                Sales = 827287.5234
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Accessories",
                SubCat = "Bike Racks",
                OrderYear = "2003",
                OrderQtr = "Q3",
                Sales = 75920.4000
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Bottom Brackets",
                OrderYear = "2003",
                OrderQtr = "Q3",
                Sales = 17453.6400
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Bikes",
                SubCat = "Touring Bikes",
                OrderYear = "2003",
                OrderQtr = "Q3",
                Sales = 3298006.2858
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Brakes",
                OrderYear = "2003",
                OrderQtr = "Q4",
                Sales = 18571.4700
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Clothing",
                SubCat = "Tights",
                OrderYear = "2002",
                OrderQtr = "Q4",
                Sales = 56782.4280
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Pedals",
                OrderYear = "2003",
                OrderQtr = "Q3",
                Sales = 54185.2014
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Clothing",
                SubCat = "Jerseys",
                OrderYear = "2003",
                OrderQtr = "Q3",
                Sales = 173041.0492
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Clothing",
                SubCat = "Jerseys",
                OrderYear = "2002",
                OrderQtr = "Q2",
                Sales = 16931.2362
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Headsets",
                OrderYear = "2002",
                OrderQtr = "Q3",
                Sales = 19701.9001
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Road Frames",
                OrderYear = "2002",
                OrderQtr = "Q4",
                Sales = 458089.4246
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Clothing",
                SubCat = "Shorts",
                OrderYear = "2003",
                OrderQtr = "Q1",
                Sales = 11230.1280
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Bikes",
                SubCat = "Road Bikes",
                OrderYear = "2002",
                OrderQtr = "Q4",
                Sales = 4189621.8590
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Brakes",
                OrderYear = "2003",
                OrderQtr = "Q3",
                Sales = 26659.0800
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Wheels",
                OrderYear = "2003",
                OrderQtr = "Q4",
                Sales = 83.2981
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Clothing",
                SubCat = "Vests",
                OrderYear = "2003",
                OrderQtr = "Q3",
                Sales = 81085.6900
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Cranksets",
                OrderYear = "2003",
                OrderQtr = "Q3",
                Sales = 80244.1372
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Clothing",
                SubCat = "Socks",
                OrderYear = "2003",
                OrderQtr = "Q4",
                Sales = 6183.1422
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Wheels",
                OrderYear = "2003",
                OrderQtr = "Q2",
                Sales = 163929.9435
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Clothing",
                SubCat = "Tights",
                OrderYear = "2002",
                OrderQtr = "Q3",
                Sales = 67088.3037
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Clothing",
                SubCat = "Tights",
                OrderYear = "2003",
                OrderQtr = "Q3",
                Sales = 779.8960
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Clothing",
                SubCat = "Socks",
                OrderYear = "2002",
                OrderQtr = "Q1",
                Sales = 1273.8550
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Bikes",
                SubCat = "Road Bikes",
                OrderYear = "2002",
                OrderQtr = "Q3",
                Sales = 4930692.7825
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Clothing",
                SubCat = "Shorts",
                OrderYear = "2003",
                OrderQtr = "Q4",
                Sales = 84192.3708
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Clothing",
                SubCat = "Jerseys",
                OrderYear = "2002",
                OrderQtr = "Q3",
                Sales = 48901.7598
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Clothing",
                SubCat = "Shorts",
                OrderYear = "2002",
                OrderQtr = "Q3",
                Sales = 26207.2314
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Bikes",
                SubCat = "Road Bikes",
                OrderYear = "2002",
                OrderQtr = "Q2",
                Sales = 3478963.5378
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Clothing",
                SubCat = "Shorts",
                OrderYear = "2003",
                OrderQtr = "Q2",
                Sales = 21423.6288
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Derailleurs",
                OrderYear = "2003",
                OrderQtr = "Q3",
                Sales = 25385.2550
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Handlebars",
                OrderYear = "2003",
                OrderQtr = "Q4",
                Sales = 21675.6840
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Bottom Brackets",
                OrderYear = "2003",
                OrderQtr = "Q4",
                Sales = 13339.1820
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Clothing",
                SubCat = "Jerseys",
                OrderYear = "2003",
                OrderQtr = "Q2",
                Sales = 31334.6088
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Accessories",
                SubCat = "Helmets",
                OrderYear = "2002",
                OrderQtr = "Q2",
                Sales = 11638.8628
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Headsets",
                OrderYear = "2003",
                OrderQtr = "Q2",
                Sales = 14102.2548
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Handlebars",
                OrderYear = "2002",
                OrderQtr = "Q3",
                Sales = 35341.0863
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Bikes",
                SubCat = "Touring Bikes",
                OrderYear = "2003",
                OrderQtr = "Q4",
                Sales = 3766585.3623
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Chains",
                OrderYear = "2003",
                OrderQtr = "Q4",
                Sales = 2217.8992
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Accessories",
                SubCat = "Locks",
                OrderYear = "2003",
                OrderQtr = "Q2",
                Sales = 3939.0000
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Bikes",
                SubCat = "Road Bikes",
                OrderYear = "2003",
                OrderQtr = "Q3",
                Sales = 3844123.5588
            };
            AdventureWorksCollection.Add(AdventureWork);
            AdventureWork = new AdventureWorks()
            {
                ProdCat = "Components",
                SubCat = "Handlebars",
                OrderYear = "2003",
                OrderQtr = "Q3",
                Sales = 43624.0992
            };
            AdventureWorksCollection.Add(AdventureWork);
            /* AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Components",
                 SubCat = "Headsets",
                 OrderYear = "2002",
                 OrderQtr = "Q4",
                 Sales = "16382.0934"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Caps",
                 OrderYear = "2003",
                 OrderQtr = "Q1",
                 Sales = "1782.0812"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Accessories",
                 SubCat = "Bike Stands",
                 OrderYear = "2003",
                 OrderQtr = "Q3",
                 Sales = "6996.0000"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Bib-Shorts",
                 OrderYear = "2003",
                 OrderQtr = "Q1",
                 Sales = "21543.6060"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Socks",
                 OrderYear = "2002",
                 OrderQtr = "Q2",
                 Sales = "1899.6200"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Components",
                 SubCat = "Wheels",
                 OrderYear = "2003",
                 OrderQtr = "Q3",
                 Sales = "1677.9907"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Caps",
                 OrderYear = "2002",
                 OrderQtr = "Q1",
                 Sales = "921.2951"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Jerseys",
                 OrderYear = "2003",
                 OrderQtr = "Q1",
                 Sales = "18205.0206"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Accessories",
                 SubCat = "Bike Racks",
                 OrderYear = "2003",
                 OrderQtr = "Q4",
                 Sales = "60883.2000"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Components",
                 SubCat = "Wheels",
                 OrderYear = "2002",
                 OrderQtr = "Q3",
                 Sales = "288627.8321"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Components",
                 SubCat = "Mountain Frames",
                 OrderYear = "2002",
                 OrderQtr = "Q4",
                 Sales = "443599.2756"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Bikes",
                 SubCat = "Mountain Bikes",
                 OrderYear = "2002",
                 OrderQtr = "Q1",
                 Sales = "2497517.6260"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Shorts",
                 OrderYear = "2003",
                 OrderQtr = "Q3",
                 Sales = "97610.4518"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Jerseys",
                 OrderYear = "2002",
                 OrderQtr = "Q4",
                 Sales = "35495.3156"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Components",
                 SubCat = "Touring Frames",
                 OrderYear = "2003",
                 OrderQtr = "Q3",
                 Sales = "666977.0361"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Components",
                 SubCat = "Cranksets",
                 OrderYear = "2003",
                 OrderQtr = "Q4",
                 Sales = "44127.2820"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Accessories",
                 SubCat = "Locks",
                 OrderYear = "2002",
                 OrderQtr = "Q4",
                 Sales = "3780.0000"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Gloves",
                 OrderYear = "2003",
                 OrderQtr = "Q1",
                 Sales = "25691.7532"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Bikes",
                 SubCat = "Mountain Bikes",
                 OrderYear = "2003",
                 OrderQtr = "Q1",
                 Sales = "2517500.0531"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Gloves",
                 OrderYear = "2002",
                 OrderQtr = "Q3",
                 Sales = "52536.8767"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Gloves",
                 OrderYear = "2003",
                 OrderQtr = "Q4",
                 Sales = "23619.1700"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Gloves",
                 OrderYear = "2003",
                 OrderQtr = "Q2",
                 Sales = "41875.9919"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Jerseys",
                 OrderYear = "2002",
                 OrderQtr = "Q1",
                 Sales = "9517.3320"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Bib-Shorts",
                 OrderYear = "2002",
                 OrderQtr = "Q4",
                 Sales = "35322.8748"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Accessories",
                 SubCat = "Hydration Packs",
                 OrderYear = "2003",
                 OrderQtr = "Q3",
                 Sales = "31577.4576"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Accessories",
                 SubCat = "Cleaners",
                 OrderYear = "2003",
                 OrderQtr = "Q3",
                 Sales = "5137.4490"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Accessories",
                 SubCat = "Bottles and Cages",
                 OrderYear = "2003",
                 OrderQtr = "Q4",
                 Sales = "15968.1566"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Gloves",
                 OrderYear = "2002",
                 OrderQtr = "Q4",
                 Sales = "38360.2071"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Accessories",
                 SubCat = "Pumps",
                 OrderYear = "2003",
                 OrderQtr = "Q2",
                 Sales = "3382.3080"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Caps",
                 OrderYear = "2003",
                 OrderQtr = "Q2",
                 Sales = "2939.7072"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Caps",
                 OrderYear = "2003",
                 OrderQtr = "Q4",
                 Sales = "8518.6543"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Shorts",
                 OrderYear = "2002",
                 OrderQtr = "Q4",
                 Sales = "23176.5366"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Caps",
                 OrderYear = "2002",
                 OrderQtr = "Q2",
                 Sales = "1479.1897"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Accessories",
                 SubCat = "Cleaners",
                 OrderYear = "2003",
                 OrderQtr = "Q4",
                 Sales = "4724.3670"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Accessories",
                 SubCat = "Bottles and Cages",
                 OrderYear = "2003",
                 OrderQtr = "Q3",
                 Sales = "11854.2609"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Components",
                 SubCat = "Pedals",
                 OrderYear = "2003",
                 OrderQtr = "Q4",
                 Sales = "39900.6900"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Accessories",
                 SubCat = "Pumps",
                 OrderYear = "2003",
                 OrderQtr = "Q1",
                 Sales = "1763.1180"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Caps",
                 OrderYear = "2003",
                 OrderQtr = "Q3",
                 Sales = "8676.4288"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Accessories",
                 SubCat = "Helmets",
                 OrderYear = "2003",
                 OrderQtr = "Q1",
                 Sales = "11659.7222"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Components",
                 SubCat = "Headsets",
                 OrderYear = "2003",
                 OrderQtr = "Q1",
                 Sales = "10949.6362"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Accessories",
                 SubCat = "Fenders",
                 OrderYear = "2003",
                 OrderQtr = "Q4",
                 Sales = "11759.3000"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Caps",
                 OrderYear = "2002",
                 OrderQtr = "Q3",
                 Sales = "3990.6653"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Accessories",
                 SubCat = "Helmets",
                 OrderYear = "2003",
                 OrderQtr = "Q4",
                 Sales = "89595.0441"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Components",
                 SubCat = "Derailleurs",
                 OrderYear = "2003",
                 OrderQtr = "Q4",
                 Sales = "18974.0842"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Bikes",
                 SubCat = "Mountain Bikes",
                 OrderYear = "2003",
                 OrderQtr = "Q2",
                 Sales = "2908658.6684"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Bikes",
                 SubCat = "Mountain Bikes",
                 OrderYear = "2002",
                 OrderQtr = "Q3",
                 Sales = "3141467.2549"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Accessories",
                 SubCat = "Tires and Tubes",
                 OrderYear = "2003",
                 OrderQtr = "Q4",
                 Sales = "61948.1660"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Bib-Shorts",
                 OrderYear = "2003",
                 OrderQtr = "Q2",
                 Sales = "43457.9708"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Gloves",
                 OrderYear = "2003",
                 OrderQtr = "Q3",
                 Sales = "26944.8741"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Components",
                 SubCat = "Forks",
                 OrderYear = "2003",
                 OrderQtr = "Q2",
                 Sales = "18345.1020"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Bikes",
                 SubCat = "Mountain Bikes",
                 OrderYear = "2003",
                 OrderQtr = "Q3",
                 Sales = "3617011.7320"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Components",
                 SubCat = "Road Frames",
                 OrderYear = "2002",
                 OrderQtr = "Q1",
                 Sales = "47486.1204"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Components",
                 SubCat = "Mountain Frames",
                 OrderYear = "2002",
                 OrderQtr = "Q1",
                 Sales = "127557.6450"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Accessories",
                 SubCat = "Locks",
                 OrderYear = "2002",
                 OrderQtr = "Q3",
                 Sales = "6325.0000"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Components",
                 SubCat = "Saddles",
                 OrderYear = "2003",
                 OrderQtr = "Q4",
                 Sales = "12939.5836"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Components",
                 SubCat = "Forks",
                 OrderYear = "2003",
                 OrderQtr = "Q1",
                 Sales = "9913.9680"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Components",
                 SubCat = "Touring Frames",
                 OrderYear = "2003",
                 OrderQtr = "Q4",
                 Sales = "367783.3714"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Accessories",
                 SubCat = "Helmets",
                 OrderYear = "2002",
                 OrderQtr = "Q4",
                 Sales = "24870.7746"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Jerseys",
                 OrderYear = "2003",
                 OrderQtr = "Q4",
                 Sales = "140702.9585"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Components",
                 SubCat = "Forks",
                 OrderYear = "2002",
                 OrderQtr = "Q3",
                 Sales = "26166.7828"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Components",
                 SubCat = "Saddles",
                 OrderYear = "2003",
                 OrderQtr = "Q3",
                 Sales = "24908.2704"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Components",
                 SubCat = "Mountain Frames",
                 OrderYear = "2003",
                 OrderQtr = "Q1",
                 Sales = "236070.3535"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Components",
                 SubCat = "Road Frames",
                 OrderYear = "2003",
                 OrderQtr = "Q1",
                 Sales = "132691.6701"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Components",
                 SubCat = "Road Frames",
                 OrderYear = "2003",
                 OrderQtr = "Q3",
                 Sales = "755820.5967"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Accessories",
                 SubCat = "Hydration Packs",
                 OrderYear = "2003",
                 OrderQtr = "Q4",
                 Sales = "27109.5201"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Components",
                 SubCat = "Handlebars",
                 OrderYear = "2003",
                 OrderQtr = "Q1",
                 Sales = "6274.9870"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Caps",
                 OrderYear = "2002",
                 OrderQtr = "Q4",
                 Sales = "3075.5940"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Bikes",
                 SubCat = "Road Bikes",
                 OrderYear = "2003",
                 OrderQtr = "Q1",
                 Sales = "3584254.7760"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Accessories",
                 SubCat = "Locks",
                 OrderYear = "2003",
                 OrderQtr = "Q1",
                 Sales = "2205.0000"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Bib-Shorts",
                 OrderYear = "2003",
                 OrderQtr = "Q3",
                 Sales = "350.9610"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Bikes",
                 SubCat = "Mountain Bikes",
                 OrderYear = "2002",
                 OrderQtr = "Q4",
                 Sales = "2837646.7493"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Components",
                 SubCat = "Wheels",
                 OrderYear = "2003",
                 OrderQtr = "Q1",
                 Sales = "63185.8290"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Bikes",
                 SubCat = "Mountain Bikes",
                 OrderYear = "2002",
                 OrderQtr = "Q2",
                 Sales = "2416836.6144"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Accessories",
                 SubCat = "Helmets",
                 OrderYear = "2003",
                 OrderQtr = "Q2",
                 Sales = "25524.1452"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Bikes",
                 SubCat = "Mountain Bikes",
                 OrderYear = "2003",
                 OrderQtr = "Q4",
                 Sales = "3808655.5025"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Accessories",
                 SubCat = "Bike Stands",
                 OrderYear = "2003",
                 OrderQtr = "Q4",
                 Sales = "11925.0000"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Bib-Shorts",
                 OrderYear = "2002",
                 OrderQtr = "Q3",
                 Sales = "66859.8703"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Accessories",
                 SubCat = "Pumps",
                 OrderYear = "2002",
                 OrderQtr = "Q3",
                 Sales = "5157.0202"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Clothing",
                 SubCat = "Tights",
                 OrderYear = "2003",
                 OrderQtr = "Q1",
                 Sales = "27588.0711"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Accessories",
                 SubCat = "Helmets",
                 OrderYear = "2003",
                 OrderQtr = "Q3",
                 Sales = "81538.2467"
             };
             AdventureWorksCollection.Add(AdventureWork);
             AdventureWork = new AdventureWorks()
             {
                 ProdCat = "Accessories",
                 SubCat = "Fenders",
                 OrderYear = "2003",
                 OrderQtr = "Q3",
                 Sales = "7649.0400"
             };
             AdventureWorksCollection.Add(AdventureWork);*/
            return AdventureWorksCollection;
        }

        public DataTable GetDataTable()
        {
            DataTable dataTable = new DataTable();
            IList data = this.GetData();
            PropertyInfo[] props = data.GetType().GetProperties();
            dataTable.TableName = "Sales";

            foreach (var pro in data[0].GetType().GetProperties())
            {
                dataTable.Columns.Add(pro.Name, pro.PropertyType);
            }

            object[] values = new object[dataTable.Columns.Count];

            foreach (var item in data)
            {
                int i = 0;

                foreach (var pro in item.GetType().GetProperties())
                {
                    values[i] = pro.GetValue(item, null);
                    i++;
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }

}
