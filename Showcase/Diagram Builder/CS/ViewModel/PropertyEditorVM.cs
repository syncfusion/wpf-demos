#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DiagramBuilder.Utility;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DiagramBuilder.ViewModel
{
    public interface IPropertyEditor : INotifyPropertyChanged
    {
        string Title { get; set; }
        string Icon { get; set; }
        UIElement Content { get; set; }
        ICommand Select { get; set; }
        bool IsSelected { get; set; }
        //string Name { get; set; }
    }

    public class PropertyEditorVM : DiagramElementViewModel, IPropertyEditor
    {
        private string _mTitle;
        private string _mIcon;
        private UIElement _mContent;
        private ICommand _mSelect;
        private bool _mIsSelected;
        //private string _mname;
        public PropertyEditorVM()
        {
            Select = new Command(param => IsSelected = true);
        }

        public string Title
        {
            get { return _mTitle; }
            set
            {
                if (_mTitle != value)
                {
                    _mTitle = value; OnPropertyChanged("Title");
                }
            }
        }

        public string Icon
        {
            get
            {
                return _mIcon;
            }
            set
            {
                if (_mIcon != value)
                {
                    _mIcon = value;
                    OnPropertyChanged("Icon");
                }
            }
        }

        public UIElement Content
        {
            get
            {
                return _mContent;
            }
            set
            {
                if (_mContent != value)
                {
                    _mContent = value;
                    OnPropertyChanged("Content");
                }
            }
        }

        public ICommand Select
        {
            get
            {
                return _mSelect;
            }
            set
            {
                if (_mSelect != value)
                {
                    _mSelect = value;
                    OnPropertyChanged("Select");
                }
            }
        }

        public bool IsSelected
        {
            get
            {
                return _mIsSelected;
            }
            set
            {
                if (_mIsSelected != value)
                {
                    _mIsSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }

        //public string Name
        //{
        //    get { return _mname; }
        //    set
        //    {
        //        if (_mname != value)
        //        {
        //            _mname = value; OnPropertyChanged("Name");
        //        }
        //    }
        //}
    }

    public class ContentPresenters : ContentPresenter
    {

        public ContentPresenters()
        {
            
        }

        public Brush Foreground
        {
            get { return (Brush)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Foreground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.Register("Foreground", typeof(Brush), typeof(ContentPresenters), new PropertyMetadata(new SolidColorBrush(Colors.DarkGray)));

      
    }
}
