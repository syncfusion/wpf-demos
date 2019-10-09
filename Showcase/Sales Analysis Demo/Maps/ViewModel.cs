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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
namespace SalesAnalysisDemo
{
    public class ViewModel : INotifyPropertyChanged
    {
        ObservableCollection<SalesByContinet> _models;
        public ObservableCollection<SalesByContinet> Models
        {
            get
            {
                return _models;
            }
            set
            {
                _models = value;
                this.onPropertyChanged(this, "Models");
            }
        }
        ObservableCollection<SalesByCountry> _salesByCountry;
        public ObservableCollection<SalesByCountry> SalesByCountry
        {
            get
            {
                return _salesByCountry;
            }
            set
            {
                _salesByCountry = value;
                this.onPropertyChanged(this, "SalesByCountry");
            }
        }
        object _salesVsTarget;
        public object SalesVsTarget
        {
            get
            {
                return _salesVsTarget;
            }
            set
            {
                _salesVsTarget = value;
                this.onPropertyChanged(this, "SalesVsTarget");
            }
        }
        ObservableCollection<SalesDetail> _total_Sales;
        public ObservableCollection<SalesDetail> Total_Sales
        {
            get
            {
                return _total_Sales;
            }
            set
            {
                _total_Sales = value;
                this.onPropertyChanged(this, "Total_Sales");
            }
        }
        double _salespercentage = 0;
        public double SalesPercentage
        {
            get
            {
                return Math.Round(_salespercentage, 0);
            }
            set
            {
                _salespercentage = value;
                this.onPropertyChanged(this, "SalesPercentage");
            }
        }
        string _salesTarget = "0";
        public string SalesTarget
        {
            get
            {
                return String.Format("{0:C}", Convert.ToInt32(_salesTarget));
            }
            set
            {
                _salesTarget = value;
                this.onPropertyChanged(this, "SalesTarget");
            }
        }
        string _salesTotal = "0";
        public string SalesTotal
        {
            get
            {
                return String.Format("{0:C}", Convert.ToInt32(_salesTotal)); ;
            }
            set
            {
                _salesTotal = value;
                this.onPropertyChanged(this, "SalesTotal");
            }
        }
        DateTime _rangestart = new DateTime(2011, 3, 1);
        public DateTime RangeStart
        {
            get
            {
                return _rangestart;
            }
            set
            {
                _rangestart = value;

               
                this.onPropertyChanged(this, "RangeStart");
            }
        }
        DateTime _rangeend = new DateTime(2011, 5, 1);
        public DateTime RangeEnd
        {
            get
            {
                return _rangeend;
            }
            set
            {
                _rangeend = value;
                #region Maps Data
                this.Total_Sales = SalesDetail.GenerateSalesDetails(_rangestart, _rangeend);
                this.Models = (SalesDetail.GenerateTotalSalesVsTargetListByContinent(this.Total_Sales));


                this.SalesByCountry = (SalesDetail.GenerateTotalSalesVsTargetListByCountry(this.Total_Sales));
                double saletotal = 0, saletarget = 0;
                for (int i = 0; i < Models.Count; i++)
                {
                    this.Models[i].DisplaySalesValue = String.Format("{0:C}", Convert.ToInt32(this.Models[i].Sales.ToString()));
                    saletotal = saletotal + this.Models[i].Sales;
                    saletarget = saletarget + this.Models[i].Target;

                }
                SalesTotal = (Math.Round(saletotal, 0)).ToString();
                SalesTarget = (Math.Round(saletarget, 0)).ToString();
                SalesPercentage = (saletotal / saletarget) * 100;
                #endregion
                this.onPropertyChanged(this, "RangeEnd");
            }
        }
        int _selectedind = 9;
        public int Selectedindex
        {
            get
            {
                return _selectedind;
            }
            set
            {
                _selectedind = value;
                if (value == 0)
                {
                    #region Maps Data
                    this.Total_Sales = SalesDetail.GenerateSalesDetails(new DateTime(2011, 1, 1), new DateTime(2011, 6, 30));
                    this.Models = (SalesDetail.GenerateTotalSalesVsTargetListByContinent(this.Total_Sales));


                    this.SalesByCountry = (SalesDetail.GenerateTotalSalesVsTargetListByCountry(this.Total_Sales));
                    for (int i = 0; i < Models.Count; i++)
                    {
                        this.Models[i].DisplaySalesValue = String.Format("{0:C}", Convert.ToInt32(this.Models[i].Sales.ToString()));
                    }
                    #endregion
                    #region Chart Data
                    SalesVsTarget = SalesDetail.GenerateTotalSalesVsTargetList(SalesDetail.GenerateSalesDetails(new DateTime(2011, 1, 1), new DateTime(2011, 6, 30)));

                    #endregion
                    #region Gauge Data
                    this.SalesVsTarget = SalesDetail.GenerateTotalSalesVsTargetList(SalesDetail.GenerateSalesDetails(new DateTime(2011, 1, 1), new DateTime(2011, 6, 30)));
                    double saletotal = (SalesVsTarget as ObservableCollection<SalesVsTarget>).Sum(s => s.Sales);
                    double saletarget = (SalesVsTarget as ObservableCollection<SalesVsTarget>).Sum(s => s.Target);
                    SalesTotal = (Math.Round(saletotal, 0)).ToString();
                    SalesTarget = (Math.Round(saletarget, 0)).ToString();
                    SalesPercentage = (saletotal / saletarget) * 100;
                    #endregion
                }
                else
                {
                    #region Maps Data
                    this.Total_Sales = SalesDetail.GenerateSalesDetails(new DateTime(2011, 7, 1), new DateTime(2011, 12, 31));
                    this.Models = (SalesDetail.GenerateTotalSalesVsTargetListByContinent(this.Total_Sales));


                    this.SalesByCountry = (SalesDetail.GenerateTotalSalesVsTargetListByCountry(this.Total_Sales));
                    for (int i = 0; i < Models.Count; i++)
                    {
                        this.Models[i].DisplaySalesValue = String.Format("{0:C}", Convert.ToInt32(this.Models[i].Sales.ToString()));
                    }
                    #endregion
                    #region Chart Data
                    SalesVsTarget = SalesDetail.GenerateTotalSalesVsTargetList(SalesDetail.GenerateSalesDetails(new DateTime(2011, 7, 1), new DateTime(2011, 12, 31)));

                    #endregion
                    #region Gauge Data
                    this.SalesVsTarget = SalesDetail.GenerateTotalSalesVsTargetList(SalesDetail.GenerateSalesDetails(new DateTime(2011, 7, 1), new DateTime(2011, 12, 31)));
                    double saletotal = (SalesVsTarget as ObservableCollection<SalesVsTarget>).Sum(s => s.Sales);
                    double saletarget = (SalesVsTarget as ObservableCollection<SalesVsTarget>).Sum(s => s.Target);
                    SalesTotal = (Math.Round(saletotal, 0)).ToString();
                    SalesTarget = (Math.Round(saletarget, 0)).ToString();
                    SalesPercentage = (saletotal / saletarget) * 100;
                    #endregion
                }
                this.onPropertyChanged(this, "Selectedindex");
            }
        }
        ClickCMD cmd;
        public ClickCMD ClickCommand
        {
            get
            {
                if (cmd == null)
                    cmd = new ClickCMD(this);
                return cmd;
            }
            set
            {
                cmd = value;
                this.onPropertyChanged(this, "ClickCommand");
            }
        }
        bool _isButtonEnable;
        public bool IsButtonEnable
        {
            get
            {
                return _isButtonEnable;
            }
            set
            {
                _isButtonEnable = value;
                this.onPropertyChanged(this, "IsButtonEnable");
            }
        }
        string _buttonContent = string.Empty;
        public string ButtonContent
        {
            get
            {
                return _buttonContent;
            }
            set
            {
                _buttonContent = value;
                this.onPropertyChanged(this, "ButtonContent");
            }
        }
        double _zoomFactor = 0;
        public double ZoomFactor
        {
            get
            {
                return _zoomFactor;
            }
            set
            {
                _zoomFactor = value;
                this.onPropertyChanged(this, "ZoomFactor");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(object sender, string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
            }
        }
        public ViewModel()
        {
            this.Models = new ObservableCollection<SalesByContinet>();
            this.SalesByCountry = new ObservableCollection<SalesByCountry>();
            this.SalesVsTarget = new ObservableCollection<SalesVsTarget>();
            this.Selectedindex = 0;
        }
    }


    public class ClickCMD : ICommand
    {
        ViewModel current_VM;
        public ClickCMD(ViewModel VM)
        {
            current_VM = VM;
        }
        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public event EventHandler CanExecuteChanged
        {
            add {}
            remove {}
        }

        public void Execute(object parameter)
        {

        }
    }
    
}
