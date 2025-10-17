using System;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    public class Stacked3D100ViewModel : IDisposable
    {
        public ObservableCollection<Stacked3D100Model> CloudData { get; set; }
        public ObservableCollection<Stacked3D100Model> SaharaData { get; set; }
        public ObservableCollection<Stacked3D100Model> LowIncomeData { get; set; }
        public ObservableCollection<Stacked3D100Model> PetData { get; set; }
        public ObservableCollection<Stacked3D100Model> CostData { get; set; }
        public ObservableCollection<Stacked3D100Model> CostData1 { get; set; }
        public ObservableCollection<Stacked3D100Model> CostData2 { get; set; }
        public Stacked3D100ViewModel()
        {
            //100 Stacked Column
            CloudData = new ObservableCollection<Stacked3D100Model>()
            {
                 new Stacked3D100Model() { Cloud = "Microsoft", SoutheastAsia = 31,NorthAmerica = 37,Europe = 32, Balance = 18},
                 new Stacked3D100Model() { Cloud = "Amazon", SoutheastAsia = 21, NorthAmerica = 25,Europe = 18, Balance = 12},
                 new Stacked3D100Model() { Cloud = "Google", SoutheastAsia = 24, NorthAmerica = 25, Europe = 18, Balance = 6 },
                 new Stacked3D100Model() { Cloud = "Alibaba", SoutheastAsia = 49, NorthAmerica = 4, Europe = 4, Balance = 3},
                 new Stacked3D100Model() { Cloud = "IBM", SoutheastAsia = 8, NorthAmerica = 28, Europe = 18, Balance = 6 },
            };

            //100 Cluster Stacked Column
            SaharaData = new ObservableCollection<Stacked3D100Model>()
              {
                new Stacked3D100Model("2018",29.09,33.69,12.6,16.72,7.9),
                new Stacked3D100Model("2019",29.62,34.16,12.75,16.12,7.35),
                new Stacked3D100Model("2020",30.03,34.63,12.87,15.63,6.84),
                };

            LowIncomeData = new ObservableCollection<Stacked3D100Model>()
              {
                new Stacked3D100Model("2018",27.26,30.12,17.21,18.46,6.94),
                new Stacked3D100Model("2019",28.03,30.27,17.55,17.79,6.37),
                new Stacked3D100Model("2020",28.8,30.38,17.83,17.11,5.88),
                };

            // 100 Stacked Bar
            PetData = new ObservableCollection<Stacked3D100Model>()
            {
                new Stacked3D100Model("Dog",5,24,21,18,12,20),
                new Stacked3D100Model("Cat",24,25,4,24,10,13),
                new Stacked3D100Model("Others",7,16,5,5,48,19),
            };

            // 100 Cluster Stacked Bar
            CostData = new ObservableCollection<Stacked3D100Model>()
            {
             new Stacked3D100Model ( "Q1", 75,50.76 ),
             new Stacked3D100Model ("Q2", 55,58.14 ),
             new Stacked3D100Model ("Q3", 65,61.89 ),
             new Stacked3D100Model ("Q4",70,64.578)
            };

            CostData1 = new ObservableCollection<Stacked3D100Model>()
            {
             new Stacked3D100Model ( "Q1", 55, 35.9),
             new Stacked3D100Model ("Q2", 40,45.2 ),
             new Stacked3D100Model ("Q3", 55,52.34),
             new Stacked3D100Model ("Q4",55,48.765 )
            };

            CostData2 = new ObservableCollection<Stacked3D100Model>()
            {
             new Stacked3D100Model ( "Q1", 35,18.25 ),
             new Stacked3D100Model ("Q2", 20 ,18.55),
             new Stacked3D100Model ("Q3", 15,16.24),
             new Stacked3D100Model ("Q4",20,18.5 )
            };
        }

        public void Dispose()
        {
            if (CloudData != null)
                CloudData.Clear();

            if (SaharaData != null)
                SaharaData.Clear();

            if (LowIncomeData != null)
                LowIncomeData.Clear();

            if (PetData != null)
                PetData.Clear();

            if (CostData != null)
                CostData.Clear();

            if (CostData1 != null)
                CostData1.Clear();

            if (CostData2 != null)
                CostData2.Clear();

        }
    }
}
