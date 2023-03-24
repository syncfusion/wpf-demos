#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.UI.Xaml.Charts;
using System.Windows;

namespace syncfusion.chartdemos.wpf
{
    public class PatientViewModel
    {
        public Array LabelsIntersectionArray 
        {
            get
            {
                return new string[]
                {
                    "None",
                    "MultipleRows",
                    "Hide",
                    "Auto"
                };
            }
        }

        public PatientViewModel()
        {
            PatientData = new ObservableCollection<Patient>();

            PatientData.Add(new Patient("Johnson Godwin", 176));
            PatientData.Add(new Patient("Peter Jackman", 163.3));
            PatientData.Add(new Patient("James Oliver", 177));
            PatientData.Add(new Patient("Richard Joseph", 168.5));
            PatientData.Add(new Patient("Robert George", 178));
            PatientData.Add(new Patient("Kevin", 165.3));
            PatientData.Add(new Patient("Alvin", 175.3));
            PatientData.Add(new Patient("Charles Darwin", 178));
            PatientData.Add(new Patient("Nikola Tesla", 165.3));
            PatientData.Add(new Patient("Ada Lovelace", 175.3));
            PatientData.Add(new Patient("Marie Curie", 161));
            PatientData.Add(new Patient("Isaac Newton", 179));
            PatientData.Add(new Patient("Pythagoras", 168));
        }

        public ObservableCollection<Patient> PatientData
        {
            get;
            set;
        }
    }
}
