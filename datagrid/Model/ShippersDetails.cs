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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.datagriddemos.wpf
{
    public class ShipperDetails : NotificationObject
    {
        private int _ShipperID;

        private string _CompanyName;

        public int ShipperID
        {
            get
            {
                return _ShipperID;
            }
            set
            {
                _ShipperID = value;
                RaisePropertyChanged("ShipperID");
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
    }
}
