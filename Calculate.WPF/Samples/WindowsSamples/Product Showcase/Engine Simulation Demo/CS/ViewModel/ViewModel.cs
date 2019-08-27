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
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Syncfusion.Calculate;

namespace XlsFileUsingXlsIO
{
    public class ViewModel : INotifyPropertyChanged
    {
        #region API Definitions

        ObservableCollection<Data> ListOfSex = new ObservableCollection<Data>();
        ObservableCollection<Data> ListOfSexYear = new ObservableCollection<Data>();
        ObservableCollection<Data> ListOfModel = new ObservableCollection<Data>();
        ObservableCollection<Data> ListOfState = new ObservableCollection<Data>();

        public int ageRow = 3;
        public int sexRow = 4;
        public int stateRow = 5;
        public int pointsRow = 6;
        public int modelRow = 7;
        public int modelYearRow = 8;
        public int multipleDiscountRow = 9;

        public XlsIOCalcWorkbook calcWB;

        public XlsIOCalcWorkbook CalcWB
        {
            get { return calcWB; }
            set { calcWB = value; }
        }

        public int AgeRow
        {
            get { return ageRow; }
            set
            {
                ageRow = value;
                OnPropertyChanged("AgeRow");
            }
        }

        public int SexRow
        {
            get { return sexRow; }
            set
            {
                sexRow = value;
                OnPropertyChanged("SexRow");
            }

        }
        public int StateRow
        {
            get { return sexRow; }
            set
            {
                sexRow = value;
                OnPropertyChanged("SexRow");
            }
        }
        public int PointsRow
        {
            get { return pointsRow; }
            set
            {
                pointsRow = value;
                OnPropertyChanged("PointsRow");
            }
        }
        public int ModelRow
        {
            get { return modelRow; }
            set
            {
                modelRow = value;
                OnPropertyChanged("ModelRow");
            }
        }
        public int ModelYearRow
        {
            get { return modelYearRow; }
            set
            {
                modelYearRow = value;
                OnPropertyChanged("ModelYearRow");
            }
        }
        public int MultipleDiscountRow
        {
            get { return multipleDiscountRow; }
            set
            {
                multipleDiscountRow = value;
                OnPropertyChanged("MultipleDiscountRow");
            }
        }

        public int age;
        public string cboState;
        public string cboSex;
        public string cboModel;
        public int nPoint;
        public int nModelYear;
        public bool chkDiscount;
        public string txtBAmt;
        public string txtPrice;

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }

        public string CboState
        {
            get { return cboState; }
            set
            {
                cboState = value;
                OnPropertyChanged("CboState");
            }
        }

        public string TxtPrice
        {
            get { return txtPrice; }
            set
            {
                txtPrice = value;
                OnPropertyChanged("TxtPrice");
            }
        }

        public string CboSex
        {
            get { return cboSex; }
            set
            {
                cboSex = value;
                OnPropertyChanged("CboSex");
            }
        }

        public string CboModel
        {
            get { return cboModel; }
            set
            {
                cboModel = value;
                OnPropertyChanged("CboModel");
            }
        }

        public int NPoint
        {
            get { return nPoint; }
            set
            {
                nPoint = value;
                OnPropertyChanged("NPoint");
            }
        }

        public int NModelYear
        {
            get { return nModelYear; }
            set
            {
                nModelYear = value;
                OnPropertyChanged("NModelYear");
            }
        }

        public bool ChkDiscount
        {
            get { return chkDiscount; }
            set
            {
                chkDiscount = value;
                OnPropertyChanged("ChkDiscount");
            }
        }

        public string TxtBAmt
        {
            get { return txtBAmt; }
            set
            {
                txtBAmt = value;
                OnPropertyChanged("TxtBAmt");
            }
        }

        public ObservableCollection<Data> ItemSex
        {
            get
            {
                return ListOfSex;
            }
            set
            {
                ListOfSex = value;
            }
        }

        public ObservableCollection<Data> ItemModel
        {
            get
            {
                return ListOfModel;
            }
            set
            {
                ListOfModel = value;
            }
        }
        public ObservableCollection<Data> ItemSexYear
        {
            get
            {
                return ListOfSexYear;
            }
            set
            {
                ListOfSexYear = value;
            }
        }
        public ObservableCollection<Data> ItemState
        {
            get
            {
                return ListOfState;
            }
            set
            {
                ListOfState = value;
            }
        }

