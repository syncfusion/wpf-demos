using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;

namespace syncfusion.navigationdemos.wpf
{
    public class TestingViewModel : NotificationObject
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
    }
}