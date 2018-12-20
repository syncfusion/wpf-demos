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
using System.Windows.Data;
using System.Windows.Input;
using Syncfusion.Windows.Chart;

namespace LinqDataBindingDemo
{
    public class DataViewModel : INotifyPropertyChanged
    {

        public DataViewModel()
        {
            this.CarDetails = new List<CarModelDetails>();
            GenerateData();
        }

        private void GenerateData()
        {
            CarDetails.Add(new CarModelDetails("Beetle", 36700, 178, 28));
            CarDetails.Add(new CarModelDetails("Fox", 23970, 170, 23));
            CarDetails.Add(new CarModelDetails("Polo", 34675, 160, 22));
            CarDetails.Add(new CarModelDetails("Golf", 44950, 180, 36));
            CarDetails.Add(new CarModelDetails("GolfPlus", 74950, 150, 18));
            CarDetails.Add(new CarModelDetails("Jetta", 37300, 190, 25));
            CarDetails.Add(new CarModelDetails("Passat", 40765, 175, 26));
            CarDetails.Add(new CarModelDetails("Scirocco", 23799, 150, 22));
            CarDetails.Add(new CarModelDetails("Touran", 49400, 160, 29));
            CarDetails.Add(new CarModelDetails("Phaeton", 25149, 165, 22));
        }

        private ICommand modifyCollectionCommand;
        public ICommand ModifyCollectionCommand
        {
            get
            {
                return (new ModifyRecords(this));
            }
        }
        public string[] YPathsCollection
        {
            get
            {
                return (new string[] { "Price", "MaximumSpeed", "Mileage" });
            }
        }

        public string[] OperatorCollection
        {
            get
            {
                return (new string[] { "<", ">", "=" });
            }
        }
        public string selecetdYValue;
        public string SelecetdYValue
        {
            get
            {
                return selecetdYValue;
            }
            set
            {
                selecetdYValue = value;
                OnPropertyChanged("SelecetdYValue");
            }

        }
        public string selectedOperatorkey="<";
        public string SelectedOperatorkey
        {
            get
            {
                return selectedOperatorkey;
            }
            set
            {
                selectedOperatorkey = value;
                OnPropertyChanged("SelectedOperatorkey");
            }

        }

        public string conditionalInput="25000";
        public string ConditionalInput
        {
            get
            {
                return conditionalInput;
            }
            set
            {
                conditionalInput = value;
                OnPropertyChanged("ConditionalInput");
            }

        }

        public List<CarModelDetails> cardetails;
        public List<CarModelDetails> CarDetails
        {
            get
            {
                return cardetails;
            }
            set
            {
                cardetails = value;
                OnPropertyChanged("CarDetails");
            }

        }
        public CarModelDetails selectedItemKey;
        public CarModelDetails SelectedItemKey
        {
            get
            {
                return selectedItemKey;
            }
            set
            {
                selectedItemKey = value;
                OnPropertyChanged("SelectedItemKey");
            }
        }
        public ICommand queryby;
        public ICommand QueryByCommand
        {

            get
            {
                if (queryby == null)
                    queryby = new QueryRecords(this);

                return queryby;
            }
        }
        public ICommand reset;
        public ICommand ResetCommand
        {

            get
            {
                if (reset == null)
                    reset = new ResetRecords(this);

                return reset;
            }
        }

        public class ModifyRecords : ICommand
        {
            private DataViewModel dataModel;
            public ModifyRecords(DataViewModel DataModel)
            {
                dataModel = DataModel;
            }



            #region ICommand Members

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                switch (parameter.ToString())
                {
                    case "Remove":
                        this.dataModel.CarDetails.Remove(dataModel.SelectedItemKey);
                        break;

                }

            }

            #endregion
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property.ToString()));
            }
        }

    }

    public class QueryRecords : ICommand
    {
        private DataViewModel Model;
        //private 
        public QueryRecords(DataViewModel model)
        {
            this.Model = model;
        }
        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            DataViewModel modeldata = new DataViewModel();
            this.Model.CarDetails = modeldata.CarDetails;
            switch (Model.SelectedOperatorkey.ToString())
            {
                case ">":
                    switch (Model.SelecetdYValue)
                    {
                        case "Price":
                            this.Model.CarDetails = (this.Model.CarDetails.Where(s => s.Price > double.Parse(this.Model.ConditionalInput)).ToList());
                            break;
                        case "MaximumSpeed":
                            this.Model.CarDetails = (this.Model.CarDetails.Where(s => s.MaximumSpeed > double.Parse(this.Model.ConditionalInput)).ToList());
                            break;
                        case "Mileage":
                            this.Model.CarDetails = (this.Model.CarDetails.Where(s => s.Mileage > double.Parse(this.Model.ConditionalInput)).ToList());
                            break;
                    }
                    break;
                case "<":
                    switch (Model.SelecetdYValue)
                        {
                            case "Price":
                                this.Model.CarDetails=(this.Model.CarDetails.Where(s => s.Price < double.Parse(this.Model.ConditionalInput)).ToList());
                                break;
                            case "MaximumSpeed":
                                this.Model.CarDetails = (this.Model.CarDetails.Where(s => s.MaximumSpeed < double.Parse(this.Model.ConditionalInput)).ToList());
                                break;
                            case "Mileage":
                                this.Model.CarDetails = (this.Model.CarDetails.Where(s => s.Mileage < double.Parse(this.Model.ConditionalInput)).ToList());
                                break;
                        }
                    break;
                case "=":
                    switch (Model.SelecetdYValue)
                    {
                        case "Price":
                            this.Model.CarDetails = (this.Model.CarDetails.Where(s => s.Price == double.Parse(this.Model.ConditionalInput)).ToList());
                            break;
                        case "MaximumSpeed":
                            this.Model.CarDetails = (this.Model.CarDetails.Where(s => s.MaximumSpeed == double.Parse(this.Model.ConditionalInput)).ToList());
                            break;
                        case "Mileage":
                            this.Model.CarDetails = (this.Model.CarDetails.Where(s => s.Mileage == double.Parse(this.Model.ConditionalInput)).ToList());
                            break;
                    }
                    break;

            }
            if(this.Model.CarDetails.Count==0)
            this.Model.CarDetails = null;
        }

        #endregion
    }
    public class ResetRecords:ICommand
    {
           private DataViewModel Model;
        //private 
           public ResetRecords(DataViewModel model)
        {
            this.Model = model;
        }
        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            DataViewModel modeldata=new DataViewModel();
            this.Model.CarDetails=modeldata.CarDetails;
        }

        #endregion
    }
    public class YPathConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
                return new string[] { value.ToString() };
            else
                return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        #endregion
    }

}
