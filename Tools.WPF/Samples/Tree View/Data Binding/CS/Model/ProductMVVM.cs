using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Syncfusion.Windows.Shared;

namespace TreeViewBindingDemo
{
    public class ProductMVVM
    {
        static Random rd = new Random();
        string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        public ProductMVVM()
        {
            Details = new ObservableCollection<Stock>();
            for (int i = 101; i <= 111; i++)
            {
                Details.Add(new Stock() { StockID = months[i - 100], StockName = "Stock" + i.ToString(), Price = rd.Next(20, 100), Open = rd.Next(10, 50) });
            }
        }

        public ObservableCollection<Stock> Details { get; set; }

        public string Name { get; set; }

        public string ImageSource { get; set; }

        public string Description { get; set; }

        public string Des_ImageSource { get; set; }

        public ObservableCollection<ProductMVVM> SubProducts { get; set; }
    }          
}
