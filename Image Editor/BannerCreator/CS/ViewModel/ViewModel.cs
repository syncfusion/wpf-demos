#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.ImageEditor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BannerCreator
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ICommand CropCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        private bool isEnabled;

        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;
                OnPropertyChanged("IsEnabled");
            }
        }

        private int index;
        public int SelectedIndex
        {
            get { return index; }
            set
            {
                index = value;
                OnPropertyChanged("SelectedIndex");
            }
        }


        public ViewModel()
        {
            SelectedIndex = 6;
            IsEnabled = false;
            CropCommand = new CustomCommand(new Action<object>(PerformCrop));
            CancelCommand = new CustomCommand(new Action<object>(PerformCancel));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void PerformCancel(object obj)
        {
            var imageEditor = obj as SfImageEditor;
            if (imageEditor == null) return;
            imageEditor.ToggleCropping();
            SelectedIndex = 6;
        }

        private void PerformCrop(object obj)
        {
            var imageEditor = obj as SfImageEditor;
            if (imageEditor == null) return;
            imageEditor.Crop(new Rect());
            SelectedIndex = 6;
        }

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

    public class CustomCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        Action<object> commandAction;
        public CustomCommand(Action<object> action)
        {
            commandAction = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                commandAction(parameter);
            }
        }
    }
}
