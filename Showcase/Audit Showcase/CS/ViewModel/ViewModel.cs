#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.PMML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Syncfusion.PMML;
using System.Windows.Input;

namespace Audit_Showcase_sample
{
    public class ViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private int _errors = 0;

        #region Properties

        private List<string> genderCollection = new List<string>();

        public List<string> GenderCollection
        {
            get
            {
                return genderCollection;
            }
            set
            {
                genderCollection = value;
                OnPropertyChanged("GenderCollection");
            }
        }

        private List<string> employmentCollection = new List<string>();

        public List<string> EmploymentCollection
        {
            get
            {
                return employmentCollection;
            }
            set
            {
                employmentCollection = value;
                OnPropertyChanged("EmploymentCollection");
            }
        }

        private List<string> educationCollection = new List<string>();

        public List<string> EducationCollection
        {
            get
            {
                return educationCollection;
            }
            set
            {
                educationCollection = value;
                OnPropertyChanged("EducationCollection");
            }
        }

        private List<string> occupationCollection = new List<string>();

        public List<string> OccupationCollection
        {
            get
            {
                return occupationCollection;
            }
            set
            {
                occupationCollection = value;
                OnPropertyChanged("OccupationCollection");
            }
        }

        private List<string> maritalCollection = new List<string>();

        public List<string> MaritalCollection
        {
            get
            {
                return maritalCollection;
            }
            set
            {
                maritalCollection = value;
                OnPropertyChanged("MaritalCollection");
            }
        }

        private List<string> accountsCollection = new List<string>();

        public List<string> AccountsCollection
        {
            get
            {
                return accountsCollection;
            }
            set
            {
                accountsCollection = value;
                OnPropertyChanged("AccountsCollection");
            }
        }

        private string genderSelectedValue;

        public string GenderSelectedValue
        {
            get
            {
                return genderSelectedValue;
            }
            set
            {
                genderSelectedValue = value;
                OnPropertyChanged("GenderSelectedValue");
            }
        }

        private string employmentSelectedValue;

        public string EmploymentSelectedValue
        {
            get
            {
                return employmentSelectedValue;
            }
            set
            {
                employmentSelectedValue = value;
                OnPropertyChanged("EmploymentSelectedValue");
            }
        }

        private string educationSelectedValue;

        public string EducationSelectedValue
        {
            get
            {
                return educationSelectedValue;
            }
            set
            {
                educationSelectedValue = value;
                OnPropertyChanged("EducationSelectedValue");
            }
        }

        private string occupationSelectedValue;

        public string OccupationSelectedValue
        {
            get
            {
                return occupationSelectedValue;
            }
            set
            {
                occupationSelectedValue = value;
                OnPropertyChanged("OccupationSelectedValue");
            }
        }

        private string maritalSelectedValue;

        public string MaritalSelectedValue
        {
            get
            {
                return maritalSelectedValue;
            }
            set
            {
                maritalSelectedValue = value;
                OnPropertyChanged("MaritalSelectedValue");
            }
        }

        private string accountsSelectedValue;

        public string AccountsSelectedValue
        {
            get
            {
                return accountsSelectedValue;
            }
            set
            {
                accountsSelectedValue = value;
                OnPropertyChanged("AccountsSelectedValue");
            }
        }

        private int ageTextValue = 20;

        public int AgeTextValue
        {
            get
            {
                return ageTextValue;
            }
            set
            {
                ageTextValue = value;
                OnPropertyChanged("AgeTextValue");
            }
        }

        private int incomeTextValue = 20000;

        public int IncomeTextValue
        {
            get
            {
                return incomeTextValue;
            }
            set
            {
                incomeTextValue = value;
                OnPropertyChanged("IncomeTextValue");
            }
        }

        private int deductionTextValue = 10000;

        public int DeductionTextValue
        {
            get
            {
                return deductionTextValue;
            }
            set
            {
                deductionTextValue = value;
                OnPropertyChanged("DeductionTextValue");
            }
        }

        private int hoursTextValue = 12;

        public int HoursTextValue
        {
            get
            {
                return hoursTextValue;
            }
            set
            {
                hoursTextValue = value;
                OnPropertyChanged("HoursTextValue");
            }
        }

        private string auditPredicted;

        public string AuditPredicted
        {
            get
            {
                return auditPredicted;
            }
            set
            {
                auditPredicted = value;
                OnPropertyChanged("AuditPredicted");
            }
        }

        private double auditProbability0;

        public double AuditProbability0
        {
            get
            {
                return auditProbability0;
            }
            set
            {
                auditProbability0 = value;
                OnPropertyChanged("AuditProbability0");
            }
        }

        private double auditProbability1;

        public double AuditProbability1
        {
            get
            {
                return auditProbability1;
            }
            set
            {
                auditProbability1 = value;
                OnPropertyChanged("AuditProbability1");
            }
        }

        private string predictedText;

        public string PredictedText
        {
            get
            {
                return predictedText;
            }
            set
            {
                predictedText = value;
                OnPropertyChanged("PredictedText");
            }
        }

        private string imagePath;

