#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace syncfusion.chartdemos.wpf
{
    public class EnergyProductionDataSample: INotifyPropertyChanged , IDisposable
    {
        private double horizontalErrorValue;
        private double verticalErrorValue;
        public ObservableCollection<EnergyProduction> EnergyProduction { get; set; }
        public ObservableCollection<EnergyProduction> ThermalExpansions { get; set; }
        public Array ErrorMode
        {
            get { return Enum.GetValues(typeof(ErrorBarMode)); }
        }

        public Array ErrorType
        {
            get { return Enum.GetValues(typeof(ErrorBarType)); }
        }

        public double HorizontalErrorValue
        {
            get { return horizontalErrorValue; }
            set
            {
                if (horizontalErrorValue != value)
                {
                    horizontalErrorValue = value;
                    OnPropertyChanged(nameof(HorizontalErrorValue));
                }
            }
        }

        public double VerticalErrorValue
        {
            get { return verticalErrorValue; }
            set
            {
                if (verticalErrorValue != value)
                {
                    verticalErrorValue = value;
                    OnPropertyChanged(nameof(VerticalErrorValue));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public EnergyProductionDataSample()
        {
            HorizontalErrorValue = 1;
            VerticalErrorValue = 5;
            EnergyProduction = new ObservableCollection<EnergyProduction>()
            {
                new EnergyProduction{Name="IND",Value=24},
                new EnergyProduction{Name="AUS",Value=20},
                new EnergyProduction{Name="USA",Value=35},
                new EnergyProduction{Name="DEU",Value=27},
                new EnergyProduction{Name="ITA",Value=30},
                new EnergyProduction{Name="UK",Value=41},
                new EnergyProduction{Name="RUS",Value=26},
            };

            ThermalExpansions = new ObservableCollection<EnergyProduction>()
            {
                new EnergyProduction{Name="Erbium",Value=8.2,High=3.8},
                new EnergyProduction{Name="Samarium",Value=8.15,High=2.85},
                new EnergyProduction{Name="Yttrium",Value=7.15,High=3.85},
                new EnergyProduction{Name="Carbide",Value=6.45,High=2.95},
                new EnergyProduction{Name="Uranium",Value=7.45,High=3.55},
                new EnergyProduction{Name="Holmium",Value=7.45,High=3.55},
                new EnergyProduction{Name="Thulium",Value=8.45,High=3.55},
                new EnergyProduction{Name="Scandium ",Value=6.35,High=2.15},
                new EnergyProduction{Name="Tin",Value=14.6,High=5.4},
                new EnergyProduction{Name="Gallium",Value=12.2,High=5.8}
            };
        }

        public void Dispose()
        {
            if(EnergyProduction != null)
                EnergyProduction.Clear();

            if(ThermalExpansions != null)
                ThermalExpansions.Clear();
        }
    }

    public class ErrorValues : INotifyPropertyChanged
    {
        private double horizontalErrorValue;
        private double verticalErrorValue;

        public double HorizontalErrorValue
        {
            get { return horizontalErrorValue; }
            set
            {
                if (horizontalErrorValue != value)
                {
                    horizontalErrorValue = value;
                    OnPropertyChanged(nameof(HorizontalErrorValue));
                }
            }
        }

        public double VerticalErrorValue
        {
            get { return verticalErrorValue; }
            set
            {
                if (verticalErrorValue != value)
                {
                    verticalErrorValue = value;
                    OnPropertyChanged(nameof(VerticalErrorValue));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
