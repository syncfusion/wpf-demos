using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    public class LegendViewModel : ObservableCollection<LegendModel> , IDisposable
    {

        public IList<LegendModel> LegendData1 { get; set; }
        public IList<LegendModel> LegendData2 { get; set; }
        public IList<LegendModel> LegendData3 { get; set; }
        public IList<LegendModel> LegendData4 { get; set; }
        public IList<LegendModel> ToggledLegendData { get; set; }
        public ObservableCollection<LegendModel> Data { get; set; }

        public LegendViewModel()
        {
            // Multiple Legend
            DateTime date = new DateTime(2022, 01, 01);
            Data = new ObservableCollection<LegendModel>();
            Data.Add(new LegendModel() { Months = date, Sales = 15000, Target = 58 });
            Data.Add(new LegendModel() { Months = date.AddMonths(1), Sales = 18000, Target = 83 });
            Data.Add(new LegendModel() { Months = date.AddMonths(2), Sales = 13000, Target = 35 });
            Data.Add(new LegendModel() { Months = date.AddMonths(3), Sales = 17000, Target = 73 });
            Data.Add(new LegendModel() { Months = date.AddMonths(4), Sales = 22000, Target = 95 });
            Data.Add(new LegendModel() { Months = date.AddMonths(5), Sales = 12000, Target = 32 });

            // Customized Legend
            this.LegendData1 = new List<LegendModel>();
            LegendData1.Add(new LegendModel() { Name = "2005", Value = 38 });
            LegendData1.Add(new LegendModel() { Name = "2006", Value = 20 });
            LegendData1.Add(new LegendModel() { Name = "2007", Value = 60 });
            LegendData1.Add(new LegendModel() { Name = "2008", Value = 50 });

            this.LegendData2 = new List<LegendModel>();
            LegendData2.Add(new LegendModel() { Name = "2005", Value = 49 });
            LegendData2.Add(new LegendModel() { Name = "2006", Value = 40 });
            LegendData2.Add(new LegendModel() { Name = "2007", Value = 72 });
            LegendData2.Add(new LegendModel() { Name = "2008", Value = 65 });

            this.LegendData3 = new List<LegendModel>();
            LegendData3.Add(new LegendModel() { Name = "2005", Value = 67 });
            LegendData3.Add(new LegendModel() { Name = "2006", Value = 60 });
            LegendData3.Add(new LegendModel() { Name = "2007", Value = 96 });
            LegendData3.Add(new LegendModel() { Name = "2008", Value = 90 });

            this.LegendData4 = new List<LegendModel>();
            LegendData4.Add(new LegendModel() { Name = "2005", Value = 56 });
            LegendData4.Add(new LegendModel() { Name = "2006", Value = 50 });
            LegendData4.Add(new LegendModel() { Name = "2007", Value = 84 });
            LegendData4.Add(new LegendModel() { Name = "2008", Value = 80 });

            //Toggled Legend
            this.ToggledLegendData = new ObservableCollection<LegendModel>();
            ToggledLegendData.Add(new LegendModel() { Name = "2000", Apple = 0.87, Orange = 0.72, Pear = 0.48, Others = 0.23 });
            ToggledLegendData.Add(new LegendModel() { Name = "2001", Apple = 0.91, Orange = 0.64, Pear = 0.43, Others = 0.17 });
            ToggledLegendData.Add(new LegendModel() { Name = "2002", Apple = 1.01, Orange = 0.71, Pear = 0.47, Others = 0.17 });
            ToggledLegendData.Add(new LegendModel() { Name = "2003", Apple = 0.95, Orange = 0.63, Pear = 0.41, Others = 0.20 });
            ToggledLegendData.Add(new LegendModel() { Name = "2004", Apple = 0.89, Orange = 0.65, Pear = 0.43, Others = 0.23 });
            ToggledLegendData.Add(new LegendModel() { Name = "2005", Apple = 1.09, Orange = 0.76, Pear = 0.54, Others = 0.36 });
            ToggledLegendData.Add(new LegendModel() { Name = "2006", Apple = 1.14, Orange = 0.89, Pear = 0.66, Others = 0.43 });
            ToggledLegendData.Add(new LegendModel() { Name = "2007", Apple = 1.44, Orange = 1.18, Pear = 0.83, Others = 0.52 });
            ToggledLegendData.Add(new LegendModel() { Name = "2008", Apple = 1.66, Orange = 1.34, Pear = 1.09, Others = 0.72 });
            ToggledLegendData.Add(new LegendModel() { Name = "2009", Apple = 1.91, Orange = 1.59, Pear = 1.37, Others = 1.09 });
            ToggledLegendData.Add(new LegendModel() { Name = "2010", Apple = 2.14, Orange = 1.82, Pear = 1.62, Others = 1.38 });
            ToggledLegendData.Add(new LegendModel() { Name = "2011", Apple = 2.73, Orange = 2.35, Pear = 2.13, Others = 1.82 });
            ToggledLegendData.Add(new LegendModel() { Name = "2012", Apple = 3.126, Orange = 2.69, Pear = 2.44, Others = 2.16 });
            ToggledLegendData.Add(new LegendModel() { Name = "2013", Apple = 3.34, Orange = 3.01, Pear = 2.77, Others = 2.51 });
            ToggledLegendData.Add(new LegendModel() { Name = "2014", Apple = 3.58, Orange = 3.22, Pear = 2.91, Others = 2.61 });
        }

        public void Dispose()
        {
            if (LegendData1 != null)
                LegendData1.Clear();

            if (LegendData2 != null)
                LegendData2.Clear();

            if (LegendData3 != null)
                LegendData3.Clear();

            if (LegendData4 != null)
                LegendData4.Clear();

            if (ToggledLegendData != null)
                ToggledLegendData.Clear();

            if (Data != null)
                Data.Clear();

        }
    }
}
