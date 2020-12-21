#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace syncfusion.treegriddemos.wpf
{ 
    public class SelectionImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string filePath = @"/syncfusion.demoscommon.wpf;component/Assets/People/";
            var employeeInfo = value as EmployeeInfo;
            if (employeeInfo != null)
            {                
                string name = employeeInfo.FirstName;

                if(name == "Albert") return filePath + "People_Circle31.png";
                else if(name == "Andrew") return filePath + "People_Circle8.png";
                else if(name == "Anne") return filePath + "People_Circle0.png";
                else if (name == "Amy") return filePath + "People_Circle1.png";
                else if (name == "Carla") return filePath + "People_Circle2.png";
                else if (name == "Caroline") return filePath + "People_Circle3.png";
                else if (name == "Emiliya") return filePath + "People_Circle4.png";
                else if (name == "Hawkin") return filePath + "People_Circle32.png";
                else if (name == "Hill") return filePath + "People_Circle6.png";
                else if (name == "Janet") return filePath + "People_Circle18.png";
                else if (name == "John") return filePath + "People_Circle32.png";
                else if (name == "Justin") return filePath + "People_Circle33.png";
                else if (name == "Margaret") return filePath + "People_Circle27.png";
                else if (name == "Maxwell") return filePath + "People_Circle34.png";
                else if (name == "Michael") return filePath + "People_Circle5.png";
                else if (name == "Nancy") return filePath + "People_Circle19.png";
                else if (name == "Oscar") return filePath + "People_Circle35.png";
                else if (name == "Phyllis") return filePath + "People_Circle26.png";
                else if (name == "Robert") return filePath + "People_Circle12.png";
                else if (name == "Sean") return filePath + "People_Circle14.png";
                else if (name == "Seves") return filePath + "People_Circle37.png";
                else if (name == "SIMOB") return filePath + "People_Circle37.png";
                else if (name == "Steven") return filePath + "People_Circle23.png";
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
