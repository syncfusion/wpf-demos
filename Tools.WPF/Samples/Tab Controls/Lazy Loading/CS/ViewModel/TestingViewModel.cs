using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Chart;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;

namespace TabControlExtDemo
{
    public class TestingViewModel :NotificationObject
    {
        ObservableCollection<TestingModel> testing;

        public TestingViewModel()
        {
            this.TestingModels = new ObservableCollection<TestingModel>();
            Random rd = new Random();
            for (int i = 0; i < 250; i++)
            {
                this.TestingModels.Add(new TestingModel() { X = i, Y = rd.Next(0, 100) });
                this.TestingModels.Add(new TestingModel() { X = i, Y = rd.Next(0, 100) });
            }
        }

        public ObservableCollection<TestingModel> TestingModels
        { 
            get
            {
                return testing;
            }
            set
            {
                testing = value;
                RaisePropertyChanged("TestingModel");
            }
        }

        public Array TypesCollection
        {
            get
            {
                return new ChartTypes[] { ChartTypes.FastLine, 
                                                    ChartTypes.FastScatter, 
                                                    ChartTypes.FastColumn,
                                                    ChartTypes.FastBar
                                                    };
            }
        }
    }
}
