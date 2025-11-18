#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Globalization;
using syncfusion.demoscommon.wpf;
using Microsoft.Extensions.AI;

namespace syncfusion.chartdemos.wpf
{
    public class PreprocessingAzureAIService
    {
        public PreprocessingAzureAIService()
        {

        }

        public async Task<ObservableCollection<AIModel>> GetCleanedData(ObservableCollection<AIModel> rawData)
        {
            ObservableCollection<AIModel> collection = new ObservableCollection<AIModel>();

            var prompt = $"Clean the following e-commerce website traffic data, resolve outliers and fill missing values:\n{string.Join("\n", rawData.Select(d => $"{d.DateTime:yyyy-MM-dd-HH-m-ss}: {d.Visitors}"))} and the output cleaned data should be in the yyyy-MM-dd-HH-m-ss:Value, not required explanations";
            try
            {
                var response = await AISettings.ClientAI.CompleteAsync(prompt);
                return GetCleanedData(response.ToString(), collection);
            }
            catch (Exception)
            {
                return GetDummyData(collection);
            }
        }

        ObservableCollection<AIModel> GetCleanedData(string json, ObservableCollection<AIModel> collection)
        {
            if (string.IsNullOrEmpty(json))
            {
                return new ObservableCollection<AIModel>();
            }

            var lines = json.Split('\n');
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split(':');
                if (parts.Length == 2)
                {
                    var date = DateTime.ParseExact(parts[0].Trim(), "yyyy-MM-dd-HH-m-ss", CultureInfo.InvariantCulture);
                    var high = double.Parse(parts[1].Trim());

                    collection.Add(new AIModel { DateTime = date, Visitors = high });
                }
            }

            return collection;
        }

        private ObservableCollection<AIModel> GetDummyData(ObservableCollection<AIModel> collection)
        {
            return new ObservableCollection<AIModel>() {
                new AIModel { DateTime = new DateTime(2024, 07, 01, 00, 00, 00), Visitors = 150 },
                new AIModel { DateTime = new DateTime(2024, 07, 01, 01, 00, 00), Visitors = 160 },
                new AIModel { DateTime = new DateTime(2024, 07, 01, 02, 00, 00), Visitors = 155 },
                new AIModel { DateTime = new DateTime(2024, 07, 01, 03, 00, 00), Visitors = 162 }, // Missing data
                new AIModel { DateTime = new DateTime(2024, 07, 01, 04, 00, 00), Visitors = 170 },
                new AIModel { DateTime = new DateTime(2024, 07, 01, 05, 00, 00), Visitors = 175 },
                new AIModel { DateTime = new DateTime(2024, 07, 01, 06, 00, 00), Visitors = 145 }, // Missing data
                new AIModel { DateTime = new DateTime(2024, 07, 01, 07, 00, 00), Visitors = 180 },
                new AIModel { DateTime = new DateTime(2024, 07, 01, 08, 00, 00), Visitors = 190 },
                new AIModel { DateTime = new DateTime(2024, 07, 01, 09, 00, 00), Visitors = 185 },
                new AIModel { DateTime = new DateTime(2024, 07, 01, 10, 00, 00), Visitors = 200 },
                new AIModel { DateTime = new DateTime(2024, 07, 01, 11, 00, 00), Visitors = 207 }, // Missing data
                new AIModel { DateTime = new DateTime(2024, 07, 01, 12, 00, 00), Visitors = 220 },
                new AIModel { DateTime = new DateTime(2024, 07, 01, 13, 00, 00), Visitors = 230 },
                new AIModel { DateTime = new DateTime(2024, 07, 01, 14, 00, 00), Visitors = 237 }, // Missing data
                new AIModel { DateTime = new DateTime(2024, 07, 01, 15, 00, 00), Visitors = 250 },
                new AIModel { DateTime = new DateTime(2024, 07, 01, 16, 00, 00), Visitors = 260 },
                new AIModel { DateTime = new DateTime(2024, 07, 01, 17, 00, 00), Visitors = 270 },
                new AIModel { DateTime = new DateTime(2024, 07, 01, 18, 00, 00), Visitors = 277 }, // Missing data
                new AIModel { DateTime = new DateTime(2024, 07, 01, 19, 00, 00), Visitors = 280 },
                new AIModel { DateTime = new DateTime(2024, 07, 01, 20, 00, 00), Visitors = 290 },
                new AIModel { DateTime = new DateTime(2024, 07, 01, 21, 00, 00), Visitors = 300 },
                new AIModel { DateTime = new DateTime(2024, 07, 01, 22, 00, 00), Visitors = 307 }, // Missing data
                new AIModel { DateTime = new DateTime(2024, 07, 01, 23, 00, 00), Visitors = 320 },
          };
        }

        internal bool IsCredentialsValid()
        {
            if (!AISettings.IsCredentialValid)
            {
                AISettings.ShowAISettingsWindow();
            }

            return AISettings.IsCredentialValid;
        }
    }
}