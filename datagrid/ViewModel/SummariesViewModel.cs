#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Utility;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace syncfusion.datagriddemos.wpf
{
    public class SummariesViewModel : SalesInfoViewModel
    {
        public SummariesViewModel()
        {
            _SalesDetails = this.GetSalesInfo();
        }

        private ObservableCollection<SalesByDate> _SalesDetails = null;

        public new ObservableCollection<SalesByDate> YearlySalesDetails
        {
            get { return _SalesDetails; }

        }
    }
}
