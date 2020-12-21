#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections;
using syncfusion.demoscommon.wpf;

namespace syncfusion.calculatedemos.wpf
{
    public class GettingStartedViewModel : INotifyPropertyChanged
    {
        #region Variable Declerations

        public string txtA = "3";
        public string txtB = "5";
        public string txtC = "10";
        public string txtD = "12";
        public string txtGen = string.Empty;
        ObservableCollection<BindList> ListOfFormula = new ObservableCollection<BindList>();
        ObservableCollection<BindList> tempListOfFormula = new ObservableCollection<BindList>();

        #endregion

        #region Constructor
        public GettingStartedViewModel()
        {
            CalcQuick calculate = new CalcQuick();
            foreach (string formula in calculate.Engine.LibraryFunctions.Keys)
            {
                ListOfFormula.Add(new BindList() { Formula = formula });
            }

            tempListOfFormula = new ObservableCollection<BindList>(ListOfFormula.OrderBy(c => c.Formula));
            tempListOfFormula.RemoveAt(0);
            tempListOfFormula.RemoveAt(0);
            tempListOfFormula.RemoveAt(0);
            ListOfFormula = tempListOfFormula;
        }
        #endregion

        #region Properties

        public string TxtA
        {
            get { return txtA; }
            set
            {
                txtA = value;
                OnPropertyChanged("TxtA");
            }
        }

        public string TxtB
        {
            get { return txtB; }
            set
            {
                txtB = value;
                OnPropertyChanged("TxtB");
            }
        }

        public string TxtC
        {
            get { return txtC; }
            set
            {
                txtC = value;
                OnPropertyChanged("TxtC");
            }
        }

        public string TxtD
        {
            get { return txtD; }
            set
            {
                txtD = value;
                OnPropertyChanged("TxtD");
            }
        }

        public string TxtGen
        {
            get { return txtGen; }
            set
            {
                txtGen = value;
                OnPropertyChanged("TxtGen");
            }
        }

        public ObservableCollection<BindList> Items
        {
            get
            {
                return ListOfFormula;
            }
            set
            {
                ListOfFormula = value;
            }
        }

        private object selectedItem = null;
        public object SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        private ICommand compute;
        public ICommand computeCommand
        {
            get
            {
                if (compute == null)
                    compute = new DelegateCommand<object>(ExecuteComputeCommand);
                return compute;
            }
            set
            {
                compute = value;
            }
        }

        #endregion
        //Initialize calculate object
        CalcQuick calculate = new CalcQuick();
        private void ExecuteComputeCommand(object param)
        {
            calculate["A"] = TxtA;
            calculate["B"] = TxtB;
            calculate["C"] = TxtC;
            calculate["D"] = TxtD;
            calculate["Gen"] = TxtGen;

            calculate.SetDirty();

            TxtA = calculate["A"];
            TxtB = calculate["B"];
            TxtC = calculate["C"];
            TxtD = calculate["D"];
            TxtGen = calculate["Gen"];
        }
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
