using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;

namespace SfRadialSlider
{
    public class RadialSliderProperties : NotificationObject
    {
        private int sliderValue;
        public int SliderValue
        {
            get
            {
                return sliderValue;
            }
            set
            {
                sliderValue = value; RaisePropertyChanged("SliderValue");
            }
        }

        private double pointerFactor = 0.75d;
        public double PointerFactor
        {
            get
            {
                return pointerFactor;
            }
            set
            {
                pointerFactor = value; RaisePropertyChanged("PointerFactor");
            }

        }

    }
}
