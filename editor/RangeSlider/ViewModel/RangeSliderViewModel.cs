#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Tools.Controls;
using System.Windows.Data;
using Syncfusion.Windows.Controls.Input;
using System.Windows.Controls;

namespace syncfusion.editordemos.wpf
{
    public class RangeSliderViewModel : NotificationObject
    {
        #region Properties

        private double startval = 10.0;
        public double StartValue
        {
            get { return startval; }
            set
            {
                startval = value;
                this.RaisePropertyChanged("StartValue");
            }
        }

        private double endval = 20.0;
        public double EndValue
        {
            get { return endval; }
            set
            {
                endval = value;
                this.RaisePropertyChanged("EndValue");
            }
        }

        private ObservableCollection<Syncfusion.Windows.Controls.Input.Items> customCollection = new ObservableCollection<Syncfusion.Windows.Controls.Input.Items>();

        public ObservableCollection<Syncfusion.Windows.Controls.Input.Items> CustomCollection
        {
            get { return customCollection; }
            set { customCollection = value; this.RaisePropertyChanged(() => this.CustomCollection); }
        }

        private ValuePlacement valuePlacement = ValuePlacement.BottomRight;

        public ValuePlacement ValuePlacement
        {
            get { return valuePlacement; }
            set { valuePlacement = value; RaisePropertyChanged("ValuePlacement"); }
        }

        private TickPlacement tickPlacement = TickPlacement.BottomRight;

        public TickPlacement TickPlacement
        {
            get { return tickPlacement; }
            set { tickPlacement = value; RaisePropertyChanged("TickPlacement"); }
        }

        private SliderSnapsTo snapsTo = SliderSnapsTo.None;

        public SliderSnapsTo SnapsTo
        {
            get { return snapsTo; }
            set { snapsTo = value; RaisePropertyChanged("SnapsTo"); }
        }

        #endregion

        #region Constructor
        public RangeSliderViewModel()
        {
            customCollection.Add(new Syncfusion.Windows.Controls.Input.Items() { label = "Min", value = 1000 });
            customCollection.Add(new Syncfusion.Windows.Controls.Input.Items() { label = "Max", value = 5000 });
        }
        #endregion
    }
}
