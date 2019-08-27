#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridDropDownAndReadOnlyColumns
{
    public class SupplierDetails : NotificationObject
    {
        private int _supplierId;

        public int SupplierID
        {
            get
            {
                return this._supplierId;
            }
            set
            {
                this._supplierId = value;
                RaisePropertyChanged("SupplierID");
            }
        }

        private string _supplierName;

        public string SupplierName
        {
            get
            {
                return _supplierName;
            }
            set
            {
                _supplierName = value;
                RaisePropertyChanged("SupplierName");
            }
        }

        private string _supplierCity;

        public string SupplierCity
        {
            get
            {
                return this._supplierCity;
            }
            set
            {
                this._supplierCity = value;
                RaisePropertyChanged("SupplierCity");
            }
        }
    }
}
