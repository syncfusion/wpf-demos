#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace UIThreading
{
    class ProductModel
    {
        /// <summary>
        /// Gets or Sets the Product
        /// </summary>
        public string Product { get; set; }
        /// <summary>
        /// Gets or Sets the Date
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// Gets or Sets the Country
        /// </summary>
        public string Country { get; set; }       
        /// <summary>
        /// Gets or Sets the State
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Gets or Sets the Qunatity
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Gets or Sets the Amount
        /// </summary>
        public double Amount { get; set; }

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}", this.Country, this.State, this.Product);
        }
    }
}