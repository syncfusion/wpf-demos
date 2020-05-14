#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interactivity;

namespace StylingDemo
{
    public class DataGridBehavior : Behavior<SfDataGrid>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            (this.AssociatedObject as SfDataGrid).Loaded += OnLoaded;
            base.OnAttached();
        }

        /// <summary>
        /// Occurs when the SfDataGrid is rendered and ready for interaction.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The RoutedEventArgs</param>
        private void OnLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.AssociatedObject.DataContext != null)
            {
                (this.AssociatedObject as SfDataGrid).ItemsSource = (this.AssociatedObject.DataContext as CountryInfoViewModel).CountryDetails;
            }
            var countryInfoViewModel = (this.AssociatedObject.DataContext as CountryInfoViewModel);
            var random = new Random();
            for (int i = 0; i < countryInfoViewModel.CountryDetails.Count; i++)
            {
                var item = countryInfoViewModel.CountryDetails[i];
                var economy = new ObservableCollection<EconomyGrowth>();
                for (int j = 0; j < 5; j++)
                {
                    economy.Add(new EconomyGrowth() { Year = DateTime.Now.Year - j, GrowthPercentage = random.Next(0, 5) });
                }
                item.EconomyRate = economy;
            }
        }

        protected override void OnDetaching()
        {
            (this.AssociatedObject as SfDataGrid).Loaded -= OnLoaded;
            base.OnDetaching();
        }
    }
}
