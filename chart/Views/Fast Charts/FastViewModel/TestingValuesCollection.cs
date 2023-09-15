#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.wpf
{
    public class TestingValuesCollection
    {
        public TestingValuesCollection()
        {
            this.TestingModel = new ObservableCollection<TestingValues>();
            Random rd = new Random();

            for (int i = 0; i < 50; i++)
            {
                this.TestingModel.Add(new TestingValues()
                {
                    X = i + 1000,
                    Y = rd.Next(40, 50),
                    Y1 = rd.Next(0, 10),
                    Y2 = rd.Next(10, 40),
                    Y3 = rd.Next(20, 40)
                });
            }
        }

        public ObservableCollection<TestingValues> TestingModel { get; set; }
    }

    public class FinancialViewModel
    {
        public ObservableCollection<FinancialDataModel> FinancialData { get; set; }
        public FinancialViewModel()
        {
            DateTime date = new DateTime(2000, 1, 1);

            FinancialData = new ObservableCollection<FinancialDataModel>()
            {
				new FinancialDataModel(date.AddMonths(1), 65.75, 67.27, 65.75, 65.98, 7938200),
				new FinancialDataModel(date.AddMonths(2), 65.98, 65.70, 65.04, 65.11, 10185300),
				new FinancialDataModel(date.AddMonths(3), 65.11, 65.05, 64.26, 64.97, 10835800),
				new FinancialDataModel(date.AddMonths(4), 64.97, 65.16, 64.09, 64.29, 9613400),
				new FinancialDataModel(date.AddMonths(5), 64.29, 62.73, 61.85, 62.44, 17175000),
                new FinancialDataModel(date.AddMonths(6), 62.44, 62.02, 61.29, 61.47, 18040600),
                new FinancialDataModel(date.AddMonths(7), 61.47, 62.75, 61.55, 61.59, 13456300),
                new FinancialDataModel(date.AddMonths(9), 64.64, 64.50, 63.03, 63.28, 8608900),
                new FinancialDataModel(date.AddMonths(10), 63.28, 63.70, 62.70, 63.59, 15025500),
                new FinancialDataModel(date.AddMonths(11), 63.59, 64.45, 63.26, 63.61, 10065800),
				new FinancialDataModel(date.AddMonths(12), 63.61, 64.56, 63.81, 64.52, 6178200),
				new FinancialDataModel(date.AddMonths(13), 64.52, 64.84, 63.66, 63.91, 5478500),
				new FinancialDataModel(date.AddMonths(14), 63.91, 65.30, 64.50, 65.22, 7964300),
				new FinancialDataModel(date.AddMonths(15), 65.22, 65.36, 64.46, 65.06, 5679300),
				new FinancialDataModel(date.AddMonths(16), 65.06, 64.54, 63.56, 63.65, 10758300),
				new FinancialDataModel(date.AddMonths(17), 63.65, 64.03, 63.33, 63.73, 5665900),
				new FinancialDataModel(date.AddMonths(18), 63.73, 63.40, 62.80, 62.83, 5833000),
				new FinancialDataModel(date.AddMonths(19), 62.83, 63.75, 62.96, 63.60, 3500800),
				new FinancialDataModel(date.AddMonths(20), 63.6, 63.64, 62.51, 63.51, 5044700),
				new FinancialDataModel(date.AddMonths(21), 63.51, 64.03, 63.53, 63.76, 4871300),
				new FinancialDataModel(date.AddMonths(22), 63.76, 63.77, 63.01, 63.65, 7040400),
				new FinancialDataModel(date.AddMonths(23), 63.65, 63.95, 63.58, 63.79, 4727800),
				new FinancialDataModel(date.AddMonths(24), 63.79, 63.47, 62.92, 63.25, 6334900),
				new FinancialDataModel(date.AddMonths(25), 63.25, 63.96, 63.21, 63.48, 6823200),
				new FinancialDataModel(date.AddMonths(26), 63.48, 63.63, 62.55, 63.50, 9718400),
				new FinancialDataModel(date.AddMonths(27), 63.5, 63.25, 62.82, 62.90, 2827000),
				new FinancialDataModel(date.AddMonths(28), 62.9, 62.34, 62.05, 62.18, 4942700),
				new FinancialDataModel(date.AddMonths(29), 62.18, 62.86, 61.94, 62.81, 4582800),
				new FinancialDataModel(date.AddMonths(30), 62.81, 63.06, 62.44, 62.83, 12423900),
				new FinancialDataModel(date.AddMonths(31), 62.83, 63.16, 62.66, 63.09, 4940500),
				new FinancialDataModel(date.AddMonths(32), 63.09, 62.89, 62.43, 62.66, 6132300),
				new FinancialDataModel(date.AddMonths(33), 62.66, 62.39, 61.90, 62.25, 6263800),
				new FinancialDataModel(date.AddMonths(34), 62.25, 61.69, 60.97, 61.50, 5008300),
				new FinancialDataModel(date.AddMonths(35), 61.5, 61.87, 61.18, 61.79, 6662500),
				new FinancialDataModel(date.AddMonths(36), 61.79, 63.41, 62.72, 63.16, 5254000),
				new FinancialDataModel(date.AddMonths(37), 63.16, 64.40, 63.65, 63.89, 5356600),
				new FinancialDataModel(date.AddMonths(39), 61.87, 62.35, 61.30, 61.54, 6266700),
				new FinancialDataModel(date.AddMonths(40), 61.54, 61.49, 60.33, 61.06, 6190800),
				new FinancialDataModel(date.AddMonths(41), 61.06, 60.78, 59.84, 60.09, 6452300),
				new FinancialDataModel(date.AddMonths(42), 60.09, 59.62, 58.62, 58.80, 5954000),
				new FinancialDataModel(date.AddMonths(43), 58.8, 59.60, 58.89, 59.53, 6250000),
				new FinancialDataModel(date.AddMonths(44), 59.53, 60.96, 59.42, 60.68, 5307300),
				new FinancialDataModel(date.AddMonths(45), 60.68, 61.12, 60.65, 60.73, 6192900),
				new FinancialDataModel(date.AddMonths(46), 60.73, 61.19, 60.62, 61.19, 6355600),
				new FinancialDataModel(date.AddMonths(47), 61.19, 61.07, 60.54, 60.97, 2946300),
				new FinancialDataModel(date.AddMonths(48), 60.97, 61.05, 59.65, 59.75, 2257600),
				new FinancialDataModel(date.AddMonths(50), 59.93, 60.12, 59.26, 59.73, 2737500),
				new FinancialDataModel(date.AddMonths(51), 59.73, 60.11, 59.35, 59.57, 2589700),
				new FinancialDataModel(date.AddMonths(52), 59.57, 60.40, 59.60, 60.10, 7315800),
				new FinancialDataModel(date.AddMonths(53), 60.1, 60.31, 59.76, 60.28, 6883900),
				new FinancialDataModel(date.AddMonths(54), 60.28, 61.68, 60.50, 61.50, 5570700),
				new FinancialDataModel(date.AddMonths(55), 61.5, 62.72, 61.64, 62.26, 5976000),
				new FinancialDataModel(date.AddMonths(56), 62.26, 64.08, 63.10, 63.70, 3641400),
				new FinancialDataModel(date.AddMonths(57), 63.7, 64.60, 63.99, 64.39, 6711600),
				new FinancialDataModel(date.AddMonths(58), 64.39, 64.45, 63.92, 64.25, 6427000),
				new FinancialDataModel(date.AddMonths(59), 64.25, 65.40, 64.66, 64.70, 5863200),
				new FinancialDataModel(date.AddMonths(60), 64.7, 65.86, 65.32, 65.75, 4711400),
				new FinancialDataModel(date.AddMonths(61), 65.75, 65.22, 64.63, 64.75, 5930600),
				new FinancialDataModel(date.AddMonths(62), 64.75, 65.39, 64.76, 65.04, 5602700),
				new FinancialDataModel(date.AddMonths(63), 65.04, 65.30, 64.78, 65.18, 7487300),
				new FinancialDataModel(date.AddMonths(64), 65.18, 65.09, 64.42, 65.09, 9085400),
				new FinancialDataModel(date.AddMonths(65), 65.09, 65.64, 65.20, 65.25, 6455300),
				new FinancialDataModel(date.AddMonths(66), 65.25, 65.59, 64.74, 64.84, 6135500),
				new FinancialDataModel(date.AddMonths(67), 64.84, 65.84, 65.42, 65.82, 5846400),
				new FinancialDataModel(date.AddMonths(68), 65.82, 66.75, 65.85, 66.00, 6681200),
				new FinancialDataModel(date.AddMonths(69), 66, 67.41, 66.17, 67.41, 8780000),
				new FinancialDataModel(date.AddMonths(70), 67.41, 68.61, 68.06, 68.41, 10780900),
				new FinancialDataModel(date.AddMonths(71), 68.41, 68.91, 68.42, 68.76, 2336450),
				new FinancialDataModel(date.AddMonths(72), 68.76, 69.58, 68.86, 69.01, 11902000),
				new FinancialDataModel(date.AddMonths(73), 69.01, 69.14, 68.74, 68.94, 7513300),
				new FinancialDataModel(date.AddMonths(74), 68.94, 68.73, 68.06, 68.65, 12074800),
				new FinancialDataModel(date.AddMonths(75), 68.65, 68.79, 68.19, 68.67, 8785400),
				new FinancialDataModel(date.AddMonths(76), 68.67, 69.75, 68.68, 68.74, 11373200),
				new FinancialDataModel(date.AddMonths(77), 68.74, 68.82, 67.71, 67.76, 12378300),
				new FinancialDataModel(date.AddMonths(78), 67.76, 69.05, 68.43, 69.00, 8458700),
				new FinancialDataModel(date.AddMonths(79), 69, 68.39, 67.77, 68.02, 10779200),
				new FinancialDataModel(date.AddMonths(80), 68.02, 67.94, 67.22, 67.72, 9665400),
				new FinancialDataModel(date.AddMonths(81), 67.72, 68.15, 67.32, 67.32, 12258400),
				new FinancialDataModel(date.AddMonths(82), 67.32, 67.95, 67.13, 67.32, 7563600),
				new FinancialDataModel(date.AddMonths(83), 67.32, 68.00, 67.16, 67.96, 5509900),
				new FinancialDataModel(date.AddMonths(84), 67.96, 68.89, 68.34, 68.61, 12135500),
				new FinancialDataModel(date.AddMonths(85), 68.61, 69.47, 68.30, 68.51, 8462000),
				new FinancialDataModel(date.AddMonths(86), 68.51, 68.69, 68.21, 68.62, 2011950),
				new FinancialDataModel(date.AddMonths(87), 68.62, 68.39, 65.80, 68.37, 8536800),
				new FinancialDataModel(date.AddMonths(89), 67.62, 67.04, 65.04, 67.00, 13694600),
				new FinancialDataModel(date.AddMonths(90), 66, 66.83, 65.02, 67.60, 8911200),
				new FinancialDataModel(date.AddMonths(92), 66.73, 66.84, 65.10, 66.11, 6451900),
				new FinancialDataModel(date.AddMonths(93), 66.11, 66.59, 65.69, 66.38, 6739100),
				new FinancialDataModel(date.AddMonths(94), 66.38, 67.98, 66.51, 67.67, 2103260),
				new FinancialDataModel(date.AddMonths(95), 67.67, 69.21, 68.59, 68.90, 10551800),
				new FinancialDataModel(date.AddMonths(96), 68.9, 69.96, 69.27, 69.44, 5261100),
				new FinancialDataModel(date.AddMonths(97), 69.44, 69.01, 68.14, 68.18, 5905400),
				new FinancialDataModel(date.AddMonths(98), 68.18, 68.93, 68.08, 68.14, 10283600),
				new FinancialDataModel(date.AddMonths(99), 68.14, 68.60, 66.92, 67.25, 5006800),
				new FinancialDataModel(date.AddMonths(100), 67.25, 67.77, 67.23, 67.77, 4110000)
			};
        }
    }
}