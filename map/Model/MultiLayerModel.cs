#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.mapdemos.wpf
{
    public class MultiLayerModel : NotificationObject
    {
        public string NAME { get; set; }

        private Visibility itemsvisibility = Visibility.Visible;
        public Visibility ItemsVisibility
        {
            get { return itemsvisibility; }
            set { itemsvisibility = value; }
        }

        private double weather { get; set; }
        public double Weather
        {
            get
            {
                return weather;
            }
            set
            {
                weather = value;
            }
        }

        private double population { get; set; }
        public double Population
        {
            get
            {
                return population;
            }
            set
            {
                population = value;
                this.PopulationFormat = (String.Format("{0:0,0}", this.Population).Trim('$'));
                RaisePropertyChanged("Population");
            }

        }
        public string PopulationFormat { get; set; }

    }
}
