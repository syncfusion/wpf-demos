#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CarDashBoard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Page mainPage;
       public Frame frame;
         Random r = new Random();
         public bool reverse = false;
        private DispatcherTimer timer;
        public double _Speed = 0;
        public double gear = 1;
        public double _Rpm = 0;
        public MainWindow()
        {
            this.InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0,50);
            timer.Tick += timer_Tick;
            
            Fuel = 100;
            Speed = 0;
            RPM = 0;
            Temperature = 0;
            _torque = 0.3;
            this.DataContext = this;
        }   
        
      
        void ReverseTimer_Tick()
        {
            _Speed -= .25 * gear*2;
            Speed = _Speed;
            if (Speed <=80)
            {
                reverse = false;
                gear = 2;
            }

        }
        static double GenRand(double one, double two)
        {
            Random rand = new Random();
            return one + rand.NextDouble() * (two - one);
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
                        _Speed += .25 * gear;
                        Speed = _Speed;
                    }
                }
                else if(!reverse)
                {
                    _Speed += .25 * gear;
                    Speed = _Speed;
                }
               
                
            }
            else
            {
                _Speed = 0;
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
            int TorqueMedium = r.Next(40, 50);
            _torque = Speed / (2*TorqueMedium);
            Torque = Math.Round(_torque, 1, MidpointRounding.AwayFromZero);
        }

        public double _speed;
        public double Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
                this.onPropertyChanged(this, "Speed");
            }
        }



        public double _RPM;
        public double RPM
        {
            get
            {
                return _RPM;
            }
            set
            {
                _RPM = value;
                this.onPropertyChanged(this, "RPM");
            }
        }

        public double _temperature;
        public double Temperature
        {
            get
            {
                return _temperature;
            }
            set
            {
                _temperature = value;
                this.onPropertyChanged(this, "Temperature");
            }
        }

        public double _fuel;
        public double Fuel
        {
            get
            {
                return _fuel;
            }
            set
            {
                _fuel = value;
                this.onPropertyChanged(this, "Fuel");
            }
        }

        public double _torque;
        public double Torque
        {
            get
            {
                return _torque;
            }
            set
            {
                _torque = value;
                this.onPropertyChanged(this, "Torque");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(object sender, string propertyName)
        {
            SpeedGauge.Scales[0].Pointers[0].Value = Speed;
            SpeedGauge.Scales[0].Pointers[1].Value = Speed;
            RpmGauge.Scales[0].Pointers[0].Value = RPM;
            RpmGauge.Scales[0].Pointers[1].Value = RPM;
            TempGauge.Scales[0].Pointers[0].Value = Temperature;
            TempTextBlock.Text = Math.Round(Temperature).ToString();
            FuelGauge.Scales[0].Pointers[1].Value = Fuel;
            FuelTextBlock.Text = Math.Round(Fuel).ToString();
            TorqueGauge.Scales[0].Pointers[0].Value = Torque;
            TorqueTextBlock.Text = Torque.ToString();
            if (this.PropertyChanged != null)
            {
                PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
            }
        }
       

        private void TorqueGauge_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

      
    }
    }

