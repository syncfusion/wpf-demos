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
    public class BubbleChartViewModel
    {
        public ObservableCollection<BubbleChartModel> GDPGrowthCollection { get; set; }
        public ObservableCollection<BubbleChartModel> ActionData { get; set; }
        public ObservableCollection<BubbleChartModel> HorrorData { get; set; }
        public ObservableCollection<BubbleChartModel> ScienceFictionData { get; set; }
        public ObservableCollection<BubbleChartModel> ThrillerData { get; set; }

        public BubbleChartViewModel()
        {
            //Default Bubble
            GDPGrowthCollection = new ObservableCollection<BubbleChartModel>()
        {
         new BubbleChartModel("China",96.8,15133.9,1.41),
         new BubbleChartModel("India",74.3,6436.1,1.36),
         new BubbleChartModel( "Indonesia", 95.6, 11397.4, 0.26),
         new BubbleChartModel( "Italy", 99.1, 42045.9, 0.06),
         new BubbleChartModel( "Malaysia", 94.8, 26835.8, 0.03),
         new BubbleChartModel( "Romania", 98.8, 28741.2, 0.02),
         new BubbleChartModel( "Russia", 99.7, 26656.4, 0.14),
         new BubbleChartModel( "Mexico", 95.3, 20278.2, 0.12),
         new BubbleChartModel( "Uganda", 76.5, 2186.9, 0.04),
         new BubbleChartModel( "Nigeria", 62, 5089.7, 0.19),
         new BubbleChartModel( "Algeria", 81.4, 11725.8, 0.04),
         new BubbleChartModel( "Greece", 97.9, 29141.1, 0.01),
         new BubbleChartModel( "Jordan", 98.2, 9584.5, 0.01),
         new BubbleChartModel( "Colombia", 95, 14426.4, 0.04),
         new BubbleChartModel( "Mongolia", 98.4, 12052.2, 0.003),
         new BubbleChartModel( "Brazil", 93.2, 14619.5, 0.21),
         new BubbleChartModel( "Nepal", 67.9, 3719.3, 0.02),
         new BubbleChartModel( "Sudan", 60.6, 4349.2, 0.04),
        };
            //Gradient Bubble
            ActionData = new ObservableCollection<BubbleChartModel>()
        {
                new BubbleChartModel("Transformers II",150, 836.2,369.4,6),
                new BubbleChartModel("Skyfall",200,1108.5,599.4,7.7),
                new BubbleChartModel("The Avengers",220,1519.5,1205,8),
                new BubbleChartModel("Spider-Man 3",258,890.8,470.9,6.2),
                new BubbleChartModel("Transformers III",195,1123.7,370.6,6.2),
                new BubbleChartModel("The Dark Knight Rises",250,1084.9,1418.2,8.4),
                new BubbleChartModel("The Dark Knight",185,1004.5,2127.2,9),
                new BubbleChartModel("Inception",160,825.5,1888.1,8.8),
        };

            HorrorData = new ObservableCollection<BubbleChartModel>()
        {
                new BubbleChartModel("Interview with the Vampire",60,223.6,83.2, 6.9),
                new BubbleChartModel("Scream",14,173,267.5,7.2),
                new BubbleChartModel("I Know What You Did Last Summer", 17,125.5, 125.9,5.7),
                new BubbleChartModel("The Ring", 48,249.3, 303.3,7.1),
                new BubbleChartModel("Van Helsing", 160,300.2,232.8,6.1),
                new BubbleChartModel("Scream 2", 24,172.3, 147.6,6.2),
                new BubbleChartModel("The Conjuring", 13,318,410.3,7.5),
                new BubbleChartModel("Flatliners",26,61.4,76.1,6.6),
        };

            ScienceFictionData = new ObservableCollection<BubbleChartModel>()
        {
                new BubbleChartModel("Armageddon",140,553.8,376.7,6.7),
                new BubbleChartModel("Star Wars : Episode I",115,924.3,667.3,6.5),
                new BubbleChartModel("Star Wars : Episode II",120,649.3,587.3,6.6),
                new BubbleChartModel("The Matrix Reloaded", 150,738.6,487.3,7.2),
                new BubbleChartModel("Star Wars : Episode III", 113,850,653.7,7.5),
                new BubbleChartModel("War of the Worlds", 132, 591.7,394,6.5),
                new BubbleChartModel("World War Z", 200,531.8, 564,7),
                new BubbleChartModel("Dawn of the Planet of the Apes", 170,710.6,395.4,7.6),
        };

            ThrillerData = new ObservableCollection<BubbleChartModel>()
        {
                new BubbleChartModel("Men in Black",90, 589.3,486.9,7.3),
                new BubbleChartModel("Godzilla",130,379,174.6,5.4),
                new BubbleChartModel("The Sixth Sense",40,672.8,860,8.1),
                new BubbleChartModel("Ocean's Eleven",85,450.7,482.3,7.8),
                new BubbleChartModel("Terminator 3",200,435,357.1,6.3),
                new BubbleChartModel("Casino Royale",150,599,546.9,8),
                new BubbleChartModel("Live Free or Die Hard",110, 383.5,375,7.1),
                new BubbleChartModel("Clash of the Titans",125,493.2,260,5.8),
                new BubbleChartModel("Mission : Impossible",145, 694.7,434.8,7.4),
                new BubbleChartModel("Godzilla",160,529,359.4,6.4),
        };
        }
    }
}
