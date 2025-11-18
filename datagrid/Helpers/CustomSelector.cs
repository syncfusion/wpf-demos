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
