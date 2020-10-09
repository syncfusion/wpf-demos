#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Windows.Shared;

namespace syncfusion.navigationdemos.wpf
{
    public class ProductModel : NotificationObject
    {
        double _prodid;
        string _prodname;
        double _price2000;
        double _price2010;

        public double ProdId
        {
            get
            {
                return _prodid;
            }
            set
            {
                _prodid = value;
                RaisePropertyChanged("ProdId");
            }
        }

        public string Prodname
        {
            get
            {
                return _prodname;
            }
            set
            {
                _prodname = value;
                RaisePropertyChanged("Prodname");
            }
        }

        public double Price2000
        {
            get
            {
                return _price2000;
            }
            set
            {
                _price2000 = value;
                RaisePropertyChanged("Price2000");
            }
        }

        public double Price2010
        {
            get
            {
                return _price2010;
            }
            set
            {
                _price2010 = value;
                RaisePropertyChanged("Price2010");
            }
        }
    }
}