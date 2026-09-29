using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace syncfusion.gaugedemos.wpf
{
    public class MultipleScaleViewModel : NotificationObject
    {
        private double startAngle = 135;

        public double StartAngle
        {
            get 
            {
                return startAngle;
            }
            set 
            {
                startAngle = value;
                RaisePropertyChanged("StartAngle");
            }
        }

        private double sweepAngle = 270;

        public double SweepAngle
        {
            get 
            {
                return sweepAngle; 
            }
            set 
            {
                sweepAngle = value;
                RaisePropertyChanged("SweepAngle");
            }
        }

    }
}
