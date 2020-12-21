#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Implementation class for ItemsSourceSelector interface
    /// </summary>
    public class CustomSelector : IItemsSourceSelector
    {
        public IEnumerable GetItemsSource(object record, object dataContext)
        {
            if (record == null)
                return null;

            var orderinfo = record as OrderInfo;
            var countryName = orderinfo.ShipCountry;

            var viewModel = dataContext as ComboBoxColumnsViewModel;

            //Returns ShipCity collection based on ShipCountry.
            if (viewModel.ShipCities.ContainsKey(countryName))
            {
                ObservableCollection<ShipCityDetails> shipcities = null;
                viewModel.ShipCities.TryGetValue(countryName, out shipcities);
                return shipcities.ToList();
            }
            return null;
        }
    }
}
