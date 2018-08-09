using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Syncfusion.Grouping;
using ISummary = Syncfusion.Collections.BinaryTree.ITreeTableSummary;
using System.Windows.Input;

namespace RandomTest
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            Load();
        }

        //grouping support objects 
        private Syncfusion.Grouping.Table theTable;
        private Syncfusion.Grouping.Engine engine;

        //supports IBindingList
        private IntegerCollection intCollection;

        public Syncfusion.Grouping.Table TheTable
        {
            get { return theTable; }
            set { theTable = value; OnPropertyChanged("TheTable"); }
        }

        public Syncfusion.Grouping.Engine Engine
        {
            get { return engine; }
            set { engine = value; 
                OnPropertyChanged("Engine"); }
        }

        public IntegerCollection IntCollection
        {
            get { return intCollection; }
            set { intCollection = value; 
                OnPropertyChanged("IntCollection"); }
        }
        public void Load()
        {
            //create an integer collection to hold the random numbers
            intCollection = new IntegerCollection();

            //create a new grouping engine and assign it a IList datasource
            engine = new Engine();
            engine.SetSourceList(intCollection);
            engine.RecordAsDisplayElements = true;

            //get a reference to the underlying grouping Table
            theTable = engine.Table;

            //group by the Value
            engine.TableDescriptor.GroupedColumns.Add("Value");

            //add the Summaries that we want
            engine.TableDescriptor.Summaries.Add("Int32Agg", "Value", SummaryType.Int32Aggregate);
            engine.TableDescriptor.Summaries.Add("Vect", "Value", SummaryType.DoubleVector);

        }
        public string lblauto = string.Empty;
        public string lblavg = "";
        public string lblmed = "";
        public string lblpeer25 = "";
        public string lblper75 = "";
        public string lblbuk56 = "";
        public string lblbuk3 = "";
        public string nTimeInTest;
        public string nRefreshrate;

        public string Lblauto
        {
            get { return lblauto; }
            set
            {
                lblauto = value;
                OnPropertyChanged("Lblauto");
            }
        }
        public string Lblavg
        {
            get { return lblavg; }
            set
            {
                lblavg = value;
                OnPropertyChanged("Lblavg");
            }
        }
        public string Lblmed
        {
            get { return lblmed; }
            set
            {
                lblmed = value;
                OnPropertyChanged("Lblmed");
            }
        }
        public string Lblpeer25
        {
            get { return lblpeer25; }
            set
            {
                lblpeer25 = value;
                OnPropertyChanged("Lblpeer25");
            }
        }
        public string Lblper75
        {
            get { return lblper75; }
            set
            {
                lblper75 = value;
                OnPropertyChanged("Lblper75");
            }
        }
        public string Lblbuk56
        {
            get { return lblbuk56; }
            set
            {
                lblbuk56 = value;
                OnPropertyChanged("Lblbuk56");
            }
        }
        public string Lblbuk3
        {
            get { return lblbuk3; }
            set
            {
                lblbuk3 = value;
                OnPropertyChanged("Lblbuk3");
            }
        }
        public string NRefreshrate
        {
            get { return nRefreshrate; }
            set
            {
                nRefreshrate = value;
                OnPropertyChanged("NRefreshrate");
            }
        }

        public string NTimeInTest
        {
            get { return nTimeInTest; }
            set
            {
                nTimeInTest = value;
                OnPropertyChanged("NTimeInTest");
            }
        }
        private ICommand startCmd;
        public ICommand StartCmd
        {
            get
            {
                if (startCmd == null)
                    startCmd = new StartTestCmd(this);
                return startCmd;
            }
            set
            {
                startCmd = value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
