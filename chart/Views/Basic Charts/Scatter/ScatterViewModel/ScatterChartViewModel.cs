#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
   public class ScatterChartViewModel
    {
        public ObservableCollection<ScatterModel> MaleData { get; set; }
        public ObservableCollection<ScatterModel> FemaleData { get; set; }

        public ScatterChartViewModel()
        {
            MaleData = new ObservableCollection<ScatterModel>()
            {
                new ScatterModel( 161, 65 ), new ScatterModel( 150,  65 ), new ScatterModel(155,  65 ), new ScatterModel(160, 65 ),
                new ScatterModel( 148, 66 ), new ScatterModel( 145,  66 ), new ScatterModel(137,  66 ), new ScatterModel(138, 66 ),
                new ScatterModel( 162, 66 ), new ScatterModel( 166,  66 ), new ScatterModel(159,  66 ), new ScatterModel(151, 66 ),
                new ScatterModel( 180, 66 ), new ScatterModel( 181,  66 ), new ScatterModel(174,  66 ), new ScatterModel(159, 66 ),
                new ScatterModel( 151, 67 ), new ScatterModel( 148,  67 ), new ScatterModel(141,  67 ), new ScatterModel(145, 67 ),
                new ScatterModel( 165, 67 ), new ScatterModel( 168,  67 ), new ScatterModel(159,  67 ), new ScatterModel(183, 67 ),
                new ScatterModel( 188, 67 ), new ScatterModel( 187,  67 ), new ScatterModel(172,  67 ), new ScatterModel(193, 67 ),
                new ScatterModel( 153, 68 ), new ScatterModel( 153,  68 ), new ScatterModel(147,  68 ), new ScatterModel(163, 68 ),
                new ScatterModel( 174, 68 ), new ScatterModel( 173,  68 ), new ScatterModel(160,  68 ), new ScatterModel(191, 68 ),
                new ScatterModel( 131, 62 ), new ScatterModel( 140,  62 ), new ScatterModel(149,  62 ), new ScatterModel(115, 62 ),
                new ScatterModel( 164, 63 ), new ScatterModel( 162,  63 ), new ScatterModel(167,  63 ), new ScatterModel(146, 63 ),
                new ScatterModel( 150, 64 ), new ScatterModel( 141,  64 ), new ScatterModel(142,  64 ), new ScatterModel(129, 64 ),
                new ScatterModel( 159, 64 ), new ScatterModel( 158,  64 ), new ScatterModel(162,  64 ), new ScatterModel(136, 64 ),
                new ScatterModel( 176, 64 ), new ScatterModel( 170,  64 ), new ScatterModel(167,  64 ), new ScatterModel(144, 64 ),
                new ScatterModel( 143, 65 ), new ScatterModel( 137,  65 ), new ScatterModel(137,  65 ), new ScatterModel(140, 65 ),
                new ScatterModel( 182, 65 ), new ScatterModel( 168,  65 ), new ScatterModel(181,  65 ), new ScatterModel(165, 65 ),
                new ScatterModel( 214, 74 ), new ScatterModel( 211,  74 ), new ScatterModel(166,  74 ), new ScatterModel(185, 74 ),
                new ScatterModel( 189, 68 ), new ScatterModel( 182,  68 ), new ScatterModel(181,  68 ), new ScatterModel(196, 68 ),
                new ScatterModel( 152, 69 ), new ScatterModel( 173,  69 ), new ScatterModel(190,  69 ), new ScatterModel(161, 69 ),
                new ScatterModel( 173, 69 ), new ScatterModel( 185,  69 ), new ScatterModel(141,  69 ), new ScatterModel(149, 69 ),
                new ScatterModel( 134, 62 ), new ScatterModel( 183,  62 ), new ScatterModel(155,  62 ), new ScatterModel(164, 62 ),
                new ScatterModel( 169, 62 ), new ScatterModel( 122,  62 ), new ScatterModel(161,  62 ), new ScatterModel(166, 62 ),
                new ScatterModel( 137, 63 ), new ScatterModel( 140,  63 ), new ScatterModel(140,  63 ), new ScatterModel(126, 63 ),
                new ScatterModel( 150, 63 ), new ScatterModel( 153,  63 ), new ScatterModel(154,  63 ), new ScatterModel(139, 63 ),
                new ScatterModel( 186, 69 ), new ScatterModel( 188,  69 ), new ScatterModel(148,  69 ), new ScatterModel(174, 69 ),
                new ScatterModel( 164, 70 ), new ScatterModel( 182,  70 ), new ScatterModel(200,  70 ), new ScatterModel(151, 70 ),
                new ScatterModel( 204, 74 ), new ScatterModel( 177,  74 ), new ScatterModel(194,  74 ), new ScatterModel(212, 74 ),
                new ScatterModel (162, 70 ), new ScatterModel( 200,  70 ), new ScatterModel(166,  70 ), new ScatterModel(177, 70 ),
                new ScatterModel( 188, 70 ), new ScatterModel( 156,  70 ), new ScatterModel(175,  70 ), new ScatterModel(191, 70 ),
                new ScatterModel( 174, 71 ), new ScatterModel( 187,  71 ), new ScatterModel(208,  71 ), new ScatterModel(166, 71 ),
                new ScatterModel( 150, 71 ), new ScatterModel( 194,  71 ), new ScatterModel(157,  71 ), new ScatterModel(183, 71 ),
                new ScatterModel( 204, 71 ), new ScatterModel( 162,  71 ), new ScatterModel(179,  71 ), new ScatterModel(196, 71 ),
                new ScatterModel( 170, 72 ), new ScatterModel( 184,  72 ), new ScatterModel(197,  72 ), new ScatterModel(162, 72 ),
                new ScatterModel( 177, 72 ), new ScatterModel( 203,  72 ), new ScatterModel(159,  72 ), new ScatterModel(178, 72 ),
                new ScatterModel( 198, 72 ), new ScatterModel( 167,  72 ), new ScatterModel(184,  72 ), new ScatterModel(201, 72 ),
                new ScatterModel( 167, 73 ), new ScatterModel( 178,  73 ), new ScatterModel(215,  73 ), new ScatterModel(207, 73 ),
                new ScatterModel( 172, 73 ), new ScatterModel( 204,  73 ), new ScatterModel(162,  73 ), new ScatterModel(182, 73 ),
                new ScatterModel( 201, 73 ), new ScatterModel( 172,  73 ), new ScatterModel(189,  73 ), new ScatterModel(206, 73 ),
                new ScatterModel( 150, 74 ), new ScatterModel( 187,  74 ), new ScatterModel(153,  74 ), new ScatterModel(171, 74 ),
            };

            FemaleData = new ObservableCollection<ScatterModel>()
            {
                new ScatterModel(115, 57 ), new ScatterModel(138, 57 ), new ScatterModel(166, 57 ), new ScatterModel(122,  57 ),
                new ScatterModel(126, 57 ), new ScatterModel(130, 57 ), new ScatterModel(125, 57 ), new ScatterModel(144,  57 ),
                new ScatterModel(150, 57 ), new ScatterModel(120, 57 ), new ScatterModel(125, 57 ), new ScatterModel(130,  57 ),
                new ScatterModel(103, 58 ), new ScatterModel(116, 58 ), new ScatterModel(130, 58 ), new ScatterModel(126,  58 ),
                new ScatterModel(136, 58 ), new ScatterModel(148, 58 ), new ScatterModel(119, 58 ), new ScatterModel(141,  58 ),
                new ScatterModel(159, 58 ), new ScatterModel(120, 58 ), new ScatterModel(135, 58 ), new ScatterModel(163,  58 ),
                new ScatterModel(119, 59 ), new ScatterModel(131, 59 ), new ScatterModel(148, 59 ), new ScatterModel(123,  59 ),
                new ScatterModel(137, 59 ), new ScatterModel(149, 59 ), new ScatterModel(121, 59 ), new ScatterModel(142,  59 ),
                new ScatterModel(160, 59 ), new ScatterModel(118, 59 ), new ScatterModel(130, 59 ), new ScatterModel(146,  59 ),
                new ScatterModel(119, 60 ), new ScatterModel(133, 60 ), new ScatterModel(150, 60 ), new ScatterModel(133,  60 ),
                new ScatterModel(149, 60 ), new ScatterModel(165, 60 ), new ScatterModel(130, 60 ), new ScatterModel(139,  60 ),
                new ScatterModel(154, 60 ), new ScatterModel(118, 60 ), new ScatterModel(152, 60 ), new ScatterModel(154,  60 ),
                new ScatterModel(130, 61 ), new ScatterModel(145, 61 ), new ScatterModel(166, 61 ), new ScatterModel(131,  61 ),
                new ScatterModel(143, 61 ), new ScatterModel(162, 61 ), new ScatterModel(131, 61 ), new ScatterModel(145,  61 ),
                new ScatterModel(162, 61 ), new ScatterModel(115, 61 ), new ScatterModel(149, 61 ), new ScatterModel(183,  61 ),
                new ScatterModel(121, 62 ), new ScatterModel(139, 62 ), new ScatterModel(159, 62 ), new ScatterModel(135,  62 ),
                new ScatterModel(152, 62 ), new ScatterModel(178, 62 ), new ScatterModel(130, 62 ), new ScatterModel(153,  62 ),
                new ScatterModel(172, 62 ), new ScatterModel(114, 62 ), new ScatterModel(135, 62 ), new ScatterModel(154,  62 ),
                new ScatterModel(126, 63 ), new ScatterModel(141, 63 ), new ScatterModel(160, 63 ), new ScatterModel(135,  63 ),
                new ScatterModel(149, 63 ), new ScatterModel(180, 63 ), new ScatterModel(132, 63 ), new ScatterModel(144,  63 ),
                new ScatterModel(163, 63 ), new ScatterModel(122, 63 ), new ScatterModel(146, 63 ), new ScatterModel(156,  63 ),
                new ScatterModel(133, 64 ), new ScatterModel(150, 64 ), new ScatterModel(176, 64 ), new ScatterModel(133,  64 ),
                new ScatterModel(149, 64 ), new ScatterModel(176, 64 ), new ScatterModel(136, 64 ), new ScatterModel(157,  64 ),
                new ScatterModel(174, 64 ), new ScatterModel(131, 64 ), new ScatterModel(155, 64 ), new ScatterModel(191,  64 ),
                new ScatterModel(136, 65 ), new ScatterModel(149, 65 ), new ScatterModel(177, 65 ), new ScatterModel(143,  65 ),
                new ScatterModel(149, 65 ), new ScatterModel(184, 65 ), new ScatterModel(128, 65 ), new ScatterModel(146,  65 ),
                new ScatterModel(157, 65 ), new ScatterModel(133, 65 ), new ScatterModel(153, 65 ), new ScatterModel(173,  65 ),
                new ScatterModel(141, 66 ), new ScatterModel(156, 66 ), new ScatterModel(175, 66 ), new ScatterModel(125,  66 ),
                new ScatterModel(138, 66 ), new ScatterModel(165, 66 ), new ScatterModel(122, 66 ), new ScatterModel(164,  66 ),
                new ScatterModel(182, 66 ), new ScatterModel(137, 66 ), new ScatterModel(157, 66 ), new ScatterModel(176,  66 ),
                new ScatterModel(149, 67 ), new ScatterModel(159, 67 ), new ScatterModel(179, 67 ), new ScatterModel(156,  67 ),
                new ScatterModel(179, 67 ), new ScatterModel(186, 67 ), new ScatterModel(147, 67 ), new ScatterModel(166,  67 ),
                new ScatterModel(185, 67 ), new ScatterModel(140, 67 ), new ScatterModel(160, 67 ), new ScatterModel(180,  67 ),
                new ScatterModel(145, 68 ), new ScatterModel(155, 68 ), new ScatterModel(170, 68 ), new ScatterModel(129,  68 ),
                new ScatterModel(164, 68 ), new ScatterModel(189, 68 ), new ScatterModel(150, 68 ), new ScatterModel(157,  68 ),
                new ScatterModel(183, 68 ), new ScatterModel(144, 68 ), new ScatterModel(170, 68 ), new ScatterModel(180,  68 )
            };
        }
    }
}



