#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Represents contact Model.
    /// </summary>
    public class ContactModel  : NotificationObject, IComparable<ContactModel>
    {
        /// <summary>
        ///  Maintains the name of the person.
        /// </summary>
        private string name;

        /// <summary>
        /// Gets or sets the name <see cref="ContactModel"/> class.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        /// <summary>
        /// Compares the name property.
        /// </summary>
        /// <param name="other">Used to compare the property</param>
        /// <returns>Return the compared value</returns>
        public int CompareTo(ContactModel other)
        {
            return string.Compare(this.Name, other.Name);
        }
    }
}
