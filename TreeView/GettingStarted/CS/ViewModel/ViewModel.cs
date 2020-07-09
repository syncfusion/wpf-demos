#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;
using System;
using System.Xml.Linq;
using System.Windows.Input;
using Syncfusion.Windows.Shared;
using System.Windows.Media.Imaging;
using System.Windows;

namespace SfTreeViewDemo
{
    public class ViewModel : NotificationObject
    {
        private ObservableCollection<Model> items;
        public ObservableCollection<Model> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
                this.RaisePropertyChanged("Items");
            }
        } 

        private Visibility visibility = Visibility.Collapsed;

        public Visibility Visibility
        {
            get { return visibility; }
            set
            {
                visibility = value;
                this.RaisePropertyChanged(() => this.Visibility);
            }
        }

        public ViewModel()
        {
            Items = new ObservableCollection<Model>();
            PopulateCollection();
        }

        private void PopulateCollection()
        {
            var productType = new Model { Header = "Product Type"  };

            var brand1 = new Model { Header = "Laptop"  };
            var brand2 = new Model { Header = "Watch"  };
            var brand3 = new Model { Header = "Mobile"  };

            var asus = new Model() { Header = "Asus"  };
            var apple = new Model() { Header = "Apple"  };
            var dell = new Model() { Header = "Dell"  };
            var sony = new Model() { Header = "Sony"  };

            var rolex = new Model() { Header = "ROLEX"  };
            var fastrack = new Model() { Header = "FastTrack"  };
            var casio = new Model() { Header = "Casio"  };
            var geneva = new Model() { Header = "Geneva"  };

            var sonyMobile = new Model() { Header = "Sony"  };
            var samsung = new Model() { Header = "Samsung"  };
            var nokia = new Model() { Header = "Nokia"  };
            var htc = new Model() { Header = "HTC"  };

            var asus_model = new Model() { Header = "Transformer", Price= "$1,341.00", Image = new BitmapImage(new Uri("Images/Transformer.png", UriKind.RelativeOrAbsolute)), Brand = "Asus", Product = "Laptop" };
            var dell_model = new Model() { Header = "XPS12" , Price= "$1,341.00", Image = new BitmapImage(new Uri("Images/XPS12.png", UriKind.RelativeOrAbsolute)), Brand = "Sony", Product="Laptop"};
            var dell_model1 = new Model() { Header = "XPS15", Price= "$1,341.00", Image = new BitmapImage(new Uri("Images/XPS15.png", UriKind.RelativeOrAbsolute)), Brand= "Sony", Product = "Laptop"  };
            var sony_model = new Model() { Header = "Vaio", Price= "$1,341.00", Image = new BitmapImage(new Uri("Images/Vaio.png", UriKind.RelativeOrAbsolute)), Brand = "Sony", Product = "Laptop"  };
            var apple_model = new Model() { Header = "Macbook Pro 2", Price= "$1,341.00", Image = new BitmapImage(new Uri("Images/MacBook_Pro2.png", UriKind.RelativeOrAbsolute)), Brand = "Apple", Product = "Laptop"  };
            var apple_model1 = new Model() { Header = "Macbook Air" , Price = "$1,341.00", Image = new BitmapImage(new Uri("Images/MacBook_Air.png", UriKind.RelativeOrAbsolute)), Brand = "Apple", Product = "Laptop"  };
            var rolex_model = new Model() { Header = "Submariner", Price = "$135.00", Image = new BitmapImage(new Uri("Images/Submariner.png", UriKind.RelativeOrAbsolute)), Brand = "ROLEX", Product = "Watch"  };
            var rolex_model1 = new Model() { Header = "Sea Dweller Deepsea", Price = "$135.00", Image = new BitmapImage(new Uri("Images/Sea_Dweller Deepsea.png", UriKind.RelativeOrAbsolute)), Brand = "ROLEX", Product = "Watch"  };
            var fastrack_model = new Model() { Header = "FastTrack", Price= "$135.00", Image = new BitmapImage(new Uri("Images/Fastrack.png", UriKind.RelativeOrAbsolute)), Brand = "Fastrack", Product = "Watch"  };
            var fastrack_model1 = new Model() { Header = "Men Black", Price = "$135.00", Image = new BitmapImage(new Uri("Images/Men_Black.png", UriKind.RelativeOrAbsolute)), Brand = "Fastrack", Product = "Watch"  };
            var casio_model = new Model() { Header = "G-Shock", Price = "$135.00", Image = new BitmapImage(new Uri("Images/G-Shock.png", UriKind.RelativeOrAbsolute)), Brand = "Fastrack", Product = "Watch"  };
            var geneva_model = new Model() { Header = "Monaco", Price = "$135.00", Image = new BitmapImage(new Uri("Images/Monaco.png", UriKind.RelativeOrAbsolute)), Brand = "Casio", Product = "Laptop"  };
            var sonyMobile_model = new Model() { Header = "Xperia Z", Price = "$135.00", Image = new BitmapImage(new Uri("Images/Xperia_Z.png", UriKind.RelativeOrAbsolute)), Brand = "Sony", Product = "Laptop"  };
            var sonyMobile_model1 = new Model() { Header = "Xperia Tipo", Price = "$135.00", Image = new BitmapImage(new Uri("Images/Xperia_Tipo.png", UriKind.RelativeOrAbsolute)), Brand = "Sony", Product = "Mobile"  };
            var samsung_model = new Model() { Header = "S3", Price = "$135.00", Image = new BitmapImage(new Uri("Images/S3.png", UriKind.RelativeOrAbsolute)), Brand = "Sony", Product = "Mobile"  };
            var nokia_model = new Model() { Header = "Lumia 920", Price = "$135.00", Image = new BitmapImage(new Uri("Images/Lumia_920.png", UriKind.RelativeOrAbsolute)), Brand = "Dell", Product = "Mobile"  };
            var nokia_model1 = new Model() { Header = "Lumia 800", Price = "$135.00", Image = new BitmapImage(new Uri("Images/Lumia_800.png", UriKind.RelativeOrAbsolute)), Brand = "Nokia", Product = "Mobile"  };
            var htc_model = new Model() { Header = "8X", Price = "$135.00", Image = new BitmapImage(new Uri("Images/8x.png", UriKind.RelativeOrAbsolute)), Brand = "HTC", Product = "Mobile"  };

            asus.Models.Add(asus_model);
            apple.Models.Add(apple_model);
            apple.Models.Add(apple_model1);
            dell.Models.Add(dell_model);
            dell.Models.Add(dell_model1);
            sony.Models.Add(sony_model);
            rolex.Models.Add(rolex_model);
            rolex.Models.Add(rolex_model1);
            fastrack.Models.Add(fastrack_model);
            fastrack.Models.Add(fastrack_model1);
            casio.Models.Add(casio_model);
            geneva.Models.Add(geneva_model);
            sonyMobile.Models.Add(sonyMobile_model);
            sonyMobile.Models.Add(sonyMobile_model1);
            samsung.Models.Add(samsung_model);
            nokia.Models.Add(nokia_model);
            nokia.Models.Add(nokia_model1);
            htc.Models.Add(htc_model);
            brand1.Models.Add(asus);
            brand1.Models.Add(apple);
            brand1.Models.Add(dell);
            brand1.Models.Add(sony);
            brand2.Models.Add(rolex);
            brand2.Models.Add(fastrack);
            brand2.Models.Add(casio);
            brand2.Models.Add(geneva);
            brand3.Models.Add(sonyMobile);
            brand3.Models.Add(samsung);
            brand3.Models.Add(nokia);
            brand3.Models.Add(htc);

            productType.Models.Add(brand1);
            productType.Models.Add(brand2);
            productType.Models.Add(brand3);

            Items.Add(productType);
        }
    }
}
