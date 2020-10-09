#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace syncfusion.layoutdemos.wpf
{
    public class CarouselViewModel : NotificationObject
    {
        private ObservableCollection<CarouselModel> itemsCollection;
     
        public ObservableCollection<CarouselModel> ItemsCollection
        {
            get
            {
                return itemsCollection;
            }
            set
            {
                itemsCollection = value;
            }
        }

        #region Constructor
        /// <summary>
        /// Initializes the instance of this class 
        /// </summary>
        public CarouselViewModel()
        {
            ItemsCollection = new ObservableCollection<CarouselModel>();
            ItemsCollection.Add(new CarouselModel() { Name = "Buchanan", DOB = DateTime.Parse("1984/07/15"), State = "Montana", Age = 25, Designation = "Software Developer", Experience = "2+ Years", ImageSource = new BitmapImage(new Uri("/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle37.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Callahan", DOB = DateTime.Parse("1984/12/20"), State = "Texas", Age = 25, Designation = "Software Tester", Experience = "2+ Years", ImageSource = new BitmapImage(new Uri("/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle28.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Davolio", DOB = DateTime.Parse("1985/04/07"), State = "Alaska", Age = 24, Designation = "Software Developer", Experience = "1.5+ Years", ImageSource = new BitmapImage(new Uri("/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle10.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Dodsworth", DOB = DateTime.Parse("1975/09/21"), State = "Idaho", Age = 34, Designation = "Business Analyst", Experience = "9+ Years", ImageSource = new BitmapImage(new Uri("/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle6.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Fuller", DOB = DateTime.Parse("1970/10/21"), State = "Washington", Age = 37, Designation = "Business Analyst", Experience = "10+ Years", ImageSource = new BitmapImage(new Uri("/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle33.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Leverling", DOB = DateTime.Parse("1985/01/01"), State = "Hawaii", Age = 25, Designation = "Software Tester", Experience = "1+ Years", ImageSource = new BitmapImage(new Uri("/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle17.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "King", DOB = DateTime.Parse("1984/07/15"), State = "Montana", Age = 25, Designation = "Software Developer", Experience = "2+ Years", ImageSource = new BitmapImage(new Uri("/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle34.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Peacock", DOB = DateTime.Parse("1973/11/13"), State = "Washington", Age = 36, Designation = "Business Analyst", Experience = "10+ Years", ImageSource = new BitmapImage(new Uri("/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle25.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Suyama", DOB = DateTime.Parse("1983/12/31"), State = " West Virginia", Age = 26, Designation = "Senior Software Developer", Experience = "3+ Years", ImageSource = new BitmapImage(new Uri("/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle31.png", UriKind.RelativeOrAbsolute)) });
        }

        #endregion 
    }
}
