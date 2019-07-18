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
using System.ComponentModel;
using Syncfusion.Windows.Shared;


namespace ItemsSourceDemo
{
    public class Employee : NotificationObject
    {
        private string age;

        private string name;

        private string location;

        private string dob;

        private string image;

        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }

        public string DOB
        {
            get
            {
                return dob;
            }
            set
            {
                dob = value;
                RaisePropertyChanged("dob");
            }
        }

        public string Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
                 RaisePropertyChanged("Age");
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Location
        {
            get
            {
                return location;
            }

            set
            {
                location = value;
                RaisePropertyChanged("Location");
            }
        }

        
    }
}
