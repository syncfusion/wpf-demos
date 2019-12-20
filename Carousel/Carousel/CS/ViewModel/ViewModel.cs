#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CarouselDemo
{
    public class ViewModel : NotificationObject
    {
        #region Private variables

        private ObservableCollection<CarouselModel> itemsCollection;
        private double radiusX = 300;
        private double radiusY = -200;
        private int rotationSpeed = 150;
        private int angle = 0;
        private double scaleFraction = 0.6;

        #endregion

        #region Public variabels

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

        public double RadisuX
        {
            get
            {
                return radiusX;
            }
            set
            {
                radiusX = value;
                RaisePropertyChanged("RadisuX");
            }
        }

        public double RadisuY
        {
            get
            {
                return radiusY;
            }
            set
            {
                radiusY = value;
                RaisePropertyChanged("RadisuY");
            }
        }

        public int RotationSpeed
        {
            get
            {
                return rotationSpeed;
            }
            set
            {
                rotationSpeed = value;
                RaisePropertyChanged("RotationSpeed");
            }
        }

        public int RotationAngle
        {
            get
            {
                return angle;
            }
            set
            {
                angle = value;
                RaisePropertyChanged("RotationAngle");
            }
        }

        public double ScaleFraction
        {
            get
            {
                return scaleFraction;
            }
            set
            {
                scaleFraction = value;
                RaisePropertyChanged("ScaleFraction");
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes the instance of this class 
        /// </summary>
        public ViewModel()
        {
            ItemsCollection = new ObservableCollection<CarouselModel>();
            ItemsCollection.Add(new CarouselModel() { Name = "Buchanan", DOB = "15/07/1984", State = "Montana", Age = "25", Designation = "Software Developer", Experience = "2+ Years", ImageSource = new BitmapImage(new Uri(@"/Images/Buchanan.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Callahan", DOB = "20/12/1984", State = "Texas", Age = "25", Designation = "Software Tester", Experience = "2+ Years", ImageSource = new BitmapImage(new Uri(@"/Images/Callahan.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Davolio", DOB = "7/04/1985", State = "Alaska", Age = "24", Designation = "Software Developer", Experience = "1.5+ Years", ImageSource = new BitmapImage(new Uri(@"/Images/Davolio-1.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Dodsworth", DOB = "21/09/1975", State = "Idaho", Age = "34", Designation = "Business Analyst", Experience = "9+ Years", ImageSource = new BitmapImage(new Uri(@"/Images/dodsworth.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Fuller", DOB = "21/10/1970", State = "Washington", Age = "37", Designation = "Business Analyst", Experience = "10+ Years", ImageSource = new BitmapImage(new Uri(@"/Images/Fuller.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Leverling", DOB = "01/01/1985", State = "Hawaii", Age = "25", Designation = "Software Tester", Experience = "1+ Years", ImageSource = new BitmapImage(new Uri(@"/Images/Leverling.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "King", DOB = "15/07/1984", State = "Montana", Age = "25", Designation = "Software Developer", Experience = "2+ Years", ImageSource = new BitmapImage(new Uri(@"/Images/King.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Peacock", DOB = "13/11/1973", State = "Washington", Age = "36", Designation = "Business Analyst", Experience = "10+ Years", ImageSource = new BitmapImage(new Uri(@"/Images/Leverling.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Suyama", DOB = "31/12/1983", State = " West Virginia", Age = "26", Designation = "Senior Software Developer", Experience = "3+ Years", ImageSource = new BitmapImage(new Uri(@"/Images/Suyama.png", UriKind.RelativeOrAbsolute)) });
        }

        #endregion 
    }

    /// <summary>
    /// Carousel model class 
    /// </summary>
    public class CarouselModel
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private string dob;

        public string DOB
        {
            get
            {
                return dob;
            }
            set
            {
                dob = value;
            }
        }

        private string age;

        public string Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        private string state;

        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }

        private string designation;

        public string Designation
        {
            get
            {
                return designation;
            }
            set
            {
                designation = value;
            }
        }

        private string experience;

        public string Experience
        {
            get
            {
                return experience;
            }
            set
            {
                experience = value;
            }
        }

        private ImageSource imageSource;

        public ImageSource ImageSource
        {
            get
            {
                return imageSource;
            }
            set
            {
                imageSource = value;
            }
        }

    }
}
