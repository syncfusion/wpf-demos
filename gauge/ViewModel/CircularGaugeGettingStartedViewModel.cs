using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Gauges;

namespace syncfusion.gaugedemos.wpf
{
    public class CircularGaugeGettingStartedViewModel : NotificationObject
    {

        private double circularRangeEndValue;
        private RangePosition rangePosition;
        private LabelPosition labelPosition;
        private TickPosition tickPosition;

        public double CircularRangeEndValue
        {
            get 
            {
                return circularRangeEndValue;
            }
            set 
            { 
                circularRangeEndValue = value;
                RaisePropertyChanged("CircularRangeEndValue");
            }
        }

        public RangePosition RangePosition
        {
            get 
            { 
                return rangePosition; 
            }
            set 
            { 
                rangePosition = value;
                RaisePropertyChanged("RangePosition");
            }
        }

        public LabelPosition LabelPosition
        {
            get 
            { 
                return labelPosition;
            }
            set 
            { 
                labelPosition = value;
                RaisePropertyChanged("LabelPosition");
            }
        }

        public TickPosition TickPosition
        {
            get 
            { 
                return tickPosition; 
            }
            set 
            { 
                tickPosition = value;
                RaisePropertyChanged("TickPosition");
            }
        }


        public CircularGaugeGettingStartedViewModel()
        {
            CircularRangeEndValue = 60;
            RangePosition = RangePosition.SetAsGaugeRim;
            LabelPosition = LabelPosition.Inside;
            TickPosition = TickPosition.Inside;
        }
    }
}
