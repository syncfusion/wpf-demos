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
