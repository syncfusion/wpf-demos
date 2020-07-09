#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Syncfusion.Windows.Shared;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SfTreeViewDemo
{
    public class Model : NotificationObject
    {
        public Model()
        {
            models = new ObservableCollection<Model>();
        }

        private ObservableCollection<Model> models;
        public ObservableCollection<Model> Models
        {
            get
            {
                return models;
            }

            set
            {
                models = value;
                this.RaisePropertyChanged("Models");
            }
        }
       

        #region TreeViewItemAdv Properties

        private string header;
        /// <summary>
        /// Gets or sets a value indicating the Header of the TreeViewItemAdv.
        /// </summary>        
        public string Header
        {
            get
            {
                return header;
            }

            set
            {
                header = value;
                this.RaisePropertyChanged("Header");
            }
        }

        private string brand;
        /// <summary>
        /// Gets or sets a value indicating the Brand of the TreeViewItemAdv.
        /// </summary>
        public string Brand
        {
            get
            {
                return brand;
            }

            set
            {
                brand = value;
                this.RaisePropertyChanged("Brand");
            }
        }

        private string product;
        /// <summary>
        /// Gets or sets a value indicating the Product of the TreeViewItemAdv.
        /// </summary>
        public string Product
        {
            get
            {
                return product;
            }

            set
            {
                product = value;
                this.RaisePropertyChanged("Product");
            }
        }

        private string price;
        /// <summary>
        /// Gets or sets a value indicating the Price of the TreeViewItemAdv.
        /// </summary>
        public string Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                this.RaisePropertyChanged("Price");
            }
        }

        private BitmapImage image;
        /// <summary>
        /// Gets or sets a value indicating the Image of the TreeViewItemAdv.
        /// </summary>
        public BitmapImage Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
                this.RaisePropertyChanged("Image");
            }
        } 


        #endregion
    }
}
