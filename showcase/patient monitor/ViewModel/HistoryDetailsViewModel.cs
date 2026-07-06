using Syncfusion.UI.Xaml.Charts;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.patientmonitor.wpf
{
    public class HistoryDetailsViewModel : NotificationObject
    {
        #region Fields

        PatientHealthDetails patientDetails;

        #endregion

        #region Constructor

        public HistoryDetailsViewModel()
        {
            patientDetails = new PatientHealthDetails();
        }

        #endregion

        #region Properties

        IList<HealthData> hdetails;
        public IList<HealthData> HealthDetails
        {

            get
            {
                if (hdetails == null)
                    return hdetails = patientDetails.GenerateData();
                else
                    return hdetails;
            }
        }

        public DoubleRange AxisRange4
        {
            get
            {
                return new DoubleRange(36, 106);
            }
        }

        public DoubleRange AxisRange1
        {
            get
            {
                return new DoubleRange(10, 40);
            }
        }

        public DoubleRange AxisRange3
        {
            get
            {
                return new DoubleRange(100, 200);
            }
        }

        public DoubleRange AxisRange2
        {
            get
            {
                return new DoubleRange(40, 100);
            }
        }

        #endregion 
    }
}
