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
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Syncfusion.Windows.Tools;
using System.Windows;
using System.Windows.Controls;
using Syncfusion.SfSkinManager;
using System.Windows.Media;

namespace ColorPickerDemo
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            isCheckedCommand = new DelegateCommand<object>(PropertyChangedHandler);
            selectioChangedCommand = new DelegateCommand<object>(selectioChanged);
        }

        private ICommand colorChangedLogCommand;

        private ICommand isCheckedCommand;

        private ObservableCollection<string> eventlog = new ObservableCollection<string>();

        private ColorSelectionMode visualizationStyle;

        private Brush selectedBrush;

        public Brush SelectedBrush
        {
            get { return selectedBrush; }

            set
            {
                selectedBrush = value;
                OnPropertyChanged("SelectedBrush");
            }
        }
        public ColorSelectionMode VisualizationStyle
        {
            get { return visualizationStyle; }
            set
            {
                visualizationStyle = value;
                OnPropertyChanged("visualizationStyle");
            }
        }

        public ObservableCollection<string> EventLog
        {
            get { return eventlog; }
            set { eventlog = value; }
        }
        public ICommand IsCheckedCommand
        {
            get
            {
                return isCheckedCommand;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public void PropertyChangedHandler(object param)
        {
            if (param.ToString() == "RGB")
            {
                VisualizationStyle = ColorSelectionMode.RGB;
            }
            else
            {
                VisualizationStyle = ColorSelectionMode.HSV;
            }
        }

        

    private ICommand selectioChangedCommand;

    public ICommand SelectioChangedCommand
    {
        get
        {
            return selectioChangedCommand;
        }
    }
    public void selectioChanged(object param)
    {
        WindowCollection windows = Application.Current.Windows;
        if (windows.Count > 0)
        {
            Window samplewindow = windows[0];
            ComboBox combo = param as ComboBox;
            if (combo != null)
            {
                if (combo.SelectedItem != null)
                {
                    ComboBoxItem item = combo.SelectedItem as ComboBoxItem;
                    SfSkinManager.SetVisualStyle(samplewindow, (VisualStyles)Enum.Parse(typeof(VisualStyles), item.Content.ToString()));
                }
            }
        }
    }
}
}
