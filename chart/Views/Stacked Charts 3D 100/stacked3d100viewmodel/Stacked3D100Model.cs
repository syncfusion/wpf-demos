namespace syncfusion.chartdemos.wpf
{
    public class Stacked3D100Model
    {
        #region Field

        private double Total => SoutheastAsia + NorthAmerica + Europe + Balance;
        public string SoutheastAsiaValue => $"{SoutheastAsia} ({((SoutheastAsia / Total) * 100):F0}%)";
        public string NorthAmericaValue => $"{NorthAmerica} ({((NorthAmerica / Total) * 100):F0}%)";
        public string EuropeValue => $"{Europe} ({((Europe / Total) * 100):F0}%)";
        public string OthersValue => $"{Balance} ({((Balance / Total) * 100):F0}%)";

        #endregion

        #region Prperties

        public string Cloud { get; set; }
        public double SoutheastAsia { get; set; }
        public double NorthAmerica { get; set; }
        public double Europe { get; set; }
        public double Balance { get; set; }
        public double Others { get; set; }


        public string Year { get; set; }
        public double SafelyManaged { get; set; }
        public double Basic { get; set; }
        public double Limited { get; set; }
        public double Unimproved { get; set; }
        public double NoAccess { get; set; }


        public string Pet { get; set; }
        public double Street { get; set; }
        public double Friend { get; set; }
        public double Breeder { get; set; }
        public double Shelter { get; set; }
        public double Shop { get; set; }

        public string Name { get; set; }
        public double Value { get; set; }
        public double Size { get; set; } 

        #endregion

        #region Constructor

        public Stacked3D100Model()
        {

        }

        public Stacked3D100Model(string year, double safelyManaged, double basic, double limited, double unimproved, double noAccess)
        {
            Year = year;
            SafelyManaged = safelyManaged;
            Basic = basic;
            Limited = limited;
            Unimproved = unimproved;
            NoAccess = noAccess;
        }

        public Stacked3D100Model(string pet, double street, double friend, double breeder, double shelter, double shop,double other)
        {
            Pet = pet;
            Street = street;
            Friend = friend;
            Breeder = breeder;
            Shelter = shelter;
            Shop = shop;
            Others= other;
        }

        public Stacked3D100Model(string name, double value, double size)
        {
            Name = name;
            Value = value;
            Size = size;
        }

        #endregion
    }
}
