#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.gaugedemos.wpf
{
    public class CustomizationViewModel : NotificationObject
    {
        private readonly IList<CustomizationModel> items = new ObservableCollection<CustomizationModel>();
        public IList<CustomizationModel> Items
        {
            get
            {
                return items;
            }
        }

        private readonly IList<CustomizationModel> items1 = new ObservableCollection<CustomizationModel>();
        public IList<CustomizationModel> Items1
        {
            get
            {
                return items1;
            }
        }

        private readonly IList<CustomizationModel> items2 = new ObservableCollection<CustomizationModel>();
        public IList<CustomizationModel> Items2
        {
            get
            {
                return items2;
            }
        }

        private CustomizationModel selectedItem;

        public CustomizationModel SelectedItem
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

        private CustomizationModel selectedItem1;

        public CustomizationModel SelectedItem1
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

        private CustomizationModel selectedItem2;

        public CustomizationModel SelectedItem2
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

        private double pointerValue = 800;

        public double PointerValue
        {
            get 
            {
                return pointerValue;
            }
            set 
            {
                if (Object.Equals(pointerValue, value))
                {
                    return;
                }

                pointerValue = value;
                RaisePropertyChanged("PointerValue");
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

        public CustomizationViewModel()
        {
            Items.Add(new CustomizationModel { Title = "Yellow", Brush = Brushes.Yellow });
            Items.Add(new CustomizationModel { Title = "Pink", Brush = Brushes.Pink });
            Items.Add(new CustomizationModel { Title = "Green", Brush = Brushes.Green });

            Items1.Add(new CustomizationModel { Title = "DarkGray", Brush = Brushes.DarkGray });
            Items1.Add(new CustomizationModel { Title = "Black", Brush = Brushes.Black });            
            Items1.Add(new CustomizationModel { Title = "Violet", Brush = Brushes.Violet });
            Items1.Add(new CustomizationModel { Title = "Brown", Brush = Brushes.Brown });

            Items2.Add(new CustomizationModel { Title = "LightGray", Brush = Brushes.LightGray });
            Items2.Add(new CustomizationModel { Title = "Blue", Brush = Brushes.Blue });
            Items2.Add(new CustomizationModel { Title = "Orange", Brush = Brushes.Orange });
        }
    }
}
