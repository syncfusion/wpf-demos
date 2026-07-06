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

namespace syncfusion.mapdemos.wpf
{
    public class BubbleViewModel
    {
        public BubbleViewModel()
        {
            Countries = new ObservableCollection<BubbleModel>();

            Countries.Add(new BubbleModel("China", 1393730000, 18.2));
            Countries.Add(new BubbleModel("India", 1336180000, 17.5));
            Countries.Add(new BubbleModel("United States", 327726000, 4.29));
            Countries.Add(new BubbleModel("Indonesia", 265015300, 3.47));
            Countries.Add(new BubbleModel("Pakistan", 209503000, 2.78));
            Countries.Add(new BubbleModel("Brazil", 201795000, 2.74));
            Countries.Add(new BubbleModel("Nigeria", 197306006, 2.53));
            Countries.Add(new BubbleModel("Bangladesh", 165086000, 2.16));
            Countries.Add(new BubbleModel("Russia", 146877088, 1.92));
            Countries.Add(new BubbleModel("Japan", 126490000, 1.66));
            Countries.Add(new BubbleModel("Mexico", 124737789, 1.63));
            Countries.Add(new BubbleModel("Ethiopia", 107534882, 1.41));
            Countries.Add(new BubbleModel("Philippines", 106375000, 1.39));
            Countries.Add(new BubbleModel("Egypt", 97459100, 1.27));
            Countries.Add(new BubbleModel("Vietnam", 94660000, 1.24));
            Countries.Add(new BubbleModel("Germany", 82740900, 1.08));
            Countries.Add(new BubbleModel("Iran", 81737800, 1.07));
            Countries.Add(new BubbleModel("Turkey", 80810525, 1.06));
            Countries.Add(new BubbleModel("Thailand", 69183173, 0.91));
            Countries.Add(new BubbleModel("France", 67297000, 0.88));
            Countries.Add(new BubbleModel("United Kingdom", 66040229, 0.86));
            Countries.Add(new BubbleModel("Italy", 60436469, 0.79));
            Countries.Add(new BubbleModel("South Africa", 57725600, 0.76));
            Countries.Add(new BubbleModel("Colombia", 49918600, 0.65));
            Countries.Add(new BubbleModel("Spain", 46659302, 0.61));
            Countries.Add(new BubbleModel("Argentina", 44494502, 0.58));
            Countries.Add(new BubbleModel("Poland", 38433600, 0.5));
            Countries.Add(new BubbleModel("Canada", 37206700, 0.48));
            Countries.Add(new BubbleModel("Saudi Arabia", 33413660, 0.44));
            Countries.Add(new BubbleModel("Malaysia", 32647000, 0.42));
            Countries.Add(new BubbleModel("Nepal", 29218867, 0.38));
            Countries.Add(new BubbleModel("Australia", 25015400, 0.32));
            Countries.Add(new BubbleModel("Kazakhstan", 18253300, 0.24));
            Countries.Add(new BubbleModel("Cambodia", 16069921, 0.21));
            Countries.Add(new BubbleModel("Belgium", 11414214, 0.15));
            Countries.Add(new BubbleModel("Greece", 10768193, 0.14));
            Countries.Add(new BubbleModel("Sweden", 10171524, 0.13));
            Countries.Add(new BubbleModel("Somalia", 15181925, 0.12));
            Countries.Add(new BubbleModel("Austria", 8830487, 0.12));
            Countries.Add(new BubbleModel("Bulgaria", 7050034, 0.092));
        }
        public ObservableCollection<BubbleModel> Countries { get; set; }
    }
}
