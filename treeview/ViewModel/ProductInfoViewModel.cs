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
using System.Windows.Media.Imaging;
using System.Windows;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.treeviewdemos.wpf
{
    public class ProductInfoViewModel : Syncfusion.Windows.Shared.NotificationObject
    {
        private ObservableCollection<ProductInfo> items;
        public ObservableCollection<ProductInfo> Items
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

        private ICommand selectionCommand;

        public ICommand SelectionCommand
        {
            get { return selectionCommand; }
            set { selectionCommand = value; }
        }


        public ProductInfoViewModel()
        {
            selectionCommand = new demoscommon.wpf.DelegateCommand<object>(SelectionExecute);
            Items = new ObservableCollection<ProductInfo>();
            PopulateCollection();
        }

        private void SelectionExecute(object obj)
        {
            if (obj != null)
            {
                var product = (obj as ProductInfo).Product;
                this.Visibility = product != null ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void PopulateCollection()
        {
            var productType = new ProductInfo { Header = "Product Type"  };

            var brand1 = new ProductInfo { Header = "Laptop"  };
            var brand2 = new ProductInfo { Header = "Watch"  };
            var brand3 = new ProductInfo { Header = "Mobile"  };

            var asus = new ProductInfo() { Header = "Asus"  };
            var apple = new ProductInfo() { Header = "Apple"  };
            var dell = new ProductInfo() { Header = "Dell"  };
            var sony = new ProductInfo() { Header = "Sony"  };

            var rolex = new ProductInfo() { Header = "ROLEX"  };
            var fastrack = new ProductInfo() { Header = "FastTrack"  };
            var casio = new ProductInfo() { Header = "Casio"  };
            var geneva = new ProductInfo() { Header = "Geneva"  };

            var sonyMobile = new ProductInfo() { Header = "Sony"  };
            var samsung = new ProductInfo() { Header = "Samsung"  };
            var nokia = new ProductInfo() { Header = "Nokia"  };
            var htc = new ProductInfo() { Header = "HTC"  };

            var asus_model = new ProductInfo() { Header = "Transformer", Price= "$1,341.00", Image = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/Gadgets/Transformer.png", UriKind.Relative)), Brand = "Asus", Product = "Laptop" };
            var dell_model = new ProductInfo() { Header = "XPS12" , Price= "$1,341.00", Image = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/Gadgets/XPS12.png", UriKind.Relative)), Brand = "Sony", Product="Laptop"};
            var dell_model1 = new ProductInfo() { Header = "XPS15", Price= "$1,341.00", Image = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/Gadgets/XPS15.png", UriKind.Relative)), Brand= "Sony", Product = "Laptop"  };
            var sony_model = new ProductInfo() { Header = "Vaio", Price= "$1,341.00", Image = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/Gadgets/Vaio.png", UriKind.Relative)), Brand = "Sony", Product = "Laptop"  };
            var apple_model = new ProductInfo() { Header = "Macbook Pro 2", Price= "$1,341.00", Image = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/Gadgets/MacBook_Pro2.png", UriKind.Relative)), Brand = "Apple", Product = "Laptop"  };
            var apple_model1 = new ProductInfo() { Header = "Macbook Air" , Price = "$1,341.00", Image = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/Gadgets/MacBook_Air.png", UriKind.Relative)), Brand = "Apple", Product = "Laptop"  };
            var rolex_model = new ProductInfo() { Header = "Submariner", Price = "$135.00", Image = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/Gadgets/Submariner.png", UriKind.Relative)), Brand = "ROLEX", Product = "Watch"  };
            var rolex_model1 = new ProductInfo() { Header = "Sea Dweller Deepsea", Price = "$135.00", Image = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/Gadgets/Sea_Dweller Deepsea.png", UriKind.Relative)), Brand = "ROLEX", Product = "Watch"  };
            var fastrack_model = new ProductInfo() { Header = "FastTrack", Price= "$135.00", Image = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/Gadgets/Fastrack.png", UriKind.Relative)), Brand = "Fastrack", Product = "Watch"  };
            var fastrack_model1 = new ProductInfo() { Header = "Men Black", Price = "$135.00", Image = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/Gadgets/Men_Black.png", UriKind.Relative)), Brand = "Fastrack", Product = "Watch"  };
            var casio_model = new ProductInfo() { Header = "G-Shock", Price = "$135.00", Image = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/Gadgets/G-Shock.png", UriKind.Relative)), Brand = "Fastrack", Product = "Watch"  };
            var geneva_model = new ProductInfo() { Header = "Monaco", Price = "$135.00", Image = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/Gadgets/Monaco.png", UriKind.Relative)), Brand = "Casio", Product = "Laptop"  };
            var sonyMobile_model = new ProductInfo() { Header = "Xperia Z", Price = "$135.00", Image = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/Gadgets/Xperia_Z.png", UriKind.Relative)), Brand = "Sony", Product = "Laptop"  };
            var sonyMobile_model1 = new ProductInfo() { Header = "Xperia Tipo", Price = "$135.00", Image = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/Gadgets/Xperia_Tipo.png", UriKind.Relative)), Brand = "Sony", Product = "Mobile"  };
            var samsung_model = new ProductInfo() { Header = "S3", Price = "$135.00", Image = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/Gadgets/S3.png", UriKind.Relative)), Brand = "Sony", Product = "Mobile"  };
            var nokia_model = new ProductInfo() { Header = "Lumia 920", Price = "$135.00", Image = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/Gadgets/Lumia_920.png", UriKind.Relative)), Brand = "Dell", Product = "Mobile"  };
            var nokia_model1 = new ProductInfo() { Header = "Lumia 800", Price = "$135.00", Image = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/Gadgets/Lumia_800.png", UriKind.Relative)), Brand = "Nokia", Product = "Mobile"  };
            var htc_model = new ProductInfo() { Header = "8X", Price = "$135.00", Image = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/Gadgets/8x.png", UriKind.Relative)), Brand = "HTC", Product = "Mobile"  };

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
