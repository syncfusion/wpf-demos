#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using syncfusion.diagrambackstage.wpf;

namespace syncfusion.workfloweditor.wpf
{
  public  class ProcessAutomationViewModel:DiagramCommonViewModel
    {
      private object _selected;

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
                  OnPropertyChanged("SelectedObject");
              }
          }
      }

      private bool isplay=true;

      public bool IsPlay
      {
          get
          {
              return isplay;
          }
          set
          {
              if (isplay != value)
              {
                  isplay = value;
                  OnPropertyChanged("IsPlay");
              }
          }
      }
      private bool issadded;
      public bool IsStartAdded
      {
          get
          {
              return issadded;
          }
          set
          {
              if (issadded != value)
              {
                  issadded = value;
                  OnPropertyChanged("IsStartAdded");
              }
          }
      }

      private bool iseadded;
      public bool IsEndAdded
      {
          get
          {
              return iseadded;
          }
          set
          {
              if (iseadded != value)
              {
                  iseadded = value;
                  OnPropertyChanged("IsEndAdded");
              }
          }
      }
      private ICommand m_Back;

      public ICommand Back
      {
          get { return m_Back; }
          set
          {
              if (m_Back != value)
              {
                  m_Back = value;
                  OnPropertyChanged("Back");
              }
          }
      }

      private ICommand _mplay;

      public ICommand Play
      {
          get
          {
              return _mplay;
          }
          set
          {
              if (_mplay != value)
              {
                  _mplay = value;
                  OnPropertyChanged("Play");
              }
          }
      }
      private ICommand m_GoBack;

      public ICommand GoBack
      {
          get { return m_GoBack; }
          set
          {
              if (m_GoBack != value)
              {
                  m_GoBack = value;
                  OnPropertyChanged("GoBack");
              }
          }
      }
      private Visibility m_DiagramVisibility = Visibility.Collapsed;

      public new Visibility DiagramVisibility
      {
          get { return m_DiagramVisibility; }
          set
          {
              if (m_DiagramVisibility != value)
              {
                  m_DiagramVisibility = value;
                  OnPropertyChanged("DiagramVisibility");
              }
          }
      }
      private string m_CurrentlyLoaded;

      public string CurrentlyLoaded
      {
          get { return m_CurrentlyLoaded; }
          set
          {
              if (m_CurrentlyLoaded != value)
              {
                  m_CurrentlyLoaded = value;
                  OnPropertyChanged("CurrentlyLoaded");
              }
          }
      }
    
      private ICommand m_Save;

      public ICommand Save
      {
          get { return m_Save; }
          set
          {
              if (m_Save != value)
              {
                  m_Save = value;
                  OnPropertyChanged("Save");
              }
          }
      }

      private ICommand m_Load;

      public ICommand Load
      {
          get { return m_Load; }
          set
          {
              if (m_Load != value)
              {
                  m_Load = value;
                  OnPropertyChanged("Load");
              }
          }
      }

      private ICommand m_Create;

      public new ICommand Create
      {
          get { return m_Create; }
          set
          {
              if (m_Create != value)
              {
                  m_Create = value;
                  OnPropertyChanged("Create");
              }
          }
      }

      private ICommand _mdelete;

      public ICommand Delete
      {
          get
          {
              return _mdelete;
          }
          set
          {
              if (_mdelete != value)
              {
                  _mdelete = value;
                  OnPropertyChanged("Delete");
              }
          }
      }

      private ICommand _mclear;

      public ICommand Clear
      {
          get
          {
              return _mclear;
          }
          set
          {
              if (_mclear != value)
              {
                  _mclear = value;
                  OnPropertyChanged("Clear");
              }
          }
      }

        private bool _mIsItemEnabled = true;

        public bool IsItemEnabled
        {
            get
            {
                return _mIsItemEnabled;
            }
            set
            {
                if (_mIsItemEnabled != value)
                {
                    _mIsItemEnabled = value;
                    OnPropertyChanged("IsItemEnabled");
                }
            }
        }
    }
}
