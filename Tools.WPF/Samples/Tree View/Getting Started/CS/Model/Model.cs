#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows;
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using Syncfusion.Windows.Tools.Controls;

namespace TreeViewAdvConfigurationDemo
{
    public class Model : NotificationObject
    {
        public Model()
        {
            models = new ObservableCollection<Model>();
            
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        

        private ObservableCollection<Model> models;
        public ObservableCollection<Model> Models
        {
            get
            {
                return models;
            }

            set
            {
                models = value;
            }
        }

       

        #region TreeViewItemAdv Properties

        private string header;
        /// <summary>
        /// Gets or sets a value indicating the Header of the TreeViewItemAdv.
        /// </summary>        
        public string Header
        {
            get
            {
                return header;
            }

            set
            {
                header = value;
                this.RaisePropertyChanged(() => this.Header);
            }
        }      

        private bool isExpaned;
        /// <summary>
        /// Gets or sets a value indicating whether the TreeViewItemAdv is expanded.
        /// </summary>        
        public bool IsExpanded
        {
            get
            {
                return isExpaned;
            }

            set
            {
                isExpaned = value;
                this.RaisePropertyChanged(() => this.IsExpanded);
            }
        }

        private bool isEditable = true;
        /// <summary>
        /// Gets or sets a value indicating whether the TreeViewItemAdv is editable.
        /// </summary>        
        public bool IsEditable
        {
            get
            {
                return isEditable;
            }
            set
            {
                isEditable = value;
                this.RaisePropertyChanged(() => this.IsEditable);
            }
        }

        #endregion        
    }

    public class CountToVisibilityConverter : IValueConverter
    {

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((int)value == 0)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
