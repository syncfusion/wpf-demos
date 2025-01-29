#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
    public class ScatterSeriesChart3DViewModel
    {
        public ObservableCollection<ScatterSeriesChart3DModel> TeamA { get; set; }
        public ObservableCollection<ScatterSeriesChart3DModel> TeamB { get; set; }

        public ScatterSeriesChart3DViewModel()
        {
            this.TeamA = new ObservableCollection<ScatterSeriesChart3DModel>()
            {
                new ScatterSeriesChart3DModel(5,152),
                new ScatterSeriesChart3DModel(10,287),
                new ScatterSeriesChart3DModel(15,398),
                new ScatterSeriesChart3DModel(20,143),
                new ScatterSeriesChart3DModel(25,312),
                new ScatterSeriesChart3DModel(30,187),
                new ScatterSeriesChart3DModel(35,147),
                new ScatterSeriesChart3DModel(40,198),
                new ScatterSeriesChart3DModel(45,290),
                new ScatterSeriesChart3DModel(50,350),
                new ScatterSeriesChart3DModel(55,390),
                new ScatterSeriesChart3DModel(60,290),
                new ScatterSeriesChart3DModel(65,182),
                new ScatterSeriesChart3DModel(70,120),
                new ScatterSeriesChart3DModel(75,190),
                new ScatterSeriesChart3DModel(80,280),
                new ScatterSeriesChart3DModel(85,317),
                new ScatterSeriesChart3DModel(90,245),
                new ScatterSeriesChart3DModel(95,319),
                new ScatterSeriesChart3DModel(100,270),
                new ScatterSeriesChart3DModel(105,380),
                new ScatterSeriesChart3DModel(110,300),
                new ScatterSeriesChart3DModel(115,189),
                new ScatterSeriesChart3DModel(120,117),
                new ScatterSeriesChart3DModel(125,301),
                new ScatterSeriesChart3DModel(130,400),
                new ScatterSeriesChart3DModel(135,310),
                new ScatterSeriesChart3DModel(140,385),
                new ScatterSeriesChart3DModel(145,276),
                new ScatterSeriesChart3DModel(150,345),
                new ScatterSeriesChart3DModel(155,118),
                new ScatterSeriesChart3DModel(160,273),
                new ScatterSeriesChart3DModel(162,317),
                new ScatterSeriesChart3DModel(170,211),
                new ScatterSeriesChart3DModel(175,111),
                new ScatterSeriesChart3DModel(180,280),
                new ScatterSeriesChart3DModel(185,182),
                new ScatterSeriesChart3DModel(190,112),
                new ScatterSeriesChart3DModel(195,302),
                new ScatterSeriesChart3DModel(200,216),
                new ScatterSeriesChart3DModel(205,102),
                new ScatterSeriesChart3DModel(210,223),
                new ScatterSeriesChart3DModel(215,152),
            };

            this.TeamB = new ObservableCollection<ScatterSeriesChart3DModel>()
            {
                   new ScatterSeriesChart3DModel(5,312),
                    new ScatterSeriesChart3DModel(10,190),
                    new ScatterSeriesChart3DModel(15,298),
                    new ScatterSeriesChart3DModel(20,171),
                    new ScatterSeriesChart3DModel(25,109),
                    new ScatterSeriesChart3DModel(30,390),
                    new ScatterSeriesChart3DModel(35,290),
                    new ScatterSeriesChart3DModel(40,315),
                    new ScatterSeriesChart3DModel(45,145),
                    new ScatterSeriesChart3DModel(50,284),
                    new ScatterSeriesChart3DModel(55,194),
                    new ScatterSeriesChart3DModel(60,154),
                    new ScatterSeriesChart3DModel(65,396),
                    new ScatterSeriesChart3DModel(70,310),
                    new ScatterSeriesChart3DModel(75,267),
                    new ScatterSeriesChart3DModel(80,179),
                    new ScatterSeriesChart3DModel(85,154),
                    new ScatterSeriesChart3DModel(90,285),
                    new ScatterSeriesChart3DModel(95,184),
                    new ScatterSeriesChart3DModel(100,100),
                    new ScatterSeriesChart3DModel(105,205),
                    new ScatterSeriesChart3DModel(110,390),
                    new ScatterSeriesChart3DModel(115,180),
                    new ScatterSeriesChart3DModel(120,250),
                    new ScatterSeriesChart3DModel(125,194),
                    new ScatterSeriesChart3DModel(130,287),
                    new ScatterSeriesChart3DModel(135,392),
                    new ScatterSeriesChart3DModel(140,312),
                    new ScatterSeriesChart3DModel(145,109),
                    new ScatterSeriesChart3DModel(150,213),
                    new ScatterSeriesChart3DModel(155,309),
                    new ScatterSeriesChart3DModel(160,106),
                    new ScatterSeriesChart3DModel(165,143),
                    new ScatterSeriesChart3DModel(170,111),
                    new ScatterSeriesChart3DModel(175,211),
                    new ScatterSeriesChart3DModel(180,180),
                    new ScatterSeriesChart3DModel(185,382),
                    new ScatterSeriesChart3DModel(190,202),
                    new ScatterSeriesChart3DModel(195,102),
                    new ScatterSeriesChart3DModel(200,276),
                    new ScatterSeriesChart3DModel(205,210),
                    new ScatterSeriesChart3DModel(210,310),
                    new ScatterSeriesChart3DModel(215,390),
            };
        }
    }
}
