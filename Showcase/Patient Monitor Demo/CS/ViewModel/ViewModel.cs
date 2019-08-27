#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientDetailsDemo;
using System.ComponentModel;
using System.Windows.Input;
using Syncfusion.UI.Xaml.Charts;
using System.Windows.Threading;

namespace PatientDetailsDemo
{
    public class CurrentDetailsViewModel : INotifyPropertyChanged
    {
        #region fields
        int tickCount = 0;
        int XVal = 0;
        DispatcherTimer timer;
        PatientDataRandomModel rdModel;
        PatientDetails patientDetails;
        #endregion

        #region ctor

        public CurrentDetailsViewModel()
        {
            randomData = new ObservableCollection<ChartPoint>();
            randomData2 = new ObservableCollection<ChartPoint>();
            randomData3 = new ObservableCollection<ChartPoint>();
            rdModel = new PatientDataRandomModel();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Tick += timer_Tick;
            timer.Start();

            randomData = rdModel.randomData;
            randomData2 = rdModel.randomData2;
            randomData3 = rdModel.randomData3;
            patientDetails = new PatientDetails();
        }

        #endregion

        #region Properties

        private ObservableCollection<ChartPoint> randomData;

        public ObservableCollection<ChartPoint> RandomData
        {

            get
            {

                return randomData;
            }
            set
            {
                randomData = value;
                OnPropertyChanged("RandomData");
            }
        }

        private ObservableCollection<ChartPoint> randomData2;

        public ObservableCollection<ChartPoint> RandomData2
        {

            get
            {

                return randomData2;
            }
            set
            {
                randomData2 = value;
                OnPropertyChanged("RandomData2");
            }
        }

        private ObservableCollection<ChartPoint> randomData3;

        public ObservableCollection<ChartPoint> RandomData3
        {

            get
            {

                return randomData3;
            }
            set
            {
                randomData3 = value;
                OnPropertyChanged("RandomData3");
            }
        }

        private PatientDetails selectedPatientObject;

        public PatientDetails SelectedPatientObject
        {

            get
            {

                return selectedPatientObject;
            }
            set
            {
                selectedPatientObject = value;
                OnPropertyChanged("SelectedPatientObject");
            }
        }



        #endregion

        #region Methods

        void timer_Tick(object sender, object e)
        {
            AddRandomData();
        }

        public void OnUnLoaded()
        {
            timer.Tick -= timer_Tick;
        }


        private void AddRandomData()
        {
            if (tickCount > rdModel.yValues1.Length - 1)
            {

                tickCount = 0;
            }



            var i=(int)(tickCount % rdModel.yValues1.Length);
            RandomData.Add(new ChartPoint(XVal++, rdModel.yValues1[i]));
            RandomData2.Add(new ChartPoint(XVal++, rdModel.yValues2[i]));
            RandomData3.Add(new ChartPoint(XVal++, rdModel.yValues3[i]));

            RandomData.RemoveAt(0);
            RandomData2.RemoveAt(0);
            RandomData3.RemoveAt(0);
           

            tickCount++;
        }

        #endregion

        #region events
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }


    public class HistoryDetailsViewModel : INotifyPropertyChanged
    {

        #region ctor

        PatientHealthDetails patientDetails;

        public HistoryDetailsViewModel()
        {
            patientDetails = new PatientHealthDetails();
        }
        #endregion

        #region Properties

        IList<HealthData> hdetails;
        public IList<HealthData> HealthDetails
        {

            get
            {
                if (hdetails == null)
                    return hdetails = patientDetails.GenerateData();
                else
                    return hdetails;
            }
        }

        public DoubleRange AxisRange4
        {
            get
            {
                return new DoubleRange(36, 106);
            }
        }

        public DoubleRange AxisRange1
        {
            get
            {
                return new DoubleRange(10, 40);
            }
        }

        public DoubleRange AxisRange3
        {
            get
            {
                return new DoubleRange(100, 200);
            }
        }

        public DoubleRange AxisRange2
        {
            get
            {
                return new DoubleRange(40, 100);
            }
        }

        #endregion

        #region events
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }   

    public class PatientSelectedCommand : ICommand
    {
        PatientDetails selectedRecord;


        public PatientSelectedCommand(PatientDetails SelectedRecord)
        {
            selectedRecord = SelectedRecord;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged 
        {
            add { }
            remove { }
        }
    

        public void Execute(object parameter)
        {
            CurrentDetailsViewModel viewModel = new CurrentDetailsViewModel();
            //CurrentDetailsDemo demo = new CurrentDetailsDemo();
            viewModel.SelectedPatientObject = selectedRecord;
            
        }
    }

}
