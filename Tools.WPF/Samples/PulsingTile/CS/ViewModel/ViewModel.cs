#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;

namespace SfPulsingTile
{
    public class ViewModel :NotificationObject
    {
        public ViewModel()
        {
            radiusvalue = new ObservableCollection<int>();
            pulsevalue = new ObservableCollection<int>();
            pulseduration = new ObservableCollection<int>();
            AddItems();
        }
        

        private ObservableCollection<int> radiusvalue;

        public ObservableCollection<int> RadiusValue
        {
            get
            {
                return radiusvalue;
            }
            set
            {
                radiusvalue = value;
                RaisePropertyChanged("RadiusValue");
            }
        }

        private ObservableCollection<int> pulsevalue;

        public ObservableCollection<int> PulseValue
        {
            get
            {
                return pulsevalue;
            }
            set
            {
                pulsevalue = value;
                RaisePropertyChanged("PulseValue");
            }
        }
        private ObservableCollection<int> pulseduration;

        public ObservableCollection<int> PulseDuration
        {
            get
            {
                return pulseduration;
            }
            set
            {
                pulseduration = value;
                RaisePropertyChanged("PulseDuration");
            }
        }
        private void AddItems()
        {
            for (int i = 0; i <= 5; i++)
            {
                radiusvalue.Add(i);
            }
            for (int i = 1; i <= 3; i++)
            {
                pulsevalue.Add(i);
            }
            for (int i = 1; i <= 8; i++)
            {
                pulseduration.Add(i);
            }
        }
        
    }
}
