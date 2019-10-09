#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using RibbonSample.OptionTabContent;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RibbonSample
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            DisplayTabContent = new DisplayTabContent();
            GeneralTabContent = new GeneralTabContent();
            PopulateCollection();
            //BackStageColor = Brushes.Green;
            IsQATBelow = false;
        }

        //private Brush backStageColor;

        //public Brush BackStageColor
        //{
        //    get
        //    {
        //        return backStageColor;
        //    }
        //    set
        //    {
        //        backStageColor = value;
        //        RaisePropertyCahnged("BackStageColor");
        //    }
        //}

        public DisplayTabContent DisplayTabContent
        {
            get;
            set;
        }

        public GeneralTabContent GeneralTabContent
        {
            get;
            set;
        }

        private ObservableCollection<OptionTab> _optionTabs;
        public ObservableCollection<OptionTab> OptionTabsCollection
        {
            get
            {
                return _optionTabs;
            }
            set
            {
                _optionTabs = value;
                RaisePropertyCahnged("OptionTabsCollection");
            }
        }

        private bool isQATBelow;

        public bool IsQATBelow
        {
            get
            {
                return isQATBelow;

            }
            set
            {
                isQATBelow = value;
                RaisePropertyCahnged("IsQATBelow");
            }
        }


        public void PopulateCollection()
        {

            OptionTabsCollection = new ObservableCollection<OptionTab>();

            OptionTab generalTab = new OptionTab() { Header = "General", Content = GeneralTabContent, TabPosition = TabPosition.Above };
            OptionTab displayTab = new OptionTab() { Header = "Display", Content = DisplayTabContent, TabPosition = TabPosition.Above };
            
            OptionTabsCollection.Add(generalTab);
            OptionTabsCollection.Add(displayTab);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyCahnged(string propertyname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
