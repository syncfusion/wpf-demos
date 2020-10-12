#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace syncfusion.cardashboard.wpf.ViewModel
{
    public class CarDashBoardViewModel : NotificationObject
    {
        #region Fields

        Random randomTorque = new Random();
        private bool reverse = false;
        private string temperatureText;
        private double speedTemp = 0;
        private double gear = 1;
        private double _Rpm = 0;
        private double _speed;
        private double _rpm;
        private double _temperature;
        private double _fuel;
        private double _torque;
        private string fuelGaugeText;

        #endregion

        #region Constructor

        public CarDashBoardViewModel()
        {
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            Timer.Tick += timer_Tick;

            Fuel = 100;
            Speed = 0;
            RPM = 0;
            Temperature = 0;
            _torque = 0.3;

            Timer.Start();
        }

        #endregion

        #region Properties

        public DispatcherTimer Timer { get; set; }

        public double Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
                RaisePropertyChanged("Speed");
            }
        }

        public double RPM
        {
            get
            {
                return _rpm;
            }
            set
            {
                _rpm = value;
                RaisePropertyChanged("RPM");
            }
        }

        public double Temperature
        {
            get
            {
                return _temperature;
            }
            set
            {
                _temperature = value;
                TemperatureText = Math.Round(_temperature).ToString();
                RaisePropertyChanged("Temperature");
            }
        }

        public string TemperatureText
        {
            get
            {
                return temperatureText;
            }
            set
            {
                if (temperatureText != value)
                {
                    temperatureText = value;
                    RaisePropertyChanged("TemperatureText");
                }
            }
        }

        public string FuelGaugeText
        {
            get
            {
                return fuelGaugeText;
            }
            set
            {
                if (fuelGaugeText != value)
                {
                    fuelGaugeText = value;
                    RaisePropertyChanged("FuelGaugeText");
                }
            }
        }

        public double Fuel
        {
            get
            {
                return _fuel;
            }
            set
            {
                _fuel = value;
                FuelGaugeText = Math.Round(_fuel).ToString();
                RaisePropertyChanged("Fuel");
            }
        }

        public double Torque
        {
            get
            {
                return _torque;
            }
            set
            {
                _torque = value;
                RaisePropertyChanged("Torque");
            }
        }

        #endregion

        #region Methods

        void ReverseTimer_Tick()
        {
            speedTemp -= .25 * gear * 2;
            Speed = speedTemp;
            if (Speed <= 80)
            {
                reverse = false;
                gear = 2;
            }

        }

        void timer_Tick(object sender, object e)
        {
            if (Fuel > 0 && Temperature < 80)
            {
                if (Temperature > 35)
                {
                    Temperature += .05;
                }
                else
                {
                    Temperature += 1;
                }

                if (RPM >= 6.2)
                {
                    if (gear < 5)
                    {
                        gear += 1;
                        _Rpm -= 3;
                        RPM = _Rpm;
                    }
                    else if (RPM > 6.5)
                    {
                        _Rpm = 6.2;
                        RPM = _Rpm;
                    }
                    else
                    {
                        _Rpm += 0.1;
                        RPM = _Rpm;
                    }
                }
                else
                {
                    _Rpm += 0.1;
                    RPM = _Rpm;
                }


                if (Speed >= 80)
                {

                    if (Speed >= 140 || reverse == true)
                    {
                        //Speed = 80;
                        reverse = true;
                        ReverseTimer_Tick();

                    }
                    else
                    {
                        speedTemp += .25 * gear;
                        Speed = speedTemp;
                    }
                }
                else if (!reverse)
                {
                    speedTemp += .25 * gear;
                    Speed = speedTemp;
                }


            }
            else
            {
                speedTemp = 0;
                Speed = 0;
                _Rpm = 0;
                RPM = 0;
                gear = 1;
                Temperature = 0;
                Torque = 0;
                reverse = false;
                if (Fuel == 0 || Temperature == 85)
                {
                    Fuel = 100;
                    Temperature = 0;
                }
            }
            Fuel -= .25;
            int TorqueMedium = randomTorque.Next(40, 50);
            _torque = Speed / (2 * TorqueMedium);
            Torque = Math.Round(_torque, 1, MidpointRounding.AwayFromZero);
        }

        #endregion       
    }
}
