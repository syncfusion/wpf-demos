#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckBoxSelectorColumnDemo
{
    class ProductInfoRespository
    {

        /// <summary>
        /// Gets the orders details.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public List<ProductInfo> GetProductDetails(int count)
        {
            List<ProductInfo> productDetails = new List<ProductInfo>();
            SetProduct();
            SetProductPrice();
            for (int i = 10000; i < count + 10000; i++)
            {
                productDetails.Add(GetProduct(i));
            }
            return productDetails;
        }

        

        Random r = new Random();

        private ProductInfo GetProduct(int i)
        {
            ProductInfo product = new ProductInfo();
            var productName = ProductName[r.Next(ProductName.Count() -1 )];
            var Productcoll = Product[productName];
            product.ProductID = i;
            product.UserRating = r.Next(3, 5);
            product.ShippingDays = r.Next(1, 5);
            product.ProductType = productName;
            product.Product = Productcoll[r.Next(Productcoll.Length - 1)];
            var productModel = ProductModel[product.Product];
            product.Availability = r.Next(0, 20) % 5 == 0 ? false : true;
            product.Price = ProductPrice[productName];
            product.ProductModel = productModel[r.Next(productModel.Count())];

            return product;
        }

        string[] ProductName = new string[]
        {
            "Laptop",
            "Mobile",
            "Watch",         
            "Footware"
        };

        Dictionary<string, string[]> Product = new Dictionary<string, string[]>();
        Dictionary<string, string[]> ProductModel = new Dictionary<string, string[]>();
        Dictionary<string, int> ProductPrice = new Dictionary<string, int>();


        private void SetProduct()
        {

            string[] laptop = new string[] { "Dell", "HP", "Asus", "Sony", "Apple", "Lenovo" };

            string[] mobile = new string[] { "Nokia", "Samsung", "SonyMobile", "HTC", "IPhone" };

            string[] watch = new string[] { "FastTrack", "ROLEX", "Casio",  "Geneva", "Seiko" };

            string[] footware = new string[] { "Reebok", "Puma" };


            Product.Add("Laptop", laptop);
            Product.Add("Mobile", mobile);
            Product.Add("Watch", watch);
            Product.Add("Footware", footware);

            ProductModel.Add("Dell", new string[] { "XPS15", "XPS12" });
            ProductModel.Add("HP", new string[] { "Pavilion_G6", "Envy_X2" });
            ProductModel.Add("Asus", new string[] { "Transformer" });
            ProductModel.Add("Sony", new string[] { "Vaio" });
            ProductModel.Add("Apple", new string[] { "Macbook_Air", "Macbook_Pro2" });
            ProductModel.Add("Lenovo", new string[] { "Yoga" });

            ProductModel.Add("Nokia", new string[] { "Lumia_920", "Lumia_800" });
            ProductModel.Add("Samsung", new string[] { "S3" });
            ProductModel.Add("SonyMobile", new string[] { "Xperia_Tipo", "Xperia_Z" });
            ProductModel.Add("IPhone", new string[] { "Iphone5" });
            ProductModel.Add("HTC", new string[] { "8x", "One_X" });

            ProductModel.Add("FastTrack", new string[] { "Fastrack", "Men_Black" });
            ProductModel.Add("Casio", new string[] { "G-Shock" });
            ProductModel.Add("Geneva", new string[] { "Carrera", "Monaco" });
            ProductModel.Add("Seiko", new string[] { "Aquaracer" });
            ProductModel.Add("ROLEX", new string[] { "Sea_Dweller Deepsea", "Submariner" });

            ProductModel.Add("Puma", new string[] { "Aquil", "Axis_XT" });
            ProductModel.Add("Reebok", new string[] { "Advantage_Runner", "FieldEffect", "RunCruise" });
        }

        private void SetProductPrice()
        {
            ProductPrice.Add("Laptop", r.Next(1200,1500));
            ProductPrice.Add("Mobile", r.Next(250, 350));
            ProductPrice.Add("Watch", r.Next(120, 150));
            ProductPrice.Add("Footware", r.Next(35, 45));
        }

        string[] ProductID = new string[]
        {
            "ALFKI",
            "FRANS",
            "MEREP",
            "FOLKO",
            "SIMOB",
            "WARTH",
            "VAFFE",
            "FURIB",
            "SEVES",
            "LINOD",
            "RISCU",
            "PICCO",
            "BLONP",
            "WELLI",
            "FOLIG"
        };
    }
}