        private ICommand compute;
        public ICommand computeCommand
        {

            get
            {
                if (compute == null)
                    compute = new ComputeCmd(this);
                return compute;
            }
            set
            {
                compute = value;
            }
        }
        #endregion

        #region Constructor
        public ViewModel()
        {
            BindList();
        }
        #endregion 

        #region FindFile Utility
        /// <summary>
        /// Finds a file of the given name in the current directory or sibling "Data" directory.
        /// If file is not found, the parent folder is checked until the file is found. This method
        /// is used by our samples when they load data from a separate "Data" folder.
        /// </summary>
        /// <param name="dataDirName">The name of the "Data" folder.</param>
        /// <param name="fileName">The filename to be searched.</param>
        /// <returns>The full path of the file that was found; an empty string is returned if file is not found.</returns>

        public static string FindFile(string dataDirName, string fileName)
        {
            dataDirName = dataDirName.TrimEnd('\\', '/');
            // Check both in parent folder and Parent\Data folders.
            string dataFileName = dataDirName + "\\" + fileName;
            for (int n = 0; n < 10; n++)
            {
                if (System.IO.File.Exists(fileName))
                {
                    return fileName;
                }
                if (System.IO.File.Exists(dataFileName))
                {
                    return dataFileName;
                }
                fileName = @"..\" + fileName;
                dataFileName = @"..\" + dataFileName;
            }

            return "";
        }
        #endregion
        
        #region Method

        private void Load()
        {
            calcWB = XlsIOCalcWorkbook.CreateFromXLS(@"..\..\..\CarIns.xls");

            this.calcWB.Engine.LockDependencies = false;
            this.calcWB.CalculateAll();
            this.calcWB.Engine.LockDependencies = true;
        }

        //Set the input values into the CalcSheets:
        public void SetSheetInputs()
        {
            CalcSheet inputSheet = this.CalcWB["Inputs"];
            inputSheet[ageRow, 2] = Age;
            inputSheet[sexRow, 2] = CboSex;
            inputSheet[stateRow, 2] = CboState;
            inputSheet[pointsRow, 2] = NPoint;
            inputSheet[modelRow, 2] = CboModel;
            inputSheet[modelYearRow, 2] = NModelYear;
            if (ChkDiscount == true)
                inputSheet[multipleDiscountRow, 2] = "Yes";
            else
                inputSheet[multipleDiscountRow, 2] = "No";
            inputSheet[3, 5] = txtBAmt;
        }

