using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Collections;

namespace CheckedComboBoxDemo
{
   class ViewModel : NotificationObject
    {

        private ObservableCollection<string> eventLogsCollection;

        public ObservableCollection<string> EventLogsCollection
        {
            get { return eventLogsCollection; }
            set
            {
                eventLogsCollection = value;
                this.RaisePropertyChanged(() => this.EventLogsCollection);
            }
        }
        ObservableCollection<string> coll = new ObservableCollection<string>();
        //public ParameterConverter Multiconverter = new ParameterConverter();

        private ObservableCollection<Country> countries;
         public ObservableCollection<Country> Countries
        {
            get { return countries; }
            set {
                 countries = value;
                this.RaisePropertyChanged(() => this.Countries);
            }
        }

         private bool multiselect=true ;
         public bool MultiSelect
         {
             get
             {
                 return multiselect;
             }
             set
             {
                 multiselect = value;
                 this.RaisePropertyChanged(() => this.MultiSelect);
             }

         }
         private object selectedValue;
         public object SelectedValue
         {
             get
             {
                 return selectedValue;
             }
             set
             {
                 selectedValue = value;
                 this.RaisePropertyChanged(() => this.SelectedValue);
             }

         }

        private ICommand dropDownOpenedCommand;
        public ICommand
           DropDownOpenedCommand
        {
            get
            {
                 if (dropDownOpenedCommand == null)
                {
                    dropDownOpenedCommand = new DelegateCommand<object>(DropDownOpened);
                }
                return dropDownOpenedCommand;
            }
        }
       private ICommand dropDownClosedCommand;
        public ICommand
           DropDownClosedCommand
        {
            get
            {
                 if (dropDownClosedCommand == null)
                {
                    dropDownClosedCommand = new DelegateCommand<object>(DropDownClosed);
                }
                return dropDownClosedCommand;
            }
        }
        private ICommand addItemCommand;
        public ICommand
           AddItemCommand
        {
            get
            {
                if (addItemCommand == null)
                {
                    addItemCommand = new DelegateCommand<object>(AddItem);
                }
                return addItemCommand;
            }
        }

        private ICommand selectionChangedCommand;
        public ICommand
           SelectionChangedCommand
        {
            get
            {
                if (selectionChangedCommand == null)
                {
                    selectionChangedCommand = new DelegateCommand<object>(SelectionChagned);
                }
                return selectionChangedCommand;
            }
        }
        public ViewModel()
        {

            Countries = Initailize();

        }

        public void AddItem(object param)
        {

            Countries.Add(param as Country);
        }

        public ObservableCollection<Country> Initailize()
        {
            ObservableCollection<Country> countries1= new ObservableCollection<Country>();
          countries1.Add(new Country()
            {
                Name = "United Kindom",
                Code = "UK"
            });
          countries1.Add(new Country()
            {
                Name = "Canada",
                Code = "CA"
            });

          countries1.Add(new Country()
            {
                Name = "Germany",
                Code = "DE"
            });
          countries1.Add(new Country()
            {
                Name = "India",
                Code = "IN"
            });
          countries1.Add(new Country()
            {
                Name = "Ukraine",
                Code = "UA"
            });
          return countries1;
        }

        public void SelectionChagned(object param)
        {
            if (MultiSelect && param != null)
            {

                string s = "";
                foreach (object item in (IEnumerable)param)
                {
                    s = s + (item as Country).Code + ",";
                }
                AddLog("Selection changed  : " + s);
            }
            else
                AddLog("Selection changed  : " + SelectedValue);
        }
        public void DropDownOpened(object param)
        {
             AddLog("Drop Down Opened");


        }
        public void DropDownClosed(object param)
        {
             AddLog("Drop Down Closed");


        }
        private void AddLog(string eventlog)
        {
            coll.Add(eventlog);
            EventLogsCollection = coll;
        }

   
}
}
