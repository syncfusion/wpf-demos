#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GroupbarOutlookDemo
{
    /// <summary>
    /// Represents contact Model.
    /// </summary>
    public class ContactModel  : IComparable<ContactModel>
    {
        #region Fields
        /// <summary>
        ///  Maintains the name of the person.
        /// </summary>
        private string name;

        /// <summary>
        ///  Maintains the phoneNumber of the person.
        /// </summary>
        private string phoneNumber;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [Category("Summary")]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                    name = value;
            }
        }

        /// <summary>
        /// Gets or sets the phonenumber.
        /// </summary>
        [Category("Summary")]
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                if (phoneNumber != value)
                    phoneNumber = value;
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// Compares the name property.
        /// </summary>
        /// <param name="other">Used to compare the property</param>
        /// <returns>Return the compared value</returns>
        public int CompareTo(ContactModel other)
        {
            return string.Compare(this.Name, other.Name);
        }
        #endregion
    }
}
