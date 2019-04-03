#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;

namespace ObservableCollectionBindingDemo
{  

    public class SportsViewModel:INotifyPropertyChanged
    {
       
        public SportsViewModel()
        {
            this.Sports = new ObservableCollection<SportDataModel>();
            this.Sports.Add(new SportDataModel() { SportID = 102, SportName = "Cricket", CandidatesCount = 31 });
            this.Sports.Add(new SportDataModel() { SportID = 103, SportName = "Hockey", CandidatesCount = 15 });
            this.Sports.Add(new SportDataModel() { SportID = 104, SportName = "Football", CandidatesCount = 7 });
            this.Sports.Add(new SportDataModel() { SportID = 105, SportName = "Atheletics", CandidatesCount = 3 });
            this.Sports.Add(new SportDataModel() { SportID = 106, SportName = "Tennis", CandidatesCount = 10 });
            this.Sports.Add(new SportDataModel() { SportID = 107, SportName = "Baseball", CandidatesCount = 6 });
            this.Sports.Add(new SportDataModel() { SportID = 108, SportName = "Basketball", CandidatesCount = 10 });
        }
        public ObservableCollection<SportDataModel> Sports
        {
            get;
            set;
        }

        private ICommand mAdd;
        public ICommand AddCommand
        {
            get
            {
                if (mAdd == null)
                    mAdd = new Add(this);
                return mAdd;
            }
            set
            {
                mAdd = value;
            }
        }

        private ICommand mEdit;
        public ICommand EditCommand
        {
            get
            {
                if (mEdit == null)
                    mEdit = new Edit(this);
                return mEdit;
            }
            set
            {
                mEdit = value;
            }
        }
        private Visibility _grpbxvisibility = Visibility.Collapsed;
        public Visibility GrpBoxVisibility
        {
            get
            {
                return _grpbxvisibility;
            }
            set
            {
                _grpbxvisibility = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("GrpBoxVisibility"));
            }
        }
        private ICommand mOk;
        public ICommand OkCommand
        {
            get
            {
                if (mOk == null)
                    mOk = new Ok(this);
                return mOk;
            }
            set
            {
                mOk = value;
            }
        }
        private bool _isediting=false;
        public bool IsEditing
        {
            get
            {
                return _isediting;
            }
            set
            {
                _isediting = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("IsEditing"));
            }
        }
        private ICommand mCancel;
        public ICommand CancelCommand
        {
            get
            {
                if (mCancel == null)
                    mCancel = new Cancel(this);
                return mCancel;
            }
            set
            {
                mCancel = value;
            }
        }
        private ICommand mRemove;
        public ICommand RemoveCommand
        {
            get
            {
                if (mRemove == null)
                    mRemove = new Remove(this);
                return mRemove;
            }
            set
            {
                mRemove = value;
            }
        }

        private SportDataModel _selecteditem;
        public SportDataModel Selecteditem
        {
            get
            {
                if (_selecteditem == null)
                    _selecteditem = new SportDataModel();
                return _selecteditem;
            }
            set
            {
                _selecteditem = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("Selecteditem"));
            }
        }
        private class Add : ICommand
        {
            #region ICommand Members
            public SportsViewModel spmo
            {
                get;
                set;
            }
            const int id = 108;
            int index = 0;
            public Add(SportsViewModel sportsmodel)
            {
                this.spmo = sportsmodel;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                this.spmo.Selecteditem = new SportDataModel() {SportID=0, SportName= "None", CandidatesCount=0 };
                this.spmo.GrpBoxVisibility = Visibility.Visible;
                this.spmo.IsEditing = false;
            }

            

            #endregion
        }

        private class Ok : ICommand
        {
            #region ICommand Members
            public SportsViewModel spmo
            {
                get;
                set;
            }
            const int id = 108;
            int index = 0;
            public Ok(SportsViewModel sportsmodel)
            {
                this.spmo = sportsmodel;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                if (!this.spmo.IsEditing)
                {
                    SportDataModel spt = this.spmo.Selecteditem;
                    this.spmo.Sports.Add(spt);
                }
                               
                
                this.spmo.GrpBoxVisibility = Visibility.Collapsed;
            }



            #endregion
        }
        private class Cancel : ICommand
        {
            #region ICommand Members
            public SportsViewModel spmo
            {
                get;
                set;
            }
            const int id = 108;
            int index = 0;
            public Cancel(SportsViewModel sportsmodel)
            {
                this.spmo = sportsmodel;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {

                this.spmo.GrpBoxVisibility = Visibility.Collapsed;
            }



            #endregion
        }
        private class Edit : ICommand
        {
            #region ICommand Members
            public SportsViewModel spmo
            {
                get;
                set;
            }
            public Edit(SportsViewModel spomod)
            {
                this.spmo = spomod;
            }
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                this.spmo.GrpBoxVisibility = Visibility.Visible;
                this.spmo.IsEditing = true;
            }

            #endregion
        }

        private class Remove : ICommand
        {
            #region ICommand Members
             public SportsViewModel spmo
            {
                get;
                set;
            }
            public Remove(SportsViewModel Sm)
            {
                this.spmo = Sm;
            }
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                this.spmo.Sports.Remove(this.spmo.Selecteditem);       
            }

            #endregion
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, args);
        }
        #endregion
    }

}

