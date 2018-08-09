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