        public string ImagePath
        {
            get
            {
                return imagePath;
            }
            set
            {
                imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }

        #endregion Properties

        #region Command

        private BaseCommand predict;

        public BaseCommand Predict
        {
            get
            {
                if (predict == null)
                {
                    predict = new BaseCommand(PredictMethod);
                }
                return predict;
            }
        }

        #endregion Command

        #region Constructor

        public ViewModel()
        {
            GetComboBoxCollection();
        }

        #endregion Constructor

        #region Methods

        private void PredictMethod(object param)
        {
            PMMLEvaluator evaluator = new PMMLEvaluatorFactory().
                GetPMMLEvaluatorInstance(new PMMLDocument(new MemoryStream(Encoding.ASCII.GetBytes(File.ReadAllText("Data/Audit.pmml")))));

            //Create and anonymous type for audit record
            var audit = new
            {
                ID = 0,
                Age = AgeTextValue,
                Employment = EmploymentSelectedValue,
                Education = EducationSelectedValue,
                Marital = MaritalSelectedValue,
                Occupation = OccupationSelectedValue,
                Income = IncomeTextValue,
                Sex = GenderSelectedValue,
                Deductions = DeductionTextValue,
                Hours = HoursTextValue,
                Accounts = AccountsSelectedValue,
                Adjustment = 0
            };

            //Get predicted result
            PredictedResult predictedResult = evaluator.GetResult(audit, null);

            //Get predicted category 0 or 1
            string predicted = (predictedResult.PredictedValue != null) ? predictedResult.PredictedValue.ToString() : "-";

            //Display result based on predicted category
            ImagePath = predicted == "0" ? "/Images/thumb_yes.png" : "/Images/thumb_no.png";
            AuditPredicted = predicted == "0" ? "YES!" : "NO!";
            PredictedText = predicted == "0" ? "Your audit risk is low." : "Your audit risk is high.";
        }

        private void GetComboBoxCollection()
        {
            GenderCollection.Add("Male");
            GenderCollection.Add("Female");

            EmploymentCollection.Add("Consultant");
            EmploymentCollection.Add("Private");
            EmploymentCollection.Add("PSFederal");
            EmploymentCollection.Add("PSLocal");
            EmploymentCollection.Add("PSState");
            EmploymentCollection.Add("SelfEmp");
            EmploymentCollection.Add("Volunteer");

            EducationCollection.Add("Associate");
            EducationCollection.Add("Bachelor");
            EducationCollection.Add("College");
            EducationCollection.Add("Doctorate");
            EducationCollection.Add("HSgrad");
            EducationCollection.Add("Master");
            EducationCollection.Add("Preschool");
            EducationCollection.Add("Professional");
            EducationCollection.Add("Vocational");
            EducationCollection.Add("Yr9");
            EducationCollection.Add("Yr10");
            EducationCollection.Add("Yr11");
            EducationCollection.Add("Yr12");
            EducationCollection.Add("Yr1t4");
            EducationCollection.Add("Yr5t6");
            EducationCollection.Add("Yr7t8");

            MaritalCollection.Add("Absent");
            MaritalCollection.Add("Divorced");
            MaritalCollection.Add("Married");
            MaritalCollection.Add("Married-spouse-absent");
            MaritalCollection.Add("Unmarried");
            MaritalCollection.Add("Widowed");

            OccupationCollection.Add("Cleaner");
            OccupationCollection.Add("Clerical");
            OccupationCollection.Add("Executive");
            OccupationCollection.Add("Farming");
            OccupationCollection.Add("Home");
            OccupationCollection.Add("Machinist");
            OccupationCollection.Add("Military");
            OccupationCollection.Add("Professional");
            OccupationCollection.Add("Protective");
            OccupationCollection.Add("Repair");
            OccupationCollection.Add("Sales");
            OccupationCollection.Add("Service");
            OccupationCollection.Add("Support");
            OccupationCollection.Add("Transport");

            AccountsCollection.Add("Canada");
            AccountsCollection.Add("China");
            AccountsCollection.Add("Columbia");
            AccountsCollection.Add("Cuba");
            AccountsCollection.Add("Ecuador");
            AccountsCollection.Add("England");
            AccountsCollection.Add("Fiji");
            AccountsCollection.Add("Germany");
            AccountsCollection.Add("Greece");
            AccountsCollection.Add("Guatemala");
            AccountsCollection.Add("Hong");
            AccountsCollection.Add("Hungary");
            AccountsCollection.Add("India");
            AccountsCollection.Add("Indonesia");
            AccountsCollection.Add("Iran");
            AccountsCollection.Add("Ireland");
            AccountsCollection.Add("Italy");
            AccountsCollection.Add("Jamaica");
            AccountsCollection.Add("Japan");
            AccountsCollection.Add("Malaysia");
            AccountsCollection.Add("Mexico");
            AccountsCollection.Add("NewZealand");
            AccountsCollection.Add("Nicaragua");
            AccountsCollection.Add("Philippines");
            AccountsCollection.Add("Poland");
            AccountsCollection.Add("Portugal");
            AccountsCollection.Add("Scotland");
            AccountsCollection.Add("Singapore");
            AccountsCollection.Add("Taiwan");
            AccountsCollection.Add("UnitedStates");
            AccountsCollection.Add("Vietnam");
            AccountsCollection.Add("Yugoslavia");
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;

                if (columnName == "AgeTextValue")
                {
                    if (AgeTextValue <= 17 || AgeTextValue >= 97)
                        result = "Please enter the correct age";
                }
                else if (columnName == "IncomeTextValue")
                {
                    if (IncomeTextValue <= 0)
                        result = "Please enter a valid amount";
                }
                else if (columnName == "HoursTextValue")
                {
                    if (HoursTextValue <= 0)
                        result = "Please enter a valid worked hours";
                }
                else if (columnName == "DeductionTextValue")
                {
                    if (DeductionTextValue < 0)
                        result = "Please enter a valid amount";
                }
                return result;
            }
        }

        #endregion Methods

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);

                handler(this, e);
            }
        }

        #endregion INotifyPropertyChanged
    }
}