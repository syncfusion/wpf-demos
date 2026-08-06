using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace syncfusion.patientmonitor.wpf
{
    public class SaturationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PatientDetails patient = value as PatientDetails;

            if (patient != null)
            {
                var val = patient.Saturation + "%";
                //var BP2 = patient.BloodPressure2.ToString();
                return val;
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
