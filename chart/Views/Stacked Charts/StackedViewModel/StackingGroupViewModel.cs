using System;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    public class StackingGroupViewModel : IDisposable
    {
        public StackingGroupViewModel()
        {
            this.AnnualDetails = new ObservableCollection<StackingGroupModel>();
            AnnualDetails.Add(new StackingGroupModel() { Year = "2009", Quarter1 = 34, Quarter2 = 31, Quarter3 = 29, Quarter4 = 30 });
            AnnualDetails.Add(new StackingGroupModel() { Year = "2010", Quarter1 = 24, Quarter2 = 28, Quarter3 = 32, Quarter4 = 33 });
            AnnualDetails.Add(new StackingGroupModel() { Year = "2011", Quarter1 = 20, Quarter2 = 25, Quarter3 = 25, Quarter4 = 26 });
            AnnualDetails.Add(new StackingGroupModel() { Year = "2012", Quarter1 = 19, Quarter2 = 21, Quarter3 = 23, Quarter4 = 26 });
            AnnualDetails.Add(new StackingGroupModel() { Year = "2013", Quarter1 = 19, Quarter2 = 15, Quarter3 = 17, Quarter4 = 21 });
        }

        public ObservableCollection<StackingGroupModel> AnnualDetails { get; set; }

        public void Dispose()
        {
           if(AnnualDetails != null)
                AnnualDetails.Clear();
        }
    } 
}
