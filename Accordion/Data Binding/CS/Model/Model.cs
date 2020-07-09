#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.Windows.Media;

namespace DataBinding
{
    /// <summary>
    /// Represents a model class.
    /// </summary>
    public class Model
    {
        /// <summary>
        ///  Maintains the image details.
        /// </summary>
        private ImageSource image;

        /// <summary>
        ///  Maintains the name details.
        /// </summary>
        private string name;

        /// <summary>
        ///  Maintains the position details.
        /// </summary>
        private string position;

        /// <summary>
        ///  Maintains the organization unit details.
        /// </summary>
        private string organizationUnit;

        /// <summary>
        ///  Maintains the date of birth.
        /// </summary>
        private string dateOfBirth;

        /// <summary>
        ///  Maintains the location details.
        /// </summary>
        private string location;

        /// <summary>
        ///  Maintains the phone number.
        /// </summary>
        private string phone;

        /// <summary>
        ///  Maintains the email address.
        /// </summary>
        private string email;

        /// <summary>
        ///  Maintains the tile Color.
        /// </summary>
        private string tileColor;

        /// <summary>
        ///  Maintains the header color.
        /// </summary>
        private string headerColor;

        /// <summary>
        /// Gets or sets the image details <see cref="Model"/> class.
        /// </summary>
        public ImageSource Image
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

        /// <summary>
        /// Gets or sets the name <see cref="Model"/> class.
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
            }
        }

        /// <summary>
        /// Gets or sets the position <see cref="Model"/> class.
        /// </summary>
        public string Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        /// <summary>
        /// Gets or sets the organization unit <see cref="Model"/> class.
        /// </summary>
        public string OrganizationUnit
        {
            get
            {
                return organizationUnit;
            }
            set
            {
                organizationUnit = value;
            }
        }

        /// <summary>
        /// Gets or sets date of birth <see cref="Model"/> class.
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
            }
        }

        /// <summary>
        /// Gets or sets the location <see cref="Model"/> class.
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
            }
        }

        /// <summary>
        /// Gets or sets the phone number <see cref="Model"/> class.
        /// </summary>
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }

        /// <summary>
        /// Gets or sets the email address <see cref="Model"/> class.
        /// </summary>
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        /// <summary>
        /// Gets or sets the tile color <see cref="Model"/> class.
        /// </summary>
        public string TileColor
        {
            get
            {
                return tileColor;
            }
            set
            {
                tileColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the header color <see cref="Model"/> class.
        /// </summary>
        public string HeaderColor
        {
            get
            {
                return headerColor;
            }
            set
            {
                headerColor = value;
            }
        }
    }
}
