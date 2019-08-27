#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.ComponentModel;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;

namespace TreeViewBindingDemo
{
    public class ViewModel : NotificationObject
    {
        public ViewModel()
        {
            _products = PopulateData();
            _SelectedItem = _products[0];
        }
        private ProductMVVM _SelectedItem;
        public ProductMVVM SelectedItem
        {
            set
            {
                _SelectedItem = value;
                this.RaisePropertyChanged(() => this.SelectedItem);
            }
            get { return _SelectedItem; }
        }

        ObservableCollection<ProductMVVM> _products;
        public ObservableCollection<ProductMVVM> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                this.RaisePropertyChanged(() => this.Products);
            }
        }       

        private ObservableCollection<ProductMVVM> PopulateData()
        {
            ObservableCollection<ProductMVVM> productList = new ObservableCollection<ProductMVVM>();
            ObservableCollection<ProductMVVM> us = new ObservableCollection<ProductMVVM>();
            us.Add(new ProductMVVM() { Name = "Washington" });
            us.Add(new ProductMVVM() { Name = "NewYork" });
            us.Add(new ProductMVVM() { Name = "Alaska" });
            us.Add(new ProductMVVM() { Name = "Canada" });

            ObservableCollection<ProductMVVM> uk = new ObservableCollection<ProductMVVM>();
            uk.Add(new ProductMVVM() { Name = "London" });
            uk.Add(new ProductMVVM() { Name = "Boston" });

            ObservableCollection<ProductMVVM> fr = new ObservableCollection<ProductMVVM>();
            fr.Add(new ProductMVVM() { Name = "Paris" });
            fr.Add(new ProductMVVM() { Name = "Privas" });
            fr.Add(new ProductMVVM() { Name = "Oreans" });

            ObservableCollection<ProductMVVM> gr = new ObservableCollection<ProductMVVM>();
            gr.Add(new ProductMVVM() { Name = "Berlin" });
            gr.Add(new ProductMVVM() { Name = "Dahlen" });
            gr.Add(new ProductMVVM() { Name = "Emden" });

            ProductMVVM unitedstates = new ProductMVVM()
            {
                Name = "United States",
                SubProducts = us
            };

            ProductMVVM unitedkingdom = new ProductMVVM()
            {
                Name = "United Kingdom",
                SubProducts = uk
            };

            ProductMVVM france = new ProductMVVM()
            {
                Name = "France",
                SubProducts = fr
            };

            ProductMVVM germany = new ProductMVVM()
            {
                Name = "Germany",
                SubProducts = gr
            };


            productList.Add(unitedstates);
            productList.Add(unitedkingdom);
            productList.Add(france);
            productList.Add(germany);
            return productList;
        }

    }
}
       

