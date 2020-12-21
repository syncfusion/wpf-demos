#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Windows.Shared;

namespace syncfusion.navigationdemos.wpf
{
    public class MultilineTabitemViewModel : NotificationObject
    {
        private ObservableCollection<MultilineTabitemModel> tabItems;
        public ObservableCollection<MultilineTabitemModel> TabItems
        {
            get { return tabItems; }
            set
            {
                tabItems = value;
                this.RaisePropertyChanged("TabItems");
            }
        }
        private ObservableCollection<MultilineTabitemModel> multiline_Tabitems;
        public ObservableCollection<MultilineTabitemModel> Multiline_Tabitems
        {
            get { return multiline_Tabitems; }
            set
            {
                multiline_Tabitems = value;
                this.RaisePropertyChanged("Multiline_Tabitems");
            }
        }

        public MultilineTabitemViewModel()
        {
            tabItems = new ObservableCollection<MultilineTabitemModel>();
            Multiline_Tabitems = new ObservableCollection<MultilineTabitemModel>();
            PopulateCollection();
        }

        public void PopulateCollection()
        {
            MultilineTabitemModel models1 = new MultilineTabitemModel()
            {
                Header = "Tab1",
                Content = "This is the content of first tabitem."
            };
            MultilineTabitemModel models2 = new MultilineTabitemModel()
            {
                Header = "Tab2",
                Content = "This is the content of second tabitem."
            };
            MultilineTabitemModel models3 = new MultilineTabitemModel()
            {
                Header = "Tab3",
                Content = "This is the content of third tabitem."
            };
            MultilineTabitemModel models4 = new MultilineTabitemModel()
            {
                Header = "Tab4",
                Content = "This is the content of fourth tabitem."
            };
            MultilineTabitemModel models5 = new MultilineTabitemModel()
            {
                Header = "Tab5",
                Content = "This is the content of fifth tabitem."
            };
            MultilineTabitemModel models6 = new MultilineTabitemModel()
            {
                Header = "Tab6",
                Content = "This is the content of sixth tabitem."
            };
            MultilineTabitemModel models7 = new MultilineTabitemModel()
            {
                Header = "Tab7",
                Content = "This is the content of seventh tabitem."
            };
            MultilineTabitemModel models8 = new MultilineTabitemModel()
            {
                Header = "Tab8",
                Content = "This is the content of eighth tabitem."
            };
            MultilineTabitemModel model1 = new MultilineTabitemModel()
            {
                Header = "tab1",
                Content = "This is the content of first tabitem."
            };
            MultilineTabitemModel model2 = new MultilineTabitemModel()
            {
                Header = "tab2",
                Content = "This is the content of second tabitem."
            };
            MultilineTabitemModel model3 = new MultilineTabitemModel()
            {
                Header = "tab3",
                Content = "This is the content of Third tabitem."
            };
            MultilineTabitemModel model4 = new MultilineTabitemModel()
            {
                Header = "tab4",
                Content = "This is the content of Fourth tabitem."
            };
            MultilineTabitemModel model5 = new MultilineTabitemModel()
            {
                Header = "tab5",
                Content = "This is the content of Fifth tabitem."
            };
            MultilineTabitemModel model6 = new MultilineTabitemModel()
            {
                Header = "tab6",
                Content = "This is the content of Sixth tabitem."
            };
            MultilineTabitemModel model7 = new MultilineTabitemModel()
            {
                Header = "tab7",
                Content = "This is the content of sevenh tabitem."
            };
            MultilineTabitemModel model8 = new MultilineTabitemModel()
            {
                Header = "tab8",
                Content = "This is the content of eighth tabitem."
            };
            MultilineTabitemModel model9 = new MultilineTabitemModel()
            {
                Header = "tab9",
                Content = "This is the content of nineth tabitem."
            };
            MultilineTabitemModel model10 = new MultilineTabitemModel()
            {
                Header = "tab10",
                Content = "This is the content of Tenth tabitem."
            };
            MultilineTabitemModel model11 = new MultilineTabitemModel()
            {
                Header = "tab11",
                Content = "This is the content of Eleventh tabitem."
            };
            MultilineTabitemModel model12 = new MultilineTabitemModel()
            {
                Header = "tab12",
                Content = "This is the content of Twelth tabitem."
            };
            MultilineTabitemModel model13 = new MultilineTabitemModel()
            {
                Header = "tab13",
                Content = "This is the content of Thirteenth tabitem."
            };
            MultilineTabitemModel model14 = new MultilineTabitemModel()
            {
                Header = "tab14",
                Content = "This is the content of Fourteenth tabitem."
            };
            MultilineTabitemModel model15 = new MultilineTabitemModel()
            {
                Header = "tab15",
                Content = "This is the content of Fifteenth tabitem."
            };
            MultilineTabitemModel model16 = new MultilineTabitemModel()
            {
                Header = "tab16",
                Content = "This is the content of Sixteenth tabitem."
            };
            MultilineTabitemModel model17 = new MultilineTabitemModel()
            {
                Header = "tab17",
                Content = "This is the content of seventeenth tabitem."
            };
            MultilineTabitemModel model18 = new MultilineTabitemModel()
            {
                Header = "tab18",
                Content = "This is the content of eightteenth tabitem."
            };
            MultilineTabitemModel model19 = new MultilineTabitemModel()
            {
                Header = "tab19",
                Content = "This is the content of nineteenth tabitem."
            };
            MultilineTabitemModel model20 = new MultilineTabitemModel()
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