        private void BindList()
        {

            ListOfSex.Add(new Data { Sex = "M" });
            ListOfSex.Add(new Data { Sex = "F" });

            ListOfModel.Add(new Data { Model = "Ford" });
            ListOfModel.Add(new Data { Model = "Chevrolet" });
            ListOfModel.Add(new Data { Model = "Buick" });
            ListOfModel.Add(new Data { Model = "Toyota" });
            ListOfModel.Add(new Data { Model = "BMW" });
            ListOfModel.Add(new Data { Model = "Mercedes" });
            ListOfModel.Add(new Data { Model = "Honda" });
            ListOfModel.Add(new Data { Model = "Hundai" });
            ListOfModel.Add(new Data { Model = "Mitsubishu" });
            ListOfModel.Add(new Data { Model = "Cadilac" });
            ListOfModel.Add(new Data { Model = "Lexis" });


            ListOfSexYear.Add(new Data { SexYear = "2005" });
            ListOfSexYear.Add(new Data { SexYear = "2004" });
            ListOfSexYear.Add(new Data { SexYear = "2003" });
            ListOfSexYear.Add(new Data { SexYear = "2002" });
            ListOfSexYear.Add(new Data { SexYear = "2001" });
            ListOfSexYear.Add(new Data { SexYear = "2000" });
            ListOfSexYear.Add(new Data { SexYear = "1999" });
            ListOfSexYear.Add(new Data { SexYear = "1998" });
            ListOfSexYear.Add(new Data { SexYear = "1997" });
            ListOfSexYear.Add(new Data { SexYear = "1996" });
            ListOfSexYear.Add(new Data { SexYear = "1995" });
            ListOfSexYear.Add(new Data { SexYear = "1994" });
            ListOfSexYear.Add(new Data { SexYear = "1993" });
            ListOfSexYear.Add(new Data { SexYear = "1992" });
            ListOfSexYear.Add(new Data { SexYear = "1991" });
            ListOfSexYear.Add(new Data { SexYear = "1990" });
            ListOfSexYear.Add(new Data { SexYear = "1989" });
            ListOfSexYear.Add(new Data { SexYear = "1988" });
            ListOfSexYear.Add(new Data { SexYear = "1987" });
            ListOfSexYear.Add(new Data { SexYear = "1986" });
            ListOfSexYear.Add(new Data { SexYear = "1985" });
            ListOfSexYear.Add(new Data { SexYear = "1984" });
            ListOfSexYear.Add(new Data { SexYear = "1983" });
            ListOfSexYear.Add(new Data { SexYear = "1982" });
            ListOfSexYear.Add(new Data { SexYear = "1981" });
            ListOfSexYear.Add(new Data { SexYear = "1980" });
            ListOfSexYear.Add(new Data { SexYear = "1979" });
            ListOfSexYear.Add(new Data { SexYear = "1978" });
            ListOfSexYear.Add(new Data { SexYear = "1977" });
            ListOfSexYear.Add(new Data { SexYear = "1976" });
            ListOfSexYear.Add(new Data { SexYear = "1975" });
            ListOfSexYear.Add(new Data { SexYear = "1974" });
            ListOfSexYear.Add(new Data { SexYear = "1973" });
            ListOfSexYear.Add(new Data { SexYear = "1972" });

            ListOfState.Add(new Data { State = "AL" });
            ListOfState.Add(new Data { State = "AK" });
            ListOfState.Add(new Data { State = "AZ" });
            ListOfState.Add(new Data { State = "AR" });
            ListOfState.Add(new Data { State = "CA" });
            ListOfState.Add(new Data { State = "CO" });
            ListOfState.Add(new Data { State = "CT" });
            ListOfState.Add(new Data { State = "DE" });
            ListOfState.Add(new Data { State = "FL" });
            ListOfState.Add(new Data { State = "GA" });
            ListOfState.Add(new Data { State = "HI" });
            ListOfState.Add(new Data { State = "ID" });
            ListOfState.Add(new Data { State = "IL" });
            ListOfState.Add(new Data { State = "IN" });
            ListOfState.Add(new Data { State = "IA" });
            ListOfState.Add(new Data { State = "KA" });
            ListOfState.Add(new Data { State = "KY" });
            ListOfState.Add(new Data { State = "LA" });
            ListOfState.Add(new Data { State = "ME" });
            ListOfState.Add(new Data { State = "MD" });
            ListOfState.Add(new Data { State = "MA" });
            ListOfState.Add(new Data { State = "MI" });
            ListOfState.Add(new Data { State = "MN" });
            ListOfState.Add(new Data { State = "MS" });
            ListOfState.Add(new Data { State = "MO" });
            ListOfState.Add(new Data { State = "MT" });
            ListOfState.Add(new Data { State = "NE" });
            ListOfState.Add(new Data { State = "NV" });
            ListOfState.Add(new Data { State = "NH" });
            ListOfState.Add(new Data { State = "NJ" });
            ListOfState.Add(new Data { State = "NM" });
            ListOfState.Add(new Data { State = "NY" });
            ListOfState.Add(new Data { State = "NC" });
            ListOfState.Add(new Data { State = "ND" });
            ListOfState.Add(new Data { State = "OH" });
            ListOfState.Add(new Data { State = "OK" });
            ListOfState.Add(new Data { State = "OR" });
            ListOfState.Add(new Data { State = "PA" });
            ListOfState.Add(new Data { State = "RI" });
            ListOfState.Add(new Data { State = "SC" });
            ListOfState.Add(new Data { State = "SD" });
            ListOfState.Add(new Data { State = "TN" });
            ListOfState.Add(new Data { State = "TX" });
            ListOfState.Add(new Data { State = "UT" });
            ListOfState.Add(new Data { State = "VT" });
            ListOfState.Add(new Data { State = "VA" });
            ListOfState.Add(new Data { State = "WA" });
            ListOfState.Add(new Data { State = "WV" });
            ListOfState.Add(new Data { State = "WI" });
            ListOfState.Add(new Data { State = "WY" });
        }

        #endregion 

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}
