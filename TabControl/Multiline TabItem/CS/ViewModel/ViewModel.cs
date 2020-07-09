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
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultilineTabItems
{
    public  class ViewModel:NotificationObject
    {
        private ObservableCollection<Model> tabItems;
        public ObservableCollection<Model> TabItems
        {
            get { return tabItems; }
            set
            {
                tabItems = value;
                this.RaisePropertyChanged("TabItems");
            }
        }
        private ObservableCollection<Model> multiline_Tabitems;
        public ObservableCollection<Model> Multiline_Tabitems
        {
            get { return multiline_Tabitems; }
            set
            {
                multiline_Tabitems = value;
                this.RaisePropertyChanged("Multiline_Tabitems");
            }
        }

        public ViewModel()
        {
            tabItems = new ObservableCollection<Model>();
            Multiline_Tabitems = new ObservableCollection<Model>();
            PopulateCollection();
        }

        public void PopulateCollection()
        {
            Model models1= new Model()
            {
                Header = "Tab1",
                Content = "This is the content of first tabitem."
            };
            Model models2 = new Model()
            {
                Header = "Tab2",
                Content = "This is the content of second tabitem."
            };
            Model models3 = new Model()
            {
                Header = "Tab3",
                Content = "This is the content of third tabitem."
            };
            Model models4 = new Model()
            {
                Header = "Tab4",
                Content = "This is the content of fourth tabitem."
            };
            Model models5 = new Model()
            {
                Header = "Tab5",
                Content = "This is the content of fifth tabitem."
            };
            Model models6 = new Model()
            {
                Header = "Tab6",
                Content = "This is the content of sixth tabitem."
            };
            Model models7 = new Model()
            {
                Header = "Tab7",
                Content = "This is the content of seventh tabitem."
            };
            Model models8 = new Model()
            {
                Header = "Tab8",
                Content = "This is the content of eighth tabitem."
            };
            Model model1 = new Model()
            {
                Header = "tab1",
                Content = "This is the content of first tabitem."
            };
            Model model2 = new Model()
            {
                Header = "tab2",
                Content = "This is the content of second tabitem."
            };
            Model model3 = new Model()
            {
                Header = "tab3",
                Content = "This is the content of Third tabitem."
            };
            Model model4 = new Model()
            {
                Header = "tab4",
                Content = "This is the content of Fourth tabitem."
            };
            Model model5 = new Model()
            {
                Header = "tab5",
                Content = "This is the content of Fifth tabitem."
            };
            Model model6 = new Model()
            {
                Header = "tab6",
                Content = "This is the content of Sixth tabitem."
            };
            Model model7 = new Model()
            {
                Header = "tab7",
                Content = "This is the content of sevenh tabitem."
            };
            Model model8 = new Model()
            {
                Header = "tab8",
                Content = "This is the content of eighth tabitem."
            };
            Model model9 = new Model()
            {
                Header = "tab9",
                Content = "This is the content of nineth tabitem."
            };
            Model model10 = new Model()
            {
                Header = "tab10",
                Content = "This is the content of Tenth tabitem."
            };
            Model model11 = new Model()
            {
                Header = "tab11",
                Content = "This is the content of Eleventh tabitem."
            };
            Model model12 = new Model()
            {
                Header = "tab12",
                Content = "This is the content of Twelth tabitem."
            };
            Model model13 = new Model()
            {
                Header = "tab13",
                Content = "This is the content of Thirteenth tabitem."
            };
            Model model14 = new Model()
            {
                Header = "tab14",
                Content = "This is the content of Fourteenth tabitem."
            };
            Model model15 = new Model()
            {
                Header = "tab15",
                Content = "This is the content of Fifteenth tabitem."
            };
            Model model16 = new Model()
            {
                Header = "tab16",
                Content = "This is the content of Sixteenth tabitem."
            };
            Model model17 = new Model()
            {
                Header = "tab17",
                Content = "This is the content of seventeenth tabitem."
            };
            Model model18 = new Model()
            {
                Header = "tab18",
                Content = "This is the content of eightteenth tabitem."
            };
            Model model19 = new Model()
            {
                Header = "tab19",
                Content = "This is the content of nineteenth tabitem."
            };
            Model model20 = new Model()
            {
                Header = "tab20",
                Content = "This is the content of tweentyth tabitem."
            };

            //Adding the tab tems into the collection
            tabItems.Add(model1);
            tabItems.Add(model2);
            tabItems.Add(model3);
            tabItems.Add(model4);
            tabItems.Add(model5);
            tabItems.Add(model6);
            tabItems.Add(model7);
            tabItems.Add(model8);
            tabItems.Add(model9);
            tabItems.Add(model10);
            tabItems.Add(model11);
            tabItems.Add(model12);
            tabItems.Add(model13);
            tabItems.Add(model14);
            tabItems.Add(model15);
            tabItems.Add(model16);
            tabItems.Add(model17);
            tabItems.Add(model18);
            tabItems.Add(model19);
            tabItems.Add(model20);
            Multiline_Tabitems.Add(models1);
            Multiline_Tabitems.Add(models2);
            Multiline_Tabitems.Add(models3);
            Multiline_Tabitems.Add(models4);
            Multiline_Tabitems.Add(models5);
            Multiline_Tabitems.Add(models6);
            Multiline_Tabitems.Add(models7);
            Multiline_Tabitems.Add(models8);
        }
    }
}
