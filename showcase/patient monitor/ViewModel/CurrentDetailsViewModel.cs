#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using System.ComponentModel;
using System.Windows.Input;
using Syncfusion.UI.Xaml.Charts;
using System.Windows.Threading;
using Syncfusion.Windows.Shared;

namespace syncfusion.patientmonitor.wpf
{
    public class CurrentDetailsViewModel : NotificationObject
    {
        #region Fields

        int tickCount = 0;
        int XVal = 0;
        DispatcherTimer timer;
        PatientDataRandomModel rdModel;
        PatientDetails patientDetails;

        #endregion

        #region Constructor

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
                RaisePropertyChanged("RandomData");
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
                RaisePropertyChanged("RandomData2");
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
                RaisePropertyChanged("RandomData3");
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
                RaisePropertyChanged("SelectedPatientObject");
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

        internal void SwapDataContext()
        {
            var context1 = this.RandomData;
            var context2 = this.RandomData2;
            var context3 = this.RandomData3;

            if (context1 == null)
                return;

            this.RandomData = context3;
            this.RandomData2 = context1;
            this.RandomData3 = context2;
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
    } 
}
