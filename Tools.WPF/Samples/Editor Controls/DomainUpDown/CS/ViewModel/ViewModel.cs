using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DomainUpDownDemo
{
    class ViewModel : NotificationObject
    {
        private ObservableCollection<Technology> technology = new ObservableCollection<Technology>();
        private ObservableCollection<Product> product = new ObservableCollection<Product>();
        
        public ObservableCollection<Technology> Technology
        {
            get { return technology; }
            set { technology = value; RaisePropertyChanged("Technology"); }
        }

        public ObservableCollection<Product> Product
        {
            get { return product; }
            set { product = value; RaisePropertyChanged("Product"); }
        }
        public ViewModel()
        {
            Technology tech1 = new Technology() { Name = "Windows Forms" };
            Technology tech2 = new Technology() { Name = "WPF" };
            Technology tech3 = new Technology() { Name = "Silverlight" };
            Technology tech4 = new Technology() { Name = "ASP .NET" };
            Technology tech5 = new Technology() { Name = "ASP .NET MVC" };

            Product product1 = new Product() { ProductName = "Essential Tools", ProductIcon = "Images/Tools.png" };
            Product product2 = new Product() { ProductName = "Essential Chart", ProductIcon = "Images/Chart.png" };
            Product product3 = new Product() { ProductName = "Essential Grid", ProductIcon = "Images/Grid.png" };
            Product product4 = new Product() { ProductName = "Essential Report", ProductIcon = "Images/Report.png" };
            Product product5 = new Product() { ProductName = "Essential Diagram", ProductIcon = "Images/Diagram.png" };

            technology.Add(tech1);
            technology.Add(tech2);
            technology.Add(tech3);
            technology.Add(tech4);
            technology.Add(tech5);

            product.Add(product1);
            product.Add(product2);
            product.Add(product3);
            product.Add(product4);
            product.Add(product5);        
        }

    }
    public class Technology
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }

    public class Product
    {
        private string productname;
        private string producticon;

        public string ProductName
        {
            get { return productname; }
            set { productname = value; }
        }
        public string ProductIcon
        {
            get { return producticon; }
            set { producticon = value; }
        }
    }
}
