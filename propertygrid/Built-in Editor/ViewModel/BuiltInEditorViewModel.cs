#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace syncfusion.propertygriddemos.wpf
{
    public class BuiltInEditorViewModel : NotificationObject
    {
        #region Properties
        private PropertyList propertyList;

        public PropertyList PropertyList
        {
            get
            {
                return propertyList;
            }
            set
            {
                propertyList = value;
                this.RaisePropertyChanged(() => this.PropertyList);
            }
        }
        #endregion

        public BuiltInEditorViewModel()
        {
            propertyList = new PropertyList();
            propertyList.BoolProperty = true;
            propertyList.BrushProperty = Brushes.Red;
            propertyList.CharProperty = 'A';
            propertyList.ColorProperty = Colors.Red;
            propertyList.DateTimeProperty = DateTime.Today;
            propertyList.DecimalProperty = 1.0M;
            propertyList.DoubleProperty = 89.76;
            propertyList.EnumProperty =  Gender.Male;
            propertyList.IntProperty = 123;
            propertyList.LongProperty = 1234567890;
            propertyList.ListProperty = new System.Collections.Generic.List<Customers>();
            propertyList.ListProperty.Add(
                new Customers() 
                {  
                    CustomerID=01, 
                    CustomerName= "John"
                });
            propertyList.ListProperty.Add(
                new Customers()
                {
                    CustomerID =02,
                    CustomerName = "Mark"
                });
           
            propertyList.ObservableCollectionProperty = new ObservableCollection<Customers>();
            propertyList.ObservableCollectionProperty.Add(
                new Customers()
                {
                    CustomerID = 01,
                    CustomerName = "Peter"
                });
            propertyList.ObservableCollectionProperty.Add(
                new Customers()
                {
                    CustomerID = 02,
                    CustomerName = "David"
                });
            propertyList.PointProperty = new System.Windows.Point(10.4, 10.8);
            propertyList.StringProperty = "This is PropertyGrid control ";
            propertyList.TimeSpanProperty = new TimeSpan(12, 38, 56);
        }
    }
}