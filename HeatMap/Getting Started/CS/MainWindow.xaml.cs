#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Getting_Started
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PopulateData();
            this.DataContext = productList;
        }

        private ObservableCollection<ProductInfoModel> productList = new ObservableCollection<ProductInfoModel>();

        private void PopulateData()
        {
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                ProductInfoModel productInfo = new ProductInfoModel();
                productInfo.ProductName = productName[i];
                productInfo.Y2007 = r.Next(0, 51);
                productInfo.Y2008 = r.Next(0, 51);
                productInfo.Y2009 = r.Next(0, 51);
                productInfo.Y2010 = r.Next(0, 51);
                productInfo.Y2011 = r.Next(0, 51);
                productInfo.Y2012 = r.Next(0, 51);
                productInfo.Y2013 = r.Next(0, 51);
                productInfo.Y2014 = r.Next(0, 51);
                productInfo.Y2015 = r.Next(0, 51);
                productInfo.Y2016 = r.Next(0, 51);
                this.productList.Add(productInfo);
            }
        }

        string[] productName = new string[]
        {
            "Alice Mutton",
            "Boston Crab Meat",
            "Raclette Courdavault",
            "Gorgonzola Telino",
            "Chartreuse verte",
            "Fløtemysost",
            "Carnarvon Tigers",
            "Vegie-spread",
            "Tarte au sucre",
            "Konbu",
            "Valkoinen suklaa",
            "Perth Pasties",
            "Vegie-spread",
            "Tofu",
        };
    }
}
