#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
using System.Windows.Media;
using System.Reflection;
using System.Windows.Input;

namespace StripLinesDemo
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            DateTime dt = new DateTime(2012, 5, 1);
            this.Model = new List<TemperatureDataModel>();
            this.Model.Add(new TemperatureDataModel() { Day = dt, Tempaerature = 70 });
            this.Model.Add(new TemperatureDataModel() { Day = dt.AddDays(1), Tempaerature = 65 });            
            this.Model.Add(new TemperatureDataModel() { Day = dt.AddDays(2), Tempaerature = 77 });
            this.Model.Add(new TemperatureDataModel() { Day = dt.AddDays(4), Tempaerature = 60 });
            this.Model.Add(new TemperatureDataModel() { Day = dt.AddDays(6), Tempaerature = 70 });
            
        }

        private List<TemperatureDataModel> model;
        public List<TemperatureDataModel> Model
        {

            get
            {

                return model;
            }
            set
            {
                model = value;
                OnPropertyChanged("Model");
            }
        }
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property.ToString()));
            }
        }
        #endregion
    }

    public class AddStripLine : ICommand
    {

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            
        }

        #endregion
    }
}
