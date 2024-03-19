#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.PropertyGrid;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.RightsManagement;
using System.Windows.Input;
using System.Windows.Media;

namespace syncfusion.propertygriddemos.wpf
{
    public class NestedAndReadOnlySupportViewModel : NotificationObject
    {
        private bool enableReadOnlyMode= false;
        private ICommand loadedCommand;
        private PropertyExpandModes propertyExpandMode = PropertyExpandModes.NestedMode;

        public ICommand LoadedCommand
        {
            get
            {
                return loadedCommand;
            }
        }

        public bool EnableReadOnlyMode
        {
            get { return enableReadOnlyMode; }
            set
            {
                enableReadOnlyMode = value;
                this.RaisePropertyChanged(nameof(this.EnableReadOnlyMode));
            }
        }        

        public PropertyExpandModes PropertyExpandMode
        {
            get { return propertyExpandMode; }
            set
            {
                propertyExpandMode = value;
                this.RaisePropertyChanged(nameof(this.PropertyExpandMode));
            }
        }

        public Company Company { get; set; }

        public void PropertyGridLoaded(object parameter)
        {
            (parameter as PropertyGrid).CollectionEditorOpening += PropertyGrid_CollectionEditorOpening;
        }

        private void PropertyGrid_CollectionEditorOpening(object sender, CollectionEditorOpeningEventArgs e)
        {
            //Enable or disabe the collection property as readonly
            e.IsReadonly = enableReadOnlyMode;
        }

        public NestedAndReadOnlySupportViewModel()
        {
            loadedCommand = new DelegateCommand<object>(PropertyGridLoaded);
            Company = new Company()
            {
                CompanyName = "ABC furnitures",
                CompanyID = 037,
                ProductName = "Office Table",
                Bank = new Bank()
                {
                    Name = "Centura Banks",
                    AccountNumber = 00987453721,
                    CustomerID = "carljohnson",
                    Password = "nuttertools",
                    Address = new Address() { State = "New Yark", DoorNo = 87, StreetName = "Martin street" }
                },

                Address = new Address()
                {
                    State = "New Yark",
                    DoorNo = 10,
                    StreetName = "Martin street"
                },
                Customers = new List<CollectionCustomerDetails>()
                {
                    new CollectionCustomerDetails()
                    {
                        CustomerID = "ALFKI",
                        EmployeeID = "0001A",
                        CompanyName = "Alfreds Futterkiste",
                        ContactName = "Maria Anders",
                        Country = "Germany",
                        Orders = new ObservableCollection<OrderDetails>()
                        {
                            new OrderDetails()
                            {
                                OrderID = "10835",
                                CustomerID = "ALFKI",
                                OrderDate = new DateTime(2020, 1, 15),
                                ShippedDate = new DateTime(2020, 1, 21),
                                RequiredDate = new DateTime(2020, 2, 12),
                            },
                            new OrderDetails()
                            {
                                OrderID = "10952",
                                CustomerID = "ALFKI",
                                OrderDate = new DateTime(2020, 3, 16),
                                ShippedDate = new DateTime(2020, 3, 24),
                                RequiredDate = new DateTime(2020, 4, 27),
                            }
                        }
                    },
                    new CollectionCustomerDetails()
                    {
                        CustomerID = "AROUT",
                        EmployeeID = "0001B",
                        CompanyName = "Around the Horn",
                        ContactName = "Thomas Hardy",
                        Country = "UK",
                        Orders = new ObservableCollection<OrderDetails>()
                        {
                            new OrderDetails()
                            {
                                OrderID = "10453",
                                CustomerID = "AROUT",
                                OrderDate = new DateTime(2020, 2, 17),
                                ShippedDate = new DateTime(2020, 2, 17),
                                RequiredDate = new DateTime(2020, 3, 17),
                            },
                            new OrderDetails()
                            {
                                OrderID = "10558",
                                CustomerID = "AROUT",
                                OrderDate = new DateTime(2020, 3, 21),
                                ShippedDate = new DateTime(2020, 3, 28),
                                RequiredDate = new DateTime(2020, 4, 2),
                            },
                            new OrderDetails()
                            {
                                OrderID = "10743",
                                CustomerID = "AROUT",
                                OrderDate = new DateTime(2020, 4, 17),
                                ShippedDate = new DateTime(2020, 4, 21),
                                RequiredDate = new DateTime(2020, 5, 5),
                            }
                        }
                    }
                }                
            };
        }
    }
}