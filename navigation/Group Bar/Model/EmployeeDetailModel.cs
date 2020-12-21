#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using syncfusion.demoscommon.wpf;

namespace syncfusion.navigationdemos.wpf
{
    public class EmployeeDetailModel : NotificationObject
    {
        /// <summary>
        /// Specifies the age of the employee.
        /// </summary>
        private string age;

        /// <summary>
        /// Specifies the name of the employee.
        /// </summary>
        private string name;

        /// <summary>
        /// Specifies the location of the employee.
        /// </summary>
        private string location;

        /// <summary>
        /// Specifies the date of birth of the employee.
        /// </summary>
        private string dateOfBirth;

        /// <summary>
        /// Specifies the profile of the employee.
        /// </summary>
        private string image;

        /// <summary>
        /// Gets or sets the image for the employee to be displayed <see cref="EmployeeDetailModel"/> class.
        /// </summary>
        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                RaisePropertyChanged("Image");
            }
        }

        /// <summary>
        /// Gets or sets the date of birth for the employee to be displayed <see cref="EmployeeDetailModel"/> class.
        /// </summary>
        public string DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                dateOfBirth = value;
                RaisePropertyChanged("DateOfBirth");
            }
        }

        /// <summary>
        /// Gets or sets the date of age of the employee to be displayed <see cref="EmployeeDetailModel"/> class.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the name for the employee to be displayed <see cref="EmployeeDetailModel"/> class.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the location of the employee to be displayed <see cref="EmployeeDetailModel"/> class.
        /// </summary>
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
