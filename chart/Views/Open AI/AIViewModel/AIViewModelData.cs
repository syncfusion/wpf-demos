#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    public class AIViewModelData : NotificationObject , IDisposable
    {
        public ObservableCollection<AIModel> RawData { get; set; }

        private ObservableCollection<AIModel> cleanData;
        public ObservableCollection<AIModel> CleanedData
        {
            get { return cleanData; }
            set
            {
                cleanData = value;
                RaisePropertyChanged(nameof(this.CleanedData));
            }
        }

        private bool isBusy;
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }

            set
            {
                isBusy = value;
                RaisePropertyChanged(nameof(this.IsBusy));
            }
        }


        public AIViewModelData()
        {
            IsBusy = false;

            RawData = new ObservableCollection<AIModel>()
            {
                new AIModel{ DateTime = new DateTime(2024, 07, 01, 00, 00, 00), Visitors = 150 },
                new AIModel{ DateTime = new DateTime(2024, 07, 01, 01, 00, 00), Visitors = 160 },
                new AIModel{ DateTime = new DateTime(2024, 07, 01, 02, 00, 00), Visitors = 155 },
                new AIModel{ DateTime = new DateTime(2024, 07, 01, 03, 00, 00), Visitors = double.NaN }, // Missing data
                new AIModel{ DateTime = new DateTime(2024, 07, 01, 04, 00, 00), Visitors = 170 },
                new AIModel{ DateTime = new DateTime(2024, 07, 01, 05, 00, 00), Visitors = 175 },
                new AIModel{ DateTime = new DateTime(2024, 07, 01, 06, 00, 00), Visitors = 145 }, // Missing data
                new AIModel{ DateTime = new DateTime(2024, 07, 01, 07, 00, 00), Visitors = 180 },
                new AIModel{ DateTime = new DateTime(2024, 07, 01, 08, 00, 00), Visitors = 190 },
                new AIModel{ DateTime = new DateTime(2024, 07, 01, 09, 00, 00), Visitors = 185 },
                new AIModel{ DateTime = new DateTime(2024, 07, 01, 10, 00, 00), Visitors = 200 },
                new AIModel{ DateTime = new DateTime(2024, 07, 01, 11, 00, 00), Visitors = double.NaN }, // Missing data
                new AIModel{ DateTime = new DateTime(2024, 07, 01, 12, 00, 00), Visitors = 220 },
                new AIModel{ DateTime = new DateTime(2024, 07, 01, 13, 00, 00), Visitors = 230 },
                new AIModel{ DateTime = new DateTime(2024, 07, 01, 14, 00, 00), Visitors = double.NaN }, // Missing data
                new AIModel{ DateTime = new DateTime(2024, 07, 01, 15, 00, 00), Visitors = 250 },
                new AIModel{ DateTime = new DateTime(2024, 07, 01, 16, 00, 00), Visitors = 260 },
                new AIModel{ DateTime = new DateTime(2024, 07, 01, 17, 00, 00), Visitors = 270 },
                new AIModel{ DateTime = new DateTime(2024, 07, 01, 18, 00, 00), Visitors = double.NaN }, // Missing data
                new AIModel{ DateTime = new DateTime(2024, 07, 01, 19, 00, 00), Visitors = 280 },
                new AIModel{ DateTime = new DateTime(2024, 07, 01, 20, 00, 00), Visitors = 290 },
                new AIModel{ DateTime = new DateTime(2024, 07, 01, 21, 00, 00), Visitors = 300 },
                new AIModel{ DateTime = new DateTime(2024, 07, 01, 22, 00, 00), Visitors = double.NaN }, // Missing data
                new AIModel{ DateTime = new DateTime(2024, 07, 01, 23, 00, 00), Visitors = 320 },
            };

            CleanedData = new ObservableCollection<AIModel>();
            //_ = LoadCleanedDataAsync();
        }

        internal async Task LoadCleanedDataAsync(PreprocessingAzureAIService service)
        {
            CleanedData = await service.GetCleanedData(RawData);
            IsBusy = false;
        }

        public void Dispose()
        {
           if(RawData != null)
                RawData.Clear();

           if(CleanedData != null)
                CleanedData.Clear();
        }
    }
}