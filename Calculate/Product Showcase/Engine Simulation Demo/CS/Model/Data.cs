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

namespace XlsFileUsingXlsIO
{
    public class Data
    {
        #region Variable Declerations

        public string sex;
        public string model;
        public string sexYear;
        public string state;

        #endregion

        #region Properties

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public string SexYear
        {
            get { return sexYear; }
            set { sexYear = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }
        #endregion
    }
}
