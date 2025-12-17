using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;

namespace syncfusion.chartdemos.wpf
{
    public class GroupingViewModel : IDisposable
    {
        public IList<GroupingModel> PieData { get; set; }
        public IList<GroupingModel> DoughnutData { get; set; }

        public Array PieGroupMode
        {
            get { return Enum.GetValues(typeof(PieGroupMode)); }
        }

        public GroupingViewModel()
        {
            // Pie
            PieData = new List<GroupingModel>
            {
                new GroupingModel( "US",22.90,0.244),
                new GroupingModel("China",16.90,0.179),
                new GroupingModel( "Japan",5.10,0.054),
                new GroupingModel("Germany",4.20,0.045),
                new GroupingModel("UK",3.10,0.033),
                new GroupingModel("India",2.90,0.031),
                new GroupingModel("France",2.90,0.031),
                new GroupingModel( "Italy",2.10,0.023),
                new GroupingModel( "Canada",2.00,0.021),
                new GroupingModel( "Korea",1.80,0.019),
                new GroupingModel("Russia",1.60,0.017),
                new GroupingModel("Brazil",1.60,0.017),
                new GroupingModel("Australia",1.60,0.017),
                new GroupingModel("Spain",1.40,0.015),
                new GroupingModel("Mexico",1.30,0.014),
                new GroupingModel("Indonesia",1.20,0.012),
                new GroupingModel("Iran",1.10,0.011),
                new GroupingModel("Netherlands",1.00,0.011),
                new GroupingModel("Saudi Arabia",0.80,0.009),
                new GroupingModel("Switzerland",0.80,0.009),
                new GroupingModel("Turkey",0.80,0.008),
                new GroupingModel("Taiwan",0.80,0.008),
                new GroupingModel("Poland",0.70,0.007),
                new GroupingModel("Sweden",0.60,0.007),
                new GroupingModel("Belgium",0.60,0.006),
                new GroupingModel("Thailand",0.50,0.006),
                new GroupingModel("Ireland",0.50,0.005),
                new GroupingModel("Austria",0.50,0.005),
                new GroupingModel("Nigeria",0.50,0.005),
                new GroupingModel("Israel",0.50,0.005),
                new GroupingModel("Argentina",0.50,0.005),
                new GroupingModel("Norway",0.40,0.005),
                new GroupingModel("South Africa",0.40,0.004),
                new GroupingModel("UAE",0.40,0.004),
                new GroupingModel("Denmark",0.40,0.004),
                new GroupingModel("Egypt",0.40,0.004),
                new GroupingModel("Philippines",0.40,0.004),
                new GroupingModel("Singapore",0.40,0.004),
                new GroupingModel("Malaysia",0.40,0.004),
                new GroupingModel("Hong Kong SAR",0.40,0.004),
                new GroupingModel("Vietnam",0.40,0.004),
                new GroupingModel("Bangladesh",0.40,0.004),
                new GroupingModel("Chile",0.30,0.004),
                new GroupingModel("Colombia",0.30,0.003),
                new GroupingModel("Finland",0.30,0.003),
                new GroupingModel("Romania",0.30,0.003),
                new GroupingModel("Czech Republic",0.30,0.003),
                new GroupingModel("Portugal",0.30,0.003),
                new GroupingModel("Pakistan",0.30,0.003),
                new GroupingModel("New Zealand",0.20,0.003),
            };

            //Doughnut
            DoughnutData = new List<GroupingModel>
            {
                new GroupingModel("US",51.30,0.39),
                new GroupingModel("China",20.90,0.16),
                new GroupingModel("Japan",11.00,0.08),
                new GroupingModel("France",4.40,0.03),
                new GroupingModel("UK",4.30,0.03),
                new GroupingModel ("Canada",4.00,0.03),
                new GroupingModel("Germany",3.70,0.03),
                new GroupingModel("Italy",2.90,0.02),
                new GroupingModel("KY",2.70,0.02),
                new GroupingModel("Brazil",2.40,0.02),
                new GroupingModel("South Korea",2.20,0.02),
                new GroupingModel("Australia",2.20,0.02),
                new GroupingModel("Netherlands",1.90,0.01),
                new GroupingModel("Spain",1.90,0.01),
                new GroupingModel("India",1.30,0.01),
                new GroupingModel("Ireland",1.00,0.01),
                new GroupingModel("Mexico",1.00,0.01),
                new GroupingModel("Luxembourg",0.90,0.01),
            };
        }

        public void Dispose()
        {
            if(PieData != null)
                PieData.Clear();

            if (DoughnutData != null)
                DoughnutData.Clear();
        }
    }
}
