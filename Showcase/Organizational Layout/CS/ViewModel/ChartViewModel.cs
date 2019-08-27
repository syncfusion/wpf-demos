#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OrganizationalChartDemo
{
    public class ChartViewModel : INotifyPropertyChanged, IDisposable
    {
        public ChartViewModel()
        {
            NodeCollection = new DiagramCollection<OrgNodeViewModel>();
            Connections = new DiagramCollection<OrgConnectorViewModel>();
            Searchview = new SearchViewModel();
        }

        #region Variables
        private ICommand _search;
        private Visibility searchvisibility = Visibility.Collapsed;
        private ICommand _movepre;
        private ICommand _movenext;
        internal IEnumerator<OrgNodeViewModel> Item;
        internal delegate void FilterChanged();

        #endregion

        #region Properties
        
        private Visibility textWaterMark = Visibility.Visible;
        private Visibility comboWaterMark = Visibility.Visible;
        private string filterSelection = "Search";
        private string filterOption = "Name";
        private object _selected;
        private string filterText = string.Empty;
        private string filterCondition;

        public Visibility TextWaterMark
        {
            get
            {
                return textWaterMark;
            }
            set
            {
                if (textWaterMark != value)
                {
                    textWaterMark = value;
                    OnPropertyChanged("TextWaterMark");
                }
            }

        }      

        public Visibility ComboboxWaterMark
        {
            get
            {
                return comboWaterMark;
            }
            set
            {
                if (comboWaterMark != value)
                {
                    comboWaterMark = value;
                    OnPropertyChanged("ComboboxWaterMark");
                }
            }

        }

        public Employee Modeldata
        {
            get;
            set;
        }

        public SearchViewModel Searchview
        {
            get;
            set;
        }

        public DiagramCollection<OrgConnectorViewModel> Connections
        {
            get;
            set;
        }

        public DiagramCollection<OrgNodeViewModel> NodeCollection
        {
            get;
            set;
        }
      
        public string FilterSelection
        {
            get
            {
                return filterSelection;
            }
            set
            {
                filterSelection = value;
                OnPropertyChanged("FilterSelection");
            }
        }
       
        public string FilterOption
        {
            get { return filterOption; }
            set
            {
                filterOption = value;
                OnPropertyChanged("FilterOption");
                CreatenewSearch();
            }
        }      

        public string FilterText
        {
            get { return filterText; }
            set
            {
                filterText = value;
                OnPropertyChanged("FilterText");
            }
        }       

        public string FilterCondition
        {
            get { return filterCondition; }
            set
            {
                filterCondition = value;
                OnPropertyChanged("FilterCondition");
                CreatenewSearch();
            }
        }
       
        public object SelectedObject
        {
            get
            {
                return _selected;
            }
            set
            {
                if (_selected != value)
                {
                    _selected = value;
                    if (_selected != null)
                    {
                        ((_selected as OrgNodeViewModel).Content as Employee).IsFocus = NodeFocusState.Focused;
                    }
                    OnPropertyChanged("SelectedObject");
                }
            }
        }

        #endregion

        #region Commands

        public object ScrollViewer
        {
            get;
            set;
        }

        private ICommand textchanged;

        public ICommand TextChanged
        {
            get { return new DelegateCommand<object>(TextChangeEvent, args => true); }
            set { textchanged = value; OnPropertyChanged("TextChanged"); }
        }

        public ICommand salarychanged;

        public ICommand SalaryChanged
        {
            get { return new DelegateCommand<object>(SalaryChangeEvent, args => true); }
            set { salarychanged = value; OnPropertyChanged("SalaryChanged"); }
        }

        public ICommand designationchanged;

        public ICommand DesignationChanged
        {
            get { return new DelegateCommand<object>(DesignationChangeEvent, args => true); }
            set { designationchanged = value; OnPropertyChanged("DesignationChanged"); }
        }

        public ICommand ComboChanged
        {
            get { return new DelegateCommand<object>(ComboxChangedEvent, args => { return true; }); }
        }

        public ICommand FilterComboChanged
        {
            get { return new DelegateCommand<object>(FilterComboxChangedEvent, args => { return true; }); }
        }

        public ICommand Search
        {
            get
            {
                return _search;
            }
            set
            {
                if (_search != value)
                {
                    _search = value;
                    OnPropertyChanged("Search");
                }
            }
        }
        public Visibility SearchVisibility
        {
            get
            {
                return searchvisibility;
            }
            set
            {
                if (searchvisibility != value)
                {
                    searchvisibility = value;
                    OnPropertyChanged("SearchVisibility");
                }
            }
        }
        public ICommand Previous
        {
            get
            {
                return _movepre;
            }
            set
            {
                if (_movepre != value)
                {
                    _movepre = value;
                    OnPropertyChanged("Previous");
                }
            }
        }
        public ICommand Next
        {
            get
            {
                return _movenext;
            }
            set
            {
                if (_movenext != value)
                {
                    _movenext = value;
                    OnPropertyChanged("Next");
                }
            }
        } 

        private void FilterComboxChangedEvent(object pram)
        {
            if (pram != null)
            {
                if ((pram as ComboBox).SelectedItem != null)
                {
                    ComboboxWaterMark = Visibility.Collapsed;
                    this.FilterOption = ((pram as ComboBox).SelectedItem as ComboBoxItem).Content.ToString();
                    this.Item = null;
                    foreach(OrgNodeViewModel  b in NodeCollection)
                    {
                        if (((b as OrgNodeViewModel).Content as Employee).IsFocus==NodeFocusState.Focused || ((b as OrgNodeViewModel).Content as Employee).IsSearched ==true)
                        {
                            ((b as OrgNodeViewModel).Content as Employee).IsFocus = NodeFocusState.Normal;
                            ((b as OrgNodeViewModel).Content as Employee).IsSearched = false;                          
                        }                     
                    }
                }
                else
                {
                    (pram as ComboBox).SelectedIndex = 0;
                }
            }
        }

        private void ComboxChangedEvent(object pram)
        {
            if (pram != null)
            {
                this.FilterCondition = (pram as ComboBoxItem).Content.ToString();
            }
        }

        private void TextChangeEvent(object pram)
        {
            if (pram != null)
            {
                TextWaterMark = Visibility.Collapsed;
                this.FilterText = pram.ToString();
             
                this.Item = null;
                foreach (OrgNodeViewModel b in NodeCollection)
                {
                    if (((b as OrgNodeViewModel).Content as Employee).IsFocus == NodeFocusState.Focused || ((b as OrgNodeViewModel).Content as Employee).IsSearched == true)
                    {
                        ((b as OrgNodeViewModel).Content as Employee).IsFocus = NodeFocusState.Normal;
                        ((b as OrgNodeViewModel).Content as Employee).IsSearched = false;
                    }
                }
                StartSearch();
            }
        }

        private void SalaryChangeEvent(object param)
        {
            if(param!=null)
            {
                this.FilterText =param.ToString();
                this.Item = null;
                foreach (OrgNodeViewModel b in NodeCollection)
                {
                    if (((b as OrgNodeViewModel).Content as Employee).IsFocus == NodeFocusState.Focused || ((b as OrgNodeViewModel).Content as Employee).IsSearched == true)
                    {
                        ((b as OrgNodeViewModel).Content as Employee).IsFocus = NodeFocusState.Normal;
                        ((b as OrgNodeViewModel).Content as Employee).IsSearched = false;
                    }
                }
                StartSearch();
            }
        }

        private void DesignationChangeEvent(object prm)
        {
            if(prm!=null)
            {
                this.FilterText = prm.ToString();
                this.Item = null;
                foreach (OrgNodeViewModel b in NodeCollection)
                {
                    if (((b as OrgNodeViewModel).Content as Employee).IsFocus == NodeFocusState.Focused || ((b as OrgNodeViewModel).Content as Employee).IsSearched == true)
                    {
                        ((b as OrgNodeViewModel).Content as Employee).IsFocus = NodeFocusState.Normal;
                        ((b as OrgNodeViewModel).Content as Employee).IsSearched = false;
                    }
                }
                StartSearch();
            }
        }

        #endregion     

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }      

        internal void StartSearch()
        {
            this.Searchview.UpdateSearch(this.NodeCollection, this.Connections, this.FilterText, this.FilterOption, this.FilterSelection);
        }

        public void Dispose()
        {
           
        }

        private void CreatenewSearch()
        {
            Searchview = new SearchViewModel();
        }       
    }

    public class DelegateCommand<T> : ICommand
    {
        private Predicate<T> _canExecute;
        private Action<T> _method;
        bool _canExecuteCache = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="method">The method.</param>
        public DelegateCommand(Action<T> method)
            : this(method, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="canExecute">The can execute.</param>
        public DelegateCommand(Action<T> method, Predicate<T> canExecute)
        {
            _method = method;
            _canExecute = canExecute;
        }

        public DelegateCommand(ICommand Clicked, Predicate<object> predicate)
        {
            // TODO: Complete member initialization
            this.Clicked = Clicked;
            this.predicate = predicate;
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
            {
                bool tempCanExecute = _canExecute((T)parameter);

                if (_canExecuteCache != tempCanExecute)
                {
                    _canExecuteCache = tempCanExecute;
                    if (CanExecuteChanged != null)
                    {
                        CanExecuteChanged(this, new EventArgs());
                    }
                }
            }

            return _canExecuteCache;

        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            if (_method != null)
                _method.Invoke((T)parameter);
        }

        #region ICommand Members

        public event EventHandler CanExecuteChanged;
        private ICommand Clicked;
        private Predicate<object> predicate;

        #endregion
    }
}
