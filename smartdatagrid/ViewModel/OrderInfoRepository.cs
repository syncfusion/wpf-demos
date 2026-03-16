#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Chat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.smartdatagriddemos.wpf
{
    public class OrderInfoRepository : INotifyPropertyChanged
    {
        public ObservableCollection<OrderInfo> OrderInfoCollection { get; set; }
        private Author currentUser;
        public Author CurrentUser
        {
            get
            {
                return this.currentUser;
            }
            set
            {
                this.currentUser = value;
                RaisePropertyChanged("CurrentUser");
            }
        }
        public ObservableCollection<string> AiSuggestions { get; } = new ObservableCollection<string>
        {
            "Which orders have a payment status of Not Paid?",
            "What are the top 10 orders with the highest freight cost?",
            "Which customers have placed the most orders?",
            "What are the orders shipped to Brazil?",
            "What is the total quantity of products ordered across all orders?",
        };

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public OrderInfoRepository()
        {
            this.CurrentUser = new Author { Name = "John" };
            OrderInfoCollection = new ObservableCollection<OrderInfo>();
            GenerateOrders();
        }

        private Random random = new Random();
        private static readonly string[] Names = new[]
        {
            "Emma", "Olivia", "Charlotte", "Amelia", "Sophia",
            "William", "Isabella", "Emily", "George", "Grace",
            "Lily","Ava","Chloe","Ella","Mia","James","Sophie",
            "Isla","Henry","Lucy"
        };

        private static readonly string[] Countries = new[]
        {
            "Spain","Brazil","Switzerland","France","Germany","UK","Canada","Mexico","USA","Italy"
        };


        public string[] ElectronicsProducts = new string[]
       {
            "Keyboard", "Mouse", "Trackpad", "Stylus", "Scanner", "Webcam", "Microphone", "Monitor", "Speakers", "Headphones", "Printers", "Projectors", "External Drive", "UPS"
       };

        private static readonly string[] Cities = new[]
        {
            "Madrid","Rio","Bern","Paris","Berlin","London","Toronto","Mexico D.F.","Seattle","Rome"
        };

        private static readonly string[] PaymentStatuses = new[] { "Paid", "Not Paid" };


        private void GenerateOrders()
        {
            var rnd = new Random(42);
            int baseOrderId = 20251001;

            for (int i = 0; i < 100; i++)
            {
                int orderId = baseOrderId + i;
                var name = Names[i % Names.Length];
                var custId = $"C{100 + (i % 50):D3}";
                string productName = ElectronicsProducts[random.Next(ElectronicsProducts.Length)];
                DateTime orderDate = DateTime.Today.AddDays(-rnd.Next(1, 90));

                // Quantity realistic
                int quantity = rnd.Next(1, 20);

                // Freight based on product type
                int freight;
                if (productName == "Mouse" || productName == "Stylus" || productName == "Trackpad")
                    freight = rnd.Next(50, 150);
                else if (productName == "Keyboard" || productName == "Webcam" || productName == "Microphone")
                    freight = rnd.Next(150, 350);
                else
                    freight = rnd.Next(350, 750);

                // Country and city mapping
                var country = Countries[i % Countries.Length];
                var city = Cities[i % Cities.Length];

                // Payment status with realistic ratio
                var status = rnd.NextDouble() < 0.7 ? "Paid" : "Not Paid";

                // Rating bell curve around 3-4
                var rating = Math.Round(3 + (rnd.NextDouble() - 0.5) * 2, 1);
                rating = Math.Min(Math.Max(rating, 1.0), 5.0);

                OrderInfoCollection.Add(new OrderInfo(
                    orderId: orderId,
                    customerName: name,
                    customerId: custId,
                    productName: productName,
                    orderDate: orderDate,
                    quantity: quantity,
                    freight: freight,
                    shipCountry: country,
                    shipCity: city,
                    paymentStatus: status,
                    rating: rating,
                    isSelected: false));
            }
        }

    }
}
