using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.patientmonitor.wpf
{
    public class ChartPoint : NotificationObject
    {
        #region Fields

        private double x;

        private double y;

        #endregion

        #region Constructor
        public ChartPoint(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        #endregion

        #region Properties
        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
                RaisePropertyChanged("X");
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
                RaisePropertyChanged("Y");
            }
        }
        #endregion
    }
}
