#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.smartdatagriddemos.wpf
{
    public partial class OrderInfo : INotifyPropertyChanged
    {
        private int _orderID;
        private string _customerID = string.Empty;
        private string _customerName = string.Empty;
        private string _productName = string.Empty;
        private DateTime _orderDate;
        private int _quantity;
        private double _freight;
        private string _shipCountry = string.Empty;
        private string _shipCity = string.Empty;
        private string _paymentStatus = string.Empty;
        private double _rating;
        private bool _isSelected;


        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
                return false;
            storage = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }

        public int OrderID
        {
            get => _orderID;
            set => SetProperty(ref _orderID, value);
        }

        public string CustomerID
        {
            get => _customerID;
            set => SetProperty(ref _customerID, value);
        }

        public string CustomerName
        {
            get => _customerName;
            set => SetProperty(ref _customerName, value);
        }

        public string ProductName
        {
            get => _productName;
            set => SetProperty(ref _productName, value);
        }

        public DateTime OrderDate
        {
            get => _orderDate;
            set => SetProperty(ref _orderDate, value);
        }

        public int Quantity
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }

        public double Freight
        {
            get => _freight;
            set => SetProperty(ref _freight, value);
        }

        public string ShipCountry
        {
            get => _shipCountry;
            set => SetProperty(ref _shipCountry, value);
        }

        public string ShipCity
        {
            get => _shipCity;
            set => SetProperty(ref _shipCity, value);
        }

        public string PaymentStatus
        {
            get => _paymentStatus;
            set => SetProperty(ref _paymentStatus, value);
        }

        public double Rating
        {
            get => _rating;
            set => SetProperty(ref _rating, value);
        }

        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }



        public OrderInfo() { }

        public OrderInfo(int orderId,
                         string customerName,
                         string customerId,
                         string productName,
                         DateTime orderDate,
                         int quantity,
                         double freight,
                         string shipCountry,
                         string shipCity,
                         string paymentStatus,
                         double rating,
                         bool isSelected = false)
        {
            _orderID = orderId;
            _customerName = customerName;
            _customerID = customerId;
            _productName = productName;
            _orderDate = orderDate;
            _quantity = quantity;
            _freight = freight;
            _shipCountry = shipCountry;
            _shipCity = shipCity;
            _paymentStatus = paymentStatus;
            _rating = rating;
            _isSelected = isSelected;
        }
    }
}
