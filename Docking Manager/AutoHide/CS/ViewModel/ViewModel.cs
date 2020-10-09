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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AutoHideDemo
{
    public class ViewModel : NotificationObject
    {
        private Duration animationDuration;
        public Duration AnimationDuration
        {
            get
            {
                return animationDuration;
            }
            set
            {
                animationDuration = value;
                RaisePropertyChanged("AnimationDuration");
            }
        }
        private bool valueLabel = false;
        public bool ValueLabel
        {
            get
            {
                return valueLabel;
            }
            set
            {
                valueLabel = value;
                RaisePropertyChanged("ValueLabel");
            }
        }
        private bool enableTextBox = false;
        public bool EnableTextBox
        {
            get
            {
                return enableTextBox;
            }
            set
            {
                enableTextBox = value;
                RaisePropertyChanged("EnableTextBox");
            }
        }
        private object selectedItem;
        public object SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
                Animation();           
            }
        }
        
        private ICommand textBox_TextChanged;
        public ICommand TextBox_TextChanged
        {
            get
            {
                return textBox_TextChanged;
            }
            set
            {
                textBox_TextChanged = value;
                RaisePropertyChanged("TextBox_TextChanged");
            }
        }
        private void Animation()
        {
            string selectedText = (SelectedItem as ComboBoxItem).Content.ToString();
            if (selectedText == "Very Slow")
            {               
               AnimationDuration = new Duration(new TimeSpan(30000000));
            }
            else if (selectedText == "Slow")
            {
                AnimationDuration = new Duration(new TimeSpan(10000000));
            }
            else if (selectedText == "Normal")
            {
                AnimationDuration = new Duration(new TimeSpan(5000000));
            }
            else if (selectedText == "Fast")
            {
                AnimationDuration = new Duration(new TimeSpan(1000000));
            }
            else if (selectedText == "Very Fast")
            {
                AnimationDuration = new Duration(new TimeSpan(10000));
            }
            else if (selectedText == "Custom(ms)")
            {
                EnableTextBox = true;
                ValueLabel = true;            
            }
            if (selectedText != "Custom(ms)")
            {
                EnableTextBox = false;
                ValueLabel = false;
            }
        } 

        public ViewModel()
        {
            TextBox_TextChanged = new DelegateCommand<object>(TextChanged);            
        }
        private void TextChanged(object par)
        {
            SetCustomDelay((par as TextBox));
        }
        
        private void SetCustomDelay(TextBox textBox)
        {
            long l;
            if (long.TryParse(textBox.Text, out l))
            {
                l = l* 10000;
                AnimationDuration = new Duration(new TimeSpan(l));
            }
            else
            {
                AnimationDuration = new Duration(TimeSpan.FromMilliseconds(200));
            }
        }
    }
}

