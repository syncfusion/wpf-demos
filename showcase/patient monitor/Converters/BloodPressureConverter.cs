using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace syncfusion.patientmonitor.wpf
{
    public class BloodPressureConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PatientDetails patient = value as PatientDetails;

            if (patient != null)
            {
                var BP1 = patient.BloodPressure.ToString();
                var BP2 = patient.BloodPressure2.ToString();
                return BP1 + "/" + BP2;
            }
            else
                return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
