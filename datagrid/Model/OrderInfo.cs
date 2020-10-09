#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.datagriddemos.wpf
{
    public class OrderInfo : NotificationObject
    {
        private int _OrderID;
        private string _CustomerID;        
        private string _productName;
        private double _unitPrice;
        private DateTime _orderDate;
        private double _freight;
        private long _contactNumber;        
        private string _shipcity;
        private string _shipCountry;
        private int _quantity;
        private DateTime shippedDate;
        private string _shipAddress;
        private string _shipName;
        private double _discount;
        private double _NoOfOrders;
        private int _supplierID;
        private short _unitsInStock;
        private TimeSpan _deliveryDelay;
        private string _shipPostalCode;        
        private bool _isShipped;
        private int _productID;
        private string _CompanyName;
        private double _Expense;
        private string imageLink;
        private int _employeeID;
        private ObservableCollection<OrderInfo> orderDetails;
        private CustomerInfo _Customers;
        private ShipperDetails[] shippersInfo;
        static int count = 0;
        private List<OrderInfo> orderList;

        public OrderInfo()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDetails"/> class.
        /// </summary>
        /// <param name="ord">The ord.</param>
        /// <param name="cusid">The custmer iD.</param>
        /// <param name="productName">The product name.</param>
        /// <param name="NoOfOrders">The no of orders.</param>
        /// <param name="country">The country.</param>
        /// <param name="ShipCity">The ship city ID.</param>
        public OrderInfo(int ord, string cusid, string productName, int NoOfOrders, string country, int shipCityID)
        {
            this._OrderID = ord;
            this._CustomerID = cusid;
            this._shipCountry = country;
            this._shipCityID = shipCityID;
            this._productName = productName;
            this._NoOfOrders = NoOfOrders;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderInfo"/> class.
        /// </summary>
        /// <param name="ord">The ord.</param>
        /// <param name="prod">The prod.</param>
        /// <param name="unit">The unit.</param>
        /// <param name="quan">The quan.</param>
        /// <param name="disc">The disc.</param>
        public OrderInfo(int ord, int prod, decimal unit, Int16 quan, double disc, string cusid, DateTime ordDt)
        {
            this._discount = disc;
            this._OrderID = ord;
            this._productID = prod;
            this._quantity = quan;
            this._unitPrice = (double)unit;
            this._CustomerID = cusid;
            this._orderDate = ordDt;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderInfo"/> class.
        /// </summary>
        /// <param name="ord">The ord.</param>
        /// <param name="prod">The prod.</param>
        /// <param name="unit">The unit.</param>
        /// <param name="quan">The quan.</param>
        /// <param name="disc">The disc.</param>
        public OrderInfo(int ord, int prod, decimal unit, Int16 quan, double disc, string cusid, DateTime ordDt, string city)
        {
            this._discount = disc;
            this._OrderID = ord;
            this._productID = prod;
            this._quantity = quan;
            this._unitPrice = (double)unit;
            this._CustomerID = cusid;
            this._orderDate = ordDt;
            this.ShipCity = city;
            this._deliveryDelay = ordDt.AddDays(quan - 1) - ordDt;
           if (count % 3 == 0)
                this.imageLink = "US.jpg";
            else if (count % 2 == 0)
                this.imageLink = "UK.jpg";
            else
                this.imageLink = "Japan.jpg";
            this._supplierID = count % 3 == 0 ? 1 : count % 3;
            count++;

        }
        public ObservableCollection<OrderInfo> OrderDetails
        {
            get
            {
                return this.orderDetails;
            }
            set
            {
                this.orderDetails = value;
                RaisePropertyChanged("OrderDetails");
            }
        }

        public List<OrderInfo> OrderList
        {
            get
            {
                return this.orderList;
            }
            set
            {
                this.orderList = value;
                RaisePropertyChanged("OrderList");
            }
        }

        private List<EmployeeDetails> employeeDetails;


        public List<EmployeeDetails> EmployeeDetails
        {
            get
            {
                return this.employeeDetails;
            }
            set
            {
                this.employeeDetails = value;
                RaisePropertyChanged("EmployeeDetails");
            }
        }

        private List<OrderInfo> orderDetail;


        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        /// <value>The order details.</value>
        public List<OrderInfo> OrderDetail
        {
            get
            {
                return this.orderDetail;
            }
            set
            {
                this.orderDetail = value;
                RaisePropertyChanged("OrderDetail");
            }
        }

        public int OrderID
        {
            get
            {
                return _OrderID;
            }
            set
            {
                _OrderID = value;
                RaisePropertyChanged("OrderID");
            }
        }
        public int ProductID
        {
            get
            {
                return _productID;
            }
            set
            {
                _productID = value;
                RaisePropertyChanged("ProductID");
            }
        }

        public int ShipCityID
        {
            get
            {
                return _shipCityID;
            }
            set
            {
                _shipCityID = value;
                RaisePropertyChanged("ShipCityID");
            }
        }
        public int EmployeeID
        {
            get
            {
                return _employeeID;
            }
            set
            {
                _employeeID = value;
                RaisePropertyChanged("EmployeeID");
            }
        }

        public string CompanyName
        {
            get
            {
                return _CompanyName;
            }
            set
            {
                _CompanyName = value;
                RaisePropertyChanged("CompanyName");
            }
        }

        public int SupplierID
        {
            get
            {
                return _supplierID;
            }
            set
            {
                _supplierID = value;
                RaisePropertyChanged("SupplierID");
            }
        }

        public string CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                _CustomerID = value;
                RaisePropertyChanged("CustomerID");
            }
        } 

        public CustomerInfo Customers
        {
            get
            {
                return _Customers;
            }
            set
            {
                _Customers = value;
                RaisePropertyChanged("Customers");
            }
        }

        public ShipperDetails[] ShippersInfo
        {
            get
            {
                return shippersInfo;
            }
            set
            {
                shippersInfo = value;
                RaisePropertyChanged("ShippersInfo");
            }
        }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>The name of the product.</value>
        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
                RaisePropertyChanged("ProductName");
            }
        }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>The unit price.</value>
        public double UnitPrice
        {
            get
            {
                return _unitPrice;
            }
            set
            {
                _unitPrice = value;
                RaisePropertyChanged("UnitPrice");
            }
        }

        public short UnitsInStock
        {
            get
            {
                return this._unitsInStock;
            }
            set
            {
                this._unitsInStock = value;
                this.RaisePropertyChanged("UnitsInStock");
            }
        }

        public double Expense
        {
            get
            {
                return this._Expense;
            }
            set
            {
                this._Expense = value;
                this.RaisePropertyChanged("Expense");
            }
        }

        /// <summary>
        /// Gets or sets the freight.
        /// </summary>
        /// <value>The freight.</value>
        public double Freight
        {
            get
            {
                return _freight;
            }
            set
            {
                _freight = value;
                RaisePropertyChanged("Freight");
            }
        }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public double NoOfOrders
        {
            get
            {
                return _NoOfOrders;
            }
            set
            {
                _NoOfOrders = value;
                RaisePropertyChanged("NoOfOrders");
            }
        }

        /// <summary>
        /// Gets or sets the ImageLink.
        /// </summary>    
        public string ImageLink
        {
            get
            {
                return imageLink;
            }
            set
            {
                imageLink = value;
                RaisePropertyChanged("ImageLink");
            }
        }

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>The discount.</value>
        public double Discount
        {
            get
            {
                return _discount;
            }
            set
            {
                _discount = value;
                RaisePropertyChanged("Discount");
            }
        }

        /// <summary>
        /// Gets or sets the order date.
        /// </summary>
        /// <value>The order date.</value>
        public DateTime OrderDate
        {
            get
            {
                return _orderDate;
            }
            set
            {
                _orderDate = value;
                RaisePropertyChanged("OrderDate");
            }
        }
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                RaisePropertyChanged("Quantity");
            }
        }

        /// <summary>
        /// Gets or sets the contact number.
        /// </summary>
        /// <value>
        /// The contact number.
        /// </value>
        public long ContactNumber
        {
            get
            {
                return _contactNumber;
            }
            set
            {
                _contactNumber = value;
                RaisePropertyChanged("ContactNumber");
            }
        }

        /// <summary>
        /// Gets or sets the ShipAddress.
        /// </summary>
        /// <value>
        /// The ShipAddress.
        /// </value>
        public string ShipAddress
        {
            get
            {
                return _shipAddress;
            }
            set
            {
                _shipAddress = value;
                RaisePropertyChanged("ShipAddress");
            }
        }

        /// <summary>
        /// Gets or sets the ShipCity.
        /// </summary>
        /// <value>
        /// The ShipCity.
        /// </value>
        public string ShipCity
        {
            get
            {
                return _shipcity;
            }
            set
            {
                _shipcity = value;
                RaisePropertyChanged("ShipCity");
            }
        }

        /// <summary>
        /// Gets or sets the ShipCountry.
        /// </summary>
        /// <value>
        /// The ShipCity.
        /// </value>
        public string ShipCountry
        {
            get
            {
                return _shipCountry;
            }
            set
            {
                _shipCountry = value;
                RaisePropertyChanged("ShipCountry");
            }
        } 

        public bool IsShipped
        {
            get { return _isShipped; }
            set
            {
                _isShipped = value;
                RaisePropertyChanged("IsShipped");
            }
        }

        public string ShipName
        {
            get { return _shipName; }
            set
            {
                _shipName = value;
                RaisePropertyChanged("ShipName");
            }
        } 

        public DateTime ShippedDate
        {
            get { return shippedDate; }
            set
            {
                shippedDate = value;
                RaisePropertyChanged("ShippedDate");
            }
        }

        /// <summary>
        /// Gets or sets the ship postal code.
        /// </summary>
        /// <value>The ship postal code.</value>
        public string ShipPostalCode
        {
            get
            {
                return _shipPostalCode;
            }
            set
            {
                _shipPostalCode = value;
                RaisePropertyChanged("ShipPostalCode");
            }
        } 
         

        public TimeSpan DeliveryDelay
        {
            get
            {
                return _deliveryDelay;
            }
            set
            {
                _deliveryDelay = value;
                RaisePropertyChanged("DeliveryDelay");
            }
        }

        private bool _isChecked;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is checked.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is checked; otherwise, <c>false</c>.
        /// </value>
        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                _isChecked = value;
                RaisePropertyChanged("IsChecked");
            }
        }

        public string _name;
        private int _shipCityID;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }
    }        
}
