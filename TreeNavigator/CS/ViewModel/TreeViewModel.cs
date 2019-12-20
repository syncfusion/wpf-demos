#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Controls.Navigation;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SfTreeNavigator
{
    public class TreeViewModel : INotifyPropertyChanged
    {
        private List<TreeModel> models;

        public List<TreeModel> Models
        {
            get
            {
                return models;
            }
            set
            {
                models = value;
                OnPropertyChanged("Models");
            }
        }

        public TreeViewModel()
        {
            Models = new List<TreeModel>();
            comboBoxItemsSource = styleName.ToList();
        }

        private object selecteditem;

        public object SelectedItem
        {
            get
            {
                return selecteditem;
            }
            set
            {
                selecteditem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        private object navigationmode = NavigationMode.Extended;

        public object Navigationmode
        {
            get
            {
                return navigationmode;
            }
            set
            {
                navigationmode = value;
                OnPropertyChanged("NaVigationMode");
            }
        }

        private List<string> comboBoxItemsSource = new List<string>();

        public List<string> ComboBoxItemsSource
        {
            get
            {
                return comboBoxItemsSource;
            }
            set
            {
                comboBoxItemsSource = value;
            }
        }

        private static string[] styleName = new string[] {
                "Default",
                "Office2016Colorful",
                "Office2016DarkGray",
                "Office2016White",
                "Office365",
                "Office2013DarkGray",
                "Office2013LightGray",
                "Office2013White",
                "Office2010Black",
                "Office2010Blue",
                "Office2010Silver",
                "VisualStudio2015",
                "VisualStudio2013",
                "SystemTheme",
                "Metro",
                "Blend",
                "Lime",
                "Saffron"
        };

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
