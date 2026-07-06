using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.patientmonitor.wpf
{
    public class HealthData
    {
        #region Properties
        public DateTime DateTime
        {
            get;
            set;
        }

        public double Temp
        {
            get;
            set;
        }

        public double RR
        {
            get;
            set;
        }

        public double HR
        {
            get;
            set;
        }

        public double Sat
        {
            get;
            set;
        }

        #endregion
    }
}
