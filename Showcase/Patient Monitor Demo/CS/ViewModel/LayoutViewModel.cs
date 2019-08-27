#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using System.Windows.Input;

namespace PatientDetailsDemo
{
    class LayoutViewModel
    {
        public List<PatientDetails> Model_BlockA
        {
            get;
            set;
        }
        public List<PatientDetails> Model_BlockB 
        {
            get; set;
        }
        public List<PatientDetails> Model_BlockC 
        {
            get; set;
        }
        public List<PatientDetails> TotalList { get; set; }

        public PatientDetails SelectedPatient { get; set; }

        public LayoutViewModel()
        {

            this.Model_BlockA = new List<PatientDetails>();
            this.Model_BlockB = new List<PatientDetails>();
            this.Model_BlockC = new List<PatientDetails>();
            this.TotalList = new List<PatientDetails>();
            this.TotalList = PatientDetails.GetPatientDetails();
            this.SelectedPatient = this.TotalList[3];
            foreach (PatientDetails Patient in TotalList)
            {
                if (Patient.Block == "A")
                {
                    this.Model_BlockA.Add(Patient);
                }
                if (Patient.Block == "B")
                {
                    this.Model_BlockB.Add(Patient);
                }
                if (Patient.Block == "C")
                {
                    this.Model_BlockC.Add(Patient);
                }
            }
        }

        //private ICommand selectionChanged = null;

        //public ICommand SelectionChanged
        //{

        //    get
        //    {

        //        if (selectionChanged != null)
        //            return new PatientSelectedCommand(SelectedPatientObject);
        //        else
        //            return selectionChanged;
        //    }

        //}
    }
}
