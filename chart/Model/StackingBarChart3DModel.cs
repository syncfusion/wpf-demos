#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    public class StackingBarChart3DModel : NotificationObject
    {
        private double value;

        public StackingBarChart3DModel(double iron, double metal, double plastic, string year)
        {
            Plastic = plastic;
            Year = year;
            Metal = metal;
            Iron = iron;
        }

        public string Year
        {
            get;
            set;
        }

        public double Iron
        {
            get;
            set;
        }

        public double Plastic
        {
            get
            {
                return value;
            }
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    RaisePropertyChanged(nameof(this.Plastic));
                }
            }
        }

        public double Metal
        {
            get;
            set;
        }
    }
}
