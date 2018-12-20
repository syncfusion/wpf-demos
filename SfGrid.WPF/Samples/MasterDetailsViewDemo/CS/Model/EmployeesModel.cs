#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.ComponentModel;

namespace MasterDetailsViewDemo
{
    public class Employees:INotifyPropertyChanged  
    {
        private System.Nullable<int> _OrderID;

        /// <summary>
        /// Gets or sets the order ID.
        /// </summary>
        /// <value>The order ID.</value>
        public System.Nullable<int> OrderID
        {
            get 
            {
                return this._OrderID; 
            }
            set
            {
                this._OrderID = value;
                RaisePropertyChanged("OrderID");
            }
        }

        private int _EmployeeID;

        /// <summary>
        /// Gets or sets the employee ID.
        /// </summary>
        /// <value>The employee ID.</value>
        public int EmployeeID
        {
            get
            {
                return this._EmployeeID; 
            }
            set
            {
                this._EmployeeID = value;
                RaisePropertyChanged("EmployeeID");
            }
        }

        private string _Name;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get 
            {
                return this._Name; 
            }
            set
            {
                this._Name = value;
                RaisePropertyChanged("Name");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Employees"/> class.
        /// </summary>
        /// <param name="or">The or.</param>
        /// <param name="emp">The emp.</param>
        /// <param name="nam">The nam.</param>
        public Employees(int or, int emp, string nam)
        {
            this.EmployeeID = emp;
            this.OrderID = or;
            this.Name = nam;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
