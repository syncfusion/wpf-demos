using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FormulaSupport
{
    public class BindList: INotifyPropertyChanged
    {
        #region Constructor
        public BindList()
        {
            //this.Formula = string.Empty;
        }
        #endregion 

        public string formula;
        public string Formula
        {
            get { return formula; }
            set { formula = value; }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        public void Onpropertychagned(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}
