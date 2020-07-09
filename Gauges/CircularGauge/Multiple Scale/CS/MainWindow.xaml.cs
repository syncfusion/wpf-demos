#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Gauges;
using Syncfusion.Windows.SampleLayout;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MultipleScale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            gaugeScale.StartAngle  = gaugeScale1.StartAngle = e.NewValue;
        }

        private void slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            gaugeScale.SweepAngle = gaugeScale1.SweepAngle = e.NewValue;
        }

        private void UpperPointer_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (lowerPointer != null)
                lowerPointer.Value = (e.Value / 240) * 160;
        }

        private void LowerPointer_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (upperPointer != null)
                upperPointer.Value = (e.Value / 160) * 240;
        }

    }

    public class BackgroundColorItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var localEvent = PropertyChanged;
            if (localEvent != null)
            {
                localEvent.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (string.Equals(title, value))
                {
                    return;
                }
                title = value;
                RaisePropertyChanged("Title");
            }
        }

        private Brush brush;
        public Brush Brush
        {
            get
            {
                return brush;
            }
            set
            {
                if (Brush.Equals(brush, value))
                {
                    return;
                }
                brush = value;
                RaisePropertyChanged("Brush");
            }
        }
    }
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            var localEvent = PropertyChanged;
            if (localEvent != null)
            {
                localEvent.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private readonly IList<BackgroundColorItem> items = new ObservableCollection<BackgroundColorItem>();
        public IList<BackgroundColorItem> Items
        {
            get
            {
                return items;
            }
        }

        private readonly IList<BackgroundColorItem> items1 = new ObservableCollection<BackgroundColorItem>();
        public IList<BackgroundColorItem> Items1
        {
            get
            {
                return items1;
            }
        }

        private readonly IList<BackgroundColorItem> items2 = new ObservableCollection<BackgroundColorItem>();
        public IList<BackgroundColorItem> Items2
        {
            get
            {
                return items2;
            }
        }

        private BackgroundColorItem selectedItem;

        public BackgroundColorItem SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                if (Object.Equals(selectedItem, value))
                {
                    return;
                }
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        private BackgroundColorItem selectedItem1;

        public BackgroundColorItem SelectedItem1
        {
            get
            {
                return selectedItem1;
            }
            set
            {
                if (Object.Equals(selectedItem1, value))
                {
                    return;
                }
                selectedItem1 = value;
                RaisePropertyChanged("SelectedItem1");
            }
        }

        private BackgroundColorItem selectedItem2;

        public BackgroundColorItem SelectedItem2
        {
            get
            {
                return selectedItem2;
            }
            set
            {
                if (Object.Equals(selectedItem2, value))
                {
                    return;
                }
                selectedItem2 = value;
                RaisePropertyChanged("SelectedItem2");
            }
        }

        private double sliderValue = 856;
        public double SliderValue
        {
            get
            {
                return sliderValue;
            }
            set
            {
                sliderValue = value;
                RaisePropertyChanged("SliderValue");
            }
        }

        public ViewModel()
        {
            // add the basic items to the ItemCollection during load
            Items.Add(new BackgroundColorItem { Title = "Yellow", Brush = Brushes.Yellow });
            Items.Add(new BackgroundColorItem { Title = "Pink", Brush = Brushes.Pink });
            Items.Add(new BackgroundColorItem { Title = "Green", Brush = Brushes.Green });

            Items1.Add(new BackgroundColorItem { Title = "Black", Brush = Brushes.Black });
            Items1.Add(new BackgroundColorItem { Title = "Gray", Brush = Brushes.Gray });
            Items1.Add(new BackgroundColorItem { Title = "Violet", Brush = Brushes.Violet });
            Items1.Add(new BackgroundColorItem { Title = "Brown", Brush = Brushes.Brown });

            Items2.Add(new BackgroundColorItem { Title = "LightGray", Brush = Brushes.LightGray });
            Items2.Add(new BackgroundColorItem { Title = "Blue", Brush = Brushes.Blue });
            Items2.Add(new BackgroundColorItem { Title = "Orange", Brush = Brushes.Orange });
        }
    }
}
