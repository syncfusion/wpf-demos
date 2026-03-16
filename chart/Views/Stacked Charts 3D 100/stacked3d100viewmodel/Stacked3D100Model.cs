#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents multi-purpose data for 3D 100% stacked columns and bars.</summary>
    public class Stacked3D100Model
    {
        #region Field

        private double Total => SoutheastAsia + NorthAmerica + Europe + Balance;

        /// <summary>Gets the Southeast Asia value with percentage of total.</summary>
        public string SoutheastAsiaValue => $"{SoutheastAsia} ({((SoutheastAsia / Total) * 100):F0}%)";

        /// <summary>Gets the North America value with percentage of total.</summary>
        public string NorthAmericaValue => $"{NorthAmerica} ({((NorthAmerica / Total) * 100):F0}%)";

        /// <summary>Gets the Europe value with percentage of total.</summary>
        public string EuropeValue => $"{Europe} ({((Europe / Total) * 100):F0}%)";

        /// <summary>Gets the Others value with percentage of total.</summary>
        public string OthersValue => $"{Balance} ({((Balance / Total) * 100):F0}%)";

        #endregion

        #region Prperties

        /// <summary>Gets or sets the cloud provider name.</summary>
        public string Cloud { get; set; }

        /// <summary>Gets or sets the Southeast Asia share.</summary>
        public double SoutheastAsia { get; set; }

        /// <summary>Gets or sets the North America share.</summary>
        public double NorthAmerica { get; set; }

        /// <summary>Gets or sets the Europe share.</summary>
        public double Europe { get; set; }

        /// <summary>Gets or sets the residual share (others/balance).</summary>
        public double Balance { get; set; }

        /// <summary>Gets or sets the others share.</summary>
        public double Others { get; set; }

        // Inputs for water access dataset
        /// <summary>Gets or sets the year label.</summary>
        public string Year { get; set; }

        /// <summary>Gets or sets the safely managed share.</summary>
        public double SafelyManaged { get; set; }

        /// <summary>Gets or sets the basic services share.</summary>
        public double Basic { get; set; }

        /// <summary>Gets or sets the limited services share.</summary>
        public double Limited { get; set; }

        /// <summary>Gets or sets the unimproved services share.</summary>
        public double Unimproved { get; set; }

        /// <summary>Gets or sets the no access share.</summary>
        public double NoAccess { get; set; }


        /// <summary>Gets or sets the pet type.</summary>
        public string Pet { get; set; }

        /// <summary>Gets or sets the street source share.</summary>
        public double Street { get; set; }

        /// <summary>Gets or sets the friend source share.</summary>
        public double Friend { get; set; }

        /// <summary>Gets or sets the breeder source share.</summary>
        public double Breeder { get; set; }

        /// <summary>Gets or sets the shelter source share.</summary>
        public double Shelter { get; set; }

        /// <summary>Gets or sets the shop source share.</summary>
        public double Shop { get; set; }

        // Inputs for cost datasets
        /// <summary>Gets or sets the category/quarter name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the primary value.</summary>
        public double Value { get; set; }

        /// <summary>Gets or sets the secondary value used for size/stack.</summary>
        public double Size { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Stacked3D100Model"/> class.
        /// </summary>
        public Stacked3D100Model()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Stacked3D100Model"/> class with water access data.
        /// </summary>
        /// <param name="year">The year associated with the data.</param>
        /// <param name="safelyManaged">The percentage of safely managed water access.</param>
        /// <param name="basic">The percentage of basic water access.</param>
        /// <param name="limited">The percentage of limited water access.</param>
        /// <param name="unimproved">The percentage of unimproved water access.</param>
        /// <param name="noAccess">The percentage of population with no water access.</param>
        public Stacked3D100Model(string year, double safelyManaged, double basic, double limited, double unimproved, double noAccess)
        {
            Year = year;
            SafelyManaged = safelyManaged;
            Basic = basic;
            Limited = limited;
            Unimproved = unimproved;
            NoAccess = noAccess;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Stacked3D100Model"/> class with pet acquisition data.
        /// </summary>
        /// <param name="pet">The type of pet.</param>
        /// <param name="street">The percentage acquired from the street.</param>
        /// <param name="friend">The percentage acquired from friends.</param>
        /// <param name="breeder">The percentage acquired from breeders.</param>
        /// <param name="shelter">The percentage acquired from shelters.</param>
        /// <param name="shop">The percentage acquired from shops.</param>
        /// <param name="other">The percentage acquired from other sources.</param>
        public Stacked3D100Model(string pet, double street, double friend, double breeder, double shelter, double shop, double other)
        {
            Pet = pet;
            Street = street;
            Friend = friend;
            Breeder = breeder;
            Shelter = shelter;
            Shop = shop;
            Others = other;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Stacked3D100Model"/> class with cost data for the specified category.
        /// </summary>
        /// <param name="name">The category name.</param>
        /// <param name="value">The associated value.</param>
        /// <param name="size">The size of the category.</param>
        public Stacked3D100Model(string name, double value, double size)
        {
            Name = name;
            Value = value;
            Size = size;
        }

        #endregion
    }
}
